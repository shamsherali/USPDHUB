<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="UpgradeSelectPayType.aspx.cs" Inherits="USPDHUB.Admin.UpgradeSelectPayType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <div>
        <div class="clear15">
        </div>
        <div class="adminpagehead">
        <%if (pnlActivate.Visible == false)
          { %>
            Select Payment Type<%}
          else
          { %>
            Activate Premium Membership
            <%} %></div>
        <div align="center">
            <img src="../images/Admin/shadow-title.png" /></div>
        <div class="adminformwrap">
            <div class="clear10">
            </div>
            <div class="errormsg_text">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
            <div class="submitadm">
                <asp:Panel ID="pnlSelectPay" runat="server">
                    <asp:Button ID="btnCard" runat="server" Text="Credit Card" OnClick="btnCard_Click" />&nbsp;<asp:Button
                        ID="btnBill" runat="server" Text="Bill Me" OnClick="btnBill_Click" />
                </asp:Panel>
                <asp:Panel ID="pnlActivate" runat="server" Visible="false">
                    <asp:Button ID="btnActivatePremium" runat="server" Text="Activate Premium" OnClick="btnActivatePremium_Click" />
                </asp:Panel>
            </div>
        </div>
        <asp:HiddenField ID="hdnDomain" runat="server" />
        <asp:HiddenField ID="hdnSetupFee" runat="server" />
        <asp:HiddenField ID="hdnSetupSID" runat="server" />
    </div>
</asp:Content>
