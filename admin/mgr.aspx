<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="mgr.aspx.cs" Inherits="admin_mgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="scriptmgr" runat="server"></asp:ScriptManager>
<div class="view">
        <div class="view1">
            <div class="view4">
                <asp:RequiredFieldValidator runat="server" ID="NReq" ControlToValidate="txtmgrname" Display="None" ErrorMessage="Mgr name is required." />
                <cc1:ValidatorCalloutExtender runat="Server" ID="NReqE" TargetControlID="NReq" HighlightCssClass="validatorCalloutHighlight" />
                <table width="100%" border="0" class="view5aa">
                    <tr>
                        <td height="20" class="view5">
                            Add Mgr
                        </td>
                        <td width="250" align="right">
                            Add Mgr
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
                                        Mgr Name*
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtmgrname" runat="server" MaxLength="100"></asp:TextBox>
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

