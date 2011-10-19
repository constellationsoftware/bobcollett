using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_property : System.Web.UI.Page
{
    public string message = string.Empty;
    public int uuid;
    Property objProperty = new Property();
    Unit objunit = new Unit();
    propunit objpropunit = new propunit();
    public string PropertyName = string.Empty;
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
            if (Request.QueryString["pid"] != null)
            {
                PageTitle = "Edit Property";
                DataTable dt = objProperty.GetPropertyById(Convert.ToInt32(Request.QueryString["pid"].ToString()));
                DataTable dt1 = objpropunit.GetUnitByPropid(Convert.ToInt32(Request.QueryString["pid"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    txtAbbreviation.Text = dt.Rows[0]["Abbreviation"].ToString();
                    txtname.Text = dt.Rows[0]["name"].ToString();
                    //txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtState.Text = dt.Rows[0]["State"].ToString();
                    txtStreet.Text = dt.Rows[0]["Street"].ToString();
                    txtStreetNo.Text = dt.Rows[0]["StreetNumber"].ToString();
                    ddBuildingType.ClearSelection();
                    ddBuildingType.Items.FindByValue(dt.Rows[0]["BuildingType"].ToString()).Selected = true;
                    txtZip.Text = dt.Rows[0]["Zip"].ToString();
                    txtFloors.Text = dt.Rows[0]["Floors"].ToString();
                    txtLongDesc.Text = dt.Rows[0]["LongDesc"].ToString();
                    ddMultiUnit.ClearSelection();
                    ddMultiUnit.Items.FindByValue(dt.Rows[0]["isMultiUnit"].ToString()).Selected = true;
                    txtParcelNo.Text = dt.Rows[0]["parcelNumber"].ToString();


                    ddPortfolio.ClearSelection();
                    string portfo = dt.Rows[0]["portfolioId"].ToString();
                    if (!string.IsNullOrEmpty(portfo))
                        ddPortfolio.Items.FindByValue(dt.Rows[0]["portfolioId"].ToString()).Selected = true;

                    ddowner.ClearSelection();
                    string ownerfo = dt.Rows[0]["OwnerId"].ToString();
                    if (!string.IsNullOrEmpty(ownerfo))
                        ddowner.Items.FindByValue(dt.Rows[0]["OwnerId"].ToString()).Selected = true;


                    ddmgr.ClearSelection();
                    string mgrfo = dt.Rows[0]["maintMgrId"].ToString();
                    if (!string.IsNullOrEmpty(mgrfo))
                        ddmgr.Items.FindByValue(dt.Rows[0]["maintMgrId"].ToString()).Selected = true;


                    //txtPortfolio.Text = dt.Rows[0]["parcelNumber"].ToString();
                    txtRent.Text = dt.Rows[0]["Rent"].ToString();
                    txtDeposit.Text = dt.Rows[0]["Deposit"].ToString();
                    txtSqrFt.Text = dt.Rows[0]["sqrFeet"].ToString();
                    //txtDeposit.Text = dt.Rows[0]["Deposit"].ToString();
                    ddUse.ClearSelection();
                    ddUse.Items.FindByValue(dt.Rows[0]["useType"].ToString()).Selected = true;

                    PropertyName = dt.Rows[0]["name"].ToString();

                    if (dt1.Rows.Count > 0)
                    {
                        int i;
                        //chkunit.ClearSelection();
                        for (i = 0; i < dt1.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                uuid = Convert.ToInt32(dt1.Rows[i]["unitID"].ToString());
                            }
                            //chkunit.Items.FindByValue(dt1.Rows[i]["unitID"].ToString()).Selected = true;
                        }
                    }

                    pnlunit.Visible = true;
                    pnlunitadd.Visible = true; 
                    BindUnits(Convert.ToInt32(Request.QueryString["pid"].ToString()));
                    DisplayData(uuid);
                }

            }
            else
            {
                PageTitle = "Add Property";
            }
        }
    }


    private void BindDropDowns()
    {

        // Protfolio
        Portfolio objPortfolio = new Portfolio();
        ddPortfolio.DataSource = objPortfolio.GetPortfolio();
        ddPortfolio.DataValueField = "PortfolioId";
        ddPortfolio.DataTextField = "Name";
        ddPortfolio.DataBind();

        // Owner
        Owner objowner = new Owner();
        ddowner.DataSource = objowner.GetOwner();
        ddowner.DataValueField = "id";
        ddowner.DataTextField = "owner";
        ddowner.DataBind();


        //MGR
        Mgr objmgr = new Mgr();
        ddmgr.DataSource = objmgr.GetMgr();
        ddmgr.DataValueField = "id";
        ddmgr.DataTextField = "mgr";
        ddmgr.DataBind();

        //Unit
        //chkunit.DataSource = objunit.GetUnits();
        //chkunit.DataValueField = "Unitid";
        //chkunit.DataTextField = "title";
        //chkunit.DataBind();
    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        int unitid;
        int defaultFloor = 0;
        DateTime defaultDate = new DateTime();
        decimal defaultDec = 0;
        int? floor = null;
        DateTime? Date = null;
        int? mgrid = null;
        int? Owner = null;
        int? Portfolio = null;
        decimal? Rent = null;
        decimal? Deposit = null;
        if (!int.TryParse(txtFloors.Text, out defaultFloor))
            floor = null;
        else
            floor = Convert.ToInt32(txtFloors.Text);

        if (!DateTime.TryParse(txtDate.Text, out defaultDate))
            Date = null;
        else
            Date = Convert.ToDateTime(txtDate.Text);

        try
        {
            if (!int.TryParse(ddowner.SelectedItem.Value, out defaultFloor))
                Owner = null;
            else
                Owner = Convert.ToInt32(ddowner.SelectedItem.Value);
        }
        catch (Exception ex)
        {
            Owner = null;
        }

        try
        {
            if (!int.TryParse(ddmgr.SelectedItem.Value, out defaultFloor))
                mgrid = null;
            else
                mgrid = Convert.ToInt32(ddmgr.SelectedItem.Value);
        }
        catch (Exception ex)
        {
            mgrid = null;
        }


        try
        {
            if (!int.TryParse(ddPortfolio.SelectedItem.Value, out defaultFloor))
                Portfolio = null;
            else
                Portfolio = Convert.ToInt32(ddPortfolio.SelectedItem.Value);
        }
        catch (Exception ex)
        {
            Portfolio = null;
        }
        //if (!int.TryParse(ddPortfolio.SelectedItem.Value, out defaultFloor))
        //    Portfolio = null;
        //else
        //    Portfolio = Convert.ToInt32(ddPortfolio.SelectedItem.Value);
        if (!decimal.TryParse(txtRent.Text, out defaultDec))
            Rent = null;
        else
            Rent = Convert.ToDecimal(txtRent.Text);
        if (!decimal.TryParse(txtDeposit.Text, out defaultDec))
            Deposit = null;
        else
            Deposit = Convert.ToDecimal(txtDeposit.Text);
        if (Request.QueryString["pid"] != null)
        {
            try
            {

                if (objProperty.updateProperty(txtAbbreviation.Text, txtname.Text, "", txtState.Text, txtStreet.Text, txtStreetNo.Text, ddBuildingType.SelectedItem.Value, txtZip.Text, txtCountry.Text, floor, Convert.ToInt32(Session["adminuserid"].ToString()), txtLongDesc.Text, Date, Convert.ToInt32(mgrid), bool.Parse(ddMultiUnit.SelectedItem.Value), Owner, txtParcelNo.Text, Portfolio, Convert.ToInt32(Session["adminuserid"].ToString()), txtShortDesc.Text, txtSqrFt.Text, ddUse.SelectedItem.Value, Rent, Deposit, Convert.ToInt32(Request.QueryString["pid"].ToString())))
                {
                    //Boolean delpropunitfirst;
                    //delpropunitfirst = objpropunit.DeletePropUnitById(Convert.ToInt32(Request.QueryString["pid"].ToString()));
                    //for (int i = 0; i < chkunit.Items.Count; i++)
                    //{
                    //    if (chkunit.Items[i].Selected)
                    //    {
                    //        unitid = Convert.ToInt32(chkunit.Items[i].Value);
                    //        objpropunit.AddUnitProp(Convert.ToInt32(Request.QueryString["pid"].ToString()), unitid);
                    //    }
                    //}
                    message = "Property has been updated successfully.";
                    Response.Redirect("manageproperty.aspx");
                }
                else
                {
                    message = "Unable to update Property.";
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
                if (objProperty.AddProperty(txtAbbreviation.Text, txtname.Text, "", txtState.Text, txtStreet.Text, txtStreetNo.Text, ddBuildingType.SelectedItem.Value, txtZip.Text, txtCountry.Text, floor, Convert.ToInt32(Session["adminuserid"].ToString()), txtLongDesc.Text, Date, mgrid, bool.Parse(ddMultiUnit.SelectedItem.Value), Owner, txtParcelNo.Text, Portfolio, Convert.ToInt32(Session["adminuserid"].ToString()), txtShortDesc.Text, txtSqrFt.Text, ddUse.SelectedItem.Value, Rent, Deposit) > 0)
                {
                    int maxid;
                    maxid = objProperty.GetPropID();
                    unitid = 20;
                    objpropunit.AddUnitProp(maxid, unitid);
                    //for (int i = 0; i < chkunit.Items.Count; i++)
                    //{
                    //    if (chkunit.Items[i].Selected)
                    //    {
                    //        unitid = Convert.ToInt32(chkunit.Items[i].Value);
                    //        objpropunit.AddUnitProp(maxid, unitid);
                    //    }
                    //}
                    // Property added successfully.
                    message = "Property has been added successfully.";
                    Response.Redirect("manageproperty.aspx");
                }
                else
                {
                    // Unable to add Property.
                    message = "Unable to add Property.";
                }

            }
            catch (Exception ex)
            {
                message = "Unable to add Property.";
            }
        }
    }

    private void BindUnits(int pid)
    {

        // Units
        ddunit.DataSource = objpropunit.GetUnitByMainPropid(pid);
        ddunit.DataValueField = "unitID";
        ddunit.DataTextField = "title";
        ddunit.DataBind();
    }

    private void DisplayData(int unitid)
    {
        DataTable dt = new DataTable();
        dt = objunit.GetUnitById(unitid);
        if (dt.Rows.Count > 0)
        {
            lbltitle.Text = dt.Rows[0]["title"].ToString();
            lblgarage.Text = dt.Rows[0]["Garage"].ToString();
            lblleaseterms.Text = dt.Rows[0]["LeaseTerms"].ToString();
            lblmdate.Text = dt.Rows[0]["LastModifiedDate"].ToString();
            lbllmb.Text = dt.Rows[0]["LastModifiyBy"].ToString();
            lbllongdesc.Text = dt.Rows[0]["LongDesc"].ToString();
            lblnotes.Text = dt.Rows[0]["Notes"].ToString();
            lblpets.Text = dt.Rows[0]["Pets"].ToString();
            lblready.Text = dt.Rows[0]["Ready"].ToString();
            lblsdesc.Text = dt.Rows[0]["ShortDesc"].ToString();
            lblsmoking.Text = dt.Rows[0]["Smoking"].ToString();
            lbltarget.Text = dt.Rows[0]["TargetDeposite"].ToString();
            lbltargetrent.Text = dt.Rows[0]["TargetRent"].ToString();
            lblbathroom.Text = dt.Rows[0]["Bathrooms"].ToString();
            lblbedroom.Text = dt.Rows[0]["Bedrooms"].ToString();
            lblfloor.Text = dt.Rows[0]["Floor"].ToString();
            lblsqfeet.Text = dt.Rows[0]["SqFt"].ToString();
            lblunittype.Text = dt.Rows[0]["UnitType"].ToString();
            lblunituse.Text = dt.Rows[0]["UnitUse"].ToString();
            lblunitstatus.Text = dt.Rows[0]["UnitUse"].ToString();
        }
        else
        {

        }
    }

    protected void ddunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Response.Redirect("Property.aspx?pid" + Convert.ToInt32(Request.QueryString["pid"].ToString()) + "&uid" + Convert.ToInt32(Convert.ToInt32(ddunit.SelectedItem.Value)));  
        DisplayData(Convert.ToInt32(ddunit.SelectedItem.Value));
    }

    protected void txtSubmit1_Click(object sender, EventArgs e)
    {
        try
        {
            if (objunit.AddUnit(Convert.ToInt32(drdgarage.SelectedValue), Convert.ToInt32(txtleaseterms.Text), txtldesc.Text, txtnotes.Text, bool.Parse(drdpets.SelectedItem.Value), bool.Parse(drdready.SelectedItem.Value), txtsdesc.Text, bool.Parse(drdsmoking.SelectedItem.Value), Convert.ToDecimal(txttargetdpst.Text), Convert.ToDecimal(txttargetrent.Text), Convert.ToInt32(txtbathroom.Text), Convert.ToInt32(txtbedroom.Text), Convert.ToInt32(txtfloor.Text), Convert.ToDecimal(txtsqft.Text), drdunittype.SelectedValue, drdunituse.SelectedItem.Value, drdunitstatus.SelectedValue, txtlastmodby.Text, txtlastmod.Text, txttitle.Text) > 0)
            {
                int maxunitid;
                maxunitid = objunit.GetMaxUnitID();
                objpropunit.AddUnitProp(Convert.ToInt32(Request.QueryString["pid"].ToString()), maxunitid); 
                // Property added successfully.
                Response.Redirect("property.aspx?pid=" + Convert.ToInt32(Request.QueryString["pid"].ToString()));  
                message = "Unit has been added successfully for this property.";
            }
            else
            {
                // Unable to add Property.
                message = "Unable to add Unit.";
            }

        }
        catch (Exception ex)
        {

        }
    }
}