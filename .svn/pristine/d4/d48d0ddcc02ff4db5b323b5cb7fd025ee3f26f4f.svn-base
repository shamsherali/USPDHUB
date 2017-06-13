<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="SponsorAdClickCountReport.aspx.cs" 
 MasterPageFile="~/AdminHome.master" Inherits="USPDHUB.Admin.SponsorAdClickCountReport" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
<asp:ScriptManager ID="smgr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../../Scripts/jsapi.js" language="javascript"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });
        function showTooltip(value1, ex) {
            if (value1 != "") {
                var tooltip = document.getElementById("myToolTip");
                tooltip.style.visibility = "visible";
                var posx = 0;
                var posy = 0;
                if (!e) var e = (window.event) ? event : ex;
                if (e.pageX || e.pageY) {
                    posx = e.pageX;
                    posy = e.pageY;
                    tooltip.style.left = (posx - 10) + "px";
                    tooltip.style.top = (posy - 50) + "px";
                }
                else if (e.clientX || e.clientY) {
                    if (e.cancelBubble != null) e.cancelBubble = true;
                    //for IE8 and earlier versions event bubbling occurs...
                    posx = e.clientX + document.body.scrollLeft
                   + document.documentElement.scrollLeft;
                    posy = e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
                    tooltip.style.left = (posx - 10) + "px";
                    tooltip.style.top = (posy - 50) + "px";
                }
                document.getElementById("<%=lbl.ClientID%>").innerHTML = "<img src='" + value1 + "'/>";
            }
        }
        function hide() {
            var tooltip = document.getElementById("myToolTip");
            tooltip.style.visibility = "hidden";
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="myToolTip" style="position: absolute; visibility: hidden; width: 500px;
                height: 70px; padding: 17px 19px;">
                <div style="position: absolute; float: left;">
                    <asp:Label ID="lbl" runat="server"></asp:Label></b>
                </div>
            </div>
            <div id="webmangement_wrapper" style="width: 934px;">
                <div id="webmangement_rightcol" style="border-right: 0px solid grey;">
                    <div id="divAppUsagePage">
                        <div class="webmangement_rightcol_heading">
                            Sponsor Ad Click Report</div>
                        <div class="clear5">
                        </div>
                        <div>
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
                            <table cellspacing="0" cellpadding="0" width="90%" border="0" style="padding: 15px;
                                margin: 0px auto;">
                                <colgroup>
                                    <col width="290" />
                                    <col width="290" />
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
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="Start Date is mandatory.">*</asp:RequiredFieldValidator>
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
                                            OnClientClick="return ShowPieChart();" />&nbsp;&nbsp;
                                        <asp:Button ID="btnBack" Text="Back" runat="server" CausesValidation="false" OnClick="btnBack_Click" />
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
                                            <div class="label-title">
                                                <asp:Label ID="lblTitle" runat="server"></asp:Label></div>
                                            <asp:Chart ID="chartAppUsage" runat="server" BorderlineWidth="0" Height="340px" Width="600px">
                                                <Titles>
                                                    <asp:Title ShadowOffset="30" />
                                                </Titles>
                                                <Legends>
                                                    <asp:Legend Font="Microsoft Sans Serif, 10pt" Alignment="Near" Docking="Right" LegendStyle="Column">
                                                    </asp:Legend>
                                                </Legends>
                                                <Series>
                                                    <%--   <asp:Series IsVisibleInLegend="true" Name="Apple" ChartType="Column" BorderWidth="10" IsValueShownAsLabel="true"
                                                        Font="Microsoft Sans Serif, 10pt" LabelForeColor="#FFFFFF">
                                                    </asp:Series>--%>
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
