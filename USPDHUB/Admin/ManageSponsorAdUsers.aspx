<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ManageSponsorAdUsers.aspx.cs" MasterPageFile="~/AdminHome.master"
    Inherits="USPDHUB.Admin.ManageSponsorAdUsers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
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
                                    Manage Sponsor Ads
                                </td>
                                <td style="padding-right: 70px;">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label>
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
                                                                            <asp:GridView ID="grdSponsorAdUsers" runat="server" AllowSorting="true" AutoGenerateColumns="False"
                                                                                AllowPaging="true" Width="100%" CssClass="datagrid2" OnPageIndexChanging="grdSponsorAdUsers_PageIndexChanging" 
                                                                                PageSize="6">
                                                                                
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="User ID">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblUserId" runat="server" Text='<%#Eval("User_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="100px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="First Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblfrstName" runat="server" Text='<%#Eval("Firstname") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="150px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Last Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbllastname" runat="server" Text='<%#Eval("Lastname") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="170px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Profile Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblProfileName" runat="server" Text='<%#Eval("Profile_name") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="170px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="User Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblUsername" runat="server" Text='<%#Eval("Username") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="130px" />
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    <asp:TemplateField HeaderText="">
                                                                                        <ItemTemplate>
                                                                                            <asp:Button runat="server" ID="btnManageAds" Text="Manage Ads" CommandArgument='<%#Eval("User_ID")+ ","+Eval("Profile_ID") %>' OnClick="btnManageAds_Click"/>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="10px" />
                                                                                    </asp:TemplateField>
                                                                                 </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <asp:Label ID="lblBUempty" runat="server" Text="There are no sponsor ad users."
                                                                                        Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                                                </EmptyDataTemplate>
                                                                                <HeaderStyle CssClass="title1" />
                                                                                <EmptyDataRowStyle ForeColor="#C00000" />
                                                                                <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
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
                       
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>