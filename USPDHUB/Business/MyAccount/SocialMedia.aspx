<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="SocialMedia.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SocialMedia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <div id="webmangement_wrapper">
        <div id="webmangement_rightcol">
            <div id="divSocialMediaPage">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="content">
                            <div class="webmangement_rightcol_heading">
                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                <span style="color: Black; font-size: 14px; margin: 0px; padding: 0px; position: absolute;
                                    margin-left: 230px; margin-top: 0px;">
                                    <asp:Label runat="server" ID="lblOn" Visible="false">Displayed on App: <font class="showonapp">On</font></asp:Label>
                                    <asp:Label runat="server" ID="lblOff">Displayed on App: <font class="showoffapp">Off</font></asp:Label>
                                </span>
                            </div>
                            <div style="padding-left: 80px; text-align: center;">
                                <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                            </div>
                            <div id="webmangement_body">
                                <div>
                                    <strong>Note:</strong> <a id="A3" href="javascript:ModalHelpPopup('Add Social Media Links',159,'');">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                </div>
                                <div style="padding-left: 10px;">
                                    Adding social network URL’s will allow you to display them on the App.</div>
                                <div class="socialmedia_wrapper">
                                    <div class="socialmedia_selectmenu">
                                        Facebook Profile URL:
                                    </div>
                                    <div class="socialmedia_checkbox">
                                        <asp:TextBox ID="txtfacebook" runat="server" Width="300px"></asp:TextBox>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="socialmedia_wrapper">
                                    <div class="socialmedia_selectmenu">
                                        Twitter Profile URL:
                                    </div>
                                    <div class="socialmedia_checkbox">
                                        <asp:TextBox ID="txttwitter" runat="server" Width="300px"></asp:TextBox>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="socialmedia_wrapper">
                                    <div class="socialmedia_selectmenu">
                                        Youtube URL:
                                    </div>
                                    <div class="socialmedia_checkbox">
                                        <asp:TextBox ID="txtYoutube" runat="server" Width="300px"></asp:TextBox>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="socialmedia_wrapper">
                                    <div class="socialmedia_selectmenu">
                                        Instagram Profile URL:
                                    </div>
                                    <div class="socialmedia_checkbox">
                                        <asp:TextBox ID="txtInstagram" runat="server" Width="300px"></asp:TextBox>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div id="divsubmitnew">
                                    <asp:ImageButton ID="btnSubmt" runat="server" ImageUrl="../../images/Dashboard/submit.png"
                                        OnClientClick="return ValidateSocialMedia();" OnClick="btnSubmt_Click"></asp:ImageButton>
                                    <asp:HiddenField runat="server" ID="hdnPermissionType" />
                                     <asp:HiddenField runat="server" ID="hdnSocialMediaPermission" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="height: 161px;">
                </div>
            </div>
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
        function ValidateSocialMedia() {
            var fbUrl = document.getElementById('<%=txtfacebook.ClientID %>').value;
            var twUrl = document.getElementById('<%=txttwitter.ClientID %>').value;
            var youtubeUrl = document.getElementById('<%=txtYoutube.ClientID %>').value;
            var instagUrl = document.getElementById('<%=txtInstagram.ClientID %>').value;
            var errMsg = "";

            if (fbUrl != "" && fbUrl != "https://" && fbUrl != "http://") {
                if (!(/^((http|https):\/\/)?(www[.])?([a-zA-Z0-9]|-)+([.][a-zA-Z0-9(-|\/|=|?)?]+)+$/i.test(fbUrl)))
                    errMsg = "Please enter valid facebook profile url.\n";

            }
            if (twUrl != "" && twUrl != "https://" && twUrl != "http://") {
                if (!(/^((http|https):\/\/)?(www[.])?([a-zA-Z0-9]|-)+([.][a-zA-Z0-9(-|\/|=|?)?]+)+$/i.test(twUrl)))
                    errMsg = errMsg + "Please enter valid twitter profile url.";

            }
            if (youtubeUrl != "" && youtubeUrl != "https://" && youtubeUrl != "http://") {
                if (!(/^((http|https):\/\/)?(www[.])?([a-zA-Z0-9]|-)+([.][a-zA-Z0-9(-|\/|=|?)?]+)+$/i.test(youtubeUrl)))
                    errMsg = "Please enter valid youtube url.\n";

            }
            if (instagUrl != "" && instagUrl != "https://" && instagUrl != "http://") {
                if (!(/^((http|https):\/\/)?(www[.])?([a-zA-Z0-9]|-)+([.][a-zA-Z0-9(-|\/|=|?)?]+)+$/i.test(instagUrl)))
                    errMsg = errMsg + "Please enter valid instagram profile url.";

            }
            if (errMsg != "") {
                alert(errMsg);
                return false;
            }
            else
                return true;

        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblcreateshortcut" runat="server"></asp:Label>
            <asp:ModalPopupExtender ID="popcreateshortcut" runat="server" TargetControlID="lblcreateshortcut"
                PopupControlID="pnlcreateshortcut" BackgroundCssClass="modal" BehaviorID="createshortcut"
                CancelControlID="imgclse">
            </asp:ModalPopupExtender>
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
                                <asp:ImageButton ID="imgclse" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid" style="padding: 5px; text-align: center;">
                                <div style="text-align: center;">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
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
