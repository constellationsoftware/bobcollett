using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_Invoice : System.Web.UI.Page
{
    public string message = string.Empty;
    Invoice objinvoice = new Invoice(); 
    Unit objunit = new Unit();
    Lease objlease = new Lease();
    public string leasefilename = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuserid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            BindDropDowns();
            if (Request.QueryString["iid"] != null)
            {
                DataTable dt = objinvoice.GetInvoiceId(Convert.ToInt32(Request.QueryString["iid"].ToString()));  
                if (dt.Rows.Count > 0)
                {
                    txtinvoicetitle.Text = dt.Rows[0]["title"].ToString();
                    txtinvoicedate.Text = dt.Rows[0]["Invoice_date"].ToString();
                    ddlease.Items.FindByValue(dt.Rows[0]["Lease_id"].ToString()).Selected = true;
                    txtbalancedue.Text = dt.Rows[0]["Balance_Due"].ToString();
                    txtcreatedby.Text = dt.Rows[0]["created_by"].ToString();
                    txtduedate.Text = dt.Rows[0]["Due_date"].ToString();
                    txtemailsentdate.Text = dt.Rows[0]["email_sent_date"].ToString();
                    txtformonthof.Text = dt.Rows[0]["For_Month_of"].ToString();
                    txtinvoicenote.Text = dt.Rows[0]["invoice_note"].ToString();
                    ddsendbyemail.Items.FindByValue(dt.Rows[0]["sent_by_email"].ToString()).Selected = true;
                    ddunit.Items.FindByValue(dt.Rows[0]["unit_id"].ToString()).Selected = true;
                }
                else
                {

                }

            }
            else
            {
            }
        }
    }

    private void BindDropDowns()
    {
        //Unit
        ddunit.DataSource = objunit.GetUnits();  
        ddunit.DataValueField = "unitid";
        ddunit.DataTextField = "title";
        ddunit.DataBind();

        //Lease
        ddlease.DataSource = objlease.GetLease();  
        ddlease.DataValueField = "Leaseid";
        ddlease.DataTextField = "Leasename1";
        ddlease.DataBind();
        
    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["iid"] != null)
        {
            try
            {
                if (objinvoice.UpdateInvoice(Convert.ToDecimal(txtbalancedue.Text.ToString()),txtcreatedby.Text,txtduedate.Text,txtemailsentdate.Text,txtformonthof.Text,txtinvoicenote.Text,txtinvoicenote.Text,Convert.ToInt32(ddlease.SelectedItem.Value),txtemailsentdate.Text,bool.Parse(ddsendbyemail.SelectedItem.Value),Convert.ToInt32(ddunit.SelectedItem.Value),Convert.ToInt32(Request.QueryString["iid"].ToString()),txtinvoicetitle.Text))            
                {
                    message = "Invoice has been updated successfully.";
                }
                else
                {
                    message = "Unable to update Invoice.";
                }

            }
            catch (Exception ex)
            {
                message = "Unable to update Lease.";
            }
        }
        else
        {
            try
            {
                //End
                if (objinvoice.AddInvoice(Convert.ToDecimal(txtbalancedue.Text.ToString()),txtcreatedby.Text,txtduedate.Text,txtemailsentdate.Text,txtformonthof.Text,txtinvoicenote.Text,txtinvoicenote.Text,Convert.ToInt32(ddlease.SelectedItem.Value),txtemailsentdate.Text,bool.Parse(ddsendbyemail.SelectedItem.Value),Convert.ToInt32(ddunit.SelectedItem.Value),txtinvoicetitle.Text) > 0)
                {
                    message = "Invoice has been added successfully.";
                }
                else
                {
                    // Unable to add Property.
                    message = "Unable to add Invoice.";
                }

            }
            catch (Exception ex)
            {
                message = "Unable to add Invoice.";
            }
        }
    }
}
