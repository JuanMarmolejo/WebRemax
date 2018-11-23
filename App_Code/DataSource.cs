using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for DataSource
/// </summary>
public class DataSource
{
    public static OleDbConnection myCon;
    public static DataSet mySet;
    public static OleDbDataAdapter adpEmmployees;
    public static OleDbDataAdapter adpClients;
    public static OleDbDataAdapter adpHouses;

    public static void StartData()
    {
        StartConnection();


        OleDbCommand mycmd = new OleDbCommand("SELECT * FROM Employees", myCon);

        adpEmmployees = new OleDbDataAdapter(mycmd);

        mySet = new DataSet();
        adpEmmployees.Fill(mySet, "Employees");

        OleDbCommand mycmd2 = new OleDbCommand("SELECT * FROM Clients", myCon);
        adpClients = new OleDbDataAdapter(mycmd2);
        adpClients.Fill(mySet, "Clients");

        OleDbCommand mycmd3 = new OleDbCommand("SELECT * FROM Houses", myCon);
        adpHouses = new OleDbDataAdapter(mycmd3);
        adpHouses.Fill(mySet, "Houses");

        mySet.Relations.Add(new DataRelation("EC", mySet.Tables["Employees"].Columns["RefEmployee"], mySet.Tables["Clients"].Columns["RefAgent"]));
        mySet.Relations.Add(new DataRelation("CH", mySet.Tables["Clients"].Columns["RefClient"], mySet.Tables["Houses"].Columns["RefClient"]));
    }

    internal static void UpdateMsgs(int refAgent, int refHouse, string phone, string msg)
    {
        StartConnection();
        string sql = "INSERT INTO Sendmail (RefAgent, RefHouse, Phone, Msg) " +
            "VALUES(" + refAgent + ", " + refHouse + ", '" + phone + "', '" + msg + "')";

        OleDbCommand myCmd = new OleDbCommand(sql, myCon);
        myCmd.ExecuteNonQuery();

    }
    
    internal static DataRow AgentByRefHouse(string refHouse)
    {
        StartConnection();
        String sql = "SELECT Employees.* FROM((Clients INNER JOIN Employees ON Clients.RefAgent = Employees.RefEmployee) " +
            "INNER JOIN Houses ON Clients.RefClient = Houses.RefClient) WHERE(Houses.RefHouse = @RefHouse)";

        OleDbCommand myCmd = new OleDbCommand(sql, myCon);
        myCmd.Parameters.AddWithValue("@RefHouse", refHouse);
        OleDbDataAdapter adp = new OleDbDataAdapter(myCmd);

        DataSet mySet = new DataSet();
        adp.Fill(mySet);

        return mySet.Tables[0].Rows[0];
    }

    internal static DataRow HouseByReference(string refHouse)
    {
        StartConnection();
        String sql = "SELECT Houses.* FROM Houses WHERE(RefHouse = @RefHouse)";

        OleDbCommand myCmd = new OleDbCommand(sql, myCon);
        myCmd.Parameters.AddWithValue("@RefHouse", refHouse);
        OleDbDataAdapter adp = new OleDbDataAdapter(myCmd);
        
        DataSet mySet = new DataSet();
        adp.Fill(mySet);

        return mySet.Tables[0].Rows[0];
    }

    internal static DataTable OrderbyBedroom()
    {
        StartConnection();
        String sql = "SELECT DISTINCT Bedrooms FROM Houses ORDER BY Bedrooms";

        OleDbCommand myCmd = new OleDbCommand(sql, myCon);
        OleDbDataAdapter adp = new OleDbDataAdapter(myCmd);

        DataSet mySet = new DataSet();
        adp.Fill(mySet);

        return mySet.Tables[0];
    }

    internal static DataTable OrderbyCity()
    {
        StartConnection();
        String sql = "SELECT DISTINCT City FROM Houses ORDER BY City";

        OleDbCommand myCmd = new OleDbCommand(sql, myCon);
        OleDbDataAdapter adp = new OleDbDataAdapter(myCmd);

        DataSet mySet = new DataSet();
        adp.Fill(mySet);

        return mySet.Tables[0];
    }

    internal static DataTable AllHouses(string sql)
    {
        try
        {
            StartConnection();
            
            OleDbCommand myCmd = new OleDbCommand(sql, myCon);
            OleDbDataAdapter adp = new OleDbDataAdapter(myCmd);

            DataSet vSet = new DataSet();
            adp.Fill(vSet);

            return vSet.Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal static DataTable OrderbyPrice()
    {
        StartConnection();
        String sql = "SELECT DISTINCT Price FROM Houses ORDER BY Price";

        OleDbCommand myCmd = new OleDbCommand(sql, myCon);
        OleDbDataAdapter adp = new OleDbDataAdapter(myCmd);

        DataSet mySet = new DataSet();
        adp.Fill(mySet);

        return mySet.Tables[0];
    }

    internal static DataTable OrderbyBathroom()
    {
        StartConnection();
        String sql = "SELECT DISTINCT Bathrooms FROM Houses ORDER BY Bathrooms";

        OleDbCommand myCmd = new OleDbCommand(sql, myCon);
        OleDbDataAdapter adp = new OleDbDataAdapter(myCmd);

        DataSet mySet = new DataSet();
        adp.Fill(mySet);

        return mySet.Tables[0];
    }

    internal static DataTable OrderbyYear()
    {
        
            StartConnection();
            String sql = "SELECT DISTINCT ConstructionYear FROM Houses ORDER BY ConstructionYear";
        
            OleDbCommand myCmd = new OleDbCommand(sql, myCon);
            OleDbDataAdapter adp = new OleDbDataAdapter(myCmd);
        
            DataSet mySet = new DataSet();
            adp.Fill(mySet);

            return mySet.Tables[0];
        
    }

    internal static void UpdateHouses(DataTable myTb)
    {
        OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(adpHouses);
        adpHouses.Update(myTb);
    }

    internal static DataTable AllSellers()
    {
        string expression = "ClientType = '" + ClientType.Seller + "'";
        DataRow[] myRows = mySet.Tables["Clients"].Select(expression);
        DataTable myResult = mySet.Tables["Clients"].Clone();
        foreach (DataRow rw in myRows)
        {
            myResult.ImportRow(rw);
        }
        return myResult;
    }

    internal static DataTable HousesOfSellers(int refClient)
    {
        string expression = "RefClient = " + refClient;
        DataRow[] myRows = mySet.Tables["Houses"].Select(expression);
        DataTable myResult = mySet.Tables["Houses"].Clone();
        foreach (DataRow rw in myRows)
        {
            myResult.ImportRow(rw);
        }
        return myResult;
    }

    public static DataTable AllHouses()
    {
        return mySet.Tables["Houses"];
    }

    internal static DataTable AllAgents()
    {
        string expression = "Role = '" + Role.Agent + "'";
        DataRow[] myRows = mySet.Tables["Employees"].Select(expression);
        DataTable myResult = mySet.Tables["Employees"].Clone();
        foreach (DataRow rw in myRows)
        {
            myResult.ImportRow(rw);
        }
        return myResult;
    }

    internal static string AgentName(int refClient)
    {
        try
        {
            StartConnection();
            String sql = "SELECT Employees.FirstName, Employees.LastName " +
            "FROM(Clients INNER JOIN Employees ON Clients.RefAgent = Employees.RefEmployee) " +
            "WHERE(Clients.RefClient = @refClient)";

            OleDbCommand myCmd = new OleDbCommand(sql, myCon);
            myCmd.Parameters.AddWithValue("@refClient", refClient);
            OleDbDataAdapter adpAgentName = new OleDbDataAdapter(myCmd);

            DataSet mySet = new DataSet();
            adpAgentName.Fill(mySet);

            DataRow myrw = mySet.Tables[0].Rows[0];

            return myrw["FirstName"].ToString() + " " + myrw["LastName"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal static DataTable ClientsByAgent(int refEmployee)
    {
        string expression = "RefAgent = " + refEmployee;
        DataRow[] myRows = mySet.Tables["Clients"].Select(expression);
        DataTable myResult = mySet.Tables["Clients"].Clone();
        foreach (DataRow rw in myRows)
        {
            myResult.ImportRow(rw);
        }
        return myResult;
    }

    internal static DataTable AllClients()
    {
        return mySet.Tables["Clients"];
    }

    internal static void UpdateEmployees(DataTable myTb)
    {
        OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(adpEmmployees);
        adpEmmployees.Update(myTb);
    }

    internal static void UpdateClients(DataTable myTb)
    {
        OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(adpClients);
        adpClients.Update(myTb);
    }

    internal static DataTable AllEmployees()
    {
        return mySet.Tables["Employees"];
    }

    internal static DataTable EmployeeByUsername(string Username)
    {
        try
        {
            StartConnection();
            String sql = "SELECT Employees.* FROM Employees WHERE(UserName = @Username)";

            OleDbCommand myCmd = new OleDbCommand(sql, myCon);
            myCmd.Parameters.AddWithValue("@Username", Username);
            adpEmmployees = new OleDbDataAdapter(myCmd);

            DataSet mySet = new DataSet();
            adpEmmployees.Fill(mySet);

            return mySet.Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private static void StartConnection()
    {
        myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='C:\Users\jcmarmolejo\Google Drive\La Salle\WebRemax\App_Data\prjRemaxDB.mdb';Persist Security Info=True");
        myCon.Open();
    }
}

