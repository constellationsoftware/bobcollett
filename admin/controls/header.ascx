<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="admin_controls_header" %>
 <div class="header_2">
      <div class="dav_logo"><img src="images/logo.png" alt="" width="215" height="73" /></div>
      <div class="administrator"><img src="images/administrator.png" alt="" width="419" height="89" /></div>
    </div>
    <div class="menu">
  
      
      <% if (pagename.ToLower() == "manageproperty.aspx" || pagename.ToLower() == "property.aspx")
         {
             %>
             <div class="menu3"><a href="desktop.aspx" title="Desktop">Desktop</a></div>
             <div class="menu1_cur"><a href="manageProperty.aspx" title="Properties">Properties</a></div>
             <%
         }
         else
         {
              %>
              <div class="menu1_cur"><a href="desktop.aspx" title="Desktop">Desktop</a></div>
              <div class="menu3"><a href="manageProperty.aspx" title="Properties">Properties</a></div>
             <%
         }    %>
	  
	  <div class="menu3"><a href="managelease.aspx" title="Leases">Leases</a></div>
	  <div class="menu3"><a href="ManageTenant.aspx" title="Tenants">Tenants</a></div>
	  <div class="menu2"><a href="#" title="RENTS">RENTS</a></div>
	  <div class="menu2"><a href="#" title="Maintenance">Maintenance</a></div>
	  <div class="menu2"><a href="#" title="Reports">Reports</a></div>
	  <div class="menu2"><a href="#" title="Settings">Settings</a></div>
	  <div class="clear"></div>
    </div>