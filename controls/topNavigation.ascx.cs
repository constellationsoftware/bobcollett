﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_topNavigation : System.Web.UI.UserControl
{
    public string rootPath = System.Configuration.ConfigurationManager.AppSettings["rootPath"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}