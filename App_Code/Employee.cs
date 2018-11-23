using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee : Person
{
    private int vRefEmployee;
    private string vUsername;
    private string vUserPassword;
    private Role vRole;
    private string vSex;
    private ClientList vClients;
    private string vPhoto;

    public int RefEmployee { get => vRefEmployee; set => vRefEmployee = value; }

    public void AgentByRefHouse(string refHouse)
    {
        DataRow myRow = DataSource.AgentByRefHouse(refHouse);

        CopyDataRow(myRow);
    }

    public string Username { get => vUsername; set => vUsername = value; }
    public string UserPassword { get => vUserPassword; set => vUserPassword = value; }
    public Role Role { get => vRole; set => vRole = value; }
    public string Sex { get => vSex; set => vSex = value; }
    public ClientList Clients { get => vClients; set => vClients = value; }
    public string Photo { get => vPhoto; set => vPhoto = value; }

    public Employee(string vFirstName, string vLastName, DateTime vBirthDate, string vPhoneNumber, string vEmail, string vUsername, string vUserPassword, Role vRole, string vSex) :
        base(vFirstName, vLastName, vBirthDate, vPhoneNumber, vEmail)
    {
        this.vUsername = vUsername;
        this.vUserPassword = vUserPassword;
        this.vRole = vRole;
        this.vSex = vSex;
        Clients = new ClientList();
    }

    public Employee(string vUsername, string vUserPassword, Role vRole, string vSex)
    {
        this.vUsername = vUsername;
        this.vUserPassword = vUserPassword;
        this.vRole = vRole;
        this.vSex = vSex;
    }

    public Employee()
    {
        Clients = new ClientList();
    }

    internal void RecoverUser(string Username)
    {
        DataTable myTb = DataSource.EmployeeByUsername(Username);

        try
        {
            this.CopyDataRow(myTb.Rows[0]);
        }
        catch (Exception ex)
        {
            ArgumentException Argex = new ArgumentException("Username or password is invalid", ex);
            throw Argex;
        }
    }

    internal void LoadClients()
    {
        Clients.ClientsByAgent(RefEmployee);
    }

    public void CopyDataRow(DataRow myRow)
    {
        vRefEmployee = Convert.ToInt32(myRow["RefEmployee"]);
        FirstName = myRow["FirstName"].ToString();
        LastName = myRow["LastName"].ToString();
        BirthDate = Convert.ToDateTime(myRow["BirthDate"]);
        PhoneNumber = myRow["PhoneNumber"].ToString();
        Email = myRow["Email"].ToString();
        vUsername = myRow["UserName"].ToString();
        vUserPassword = myRow["UserPassword"].ToString();
        vRole = (Role)Enum.Parse(typeof(Role), myRow["Role"].ToString());
        this.vSex = myRow["Sex"].ToString();
        Photo = myRow["Photo"].ToString();
    }

    internal bool Login(string text)
    {
        return (this.UserPassword == text);
    }

    internal void InsertEmployeeDB()
    {
        DataTable myTb = DataSource.AllEmployees();
        DataRow myRow = null;
        myRow = myTb.NewRow();

        //myRow["RefEmployee"] = null;
        myRow["FirstName"] = FirstName;
        myRow["LastName"] = LastName;
        myRow["BirthDate"] = BirthDate;
        myRow["PhoneNumber"] = PhoneNumber;
        myRow["Email"] = Email;
        myRow["UserName"] = Username;
        myRow["UserPassword"] = UserPassword;
        myRow["Role"] = Role;
        myRow["Sex"] = Sex;

        myTb.Rows.Add(myRow);

        DataSource.UpdateEmployees(myTb);
    }

    internal void ModifyEmployeeDB(int current)
    {
        DataTable myTb = DataSource.AllEmployees();
        DataRow myRow = null;
        myRow = myTb.Rows[current];

        myRow["FirstName"] = FirstName;
        myRow["LastName"] = LastName;
        myRow["BirthDate"] = BirthDate;
        myRow["PhoneNumber"] = PhoneNumber;
        myRow["Email"] = Email;
        myRow["UserName"] = Username;
        myRow["UserPassword"] = UserPassword;
        myRow["Role"] = Role;
        myRow["Sex"] = Sex;

        DataSource.UpdateEmployees(myTb);
    }
}