<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="USPDHUB.Admin.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="page-top">
                        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding">
                            <tr>
                                <td class="valign-top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                                        <tr>
                                            <td>
                                                Welcome to the USPDhub Admin Panel
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <colgroup>
                                            <col width="48%" style="padding-right: 7px" />
                                            <col width="*" />
                                        </colgroup>
                                        <tr>
                                            <td class="valign-top">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid">
                                                    <tr class="title">
                                                        <td class="bold">
                                                            User Management
                                                        </td>
                                                    </tr>
                                                    <%if (Session["AdminUserRole"] == null || Convert.ToInt32(Session["AdminUserRole"]) != Convert.ToInt32(USPDHUBBLL.UtilitiesBLL.RoleTypes.Developer))
                                                      { %>
                                                    <tr>
                                                        <td class="bold">
                                                            <%--<asp:LinkButton ID="lnkUserManagement" runat="server" OnClick="lnkUserManagement_Click">Users Management</asp:LinkButton>--%>
                                                            <a href="<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/Admin/ConsumerManagement.aspx">
                                                                Users Management</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("~/Admin/Customerservicenew.aspx")%>">Customer Service</a>
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none;">
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("~/Admin/EnquiryListings.aspx")%>">Pending Verifications</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <asp:LinkButton ID="lnkSalesPeople" runat="server" OnClick="lnkSalesPeople_Click">Manage Sales People</asp:LinkButton>
                                                            <%--<a href="<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/Admin/ManageSalesPeople.aspx">
                                                                Manage Sales People</a>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("~/Admin/ManagePromocodes.aspx")%>">Promo Codes</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/DashboardLoginReport.aspx")%>">Dashboard Login
                                                                Report</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/ManageAccessCodes.aspx")%>">Manage Access
                                                                Codes</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/ManageRequestCustomForms.aspx")%>">Manage
                                                                Request Custom Forms</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/ManageBrandedAppProcessStatus.aspx")%>">Manage
                                                                Branded App Order Status</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/AppStatisticsReportNew.aspx")%>">App Download
                                                                Report</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/SubappsManagement.aspx")%>">Sub Apps Management</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/CSNotesReport.aspx")%>">CS Notes Report</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/WebnairItems.aspx")%>">Webinar Management</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/ExpirationMembers.aspx")%>">Expiration Date
                                                                Search</a>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/Admin/UpdateUserAppVersion.aspx">
                                                                Update Member App Version</a>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/ManageActivityLog.aspx")%>">Manage News & Updates</a>
                                                        </td>
                                                    </tr>
                                                    <tr style="display:none;">
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/ManageSponsorAdUsers.aspx")%>">Manage Sponsor Ads</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/ManageSalesCode.aspx")%>">Manage Sales Code</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/ManageRecurringTranscationDetails.aspx")%>">Manage Recurring Transcation Details</a>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="bold">
                                                            <a href="<%=Page.ResolveClientUrl("/Admin/ManageInvoices.aspx")%>">Manage Invoices</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table cellspacing="0" cellpadding="0" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCheckPermission" runat="server"></asp:Label>
                                        <asp:ModalPopupExtender ID="mpeCheckPermission" runat="server" BackgroundCssClass="modal"
                                            PopupControlID="pnlCheckPermission" TargetControlID="lblCheckPermission" CancelControlID="imgClose">
                                        </asp:ModalPopupExtender>
                                        <asp:Panel Style="display: none" ID="pnlCheckPermission" runat="server" Width="100%"
                                            DefaultButton="btnSumbit">
                                            <table class="popuptable" cellspacing="0" cellpadding="0" width="600px" align="center"
                                                border="0">
                                                <tr>
                                                    <td align="center">
                                                        <asp:UpdateProgress ID="UpdateProgress10" runat="server" DisplayAfter="3">
                                                            <ProgressTemplate>
                                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                    <td align="right">
                                                        <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                            CausesValidation="false"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="left" style="color: Green; font-size: 14px; font-weight: bold;">
                                                        <asp:Label ID="lblHeader" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Label ID="lblerror" runat="server" Style="color: Red; font-size: 14px;"></asp:Label>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                                                        ValidationGroup="P" HeaderText="The following error(s) occurred:" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                                            <tr style="display: none;">
                                                                <td style="width: 100px; padding-left: 150px;">
                                                                    User name:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtUserName" runat="server" TabIndex="1" Text="user"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RFUserName" ControlToValidate="txtUserName"
                                                                        ValidationGroup="P" ErrorMessage="User name is mandatory.">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; padding-left: 150px;">
                                                                    Password:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150" TabIndex="2"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RFPassword" ControlToValidate="txtPassword"
                                                                        ValidationGroup="P" ErrorMessage="Password is mandatory.">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 10px;" colspan="2">
                                                                    <asp:Button ID="btnSumbit" runat="server" Text="Check" ValidationGroup="P" TabIndex="3"
                                                                        OnClick="btnSumbit_Click" />
                                                                    <asp:HiddenField ID="hdnPage" runat="server" />
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
