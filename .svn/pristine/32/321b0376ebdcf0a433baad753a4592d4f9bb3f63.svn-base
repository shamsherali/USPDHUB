<%@ Page Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="AppManagement.aspx.cs" Inherits="USPDHUB.Business.MyAccount.AppManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <div id="webmangement_wrapper">
        <div id="webmangement_leftcol">
            <div class="webmangement_leftcol_heading">
                Mobile App Management
                <asp:HiddenField ID="hdnPreviousDivID" runat="server" />
            </div>
            <div class="webmangement_rightcol_rowbg">
                <div class="webmangement_rightcol_rowbg_heading13" id="divGeneralAppSettings">
                    <img src="../../images/dashboard/gen-app-settings-s.png" /><span> <a href="javascript:void(0);"
                        onclick="ChangeWebPage('divGeneralAppSettings');">General App Settings</a> </span>
                </div>
                <div class="webmangement_rightcol_rowbg_heading14" id="divManageLogins">
                    <%if (ShowBulletins)
                      {
                    %>
                    <%if (IsSuperAdmin)
                      { %>
                    <img src="../../images/dashboard/manage-logins.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx")%>">
                        Manage Logins</a> </span>
                    <%}
                      else
                      { %>
                    <img src="../../images/dashboard/manage-logins.png" /><span> <a href="#" onclick="ShowAssociateMSG();">
                        Manage Logins</a> </span>
                    <%} %>
                    <%
                      }
                      else
                      {
                    %>
                    <img src="../../images/dashboard/manage-logins.png" /><span> <a href="javascript:ModalPopupsAlert1('Premium Plus Tools', '<div style=\'padding:25px;\'><table cellpadding=\'0\' cellspacing=\'0\' border=\'0\'><tr><td><table width=\'100%\' border=\'0\' cellspacing=\'0\' cellpadding=\'0\'><tr><td class=\'ftrs-text\'><span>Mobile App</span><ul><li>Displays Bulletins</li><li>Send Notifications</li><li>Custom Buttons</li><li>Multiple Logins</li><li>Displays Web Links</li></ul></td></tr></table><table width=\'100%\' border=\'0\' cellspacing=\'0\' cellpadding=\'0\'><tr><td align=\'center\'><%=Upgradeurl %></td></tr></table></td></tr></table></div>')">
                        Manage Logins</a> </span>
                    <%
                      }%>
                </div>
                <div class="webmangement_rightcol_rowbg_heading14" id="divManageWebLinks">
                    <%if (ShowBulletins)
                      {
                    %><img src="../../images/dashboard/web-links.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageWebLinks.aspx")%>">
                        Web Links</a> </span>
                    <%
                      }
                      else
                      {
                    %>
                    <img src="../../images/dashboard/web-links.png" /><span> <a href="javascript:ModalPopupsAlert1('Premium Plus Tools', '<div style=\'padding:25px;\'><table cellpadding=\'0\' cellspacing=\'0\' border=\'0\'><tr><td><table width=\'100%\' border=\'0\' cellspacing=\'0\' cellpadding=\'0\'><tr><td class=\'ftrs-text\'><span>Mobile App</span><ul><li>Displays Bulletins</li><li>Send Notifications</li><li>Custom Buttons</li><li>Multiple Logins</li><li>Displays Web Links</li></ul></td></tr></table><table width=\'100%\' border=\'0\' cellspacing=\'0\' cellpadding=\'0\'><tr><td align=\'center\'><%=Upgradeurl %></td></tr></table></td></tr></table></div>')">
                        Web Links</a> </span>
                    <%
                      }%>
                </div>
                <%--<div class="webmangement_rightcol_rowbg_heading14" id="divShortcut">
                <img src="../../images/dashboard/create-destop-shortcut.png" /><span><a href="javascript:ShortCut();">Create
                Desktop Shortcut</a></span>
                </div>--%>
                <div class="webmangement_rightcol_rowbg_heading14" id="divSocialMedia">
                    <img src="../../images/dashboard/Social-media.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/SocialMedia.aspx")%>">
                        Social Media</a> </span>
                </div>
                <%--<div class="webmangement_rightcol_rowbg_heading14">
                    <img src="../../images/dashboard/download_n.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/DownloadInstallers.aspx")%>">
                        Downloads</a></span></div>--%>
                <div class="webmangement_rightcol_rowbg_heading14">
                    <img src="../../images/dashboard/appdownloads.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/AppUsageReports.aspx")%>">App
                        Usage Report</a></span></div>
                <%if (IsParent && IsBranded)
                  { %>
                <div class="webmangement_rightcol_rowbg_heading14">
                    <img src="../../images/dashboard/invitations.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/SendInvitation.aspx")%>">Setup
                        Affiliate Apps</a></span></div>
                <%} %>
                <%if (IsBlockedSendAccess)
                  {%>
                <div class="webmangement_rightcol_rowbg_heading14">
                    <img src="../../images/dashboard/blocksenders.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageBlockedSenders.aspx")%>">Manage
                        Blocked Senders</a></span></div>
                <%}
                  else
                  {
                %>
                <div class="webmangement_rightcol_rowbg_heading14">
                    <img src="../../images/dashboard/blocksenders.png" /><span> <a href="#" onclick="ShowAssociateMSG();">
                        Manage Blocked Senders</a> </span>
                </div>
                <%}%>
                <div class="webmangement_rightcol_rowbg_heading14">
                    <img src="../../images/dashboard/resource.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/WebWidget.aspx")%>">
                      Resources</a></span></div>
            </div>
        </div>
        <div id="webmangement_rightcol">
            <div id="divGeneralAppSettingsPage">
                <div class="webmangement_rightcol_heading">
                    Manage App Settings
                </div>
                <div class="clear10">
                </div>
                <div class="row-wrapper">
                    <div class="leftcol">
                        <span>Manage Basic Information</span><br />
                        Update your name, address, phone and fax numbers.
                    </div>
                    <div class="rightcol">
                        <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ModifyProfileDetails.aspx?App=1")%>">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" />
                        </a>
                    </div>
                </div>
                <div class="clear5">
                </div>
                <div class="row-wrapper">
                    <div class="leftcol">
                        <span>Manage Description</span><br />
                        Update your description.
                    </div>
                    <div class="rightcol">
                        <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ProfileDescription.aspx?App=1")%>">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" />
                        </a>
                    </div>
                </div>
                <div class="clear5">
                </div>
                <div class="row-wrapper">
                    <div class="leftcol">
                        <span>Manage About Us Information</span><br />
                        Update your information. About Us will display from a button on the App.
                    </div>
                    <div class="rightcol" style="margin-top: 15px;">
                        <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/AboutUs.aspx?App=1")%>">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" />
                        </a>
                    </div>
                </div>
                <div class="clear5">
                </div>
                <div class="row-wrapper">
                    <div class="leftcol">
                        <span>App Display Settings</span><br />
                        Choose which features and information to display on the Mobile App.
                    </div>
                    <div class="rightcol">
                        <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/MobileAppSettings.aspx")%>">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" />
                        </a>
                    </div>
                </div>
                <div class="clear5">
                </div>
                <div class="row-wrapper">
                    <div class="leftcol">
                        <span>Logo</span><br />
                        <!-- *** Fix for IRH-36 25-01-2013 *** -->
                        Upload an image that displays on your App.
                    </div>
                    <div class="rightcol">
                        <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ModifyLogo.aspx?App=1")%>">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" />
                        </a>
                    </div>
                </div>
                <div class="clear5">
                </div>
            </div>
        </div>
    </div>
    <div style="background-color: #D2E5FA; border: 1px solid #D1DDEA; height: 35px;">
        <div style="margin: 0px auto 0px auto; padding-top: 5px; text-align: center;">
            <asp:Button ID="btnCancel" runat="server" Text="Dashboard" OnClick="btnCancel_Click" />
        </div>
    </div>
    <script type="text/javascript">
        function ChangeWebPage(id) {
            var previousID = "";
            if (document.getElementById('<%=hdnPreviousDivID.ClientID %>').value == "")
                previousID = 'divGeneralAppSettings';
            else
                previousID = document.getElementById('<%=hdnPreviousDivID.ClientID %>').value;
            if (id != previousID) {
                $('#' + id).removeClass('webmangement_rightcol_rowbg_heading2').addClass('webmangement_rightcol_rowbg_heading1');
                $('#' + id + 'Page').css('display', 'block');
                $('#' + previousID).removeClass('webmangement_rightcol_rowbg_heading1').addClass('webmangement_rightcol_rowbg_heading2');
                $('#' + previousID + 'Page').css('display', 'none');
                document.getElementById('<%=hdnPreviousDivID.ClientID %>').value = id;
            }
        }
        window.onload = function () {
            if (document.getElementById('<%=hdnPreviousDivID.ClientID %>').value == "") {
                $('#divGeneralSettingsPage').css('display', 'block');
            }
        }
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
</asp:Content>
