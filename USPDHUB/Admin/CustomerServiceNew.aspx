<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="CustomerServiceNew.aspx.cs" Inherits="USPDHUB.Admin.CustomerServiceNew"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/Sitemaplinks.ascx" TagName="Sitemaplinks" TagPrefix="uc1" %>
<%@ Register Src="../Controls/EditCCDetails.ascx" TagName="CCDetails" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        .realusers
        {
            background-color: #AFC7C7;
            font-weight: bold;
        }
        .realusers1
        {
            background-color: #AFC7C7;
            font-weight: bold;
        }
        .demousers
        {
        }
        .sponserbtn
        {
            text-decoration: none;
            color: #001625;
            font-weight: normal;
            background: #e9e9e9;
            border: 1px solid #a2a2a2;
            padding: 2px;
            font-style: normal; /* margin-top: 5px; */ /* float: left; */
            font: 13.3333px Arial;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td>
                    </td>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td style="padding-top: 8px; padding-left: 35px;" align="left">
                                    Customer Service
                                </td>
                                <td align="right">
                                 <%--   <asp:Button ID="btnUpgrade" runat="server" Text="Upgrade" OnClick="btnUpgrade_Click"
                                        Visible="false" />--%>
                                         <asp:HyperLink ID="btnUpgrade" CssClass="sponserbtn" Visible="false" NavigateUrl=""
                                        Target="_blank" runat="server" style="display:none;">Upgrade</asp:HyperLink>
                                    <%-- <asp:Button ID="btnSponserAds" runat="server" Text="Add Sponsor Ads" OnClick="btnSponserAds_Click" 
                                        Visible="false" />--%>
                                    <asp:HyperLink ID="btnSponserAds" CssClass="sponserbtn" Visible="false" NavigateUrl=""
                                        Target="_blank" runat="server" style="display:none;">Add Sponsor Ads</asp:HyperLink>
                                    <%-- <asp:Button ID="btnAddActivity" runat="server" Text="Add News & Updates" OnClick="btnAddActivity_Click"
                                        Visible="false" />--%>
                                     <asp:HyperLink ID="btnAddActivity" CssClass="sponserbtn" NavigateUrl=""
                                        Target="_blank" runat="server">Add News & Updates</asp:HyperLink>
                                    <asp:Button ID="btnFreeAccount" runat="server" Text="Create Free Account" OnClick="btnCreateFreeAccount" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="color: Red;">
                            <tr>
                                <td align="center">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblerror" runat="server" Style="font-weight: bold; font-size: 16px;"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlcategory" runat="server" DefaultButton="btn">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="background-color: #E9E9E9;
                                            padding: 10px; border: solid 1px #29A2C6; border-bottom: 0px;">
                                            <colgroup>
                                                <col width="175px" />
                                                <col width="200px" />
                                                <col width="175px" />
                                                <col width="200px" />
                                            </colgroup>
                                            <tr>
                                                <td style="font-weight: bold;">
                                                    Select Criteria:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpcategory" runat="server" OnSelectedIndexChanged="DrpcategorySelectedIndexChanged"
                                                        AutoPostBack="True">
                                                        <asp:ListItem Text="Select " Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Member ID" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Phone No" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="First Name" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Last Name" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Login Name" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Business Name" Value="6"></asp:ListItem>
                                                        <%-- <asp:ListItem Text="Profile Name" Value="6"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="font-weight: bold;">
                                                    Enter
                                                    <%=drpcategory.SelectedItem.Text%>:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtcategory" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcategory"
                                                        ErrorMessage="Category Name is mandatory." ValidationGroup="g" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px;" align="left">
                                                    <%-- <strong>Include Associate Users </strong>:--%>
                                                </td>
                                                <td style="padding-top: 5px;" align="left">
                                                    <asp:CheckBox runat="server" ID="chkAssociteUser" Style="display: none;" />
                                                </td>
                                                <td colspan="2" style="padding-top: 5px; padding-right: 75px;" align="right">
                                                    <%--<asp:Button ID="btngetDetails" runat="server" Text="Get Details" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                            ID="btnDashboard" runat="server" Text="Go To Dashboard" />
                                                    --%>
                                                    <asp:Button ID="btn" runat="server" Text="Get Details" OnClientClick="return isNumber();"
                                                        ValidationGroup="g" OnClick="BtnClick" />
                                                    <%--<asp:Button ID="Button1" Text="Go to Admin" runat="server" CssClass="button" OnClick="BtndashboardClick" />--%>&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="lblmsg" runat="server" ForeColor="red" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="lblerr" runat="server" ForeColor="green" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: solid 1px #29A2C6;">
                            <tr>
                                <asp:UpdatePanel ID="pnlCustomerDetails" runat="server">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <colgroup>
                                                <col width="30%" />
                                                <col width="*" />
                                            </colgroup>
                                            <tr>
                                                <td style="padding-left: 5px;">
                                                    <%--<asp:LinkButton runat="server" ID="lnkSuspend" OnClick="LnkSuspendClick" Visible="false"
                                                    Style="color: #FB8926; font-size: 14px; font-weight: bold;">Suspend InReachHub</asp:LinkButton>
                                                <asp:LinkButton runat="server" ID="lnkActivate" OnClick="LnkActivateClick" Visible="false"
                                                    Style="color: #FB8926; font-size: 14px; font-weight: bold;">Activate InReachHub</asp:LinkButton>--%>
                                                </td>
                                                <td>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding: 5px;">
                                                        <tr>
                                                            <td style="text-align: right;">
                                                            <asp:Button ID="btnUpgradeModules" runat="server" Text="Extend Module Expiry Date" OnClick="btnUpgradeModules_Click" />
                                                            <asp:Button ID="btnBillingHistory" style="display:none;" visibility="false" runat="server" Text="Billing History" OnClick="btnBillingHistory_Click"
                                                                    />
                                                                <asp:Button ID="btnAddContentModule" runat="server" Text="Add New Content Module"
                                                                    OnClick="btnAddContentModule_OnClick" />
                                                                <asp:Button ID="btnExtendMemShip" runat="server" Text="Extend Membership" CausesValidation="false"
                                                                    OnClientClick="return ShowExtendModalDialog();" />
                                                                <asp:Button ID="btnTestAccount" runat="server" Text="" OnClick="BtnTestAccountClick"
                                                                    OnClientClick="return confirm('Are you sure you want to change the account type?');" />
                                                                <asp:Button ID="btnMemberLogin" runat="server" Text="Go to Member Dashboard" OnClick="BtnMemberLoginClick"
                                                                    Visible="false" />
                                                                <asp:Button ID="btnMemberSiteTop" runat="server" Visible="false" Text="Go to Member Site"
                                                                    OnClick="BtnMemberSiteClick" />
                                                                <asp:Button ID="btnPay_Upgrade" runat="server" Visible="false" Text="Pay or Upgrade"
                                                                    OnClick="BtnPayUpgradeClick" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <colgroup>
                                                <col width="50%" />
                                                <col width="*" />
                                            </colgroup>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="Customertbl">
                                                        <colgroup>
                                                            <col width="40%" />
                                                            <col width="*" />
                                                        </colgroup>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label3" runat="server" Text="&nbsp;" Style="background-color: #AFC7C7;"
                                                                    Width="25px"></asp:Label>
                                                                <asp:Label ID="Label5" Text="- Colored rows are real users." runat="server" Style="font-weight: bold;
                                                                    font-size: 14px;"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" class="title">
                                                                General Details
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Member ID:
                                                            </td>
                                                            <td>
                                                                <asp:HiddenField runat="server" ID="hdnMemberID" />
                                                                <asp:Label ID="lblMemberID" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnUserAppName" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Company Name:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcompname" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Contact Name:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblContname" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Profile Name:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblProfName" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Address 1:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbladdress1" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Address 2:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbladdress2" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                City:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcity" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                State:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblstate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Country:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Zip Code:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblzipcode" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Login Email ID:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLoginEmail" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Communication Email:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblemail" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Phone:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="pblphone" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trPinCode">
                                                            <td class="left10">
                                                                Pin Code:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAppPinCode" runat="server"></asp:Label>
                                                                <asp:Button ID="btnShowPinCode" Style="display: none;" runat="server" Text="" OnClientClick="return ShowPinCodeDialog();" />
                                                                <asp:Button ID="btnRemovePinCode" Style="display: none;" runat="server" Text="Remove"
                                                                    Visible="false" OnClick="btnRemovePinCode_Click" OnClientClick="return confirm('Are you sure you want to remove the pin code?')" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Fax:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblfax" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Access Code:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAccCode" runat="server"></asp:Label>
                                                                <asp:Button ID="btnAccCode" runat="server" Text="" OnClientClick="return ShowAccessCodeDialog();" />
                                                                <asp:Button ID="btnRemoveCode" runat="server" Text="Remove" Visible="false" OnClick="btnRemoveCode_Click"
                                                                    OnClientClick="return confirm('Are you sure you want to remove the access code?')" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10" style="padding-top: 10px;">
                                                                Change Logo:
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnLogoUpdate" runat="server" Text="Update Logo" OnClientClick="return ShowLogoUploadDialog();" />
                                                            </td>
                                                        </tr>
                                                        <% if (!Convert.ToBoolean(hdnTurnOff.Value))
                                                           { %>
                                                        <tr>
                                                            <td class="left10">
                                                                Turn on auto email:
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnTurnonMail" runat="server" Text="Turn on Email" OnClick="btnTurnonMail_Click" />
                                                            </td>
                                                        </tr>
                                                        <% } %>
                                                    </table>
                                                    <table width="90%" border="0" cellpadding="0" cellspacing="0" class="logibBoxtbl">
                                                        <tr>
                                                            <td>
                                                                <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <span style="color: Red;">LOGIN DETAILS - HIGH PRIVACY - NEVER DISCLOSE</span>
                                                                            <br />
                                                                            <span class="small">send by email to User Email Address Only</span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="left10">
                                                                            Login Email ID:
                                                                        </td>
                                                                        <td class="black">
                                                                            <asp:Label ID="lblloginname" runat="server"></asp:Label>
                                                                            <asp:HiddenField runat="server" ID="hdnLoginName" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <span style="color: Red;">Note: Please select a member at 'Select Member' section.</span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="left10">
                                                                            Password:
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnPassword" runat="server" Text="Send Password" OnClick="BtnPasswordClick" />&nbsp;&nbsp;<asp:Button
                                                                                ID="btnUpdate" runat="server" CausesValidation="false" Text="Reset Password"
                                                                                OnClientClick="return ShowModalDialog();" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="Customertbl">
                                                        <colgroup>
                                                            <col width="50%" />
                                                            <col width="*" />
                                                        </colgroup>
                                                        <tr>
                                                            <td colspan="2" class="title">
                                                                <span>Membership Details</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                First Name:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblfirstname" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Last Name:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbllastname" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Membership Status:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblstatus" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10" style="color: #E45641; font-weight: bold;">
                                                                Subscription Type:
                                                            </td>
                                                            <td style="color: #E45641; font-size: 12px;">
                                                                <asp:Label ID="lblPSType" runat="server"></asp:Label><%if (lbllevel.Text.ToLower().Contains("trial"))
                                                                                                                       { %>
                                                                &nbsp;(<asp:Label ID="lbllevel" runat="server"></asp:Label>)<%} %></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Subscription Start Date:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblsubscpstartdate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Vertical:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblVertical" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Referred By:
                                                            </td>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlReferBy" runat="server" Width="150px" Font-Size="13px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnReferBy" runat="server" Text="Refer By" OnClientClick="return ValidateSalesPerson();"
                                                                                OnClick="BtnReferByOnClick" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <%-- <asp:Label ID="lblreffer" runat="server"></asp:Label>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="Customertbl">
                                                        <colgroup>
                                                            <col width="50%" />
                                                            <col width="*" />
                                                        </colgroup>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" class="title">
                                                                Subscription Status
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Last Login Date:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbllastlogin" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <% if (AssociateID > 0)
                                                           { %>
                                                        <tr>
                                                            <td class="left10">
                                                                Associate User ID:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAssocID" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <% } %>
                                                        <tr>
                                                            <td class="left10">
                                                                User Browser:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblbrowser" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Remaining Days:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblremainingdays" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Renewal Date:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblrenewdate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%--   <tr>
                                    <td colspan="2" class="title">
                                     Subscription Period
                                    </td>
                                </tr>--%>
                                                        <tr>
                                                            <td class="left10">
                                                                Amount Paid in $:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblamount" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                <asp:LinkButton ID="lnkUpdateCredicard" runat="server" Text="Update CC Details" ForeColor="Blue"
                                                                    OnClick="LnkUpdateCredicardOnClick"></asp:LinkButton>
                                                                <br />
                                                                Auto Renew:&nbsp;<asp:LinkButton runat="server" ID="HyperEnable" Font-Size="14px"
                                                                    ForeColor="Blue" OnClientClick="return Enabled_Disabled(this.Text);" OnClick="HyperEnable_OnClick"></asp:LinkButton>
                                                            </td>
                                                            <td style="padding-top: 20px;">
                                                                <asp:Label ID="lblRecurring" runat="server"></asp:Label>
                                                                <%if (lblExpiredDatecc.Text != "")
                                                                  { %>
                                                                &nbsp;&nbsp; <span style="font-size: 14px;">Exp Date:</span>
                                                                <asp:Label ID="lblExpiredDatecc" runat="server"></asp:Label><%} %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="left10">
                                                                Sub App:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSubApp" runat="server"></asp:Label>
                                                                &nbsp;
                                                                <% if (lblSubApp.Text == "Yes")
                                                                   { %>
                                                                <span style="font-weight: bold; font-size: 16px;">(<asp:LinkButton ID="lnkUserID"
                                                                    runat="server" ForeColor="Blue" Text="" OnClick="lnkUserID_Click"></asp:LinkButton>)</span>
                                                                <%} %>
                                                            </td>
                                                        </tr>
                                                        <%if (lblAppVersion.Text != "")
                                                          { %>
                                                        <tr>
                                                            <td class="left10">
                                                                App Version:
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblAppVersion" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%} %>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding: 5px;">
                                                        <tr>
                                                            <td colspan="2" style="text-align: left;">
                                                                <%--<asp:LinkButton runat="server" ID="lnkSuspend1" OnClick="LnkSuspendClick" Visible="false"
                                                                Style="color: #FB8926; font-size: 14px; font-weight: bold;">Suspend InReachHub</asp:LinkButton>
                                                            <asp:LinkButton runat="server" ID="lnkActivate1" OnClick="LnkActivateClick" Visible="false"
                                                                Style="color: #FB8926; font-size: 14px; font-weight: bold;">Activate InReachHub</asp:LinkButton>--%>
                                                            </td>
                                                            <td colspan="2" style="text-align: right;">
                                                                <asp:Button ID="btnMemberInformation" Text="Go to Member Information" runat="server"
                                                                    OnClick="btnMemberInformation_OnClick" />
                                                                <asp:Button ID="btnMemberLoginBottom" runat="server" Text="Go to  Member Dashboard"
                                                                    OnClick="BtnMemberLoginClick" Style='display: none;' />
                                                                <asp:Button ID="btnEmail" runat="server" Text="Send Email" OnClick="BtnEmailClick">
                                                                </asp:Button>
                                                                <asp:Button ID="btnMemberSiteBottom" runat="server" Visible="false" Text="Go to  Member Site"
                                                                    OnClick="BtnMemberSiteClick" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: left;">
                                                                &nbsp;
                                                            </td>
                                                            <td align="right" colspan="2" style="padding: 5px;">
                                                                <asp:Panel runat="server" ID="pnlAssociates">
                                                                    <table style="border: 1px solid orange; padding: 10px; border-radius: 10px;">
                                                                        <tr>
                                                                            <td>
                                                                                Select Member:
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlAssociates" Width="210px" runat="server" Font-Size="14px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btnAssociateMemberLogin" runat="server" OnClick="btnAssociateMemberLogin_OnClick"
                                                                                    Text="Go to  Member Dashboard" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </tr>
                            <tr>
                                <asp:Panel ID="CustomersPanel" runat="server">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                        <tr>
                                            <td width="100%">
                                                <div style="width: 920px; overflow: auto;">
                                                    <asp:GridView ID="CustomersGridView" GridLines="None" AutoGenerateColumns="False"
                                                        DataKeyNames="User_ID" runat="server" AllowSorting="True" PageSize="25" OnRowDataBound="CustomersGridView_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="User_ID">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LabelGdMember_ID" runat="server" Text='<%# Bind("User_ID") %>'
                                                                        OnClick="GridView_RowEditing" CommandArgument='<%# Bind("User_ID") %>'></asp:LinkButton>
                                                                    <asp:Label ID="Label4" runat="server" Visible="false" Text='<%# Bind("User_ID") %>'> </asp:Label>
                                                                    <%--  <asp:LinkButton ID="LnkBtnGdMember_ID" runat="server" OnClick="LnkBtnGetMemberDetails_Click"></asp:LinkButton>--%>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Profile Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProfileName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProfileName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="300px" Wrap="False" BackColor="#003399" />
                                                                <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="First Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGdFirstname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Firstname") %>'></asp:Label>
                                                                    <asp:Label ID="lblIsArchived" runat="server" Text='<%# Bind("IsArchived") %>' Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Last Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGdlastname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Lastname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Login Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGdLoginName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LoginName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Password">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGdPassword" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Password") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Contact Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGdPhoneNo1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PhoneNo1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Address1">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGdAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Address2">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGdAddress2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address2") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="City">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGdCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "City") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="State">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGdState" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "State") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Zip">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Zip" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Zip") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                <HeaderStyle Width="100%" Wrap="False" BackColor="#003399" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="title1" />
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </tr>
                            <tr>
                                <asp:Panel ID="NotesTable" runat="server">
                                    <table>
                                        <tr>
                                            <td style="width: 336px; height: 3px;">
                                                <span style="color: #FB8926; font-size: 14px;">Notes:</span>
                                                <asp:TextBox ID="TxtBxNotes" runat="server" TextMode="MultiLine" Height="100px" Width="647px"></asp:TextBox>
                                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width: 336px; height: 3px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 336px; height: 3px;">
                                                <span style="color: #FB8926; font-size: 14px;">Notes By:</span>
                                                <asp:TextBox ID="txtNotesBy" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 336px; height: 3px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 336px; height: 3px;">
                                            </td>
                                            <td style="width: 336px; height: 3px;">
                                                <asp:Button ID="BtnNotes" runat="server" Text="Submit" OnClick="BtnNotes_Click" OnClientClick="return CheckNotes();" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </tr>
                            <tr>
                                <asp:Panel ID="NotesDatalist" runat="server">
                                    <asp:DataList ID="DataList_CustomerNotes" runat="server" DataKeyField="CustomerNotesId"
                                        ForeColor="Black" CellSpacing="12" Width="100%">
                                        <ItemTemplate>
                                            <asp:Panel ID="UpdatePanel" runat="server" Style="overflow: auto;" BackColor="Gainsboro"
                                                Width="100%">
                                                <table style="border-collapse: collapse" border="0" cellpadding="10" width="100%">
                                                    <tr>
                                                        <td align="right">
                                                            By:
                                                            <asp:Label ID="lblRepName" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Notes_By") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="NotesText" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Notes") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label1" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"Created_Dt") %>' />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </asp:Panel>
                                            <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" TargetControlID="UpdatePanel"
                                                runat="server">
                                            </cc1:RoundedCornersExtender>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </asp:Panel>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table border="0" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalPopupExtenderSendEmail" runat="server" TargetControlID="lblpre"
                            PopupControlID="pnlpopup1" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel Style="display: none" ID="pnlpopup1" runat="server" Width="850px">
                            <table class="inputgrid nomargin-bottom" cellspacing="0" cellpadding="0" width="100%"
                                border="0" style="border: 1px solid #03A8DF">
                                <colgroup>
                                    <col width="100" />
                                    <col width="*" />
                                </colgroup>
                                <tbody>
                                    <tr class="title">
                                        <td colspan="2">
                                            Send Email to Customer
                                        </td>
                                    </tr>
                                    <tr class="row1">
                                        <td colspan="2" align="center">
                                            <span style="color: Red; font-weight: bold;">
                                                <asp:Label runat="server" ID="Label2"></asp:Label></span>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr class="row1">
                                        <td>
                                            * To:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSendEmailTo" runat="server" Width="200px">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtSendEmailTo" ID="RequiredFieldValidator1"
                                                runat="server" ErrorMessage="Email to is mandatory" ValidationGroup="Submit"
                                                Display="None">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtSendEmailTo"
                                                runat="server" ValidationGroup="Submit" ErrorMessage="Invalid Email Format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                Display="None">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr class="row1">
                                        <td>
                                            * Subject:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmailSubject" runat="server" Width="500px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEmailSubject"
                                                runat="server" ValidationGroup="Submit" ErrorMessage="Subject is mandatory" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr class="row1">
                                        <td>
                                            * Notes:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="500px" Height="150px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtNotes"
                                                runat="server" ErrorMessage="Notes is mandatory" ValidationGroup="Submit" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSendEmail" runat="server" Width="56px" CssClass="button" Text="Send"
                                                ValidationGroup="Submit" OnClick="BtnSendEmailClick"></asp:Button>
                                            <asp:Button ID="btnCancel" runat="server" CssClass="button" CausesValidation="false"
                                                OnClick="BtnCancelClick" Text="Cancel"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            * <span style="color: Red;">Marked fields are mandatory.</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div id="divError">
                                                <asp:ValidationSummary ID="ValidationSummary1" HeaderText="*Please correct the following."
                                                    runat="server" ValidationGroup="Submit" ShowSummary="true" />
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table border="0" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblpre5" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="CCDetailsModalPopup" runat="server" TargetControlID="lblpre5"
                            PopupControlID="pnlpopup5" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlpopup5" runat="server" Width="50%" Style="display: none;">
                            <table class="inputgrid nomargin-bottom">
                                <tr>
                                    <td align="right" style="padding: 5px 10px 0px 10px;">
                                        <asp:LinkButton ID="lnkClose" runat="server" OnClick="lnkClose_Click" CausesValidation="false"><img src="../../images/popup_close.gif" /></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc2:CCDetails ID="CCDetails1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="50%" border="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblUpdate" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="UpdateModalPopup" runat="server" TargetControlID="lblUpdate"
                            PopupControlID="pnlUpdate" BackgroundCssClass="modal" CancelControlID="lnkClosePopup">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlUpdate" runat="server" Width="420px" Style="display: none;">
                            <table class="modalpopup">
                                <tr>
                                    <td align="left" class="header">
                                        Reset Password
                                    </td>
                                    <td align="right" style="padding: 5px 10px 0px 10px;">
                                        <asp:LinkButton ID="lnkClosePopup" runat="server" CausesValidation="false"><img src="../../images/popup_close.gif" /></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span style="font-weight: bold;">Member Information:</span><br />
                                        <asp:Label ID="lblResetUser" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Password:
                                    </td>
                                    <td>
                                        <input id="txtNewPwd" runat="server" width="175px" type="password" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNewPwd"
                                            Display="Dynamic" SetFocusOnError="True" ErrorMessage="New password is mandatory."
                                            ValidationGroup="P">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNewPwd"
                                            Display="Dynamic" ErrorMessage="Passwords must contain 6 - 15 characters." SetFocusOnError="True"
                                            ValidationExpression="^([^ ]).{5,15}$" ValidationGroup="P">*</asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Special Characters and blank spaces not allowed in Password."
                                            Display="Dynamic" ValidationExpression="\w{1,255}" Width="7px" SetFocusOnError="True"
                                            ControlToValidate="txtNewPwd" ValidationGroup="P">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Confirm Password:
                                    </td>
                                    <td>
                                        <input runat="server" width="175px" id="txtCnfPwd" type="password" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCnfPwd"
                                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="P" ErrorMessage="Confirm password is mandatory.">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="font-size: 11px;">
                                        (Note: Passwords are case sensitive and must contain between 6-15 alpha/numeric
                                        characters. Special characters are not allowed.)
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnChange" runat="server" ValidationGroup="P" Text="Update Password"
                                            OnClick="BtnUpdatePassword" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="The following error(s) are occurred:"
                                            ShowSummary="true" ValidationGroup="P" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="50%" border="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblAccessCode" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="mpeAccessCode" runat="server" TargetControlID="lblAccessCode"
                            PopupControlID="pnlAccessCode" BackgroundCssClass="modal" CancelControlID="lnkClsPopup">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlAccessCode" runat="server" Width="420px" Style="display: none;">
                            <table class="modalpopup">
                                <tr>
                                    <td align="left" class="header">
                                        Access Code:
                                    </td>
                                    <td align="right" style="padding: 5px 10px 0px 10px;">
                                        <asp:LinkButton ID="lnkClsPopup" runat="server" CausesValidation="false"><img src="../../images/popup_close.gif" /></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Access code:
                                    </td>
                                    <td>
                                        <input type="text" runat="server" width="175px" id="txtAccsCode" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAccsCode"
                                            Display="Dynamic" SetFocusOnError="True" ErrorMessage="Access code is mandatory."
                                            ValidationGroup="AccessCode">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REValphaOnly" runat="server" Display="Dynamic"
                                            ErrorMessage="Please enter alphanumerics only." ValidationGroup="AccessCode"
                                            ControlToValidate="txtAccsCode" ValidationExpression="^[a-zA-Z0-9]+$">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnAccCodeUpdate" runat="server" ValidationGroup="AccessCode" Text="Update"
                                            OnClick="CreateUpdateAccessCodeClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="The following error(s) are occurred:"
                                            ShowSummary="true" ValidationGroup="AccessCode" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="50%" border="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblPinCodeTarget" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="modalPinCode" runat="server" TargetControlID="lblPinCodeTarget"
                            PopupControlID="pnlPinCodeTarget" BackgroundCssClass="modal" CancelControlID="lnkPinClose">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlPinCodeTarget" runat="server" Width="420px" Style="display: none;">
                            <table class="modalpopup">
                                <tr>
                                    <td align="left" class="header">
                                        Pin Code:
                                    </td>
                                    <td align="right" style="padding: 5px 10px 0px 10px;">
                                        <asp:LinkButton ID="lnkPinClose" runat="server" CausesValidation="false"><img src="../../images/popup_close.gif" /></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Pin code:
                                    </td>
                                    <td>
                                        <input type="text" runat="server" width="175px" id="txtPinDummy" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPinDummy"
                                            Display="Dynamic" SetFocusOnError="True" ErrorMessage="Pin code is mandatory."
                                            ValidationGroup="PinCode">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                            ErrorMessage="Please enter alphanumerics only." ValidationGroup="PinCode" ControlToValidate="txtPinDummy"
                                            ValidationExpression="^[a-zA-Z0-9]+$">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnUpdatePin" runat="server" ValidationGroup="PinCode" Text="Update"
                                            OnClick="btnUpdatePin_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ValidationSummary ID="ValidationSummary5" runat="server" HeaderText="The following error(s) are occurred:"
                                            ShowSummary="true" ValidationGroup="PinCode" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="50%" border="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblExtendMemship" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="mpeExtendMemship" runat="server" TargetControlID="lblExtendMemship"
                            PopupControlID="pnlExtendMemship" BackgroundCssClass="modal" CancelControlID="lnkCls">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlExtendMemship" runat="server" Width="420px" Style="display: none;">
                            <table class="modalpopup">
                                <tr>
                                    <td align="left" class="header">
                                        Extend Membership:
                                    </td>
                                    <td align="right" style="padding: 5px 10px 0px 10px;">
                                        <asp:LinkButton ID="lnkCls" runat="server" CausesValidation="false"><img src="../../images/popup_close.gif" /></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Select Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMemshipExtend" runat="server" Width="175px"></asp:TextBox>
                                        <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtMemshipExtend"
                                            WatermarkText="MM/DD/YYYY" runat="server">
                                        </cc1:TextBoxWatermarkExtender>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                            ControlToValidate="txtMemshipExtend" ValidationGroup="ME" ErrorMessage="Extension date is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" Display="Dynamic"
                                            ControlToValidate="txtMemshipExtend" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            SetFocusOnError="True" ValidationGroup="ME" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                        <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtMemshipExtend"
                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnExtend" runat="server" ValidationGroup="ME" Text="Extend" OnClick="btnExtend_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ValidationSummary ID="ValidationSummary4" runat="server" HeaderText="The following error(s) are occurred:"
                                            ShowSummary="true" ValidationGroup="ME" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="50%" border="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblLogo" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="mpeLogo" runat="server" TargetControlID="lblLogo" PopupControlID="pnlLogo"
                            BackgroundCssClass="modal" CancelControlID="lnkClsLogoPopup">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlLogo" runat="server" Width="420px" Style="display: none;">
                            <table class="modalpopup">
                                <colgroup>
                                    <col width="50%" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td align="left" class="header">
                                        Profile Logo:
                                    </td>
                                    <td align="right" style="padding: 5px 10px 0px 10px;">
                                        <asp:LinkButton ID="lnkClsLogoPopup" runat="server" CausesValidation="false"><img src="../../images/popup_close.gif" /></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Upload Your Logo:
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="logoimage" runat="server"></asp:FileUpload>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:LinkButton ID="BtnUpdateLogo" OnClick="BtnUpdateLogo_Click" runat="server" Text="<img src='../../images/upload.gif' border='0'/>"></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblLogoMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <input type="hidden" id="hdnSalesPeronID" value="0" runat="server" />
            <input type="hidden" id="hdnTurnOff" value="True" runat="server" />
            <asp:HiddenField ID="hdnPID" runat="server" />
            <asp:HiddenField ID="hdnUID" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn" />
            <asp:PostBackTrigger ControlID="BtnUpdateLogo" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function isNumber() {
            if (Page_ClientValidate('g')) {
                if (document.getElementById('<%=drpcategory.ClientID %>').selectedIndex == 1) {
                    var numbers = /^[0-9]+$/;
                    var inputtxt = document.getElementById("<%=txtcategory.ClientID %>").value;
                    if (inputtxt.match(numbers)) {
                        return true;
                    }
                    else {
                        alert('Please enter numerics only.');
                        return false;
                    }
                }
                else {
                    if (document.getElementById("<%=txtcategory.ClientID %>").value == "") {
                        var alertMessage = '<%=drpcategory.SelectedItem.Text%>';
                        alert(alertMessage);
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        function CheckNotes() {
            var msg = '';
            if (document.getElementById('<%=TxtBxNotes.ClientID %>').value == '')
                msg = 'Please enter comments for Notes.\n';
            if (document.getElementById('<%=txtNotesBy.ClientID %>').value == '')
                msg = msg + 'Please enter your name for Notes By.';
            if (msg != '') {
                alert(msg);
                return false;
            }
            else
                return true;
        }

        function Enabled_Disabled(message) {
            message = document.getElementById('<%= HyperEnable.ClientID %>').innerText;
            if (message == 'Enable') {
                return confirm('Are you sure you want to enable?');
            }
            else {
                return confirm('Are you sure you want to disable?');
            }
        }
        function ValidateSalesPerson() {
            var newSalesID = document.getElementById('<%=ddlReferBy.ClientID %>').value;
            var oldSalesID = document.getElementById("<%=hdnSalesPeronID.ClientID %>").value;

            if (newSalesID == oldSalesID) {
                alert('Sales person already assigned.');
                return false;
            }
            else {
                return confirm('Are your sure you want to assign?');
            }

        }
        function ShowModalDialog() {
            $find('<%=UpdateModalPopup.ClientID %>').show();
            document.getElementById('<%=ValidationSummary2.ClientID%>').style.display = 'none';
            document.getElementById('<%=RequiredFieldValidator7.ClientID%>').style.display = 'none';
            document.getElementById('<%=RequiredFieldValidator8.ClientID%>').style.display = 'none';
            document.getElementById('<%=RegularExpressionValidator2.ClientID%>').style.display = 'none';
            document.getElementById('<%=RegularExpressionValidator4.ClientID%>').style.display = 'none';
            document.getElementById('<%=txtNewPwd.ClientID%>').value = "";
            document.getElementById('<%=txtCnfPwd.ClientID%>').value = "";
            var userSelect = document.getElementById('<%=ddlAssociates.ClientID%>');
            var selectedText = userSelect.options[userSelect.selectedIndex].text;
            document.getElementById('<%=lblResetUser.ClientID%>').innerHTML = '<div style="padding-left: 5px;"><b>User ID:</b> ' + document.getElementById('<%=ddlAssociates.ClientID%>').value + '</div><div style="clear:both;"></div><div style="padding-left: 5px;"><b>Username:</b> ' + selectedText + '</div>';
            return false;
        }
        function ShowLogoUploadDialog() {
            $find('<%=mpeLogo.ClientID %>').show();
            document.getElementById('<%=lblLogoMsg.ClientID%>').innerHTML = '';
            return false;
        }
        function ShowAccessCodeDialog() {
            var pin = document.getElementById('<%=lblAccCode.ClientID %>');
            if (pin != null)
                accessCode = pin.innerHTML;
            if (accessCode != null || accessCode != "")
                document.getElementById('<%=txtAccsCode.ClientID%>').value = accessCode;
            else
                document.getElementById('<%=txtAccsCode.ClientID%>').value = "";
            $find('<%=mpeAccessCode.ClientID %>').show();
            document.getElementById('<%=ValidationSummary3.ClientID%>').style.display = 'none';
            document.getElementById('<%=REValphaOnly.ClientID%>').style.display = 'none';
            document.getElementById('<%=RequiredFieldValidator5.ClientID%>').style.display = 'none';
            return false;
        }
        function ShowPinCodeDialog() {
            var pinCode = document.getElementById('<%=lblAppPinCode.ClientID %>');
            if (pinCode != null)
                accessCode = pinCode.innerHTML;
            if (accessCode != null || accessCode != "")
                document.getElementById('<%=txtPinDummy.ClientID%>').value = accessCode;
            else
                document.getElementById('<%=txtPinDummy.ClientID%>').value = "";
            $find('<%=modalPinCode.ClientID %>').show();
            document.getElementById('<%=ValidationSummary5.ClientID%>').style.display = 'none';
            document.getElementById('<%=RegularExpressionValidator3.ClientID%>').style.display = 'none';
            document.getElementById('<%=RequiredFieldValidator9.ClientID%>').style.display = 'none';
            return false;
        }
        function ShowExtendModalDialog() {
            $find('<%=mpeExtendMemship.ClientID %>').show();
            document.getElementById('<%=ValidationSummary4.ClientID%>').style.display = 'none';
            document.getElementById('<%=RegularDate.ClientID%>').style.display = 'none';
            document.getElementById('<%=RequiredFieldValidator6.ClientID%>').style.display = 'none';
            document.getElementById('<%=txtMemshipExtend.ClientID%>').value = "";
            return false;
        }
    </script>
</asp:Content>
