<%@ Control Language="C#" AutoEventWireup="true" CodeFile="topNavigation.ascx.cs" Inherits="controls_topNavigation" %>
<div class="nav">
    <ul>
    <li ><a href="#" class="active" title="DASHBOARD">DASHBOARD</a>
        <ul>
        <li><a href="#">test 1</a></li>
        <li><a href="#">test 2</a></li>
        <li><a href="#">test 3</a></li>
        <li><a href="#">test 4</a></li>
        </ul>
    </li>
    <li><a href="#" title="PROPERTIES">PROPERTIES</a></li>
    <li><a href="#" title="RENTAL INCOME">RENTAL INCOME</a></li>
    <li><a href="#" title="LEASES">LEASES</a></li>
    <li><a href="#" title="MAINTENANCE">MAINTENANCE</a>
    <ul>
        <li><a href="#">test 1</a></li>
        <li><a href="#">test 2</a></li>
        <li><a href="#">test 3</a></li>
        <li><a href="#">test 4</a></li>
        </ul>
    </li>
    <li><a href="#" title="REPORTS">REPORTS</a></li>
     <li><a href="<%= rootPath %>/admin/login.aspx" title="ADMIN">ADMIN</a></li>
    
    </ul>
    
  </div>