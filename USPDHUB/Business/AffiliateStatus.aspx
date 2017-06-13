<%@ Page Title="" Language="C#" MasterPageFile="~/SecurePage.master" AutoEventWireup="true"
    CodeBehind="AffiliateStatus.aspx.cs" Inherits="USPDHUB.Business.AffiliateStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script language="javascript">
        history.forward();
    </script>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="body_bg" style="height: 380px;">
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="page-width">
                    <tr>
                        <td class="valign-top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="maingeading" align="left">
                                        Invitation Status
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="font-family: Arial; font-size: 16px; font-weight: bold; color: Green;
                                                    padding-left: 20px;">
                                                    <span>
                                                        <asp:Label ID="lblStatus" runat="server"></asp:Label></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <a href="<%=Page.ResolveClientUrl("~/Default.aspx")%>">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Secure/btn_continue.gif")%>" style="border: 0px;" /></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
