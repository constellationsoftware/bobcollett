using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Register : System.Web.UI.Page
{
    siteUsers objSiteUsers = new siteUsers();
    public string message = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetVerificationText();
            if (Request.QueryString["uid"] != null)
            {
                DataTable dt = objSiteUsers.getUserById(int.Parse(Request.QueryString["uid"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    txtemail.Text = dt.Rows[0]["email"].ToString();
                    txtPassword.Text = dt.Rows[0]["password"].ToString();
                    ddTitle.ClearSelection();
                    ddTitle.Items.FindByValue(dt.Rows[0]["title"].ToString()).Selected = true;
                    txtfname.Text = dt.Rows[0]["firstname"].ToString();
                    txtSurname.Text = dt.Rows[0]["lastname"].ToString();
                    txtPhone.Text = dt.Rows[0]["phone"].ToString();
                    txtAddress1.Text = dt.Rows[0]["address1"].ToString();
                    txtAddress2.Text = dt.Rows[0]["address2"].ToString();
                    txtPhone.Text = dt.Rows[0]["postalcode"].ToString();
                    txtCounty.Text = dt.Rows[0]["county"].ToString();
                    txtCountry.Text = dt.Rows[0]["country"].ToString();
                }

            }
        }

    }
    public void SetVerificationText()
    {
        Random ran = new Random();
        int no = ran.Next(999999);
        Session["Captcha"] = no.ToString();
    }
    protected void CAPTCHAValidate(object source, ServerValidateEventArgs args)
    {
        if (Session["Captcha"] != null)
        {
            if (txtVerify.Text != Session["Captcha"].ToString())
            {
                SetVerificationText();
                args.IsValid = false;
                return;
            }
        }
        else
        {
            SetVerificationText();
            args.IsValid = false;
            return;
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
                    if (objSiteUsers.updateUser(txtemail.Text, txtPassword.Text,4, txtfname.Text, txtSurname.Text, txtPhone.Text, txtAddress1.Text, txtAddress2.Text, txtPostal.Text, txtCounty.Text, txtCountry.Text,ddTitle.SelectedItem.Value, int.Parse(Request.QueryString["uid"].ToString())))
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
                if (objSiteUsers.IsEmailExists(txtemail.Text))
                {
                    // Email exists, not able to add user.
                    message = "Email Id alreay exists.";
                }
                else
                {
                    if (objSiteUsers.addUser(txtemail.Text, txtPassword.Text, 4, txtfname.Text, txtSurname.Text, txtPhone.Text, txtAddress1.Text, txtAddress2.Text, txtPostal.Text, txtCounty.Text, txtCountry.Text,ddTitle.SelectedItem.Value) > 0)
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
        SetVerificationText();
    }
}