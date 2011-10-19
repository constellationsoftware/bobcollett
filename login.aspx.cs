using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class login : System.Web.UI.Page
{
    public string uMessage = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uMessage"] != null)
            uMessage = Session["uMessage"].ToString();
        if (!Page.IsPostBack)
        {
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        siteUsers objSiteUsers = new siteUsers();
        DataTable dsUsers = objSiteUsers.AuthenticateSiteUser(txtEmail.Text, txtPassword.Text);
        if (dsUsers.Rows.Count > 0)
        {
            Session["userid"] = dsUsers.Rows[0]["UserId"].ToString();
            Response.Redirect("desktop.aspx");

        }
        else
        {
            uMessage = "Invalid username or password.";
        }

    }
}