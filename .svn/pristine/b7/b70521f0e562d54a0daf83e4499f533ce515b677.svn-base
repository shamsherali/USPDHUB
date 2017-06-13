<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ManageActivityLog.aspx.cs" Inherits="USPDHUB.Admin.ManageActivityLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        #tblpreview
        {
            width: 100%;
            border-width: 0;
        }
        #tblpreview td
        {
            border: none;
        }
    </style>
    <asp:ScriptManager ID="smgr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Manage News & Updates
                                </td>
                                <td style="padding-right: 70px;">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnAddActivity" runat="server" Text="Add News & Updates" OnClick="btnAddActivity_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label>
                                </td>
                            </tr>
                            </br>
                            </br>
                            <tr>
                                <td style="padding-top: 10px;">
                                    <asp:Label ID="lblSelectVertical" runat="server" Text="Select a Vertical" Style="float: left;
                                        display: block;"></asp:Label>&nbsp;
                                    <asp:DropDownList ID="ddlDomainName" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDomainName_SelectedIndexChanged" Width="140px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
                            <colgroup>
                                <col width="310px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td colspan="2" class="content">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td class="leftmenu">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <asp:GridView ID="gvActivity" runat="server" AutoGenerateColumns="False" DataKeyNames="ActivityID"
                                                                                CssClass="datagrid2" Width="100%" PageSize="10" AllowPaging="True"  AllowSorting="True" OnPageIndexChanging="gvActivity_PageIndexChanging" OnSorting="gvActivity_Sorting">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="User ID">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblProfileID" runat="server" Text='<%# Bind("User_ID") %>' Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="50px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Profile Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblPName" runat="server" Text='<%# Bind("Profile_name") %>' Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="150px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="News & Updates">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblPreviewHTML" runat="server" Text='<%# Bind("PreviewHtml") %>' Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                     <asp:TemplateField HeaderText="Vertical" >
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblVertical" runat="server" Text='<%# Bind("Vertical") %>' Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Created Date" SortExpression="date" >
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Bind("CreatedDate") %>' Width="100%"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Edit">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="btnEdit" Text="<img src='../../Images/Dashboard/icon_modify.gif' title='Edit' border='0'"
                                                                                                CommandArgument='<%#Eval("ActivityID") %>' OnClick="btnEdit_Click"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="10px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Delete">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="btnDelete" Text="<img src='../../Images/Dashboard/icon_delete.gif' title='Delete' border='0'"
                                                                                                CommandArgument='<%#Eval("ActivityID") %>' OnClick="btnDelete_Click" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="10px" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <HeaderStyle CssClass="title1" />
                                                                                <EmptyDataTemplate>
                                                                                    <asp:Label ID="lblBUempty" runat="server" Text="There are no content at this time."
                                                                                        Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                                                </EmptyDataTemplate>
                                                                                <EmptyDataRowStyle ForeColor="#C00000" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                          <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                           <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="page-title">
                            <tr>
                                <td align="right">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
