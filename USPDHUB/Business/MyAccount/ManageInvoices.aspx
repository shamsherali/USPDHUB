<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" Inherits="Business_MyAccount_ManageInvoices"
    CodeBehind="ManageInvoices.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <table width="100%" height="100%" class="page-top" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="valign-top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                    <tr>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                                <tr>
                                    <td>
                                        Billing History <a id="A3" href="javascript:ModalHelpPopup('Billing History',160,'');">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-top">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <!-- Form body functionality will be displayed. -->
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="title1">
                                                    <asp:GridView ID="DgInvoice" Width="100%" AutoGenerateColumns="False" runat="server"
                                                        OnRowDataBound="DgInvoice_RowDataBound" CssClass="datagrid2">
                                                        <Columns>
                                                            <asp:BoundField DataField="Profile_ID" HeaderText="Profile ID">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SubscriptionType_ID" HeaderText="Invoice ID">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Created_Date" HeaderText="Invoice Date" HtmlEncode="False"
                                                                DataFormatString="{0:MM/dd/yyyy}">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Subscription_EndDate" HeaderText="Subscription Renewal Date"
                                                                HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="OrderBillable_Amt" HeaderText="Amount">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lkbt1" Text="Download" runat="server" OnClick="lkbt1_Click" CssClass="blue-color"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerSettings Position="TopAndBottom" />
                                                        <HeaderStyle CssClass="title1" />
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
