<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageInvoices.aspx.cs"
    EnableEventValidation="true" MasterPageFile="~/AdminHome.master" Inherits="USPDHUB.Admin.ManageInvoices" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style>
        .createbtn
        {
            width: 100px;
            height: 30px;
            border-radius: 4.5px;
            font-weight: 600;
            background-color: #5b99d8;
            color: white;
        }
    </style>
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Manage Invoices
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
                                                                            <div>
                                                                                <asp:GridView ID="grdBillMe" runat="server" AutoGenerateColumns="False" DataKeyNames="SubscriptionType_ID" AllowSorting="true"
                                                                                    CssClass="datagrid2" PageSize="10" AllowPaging="True" Width="100%" OnPageIndexChanging="grdBillMe_PageIndexChanging" OnSorting="grdBillMe_Sorting">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="User_ID" HeaderText="User ID" />
                                                                                        <asp:BoundField DataField="Profile_ID" HeaderText="Profile ID" />
                                                                                        <asp:BoundField DataField="Profile_Name" HeaderText="Profile Name" />
                                                                                        <asp:BoundField DataField="subscription_renewal_date" HeaderText="Renewal Date" />
                                                                                        <asp:BoundField DataField="Renewal_Cost" HeaderText="Renewal Cost" />
                                                                                    
                                                                                        <asp:BoundField DataField="SentDate" HeaderText="Last Invoice Sent Date" SortExpression="DateSent" />
                                                                                      
                                                                                        <asp:TemplateField HeaderText="Send">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="btnSend" runat="server" CommandArgument='<%#Eval("SubscriptionType_ID") %>'
                                                                                                    Text="Send Invoice" OnClick="btnSend_Click"></asp:LinkButton>
                                                                                            </ItemTemplate>
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
                                                    <tr>
                                                        <td>
                                                            <div>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblPopPreview" runat="server"></asp:Label>
                                                                                <cc1:ModalPopupExtender ID="MPEPreview" runat="server" TargetControlID="lblPopPreview"
                                                                                    PopupControlID="pnlPreview" BackgroundCssClass="modal" CancelControlID="imglogin2" >
                                                                                </cc1:ModalPopupExtender>
                                                                                <asp:Panel Style="display: none;" ID="pnlPreview" runat="server" Width="100%">
                                                                                    <table class="popuptable" cellspacing="0" cellpadding="0" width="400" align="center"
                                                                                        border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                                                                        <ProgressTemplate>
                                                                                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                                                        </ProgressTemplate>
                                                                                                    </asp:UpdateProgress>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td style="font-weight: bold; color: #3b73af; font-size: 14px;">
                                                                                                                    Send Invoice
                                                                                                                </td>
                                                                                                                <td align="right">
                                                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                                                                        CausesValidation="false"></asp:ImageButton>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="padding-right: 10px;">
                                                                                                    <br />
                                                                                                    <br />
                                                                                                    <div style="overflow-y: auto; max-height: 340px; border: 1px solid black;">
                                                                                                        <asp:Label ID="lblInvoice" runat="server"></asp:Label>
                                                                                                    </div>
                                                                                                    <br />
                                                                                                    <br />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <font color="red">*</font>
                                                                                                    <asp:Label ID="lblInitial" runat="server" Text="Initial Name:"></asp:Label>
                                                                                                    <asp:TextBox ID="txtInitial" runat="server" CssClass="HelpBox" Width="200px" Style="border: solid 1px black;"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="rfvinitial" runat="server" Display="Dynamic" ValidationGroup="SV"
                                                                                                        ControlToValidate="txtInitial" ErrorMessage="Enter Initial Name"></asp:RequiredFieldValidator>
                                                                                                    <br />
                                                                                                    <br />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <font color="red">*</font>
                                                                                                    <asp:Label ID="lblRemark" runat="server" Text="Remarks:"></asp:Label>
                                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtRemark" runat="server" CssClass="HelpBox"
                                                                                                        Width="200px" TextMode="MultiLine" Style="border: solid 1px black;"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                                                        ValidationGroup="SV" ControlToValidate="txtRemark" ErrorMessage="Enter Remarks"></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" align="center">
                                                                                                    <br />
                                                                                                    <asp:Button ID="btnSubmit" runat="server" Text="Send" CssClass="HelpButton" border="0"
                                                                                                        OnClick="btnSubmit_Click" ValidationGroup="SV" />
                                                                                                    <br />
                                                                                                    <br />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
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
            <asp:HiddenField ID="hdnManageInvoiceSortCount" runat="server" Value="" />
            <asp:HiddenField ID="hdnManageInvoiceSorttDir" runat="server" Value="" />
            <asp:HiddenField ID="hdnDate" runat="server" Value="" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div>
                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
