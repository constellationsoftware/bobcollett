<%@ Page Title="Admin Panel : Portfolio (Add/Edit)" Language="C#" MasterPageFile="~/admin/admin.master"
    AutoEventWireup="true" CodeFile="Portfolio.aspx.cs" Inherits="AdminPortfolio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
    <div class="view">
        <div class="view1">
            <div class="view4">
                <asp:RequiredFieldValidator runat="server" ID="NReq" ControlToValidate="txname" Display="None" ErrorMessage="A Portfolio name is required." />
                <cc1:ValidatorCalloutExtender runat="Server" ID="NReqE" TargetControlID="NReq" HighlightCssClass="validatorCalloutHighlight" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtAbbreviation"
                    Display="None" ErrorMessage="A Abbreviation is required." />
                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1"
                    HighlightCssClass="validatorCalloutHighlight" />
                <table width="100%" border="0" class="view5aa">
                    <tr>
                        <td height="20" class="view5">
                            Add Portfolio
                        </td>
                        <td width="250" align="right">
                            Add Portfolio
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="10">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table style="color: #000000" width="500" class="normal" border="0">
                                <tr>
                                    <td colspan="2" height="10" align="right">
                                        <span class="mandatory">Field marked with* are mandatory.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="10">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="10">
                                        <table width="100%">
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <%=message%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" width="250">
                                        Name *
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txname" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" width="250">
                                        Abbreviation&nbsp; *
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtAbbreviation" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                            <!--
                                <tr>
                                    <td class="normal" width="250">
                                        Default Bank Account<span class="mandatory">*</span>
                                    </td>
                                    <td width="500">
                                        <asp:DropDownList ID="ddDefaultBank" runat="server" Style="width: 180px;">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" width="250">
                                        Default Security Bank Account
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddDefaultSecurity" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" width="250">
                                        Account Closing Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" Width="200"></asp:TextBox>
                                        <cc1:CalendarExtender  runat="server"
    TargetControlID="txtDate"
    CssClass="ClassName"
    Format="MMMM d, yyyy"
    PopupButtonID="images/Calendar.png" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" width="250">
                                        Maintenance Spending Limit
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtlimit" runat="server" Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" width="250">
                                        Portfolio Minimum
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMinimum" runat="server" Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                                -->
                                <tr>
                                    <td class="normal" width="250">
                                        Owner
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOwner" runat="server" Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="10">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
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
