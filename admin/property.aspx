<%@ Page Title="Admin Panel : Properties (Add/Edit)" Language="C#" MasterPageFile="~/admin/admin.master"
    AutoEventWireup="true" CodeFile="property.aspx.cs" Inherits="admin_property" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
    <div class="view">
        <div class="view1">
            <div class="view4">
                
                <table width="100%" border="0" class="view5aa">
                    <tr>
                        <td height="20" class="view5">
                            <%=PageTitle%>
                        </td>
                        <td  align="right">
                           
                            </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="10">
                            &nbsp;
                        </td>
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
                                    <td class="normal" >
                                        Abbreviation *
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtAbbreviation" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="NReq" ControlToValidate="txtAbbreviation"
                    Display="None" ErrorMessage="A property abbreviation is required." ValidationGroup="prp" />
                <cc1:validatorcalloutextender runat="Server" ID="NReqE" TargetControlID="NReq" 
                                            HighlightCssClass="validatorCalloutHighlight" />
                                    </td>
                                    <td class="normal" >
                                        Name *
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtname" runat="server" MaxLength="100"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtname"
                    Display="None" ErrorMessage="A property name is required."  ValidationGroup="prp"/>
                <cc1:validatorcalloutextender runat="Server" ID="ValidatorCalloutExtender1" 
                                            TargetControlID="RequiredFieldValidator1" 
                                            HighlightCssClass="validatorCalloutHighlight" />
                                    </td>
                                </tr>
                                <tr>                                   
                                    <td class="normal" >
                                        State *
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtState" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Street
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtStreet" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td class="normal" >
                                        Street No
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtStreetNo" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        BuildingType *
                                    </td>
                                    <td>
                                       <asp:DropDownList ID="ddBuildingType" runat="server">
                                       <asp:ListItem Text="House" Value="House">House</asp:ListItem>
                                       <asp:ListItem Text="Apartment" Value="Apartment">Apartment</asp:ListItem>
                                       </asp:DropDownList>
                                    </td>
                                    <td class="normal" >
                                        Zip
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtZip" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        County 
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtCountry" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td class="normal" >
                                        Floors
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtFloors" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal"  colspan="2" align="left">
                                        Image
                                    </td>
                                    <td colspan="2">
                                        <asp:FileUpload ID="uploadImage" runat="server" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="normal"  colspan="2" align="left">
                                        Short Description
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox Width="200" ID="txtShortDesc" runat="server" MaxLength="100" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="normal"  colspan="2" align="left">
                                        Long Description
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox Width="200" ID="txtLongDesc" runat="server" MaxLength="100" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Multi Unit
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddMultiUnit" runat="server">
                                        <asp:ListItem Value="True" Text="Yes">Yes</asp:ListItem>
                                        <asp:ListItem Value="False" Text="No">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="normal" >
                                        Owner
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddowner" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Parcel No
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtParcelNo" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td class="normal" >
                                        Portfolio
                                    </td>
                                    <td>
                                       <asp:DropDownList ID="ddPortfolio" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="normal" >
                                        Maintenance Assign Date.
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtDate" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td class="normal" >
                                        Maintenance Mgr Id
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddmgr" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="normal" >
                                        Rent
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtRent" runat="server" MaxLength="100"></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                    ControlToValidate="txtRent" Display="None" 
                                                    ErrorMessage="Please provide valid rent<br> Decimal value is required" 
                                                    ValidationExpression="^\d{1,3}(\.\d{0,2})?$" ValidationGroup="prp"></asp:RegularExpressionValidator>
                                                    <cc1:validatorcalloutextender ID="ValidatorCalloutExtender4" 
                                            runat="server" TargetControlID="RegularExpressionValidator1">
                                        </cc1:validatorcalloutextender>
                                    </td>
                                    <td class="normal" >
                                        Deposit 
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtDeposit" runat="server" MaxLength="100"></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="valEmail" runat="server" 
                                                    ControlToValidate="txtDeposit" Display="None" 
                                                    ErrorMessage="Please provide valid desposit<br> Decimal value is required" 
                                                    ValidationExpression="^\d{1,3}(\.\d{0,2})?$" ValidationGroup="prp"></asp:RegularExpressionValidator>
                                                    <cc1:validatorcalloutextender ID="ValidatorCalloutExtender3" 
                                            runat="server" TargetControlID="valEmail"></cc1:validatorcalloutextender>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="normal" >
                                        Sqaure ft. *
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtSqrFt" runat="server" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td class="normal" >
                                        Use *
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddUse" runat="server">
                                        <asp:ListItem Text="Residential" Value="Residential">Residential</asp:ListItem>                                        
                                        <asp:ListItem Text="Commercial" Value="Commercial">Commercial</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <!--
                                <tr>
                                    <td class="normal" >Select Unit. *</td>
                                    <td>
                                        <asp:CheckBoxList runat="server" ID="chkunit">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                -->
                                <tr>
                                    <td colspan="4" height="10">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:LinkButton ID="txtSubmit" runat="server" OnClick="txtSubmit_Click" ValidationGroup="prp"><img src="images/submit.png" alt="SUBMIT" width="109" height="34" border="0" /></asp:LinkButton>
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

    <asp:Panel ID="pnlunitadd" runat="server" Visible="false">
    <div class="view">
        <div class="view1">
            <div class="view4">
                
                <table width="100%" border="0" class="view5aa">
                    <tr>
                        <td height="20" class="view5">Add Unit for <%=PropertyName %></td>
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
                                    <td class="normal">Title*</td>
                                    <td><asp:TextBox ID="txttitle" runat="server" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttitle" Display="None" ErrorMessage="Please enter title." SetFocusOnError="True" TabIndex="1" ValidationGroup="uni"></asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
                                    </td>
                                <tr>
                                    <td class="normal">Garage</td>
                                    <td>
                                    <asp:DropDownList id="drdgarage" runat="server">
                                        <asp:ListItem Text="0" Value="0">0</asp:ListItem>
                                        <asp:ListItem Text="1" Value="1">1</asp:ListItem>
                                        <asp:ListItem Text="2" Value="2">2</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    <td class="normal">LeaseTerms *</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txtleaseterms" runat="server" MaxLength="100"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtleaseterms" Display="None" ErrorMessage="Please enter Lease Terms." SetFocusOnError="True" TabIndex="2" ValidationGroup="uni"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"></cc1:ValidatorCalloutExtender>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtleaseterms" Display="None" ErrorMessage="Please provide valid Lease Terms." ValidationExpression="^\d{0,2}(\.\d{1,2})?$" ValidationGroup="uni"></asp:RegularExpressionValidator>
                                         <cc1:validatorcalloutextender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RegularExpressionValidator1">
                                        </cc1:validatorcalloutextender>                                             
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal">Last Modified Date</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txtlastmod" runat="server"></asp:TextBox>
                                         <cc1:CalendarExtender ID="txtlastmod_CalendarExtender" runat="server" TargetControlID="txtlastmod">
                                         </cc1:CalendarExtender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtlastmod" Display="None" ErrorMessage="Please select last modified date." SetFocusOnError="True" TabIndex="3" ValidationGroup="uni"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RequiredFieldValidator3"></cc1:ValidatorCalloutExtender>
                                    </td>
                                    <td class="normal">Last Modified By</td>
                                    <td><asp:TextBox Width="200" ID="txtlastmodby" runat="server" MaxLength="100"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="normal">Long Description</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txtldesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td class="normal">Notes</td>
                                    <td><asp:TextBox Width="200" ID="txtnotes" runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="normal">Pets</td>
                                    <td><asp:DropDownList id="drdpets" runat="server">
                                        <asp:ListItem Text="Yes" Value="True">Yes</asp:ListItem>
                                        <asp:ListItem Text="No" Value="False">No</asp:ListItem>
                                    </asp:DropDownList></td>
                                    <td class="normal" >Ready</td>
                                    <td><asp:DropDownList id="drdready" runat="server">
                                        <asp:ListItem Text="Yes" Value="True">Yes</asp:ListItem>
                                        <asp:ListItem Text="No" Value="False">No</asp:ListItem>
                                    </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="normal">Short Description</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txtsdesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td class="normal" >Smoking</td>
                                    <td><asp:DropDownList id="drdsmoking" runat="server">
                                        <asp:ListItem Text="Yes" Value="True">Yes</asp:ListItem>
                                        <asp:ListItem Text="No" Value="False">No</asp:ListItem>
                                    </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="normal">Target Deposit*</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txttargetdpst" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txttargetdpst" Display="None" ErrorMessage="Please enter valid target deposite." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$" ValidationGroup="uni"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RegularExpressionValidator3">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txttargetdpst" Display="None" ErrorMessage="Please enter Target Deposit." SetFocusOnError="True" TabIndex="4" ValidationGroup="uni"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="Nreq_1" runat="server" TargetControlID="RequiredFieldValidator5"></cc1:ValidatorCalloutExtender>
                                    </td>
                                    <td class="normal">Target Rent*</td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txttargetrent" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txttargetrent" Display="None" ErrorMessage="Please enter valid target rent." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$" ValidationGroup="uni"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RegularExpressionValidator4">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txttargetrent" Display="None" ErrorMessage="Please enter Target Rent." SetFocusOnError="True" TabIndex="5" ValidationGroup="uni"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="Nreq_2" runat="server" TargetControlID="RequiredFieldValidator6"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal">Bathroom*</td>
                                    <td>
                                         <asp:TextBox Width="200" ID="txtbathroom" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtbathroom" Display="None" ErrorMessage="Please enter valid Bathroom." ValidationExpression="^\d{0,2}(\.\d{1,2})?$" ValidationGroup="uni"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RegularExpressionValidator5">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbathroom" Display="None" ErrorMessage="Please enter number of Bathrooms." SetFocusOnError="True" TabIndex="6" ValidationGroup="uni"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="RequiredFieldValidator7"></cc1:ValidatorCalloutExtender>
                                    </td>
                                    <td class="normal">Bedrooms*</td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtbedroom" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbedroom" Display="None" ErrorMessage="Please enter number of Bedrooms." SetFocusOnError="True" TabIndex="7" ValidationGroup="uni"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="RequiredFieldValidator8"></cc1:ValidatorCalloutExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtbedroom" Display="None" ErrorMessage="Please enter valid Bedrooms." ValidationExpression="^\d{0,2}(\.\d{1,2})?$" ValidationGroup="uni"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="Nreq_3" runat="server" TargetControlID="RegularExpressionValidator6">
                                        </cc1:validatorcalloutextender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal">Floor*</td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtfloor" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtfloor" Display="None" ErrorMessage="Please enter valid Floor." ValidationExpression="^\d{0,2}(\.\d{1,2})?$" ValidationGroup="uni"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RegularExpressionValidator7">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtfloor" Display="None" ErrorMessage="Please enter Floor." SetFocusOnError="True" TabIndex="8" ValidationGroup="uni"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" TargetControlID="RequiredFieldValidator9"></cc1:ValidatorCalloutExtender>
                                    </td>
                                    <td class="normal">Square Feet*</td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtsqft" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtsqft" Display="None" ErrorMessage="Please enter valid Square Feet." ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$" ValidationGroup="uni"></asp:RegularExpressionValidator>
                                        <cc1:validatorcalloutextender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="RegularExpressionValidator8">
                                        </cc1:validatorcalloutextender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtsqft" Display="None" ErrorMessage="Please enter Square Feet." SetFocusOnError="True" TabIndex="9" ValidationGroup="uni"></asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="RequiredFieldValidator10"></cc1:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal">Unit Type</td>
                                    <td>
                                    <asp:DropDownList id="drdunittype" runat="server">
                                        <asp:ListItem Text="Apartment" Value="Apartment">Apartment</asp:ListItem>
                                        <asp:ListItem Text="House" Value="House">House</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    <td class="normal">Unit Use</td>
                                    <td>
                                    <asp:DropDownList id="drdunituse" runat="server">
                                        <asp:ListItem Text="Commercial" Value="Commercial">Commercial</asp:ListItem>
                                        <asp:ListItem Text="Residential" Value="Residential">Residential</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal">Unit Status</td>
                                    <td>
                                    <asp:DropDownList id="drdunitstatus" runat="server">
                                        <asp:ListItem Text="Vacant" Value="Vacant">Vacant</asp:ListItem>
                                        <asp:ListItem Text="Pending" Value="Pending">Pending</asp:ListItem>
                                        <asp:ListItem Text="Occupied" Value="Occupied">Occupied</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" height="10">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:LinkButton ID="txtSubmit1" runat="server" OnClick="txtSubmit1_Click" ValidationGroup="uni"><img src="images/submit.png" alt="SUBMIT" width="109" height="34" border="0" /></asp:LinkButton>
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
    
    </asp:Panel>
    <asp:Panel ID="pnlunit" runat="server" Visible="false">
<div class="view">
        <div class="view1">
            <div class="view4">
                
                <table width="100%" border="0" class="view5aa">
                        <td height="20" class="view5">Select Unit:&nbsp;&nbsp;&nbsp;<asp:DropDownList runat="server" ID="ddunit" AutoPostBack="true" onselectedindexchanged="ddunit_SelectedIndexChanged"></asp:DropDownList></td>
                        <tr>
                        <td colspan="2" height="10">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table style="color: #000000" width="100%" class="normal">
                                <tr>
                                    <td colspan="4" height="10">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="normal"><b>Title:</b></td>
                                    <td><asp:Label ID="lbltitle" runat="server"></asp:Label></td>
                                    <td class="normal"><b>Unit Status:</b></td>
                                    <td>
                                        <asp:Label ID="lblunitstatus" runat="server"></asp:Label>
                                    </td>
                                <tr>
                                    <td class="normal"><b>Garage:</b></td>
                                    <td>
                                      <asp:Label ID="lblgarage" runat="server"></asp:Label>
                                    </td>
                                    <td class="normal" ><b>LeaseTerms:</b></td>
                                    <td>
                                        <asp:Label ID="lblleaseterms" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal"><b>Last Modified Date:</b></td>
                                    <td>
                                        <asp:Label ID="lblmdate" runat="server"></asp:Label>
                                    </td>
                                    <td class="normal"><b>Last Modified By:</b></td>
                                    <td>
                                        <asp:Label ID="lbllmb" runat="server"></asp:Label>                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal"><b>Long Description:</b></td>
                                    <td>
                                        <asp:Label ID="lbllongdesc" runat="server"></asp:Label>                                    
                                    </td>
                                    <td class="normal"><b>Notes:</b></td>
                                    <td>
                                        <asp:Label ID="lblnotes" runat="server"></asp:Label>                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal"><b>Pets:</b></td>
                                    <td>
                                        <asp:Label ID="lblpets" runat="server"></asp:Label>                                    
                                    </td>
                                    <td class="normal" ><b>Ready:</b></td>
                                    <td>
                                        <asp:Label ID="lblready" runat="server"></asp:Label>                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal"><b>Short Description:</b></td>
                                    <td>
                                        <asp:Label ID="lblsdesc" runat="server"></asp:Label>
                                    </td>
                                    <td class="normal" ><b>Smoking:</b></td>
                                    <td>
                                        <asp:Label ID="lblsmoking" runat="server"></asp:Label>                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal"><b>Target Deposit:</b></td>
                                    <td>
                                        <asp:Label ID="lbltarget" runat="server"></asp:Label>
                                    </td>
                                    <td class="normal"><b>Target Rent:</b></td>
                                    <td>
                                        <asp:Label ID="lbltargetrent" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal"><b>Bathroom:</b></td>
                                    <td>
                                        <asp:Label ID="lblbathroom" runat="server"></asp:Label>
                                    </td>
                                    <td class="normal"><b>Bedrooms:</b></td>
                                    <td>
                                        <asp:Label ID="lblbedroom" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal"><b>Floor:</b></td>
                                    <td>
                                        <asp:Label ID="lblfloor" runat="server"></asp:Label>
                                    </td>
                                    <td class="normal"><b>Square Feet:</b></td>
                                    <td>
                                        <asp:Label ID="lblsqfeet" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal"><b>Unit Type:</b></td>
                                    <td>
                                        <asp:Label ID="lblunittype" runat="server"></asp:Label>
                                    </td>
                                    <td class="normal"><b>Unit Use:</b></td>
                                    <td>
                                        <asp:Label ID="lblunituse" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" height="10">&nbsp;</td>
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
    </asp:Panel>
</asp:Content>
