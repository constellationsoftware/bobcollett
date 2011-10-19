using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Property
/// </summary>
public class Property
{
	public Property()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["strConnectionString"].ToString();

    public int GetPropID()
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select Max(PropertyId) as mid from tbl_property", con);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Rows[0]["mid"].ToString());
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public DataTable GetProperties()
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_property", con);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            return ds;
        }
    }
    public DataTable GetPropertyById(int PropertyId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Property where PropertyId=@PropertyId", con);
            cmd.Parameters.AddWithValue("@PropertyId", PropertyId);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            return ds;
        }
    }
    public int AddProperty(string Abbreviation, string Name, string Address, string State, string Street, string StreetNumber, string BuildingType, string Zip, string Country, int? Floors, int? lastModifiedByUserId, string LongDesc, DateTime? mainAssignedDate, int? maintMgrId, bool isMultiUnit, int? OwnerId, string parcelNumber, int? portfolioId, int? createdByUser, string shortDesc, string sqrFeet, string useType, decimal? Rent, decimal? Deposit)
    {
        int insertID = 0;
        string sqlIns = "INSERT INTO tbl_property (Abbreviation,  Name,  Address,  State,  Street,  StreetNumber,  BuildingType,  Zip,  Country,  Floors,  lastModifiedByUserId,  LongDesc,  mainAssignedDate,  maintMgrId,  isMultiUnit,  OwnerId,  parcelNumber,  portfolioId,  createdByUser,  shortDesc,  sqrFeet,  useType,Rent,Deposit) VALUES (@Abbreviation,  @Name,  @Address,  @State,  @Street,  @StreetNumber,  @BuildingType,  @Zip,  @Country,  @Floors,  @lastModifiedByUserId,  @LongDesc,  @mainAssignedDate,  @maintMgrId,  @isMultiUnit,  @OwnerId,  @parcelNumber,  @portfolioId,  @createdByUser,  @shortDesc,  @sqrFeet,  @useType,@Rent,@Deposit)";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Abbreviation", Abbreviation);
            cmdIns.Parameters.Add("@Name", Name);
            cmdIns.Parameters.Add("@Address", Address);
            cmdIns.Parameters.Add("@State", State);
           
            cmdIns.Parameters.Add("@Street", Street);
            cmdIns.Parameters.Add("@StreetNumber", StreetNumber);
            cmdIns.Parameters.Add("@BuildingType", BuildingType);
            cmdIns.Parameters.Add("@Zip", Zip);
            cmdIns.Parameters.Add("@Country", Country);
            if(Floors != null)
                cmdIns.Parameters.Add("@Floors", Floors);
            else
                cmdIns.Parameters.Add("@Floors", DBNull.Value);
            cmdIns.Parameters.Add("@lastModifiedByUserId", lastModifiedByUserId);
            cmdIns.Parameters.Add("@LongDesc", LongDesc);

            //cmdIns.Parameters.Add("@mainAssignedDate", mainAssignedDate);
            if (mainAssignedDate != null)
                cmdIns.Parameters.Add("@mainAssignedDate", mainAssignedDate);
            else
                cmdIns.Parameters.Add("@mainAssignedDate", DBNull.Value);
            //cmdIns.Parameters.Add("@maintMgrId", maintMgrId);
            if (maintMgrId != null)
                cmdIns.Parameters.Add("@maintMgrId", maintMgrId);
            else
                cmdIns.Parameters.Add("@maintMgrId", DBNull.Value);
            cmdIns.Parameters.Add("@isMultiUnit", isMultiUnit);
            //cmdIns.Parameters.Add("@OwnerId", OwnerId);
            if (OwnerId != null)
                cmdIns.Parameters.Add("@OwnerId", OwnerId);
            else
                cmdIns.Parameters.Add("@OwnerId", DBNull.Value);
            cmdIns.Parameters.Add("@parcelNumber", parcelNumber);
            //cmdIns.Parameters.Add("@portfolioId", portfolioId);
            if (portfolioId != null)
                cmdIns.Parameters.Add("@portfolioId", portfolioId);
            else
                cmdIns.Parameters.Add("@portfolioId", DBNull.Value);
            cmdIns.Parameters.Add("@createdByUser", createdByUser);
            cmdIns.Parameters.Add("@shortDesc", shortDesc);
            cmdIns.Parameters.Add("@sqrFeet", sqrFeet);
            cmdIns.Parameters.Add("@useType", useType);
            //cmdIns.Parameters.Add("@Rent", Rent);
            if (Rent != null)
                cmdIns.Parameters.Add("@Rent", Rent);
            else
                cmdIns.Parameters.Add("@Rent", DBNull.Value);
            //cmdIns.Parameters.Add("@Deposit", Deposit);
            if (Deposit != null)
                cmdIns.Parameters.Add("@Deposit", Deposit);
            else
                cmdIns.Parameters.Add("@Deposit", DBNull.Value);

            cmdIns.ExecuteNonQuery();

            cmdIns.Parameters.Clear();
            cmdIns.CommandText = "SELECT @@IDENTITY";

            // Get the last inserted id.
            insertID = Convert.ToInt32(cmdIns.ExecuteScalar());

            cmdIns.Dispose();
            cmdIns = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString(), ex);
        }
        finally
        {
            con.Close();
        }
        return insertID;
    }

    public bool DeletePropertyById(int PropertyId)
    {
        bool result = false;
        string sqlIns = "delete from tbl_Property where PropertyId=@PropertyId";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@PropertyId", PropertyId);
            cmdIns.ExecuteNonQuery();


            cmdIns.Dispose();
            cmdIns = null;
            result = true;
        }
        catch (Exception ex)
        {
            //  throw new Exception(ex.ToString(), ex);
        }
        finally
        {
            con.Close();
        }
        return result;
    }


    public bool updateProperty(string Abbreviation, string Name, string Address, string State, string Street, string StreetNumber, string BuildingType, string Zip, string Country, int? Floors, int? lastModifiedByUserId, string LongDesc, DateTime? mainAssignedDate, int? maintMgrId, bool isMultiUnit, int? OwnerId, string parcelNumber, int? portfolioId, int? createdByUser, string shortDesc, string sqrFeet, string useType,decimal? Rent,decimal? Deposit, int PropertyId)
    {
        int insertID = 0;
        string sqlIns = "update tbl_Property set Rent=@Rent,Deposit=@Deposit,Abbreviation=@Abbreviation,  Name=@Name,  Address=@Address,  State=@State,  Street=@Street,  StreetNumber=@StreetNumber,  BuildingType=@BuildingType,  Zip=@Zip,  Country=@Country,  Floors=@Floors,  lastModifiedByUserId=@lastModifiedByUserId,  LongDesc=@LongDesc,  mainAssignedDate=@mainAssignedDate,  maintMgrId=@maintMgrId,  isMultiUnit=@isMultiUnit,  OwnerId=@OwnerId,  parcelNumber=@parcelNumber,  portfolioId=@portfolioId,  createdByUser=@createdByUser,  shortDesc=@shortDesc,  sqrFeet=@sqrFeet,  useType=@useType  where PropertyId=@PropertyId";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Abbreviation", Abbreviation);
            cmdIns.Parameters.Add("@Name", Name);
            cmdIns.Parameters.Add("@Address", Address);
            cmdIns.Parameters.Add("@State", State);
         
            cmdIns.Parameters.Add("@Street", Street);
            cmdIns.Parameters.Add("@StreetNumber", StreetNumber);
            cmdIns.Parameters.Add("@BuildingType", BuildingType);
            cmdIns.Parameters.Add("@Zip", Zip);
            cmdIns.Parameters.Add("@Country", Country);

            if (Floors != null)
                cmdIns.Parameters.Add("@Floors", Floors);
            else
                cmdIns.Parameters.Add("@Floors", DBNull.Value);
            cmdIns.Parameters.Add("@lastModifiedByUserId", lastModifiedByUserId);
            cmdIns.Parameters.Add("@LongDesc", LongDesc);

            //cmdIns.Parameters.Add("@mainAssignedDate", mainAssignedDate);
            if (mainAssignedDate != null)
                cmdIns.Parameters.Add("@mainAssignedDate", mainAssignedDate);
            else
                cmdIns.Parameters.Add("@mainAssignedDate", DBNull.Value);
            //cmdIns.Parameters.Add("@maintMgrId", maintMgrId);
            if (maintMgrId != null)
                cmdIns.Parameters.Add("@maintMgrId", maintMgrId);
            else
                cmdIns.Parameters.Add("@maintMgrId", DBNull.Value);
            cmdIns.Parameters.Add("@isMultiUnit", isMultiUnit);
            //cmdIns.Parameters.Add("@OwnerId", OwnerId);
            if (OwnerId != null)
                cmdIns.Parameters.Add("@OwnerId", OwnerId);
            else
                cmdIns.Parameters.Add("@OwnerId", DBNull.Value);
            cmdIns.Parameters.Add("@parcelNumber", parcelNumber);
            //cmdIns.Parameters.Add("@portfolioId", portfolioId);
            if (portfolioId != null)
                cmdIns.Parameters.Add("@portfolioId", portfolioId);
            else
                cmdIns.Parameters.Add("@portfolioId", DBNull.Value);
            cmdIns.Parameters.Add("@createdByUser", createdByUser);
            cmdIns.Parameters.Add("@shortDesc", shortDesc);
            cmdIns.Parameters.Add("@sqrFeet", sqrFeet);
            cmdIns.Parameters.Add("@useType", useType);
            //cmdIns.Parameters.Add("@Rent", Rent);
            if (Rent != null)
                cmdIns.Parameters.Add("@Rent", Rent);
            else
                cmdIns.Parameters.Add("@Rent", DBNull.Value);
            //cmdIns.Parameters.Add("@Deposit", Deposit);
            if (Deposit != null)
                cmdIns.Parameters.Add("@Deposit", Deposit);
            else
                cmdIns.Parameters.Add("@Deposit", DBNull.Value);
            cmdIns.Parameters.Add("@PropertyId", PropertyId);
            cmdIns.ExecuteNonQuery();

            cmdIns.Parameters.Clear();

            cmdIns.Dispose();
            cmdIns = null;
            con.Close();
            return true;
        }
        catch (Exception ex)
        {
            // throw new Exception(ex.ToString(), ex);
        }

        con.Close();

        return false;
    }

    
}