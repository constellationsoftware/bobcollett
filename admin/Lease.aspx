<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="Lease.aspx.cs" Inherits="admin_Lease" %>

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
                            Add Lease
                        </td>
                        <td  align="right">
                           
                            </td>
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
                                    <td colspan="4" height="10">
                                        &nbsp;
                                    </td>
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
                                    <td class="normal" >
                                        Tenant Name *
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtleasename1" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="NReq" ControlToValidate="txtleasename1" Display="None" ErrorMessage="Please enter Tenant Name." />
                                        <cc1:validatorcalloutextender runat="Server" ID="NReqE" TargetControlID="NReq" HighlightCssClass="validatorCalloutHighlight" />
                                    </td>
                                    <td class="normal" >
                                        Lease Name2 
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtleasename2" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Addendum
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtaddendum" runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td class="normal" >
                                        Adult Occupant
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtadultoccupant" runat="server" MaxLength="10"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtadultoccupant" Display="None" ErrorMessage="Please enter valid Adult Occupant." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="RegularExpressionValidator4"></cc1:validatorcalloutextender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Email Address1
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtemailaddress1" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtemailaddress1" Display="None" ErrorMessage="Please enter Email address1." />
                                        <cc1:validatorcalloutextender runat="Server" ID="Validatorcalloutextender1" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                                    </td>
                                    <td class="normal" >
                                        Email Address2
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtemailaddress2" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Inspection Date *
                                    </td>
                                    <td>
                                    <asp:TextBox ID="txtinspectiondate" Width="200" runat="server" MaxLength="100"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtinspectiondate_CalendarExtender" runat="server" 
                                            TargetControlID="txtinspectiondate">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtinspectiondate" Display="None" ErrorMessage="Please select Inspection date." />
                                        <cc1:validatorcalloutextender runat="Server" ID="Validatorcalloutextender2" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                                    </td>
                                    <td class="normal" >
                                        Late Fee Rule
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtlatefeerule" runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Lease Document
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:Panel ID="pnlupload" runat="server" Visible="false">
                                        <a href="../Lease/<%=filename_display %>">View Document</a>                                        
                                        </asp:Panel>
                                    </td>
                                    <td class="normal" >
                                        Lease End Date*
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtleasedate" runat="server" MaxLength="100"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtleasedate_CalendarExtender" runat="server" 
                                            TargetControlID="txtleasedate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal">
                                        Lease Start Date*
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtleasestartdate" runat="server" MaxLength="100"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtleasestartdate_CalendarExtender" runat="server" TargetControlID="txtleasestartdate">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td class="normal">
                                        Lease Phone1
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtleasephone" runat="server" MaxLength="20"></asp:TextBox>
                                    </td>                                                                        
                                </tr>
                                <tr>
                                    <td class="normal">
                                        Minor Occupants
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtminoroccumants" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtminoroccumants" Display="None" ErrorMessage="Please enter valid Minor Occupant." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="RegularExpressionValidator5"></cc1:validatorcalloutextender>
                                    </td>
                                    <td class="normal">
                                        Renewal Number
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtrenewal" runat="server" MaxLength="20" Width="200"></asp:TextBox>
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Fee Notes
                                    </td>
                                    <td>
                                    <asp:TextBox ID="txtfeenotes" runat="server" MaxLength="100" Width="200" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td class="normal" >
                                        Other Fee*
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtotherfee" runat="server" MaxLength="100" Width="200"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtotherfee" Display="None" ErrorMessage="Please enter valid other fee." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RegularExpressionValidator7">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtotherfee" Display="None" ErrorMessage="Please enter other fee." SetFocusOnError="True" TabIndex="9"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="RequiredFieldValidator9"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Pet Fee*
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtpetfee" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtpetfee" Display="None" ErrorMessage="Please enter valid pet fee." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RegularExpressionValidator2">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpetfee" Display="None" ErrorMessage="Please enter Pet Fee." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator3"></cc1:ValidatorCalloutExtender>
                                    </td>
                                    <td class="normal">
                                        Lease Phone2
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtleasephone2" runat="server" MaxLength="20" Width="200"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="normal" >
                                        Rental Amount*
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtrentalamount" runat="server" Width="200" MaxLength="10"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtrentalamount" Display="None" ErrorMessage="Please enter valid Rental Amount." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RegularExpressionValidator3">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtrentalamount" Display="None" ErrorMessage="Please enter Rental Amount." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RequiredFieldValidator4"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="normal" >
                                        Scheduled Inspection
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="drdschinspection">
                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                        <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="normal" >
                                        Security Deposit*
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtsecuritydeposit" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtsecuritydeposit" Display="None" ErrorMessage="Please enter valid Security Deposit." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator1">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtsecuritydeposit" Display="None" ErrorMessage="Please enter Rental Amount." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator5"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="normal" >
                                        Security Deposit Date *
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtsecdepdate" runat="server" MaxLength="100"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtsecdepdate" Display="None" ErrorMessage="Please enter Security Deposit Date." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RequiredFieldValidator6"></cc1:ValidatorCalloutExtender>
                                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtsecdepdate"></cc1:CalendarExtender>
                                    </td>
                                    <td class="normal" >
                                        Status *
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddstatus" runat="server">
                                        <asp:ListItem Text="Active" Value="Active">Active</asp:ListItem>
                                        <asp:ListItem Text="Completed" Value="Completed">Completed</asp:ListItem>
                                        <asp:ListItem Text="Pending" Value="Pending">Pending</asp:ListItem>
                                        </asp:DropDownList>
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

