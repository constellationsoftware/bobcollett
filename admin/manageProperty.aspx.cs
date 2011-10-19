using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_manageProperty : System.Web.UI.Page
{
    Property objProperty = new Property();
    propunit objpropunit = new propunit(); 
    public string rootPath = System.Configuration.ConfigurationManager.AppSettings["rootPath"].ToString();
    public string message = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuserid"] == null)
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
        this.gvProperty.DataSource = objProperty.GetProperties();
        this.gvProperty.DataBind();
        if (this.gvProperty.Rows.Count == 0)
            message = "No properties found.";

    }

    protected void gvProperty_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // find our image control on the current row we are on
            //Image myImage = e.Row.FindControl("MyImageControlID") as Image;
            //Label lblUserType = e.Row.FindControl("lblUserType") as Label;
            //if (lblUserType != null)
            //{
            //    if (lblUserType.Text == "1")
            //    {
            //        lblUserType.Text = "Admin";
            //    }
            //    else if (lblUserType.Text == "2")
            //    {
            //        lblUserType.Text = "Tenant";
            //    }
            //    else if (lblUserType.Text == "3")
            //    {
            //        lblUserType.Text = "Maintenance";
            //    }
            //    else if (lblUserType.Text == "4")
            //    {
            //        lblUserType.Text = "Accounts";
            //    }

            //}
            //if (myImage != null)
            //{
            //    myImage.ImageUrl = "path to image here";
            //}
            //ImageButton lnkshow = (ImageButton)e.Row.FindControl("btnActiveInActive");
            //if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "isActive").ToString()) == true)
            //{
            //    lnkshow.ImageUrl = rootPath + "/admin/images/status1.jpg";
            //    lnkshow.CommandName = "InActive";
            //    lnkshow.CommandArgument = lnkshow.AlternateText.ToString();
            //}
            //else
            //{
            //    lnkshow.ImageUrl = rootPath + "/admin/images/status3.jpg";
            //    lnkshow.CommandName = "Active";
            //    lnkshow.CommandArgument = lnkshow.AlternateText;
            //}
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //  get the gridviewrow from the sender so we can get the datakey we need
        try
        {
            ImageButton btnDelete = sender as ImageButton;

            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;

            int PropertyId = int.Parse(btnDelete.CommandArgument);
            if (objProperty.DeletePropertyById(PropertyId))
            {
                message = "Property has been deleted successfully.";
            }
            else
            {
                message = "Unable to delete property.";
            }
        }
        catch (Exception ex)
        {
        }

        BindData();
        ///-- you delete Method here

    }


    protected void gvProperty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i;
        //if (e.CommandName == "InActive")
        //{
        //     write code to update column to 0
        //    if (objProperty.updateStatus(0, int.Parse(e.CommandArgument.ToString())))
        //    {
        //        message = "User status has been updated successfully.";
        //    }
        //    else
        //    {
        //        message = "Unable to update status of user.";
        //    }
        //}
        //else if (e.CommandName == "Active")
        //{
        //           write code  to update column to 1
        //    if (objProperty.updateStatus(1, int.Parse(e.CommandArgument.ToString())))
        //    {
        //        message = "User status has been updated successfully.";
        //    }
        //    else
        //    {
        //        message = "Unable to update status of user.";
        //    }
        //}
        //else if (e.CommandName == "Delete")
        //{
        //}
        BindData();
    }
    protected void gvProperty_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    public int getunits(object pid)
    {
        try
        {
            int pp;
            pp = Convert.ToInt32(pid.ToString());  
            int unum;
            unum = objpropunit.GetUnitInProperty(pp);
            return unum;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}