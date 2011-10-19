<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="admin_Invoice" %>

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
                        <td height="20" class="view5">
                            Add Invoice
                        </td>
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
                                    <td class="normal" >Invoice Title*</td>
                                    <td>
                                        <asp:TextBox ID="txtinvoicetitle" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtinvoicetitle" Display="None" ErrorMessage="Please enter Invoice Title." />
                                        <cc1:validatorcalloutextender runat="Server" ID="NReqE1_1" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />                                                                                
                                    </td>
                                    <td class="normal" ></td>
                                    <td>&nbsp;</td>
                                </tr>                                
                                <tr>
                                    <td class="normal" >Invoice Date*</td>
                                    <td>
                                        <asp:TextBox ID="txtinvoicedate" runat="server" MaxLength="100"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtinvoicedate"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="txtinvoicedate" Display="None" ErrorMessage="Please select Invoice Date." />
                                        <cc1:validatorcalloutextender runat="Server" ID="NReqE1" TargetControlID="RequiredFieldValidator7" HighlightCssClass="validatorCalloutHighlight" />                                                                                
                                    </td>
                                    <td class="normal" >Select Lease. *</td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlease" Width="200"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Balance Due*
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtbalancedue" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="NReq1" ControlToValidate="txtbalancedue" Display="None" ErrorMessage="Please enter Balance Due." />
                                        <cc1:validatorcalloutextender runat="Server" ID="NReqE2" TargetControlID="NReq1" HighlightCssClass="validatorCalloutHighlight" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtbalancedue" Display="None" ErrorMessage="Please enter valid Balance Due." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RegularExpressionValidator4">
                                        </cc1:validatorcalloutextender>                                        
                                    </td>
                                    <td class="normal" >
                                        Created By 
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtcreatedby" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >Due Date*</td>
                                    <td>
                                        <asp:TextBox ID="txtduedate" runat="server" MaxLength="100"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtduedate"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtduedate" Display="None" ErrorMessage="Please select Due Date." />
                                        <cc1:validatorcalloutextender runat="Server" ID="NReqE12" TargetControlID="RequiredFieldValidator6" HighlightCssClass="validatorCalloutHighlight" />                                                                                
                                    </td>
                                    <td class="normal" >Email Sent Date*</td>
                                    <td>
                                        <asp:TextBox ID="txtemailsentdate" runat="server" MaxLength="100"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtemailsentdate"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="txtemailsentdate" Display="None" ErrorMessage="Please select Email Sent Date." />
                                        <cc1:validatorcalloutextender runat="Server" ID="NReqE9" TargetControlID="RequiredFieldValidator8" HighlightCssClass="validatorCalloutHighlight" />                                                                                
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        For Month Of
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtformonthof" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td class="normal" >
                                        Invoice Note
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtinvoicenote" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Send By Email *
                                    </td>
                                    <td>
                                    <asp:DropDownList ID="ddsendbyemail" runat="server">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    <td class="normal" >
                                        Select Unit*
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddunit" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>                             
                                <tr>
                                    <td colspan="4" height="10">
                                        &nbsp;
                                    </td>
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


