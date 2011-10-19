using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_Unit : System.Web.UI.Page
{
    public string message = string.Empty;
    Unit objunit = new Unit(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuserid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                DataTable dt = objunit.GetUnitById(Convert.ToInt32(Request.QueryString["id"].ToString()));  
                if (dt.Rows.Count > 0)
                {
                    txttitle.Text = dt.Rows[0]["title"].ToString();

                    drdgarage.ClearSelection();
                    string garage = dt.Rows[0]["Garage"].ToString();
                    if (!string.IsNullOrEmpty(garage))
                        drdgarage.Items.FindByValue(dt.Rows[0]["Garage"].ToString()).Selected = true;

                    txtleaseterms.Text = dt.Rows[0]["LeaseTerms"].ToString();
                    txtlastmod.Text = dt.Rows[0]["LastModifiedDate"].ToString();
                    txtlastmodby.Text = dt.Rows[0]["LastModifiyBy"].ToString();
                    txtlongdesc.Text = dt.Rows[0]["LongDesc"].ToString();
                    txtnotes.Text = dt.Rows[0]["Notes"].ToString();
                    drdpets.Items.FindByValue(dt.Rows[0]["Pets"].ToString()).Selected = true;
                    drdready.Items.FindByValue(dt.Rows[0]["Ready"].ToString()).Selected = true;
                    txtshortdesc.Text = dt.Rows[0]["ShortDesc"].ToString();
                    drdsmoking.Items.FindByValue(dt.Rows[0]["Smoking"].ToString()).Selected = true;
                    txttargetdpst.Text = dt.Rows[0]["TargetDeposite"].ToString();
                    txttargetrent.Text = dt.Rows[0]["TargetRent"].ToString();
                    txtbathroom.Text = dt.Rows[0]["Bathrooms"].ToString();
                    txtbedroom.Text = dt.Rows[0]["Bedrooms"].ToString();
                    txtfloor.Text = dt.Rows[0]["Floor"].ToString();
                    txtsqft.Text = dt.Rows[0]["SqFt"].ToString();
                    drdunittype.Items.FindByValue(dt.Rows[0]["UnitType"].ToString()).Selected = true;
                    drdunituse.Items.FindByValue(dt.Rows[0]["UnitUse"].ToString()).Selected = true;
                    drdunitstatus.Items.FindByValue(dt.Rows[0]["Status"].ToString()).Selected = true;
                }

            }
        }
    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            try
            {

                if (objunit.UpdateUnit(Convert.ToInt32(drdgarage.SelectedValue), Convert.ToInt32(txtleaseterms.Text), txtlongdesc.Text, txtnotes.Text, bool.Parse(drdpets.SelectedItem.Value), bool.Parse(drdready.SelectedItem.Value), txtshortdesc.Text, bool.Parse(drdsmoking.SelectedItem.Value), Convert.ToDecimal(txttargetdpst.Text), Convert.ToDecimal(txttargetrent.Text), Convert.ToInt32(txtbathroom.Text), Convert.ToInt32(txtbedroom.Text), Convert.ToInt32(txtfloor.Text), Convert.ToDecimal(txtsqft.Text), drdunittype.SelectedItem.Value, drdunituse.SelectedItem.Value, Convert.ToInt32(Request.QueryString["id"].ToString()), drdunitstatus.SelectedValue, txtlastmodby.Text, txtlastmod.Text, txttitle.Text))                                               
                {
                    message = "Unit has been updated successfully.";
                }
                else
                {
                    message = "Unable to update Unit.";
                }

            }
            catch (Exception ex)
            {
                message = "Unable to add Property.";
            }
        }
        else
        {
            try
            {
                if (objunit.AddUnit(Convert.ToInt32(drdgarage.SelectedValue), Convert.ToInt32(txtleaseterms.Text), txtlongdesc.Text, txtnotes.Text, bool.Parse(drdpets.SelectedItem.Value), bool.Parse(drdready.SelectedItem.Value), txtshortdesc.Text, bool.Parse(drdsmoking.SelectedItem.Value), Convert.ToDecimal(txttargetdpst.Text), Convert.ToDecimal(txttargetrent.Text), Convert.ToInt32(txtbathroom.Text), Convert.ToInt32(txtbedroom.Text), Convert.ToInt32(txtfloor.Text), Convert.ToDecimal(txtsqft.Text), drdunittype.SelectedValue,drdunituse.SelectedItem.Value, drdunitstatus.SelectedValue, txtlastmodby.Text, txtlastmod.Text, txttitle.Text) > 0)
                {
                    // Property added successfully.
                    message = "Unit has been added successfully.";
                }
                else
                {
                    // Unable to add Property.
                    message = "Unable to add Unit.";
                }

            }
            catch (Exception ex)
            {
                message = "Unable to add Property.";
            }
        }
    }
}