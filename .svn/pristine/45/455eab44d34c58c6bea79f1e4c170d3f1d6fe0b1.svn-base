<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="SelectPayType.aspx.cs" Inherits="USPDHUB.Admin.SelectPayType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <div>
        <div class="clear15">
        </div>
        <div class="adminpagehead">
            Select Payment Type</div>
        <div align="center">
            <img src="../images/Admin/shadow-title.png" /></div>
        <div class="adminformwrap">
            <div class="clear10">
            </div>
            <div class="errormsg_text">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
            <asp:Panel ID="pnlSubscriptions" runat="server" Visible="false">
                <div class="labeladm">
                    <strong>Subscription Type:</strong></div>
                <div class="txtfildwrap2" align="left">
                    <asp:DropDownList ID="ddlSubscriptions" runat="server" CssClass="selectmen-big">
                    </asp:DropDownList>
                </div>
                <div class="clear15">
                </div>
            </asp:Panel>
            <div class="submitadm">
                <asp:Panel ID="pnlSelectPay" runat="server">
                    <asp:Button ID="btnCard" runat="server" Text="Credit Card" OnClick="btnCard_Click" />&nbsp;<asp:Button
                        ID="btnBill" runat="server" Text="Bill Me" OnClick="btnBill_Click" />&nbsp;<asp:Button
                            ID="btnFree" runat="server" Text="Free" OnClick="btnFree_Click" />&nbsp;<asp:Button
                                ID="lnkMainScreen" runat="server" Text="Go to Main Screen" OnClick="lnkMainScreen_OnClick" />
                </asp:Panel>
                <asp:LinkButton ID="lnkActivateAcnt" runat="server" CausesValidation="false" OnClick="lnkActivateAcnt_Click"><img src="../images/Admin/aaccount.png" alt="" /></asp:LinkButton>
                <asp:LinkButton ID="lnkMainScreen1" runat="server" CausesValidation="false" OnClick="lnkMainScreen_OnClick"><img src="../images/Admin/gtmscreen-btn.png" alt="" /></asp:LinkButton>
            </div>
        </div>
        <asp:HiddenField ID="hdnDomain" runat="server" />
        <asp:HiddenField ID="hdnSetupFee" runat="server" />
        <asp:HiddenField ID="hdnSetupSID" runat="server" />
    </div>
</asp:Content>
