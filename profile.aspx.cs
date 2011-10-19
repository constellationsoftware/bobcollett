using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class profile : System.Web.UI.Page
{
    siteUsers objSiteUsers = new siteUsers();
    public string message = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
            Response.Redirect("login.aspx");
        if (Request.QueryString["uid"] == null)
        {
            Response.Redirect("desktop.aspx");
        }
        if (Request.QueryString["uid"] != null)
        {
            if(Request.QueryString["uid"].ToString() != Session["userid"].ToString())
            {
                Response.Redirect("desktop.aspx");
            }
        }
        if (!IsPostBack)
        {
            
            if (Request.QueryString["uid"] != null)
            {
                DataTable dt = objSiteUsers.getUserById(int.Parse(Request.QueryString["uid"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    txtemail.Text = dt.Rows[0]["email"].ToString();
                   
                    ddTitle.ClearSelection();
                    ddTitle.Items.FindByValue(dt.Rows[0]["title"].ToString()).Selected = true;
                    txtfname.Text = dt.Rows[0]["firstname"].ToString();
                    txtSurname.Text = dt.Rows[0]["lastname"].ToString();
                    txtPhone.Text = dt.Rows[0]["phone"].ToString();
                    txtAddress1.Text = dt.Rows[0]["address1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["address2"].ToString();
                   // txtPhone.Text = dt.Rows[0]["postalcode"].ToString();
                    txtCounty.Text = dt.Rows[0]["county"].ToString();
                    txtCountry.Text = dt.Rows[0]["country"].ToString();
                    txtPostal.Text = dt.Rows[0]["Postalcode"].ToString();
                }

            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        //Save the content
        if (Request.QueryString["uid"] != null)
        {
            try
            {
                if (objSiteUsers.IsEmailExistsForUpdate(txtemail.Text, int.Parse(Request.QueryString["uid"].ToString())))
                {
                    // Email exists, not able to add user.
                    message = "Email Id already exists.";
                }
                else
                {
                    if (objSiteUsers.updateUserWithoutPwd(txtemail.Text,ddTitle.SelectedItem.Value, 4, txtfname.Text, txtSurname.Text, txtPhone.Text, txtAddress1.Text, txtAddress2.Text, txtPostal.Text, txtCounty.Text, txtCountry.Text, int.Parse(Request.QueryString["uid"].ToString())))
                    {
                        message = "User has been updated successfully.";
                    }
                    else
                    {
                        message = "Unable to update user.";
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Unable to update user.";
            }
        }
        
    }
}