using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_Lease : System.Web.UI.Page
{
    public string message = string.Empty;
    Property objProperty = new Property();
    Unit objunit = new Unit();
    propunit objpropunit = new propunit();
    Lease objlease = new Lease();
    public string leasefilename = string.Empty;
    public string filename_display = string.Empty;  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminuserid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!Page.IsPostBack)
        {
            BindDropDowns();
            if (Request.QueryString["lid"] != null)
            {
                DataTable dt = objlease.GetLeaseById(Convert.ToInt32(Request.QueryString["lid"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    txtleasename1.Text = dt.Rows[0]["leasename1"].ToString();
                    txtleasename2.Text = dt.Rows[0]["leasename2"].ToString();
                    txtaddendum.Text = dt.Rows[0]["Addendum"].ToString();
                    txtadultoccupant.Text = dt.Rows[0]["Adult_Occupants"].ToString();
                    txtemailaddress1.Text = dt.Rows[0]["email1"].ToString();
                    txtemailaddress2.Text = dt.Rows[0]["email2"].ToString();
                    txtinspectiondate.Text = dt.Rows[0]["inspectiondate"].ToString();
                    txtlatefeerule.Text = dt.Rows[0]["latefeerule"].ToString();
                    txtleasedate.Text = dt.Rows[0]["leaseenddate"].ToString();
                    txtleasestartdate.Text = dt.Rows[0]["leasestartdate"].ToString();
                    txtleasephone.Text = dt.Rows[0]["leasephone1"].ToString();
                    txtminoroccumants.Text = dt.Rows[0]["minoroccupants"].ToString();
                    txtfeenotes.Text = dt.Rows[0]["feenotes"].ToString();
                    txtotherfee.Text = dt.Rows[0]["otherfee"].ToString();
                    txtleasephone2.Text = dt.Rows[0]["leasephone2"].ToString();
                    drdproperty.ClearSelection();
                    drdproperty.Items.FindByValue(dt.Rows[0]["propertyid"].ToString()).Selected = true;
                    txtrentalamount.Text = dt.Rows[0]["rentalamount"].ToString();
                    drdschinspection.ClearSelection();
                    drdschinspection.Items.FindByValue(dt.Rows[0]["scheduleinspection"].ToString()).Selected = true;
                    txtsecuritydeposit.Text = dt.Rows[0]["securitydeposit"].ToString();
                    txtsecdepdate.Text = dt.Rows[0]["securitydepositdate"].ToString();
                    ddstatus.ClearSelection();
                    ddstatus.Items.FindByValue(dt.Rows[0]["status"].ToString()).Selected = true;
                    txtpetfee.Text = dt.Rows[0]["petfee"].ToString();
                    txtrenewal.Text = dt.Rows[0]["renewalnumber"].ToString();

                    BindDropDowns1(Convert.ToInt32(dt.Rows[0]["propertyid"].ToString()), Convert.ToInt32(dt.Rows[0]["unitid"].ToString()));

                    leasefilename = dt.Rows[0]["leasedoc"].ToString();

                    if (!(string.IsNullOrEmpty(leasefilename)))
                    {
                        filename_display = leasefilename;
                        pnlupload.Visible = true;
                    }
                    else
                    {
                        pnlupload.Visible = false; 
                    }

                    //ddunit.ClearSelection();
                    //ddunit.Items.FindByValue(dt.Rows[0]["unitid"].ToString()).Selected = true;
                }
                else
                {
                    
                }

            }
            else
            {
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

    private void BindDropDowns1(int pid,int uid)
    {
        ddunit.DataSource = objpropunit.GetUnitByMainPropid(pid);
        ddunit.DataValueField = "UnitId";
        ddunit.DataTextField = "title";
        ddunit.DataBind();
        ddunit.Items.FindByValue(uid.ToString()).Selected = true; 
    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["lid"] != null)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string filename = System.IO.Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("~/Lease/") + filename);
                        leasefilename = filename;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {

                }

                if (objlease.CheckByUnitId_Update(Convert.ToInt32(ddunit.SelectedItem.Value),Convert.ToInt32(Request.QueryString["lid"].ToString())))
                {
                    message = "Lease already added for this Unit.";
                }
                else
                {
                    if (objlease.UpdateLease(txtaddendum.Text, txtadultoccupant.Text, txtemailaddress1.Text, txtemailaddress2.Text, txtinspectiondate.Text, txtlatefeerule.Text, leasefilename, txtleasedate.Text, txtleasestartdate.Text, txtleasename1.Text, txtleasephone.Text, txtminoroccumants.Text, txtleasename2.Text, Convert.ToDecimal(txtotherfee.Text.ToString()), txtfeenotes.Text, Convert.ToDecimal(txtpetfee.Text.ToString()), txtleasephone2.Text, Convert.ToInt32(drdproperty.SelectedItem.Value), txtrenewal.Text, Convert.ToDecimal(txtrentalamount.Text), bool.Parse(drdschinspection.SelectedItem.Value), Convert.ToDecimal(txtsecuritydeposit.Text), txtsecdepdate.Text, ddstatus.SelectedItem.Value, Convert.ToInt32(ddunit.SelectedItem.Value), Convert.ToInt32(Request.QueryString["lid"].ToString())))
                    {
                        message = "Lease has been updated successfully.";
                    }
                    else
                    {
                        message = "Unable to update Lease.";
                    }
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
                //File Upload
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string filename = System.IO.Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("~/Lease/") + filename);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                //End
                if(objlease.CheckByUnitId_Add(Convert.ToInt32(ddunit.SelectedItem.Value)))
                {
                   message = "Lease already added for this Unit.";
                }
                else
                {
                    if (objlease.AddLease(txtaddendum.Text, txtadultoccupant.Text, txtemailaddress1.Text, txtemailaddress2.Text, txtinspectiondate.Text, txtlatefeerule.Text, FileUpload1.FileName, txtleasedate.Text, txtleasestartdate.Text, txtleasename1.Text, txtleasephone.Text, txtminoroccumants.Text, txtleasename2.Text, Convert.ToDecimal(txtotherfee.Text.ToString()), txtfeenotes.Text, Convert.ToDecimal(txtpetfee.Text.ToString()), txtleasephone2.Text, Convert.ToInt32(drdproperty.SelectedItem.Value), txtrenewal.Text, Convert.ToDecimal(txtrentalamount.Text), bool.Parse(drdschinspection.SelectedItem.Value), Convert.ToDecimal(txtsecuritydeposit.Text), txtsecdepdate.Text, ddstatus.SelectedItem.Value, Convert.ToInt32(ddunit.SelectedItem.Value)) > 0)
                    {
                        message = "Lease has been added successfully.";
                    }
                    else
                    {
                        // Unable to add Property.
                        message = "Unable to add Lease.";
                    }
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