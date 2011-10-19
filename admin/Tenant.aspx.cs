using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_Tenant : System.Web.UI.Page
{
    public string message = string.Empty;
    Property objProperty = new Property();
    Unit objunit = new Unit();
    propunit objpropunit = new propunit();
    Tenant objtenant = new Tenant();
    public string PageTitle = string.Empty;  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuserid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            BindDropDowns();
            if (Request.QueryString["tid"] != null)
            {
                PageTitle = "Update Tenant";
                DataTable dt = objtenant.GetTenantById(Convert.ToInt32(Request.QueryString["tid"].ToString()));  
                if (dt.Rows.Count > 0)
                {
                    txtfname.Text = dt.Rows[0]["First_name"].ToString();
                    txtlname.Text = dt.Rows[0]["Last_name"].ToString();
                    txtphonecell.Text = dt.Rows[0]["Phone_cell"].ToString();
                    txtphoneland.Text = dt.Rows[0]["Phone_land"].ToString();
                    txtphonework.Text = dt.Rows[0]["Phone_work"].ToString();
                    txtemailaddress.Text = dt.Rows[0]["Email"].ToString();
                    txtemergencyphone.Text = dt.Rows[0]["Emergency_phone"].ToString();
                    txtemployer.Text = dt.Rows[0]["Employer"].ToString();
                    txtemerrefrence.Text = dt.Rows[0]["Emergency_Reference"].ToString();
                    txtamount.Text = dt.Rows[0]["Amount_in_escrow"].ToString();
                    drdproperty.ClearSelection();
                    drdproperty.Items.FindByValue(dt.Rows[0]["Property_ID"].ToString()).Selected = true;

                    BindDropDowns1(Convert.ToInt32(dt.Rows[0]["Property_ID"].ToString()), Convert.ToInt32(dt.Rows[0]["Unit_id"].ToString()));

                }
                else
                {

                }

            }
            else
            {
                PageTitle = "Add Tenant";
                Bindunitatadd();
            }
        }
    }
    private void BindDropDowns()
    {
        //Property
        drdproperty.DataSource = objProperty.GetProperties();
        drdproperty.DataValueField = "PropertyId";
        drdproperty.DataTextField = "Name";
        drdproperty.DataBind();
    }

    private void Bindunitatadd()
    {
        ddunit.DataSource = objunit.GetUnits();
        ddunit.DataValueField = "UnitId";
        ddunit.DataTextField = "title";
        ddunit.DataBind();
    }

    private void BindDropDowns1(int pid, int uid)
    {
        ddunit.DataSource = objpropunit.GetUnitByMainPropid(pid);
        ddunit.DataValueField = "UnitId";
        ddunit.DataTextField = "title";
        ddunit.DataBind();
        ddunit.Items.FindByValue(uid.ToString()).Selected = true;
    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["tid"] != null)
        {
            try
            {

                if (objtenant.UpdateTenant(Convert.ToInt32(ddunit.SelectedItem.Value),Convert.ToInt32(drdproperty.SelectedItem.Value),txtphonework.Text,txtphoneland.Text,txtphonecell.Text,txtlname.Text,txtfname.Text,txtemployer.Text,txtemerrefrence.Text,txtemergencyphone.Text,txtemailaddress.Text,Convert.ToDecimal(txtamount.Text),Convert.ToInt32(Request.QueryString["tid"].ToString())))               
                {
                    message = "Tenant has been updated successfully.";
                }
                else
                {
                    message = "Unable to update Tenant.";
                }
            }
            catch (Exception ex)
            {
                message = "Unable to update Tenant.";
            }
        }
        else
        {
            try
            {
                if (objtenant.AddTenant(Convert.ToInt32(ddunit.SelectedItem.Value), Convert.ToInt32(drdproperty.SelectedItem.Value), txtphonework.Text, txtphoneland.Text, txtphonecell.Text, txtlname.Text, txtfname.Text, txtemployer.Text, txtemerrefrence.Text, txtemergencyphone.Text, txtemailaddress.Text, Convert.ToDecimal(txtamount.Text.ToString())) > 0)
                {
                    message = "Tenant has been added successfully.";
                }
                else
                {
                    // Unable to add Property.
                    message = "Unable to add Tenant.";
                }
            }
            catch (Exception ex)
            {
                message = "Unable to add Lease.";
            }
        }
    }
    protected void drdproperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddunit.DataSource = objpropunit.GetUnitByMainPropid(Convert.ToInt32(drdproperty.SelectedItem.Value));
        ddunit.DataValueField = "unitID";
        ddunit.DataTextField = "title";
        ddunit.DataBind();
    }
}