using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Company cia = new Company("Remax");

        HouseList myHouses = new HouseList();
        //myHouses.RecoverHouses();

        cboType.DataSource = Enum.GetValues(typeof(PropertyType));
        cboType.DataBind();
        cboType.Items.Insert(0, new ListItem("Property Type", "0"));

        cboYear.DataSource = myHouses.OrderbyYear();
        cboYear.DataBind();
        cboYear.Items.Insert(0, new ListItem("Year of construction - Minimum", "0"));

        cboCity.DataSource = myHouses.OrderbyCity();
        cboCity.DataBind();
        cboCity.Items.Insert(0, new ListItem("City", "0"));

        cboBath.DataSource = myHouses.OrderbyBathroom();
        cboBath.DataBind();
        cboBath.Items.Insert(0, new ListItem("Bathrooms - Minimum", "0"));

        cboBed.DataSource = myHouses.OrderbyBedroom();
        cboBed.DataBind();
        cboBed.Items.Insert(0, new ListItem("Bedrooms - Minimum", "0"));

        cboPrice.DataSource = myHouses.OrderbyPrice();
        cboPrice.DataBind();
        cboPrice.Items.Insert(0, new ListItem("Price - Maximum", "0"));
    }
}