<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ExpirationMembers.aspx.cs" Inherits="USPDHUB.Admin.ExpirationMembers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        .headings
        {
            font-family: Arial,Helvetica,sans-serif;
            font-size: 12px;
        }
        .ReportPanel
        {
            border: 2px solid #ABCDEF;
        }
    </style>
    <script type="text/javascript">
        function ValidateDates() {
            var errMsg = "";
            var strDate = document.getElementById("<%=txtStartDate.ClientID %>").value;
            var endDate = document.getElementById("<%=txtEndDate.ClientID %>").value;
            if (Page_ClientValidate("ME")) {
                if (new Date(strDate) > new Date(endDate))
                    errMsg += "To Date should be later than or equal to From Date.";
                if (errMsg != "") {
                    alert(errMsg);
                    return false;
                }
                else
                    return true;
            }
        }
    </script>
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td style="padding-top: 8px;" align="left" colspan="2">
                                    Expiration Members
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="color: Red;">
                            <tr>
                                <td align="center">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblerror" runat="server" Style="font-weight: bold; font-size: 16px;"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table width="900" border="0" cellpadding="4px" cellspacing="4px" class="ReportPanel">
                            <colgroup>
                                <col width="41%" />
                                <col width="40%" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td colspan="3" align="center">
                                    <table border="0" cellpadding="0" cellspacing="0" width="200px">
                                        <tr>
                                            <td>
                                                <asp:ValidationSummary ID="ValidationSummary4" runat="server" HeaderText="The following error(s) occurred:"
                                                    ShowSummary="true" ValidationGroup="ME" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 20px;">
                                    <span class="headings">From Date:</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>&nbsp;<b>(MM/DD/YYYY)</b>
                                    <asp:RequiredFieldValidator ID="reqDate" runat="server" Display="Dynamic" ControlToValidate="txtStartDate"
                                        ValidationGroup="ME" ErrorMessage="From Date is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regDate" runat="server" Display="Dynamic" ControlToValidate="txtStartDate"
                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        SetFocusOnError="True" ValidationGroup="ME" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtStartDate" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
                                </td>
                                <td>
                                    <span class="headings">To Date:</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>&nbsp;<b>(MM/DD/YYYY)</b>
                                    <asp:RequiredFieldValidator ID="reqEndDate" runat="server" Display="Dynamic" ControlToValidate="txtEndDate"
                                        ValidationGroup="ME" ErrorMessage="To Date is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regEndDate" runat="server" Display="Dynamic"
                                        ControlToValidate="txtEndDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        SetFocusOnError="True" ValidationGroup="ME" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="calext" runat="server" TargetControlID="txtEndDate" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" ValidationGroup="ME" Text="Submit" OnClientClick="return ValidateDates();"
                                        OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </table>
                        <table class="admin-padding inputgrid" cellspacing="0" cellpadding="0" width="900"
                            border="0" style="padding-top: 15px;">
                            <tbody>
                                <tr>
                                    <td align="right" style="padding-right: 10px;">
                                        <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:GridView ID="GrdExpMembers" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CssClass="datagrid2" AllowPaging="True" DataKeyNames="Order_ID" OnPageIndexChanging="GrdExpMembers_PageIndexChanging"
                                            GridLines="None" OnSorting="GrdExpMembers_Sorting" PageSize="10" Width="900">
                                            <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                            <Columns>
                                                <asp:BoundField DataField="User_ID" HeaderText="User ID" ItemStyle-Width="70px" SortExpression="UserID" />
                                                <asp:BoundField DataField="Profile_name" HeaderText="Profile Name" SortExpression="ProfileName" />
                                                <asp:BoundField DataField="subscription_renewal_date" HeaderText="Expiration Date"
                                                    DataFormatString="{0:MMMM d, yyyy hh:mm tt}" HtmlEncode="false" ItemStyle-Width="150px"
                                                    SortExpression="ExpirationDate" />
                                            </Columns>
                                            <HeaderStyle CssClass="title" />
                                            <EmptyDataTemplate>
                                                No data found
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                        <asp:HiddenField ID="hdnsortcount" runat="server" />
                                        <asp:HiddenField ID="hdnsortdire" runat="server" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:Panel ID="pnlexportexcel" runat="server" Visible="false">
                            <asp:GridView ID="grdExportexcel" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="User_ID" HeaderText="User ID" ItemStyle-Width="70px" SortExpression="UserID" />
                                    <asp:BoundField DataField="Profile_name" HeaderText="Profile Name" SortExpression="ProfileName" />
                                    <asp:BoundField DataField="subscription_renewal_date" HeaderText="Expiration Date"
                                        DataFormatString="{0:MMMM d, yyyy hh:mm tt}" HtmlEncode="false" ItemStyle-Width="150px"
                                        SortExpression="ExpirationDate" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
