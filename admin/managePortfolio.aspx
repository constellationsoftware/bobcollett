<%@ Page Title="Admin Panel : Portfolio (Add/Edit)" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="managePortfolio.aspx.cs" Inherits="admin_managePortfolio" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        
        .confirm
        {
            background-color: White;
            padding: 10px;
            width: 370px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript">

     //  keeps track of the delete button for the row

     //  that is going to be removed

     var _source;

     // keep track of the popup div

     var _popup;



     function showConfirm(source) {

         this._source = source;

         this._popup = $find('mdlPopup');



         //  find the confirm ModalPopup and show it   

         this._popup.show();

     }



     function okClick() {

         //  find the confirm ModalPopup and hide it   

         this._popup.hide();

         //  use the cached button as the postback source

         __doPostBack(this._source.name, '');

     }



     function cancelClick() {

         //  find the confirm ModalPopup and hide it

         this._popup.hide();

         //  clear the event source

         this._source = null;

         this._popup = null;

     }
        
    </script>
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div id="progressBackgroundFilter">
            </div>
            <div id="processMessage">
                Please Wait .....</div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <cc1:ModalPopupExtender ID="md1" runat="server" BackgroundCssClass="modalBackground"
        BehaviorID="mdlPopup" CancelControlID="btnNo" OkControlID="btnOk" OnCancelScript="cancelClick();"
        OnOkScript="okClick();" PopupControlID="div" TargetControlID="div">
    </cc1:ModalPopupExtender>
    <div id="div" runat="server" align="center" class="confirm" style="display: none;
        height: 100px; border: 2px solid black">
        <br />
        <br />
        Are you sure you want to delete ?
        <asp:Button ID="btnOk" runat="server" Text="Yes" Width="50px" />
        <asp:Button ID="btnNo" runat="server" Text="No" Width="50px" />
    </div>
    <div class="view">
        <div class="view1">
            <form id="form1" name="form1" method="post" action="" class="form">
            <div class="view4">
                <div class="view5">
                    <table width="100%">
                        <tr>
                            <td width="85%">
                                Manage Portfolio
                            </td>
                            <td align="right">
                                <a href="Portfolio.aspx" title="Add Portfolio"> Add Portfolio</a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="view5aa">
                    <div class="view">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="center" style="color: #000000">
                                            <br />
                                            <%=message%>
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="gvPortfolio" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both"
                                    AutoGenerateColumns="false" OnRowDataBound="gvPortfolio_RowDataBound" OnRowCommand="gvPortfolio_RowCommand"
                                    Width="90%" onrowdeleting="gvPortfolio_RowDeleting">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField AccessibleHeaderText="Name" HeaderText="Name" DataField="Name"
                                            SortExpression="Name" />
                                        <asp:TemplateField AccessibleHeaderText="Abbreviation" HeaderText="Abbreviation" ItemStyle-VerticalAlign="Middle"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserType" runat="server" Text='<%# Eval("Ownerid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField AccessibleHeaderText="Options" HeaderText="Options" ItemStyle-VerticalAlign="Middle"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="images/drop.png" ID="Button1" runat="server" CausesValidation="False" CommandName="Delete"
                                                    CommandArgument='<%# Eval("PortfolioId") %>' OnClick="Button1_Click" OnClientClick="showConfirm(this); return false;"
                                                    Text="Delete" />
                                                <a href="Portfolio.aspx?fid=<%# Eval("PortfolioId") %>">
                                                    <img alt="Edit" src="images/Update.png" title="Edit" border="0" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
</asp:Content>

