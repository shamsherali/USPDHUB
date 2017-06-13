<%@ Page Language="C#" AutoEventWireup="true" Inherits="ProfileIframes_UserActions" Codebehind="UserActions.aspx.cs" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<%@ Register Src="~/Controls/popupcontorl.ascx" TagName="POP" TagPrefix="pop1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Control</title>  
</head>
<body style="background: #FFF  top; font-family: Georgia, 'Times New Roman', Times, serif;
    font-size: 12px; padding: 0; margin: 0; color: #101010;">
    <link href="themes.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    function openwindow(url)
    {      
      window.open(url,'PrintWindow','width=700,height=424,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes');
    }
    
        function PrintContent()    {  
              var DocumentContainer = document.getElementById('<%=pnleventcalendar.ClientID %>');    
              var WindowObject = window.open('', "TrackHistoryData",  "width=740,height=325,top=200,left=250,toolbars=no,scrollbars=yes,status=no,resizable=no");    
              WindowObject.document.writeln(DocumentContainer.innerHTML);   
              WindowObject.document.close(); 
              WindowObject.focus();   
              WindowObject.print();  
              WindowObject.close(); 
                                     }
    </script>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="script1" runat="server">
        </asp:ScriptManager>        
        <asp:Panel ID="pnleventcalendar" runat="server" Class="popuptable" BorderStyle="None">
            <table width="100%" cellpadding="0" cellspacing="0" class="popup-tbl" style="padding: 5px;">
                <colgroup>
                    <col width="164px" />
                    <col width="8px" />
                    <col width="*" />
                </colgroup>
                <tr>
                    <td align="right" colspan="3">
                        <a href="javascript:PrintContent();">
                            <img src="../images/OuterImages/printlabel.gif" border="0" /></a>
                        <asp:Button ID="btnview" runat="server" OnClick="btnview_Click" class="button" /></td>
                </tr>
                <tr>
                    <td style="padding: 2px; text-align: center;">
                        <div style="padding: 5px; border: 1px solid #000;" id="tdlogo" runat="server">
                            <asp:Image ID="imglogo" runat="server" Height="75px"/></div>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td class="templateheader">
                        <asp:Label ID="lblbusinessname" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnldaypilot" runat="server" Width="100%">
                <table width="100%" cellpadding="0" cellspacing="0" class="popup-tbl" style="padding: 5px;">
                    <colgroup>
                        <col width="164px" />
                        <col width="8px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td valign="top" style="width: 150px">
                            <DayPilot:DayPilotNavigator ID="DayPilotNavigator1" runat="server" BoundDayPilotID="DayPilotMonth1"
                                SelectMode="Month" ShowMonths="3" SkipMonths="3" CssClassPrefix="navigator_silver_"
                                DataStartField="start" DataEndField="end1" VisibleRangeChangedHandling="CallBack"
                                Width="164px" OnVisibleRangeChanged="DayPilotNavigator1_VisibleRangeChanged"></DayPilot:DayPilotNavigator>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td valign="top">
                            <DayPilot:DayPilotMonth ID="DayPilotMonth1" runat="server" DataEndField="end1" DataStartField="start"
                                DataTextField="name" DataValueField="id" DataTagFields="name, id" EventClickHandling="PostBack"
                                EventClickJavaScript="alert(e.text());" ContextMenuID="DayPilotMenu1" OnEventMenuClick="DayPilotCalendar1_EventMenuClick"
                                ClientObjectName="dpm" EventMoveHandling="CallBack" OnEventMove="DayPilotMonth1_EventMove"
                                Width="100%" EventResizeHandling="CallBack" OnEventResize="DayPilotMonth1_EventResize"
                                OnTimeRangeSelected="DayPilotMonth1_TimeRangeSelected" TimeRangeSelectedHandling="CallBack"
                                OnBeforeEventRender="DayPilotMonth1_BeforeEventRender" ShowToolTip="false" EventStartTime="false"
                                EventEndTime="false" OnCommand="DayPilotMonth1_Command" CssClassPrefix="month_silver_"
                                OnBeforeCellRender="DayPilotMonth1_BeforeCellRender" OnEventClick="DayPilotMonth1_EventClick"
                                WeekStarts="Auto" EventHeight="27" ></DayPilot:DayPilotMonth>
                            &nbsp;
                            <br />
                        </td>
                    </tr>
                </table>
                <DayPilot:DayPilotBubble ID="DayPilotBubble1" runat="server" OnRenderContent="DayPilotBubble1_RenderContent"
                    ClientObjectName="bubble" UseShadow="True"></DayPilot:DayPilotBubble>
            </asp:Panel>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <colgroup>
                    <col width="164px" />
                    <col width="10px" />
                    <col width="*" />
                </colgroup>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="padding-left: 10px;">
                        <asp:Panel ID="pnllist" runat="server" Width="100%">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdevents" GridLines="None" runat="server" DataKeyNames="EventId"
                                            CssClass="templatelisttbl" AutoGenerateColumns="false" Width="100%" PageSize="5"
                                            OnPageIndexChanging="grdevents_PageIndexChanging" OnRowDataBound="grdevents_RowDataBound">
                                            <RowStyle CssClass="row1" />
                                            <AlternatingRowStyle CssClass="row2" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="text">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:Label ID="lbleventtitle" runat="server" Text='<%# Eval("EventTitle") %>' Font-Bold="true"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lbleventdate" CssClass="profilename" runat="server" Font-Size="12px"
                                                                                    ForeColor="#333333" Font-Bold="true"></asp:Label>
                                                                                <asp:Label ID="lblstartdate" CssClass="profilename" runat="server" Visible="false"
                                                                                    Text='<%# Eval("EventStartDate") %>'></asp:Label>
                                                                                <asp:Label ID="lblenddate" CssClass="profilename" runat="server" Visible="false"
                                                                                    Text='<%# Eval("EventEndDate") %>'></asp:Label>
                                                                            </td>
                                                                            <td class="template_link" align="right" style="padding-right: 3px;">
                                                                                <asp:Label ID="lblviewdetails" runat="server" Text='<%# Eval("EventId") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <strong style="font-family: Verdana; font-size: 12px;">There are no events for the current month.
                                                   </strong>
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle ForeColor="#FB7101" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0" class="popup-tbl">
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnview1" runat="server" OnClick="btnview1_Click" class="button" /></td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
