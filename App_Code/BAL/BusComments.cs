using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;




namespace BusinessLayer
{
    public class BusComments
    {
        DbAccess _dbAccess = new DbAccess();
        private DataSet _CommentsDS = new DataSet();
        public DataSet CommentsDS
        {
            get
            {
                return _CommentsDS;
            }
            set
            {
                _CommentsDS = value;
            }
        }


        public void getComments()
        {
            try
            {
                string strSQL = "SELECT * from comments";
                //Creating Datatable, if datatable not exist already.  
                //The data return by query will be stored in DataTable.  
                if (_CommentsDS.Tables.Contains("GetComments"))
                {
                    _CommentsDS.Tables.Remove("GetComments");
                }


                _dbAccess.selectQuery(_CommentsDS, strSQL, "GetComments");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}