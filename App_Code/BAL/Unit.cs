using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Unit
/// </summary>
public class Unit
{
	public Unit()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["strConnectionString"].ToString();
    public DataTable GetUnits()
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_unit", con);
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

    public DataTable GetUnitById(int UnitId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_unit where UnitId=@UnitId", con);
            cmd.Parameters.AddWithValue("@UnitId", UnitId);
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

    public int AddUnit(int Garage, int LeaseTerms, string LongDesc, string Notes, Boolean Pets, Boolean Ready, string ShortDesc, Boolean Smoking, decimal TargetDeposite, decimal TargetRent, int Bathrooms, int Bedrooms, int Floor, decimal SqFt, string UnitType, string UnitUse,string  Status, string  LastModifiyBy, string  LastModifiedDate, string title)
    {
        int insertID = 0;
        string sqlIns = "INSERT INTO tbl_unit (Garage, LeaseTerms, LongDesc, Notes, Pets, Ready, ShortDesc, Smoking, TargetDeposite, TargetRent, Bathrooms, Bedrooms, Floor, SqFt, UnitType, UnitUse, Status, LastModifiyBy, LastModifiedDate, title) VALUES (@Garage, @LeaseTerms, @LongDesc, @Notes, @Pets, @Ready, @ShortDesc, @Smoking, @TargetDeposite, @TargetRent, @Bathrooms, @Bedrooms, @Floor, @SqFt, @UnitType, @UnitUse, @Status, @LastModifiyBy, @LastModifiedDate, @title)";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Garage", Garage);
            cmdIns.Parameters.Add("@LeaseTerms", LeaseTerms);
            cmdIns.Parameters.Add("@LongDesc", LongDesc);
            cmdIns.Parameters.Add("@Notes", Notes);
            cmdIns.Parameters.Add("@Pets", Pets);
            cmdIns.Parameters.Add("@Ready", Ready);
            cmdIns.Parameters.Add("@ShortDesc", ShortDesc);
            cmdIns.Parameters.Add("@Smoking", Smoking);
            cmdIns.Parameters.Add("@TargetDeposite",TargetDeposite);
            cmdIns.Parameters.Add("@TargetRent", TargetRent);
            cmdIns.Parameters.Add("@Bathrooms", Bathrooms);
            cmdIns.Parameters.Add("@Bedrooms", Bedrooms);
            cmdIns.Parameters.Add("@Floor", Floor);
            cmdIns.Parameters.Add("@SqFt", SqFt);
            cmdIns.Parameters.Add("@UnitType", UnitType);
            cmdIns.Parameters.Add("@UnitUse", UnitUse);
            cmdIns.Parameters.Add("@Status", Status);
            cmdIns.Parameters.Add("@LastModifiyBy", LastModifiyBy);
            cmdIns.Parameters.Add("@LastModifiedDate", LastModifiedDate);
            cmdIns.Parameters.Add("@title", title);            
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

    public bool DeleteUnitById(int UnitId)
    {
        bool result = false;
        string sqlIns = "delete from tbl_unit where UnitId=@UnitId";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@UnitId", UnitId);
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

    public bool UpdateUnit(int Garage, int LeaseTerms, string LongDesc, string Notes, Boolean Pets, Boolean Ready, string ShortDesc, Boolean Smoking, decimal TargetDeposite, decimal TargetRent, int Bathrooms, int Bedrooms, int Floor, decimal SqFt, string UnitType, string UnitUse, int UnitId, string Status, string LastModifiyBy, string LastModifiedDate, string title)
    {
        int insertID = 0;
        string sqlIns = "UPDATE tbl_unit set Garage = @Garage, LeaseTerms = @LeaseTerms, LongDesc = @LongDesc, Notes = @Notes, Pets = @Pets, Ready = @Ready, ShortDesc = @ShortDesc, Smoking = @Smoking, TargetDeposite = @TargetDeposite, TargetRent= @TargetRent, Bathrooms = @Bathrooms, Bedrooms = @Bedrooms, Floor = @Floor, SqFt = @SqFt, UnitType = @UnitType, UnitUse = @UnitUse,LastModifiedDate = @LastModifiedDate,LastModifiyBy = @LastModifiyBy,Status=@Status,title = @title where UnitId=@UnitId";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Garage", Garage);
            cmdIns.Parameters.Add("@LeaseTerms", LeaseTerms);
            cmdIns.Parameters.Add("@LongDesc", LongDesc);
            cmdIns.Parameters.Add("@Notes", Notes);
            cmdIns.Parameters.Add("@Pets", Pets);
            cmdIns.Parameters.Add("@Ready", Ready);
            cmdIns.Parameters.Add("@ShortDesc", ShortDesc);
            cmdIns.Parameters.Add("@Smoking", Smoking);
            cmdIns.Parameters.Add("@TargetDeposite", TargetDeposite);
            cmdIns.Parameters.Add("@TargetRent", TargetRent);
            cmdIns.Parameters.Add("@Bathrooms", Bathrooms);
            cmdIns.Parameters.Add("@Bedrooms", Bedrooms);
            cmdIns.Parameters.Add("@Floor", Floor);
            cmdIns.Parameters.Add("@SqFt", SqFt);
            cmdIns.Parameters.Add("@UnitType", UnitType);
            cmdIns.Parameters.Add("@UnitUse", UnitUse);
            cmdIns.Parameters.Add("@Status", Status);
            cmdIns.Parameters.Add("@LastModifiyBy", LastModifiyBy);
            cmdIns.Parameters.Add("@LastModifiedDate", LastModifiedDate);
            cmdIns.Parameters.Add("@title", title);
            cmdIns.Parameters.Add("@UnitId", UnitId);            
            cmdIns.ExecuteNonQuery();

            cmdIns.Parameters.Clear();

            cmdIns.Dispose();
            cmdIns = null;
            con.Close();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString(), ex);
        }
        finally
        {
            con.Close();
        }
    }

    public string GetUnitNameById(int UnitId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_unit where UnitId=@UnitId", con);
            cmd.Parameters.AddWithValue("@UnitId", UnitId);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                return ds.Rows[0]["title"].ToString();
            }
            else
            {
                return "Test";
            }
        }
        catch (Exception ex)
        {
            return "Test";
        }
    }

    public DataTable GetPropertyNameByUnitId(int UnitId)
    {
        // get data from Database //
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select p1.Name,p2.propertyid from tbl_property p1, tbl_linkedProperty p2 where p1.PropertyId=p2.PropertyId and p2.unitid = @unitid", con);
            cmd.Parameters.AddWithValue("@unitid", UnitId);
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

    public int GetMaxUnitID()
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select Max(UnitId) as uid from tbl_unit", con);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Rows[0]["uid"].ToString());
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


    public bool DeleteUnitById1(int UnitId)
    {
        bool result = false;
        string sqlIns = "delete from tbl_linkedProperty where UnitId=@UnitId";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@UnitId", UnitId);
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


}