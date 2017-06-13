<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ManageSalesCode.aspx.cs" Inherits="USPDHUB.Admin.ManageSalesCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Channel Codes Management
                                </td>
                                <td style="padding-right: 70px;">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click"
                                        CssClass="btn" Style="float: none !important;" />
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
                                                                            <div style="width: 930px; height: 400px; overflow-x: scroll;">
                                                                                <asp:GridView ID="gvSalesCode" runat="server" AutoGenerateColumns="False" DataKeyNames="ConfigId"
                                                                                    CssClass="datagrid2" PageSize="10" AllowPaging="True" Width="2345px" OnPageIndexChanging="gvSalesCode_PageIndexChanging">
                                                                                    <Columns>
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="SalesCode" HeaderText="Sales Code" />
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="ChannelPartnerName" HeaderText="Channel Partner Name" />
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="ChannelPartnerCommission" HeaderText="Channel Partner Commission" />
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="LTManagerName" HeaderText="Manager Name" />
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="LTManagerCommission" HeaderText="Manager Commission" />
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="ChannelManagerName" HeaderText="Channel Manager Name" />
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="ChannelManagerCommission" HeaderText="Channel Manager Commission" />
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="ChannelAffiliateName" HeaderText="Channel Affiliate Name" />
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="ChannelAffiliateCommission" HeaderText="Channel Affiliate Commission" />
                                                                                        <asp:BoundField DataField="AgreementDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Agreement Date">
                                                                                            <HeaderStyle Width="150px"></HeaderStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="AgreementExpiryDate" DataFormatString="{0:MM/dd/yyyy}"
                                                                                            HeaderText="Agreement Expiry Date">
                                                                                            <HeaderStyle Width="150px"></HeaderStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="MarketingCode" HeaderText="Marketing Code"
                                                                                            Visible="false" />
                                                                                        <asp:TemplateField HeaderText="Delete">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="btnDelete" Text="<img src='../../Images/Dashboard/icon_delete.gif' title='Delete' border='0'"
                                                                                                    CommandArgument='<%#Eval("ConfigId") %>' OnClick="btnDelete_Click" OnClientClick="if (!confirm('Are you sure you want to delete?')) return false;"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="10px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="View">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton runat="server" ID="btnView" Text="<img src='../../Images/Dashboard/preview.png' title='View' border='0'"
                                                                                                    CommandArgument='<%#Eval("ConfigId") %>' OnClick="btnView_Click"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="10px" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle CssClass="title1" />
                                                                                    <EmptyDataTemplate>
                                                                                        <asp:Label ID="lblempty" runat="server" Text="There are no content at this time."
                                                                                            Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                                                    </EmptyDataTemplate>
                                                                                    <EmptyDataRowStyle ForeColor="#C00000" />
                                                                                </asp:GridView>
                                                                            </div>
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
