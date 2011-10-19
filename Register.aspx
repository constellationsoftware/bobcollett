<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
    <div id="mid">
        <div id="left">
            <h2>
                Register&nbsp; to <span class="blue_txt">Crossroads Property Management</span></h2>
            <tbody>
                <tr>
                    <td height="10">
                    <%=message%>
                    </td>
                </tr>
                <tr>
                    <td class="normal_txt_bold">
                        <div id="ctl00_ContentPlaceHolder1_pnlEmail">
                            <fieldset class="rating_bg fieldset">
                                <legend class="legend">Login Information</legend>
                                <table align="center" border="0" cellpadding="4" cellspacing="0" width="654">
                                    <tbody>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="normal_txt" width="154">
                                                Email ID<span class="mandatory">*</span>
                                            </td>
                                            <td width="500">
                                                <asp:TextBox ID="txtemail" runat="server" MaxLength="150" style="width:180px;" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtemail" Display="None" ErrorMessage ="Email id is required field."></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="valEmail" runat="server" 
                                                    ControlToValidate="txtemail" Display="None" 
                                                    ErrorMessage="Please provide valid email id" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                <cc1:ValidatorCalloutExtender ID="valval" runat="server" TargetControlID="reqEmail"></cc1:ValidatorCalloutExtender>
                                                 <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="valEmail"></cc1:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="normal_txt">
                                                Password<span class="mandatory">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="150" style="width:180px;" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage ="Password is required field."></asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="normal_txt">
                                                Confirm Password<span class="mandatory">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtConfirm" runat="server" MaxLength="150" style="width:180px;" ></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtConfirm" ErrorMessage ="Confirm password is required field."></asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2"></cc1:ValidatorCalloutExtender>
                                                <asp:CompareValidator ID="cdCompare" runat="server" ControlToCompare="txtPassword" Display="None" ControlToValidate="txtConfirm" ErrorMessage="Confirm password not matched"></asp:CompareValidator>
                                                
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="cdCompare"></cc1:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </fieldset>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset class="rating_bg fieldset">
                            <legend class="legend">Contact Details</legend>
                            <table align="center" border="0" cellpadding="4" cellspacing="0" width="654">
                                <tbody>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
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
                                    <tr>
                                        <td class="normal_txt">
                                            First Name<span class="mandatory">*</span>
                                        </td>
                                        <td>
                                           <asp:TextBox ID="txtfname" runat="server" MaxLength="150" style="width:180px;" ></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtfname" ErrorMessage ="First name is required field."></asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator3"></cc1:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="normal_txt">
                                            Surname<span class="mandatory">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSurname" runat="server" MaxLength="150" style="width:180px;" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="normal_txt" >
                                            Telephone<span class="mandatory">*</span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtPhone" ErrorMessage ="Phone is required field."></asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator4"></cc1:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="150" style="width:180px;" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="normal_txt">
                                            Address1
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress1" runat="server" MaxLength="150" style="width:180px;" TextMode="MultiLine" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="normal_txt">
                                            Address2
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress2" runat="server" MaxLength="150" style="width:180px;" TextMode="MultiLine" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="normal_txt">
                                            Postalcode
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPostal" runat="server" MaxLength="150" style="width:180px;" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="normal_txt">
                                            County/Town
                                        </td>
                                        <td>
                                             <asp:TextBox ID="txtCounty" runat="server" MaxLength="150" style="width:180px;" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="normal_txt">
                                            Country
                                        </td>
                                        <td>
                                             <asp:TextBox ID="txtCountry" runat="server" MaxLength="150" style="width:180px;" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td style="display: none;">
                        <div id="ctl00_ContentPlaceHolder1_pnlWordVeri">
                            <fieldset class="rating_bg fieldset">
                                <legend class="legend">Word Verification</legend>
                                <table align="center" border="0" cellpadding="4" cellspacing="0" width="654">
                                    <tbody>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="normal_txt" width="154">
                                                Word Verification
                                            </td>
                                            <td class="normal_txt" width="500">
                                                                                                       <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtVerify"
                                                            ErrorMessage="You have Entered a Wrong Verification Code! <br/>Please Re-enter!!!"
                                                            OnServerValidate="CAPTCHAValidate"></asp:CustomValidator>
<asp:RequiredFieldValidator ID="reqCapcta" runat="server" Display="None" ControlToValidate="txtVerify" ErrorMessage="Verification words are required"></asp:RequiredFieldValidator>
<cc1:ValidatorCalloutExtender ID="valVerification" runat="server" TargetControlID="reqCapcta"></cc1:ValidatorCalloutExtender>
                                                        <asp:Image ID="imCaptcha" ImageUrl="~/Captcha.ashx" runat="server" />
                                                        <asp:TextBox ID="txtVerify" runat="server"></asp:TextBox>
                                                       
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </fieldset>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
                    </td>
                </tr>
            </tbody>
        </div>
        <%--<div id="right">
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
        </div>--%>
    </div>
</asp:Content>
