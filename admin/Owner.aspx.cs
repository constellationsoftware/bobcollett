using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_Owner : System.Web.UI.Page
{
    public string message = string.Empty;
    Owner objowner = new Owner();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuserid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["oid"] != null)
            {
                DataTable dt = objowner.GetOwnerById(int.Parse(Request.QueryString["oid"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    txtownername.Text = dt.Rows[0]["owner"].ToString();
                }

            }
        }
    }


    protected void txtSubmit_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["oid"] != null)
        {
            try
            {

                if (objowner.updateOwner(txtownername.Text, int.Parse(Request.QueryString["oid"].ToString())))
                {
                    message = "Owner has been updated successfully.";
                }
                else
                {
                    message = "Unable to update Owner.";
                }

            }
            catch (Exception ex)
            {
                message = "Unable to update Owner.";
            }
        }
        else
        {
            try
            {

                if (objowner.AddOwner(txtownername.Text) > 0)
                {
                    // Portfolio added successfully.
                    message = "Owner has been added successfully.";
                }
                else
                {
                    // Unable to add Portfolio.
                    message = "Unable to add Owner.";
                }

            }
            catch (Exception ex)
            {
                message = "Unable to add Owner.";
            }
        }

    }
}
