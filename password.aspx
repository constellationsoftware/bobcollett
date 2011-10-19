<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="password.aspx.cs" Inherits="password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="mid">
    	<div id="left">
            <h2>Retrieve Your Password</h2>
        <fieldset class="rating_bg fieldset">
                	<legend class="legend">Please provide your email address registered to us </legend>
                    <table align="center" border="0" cellpadding="4" cellspacing="0" width="654">
                      <tbody><tr>
                        <td colspan="2" height="5"></td>
                      </tr>
                      <tr>

                        <td class="normal_txt" width="154">Email ID<span class="mandatory">*</span></td>
                        <td width="500">
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="150" style="width:180px;"></asp:TextBox>
                        </td>
                      </tr>
                      
                      <tr>
						<td></td>
                        <td class="normal_txt" align="left"><asp:Button ID="btnPassword" runat="server" Text="Send Password" ToolTip="
                        Send Password" /> &nbsp;</td>
                        
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

