<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="SetupInvitation.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SetupInvitation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <div id="webmangement_wrapper">
        <div id="webmangement_leftcol">
            <div class="clear10">
            </div>
            <div class="webmangement_rightcol_rowbg">
                <div class="webmangement_rightcol_rowbg_heading13">
                    <img src="../../images/dashboard/invitation-h.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/SetupInvitation.aspx")%>">
                        Manage Private Button</a></span>
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hdnPermissionType" />
        <div id="webmangement_leftcol1">
            <div id="divGeneralAppSettingsPage">
                <h1 style="margin-left: 150px; margin-top: 10px;">
                    <asp:Label runat="server" ID="lblButtonName" Text="Private22"></asp:Label></h1>
                <div style="margin-top: 10px;">
                    <asp:Label ID="lblstatusmessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </div>
                <div class="clear10">
                </div>
                <asp:Panel runat="server" ID="pnlSetup">
                    <div class="row-wrapper">
                        <div class="leftcol">
                            <span>Setup Contacts</span><br />
                            Setup Contacts and manage groups to email invitations for viewing your private
                            buttons.
                        </div>
                        <div class="rightcol" style="width: 140px;">
                            <asp:ImageButton ID="btnSetupcontact" runat="server" ImageUrl="~/images/Dashboard/setupcontacts.png"
                                OnClick="btnSetupcontact_OnClick" />
                        </div>
                    </div>
                    <div class="clear5">
                    </div>
                    <div class="row-wrapper">
                        <div class="leftcol">
                            <span>Send Invitations</span><br />
                            Send Invitations to contacts so that the Private Button will display on their device.
                            <br />
                            <br />
                            <b>Note</b>: The Private Button and Content will only display on devices that accept
                            your invitation.
                        </div>
                        <div class="rightcol" style="width: 140px;">
                            <asp:ImageButton ID="btnSendInvitation" runat="server" ImageUrl="~/images/Dashboard/sendinvitations.png"
                                OnClick="btnSendInvitation_OnClick" />
                        </div>
                    </div>
                    <div class="clear5">
                    </div>
                    <div class="row-wrapper">
                        <div class="leftcol" style="width: 400px;">
                            <span>Manage Invitations</span><br />
                            Enable, Disable or Delete invitations to add devices.
                        </div>
                        <div class="rightcol" style="width: 165px;">
                            <asp:ImageButton ID="btnManageInvitation" OnClick="btnManageInvitation_OnClick" runat="server"
                                ImageUrl="~/images/Dashboard/manageinvitations.png" />
                        </div>
                    </div>
                    <div class="clear5">
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
