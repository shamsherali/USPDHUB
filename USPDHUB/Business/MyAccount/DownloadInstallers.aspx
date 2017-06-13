<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="DownloadInstallers.aspx.cs" Inherits="USPDHUB.Business.MyAccount.DownloadInstallers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <style type="text/css">
        .couponcode
        {
            width: 100px;
        }
        .couponcode:hover .coupontooltip
        {
            display: inline-block;
        }
        .couponcode span
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            margin-left: 10px;
            margin-bottom: 100px;
            border: 1px dashed #297CCF;
            padding: 10px;
            position: absolute;
            z-index: 1000;
            width: 360px;
            height: 150px;
            color: Black;
        }
    </style>
    <div id="webmangement_wrapper">
        <div id="divGeneralAppSettingsPage">
            <div class="webmangement_rightcol_heading">
                Downloads
            </div>
            <div class="clear10">
            </div>
            <% if (Convert.ToBoolean(hdnIsLiteVersion.Value) && Session["VerticalDomain"].ToString().ToLower().Contains("inschoolalert"))
               { %>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>inSchoolAlert App Flyer</span><br />
                    Download a printable flyer that displays a QR Code for app users that<br />
                    takes them to their app store to install your app.
                </div>
                <div class="rightcol">
                    <asp:ImageButton ID="btnISAFlyer" runat="server" OnClick="btnISAFlyer_OnClick" ImageUrl="~/images/Dashboard/download.png" />
                </div>
            </div>
            <div class="clear5">
            </div>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>Desktop PC Notifications Manager</span> &nbsp;&nbsp; <span class="couponcode">
                        <img border="0" src="../../images/Dashboard/new.png" />
                        <span class="coupontooltip">The Desktop Notifications Manager will install a widget
                            on your PC's desktop that will alert you in a pop up window when a notification
                            has been sent. Click the pop up to open the Notifications Message Center. By clicking
                            the Share Now link, you may email the Notifications Manager to others so they may
                            also install the Manager on their desktop.</span></span><br />
                    Install the Notifications Manager to receive desktop alerts of incoming notifications.
                    <br />
                    You can share the Notification Manager to your community. <a href="javascript:openEmailwindow('ShareDownloads.aspx')">
                        Share Now</a>
                </div>
                <div class="rightcol">
                    <asp:ImageButton ID="imgISANotifcations" runat="server" OnClick="btnISANotifications_OnClick"
                        ImageUrl="~/images/Dashboard/download.png" />
                </div>
            </div>
            <%}
               else
               {%>
                <% if (!Convert.ToBoolean(Session["IsBranded"]))
                   { %>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>
                        <%=App_DisplayName%>
                        App Flyer</span><br />
                    Download a printable flyer that displays a QR Code for app users that
                    <br />
                    takes them to their app store to install your app.
                </div>
                <div class="rightcol">
                    <asp:ImageButton ID="btnUSPDFlyer" runat="server" OnClick="btnUSPDFlyer_OnClick"
                        ImageUrl="~/images/Dashboard/download.png" />
                </div>
            </div>
            <div class="clear5">
            </div>
            <%} %>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>Shortcut</span><br />
                    Install the desktop shortcut to conveniently access your account.
                </div>
                <div class="rightcol">
                    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="btnshortcut_OnClick" ImageUrl="~/images/Dashboard/download.png" />
                </div>
            </div>
            <div class="clear5">
            </div>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>Notifications Manager</span><br />
                    Install the Notifications Manager to receive desktop alerts of incoming messages.
                </div>
                <div class="rightcol">
                    <asp:ImageButton ID="ImageButton2" runat="server" OnClick="btnTipsmanager_OnClick"
                        ImageUrl="~/images/Dashboard/download.png" />
                </div>
            </div>
            <div class="clear5">
            </div>
            <% if (Convert.ToBoolean(Session["IsBranded"]))
               { %>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>Branded App Flyer</span><br />
                    Download the flyer for your branded app.
                </div>
                <div class="rightcol">
                    <asp:ImageButton ID="btnBranded" runat="server" OnClick="btnBranded_OnClick" ImageUrl="~/images/Dashboard/download.png" />
                </div>
            </div>
            <div class="clear5">
            </div>
            <%} %>
            <% if (Convert.ToBoolean(Session["IsBranded"]))
               { %>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>QR Code</span><br />
                    Download the QR code for your branded app.
                </div>
                <div class="rightcol">
                    <asp:ImageButton ID="imgBtnQRcodeDownload" runat="server" OnClick="imgBtnQRcodeDownload_OnClick"
                        ImageUrl="~/images/Dashboard/download.png" />
                </div>
            </div>
            <div class="clear5">
            </div>
            <%} %>
            <%} %>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>Getting Started</span><br />
                    Some things you may want to think about when setting up your app.
                </div>
                <div class="rightcol">
                    <asp:ImageButton ID="imgBtnGetStarted" runat="server" OnClick="imgBtnGetStarted_OnClick"
                        ImageUrl="~/images/Dashboard/download.png" />
                </div>
            </div>
            <div class="clear5">
            </div>
            <asp:HiddenField ID="hdnIsLiteVersion" runat="server" Value="false" />
        </div>
    </div>
    <div style="background-color: #D2E5FA; border: 1px solid #D1DDEA; height: 35px; width: 985px;">
        <div style="margin: 0px auto 0px auto; padding-top: 5px; text-align: center;">
            <asp:Button ID="btnCancel" runat="server" Text="Dashboard" OnClick="btnCancel_Click" />
        </div>
    </div>
    <script type="text/javascript">

        function ShortCut() {
            var modalDialog = $find("createshortcut");
            var iframe = document.getElementById('frmShortcut');
            var innerDoc = iframe.contentDocument || iframe.contentWindow.document;
            innerDoc.getElementById('chkCreate').checked = false;
            modalDialog.show();
        }
        function ShowAssociateMSG() {
            alert('You do not have sufficient permissions.');
            return false;
        }
        function Installation() {
            if (confirm("Setup file sucessfully downloaded. Do you want to install setup file?")) {
                MyObject = new ActiveXObject("WScript.Shell")
                var setupFilePath = document.getElementById("<%=hdnCopyPath.ClientID %>").value + "setup.exe";
                MyObject.Run(setupFilePath);
            }
        }
        function DownloadInstaller(type) {
            document.getElementById("<%=hdnInstallerName.ClientID %>").value = type;
            var modalDialog = $find("downloadinstaller");
            modalDialog.show();
        }
        function openEmailwindow(url) {
            window.open(url, '', "width=700,height=650,scrollbars=no,toolbars=yes,status=yes,resizable=yes").focus();
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblcreateshortcut" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popcreateshortcut" runat="server" TargetControlID="lblcreateshortcut"
                PopupControlID="pnlcreateshortcut" BackgroundCssClass="modal" BehaviorID="createshortcut"
                CancelControlID="imgclose">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlcreateshortcut" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="80%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="left">
                                <div class="pageheading">
                                    &nbsp; Create Shortcut
                                </div>
                            </td>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imgclose" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid" style="padding: 5px; text-align: center;">
                                <div style="text-align: center;">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b> <font color="green">Processing....</font>
                                            </b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Font-Names="arial" Font-Size="14px"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <iframe src="../../ProfileIframes/UrlShortCut.aspx" frameborder="0" scrolling="no"
                                    height="100%" width="100%" style="border: 0px;" id="frmShortcut"></iframe>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnCopyPath" runat="server" />
            <asp:HiddenField ID="hdnInstallerName" runat="server" Value="1" />
            <asp:Label ID="lbldownload" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lbldownload"
                PopupControlID="Paneldownload" BackgroundCssClass="modal" BehaviorID="downloadinstaller"
                CancelControlID="ImageButton3">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="Paneldownload" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="80%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="left">
                                <div class="pageheading">
                                    &nbsp; Download Installer
                                </div>
                            </td>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid" style="padding: 5px; text-align: center;">
                                <div style="text-align: center;">
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="1">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b> <font color="green">Processing....</font>
                                            </b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="Label2" runat="server" ForeColor="Green" Font-Names="arial" Font-Size="14px"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table style="font-family: Segoe UI; font-size: 14px;">
                                    <tr>
                                        <td valign="top">
                                            Installer Folder Path:
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtfolderpath" runat="server" ValidationGroup="ABC1" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtfolderpath"
                                                runat="server" ErrorMessage="Download file path is mandatory." Display="Dynamic"
                                                ValidationGroup="ABC1" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <br />
                                            <span style="text-align: left; margin: 0px;">Ex: <b>D:\\Softwares\\</b></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
