<%@ Page Title="" Language="C#" MasterPageFile="~/Business/MyAccount/CallIndexMaster.Master"
    AutoEventWireup="true" CodeBehind="SetupCallIndexInvitation.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SetupCallIndexInvitation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser1" runat="server">
    <style>
        .row-wrapper
        {
            width: 640px;
            margin: 0px;
        }
    </style>
    <div>
        <asp:HiddenField runat="server" ID="hdnPermissionType" />
        <div id="webmangement_leftcol1">
            <div id="divGeneralAppSettingsPage">
                <div style="margin-top: 10px;">
                    <asp:Label ID="lblstatusmessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </div>
                <div class="clear10">
                </div>
                <asp:Panel runat="server" ID="pnlSetup">
                    <div class="row-wrapper">
                        <div class="leftcol">
                            <span>Setup Contacts</span><br />
                            Setup Contacts and manage groups to email invitations for viewing your private buttons.
                        </div>
                        <div class="rightcol" style="width: 140px;">
                            <asp:ImageButton ID="btnSetupcontact" runat="server" ImageUrl="~/images/Dashboard/setupcontacts.png"
                                OnClick="btnSetupcontact_OnClick" />
                            <asp:HiddenField ID="hdnIsLiteVersion" runat="server" Value="false" />
                        </div>
                    </div>
                    <div class="clear5">
                    </div>
                    <div class="row-wrapper">
                        <div class="leftcol">
                            <span>Send Invitations</span><br />
                            Send Invitations to contacts so that the Private Call Directory Button will display
                            on their device.
                            <br />
                            <br />
                            <b>Note</b>: The Private Call Directory Button will only display on devices that
                            accept your invitation.
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
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                <asp:Button ID="btnBack" runat="server" Text="Dashboard" CausesValidation="false"
                                    OnClick="btnBack_OnClick" Width="100px" Height="28px" Style="font-weight: bold;
                                    font-size: 14px;" /><asp:HiddenField ID="hdnPrevioulUrl" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
