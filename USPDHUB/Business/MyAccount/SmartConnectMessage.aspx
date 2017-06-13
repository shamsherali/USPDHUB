<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="SmartConnectMessage.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SmartConnectMessage"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/UcPageSize.ascx" TagName="PageSize" TagPrefix="UcPageSize" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../Scripts/autopopulatedbox/sol.js" type="text/javascript"></script>
    <link href="../../css/Jquery-order-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../css/autopopulatedbox/sol.css" rel="stylesheet" type="text/css" />
    <link href="../../css/SmartConnectStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
    </style>
    <script type="text/javascript">
        function GetSelectedCategory() {
        }
        function SelectAllPublicCalls(headerchk) {
            var grdPublicCalls = document.getElementById('<%=grdPublicCallHistory.ClientID%>');
            var i;
            if (headerchk.checked) {
                for (i = 0; i < grdPublicCalls.rows.length; i++) {
                    var inputs = grdPublicCalls.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
            }
            else {
                for (i = 0; i < grdPublicCalls.rows.length; i++) {
                    var inputs = grdPublicCalls.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        function SelectPubliccheckboxes(header) {
            var count = 0;
            var rowcount = 0;
            var grdPublicCalls = document.getElementById('<%= this.grdPublicCallHistory.ClientID %>');
            var headerchk = document.getElementById(header);
            var Inputs = grdPublicCalls.getElementsByTagName("input");
            var itemCheckBox = "chkPublicCalls";
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox'
                    && Inputs[n].id.indexOf(itemCheckBox, 0) >= 0) {
                    if (Inputs[n].checked)
                        count++;
                    rowcount++;
                }
            }
            if (count == rowcount) {
                headerchk.checked = true;
            }
            else {
                headerchk.checked = false;
            }

        }


        function ValidateMessageTitle(ControlId) {
            var id = ControlId.id;
            if (document.getElementById("<%=hdnarchive.ClientID%>").value != "Archive") {
                var selectedcount = 0;
                var rowIndex = 0;
                var TargetBaseControl = document.getElementById('<%= this.grdPublicCallHistory.ClientID %>');
                var TargetChildControl = "chkPublicCalls";
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
                    alert('Please select at least one Message.');
                    return false;
                }
                else {
                    var multiSelectionMsg = "Multiple selections are not allowed.";

                    if (id.indexOf("lnkView") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    }
                    else if (id.indexOf("lnkAssign") != -1 && selectedcount > 1) {
                        alert(multiSelectionMsg);
                        return false;
                    }
                    else if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete the selected message(s)?');
                    else if (id.indexOf("lnkArchive") != -1)
                        return confirm('Are you sure you want to archive the selected message(s)?');
                    return true;
                }
            }
            else {
                var selectedcount = 0;
                var TargetBaseControl = document.getElementById('<%= this.grdPublicCallHistory.ClientID %>');
                var TargetChildControl = "chkPublicCalls";
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
                    alert('Please select at least one Message.');
                    return false;
                }
                else if (selectedcount > 1) {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete the selected message(s)?');
                    else if (id.indexOf("lnkChangeCurrent") != -1)
                        return confirm('Are you sure you want to reinstate this title(s)?');
                    else {
                        alert('Please select only one Message.');
                        return false;
                    }
                }
                else {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete this message(s)?');
                    else {
                        if (document.getElementById("<%=hdnCommandArg.ClientID%>").value == '') {
                            alert('Please select only one Message.');
                            return false;
                        }
                        else {
                            if (id.indexOf("lnkChangeCurrent") != -1)
                                return confirm('Are you sure you want to reinstate this message(s)?');
                            else
                                return true;
                        }
                    }
                }
            }
        }
        function ShowExportPopUp() {
            document.getElementById("<%=chkArchiveExport.ClientID%>").checked = false;
            document.getElementById("<%=chkGraph.ClientID%>").checked = false;
            document.getElementById('<%=chkExportAll.ClientID%>').checked = false;
            var cblist = document.getElementById('<%=chkExportList.ClientID%>');
            var inputs = cblist.getElementsByTagName("input");
            for (i = 0; i < inputs.length; i++) {
                inputs[i].checked = false;
            }
            $find("exportPopup").show();
            return false;
        }
        function HideExportPopUp() {
            $find("exportPopup").hide();
            return true;
        }
        function HideAssignPopUp() {
            if (Page_ClientValidate('AssignValidate')) {
                $find("assignPopup").hide();
                return true;
            }
            else {
                return false;
            }
        }

        function DateValidation() {

            if (Page_ClientValidate('VG')) {
                $("#<%=hdnSelectCategoryID.ClientID %>").val($('#my-selectCategory').val());
                var array_of_SalesGroup = $('#my-selectCategory').searchableOptionList().getSelection().map(function () {
                    return this.value;
                }).get();

                $("#<%=hdnresult.ClientID %>").val(array_of_SalesGroup);

                var selMulti = $.map($("#my-selectCategory option:selected"), function (el, i) {
                    return $(el).text();
                });
                var str = selMulti.join(", ");

                document.getElementById('<%=hdnResultCategory.ClientID%>').value = str;

                var startVal = document.getElementById('<%=txtStartDate.ClientID%>').value;
                var endVal = document.getElementById('<%=txtEndDate.ClientID%>').value;
                var ErrMsg = "";
                if (startVal != '' && endVal == '')
                    ErrMsg = ErrMsg + "Please select the To Date";
                if (startVal == '' && endVal != '')
                    ErrMsg = ErrMsg + "Please select the From Date";
                if (startVal != '' && endVal != '') {

                    var startDt = new Date(startVal);
                    var endDt = new Date(endVal);
                    startDt = new Date(startDt);
                    endDt = new Date(endDt);

                    if (!(startDt <= endDt))
                        ErrMsg = ErrMsg + "To Date should be always later than or equal to From Date.";
                }
                if (ErrMsg == "") {

                    return true;
                }
                else {
                    alert(ErrMsg);
                }

            }
            return false;

        }
        function checkBlockSenders(frm) {
            var result = false;
            for (i = 0; i < frm.length; i++) {
                if (frm.elements[i].name.indexOf("chkPublicCalls") != -1) {
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
            }
            var msg = '';
            if (result) {
                msg = 'Are you sure you want to block selected senders?';
                return confirm(msg);
            }
            else {
                msg = 'Please select at least one checkbox to block senders.';
                alert(msg);
                return false;
            }
        }
        $(document).ready(function () {
            LoadControls();
            AssignSlectedValues();

        });
        function GetCategory() {

            var categoryNamesString = $("#<%=hdnCategory.ClientID %>").val();
            var categoryIDsString = $("#<%=hdnCategoryID.ClientID %>").val();

            document.getElementById("my-selectCategory").options.length = 0;
            document.getElementById("my-selectCategory").focus();

            var list = categoryNamesString.split(',');
            var list1 = categoryIDsString.split(',');

            for (i = 0; i < list.length; i++) {
                $('#my-selectCategory').append($("<option></option>").attr("value", list1[i]).text(list[i]));
            }

        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            LoadControls();
            GetCategory();
            AssignSlectedValues();



        });
        function Isimage(lnk) {
            var ImageAvail = lnk.innerText;
            if (ImageAvail == 'No') {
                alert("Image is not available");
                return false;
            }

        }

        function LoadControls() {

            // initialize sol
            $('#my-selectCategory').searchableOptionList({
                showSelectAll: true
            });

        }

        function AssignSlectedValues() {

            if ($('#<%= hdnresult.ClientID %>').val() != '') {
                var selected = $('#<%= hdnresult.ClientID %>').val().split(",");
                $("#my-selectCategory > option ").each(function () {
                    if ($.inArray(this.value, selected) > -1) {
                        $(this).attr("selected", "selected");

                    }

                });

                // $('#my-selectCategory').multiselect('refresh');
            }

        }



        function DisplayUnread(chkValue) {

            var chk = "";
            if (chkValue.checked) {

                chk = " IsChecked='True' ";

            }
            else {
                chk = " IsChecked='False' ";
            }
            XMLString = "<SmartConnectMessage " + chk + " /> ";
            document.getElementById("<%=hdnDisplayRead.ClientID %>").value = XMLString;
            $("#<%=hdnSelectCategoryID.ClientID %>").val($('#my-selectCategory').val());
            var array_of_SalesGroup = $('#my-selectCategory').searchableOptionList().getSelection().map(function () {
                return this.value;
            }).get();

            $("#<%=hdnresult.ClientID %>").val(array_of_SalesGroup);
        }
        function CheckAll(headerchk) {

            var cblist = document.getElementById('<%=chkExportList.ClientID%>');
            var inputs = cblist.getElementsByTagName("input");

            if (headerchk.checked) {
                for (i = 0; i < inputs.length; i++) {
                    inputs[i].checked = true;
                }
            }
            else {
                for (i = 0; i < inputs.length; i++) {
                    inputs[i].checked = false;
                }
            }
        }
        function UnCheckAll() {

            var flag = 0;
            var cblist = document.getElementById('<%=chkExportList.ClientID%>');
            var rowCount = cblist.getElementsByTagName("input").length;
            var inputs = cblist.getElementsByTagName("input");
            for (i = 0; i < rowCount; i++) {

                if (inputs[i].checked == true) {
                    flag = 1;
                }
                else {
                    flag = 0;
                    break;
                }

            }

            if (flag == 0)
                document.getElementById('<%=chkExportAll.ClientID%>').checked = false;
            else
                document.getElementById('<%=chkExportAll.ClientID%>').checked = true;
        }

    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
            <asp:PostBackTrigger ControlID="btnDownload" />
        </Triggers>
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
                                        </h1>
                                    </td>
                                </tr>
                                <!--Processing.. -->
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b style="color: #0a59a9;">Filter Options:</b>
                                        <h2>
                                            <table cellspacing="3" cellpadding="3" width="100%" border="0">
                                                <!--Categories Block and Search Text including Dates Block -->
                                                <tr>
                                                    <td align="left">
                                                        Category:
                                                        <div style="">
                                                            <select id="my-selectCategory" name="character" multiple="multiple" style="width: 300px;">
                                                            </select>
                                                        </div>
                                                        <asp:HiddenField runat="server" ID="hdnCategory" />
                                                        <asp:HiddenField runat="server" ID="hdnCategoryID" />
                                                        <asp:HiddenField runat="server" ID="hdnSelectCategoryID" />
                                                        <asp:HiddenField runat="server" ID="hdnresult" />
                                                        <asp:HiddenField runat="server" ID="hdnDisplayRead" />
                                                        <asp:HiddenField runat="server" ID="hdnResultCategory" />
                                                        <asp:HiddenField runat="server" ID="hdnMessageId" />
                                                        <asp:HiddenField runat="server" ID="hdnSearchDates" />
                                                    </td>
                                                    <td style="vertical-align: bottom;">
                                                        Message/Reference ID:&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtSearchMsg" runat="server" placeholder="Message/Reference ID"
                                                            Width="160px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkDisplayUnread" runat="server" Text="Display Unread First" OnCheckedChanged="chkDisplayUnread_CheckedChanged"
                                                            onclick="DisplayUnread(this);" AutoPostBack="true" />
                                                    </td>
                                                    <td class="filtertd">
                                                        From Date:&nbsp;
                                                        <asp:TextBox ID="txtStartDate" runat="server" Width="160px" placeholder="From Date"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtStartDate"
                                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                            ValidationGroup="VG" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                        <cc1:CalendarExtender ID="calStart" runat="server" Enabled="True" TargetControlID="txtStartDate"
                                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                        &nbsp;&nbsp;&nbsp;To Date:&nbsp;
                                                        <asp:TextBox ID="txtEndDate" runat="server" Width="160px" placeholder="To Date"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"
                                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                            ValidationGroup="VG" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                                        <cc1:CalendarExtender ID="calEnd" runat="server" TargetControlID="txtEndDate" Format="MM/dd/yyyy"
                                                            CssClass="MyCalendar" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="true" OnClick="btnSearch_Click"
                                                            OnClientClick="return DateValidation();" ValidationGroup="VG" class="SearchButton" />
                                                        &nbsp;&nbsp;
                                                        <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="false" OnClick="btnClear_Click"
                                                            class="CancelButton" />
                                                        &nbsp;&nbsp;
                                                        <%if (hdnarchive.Value != "Archive")
                                                          { %>
                                                        <asp:LinkButton ID="lnkExport" runat="server" Text="Export" CausesValidation="false"
                                                            OnClientClick="return ShowExportPopUp();" CssClass="ExportButton">Export</asp:LinkButton>&nbsp;&nbsp;
                                                        <%} %>
                                                        <asp:LinkButton ID="lnkShowGraph" runat="server" CausesValidation="false" OnClick="lnkShowGraph_Click"
                                                            CssClass="ExportButton">Show Graph</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </h2>
                                    </td>
                                    <!--Serach Button Block -->
                                    <td valign="bottom" align="right">
                                        <table border="0" cellpadding="0" cellspacing="10">
                                        </table>
                                    </td>
                                    <!--Read and UnRead Block -->
                                    <td valign="bottom" align="right">
                                        <table border="0" cellpadding="0" cellspacing="10">
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <br />
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td style="color: green; font-weight: bold; font-size: medium;" align="center">
                                        <asp:Label ID="lblmess" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
                            <%--  <tr>
                                <td align="right">
                                    <p style="margin-top: -34px; float: right; font-weight: bold; font-size: 15px; margin-right: 15%;">
                                        View As:</p>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="position: relative;">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td width="155px">
                                                <asp:LinkButton ID="lnkCurrent" runat="server" OnClick="lnkCurrent_Click" CausesValidation="false"
                                                    Text="<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkGetArchive" runat="server" OnClick="lnkGetArchive_Click" CausesValidation="false"
                                                    Text="<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>"></asp:LinkButton>
                                            </td>
                                            <td align="right">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: -14px;">
                                                    <tr>
                                                        <td align="right">
                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-right: 10px; float: right;">
                                                                            Page Size
                                                                            <ucpagesize:pagesize id="PageSizes" runat="server" />
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <div style="height: 27px; background-color: #d2e5fa; width: 27px;">
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        Unread
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <div style="height: 25px; background-color: #FFFFFF; width: 27px; border: 1px solid">
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        Read
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <%--     <td>
                                                                        <asp:LinkButton ID="lnkListView" runat="server" OnClick="lnkListView_Click" CausesValidation="false"
                                                                            Text="<img src='../../Images/Dashboard/list_h.png' title='List' border='0'/>"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkGraph" runat="server" CausesValidation="false" OnClick="lnkGraph_Click"
                                                                            Text="<img src='../../Images/Dashboard/graph.png' title='Graph' border='0' style='margin-left: -3px;'/>"></asp:LinkButton>
                                                                    </td>--%>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Panel runat="server" Visible="true" ID="pnlList">
                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <!--ListView Block -->
                                                <td class="content" colspan="2">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td class="leftmenu">
                                                                <!--SmartConnect Message Block -->
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                                                                <tr>
                                                                                    <td style="padding: 0px;">
                                                                                        <div class="GridDock" id="dvGridWidth" style="border: 1px solid #428ad7;">
                                                                                            <asp:HiddenField ID="hdnGvPageIndex" runat="server" />
                                                                                            <asp:GridView ID="grdPublicCallHistory" runat="server" DataKeyNames="CallAddOnsHistoryID"
                                                                                                Width="2200px" AllowSorting="true" AutoGenerateColumns="False" AllowPaging="true"
                                                                                                OnPageIndexChanging="grdPublicCallHistory_PageIndexChanging" OnRowDataBound="grdPublicCallHistory_RowDataBound"
                                                                                                CssClass="datagrid2" OnSorting="grdPublicCallHistory_Sorting" PageSize="5">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField>
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="chkSelectAllPublicCalls" runat="server" Text="Select All" onclick="SelectAllPublicCalls(this);" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chkPublicCalls" runat="server" OnCheckedChanged="chkPublicCalls_CheckedChanged"
                                                                                                                AutoPostBack="true" />
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="100px" />
                                                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Reference Id" SortExpression="ReferID">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblRefID" runat="server" Text='<%# "SC" +Eval("ReferenceID").ToString() %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="82px" />
                                                                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="100px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <%-- <asp:BoundField DataField="ReferenceID" HeaderText="Reference ID" ItemStyle-Width="82px"
                                                                                                        HeaderStyle-Width="91px" SortExpression="ReferID" />--%>
                                                                                                    <asp:TemplateField HeaderText="Message">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkPublicCall" runat="server" Text='<%#Eval("CustomPredefinedMessage") %>'
                                                                                                                CommandArgument='<%# Eval("CallAddOnsHistoryID")%>' OnClick="lnkView_Click"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="180px" />
                                                                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <%--<asp:BoundField DataField="Email_Subject" HeaderText="Subject" ItemStyle-Width="250px" />--%>
                                                                                                    <asp:TemplateField HeaderText="Image">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkImage" runat="server" Text='<%# Eval("ImageName") != "" ? "Yes" : "No" %>'
                                                                                                                CommandArgument='<%# Eval("CallAddOnsHistoryID")%>' CommandName='<%# Eval("ImageName")%>'
                                                                                                                OnClientClick="return Isimage(this);" OnClick="lblImage_Click"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="150px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <%--   <asp:TemplateField HeaderText="Contact Information">
                                                                                                        <ItemTemplate>
                                                                                                            Name:
                                                                                                            <asp:Label ID="lblCName" runat="server" Text='<%#Eval("ContactName") %>'></asp:Label><br />
                                                                                                            Email:
                                                                                                            <asp:Label ID="lblCEmail" runat="server" Text='<%#Eval("ContactEmail") %>'></asp:Label><br />
                                                                                                            Ph:
                                                                                                            <asp:Label ID="lblCPhone" runat="server" Text='<%#Eval("ContactPhoneNumber") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="250px" />
                                                                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                                                                    </asp:TemplateField>--%>
                                                                                                    <asp:BoundField DataField="ContactName" HeaderText="Contact Name" ItemStyle-Width="150px" />
                                                                                                    <asp:BoundField DataField="ContactEmail" HeaderText="Contact Email" ItemStyle-Width="150px" />
                                                                                                    <asp:BoundField DataField="ContactPhoneNumber" HeaderText="Contact Phone Number"
                                                                                                        ItemStyle-Width="170px" />
                                                                                                    <%-- <asp:TemplateField HeaderText="Location">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("CurrentLocation") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="180px" />
                                                                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                                                                    </asp:TemplateField>--%>
                                                                                                    <asp:TemplateField HeaderText="Street Address" ItemStyle-Width="150px">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblAddress1" runat="server" Text='<%# Eval("AddressLine1") %>'></asp:Label>
                                                                                                            <asp:Label ID="lblAddress2" runat="server" Text='<%# Eval("AddressLine2") %>'></asp:Label>
                                                                                                            <itemstyle horizontalalign="Left" font-size="12px" width="400px" />
                                                                                                            <headerstyle horizontalalign="Center" font-size="12px" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="City" HeaderText="City" ItemStyle-Width="100px" />
                                                                                                    <asp:BoundField DataField="State" HeaderText="State" ItemStyle-Width="100px" />
                                                                                                    <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" ItemStyle-Width="100px" />
                                                                                                    <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="100px" />
                                                                                                    <asp:BoundField DataField="RepliedDate" HeaderText="Replied Date" ItemStyle-Width="150px" />
                                                                                                    <%--   <asp:BoundField DataField="Notes" HeaderText="Notes" ItemStyle-Width="550px" />--%>
                                                                                                    <asp:TemplateField HeaderText="Notes">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblNotes" runat="server" Text='<%# Eval("Notes") %>'></asp:Label>
                                                                                                            <br />
                                                                                                            <asp:LinkButton ID="lnkReadMore" CommandArgument='<%# Eval("CallAddOnsHistoryID")%>'
                                                                                                                runat="server" Visible='<%# SetVisibility(Eval("Notes"),50) %>' OnClick="lnkView_Click"><font color="Orange"><b>Click to View</b></font> </asp:LinkButton>
                                                                                                            <itemstyle horizontalalign="Left" font-size="12px" width="300px" />
                                                                                                            <headerstyle horizontalalign="Center" font-size="12px" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Notes" Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Literal ID="ltFullNotes" runat="server" Text='<%# Eval("FullNotes") %>'></asp:Literal>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="NotesByUser" HeaderText="Replied By" ItemStyle-Width="150px" />
                                                                                                    <asp:TemplateField HeaderText="Button Title">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="170px" />
                                                                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="CategoryName" HeaderText="Category" ItemStyle-Width="100px" />
                                                                                                    <asp:TemplateField Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblpubliccallflag" runat="server" Text='<%#Eval("isRead") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="170px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="CreatedDate" HeaderText="Date Sent" SortExpression="DateSent"
                                                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="180px" />
                                                                                                    <asp:BoundField DataField="CreatedDate" HeaderText="Time Sent" SortExpression="DateSent"
                                                                                                        DataFormatString="{0:hh:mm tt}" ItemStyle-Width="130px" />
                                                                                                    <asp:BoundField DataField="IsBlocked" HeaderText="Device Blocked" ItemStyle-Width="150px" />
                                                                                                    <asp:BoundField DataField="StatusArchive" HeaderText="Status" ItemStyle-Width="160px"
                                                                                                        Visible="false" />
                                                                                                </Columns>
                                                                                                <EmptyDataTemplate>
                                                                                                    <asp:Label ID="lblBUempty" runat="server" Text="There are no messages at this time."
                                                                                                        Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                                                                </EmptyDataTemplate>
                                                                                                <HeaderStyle CssClass="title1" />
                                                                                                <PagerStyle CssClass="paginationClass" />
                                                                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First" LastPageText="Last" />
                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                    </td>
                                                                                    <asp:HiddenField ID="hdnPubicCallSortCount" runat="server"></asp:HiddenField>
                                                                                    <asp:HiddenField ID="hdnPubicCallSortDir" runat="server"></asp:HiddenField>
                                                                                </tr>
                                                                            </table>
                                                                            <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                                            <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                                            <asp:HiddenField ID="hdnCommandArg" runat="server" />
                                                                            <asp:HiddenField ID="hdnarchive" runat="server" />
                                                                            <asp:HiddenField ID="hdnRowIndex" runat="server" />
                                                                            <asp:HiddenField ID="hdnSelectedMsgHistoryId" runat="server" />
                                                                            <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                                                            <asp:HiddenField ID="hdnType" runat="server" Value="1" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="rightmenu">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                    <%if (hdnarchive.Value != "Archive")
                                                                      { %>
                                                                    <tr>
                                                                        <td class="rightLinks">
                                                                            <asp:LinkButton ID="lnkView" runat="server" CausesValidation="false" OnClientClick="return ValidateMessageTitle(this);"
                                                                                OnClick="lnkView_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px 5px;"></span>View/Reply</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <%} %>
                                                                    <%if (hdnarchive.Value == "Archive")
                                                                      { %>
                                                                    <tr>
                                                                        <td class="rightLinks">
                                                                            <asp:LinkButton ID="lnkChangeCurrent" runat="server" CausesValidation="false" OnClick="lnkArchive_Click"
                                                                                OnClientClick="return ValidateMessageTitle(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;"></span>Current</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <%} %>
                                                                    <%if (hdnarchive.Value != "Archive")
                                                                      { %>
                                                                    <tr>
                                                                        <td class="rightLinks">
                                                                            <asp:LinkButton ID="lnkArchive" runat="server" CausesValidation="false" OnClick="lnkArchive_Click"
                                                                                OnClientClick="return ValidateMessageTitle(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -183px;"></span>Archive</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <%} %>
                                                                    <tr>
                                                                        <td class="rightLinks">
                                                                            <asp:LinkButton ID="lnkdelete" runat="server" CausesValidation="false" OnClick="lnkdelete_Click"
                                                                                OnClientClick="return ValidateMessageTitle(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -108px;"></span>Delete</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <%if (hdnarchive.Value != "Archive")
                                                                      { %>
                                                                    <tr>
                                                                        <td class="rightLinks">
                                                                            <asp:LinkButton ID="lnkAssign" runat="server" CausesValidation="false" OnClick="lnkAssign_Click"
                                                                                OnClientClick="return ValidateMessageTitle(this);" ToolTip="Change Category"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -147px;"></span>
                                                                                Change Category</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <%} %>
                                                                    <tr>
                                                                        <td class="rightLinks">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td align="right" style="padding-right: 5px;" colspan="2">
                                                    <br />
                                                    <span class="couponcode">
                                                        <img border="0" src="../../images/Dashboard/new.png" />
                                                        <span class="coupontooltip" style="margin: -132px 10px 0px 500px;">If you receive prank
                                                            or abusive messages you have the ability to block the messages sent from that particular
                                                            device. Blocked users will still be able to use your App but are unable to send
                                                            messages.</span> </span>
                                                    <asp:Button ID="btnBlockUsers" runat="server" Text="Block Sender" OnClick="btnBlockUsers_Click"
                                                        Visible="false" OnClientClick="return checkBlockSenders(this.form);" Style="display: none;" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <%--<asp:Panel runat="server" Visible="false" ID="pnlGraph" Style="border: solid 1px #d5d5d5;">
                                        <div style="float: right; margin-right: 40px; margin-top: 24px;">
                                            <asp:Button runat="server" ID="btnPrint" Text="Print" Width="70px" OnClick="btnPrint_OnClick" />
                                            &nbsp;&nbsp;<asp:Button runat="server" ID="btnDownload" Text="Download" Width="70px"
                                                Style="text-align: center; padding-left: 3px;" OnClick="btnDownload_OnClick" />
                                        </div>
                                        <div class="app-chart chart-one">
                                            <asp:Chart ID="chartAppUsage" runat="server" BorderlineWidth="0" Height="340px" Width="600px">
                                                <Titles>
                                                    <asp:Title ShadowOffset="30" />
                                                </Titles>
                                                <Legends>
                                                    <asp:Legend Font="Microsoft Sans Serif, 10pt" Alignment="Near" Docking="Right" LegendStyle="Column">
                                                    </asp:Legend>
                                                </Legends>
                                                <ChartAreas>
                                                    <asp:ChartArea Name="UsageChartArea" BackColor="white">
                                                    </asp:ChartArea>
                                                </ChartAreas>
                                            </asp:Chart>
                                        </div>
                                    </asp:Panel>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="background-color: #D2E5FA; border: 1px solid #D1DDEA;
                                    padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnBack" runat="server" CausesValidation="false" OnClick="btnBack_Click"
                                        Text="Back" />
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" OnClick="btnCancel_Click"
                                        Text="Dashboard" />
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
                            <asp:Label ID="lblExport" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="modalExport" runat="server" TargetControlID="lblExport"
                                PopupControlID="pnlExport" BackgroundCssClass="modal" BehaviorID="exportPopup">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none;" ID="pnlExport" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="500px" border="0"
                                    align="center">
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
                                            <td>
                                                <br />
                                                Include archived messages
                                                <asp:CheckBox ID="chkArchiveExport" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                Include Graph
                                                <asp:CheckBox ID="chkGraph" runat="server" />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Include All Columns
                                                <asp:CheckBox ID="chkExportAll" runat="server" onclick="CheckAll(this);" /><br />
                                                <br />
                                                <asp:CheckBoxList ID="chkExportList" runat="server" onclick="UnCheckAll();" RepeatColumns="3"
                                                    RepeatDirection="Horizontal" RepeatLayout="Table">
                                                    <asp:ListItem Value="1">Contact Name</asp:ListItem>
                                                    <asp:ListItem Value="2">Contact Email</asp:ListItem>
                                                    <asp:ListItem Value="3">Contact PhoneNumber</asp:ListItem>
                                                    <asp:ListItem Value="4">Street Address</asp:ListItem>
                                                    <asp:ListItem Value="5">City</asp:ListItem>
                                                    <asp:ListItem Value="6">State</asp:ListItem>
                                                    <asp:ListItem Value="7">ZipCode</asp:ListItem>
                                                    <asp:ListItem Value="8">Country</asp:ListItem>
                                                    <asp:ListItem Value="9">Replied Date</asp:ListItem>
                                                    <asp:ListItem Value="10">Notes</asp:ListItem>
                                                    <asp:ListItem Value="11">Replied By</asp:ListItem>
                                                    <asp:ListItem Value="12">Category</asp:ListItem>
                                                    <asp:ListItem Value="13">Date Sent</asp:ListItem>
                                                    <asp:ListItem Value="14">Device Blocked</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <br />
                                                <asp:Button ID="btnExport" runat="server" Text="Export" CssClass="HelpButton" border="0"
                                                    OnClick="btnExport_Click" OnClientClick="return HideExportPopUp();" CausesValidation="false" />
                                                <br />
                                                <br />
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
                            <asp:Label ID="lblAssign" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="modelAssign" runat="server" TargetControlID="lblAssign"
                                PopupControlID="pnlAssign" BackgroundCssClass="modal" BehaviorID="assignPopup">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none;" ID="pnlAssign" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="400px" border="0"
                                    align="center" style="height: 155px;">
                                    <tbody>
                                        <tr>
                                            <td style="font-weight: bold; color: #F2635F; font-size: 14px;">
                                                Change Category
                                            </td>
                                            <td align="right">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/popup_close.gif"
                                                    CausesValidation="false"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; font-size: 12px;">
                                                Current Category :
                                                <asp:Label ID="lblCategoryName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <strong>New Category:</strong>
                                                <asp:DropDownList ID="ddlAssignCategory" runat="server" Width="150px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="reqCategory" runat="server" ControlToValidate="ddlAssignCategory"
                                                    InitialValue="0" ValidationGroup="AssignValidate" ErrorMessage="Select the Category">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnAssign" runat="server" Text="Submit" CssClass="HelpButton" border="0"
                                                    ValidationGroup="AssignValidate" OnClick="btnAssign_Click" OnClientClick="return HideAssignPopUp();"
                                                    CausesValidation="true" />
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
                            <asp:Label ID="lblPGraph" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="modelPGraph" runat="server" TargetControlID="lblPGraph"
                                PopupControlID="pnlPGraph" BackgroundCssClass="modal" BehaviorID="graphPopup">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none;" ID="pnlPGraph" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="60%" border="0"
                                    align="center">
                                    <tbody>
                                        <tr>
                                            <td style="font-weight: bold; color: #F2635F; font-size: 14px;">
                                                SmartConnect Messages
                                            </td>
                                            <td align="right">
                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/popup_close.gif"
                                                    CausesValidation="false"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            <td>
                                                <div style="float: right; margin-right: 40px; margin-top: 24px;">
                                                    <asp:Button runat="server" ID="btnPrint" Text="Print" Width="70px" OnClick="btnPrint_OnClick" />
                                                    &nbsp;&nbsp;<asp:Button runat="server" ID="btnDownload" Text="Download" Width="70px"
                                                        Style="text-align: center; padding-left: 3px;" OnClick="btnDownload_OnClick" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center; font-weight: bold;">
                                                SmartConnect Messages Chart
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center; font-weight: bold;">
                                                Total Messages -
                                                <asp:Label ID="lblTotalCount" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="app-chart chart-one-pie">
                                                    <asp:Chart ID="chartAppUsage" runat="server" BorderlineWidth="0" Height="550px" Width="900px">
                                                        <%-- <Legends>
                                                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                                                Font="Microsoft Sans Serif, 10pt" LegendStyle="Table" TableStyle="Wide" IsEquallySpacedItems="false"/>
                                                        </Legends>--%>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="UsageChartArea" BackColor="white">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                    </asp:Chart>
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
            <asp:Label ID="lblPSCimage" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popSCimage" runat="server" TargetControlID="lblPSCimage"
                PopupControlID="pnlbulletinimage" BackgroundCssClass="modal" BehaviorID="popupimage"
                CancelControlID="imcloseimagepopup">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlbulletinimage" runat="server" Style="display: none" Width="530px"
                Height="600px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imcloseimagepopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="padding-bottom: 30px;">
                                <div id="divImg" style="overflow: auto; height: 400px; width: 500px;">
                                    <asp:Label ID="lblImage" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div class="largetxt">
                <asp:Label ID="lblTitle1" runat="server"></asp:Label>
            </div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
