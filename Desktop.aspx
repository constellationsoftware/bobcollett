<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Desktop.aspx.cs" Inherits="Desktop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="mid">
    	<div id="left">
            <h2>Welcome&nbsp; to <span class="blue_txt">Crossroads Property Management</span></h2>
        <fieldset class="rating_bg fieldset">
                	<legend class="legend">Dashboard</legend>
                    <table align="center" border="0" cellpadding="4" cellspacing="0" width="654">
                      <tbody><tr>
                        <td colspan="2" height="5"></td>
                      </tr>
                      
                      
                      <tr>
                        <td class="normal_txt" colspan="2" align="center">
                        <table width="50%" >
                        <tr>
                        <td align="left">
                        <ul>
                        <li><a href="profile.aspx?uid=<%= Session["userid"].ToString() %>" title="Manage Your Profile">Manage Your Profile</a></li>
                        <li><a href="changePassword.aspx" title="Change Password">Change Password</a></li>
                        <li><a href="logout.aspx">Logout</a></li>
                        </ul>
                        </td>
                        </tr>
                        </table>
                        
                         </td>
                        
                      </tr>
                      <tr>

                        <td colspan="2" height="5"></td>
                      </tr>
                    </tbody></table>
                </fieldset>

        </div>
        <div id="right">
        	<div class="latest_property">
            <div class="property_img"><img src="images/property.jpg" alt="property" /></div>
            <div class="content_property">
            <div class="content_head">Title <span class="light_blue_txt">Here</span></div>
            <div class="prop_details">
            Sed rhoncus consequat dignissim. Suspendisse ligula purus, euismod nec ultricies condimentum, posuere sed nisl. In vulputate dignissim nisi.<br />
              Sed rhoncus consequat dignissim. Suspendisse ligula purus.
              </div>
              <div class="more"><a href="#" class="moretxt">[more...]</a></div>
              </div>
            </div>
        </div>
    </div>

</asp:Content>

