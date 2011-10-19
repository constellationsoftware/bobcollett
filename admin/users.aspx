<%@ Page Title="Admin Panel : Users (Add/Edit)" Language="C#" MasterPageFile="~/admin/admin.master"
    AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="admin_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
    <div class="view">
        <div class="view1">
            
            <div class="view4">
            
                <asp:RequiredFieldValidator runat="server" ID="NReq" ControlToValidate="txtEmail"
            Display="None" ErrorMessage="A email is required." />
          
        <cc1:ValidatorCalloutExtender runat="Server" ID="NReqE" TargetControlID="NReq" HighlightCssClass="validatorCalloutHighlight" />

    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtPassword"
            Display="None" ErrorMessage="A Password is required." />
          
        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                
                    <table width="100%" border="0" class="view5aa">
                    <tr><td height="20" class="view5">Add User</td><td width="100" align="right">Add New User</td></tr>
                    <tr><td colspan="2" height="10">&nbsp;</td></tr>
                    <tr><td colspan="2">
                    <table style="color:#000000" width="100%" class="normal">
                    <tr><td colspan="2" height="10" align="right"><span class="mandatory">Field marked with* are mandatory.</span></td></tr>
                    <tr><td colspan="2" height="10">&nbsp;</td></tr>
                    <tr><td colspan="2" height="10"><table width="100%" >
                    <tr><td align="center" colspan="2"><%=message%></td></tr>
                    </table></td></tr>
					<tr><td class="normal">User Type </td><td><asp:DropDownList ID="ddUserType" runat="server">
                    <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Tenant" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Maintenance" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Accounting" Value="4"></asp:ListItem>
                    
                    </asp:DropDownList></td></tr>
                    <tr><td class="normal" width="100">Email *</td><td><asp:TextBox Width="200" ID="txtEmail" runat="server" MaxLength="100"></asp:TextBox> </td></tr>
                     
                    <tr><td class="normal">Password *</td><td><asp:TextBox  Width="200"  ID="txtPassword" runat="server" MaxLength="100"></asp:TextBox> </td></tr>
                     
                    
                    <tr>
                                        <td class="normal_txt" width="154">
                                            Title<span class="mandatory">*</span>
                                        </td>
                                        <td width="500">
                                        <asp:DropDownList ID="ddTitle" runat="server" style="width:180px;">
                                        <asp:ListItem Text="Mr" Value="Mr">Mr</asp:ListItem>
                                        <asp:ListItem Text="Mrs" Value="Mrs">Mrs</asp:ListItem>
                                        <asp:ListItem Text="Miss" Value="Miss">Miss</asp:ListItem>
                                        </asp:DropDownList>
                                         
                                        </td>
                                    </tr>
                    <tr><td class="normal">Firstname</td><td><asp:TextBox ID="txtfname" runat="server" Width="200"></asp:TextBox> </td></tr>
                     <tr><td class="normal">Lastname</td><td><asp:TextBox ID="txtlastname" runat="server" Width="200"></asp:TextBox> </td></tr>
                      <tr><td class="normal">Phone</td><td><asp:TextBox ID="txtPhone" runat="server" Width="200"></asp:TextBox> </td></tr>
                       <tr><td class="normal">Address1</td><td><asp:TextBox ID="txtAddress1" TextMode="MultiLine" runat="server" Width="200"></asp:TextBox> </td></tr>
                        <tr><td class="normal">Address2</td><td><asp:TextBox ID="txtAddress2" TextMode="MultiLine" runat="server" Width="200"></asp:TextBox> </td></tr>
                         <tr><td class="normal">Postal Code</td><td><asp:TextBox ID="txtPostal" runat="server" Width="200"></asp:TextBox> </td></tr>
                          <tr><td class="normal">County</td><td><asp:TextBox ID="txtCounty" runat="server" Width="200"></asp:TextBox> </td></tr>
                           <tr><td class="normal">Country</td><td><asp:TextBox ID="txtCountry" runat="server" Width="200"></asp:TextBox> </td></tr>
                        <tr><td colspan="2" height="10">&nbsp;</td></tr>
                            <tr><td colspan="2" align="center"> <asp:LinkButton ID="txtSubmit" runat="server" onclick="txtSubmit_Click"><img src="images/submit.png" alt="SUBMIT" width="109" height="34" border="0" /></asp:LinkButton></td></tr>
                    </table>
                    </td></tr>
                    <tr><td colspan="2" height="10">&nbsp;</td></tr>
                    </table>
                   </div>
            
        </div>
    </div>
</asp:Content>
