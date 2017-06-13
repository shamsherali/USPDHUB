<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="GenerateCodes.aspx.cs" Inherits="USPDHUB.Business.MyAccount.GenerateCodes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="webmangement_wrapper">
                <div id="webmangement_leftcol">
                    <div class="webmangement_leftcol_heading">
                        Mobile App Management
                        <asp:HiddenField ID="hdnPreviousDivID" runat="server" />
                    </div>
                    <div class="webmangement_rightcol_rowbg">
                        <div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/gen-app-settings.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/AppManagement.aspx")%>">General
                                App Settings</a></span></div>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divManageButtons">
                            <img src="../../images/dashboard/manage-buttons.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/DefineProfileButtons.aspx")%>">Manage
                                Buttons</a></span></div>
                        <%if (IsSuperAdmin)
                          { %>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divManageLogins">
                            <img src="../../images/dashboard/manage-logins.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx")%>">Manage
                                Logins</a></span></div>
                        <%}
                          else
                          { %>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divManageLogins">
                            <img src="../../images/dashboard/manage-logins.png" /><span><a href="#" onclick="ShowAssociateMSG();">Manage
                                Logins</a></span></div>
                        <%} %>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divManageWebLinks">
                            <img src="../../images/dashboard/web-links.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageWebLinks.aspx")%>">Web
                                Links</a></span></div>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divSocialMedia">
                            <img src="../../images/dashboard/Social-media.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/SocialMedia.aspx")%>">Social
                                Media</a></span>
                        </div>
                        <%--<div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/download_n.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/DownloadInstallers.aspx")%>">
                                Downloads</a></span></div>--%>
                        <div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/appdownloads.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/AppUsageReports.aspx")%>">App
                                Usage Report</a></span></div>
                        <div class="webmangement_rightcol_rowbg_heading13">
                            <img src="../../images/dashboard/invitations_h.png" /><span><a href="javascript:void(0);">Setup
                                Affiliate Apps</a></span></div>
                    </div>
                </div>
                <div id="webmangement_rightcol">
                    <div id="divManageWebLinksPage">
                        <div class="webmangement_rightcol_heading">
                            Request New Activation Codes</div>
                        <div class="clear5">
                        </div>
                        <div>
                            <div style="text-align: center; color: Green;">
                                <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                            </div>
                            <div align="center">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                </asp:UpdateProgress>
                                <div>
                                    <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="S" HeaderText="The following error(s) occurred:"
                                        CssClass="invitationerrormsg_text" />
                                </div>
                            </div>
                            <div id="webmangement_body">
                                <div class="socialmedia_wrapper">
                                    <div id="heading">
                                        Select one option below:
                                    </div>
                                    <div class="clear15">
                                    </div>
                                    <div>
                                        <asp:RadioButton ID="rbPaid" runat="server" Checked="true" GroupName="Paid" />&nbsp;&nbsp;
                                        I will pay for the Affiliate App.
                                    </div>
                                    <div class="clear15">
                                    </div>
                                    <div>
                                        <asp:RadioButton ID="ubUnPaid" runat="server" GroupName="Paid" />&nbsp;&nbsp; User
                                        will pay for the Affiliate App.
                                    </div>
                                    <div class="clear15">
                                    </div>
                                    <div>
                                        Number of Affiliate-Apps you want to activate
                                        <asp:TextBox ID="txtAppsCount" runat="server" Width="40"></asp:TextBox>
                                        &nbsp;&nbsp;(<b>Max limit:
                                            <%=hdnSubAppsCount.Value%></b>)
                                        <asp:RequiredFieldValidator ID="rfvAppsCount" runat="server" ControlToValidate="txtAppsCount"
                                            ErrorMessage="Sub Apps count is mandatory." Display="Dynamic" ValidationGroup="S">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegValidator" runat="server" ControlToValidate="txtAppsCount"
                                            ErrorMessage="Please enter a valid number." Display="Dynamic" ValidationGroup="S"
                                            ValidationExpression="^[1-9]+[0-9]*$">*</asp:RegularExpressionValidator>
                                    </div>
                                    <div class="clear10">
                                    </div>
                                    <div style="margin: 0px auto; width: 200px;">
                                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click"
                                            ValidationGroup="S" OnClientClick="return CheckSubAppsCount()" />
                                        &nbsp;&nbsp;<asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click"
                                            CausesValidation="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnSubAppsCount" runat="server" />
                    <div style="height: 219px;">
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShowAssociateMSG() {
            alert('You do not have sufficient permissions.');
            return false;
        }
        function CheckSubAppsCount() {
            var SubAppsCount_WebConfig = parseInt(document.getElementById("<%=hdnSubAppsCount.ClientID %>").value);
            var SubAppsCount_txt = parseInt(document.getElementById("<%=txtAppsCount.ClientID %>").value);
            if (Page_ClientValidate("S")) {
                if (SubAppsCount_txt <= SubAppsCount_WebConfig)
                    return true;
                else
                    alert("Sub Apps count should be always less than or equal to " + SubAppsCount_WebConfig);
                return false;
            }
        }
    </script>
</asp:Content>
