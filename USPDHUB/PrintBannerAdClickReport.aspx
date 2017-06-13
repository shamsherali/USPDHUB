<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintBannerAdClickReport.aspx.cs" Inherits="USPDHUB.PrintBannerAdClickReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online Banner Ad Click Report</title>
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../../Scripts/jsapi.js" language="javascript"></script>
    <script type="text/javascript">
      
        google.load('visualization', '1', { packages: ['corechart'] });
      
     </script>
</head>
<body onload="javascript:window.print();" style="background-color: #FFF;">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="30%" align="center">
        <tr>
            <td align="right">
                <a href="javascript:window.print();">
                    <img src="images/OuterImages/printlabel.gif" border="0" /></a>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-top: 10px;">
        <tr>
            <td align="center" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="25%" style="border: 0px solid gray;">
                    <tr>
                        <td valign="top" style="padding-top: 20px; text-align: left">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            <br />
                            <div style="align: left; padding-top: 10px;">
                                <asp:Label ID="lblTotalCount" runat="server"></asp:Label></div>
                            <asp:Chart ID="chartAppUsage" runat="server" BorderlineWidth="0" Height="340px" Width="600px">
                                <Titles>
                                    <asp:Title ShadowOffset="30" />
                                </Titles>
                                <Legends>
                                    <asp:Legend Font="Microsoft Sans Serif, 10pt" Alignment="Near" Docking="Right" LegendStyle="Column">
                                    </asp:Legend>
                                </Legends>
                                <Series>
                                    <%--<asp:Series IsVisibleInLegend="true" Name="Legend" ChartType="Pie" IsValueShownAsLabel="true"
                                        Font="Microsoft Sans Serif, 10pt" LabelForeColor="#FFFFFF">
                                    </asp:Series>--%>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="UsageChartArea" BackColor="white">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
