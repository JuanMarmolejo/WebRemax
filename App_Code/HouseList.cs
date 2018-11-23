using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HouseList
/// </summary>
public class HouseList
{
    private List<House> myList;

    public HouseList()
    {
        myList = new List<House>();
    }

    public int Quantity
    {
        get => myList.Count;
    }

    public List<House> Elements
    {
        get => myList;
    }

    public void RecoverHouses()
    {
        DataTable tbHouses;
        House myHou;
        myList = new List<House>();

        tbHouses = DataSource.AllHouses();
        foreach (DataRow myRow in tbHouses.Rows)
        {
            myHou = new House();
            myHou.CopyDataRow(myRow);
            myList.Add(myHou);
        }
    }

    public void RecoverHouses(string txtBath, string txtBed, string txtCity, string txtPrice, string txtType, string txtYear)
    {
        bool flag = true;
        string sql = "SELECT *  FROM Houses";

        if (txtBath != "0")
        {
            sql += " WHERE (Bathrooms >= " + txtBath + ")";
            flag = false;
        }
        if (txtBed != "0")
        {
            sql += flag ? " WHERE" : " AND";
            sql += " (Bedrooms >= " + txtBed + ")";
            flag = false;
        }
        if (txtCity != "0")
        {
            sql += flag ? " WHERE" : " AND";
            sql += " (City = '" + txtCity + "')";
            flag = false;
        }
        if (txtPrice != "0")
        {
            sql += flag ? " WHERE" : " AND";
            sql += " (Price <= " + txtPrice + ")";
            flag = false;
        }
        if (txtType != "0")
        {
            sql += flag ? " WHERE" : " AND";
            sql += " (PropertyType = '" + txtType + "')";
            flag = false;
        }
        if (txtYear != "0")
        {
            sql += flag ? " WHERE" : " AND";
            sql += " (ConstructionYear >= " + txtYear + ")";
            flag = false;
        }

        DataTable tbHouses;
        House myHou;
        myList = new List<House>();

        tbHouses = DataSource.AllHouses(sql);
        foreach (DataRow myRow in tbHouses.Rows)
        {
            myHou = new House();
            myHou.CopyDataRow(myRow);
            myList.Add(myHou);
        }
    }

    public object OrderbyCity()
    {
        DataTable tbHouses;
        List<string> tmpList = new List<string>();

        tbHouses = DataSource.OrderbyCity();
        foreach (DataRow myRow in tbHouses.Rows)
        {
            tmpList.Add(myRow["City"].ToString());
        }
        return tmpList;
    }

    public object OrderbyBedroom()
    {
        DataTable tbHouses;
        List<string> tmpList = new List<string>();

        tbHouses = DataSource.OrderbyBedroom();
        foreach (DataRow myRow in tbHouses.Rows)
        {
            tmpList.Add(myRow["Bedrooms"].ToString());
        }
        return tmpList;
    }

    public object OrderbyPrice()
    {
        DataTable tbHouses;
        List<string> tmpList = new List<string>();

        tbHouses = DataSource.OrderbyPrice();
        foreach (DataRow myRow in tbHouses.Rows)
        {
            tmpList.Add(myRow["Price"].ToString());
        }
        return tmpList;
    }

    public object OrderbyBathroom()
    {
        DataTable tbHouses;
        List<string> tmpList = new List<string>();

        tbHouses = DataSource.OrderbyBathroom();
        foreach (DataRow myRow in tbHouses.Rows)
        {
            tmpList.Add(myRow["Bathrooms"].ToString());
        }
        return tmpList;
    }

    public List<string> OrderbyYear()
    {
        DataTable tbHouses;
        List<string> tmpList = new List<string>();
        
        tbHouses = DataSource.OrderbyYear();
        foreach (DataRow myRow in tbHouses.Rows)
        {   
            tmpList.Add(myRow["ConstructionYear"].ToString());
        }
        return tmpList;
    }

    public House HouseAt(int current)
    {
        return myList.ElementAt<House>(current);
    }

    public void DeleteHouse(int current)
    {
        myList.RemoveAt(current);
        DataTable myTb = DataSource.AllHouses();
        myTb.Rows[current].Delete();
        DataSource.UpdateHouses(myTb);
    }

    public void Add(House newHou)
    {
        myList.Add(newHou);
        newHou.InsertHouseDB();
    }

    public void Modify(int current, House newHou)
    {
        myList[current] = newHou;
        newHou.ModifyHouseDB(current);
    }

    public void HousesOfSellers(int refClient)
    {
        DataTable tbHouses;
        House myHou;
        myList = new List<House>();

        tbHouses = DataSource.HousesOfSellers(refClient);
        foreach (DataRow myRow in tbHouses.Rows)
        {
            myHou = new House();
            myHou.CopyDataRow(myRow);
            myList.Add(myHou);
        }
    }
}