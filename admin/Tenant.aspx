<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="Tenant.aspx.cs" Inherits="admin_Tenant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
    <div class="view">
        <div class="view1">
            <div class="view4">
                
                <table width="100%" border="0" class="view5aa">
                    <tr>
                        <td height="20" class="view5"><%=PageTitle %></td>
                        <td  align="right"></td>
                    </tr>
                    <tr>
                        <td colspan="2" height="10">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table style="color: #000000" width="100%" class="normal">
                                <tr>
                                    <td colspan="4" height="10" align="right">
                                        <span class="mandatory">Field marked with* are mandatory.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" height="10">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" height="10">
                                        <table width="100%" cellpadding="4">
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <%=message%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >Select Property*</td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="drdproperty" Width="200" onselectedindexchanged="drdproperty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                    <td class="normal" >Select Unit. *</td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddunit" Width="200"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal">First Name*</td>
                                    <td><asp:TextBox ID="txtfname" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfname" Display="None" ErrorMessage="Please enter First Name." SetFocusOnError="True" TabIndex="1"></asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
                                    </td>
                                    <td class="normal">Last Name*</td>
                                    <td><asp:TextBox ID="txtlname" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtlname" Display="None" ErrorMessage="Please enter Last Name." SetFocusOnError="True" TabIndex="2"></asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" TargetControlID="RequiredFieldValidator10"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >Phone Cell *</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txtphonecell" runat="server" MaxLength="20"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtphonecell" Display="None" ErrorMessage="Please enter Phone Cell." SetFocusOnError="True" TabIndex="3"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator2"></cc1:ValidatorCalloutExtender>                                             
                                    </td>
                                    <td class="normal">Phone Land Line</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txtphoneland" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal">Phone Work</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txtphonework" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="normal">Email Address *</td>
                                    <td><asp:TextBox Width="200" ID="txtemailaddress" runat="server" MaxLength="100"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="normal">Emergency Phone</td>
                                    <td><asp:TextBox Width="200" ID="txtemergencyphone" runat="server" MaxLength="20"></asp:TextBox></td>
                                    <td class="normal" >Employer</td>
                                    <td><asp:TextBox Width="200" ID="txtemployer" runat="server" MaxLength="100"></asp:TextBox></td>                                    
                                </tr>
                                <tr>
                                    <td class="normal" >Emergency Reference</td>
                                    <td><asp:TextBox Width="200" ID="txtemerrefrence" runat="server" MaxLength="100"></asp:TextBox></td>
                                    <td class="normal">Amount in Escrow</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txtamount" runat="server" MaxLength="10"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtamount" Display="None" ErrorMessage="Please enter valid Amount in Escrow." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator2">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtamount" Display="None" ErrorMessage="Please enter Amount in Escrow." SetFocusOnError="True" TabIndex="4"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RequiredFieldValidator4"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" height="10">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:LinkButton ID="txtSubmit" runat="server" OnClick="txtSubmit_Click"><img src="images/submit.png" alt="SUBMIT" width="109" height="34" border="0" /></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="10">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

