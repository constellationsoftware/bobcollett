using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_managePortfolio : System.Web.UI.Page
{
    Portfolio objPortfolio = new Portfolio();
    public string rootPath = System.Configuration.ConfigurationManager.AppSettings["rootPath"].ToString();
    public string message = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Adminuserid"] == null)
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
        this.gvPortfolio.DataSource = objPortfolio.GetPortfolio();
        this.gvPortfolio.DataBind();
        if (this.gvPortfolio.Rows.Count == 0)
            message = "No Portfolio found.";

    }

    protected void gvPortfolio_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // find our image control on the current row we are on
            Image myImage = e.Row.FindControl("MyImageControlID") as Image;
           
            if (myImage != null)
            {
                myImage.ImageUrl = "path to image here";
            }
           
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //  get the gridviewrow from the sender so we can get the datakey we need
        try
        {
            ImageButton btnDelete = sender as ImageButton;

            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            int PortfolioId = int.Parse(btnDelete.CommandArgument);
            if (objPortfolio.DeletePortfolioById(PortfolioId))
            {
                message = "Portfolio has been deleted successfully.";
            }
            else
            {
                message = "Unable to delete portfolio.";
            }
        }
        catch (Exception ex)
        {
        }

        BindData();
        ///-- you delete Method here

    }


    protected void gvPortfolio_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i;
        if (e.CommandName == "InActive")
        {
            // write code to update column to 0
            //if (objPortfolio.updateStatus(0, int.Parse(e.CommandArgument.ToString())))
            //{
            //    message = "User status has been updated successfully.";
            //}
            //else
            //{
            //    message = "Unable to update status of user.";
            //}
        }
        else if (e.CommandName == "Active")
        {
            //       write code  to update column to 1
            //if (objPortfolio.updateStatus(1, int.Parse(e.CommandArgument.ToString())))
            //{
            //    message = "User status has been updated successfully.";
            //}
            //else
            //{
            //    message = "Unable to update status of user.";
            //}
        }
        else if (e.CommandName == "Delete")
        {
        }
        BindData();
    }
    protected void gvPortfolio_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}