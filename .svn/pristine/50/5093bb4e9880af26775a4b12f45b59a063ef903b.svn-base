<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="ManageCalAddOns.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageCalAddOns" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <script type="text/javascript">
        function GetThis(T, C, U) {
            var targetUrl = 'http://www.myspace.com/index.cfm?fuseaction=postto&t=' + encodeURIComponent(T) + '&c=' + encodeURIComponent(C) + '&u=' + encodeURIComponent(U);
            window.open(targetUrl).focus();
        }

        function SelectAll(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdEvents.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdEvents.ClientID %>');
            var TargetChildControl = "CheckBox1";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[iCount].checked = CheckBox.checked;
            }
        }
    </script>
    <script type="text/javascript">
        function fnShowMessage(EventId) {

            var confrm = confirm('Your event has not been sent yet. Are you sure you want to edit?');
            if (confrm == true) {
                var url = "../../Business/MyAccount/CAEventsCalendar.aspx?CalId=" + EventId;
                window.location = url;
            }
        }

        function SelectAll(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdEvents.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdEvents.ClientID %>');
            var TargetChildControl = "chkUpdate";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[iCount].checked = CheckBox.checked;
            }
        }

        function SelectDeSelectHeader(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdEvents.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdEvents.ClientID %>');
            var TargetChildControl = "chkUpdate";
            var TargetHeaderControl = "chkSelectAll";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            var flag = false;
            var HeaderCheckBox;
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetHeaderControl, 0) >= 0)
                    HeaderCheckBox = Inputs[iCount];
                if (Inputs[iCount] != CheckBox && Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[iCount].id.indexOf(TargetHeaderControl, 0) == -1) {
                    if (CheckBox.checked) {
                        if (!Inputs[iCount].checked) {
                            flag = false;
                            HeaderCheckBox.checked = false;
                            return;
                        }
                        else
                            flag = true;
                    }
                    else if (!CheckBox.checked)
                        HeaderCheckBox.checked = false;
                }
            }
            if (flag)
                HeaderCheckBox.checked = CheckBox.checked
        }
        function GetConfirm(text, controlID) {

            if (ValidateEvent(controlID)) {
                if (text.toLowerCase() == 'publish')
                    return confirm('Are you sure you want to ' + text + ' selected event(s)?');
                else
                    return confirm('Are you sure you want to make selected event(s) ' + text + '?');
            }
            else {
                return false;
            }
        }
    </script>
    <style type="text/css">
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
            height: 36px;
            line-height: 36px;
            padding-left: 5px;
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
            background: #f3f3f3;
            border: solid 1px #d5d5d5;
            padding: 6px;
        }
        #tabber .content .leftmenu
        {
            vertical-align: top;
            width: 740px;
            padding-right: 5px;
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
            margin-right: 10px;
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
        .navy20
        {
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
            padding: 10px 0px 5px 0px;
            width: 100px;
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
            height: 369px;
            padding: 10px;
            background-color: #FFFFFF;
            margin-top: 12%;
            margin-left: 36%;
        }
        .mylistbox
        {
            padding: 5px;
            border: 1px solid #ccc;
            background-color: #fff;
            font-family: Arial, Helvitica, Sans-Serif;
            font-size: 14px;
        }
        .GridDock
        {
            overflow-x: auto;
            overflow-y: hidden;
            width: 740px;
            padding: 0 0 10px 0;
        }
    </style>
    <script type="text/javascript">
        function ValidateNotification(ControlId) {
            var resultItem = ValidateEvent(ControlId);
            if (resultItem) {
                if (document.getElementById('<%= hdnIsPusblished.ClientID %>').value == "true")
                    return true;
                else
                    alert('You cannot push a private item.');
            }
            return false;
        }
        function ValidateEvent(ControlId) {
            var id = ControlId.id;
            if (document.getElementById("<%=hdnarchive.ClientID%>").value != "Archive") {
                var selectedcount = 0;
                var rowIndex = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdEvents.ClientID %>');
                var TargetChildControl = "chkCurrentTabEventID";
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                    if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                        if (Inputs[iCount].checked) {
                            rowIndex = iCount + 1;
                            selectedcount += 1;
                            if (selectedcount > 1)
                                break;
                        }
                    }
                }

                if (selectedcount == 0) {
                    alert('Please select an title.');
                    return false;
                }
                else {
                    //                    if (id.indexOf("lnkdelete") != -1)
                    //                        return confirm('Are you sure you want to delete this event?');
                    //                    else if (id.indexOf("lnkArchive") != -1)
                    //                        return confirm('Are you sure you want to archive this event?');
                    //                    else
                    //                        return true;
                    var multiSelectionMsg = "Multiple selections are not allowed.";
                    if (id.indexOf("lnkPreview") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    }
                    else if (id.indexOf("lnkEdit") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    } else if (id.indexOf("lnkNotification") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    } else if (id.indexOf("lnkcopy") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    } else if (id.indexOf("lnkRename") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    } else if (id.indexOf("lnkSend") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    } else if (id.indexOf("lnkPrint") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    } else if (id.indexOf("lnkPrint") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    }
                    else if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete selected title(s)?');
                    else if (id.indexOf("lnkArchive") != -1)
                        return confirm('Are you sure you want to archive selected title(s)?');
                    return true;
                }
            }
            else {
                var selectedcount = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdEvents.ClientID %>');
                var TargetChildControl = "chkUpdate";
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                    if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                        if (Inputs[iCount].checked) {
                            selectedcount += 1;
                            if (selectedcount > 1)
                                break;
                        }
                    }
                }
                if (selectedcount == 0) {
                    alert('Please select an event.');
                    return false;
                }
                else if (selectedcount > 1) {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete selected title(s)?');
                    else if (id.indexOf("lnkChangeCurrent") != -1)
                        return confirm('Are you sure you want to reinstate this title(s)?');
                    else {
                        alert('Please select only one event.');
                        return false;
                    }
                }
                else {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete this title?');
                    else {
                        if (document.getElementById("<%=hdnCommandArg.ClientID%>").value == '') {
                            alert('Please select only one event.');
                            return false;
                        }
                        else {
                            if (id.indexOf("lnkChangeCurrent") != -1)
                                return confirm('Are you sure you want to reinstate this title?');
                            else
                                return true;
                        }
                    }
                }
            }
        }
        function openEmailwindow(url) {
            if (ValidateCustomModuleMutipleSelection('Email'))
                window.open(url, '', "width=700,height=650,scrollbars=no,toolbars=yes,status=yes,resizable=yes").focus();
        }
        function RadioCheck(rb, UpdateName, UpdateID) {
            RadioCheched = "True";
            var gv = document.getElementById("<%=GrdEvents.ClientID%>");
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
                                        <h1>
                                            Manage Event Calendar</h1>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <colgroup>
                                <col width="75%" />
                                <col width="*" />
                            </colgroup>
                            <tbody>
                                <tr>
                                    <td>
                                        <h1>
                                            <asp:Literal ID="ltrlTitleImage" runat="server"></asp:Literal>&nbsp; <span style="vertical-align: middle">
                                                Manage
                                                <%=hdnAddOnName.Value %></span>
                                        </h1>
                                    </td>
                                    <td style="float: left;">
                                        <span style="color: Black; font-size: 14px; margin: 0px; padding: 0px; position: absolute;
                                            margin-top: 8px;">
                                            <asp:Label runat="server" ID="lblOn" Visible="false">Displayed on App: <font class="showonapp">On</font></asp:Label>
                                            <asp:Label runat="server" ID="lblOff">Displayed on App: <font class="showoffapp">Off</font></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; padding-right: 25%;">
                                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <%--<span style="color: Black; font-size: 14px; margin: 0px; font-weight: bold;">App Display
                                            Order: </span>
                                        <asp:RadioButtonList ID="RBAppOrder" runat="server" RepeatDirection="Horizontal"
                                            Style="color: Black; font-size: 14px; margin-left:-8px; padding-left:-8px;" OnSelectedIndexChanged="RBAppOrder_OnSelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Text="By Date" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="By Custom Order" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>--%>
                                    </td>
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
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabber">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td colspan="3" align="right">
                                                <asp:Label ID="lblLastSyncDate" runat="server" ForeColor="BlueViolet" Font-Size="Medium"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="155px">
                                                <asp:LinkButton ID="lnkCurrent" runat="server" OnClick="lnkCurrent_Click" CausesValidation="false"
                                                    Text="<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkGetArchive" runat="server" CausesValidation="false" OnClick="lnkGetArchive_Click"
                                                    Text="<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>"></asp:LinkButton>
                                            </td>
                                            <td align="right">
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td align="right">
                                                            <%if (hdnShowButtons.Value == "1" || ShowButtons == "1")
                                                              { %>
                                                            <strong>Filter By :</strong> &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="drpfilter" runat="server"
                                                                AutoPostBack="true" OnSelectedIndexChanged="drpfilter_SelectedIndexChanged">
                                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Completed" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="Work In Progress" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Sending" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Scheduled" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Sent" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="Cancelled" Value="5"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <%} %>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="btnSyncOn" runat="server" OnClick="btnSyncOn_Click" CausesValidation="false"
                                                                Text="Sync On Google Events" />
                                                            <asp:Button ID="btnSyncOff" runat="server" OnClick="btnSyncOff_Click" CausesValidation="false"
                                                                Text="Sync Off" OnClientClick="return confirm('Are you sure you want to sync off your google events?');" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="content">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td class="leftmenu">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="GridDock" id="dvGridWidth" style="border: 1px solid #428ad7;">
                                                                                <asp:GridView ID="GrdEvents" runat="server" PageSize="5" AllowPaging="True" OnPageIndexChanging="GrdEvents_PageIndexChanging"
                                                                                    ForeColor="Black" EmptyDataText="" OnRowDataBound="GrdEvents_RowDataBound" DataKeyNames="CalendarId,Expiration_Date"
                                                                                    GridLines="None" AutoGenerateColumns="False" CssClass="datagrid2" Width="1165"
                                                                                    OnSorting="GrdEvents_Sorting" AllowSorting="True">
                                                                                    <EmptyDataRowStyle ForeColor="Red"></EmptyDataRowStyle>
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Image">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblupdatethub" Text='<%#Eval("ParentCalendarID")%>' runat="server" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle CssClass="align-center" Width="100px" />
                                                                                            <FooterStyle CssClass="align-center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkCurrentTabEventID" runat="server" AutoPostBack="true" OnCheckedChanged="chkEventID_CheckedChanged" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="30px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField>
                                                                                            <HeaderTemplate>
                                                                                                <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" onclick="SelectAll(this);"
                                                                                                    AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkUpdate" runat="server" AutoPostBack="true" OnCheckedChanged="chkUpdate_CheckedChanged" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="30px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Title" SortExpression="Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkEventName" OnClick="lnkUpdateName_Click" Text='<%#Eval("EventTitle") %>'
                                                                                                    runat="server" CommandArgument='<%#Eval("CalendarId")%>'></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="165px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Campaign Status" SortExpression="Status">
                                                                                            <ItemTemplate>
                                                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td style="border: 0px;" valign="top" nowrap="nowrap">
                                                                                                            <asp:Label ID="lblcam" runat="server" Text='<%# Bind("Sent_Flag") %>'></asp:Label>
                                                                                                            <asp:LinkButton Style="font-weight: bold; color: blue; font-family: verdana; color: #0b689d;"
                                                                                                                ID="lnkruncampaion" OnClick="lblhistroy_Click" runat="server" CausesValidation="false"
                                                                                                                Text="Campaign report" CommandArgument='<%# Bind("CalendarId") %>'></asp:LinkButton>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="120px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="EventStartDate" DataFormatString="{0:MM/dd/yyyy hh:mm tt}"
                                                                                            HeaderText="Start Date" HtmlEncode="False" SortExpression="EventStartDate">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="85px"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="EventEndDate" DataFormatString="{0:MM/dd/yyyy hh:mm tt}"
                                                                                            HeaderText="End Date" HtmlEncode="False" SortExpression="EventEndDate">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="85px"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Status" SortExpression="IsPublic">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("IsDisplay") %>'></asp:Label>
                                                                                                <br />
                                                                                                <asp:Label ID="lblApprovalStatus" runat="server" Style="color: Red; font-size: 11px;"
                                                                                                    Text='<%# Bind("Approval_Status") %>'></asp:Label>
                                                                                                <asp:Label ID="lnkStatus" runat="server" Visible="False"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="CreatedUsername" HeaderText="Created by" HtmlEncode="False"
                                                                                            SortExpression="CreatedUsername" Visible="false">
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            <ItemStyle Width="130px"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Created By</br>Approved / Rejected By" SortExpression="ApproveReject">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCreatedBy" runat="server" Text='<%#Eval("CreatedUsername") %>'></asp:Label>
                                                                                                <br />
                                                                                                <asp:Label ID="lblApproveReject" runat="server" Text='<%#Eval("Username") %>' Style="color: #FF9900;
                                                                                                    font-weight: bold;"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            <ItemStyle Width="130px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Completed" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblisCompleted" runat="server" Text='<%# Bind("IsPublished") %>' Visible="False"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="100px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Expiration_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Expiration Date"
                                                                                            HtmlEncode="False" SortExpression="ExpDate">
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Event_Type" HeaderText="Event Type" SortExpression="EventType">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                    </Columns>
                                                                                    <EmptyDataTemplate>
                                                                                      <%if (hdnarchive.Value == "Archive")
                                                                                      { %>
                                                                                       There is no archived content.
                                                                                      <%}
                                                                                      else
                                                                                      {%>
                                                                                       Start building
                                                                                       <%=hdnAddOnName.Value %>
                                                                                      <%} %>
                                                                                        
                                                                                    </EmptyDataTemplate>
                                                                                    <HeaderStyle CssClass="title3"></HeaderStyle>
                                                                                    <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnCommandArg" runat="server" />
                                                            <asp:HiddenField ID="hdnShowButtons" runat="server" />
                                                            <asp:HiddenField ID="hdnflyerthumb" runat="server" />
                                                            <asp:HiddenField ID="hdnarchive" runat="server" />
                                                            <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                                            <asp:HiddenField ID="hdnLinkShareFB" runat="server" />
                                                            <asp:HiddenField ID="hdnMessageDes" runat="server" />
                                                            <asp:HiddenField ID="hdnFacebookAppId" runat="server" />
                                                            <asp:HiddenField ID="hdnEventTitle" runat="server" />
                                                            <asp:HiddenField ID="hdnFacebook" runat="server" />
                                                            <asp:HiddenField ID="hdnTwitter" runat="server" />
                                                            <asp:HiddenField ID="hdnAddOnName" runat="server" />
                                                            <asp:HiddenField ID="hdnIsPusblished" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="right" class="rightmenu">
                                                <!-- Manage links goes here -->
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCreate" runat="server" CausesValidation="false" OnClick="lnkCreate_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -370px;">
                                                                </span>Create</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnShowButtons.Value == "1")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPreviewCalendar" runat="server" CausesValidation="false" OnClick="lnkPreviewCalendar_Click">
                                                            <span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -300px;">
                                                            </span>Preview Calendar</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPreview" runat="server" CausesValidation="false" OnClick="lnkPreview_Click"
                                                                OnClientClick="return ValidateEvent(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px 5px;">
                                                            </span>Preview</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnarchive.Value != "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" OnClick="lnkEdit_Click"
                                                                OnClientClick="return ValidateEvent(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -32px;">
                                                            </span>Edit</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkcopy" runat="server" OnClientClick="return ValidateEvent(this);"
                                                                CausesValidation="false" OnClick="lnkCopy_Click">
                                                            <span style="background: url(../../images/Dashboard/side_icons.png)  no-repeat 6px -70px;">
                                                            </span>Copy</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkRename" runat="server" OnClientClick="return ValidateEvent(this);"
                                                                CausesValidation="false" OnClick="lnkRename_Click">
                                                            <span style="background: url(../../images/Dashboard/side_icons.png)  no-repeat 6px -522px;">
                                                            </span>Rename</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trPublish">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPublish" runat="server" CausesValidation="false" OnClick="lnkPublish_Click"
                                                                OnClientClick="return GetConfirm('publish',this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -407px;">
                                                            </span>Publish</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trUnPublish">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkUnpublish" runat="server" CausesValidation="false" OnClick="lnkUnpublish_Click"
                                                                OnClientClick="return GetConfirm('private',this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -450px;">
                                                            </span>Private</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSendNotification">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkNotification" runat="server" CausesValidation="false" OnClick="lnkNotification_Click"
                                                                OnClientClick="return ValidateNotification(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -487px;">
                                                            </span>Push Notification</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkdelete" runat="server" CausesValidation="false" OnClick="lnkdelete_Click"
                                                                OnClientClick="return ValidateEvent(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -108px;">
                                                            </span>Delete</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkSend" runat="server" CausesValidation="false" OnClick="lnkSend_Click"
                                                                OnClientClick="return ValidateEvent(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -147px;">
                                                            </span>Email</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnarchive.Value == "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkChangeCurrent" runat="server" CausesValidation="false" OnClick="lnkArchive_Click"
                                                                OnClientClick="return ValidateEvent(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;">
                                                                </span>Current</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <%if (hdnarchive.Value != "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkArchive" runat="server" CausesValidation="false" OnClick="lnkArchive_Click"
                                                                OnClientClick="return ValidateEvent(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;">
                                                                </span>Archive</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr id="CancelCamp" runat="server" visible="false">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCancelCamp" runat="server" OnClick="lnkCancelCamp_Click" CausesValidation="false"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -263px">
                                                            </span>Cancel Campaign</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkReports" runat="server" Text="Reports" OnClick="lnkReports_Click"
                                                                CausesValidation="false"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -222px;">
                                                            </span>Reports</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <% if (hdnarchive.Value != "Archive")
                                                       { %>
                                                    <tr>
                                                        <td align="left">
                                                            <img src="../../images/Dashboard/share.gif" />
                                                        </td>
                                                    </tr>
                                                    <% if (hdnCommandArg.Value != "")
                                                       { %>
                                                    <tr id="trShareOn1" runat="server">
                                                        <td class="share">
                                                            <div>
                                                                <table border="0" width="95%" cellpadding="0" cellspacing="0">
                                                                    <colgroup>
                                                                        <col width="50%" />
                                                                        <col width="*" />
                                                                    </colgroup>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblEmailShare" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:LinkButton ID="lnkTwrShare" runat="server" OnClick="lnkTwrShare_Click" CausesValidation="false"
                                                                                OnClientClick="return ValidateCustomModuleMutipleSelection('Twitter');">
                                                                                <img src="../../images/Dashboard/twitternew.gif" alt="Share on Twitter" width="39" height="38" title="Share on Twitter" border="0" />
                                                                            </asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div>
                                                                <table border="0" width="95%" cellpadding="0" cellspacing="0">
                                                                    <colgroup>
                                                                        <col width="50%" />
                                                                        <col width="*" />
                                                                    </colgroup>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblFacebookShare" runat="server" Style="display: none;"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:LinkButton ID="lnkShareBtn" runat="server" OnClick="lnkShareBtn_Click" CausesValidation="false"
                                                                                OnClientClick="return ValidateCustomModuleMutipleSelection('Facebook');">
                                                                                <img src="../../images/Dashboard/facebooknew.gif" alt="Share on Facebook Page" width="55" height="36" title="Share on Facebook Page" border="0" />
                                                                            </asp:LinkButton>
                                                                            <asp:Label ID="lblFacebookPageShare" runat="server"></asp:Label>
                                                                            <asp:Label ID="lblPinShare" runat="server" Style="display: none;"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <%}
                                                       else
                                                       {%>
                                                    <tr id="trShareOn2" runat="server">
                                                        <td class="share">
                                                            <div>
                                                                <table border="0" width="95%" cellpadding="0" cellspacing="0">
                                                                    <colgroup>
                                                                        <col width="50%" />
                                                                        <col width="*" />
                                                                    </colgroup>
                                                                    <tr>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select a title.');">
                                                                                <img src='../../images/Dashboard/emailnew.gif' title='Share on Email' width='30'
                                                                                    height='38' alt='Share on Email' /></a>
                                                                        </td>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select a title.');">
                                                                                <img src='../../images/Dashboard/twitternew.gif' alt='Share on Twitter' title='Share on Twitter'
                                                                                    border='0' width='39' height='38' /></a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div>
                                                                <table border="0" width="95%" cellpadding="0" cellspacing="0">
                                                                    <colgroup>
                                                                        <col width="50%" />
                                                                        <col width="*" />
                                                                    </colgroup>
                                                                    <tr>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select a title.');" style="display: none;">
                                                                                <img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook' width='55'
                                                                                    height='36' title='Share on Facebook' border='0' /></a>
                                                                        </td>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select a title.');">
                                                                                <img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook' width='55'
                                                                                    height='36' title='Share on Facebook' border='0' /></a> <a class="cursor" onclick="alert('Please select an event.');"
                                                                                        style="display: none;">
                                                                                        <img src='../../images/Dashboard/PinterestLogo.gif' alt='Pin it on Pinterest' width='55'
                                                                                            height='36' title='Pin it on Pinterest' border='0' /></a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <%} %>
                                                    <%} %>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA;
                                                padding: 7px 0px 7px 0px;">
                                                <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Back" OnClick="btnBack_Click"
                                                    CausesValidation="false" />&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server"
                                                        Text="Dashboard" OnClick="btnCancel_Click" CausesValidation="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%-- Modal Popups--%>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="lblpnl" runat="server"></asp:Label>
                                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblpnl"
                                            PopupControlID="pnlpopup" BackgroundCssClass="modal" CancelControlID="imgbtn">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel Style="display: none" ID="pnlpopup" runat="server" Width="80%">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="right">
                                                        <asp:ImageButton ID="imgbtn" runat="server" ImageUrl="~/images/popup_close.gif" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <iframe id="Iframeevent" runat="server" frameborder="0" scrolling="yes" width="100%"
                                                            height="600px"></iframe>
                                                    </td>
                                                </tr>
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
                                            <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                                border="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
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
                                                                            History <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
                                                                                font-family: Arial; size: 2">
                                                                                <asp:Label ID="lblviewsentnewlettername" runat="server"></asp:Label>
                                                                            </span></span>
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:ImageButton ID="imglogin2" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif">
                                                                            </asp:ImageButton>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="grdviewsenthis" runat="server" OnSorting="grdviewsenthis_Sorting"
                                                                                AllowSorting="True" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                                                                                OnRowDataBound="grdviewsenthis_RowDataBound" OnPageIndexChanging="grdviewsenthis_PageIndexChanging"
                                                                                AllowPaging="True" PageSize="15">
                                                                                <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email IDs"></asp:BoundField>
                                                                                    <asp:BoundField DataField="SchduleSubject" HeaderText="Subject" />
                                                                                    <asp:BoundField DataField="Sending_Date" HeaderText="Date"></asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Status">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Sent_Flag") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    No contacts found
                                                                                </EmptyDataTemplate>
                                                                                <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
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
                                        <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                                        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblpre"
                                            PopupControlID="pnlpopup1" BackgroundCssClass="modal" CancelControlID="imglogin5">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel Style="display: none" ID="pnlpopup1" runat="server" Width="100%">
                                            <table style="padding-left: 10px; background-color: white" cellspacing="0" cellpadding="0"
                                                width="450" align="center" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="3">
                                                                <ProgressTemplate>
                                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-right: 20px; padding-top: 10px" align="right">
                                                            <asp:ImageButton ID="imglogin5" OnClick="imclose_Click" runat="server" CausesValidation="false"
                                                                ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                                            padding-top: 10px" align="left">
                                                            <asp:Label ID="lblupdatename" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-right: 10px; padding-bottom: 20px">
                                                            <div style="overflow: auto; position: relative; height: 500px">
                                                                <asp:Label ID="lblPreviewHTML" runat="server"></asp:Label>
                                                            </div>
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
                                        <asp:Label ID="lblc1" runat="server"></asp:Label>
                                        <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" BackgroundCssClass="modal"
                                            PopupControlID="pnleditnews1" TargetControlID="lblc1" CancelControlID="Imag4">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel Style="display: none" ID="pnleditnews1" runat="server" Width="100%">
                                            <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                                border="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                                <ProgressTemplate>
                                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td align="right">
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:ImageButton ID="Imag4" OnClick="imclose_Click" runat="server" ImageUrl="~/images/popup_close.gif">
                                                                            </asp:ImageButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <table width="370" cellpadding="0" cellspacing="0" border="0" style="border: 1px solid #EBB011;
                                                                                padding: 5px;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblFlyerimage" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="header" align="center" colspan="2" style="padding-top: 10px;">
                                                                            Content to be copied
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="header" style="padding-left: 100px; padding-bottom: 10px; padding-top: 20px;">
                                                                            Enter a new name:
                                                                        </td>
                                                                        <td style="padding-bottom: 10px; padding-top: 20px; padding-left: 5px;">
                                                                            <asp:TextBox ID="txteventname" runat="server" Width="275" MaxLength="150"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Event name is mandatory."
                                                                                ControlToValidate="txteventname" ValidationGroup="eventgroup"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td style="padding-left: 5px; padding-bottom: 10px;">
                                                                            <asp:Button ID="btneditcancel" OnClick="btneditcancel_Click" CausesValidation="false"
                                                                                runat="server" Text="Cancel"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:Button ID="BtneditTemplate" ValidationGroup="eventgroup" OnClick="BtneditTemplate_Click"
                                                                                runat="server" Text="Continue"></asp:Button><asp:HiddenField runat="server" ID="hdnURLPath" />
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
                                        <asp:Label ID="lblRename" runat="server"></asp:Label>
                                        <cc1:ModalPopupExtender ID="modalRename" runat="server" BackgroundCssClass="modal"
                                            PopupControlID="pnlRename" TargetControlID="lblRename" CancelControlID="imgRenameClose">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel Style="display: none" ID="pnlRename" runat="server" Width="100%">
                                            <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                                border="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:UpdateProgress ID="UpdateProgress11" runat="server" DisplayAfter="3">
                                                                <ProgressTemplate>
                                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <colgroup>
                                                                    <col width="40%" />
                                                                    <col width="*" />
                                                                </colgroup>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td align="right">
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:ImageButton ID="imgRenameClose" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif">
                                                                            </asp:ImageButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center" style="color: Red; font-size: 13px; padding-bottom: 5px;">
                                                                            <asp:Label ID="lblRenameMsg" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <table width="370" cellpadding="0" cellspacing="0" border="0" style="border: 1px solid #EBB011;
                                                                                padding: 5px;" align="center">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRenameImage" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="header" style="padding-left: 100px; padding-bottom: 10px; padding-top: 20px;"
                                                                            align="right">
                                                                            Existing name:
                                                                        </td>
                                                                        <td style="padding-bottom: 10px; padding-top: 20px; padding-left: 5px;">
                                                                            <asp:Label ID="lblExisting" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="header" style="padding-left: 100px; padding-bottom: 10px; padding-top: 20px;"
                                                                            align="right">
                                                                            Enter a new name:
                                                                        </td>
                                                                        <td style="padding-bottom: 10px; padding-top: 20px; padding-left: 5px;">
                                                                            <asp:TextBox ID="txtNewName" runat="server" Width="275" onkeypress="return DisableSplChars(event);"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Content name is mandatory."
                                                                                Display="Dynamic" ControlToValidate="txtNewName" ValidationGroup="Rename"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td style="padding-left: 5px; padding-bottom: 10px;">
                                                                            <asp:Button ID="btnRenameCancel" OnClick="btnRenameCancel_Click" runat="server" Text="Cancel"
                                                                                CausesValidation="false"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:Button ID="btnRenameBulletin" OnClick="btnRenameBulletin_Click" ValidationGroup="Rename"
                                                                                runat="server" Text="Save"></asp:Button>
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
                                        <asp:Label ID="lblp" runat="server" Visible="false"></asp:Label><asp:Label ID="lblc"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" TargetControlID="lblc"
                                            PopupControlID="pnlcoupsch" BackgroundCssClass="modal" CancelControlID="imglogin1">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel Style="display: none" ID="pnlcoupsch" runat="server" Width="100%">
                                            <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                                border="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
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
                                                                            Campaign History <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
                                                                                font-family: Arial; size: 2">
                                                                                <asp:Label ID="lblx" runat="server"></asp:Label>
                                                                            </span></span>
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:ImageButton ID="imglogin1" OnClick="imclose_Click" runat="server" CausesValidation="false"
                                                                                ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="grdschemail" runat="server" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                                                                                OnRowDataBound="grdschemail_RowDataBound" OnPageIndexChanging="grdschemail_PageIndexChanging"
                                                                                AllowPaging="True" PageSize="10">
                                                                                <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                                <Columns>
                                                                                    <asp:TemplateField Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Event_ID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Sending_Date" HeaderText="Date" />
                                                                                    <asp:TemplateField HeaderText="Scheduled Date" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblscheduleddate" runat="server" Text='<%# Bind("Schedule_Date") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Number of Emails per Day">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label4" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Status">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Sent_Flag") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    No contacts found
                                                                                </EmptyDataTemplate>
                                                                                <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="CancelCampaign" runat="server">
                                                                        <td>
                                                                            To cancel your campaign, please click here. &nbsp;&nbsp;<asp:Button ID="btnstopcampain"
                                                                                OnClick="btnstopcampain_Click" runat="server" Text="Cancel Campaign" CausesValidation="false">
                                                                            </asp:Button>
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
                                        <cc1:ModalPopupExtender ID="ModalPopupPublish" runat="server" PopupControlID="pnlPublish"
                                            TargetControlID="lblPublish" BackgroundCssClass="modal" CancelControlID="ImageButton2">
                                        </cc1:ModalPopupExtender>
                                        <asp:Label ID="lblPublish" runat="server"></asp:Label>
                                        <asp:Panel ID="pnlPublish" runat="server" Style="display: none;">
                                            <table class="popuptable" cellspacing="4px" cellpadding="4px" width="500px" border="0">
                                                <colgroup>
                                                    <col width="40%" />
                                                    <col width="*" />
                                                </colgroup>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                            <ProgressTemplate>
                                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="header">
                                                        Publish Event
                                                    </td>
                                                    <td align="right">
                                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" ImageUrl="../../images/popup_close.gif" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="padding: 10px 0px 0px 0px;">
                                                        <table border="0" cellpadding="2px" cellspacing="2px" width="100%">
                                                            <tr>
                                                                <td align="right" style="padding: 0px 0px 0px 55px;">
                                                                    Publish Date :
                                                                </td>
                                                                <td style="padding: 0px 0px 0px 8px;">
                                                                    <asp:TextBox ID="txtPublishDate" runat="server" Width="150"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPublishDate"
                                                                        runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="SV"
                                                                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                        ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                                    <span><b>(MM/DD/YYYY)</b></span>
                                                                    <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                                        Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td style="padding-top: 10px;" colspan="2">
                                                        <asp:Button ID="btnPublish" runat="server" OnClick="btnPublish_Click" Text="Update"
                                                            ValidationGroup="SV" />
                                                        <asp:Button ID="btnPublishCancel" runat="server" CausesValidation="false" OnClick="btnPublishCancel_Click"
                                                            Text="Cancel" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="padding: 0px 0px 10px 0px;">
                                                        <br />
                                                        <asp:Label ID="lblPublishError" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
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
                                        <cc1:ModalPopupExtender ID="MPELoginforGoogleEvents" runat="server" PopupControlID="PnlGoogleCalendars"
                                            TargetControlID="lblGoogleEvents" BackgroundCssClass="modal" CancelControlID="ImageButton2">
                                        </cc1:ModalPopupExtender>
                                        <asp:Label ID="lblGoogleEvents" runat="server"></asp:Label>
                                        <asp:Panel ID="PnlGoogleCalendars" runat="server" Style="display: none;" DefaultButton="btnGo">
                                            <table class="modalpopup" cellspacing="0" cellpadding="0" width="500px" border="0">
                                                <tr>
                                                    <td align="left" class="header">
                                                        Google Calendars
                                                    </td>
                                                    <td align="right">
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false"><img src="../../Images/popup_close.gif" alt="" /></asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:UpdateProgress ID="UpdateProgress9" runat="server" DisplayAfter="3">
                                                            <ProgressTemplate>
                                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:ListBox ID="lstGoogleCalenders" Height="70px" Width="200px" runat="server" SelectionMode="Multiple"
                                                                        CssClass="mylistbox"></asp:ListBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Button ID="btnGo" runat="server" Text="Get Events" Width="100px" OnClick="btnGo_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblpopupgooglecal" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
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
                                        <asp:Label ID="lblFbPreview" runat="server" visiable="false"></asp:Label>
                                        <cc1:ModalPopupExtender ID="MPEFbPreview" runat="server" TargetControlID="lblFbPreview"
                                            PopupControlID="pnlFbPreview" BackgroundCssClass="modal" CancelControlID="imgPopupClose">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel Style="display: none;" ID="pnlFbPreview" runat="server" Width="500px">
                                            <table class="modalpopup" cellspacing="0" cellpadding="0" width="100%" align="center"
                                                border="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
                                                                <ProgressTemplate>
                                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-right: 05px; padding-top: 05px" align="right">
                                                            <asp:ImageButton ID="imgPopupClose" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif">
                                                            </asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                                            padding-top: 10px" align="left">
                                                            <asp:TextBox TextMode="MultiLine" ID="txtFacebookdes" Width="97%" Height="100px"
                                                                runat="server" ReadOnly="true" Font-Size="Medium"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-right: 10px; padding-bottom: 20px" align="right">
                                                            <asp:Button ID="btnFbShare" runat="server" Text="Share" OnClientClick="post_on_wall()" />
                                                            <asp:Button ID="btnFbCancel" runat="server" Text="Cancel" OnClientClick="PopupClose()" />
                                                        </td>
                                                    </tr>
                                                </tbody>
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
                                                            <asp:DropDownList ID="ddlFbPagesList" class="FbPagesList" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-right: 10px; padding-bottom: 20px" align="center">
                                                            <asp:Button ID="btnShareOnPage" runat="server" class="FBpopupBtn" Text="Post Data"
                                                                OnClick="btnShareOnPage_Click" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblpopupVideoPlay" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popupVideoPlay" runat="server" TargetControlID="lblpopupVideoPlay"
                PopupControlID="pnlVideoPlay" BackgroundCssClass="modal" CancelControlID="imgclosVidepepreviewpopup1"
                BehaviorID="VideoPreviewPlay">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlVideoPlay" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosVidepepreviewpopup1" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid" style="padding-left: 30px; padding-bottom: 20px;">
                                <iframe id="IframeVideoPopup" width="640" height="375" frameborder="0" webkitallowfullscreen
                                    mozallowfullscreen allowfullscreen></iframe>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        //Show the Video Preivew
        function PlayVideo(videoUrl) {

            var Iframe = document.getElementById("IframeVideoPopup");
            var videoID = "";
            var playUrl = "";

            //url = url + "?autoplay=1";
            //Iframe.src = "//www.youtube.com/embed/DS88TwUvzjM?rel=0";
            if (videoUrl.indexOf("youtube") != -1) {
                videoID = videoUrl.match(/youtube\.com.*(\?v=|\/embed\/)(.{11})/).pop();
                playUrl = "//www.youtube.com/embed/" + videoID + "";

            }
            else if (videoUrl.indexOf("vimeo.com") != -1) {

                var match = /vimeo.*\/(\d+)/i.exec(videoUrl);
                videoID = match[1];
                playUrl = "//player.vimeo.com/video/" + videoID;
            }


            Iframe.src = playUrl;
            var modalDialog = $find("VideoPreviewPlay");
            modalDialog.show();

        }

        function LoadEventForPlayVideo() {
            $('.videoclass1').mousedown(function (event) {
                var Url = this.href;
                //alert(1);

                switch (event.which) {
                    case 1:
                        //alert('Left mouse button pressed');
                        PlayVideo(Url);
                        //$(this).attr('target','_self');
                        break;
                    case 2:
                        //alert('Middle mouse button pressed');
                        PlayVideo(Url);
                        //$(this).attr('target','_blank');
                        break;
                    case 3:
                        //alert('Right mouse button pressed');
                        PlayVideo(Url);
                        //$(this).attr('target','_blank');
                        break;
                    default:
                        //alert('You have a strange mouse');
                        PlayVideo(Url);
                        //$(this).attr('target','_self"');
                }
            });


        }
        function Display_FB_Popup() {
            $find('<%=MPEFbPreview.ClientID%>').show();
        }
        function PopupClose() {
            $find('<%=MPEFbPreview.ClientID%>').hide();
        }

        function ValidateCustomModuleMutipleSelection(shareType) {
            var selectedcount = 0;
            var rowIndex = 0;
            var TargetBaseControl = document.getElementById('<%= this.GrdEvents.ClientID %>');
            var TargetChildControl = "chkCurrentTabEventID";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                    if (Inputs[iCount].checked) {
                        rowIndex = iCount + 1;
                        selectedcount += 1;
                        if (selectedcount > 1)
                            break;
                    }
                }
            }
            // END for loop
            if (selectedcount == 0) {
                alert('Please select a Title.');
                return false;
            }
            else if (selectedcount > 1) {
                alert("Multiple selections are not allowed.");
                return false;
            }
            else {
                var status = TargetBaseControl.rows[rowIndex].cells[6].childNodes[1].innerHTML;
                if (status == "Published") {
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
                else {
                    if (TargetBaseControl.rows[rowIndex].cells[6].innerHTML.indexOf("(Pending Approval)") != -1)
                        alert("You cannot share an item that is pending approval.");
                    else
                        alert("You cannot share an item that is private.");
                    return false;
                }
            }
        }
        function TwitterShare(url) {
            if (ValidateCustomModuleMutipleSelection('Twitter'))
                window.open(url, '_blank');
        }
    </script>
    <!--Facebook Share START -->
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                appId: document.getElementById("<%=hdnFacebookAppId.ClientID%>").value,
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true, // parse XFBML
                oauth: true // Enable oauth authentication
            });
        };
        function post_on_wall() {
            $find('<%=MPEFbPreview.ClientID%>').hide();
            var msg = document.getElementById("<%=hdnMessageDes.ClientID%>").value;
            var title = document.getElementById("<%=hdnEventTitle.ClientID%>").value;
            var ShareLink = document.getElementById("<%=hdnLinkShareFB.ClientID%>").value;
            FB.login(function (response) {
                if (response.authResponse) {
                    // Post message to your wall
                    var opts = {
                        message: msg,
                        name: title,
                        link: ShareLink
                    };
                    FB.api('/me/feed', 'post', opts, function (response) {
                        if (!response || response.error) {
                            alert('Facebook server is not responding. Please try again later.'); //Posting has been failed. Please Call us at 1-800-281-0263 Monday - Friday 8 a.m. - 5 p.m. PST');
                        }
                        else {
                            // *** Display any success message if needed ***//
                            alert("title has been posted successfully.");
                        }
                    });
                }
                else {
                    // *** show message for not logged in *** //
                }
            }, { scope: 'publish_stream' });
        }
        function post_on_page() {
            if (ValidateCustomModuleMutipleSelection('Facebook'))
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
            var title = document.getElementById("<%=hdnEventTitle.ClientID%>").value;
            var ShareLink = document.getElementById("<%=hdnLinkShareFB.ClientID%>").value;
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    var select = document.getElementById("thebox");
                    var page_id = select.options[select.selectedIndex].value;
                    FB.api('/' + page_id + '/feed', 'POST',
                            {
                                'name': title,
                                'message': msg,
                                'link': ShareLink
                            },
                            function (response) {
                                if (response && !response.error)
                                    alert("Event has been posted successfully.");
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
    <script>
        (function () {
            var e = document.createElement('script');
            // replacing with an older version until FB fixes the cancel-login bug
            e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
            //e.src = 'scripts/all.js';
            e.async = true;
            document.getElementById('fb-root').appendChild(e);
        } ());
    </script>
    <!--Facebook Share END -->
    <script type="text/javascript">
        function DisableSplChars(e) {

            var keynum;
            // For Internet Explorer    
            if (window.event) {
                keynum = e.keyCode
            }
            // For Netscape/Firefox/Opera    
            else if (e.which) {
                keynum = e.which
            }
            //keychar = String.fromCharCode(keynum)    
            //List of special characters you want to restrict    
            if (keynum == '34' || keynum == '42' || keynum == '47' || keynum == '58' || keynum == '60' || keynum == '62' || keynum == '92' || keynum == '124') {
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>
