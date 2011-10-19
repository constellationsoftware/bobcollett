using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Lease
/// </summary>
public class Lease
{
	public Lease()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["strConnectionString"].ToString();
    public DataTable GetLease()
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from Tbl_Lease", con);
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

    public DataTable GetLeaseById(int LeaseId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from Tbl_Lease where Leaseid=@LeaseId", con);
            cmd.Parameters.AddWithValue("@LeaseId", LeaseId);
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


    public int AddLease(string Addendum, string Adult_Occupants, string email1, string email2, string  inspectiondate, string latefeerule, string leasedoc, string leaseenddate, string leasestartdate, string leasename1, string leasephone1, string minoroccupants, string leasename2, decimal otherfee, string feenotes, decimal petfee, string leasephone2, int propertyid, string renewalnumber, decimal rentalamount, Boolean scheduleinspection, decimal securitydeposit, string securitydepositdate, string status, int unitid)
    {
        int insertID = 0;
        string sqlIns = "INSERT INTO Tbl_Lease (Addendum,Adult_Occupants,email1,email2,inspectiondate,latefeerule,leasedoc,leaseenddate,leasestartdate,leasename1,leasephone1,minoroccupants,leasename2,otherfee,feenotes,petfee,leasephone2,propertyid,renewalnumber,rentalamount,scheduleinspection,securitydeposit,securitydepositdate,status,unitid) VALUES (@Addendum,@Adult_Occupants,@email1,@email2,@inspectiondate,@latefeerule,@leasedoc,@leaseenddate,@leasestartdate,@leasename1,@leasephone1,@minoroccupants,@leasename2,@otherfee,@feenotes,@petfee,@leasephone2,@propertyid,@renewalnumber,@rentalamount,@scheduleinspection,@securitydeposit,@securitydepositdate,@status,@unitid)";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Addendum", Addendum);
            cmdIns.Parameters.Add("@Adult_Occupants", Adult_Occupants);
            cmdIns.Parameters.Add("@email1", email1);
            cmdIns.Parameters.Add("@email2", email2);
            cmdIns.Parameters.Add("@inspectiondate", inspectiondate);
            cmdIns.Parameters.Add("@latefeerule", latefeerule);
            cmdIns.Parameters.Add("@leasedoc", leasedoc);
            cmdIns.Parameters.Add("@leasestartdate", leasestartdate);            
            cmdIns.Parameters.Add("@leaseenddate", leaseenddate);
            cmdIns.Parameters.Add("@leasename1", leasename1);
            cmdIns.Parameters.Add("@leasephone1", leasephone1);
            cmdIns.Parameters.Add("@minoroccupants", minoroccupants);
            cmdIns.Parameters.Add("@leasename2", leasename2);
            cmdIns.Parameters.Add("@otherfee", otherfee);
            cmdIns.Parameters.Add("@feenotes", feenotes);
            cmdIns.Parameters.Add("@petfee", petfee);
            cmdIns.Parameters.Add("@leasephone2", leasephone2);
            cmdIns.Parameters.Add("@propertyid", propertyid);
            cmdIns.Parameters.Add("@renewalnumber", renewalnumber);
            cmdIns.Parameters.Add("@rentalamount", rentalamount);
            cmdIns.Parameters.Add("@scheduleinspection", scheduleinspection);
            cmdIns.Parameters.Add("@securitydeposit", securitydeposit);
            cmdIns.Parameters.Add("@securitydepositdate", securitydepositdate);
            cmdIns.Parameters.Add("@status", status);
            cmdIns.Parameters.Add("@unitid", unitid);
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

    public bool UpdateLease(string Addendum, string Adult_Occupants, string email1, string email2, string inspectiondate, string latefeerule, string leasedoc, string leaseenddate, string leasestartdate, string leasename1, string leasephone1, string minoroccupants, string leasename2, decimal otherfee, string feenotes, decimal petfee, string leasephone2, int propertyid, string renewalnumber, decimal rentalamount, Boolean scheduleinspection, decimal securitydeposit, string securitydepositdate, string status, int unitid, int leaseid)
    {
        int insertID = 0;
        string sqlIns = "UPDATE Tbl_Lease SET Addendum = @Addendum,Adult_Occupants = @Adult_Occupants,email1 = @email1,email2 = @email2,inspectiondate = @inspectiondate,latefeerule = @latefeerule,leasedoc = @leasedoc,leaseenddate = @leaseenddate,leasestartdate = @leasestartdate,leasename1 = @leasename1,leasephone1 = @leasephone1,minoroccupants = @minoroccupants,leasename2 = @leasename2,otherfee = @otherfee,feenotes = @feenotes,petfee = @petfee,leasephone2 = @leasephone2,propertyid = @propertyid,renewalnumber = @renewalnumber,rentalamount = @rentalamount,scheduleinspection = @scheduleinspection,securitydeposit = @securitydeposit,securitydepositdate = @securitydepositdate,status = @status,unitid = @unitid where Leaseid = @Leaseid";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Addendum", Addendum);
            cmdIns.Parameters.Add("@Adult_Occupants", Adult_Occupants);
            cmdIns.Parameters.Add("@email1", email1);
            cmdIns.Parameters.Add("@email2", email2);
            cmdIns.Parameters.Add("@inspectiondate", inspectiondate);
            cmdIns.Parameters.Add("@latefeerule", latefeerule);
            cmdIns.Parameters.Add("@leasedoc", leasedoc);
            cmdIns.Parameters.Add("@leasestartdate", leasestartdate);
            cmdIns.Parameters.Add("@leaseenddate", leaseenddate);
            cmdIns.Parameters.Add("@leasename1", leasename1);
            cmdIns.Parameters.Add("@leasephone1", leasephone1);
            cmdIns.Parameters.Add("@minoroccupants", minoroccupants);
            cmdIns.Parameters.Add("@leasename2", leasename2);
            cmdIns.Parameters.Add("@otherfee", otherfee);
            cmdIns.Parameters.Add("@feenotes", feenotes);
            cmdIns.Parameters.Add("@petfee", petfee);
            cmdIns.Parameters.Add("@leasephone2", leasephone2);
            cmdIns.Parameters.Add("@propertyid", propertyid);
            cmdIns.Parameters.Add("@renewalnumber", renewalnumber);
            cmdIns.Parameters.Add("@rentalamount", rentalamount);
            cmdIns.Parameters.Add("@scheduleinspection", scheduleinspection);
            cmdIns.Parameters.Add("@securitydeposit", securitydeposit);
            cmdIns.Parameters.Add("@securitydepositdate", securitydepositdate);
            cmdIns.Parameters.Add("@status", status);
            cmdIns.Parameters.Add("@unitid", unitid);
            cmdIns.Parameters.Add("@Leaseid", leaseid);
            cmdIns.ExecuteNonQuery();
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

    public bool DeleteLeaseById(int LeaseId)
    {
        bool result = false;
        string sqlIns = "delete from Tbl_Lease where Leaseid=@LeaseId";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@LeaseId", LeaseId);
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

    public bool CheckByUnitId_Add(int Unitid)
    {
        try
        {
            DataTable ds = new DataTable(); 
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from Tbl_Lease where unitid=@unitid", con);
            cmd.Parameters.AddWithValue("@unitid", Unitid);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool CheckByUnitId_Update(int Unitid,int leaseid)
    {
        try
        {
            DataTable ds = new DataTable();
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from Tbl_Lease where unitid=@unitid and Leaseid<>@leaseid", con);
            cmd.Parameters.AddWithValue("@unitid", Unitid);
            cmd.Parameters.AddWithValue("@leaseid", leaseid);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}