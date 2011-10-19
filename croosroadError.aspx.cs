using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class croosroadError : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EncounteredException"] != null)
        {
            lblError.Text = Session["lblError"].ToString();
            Session["lblError"] = null;
        }
        else
        {
            Response.Redirect("deafult.aspx");
        }
    }
}