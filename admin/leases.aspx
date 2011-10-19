<%@ Page Title="Admin Panel : Leases (Add/Edit)" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="leases.aspx.cs" Inherits="admin_leases" %>

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
                            Add Property
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
                    Display="None" ErrorMessage="A property abbreviation is required." />
                <cc1:ValidatorCalloutExtender runat="Server" ID="NReqE" TargetControlID="NReq" HighlightCssClass="validatorCalloutHighlight" />
                                    </td>
                                    <td class="normal" >
                                        Name *
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtname" runat="server" MaxLength="100"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtname"
                    Display="None" ErrorMessage="A property name is required." />
                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="normal" >
                                        Address*
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtAddress" runat="server" MaxLength="100"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtAddress"
                    Display="None" ErrorMessage="A property address is required." />
                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                                    </td>
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
                                        Country 
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
                                        <asp:TextBox Width="200" ID="txtOwner" runat="server" MaxLength="100"></asp:TextBox>
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
                                        <asp:TextBox Width="200" ID="txtmgrid" runat="server" MaxLength="100"></asp:TextBox>
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
                                                    ValidationExpression="^\d{1,3}(\.\d{0,2})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RegularExpressionValidator1"></cc1:ValidatorCalloutExtender>
                                    </td>
                                    <td class="normal" >
                                        Deposit 
                                    </td>
                                    <td>
                                        <asp:TextBox Width="200" ID="txtDeposit" runat="server" MaxLength="100"></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="valEmail" runat="server" 
                                                    ControlToValidate="txtDeposit" Display="None" 
                                                    ErrorMessage="Please provide valid desposit<br> Decimal value is required" 
                                                    ValidationExpression="^\d{1,3}(\.\d{0,2})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="valEmail"></cc1:ValidatorCalloutExtender>
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
                                        <asp:ListItem Text="Commercial" Value="Commercial">Commercial</asp:ListItem>
                                        <asp:ListItem Text="Residential" Value="Residential">Residential</asp:ListItem>
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

