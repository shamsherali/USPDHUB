<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ApproveAndRejectForms.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.ApproveAndRejectForms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table border="0" cellspacing="5" cellpadding="0" style="padding-left: 150px;">
                <tr>
                    <span style="color: Red; font-size: 16px; font-weight: bold; font-family: Times New Roman;">
                        Approve(Or)Reject&nbsp;&nbsp;Bulletin/Update/Event</span>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblstatusmessage" runat="server" ForeColor="green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" align="center">
                        <asp:UpdateProgress ID="upprogress" runat="server" DisplayAfter="1" AssociatedUpdatePanelID="UpdatePanel2">
                            <ProgressTemplate>
                                <img src='<%=System.Configuration.ConfigurationManager.AppSettings.Get("RootPath")%>/images/popup_ajax-loader.gif' /><b><font
                                    color="green">Processing....</font></b></ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" align="center">
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                            ValidationGroup="g" Font-Size="Small" HeaderText="The following error(s) occurred:" />
                    </td>
                </tr>
                <tr align="center">
                    <td valign="top">
                        <asp:Label ID="Label1" runat="server" Text="Reason For Reject:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtRemarks" runat="server" TextMode="MultiLine" Width="380px" Height="50px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqeditcheck" runat="server" ErrorMessage="Reason for reject is mandatory."
                            Display="Dynamic" ControlToValidate="TxtRemarks" ValidationGroup="g">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <br />
                <tr align="center">
                    <td>
                    </td>
                    <td>
                        <%--       <asp:Button ID="BtnReject" runat="server" Text="Submit" OnClick="BtnReject_Click"
                            CausesValidation="true" ValidationGroup="g" />--%>
                        <asp:ImageButton ID="BtnReject" runat="server" Text="I Accept" ImageUrl="../../images/Homepage/submit.png"
                            OnClick="BtnReject_Click" CausesValidation="true" ValidationGroup="g" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
