using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_controls_header : System.Web.UI.UserControl
{
    public string pagename = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

    string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath; 
    System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
    pagename = oInfo.Name; 
    

        }
    }
}