using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Tenant
/// </summary>
public class Tenant
{
	public Tenant()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["strConnectionString"].ToString();

    public DataTable GetTenants()
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_tenant", con);
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

    public DataTable GetTenantById(int TenantId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_tenant where Tenant_id=@TenantId", con);
            cmd.Parameters.AddWithValue("@TenantId", TenantId);
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

    public int AddTenant(int Unit_id, int Property_ID, string Phone_work, string Phone_land, string Phone_cell, string Last_name, string First_name, string Employer, string Emergency_Reference, string Emergency_phone, string Email, decimal Amount_in_escrow)
    {
        int insertID = 0;
        string sqlIns = "INSERT INTO tbl_tenant (Unit_id,Property_ID,Phone_work,Phone_land,Phone_cell,Last_name,First_name,Employer,Emergency_Reference,Emergency_phone,Email,Amount_in_escrow) VALUES (@Unit_id,@Property_ID,@Phone_work,@Phone_land,@Phone_cell,@Last_name,@First_name,@Employer,@Emergency_Reference,@Emergency_phone,@Email,@Amount_in_escrow)";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Unit_id", Unit_id);
            cmdIns.Parameters.Add("@Property_ID", Property_ID);
            cmdIns.Parameters.Add("@Phone_work", Phone_work);
            cmdIns.Parameters.Add("@Phone_land", Phone_land);
            cmdIns.Parameters.Add("@Phone_cell", Phone_cell);
            cmdIns.Parameters.Add("@Last_name", Last_name);
            cmdIns.Parameters.Add("@First_name", First_name);
            cmdIns.Parameters.Add("@Employer", Employer);
            cmdIns.Parameters.Add("@Emergency_Reference", Emergency_Reference);
            cmdIns.Parameters.Add("@Emergency_phone", Emergency_phone);
            cmdIns.Parameters.Add("@Email", Email);
            cmdIns.Parameters.Add("@Amount_in_escrow", Amount_in_escrow);
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

    public bool UpdateTenant(int Unit_id, int Property_ID, string Phone_work, string Phone_land, string Phone_cell, string Last_name, string First_name, string Employer, string Emergency_Reference, string Emergency_phone, string Email, decimal Amount_in_escrow, int Tenant_id)
    {
        int insertID = 0;
        string sqlIns = "UPDATE tbl_tenant SET Unit_id = @Unit_id,Property_ID = @Property_ID,Phone_work = @Phone_work,Phone_land = @Phone_land,Phone_cell = @Phone_cell,Last_name = @Last_name,First_name = @First_name,Employer = @Employer,Emergency_Reference = @Emergency_Reference,Emergency_phone = @Emergency_phone,Email = @Email,Amount_in_escrow = @Amount_in_escrow WHERE Tenant_id = @Tenant_id";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Unit_id", Unit_id);
            cmdIns.Parameters.Add("@Property_ID", Property_ID);
            cmdIns.Parameters.Add("@Phone_work", Phone_work);
            cmdIns.Parameters.Add("@Phone_land", Phone_land);
            cmdIns.Parameters.Add("@Phone_cell", Phone_cell);
            cmdIns.Parameters.Add("@Last_name", Last_name);
            cmdIns.Parameters.Add("@First_name", First_name);
            cmdIns.Parameters.Add("@Employer", Employer);
            cmdIns.Parameters.Add("@Emergency_Reference", Emergency_Reference);
            cmdIns.Parameters.Add("@Emergency_phone", Emergency_phone);
            cmdIns.Parameters.Add("@Email", Email);
            cmdIns.Parameters.Add("@Amount_in_escrow", Amount_in_escrow);
            cmdIns.Parameters.Add("@Tenant_id", Tenant_id);
            cmdIns.ExecuteNonQuery();
            cmdIns.Dispose();
            cmdIns = null;
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

    public bool DeleteTenantById(int TenantId)
    {
        bool result = false;
        string sqlIns = "delete from tbl_tenant where Tenant_id=@Tenant_id";
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

}