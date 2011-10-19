using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminPortfolio : System.Web.UI.Page
{
    public string message = string.Empty;
    Portfolio objPortfolio = new Portfolio();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuserid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            //bindDefaultBank();
            if (Request.QueryString["fid"] != null)
            {
                DataTable dt = objPortfolio.GetPortfolioById(int.Parse(Request.QueryString["fid"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    txname.Text = dt.Rows[0]["Name"].ToString();
                    txtAbbreviation.Text = dt.Rows[0]["Abbreviation"].ToString();
                    //ddDefaultBank.ClearSelection();
                    //ddDefaultBank.Items.FindByValue(dt.Rows[0]["DefaultBankAccount"].ToString()).Selected = true;
                    //ddDefaultSecurity.ClearSelection();
                    //ddDefaultSecurity.Items.FindByValue(dt.Rows[0]["SecurityBankAccount"].ToString()).Selected = true;
                    //txtDate.Text = dt.Rows[0]["AccountCloseDate"].ToString();
                    txtOwner.Text = dt.Rows[0]["OwnerId"].ToString();
                    //txtMinimum.Text = dt.Rows[0]["PortFolioMinimum"].ToString();
                    //txtlimit.Text = dt.Rows[0]["SpendingLimit"].ToString();
                    
                }

            }
        }
    }
    Bank objBank = new Bank();
    private void bindDefaultBank()
    {
        ddDefaultBank.DataSource = objBank.GetBanks();
        ddDefaultBank.DataValueField = "Bankid";
        ddDefaultBank.DataTextField = "Bankname";
        ddDefaultBank.DataBind();

        ddDefaultSecurity.DataSource = objBank.GetBanks();
        ddDefaultSecurity.DataValueField = "Bankid";
        ddDefaultSecurity.DataTextField = "Bankname";
        ddDefaultSecurity.DataBind();
    }
    
    protected void txtSubmit_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["fid"] != null)
        {
            try
            {               
                    if (objPortfolio.updatePortfolio(txname.Text,txtAbbreviation.Text,0,0,DateTime.Now.Date,1,0,"", int.Parse(Request.QueryString["fid"].ToString())))
                    {
                        Session["msg"] = "Portfolio has been updated successfully.";
                        Response.Redirect("managePortfolio.aspx");  
                        //message = "Portfolio has been updated successfully.";
                    }
                    else
                    {
                        Session["msg"] = "Unable to update Portfolio.";
                        Response.Redirect("managePortfolio.aspx");  
                    }                
            }
            catch (Exception ex)
            {
                message = "Unable to add Portfolio.";
            }
        }
        else
        {
            try
            {

                if (objPortfolio.AddPortfolio(txname.Text, txtAbbreviation.Text, 0, 0, DateTime.Now.Date, 1, 0, "") > 0)
                    {
                        // Portfolio added successfully.
                        Session["msg"] = "Portfolio has been added successfully.";
                        Response.Redirect("managePortfolio.aspx");  
                    }
                    else
                    {
                        // Unable to add Portfolio.
                        Session["msg"] = "Unable to add Portfolio.";
                        Response.Redirect("managePortfolio.aspx");  
                    }
                
            }
            catch (Exception ex)
            {
                message = "Unable to add Portfolio.";
            }
        }
    }
}