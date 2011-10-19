using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_users : System.Web.UI.Page
{
    public string message = string.Empty;
    siteUsers objSiteUsers = new siteUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if(!Page.IsPostBack)
        {
            if (Request.QueryString["uid"] != null)
            {
                DataTable dt = objSiteUsers.getUserById(int.Parse(Request.QueryString["uid"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    txtEmail.Text = dt.Rows[0]["email"].ToString();
                    txtPassword.Text = dt.Rows[0]["password"].ToString();
                    try{
                    }
                    catch(Exception XE)
                    {
                    }

                    ddUserType.ClearSelection();
                    ddUserType.Items.FindByValue(dt.Rows[0]["roleid"].ToString()).Selected = true;
                    txtfname.Text = dt.Rows[0]["firstname"].ToString();
                    txtlastname.Text =  dt.Rows[0]["lastname"].ToString();
                    txtPhone.Text= dt.Rows[0]["phone"].ToString();
                    txtAddress1.Text= dt.Rows[0]["address1"].ToString();
                    txtAddress2.Text= dt.Rows[0]["address2"].ToString();
                    txtPhone.Text= dt.Rows[0]["postalcode"].ToString();
                    txtCounty.Text= dt.Rows[0]["county"].ToString();
                    txtCountry.Text= dt.Rows[0]["country"].ToString();
                    try{
                        ddTitle.ClearSelection();
                    ddTitle.Items.FindByValue(dt.Rows[0]["title"].ToString()).Selected = true;
                    }
                    catch(Exception EX)
                    {
                    }
                    
                }

            }
        }
    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        
        if (Request.QueryString["uid"] != null)
        {
            try
            {
                if (objSiteUsers.IsEmailExistsForUpdate(txtEmail.Text, int.Parse(Request.QueryString["uid"].ToString())))
                {
                    // Email exists, not able to add user.
                    message = "Email Id already exists.";
                }
                else
                {
                    if (objSiteUsers.updateUser(txtEmail.Text, txtPassword.Text, int.Parse(ddUserType.SelectedItem.Value), txtfname.Text, txtlastname.Text, txtPhone.Text, txtAddress1.Text, txtAddress2.Text, txtPostal.Text, txtCounty.Text, txtCountry.Text,ddTitle.SelectedItem.Value, int.Parse(Request.QueryString["uid"].ToString())))
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
                message = "Unable to add user.";
            }
        }
        else
        {
            try
            {
                if (objSiteUsers.IsEmailExists(txtEmail.Text))
                {
                    // Email exists, not able to add user.
                    message = "Email Id alreay exists.";
                }
                else
                {
                    if (objSiteUsers.addUser(txtEmail.Text, txtPassword.Text, int.Parse(ddUserType.SelectedItem.Value),txtfname.Text,txtlastname.Text,txtPhone.Text,txtAddress1.Text,txtAddress2.Text,txtPostal.Text,txtCounty.Text,txtCountry.Text,ddTitle.SelectedItem.Value) > 0)
                    {
                        // User added successfully.
                        message = "User has been added successfully.";
                    }
                    else
                    {
                        // Unable to add user.
                        message = "Unable to add user.";
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Unable to add user.";
            }
        }
    }
}