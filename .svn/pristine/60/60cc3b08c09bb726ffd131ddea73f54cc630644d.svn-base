<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="UserPermissions.aspx.cs" Inherits="USPDHUB.Business.MyAccount.UserPermissions"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <style type="text/css">
        .couponcode
        {
            width: 100px;
            padding-top:5px;
        }
        .couponcode:hover .coupontooltip
        {
            display: inline-block;
        }
        .coupontooltip
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            margin-left: 2px;
            margin-bottom: 10px;
            border: 1px dashed #297CCF;
            padding: 10px;
            position: absolute;
            z-index: 1000;
            width: 350px;
            height: 60px;
            color: Black;
        }
    </style>
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
            <ContentTemplate>
                <div style="color: red;" align="center">
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="ContactEditInfo">
                    <%if (PermissionCnt == 0)
                      { %>
                    Create
                    <%}
                      else
                      { %>
                    Edit
                    <%} %>
                    Permissions for
                    <%=hdnuserflag.Value%>
                    <a id="ChangeAssociatePermissions" href="javascript:ModalHelpPopup('Change Associate Permissions',152,'');">
                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                </div>
                <div style="text-align: center;">
                    <asp:Label ID="lblstatusmessage" runat="server"></asp:Label>
                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                        <ProgressTemplate>
                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing"
                                style="color: Green; font-size: 12px;">Processing....</span>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <br />
                <div>
                    <div class="pricingtable">
                        <div class="pricediv">
                            <div class="features">
                                Feature</div>
                            <div class="author">
                                Create
                                <br />
                                <br />
                                <span>(Does not allow approval<br />
                                    for display on App)</span></div>
                            <div class="publisher">
                                Approve and Publish<br />
                                <br />
                                <span>(Allows for display on App)</span></div>
                        </div>
                        <div class="fcontainer">
                            <div class="columnmain dark">
                                <ul>
                                    <li>Bulletins</li>
                                    <%--<li>Updates</li>--%>
                                    <li>Event Calender</li>
                                    <li>Surveys</li>
                                </ul>
                            </div>
                            <div class="column light">
                                <ul>
                                    <li>
                                        <asp:CheckBox ID="chkBulletinsAuthor" runat="server" />
                                    </li>
                                    <%--<li>
                                        <asp:CheckBox ID="chkUpdatesAuthor" runat="server" />
                                    </li>--%>
                                    <li>
                                        <asp:CheckBox ID="chkEventsAuthor" runat="server" />
                                    </li>
                                    <li>
                                        <asp:CheckBox ID="chkSurveyAuthor" runat="server" />
                                    </li>
                                </ul>
                            </div>
                            <div class="column dark">
                                <ul>
                                    <li>
                                        <asp:CheckBox ID="chkBulletinsPublisher" runat="server" />
                                    </li>
                                    <%--<li>
                                        <asp:CheckBox ID="chkUpdatesPublisher" runat="server" />
                                    </li>--%>
                                    <li>
                                        <asp:CheckBox ID="chkEventsPublisher" runat="server" />
                                    </li>
                                    <li>
                                        <asp:CheckBox ID="chkSurveyPublisher" runat="server" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clear41">
                </div>
                <div style="padding-left: 65px; font-size: 12px; font-weight: bold; color: Black">
                    * Note: To allow access to the following areas, select the appropriate check boxes
                    below.
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 65px; font-weight: normal;">
                    <asp:CheckBox ID="chkMessageAuthor" runat="server" Text=" Manage Message Receipt" />
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 65px; font-weight: normal;">
                    <asp:CheckBox ID="chkPushAuthor" runat="server" Text=" Push Notifications" />&nbsp;&nbsp;
                    <asp:CheckBox ID="chkMButtonsAuthor" runat="server" Text=" Manage Buttons" />
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 65px; font-weight: normal;">
                    <asp:CheckBox ID="chkASettingsAuthor" runat="server" Text=" App Settings" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chkAuthorContacts" runat="server" Text=" Contacts" />
                </div>
                <div class="clear41">
                </div>
                <div style="padding-left: 65px; font-size: 12px; font-weight: bold; color: Black">
                    * Note: Check the box to receive email notifications sent from the App.
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 65px; font-weight: normal;">
                    <asp:CheckBox ID="chkToolTip" runat="server" Text=" Receive Feedback/Tips" />
                </div>
                <div class="clear41">
                </div>
                <div style="padding-left: 65px; font-weight: normal;">
                    <asp:CheckBox ID="chkDownloads" runat="server" Text=" Downloads" />&nbsp;&nbsp;
                    <span class="couponcode">
                        <img border="0" src="../../images/Dashboard/new.png" />
                        <span class="coupontooltip">Check this box if you would like this Associate to have
                            access to the Downloads button that allows installation of the Desktop Shortcut
                            and Notifications Manger. </span></span>
                </div>
                <div class="clear41">
                </div>
                <div class="submitadm">
                    <%if (PermissionCnt != 0)
                      { %><asp:LinkButton ID="lnkUpdate" runat="server" Text="Save" OnClick="lnkSave_Click"
                          CausesValidation="true" TabIndex="9" ValidationGroup="g"><img src="../../images/Dashboard/update.png" alt="" /></asp:LinkButton>
                    <%}
                      else
                      { %>
                    <asp:LinkButton ID="lnkSave" runat="server" Text="Save" OnClick="lnkSave_Click" CausesValidation="true"
                        TabIndex="9" ValidationGroup="g"><img src="../../images/Dashboard/save.png" alt=""/></asp:LinkButton>
                    <%} %>
                    &nbsp;<asp:LinkButton ID="lnkcancel" runat="server" Text="Cancel" CausesValidation="false"
                        TabIndex="10" OnClick="lnkcancel_Click"><img src="../../images/Dashboard/cancel.png" alt=""/></asp:LinkButton>
                    <asp:HiddenField ID="hdnPermissionAuthorId" runat="server" />
                    <asp:HiddenField ID="hdnPermissionPublisherId" runat="server" />
                    <asp:HiddenField ID="hdnuserflag" runat="server" />
                </div>
                <div class="clear">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
