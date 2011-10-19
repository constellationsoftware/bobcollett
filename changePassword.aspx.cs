using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class changePassword : System.Web.UI.Page
{
    public string uMessage = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
            Response.Redirect("login.aspx");
        if (!Page.IsPostBack)
        {
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        siteUsers objSiteUsers = new siteUsers();
        DataTable dsUsers = objSiteUsers.getUserById(int.Parse(Session["userid"].ToString()));
        if (dsUsers.Rows.Count > 0)
        {
            string oldPassword = dsUsers.Rows[0]["Password"].ToString();
            if (oldPassword == txtOldPassword.Text)
            {
                if(objSiteUsers.updatePassword(txtPassword.Text,int.Parse(Session["userid"].ToString())))
                {
                    uMessage = "Password has been updated successfully.";
                }
                else
                {
                    uMessage = "Unable to update password.";
                }
            }
            else
            {
                uMessage = "Old password does not matched.";
            }

        }
        else
        {
            uMessage = "Authentication fails.";
        }

    }
}