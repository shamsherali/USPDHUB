<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="SendAppNotifications.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.SendAppNotifications" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <style type="text/css">
        .displaynone
        {
            display: none;
        }
        .navy20
        {
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
            padding: 10px 0px 5px 0px;
            width: 100px;
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
        #manage h1
        {
            font-size: 18px;
            color: #EC2027;
            height: 35px;
            line-height: 35px;
            padding-left: 5px;
        }
        #manage h2
        {
            background: #f3f3f3;
            display: block;
            padding: 5px;
            font-size: 16px;
            color: #0a59a9;
            border: solid 1px #dcdcdc;
            margin-top: 10px;
        }
        #tabber
        {
            margin-top: 27px;
        }
        #tabber .content
        {
            background: #f3f3f3;
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
            background: url(../../images/Dashboard/CreateModule.png) no-repeat;
            width: 134px;
            height: 35px;
            color: #fff;
            font-size: 16px;
            text-align: center;
            border: 0px;
            font-weight: bold;
            cursor: hand;
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
        .btn-send
        {
            background: #3c83d7;
            border-radius: 5px;
            padding: 8px 15px;
            color: #fff;
            font-size: 14px;
            text-decoration: none;
        }
        .btn-cancel
        {
            background: #f15a29;
            border-radius: 5px;
            padding: 8px 15px;
            color: #fff;
            font-size: 14px;
            text-decoration: none;
        }
        .smstxtfildwrapdsh
        {
            float: left;
            font-weight: normal;
            font-size: 16px;
        }
        #ctl00_cphUser_lblbulletinthumb img
        {
            width: 150px;
        }
        input[disabled]
        {
            cursor: not-allowed;
        }
    </style>
    <script type="text/javascript">

        function RadioCheck(rb, NotificationID) {

            RadioCheched = "True";
            var gv = document.getElementById("<%=NotificationGrid.ClientID%>");
            var rbs = gv.getElementsByTagName("input");
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }
        $(function () {

            $('#chkSMS').change(function () {

                if ($('#chkSMS').is(':checked'))
                    $("#divSMS").fadeIn();
                else
                    $('#divSMS').fadeOut();
            });
        }); 

    </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <tbody>
                                <tr>
                                    <td>
                                        <h1>
                                            <div style="float: left;">
                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                <%if (Convert.ToBoolean(hdnIsLiteVersion.Value))
                                                  { %>
                                                <a href="javascript:ModalHelpPopup('Send Notifications',373,'');">
                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" style="border: 0px;" /></a>
                                                <%}
                                                  else
                                                  { %>
                                                <a href="javascript:ModalHelpPopup('Send Notifications',158,'');">
                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" style="border: 0px;" /></a>
                                                <%} %>
                                            </div>
                                            <span style="color: Black; font-size: 14px; margin: 0px; padding: 0px; float: right;
                                                margin-right: 10px;">
                                                <asp:Label runat="server" ID="lblOn" Visible="false">Displayed on App: <font class="showonapp">On</font></asp:Label>
                                                <asp:Label runat="server" ID="lblOff" Visible="false">Displayed on App: <font class="showoffapp">Off</font></asp:Label>
                                            </span>
                                    </td>
                                    <td align="center" class="navy20" valign="top">
                                        &nbsp;<asp:HiddenField ID="hdnCommandArg" runat="server" />
                                        <asp:HiddenField ID="hdnIsSMS" runat="server" Value="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <%if (Convert.ToBoolean(hdnIsPrivate.Value))
                                                      { %>
                                                    <span style="font-weight: bold; font-size: 14px; margin-left: 50px;">Private Module</span><br />
                                                    <%}
                                                      else
                                                      {%>&nbsp;
                                                    <%} %>
                                                </td>
                                                <td style="text-align: right; padding-right: 35%;">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div id="sendnotification_content">
                            <div id="divSendNotificationsPage">
                                <div class="clear5">
                                </div>
                                <div>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSuccess" runat="server" Style="font-weight: bold; font-size: 16px;
                                                    text-align: center; padding-left: 150px;"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div>
                                        <%--<span style="padding-left: 5px; font-size: 13px;"><b>Note: </b>Please do not enter &
                                            and < characters.</span>--%>
                                    </div>
                                    <asp:Panel runat="server" ID="pnlPsuh" Visible="false">
                                        <div style="padding-left: 5px;">
                                            <asp:CheckBox ID="chkPush" runat="server" Checked="true" />
                                            <span style="font-size: 14px; font-weight: bold;">Include Push Notification</span>
                                        </div>
                                        <div style="padding-left: 5px;">
                                            <asp:CheckBox ID="chkPrepop" runat="server" Checked="true" OnCheckedChanged="chkPrepop_CheckedChanged"
                                                AutoPostBack="true" />
                                            <span style="font-size: 14px; font-weight: bold;">Prepopulate app name</span>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <table cellpadding="0" cellspacing="8">
                                        <tr>
                                            <td>
                                                <font color="red">&nbsp;*</font>Notification:
                                                <asp:TextBox ID="txtNoticication" runat="server" MaxLength="250" Width="370" Height="50"
                                                    TextMode="MultiLine" onkeyup="CountMaxLength(this,'Message',event);" onChange="CountMaxLength(this,'Notification',event);"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="REFVMessage" runat="server" Font-Size="Small" ControlToValidate="txtNoticication" ValidationGroup="myValidator" ErrorMessage="Notification is mandatory."></asp:RequiredFieldValidator>--%>
                                                <div style="margin-left: 467px; margin-top: -107px; position: absolute;">
                                                    <asp:Label ID="lblbulletinthumb" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <span style="margin-left: 92px;">You have
                                        <asp:Label ID="lblLength" runat="server"></asp:Label>
                                        characters left.</span><span style="margin-left: 50px;">(Max Characters 250)</span>
                                    <br />
                                    <br />
                                    <asp:Panel runat="server" ID="pnlSMS" Visible="false">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <div>
                                                        <asp:CheckBox ID="chkSMS" runat="server" OnCheckedChanged="chkSMS_CheckedChanged"
                                                            AutoPostBack="true" /><font size="3"><b> Include Send SMS (Text)</b></font>
                                                    </div>
                                                    <asp:Label ID="lblSMSExceed" runat="server"></asp:Label>
                                                    &nbsp;&nbsp;<asp:LinkButton ID="lnkBuyMoreSMS" runat="server" Text="Buy More" OnClick="lnkBuyMore_Click"
                                                        CausesValidation="false" Style="color: #ff8d31; font-weight: bold; float: right;
                                                        margin-right: 105px; display: none;"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel runat="server" ID="pnlSMSGroups" Visible="false">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div style="margin-left: 25px;" class="smstxtfildwrapdsh">
                                                                        <strong>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <font color="green">Sent</font> :
                                                                                        <asp:Label ID="lblSMSCount" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <%if ((Convert.ToBoolean(hdnIsLiteVersion.Value) && Session["VerticalDomain"].ToString().ToLower().Equals("inschoolalertcom")) || (Convert.ToBoolean(Session["isLiteVersion"]) == true))
                                                                                      { %>
                                                                                    <td>
                                                                                        <%}
                                                                                      else
                                                                                      {%>
                                                                                        <td>
                                                                                            <%if (IsScheduledPushNotification)
                                                                                              { %>
                                                                                            &nbsp;&nbsp;&nbsp; <font color="green">Scheduled</font> :
                                                                                            <asp:Label ID="lblScheduleCount" runat="server"></asp:Label>
                                                                                            <%}%>
                                                                                            <%} %>
                                                                                        </td>
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;&nbsp;&nbsp; <font color="green">Remaining</font> :
                                                                                        <asp:Label ID="lblRemainingCount" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;&nbsp;<asp:LinkButton ID="lnkBuyMore" runat="server" Text="Buy More" OnClick="lnkBuyMore_Click"
                                                                                            CausesValidation="false" Style="color: #ff8d31; font-weight: bold;"></asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </strong>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="margin-left: 25px;">
                                                                        <div style="display: none;">
                                                                            *Note : Please select 1 or more contacts within your chosen group(s).
                                                                            <br />
                                                                            <asp:CheckBox ID="chkGroups" runat="server" Text="All Groups" AutoPostBack="true"
                                                                                OnCheckedChanged="chkGroups_CheckedChanged" Style="font-size: 12px;" Visible="false" />
                                                                            <br />
                                                                            <asp:CheckBoxList ID="chkGroupList" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"
                                                                                AutoPostBack="true" OnSelectedIndexChanged="chkGroupList_SelectedIndexChanged">
                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                        <div>
                                                                            <asp:Label runat="server" ID="lblcontacts">SMS Opt-In (<asp:LinkButton runat="server"
                                                                                ID="lblSMSOptinCount" OnClick="lnkViewContacts_OnClick">0 - View</asp:LinkButton>)
                                                                            </asp:Label>
                                                                        </div>
                                                                        <div style="min-height: 50px; max-height: 200px; overflow: auto; display: none;">
                                                                            <%--contacts grid controls goes here--%>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="tdlblmsg" runat="server" visible="false">
                                                                    <asp:Label ID="Lblmsg" runat="server" Visible="False"></asp:Label><font color="red">
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; you have selected more than remainig messages</font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <div style="margin-left: 70px;">
                                        <% if (((Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "") || hdnPermissionType.Value == "P") && (Convert.ToBoolean(hdnIsPrivate.Value) == false && Convert.ToBoolean(Session["IsLiteVersion"]) == false))
                                           { %>
                                        <asp:CheckBox ID="chkFbAutoPost" runat="server" Text="Auto post on facebook" Style="font-size: 12px;
                                            padding-left: 4px;" /><br />
                                        <asp:CheckBox ID="chkTwrAutoPost" runat="server" Text="Auto post on twitter" Style="font-size: 12px;
                                            padding-left: 4px;" />
                                        <br />
                                        <%} %>
                                        <%if (!IsScheduledPushNotification)
                                          { %>
                                        <div>
                                        </div>
                                        <%}
                                          else
                                          {%>
                                        <div>
                                            <div style="">
                                                <asp:RadioButton ID="rbSendNow" Checked="true" runat="server" OnClick="ChangeSchedule('0');"
                                                    GroupName="Send" />&nbsp;<b>Send Now</b> &nbsp;&nbsp;<asp:RadioButton ID="rbSchedule"
                                                        runat="server" OnClick="ChangeSchedule('1');" GroupName="Send" />&nbsp;<b>Schedule On</b>
                                            </div>
                                            <div style="margin-top: 5px; margin-left: 115px; display: none;" id="divSendDate">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="padding-top: 2px; padding-right: 5px;">
                                                            <asp:TextBox ID="txtSendingDate" runat="server" ValidationGroup="Send"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtSendingDate"
                                                                Display="Dynamic" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                SetFocusOnError="True" ErrorMessage="Invalid Date Format" ValidationGroup="group"></asp:RegularExpressionValidator>
                                                            <br />
                                                            <b>(MM/DD/YYYY)</b>
                                                            <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtSendingDate"
                                                                Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                        </td>
                                                        <td valign="top">
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox runat="server" ID="txtStrHours" Width="50px" MaxLength="2"></asp:TextBox>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtStrHours"
                                                                            WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                                            ControlToValidate="txtStrHours" ValidationExpression="^(1[0-2]|0[1-9]|[0-9])$"
                                                                            ValidationGroup="group" ErrorMessage="Invalid Start Time">*</asp:RegularExpressionValidator>
                                                                        <asp:TextBox runat="server" ID="txtStrMins" Width="50px" MaxLength="2"></asp:TextBox>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtStrMins"
                                                                            WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic"
                                                                            ControlToValidate="txtStrMins" ValidationExpression="^([0-5][0-9]|[0-9])$" ValidationGroup="group"
                                                                            ErrorMessage="Invalid Start Time">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td valign="top" style="padding: 1px;">
                                                                        <asp:DropDownList runat="server" ID="ddlStrAPM" Width="60px" Height="23px">
                                                                            <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <%}%>
                                    </div>
                                    <br />
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr align="center">
                                            <td align="center" style="padding-left: 250px;">
                                                <asp:LinkButton ID="lnkSend" runat="server" OnClick="btnSend_Click" OnClientClick="return CheckNotification();"
                                                    ValidationGroup="group" CssClass="btn-send"> Send </asp:LinkButton>&nbsp;&nbsp;
                                                <asp:LinkButton ID="lnkCancel" runat="server" OnClick="lnkCancel_Click" CausesValidation="false"
                                                    CssClass="btn-cancel"> Cancel </asp:LinkButton>
                                                <asp:HiddenField ID="hdbProfileName" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <table style="font-size: 16px;">
                            <tr>
                                <td>
                                    <img src="../../images/TextSMS_15x15.png" />
                                    : SMS (Text)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="../../images/PushNotification_15x15.png" />
                                    : Push Notification
                                </td>
                            </tr>
                        </table>
                        <%if (Convert.ToBoolean(hdnIsPrivate.Value) == false)
                          { %>
                        <%if (!Convert.ToBoolean(hdnIsLiteVersion.Value))
                          { %>
                        <asp:Panel ID="pnlShareSocial" runat="server">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="padding-bottom: 10px;">
                                <tr>
                                    <td class="share" align="right">
                                        <span style="font-weight: bold; color: Green; font-size: 14px;">Share On: </span>
                                    </td>
                                    <td style="width: 50px;">
                                        <% if
                        (hdnCommandArg.Value != "")
                                           { %>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <%--<asp:Label ID="lblFacebookSharePage" runat="server"></asp:Label>--%>
                                                    <asp:LinkButton ID="lnkShareBtn" runat="server" OnClick="lnkShareBtn_Click" CausesValidation="false"
                                                        OnClientClick="return ValidateCustomModuleMutipleSelection('Facebook');"> <img src="../../images/Dashboard/facebook.png"
                        alt="Share on Facebook Page" title="Share on Facebook Page" border="0" /> </asp:LinkButton>
                                                </td>
                                                <td>
                                                    <%--<asp:Label ID="lblTwitterShare" runat="server"></asp:Label>--%>
                                                    <asp:LinkButton ID="lnkTwrShare" runat="server" OnClick="lnkTwrShare_Click" CausesValidation="false"
                                                        OnClientClick="return ValidateCustomModuleMutipleSelection('Twitter');"> <img src="../../images/Dashboard/twitter.png"
                        alt="Share on Twitter" title="Share on Twitter" border="0" /> </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                        <%}
                                           else
                                           {%>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <a class="cursor" onclick="alert('Please select a notification.');">
                                                        <img src='<%=Page.ResolveClientUrl("~/images/Dashboard/facebook.png")%>' alt='Share on
                        Facebook' title='Share on Facebook' border='0' /></a>
                                                </td>
                                                <td>
                                                    <a class="cursor" onclick="alert('Please select a notification.');">
                                                        <img src='<%=Page.ResolveClientUrl("~/images/Dashboard/twitter.png")%>' alt='Share on Twitter'
                                                            title='Share on Twitter' border='0' /></a>
                                                </td>
                                            </tr>
                                        </table>
                                        <%}%>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <%} %>
                        <%} %>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="content">
                                    <div>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="valign-top">
                                            <tr>
                                                <td valign="top" align="center">
                                                    <asp:GridView ID="NotificationGrid" runat="server" AutoGenerateColumns="False" PageSize="25"
                                                        AllowSorting="true" Width="100%" ForeColor="Black" CssClass="datagrid2" AllowPaging="True"
                                                        OnPageIndexChanging="NotificationGrid_PageIndexChanging" OnRowCommand="NotificationGrid_RowCommand"
                                                        OnRowDeleting="NotificationGrid_RowDeleting" OnSorting="NotificationGrid_Sorting"
                                                        OnRowDataBound="NotificationGrid_RowDataBound">
                                                        <Columns>
                                                            <asp:BoundField DataField="PushNotifyID" Visible="false">
                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Select">
                                                                <ItemTemplate>
                                                                    <asp:RadioButton ID="rbNotification" runat="server" AutoPostBack="true" OnCheckedChanged="rbNotificationCheckedChanged"
                                                                        onclick='<%#
                        string.Format("javascript:RadioCheck(this, \"{0}\")", Eval("PushNotifyID")) %>' />
                                                                    <asp:Label ID="lblCommand" runat="server" Text='<%#Eval("PushNotifyID") %>' Style="display: none;"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="20px"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Notification">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTitle" runat="server" CssClass='<%#Eval("Alert_Type") %>' Text='<%# Eval("Message") %>'></asp:Label>
                                                                    <asp:Label ID="lblImage" runat="server" Text='<%# Eval("MessageType") %>'></asp:Label>
                                                                    <br></br>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="400px"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Created_Date" HeaderText="Created Date" SortExpression="CreatedDate"
                                                                DataFormatString="{0:MM/dd/yyyy hh:mm tt}">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <HeaderStyle Width="200px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Username" HeaderText="Created By">
                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                <ItemStyle Width="150px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Status" SortExpression="CampaignStatus">
                                                                <ItemTemplate>
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="border: 0px;" valign="top" nowrap="nowrap">
                                                                                <asp:Label ID="lblcam" runat="server" Text='<%# Bind("NotificationStatus") %>' Visible='<%#
                        Convert.ToInt32(Eval("Sent_Flag"))==0?false:true %>'></asp:Label>
                                                                                <asp:LinkButton Style="font-weight: bold; color: blue; font-family: verdana; color: #0b689d;"
                                                                                    ToolTip="Click
                        to Cancel" ID="lnkruncampaion" runat="server" CausesValidation="false" Text='<%#
                        Bind("NotificationStatus") %>' CommandArgument='<%# Bind("PushNotifyID") %>' Visible='<%#Convert.ToInt32(Eval("Sent_Flag"))==0?true:false
                        %>' CommandName="History"></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="70px" />
                                                                <ItemStyle Width="100px"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="btnDelete" CommandName="Delete" CausesValidation="false"
                                                                        Style="cursor: pointer;" ToolTip="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PushNotifyID")
                        %>' OnClientClick="return confirm('Are you sure you want to delete this notification?');">
                        <img src="../../Images/Dashboard/icon_delete.gif" /> </asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Profile_ID" Visible="false">
                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="title3" />
                                                        <EmptyDataTemplate>
                                                            <span style="color: #c00000;">No Data Found</span>
                                                        </EmptyDataTemplate>
                                                        <EmptyDataRowStyle ForeColor="#e8e8e8" />
                                                        <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                    </asp:GridView>
                                                </td>
                                                <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnFacebookAppId" runat="server" />
                                                <asp:HiddenField ID="hdnMessageDes" runat="server" />
                                                <asp:HiddenField ID="hdnLinkShareFB" runat="server" />
                                                <asp:HiddenField ID="hdnRedirectUrl" runat="server" />
                                                <asp:HiddenField ID="hdnFacebook" runat="server" />
                                                <asp:HiddenField ID="hdnTwitter" runat="server" />
                                                <asp:HiddenField ID="hdnMessageType" runat="server" />
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblProgress" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="MPEProgress" runat="server" TargetControlID="lblProgress"
                                PopupControlID="pnlProgress" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none;" ID="pnlProgress" runat="server" Width="500px">
                                <table class="modalpopup" cellspacing="0" cellpadding="0" width="100%" align="center"
                                    border="0">
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Your
                                                        notification send is in progress....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFbPages" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="mpeFbPages" runat="server" TargetControlID="lblFbPages"
                                PopupControlID="pnlFbPages" BackgroundCssClass="modal" CancelControlID="imgPopupClosed">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none;" ID="pnlFbPages" runat="server" Width="500px">
                                <table class="modalpopup border_PopupFb" cellspacing="0" cellpadding="0" width="100%"
                                    align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress10" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 05px; padding-top: 05px" align="right">
                                                <asp:ImageButton ID="imgPopupClosed" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif">
                                                </asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; padding-bottom: 10px; color: #0917B1; padding-top: 10px"
                                                align="left">
                                                Select your page to share :
                                                <%--<select id="thebox" class="FbPagesList">
                                                </select>--%>
                                                <asp:DropDownList ID="ddlFbPagesList" class="FbPagesList" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px; padding-bottom: 20px" align="center">
                                                <asp:Button ID="btnShareOnPage" runat="server" class="FBpopupBtn" Text="Post Data"
                                                    OnClick="btnShareOnPage_Click" />
                                                <%--onclick="ShareOnPage()"--%>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblviewc" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="lblviewc"
                                PopupControlID="pnlviewcouponsenthis" BackgroundCssClass="modal" CancelControlID="imglogin2">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlviewcouponsenthis" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="600" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="header">
                                                                History
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin2" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 10px;">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <b>Sending Date:</b>
                                                                <asp:Label ID="lblSendDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-top: 10px;">
                                                                <b>Message:</b>
                                                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-top: 10px;">
                                                                <asp:HiddenField ID="hdnSchNotifyID" runat="server" />
                                                                <asp:Button ID="btnSchCancel" runat="server" Text="Cancel Schedule" OnClick="btnSchCancel_Click"
                                                                    OnClientClick="return confirm('Are you sure you want to cancel this?')" CausesValidation="false" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblContacts1" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="modalContacts" runat="server" TargetControlID="lblContacts1"
                                PopupControlID="pnlContact1" BackgroundCssClass="modal" CancelControlID="imglogin2">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlContact1" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="600" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="header">
                                                                Contacts
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 10px;">
                                                <asp:GridView ID="GVContacts" runat="server" AutoGenerateColumns="False" Width="80%"
                                                    ForeColor="#333333" CssClass="datagrid2" AllowPaging="True" OnPageIndexChanging="GVContacts_PageIndexChanging"
                                                    CellPadding="4" GridLines="None" DataKeyNames="ContactID">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="displaynone" ItemStyle-CssClass="displaynone"
                                                            ItemStyle-Width="1px">
                                                            <HeaderTemplate>
                                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/emailarrow.gif")%>" width="17px"
                                                                    height="8" border="0" /><asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true"
                                                                        OnCheckedChanged="chkSelectAll_CheckedChanged" Checked="true"></asp:CheckBox>Select
                                                                All
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="cbSelect" runat="server" Checked='<%#Eval("CheckFlag")%>' AutoPostBack="true"
                                                                    OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("ContactName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mobile Number">
                                                            <ItemTemplate>
                                                                <itemstyle />
                                                                <asp:Literal ID="MobileNumber" runat="server" Text='<%#Eval("Mobile")%>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGroupID" runat="server" Text='<%#Eval("Contact_Group_Name")%>'></asp:Label>
                                                                <asp:Label ID="lblCheckFlag" runat="server" Text='<%#Eval("CheckFlag")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="title3" />
                                                    <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                    <EmptyDataTemplate>
                                                        <span style="padding-left: 5px;">No contacts found </span>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
            <asp:HiddenField ID="hdnUserDate" runat="server" />
            <asp:HiddenField ID="hdnIsPrivate" runat="server" Value="false" />
            <asp:HiddenField ID="hdnIsLiteVersion" runat="server" Value="false" />
            <asp:HiddenField ID="hdnPrePopulate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            //to show the initial number of characters left
            $("#ctl00_cphUser_txtNoticication").focus();
            var initialContent = $("#ctl00_cphUser_txtNoticication").val();

            if (initialContent.toLowerCase().indexOf('auburn') != -1) {
                var profilename = $("#ctl00_cphUser_hdbProfileName").val();
                initialContent = initialContent.replace(profilename + ' - ', '');
            }
            $("#ctl00_cphUser_txtNoticication").val('');
            $("#ctl00_cphUser_txtNoticication").val(initialContent);
            CountMaxLength(document.getElementById('<%=txtNoticication.ClientID %>'), 'Notification');
            GetCurrentDate();
        });
        window.onload = function () {

            //to show the initial number of characters left
            $("#ctl00_cphUser_txtNoticication").focus();
            var initialContent = $("#ctl00_cphUser_txtNoticication").val();

            if (initialContent.toLower().indexOff('auburn') != -1) {
                var profilename = $("#ctl00_cphUser_hdbProfileName").val();
                initialContent = initialContent.replace(profilename + ' - ', '');
            }
            $("#ctl00_cphUser_txtNoticication").val('');
            $("#ctl00_cphUser_txtNoticication").val(initialContent);
            CountMaxLength(document.getElementById('<%=txtNoticication.ClientID %>'), 'Notification');
            GetCurrentDate();
        }
        function GetCurrentDate() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/GetUserTimeZoneDashboard",
                dataType: "json",
                success: function (response) {
                    currentTime = new Date(response.d);
                    //var dformat = [(currentTime.getMonth() + 1).padLeft(), currentTime.getDate().padLeft(), currentTime.getFullYear()].join('/');
                    document.getElementById('<%= hdnUserDate.ClientID%>').value = currentTime;
                    setTimeout(GetCurrentDate, 60000); //Then set it to run again after 6 seconds
                }
            });
        }
        function CountMaxLength(id, text, e) {
            var maxlength = 250;
            var myRegExp = new RegExp(/^[^<&]+$/);   //(/^[a-zA-Z0-9\-\.\'\,]+$/);            
            if (myRegExp.test(id.value)) {
                if (id.value.length > maxlength) {
                    id.value = id.value.substring(0, maxlength);
                    alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
                }
                document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;
                //alert(document.getElementById("ctl00_cphUser_txtNoticication"));    
                return true;
            }
            else {
                if (e != undefined && (e.keyCode == 8 || e.keyCode == 46)) {
                    //
                }
                else {
                    if (document.getElementById('<%=txtNoticication.ClientID %>').value != '') {
                        document.getElementById('<%=txtNoticication.ClientID %>').value = id.value.replace(/[&<]/g, '')
                        alert("Please do not enter & and < characters.");
                        return false;
                    }
                }
            }
        }
        function CheckNotification() {
            var returnvalue = false;
            if (Page_ClientValidate('group') && Page_IsValid) {
                var notification = $("#ctl00_cphUser_txtNoticication").val().trim();
                var notification = notification.substring(0, notification.length - 1).trim();
                var profilename = $("#ctl00_cphUser_hdbProfileName").val();
                if (notification != "" && notification != null) {
                    if (notification == profilename) {
                        alert('Please enter your notification.');
                        $("#ctl00_cphUser_txtNoticication").focus();
                    }
                    else {
                        var allowNotification = 'Please select push notification to send notification.';
                        if (document.getElementById('<%=chkPush.ClientID %>') != null) {
                            if (document.getElementById('<%=chkPush.ClientID %>').checked)
                                returnvalue = true;
                            else if (document.getElementById('<%=chkSMS.ClientID %>') != null) {
                                if (document.getElementById('<%=chkSMS.ClientID %>').checked)
                                    returnvalue = true;
                                else
                                    allowNotification = 'Please select either push notification or SMS to send notification.';
                            }
                            if (returnvalue == false)
                                alert(allowNotification);
                        }
                        else
                            returnvalue = true;
                    }
                }
                else {
                    alert("Notification is mandatory.");
                    return false;
                }

                if (document.getElementById("<%=chkSMS.ClientID %>").checked == true && document.getElementById("<%=lblSMSOptinCount.ClientID %>").innerHTML == "0 - View") {
                    returnvalue = false;
                    alert("You don't have any contact number(s) to send messages.");
                    return false;
                }

                if (returnvalue) {
                    returnvalue = ValidateSchedule();
                }




                if (returnvalue) {
                    $find("<%=MPEProgress.ClientID %>").show();
                    document.getElementById("<%=lnkSend.ClientID %>").style.display = 'none';
                }
            }
            return returnvalue;
        }
        function ValidateSchedule() {
            var datemsg = "";
            if (document.getElementById("<%=rbSchedule.ClientID %>").checked) {
                var date = document.getElementById('<%= txtSendingDate.ClientID%>').value;
                var strHours = document.getElementById('<%= txtStrHours.ClientID%>').value;
                if (strHours == "Hour")
                    strHours = "";
                var strMins = document.getElementById('<%= txtStrMins.ClientID%>').value;
                if (strMins == "Minutes")
                    strMins = "";
                if (date != "" && strHours != "" && strMins != "") {
                    var tt = document.getElementById('<%= ddlStrAPM.ClientID%>').value;
                    if (parseInt(strHours) < 0 || parseInt(strHours) > 12)
                        datemsg = "Hours should be between 1 - 12.\n\r";
                    if (parseInt(strMins) < 0 || parseInt(strMins) > 59)
                        datemsg = datemsg + "Minutes should be between 0 - 59.\n\r";
                    if (datemsg == "") {
                        if (tt == "PM") {
                            if (parseInt(strHours) != 0 && parseInt(strHours) != 12)
                                strHours = parseInt(strHours) + 12;
                        }
                        var datearray = date.split("/");
                        var scheduledate = new Date(datearray[2], datearray[0] - 1, datearray[1], parseInt(strHours), parseInt(strMins), 0, 0);
                        var currentDateTime = new Date(document.getElementById('<%= hdnUserDate.ClientID%>').value);
                        if (scheduledate < currentDateTime)
                            datemsg = "Schedule date and time should be later than current date and time.";
                    }
                }
                else
                    datemsg = "Schedule date and timings are mandatory.";
            }
            if (datemsg == "")
                return true;
            else {
                alert(datemsg);
                return false;
            }
        }

        window.fbAsyncInit = function () {
            FB.init({
                appId: document.getElementById("<%=hdnFacebookAppId.ClientID%>").value,
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true, // parse XFBML
                oauth: true // Enable oauth authentication
            });
        };
        function post_on_page() {
            FB.login(function (response) {
                if (response.authResponse) {
                    var uid = response.authResponse.userID;
                    var accessToken = response.authResponse.accessToken;
                    FB.api(
                    {
                        method: 'fql.query',
                        query: 'SELECT page_id, name, page_url FROM page WHERE page_id IN (SELECT page_id FROM page_admin WHERE uid=' + uid + ')'
                    },
                    function (data) {
                        var ids = new Array();
                        var names = document.getElementById("thebox");
                        if (data.length > 0) {
                            document.getElementById("thebox").options.length = 0;
                            for (var i = 0; i < data.length; i++) {
                                ids[i] = data[i].page_id;
                                var opt = document.createElement("option");
                                document.getElementById("thebox").options.add(opt);
                                opt.text = data[i].name;
                                opt.value = ids[i];
                            }
                            $find('<%=mpeFbPages.ClientID%>').show();
                        }
                        else
                            alert("There are no pages in your account");
                    });

                }
                else {
                    // *** show message for not logged in *** //
                }
            }, { scope: 'publish_stream, manage_pages' });
        }
        function ShareOnPage() {
            $find('<%=mpeFbPages.ClientID%>').hide();
            var msg = document.getElementById("<%=hdnMessageDes.ClientID%>").value;
            var ShareLink = document.getElementById("<%=hdnLinkShareFB.ClientID%>").value;
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    var select = document.getElementById("thebox");
                    var page_id = select.options[select.selectedIndex].value;
                    FB.api('/' + page_id + '/feed', 'POST',
                            {
                                'message': msg,
                                'link': ShareLink
                            },
                            function (response) {
                                if (response && !response.error)
                                    alert("Notification has been posted successfully.");
                                else
                                    alert('Facebook server is not responding. Please try again later.'); //Posting has been failed. Please Call us at 1-800-281-0263 Monday - Friday 8 a.m. - 5 p.m. PST');
                            }
                     );
                }
            });
        }
    </script>
    <div id="fb-root">
    </div>
    <script type="text/javascript">
        (function () {
            var e = document.createElement('script');
            // replacing with an older version until FB fixes the cancel-login bug
            e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
            //e.src = 'scripts/all.js';
            e.async = true;
            document.getElementById('fb-root').appendChild(e);
        } ());

        function ChangeSchedule(type) {
            if (document.getElementById("divSendDate") != null) {
                document.getElementById("divSendDate").style.display = "none";
                if (type == '1') {
                    document.getElementById("divSendDate").style.display = "block";
                }
            }
        }
        function ValidateCustomModuleMutipleSelection(shareType) {
            var facebook = document.getElementById("<%=hdnFacebook.ClientID %>").value;
            var twitter = document.getElementById("<%=hdnTwitter.ClientID %>").value;
            var errMsg = "";
            if (facebook == "false" && shareType == 'Facebook')
                errMsg += "This title has already been shared to facebook. Are you sure you want to share it again?\n";
            if (twitter == "false" && shareType == 'Twitter')
                errMsg += "This title has already been shared to twitter. Are you sure you want to share it again?";
            if (errMsg != "") {
                var result = confirm(errMsg);
                return result;
            }
            else
                return true;
        }
        function TwitterShare(url) {
            if (ValidateCustomModuleMutipleSelection('Twitter'))
                window.open(url, '_blank');
        }

        window.onload = function () {
            ChangeSchedule(0);
        }
    </script>
    <script type="text/javascript">
        function ShowNotShareMessage(MediaShare) {
            alert(MediaShare);
            return false;
        }
    </script>
</asp:Content>
