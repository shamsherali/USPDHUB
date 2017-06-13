<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="ManageBulletins.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageBulletins"
    EnableEventValidation="false" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/UcPageSize.ascx" TagName="PageSize" TagPrefix="UcPageSize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <link href="../../css/Jquery-order-ui.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <style type="text/css">
        .lblfont
        {
            font-size: 11px;
        }
        .headerbgcolor
        {
            background-color: #000080;
        }
        .multiline-txtbox
        {
            display: block;
            width: 90%;
            height: 80px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857;
            color: #555;
            vertical-align: middle;
            background-color: #FFF;
            background-image: none;
            border: 1px solid #CCC;
            border-radius: 4px;
            box-shadow: 0px 1px 1px rgba(0, 0, 0, 0.075) inset;
            transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s;
        }
        #sortable
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: auto;
        }
        #sortable li
        {
            margin: 0 5px 5px 5px;
            padding: 5px;
            font-size: 1.2em;
            height: 1.5em;
            cursor: move;
        }
        html > body #sortable li
        {
            height: 1.5em;
            line-height: 1.2em;
        }
    </style>
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
        .paginationClass span
        {
            font-weight: bold;
            font-size: 14px;
            color: White;
            border: 1px solid #f15a29;
            padding: 0px 5px;
            background-color: #FFCC00;
        }
    </style>
    <script type="text/javascript">

        var order = '';
        function ShowOrderScript() {
            $('#sortable').sortable({
                placeholder: 'ui-state-highlight',
                update: OnSortableUpdate
            });
            $('#sortable').disableSelection();


            function OnSortableUpdate(event, ui) {
                order = $('#sortable').sortable('toArray').join(',').replace(/id_/gi, '');
            }
        }
        function UpdateOder() {
            var typeval = PageMethods.UpdateItemsOrder(order, OnSuccess, OnFailure);
            return false;
        }
        function OnSuccess(result) {
            if (result == "success") {
                document.getElementById("<%=lblmess.ClientID%>").innerHTML = "The content order has been updated successfully.";
                $find('<%=ModalPopupImgOrderNo.ClientID %>').hide();
            }
            else
                OnFailure(result);
        }
        function OnFailure(result) {
            $find('<%=ModalPopupImgOrderNo.ClientID %>').show();
            alert("Failure occurs while updating the ontent order.");
        }
        function SelectAll(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdBulletins.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdBulletins.ClientID %>');
            var TargetChildControl = "chkBulletin";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[iCount].checked = CheckBox.checked;
            }
        }

        function SelectDeSelectHeader(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdBulletins.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdBulletins.ClientID %>');
            var TargetChildControl = "chkBulletin";
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
        function ValidateNotification(ControlId) {
            var resultItem = ValidateBulletin(ControlId);
            if (resultItem) {
                if (document.getElementById('<%= hdnIsPusblished.ClientID %>').value == "true")
                    return true;
                else
                    alert('You cannot push a private item.');
            }
            return false;
        }
        function ValidateBulletin(ControlId) {
            var id = ControlId.id;
            if (document.getElementById("<%=hdnarchive.ClientID%>").value != "Archive") {
                var selectedcount = 0;
                var rowIndex = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdBulletins.ClientID %>');
                var TargetChildControl = "chkBulletinID";
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
                    alert('Please select a Title.');
                    return false;
                }
                else {
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
                    } else if (id.indexOf("lnkCopy") != -1 && selectedcount > 1) {
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
                    } else if (id.indexOf("lnkCrisisExport") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    }
                    else if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete the selected content?');
                    else if (id.indexOf("lnkArchive") != -1)
                        return confirm('Are you sure you want to archive the selected content?');
                    return true;
                }
            }
            else {
                var selectedcount = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdBulletins.ClientID %>');
                var TargetChildControl = "chkBulletin";
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
                    alert('Please select a Title.');
                    return false;
                }
                else if (selectedcount > 1) {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete the selected content?');
                    else if (id.indexOf("lnkChangeCurrent") != -1)
                        return confirm('Are you sure you want to reinstate this title(s)?');
                    else {
                        alert('Please select only one title.');
                        return false;
                    }
                }
                else {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete this title?');
                    else {
                        if (document.getElementById("<%=hdnCommandArg.ClientID%>").value == '') {
                            alert('Please select only one title.');
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
            if (ValidateCustomModuleMutipleSelection())
                window.open(url, '', "width=700,height=650,scrollbars=no,toolbars=yes,status=yes,resizable=yes").focus();
        }
        function RadioCheck(rb, NewsName, NewsID) {
            var gv = document.getElementById("<%=GrdBulletins.ClientID%>");
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
        function GetConfirm(text, controlID) {
            if (ValidateBulletin(controlID)) {
                if (text.toLowerCase() == 'publish') {
                    if ('<%= IsScheduleEmails %>' == 'True') {
                        return confirm('Are you sure you want to ' + text + ' the selected content?');
                    }
                    else {
                        return confirm('This item will be published immediately; continue?');
                    }
                }
                else
                    return confirm('Are you sure you want to make the selected content ' + text + '?');
            }
            else {
                return false;
            }
        }
    </script>
    <style>
        .GridDock
        {
            overflow-x: auto;
            overflow-y: hidden;
            width: 740px;
            padding: 0 0 10px 0;
        }
    </style>
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
                                            Manage Bulletins</h1>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkCrisisExport" />
            <asp:PostBackTrigger ControlID="lnkPrint" />
        </Triggers>
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
                                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                        </h1>
                                        <%-- &nbsp;<a href="javascript:void(0)" onclick="ShowHelpVideos('Contacts')" title="Bulletins">
                                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages//play_icon.png")%>" />How
                                    to Video</a>--%>
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
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td>
                                        <span style="color: Black; font-size: 14px; margin: 0px; font-weight: bold;">App Display
                                            Order: </span>
                                        <asp:RadioButtonList ID="RBAppOrder" runat="server" RepeatDirection="Horizontal"
                                            Style="color: Black; font-size: 14px; padding-left: -8px; margin-left: -8px;"
                                            OnSelectedIndexChanged="RBAppOrder_OnSelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="By Date" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="By Custom Order" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <p style="margin-top: 10px; position: absolute;margin-left:49px;">
                                            Page Size
                                            <UcPageSize:PageSize ID="PageSizes" runat="server" />
                                        </p>
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
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td width="155px">
                                                <asp:LinkButton ID="lnkCurrent" runat="server" OnClick="lnkCurrent_Click" CausesValidation="false"
                                                    Text="<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkGetArchive" runat="server" CausesValidation="false" OnClick="lnkGetArchive_Click"
                                                    Text="<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right">
                                    <%if (hdnShowButtons.Value == "1" || ShowButtons == "1")
                                      { %>
                                    <strong>Filter Status:</strong>
                                    <asp:DropDownList ID="drpfilter" runat="server">
                                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Active" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Inactive" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%if (DomainName.ToLower().Contains("uspdhub"))
                                      { %>
                                    &nbsp;&nbsp;&nbsp;<strong>Category:</strong>
                                    <asp:DropDownList ID="ddlCategory" runat="server">
                                    </asp:DropDownList>
                                    <%} %>
                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click"
                                        CausesValidation="false" Text="Go" />
                                    <%} %>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="content">
                                    <table cellpadding="0" cellspacing="0" border="0" width="909px">
                                        <tr>
                                            <td class="leftmenu">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div class="GridDock" id="dvGridWidth" style="border: 1px solid #428ad7;">
                                                                                <asp:GridView ID="GrdBulletins" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                    CssClass="datagrid2" AllowPaging="True" DataKeyNames="Bulletin_ID,Template_BID,Expiration_Date"
                                                                                    OnRowDataBound="GrdBulletins_RowDataBound" OnPageIndexChanging="GrdBulletins_PageIndexChanging"
                                                                                    Width="1080" GridLines="None" OnSorting="GrdBulletins_Sorting" PageSize="5">
                                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Image">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblbulletinthumb" runat="server" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle CssClass="align-center" Width="100px" />
                                                                                            <FooterStyle CssClass="align-center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                            <ItemTemplate>
                                                                                                <%--<asp:RadioButton ID="rbBulletin" runat="server" AutoPostBack="true" OnCheckedChanged="rbBulletin_CheckedChanged"
                                                                                                    onclick='<%# string.Format("javascript:RadioCheck(this, \"{0}\",\"{1}\")", "", Eval("Bulletin_ID")) %>' />--%>
                                                                                                <asp:CheckBox ID="chkBulletinID" runat="server" AutoPostBack="true" OnCheckedChanged="rbBulletin_CheckedChanged" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="30px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField>
                                                                                            <HeaderTemplate>
                                                                                                <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" onclick="SelectAll(this);"
                                                                                                    AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkBulletin" runat="server" AutoPostBack="true" OnCheckedChanged="chkBulletin_CheckedChanged" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="30px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkTitle" runat="server" CausesValidation="false" Text='<%# Bind("Bulletin_Title") %>'
                                                                                                    CommandArgument='<%# Bind("Bulletin_ID") %>' OnClick="lnkTitle_Click"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="175px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Modified_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Updated Date"
                                                                                            HtmlEncode="False" SortExpression="Date">
                                                                                            <HeaderStyle Width="120px"></HeaderStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("IsPublished") %>' Visible="false"></asp:Label>
                                                                                                <asp:Label ID="lblDisplay" runat="server" Text='<%# Bind("IsDisplay") %>'></asp:Label>
                                                                                                <br />
                                                                                                <asp:Label ID="lblApprovalStatus" runat="server" Text='<%# Bind("Approval_Status") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="105px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="CreatedUsername" HeaderText="Created by" Visible="false"
                                                                                            SortExpression="CreatedUsername">
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            <ItemStyle Width="150px"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Created By</br>Approved / Rejected By" SortExpression="ApproveReject">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCreatedBy" runat="server" Text='<%#Eval("CreatedUsername") %>'></asp:Label>
                                                                                                <br />
                                                                                                <asp:Label ID="lblApproveReject" runat="server" Text='<%#Eval("Username") %>' Style="color: #FF9900;
                                                                                                    font-weight: bold;"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            <ItemStyle Width="150px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <%-- <asp:BoundField DataField="Username" HeaderText="Approved</br>Rejected by" HtmlEncode="False"
                                                                                            SortExpression="Username">
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            <ItemStyle Width="150px"></ItemStyle>
                                                                                        </asp:BoundField>--%>
                                                                                        <asp:TemplateField HeaderText="Email Status" SortExpression="CampaignStatus">
                                                                                            <ItemTemplate>
                                                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td style="border: 0px;" valign="top" nowrap="nowrap">
                                                                                                            <asp:Label ID="lblcam" runat="server" Text='<%# Bind("Sent_Flag") %>'></asp:Label>
                                                                                                            <asp:LinkButton Style="font-weight: bold; color: blue; font-family: verdana; color: #0b689d;"
                                                                                                                ID="lnkruncampaion" OnClick="lblhistroy_Click" runat="server" CausesValidation="false"
                                                                                                                Text="Campaign report" CommandArgument='<%# Bind("Bulletin_ID") %>' ToolTip="Click to Cancel"></asp:LinkButton>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="100px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Expiration_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Expiration Date"
                                                                                            HtmlEncode="False" SortExpression="ExpDate">
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="Bulletin_Category" HeaderText="Category" SortExpression="CateID">
                                                                                            <HeaderStyle Width="150px"></HeaderStyle>
                                                                                        </asp:BoundField>
                                                                                    </Columns>
                                                                                    <EmptyDataTemplate>
                                                                                        No contents found
                                                                                    </EmptyDataTemplate>
                                                                                    <HeaderStyle CssClass="title3"></HeaderStyle>
                                                                                    <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                                    <PagerStyle CssClass="paginationClass" />
                                                                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First"
                                                                                        LastPageText="Last" />
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
                                                            <asp:HiddenField ID="hdnPrintNewsID" runat="server" />
                                                            <asp:HiddenField ID="hdnRowIndex" runat="server" />
                                                            <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                                            <asp:HiddenField ID="hdnLinkShareFB" runat="server" />
                                                            <asp:HiddenField ID="hdnMessageDes" runat="server" />
                                                            <asp:HiddenField ID="hdnFacebookAppId" runat="server" />
                                                            <asp:HiddenField ID="hdnBulletinTitle" runat="server" />
                                                            <asp:HiddenField ID="hdnFacebook" runat="server" />
                                                            <asp:HiddenField ID="hdnTwitter" runat="server" />
                                                            <asp:HiddenField ID="hdnIsPusblished" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="rightmenu">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCreate" runat="server" CausesValidation="false" OnClick="lnkCreate_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -370px;"></span>Create</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%if (hdnShowButtons.Value == "1" && ShowFilter == "")
                                                  { %>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPreview" runat="server" CausesValidation="false" OnClick="lnkPreview_Click"
                                                                OnClientClick="return ValidateBulletin(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px 5px;"></span>Preview</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnarchive.Value != "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" OnClick="lnkEdit_Click"
                                                                OnClientClick="return ValidateBulletin(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -32px;"></span>Edit</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkbulletinorder" runat="server" CausesValidation="false" OnClick="btnEditOrderNumber_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -221px;"></span>Change Order</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trPublish">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPublish" runat="server" CausesValidation="false" OnClick="lnkPublish_Click"
                                                                OnClientClick="return GetConfirm('publish',this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -407px;"></span>Publish</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trUnPublish">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkUnpublish" runat="server" CausesValidation="false" OnClick="lnkUnpublish_Click"
                                                                OnClientClick="return GetConfirm('private',this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -450px;"></span>Private</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSendNotification">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkNotification" runat="server" CausesValidation="false" OnClick="lnkNotification_Click"
                                                                OnClientClick="return ValidateNotification(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -487px;"></span>Push Notification</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCopy" runat="server" CausesValidation="false" OnClick="lnkCopy_Click"
                                                                OnClientClick="return ValidateBulletin(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -70px;"></span>Copy</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkRename" runat="server" CausesValidation="false" OnClick="lnkRename_Click"
                                                                OnClientClick="return ValidateBulletin(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -522px;"></span>Rename</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkdelete" runat="server" CausesValidation="false" OnClick="lnkdelete_Click"
                                                                OnClientClick="return ValidateBulletin(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -108px;"></span>Delete</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkSend" runat="server" OnClick="lnkSend_Click" CausesValidation="false"
                                                                OnClientClick="return ValidateBulletin(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -147px;"></span>Email</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr id="CancelCamp" runat="server" visible="false">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCancelCamp" runat="server" OnClick="lnkCancelCamp_Click" CausesValidation="false"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -263px"></span>Cancel Campaign</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnarchive.Value == "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkChangeCurrent" runat="server" CausesValidation="false" OnClick="lnkArchive_Click"
                                                                OnClientClick="return ValidateBulletin(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;"></span>Current</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <%if (hdnarchive.Value != "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkArchive" runat="server" CausesValidation="false" OnClick="lnkArchive_Click"
                                                                OnClientClick="return ValidateBulletin(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;"></span>Archive</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPrint" runat="server" CausesValidation="false" OnClick="lnkPrint_Click"
                                                                OnClientClick="return ValidateBulletin(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -32px;"></span>Print</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (IsReport)
                                                      {%>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkReports" runat="server" Text="Reports" CausesValidation="false"
                                                                OnClick="lnkReports_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -222px;"></span>Reports</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <% if (hdnarchive.Value != "Archive")
                                                       { %>
                                                    <tr id="trCrisisExport" runat="server">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCrisisExport" runat="server" Text="Export" CausesValidation="false"
                                                                OnClick="lnkCrisisExport_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -222px;"></span>Export</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr id="trShareOn2" runat="server" class="rightLinks">
                                                        <td align="left">
                                                            <img src="../../images/Dashboard/share.gif" />
                                                        </td>
                                                    </tr>
                                                    <% if (hdnCommandArg.Value != "")
                                                       { %>
                                                    <tr id="trShareOn1" runat="server">
                                                        <td class="share" align="left">
                                                            <div style="display: block;">
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
                                                                            <%--<asp:Label ID="lblTwitterShare" runat="server"></asp:Label>--%>
                                                                            <asp:LinkButton ID="lnkTwrShare" runat="server" OnClick="lnkTwrShare_Click" CausesValidation="false"
                                                                                OnClientClick="return ValidateCustomModuleMutipleSelection('Twitter');">
                                                                                <img src="../../images/Dashboard/twitternew.gif" alt="Share on Twitter" width="39" height="38" title="Share on Twitter" border="0" />
                                                                            </asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div style="display: block;">
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
                                                                            <asp:LinkButton ID="lnkShareBtn" runat="server" OnClientClick="return ValidateCustomModuleMutipleSelection('Facebook');"
                                                                                CausesValidation="false" OnClick="lnkShareBtn_Click">
                                                                                <img src="../../images/Dashboard/facebooknew.gif" alt="Share on Facebook Page" width="55" height="36" title="Share on Facebook Page" border="0" />
                                                                            </asp:LinkButton>
                                                                            <asp:Label ID="lblFacebookPageShare" runat="server"></asp:Label>
                                                                            <asp:Label ID="lblPinShare" runat="server" Style="display: none;"></asp:Label>
                                                                            <%--<asp:Label ID="lbllinkedinShare" runat="server" Style="display: none;"></asp:Label>--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <%}
                                                       else
                                                       { %>
                                                    <tr>
                                                        <td class="share">
                                                            <div style="display: block;">
                                                                <table border="0" width="95%" cellpadding="0" cellspacing="0">
                                                                    <colgroup>
                                                                        <col width="50%" />
                                                                        <col width="*" />
                                                                    </colgroup>
                                                                    <tr>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select a Title.');">
                                                                                <img src='../../images/Dashboard/emailnew.gif' title='Share on Email' width='30'
                                                                                    height='38' alt='Share on Email' /></a>
                                                                        </td>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select a Title.');">
                                                                                <img src='../../images/Dashboard/twitternew.gif' alt='Share on Twitter' title='Share on Twitter'
                                                                                    border='0' width='39' height='38' /></a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div style="display: block;">
                                                                <table border="0" width="95%" cellpadding="0" cellspacing="0">
                                                                    <colgroup>
                                                                        <col width="50%" />
                                                                        <col width="*" />
                                                                    </colgroup>
                                                                    <tr>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select a Title.');" style="display: none;">
                                                                                <img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook' width='55'
                                                                                    height='36' title='Share on Facebook' border='0' /></a>
                                                                        </td>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select a Title.');">
                                                                                <img src='../../images/Dashboard/facebooknew.gif' alt='Share on Facebook' width='55'
                                                                                    height='36' title='Share on Facebook' border='0' /></a> <a class="cursor" onclick="alert('Please select a Title.');"
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
                                                </table>
                                                <%} %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA;
                                                padding: 7px 0px 7px 0px;">
                                                <asp:Button ID="btnCancel" runat="server" Text="Dashboard" OnClick="btnCancel_Click"
                                                    CausesValidation="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnURLPath" runat="server" />
                    </td>
                </tr>
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
                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblc"
                                PopupControlID="pnlcoupsch" BackgroundCssClass="modal" CancelControlID="imglogin1">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlcoupsch" runat="server" Width="100%">
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
                                                                Campaign History <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
                                                                    font-family: Arial; size: 2">
                                                                    <asp:Label ID="lblx" runat="server"></asp:Label>
                                                                </span></span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin1" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif">
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
                                                                <asp:GridView ID="grdschemail" runat="server" PageSize="10" AllowPaging="True" OnPageIndexChanging="grdschemail_PageIndexChanging"
                                                                    OnRowDataBound="grdschemail_RowDataBound" AutoGenerateColumns="False" CssClass="datagrid2"
                                                                    Width="100%">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Bulletin_ID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Sending_Date" HeaderText="Date" />
                                                                        <asp:TemplateField HeaderText="Scheduled Date" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Schedule_Date") %>'></asp:Label>
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
                                                        <tr>
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
                                                                Content History <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
                                                                    font-family: Arial; size: 2">
                                                                    <asp:Label ID="lblviewsentnewlettername" runat="server"></asp:Label>
                                                                </span>
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
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdviewsenthis" runat="server" Width="100%" CssClass="datagrid2"
                                                                    AutoGenerateColumns="False" OnRowDataBound="grdviewsenthis_RowDataBound" PageSize="15"
                                                                    AllowPaging="True" OnPageIndexChanging="grdviewsenthis_PageIndexChanging">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email IDs" />
                                                                        <asp:BoundField DataField="Bulletin_Subject" HeaderText="Subject" />
                                                                        <asp:BoundField DataField="Sending_Date" HeaderText="Date" />
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
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblPreview" runat="server" visiable="false"></asp:Label>
                        <cc1:ModalPopupExtender ID="MPEPreview" runat="server" TargetControlID="lblPreview"
                            PopupControlID="pnlPreview" BackgroundCssClass="modal" CancelControlID="imgPreviewClose">
                        </cc1:ModalPopupExtender>
                        <asp:Panel Style="display: none" ID="pnlPreview" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%" class="popuptable" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" style="padding: 5px 10px 0px 10px;">
                                            <asp:ImageButton ID="imgPreviewClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                CausesValidation="false"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                            padding-top: 10px" align="left">
                                            <asp:Label ID="lblbulletinamme" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            <div style="overflow-y: auto; height: 500px; position: relative; width: auto; padding-right: 30px;">
                                                <asp:Label ID="lblPreviewHTML" runat="server"></asp:Label></div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblcopy" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="MPECopy" runat="server" BackgroundCssClass="modal" PopupControlID="pnlcopy"
                                TargetControlID="lblcopy" CancelControlID="imgCopyClose">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlcopy" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
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
                                                                <asp:ImageButton ID="imgCopyClose" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif">
                                                                </asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center" style="color: Red; font-size: 13px; padding-bottom: 5px;">
                                                                <asp:Label ID="lbleditext" runat="server" ForeColor="red"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                                <table width="370" cellpadding="0" cellspacing="0" border="0" style="border: 1px solid #EBB011;
                                                                    padding: 5px;" align="center">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblBulletinImage" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="header" align="center" colspan="2">
                                                                Content to be copied
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="header" style="padding-left: 100px; padding-bottom: 10px; padding-top: 20px;"
                                                                align="right">
                                                                Enter a new name:
                                                            </td>
                                                            <td style="padding-bottom: 10px; padding-top: 20px; padding-left: 5px;">
                                                                <asp:TextBox ID="txtBulletinName" runat="server" Width="275" onkeypress="return DisableSplChars(event);"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqeditcheck" runat="server" ErrorMessage="Content name is mandatory."
                                                                    Display="Dynamic" ControlToValidate="txtBulletinName" ValidationGroup="copy"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding-left: 5px; padding-bottom: 10px;">
                                                                <asp:Button ID="btnCopycancel" OnClick="btnCopycancel_Click" runat="server" Text="Cancel"
                                                                    CausesValidation="false"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:Button ID="btnCopyBulletin" OnClick="btnCopyBulletin_Click" runat="server" Text="Continue"
                                                                    ValidationGroup="copy"></asp:Button>
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
                                                <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
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
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Content name is mandatory."
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
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <cc1:ModalPopupExtender ID="ModalPopupImgOrderNo" runat="server" PopupControlID="pnlpopup2"
                            TargetControlID="lbl2" BackgroundCssClass="modal" CancelControlID="ImageButton1">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlpopup2" runat="server" Style="display: none;">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="500px" border="0">
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="header">
                                        <div style="float: left; text-align: left; padding: 10px 0px 0px 5px;">
                                            <asp:Label runat="server" Text="App Display Order"></asp:Label>
                                            <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Change Content Order',138,'');">
                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                        </div>
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <br />
                                        <asp:Label ID="lbl2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <caption>
                                    <br />
                                    <%--<tr>
                                        <td align="left" class="header" style="padding-left: 10px;">
                                            <asp:Label ID="lbltitle" runat="server" Font-Size="Small" Text="Name"></asp:Label>
                                        </td>
                                        <td align="right" class="header" style="padding-right: 10px;">
                                            <asp:Label ID="lblOrder" runat="server" Font-Size="Small" Text="Order Number"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="2">
                                            <div id="Div1" style="height: 300px; overflow-y: auto; border: solid 1px #ccc; padding-top: 5px;">
                                                <!--  <asp:DataList ID="DataList1" runat="server" DataKeyField="Bulletin_ID" RepeatColumns="1"
                                                    RepeatDirection="Vertical" RepeatLayout="Table">
                                                    <ItemTemplate>
                                                        <table border="0" cellpadding="2" cellspacing="0" class="imggrid" width="100%">
                                                            <tr>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:Label ID="lblphotoId" runat="server" Font-Names="arial" Font-Size="Small" ForeColor="Black"
                                                                        Text='<%#Eval("Bulletin_Title") %>' Width="500px"></asp:Label>
                                                                </td>
                                                                <td style="padding-right: 25px;">
                                                                    <asp:TextBox ID="lblhiddenorder" runat="server" CssClass="textfield" MaxLength="5"
                                                                        Text='<%#Eval("Order_No") %>' Width="40px"></asp:TextBox>
                                                                    <asp:Label ID="lblprimary" runat="server" Text='<%#Eval("Bulletin_ID") %>' Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                    <AlternatingItemStyle BackColor="WhiteSmoke" />
                                                    <ItemStyle BackColor="#EEECEC" />
                                                </asp:DataList>-->
                                                <ul id="sortable">
                                                    <asp:ListView ID="OrderListView" OnItemDataBound="OrderListView_ItemDataBound" runat="server"
                                                        DataKeyNames="Bulletin_ID" ItemPlaceholderID="myItemPlaceHolder">
                                                        <LayoutTemplate>
                                                        </LayoutTemplate>
                                                        <LayoutTemplate>
                                                            <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                        </LayoutTemplate>
                                                        <ItemTemplate>
                                                            <li class="ui-state-default" id='id_<%# Eval("Bulletin_ID") %>' style="border: 1px solid #ccc;
                                                                background: #EEEEEE; font-weight: normal; color: #8C8C8C;">
                                                                <asp:Label ID="lblKey" runat="server" Text='<%#Eval("Bulletin_ID") %>' Visible="false" />
                                                                <asp:Label ID="lblOrderThumb" runat="server" />
                                                                &nbsp&nbsp;&nbsp;
                                                                <%# Eval("Bulletin_Title")%></li>
                                                        </ItemTemplate>
                                                    </asp:ListView>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td style="padding-top: 10px; padding-left: 120px;">
                                            <asp:Button ID="btnUpdateImgOrderNumber" runat="server" OnClick="btnUpdateImgOrderNumber_Click"
                                                Text="Update" ValidationGroup="g" OnClientClick="return UpdateOder();" />
                                            <asp:Button ID="btnCancelImgOrderNumber" runat="server" CausesValidation="false"
                                                OnClick="btnCancelImgOrderNumber_Click" Text="Cancel" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 25px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </caption>
                            </table>
                        </asp:Panel>
                        <cc1:ModalPopupExtender ID="ModalPopupPublish" runat="server" PopupControlID="pnlPublish"
                            TargetControlID="lblPublish" BackgroundCssClass="modal" CancelControlID="ImageButton2">
                        </cc1:ModalPopupExtender>
                        <asp:Label ID="lblPublish" runat="server"></asp:Label>
                        <asp:Panel ID="pnlPublish" runat="server" Style="display: none;">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                        Publish Content
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" ImageUrl="../../images/popup_close.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <br />
                                        <asp:Label ID="lblPublishError" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-right: 10px;">
                                                    Publish Date :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPublishDate" runat="server" Width="100"></asp:TextBox>
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
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
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
                                                <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="3">
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
                                            <td>
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
                                                Description:
                                                <asp:TextBox ID="txtDesc" runat="server" Text="" TextMode="MultiLine" CssClass="multiline-txtbox"
                                                    placeholder="Say Something about this..." onkeyup="CountMaxLength(this,'Description',event);"
                                                    onChange="CountMaxLength(this,'message',event);" MaxLength="140"></asp:TextBox>
                                                <span>You have
                                                    <asp:Label ID="lblLength" runat="server"></asp:Label>
                                                    characters left.</span><span style="float: right; margin-right: 20px;">(Max Characters
                                                        140)</span>
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
                                                    OnClick="btnShareOnPage_Click" CausesValidation="false" />
                                                <%--onclick="ShareOnPage()"--%>
                                                <%--<input type="button" class="FBpopupBtn" onclick="ShareOnPage()" value="Post Data" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
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
                                <asp:UpdateProgress ID="UpdateProgress9" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosVidepepreviewpopup1" runat="server" ImageUrl="~/images/popup_close.gif"
                                    OnClientClick="ClosePopup();" />
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
        function CountMaxLength(id, text, e) {
            var maxlength = 140;
            if (id.value == "") {
                document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;

                return true;
            }

            var myRegExp = new RegExp(/^[^<&]+$/);   //(/^[a-zA-Z0-9\-\.\'\,]+$/);            
            if (myRegExp.test(id.value)) {
                if (id.value.length > maxlength) {
                    id.value = id.value.substring(0, maxlength);
                    alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
                }
                document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;

                return true;
            }
            else {
                if (e != undefined && (e.keyCode == 8 || e.keyCode == 46)) {
                    //
                }
                else {
                    document.getElementById('<%=txtDesc.ClientID %>').value = id.value.replace(/[&<]/g, '')
                    alert("Please do not enter & and < characters.");
                    return false;
                }
            }
        }
        function LoadEventForPlayVideo() {
            $('.videoclass1').mousedown(function (event) {
                var Url = this.href;
                //alert(1);
                var Iframe = document.getElementById("IframeVideoPopup");
                Iframe.src = "";
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

        function ClosePopup() {
            var Iframe = document.getElementById("IframeVideoPopup");
            Iframe.src = "";
        }

        //Show the Video Preivew
        function PlayVideo(videoUrl) {

            var Iframe = document.getElementById("IframeVideoPopup");

            var videoID = "";
            var playUrl = "";

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

        function Display_FB_Popup() {
            $find('<%=MPEFbPreview.ClientID%>').show();
        }
        function PopupClose() {
            $find('<%=MPEFbPreview.ClientID%>').hide();
        }
        function ValidateCustomModuleMutipleSelection(shareType) {
            var selectedcount = 0;
            var rowIndex = 0;
            var TargetBaseControl = document.getElementById('<%= this.GrdBulletins.ClientID %>');
            var TargetChildControl = "chkBulletinID";
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
                var status = TargetBaseControl.rows[rowIndex].cells[4].childNodes[1].innerHTML;
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
                    if (TargetBaseControl.rows[rowIndex].cells[4].innerHTML.indexOf("(Pending Approval)") != -1)
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
                oauth: true, // Enable oauth authentication
                version: 'v2.1'
            });
        };
        function post_on_wall() {
            $find('<%=MPEFbPreview.ClientID%>').hide();
            var msg = document.getElementById("<%=hdnMessageDes.ClientID%>").value;
            var title = document.getElementById("<%=hdnBulletinTitle.ClientID%>").value;
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
                            alert("Content has been posted successfully.");
                        }
                    });
                }
                else {
                    // *** show message for not logged in *** //
                }
            }, { scope: 'publish_stream' });
        }
        function post_on_page() {
            if (ValidateCustomModuleMutipleSelection())
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
            var title = document.getElementById("<%=hdnBulletinTitle.ClientID%>").value;
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
                                    alert("Content has been posted successfully.");
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
        //        (function (d, s, id) {
        //            var js, fjs = d.getElementsByTagName(s)[0];
        //            if (d.getElementById(id)) { return; }
        //            js = d.createElement(s); js.id = id;
        //            js.src = "//connect.facebook.net/en_US/sdk.js";
        //            fjs.parentNode.insertBefore(js, fjs);
        //        } (document, 'script', 'facebook-jssdk'));
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
        function Printflyer() {
            var NID = document.getElementById("<%=hdnPrintNewsID.ClientID%>").value;
            window.open("PrintNewsletter.aspx?NID=" + NID);
            return false;
        }
        //        function CallJquery() {
        //            document.getElementById('DIDIFrm').innerHTML = "";
        //            document.getElementById('DIDIFrm').innerHTML = "<iframe src=\"https://player.vimeo.com/video/36113051\" width=\"500\" height=\"375\" frameborder=\"0\" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>";
        //            $(document).ready(function () {
        //                $("a.modal1").click(function (e) {
        //                    e.preventDefault();
        //                    //Get the A tag
        //                    var id = $(this).attr('href');
        //                    $(id).fadeTo("slow", 1.0);

        //                });
        //                //if close button is clicked
        //                $('.window .navigate').click(function (e) {
        //                    document.getElementById('DIDIFrm').innerHTML = "";
        //                    $('.window').hide();
        //                });
        //            });
        //        }
        //        var browserName = navigator.appName;
        //        if (browserName != "Microsoft Internet Explorer") {
        //            $(document).ready(function () {
        //                document.getElementById('DIDIFrm').innerHTML = "";
        //                document.getElementById('DIDIFrm').innerHTML = "<iframe src=\"https://player.vimeo.com/video/36113051\" width=\"500\" height=\"375\" frameborder=\"0\" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>";
        //                $("a.modal1").click(function (e) {
        //                    e.preventDefault();
        //                    //Get the A tag
        //                    var id = $(this).attr('href');
        //                    $(id).fadeTo("slow", 1.0);

        //                });
        //                //if close button is clicked
        //                $('.window .navigate').click(function (e) {
        //                    document.getElementById('DIDIFrm').innerHTML = "";
        //                    $('.window').hide();
        //                });
        //            });
        //        }
    </script>
</asp:Content>
