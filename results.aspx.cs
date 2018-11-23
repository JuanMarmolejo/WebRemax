using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class results : System.Web.UI.Page
{
    HouseList resHouses = new HouseList();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string txtBath = Request.Form["cboBath"];
        string txtBed = Request.Form["cboBed"];
        string txtCity = Request.Form["cboCity"];
        string txtPrice = Request.Form["cboPrice"];
        string txtType = Request.Form["cboType"];
        string txtYear = Request.Form["cboYear"];

        resHouses.RecoverHouses(txtBath, txtBed, txtCity, txtPrice, txtType, txtYear);
        
    }

    public void displayHouses()
    {
        foreach (House hs in resHouses.Elements)
        {
            Response.Write("<div class='col-4'><span class='image fit'><a href = 'housepage.aspx?RefHouse=" + hs.RefHouse + "' ><img src = 'images/" + hs.Facade + "'></a>");
            Response.Write("<ul class='alt'><li>" + hs.City + "<br />");
            Response.Write(hs.Bathrooms + " <i class='fa fa-bath fa-2x' aria-hidden='true'></i>");
            Response.Write(hs.Bedrooms + " <i class='fa fa-bed fa-2x' aria-hidden='true'></i>");
            Response.Write("</li><li><span style = 'font-weight: bold;' > " + hs.Price + " $</span>");
            Response.Write("<br />" + hs.PropertyType + "</li></ul></span></div>");
            
        }
    }
}