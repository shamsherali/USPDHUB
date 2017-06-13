<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="AppUsageReports.aspx.cs" Inherits="USPDHUB.Business.MyAccount.AppUsageReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../../Scripts/jsapi.js" language="javascript"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="webmangement_wrapper">
                <div id="webmangement_rightcol">
                    <div id="divAppUsagePage">
                        <div class="webmangement_rightcol_heading">
                            App Usage Report</div>
                        <div class="clear5">
                        </div>
                        <div>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td align="center" style="color: Green; font-size: 14px; font-weight: bold;">
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
                            <table cellspacing="0" cellpadding="0" width="90%" border="0" style="padding: 15px;
                                margin: 0px auto;">
                                <colgroup>
                                    <col width="300" />
                                    <col width="300" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="right" style="padding-right: 10px; padding-bottom: 10px;">
                                        <asp:Button runat="server" ID="btnPrint" Text="Print" ValidationGroup="Chart" Width="70px"
                                            OnClick="btnPrint_OnClick" />
                                    </td>
                                </tr>
                                <tr class='app-usage-row'>
                                    <td>
                                        <b>From Date:</b>&nbsp;
                                        <asp:TextBox ID="txtStartDate" runat="server" Width="160px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqdate" runat="server" ControlToValidate="txtStartDate"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="From Date is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtStartDate"
                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                        <cc1:CalendarExtender ID="calStart" runat="server" Enabled="True" TargetControlID="txtStartDate"
                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                    </td>
                                    <td>
                                        <b>To Date:</b>&nbsp;
                                        <asp:TextBox ID="txtEndDate" runat="server" Width="160px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEndDate"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="To Date is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"
                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                        <cc1:CalendarExtender ID="calEnd" runat="server" TargetControlID="txtEndDate" Format="MM/dd/yyyy"
                                            CssClass="MyCalendar" />
                                    </td>
                                    <td align="left" valign="top" class="usage-button">
                                        <asp:Button ID="btnchart" Text="Submit" runat="server" ValidationGroup="Chart" OnClick="btnchart_Click"
                                            OnClientClick="return ShowPieChart();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center" style="padding-top: 10px;">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <div class="app-chart chart-one">
                                            <asp:Label ID="lblTotalCount" runat="server"></asp:Label>
                                            <br />
                                            <div class="label-title">
                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                            </div>
                                            <asp:Chart ID="chartAppUsage" runat="server" Width="400px">
                                                <Titles>
                                                    <asp:Title ShadowOffset="30" />
                                                </Titles>
                                                <Legends>
                                                    <asp:Legend Font="Microsoft Sans Serif, 10pt" Alignment="Near" Docking="Right" LegendStyle="Column">
                                                    </asp:Legend>
                                                </Legends>
                                                <Series>
                                                    <asp:Series IsVisibleInLegend="true" Name="Legend" ChartType="Pie" IsValueShownAsLabel="true"
                                                        Font="Microsoft Sans Serif, 10pt" LabelForeColor="#FFFFFF">
                                                    </asp:Series>
                                                </Series>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="UsageChartArea" BackColor="white">
                                                    </asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table width="100%">
                            <tr>
                                <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA;
                                    padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnCancel" runat="server" Text="Dashboard" PostBackUrl="~/Business/MyAccount/Default.aspx"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                        <div class="clear10">
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShowPieChart() {
            if (Page_ClientValidate('Chart') && Page_IsValid) {
                var startDt = new Date(document.getElementById('<%=txtStartDate.ClientID%>').value);
                var endDt = new Date(document.getElementById('<%=txtEndDate.ClientID%>').value);
                var today = new Date();
                var ErrMsg = "";
                //if (!(startDt <= today))
                // ErrMsg = "From Date should be always lesser than or equal to current Date.\n";
                //if (!(endDt <= today))
                // ErrMsg = ErrMsg + "To Date should be always lesser than or equal to current Date.\n";
                startDt = new Date(startDt);
                endDt = new Date(endDt);
                if (!(startDt <= endDt))
                    ErrMsg = ErrMsg + "To Date should be always greater than or equal to From Date.";
                if (ErrMsg == "") {
                    return true
                }
                else {
                    alert(ErrMsg);
                }

            }
            return false;
        }
    </script>
</asp:Content>
