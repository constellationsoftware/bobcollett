using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Portfolio
/// </summary>
public class Portfolio
{
	public Portfolio()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["strConnectionString"].ToString();
    public DataTable GetPortfolio()
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Portfolio", con);
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
    public DataTable GetPortfolioById(int PortfolioId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from tbl_Portfolio where PortfolioId=@PortfolioId", con);
            cmd.Parameters.AddWithValue("@PortfolioId", PortfolioId);
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
    public int AddPortfolio(string Name, string Abbreviation, int DefaultBankAccount, int SecurityBankAccount, DateTime AccountCloseDate, int OwnerId, decimal PortFolioMinimum, string SpendingLimit)
    {
        int insertID = 0;
        string sqlIns = "INSERT INTO tbl_Portfolio (Name,  Abbreviation,  DefaultBankAccount,  SecurityBankAccount,  AccountCloseDate,  OwnerId,  PortFolioMinimum,  SpendingLimit) VALUES (@Name,  @Abbreviation,  @DefaultBankAccount,  @SecurityBankAccount,  @AccountCloseDate,  @OwnerId,  @PortFolioMinimum,  @SpendingLimit)";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Abbreviation", Abbreviation);
            cmdIns.Parameters.Add("@Name", Name);
            cmdIns.Parameters.Add("@DefaultBankAccount", DefaultBankAccount);
            cmdIns.Parameters.Add("@SecurityBankAccount", SecurityBankAccount);

            cmdIns.Parameters.Add("@AccountCloseDate", AccountCloseDate);
            cmdIns.Parameters.Add("@OwnerId", OwnerId);
            cmdIns.Parameters.Add("@PortFolioMinimum", PortFolioMinimum);
            cmdIns.Parameters.Add("@SpendingLimit", SpendingLimit);
           
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

    public bool DeletePortfolioById(int PortfolioId)
    {
        bool result = false;
        string sqlIns = "delete from tbl_Portfolio where PortfolioId=@PortfolioId";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@PortfolioId", PortfolioId);
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


    public bool updatePortfolio(string Name, string Abbreviation, int DefaultBankAccount, int SecurityBankAccount, DateTime AccountCloseDate, int OwnerId, decimal PortFolioMinimum, string SpendingLimit, int PortfolioId)
    {
        int insertID = 0;
        string sqlIns = "update tbl_Portfolio set Abbreviation=@Abbreviation,  Name=@Name,  DefaultBankAccount=@DefaultBankAccount,  SecurityBankAccount=@SecurityBankAccount,  AccountCloseDate=@AccountCloseDate,  OwnerId=@OwnerId,  PortFolioMinimum=@PortFolioMinimum,  SpendingLimit=@SpendingLimit  where PortfolioId=@PortfolioId";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Abbreviation", Abbreviation);
            cmdIns.Parameters.Add("@Name", Name);
            cmdIns.Parameters.Add("@DefaultBankAccount", DefaultBankAccount);
            cmdIns.Parameters.Add("@SecurityBankAccount", SecurityBankAccount);

            cmdIns.Parameters.Add("@AccountCloseDate", AccountCloseDate);
            cmdIns.Parameters.Add("@OwnerId", OwnerId);
            cmdIns.Parameters.Add("@PortFolioMinimum", PortFolioMinimum);
            cmdIns.Parameters.Add("@SpendingLimit", SpendingLimit);
            cmdIns.Parameters.Add("@PortfolioId", PortfolioId);
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