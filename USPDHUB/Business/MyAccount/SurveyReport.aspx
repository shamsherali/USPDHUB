<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="SurveyReport.aspx.cs" ValidateRequest="false" Inherits="USPDHUB.Business.MyAccount.SurveyReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <style type="text/css">
        .radius
        {
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
        }
        #manage
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        #manage .clear
        {
            clear: both;
        }
        #manage a img
        {
            border: none;
        }
        #manage h1, #manage h2, #tabber ul
        {
            margin: 0;
            padding: 0;
        }
        .Surveytext
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: Green;
            font-weight: bold;
            padding-top: 10px;
        }
        #manage h1
        {
            font-size: 18px;
            color: #EC2027;
            height: 35px;
            line-height: 35px;
        }
        #manage h2
        {
            background: #f3f3f3;
            display: block;
            padding: 5px;
            font-size: 16px;
            color: #0a59a9;
            margin-top: 10px;
            border: solid 1px #dcdcdc;
        }
        #tabber
        {
            margin-top: 27px;
        }
        #tabber .content
        {
            border: solid 1px #d5d5d5;
            padding: 6px;
        }
        #tabber .content .leftmenu
        {
            vertical-align: top;
            width: 740px;
        }
        #tabber .content .rightmenu
        {
            vertical-align: top;
            padding-left: 0px;
            width: 169px;
            float: left;
        }
        #tabber .content .rightmenu .rightLinks
        {
            width: 167px;
            padding-bottom: 1px;
        }
        #tabber .content .rightmenu .rightLinks a
        {
            display: block;
            font-size: 13px;
            color: #003c7f;
            width: 167px;
            background: url(../../images/Dashboard/side_link.gif) repeat-x;
            height: 35px;
            text-align: left;
            border: solid 1px #9abfe7;
            text-decoration: none;
            font-weight: bold;
            line-height: 35px;
        }
        #tabber .content .rightmenu .rightLinks a:hover
        {
            background: url(../../images/Dashboard/side_link_h.gif) repeat-x;
        }
        #tabber .content .rightmenu .rightLinks a span
        {
            display: block;
            float: left;
            height: 35px;
            width: 35px;
            margin-right: 13px;
        }
        #tabber .content .rightmenu .share
        {
            background: #f8fcff;
            text-align: center;
            border: solid 1px #d2e8ff;
        }
        #tabber .content .rightmenu .share img
        {
            margin: 10px;
        }
        #fullheight
        {
            height: 100%;
            text-align: center;
        }
        .cursor
        {
            cursor: hand;
        }
        .sendcontactsbutton
        {
            background: url(../../images/CreateModule.png) no-repeat;
            width: 134px;
            height: 35px;
            color: #fff;
            font-size: 16px;
            text-align: center;
            border: 0px;
            font-weight: bold;
            cursor: hand;
        }
        .navy20
        {
            width: 100px;
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
            padding: 10px 0px 5px 0px;
        }
        #boxes .window
        {
            border: solid 2px #FFCC00;
            position: absolute;
            left: 0;
            top: 0;
            width: 490px;
            height: 200px;
            display: none;
            z-index: 9999;
        }
        
        #boxes #dialog
        {
            width: 500px;
            height: 405px;
            padding: 10px;
            background-color: #FFFFFF;
            margin-top: 12%;
            margin-left: 36%;
        }
    </style>
    <script>
        function GetReportSummaryHTML() {
            document.getElementById("<%=hdnReportSummary.ClientID %>").value = document.getElementById("tblReportHTML").innerHTML;
            return true;
        }

        function TimerLoading() {
            $('#DivImageGallery').css('display', 'block');
            setTimeout(function () { $('#DivImageGallery').css('display', 'none'); }, 5 * 1000);
           
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <tbody>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: red;" align="center">
                                        <asp:Label ID="lblerrormessage" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <tbody>
                                <tr>
                                    <td>
                                        <h1>
                                            <%=hdnTabName.Value %> Summary</h1>
                                            <asp:HiddenField ID="hdnTabName" runat="server" />
                                    </td>
                                    <td style="padding-right: 70px">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td style="color: green" align="center">
                                        <asp:Label ID="lblmess" runat="server"></asp:Label>
                                        <asp:Label ID="lbleditn" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
                            <colgroup>
                                <col width="310px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td align="right">
                                </td>
                            </tr>
                            <tr>
                                <td class="content">
                                    <table id="tblReportHTML" cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top" align="center">
                                                            <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0"
                                                                style="text-align: left;">
                                                                <colgroup>
                                                                    <col width="100px;" />
                                                                    <col width="*" />
                                                                </colgroup>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <b>Survey Name:</b>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblSurveyName" runat="server" class="Surveytext"></asp:Label>
                                                                            &nbsp;&nbsp; &nbsp; <b>Expiration Date:</b>&nbsp; &nbsp;
                                                                            <asp:Label ID="lblExDate" runat="server" class="Surveytext"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display:none;">
                                                                        <td>
                                                                            <b>Total Users:</b>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblTotalFavourites" runat="server" class="Surveytext"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display:none;">
                                                                        <td>
                                                                            <b>Not Started:</b>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNew" runat="server" class="Surveytext"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <b>In Progress:</b>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblInprog" runat="server" class="Surveytext"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <b>Completed:</b>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblCompleted" runat="server" class="Surveytext"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <font style="font-size: 14px; padding-bottom: 5px; color: #ec2027; font-weight: bold;">Participants: </font>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <b>IOS:</b>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblIPhoneUsers" runat="server" class="Surveytext" Text="0"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <b>Android:</b>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblAndroidUsers" runat="server" class="Surveytext" Text="0"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <b>Windows:</b>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblWindowsUsers" runat="server" class="Surveytext" Text="0"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <asp:Chart ID="Chart1" runat="server" Width="400px">
                                                                                <Titles>
                                                                                    <asp:Title ShadowOffset="30" />
                                                                                </Titles>
                                                                                <Legends>
                                                                                    <asp:Legend Font="Microsoft Sans Serif, 10pt" Alignment="Near" Docking="Right" LegendStyle="Column">
                                                                                    </asp:Legend>
                                                                                </Legends>
                                                                                <Series>
                                                                                    <asp:Series IsVisibleInLegend="False" Name="Legend" ChartType="Pie" IsValueShownAsLabel="true"
                                                                                        Font="Microsoft Sans Serif, 10pt" LabelForeColor="#FFFFFF">
                                                                                    </asp:Series>
                                                                                </Series>
                                                                                <ChartAreas>
                                                                                    <asp:ChartArea Name="SurveyChartArea" BackColor="white">
                                                                                        <AxisY Minimum="0" LineColor="#DEDEDE" LineWidth="3">
                                                                                            <LabelStyle Format="{0:0}" />
                                                                                            <MajorGrid LineColor="White" />
                                                                                        </AxisY>
                                                                                        <AxisX LineColor="#DEDEDE" LineWidth="2">
                                                                                            <MajorGrid LineColor="White" />
                                                                                        </AxisX>
                                                                                    </asp:ChartArea>
                                                                                </ChartAreas>
                                                                            </asp:Chart>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" OnClientClick="TimerLoading();"
                                                                                Text="Generate Detailed Report" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            &nbsp;
                                                                            <div id="DivImageGallery" style="display: none;">
                                                                                <div style="text-align: center;">
                                                                                    <img src="<%=Page.ResolveClientUrl("~/Images/dashboard/ezSmartAjax.gif")%>" border="0" /><b><font
                                                                                        color="green">Processing....</font></b>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                                <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" OnClick="btnDashboard_Click"
                                                    CausesValidation="false" />&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                    CausesValidation="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnURLPath" runat="server" />
                        <asp:HiddenField ID="hdnPermissionType" runat="server" />
                        <asp:HiddenField ID="hdnReportSummary" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
