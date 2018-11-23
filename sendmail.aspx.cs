using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sendmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int refAgent = Convert.ToInt32(Request.QueryString["refAgent"]);
        int refHouse = Convert.ToInt32(Request.QueryString["refHouse"]);
        string txtPhone = Request.Form["txtPhone"];
        string txtMessage = Request.Form["txtMessage"];

        Sendmail Sm = new Sendmail(refAgent, refHouse, txtPhone, txtMessage);
        Sm.UpdateMsg();

        Response.Redirect("index.aspx");
        
    }
}