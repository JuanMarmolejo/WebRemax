using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Client
/// </summary>
public class Client : Person
{
    private int vRefClient;
    private ClientType vClientType;
    private int vRefAgent;
    private HouseList vHouses;

    public Client()
    {
        Houses = new HouseList();
    }

    public Client(string vFirstName, string vLastName, DateTime vBirthDate, string vPhoneNumber, string vEmail, ClientType vClientType, int vRefAgent) :
        base(vFirstName, vLastName, vBirthDate, vPhoneNumber, vEmail)
    {
        this.ClientType = vClientType;
        this.RefAgent = vRefAgent;
    }

    public int RefClient { get => vRefClient; set => vRefClient = value; }
    public ClientType ClientType { get => vClientType; set => vClientType = value; }
    public HouseList Houses { get => vHouses; set => vHouses = value; }
    public int RefAgent { get => vRefAgent; set => vRefAgent = value; }

    internal void CopyDataRow(DataRow myRow)
    {
        vRefClient = Convert.ToInt32(myRow["RefClient"]);
        FirstName = myRow["FirstName"].ToString();
        LastName = myRow["LastName"].ToString();
        BirthDate = Convert.ToDateTime(myRow["BirthDate"]);
        PhoneNumber = myRow["PhoneNumber"].ToString();
        Email = myRow["Email"].ToString();
        vRefAgent = Convert.ToInt32(myRow["RefAgent"]);
        vClientType = (ClientType)Enum.Parse(typeof(ClientType), myRow["ClientType"].ToString());
    }

    internal void LoadHouses()
    {
        Houses.HousesOfSellers(RefClient);
    }

    internal string AgentName()
    {
        return DataSource.AgentName(RefClient);
    }

    internal void ModifyClientDB(int current)
    {
        DataTable myTb = DataSource.AllClients();
        DataRow myRow = null;
        myRow = myTb.Rows[current];

        myRow["FirstName"] = FirstName;
        myRow["LastName"] = LastName;
        myRow["BirthDate"] = BirthDate;
        myRow["PhoneNumber"] = PhoneNumber;
        myRow["Email"] = Email;
        myRow["ClientType"] = vClientType;
        myRow["RefAgent"] = vRefAgent;

        DataSource.UpdateClients(myTb);
    }

    internal void InsertClientDB()
    {
        DataTable myTb = DataSource.AllClients();
        DataRow myRow = null;
        myRow = myTb.NewRow();

        //myRow["RefClient"] = DBNull.Value;
        myRow["FirstName"] = FirstName;
        myRow["LastName"] = LastName;
        myRow["BirthDate"] = BirthDate;
        myRow["PhoneNumber"] = PhoneNumber;
        myRow["Email"] = Email;
        myRow["ClientType"] = vClientType;
        myRow["RefAgent"] = vRefAgent;

        myTb.Rows.Add(myRow);

        DataSource.UpdateClients(myTb);
    }
}