<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="SurveryQuestions.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.SurveryQuestions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <%-- <script src="../../Scripts/accordion/jquery-1.9.1.js" type="text/javascript"></script>--%>
    <script src="../../Scripts/accordion/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/accordion/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/accordion/jquery.ui.accordion.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-bubble-popup-v3.min.js" type="text/javascript"></script>
    <link href="../../css/accordion/jquery.ui.base.css" rel="stylesheet" type="text/css" />
    <link href="../../css/accordion/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-bubble-popup-v3.css" rel="stylesheet" type="text/css" />
    <script>
        $(document).ready(function () {
            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'It will alert the user to answer it.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
            $('#helpCheck').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'Check boxes allow users to choose multiple answers to a question.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
            $('#helpRadio').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'Radio buttons allow only 1 answer per question.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
            $('#helpText').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'Choose free text boxes for comments, suggestions and detailed answers.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";

            }
        });
    </script>
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'It will alert the user to answer it.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
            $('#helpCheck').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'Check boxes allow users to choose multiple answers to a question.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
            $('#helpRadio').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'Radio buttons allow only 1 answer per question.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });

            $('#helpText').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'Choose free text boxes for comments, suggestions and detailed answers.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
        });

    </script>
    <script language="javascript">

        function ddlQuestionTypes_onchange() {
            var item = 0;
            var rbList = document.getElementById("<%=rbList.ClientID %>")
            rbList = rbList.getElementsByTagName("input")
            for (var j = 0; j < rbList.length; j++) {
                if (rbList[j].checked) {
                    item = rbList[j].value;
                    break;
                }
            }
            // 1: Checkboxes
            // 2: Radio Buttons
            // 3: Free TextBoxes
            if (item == 3) {
                document.getElementById("divAddMore").style.display = "none";
                document.getElementById("maintable").style.display = "none";
                document.getElementById("divAnswers").style.display = "none";

            }
            else {
                document.getElementById("divAddMore").style.display = "block";
                document.getElementById("maintable").style.display = "block";
                document.getElementById("divAnswers").style.display = "block";
            }

            /*var divtable = document.getElementById('maintable');
            if (divtable != null) {
            for (i = 0; i < divtable.rows.length; i++) {
            var id = divtable.rows[i].id;
                    
            if (i != 0 && i != 1) {
            $("#" + id).remove();
            i = 0;
            }
            else {
            if (document.getElementById("txtAnswer" + (i + 1)) != null) {
            document.getElementById("txtAnswer" + (i + 1)).value = "";
            }
            }
            }
            }*/
            // Checking Validations for Answers
            CheckingValidationRules();
        }

        function DeleteAllBlocks() {
            var divtable = document.getElementById('maintable');
            if (divtable != null) {
                for (i = 0; i < divtable.rows.length; ) {
                    var id = divtable.rows[i].id;
                    $("#" + id).remove();
                    i = 0;
                }
            }
            $("#maintable").remove("tr");
        }

        function AddTextBox() {
            //GETTING DIVS COUNT
            var CID = 1;
            // GET MAX DIV ID
            CID = CID + 1;
            for (i = CID; i <= CID; i++) {
                if (!document.getElementById("tr" + i)) {
                    break;
                }
                else {
                    CID++;
                }
            }

            var MaxOptions = document.getElementById("<%=MaxOptions.ClientID %>").value;
            if (CID > MaxOptions) {
                alert("Maximum number of options reached.");
            }
            else {
                var newRow = " <tr id='tr" + CID + "'>" +
                                 "           <td>" +
                                                "<label>" +
                                                    "Option " + CID + ":" +
                                                "</label>" +
                                            "</td>" +
                                            "<td>" +
                                                "<input type='text'  id='txtAnswer" + CID + "' style=\"width: 250px; \" maxlength='100' />" +
                                            "</td>" +
                                            "<td>" +
                                            "<input type='button' id='btnDelete" + CID + "' value='Delete' onclick='DeleteBlock(this.id);' /> " +
                                            "</td>" +
                                        "</tr>";
                $("#maintable").append(newRow);
                document.getElementById("txtAnswer" + CID).focus();
            }
        }

        function DeleteBlock(controlID) {
            var controlID = controlID.replace("btnDelete", "tr");
            if (confirm("Are you sure you want to delete this box?")) {
                $("#" + controlID).remove();
            }
        }

        function CheckingValidationRules() {
            var item = 0;
            var rbList = document.getElementById("<%=rbList.ClientID %>");
            rbList = rbList.getElementsByTagName("input")
            for (var j = 0; j < rbList.length; j++) {
                if (rbList[j].checked) {
                    item = rbList[j].value;
                    break;
                }
            }

            $("#divChocies").css('display', 'none');
            $("#diverrormsg").css('display', 'none');

            if (item == 1 && document.getElementById("<%=chkRequire.ClientID %>").checked == true) {
                $("#divChocies").css('display', 'block');
                $("#diverrormsg").css('display', 'block');
            }
            else if (document.getElementById("<%=chkRequire.ClientID %>").checked == true) {
                $("#diverrormsg").css('display', 'block');

            }
        }

    </script>
    <script type="text/javascript">

        var dummyTable = null;
        function SaveQuestion() {
            var value = true;
            if (Page_ClientValidate('SV') && Page_IsValid) {

                // 1: Checkboxes
                // 2: Radio Buttons
                // 3: Free TextBoxes
                var item = 0;
                var rbList = document.getElementById("<%=rbList.ClientID %>")
                rbList = rbList.getElementsByTagName("input")
                for (var j = 0; j < rbList.length; j++) {
                    if (rbList[j].checked) {
                        item = rbList[j].value;
                        break;
                    }
                }

                dummyTable = document.getElementById('maintable');
                var pQuestionText = document.getElementById("<%=txtQuestionName.ClientID %>").value;
                var questionTypeID = item;

                // Validating for Options Text Boxes Values
                //3 Means FreeTextboxes
                if (item != "3") {
                    var textboxes = $('#maintable [type=text]');
                    for (i = 0; i < textboxes.length; i++) {
                        var id = textboxes[i].id;
                        if (document.getElementById(id).value.trim() == "") {
                            alert('Option ' + (id.replace(/txtanswer/gi, "")) + ' is mandatory.');
                            document.getElementById(id).focus();
                            return false;
                        }
                    }
                } // End Validations for Option Text Boxes


                //var item = document.getElementById("<%=rbList.ClientID %>").options[document.getElementById("ctl00_ctl00_cphUser_cphUser_rbList").selectedIndex].text;

                var elems = $('#maintable [type=text]');
                var optionText = "";
                for (i = 0; i < elems.length; i++) {
                    var id = elems[i].id;
                    if (item != 3) {
                        var optionText = optionText + "&yen;" + document.getElementById(id).value.replace("'", "&apos;"); ;

                    }
                }
                document.getElementById("<%=hdnAnswers.ClientID %>").value = "";
                document.getElementById("<%=hdnAnswers.ClientID %>").value = optionText;

                // new survey validation 1.6 Start
                if (document.getElementById("<%=chkRequire.ClientID %>").checked == true) {
                    //Checkbox validation Answers Choice Count
                    var choiceCount = document.getElementById("<%=txtAnswesCheckCount.ClientID %>").value;
                    var errorMessage = document.getElementById("<%=txtChoiceErrorMessage.ClientID %>").value;
                    var textboxesCount = $('#maintable [type=text]').length;

                    if (item == 1) {
                        if (choiceCount == "") {
                            alert("Please enter answer choice count.");
                            return false;
                        }
                        else if (choiceCount > textboxesCount) {
                            alert("Choice count less than or equal to options count.");
                            return false;
                        } else if (errorMessage == "") {
                            alert("Please enter error message.");
                            document.getElementById("<%=txtChoiceErrorMessage.ClientID %>").focus();
                            return false;
                        }
                    } // Item ==1
                    else {
                        if (errorMessage == "") {
                            alert("Please enter error message.");
                            document.getElementById("<%=txtChoiceErrorMessage.ClientID %>").focus();
                            return false;
                        }
                    }
                } // END Survey Validation  1.6

            }
            else {
                return;
            }

            //            // Hide Loading Bar
            window.setTimeout(function () {
                $('#loading').css('display', 'none');
            }, 100);


            return value;
        }

    </script>
    <script language="javascript" type="text/javascript">
        function AddEditTextBoxes(count) {
            // Show Loading Bar
            $('#loading').css('display', 'block');

            DeleteAllBlocks();
            ddlQuestionTypes_onchange();
            var newRows = "";
            var CID = 0;
            var answer_Options = document.getElementById("<%=hdnAnswers.ClientID %>").value;
            answer_Options = answer_Options.substring(5);
            var values = answer_Options.split('&yen;');
            if (answer_Options != "")
                for (i = 0; i < count; i++) {
                    var opsText = values[i].replace(/'/gi, "&apos;");
                    CID = CID + 1;
                    if (i == 0 || i == 1) {
                        var newRow = " <tr id='tr" + CID + "'>" +
                                 "           <td>" +
                                                "<label>" +
                                                    "Option " + CID + ":" +
                                                "</label>" +
                                            "</td>" +
                                            "<td>" +
                                                "<input type='text'  id='txtAnswer" + CID + "'  style=\"width: 250px; \" value='" + opsText + "' maxlength='100' />" +
                                            "</td>" +
                                            "<td>" +
                                            "</td>" +
                                        "</tr>";
                        $("#maintable").append(newRow);
                    }
                    else {
                        var newRow = " <tr id='tr" + CID + "'>" +
                                 "           <td>" +
                                                "<label>" +
                                                    "Option " + CID + ":" +
                                                "</label>" +
                                            "</td>" +
                                            "<td>" +
                                                "<input type='text'  id='txtAnswer" + CID + "'  style=\"width: 250px; \" value='" + opsText + "' maxlength='100' />" +
                                            "</td>" +
                                            "<td>" +
                                              "<input type='button' id='btnDelete" + CID + "' value='Delete' onclick='DeleteBlock(this.id);' /> " +
                                            "</td>" +
                                        "</tr>";
                        $("#maintable").append(newRow);
                    }
                }
            $("#accordion").accordion();

            // Hide Loading Bar
            window.setTimeout(function () {
                $('#loading').css('display', 'none');
            }, 100);

            //Hide Error Message Validation When Poll
            var stype = '<%= Session["SType"]%>';
            if (stype == "Poll") {
                $('#pnlErrorMsValidation').css('display', 'none');
            }
            else {
                $('#pnlErrorMsValidation').css('display', 'block');
            }


        }
        function CallPreviuosQuestionDetails(selectedQNumber) {

            $('#loading').css('display', 'block');

            $.ajax({
                type: "POST",
                url: "SurveryQuestions.aspx/CallPreviuosQuestionDetails",
                data: "{'CQNumber': '" + selectedQNumber + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var result = data.d
                    var QNumber = result[0];
                    var QName = result[1];
                    var OptionsCount = result[2];
                    var Answers = result[3];
                    var QType = result[4];

                    document.getElementById("<%=hdnAnswers.ClientID %>").value = Answers;
                    document.getElementById("<%=txtQuestionName.ClientID %>").value = QName;
                    if (document.getElementById("<%=lblQuestionNumber.ClientID %>") != null) {
                        document.getElementById("<%=lblQuestionNumber.ClientID %>").innerHTML = QNumber;
                    }

                    if (document.getElementById("<%=btnDeleteQuesion.ClientID %>") != null) {
                        document.getElementById("<%=btnDeleteQuesion.ClientID %>").style.display = "block";
                    }

                    var maxQNumber = '<%=Convert.ToInt32(Session["MaxQuestion"]) %>';
                    if (parseInt(QNumber) >= parseInt(maxQNumber)) {
                        document.getElementById("<%=btnSaveContnuie.ClientID %>").value = "Save & Exit";
                        if (document.getElementById("<%=btnFinish.ClientID %>") != null) {
                            document.getElementById("<%=btnFinish.ClientID %>").style.display = "none";
                        }
                        if (document.getElementById("<%=btnSkip.ClientID %>") != null) {
                            document.getElementById("<%=btnSkip.ClientID %>").style.display = "none";
                        }
                    }
                    else {
                        document.getElementById("<%=btnSaveContnuie.ClientID %>").value = "Save & Continue";
                        if (document.getElementById("<%=btnFinish.ClientID %>") != null) {
                            document.getElementById("<%=btnFinish.ClientID %>").style.display = "block";
                        }
                        if (document.getElementById("<%=btnSkip.ClientID %>") != null) {
                            document.getElementById("<%=btnSkip.ClientID %>").style.display = "block";
                        }
                        //alert(document.getElementById("<%=btnSkip.ClientID %>"));
                    }
                    // QNumber (CurrentQuestion-1) 1 menas is it first question checking
                    if (QNumber > 1) {
                        document.getElementById("<%=btnBack.ClientID %>").style.display = "block";
                    }
                    else {
                        document.getElementById("<%=btnBack.ClientID %>").style.display = "none";
                    }


                    var rbList = document.getElementById("<%=rbList.ClientID %>")
                    rbList = rbList.getElementsByTagName("input")
                    for (var j = 0; j < rbList.length; j++) {
                        if (rbList[j].value == QType) {
                            rbList[j].checked = true;
                            break;
                        }
                    }
                    AddEditTextBoxes(OptionsCount);

                }
            });
        }


    </script>
    <script>
        $(function () {
            BindLoadEvents();
        });
    </script>
    <script type="text/javascript">
        function BindLoadEvents() {
            $("#accordion").accordion();
        }
    </script>
    <script type="text/javascript">
        function ShowPublish(val) {
            if (val == "1") {
                document.getElementById('<%=divpublish.ClientID%>').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
            } else if (val == "2") {
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                document.getElementById('<%=divpublish.ClientID%>').style.display = "block";
                if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
                    GetCurrentDate();
            }
        }
        function GetCurrentDate() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/GetUserTimeZoneDashboard",
                dataType: "json",
                success: function (response) {
                    currentTime = new Date(response.d);
                    dformat = [(currentTime.getMonth() + 1).padLeft(), currentTime.getDate().padLeft(), currentTime.getFullYear()].join('/');
                    document.getElementById('<%= txtPublishDate.ClientID%>').value = dformat;
                }
            });
        }
        Number.prototype.padLeft = function (base, chr) {
            var len = (String(base || 10).length - String(this).length) + 1;
            return len > 0 ? new Array(len).join(chr || '0') + this : this;
        }

        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null) //roles & permissions..
                DisplayComplete();

        }
        function DisplayComplete() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                document.getElementById('<%=divpublish.ClientID%>').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                ShowPublish('2');
            }
        }
        function ValidateExpiryDate() {
            if (!Page_ClientValidate('SVR')) {
                return;
            }
            //ExDate checking
            var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }
            if (document.getElementById("<%=txtExpiryDate.ClientID %>").value != "") {
                var currentdate = new Date();
                var fromDate = document.getElementById("<%=txtExpiryDate.ClientID %>").value + " " + document.getElementById(controlName).value;
                var selDate = new Date(fromDate);
                if (selDate <= currentdate) {
                    alert('Expiration date should be later than current date.');
                    return false;
                }
            }
            //end exdate checking
        }

        function ShowExTimeDiv() {
            var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }
            if (document.getElementById("<%=txtExpiryDate.ClientID %>").value == "") {
                document.getElementById(controlName).disabled = true;
            }
            else {
                document.getElementById(controlName).disabled = false;
            }
        }
    </script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .left-div
        {
            width: 62%;
            height: auto;
            float: left;
            margin-right: 4px;
        }
        .right-div
        {
            margin-top: 120px;
            margin-left: 62%;
        }
        .clear
        {
            clear: both;
            height: 5px;
        }
        .parent
        {
            width: 100%;
            height: auto;
            margin: auto;
            padding: 10px;
            overflow: auto;
        }
        .contentbtm
        {
            padding: 5px !important;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(BindLoadEvents);
            </script>
            <div class="parent" style="width: 100%;">
                <asp:HiddenField runat="server" ID="hdnQuestionType" />
                <asp:HiddenField runat="server" ID="MaxOptions" Value="10" />
                <asp:HiddenField runat="server" ID="hdnAnswers" />
                <asp:HiddenField runat="server" ID="hdnPreviousQuestions" />
                <asp:HiddenField runat="server" ID="hdnChoiceErrorMessage" Value="An answer to this question is mandatory." />
                <asp:HiddenField ID="hdnPublishDate" runat="server" />
                <asp:HiddenField ID="hdnPermissionType" runat="server" />
                <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                <div class="left-div">
                    <div id="wrapper">
                        <div class="headernav">
                            <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                                Style="border: 0; border-color: White!important;"></asp:TextBox>
                        </div>
                        <div style="text-align: center;">
                            <asp:Label ID="lblerror" runat="server"></asp:Label>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                <ProgressTemplate>
                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                        size="2">Processing....</font></b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <div style="width: 350px; margin: 0 auto;">
                                <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                    ValidationGroup="SV" HeaderText="The following error(s) occurred:" />
                                <asp:ValidationSummary ID="ValidationThnxInfo" runat="server" Style="text-align: left;"
                                    ValidationGroup="SVR" HeaderText="The following error(s) occurred:" />
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <asp:Panel ID="Panel1" runat="server" Style="width: 600px;">
                            <div class="contentwrap contentbtm">
                                <div class="largetxt">
                                    <%--Survey Questions--%>
                                    <asp:Label ID="lblSurveyTitle" Text="Survey Questions" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblPollTitle" runat="server" Text="Poll Question" Visible="false"></asp:Label>
                                </div>
                                <div>
                                    <div style="float: left; width: 580px">
                                        <div class="form_wrapper" style="float: none; width: auto;">
                                            <div class="clear10">
                                            </div>
                                            <div class="fields_wrap">
                                                <label style="color: Red; font-size: 16px; margin-left: 2px;">
                                                    * Marked fields are mandatory.</label>
                                            </div>
                                            <div class="clear10">
                                            </div>
                                            <div class="fields_wrap">
                                                <div class="left_lable" style="margin-left: 5px; width: 119px">
                                                    <font color="red">*</font>
                                                    <label>
                                                        <asp:Label ID="lblSurveyQuestion" Text="Question No " runat="server" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblPollQuestion" runat="server" Text="Question" Visible="false"></asp:Label>
                                                        <asp:Label runat="server" ID="lblQuestionNumber"></asp:Label>
                                                        :
                                                    </label>
                                                </div>
                                                <div class="right_fields" style="width: 430px;">
                                                    <asp:TextBox ID="txtQuestionName" runat="server" CssClass="txtfild1" TabIndex="1"
                                                        Width="395" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtQuestionName" ValidationGroup="SV" ErrorMessage="Question Name is mandatory.">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="fields_wrap">
                                                <div class="left_lable" style="margin-left: 5px; width: 119px">
                                                    <span style="padding-left: 2px;">&nbsp;</span>
                                                    <label>
                                                        <asp:Label runat="server" ID="lblQuestionType">     Question Type : </asp:Label></label></div>
                                                <div class="right_fields" style="width: 470px; padding-left: 135px;">
                                                    <%-- <asp:DropDownList ID="ddlQuestionTypes" runat="server" CssClass="select1" TabIndex="3"
                                        onchange="ddlQuestionTypes_onchange()">
                                    </asp:DropDownList>--%>
                                                    <asp:RadioButtonList ID="rbList" runat="server" onchange="ddlQuestionTypes_onchange()">
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="ReqiredFieldValidator3" runat="server" Display="Dynamic"
                                                        ControlToValidate="rbList" Style="float: right; padding-top: -20px; margin-top: -20px;
                                                        padding-right: 50px;" ErrorMessage="Please choose option for your question type."
                                                        ValidationGroup="SV">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="fields_wrap" id='div1'>
                                                <div class="left_lable" style="margin-left: 5px; width: 119px">
                                                </div>
                                                <div class="right_fields" style="width: 480px;">
                                                    <div id='loading' style='display: none; margin-left: 70px;'>
                                                        <img src="../../Images/dashboard/ezSmartAjax.gif" /><b><font color="green" size="2">
                                                            Loading....</font></b></div>
                                                </div>
                                            </div>
                                            <div class="fields_wrap" id='divAddMore'>
                                                <div class="left_lable" style="margin-left: 5px; width: 119px">
                                                    <span style="padding-left: 2px;">&nbsp;</span>
                                                    <label>
                                                    </label>
                                                </div>
                                                <div class="right_fields" style="width: 480px;">
                                                    <input type="button" value="Add" onclick="AddTextBox();" style="margin-left: 480px;
                                                        width: 70px;" />
                                                </div>
                                            </div>
                                            <div class="fields_wrap" id='divAnswers'>
                                                <div class="left_lable" style="margin-left: 5px; width: 119px">
                                                    <span style="padding-left: 2px;">&nbsp;</span>
                                                    <label>
                                                        Answer Options :
                                                    </label>
                                                </div>
                                                <div class="right_fields" style="width: 405px;">
                                                    <asp:Panel ID="pnl" runat="server">
                                                        <table id='maintable' cellspacing="4" style="border: 2px solid grey;">
                                                        </table>
                                                    </asp:Panel>
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="fields_wrap" id='pnlErrorMsValidation'>
                                                <div class="left_lable" style="margin-left: 5px; width: 119px">
                                                    <span style="padding-left: 2px;">&nbsp;</span>
                                                    <label>
                                                    </label>
                                                </div>
                                                <div class="right_fields" id='divErrorMsgValidation'>
                                                    <input type="checkbox" id="chkRequire" runat="server" onclick="CheckingValidationRules()" />
                                                    Require an answer to this question (Optional) <a href="javascript:void();" id="hyperBubble">
                                                        <img id='help1' src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                    <br />
                                                    <div id='divChocies' style="margin-left: 20px; font-size: 12px; display: none;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    Respondent must answer
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlAnswerCheckType" runat="server">
                                                                        <asp:ListItem Text="at least" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="at most" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="only" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtAnswesCheckCount" Width="50" MaxLength="2"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator runat="server" ValidationExpression="^\d+$" ControlToValidate="txtAnswesCheckCount"
                                                                        ValidationGroup="SV" ErrorMessage="Only numbers are allowed.">*</asp:RegularExpressionValidator>
                                                                    &nbsp; choices
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id='diverrormsg' style="margin-left: 20px; font-size: 12px; display: none;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    When the question is not answered, display this error message:
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID='txtChoiceErrorMessage' TextMode="MultiLine" Width="378"
                                                                        Height="40" MaxLength="500" CssClass="txtfild1" Text="An answer to this question is mandatory."></asp:TextBox>
                                                                    <%-- <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14" TargetControlID="txtChoiceErrorMessage"
                                                                WatermarkText="A Selection Is Required For This Question." runat="server" WatermarkCssClass="watermarkbulletindate">
                                                            </cc1:TextBoxWatermarkExtender>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="clear10">
                                            </div>
                                            <div class="fields_wrap ">
                                                <div class="left_lable">
                                                </div>
                                                <div class="right_fields" style="margin: 10px 0px 0px 5px; width: 615px;">
                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" border="0" OnClick="btnBack_OnClick"
                                                        Style="display: none; padding-left: 12px; padding-right: 12px;" UseSubmitBehavior="false" />
                                                    <asp:Button ID="btnSaveContnuie" runat="server" Text="Save & Continue" CssClass="btn"
                                                        border="0" ValidationGroup="SV" CausesValidation="true" OnClientClick="return SaveQuestion();"
                                                        OnClick="btnSaveContnuie_Click" Style="padding-left: 12px; padding-right: 12px;" />
                                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                                        Text="Cancel" OnClick="btnCancel_Click" Style="padding-left: 12px; padding-right: 12px;" />
                                                    <asp:Button ID="btnFinish" runat="server" border="0" CssClass="btn" Text="Submit"
                                                        OnClick="btnFinish_OnClick" Style="padding: 0px 12px;" ValidationGroup="SV" CausesValidation="true"
                                                        OnClientClick="return SaveQuestion();" />
                                                    <asp:Button ID="btnDeleteQuesion" runat="server" CausesValidation="false" border="0"
                                                        OnClientClick='return confirm("Are you sure you want to delete this question?")'
                                                        CssClass="btn" Text="Delete" OnClick="btnDelete_OnClick" Style="display: none;
                                                        padding-left: 12px; padding-right: 12px;" />
                                                    <asp:Button runat="server" ID="btnSkip" Text="Skip" CssClass="btn" Border="0" CausesValidation="false"
                                                        OnClick="btnSkip_OnClick" Style="display: none; padding-left: 12px; padding-right: 12px;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" Style="width: 600px; display: none; height: auto">
                            <div class="contentwrap contentbtm">
                                <div class="largetxt">
                                    <asp:Label ID="Label1" Text="Thank You Message" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <div style="float: left; width: 580px">
                                        <div class="form_wrapper" style="float: none; width: auto;">
                                            <div class="fields_wrap">
                                                <label style="color: Red; font-size: 16px; margin-left: 2px;">
                                                    * Marked fields are mandatory.</label>
                                            </div>
                                            <div class="clear10">
                                            </div>
                                            <div class="fields_wrap">
                                                <div class="left_lable" style="margin-left: 5px; width: 170px;">
                                                    <font color="red">*</font>
                                                    <label>
                                                        Thank You Message :
                                                        <br />
                                                        <b>(This message will appear on the app.)</b>
                                                    </label>
                                                </div>
                                                <div class="right_fields" style="width: 350px;">
                                                    <asp:TextBox ID="txtthanksMessage" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtthanksMessage" ValidationGroup="SVR" ErrorMessage="Thank You Message is mandatory.">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="fields_wrap">
                                                <div class="left_lable" style="margin-left: 5px; width: 170px;">
                                                    &nbsp;
                                                    <label>
                                                        Expiration Date & Time :
                                                    </label>
                                                </div>
                                                <div class="right_fields" style="width: 350px;">
                                                    <table width="90%" style="margin-left: -3px; margin-top: -5px;">
                                                        <colgroup>
                                                            <col width="120px" />
                                                            <col width="*" />
                                                        </colgroup>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="txtfild1" TabIndex="5" Width="90px"
                                                                    onChange="ShowExTimeDiv();"></asp:TextBox>&nbsp;
                                                                <asp:RegularExpressionValidator ID="RegularDate" runat="server" Display="Dynamic"
                                                                    ControlToValidate="txtExpiryDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                    SetFocusOnError="True" ValidationGroup="SVR" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtExpiryDate"
                                                                    WatermarkText="MM/DD/YYYY" runat="server">
                                                                </cc1:TextBoxWatermarkExtender>
                                                                <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExpiryDate" Format="MM/dd/yyyy"
                                                                    CssClass="MyCalendar" />
                                                            </td>
                                                            <td valign="top">
                                                                <TimerUC:TimeControl ID="ExpiryTimeControl1" runat="server" Enabled="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="fields_wrap">
                                                <div class="left_lable" style="margin-left: 5px; width: 170px;">
                                                    <label>
                                                        &nbsp;
                                                    </label>
                                                </div>
                                                <div class="right_fields" style="width: 350px;">
                                                    <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                                        onclick="javascript:ShowPublish('1')" />
                                                    <label>
                                                        Private</label>
                                                    <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2')" />
                                                    <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                                    <div style="margin: 10px 0px 0px 10px; display: none;" id="divpublish" runat="server">
                                                        <div id="divSchedulePublish" style="display: block;">
                                                            <font color="red">*</font>
                                                            <label style="font-size: 14px;">
                                                                Publish Date:</label>
                                                            <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                                ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                                ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                ValidationGroup="SVR" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                            <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                                Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--<div class="clear">
                                            </div>
                                            <div class="clear10">
                                            </div>--%>
                                            <div class="fields_wrap ">
                                                <div class="left_lable">
                                                    <label>
                                                        &nbsp;</label>
                                                </div>
                                                <div class="right_fields" style="margin: 10px 0px 0px 185px; width: 400px;">
                                                    <asp:Button ID="btnBackPanle2" runat="server" Text="Back" CssClass="btn" border="0"
                                                        OnClick="btnBackPanel2_Click" Style="padding-left: 17px; padding-right: 17px;" />
                                                    <asp:Button ID="btnCancelPanel2" runat="server" CausesValidation="false" border="0"
                                                        CssClass="btn" Text="Cancel" OnClick="btnCancel_Click" Style="padding-left: 17px;
                                                        padding-right: 17px;" />
                                                    <asp:Button ID="btnSubmitPanel2" runat="server" border="0" CssClass="btn" Text="Finish"
                                                        OnClick="btnSubmitPanel2_OnClick" Style="padding: 0px 15px;" ValidationGroup="SVR"
                                                        CausesValidation="true" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="right-div">
                    <div style="overflow: auto; max-height: 600px; margin-left: 20px; margin-top: 10px;">
                        <div style="float: right;">
                            <div class="clear10">
                            </div>
                            <asp:Literal runat="server" ID="lblQuestionPreview"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%--<Triggers>
            <asp:PostBackTrigger  ControlID="Accordion1"/>
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
