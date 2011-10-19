using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for TenantLease
/// </summary>
public class TenantLease
{
	public TenantLease()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["strConnectionString"].ToString();

    public DataTable GetLeaseByTenantId(int Tenantid)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_tenant_lease where Tenant_id=@Tenant_id", con);
            cmd.Parameters.AddWithValue("@Tenant_id", Tenantid);
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

    public int AddLeaseTenant(int tenantid, int leaseid)
    {
        int insertID = 0;
        string sqlIns = "INSERT INTO tbl_tenant_lease (Lease_id,Tenant_id) VALUES (@Lease_id,@Tenant_id)";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Lease_id", leaseid);
            cmdIns.Parameters.Add("@Tenant_id", tenantid);
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

    public bool DeleteLeaseByTenantId(int TenantId)
    {
        bool result = false;
        string sqlIns = "delete from tbl_tenant_lease where Tenant_id=@Tenant_id";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Tenant_id", TenantId);
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


    public DataTable GetLeaseNameByTenantId(int Tenantid)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select l2.Leaseid,l2.leasename1 from tbl_tenant_lease l1,tbl_Lease l2 where l1.Tenant_id=@Tenant_id and l2.Leaseid = l1.Lease_id", con);
            cmd.Parameters.AddWithValue("@Tenant_id", Tenantid);
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
}