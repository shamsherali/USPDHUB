<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRecurringTranscationDetails.aspx.cs"
    MasterPageFile="~/AdminHome.master" Inherits="USPDHUB.Admin.ManageRecurringTranscationDetails" %>
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
                                  Auto Recurring Transaction Details
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
                                                                          <asp:GridView ID="grdTranscationDetails" runat="server" AutoGenerateColumns="False"
                                                                                  CssClass="datagrid2" PageSize="10" AllowPaging="True" OnRowDataBound="grdTranscationDetails_rowDatabound"
                                                                                    Width="100%"  
                                                                                onpageindexchanging="grdTranscationDetails_PageIndexChanging" >
                                                                                 <Columns>
                                                                                 
                                                                                 <asp:BoundField DataField="UserID" HeaderText="User ID" ItemStyle-Wrap="true"  />
                                                                                 <asp:BoundField DataField="ProfileID" HeaderText="Profile ID" />
                                                                                 <asp:BoundField DataField="Profile_name" HeaderText="Profile Name" />
                                                                                 <asp:BoundField DataField="BillableAmount" HeaderText="Billable Amount" />
                                                                                 <asp:BoundField DataField="ResponseCode" HeaderText="Response Code" />
                                                                                 <asp:BoundField DataField="ResponseMessage" HeaderText="Response Message" ItemStyle-Wrap="true" />
                                                                                <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />
                                                                                 </Columns>
                                                                                    <HeaderStyle CssClass="title1" />
                                                                                    <EmptyDataTemplate>
                                                                                        <asp:Label ID="lblempty" runat="server" Text="There are no content at this time."
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
                       
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>