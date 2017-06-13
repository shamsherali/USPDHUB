<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    Inherits="USPDHUB.Business.MyAccount.ManageUpdates" ValidateRequest="false" CodeBehind="ManageUpdates.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <link href="../../css/Jquery-order-ui.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <style type="text/css">
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
    <script type="text/javascript">
        function fnShowMessage(UpdateID) {

            var confrm = confirm('Your content campaign has not been sent yet. Are you sure you want to edit?');
            if (confrm == true) {
                var url = "../../Business/MyAccount/EditUpdate.aspx?Update_ID=" + UpdateID;
                window.location = url;
            }
        }

        function SelectAll(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdbusinessUpdates.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdbusinessUpdates.ClientID %>');
            var TargetChildControl = "chkUpdate";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[iCount].checked = CheckBox.checked;
            }
        }

        function SelectDeSelectHeader(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdbusinessUpdates.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdbusinessUpdates.ClientID %>');
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

    </script>
    <style type="text/css">
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
    <script type="text/javascript">
        function ValidateFlyer(ControlId) {
            var id = ControlId.id;
            if (document.getElementById("<%=hdnarchive.ClientID%>").value != "Archive") {
                if (document.getElementById("<%=hdnCommandArg.ClientID%>").value == '') {
                    alert('Please select an content.');
                    return false;
                }
                else {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete this content?');
                    else if (id.indexOf("lnkArchive") != -1)
                        return confirm('Are you sure you want to archive this content?');
                    else
                        return true;
                }
            }
            else {
                var selectedcount = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdbusinessUpdates.ClientID %>');
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
                    alert('Please select an content.');
                    return false;
                }
                else if (selectedcount > 1) {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete the selected Content?');
                    else {
                        alert('Please select only one update.');
                        return false;
                    }
                }
                else {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete this Content?');
                    else {
                        if (document.getElementById("<%=hdnCommandArg.ClientID%>").value == '') {
                            alert('Please select only one content.');
                            return false;
                        }
                        else {
                            if (id.indexOf("lnkChangeCurrent") != -1)
                                return confirm('Are you sure you want to reinstate this content?');
                            else
                                return true;
                        }
                    }
                }
            }
        }
        function openEmailwindow(url) {
            window.open(url, '', "width=700,height=650,scrollbars=no,toolbars=yes,status=yes,resizable=yes").focus();
        }
        function RadioCheck(rb, UpdateName, UpdateID) {
            RadioCheched = "True";
            var gv = document.getElementById("<%=GrdbusinessUpdates.ClientID%>");
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
        function GetConfirm(text) {
            if (text.toLowerCase() == 'publish')
                return confirm('Are you sure you want to ' + text + ' this?');
            else
                return confirm('Are you sure you want to make this ' + text + '?');
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
                                            Manage Updates</h1>
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
                            <tbody>
                                <tr>
                                    <td>
                                        <h1>
                                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                            <span style="color: Black; font-size: 14px; margin: 0px; padding: 0px; position: absolute;
                                                margin-left: 500px; margin-top: 8px;">
                                                <asp:Label runat="server" ID="lblOn" Visible="false">Displayed on App: <font class="showonapp">On</font></asp:Label>
                                                <asp:Label runat="server" ID="lblOff">Displayed on App: <font class="showoffapp">Off</font></asp:Label>
                                            </span>
                                        </h1>
                                    </td>
                                    <td style="padding-right: 70px">
                                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td align="center" class="navy20" valign="top">
                                        <div id="boxes">
                                            <div id="dialog" class="window">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="right">
                                                            <span class="cursor"><a class="navigate">
                                                                <img src="../../images/popup_close.gif" border="0" />
                                                            </a></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="padding-top: 5px;" valign="top">
                                                            <div id="DIDIFrm">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
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
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabber">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td width="155px">
                                                <asp:LinkButton ID="lnkCurrent" runat="server" OnClick="LnkCurrentClick" CausesValidation="false"
                                                    Text="<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkGetArchive" runat="server" CausesValidation="false" OnClick="LnkGetArchiveClick"
                                                    Text="<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>"></asp:LinkButton>
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
                                                                            <div class="GridDock" id="dvGridWidth">
                                                                                <asp:GridView ID="GrdbusinessUpdates" runat="server" PageSize="5" AllowPaging="True"
                                                                                    OnPageIndexChanging="GrdbusinessUpdates_PageIndexChanging" ForeColor="Black"
                                                                                    EmptyDataText="" OnRowDataBound="GrdbusinessUpdates_RowDataBound" DataKeyNames="UpdateId,Expiration_Date"
                                                                                    GridLines="None" AutoGenerateColumns="False" CssClass="datagrid2" Width="100%"
                                                                                    OnSorting="GrdbusinessUpdates_Sorting" AllowSorting="True">
                                                                                    <EmptyDataRowStyle ForeColor="Red"></EmptyDataRowStyle>
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Image">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblupdatethub" runat="server" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle CssClass="align-center" Width="100px" />
                                                                                            <FooterStyle CssClass="align-center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Select">
                                                                                            <ItemTemplate>
                                                                                                <asp:RadioButton ID="rbUpdate" runat="server" AutoPostBack="true" OnCheckedChanged="RbUpdateCheckedChanged"
                                                                                                    onclick='<%# string.Format("javascript:RadioCheck(this, \"{0}\",\"{1}\")", Eval("UpdateTitle"), Eval("UpdateId")) %>' />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="20px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField>
                                                                                            <HeaderTemplate>
                                                                                                <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" onclick="SelectAll(this);"
                                                                                                    AutoPostBack="true" OnCheckedChanged="ChkSelectAllCheckedChanged" />
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkUpdate" runat="server" AutoPostBack="true" OnCheckedChanged="ChkUpdateCheckedChanged" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="20px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Title" SortExpression="Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkUpdateName" OnClick="LnkUpdateNameClick" Text='<%#Eval("UpdateTitle") %>'
                                                                                                    runat="server" CommandArgument='<%#Eval("UpdateId") %>' CausesValidation="false"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="200px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Campaign Status" SortExpression="Status">
                                                                                            <ItemTemplate>
                                                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td style="border: 0px;" valign="top" nowrap="nowrap">
                                                                                                            <asp:Label ID="lblcam" runat="server" Text='<%# Bind("Sent_Flag") %>'></asp:Label>
                                                                                                            <asp:LinkButton Style="font-weight: bold; color: blue; font-family: verdana; color: #0b689d;"
                                                                                                                ID="lnkruncampaion" OnClick="LblhistroyClick" runat="server" CausesValidation="false"
                                                                                                                Text="Campaign report" CommandArgument='<%# Bind("UpdateId") %>'></asp:LinkButton>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="50px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Username" HeaderText="Approved by" HtmlEncode="False"
                                                                                            SortExpression="Username">
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="UpdateTime" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Posted on"
                                                                                            HtmlEncode="False" SortExpression="UpdateTime">
                                                                                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Status" SortExpression="IsPublic">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("IsDisplay") %>'></asp:Label>
                                                                                                <br />
                                                                                                <asp:Label ID="lblApprovalStatus" runat="server" Style="color: Red; font-size: 11px;"
                                                                                                    Text='<%# Bind("Approval_Status") %>'></asp:Label>
                                                                                                <%--<asp:LinkButton ID="lnkStatus" runat="server" CausesValidation="false" CommandArgument='<%# Bind("UpdateId") %>'
                                                                                                OnClientClick="return Confirmation(this);" OnClick="lnkStatus_Click"></asp:LinkButton>--%>
                                                                                                <asp:Label ID="lnkStatus" runat="server" Visible="false"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Completed" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblisCompleted" runat="server" Text='<%# Bind("IsPublished") %>' Visible="False"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Expiration_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Expiration Date"
                                                                                            HtmlEncode="False" SortExpression="ExpDate">
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                        </asp:BoundField>
                                                                                    </Columns>
                                                                                    <EmptyDataTemplate>
                                                                                        No updates found
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
                                                            <asp:HiddenField ID="hdnURLPath" runat="server" />
                                                            <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                                            <asp:HiddenField ID="hdnLinkShareFB" runat="server" />
                                                            <asp:HiddenField ID="hdnMessageDes" runat="server" />
                                                            <asp:HiddenField ID="hdnUpdateTitle" runat="server" />
                                                            <asp:HiddenField ID="hdnFacebookAppId" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="right" class="rightmenu">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCreate" runat="server" CausesValidation="false" OnClick="LnkCreateClick"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -370px;">
                                                            </span>Create</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnShowButtons.Value == "1")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPreview" runat="server" CausesValidation="false" OnClick="LnkPreviewClick"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px 5px;">
                                                            </span>Preview</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnarchive.Value != "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" OnClick="LnkEditClick"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -32px;">
                                                            </span>Edit</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkupdateorder" runat="server" CausesValidation="false" OnClick="btnEditOrderNumber_Click">
                                                                <span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -221px;"></span>Change Order
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCopy" runat="server" CausesValidation="false" OnClick="LnkCopyClick"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -70px;">
                                                                        </span>Copy</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trPublish">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPublish" runat="server" CausesValidation="false" OnClick="LnkPublishClick"
                                                                OnClientClick="return GetConfirm('publish');"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -407px;">
                                                            </span>Publish</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trUnPublish">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkUnpublish" runat="server" CausesValidation="false" OnClick="LnkUnpublishClick"
                                                                OnClientClick="return GetConfirm('private');"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -450px;">
                                                            </span>Private</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSendNotification">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkNotification" runat="server" CausesValidation="false" OnClick="LnkNotificationClick"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -487px;">
                                                            </span>Push Notification</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkSend" runat="server" OnClick="LnkSendClick" CausesValidation="false"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -147px;">
                                                                </span>Email</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkdelete" runat="server" CausesValidation="false" OnClick="LnkdeleteClick"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -108px;">
                                                            </span>Delete</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnarchive.Value != "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkArchive" runat="server" CausesValidation="false" OnClick="LnkArchiveClick"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;">
                                                                </span>Archive</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%}
                                                      else
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkChangeCurrent" runat="server" CausesValidation="false" OnClick="LnkArchiveClick"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;">
                                                                </span>Current</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr id="CancelCamp" runat="server" visible="false">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCancelCamp" runat="server" OnClick="LnkCancelCampClick" CausesValidation="false"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -263px">
                                                            </span>Cancel Campaign</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkReports" runat="server" Text="Reports" OnClick="LnkReportsClick"
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
                                                                            <asp:Label ID="lblTwitterShare" runat="server"></asp:Label>
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
                                                       {%>
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
                                                                            <a class="cursor" onclick="alert('Please select an content.');">
                                                                                <img src='<%=Page.ResolveClientUrl("~/images/Dashboard/emailnew.gif")%>' title='Share on Email'
                                                                                    width='30' height='38' alt='Share on Email' /></a>
                                                                        </td>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select an content.');">
                                                                                <img src='<%=Page.ResolveClientUrl("~/images/Dashboard/twitternew.gif")%>' alt='Share on Twitter'
                                                                                    title='Share on Twitter' border='0' width='39' height='38' /></a>
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
                                                                            <a class="cursor" onclick="alert('Please select an content.');" style="display: none;">
                                                                                <img src='<%=Page.ResolveClientUrl("~/images/Dashboard/facebooknew.gif")%>' alt='Share on Facebook'
                                                                                    width='55' height='36' title='Share on Facebook' border='0' /></a>
                                                                        </td>
                                                                        <td>
                                                                            <a class="cursor" onclick="alert('Please select an content.');">
                                                                                <img src='<%=Page.ResolveClientUrl("~/images/Dashboard/facebooknew.gif")%>' alt='Share on Facebook'
                                                                                    width='55' height='36' title='Share on Facebook' border='0' /></a> <a class="cursor"
                                                                                        onclick="alert('Please select an content.');" style="display: none;">
                                                                                        <img src='<%=Page.ResolveClientUrl("~/images/Dashboard/PinterestLogo.gif")%>' alt='Pin it on Pinterest'
                                                                                            width='55' height='36' title='Pin it on Pinterest' border='0' /></a>
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
                                                <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Back" OnClick="BtnBackClick"
                                                    CausesValidation="false" />&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server"
                                                        Text="Dashboard" OnClick="BtnCancelClick" CausesValidation="false" />
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
                                                                            <asp:ImageButton ID="imglogin1" OnClick="ImcloseClick" runat="server" CausesValidation="false"
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
                                                                            <asp:GridView ID="grdschemail" runat="server" PageSize="10" AllowPaging="True" OnPageIndexChanging="GrdschemailPageIndexChanging"
                                                                                OnRowDataBound="GrdschemailRowDataBound" AutoGenerateColumns="False" CssClass="datagrid2"
                                                                                Width="100%">
                                                                                <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                                <Columns>
                                                                                    <asp:TemplateField Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("UpdateId") %>'></asp:Label>
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
                                                                                OnClick="BtnstopcampainClick" runat="server" Text="Cancel Campaign" CausesValidation="false">
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
                                                            <asp:ImageButton ID="imglogin5" OnClick="ImcloseClick" runat="server" CausesValidation="false"
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
                                        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblc1" runat="server"></asp:Label>
                                        <cc1:ModalPopupExtender ID="ModalPopupExtender6" runat="server" BackgroundCssClass="modal"
                                            PopupControlID="pnleditnews" TargetControlID="lblc1" CancelControlID="imglogin3">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel Style="display: none" ID="pnleditnews" runat="server" Width="100%">
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
                                                                            <asp:ImageButton ID="imglogin3" OnClick="ImcloseClick" runat="server" CausesValidation="false"
                                                                                ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
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
                                                                        <td class="header" align="center" colspan="2">
                                                                            <br />
                                                                            <span>Content to be copied</span><br />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="header" style="padding-left: 100px; padding-bottom: 10px; padding-top: 20px;"
                                                                            align="right">
                                                                            Enter a new name:
                                                                        </td>
                                                                        <td style="padding-bottom: 10px; padding-top: 20px; padding-left: 5px;">
                                                                            <asp:TextBox ID="txtCampName" runat="server" Width="275"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="reqeditcheck" runat="server" ErrorMessage="Content name is mandatory."
                                                                                Display="Dynamic" ControlToValidate="txtCampName"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td style="padding-left: 5px; padding-bottom: 10px;">
                                                                            <asp:Button ID="btneditcancel" runat="server" Text="Cancel" CausesValidation="false">
                                                                            </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:Button ID="BtneditTemplate" runat="server" Text="Continue" OnClick="BtneditTemplate_Click">
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
                                                                            Update History <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
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
                                                                                AutoGenerateColumns="False" OnRowDataBound="GrdviewsenthisRowDataBound" PageSize="15"
                                                                                AllowPaging="True" OnPageIndexChanging="GrdviewsenthisPageIndexChanging">
                                                                                <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="Receiver_EmailID" HeaderText="Email IDs" />
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
                                        <%--suneel--%>
                                        <cc1:ModalPopupExtender ID="ModalPopupImgOrderNo" runat="server" PopupControlID="pnlpopup2"
                                            TargetControlID="lbl2" BackgroundCssClass="modal" CancelControlID="ImageButton8">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel ID="pnlpopup2" runat="server" Style="display: none;">
                                            <table class="popuptable" cellspacing="0" cellpadding="0" width="500px" border="0">
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
                                                            <ProgressTemplate>
                                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="header">
                                                        <div style="float: left; text-align: left; padding: 10px 0px 0px 5px;">
                                                            <asp:Label ID="Label3" runat="server" Text="App Display Order"></asp:Label>
                                                            <%--<a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Change Bulletin Order',138,'');">
                                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>--%>
                                                        </div>
                                                    </td>
                                                    <td align="right">
                                                        <asp:ImageButton ID="ImageButton8" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif" />
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
                                                    <tr>
                                                        <td colspan="2">
                                                            <div id="Div1" style="height: 300px; overflow-y: auto; border: solid 1px #ccc; padding-top: 5px;">
                                                                <ul id="sortable">
                                                                    <asp:ListView ID="OrderListView" OnItemDataBound="OrderListView_ItemDataBound" runat="server"
                                                                        DataKeyNames="UpdateId" ItemPlaceholderID="myItemPlaceHolder">
                                                                        <LayoutTemplate>
                                                                        </LayoutTemplate>
                                                                        <LayoutTemplate>
                                                                            <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                                        </LayoutTemplate>
                                                                        <ItemTemplate>
                                                                            <li class="ui-state-default" id='id_<%# Eval("UpdateId") %>' style="border: 1px solid #ccc;
                                                                                background: #EEEEEE; font-weight: normal; color: #8C8C8C;">
                                                                                <asp:Label ID="lblKey" runat="server" Text='<%#Eval("UpdateId") %>' Visible="false" />
                                                                                <asp:Label ID="lblOrderThumb" runat="server" />
                                                                                &nbsp&nbsp;&nbsp;
                                                                                <%# Eval("UpdateTitle")%></li>
                                                                        </ItemTemplate>
                                                                    </asp:ListView>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td style="padding-top: 10px; padding-left: 120px;">
                                                            <asp:Button ID="btnUpdateImgOrderNumber" runat="server" OnClick="btnUpdateImgOrderNumber_Click"
                                                                Text="Update" OnClientClick="return UpdateOder();" />
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
                                        <%--Suneel--%>
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
                                                        <asp:Button ID="btnPublish" runat="server" OnClick="BtnPublishClick" Text="Update"
                                                            ValidationGroup="SV" />
                                                        <asp:Button ID="btnPublishCancel" runat="server" CausesValidation="false" OnClick="BtnPublishCancelClick"
                                                            Text="Cancel" />
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
                                                            <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                                                <ProgressTemplate>
                                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-right: 05px; padding-top: 05px" align="right">
                                                            <asp:ImageButton ID="imgPopupClose" OnClick="ImcloseClick" runat="server" CausesValidation="false"
                                                                ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
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
                                                            Select your page to share :
                                                            <select id="thebox" class="FbPagesList">
                                                            </select>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-right: 10px; padding-bottom: 20px" align="center">
                                                            <input type="button" class="FBpopupBtn" onclick="ShareOnPage()" value="Post Data" />
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
            alert("Failure occurs while updating the content order.");
        }
    </script>
    <script type="text/javascript">
        function Display_FB_Popup() {
            $find('<%=MPEFbPreview.ClientID%>').show();
        }
        function PopupClose() {
            $find('<%=MPEFbPreview.ClientID%>').hide();
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
            var title = document.getElementById("<%=hdnUpdateTitle.ClientID%>").value;
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
            var title = document.getElementById("<%=hdnUpdateTitle.ClientID%>").value;
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
    </script>
    <!--Facebook Share END -->
    <script type="text/javascript">
        function CallJquery() {
            document.getElementById('DIDIFrm').innerHTML = "";
            document.getElementById('DIDIFrm').innerHTML = "<iframe src=\"https://player.vimeo.com/video/36113094\" width=\"500\" height=\"340\" frameborder=\"0\" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>";
            $(document).ready(function () {
                $("a.modal1").click(function (e) {
                    e.preventDefault();
                    //Get the A tag
                    var id = $(this).attr('href');
                    $(id).fadeTo("slow", 1.0);

                });
                //if close button is clicked
                $('.window .navigate').click(function (e) {
                    document.getElementById('DIDIFrm').innerHTML = "";
                    $('.window').hide();
                });
            });
        }
        var browserName = navigator.appName;
        if (browserName != "Microsoft Internet Explorer") {
            $(document).ready(function () {
                document.getElementById('DIDIFrm').innerHTML = "";
                document.getElementById('DIDIFrm').innerHTML = "<iframe src=\"https://player.vimeo.com/video/36113094\" width=\"500\" height=\"375\" frameborder=\"0\" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>";
                $("a.modal1").click(function (e) {
                    e.preventDefault();
                    //Get the A tag
                    var id = $(this).attr('href');
                    $(id).fadeTo("slow", 1.0);

                });
                //if close button is clicked
                $('.window .navigate').click(function (e) {
                    document.getElementById('DIDIFrm').innerHTML = "";
                    $('.window').hide();
                });
            });
        }
    </script>
</asp:Content>
