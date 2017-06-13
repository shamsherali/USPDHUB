<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPSCMessageChart.aspx.cs"
    Inherits="USPDHUB.PrintPSCMessageChart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>&nbsp; </title>
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../../Scripts/jsapi.js" language="javascript"></script>
    <script type="text/javascript">

        google.load('visualization', '1', { packages: ['corechart'] });
      
    </script>
    <style type="text/css">
        .chart-one-pie
        {
            width: 900px;
            height: 550px;
            margin: 0px auto;
        }
        @media print
        {
            #printbtn
            {
                display: none;
            }
        }
    </style>
</head>
<body onload="javascript:window.print();" style="background-color: #FFF; font-family: Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="30%" align="center">
        <tr>
            <td align="right">
                <a id="printbtn" href="javascript:window.print();">
                    <img src="images/OuterImages/printlabel.gif" border="0" /></a>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-top: 10px;">
        <tr>
            <td align="center" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="70%" style="border: 0px solid gray;">
                    <tr>
                        <td colspan="2" style="text-align: center; font-weight: bold;">
                            Private QR Connect Messages Chart
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; font-weight: bold;">
                            Total Messages -
                            <asp:Label ID="lblTotalCount" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="padding-top: 20px; text-align: left">
                            <div class="app-chart chart-one-pie">
                                <asp:Chart ID="chartAppUsage" runat="server" BorderlineWidth="0" Height="550px" Width="900px">
                                    <%--<Legends>
                                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                            Font="Microsoft Sans Serif, 10pt" LegendStyle="Table" />
                                    </Legends>--%>
                                    <ChartAreas>
                                        <asp:ChartArea Name="UsageChartArea" BackColor="white">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
