<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="AutoShareFacebook.aspx.cs" Inherits="USPDHUB.Business.MyAccount.AutoShareFacebook" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        .lstFbPages
        {
            font-family: Arial, Helvetica, Sans-Serif;
            font-size: 13px;
            padding: 6px;
            line-height: 20px;
            width: 200px;
        }
    </style>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="4px" cellpadding="4px" width="100%" border="0" style="padding-left: 6px;">
                <colgroup>
                    <col width="300px" />
                    <col width="*" />
                </colgroup>
                <tr>
                    <td colspan="2">
                        <h3>
                            Facebook Settings:</h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Facebook profile name:
                    </td>
                    <td>
                        <asp:Label ID="lblfbProfileName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Enable default auto share:
                    </td>
                    <td>
                        <asp:CheckBox ID="chkDefaultShare" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Select facebook pages for auto publish:
                    </td>
                    <td>
                        <asp:CheckBoxList ID="chkFbPages" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                            Style="margin-left: -3px;">
                        </asp:CheckBoxList>
                        <%--<asp:ListBox ID="lstFbPages" runat="server" SelectionMode="Multiple" CssClass="lstFbPages"></asp:ListBox>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        &nbsp;
                        <asp:Button ID="btnRemoveAccount" runat="server" Text="Remove Account" OnClick="btnRemoveAccount_Click"
                            Visible="false" />
                        &nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back"
                            OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
