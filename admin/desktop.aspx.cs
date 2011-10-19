using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_desktop : System.Web.UI.Page
{
    public string FullName;
    siteUsers objuser = new siteUsers(); 
    protected void Page_Load(object sender, EventArgs e)
    {       
        if(Session["AdminUserId"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            FullName = objuser.GetDetail(Convert.ToInt32(Session["AdminUserId"].ToString())); 
        }
    }
}