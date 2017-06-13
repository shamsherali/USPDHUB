<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="ModifyAppBGImage.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ModifyAppBGImage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="valign-top">
                            <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td>
                                                    Manage App BG Image
                                                </td>
                                                <td align="left">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                                <td class="right" align="right">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Label ID="lblBGImageMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table class="inputtable" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="valign-top">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 24px">
                                                                            <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>'
                                                                                width="9" />
                                                                        </td>
                                                                        <td class="new-header">
                                                                            App BG Image
                                                                        </td>
                                                                        <td>
                                                                            <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>'
                                                                                width="9" />
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table class="new-table" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="valign-top" align="center">
                                                                            <table cellspacing="0" cellpadding="0" align="center" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="center" colspan="2">
                                                                                            <div style="max-width: 800px; max-height: 800px; overflow: auto;">
                                                                                                <asp:Image ID="imgBGImage" runat="server" Visible="false"></asp:Image>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="align-center" colspan="2">
                                                                                            <br />
                                                                                            <asp:Button ID="btnBGImgDelete1" OnClientClick="return confirm(' Are you sure you want to delete this image?');"
                                                                                                runat="server" Text="Delete Image" OnClick="btnBGImgDelete"></asp:Button>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding-top: 10px;" valign="top">
                                                                                            <asp:FileUpload ID="fileuploadBGImage" runat="server"></asp:FileUpload><br />
                                                                                            <span class="profile-caption red-color">NOTE: Please use gif, jpeg, png or bmp files
                                                                                                only.</span>
                                                                                        </td>
                                                                                        <td style="padding-top: 10px; padding-left: 10px;" valign="top">
                                                                                            <asp:LinkButton ID="BtnUpdateBGImg" runat="server" OnClick="BtnUpdateBGImg_OnClick"
                                                                                                Text="<img src='../../images/upload.gif' border='0'/>"></asp:LinkButton>
                                                                                            <%--<a href="#">
                                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" style='border: 0px;' /></a>--%>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Panel ID="pnlwizard" runat="server" Width="100%">
                                                                                            <table class="profile-btntbl" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td class="align-center">
                                                                                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" />&nbsp;&nbsp;<asp:Button
                                                                                                                ID="btndashboard1" OnClick="btnDashboard_Click" runat="server" Text="Go to Dashboard"
                                                                                                                CausesValidation="false" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnUpdateBGImg" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
