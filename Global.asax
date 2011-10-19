<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        // Catch exception and save to session variable, for displaying in ErrorPage.aspx
        Exception ex = Server.GetLastError();
        try
        {
            // Session object is not always available, so use try finally block.
            // This will prevent recursive loop.
           // Session["EncounteredException"] = ex;
        }
        finally
        {
            // To use the Session variable in ErrorPage.aspx we must clear the error and then manualy redirect to the ErrorPage.aspx.
            // Because we manualy redirect, we don't use the "customErrors" tag in the Web.config
          //  Server.ClearError();
          //  Response.Redirect("croosroadError.aspx");
        }

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
