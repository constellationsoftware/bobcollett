using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Invoice
/// </summary>
public class Invoice
{
	public Invoice()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["strConnectionString"].ToString();
    public DataTable GetInvoice()
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from Tbl_invoices", con);
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


    public DataTable GetInvoiceId(int InvoiceId)
    {
        // get data from Database
        DataTable ds = new DataTable();
        try
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select * from Tbl_invoices where invoice_id=@InvoiceId", con);
            cmd.Parameters.AddWithValue("@InvoiceId", InvoiceId);
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


    public int AddInvoice(decimal Balance_Due, string created_by, string Due_date, string email_sent_date, string For_Month_of, string Invoice_date, string invoice_note, int Lease_id, string mail_sent_date, Boolean sent_by_email, int unit_id, string title)
    {
        int insertID = 0;
        string sqlIns = "INSERT INTO Tbl_invoices (Balance_Due,created_by,Due_date,email_sent_date,For_Month_of,Invoice_date,invoice_note,Lease_id,mail_sent_date,sent_by_email,unit_id,title) VALUES (@Balance_Due,@created_by,@Due_date,@email_sent_date,@For_Month_of,@Invoice_date,@invoice_note,@Lease_id,@mail_sent_date,@sent_by_email,@unit_id,@title)";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Balance_Due", Balance_Due);
            cmdIns.Parameters.Add("@created_by", created_by);
            cmdIns.Parameters.Add("@Due_date", Due_date);
            cmdIns.Parameters.Add("@email_sent_date", email_sent_date);
            cmdIns.Parameters.Add("@For_Month_of", For_Month_of);
            cmdIns.Parameters.Add("@Invoice_date", Invoice_date);
            cmdIns.Parameters.Add("@invoice_note", invoice_note);
            cmdIns.Parameters.Add("@Lease_id", Lease_id);
            cmdIns.Parameters.Add("@mail_sent_date", mail_sent_date);
            cmdIns.Parameters.Add("@sent_by_email", sent_by_email);
            cmdIns.Parameters.Add("@unit_id", unit_id);
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

    public bool UpdateInvoice(decimal Balance_Due, string created_by, string Due_date, string email_sent_date, string For_Month_of, string Invoice_date, string invoice_note, int Lease_id, string mail_sent_date, Boolean sent_by_email, int unit_id, int invoice_id, string title)
    {
        string sqlIns = "UPDATE Tbl_invoices SET Balance_Due = @Balance_Due,created_by = @created_by,Due_date = @Due_date,email_sent_date = @email_sent_date,For_Month_of = @For_Month_of,Invoice_date = @Invoice_date,invoice_note = @invoice_note,Lease_id = @Lease_id,mail_sent_date = @mail_sent_date,sent_by_email = @sent_by_email,unit_id = @unit_id, title = @title WHERE invoice_id = @invoice_id";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@Balance_Due", Balance_Due);
            cmdIns.Parameters.Add("@created_by", created_by);
            cmdIns.Parameters.Add("@Due_date", Due_date);
            cmdIns.Parameters.Add("@email_sent_date", email_sent_date);
            cmdIns.Parameters.Add("@For_Month_of", For_Month_of);
            cmdIns.Parameters.Add("@Invoice_date", Invoice_date);
            cmdIns.Parameters.Add("@invoice_note", invoice_note);
            cmdIns.Parameters.Add("@Lease_id", Lease_id);
            cmdIns.Parameters.Add("@mail_sent_date", mail_sent_date);
            cmdIns.Parameters.Add("@sent_by_email", sent_by_email);
            cmdIns.Parameters.Add("@unit_id", unit_id);
            cmdIns.Parameters.Add("@invoice_id", invoice_id);
            cmdIns.Parameters.Add("@title", title);            
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

    public bool DeleteInvoiceById(int InvoiceId)
    {
        bool result = false;
        string sqlIns = "delete from Tbl_invoices where invoice_id=@InvoiceId";
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        try
        {
            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
            cmdIns.Parameters.Add("@invoice_id", InvoiceId);
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
