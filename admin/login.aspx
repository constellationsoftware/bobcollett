<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CrossRoads Property : Admin Login Panel</title>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/pngfix.js" type="text/javascript" defer="defer"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptmgr" runat="server">
    </asp:ScriptManager>
   
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsername"
        ErrorMessage="Username is required." Display="None" runat="server"></asp:RequiredFieldValidator>
    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1"
        HighlightCssClass="highlight">
    </cc1:ValidatorCalloutExtender>
     <asp:RequiredFieldValidator ID="PNReq" ControlToValidate="txtPassword" ErrorMessage="Pass is required."
        Display="None" runat="server"></asp:RequiredFieldValidator>
    <cc1:ValidatorCalloutExtender runat="Server" ID="PNReqE" TargetControlID="PNReq"
        HighlightCssClass="highlight">
    </cc1:ValidatorCalloutExtender>
    <div class="maindiv">
        <div class="innerdiv">
            <div class="header">
                <div class="dav_logo">
                    <img src="images/logo.png" alt="" width="215" height="73" /></div>
                <div class="administrator_ab">
                    <img src="images/login.png" alt="" width="338" height="90" /></div>
            </div>
            <div class="c1">
                <div class="c2">
                 <center><%=message%></center>
                                       <div class="c4">
                                      
                        <div class="c5">
                        </div>
                        <div class="c6">
                            <div class="c7">
                                <div class="c7a">
                                    Username</div>
                                <div class="c8">
                                    <label>
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="f1"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                            <div class="c7">
                                <div class="c7a">
                                    Password</div>
                                <div class="c8">
                                    <label>
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="f1"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                            <div class="c8a">
                                <asp:LinkButton ID="txtLogin" runat="server" onclick="txtLogin_Click"><img src="images/submit.png" alt="SUBMIT" width="109" height="34" border="0" /></asp:LinkButton>
                            </div>
                        </div>
                        <div class="c6a">
                            <img src="images/login2.jpg" alt="" width="413" height="28" /></div>
                        <div class="clear">
                        </div>
                    </div>
                   
                </div>
            </div>
            <div class="c3">
                <img src="images/footer.png" alt="" width="953" height="96" /></div>
        </div>
        <div class="clear">
        </div>
    </div>
    </form>
</body>
</html>
