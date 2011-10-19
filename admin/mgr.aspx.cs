using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class admin_mgr : System.Web.UI.Page
{
    public string message = string.Empty;
    Mgr objmgr = new Mgr();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuserid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["mid"] != null)
            {
                DataTable dt = objmgr.GetMgrById(int.Parse(Request.QueryString["mid"].ToString()));  
                if (dt.Rows.Count > 0)
                {
                    txtmgrname.Text = dt.Rows[0]["mgr"].ToString();
                }

            }
        }
    }


    protected void txtSubmit_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["mid"] != null)
        {
            try
            {

                if (objmgr.updateMgr(txtmgrname.Text,int.Parse(Request.QueryString["mid"].ToString())))                    
                {
                    message = "Mgr has been updated successfully.";
                }
                else
                {
                    message = "Unable to update Mgr.";
                }

            }
            catch (Exception ex)
            {
                message = "Unable to update Mgr.";
            }
        }
        else
        {
            try
            {

                if (objmgr.AddMgr(txtmgrname.Text) > 0)  
                {
                    // Portfolio added successfully.
                    message = "Mgr has been added successfully.";
                }
                else
                {
                    // Unable to add Portfolio.
                    message = "Unable to add Mgr.";
                }

            }
            catch (Exception ex)
            {
                message = "Unable to add Mgr.";
            }
        }

    }
}
