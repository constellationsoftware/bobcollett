<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="changePassword.aspx.cs" Inherits="changePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
    <div id="mid">
    	<div id="left">
            <h2>Login&nbsp; to <span class="blue_txt">Crossroads Property Management</span></h2>
        <fieldset class="rating_bg fieldset">
                	<legend class="legend">Change Password</legend>
                    <table align="center" border="0" cellpadding="4" cellspacing="0" width="654">
                      <tbody><tr>
                        <td colspan="2" height="5" align="center">
                        <%=uMessage%>
                        </td>
                      </tr>
                      <tr>

                        <td class="normal_txt" width="154">Old Password<span class="mandatory">*</span></td>
                        <td width="500">
                        <asp:TextBox ID="txtOldPassword" runat="server" MaxLength="150" style="width:180px;" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword" Display="None" ErrorMessage ="Old Password is required field."></asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
                        </td>
                      </tr>
                      <tr>
                        <td class="normal_txt">New Password<span class="mandatory">*</span></td>

                        <td><asp:TextBox ID="txtPassword" runat="server" MaxLength="150" style="width:180px;" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage ="New Password is required field."></asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator2"></cc1:ValidatorCalloutExtender>
                        </td>
                      </tr>
                      <tr>
                        <td class="normal_txt">Confirm Password<span class="mandatory">*</span></td>

                        <td><asp:TextBox ID="txtConfirm" runat="server" MaxLength="150" style="width:180px;" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirm" Display="None" ErrorMessage ="Confirm Password is required field."></asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3"></cc1:ValidatorCalloutExtender>
                                                <asp:CompareValidator ID="cdCompare" runat="server" ControlToCompare="txtPassword" Display="None" ControlToValidate="txtConfirm" ErrorMessage="Confirm password not matched"></asp:CompareValidator>
                                                
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="cdCompare"></cc1:ValidatorCalloutExtender>
                        </td>
                      </tr>
                      <tr>
                        <td class="normal_txt" colspan="2" align="center"><asp:Button ID="btnLogin" 
                                runat="server" Text="Login" ToolTip="Login" onclick="btnLogin_Click" /> </td>
                        
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

