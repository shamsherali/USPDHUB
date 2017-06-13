<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="AppStatisticsReport.aspx.cs" Inherits="USPDHUB.Admin.AppStatisticsReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <style type="text/css">
        .CssDropdowns
        {
            width: 200px;
            padding: 1px;
            font-size: 13px;
            line-height: 1;
            font-family: Arial,Helvetica,sans-serif;
        }
        .headings
        {
            font-family: Arial,Helvetica,sans-serif;
            font-size: 12px;
        }
        .ReportPanel
        {
            border: 2px solid #ABCDEF;
        }
        .ReportPreview
        {
            width: 100%;
            overflow: scroll;
            height: 400px;
        }
        .VerticalBox
        {
            border: 1px solid orange;
            padding: 6px;
        }
    </style>
    <script type="text/javascript">
        function ValidateDates() {
            var errMsg = "";
            var userId = document.getElementById("<%=txtUserId.ClientID %>");
            var checkBoxList = document.getElementById("<%=chkVerticals.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }

            var strDate = document.getElementById("<%=txtStartDate.ClientID %>").value;
            var endDate = document.getElementById("<%=txtEndDate.ClientID %>").value;
            if (Page_ClientValidate("ME")) {

                if ((userId.value != "" || userId.value != null) || (isValid == true)) {
                }
                else
                    errMsg += "Your criteria is invalid.\n";
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
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td style="padding-top: 8px;" align="left" colspan="2">
                                    APP Download Report
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
                        <table width="100%" border="0" cellpadding="4px" cellspacing="4px" class="ReportPanel">
                            <colgroup>
                                <col width="50%" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td colspan="2" style="padding-left: 150px;">
                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" HeaderText="The following error(s) occurred:"
                                        ShowSummary="true" ValidationGroup="ME" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 20px;">
                                    <span class="headings">From Date:</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtStartDate" runat="server" Width="195px"></asp:TextBox>&nbsp;<b>(MM/DD/YYYY)</b>
                                    <asp:RequiredFieldValidator ID="reqDate" runat="server" Display="Dynamic" ControlToValidate="txtStartDate"
                                        ValidationGroup="ME" ErrorMessage="start date is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regDate" runat="server" Display="Dynamic" ControlToValidate="txtStartDate"
                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        SetFocusOnError="True" ValidationGroup="ME" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtStartDate" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
                                </td>
                                <td>
                                    <span class="headings">To Date:</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtEndDate" runat="server" Width="195px"></asp:TextBox>&nbsp;<b>(MM/DD/YYYY)</b>
                                    <asp:RequiredFieldValidator ID="reqEndDate" runat="server" Display="Dynamic" ControlToValidate="txtEndDate"
                                        ValidationGroup="ME" ErrorMessage="end date is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regEndDate" runat="server" Display="Dynamic"
                                        ControlToValidate="txtEndDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        SetFocusOnError="True" ValidationGroup="ME" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="calext" runat="server" TargetControlID="txtEndDate" Format="MM/dd/yyyy"
                                        CssClass="MyCalendar" />
                                </td>
                            </tr>
                            <tr style="border-width: 1px;">
                                <td colspan="2" style="padding-left:20px;">
                                    <span class="headings">Select Criteria:</span>&nbsp;
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="VerticalBox">
                                        <td>
                                            <div>
                                                <div>
                                                    <asp:CheckBoxList runat="server" ID="chkVerticals" RepeatColumns="3">
                                                    </asp:CheckBoxList>
                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <span class="headings">User Type:</span>&nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList runat="server" ID="ddlUser" CssClass="CssDropdowns">
                                                <asp:ListItem Value="0" Text="All" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Real"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Test"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left:20px;">
                                    <span style="font-weight: bold; color:#005AA0; padding-left:50px;">OR</span>
                                    <div style=" padding-top:10px;">
                                        <span class="headings">Member ID :</span>
                                        <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegExMemberID" runat="server" Display="Dynamic"
                                            ForeColor="Red" ControlToValidate="txtUserId" ValidationExpression="^\d+$" SetFocusOnError="True"
                                            ValidationGroup="ME" ErrorMessage="Please enter valid user id">*</asp:RegularExpressionValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left: 20px;">
                                    <span class="headings">Include Delta :</span>
                                    <asp:CheckBox ID="chkDelta" runat="server" Checked="true" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left: 20px;">
                                    <span class="headings">Include Generic Apps :</span>
                                    <asp:CheckBox ID="chkGenericApps" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnDisplay" runat="server" ValidationGroup="ME" Text="Preview" OnClientClick="return ValidateDates();"
                OnClick="btnDisplay_Click" />
            <asp:Button ID="btnAppReports" runat="server" ValidationGroup="ME" Text="Download Report"
                OnClientClick="return ValidateDates();" OnClick="btnAppReports_Click" />
            <div class="ReportPreview">
                <asp:Literal ID="ltrlDisplayData" runat="server"></asp:Literal>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
