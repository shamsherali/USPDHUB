<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ManageCSUsers.aspx.cs" Inherits="USPDHUB.Admin.ManageCSUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
        <tr>
            <td style="padding-left: 6px;" valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                    <tr>
                        <td>
                            Admin Users Management
                        </td>
                        <td>
                            <asp:Label ID="lblerr" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create New" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding inputgrid">
                    <tr>
                        <td valign="top">
                            <asp:GridView ID="ConsumersGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Admin_ID"
                                CssClass="datagrid2" AllowPaging="true" Width="100%" PageSize="50">
                                <Columns>
                                    <asp:BoundField HeaderText="First Name" DataField="First_Name" />
                                    <asp:BoundField HeaderText="Last Name" DataField="Last_Name" />
                                    <asp:BoundField HeaderText="User Name" DataField="User_Name" />
                                    <asp:BoundField HeaderText="Created Date" DataField="Created_Date" />
                                </Columns>
                                <HeaderStyle CssClass="title" />
                                <EmptyDataTemplate>
                                    No data Found
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle ForeColor="#C00000" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
