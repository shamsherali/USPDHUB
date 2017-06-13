<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyReport2.aspx.cs"
    Inherits="Polls.SurveyReport2" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <%--<meta http-equiv="refresh" content="10">--%>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://use.fontawesome.com/90e3582566.js"></script>
</head>
<body>
    <style>
        .logo img
        {
            width: 25%;
            height: auto;
            margin: 1% 0;
        }
        
        .settings
        {
            padding: 3% 0 0 40%;
        }
        
        .graph img
        {
            width: 40%;
            height: auto;
            margin: 0 30%;
        }
        .graph img
        {
            width: 30%;
            height: auto;
            margin: 2% 15%;
        }
        
        .graph p
        {
            text-align: left;
            margin: 2% 0 0 0;
            font-weight: 600;
        }
        
        .dashbox1
        {
            border: 1px solid #000;
            border-radius: 3px;
            margin-top: 5%;
        }
        
        .dashboard p
        {
            font-weight: 600;
            text-align: left;
            font-size: 120%;
            margin: 5px 0;
        }
        
        .dashboard h4
        {
            font-weight: 600;
            text-align: left;
            font-size: 120%;
            margin: 5px 0;
        }
        
        
        .dashboard h5
        {
            font-weight: 600;
            text-align: left;
            font-size: 120%;
            margin: 5% 0;
        }
        
        .dashbox2
        {
            border: 1px solid #000;
            border-radius: 3px;
            margin-top: 2%;
        }
        .responses
        {
            border-top:1px solid #96C0CE;
            border-right:1px solid #96C0CE;
            border-left:1px solid #96C0CE;
        }
        .responses td
        {
            border-bottom:1px solid #96C0CE;
            padding:2px;
        }
        .responses tr:nth-child(odd) td
        {
        }
        .responses tr:nth-child(even) td
        {
            background-color:#96C0CE;
        }
    </style>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="30000" Enabled="True">
    </asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <div class="container">
                <!------   LOGO & SETTINGS BTN  -->
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 logo">
                    </div>
                </div>
                <!------   GRAPH & DASHBOARD  -->
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 dashbox2">
                    <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 graph">
                        <p>
                            <asp:Label runat="server" ID="lblTitle2"></asp:Label></p>
                        <asp:Chart ID="chartAppUsage" runat="server" BorderlineWidth="0" Height="600px" Width="800px">
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Right" IsTextAutoFit="False" Name="Default" />
                            </Legends>
                            <ChartAreas>
                                <asp:ChartArea Name="UsageChartArea" BackColor="white">
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 dashboard">
                        <p>
                            Total Participants:
                            <asp:Label runat="server" ID="lblCount2"></asp:Label></p>
                        <asp:Literal runat="server" ID="literal2"></asp:Literal>
                    </div>
                </div>
                <!------   GRAPH & DASHBOARD  -->
                <br>
                <br>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
