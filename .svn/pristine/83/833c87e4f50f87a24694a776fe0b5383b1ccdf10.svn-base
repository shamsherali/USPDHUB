<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="SubappsManagement.aspx.cs" Inherits="USPDHUB.Admin.SubappsManagement"
    ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportDown" />
            <asp:PostBackTrigger ControlID="btnExportUp" />
        </Triggers>
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td style="padding-left: 6px;" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Manage Sub Apps
                                </td>
                                <td>
                                    <asp:Label ID="lblerr" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding inputgrid">
                                <tr>
                                    <td align="right">
                                        <div style="float: left;">
                                            <asp:Label ID="Label3" runat="server" Text="&nbsp;" Style="background-color: #808080;"
                                                Width="25px"></asp:Label>
                                            <asp:Label ID="Label5" Text="- Colored rows are parent users." runat="server" Style="font-weight: bold;
                                                font-size: 14px;"></asp:Label>
                                        </div>
                                        <asp:Button ID="btnExportUp" runat="server" Text="Export to Excel" OnClick="BtnExport_OnClick"
                                            Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:GridView ID="SubappsGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Profile_ID"
                                            CssClass="datagrid2" Width="100%" PageSize="10" AllowPaging="True" OnPageIndexChanging="SubappsGrid_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Profile ID">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdnParentProfileID" runat="server" Value='<%#Eval("Parent_ProfileID")%>' />
                                                        <asp:Label ID="lblgridProfile" runat="server" Text='<%# Bind("Profile_ID") %>' Style="margin-left: 20px;"></asp:Label>
                                                       
                                                    </ItemTemplate>
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="User ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgridUser" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Profile Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgridProfileName" runat="server" Text='<%# Bind("Profile_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="270px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="User Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgridUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="199px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="title" />
                                            <EmptyDataTemplate>
                                                No data Found
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle ForeColor="#C00000" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnExportDown" runat="server" Text="Export to Excel" OnClick="BtnExport_OnClick"
                                            Visible="false" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="dummyGridview" Style="display: none;" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Profile_ID" CssClass="datagrid2" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Profile ID">
                        <ItemTemplate>                         
                            <asp:HiddenField ID="hdnParentProfileID" runat="server" Value='<%#Eval("Parent_ProfileID")%>' />
                            <asp:Label ID="lblgridProfile" runat="server" Text='<%# Bind("Profile_ID") %>' Style="margin-left: 20px;"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="180px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User ID">
                        <ItemTemplate>
                            <asp:Label ID="lblgridUser" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="180px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Profile Name">
                        <ItemTemplate>
                            <asp:Label ID="lblgridProfileName" runat="server" Text='<%# Bind("Profile_Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="270px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>
                            <asp:Label ID="lblgridUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="199px" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="title" />
                <EmptyDataTemplate>
                    No data Found
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="#C00000" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
