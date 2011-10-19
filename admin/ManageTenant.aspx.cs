using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ManageTenant : System.Web.UI.Page
{
    Tenant objtenant = new Tenant(); 
    public string rootPath = System.Configuration.ConfigurationManager.AppSettings["rootPath"].ToString();
    public string message = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUserId"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!this.IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        this.gvUsers.DataSource = objtenant.GetTenants();  
        this.gvUsers.DataBind();
        if (this.gvUsers.Rows.Count == 0)
            message = "No Tenants found.";

    }


    protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // find our image control on the current row we are on
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        //  get the gridviewrow from the sender so we can get the datakey we need
        try
        {
            ImageButton btnDelete = sender as ImageButton;

            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            int TenantId = int.Parse(btnDelete.CommandArgument);
            if (objtenant.DeleteTenantById(TenantId))
            {
                message = "Tenant has been deleted successfully.";
            }
            else
            {
                message = "Unable to delete Tenant.";
            }
        }
        catch (Exception ex)
        {
        }

        BindData();
        ///-- you delete Method here

    }

    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BindData();
    }
    protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}