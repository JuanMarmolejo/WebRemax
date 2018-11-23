using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pruebas : System.Web.UI.Page
{
    HouseList resHouses = new HouseList();
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "";
        txtBath.Text = Request.Form["cboBath"];
        txtBed.Text = Request.Form["cboBed"];
        txtCity.Text = Request.Form["cboCity"];
        txtPrice.Text = Request.Form["cboPrice"];
        txtType.Text = Request.Form["cboType"];
        txtYear.Text = Request.Form["cboYear"];

        resHouses.RecoverHouses(txtBath.Text, txtBed.Text, txtCity.Text, txtPrice.Text, txtType.Text, txtYear.Text);

        foreach (House hs in resHouses.Elements)
        {
            sql += hs.Price + " ";
        }
        lblsql.Text = sql;
    }
}