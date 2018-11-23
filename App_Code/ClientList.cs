using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClientList
/// </summary>
public class ClientList
{
    private List<Client> myList;

    public ClientList()
    {
        myList = new List<Client>();
    }

    public int Quantity
    {
        get => myList.Count;
    }

    public List<Client> Elements
    {
        get => myList;
    }

    internal void RecoverClients()
    {
        DataTable tbClients;
        Client myCli;
        myList = new List<Client>();

        tbClients = DataSource.AllClients();
        foreach (DataRow myRow in tbClients.Rows)
        {
            myCli = new Client();
            myCli.CopyDataRow(myRow);
            myList.Add(myCli);
        }
    }

    internal Client ClientAt(int current)
    {
        try
        {
            return myList.ElementAt<Client>(current);
        }
        catch (Exception ex)
        {
            ArgumentException Argex = new ArgumentException("No customers found", ex);
            throw Argex;
        }

    }

    internal void Add(Client newCli)
    {
        myList.Add(newCli);
        newCli.InsertClientDB();
    }

    internal void RecoverSellers()
    {
        DataTable tbSellers;
        Client mySel;
        myList = new List<Client>();

        tbSellers = DataSource.AllSellers();
        foreach (DataRow myRow in tbSellers.Rows)
        {
            mySel = new Client();
            mySel.CopyDataRow(myRow);
            myList.Add(mySel);
        }
    }

    internal void Modify(int current, Client newCli)
    {
        myList[current] = newCli;
        newCli.ModifyClientDB(current);
    }

    internal void DeleteClient(int current)
    {
        myList.RemoveAt(current);
        DataTable myTb = DataSource.AllClients();
        myTb.Rows[current].Delete();
        DataSource.UpdateClients(myTb);
    }

    internal void ClientsByAgent(int refEmployee)
    {
        DataTable tbClients;
        Client myCli;
        myList = new List<Client>();

        tbClients = DataSource.ClientsByAgent(refEmployee);
        foreach (DataRow myRow in tbClients.Rows)
        {
            myCli = new Client();
            myCli.CopyDataRow(myRow);
            myList.Add(myCli);
        }
    }
}