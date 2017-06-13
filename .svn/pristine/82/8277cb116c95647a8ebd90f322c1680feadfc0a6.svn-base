<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="SendSubAppInvitation.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SendSubAppInvitation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <style>
        .btnsend
        {
            background: #3498db;
            background-image: -webkit-linear-gradient(top, #3498db, #2980b9);
            background-image: -moz-linear-gradient(top, #3498db, #2980b9);
            background-image: -ms-linear-gradient(top, #3498db, #2980b9);
            background-image: -o-linear-gradient(top, #3498db, #2980b9);
            background-image: linear-gradient(to bottom, #3498db, #2980b9);
            -webkit-border-radius: 15;
            -moz-border-radius: 15;
            border-radius: 15px;
            font-family: Arial;
            color: #ffffff;
            font-size: 15px;
            padding: 10px 20px 10px 20px;
            text-decoration: none;
        }
        
        .btnsend:hover
        {
            background: #3cb0fd;
            background-image: -webkit-linear-gradient(top, #3cb0fd, #3498db);
            background-image: -moz-linear-gradient(top, #3cb0fd, #3498db);
            background-image: -ms-linear-gradient(top, #3cb0fd, #3498db);
            background-image: -o-linear-gradient(top, #3cb0fd, #3498db);
            background-image: linear-gradient(to bottom, #3cb0fd, #3498db);
            text-decoration: none;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="webmangement_wrapper">
                <div id="webmangement_rightcol">
                    <div id="divAppUsagePage">
                        <div class="webmangement_rightcol_heading">
                            Send Affiliate App Invitation</div>
                        <div class="clear5">
                        </div>
                        <div>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td align="center" style="color: green; font-size: 14px; font-weight: bold;">
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                        <table cellspacing="0" cellpadding="0" width="50%" border="0">
                                            <tr>
                                                <td align="left" style="color: Red; font-size: 14px; font-weight: normal;">
                                                    <asp:ValidationSummary ID="valDownloads" runat="server" ValidationGroup="search"
                                                        HeaderText="The following error(s) occurred:" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="90%" border="0" style="padding: 15px;
                                margin: 0px auto;">
                                <colgroup>
                                    <col width="300" />
                                    <col width="340" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="right" style="padding-right: 10px; padding-bottom: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="padding-right: 10px; padding-bottom: 10px;">
                                        Enter the <strong>USER ID NUMBER</strong> and <strong>ADMINISTRATOR Login Email Address
                                        </strong>of the App to be listed as a favorite on your App and click Verify. When
                                        the App information appears, click Send. An email will be sent notifying the App
                                        Administrator that an invitation is available on their dashboard.
                                    </td>
                                </tr>
                                <tr class='app-usage-row'>
                                    <td>
                                        <b>Enter</b>&nbsp;
                                        <asp:TextBox ID="txtUserID" runat="server" Width="160px" placeholder="Primary User ID"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqdate" runat="server" ControlToValidate="txtUserID"
                                            ValidationGroup="search" Display="Dynamic" ErrorMessage="User ID is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtUserID"
                                            ValidationExpression="^[0-9]*$" ValidationGroup="search" Display="Dynamic" ErrorMessage="Invalid User ID">*</asp:RegularExpressionValidator>
                                        <a href="javascript:openWin2('<%=Page.ResolveClientUrl("~/sampleaffiliateuser.htm")%>')"><img src="../../images/Dashboard/new.png"></a>
                                    </td>
                                    <td>
                                        <b>AND</b>&nbsp;
                                        <asp:TextBox ID="txtEmailID" runat="server" Width="160px" placeholder="Primary Login Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmailID"
                                            ValidationGroup="search" Display="Dynamic" ErrorMessage="Email ID is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailID"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="search"
                                            Display="Dynamic" ErrorMessage="Invalid Email ID">*</asp:RegularExpressionValidator>
                                        <a href="javascript:openWin2('<%=Page.ResolveClientUrl("~/sampleaffiliatelogin.htm")%>')"><img src="../../images/Dashboard/new.png"></a>
                                    </td>
                                    <td align="left" valign="top" class="usage-button">
                                        <asp:Button ID="btnSearch" Text="Verify" runat="server" ValidationGroup="search"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center" style="padding-top: 10px;">
                                        <asp:Label ID="lblErrorMessage" runat="server" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Panel runat="server" ID="pnlInvitation" Visible="false">
                                            <div style="border: 1px solid gray; min-height: 260px; border-radius: 10px;">
                                                <table>
                                                    <colgroup>
                                                        <col width="150px" />
                                                        <col width="*" />
                                                    </colgroup>
                                                    <tr>
                                                        <td colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            User ID:
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblUserID" Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblDisplayName" Text="Name:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblProfileName" Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Login Email ID:
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblEmailID" Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Message:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox>
                                                            <asp:HiddenField runat="server" ID="hdnDefaultNotes" Value="An AFFILIATE LINK message is now available on your #ChildProfileName# Dashboard. By clicking the link in the message on your Dashboard, your APP will be included as a FAVORITE and available for display on the #ParentProfileName# APP." />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:LinkButton runat="server" CssClass="btnsend" Text="Send Invitation" OnClick="btnSend_OnClick"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table width="100%">
                            <tr>
                                <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnCancel" runat="server" Text="Dashboard" PostBackUrl="~/Business/MyAccount/Default.aspx"
                                        CausesValidation="false" />
                                    &nbsp;
                                    <asp:Button ID="btnManageSubApps" runat="server" Text="Manage Sub-Apps" OnClick="btnManageSubApps_OnClick" />
                                </td>
                            </tr>
                        </table>
                        <div class="clear10">
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function openWin2(url) {
            window.open(url, "composerwindow", "toolbar=no,width=700,height=400,status=no,scrollbars=no,resize=no,menubar=no");
        } 
    </script>
</asp:Content>
