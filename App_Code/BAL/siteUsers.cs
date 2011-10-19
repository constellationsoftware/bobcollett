using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Web;


/// <summary>
/// Summary description for siteUsers
/// </summary>
public class siteUsers
{
    DbAccess _dbAccess = new DbAccess();
    private DataSet _siteUsersDS = new DataSet();
    public DataSet siteUsersDS
    {
        get
        {
            return _siteUsersDS;
        }
        set
        {
            _siteUsersDS = value;
        }
    }

	public siteUsers()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["strConnectionString"].ToString();
    public DataTable AuthenticateUser(string email, string password)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Login where Email=@Email and Password=@Password and IsActive=1 and Roleid=1", con);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
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

    public DataTable AuthenticateSiteUser(string email, string password)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Login where Email=@Email and Password=@Password and IsActive=1", con);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
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


    public DataTable getUsers()
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Login where userid<>1", con);
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

    public DataTable getUserById(int UserId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Login where userId=@userid", con);
            cmd.Parameters.AddWithValue("@userid", UserId);
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


    public void getsiteUsers()
    {
        try
        {
            string strSQL = "SELECT * from siteUsers";
            //Creating Datatable, if datatable not exist already.  
            //The data return by query will be stored in DataTable.  
            if (_siteUsersDS.Tables.Contains("GetsiteUsers"))
            {
                _siteUsersDS.Tables.Remove("GetsiteUsers");
            }
            _dbAccess.selectQuery(_siteUsersDS, strSQL, "GetsiteUsers");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int addUser(string Email,string Password,int RoleId,string fname,string lname, string phone,string address1,string address2,string Postal,string County,string Country,string title)
    {
        int insertID = 0;
        string sqlIns = "INSERT INTO tbl_Login (email, password, isActive,ProfileCreatedDate,ProfileCreatedIp,RoleId,firstname,lastname,phone,address1,address2,Postalcode,county,country,title) VALUES (@email, @password, 1,getdate(),'" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + "',@RoleId,@firstname,@lastname,@phone,@address1,@address2,@Postalcode,@county,@country,@title)";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@email", Email);
            cmdIns.Parameters.Add("@title", title);
            cmdIns.Parameters.Add("@password", Password);
            cmdIns.Parameters.Add("@RoleId", RoleId);

            cmdIns.Parameters.Add("@firstname", fname);
            cmdIns.Parameters.Add("@lastname", lname);
            cmdIns.Parameters.Add("@phone", phone);
            cmdIns.Parameters.Add("@address1", address1);
            cmdIns.Parameters.Add("@address2", address2);
            cmdIns.Parameters.Add("@Postalcode", Postal);
            cmdIns.Parameters.Add("@county", County);
            cmdIns.Parameters.Add("@country", Country);
           
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
        return  insertID;
    }

    public bool deleteUserById( int UserId)
    {
        bool result = false;
        string sqlIns = "delete from tbl_Login where userid=@userid";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@userid", UserId);
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


    public bool updateUser(string Email, string Password, int RoleId,string fname,string lname, string phone,string address1,string address2,string Postal,string County,string Country,string title,int UserId)
    {
        int insertID = 0;
        string sqlIns = "update tbl_Login set email=@email, password=@password,RoleId=@Roleid,firstname=@firstname,lastname=@lastname,Phone=@phone,address1=@address1,address2=@address2,Postalcode=@postalcode,county=@county,country=@country  where userid=@userid";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@email", Email);
            cmdIns.Parameters.Add("@password", Password);
            cmdIns.Parameters.Add("@title", title);
            cmdIns.Parameters.Add("@RoleId", RoleId);
            cmdIns.Parameters.Add("@userid", UserId);
            cmdIns.Parameters.Add("@firstname", fname);
            cmdIns.Parameters.Add("@lastname", lname);
            cmdIns.Parameters.Add("@phone", phone);
            cmdIns.Parameters.Add("@address1", address1);
            cmdIns.Parameters.Add("@address2", address2);
            cmdIns.Parameters.Add("@Postalcode", Postal);
            cmdIns.Parameters.Add("@county", County);
            cmdIns.Parameters.Add("@country", Country);
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

    public bool updateUserWithoutPwd(string Email, string title, int RoleId, string fname, string lname, string phone, string address1, string address2, string Postal, string County, string Country, int UserId)
    {
        int insertID = 0;
        string sqlIns = "update tbl_Login set email=@email, title=@title,RoleId=@Roleid,firstname=@firstname,lastname=@lastname,Phone=@phone,address1=@address1,address2=@address2,Postalcode=@postalcode,county=@county,country=@country  where userid=@userid";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@email", Email);
            cmdIns.Parameters.Add("@title", title);
            cmdIns.Parameters.Add("@RoleId", RoleId);
            cmdIns.Parameters.Add("@userid", UserId);
            cmdIns.Parameters.Add("@firstname", fname);
            cmdIns.Parameters.Add("@lastname", lname);
            cmdIns.Parameters.Add("@phone", phone);
            cmdIns.Parameters.Add("@address1", address1);
            cmdIns.Parameters.Add("@address2", address2);
            cmdIns.Parameters.Add("@Postalcode", Postal);
            cmdIns.Parameters.Add("@county", County);
            cmdIns.Parameters.Add("@country", Country);
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

    public bool updateStatus(int status, int UserId)
    {
        int insertID = 0;
        string sqlIns = "update tbl_Login set isActive=@status where userid=@userid";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@status", status);
            cmdIns.Parameters.Add("@userid", UserId);
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

    public bool updatePassword(string password, int UserId)
    {
        int insertID = 0;
        string sqlIns = "update tbl_Login set password=@password where userid=@userid";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@password", password);
            cmdIns.Parameters.Add("@userid", UserId);
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

    public bool IsEmailExists(string email)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Login where Email=@Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
         
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            if (ds.Rows.Count > 0)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            return false;
        }


    }
    public bool IsEmailExistsForUpdate(string email, int UserId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Login where Email=@Email and userid<>@UserId", con);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@userid", UserId);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            if (ds.Rows.Count > 0)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            return false;
        }


    }


    public string GetDetail(int id)
    {
        // get data from Database
        DataTable ds = new DataTable();
        string name = string.Empty;  
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Login where userid = @userid", con);
            cmd.Parameters.AddWithValue("@userid", id);
            SqlDataAdapter adp = new SqlDataAdapter();
            cmd.Connection = con;
            adp.SelectCommand = cmd;
            adp.Fill(ds);
            if (ds.Rows.Count > 0)
            {
                name = ds.Rows[0]["firstname"].ToString() + " " + ds.Rows[0]["lastname"].ToString();
            }
            else
            {
                name = "";
            }
            return name;
        }
        catch (Exception ex)
        {

        }

        return name;
    }
}