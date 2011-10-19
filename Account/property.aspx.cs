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
    Property objProperty = new Property();
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
                DataTable dt = objProperty.GetPropertyById(Convert.ToInt32(Request.QueryString["pid"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    txtAbbreviation.Text = dt.Rows[0]["Abbreviation"].ToString();
                    txtname.Text = dt.Rows[0]["name"].ToString();

                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
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
                    //txtPortfolio.Text = dt.Rows[0]["parcelNumber"].ToString();
                    txtRent.Text = dt.Rows[0]["Rent"].ToString();
                    txtDeposit.Text = dt.Rows[0]["Deposit"].ToString();
                    txtSqrFt.Text = dt.Rows[0]["sqrFeet"].ToString();
                    //txtDeposit.Text = dt.Rows[0]["Deposit"].ToString();
                    ddUse.ClearSelection();
                    ddUse.Items.FindByValue(dt.Rows[0]["useType"].ToString()).Selected = true;
                }

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

    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        int defaultFloor = 0;
        DateTime defaultDate = new DateTime();
        decimal defaultDec = 0;
        int? floor=null;
       DateTime? Date =null;
int ? mgrid=null;
int? Owner=null;
int? Portfolio=null;
decimal? Rent=null;
decimal? Deposit = null;
if (!int.TryParse(txtFloors.Text, out defaultFloor))
            floor = null;
        else
            floor = Convert.ToInt32(txtFloors.Text);

if (!DateTime.TryParse(txtDate.Text, out defaultDate))
            Date = null;
        else
            Date = Convert.ToDateTime(txtDate.Text);
        if (!int.TryParse(txtmgrid.Text, out defaultFloor))
            mgrid = null;
        else
            mgrid = Convert.ToInt32(txtmgrid.Text);
        if (!int.TryParse(txtOwner.Text, out defaultFloor))
            Owner = null;
        else
            Owner = Convert.ToInt32(txtOwner.Text);
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
        if (!int.TryParse(ddPortfolio.SelectedItem.Value, out defaultFloor))
            Portfolio = null;
        else
            Portfolio = Convert.ToInt32(ddPortfolio.SelectedItem.Value);
        if (!decimal.TryParse(txtRent.Text, out defaultDec))
            Rent = null;
        else
            Rent = Convert.ToDecimal(txtRent.Text);
        if (!decimal.TryParse(txtDeposit.Text, out defaultDec))
            Deposit = null;
        else
            Deposit = Convert.ToInt32(txtDeposit.Text);
        if (Request.QueryString["pid"] != null)
        {
            try
            {

                if (objProperty.updateProperty(txtAbbreviation.Text,txtname.Text,txtAddress.Text,txtState.Text,txtStreet.Text,txtStreetNo.Text,ddBuildingType.SelectedItem.Value,txtZip.Text,txtCountry.Text,floor,Convert.ToInt32(Session["adminuserid"].ToString()),txtLongDesc.Text, Date,Convert.ToInt32(txtmgrid.Text),bool.Parse(ddMultiUnit.SelectedItem.Value),Owner,txtParcelNo.Text,Portfolio,Convert.ToInt32(Session["adminuserid"].ToString()),txtShortDesc.Text,txtSqrFt.Text,ddUse.SelectedItem.Value,Rent,Deposit,Convert.ToInt32(Request.QueryString["pid"].ToString())))
                    {
                        message = "Property has been updated successfully.";
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
                if (objProperty.AddProperty(txtAbbreviation.Text, txtname.Text, txtAddress.Text, txtState.Text, txtStreet.Text, txtStreetNo.Text, ddBuildingType.SelectedItem.Value, txtZip.Text, txtCountry.Text,floor, Convert.ToInt32(Session["adminuserid"].ToString()), txtLongDesc.Text, Date, mgrid, bool.Parse(ddMultiUnit.SelectedItem.Value), Owner, txtParcelNo.Text, Portfolio, Convert.ToInt32(Session["adminuserid"].ToString()), txtShortDesc.Text, txtSqrFt.Text, ddUse.SelectedItem.Value, Rent, Deposit) > 0)
                    {
                        // Property added successfully.
                        message = "Property has been added successfully.";
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
}