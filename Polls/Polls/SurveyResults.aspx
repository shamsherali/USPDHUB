<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyResults.aspx.cs"
    Inherits="Polls.SurveyResults" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        var rootUrl = "http://www.uspdhub.com/demopoll"; 
        //rootUrl = "http://localhost:55350";

        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var strjson = "{surveysID:'" + <%=Surveys_IDs %> + "'}";
            var options = {
                title: ''
            };
            $.ajax({
                type: "POST",
                url: rootUrl + "/SurveyResults.aspx/GetChartData",
                data: strjson,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {                
                    drawVisualization(response.d);
                },
                failure: function (response) {
                    //alert(response.d);
                },
                error: function (response) {
                    //alert(response.d);
                }
            });
        }     
        function drawVisualization(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Poll Option');
            data.addColumn('number', 'Option Answers'); 
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].PollOption, dataValues[i].TotalAnswers]);
            } 
            if(document.getElementById('<%= hdnChartType.ClientID%>').value == 'Pie')
            {
                new google.visualization.PieChart(document.getElementById('chart')).draw(data, { title: "" });
            }
            else
                new google.visualization.BarChart(document.getElementById('chart')).draw(data, { title: "",legend: 'none' });
        }      
        function countdown() 
        {
            seconds = document.getElementById("timerLabel").innerHTML;
            if(seconds == 0 || seconds == '')
                seconds = document.getElementById('<%= hdnCounter.ClientID%>').value;
            if (seconds > 0) 
            {
                document.getElementById("timerLabel").innerHTML = seconds - 1;
                setTimeout("countdown()", 1000);
            }
            else
                document.getElementById("timerLabel").innerHTML = 0;
        }
        setTimeout("countdown()", 1000);
    </script>
    <style type="text/css">
        .container
        {
            font-family: 'Source Sans Pro' ,sans-serif;
        }
        *, body
        {
            font-family: 'Source Sans Pro' ,sans-serif;
        }
        .responses
        {
            border-top: 1px solid #96C0CE;
            border-right: 1px solid #96C0CE;
            border-left: 1px solid #96C0CE;
        }
        .responses td
        {
            border-bottom: 1px solid #96C0CE;
            padding: 2px;
        }
        .responses tr:nth-child(odd) td
        {
        }
        .responses tr:nth-child(even) td
        {
            background-color: #ECEFF4;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <!------   LOGO & SETTINGS BTN  -->
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 logo">
            </div>
        </div>
        <!------   GRAPH & DASHBOARD  -->
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 dashbox1">
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 graph">
                <div style="float: right; color: #E45641; font-weight: bold;">
                    Refresh: <span id="timerLabel" runat="server">0</span>
                    <asp:HiddenField ID="hdnCounter" runat="server" />
                    <asp:HiddenField ID="hdnChartType" runat="server" Value="Bar" />
                </div>
                <div>
                    <p>
                        <asp:Label runat="server" ID="lblTitle" Font-Bold="true"></asp:Label>
                    </p>
                </div>
                <div style="clear: both;">
                </div>
                <div id="chart" style="width: 750px; height: 520px; margin: 0px auto;">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
