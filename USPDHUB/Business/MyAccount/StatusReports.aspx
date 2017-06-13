<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatusReports.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.StatusReports" MasterPageFile="~/Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    <%=MediaType%> Activity Log
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
                                                                            <asp:GridView ID="grdMediaStatusReport" runat="server" AutoGenerateColumns="False"
                                                                                CssClass="datagrid2" PageSize="10" AllowPaging="True" Width="100%" OnRowDataBound="grdMediaStatusReport_rowDatabound"
                                                                                 OnPageIndexChanging="grdMediaStatusReport_PageIndexChanging">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="ContentTitle" HeaderText="Content Title" ItemStyle-Wrap="true" />
                                                                                    <asp:BoundField DataField="Module" HeaderText="Module Name" />
                                                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                                                    <asp:BoundField DataField="Status" HeaderText="Status " />
                                                                                    <asp:BoundField DataField="Sent_Date" HeaderText="Date" ControlStyle-ForeColor= />
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
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td  align="center" style="padding-left:343px;" >
                        <asp:Button ID="btnDashboard" Text="Dashboard" runat="server" OnClick="btnDashboard_Click" CssClass="btn" style="text-align:center;"  />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
