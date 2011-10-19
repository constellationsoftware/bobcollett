<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hedear.ascx.cs" Inherits="controls_hedear" %>
  <div id="header">
    <div class="logo"><img src="images/logo.png" alt="Crossroads Group" title="Crossroads Group" /></div>
        <div class="login">
        <% if (Session["userid"] == null)
           {%>
        <a href="login.aspx"><img src="images/login.png" alt="Login" title="Login" /></a>
        <%
            }
           else
           { %>
         <a href="desktop.aspx">Desktop</a> | <a href="logout.aspx">Logout</a>
         <%} %>
        </div>
    </div>
