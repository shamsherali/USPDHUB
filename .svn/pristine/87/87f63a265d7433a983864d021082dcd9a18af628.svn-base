<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="AutoShareTwitter.aspx.cs" Inherits="USPDHUB.Business.MyAccount.AutoShareTwitter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="4px" cellpadding="4px" width="100%" border="0" style="padding-left:6px;">
                <colgroup>
                    <col width="300px" />
                    <col width="*" />
                </colgroup>
                    <tr>
                        <td colspan="2">
                            <h3>
                                Twitter Settings:</h3>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Twitter screen name:
                        </td>
                        <td>
                            <asp:Label ID="lblTwrName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Enable default auto share:
                        </td>
                        <td>
                            <asp:CheckBox ID="chkTwrDefaultShare" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;
                            <asp:Button ID="btnRemoveTwrAccount" runat="server" Text="Remove Account" OnClick="btnRemoveTwrAccount_Click" Visible="false"/>&nbsp;
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
                        </td>
                    </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
