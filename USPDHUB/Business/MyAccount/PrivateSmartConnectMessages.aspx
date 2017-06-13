<%@ Page Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="PrivateSmartConnectMessages.aspx.cs" Inherits="USPDHUB.Business.MyAccount.PrivateSmartConnectMessages"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/QRConnectCredits.ascx" TagName="QRConnectCredits" TagPrefix="QRConnectCreditsUC" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../Scripts/autopopulatedbox/sol.js" type="text/javascript"></script>
    <link href="../../css/Jquery-order-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../css/autopopulatedbox/sol.css" rel="stylesheet" type="text/css" />
    <link href="../../css/SmartConnectStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
      
        function SelectAllPublicCalls(headerchk) {
            var grdPublicCalls = document.getElementById('<%=grdCallHistory.ClientID%>');
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
            var grdPublicCalls = document.getElementById('<%= this.grdCallHistory.ClientID %>');
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
                var TargetBaseControl = document.getElementById('<%= this.grdCallHistory.ClientID %>');
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
                var TargetBaseControl = document.getElementById('<%= this.grdCallHistory.ClientID %>');
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
            document.getElementById('<%=chkExportAll.ClientID%>').checked = false;
            document.getElementById("<%=chkGraph.ClientID%>").checked = false;
            var cblist = document.getElementById('<%=chkExportList.ClientID%>');
            var inputs = cblist.getElementsByTagName("input");
            for (i = 3; i < inputs.length; i++) {
                inputs[i].checked = false;
            }
            inputs[0].checked = true;
            inputs[1].checked = true;
            inputs[2].checked = true;
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
            //            jQuery('[id$="lnkImage"]').click(function () {
            //                var ImageAvail = this.innerText;
            //                if (ImageAvail == 'No') {
            //                    alert("Image is not available.");

            //                }
            //            });

            CPcheckpostback1();
            CPcheckpostback2();
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
            //            jQuery('[id$="lnkImage"]').click(function () {
            //                var ImageAvail = this.innerText;
            //                if (ImageAvail == 'No') {
            //                    alert("Image is not available.");

            //                }
            //            });

        });

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


            $("#<%=hdnSelectCategoryID.ClientID %>").val($('#my-selectCategory').val());
            var array_of_SalesGroup = $('#my-selectCategory').searchableOptionList().getSelection().map(function () {
                return this.value;
            }).get();

            $("#<%=hdnresult.ClientID %>").val(array_of_SalesGroup);
        }
        function Isimage(lnk) {
            var ImageAvail = lnk.innerText;
            if (ImageAvail == 'No') {
                alert("Image is not available");
                return false;
            }

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

        function CPcheckpostback1() {
            __doPostBack('<%=rbTimeFormat12.ClientID %>', '')
        }
        function CPcheckpostback2() {
            __doPostBack('<%=rbTimerFormat24.ClientID %>', '')
        }

        function ShowMsgSearch(obj) {
            var btn = document.getElementById("<%=btnSearch.ClientID%>");
            btn.click();
        }

        function ShowOptionSearch() {
         
            var selMulti = $.map($("#my-selectCategory option:selected"), function (el, i) {
                return $(el).text();
            });
            var str = selMulti.join(", ");

            document.getElementById('<%=hdnResultCategory.ClientID%>').value = str;
            var btn = document.getElementById("<%=btnSearch.ClientID%>");
            btn.click();
        }
      
        function CheckDate() {
            var startVal = document.getElementById('<%=txtStartDate.ClientID%>').value;
            var endVal = document.getElementById('<%=txtEndDate.ClientID%>').value;
            var ErrMsg = "";
           
            if (startVal != '' && endVal != '') {

                var startDt = new Date(startVal);
                var endDt = new Date(endVal);
                startDt = new Date(startDt);
                endDt = new Date(endDt);

                if (!(startDt <= endDt))
                    ErrMsg = ErrMsg + "To Date should be always later than or equal to From Date.";
            }
            if (ErrMsg == "") {
                if (startVal != '' && endVal != '') {
                    var btn = document.getElementById("<%=btnSearch.ClientID%>");
                    btn.click();
                }
               
            }
            else {
                alert(ErrMsg);
                return false;
            }
            
        }
    </script>
    <style>
        /*  
first let's hide the inputs
instead we'll style our labels to look like checkboxes/radio-buttons
*/
        .market input[type='radio'], .market input[type='checkbox']
        {
            display: none;
        }
        
        .market
        {
            float: left;
        }
        
        /*
style the labels
add extra padding to the left side
*/
        .market input[type='radio'] + label, .market input[type='checkbox'] + label
        {
            margin: 0;
            clear: none;
            display: inline-block;
            padding: 10px 15px 10px 35px;
            cursor: pointer;
            background: #e3e3e3;
            color: #5F5F5F;
            border-radius: 3px;
            position: relative;
            margin: 0px 5px 5px 0px;
        }
        /*
hover-state for the labels
my design reduc
*/
        
        
        .market input[type='radio'] + label:hover, .market input[type='checkbox'] + label:hover
        {
            background: #D9D9D9;
        }
        
        
        /*
style an absolutely positioned white circle
for radio-buttons and a slighty rounded
square for the checkboxes
*/
        .market input[type='radio'] + label:before, .market input[type='checkbox'] + label:before
        {
            content: '';
            background: #fff;
            position: absolute;
            left: 10px;
            top: 50%;
            margin-top: -10px;
            width: 18px;
            height: 18px;
            border-radius: 12px;
        }
        .market input[type='checkbox'] + label:before
        {
            border-radius: 2px;
        }
        /*
the next shape will be the shape that only
appears when the input is checked
take note: opacity:0;
*/
        .market input[type='radio'] + label:after, .market input[type='checkbox'] + label:after
        {
            content: '';
            background: #d89114;
            position: absolute;
            left: 13px;
            top: 50%;
            margin-top: -7px;
            width: 12px;
            height: 12px;
            border-radius: 10px; /* transitions */
            transition: all .2s ease-in;
            -moz-transition: all .2s ease-in;
            -webkit-transition: all .2s ease-in; /* i've scaled the shape down so it will animate on the :checked state  */
            transform: scale(0.1);
            -moz-transform: scale(0.1);
            -webkit-transform: scale(0.1);
            opacity: 0;
        }
        .market input[type='checkbox'] + label:after
        {
            border-radius: 1px;
        }
        /*
now we use the :checked selector to change
affect the opacity and scale of our checked
shape
*/
        .market input[type='radio']:checked + label:after, .market input[type='checkbox']:checked + label:after
        {
            background: #4A4A4A;
            transition: all .2s ease-in;
            -moz-transition: all .2s ease-in;
            -webkit-transition: all .2s ease-in;
            transform: scale(1);
            -moz-transform: scale(1);
            -webkit-transform: scale(1);
            opacity: 1;
        }
        
        
        .market input[type='radio']:checked + label
        {
            background-color: #4dc46f;
            color: #FFFFFF;
        }
        
        .smstxtfildwrapdsh
        {
            width: 400px;
            float: left;
            font-weight: normal;
            font-size: 16px;
        }
        .smslabeldsh
        {
            font-size: 14px;
            color: #000;
            text-align: left;
            float: left;
            padding: 0px 0px 0px 0px;
            width: 200px;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
    <asp:UpdatePanel ID="updatePanel3" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="ddlModules" />
        </Triggers>
        <ContentTemplate>
            <table width="100%" style="padding-top: 12px;">
                <tr>
                    <td>
                        <div style="float: right;" id="divtabs" runat="server">
                            <b>Private QR Connect Tab Names:</b>
                            <asp:DropDownList ID="ddlModules" runat="server" Style="width: 135px; height: 20px;"
                                OnSelectedIndexChanged="ddlModules_SelectedIndexChanged" AutoPostBack="true"
                                EnableViewState="true">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                            Private QR Connect (
                                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                            ) - Messages
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
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td valign="bottom">
                                                    <b style="color: #0a59a9;">Filter Options:</b>
                                                </td>
                                                <td align="right" style="font-weight: bold; font-size: 16px;">
                                                    <QRConnectCreditsUC:QRConnectCredits ID="QRConnectCredits1" runat="server"></QRConnectCreditsUC:QRConnectCredits>
                                                </td>
                                            </tr>
                                        </table>
                                        <h2>
                                            <table cellspacing="3" cellpadding="3" width="100%" border="0">
                                                <!--Categories Block and Search Text including Dates Block -->
                                                <tr>
                                                    <td align="left">
                                                        Category:
                                                        <div style="">
                                                            <select id="my-selectCategory" name="character" multiple="multiple" style="width: 300px;" onchange="ShowOptionSearch()" >
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
                                                            Width="160px" onchange="ShowMsgSearch(this)"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="market">
                                                            Time Format:
                                                            <asp:RadioButton runat="server" ID="rbTimeFormat12" Text="12 Hour" GroupName="TimeFormat"
                                                                onclick="CPcheckpostback1()" OnCheckedChanged="rbTimeFormat12_OnCheckedChanged"
                                                                AutoPostBack="true" Checked="true" />
                                                            <asp:RadioButton runat="server" ID="rbTimerFormat24" Text="24 Hour" AutoPostBack="true"
                                                                GroupName="TimeFormat" onclick="CPcheckpostback2()" OnCheckedChanged="rbTimeFormat12_OnCheckedChanged" />
                                                        </div>
                                                    </td>
                                                    <td class="filtertd">
                                                        From Date:&nbsp;
                                                        <asp:TextBox ID="txtStartDate" runat="server" Width="160px" placeholder="From Date" onchange="CheckDate();"></asp:TextBox>
                                                          
                                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtStartDate"
                                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                            ValidationGroup="VG" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                        <cc1:CalendarExtender ID="calStart" runat="server" Enabled="True" TargetControlID="txtStartDate"
                                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                        &nbsp;&nbsp;&nbsp;To Date:&nbsp;
                                                        <asp:TextBox ID="txtEndDate" runat="server" Width="160px" placeholder="To Date"  onchange="CheckDate();"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"
                                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                            ValidationGroup="VG" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                                        <cc1:CalendarExtender ID="calEnd" runat="server" TargetControlID="txtEndDate" Format="MM/dd/yyyy"
                                                            CssClass="MyCalendar" />
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkDisplayUnread" runat="server" Text="Display Unread First" OnCheckedChanged="chkDisplayUnread_CheckedChanged"
                                                            onclick="DisplayUnread(this);" AutoPostBack="true" />
                                                    </td>
                                                    <td align="right">
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
                                                                    <td style="padding-right: 5px;">
                                                                        Page Size:
                                                                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                                                            <asp:ListItem>5</asp:ListItem>
                                                                            <asp:ListItem>10</asp:ListItem>
                                                                            <asp:ListItem>20</asp:ListItem>
                                                                            <asp:ListItem>30</asp:ListItem>
                                                                            <asp:ListItem>40</asp:ListItem>
                                                                            <asp:ListItem>50</asp:ListItem>
                                                                        </asp:DropDownList>
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
                                                                                            <asp:GridView ID="grdCallHistory" runat="server" DataKeyNames="CallAddOnsHistoryID"
                                                                                                Width="2500px" AllowSorting="true" AutoGenerateColumns="False" AllowPaging="true"
                                                                                                OnPageIndexChanging="grdCallHistory_PageIndexChanging" OnRowDataBound="grdCallHistory_RowDataBound"
                                                                                                CssClass="datagrid2" OnSorting="grdCallHistory_Sorting" PageSize="5">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField>
                                                                                                        <HeaderTemplate>
                                                                                                            <asp:CheckBox ID="chkSelectAllPublicCalls" runat="server" Text="Select All" onclick="SelectAllPublicCalls(this);" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chkPublicCalls" runat="server" OnCheckedChanged="chkPublicCalls_CheckedChanged"
                                                                                                                AutoPostBack="true" />
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="130px" />
                                                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Center" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Reference Id" SortExpression="ReferID">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkPublicCall" runat="server" Text='<%# "QRC" +Eval("ReferenceID").ToString() %>'
                                                                                                                CommandArgument='<%# Eval("CallAddOnsHistoryID")%>' OnClick="lnkView_Click"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="100px" />
                                                                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="91px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Button Title">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="170px" />
                                                                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Message">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblMessage" runat="server" Text='<%#Eval("CustomPredefinedMessage") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="220px" />
                                                                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="CreatedDate" HeaderText="Date Sent" SortExpression="DateSent"
                                                                                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="180px" />
                                                                                                    <asp:TemplateField HeaderText="Time Sent" SortExpression="DateSent">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label1" runat="server" Text='<%# rbTimerFormat24.Checked? Convert.ToDateTime((Eval("CreatedDate"))).ToString("HH:mm"):Convert.ToDateTime((Eval("CreatedDate"))).ToString("hh:mm tt") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="130px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Image">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lnkImage" runat="server" Text='<%# Eval("ImageName") != "" ? "Yes" : "No" %>'
                                                                                                                CommandArgument='<%# Eval("CallAddOnsHistoryID")%>' CommandName='<%# Eval("ImageName")%>'
                                                                                                                OnClientClick="return Isimage(this);" OnClick="lblImage_Click"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="150px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="CategoryName" HeaderText="Category" ItemStyle-Width="120px" />
                                                                                                    <asp:BoundField DataField="IsApproximateDistance" HeaderText="Proximity" ItemStyle-Width="80px" />
                                                                                                    <asp:TemplateField HeaderText="Device Street Address" ItemStyle-Width="150px">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblAddress1" runat="server" Text='<%# Eval("AddressLine1") %>'></asp:Label>
                                                                                                            <asp:Label ID="lblAddress2" runat="server" Text='<%# Eval("AddressLine2") %>'></asp:Label>
                                                                                                            <itemstyle horizontalalign="Left" font-size="12px" width="400px" />
                                                                                                            <headerstyle horizontalalign="Center" font-size="12px" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="City" HeaderText="Device City" ItemStyle-Width="120px" />
                                                                                                    <asp:BoundField DataField="State" HeaderText="Device State" ItemStyle-Width="120px" />
                                                                                                    <asp:BoundField DataField="ZipCode" HeaderText="Device ZipCode" ItemStyle-Width="120px" />
                                                                                                    <asp:BoundField DataField="ContactName" HeaderText="Contact Name" ItemStyle-Width="150px" />
                                                                                                    <asp:BoundField DataField="ContactPhoneNumber" HeaderText="Contact Phone Number"
                                                                                                        ItemStyle-Width="170px" />
                                                                                                    <asp:BoundField DataField="ContactEmail" HeaderText="Contact Email" ItemStyle-Width="150px" />
                                                                                                    <asp:BoundField DataField="RepliedDate" HeaderText="Replied Date" ItemStyle-Width="170px" />
                                                                                                    <asp:TemplateField HeaderText="Notes" ItemStyle-Width="300px">
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
                                                                                                    <asp:BoundField DataField="Country" HeaderText="Device Country" ItemStyle-Width="120px" />
                                                                                                    <asp:BoundField DataField="DeviceType" HeaderText="Device Type" ItemStyle-Width="150px" />
                                                                                                    <asp:TemplateField Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblpubliccallflag" runat="server" Text='<%#Eval("isRead") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="170px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="StatusArchive" HeaderText="Status" ItemStyle-Width="160px"
                                                                                                        Visible="false" />
                                                                                                    <%-- <asp:TemplateField HeaderText="Location">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("CurrentLocation") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="180px" />
                                                                                                        <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                                                                                    </asp:TemplateField>--%>
                                                                                                    <%--   <asp:BoundField DataField="Notes" HeaderText="Notes" ItemStyle-Width="550px" />--%>
                                                                                                </Columns>
                                                                                                <EmptyDataTemplate>
                                                                                                    <asp:Label ID="lblBUempty" runat="server" Text="There are no messages at this time."
                                                                                                        Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                                                                </EmptyDataTemplate>
                                                                                                <HeaderStyle CssClass="title1" />
                                                                                                <PagerStyle CssClass="paginationClass" />
                                                                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First"
                                                                                                    LastPageText="Last" />
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
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                Include Graph By Category
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
                                                    <asp:ListItem Value="Reference Id" Selected="True">Reference Id</asp:ListItem>
                                                    <asp:ListItem Value="Button Title" Selected="True">Button Title</asp:ListItem>
                                                    <asp:ListItem Value="Message" Selected="True">Message</asp:ListItem>
                                                    <asp:ListItem Value="Date Sent">Date Sent</asp:ListItem>
                                                    <asp:ListItem Value="Time Sent">Time Sent</asp:ListItem>
                                                    <asp:ListItem Value="Image">Image</asp:ListItem>
                                                    <asp:ListItem Value="Category">Category</asp:ListItem>
                                                    <asp:ListItem Value="Proximity">Proximity</asp:ListItem>
                                                    <asp:ListItem Value="Device Street Address">Device Street Address</asp:ListItem>
                                                    <asp:ListItem Value="Device City">Device City</asp:ListItem>
                                                    <asp:ListItem Value="Device State">Device State</asp:ListItem>
                                                    <asp:ListItem Value="Device ZipCode">Device ZipCode</asp:ListItem>
                                                    <asp:ListItem Value="Contact Name">Contact Information</asp:ListItem>
                                                    <asp:ListItem Value="Replied Date">Replied Date</asp:ListItem>
                                                    <asp:ListItem Value="Notes">Notes</asp:ListItem>
                                                    <asp:ListItem Value="Replied By">Replied By</asp:ListItem>
                                                    <asp:ListItem Value="Device Country">Device Country</asp:ListItem>
                                                    <asp:ListItem Value="Device Type">Device Type</asp:ListItem>
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
                                                Private QR Connect Messages
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
                                                Private QR Connect Messages Chart
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
            <cc1:ModalPopupExtender ID="popPSCimage" runat="server" TargetControlID="lblPSCimage"
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
                Private QR Connect (
                <asp:Label ID="lblTitle1" runat="server"></asp:Label>
                ) - Messages
            </div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
