using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class housepage : System.Web.UI.Page
{
    Employee curAgent = new Employee();
    House curHouse = new House();
    protected void Page_Load(object sender, EventArgs e)
    {
        string refHouse = Request.QueryString["RefHouse"];

        curHouse.HouseByReference(refHouse);
        curAgent.AgentByRefHouse(refHouse);
    }

    public House House { get => curHouse; }
    public Employee Agent { get => curAgent; }
}