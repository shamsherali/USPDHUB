<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="UserPermissionsNew.aspx.cs" Inherits="USPDHUB.Business.MyAccount.UserPermissionsNew"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <style type="text/css">
        .couponcode
        {
            width: 100px;
            padding-top: 5px;
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
            color: Black;
        }
        .perleft
        {
            float: left;
            width: 230px;
        }
        .perright
        {
            float: left;
            width: 300px;
        }
        .childprivatecallall td
        {
            float: left;
            width: 230px;
        }
        .chkcolor
        {
            background-color: rgba(214, 214, 214, 1);
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
                <div align="center">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <table cellpadding="1" cellspacing="1" border="0px" width="95%" style="border-collapse: collapse;
                                border-radius: 2px;">
                                <colgroup>
                                    <col width="28%" />
                                    <col width="24%" />
                                    <col width="24%" />
                                    <col width="24%" />
                                </colgroup>
                                <tr style="background-color: #5690CC; font-size: 24px; color: #fff; height: 80px;">
                                    <th valign="top" align="left" style="padding-left: 30px; padding-top: 20px; font-weight: normal;">
                                        Feature
                                    </th>
                                    <th valign="top" style="padding-top: 20px; font-weight: normal;">
                                        Create
                                        <br />
                                        <span style="font-size: 13px; line-height: 18px;">(Does not allow approval<br />
                                            for display on App)</span><br />
                                        <asp:CheckBox ID="chkCreateAll" runat="server" CssClass="headcreateall" onclick="CheckSelect('headcreateall','childcreateall')" />
                                        <span style="font-size: 13px; line-height: 18px; color: #F8F8F2; font-weight: bold;">
                                            Select All</span>
                                    </th>
                                    <th valign="top" style="padding-top: 20px; font-weight: normal;">
                                        Publish<span class="couponcode">
                                            <img border="0" src="../../images/Dashboard/new.png" />
                                            <span class="coupontooltip" style="text-align: left;">Selecting Publish allows the associate
                                                to publish their own content to the app without going through the approval process.</span></span>
                                        <br />
                                        <span style="font-size: 13px; line-height: 25px;">(Allows for display on App)</span><br />
                                        <asp:CheckBox ID="chkPublishAll" runat="server" CssClass="headpublishall" onclick="CheckSelect('headpublishall','childpublishall')" />
                                        <span style="font-size: 13px; line-height: 18px; font-weight: bold; color: #F8F8F2;">
                                            Select All</span>
                                    </th>
                                    <th valign="top" style="padding-top: 20px; font-weight: normal;">
                                        Review For <span class="couponcode">
                                            <img border="0" src="../../images/Dashboard/new.png" />
                                            <span class="coupontooltip" style="text-align: left; margin-left: -180px; margin-top: 25px;">
                                                When Review for Approve & Publish is checked the associate will receive an email
                                                with content that has been created and is waiting for approval. Once approved the
                                                content will be published.</span></span>
                                        <br />
                                        <span style="line-height: 32px;">Approve & Publish</span><br />
                                        <asp:CheckBox ID="chkReviewAll" runat="server" CssClass="headreviewall" onclick="CheckSelect('headreviewall','childreviewall')" />
                                        <span style="font-size: 13px; line-height: 18px; color: #F8F8F2; font-weight: bold;">
                                            Select All</span>
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="background-color: #d7d7d7; margin: 20px 0px; padding: 20px 0px; line-height: 40px;">
                                <td align="left" style="padding-left: 30px;">
                                    <asp:Label ID="lblModuleName1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.ModuleName")%>'></asp:Label>
                                    <asp:Label ID="lblButtonType1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ButtonType").ToString()=="PrivateAddOn"?"(Private Module)":""%>'></asp:Label>
                                    <asp:Label ID="lblModuleId1" Style="display: none;" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.UserModuleID")%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkCreate1" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsAuthor")%>'
                                        CssClass="childcreateall" onclick="CheckChildSelect('headcreateall','childcreateall')" />
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkPublisher1" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsPublisher")%>'
                                        CssClass="childpublishall" onclick="CheckChildSelect('headpublishall','childpublishall')" />
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkReviewer1" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsReviewer")%>'
                                        CssClass="childreviewall" onclick="CheckChildSelect('headreviewall','childreviewall')" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #eee; margin: 10px 0px; padding: 20px 0px; line-height: 40px;">
                                <td align="left" style="padding-left: 30px;">
                                    <asp:Label ID="lblModuleName2" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.ModuleName")%>'></asp:Label>
                                    <asp:Label ID="lblButtonType1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ButtonType").ToString()=="PrivateAddOn"?"(Private Module)":""%>'></asp:Label>
                                    <asp:Label ID="lblModuleId2" Style="display: none;" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.UserModuleID")%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkCreate2" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsAuthor")%>'
                                        CssClass="childcreateall" onclick="CheckChildSelect('headcreateall','childcreateall')" />
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkPublisher2" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsPublisher")%>'
                                        CssClass="childpublishall" onclick="CheckChildSelect('headpublishall','childpublishall')" />
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkReviewer2" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsReviewer")%>'
                                        CssClass="childreviewall" onclick="CheckChildSelect('headreviewall','childreviewall')" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <br />
                <br />
                <%if (Repeater2.Items.Count > 0)
                  { %>
                <div class="ContactEditInfo">
                    Private QR Connect Module
                </div>
                <br />
                <br />
                <div align="center">
                    <asp:Repeater ID="Repeater2" runat="server">
                        <HeaderTemplate>
                            <table cellpadding="1" cellspacing="1" border="0px" width="95%" style="border-collapse: collapse;
                                border-radius: 2px;">
                                <colgroup>
                                    <col width="28%" />
                                    <col width="24%" />
                                    <col width="24%" />
                                    <col width="24%" />
                                </colgroup>
                                <tr style="background-color: #5690CC; font-size: 24px; color: #fff; height: 80px;">
                                    <th valign="top" align="left" style="padding-left: 30px; padding-top: 20px; font-weight: normal;">
                                        Feature
                                    </th>
                                    <th valign="top" style="padding-top: 20px; font-weight: normal;">
                                        Create/Publish<span class="couponcode">
                                            <img border="0" src="../../images/Dashboard/new.png" />
                                            <span class="coupontooltip" style="text-align: left;">Allows the Associate to create, publish, edit and delete QR Connect codes and buttons.
                                            </span></span>
                                        <br />
                                        <asp:CheckBox ID="chkPSCPublishAll" runat="server" CssClass="headpscpublishall" onclick="CheckSelect('headpscpublishall','childpscpublishall')" />
                                        <span style="font-size: 13px; line-height: 18px; font-weight: bold; color: #F8F8F2;">
                                            Select All</span>
                                    </th>
                                   
                                    <th valign="top" style="padding-top: 20px; font-weight: normal;">
                                        Create/Publish  <span class="couponcode">
                                            <img border="0" src="../../images/Dashboard/new.png" />
                                            <span class="coupontooltip" style="text-align: left; margin-left: -180px; margin-top: 25px;">
                                                Allows the Associate to create, edit, delete ans save categories for use with QR Connect.</span></span>
                                        <br />
                                         <span style="line-height: 32px;">Category</span><br />
                                        <asp:CheckBox ID="chkPSCCatAll" runat="server" CssClass="headpsccatall" onclick="CheckSelect('headpsccatall','childpsccatall')" />
                                        <span style="font-size: 13px; line-height: 18px; color: #F8F8F2; font-weight: bold;">
                                            Select All</span>
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="background-color: #d7d7d7; margin: 20px 0px; padding: 20px 0px; line-height: 40px;">
                                <td align="left" style="padding-left: 30px;">
                                    <asp:Label ID="lblPSCModuleName1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.ModuleName")%>'></asp:Label>
                                    <asp:Label ID="lblPSCModuleId1" Style="display: none;" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.UserModuleID")%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkPSCPublisher1" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsPublisher")%>'
                                        CssClass="childpscpublishall" onclick="CheckChildSelect('headpscpublishall','childpscpublishall')" />
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkCategory1" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsCategory")%>'
                                        CssClass="childpsccatall" onclick="CheckChildSelect('headpsccatall','childpsccatall')" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #eee; margin: 10px 0px; padding: 20px 0px; line-height: 40px;">
                                <td align="left" style="padding-left: 30px;">
                                    <asp:Label ID="lblPSCModuleName2" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.ModuleName")%>'></asp:Label>
                                    <asp:Label ID="lblPSCModuleId2" Style="display: none;" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.UserModuleID")%>'></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkPSCPublisher2" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsPublisher")%>'
                                        CssClass="childpscpublishall" onclick="CheckChildSelect('headpscpublishall','childpscpublishall')" />
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="chkCategory2" runat="server" Checked='<%#DataBinder.Eval(Container, "DataItem.IsCategory")%>'
                                        CssClass="childpsccatall" onclick="CheckChildSelect('headpsccatall','childpsccatall')" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <%} %>
                <asp:Panel ID="pnlPrivateCallAddOns" runat="server" Style="display: none;">
                    <div class="clear41">
                    </div>
                    <div style="padding-left: 25px; font-size: 14px; font-weight: bold; color: #065baa;">
                        Private Call Module
                    </div>
                    <div class="clear10">
                    </div>
                    <div style="padding-left: 25px; font-weight: normal;">
                        <div class="perleft">
                            <asp:CheckBox ID="chkPCSelectAll" runat="server" CssClass="headprivatecallall" onclick="CheckSelect('headprivatecallall','childprivatecallall')" />
                            <span style="font-size: 13px; line-height: 18px; font-weight: bold; color: #E45641;">
                                Select All</span>
                        </div>
                    </div>
                    <div class="clear10">
                    </div>
                    <div style="padding-left: 21px; font-weight: normal;">
                        <asp:CheckBoxList ID="chkPrivateCallAddOnsList" runat="server" RepeatDirection="Horizontal"
                            CssClass="childprivatecallall" onclick="CheckChildSelect('headprivatecallall','childprivatecallall')"
                            RepeatColumns="2">
                        </asp:CheckBoxList>
                    </div>
                </asp:Panel>
                <div class="clear41">
                </div>
                <div style="padding-left: 25px; font-size: 12px; font-weight: bold; color: Black">
                    * Note: To allow access to the following areas, select the appropriate check boxes
                    below.
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div style="float: left; width: 100px;">
                        <asp:CheckBox ID="chkGenericAll" runat="server" CssClass="headgenericall" onclick="CheckSelect('headgenericall','childgenericall')" />
                        <span style="font-size: 13px; line-height: 18px; font-weight: bold; color: #E45641;">
                            Select All</span>
                    </div>
                    <div style="padding-left: 5px; font-size: 12px; color: Black" id="divNote" runat="server">
                        (Note: Items in <span class="chkcolor">grey color</span> indicate that you have
                        not purchased those modules.)
                    </div>
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkMessageAuthor" runat="server" Text=" Access Messages / Tips"
                            Visible="true" CssClass="childgenericall" onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                    <div class="perright" id="divchkPrivateAddOnInvs" runat="server">
                        <asp:CheckBox ID="chkPrivateAddOnInvs" runat="server" Text=" Access Private Module Functions"
                            CssClass="childgenericall" onclick="CheckChildSelect('headgenericall','childgenericall')" />&nbsp;&nbsp;
                        <%if (IsPrivateCall)
                          { %>
                        <span class="couponcode">
                            <img border="0" src="../../images/Dashboard/new.png" />
                            <span class="coupontooltip">A Private Module adds a button to the app that can be viewed
                                only by users who have been invited by you. Check this box if you would like to
                                give the Associate the ability to send out and manage the private module invitations
                                and smart devices. Private modules are offered at an additional price and are available
                                for purchase in the market place.</span></span>
                        <%} %>
                    </div>
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkPushAuthor" runat="server" Text=" Push Notifications" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                    <div class="perright">
                        <asp:CheckBox ID="chkMButtonsAuthor" runat="server" Text=" Manage Buttons" CssClass="childgenericall"
                            Visible="true" onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkASettingsAuthor" runat="server" Text=" App Settings" CssClass="childgenericall"
                            Visible="true" onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                    <div class="perright">
                        <asp:CheckBox ID="chkAuthorContacts" runat="server" Text=" Contacts" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkMarketPlace" runat="server" Text=" Access Market Place" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                    <div class="perright">
                        <asp:CheckBox ID="chkManageLogins" runat="server" Text=" Manage Associate Logins"
                            CssClass="childgenericall" onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkAppBG" runat="server" Text=" Access App Background Image" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                    <div class="perright">
                        <%if (Convert.ToBoolean(hdnHasBannerAds.Value))
                          { %>
                        <asp:CheckBox ID="chkBannerAds" runat="server" Text=" Access Banner Ads" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                        <%} %>
                        <asp:HiddenField runat="server" ID="hdnHasBannerAds" Value="false" />
                    </div>
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkHome" runat="server" Text=" Home" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                    <div class="perright">
                        <asp:CheckBox ID="chkMission" runat="server" Text=" Our Mission" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" /></div>
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkLinks" runat="server" Text=" Links" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                    <div class="perright">
                        <asp:CheckBox ID="chkSocial" runat="server" Text=" Social" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                </div>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkGallery" runat="server" Text=" Gallery" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                    <div class="perright">
                        <asp:CheckBox ID="chkAppsStats" runat="server" Text=" App Statistics" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" /></div>
                </div>
                <div class="clear10">
                </div>
                <%if (IsSmartConnectAviable)
                  { %>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkSmartConnect" runat="server" Text="SmartConnect" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                        <abbr>
                            (<asp:Label ID="lblPublicalButtonName" runat="server" Text=""></asp:Label>)
                        </abbr>
                    </div>
                    <div class="perright">
                        <asp:CheckBox ID="chkSmartConnectCategory" runat="server" Text="SmartConnect Categories"
                            CssClass="childgenericall" onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                </div>
                <%} %>
                <div class="clear10">
                </div>
                <div style="padding-left: 25px; font-weight: normal;">
                    <div class="perleft">
                        <asp:CheckBox ID="chkRelease" runat="server" Text=" Release History" CssClass="childgenericall"
                            onclick="CheckChildSelect('headgenericall','childgenericall')" />
                    </div>
                    <div class="perright">
                        <asp:CheckBox ID="chkBilling" runat="server" Text=" Billing History" CssClass="childgenericall"
                            Visible="false" onclick="CheckChildSelect('headgenericall','childgenericall')" /></div>
                </div>
                <div class="clear41">
                </div>
                <div id="ReceiveEmailNotifications">
                    <div style="padding-left: 25px; font-size: 12px; font-weight: bold; color: Black">
                        * Note: Check the box to receive email notifications sent from the App.
                    </div>
                    <div class="clear10">
                    </div>
                    <div style="padding-left: 25px; font-weight: normal;">
                        <div class="perleft">
                            <asp:CheckBox ID="chkEmailAll" runat="server" CssClass="heademailall" onclick="CheckSelect('heademailall','childemailall')" />
                            <span style="font-size: 13px; line-height: 18px; font-weight: bold; color: #E45641;">
                                Select All</span>
                        </div>
                    </div>
                    <div class="clear10">
                    </div>
                    <div style="padding-left: 25px; font-weight: normal;">
                        <asp:CheckBox ID="chkToolTip" runat="server" Text=" Receive Feedback" CssClass="childemailall"
                            onclick="CheckChildSelect('heademailall','childemailall')" />
                    </div>
                    <div class="clear10">
                    </div>
                    <div style="padding-left: 25px; font-weight: normal;">
                        <asp:CheckBox ID="chkTips" runat="server" Text=" Receive Tips" CssClass="childemailall"
                            onclick="CheckChildSelect('heademailall','childemailall')" />
                    </div>
                    <div class="clear10">
                    </div>
                    <div style="padding-left: 25px; font-weight: normal;">
                        <asp:CheckBox ID="chkDownloads" runat="server" Text=" Downloads" CssClass="childemailall"
                            onclick="CheckChildSelect('heademailall','childemailall')" />&nbsp;&nbsp; <span class="couponcode">
                                <img border="0" src="../../images/Dashboard/new.png" />
                                <span class="coupontooltip">Check this box if you would like this Associate to have
                                    access to the Downloads button that allows installation of the Desktop Shortcut
                                    and Notifications Manager. </span></span>
                    </div>
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
                    <asp:HiddenField ID="hdnIsLiteVersion" runat="server" />
                    <asp:HiddenField ID="hdnPermissionPublisherId" runat="server" />
                    <asp:HiddenField ID="hdnuserflag" runat="server" />
                </div>
                <div class="clear">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">

        function CheckSelect(type, typeclass) {
            if ($("." + type).find(":checkbox").is(':checked')) {
                $("." + type.replace("head", "child")).find(":checkbox").each(function () {
                    $(this).attr("checked", "checked");
                });
            }
            else {
                $("." + type.replace("head", "child")).find(":checkbox").each(function () {
                    $(this).removeAttr("checked", "checked");
                });
            }
        }
        function CheckChildSelect(type, typeclass) {
            var childCount = $("." + type.replace("head", "child")).find(":checkbox").length;
            var chldCheckedCount = 0;
            $("." + type.replace("head", "child")).find(":checkbox").each(function () {
                if ($(this).is(':checked')) {
                    chldCheckedCount += 1;
                }
            });
            if (childCount == chldCheckedCount)
                $("." + type).find(":checkbox").attr("checked", "checked");
            else
                $("." + type).find(":checkbox").removeAttr("checked", "checked");
        }
        window.onload = function () {
            CheckChildSelect('headcreateall', 'childcreateall');
            CheckChildSelect('headpublishall', 'childpublishall');
            CheckChildSelect('headreviewall', 'childreviewall');
            CheckChildSelect('headgenericall', 'childgenericall');
            CheckChildSelect('heademailall', 'childemailall');
            CheckChildSelect('headprivatecallall', 'childprivatecallall');
            CheckChildSelect('headpscpublishall', 'childpscpublishall');
            CheckChildSelect('headpsccatall', 'childpsccatall');
        }
    </script>
</asp:Content>
