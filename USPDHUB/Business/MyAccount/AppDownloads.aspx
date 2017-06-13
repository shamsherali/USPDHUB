<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="AppDownloads.aspx.cs" Inherits="USPDHUB.Business.MyAccount.AppDownloads" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jsapi.js" language="javascript"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <script type="text/javascript">
        function ShowPieChart() {
            if (Page_ClientValidate('Chart') && Page_IsValid) {
                var startDt = document.getElementById('<%=txtStartDate.ClientID%>').value;
                var endDt = document.getElementById('<%=txtEndDate.ClientID%>').value;
                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!
                var yyyy = today.getFullYear();
                if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm }
                var today = mm + '/' + dd + '/' + yyyy;
                var ErrMsg = "";
                if (!(startDt <= today))
                    ErrMsg = "From Date should be always lesser than or equal to current Date.\n";
                if (!(endDt <= today))
                    ErrMsg = ErrMsg + "To Date should be always lesser than or equal to current Date.\n";
                if (!(startDt <= endDt))
                    ErrMsg = ErrMsg + "To Date should be always greater than or equal to From Date.";
                if (ErrMsg == "") {
                    PageMethods.ServerSidefill(startDt, endDt, OnSuccess, OnFailure);
                }
                else {
                    alert(ErrMsg);
                }

            }
            return false;
        }
        function OnSuccess(result) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'PlatForms');
            data.addColumn('number', 'Downloads');
            if (result.length > 0) {
                for (var i = 0; i < result.length; i++) {
                    data.addRow([result[i].PlatForms, result[i].Downloads]);
                }
                document.getElementById('chart_div').style.height = "350px";
                document.getElementById('chart_div').style.width = '550px';
                new google.visualization.PieChart(document.getElementById('chart_div')).
                draw(data, { title: "App Downloads between " + document.getElementById('<%=txtStartDate.ClientID%>').value + " and " + document.getElementById('<%=txtEndDate.ClientID%>').value +"" });
            }
            else {
                document.getElementById('chart_div').style.height = "0px";
                document.getElementById('chart_div').style.width = '100%';
                document.getElementById('chart_div').innerHTML = '';
                document.getElementById('<%=lblMessage.ClientID%>').innerHTML = "No downloads between " + document.getElementById('<%=txtStartDate.ClientID%>').value + " and " + document.getElementById('<%=txtEndDate.ClientID%>').value + ".";
            }
        }
        function OnFailure(result) {
            alert("An error has been occurred while genearting the chart for app downloads.");
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0"
                style="background: none;">
                <tbody>
                    <tr>
                        <td>
                            <table class="profile-1stlevel" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td valign="top" width="200px;" style="text-decoration: none;">
                                            <font color="green">App Downloads</font>
                                        </td>
                                        <td style="height: 35px; text-align: left; padding-left: 100px;">
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td align="center" style="color: Red; font-size: 14px; font-weight: bold;">
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                        <table cellspacing="0" cellpadding="0" width="50%" border="0">
                                            <tr>
                                                <td align="left" style="color: Red; font-size: 14px; font-weight: normal;">
                                                    <asp:ValidationSummary ID="valDownloads" runat="server" ValidationGroup="Chart" HeaderText="The following error(s) occurred:" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="page-width" style="padding-top: 15px;">
                                <colgroup>
                                    <col width="29%" />
                                    <col width="29%" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td>
                                        <b>From Date:</b>&nbsp;
                                        <asp:TextBox ID="txtStartDate" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqdate" runat="server" ControlToValidate="txtStartDate"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="Start Date is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtStartDate"
                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                        <cc1:CalendarExtender ID="calStart" runat="server" Enabled="True" TargetControlID="txtStartDate"
                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                    </td>
                                    <td>
                                        <b>To Date:</b>&nbsp;
                                        <asp:TextBox ID="txtEndDate" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEndDate"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="To Date is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"
                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                        <cc1:CalendarExtender ID="calEnd" runat="server" TargetControlID="txtEndDate" Format="MM/dd/yyyy"
                                            CssClass="MyCalendar" />
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Button ID="btnchart" Text="Generate Chart" runat="server" ValidationGroup="Chart"
                                            OnClick="btnchart_Click" OnClientClick="return ShowPieChart();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
                                        <div id="chart_div">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
