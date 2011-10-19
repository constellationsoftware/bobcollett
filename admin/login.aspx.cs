using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_login : System.Web.UI.Page
{
    public string message = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { }
        if (Session["logout"] != null)
        {
            message = "You are successfully logout from system.";
            Session["logout"] = null;
        }
    }
    protected void txtLogin_Click(object sender, EventArgs e)
    {
        siteUsers objSiteUsers = new siteUsers();
      DataTable dsUsers =  objSiteUsers.AuthenticateUser(txtUsername.Text,txtPassword.Text);
        if(dsUsers.Rows.Count>0)
        {
            Session["AdminUserId"] = dsUsers.Rows[0]["UserId"].ToString();
            Response.Redirect("desktop.aspx");
            
        }
        else
        {
            message = "Authentication fails.";
        }
    }
}