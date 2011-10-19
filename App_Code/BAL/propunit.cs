using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for propunit
/// </summary>
public class propunit
{
	public propunit()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["strConnectionString"].ToString();

    public DataTable GetUnitByPropid(int PropertyId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_linkedProperty where PropertyId=@PropertyId", con);
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

    public int AddUnitProp(int propertyid,int unitid)
    {
        int insertID = 0;
        string sqlIns = "INSERT INTO tbl_linkedProperty (propertyID,unitID) VALUES (@propertyID,@unitID)";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@propertyID", propertyid);
            cmdIns.Parameters.Add("@unitID", unitid);
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

    public bool DeletePropUnitById(int PropertyId)
    {
        bool result = false;
        string sqlIns = "delete from tbl_linkedProperty where propertyID=@PropertyId";
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


    public DataTable GetUnitByMainPropid(int PropertyId)
    {
        // get data from Database //
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select p.PropertyId,u.title,p.unitID from tbl_linkedProperty p,tbl_unit u where p.PropertyId=@PropertyId and p.unitid=u.unitid", con);
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

    public int GetUnitInProperty(int PropertyId)
    {
        // get data from Database //
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select count(*) as pnum from tbl_linkedProperty where propertyID = @PropertyId", con);
            cmd.Parameters.AddWithValue("@PropertyId", PropertyId);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            if(ds.Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Rows[0]["pnum"].ToString());  
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
}