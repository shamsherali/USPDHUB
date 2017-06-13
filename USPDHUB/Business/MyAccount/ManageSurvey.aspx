<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="ManageSurvey.aspx.cs" EnableEventValidation="false" ValidateRequest="false"
    Inherits="USPDHUB.Business.MyAccount.ManageSurvey" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/UcPageSize.ascx" TagName="PageSize" TagPrefix="UcPageSize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
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
            alert("Failure occurs while updating the content order.");
        }
        function SelectAll(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdSurveys.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdSurveys.ClientID %>');
            var TargetChildControl = "chkSurveyID";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[iCount].checked = CheckBox.checked;
            }
        }
        function ValidateNotification(ControlId) {
            var resultItem = ValidateSurvey(ControlId);
            if (resultItem) {
                if (document.getElementById('<%= hdnIsPusblished.ClientID %>').value == "true")
                    return true;
                else
                    alert('You cannot push a private item.');
            }
            return false;
        }
        function ValidateSurvey(ControlId) {
            var id = ControlId.id;
            if (document.getElementById("<%=hdnarchive.ClientID%>").value != "Archive") {
                var selectedcount = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdSurveys.ClientID %>');
                var TargetChildControl = "chkCurrentTabSurveyID";
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

                var multiSelectionMsg = "Multiple selections are not allowed.";

                if (selectedcount == 0) {
                    alert('Please select a Survey/Poll.');
                    return false;
                }
                else if (id.indexOf("lnkPreview") != -1 && selectedcount > 1) {
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
                else if (id.indexOf("lnkArchive") != -1) {
                    return confirm('Are you sure you want to archive selected ' + document.getElementById("<%=hdnSurveyType.ClientID %>").value.toLowerCase() + '(s)?');
                }
                else if (id.indexOf("lnkdelete") != -1) {
                    if (document.getElementById("<%=hdnParticipation.ClientID%>").value != '0')
                        return confirm('Participation in progress. Deleting the ' + document.getElementById("<%=hdnSurveyType.ClientID %>").value.toLowerCase() + ' will delete all the responses. Proceed?');
                    else
                        return confirm('Are you sure you want to delete selected ' + document.getElementById("<%=hdnSurveyType.ClientID %>").value.toLowerCase() + '(s)?');
                }
                else {
                    return true;
                }
            }
            else {
                var selectedcount = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdSurveys.ClientID %>');
                var TargetChildControl = "chkSurveyID";
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
                    alert('Please select a Survey/Poll.');
                    return false;
                }
                else if (selectedcount > 1) {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete selected ' + document.getElementById("<%=hdnSurveyType.ClientID %>").value.toLowerCase() + '(s)?');
                    else if (id.indexOf("lnkChangeCurrent") != -1)
                        return confirm('Are you sure you want to reinstate this ' + document.getElementById("<%=hdnSurveyType.ClientID %>").value.toLowerCase() + '(s)?');
                    else {
                        alert('Please select only one ' + document.getElementById("<%=hdnSurveyType.ClientID %>").value.toLowerCase() + '.');
                        return false;
                    }
                }
                else {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete this ' + document.getElementById("<%=hdnSurveyType.ClientID %>").value.toLowerCase() + '?');
                    else {
                        if (document.getElementById("<%=hdnCommandArg.ClientID%>").value == '') {
                            alert('Please select only one content.');
                            return false;
                        }
                        else {
                            if (id.indexOf("lnkChangeCurrent") != -1)
                                return confirm('Are you sure you want to reinstate this ' + document.getElementById("<%=hdnSurveyType.ClientID %>").value.toLowerCase() + '?');
                            else
                                return true;
                        }
                    }
                }
            }
        }
        function openEmailwindow(url) {
            if (ValidateMultipleSelectionSurvey())
                window.open(url, '', "width=700,height=650,scrollbars=no,toolbars=yes,status=yes,resizable=yes").focus();
        }

        function ValidateMultipleSelectionSurvey() {
            var selectedcount = 0;
            var TargetBaseControl = document.getElementById('<%= this.GrdSurveys.ClientID %>');
            var TargetChildControl = "chkCurrentTabSurveyID";
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
                alert('Please select a Survey/Poll.');
                return false;
            }
            else {
                return true;
            }
        }

        function GetConfirm(text, controlID) {
            if (ValidateSurvey(controlID)) {
                if (text.toLowerCase() == 'publish') {
                    if ('<%= IsScheduleEmails %>' == 'True') {
                        return confirm('Are you sure you want to ' + text + ' selected item(s)?');
                    }
                    else {
                        return confirm('This item will be published immediately; continue?');
                    }
                }

                else
                    return confirm('Are you sure you want to make selected item(s) ' + text + '?');
            } else {
                return false;
            }
        }
        function Showpopup() {
            //document.getElementById("<%=ModalPopupExtender6.ClientID%>").style.display = 'block';
            $find('<%=ModalPopupExtender6.ClientID%>').show();
            return false;
        }
        function TwitterShare(url) {
            if (ValidateMultipleSelectionSurvey())
                window.open(url, '_blank');
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
                                            Manage Surveys</h1>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: red;" align="center">
                                        <asp:Label ID="lblerrormessage1" runat="server"></asp:Label>
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
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
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
                                        <p style="position:absolute;margin-top:9px;">
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
                                <tr>
                                    <td style="color: red;" align="center">
                                        <asp:Label ID="lblerrormessage" runat="server"></asp:Label>
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
                                                                            <asp:GridView ID="GrdSurveys" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                CssClass="datagrid2" OnRowDataBound="GrdSurveys_RowDataBound" AllowPaging="True"
                                                                                OnPageIndexChanging="GrdSurveys_PageIndexChanging" Width="100%" GridLines="None"
                                                                                OnSorting="GrdSurveys_Sorting" PageSize="5" DataKeyNames="Expiration_Date">
                                                                                <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Select">
                                                                                        <ItemTemplate>
                                                                                            <%--  <asp:RadioButton ID="rbSurvey" runat="server" AutoPostBack="true" OnCheckedChanged="rbSurvey_CheckedChanged"
                                                                                                onclick='<%# string.Format("javascript:RadioCheck(this, \"{0}\",\"{1}\")", "", Eval("Survey_ID")) %>' />--%>
                                                                                            <asp:CheckBox ID="chkCurrentTabSurveyID" runat="server" AutoPostBack="true" OnCheckedChanged="rbSurvey_CheckedChanged" />
                                                                                            <asp:Label ID="lblSurveyType" runat="server" Text='<%# Bind("Type_Name") %>' Visible="false"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="20px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <HeaderTemplate>
                                                                                            <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" onclick="SelectAll(this);"
                                                                                                AutoPostBack="true" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkSurveyID" runat="server" AutoPostBack="true" OnCheckedChanged="rbSurvey_CheckedChanged" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="30px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Survey Name" SortExpression="Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkName" runat="server" CausesValidation="false" Text='<%# Bind("Name") %>'
                                                                                                CommandArgument='<%# Bind("Survey_ID") %>' OnClick="lnkName_Click"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="125px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Type_Name" HeaderText="Survey Type" SortExpression="Type_Name">
                                                                                        <HeaderStyle Width="75px"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Status" SortExpression="IsDisplay">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("IsPublished") %>' Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblDisplay" runat="server" Text='<%# Bind("IsDisplay") %>'></asp:Label>
                                                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Dashboard/rep.png" />
                                                                                            <cc1:PopupControlExtender ID="PopupControlExtender1" runat="server" PopupControlID="Panel1"
                                                                                                TargetControlID="Image1" DynamicContextKey='<%# Eval("Survey_ID") + "##SP##"+ Eval("Name") %>'
                                                                                                DynamicControlID="Panel1" DynamicServiceMethod="GetDynamicContent" Position="Bottom">
                                                                                            </cc1:PopupControlExtender>
                                                                                            <br />
                                                                                            <asp:Label ID="lblApprovalStatus" runat="server" Text='<%# Bind("Approval_Status") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="65px"></ItemStyle>
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
                                                                                        <HeaderStyle Width="150px"></HeaderStyle>
                                                                                    </asp:TemplateField>
                                                                                    <%-- <asp:BoundField DataField="Username" HeaderText="Approved</br>Rejected by" HtmlEncode="False"
                                                                                            SortExpression="Username">
                                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            <ItemStyle Width="150px"></ItemStyle>
                                                                                        </asp:BoundField>--%>
                                                                                    <asp:BoundField DataField="Expiration_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Expiration Date"
                                                                                        HtmlEncode="False" SortExpression="Expiration_Date">
                                                                                        <HeaderStyle Width="80px"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Modified_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Updated Date"
                                                                                        HtmlEncode="False" SortExpression="Date">
                                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    No surveys found
                                                                                </EmptyDataTemplate>
                                                                                <HeaderStyle CssClass="title3"></HeaderStyle>
                                                                                <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                                <PagerStyle CssClass="paginationClass" />
                                                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First"
                                                                                    LastPageText="Last" />
                                                                            </asp:GridView>
                                                                            <asp:Panel ID="Panel1" runat="server">
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <asp:HiddenField ID="hdnarchive" runat="server" Value="NoArchive" />
                                                            <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnCommandArg" runat="server" />
                                                            <asp:HiddenField ID="hdnShowButtons" runat="server" />
                                                            <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                                            <asp:HiddenField ID="hdnRowIndex" runat="server" />
                                                            <asp:HiddenField ID="hdnSName" runat="server" />
                                                            <asp:HiddenField ID="hdnParticipation" runat="server" />
                                                            <asp:HiddenField ID="hdnSurveyType" runat="server" />
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
                                                <%if (hdnShowButtons.Value == "1")
                                                  { %>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPreview" runat="server" CausesValidation="false" OnClick="lnkPreview_Click"
                                                                OnClientClick="return ValidateSurvey(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px 5px;"></span>Preview</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnarchive.Value != "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" OnClick="lnkEdit_Click"
                                                                OnClientClick="return ValidateSurvey(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -32px;"></span>Edit</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkSurveyorder" runat="server" CausesValidation="false" OnClick="btnEditOrderNumber_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -221px;"></span>Change Order</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%if (hdnCommandArg.Value != "")
                                                      { %>
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
                                                    <%} %>
                                                    <tr runat="server" id="trSendNotification">
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkNotification" runat="server" CausesValidation="false" OnClick="lnkNotification_Click"
                                                                OnClientClick="return ValidateNotification(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -487px;"></span>Push Notification</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCopy" runat="server" CausesValidation="false" OnClick="lnkCopy_Click"
                                                                OnClientClick="return ValidateSurvey(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -70px;"></span>Copy</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkRename" runat="server" CausesValidation="false" OnClick="lnkRename_Click"
                                                                OnClientClick="return ValidateSurvey(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -522px;"></span>Rename</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <%if (hdnarchive.Value == "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkChangeCurrent" runat="server" CausesValidation="false" OnClick="lnkArchive_Click"
                                                                OnClientClick="return ValidateSurvey(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;"></span>Current</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <%if (hdnarchive.Value != "Archive")
                                                      { %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkArchive" runat="server" CausesValidation="false" OnClick="lnkArchive_Click"
                                                                OnClientClick="return ValidateSurvey(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;"></span>Archive</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkdelete" runat="server" CausesValidation="false" OnClick="lnkdelete_Click"
                                                                OnClientClick="return ValidateSurvey(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -108px;"></span>Delete</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkSurveyReport" runat="server" CausesValidation="false" OnClientClick="return ValidateSurvey(this);"
                                                                OnClick="lnkSurveyReport_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -222px;"></span>Report</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkReports" runat="server" Text="Reports" CausesValidation="false"
                                                                OnClientClick="return ValidateSurvey(this);" OnClick="lnkReports_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -222px;"></span>Reports</asp:LinkButton>
                                                        </td>
                                                    </tr>--%>
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
                                                            <div style="overflow: auto; position: relative; height: 400px">
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
                                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
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
                                                                        <td class="header" align="center" colspan="2">
                                                                            <br />
                                                                            <span>Survey to be copied</span><br />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="header" style="padding-left: 100px; padding-bottom: 10px; padding-top: 20px;"
                                                                            align="right">
                                                                            Enter a new name:
                                                                        </td>
                                                                        <td style="padding-bottom: 10px; padding-top: 20px; padding-left: 5px;">
                                                                            <asp:TextBox ID="txtCampName" runat="server" Width="275"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="reqeditcheck" runat="server" ErrorMessage="Survey name is mandatory."
                                                                                Display="Dynamic" ControlToValidate="txtCampName" ValidationGroup="copy"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td style="padding-left: 5px; padding-bottom: 10px;">
                                                                            <asp:Button ID="btneditcancel" runat="server" Text="Cancel" CausesValidation="false">
                                                                            </asp:Button>&nbsp;&nbsp;
                                                                            <asp:Button ID="btnCopyContinue" runat="server" Text="Continue" OnClick="btnCopyContinue_Click"
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
                                        TargetControlID="lbl2" BackgroundCssClass="modal" CancelControlID="ImageButton4">
                                    </cc1:ModalPopupExtender>
                                    <asp:Panel ID="pnlpopup2" runat="server" Style="display: none;">
                                        <table class="popuptable" cellspacing="0" cellpadding="0" width="500px" border="0">
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="header">
                                                    <div style="float: left; text-align: left; padding: 10px 0px 0px 5px;">
                                                        <asp:Label ID="Label2" runat="server" Text="App Display Order"></asp:Label>
                                                        <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Change Content Order',138,'');">
                                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                    </div>
                                                </td>
                                                <td align="right">
                                                    <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif" />
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
                                                                    DataKeyNames="Survey_ID" ItemPlaceholderID="myItemPlaceHolder">
                                                                    <LayoutTemplate>
                                                                    </LayoutTemplate>
                                                                    <LayoutTemplate>
                                                                        <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <li class="ui-state-default" id='id_<%# Eval("Survey_ID") %>' style="border: 1px solid #ccc;
                                                                            background: #EEEEEE; font-weight: normal; color: #8C8C8C;">
                                                                            <asp:Label ID="lblKey" runat="server" Text='<%#Eval("Survey_ID") %>' Visible="false" />
                                                                            <asp:Label ID="lblOrderThumb" runat="server" />
                                                                            &nbsp&nbsp;&nbsp;
                                                                            <%# Eval("Name")%></li>
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
                                </td>
                            </tr>
                        </table>
                        <cc1:ModalPopupExtender ID="ModalPopupPublish" runat="server" PopupControlID="pnlPublish"
                            TargetControlID="lblPublish" BackgroundCssClass="modal" CancelControlID="ImageButton2">
                        </cc1:ModalPopupExtender>
                        <asp:Label ID="lblPublish" runat="server"></asp:Label>
                        <asp:Panel ID="pnlPublish" runat="server" Style="display: none;">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                        Publish Survey
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
            <div id='dummyChart' style="display: none;">
                <asp:Chart ID="Chart1" runat="server" Width="500px" AntiAliasing="All" BackColor="White">
                    <Titles>
                        <asp:Title ShadowOffset="30" Name="Student Marks" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" LegendStyle="Row">
                        </asp:Legend>
                    </Legends>
                    <Series>
                        <asp:Series IsVisibleInLegend="False" Name="Legend" ChartType="StackedBar" IsValueShownAsLabel="true"
                            LabelFormat="{0:0}%">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="studentChartArea" BackColor="#F0F0F0">
                            <AxisY Maximum="100" Minimum="0" LineColor="#DEDEDE" LineWidth="3">
                                <LabelStyle Format="{0:0}%" />
                                <MajorGrid LineColor="White" />
                            </AxisY>
                            <AxisX LineColor="#DEDEDE" LineWidth="2">
                                <MajorGrid LineColor="White" />
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
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
        </ContentTemplate>
        <%-- <Triggers>
            <asp:PostBackTrigger ControlID="lnkReports" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
