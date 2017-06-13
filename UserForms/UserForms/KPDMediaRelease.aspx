<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="KPDMediaRelease.aspx.cs"
    Inherits="UserForms.KPDMediaRelease" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<%@ Register Src="UCEditor.ascx" TagName="UCEditor" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <script src="Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.sortable.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.droppable.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.draggable.js" type="text/javascript"></script>
    <link href="css/Bulletins.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/timePicker/jquery.timepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/timePicker/lib/bootstrap-datepicker.js" type="text/javascript"></script>
    <link href="Scripts/timePicker/lib/bootstrap-datepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/timePicker/lib/site.js" type="text/javascript"></script>
    <link href="Scripts/timePicker/lib/site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/flyers/jquery-ui-1.8.21.custom.js" type="text/javascript"></script>
    <script src="Scripts/jquery.textarea-expander.js" type="text/javascript"></script>
    <style type="text/css">
        .radius !important;
        {
            width: 475px;
        }
        
        .modal
        {
            background-color: Gray;
            filter: alpha(opacity=90);
            opacity: 0.7;
        }
        #popup
        {
            background-color: Gray;
            filter: alpha(opacity=90);
            opacity: 0.7;
            width: 100%;
            height: 100%;
        }
        .textdivStyle
        {
            text-align: left;
            border: 1px solid #FCB549;
            overflow: auto;
            font-family: Arial;
            font-size: 16px;
            width: 335px;
        }
        .drop div:hover
        {
            cursor: move;
        }
    </style>
    <script type="text/javascript">

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function tableCheck() {
            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"490px\" style=\"border: 0px solid gray; min-height: 100px;\"></table>";
                document.getElementById("<%=lblEditText.ClientID %>").innerHTML = maintableTag;
            }
        }


        function AddPerson() {

            if ($(".Vehicleclass")[0]) {
                //document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "";
            }

            tableCheck();

            //GETTING DIVS COUNT
            var CID = 1;
            for (i = CID; i <= CID; i++) {
                if (!document.getElementById("trheader" + i)) {
                    break;
                }
                else {
                    CID++;
                }
            }

            document.getElementById('DivIds').value = CID;
            var divtable = document.getElementById('maintable');


            var newRow = "<table class='drop'><tr><td><tr class=\"trheader\" id='trheader" + CID + "' >" +
            //"<td style=\"border-left: 2px dashed blue; border-right: 2px dashed blue; border-Top: 2px dashed blue; border-bottom:1px solid gray;\">" +
                                "<td><span style='font-weight:bold;margin-left: 120px;'>Person Incident Information</span><br/>" +
                                "<img align='right' src=\"../../Images/EditPerson.png\" style='cursor: pointer; display:none; padding-right:5px;' id='imgedit" + CID + "' onclick='EditPanel(trpreview" + CID + ")'  />&nbsp;&nbsp;" +
                                "<img align='right' src=\"../../Images/DeletePerson.png\" style='cursor: pointer; padding-right:5px;' onclick='RemovePanel(edit" + CID + ")' />&nbsp;&nbsp;" +
                                "</td>" +
                          "</tr>" +
                          "<tr id='trpreview" + CID + "' style='display:none;' ><td id='tdpreview" + CID + "' style='min-width: 300px;'></td></tr>" +
                          "<tr id='tr" + CID + "' class='incidentclass' >" +
                                "<td>" +
                                    "<div class=\"incident\" id=\"edit" + CID + "\"> " +
                                        "<table style='border-bottom:2px solid gray;' cellpadding=\"2\" cellspacing=\"0\" width='100%'> " +
                                            "<colgroup>" +
                                                "<col width='120px' />" +
                                                "<col width='*' />" +
                                            "</colgroup>" +

                                              "<tr>" + // Person Type
                                                "<td><span style='font-weight:bold;'>Person Type:</span></td>" +

                                                "<td>" +
                                                "<select  id='ddlPType" + CID + "' name='ddlPType" + CID + "' onchange='loadPType(this.id," + CID + ",edit" + CID + ")' style='width:140px;'>" +
                                                "<option value=''>Select</option>" +
                                                "<option value='1'>Arrested</option>" +
                                                "<option value='2'>Deceased</option>" +
                                                "<option value='3'>Driver</option>" +
                                                "<option value='4'>Missing</option>" +
                                                "<option value='5'>Other</option>" +
                                                "<option value='6'>Person of interest</option>" +
                                                "<option value='7'>Suspect</option>" +
                                                "<option value='8'>Summoned</option>" +
                                                "<option value='9'>Victim</option>" +
                                                "</select></td>" +
                                            "</tr>" +

                                            "<tr>" + // First Name
                                                "<td><span style='font-weight:bold;'>First Name:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtFName" + CID + "' name='txtFName" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // Middle Name
                                                "<td><span style='font-weight:bold;'>Middle Name:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtMName" + CID + "' name='txtLName" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // Last Name
                                                "<td><span style='font-weight:bold;'>Last Name:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtLName" + CID + "' name='txtLName" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // Address
                                                "<td><span style='font-weight:bold;'>Address:</span></td>" +
                                                "<td> <textarea style='font-weight:bold;' id='txtAddress" + CID + "'></textarea></td>" +
                                            "</tr>" +

                                             "<tr>" + // City
                                                "<td><span style='font-weight:bold;'>City:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtCity" + CID + "' name='txtCity" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // State
                                                "<td><span style='font-weight:bold;'>State:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtState" + CID + "' name='txtState" + CID + "' /> </td>" +
                                            "</tr>" +

                                            "<tr>" + // DOB
                                                "<td><span style='font-weight:bold;'>Date of Birth:</span></td>" +
                                                 "<td><input type='text' style='font-weight:bold;' id='txtDOB" + CID + "' name='txtDOB" + CID + "' /></td>" +
                                            "</tr>" +

                                             "<tr id='trAge" + CID + "' style='display:none;'>" + // Age
                                                "<td><span style='font-weight:bold;'>Age:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtAge" + CID + "' name='txtAge" + CID + "' readonly /></td>" +
                                            "</tr>" +

                                           "<tr>" + // Gender
                                                "<td><span style='font-weight:bold;'>Gender:</span></td>" +
                                                "<td><input type='radio' style='font-weight:bold;' id='rdMale" + CID + "' name='gender" + CID + "' value='Male' checked/> Male &nbsp;" +
                                                " &nbsp; &nbsp;<input type='radio' style='font-weight:bold;' id='rdFemale" + CID + "' name='gender" + CID + "' value='Female'/> Female" +
                                                " </td>" +
                                            "</tr>" +

                                            "<tr>" + // Other
                                                "<td><span style='font-weight:bold;'>Other:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtOther" + CID + "' name='txtOther" + CID + "' /> </td>" +
                                            "</tr>" +

                                            "<tr id='trEmpty" + CID + "'>" +
                                                "<td colspan='2'>&nbsp;</td>" +
                                            "</tr>" +
                                        "</table>" +
                                    "</div>" +
                                "</td>" +
                            "</tr></td></tr></table>";


            if (divtable.rows.length == 0) {
                $("#maintable").append(newRow);
            }
            else {
                var lastrow = CID - 1;
                $("#tr" + lastrow).after(newRow);
            }

            //loadPType("ddlPType" + CID);
            LoadDataPickers("txtDOB" + CID, "trAge" + CID, "txtAge" + CID);

            //Auto scroll when add new item
            var objDiv = document.getElementById("divMain");
            objDiv.scrollTop = objDiv.scrollHeight;

            LoadBlocks();
        }

        function LoadDataPickers(datepickerID, trAge, Age) {

            $("#" + datepickerID).datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-30:+0",
                onSelect: function (dateText, inst) {
                    ageCount(dateText, Age);
                    $("#" + trAge).removeAttr("style").show();
                }
            });

        }

        function ageCount(DOB, Age) {

            var now = new Date();
            if (DOB != "") {
                var DOBDate = new Date(DOB);
                if (DOBDate > now) {
                    alert('Please select date of birth less than or equal to current date.');
                    $("#" + Age).val("");
                    DOB = "";

                }
                else {
                    var years = now.getFullYear() - DOBDate.getFullYear();
                    var m = now.getMonth() - DOBDate.getMonth();
                    if (m < 0 || (m === 0 && now.getDate() < DOBDate.getDate())) {
                        years--;
                    }
                    $("#" + Age).val(years);
                }
            } else {
                $("#" + Age).val("");
            }
        }

        function loadPType(ctrlID, CID, trEdit) {

            var trEditID = trEdit.id;
            var newArrestRow = "";
            if ($("#" + ctrlID).val() == 1) {
                newArrestRow = "<table id=\"editarrest" + CID + "\" style='border-bottom:2px solid gray;' cellpadding=\"2\" cellspacing=\"0\" width='100%'> " +
                                            "<colgroup>" +
                                                "<col width='120px' />" +
                                                "<col width='*' />" +
                                            "</colgroup>" +
                                             "<tr>" + // Header
                                                "<td colspan='2' align='center'><span style='font-weight:bold;margin-left: 70px;'>Arrested Incident Information</span>" +
                                                "</td>" +
                                            "</tr>" +

                                            "<tr>" + // Counts
                                                "<td><span style='font-weight:bold;'>Counts:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtCount" + CID + "' name='txtCount" + CID + "' maxlength='3' onkeypress='return event.charCode >= 48 && event.charCode <= 57' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // Crime
                                                "<td><span style='font-weight:bold;'>Crime:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtCrime" + CID + "' name='txtCrime" + CID + "'  maxlength='100' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // Bail
                                                "<td><span style='font-weight:bold;'>Bail:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtBail" + CID + "' name='txtBail" + CID + "' maxlength='4' onkeypress='return (event.charCode >= 48 && event.charCode <= 57 && event.charCode <= 190) || event.charCode == 46' /> </td>" +
                                            "</tr>" +

                                            "<tr>" +
                                               "<td> " +
                                               "</td>" +
                                               "<td><img src=\"../../Images/AddButtonBlue.png\" style='cursor: pointer;' id='imgadd" + CID + "' onclick='checkTotal(this,txtCount" + CID + ",txtCrime" + CID + ",txtBail" + CID + "," + trEditID + "," + CID + "," + CID + ");' />&nbsp;&nbsp;" +
                                               "<img src=\"../../Images/CancelButtonBlue.png\" style='cursor: pointer;' id='imgcancel" + CID + "' onclick='clearData(imgadd" + CID + ",txtCount" + CID + ",txtCrime" + CID + ",txtBail" + CID + ");'  />" +
                                               "</td>" +
                                            "</tr>" +
                                        "</table>";

                $("#" + trEditID).append(newArrestRow);

            }
            else {
                $("#" + trEditID).append(newArrestRow);
                $("#" + 'trheaderarrest' + CID).remove();
                $("#" + 'trarrest' + CID).remove();
                $("#" + 'editarrest' + CID).remove();
                $("#" + 'trstaticheader' + CID).remove();
                $("table.tblcount" + CID + "").remove();
            }
        }



        function checkTotal(imgInput, countInput, crimeInput, bailInput, trEdit, CID) {
            var imgID = imgInput.id;
            var newCountRow = "";
            var RID = 0;
            var trEditID = trEdit.id;
            var countID = countInput.id;
            var crimeID = crimeInput.id;
            var bailID = bailInput.id;
            var countValue = $("#" + countID).val();
            var crimeValue = $("#" + crimeID).val();
            var bailValue = $("#" + bailID).val();
            debugger;
            if (bailValue.indexOf(".") == -1) {
                bailValue = bailValue + ".00";
            }

            var arr = imgInput.src.split('/');

            if (arr[4] == "UpdateButtonBlue.png") {
                var editCount = document.getElementById('<%= hdnDeleteId.ClientID%>').value;
                var divID = editCount;
                var trID = divID.replace("editcount", "trcount");

                $("#" + trID).remove();

                var divCount = $("#maintable tr").size();
                if (divCount <= 0) {
                    document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "";
                }
                document.getElementById('<%= hdnDeleteId.ClientID%>').value = "";
                imgInput.src = "../../Images/AddButtonBlue.png";
            }

            if (countValue != '' && crimeValue != '' && bailValue != '') {
                var totalBail = (countValue * bailValue);

                if (totalBail.toString().indexOf(".") == -1) {
                    totalBail = totalBail + ".00";
                }
                else { totalBail = totalBail.toFixed(2) }

                /*** arrest bail amount preview table adding ***/
                var arrestnewtable = "<div id='divpreviewcount" + CID + "' ><table style='text-align: center;' class='tblpreviewcount' id='tblpreviewcount" + CID + "' cellpadding=\"2\" cellspacing=\"0\" width='100%'> " +
                                             "<tr id='firsttr" + CID + "'>" +
                                               "<th>COUNTS</th>" +
                                               "<th>CRIME</th>" +
                                               "<th>BAIL</th>" +
                                               "<th>TOTAL BAIL</th>" +
                                               "<th></th>" +
                                               "<th></th>" +
                                             "</tr>" +
                                             "<tr id='lasttr" + CID + "'>" +
                                               "<td colspan='4' align='right' style='padding-right: 30px;'><span id='arrestedTotal" + CID + "' style='font-weight:bold;'></span></td><td colspan='2'>&nbsp;</td>" +
                                            "</tr>" +
                                        "</table></div>";



                if ($('#edit' + CID + ' table').length == 2)
                    $('#edit' + CID).append(arrestnewtable);
                //$('.previewIcon').css('display', 'block');


                // GET MAX DIV ID
                RID = RID + 2;
                for (i = RID; i <= RID; i++) {
                    if (!document.getElementById("trcount" + RID)) {
                        break;
                    }
                    else {
                        RID++;
                    }
                }

                newCountRow = "<tr id='trcount" + RID + "'>" +
                                                   "<td >" + countValue + "</td>" +
                                                   "<td>" + crimeValue + "</td>" +
                                                   "<td>$" + bailValue + "</td>" +
                                                   "<td><input type='hidden'  class='classtotalbail' value='" + totalBail + "' /> <b>$" + totalBail + "</b></td>" +
                                                   "<td style='padding-right:10px;'><img src=\"../../Images/icon_modify.gif\" class='previewIcon' style='cursor: pointer;' id='imgedit" + RID + "' onclick=\"editTotalBail('" + countID + "', '" + crimeID + "', '" + bailID + "','" + countValue + "','" + crimeValue + "','" + bailValue + "','editcount" + RID + "','" + imgID + "')\"  /></td>" +
                                                   "<td style='padding-right:10px;'><img src=\"../../Images/icon_delete.gif\" class='previewIcon' style='cursor: pointer;' id='imgcancel" + RID + "'  onclick=\"deleteTotalBail('editcount" + RID + "','" + CID + "')\"  /></td>" +
                                                 "</tr>";

                /*** append new bail row here ***/
                ;
                $("#maintable #firsttr" + CID).after(newCountRow);

                $("#" + countID).val("");
                $("#" + crimeID).val("");
                $("#" + bailID).val("");

                CalcBailTotalAmount(CID);
            }
            else {
                alert('Fill the Arrested Incident Information Details');
            }

        }

        function CalcBailTotalAmount(CID) {
            debugger;

            var MainTotal = 0.00;
            $("#maintable #tblpreviewcount" + CID + " .classtotalbail").each(function () {
                MainTotal = MainTotal + parseFloat($(this).val());
            });

            if (MainTotal.toString().indexOf(".") == -1) {
                MainTotal = MainTotal + ".00";
            }

            /*** All rows of bail :: total bail amount ***/
            $("#maintable #arrestedTotal" + CID).text("Total: $" + MainTotal.toFixed(2));
        }


        function deleteTotalBail(editCount, CID) {
            var divID = editCount;
            var trID = divID.replace("editcount", "trcount");

            if (confirm("Are you sure you want to delete ?")) {
                $("#" + trID).remove();

            }
            var divCount = $("#maintable tr").size();
            if (divCount <= 0) {
                document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "";
            }
            debugger;
            CalcBailTotalAmount(CID);
        }

        function editTotalBail(countInput, crimeInput, bailInput, countValue, crimeValue, bailValue, editCount, ImgInput) {

            $("#" + countInput).val(countValue);
            $("#" + crimeInput).val(crimeValue);
            $("#" + bailInput).val(bailValue);
            $("#" + ImgInput).attr('src', '../../Images/UpdateButtonBlue.png');
            document.getElementById('<%= hdnDeleteId.ClientID%>').value = editCount;
        }


        function clearData(ImgInput, countInput, crimeInput, bailInput) {
            var countID = countInput.id;
            var crimeID = crimeInput.id;
            var bailID = bailInput.id;
            var ImgID = ImgInput.id;
            $("#" + countID).val("");
            $("#" + crimeID).val("");
            $("#" + bailID).val("");
            $("#" + ImgID).attr('src', '../../Images/AddButtonBlue.png');
        }


        // Delete Call Header Row & Preview & Edit html
        function RemovePanel(value) {

            var divID = value.id;
            var trID = divID.replace("edit", "tr");
            var trHeaderID = divID.replace("edit", "trheader");
            var trpreviewID = divID.replace("edit", "trpreview");

            if (confirm("Are you sure you want to delete ?")) {
                $("#" + trID).remove();
                $("#" + trHeaderID).remove();
                $("#" + trpreviewID).remove();
            }
            var divCount = $("#maintable tr").size();
            if (divCount <= 0) {
                document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "";
            }
        }

        function AddVehicle() {

            document.getElementById('<%= hdnBlockType.ClientID%>').value = 2;
            if ($(".incidentclass")[0]) {
                //document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "";
            }

            tableCheck();

            //GETTING DIVS COUNT
            var CID = 1;
            var divtable = document.getElementById('maintable');
            for (i = CID; i <= CID; i++) {
                if (!document.getElementById("trheader" + i)) {
                    break;
                }
                else {
                    CID++;
                }
            }
            document.getElementById('VehicleDivIds').value = CID;

            var newRow = "<table class='drop'><tr><td><tr class=\"trheader\" id='trheader" + CID + "' >" +
            //"<td style=\"border-left: 2px dashed blue; border-right: 2px dashed blue; border-Top: 2px dashed blue; border-bottom:1px solid gray;\">" +
                                "<td><span style='font-weight:bold;margin-left: 120px;'>Vehicle Incident Information</span><br/>" +
                                    "<img align='right' src=\"../../Images/EditVehicle.png\" style='cursor: pointer;  padding-right:5px; display:none;' id='imgedit" + CID + "' onclick='EditPanel(trpreview" + CID + ")'  />&nbsp;&nbsp;" +
                                    "<img align='right' src=\"../../Images/DeleteVehicle.png\" style='cursor: pointer; padding-right:5px;' onclick='RemovePanel(edit" + CID + ")' />&nbsp;&nbsp;" +
                                "</td>" +
                          "</tr>" +
                          "<tr id='trpreview" + CID + "' style='display:none;' ><td id='tdpreview" + CID + "'  style='min-width: 300px;' ></td></tr>" +
                          "<tr id='tr" + CID + "' class='Vehicleclass' >" +
                                "<td >" +
                                    "<div class=\"incident\" id=\"edit" + CID + "\"> " +
                                        "<table style='border-bottom:2px solid gray;' cellpadding=\"2\" cellspacing=\"0\" width='100%'> " +
                                            "<colgroup>" +
                                                "<col width='120px' />" +
                                                "<col width='*' />" +
                                            "</colgroup>" +

                                            "<tr>" + // Make
                                                "<td><span style='font-weight:bold;'>Make:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtMake" + CID + "' name='txtMake" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // Model
                                                "<td><span style='font-weight:bold;'>Model:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtModel" + CID + "' name='txtModel" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // License
                                                "<td><span style='font-weight:bold;'>License:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtLicense" + CID + "' name='txtLicense" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // License State
                                                "<td><span style='font-weight:bold;'>License State:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtLicState" + CID + "' name='txtLicState" + CID + "' /> </td>" +
                                            "</tr>" +

                                            "<tr>" + // Color
                                                "<td><span style='font-weight:bold;'>Color:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtColor" + CID + "' name='txtColor" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // Style
                                                "<td><span style='font-weight:bold;'>Style:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtStyle" + CID + "' name='txtStyle" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // Year
                                                "<td><span style='font-weight:bold;'>Year:</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtYear" + CID + "' name='txtYear" + CID + "' /> </td>" +
                                            "</tr>" +

                                             "<tr>" + // Other
                                                "<td><span style='font-weight:bold;'>Other:</span></td>" +
                                                "<td> <textarea style='font-weight:bold;' id='txtOther" + CID + "'></textarea></td>" +
                                            "</tr>" +

                                            "<tr id='trEmpty" + CID + "'>" +
                                                "<td colspan='2'>&nbsp;</td>" +
                                            "</tr>" +
                                        "</table>" +
                                    "</div>" +
                                "</td>" +
                            "</tr></td></tr></table>";


            if (divtable.rows.length == 0) {
                $("#maintable").append(newRow);
            }
            else {
                var lastrow = CID - 1;
                $("#tr" + lastrow).after(newRow);
            }

            //Auto scroll when add new item
            var objDiv = document.getElementById("divMain");
            objDiv.scrollTop = objDiv.scrollHeight;

            LoadBlocks();
        }

        /*** For every form have only one Author Block ***/
        function Show_Hide_AuthorBlock_AddingButton() {
            if (document.getElementById('tblAuthor') == null) {
                $("#imgAddAuthor").css("display", "block");
            }
            else {
                $("#imgAddAuthor").css("display", "none");
            }
        }


        function AddBlocks(blockname) {

            var headerTitle = "";
            if (blockname == "DIV_TEXT") {
                headerTitle = "Summary";
            } else if (blockname == "DIV_IMAGE") {
                headerTitle = "Images";
            }
            else if (blockname == "DIV_TEXT_AUTHOR") {

                headerTitle = "Author";
            }

            document.getElementById('<%= hdnImageTextType.ClientID%>').value = 3;

            tableCheck();

            /*** Main Row Count -- CID for Row ID***/
            var CID = 1;
            for (i = CID; i <= CID; i++) {
                if (!document.getElementById("trheader" + i)) {
                    break;
                }
                else {
                    CID++;
                }
            }

            if (document.getElementById('tbl' + headerTitle) == null) {
                var newTable = "<table class='drop'><tr><td><tr class=\"trheader\" id='trheader" + CID + "'  >" +
                                         "<td align='center' style='border-bottom: 1px dotted  grey;'><span style='font-weight:bold;'> " + headerTitle + " </span><br/>" +
                                         "</td>" +
                               "</tr>" +
                               "<tr id='trpreview" + CID + "' style='display:none;' ><td id='tdpreview" + CID + "'></td></tr>" +
                               "<tr id='tr" + CID + "' class='" + headerTitle + "class' >" +
                                "<td>" +
                                    "<div id=\"edit" + CID + "\"> " +
                                        "<table id='tbl" + headerTitle + "' cellpadding=\"0\" cellspacing=\"0\" style=\"border: 0px solid gray; " +
                                                                        "min-height: 100px;\"> " +
                                         "</table>" +
                                     "</div>" +
                                "</td>" +
                            "</tr></td></tr></table>";

                $("#maintable").append(newTable);
            }
            else {
                CID = $("#tbl" + headerTitle).parent().attr("id").replace("edit", "");
            }

            //GETTING DIVS COUNT
            var rowID = 0;
            var divtable = document.getElementById('tbl' + headerTitle);
            for (i = 0; i < divtable.rows.length; i++) {
                for (j = 0; j < divtable.rows[i].cells.length - 1; j++) {
                    for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                        rowID++;
                    }
                }
            }

            // GET MAX DIV ID
            rowID = rowID + 1;

            var editingBlock = "";
            var className = "textdivStyle";
            var headingName = "";
            var authorDetails = "";

            var appendRow = "";
            if (blockname == "DIV_TEXT") {

                /***  Getting Row uniqueID ***/
                for (i = rowID; i <= rowID; i++) {
                    if (!document.getElementById("TextTrRow" + i)) {
                        break;
                    }
                    else {
                        rowID++;
                    }
                }

                //New Row Append
                appendRow = "<tr id='TextTrRow" + rowID + "' >" +
                            "<td style='min-height: 20px;'>" +
                                " <div id='TextParentEdit" + rowID + "' style='float: left; margin-top: 10px;' class='assigned' >" +
                                       "<div id='TextSubEdit" + rowID + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >" +
                                       "</div>" +
                                        "<div id='TextEditSection" + rowID + "' class='editsectionclass' style='float:left;' >" +
                                            "&nbsp;<img src='../../Images/EditText.png'  style='cursor: pointer;' onclick='ShowPopup(TextSubEdit" + rowID + ")' />" +
                                            "<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(TextTrRow" + rowID + "," + CID + ")' />" +
                                        "</div>" +
                                "</div>" +
                         "</td>" +
                    "</tr>";

                $("#tbl" + headerTitle).append(appendRow);
                //Auto scroll when add new item
                var co = document.getElementById("TextSubEdit" + rowID);
                co.focus();


            } // Text DIV END
            else if (blockname == "DIV_IMAGE") {

                /***  Getting Row uniqueID ***/
                for (i = rowID; i <= rowID; i++) {
                    if (!document.getElementById("ImageTrRow" + i)) {
                        break;
                    }
                    else {
                        rowID++;
                    }
                }

                //New Row Append
                appendRow = "<tr id='ImageTrRow" + rowID + "' >" +
                            "<td style='min-height: 20px;'>" +
                                " <div id='ImageParentEdit" + rowID + "' style='float: left; margin-top: 10px;' class='assigned' >" +
                                       "<div id='ImageSubEdit" + rowID + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >" +
                                       "</div>" +
                                        "<div id='ImageEditSection" + rowID + "' class='editsectionclass' style='float:left;' >" +
                                           "&nbsp;<img src='../../Images/EditImage.png'  style='cursor: pointer;' onclick='EditImage(ImageSubEdit" + rowID + ")' />" +
                                        "<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(ImageTrRow" + rowID + "," + CID + ")' />" +
                                        "</div>" +
                                "</div>" +
                         "</td>" +
                    "</tr>";

                $("#tbl" + headerTitle).append(appendRow);
                //Auto scroll when add new item
                var co = document.getElementById("ImageSubEdit" + rowID);
                co.focus();


            } // DIV Image END
            else if (blockname == "DIV_TEXT_AUTHOR") {

                /***  Getting Row uniqueID ***/
                for (i = rowID; i <= rowID; i++) {
                    if (!document.getElementById("AuthorTrRow" + i)) {
                        break;
                    }
                    else {
                        rowID++;
                    }
                }


                //New Row Append
                appendRow = "<tr id='AuthorTrRow" + rowID + "' >" +
                            "<td style='min-height: 20px;'>" +
                                " <div id='AuthorParentEdit" + rowID + "' style='float: left; margin-top: 10px;' class='assigned' >" +
                                       "<div id='AuthorSubEdit" + rowID + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >" +
                                       "</div>" +
                                        "<div id='AuthorEditSection" + rowID + "' class='editsectionclass' style='float:left;' >" +
                                            "&nbsp;<img src='../../Images/EditText.png'  style='cursor: pointer;' onclick='ShowPopup(AuthorSubEdit" + rowID + ")' />" +
                                            "<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(AuthorTrRow" + rowID + "," + CID + ")' />" +
                                        "</div>" +
                                "</div>" +
                                " <br/> <table id='tblAuthorDetails" + rowID + "' cellpadding=\"2\" cellspacing=\"0\" width='100%' class='authorClass'> " +
                                 "<tr>" + // Author Title
                                   "<td><span style='font-weight:bold;'>Title:</span></td>" +
                                   "<td><input type='text' style='font-weight:bold;' id='txtAuthorTitle" + rowID + "' name='txtAuthorTitle" + rowID + "' /></td>" +
                                 "</tr>" +
                                 "<tr>" + // Author Phone
                                    "<td><span style='font-weight:bold;'>Phone:</span></td>" +
                                    "<td><input type='text' style='font-weight:bold;' id='txtPhone" + rowID + "' name='txtPhone" + rowID + "' MaxLength='12' onkeypress='return event.charCode >= 48 && event.charCode <= 57' /></td>" +
                                 "</tr>" +
                                 "<tr>" + // Author Email
                                    "<td><span style='font-weight:bold;'>Email:</span></td>" +
                                    "<td><input type='text' class='divemailid' style='font-weight:bold;' id='txtEmail" + rowID + "' name='txtEmail" + rowID + "'  /><br/><div id='divEmail" + rowID + "></div></td>" +
                                 "</tr>" +
                                "</table>" +
                         "</td>" +
                    "</tr>";


                $("#tbl" + headerTitle).append(appendRow);
                //Auto scroll when add new item
                var co = document.getElementById("AuthorSubEdit" + rowID);
                co.focus();

                /*** Enable & Disable Author Add Block ***/
                Show_Hide_AuthorBlock_AddingButton();

            } // Text DIV Author END

            LoadBlocks();

        }
        function LoadBlocks() {
            $(".drop").sortable({
                connectWith: ".drop",
                scrollSpeed: 5
            });

            $(".drop").disableSelection();

        }

        //Show the Image Gallery
        function EditImage(value) {

            imgdivID = value.id;
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (290) + "&imgSrc=" + imgSrc + "&folder=Templates");
            //ifrm.style.height = "750px";
            ifrm.style.height = "650px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('DIDIFrm').appendChild(ifrm);
            document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("popupimage");
            modalDialog.show();

        }

        function RemoveBlock(value, CID) {

            var divID = value.id;

            if (confirm("Are you sure you want to delete this block?")) {
                $("#" + divID).remove();

                if (document.getElementById("tblSummary") != null & $("#tblSummary tr").length <= 0) {
                    $("#trheader" + CID).remove();
                    $("#trpreview" + CID).remove();
                    $("#tr" + CID).remove();
                }
                else if (document.getElementById("tblImages") != null & $("#tblImages tr").length <= 0) {
                    $("#trheader" + CID).remove();
                    $("#trpreview" + CID).remove();
                    $("#tr" + CID).remove();
                }
                else if (document.getElementById("tblAuthor") != null & $("#tblAuthor tr").length <= 0) {
                    $("#trheader" + CID).remove();
                    $("#trpreview" + CID).remove();
                    $("#tr" + CID).remove();

                    /*** Enable & Disable Author Add Block ***/
                    Show_Hide_AuthorBlock_AddingButton();
                }
            }

        } /*** END  RemoveBlock ***/

        function ShowExTimeDiv() {
         var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }
            if (document.getElementById("<%=txtExpires.ClientID %>").value == "" || document.getElementById("<%=txtExpires.ClientID %>").value == "MM/DD/YYYY") {
                document.getElementById(controlName).disabled = true;
            }
            else {
                document.getElementById(controlName).disabled = false;
            }
        }

        function ShowPublish(val, ischanges) {
            if (val == "1") {
                document.getElementById('divpublish').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
                ShowPublishSave('1');
            } else if (val == "2") {
              if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "") {
                    GetCurrentDate();
                }
                ShowPublishSave('2');
            }
        }
        function ShowPublishSave(val) {
            if (val == "1") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";

            } else if (val == "2") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";

                document.getElementById('divpublish').style.display = "block";
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

        function DisplayComplete() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                document.getElementById('divpublish').style.display = "block";
               if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                ShowPublish('2');
            }
            ShowExTimeDiv();
        }

        function PreviewHTML(type) {

            //Type 1:: Preview 
            // Type 2:: Save

            var divCount = $("#maintable div").size();
            var divtable = "";
            if (divCount > 0) {
                // set attribute to property value Textboxes values
                var elems = document.getElementById("maintable").getElementsByTagName("input");
                for (var i = 0; i < elems.length; i++) {
                    if (elems[i].type == "text") {
                        elems[i].setAttribute("value", elems[i].value);
                    }
                }

                ////set attribute to property value ddl values
                var elems_select = document.getElementById("maintable").getElementsByTagName("select");
                for (i = 0; i < elems_select.length; i++) {
                    var id = elems_select[i].id;
                    var selectedValue = $("#" + id).val();
                    $("#" + id + " option").removeAttr("selected");
                    $("#" + id + " option").filter(function () {
                        return $(this).attr('value') == selectedValue;
                    }).attr('selected', true);

                }

                divtable = document.getElementById("maintable");
            }

            var ROWS = "";
            var previewHTMLStr = "";

            var XMLString = "";


            // Incident Details
            //Title
            var Title = "<%=BulletinName %>";

            //XML
            XMLString = XMLString + " Title='" + Title + "'";

            if (Title != "") {
                //HTML

                ROWS = ROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px;'> Title: " + Title + "</td></tr>";
            }

            //Location
            var Location = document.getElementById("<%=txtLocation.ClientID %>").value;

            //XML
            XMLString = XMLString + " Location='" + Location + "'";

            if (Location != "") {
                //HTML

                ROWS = ROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px;'> Location: " + Location + "</td></tr>";
            }
            //Case Number
            var StartIncident = document.getElementById("<%=txtStartIncidentNo.ClientID %>").value;
            var EndIncident = document.getElementById("<%=txtEndIncidentNo.ClientID %>").value;
            var CaseNumber = StartIncident + '-' + EndIncident;


            //XML
            XMLString = XMLString + " CaseNumber='" + CaseNumber + "'";

            if (CaseNumber != "") {
                //HTML

                ROWS = ROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px;'> Incident Number: " + CaseNumber + "</td></tr>";
            }

            //Date & Time
            var Date = document.getElementById("<%=txtIncidentDate.ClientID %>").value.replace('MM/DD/YYYY', '');
            var Time = document.getElementById("<%=txtIncidentTime.ClientID %>").value==''?'':document.getElementById("<%=txtIncidentTime.ClientID %>").value;
            var DateTime = Date + (Time==''?'':' at ' + Time);

            //XML
            XMLString = XMLString + " DateTime='" + DateTime + "'";

            if (DateTime != "") {
                //HTML

                ROWS = ROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px;'> Date&Time: " + DateTime + "</td></tr>";
            }


            // end Incident Details
            var sencodBoder = "";
            var firstBorder = "";
            if (ROWS != "")
                firstBorder = "<tr><td colspan='2'><table cellpadding='0' cellspacing='0' style='width: 300px;'>" + ROWS + "</table></td></tr>";

            if (document.getElementById("maintable") != null)
                var elems = document.getElementById("maintable").getElementsByTagName("div");

            var incidentType = document.getElementById('<%= hdnBlockType.ClientID%>').value;
            var i = 0;
            totalchildXMlString = "";
            var childTable = "";
            if ($('#maintable .drop > tbody tr').length > 0) {
                $('#maintable .drop > tbody tr.incidentclass, #maintable .drop > tbody tr.Vehicleclass , #maintable .drop > tbody tr.Summaryclass, #maintable .drop > tbody tr.Imagesclass, #maintable .drop > tbody tr.Authorclass').each(function () {
                    i = $(this).attr('id').replace('tr', '');
                    if ($(this).attr("class") == 'incidentclass') { // *** Start of person
                        var personHeading = "<tr><td><div style=\"font-family: Arial, Helvetica, sans-serif; background-color:#2f348f; color:white; font-size: 14px; margin: 0 auto; padding: 10px; text-align:center;\"><b>Person Incident Information</b></div></td></tr>";
                        var childRow = personHeading + "<tr><td><table style='width:100%'>";
                        var arrestHTML = "";
                        var childXMLElements = "";

                        var PersonType = $("#ddlPType" + i + " option:selected").text();
                        if (PersonType == 'Select')
                            PersonType = '';

                        var FName = ReplaceSpecialCharacter(document.getElementById("txtFName" + i).value.trim());

                        var MName = ReplaceSpecialCharacter(document.getElementById("txtMName" + i).value.trim());

                        var LName = ReplaceSpecialCharacter(document.getElementById("txtLName" + i).value.trim());

                        var Address = ReplaceSpecialCharacter(document.getElementById("txtAddress" + i).value.trim());
                        document.getElementById("txtAddress" + i).innerHTML = Address;

                        var City = ReplaceSpecialCharacter(document.getElementById("txtCity" + i).value.trim());

                        var State = ReplaceSpecialCharacter(document.getElementById("txtState" + i).value.trim());

                        var DOB = ReplaceSpecialCharacter(document.getElementById("txtDOB" + i).value.trim());

                        var Age = ReplaceSpecialCharacter(document.getElementById("txtAge" + i).value.trim());

                        var Male = document.getElementById("rdMale" + i);
                        var Gender = "";
                        if (Male.checked)
                            Gender = ReplaceSpecialCharacter(document.getElementById("rdMale" + i).value.trim());
                        else
                            Gender = ReplaceSpecialCharacter(document.getElementById("rdFemale" + i).value.trim());

                        var Other = ReplaceSpecialCharacter(document.getElementById("txtOther" + i).value.trim());


                        if (PersonType != "") {

                            // HTML
                            childRow = childRow + "<tr><td colspan='2' style='background-color: #e0d9d6; padding:5px; patext-transform: uppercase;'><b>" + PersonType + "</b></td></tr>";
                            personHeading = "";

                            // XML
                            childXMLElements = childXMLElements + " PersonType='" + PersonType + "' ";
                        }


                        // HTML
                        childRow = childRow + "<tr><td style=' padding:5px;'>" + FName + " " + MName + " " + LName + "</td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " FName='" + FName + "' MName='" + MName + "' LName='" + LName + "' ";


                        if (Address != "") {
                            // HTML
                            childRow = childRow + "<tr><td style=' padding:5px;'>" + Address + "</td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Address='" + Address + "' ";
                        }

                        if (City != "" || State != "") {
                            // HTML
                            childRow = childRow + "<tr><td style=' padding:5px;'>" + City + "," + State + "</td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " City='" + City + "' State='" + State + "' ";
                        }

                        if (DOB != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid;  padding:5px;'>Date of Birth:</td><td style='padding-top:5px;'><b>" + DOB + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " DOB='" + DOB + "' ";
                        }

                        if (Age != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding:5px;'>Age:</td><td style='padding-top:5px;'><b>" + Age + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Age='" + Age + "' ";
                        }

                        if (Gender != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid;  padding:5px;'>Gender:</td><td style='padding-top:5px;'><b>" + Gender + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Gender='" + Gender + "' ";
                        }

                        if (Other != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid;  padding:5px;'>Other:</td><td style='padding-top:5px;'><b>" + Other + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Other='" + Other + "' ";
                        }
                        var childRow = childRow + "</table></td></tr>";
                        // rows append to single table
                        childRow = "<table class='radius' id='tblpreview" + i + "' cellpadding='0' cellspacing='0' style=' width: 300px; border-bottom: 0px solid black; margin-top:5px;'>" + childRow + "</table>";

                        //Arrest Information Append
                        if (PersonType == "Arrested") {
                            if (document.getElementById("divpreviewcount" + i) != null) {
                                arrestHTML = document.getElementById("divpreviewcount" + i).outerHTML;
                                arrestHTML = arrestHTML.replace(/<img[^>]*>/g, "");
                                childRow = childRow + arrestHTML;
                            }
                        }

                        // Loop table (append one by one table)
                        childTable = childTable + childRow;

                        //XML Sub Elements
                        totalchildXMlString = totalchildXMlString + childXMLElements;
                    } // *** End of Person
                    else if ($(this).attr("class") == 'Vehicleclass') { // *** Start of Vehicle
                        var vechicalHeading = "<tr><td><div style=\"font-family: Arial, Helvetica, sans-serif; background-color:#2f348f; color:white; font-size: 14px; margin: 0 auto; padding: 10px; text-align:center;\"><b>Vehicle Incident Information</b></div></td></tr>";
                        var childRow = vechicalHeading + "<tr><td><table style='width:100%'>";
                        var childXMLElements = "";

                        var Make = ReplaceSpecialCharacter(document.getElementById("txtMake" + i).value.trim());

                        var Model = ReplaceSpecialCharacter(document.getElementById("txtModel" + i).value.trim());

                        var License = ReplaceSpecialCharacter(document.getElementById("txtLicense" + i).value.trim());

                        var LicenseState = ReplaceSpecialCharacter(document.getElementById("txtLicState" + i).value.trim());

                        var Color = ReplaceSpecialCharacter(document.getElementById("txtColor" + i).value.trim());

                        var Style = ReplaceSpecialCharacter(document.getElementById("txtStyle" + i).value.trim());

                        var Year = ReplaceSpecialCharacter(document.getElementById("txtYear" + i).value.trim());

                        var Other = ReplaceSpecialCharacter(document.getElementById("txtOther" + i).value.trim());
                        document.getElementById("txtOther" + i).innerHTML = Other;

                        if (Make != "") {

                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Make:</td><td style='padding:5px;'><b>" + Make + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Make='" + Make + "' ";

                            vechicalHeading = "";
                        }
                        if (Model != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Model:</td><td style='padding:5px;'><b>" + Model + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Model='" + Model + "' ";
                        }
                        if (License != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>License:</td><td style='padding:5px;'><b>" + License + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " License='" + License + "' ";
                        }
                        if (LicenseState != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>License State:</td><td style='padding:5px;'><b>" + LicenseState + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " LicenseState='" + LicenseState + "' ";
                        }
                        if (Color != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Color:</td><td style='padding:5px;'><b>" + Color + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Color='" + Color + "' ";
                        }
                        if (Style != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Style:</td><td style='padding:5px;'><b>" + Style + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Style='" + Style + "' ";
                        }
                        if (Year != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Year:</td><td style='padding:5px;'><b>" + Year + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Year='" + Year + "' ";
                        }


                        if (Other != "") {
                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Other:</td><td style='padding:5px;'><b>" + Other + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Other='" + Other + "' ";
                        }
                        var childRow = childRow + "</table></td></tr>";
                        childRow = "<table class='radius' id='tblpreview" + i + "' cellpadding='0' cellspacing='0' style='border-bottom: 0px solid black; margin-top:4px; width: 300px;'>" + childRow + "</table>";
                        childTable = childTable + childRow;

                        //XML Sub Elements
                        totalchildXMlString = totalchildXMlString + childXMLElements;
                    } // *** End of Vehicle
                    else if ($(this).attr("class") == 'Summaryclass') // *** Start of Summary
                    {
                        $('#tblSummary tr', this).each(function () {
                            childRow = "<tr><td><div style=\"font-family: Arial, Helvetica, sans-serif; background-color:#2f348f; color:white; font-size: 14px; margin: 0 auto; padding: 10px; text-align:center;\"><b> Summary </b></div></td></tr>";
                            var j = $(this).attr('id').replace('TextTrRow', '');
                            var textControl = document.getElementById("TextSubEdit" + j).innerHTML;

                            // summary HTML
                            childRow = childRow + "<tr><td style='padding-top:2px; padding-left:5px;'>" + textControl + "</td></tr>";
                            childRow = "<table class='radius' id='tblpreviewsummary" + i + "' cellpadding='0' cellspacing='0' style='margin-top:5px; width: 300px;'>" + childRow + "</table>";
                            childTable = childTable + childRow;
                        });
                    } // *** End of Summary
                    else if ($(this).attr("class") == 'Imagesclass') // *** Start of Images
                    {
                        childRow = "<tr><td><div style=\"font-family: Arial, Helvetica, sans-serif; background-color:#2f348f; color:white; font-size: 14px; margin: 0 auto; padding: 10px; text-align:center;\"><b> Images </b></div></td></tr>";
                        $('#tblImages tr', this).each(function () {
                            var j = $(this).attr('id').replace('ImageTrRow', '');
                            var imgControl = document.getElementById("ImageSubEdit" + j).innerHTML;

                            // Image HTML
                            childRow = childRow + "<tr><td style='padding-top:2px;'>" + imgControl + "</td></tr>";

                        });
                        childRow = "<table class='radius' id='tblpreviewimages' cellpadding='0' cellspacing='0' style='margin-top:5px; width: 300px;'>" + childRow + "</table>"
                        childTable = childTable + childRow;
                    } // *** End of Images
                    else if ($(this).attr("class") == 'Authorclass') // *** Start of Author
                    {
                        childRow = "<tr><td><div style=\"font-family: Arial, Helvetica, sans-serif; background-color:#2f348f; color:white; font-size: 14px; margin: 0 auto; padding: 10px; text-align:center;\"><b> Author </b></div></td></tr>";
                        $('#tblAuthor .textdivStyle', this).each(function () {
                            var j = $(this).attr('id').replace('AuthorTrRow', '');
                            var textControl = document.getElementById($(this).attr('id')).innerHTML;

                            // Image HTML
                            childRow = childRow + "<tr><td style='padding-top:2px; padding-left:5px;'>" + textControl + "</td></tr>";
                        });
                        $('#tblAuthor .authorClass', this).each(function () {
                            var childXMLElements = "";
                            var j = $(this).attr('id').replace('tblAuthorDetails', '');
                            //Author Details
                            var Title = ReplaceSpecialCharacter(document.getElementById("txtAuthorTitle" + j).value.trim());

                            var Phone = ReplaceSpecialCharacter(document.getElementById("txtPhone" + j).value.trim());

                            var Email = ReplaceSpecialCharacter(document.getElementById("txtEmail" + j).value.trim());

                            if (Title != "") {

                                // HTML
                                childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding:5px;'>Title:</td><td style='padding-top:5px;'><b>" + Title + "</b></td></tr>";
                                // XML
                                childXMLElements = childXMLElements + " Title='" + Title + "' ";

                            }
                            if (Phone != "") {
                                // HTML
                                childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding:5px;'>Phone:</td><td style='padding-top:5px;'><b>" + Phone + "</b></td></tr>";
                                // XML
                                childXMLElements = childXMLElements + " Phone='" + Phone + "' ";
                            }
                            if (Email != "") {
                                // HTML
                                childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding:5px;'>Email:</td><td style='padding-top:5px;'><b>" + Email + "</b></td></tr>";
                                // XML
                                childXMLElements = childXMLElements + " Email='" + Email + "' ";
                            }
                            //XML Sub Elements
                            totalchildXMlString = totalchildXMlString + childXMLElements;
                        });
                        childRow = "<table class='radius' id='tblpreviewauthr' cellpadding='0' cellspacing='0' style='margin-top:5px; width: 300px;'>" + childRow + "</table>";
                        childTable = childTable + childRow;
                    } // *** End of Author
                });      // *** End of foreach for each class of blocks
                sencodBoder = "<tr><td colspan='2'><table cellpadding='0' cellspacing='0' style='width: 300px;'>" + childTable + "</table></td></tr>";
            }
            /*** end preview html ***/


            /*** final html string ***/
            previewHTMLStr = "<table cellpadding='0' cellspacing='0' style='padding-left:0px; padding-top:5px; text-align:left; border:1px solid black;'>" + firstBorder + sencodBoder + "</table>";

            //previewHTMLStr = previewHTMLStr + "</div>";


            //Preview HTMl
            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = previewHTMLStr;
            //Edit HTML
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;

            //Final XML String
            XMLString = "<Bulletins><Details " + XMLString + " /> " + totalchildXMlString + " </Bulletins>";
            document.getElementById("<%=hdnEditXML.ClientID %>").value = XMLString;

            if (type == "1") {
                var bulletinHeader = document.getElementById("<%=hdnBulletinHeader.ClientID %>").value;
                bulletinHeader = bulletinHeader.replace("#BuildHtmlForForm#", previewHTMLStr);
                // Shorten URL Purpose
                document.getElementById("divLoading").style.display = "block";
                bulletinHeader = bulletinHeader.replace(/</gi, "&lt;_");
                bulletinHeader = bulletinHeader.replace(/>/gi, "&gt;_");
                bulletinHeader = bulletinHeader.replace(/'/gi, "&quots;_");

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{htmlString:'" + bulletinHeader + "'}",
                    url: "KPDMediaRelease.aspx/ReplaceShortURltoHmlString",
                    dataType: "json",
                    processData: false,
                    success: function (data) {
                        bulletinHeader = data.d;

                        document.getElementById("<%=lblpreview.ClientID %>").innerHTML = "";
                        document.getElementById("<%=lblpreview.ClientID %>").innerHTML = bulletinHeader;

                        var modal = $find("BulletinPreview");
                        modal.show();

                        document.getElementById("divLoading").style.display = "none";
                        return false;
                    },
                    error: function (error) {
                        //alert("ERROR:: " + error.statusText);
                        document.getElementById("divLoading").style.display = "none";
                    }
                });

                return false;
            }
        }

        function ReplaceSpecialCharacter(value) {
            value = value.replace(/&/gi, "&amp;");
            value = value.replace(/&amp;amp;/gi, "&amp;");

            value = value.replace(/'/gi, "&apos;");
            value = value.replace(/&apos;apos;/gi, "&apos;");

            value = value.replace(/</gi, "&lt;");
            value = value.replace(/&lt;lt;/gi, "&lt;");

            return value;
        }
        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
                DisplayComplete();
            if (document.getElementById('<%=rbPrivate.ClientID %>').checked) {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";
            }
            else {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";
            }

        }
        $(document).ready(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
              if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
        function ValidateEmailID() {
           
            var reurnValue = true;
            var emailID = "";
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            //return expr.test(email);
            //divEmail

            if (document.getElementById("tblAuthor") != null) {
                $("#maintable .divemailid").each(function () {
                    emailID = $(this).val();

                    if (expr.test(emailID) == false & emailID != "") {
                        alert("Invalid email address.");
                        $(this).focus();
                        reurnValue = false;
                        return reurnValue;
                    }
                });
            }

            return reurnValue
        }

        /*** Save HTML Data & Fire Server Save Event ***/
        function SaveHTMLData() {

            //getting preview html
            if (ValidateCallDetails() & ValidateEmailID()) {

                var divtable = document.getElementById("maintable");
                var returnval = true;
                PreviewHTML(2);
                //edit html 
                var divtable = document.getElementById("maintable");
                if (divtable != null) {
                    $('#maintable tr.trheader').each(function () {
                        if ($(this).attr('id').indexOf('trheader') != -1) {
                            var j = $(this).attr('id').replace('trheader', '');
                            $("#tdpreview" + j).html('');
                        }
                    });
                    //Remove preview divs getting only Edit html(input values)
                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                }
                var isCompleted = false;
                var isPrivate = false;
                var exDate = document.getElementById("<%=txtExpires.ClientID %>").value.replace("MM/DD/YYYY", "");
                document.getElementById("<%=hdnExDate.ClientID %>").value = exDate;
                document.getElementById("<%=hdnPrivate.ClientID %>").value = "False";
                isPrivate = document.getElementById('<%=rbPrivate.ClientID %>').checked;
                if (isPrivate.toString() == "true") {
                    document.getElementById("<%=hdnPrivate.ClientID %>").value = "True";
                }
                else {
                    document.getElementById("<%=hdnPrivate.ClientID %>").value = "False";
                }
                document.getElementById("<%=hdnCompleted.ClientID %>").value = isCompleted;
                $find("<%=MPEProgress.ClientID %>").show();
                return true;
            }
            else {
                return false;
            }
        }
        function ValidateCallDetails() {
         var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }
            var reurnValue = true;
            if (Page_ClientValidate('SV') && Page_IsValid) {
                var ExDate = document.getElementById("<%=txtExpires.ClientID %>").value ;
                 var incidentdate = document.getElementById("<%=txtIncidentTime.ClientID %>").value;
                if (incidentdate != "") { 
                   var ExDate_Time = incidentdate ;
                        var todayDate = new Date();
                        ExDate_Time = new Date(ExDate_Time);
                        if (ExDate_Time < todayDate) {
                            alert('Incident date should not be later than current date.');
                            document.getElementById("<%=txtExpires.ClientID %>").focus();
                            reurnValue = false;
                }
                if (ExDate != "") {
                    
                        var ExDate_Time = ExDate + " " +document.getElementById(controlName).value;
                        var todayDate = new Date();
                        ExDate_Time = new Date(ExDate_Time);
                        if (ExDate_Time < todayDate) {
                            alert('Expiration date should be later than current date.');
                            document.getElementById("<%=txtExpires.ClientID %>").focus();
                            reurnValue = false;
                        }
                    }
            }
            else {
                reurnValue = false;
            }

            return reurnValue;
        }
        function LoadData() {
            var divtable = document.getElementById("maintable");
            if (divtable != null) {

                $('#maintable tr.trheader').each(function () {
                    if ($(this).attr('id').indexOf('trheader') != -1) {

                        var j = $(this).attr('id').replace('trheader', '');

                        var arrestHTML = "";
                        if (document.getElementById("divpreviewcount" + j) != null) {
                            arrestHTML = document.getElementById("divpreviewcount" + j).innerHTML
                            arrestHTML = arrestHTML.replace(/<img[^>]*>/g, "");

                        }



                        if (document.getElementById("tblpreview" + j) != null) {

                            var html = document.getElementById("tblpreview" + j).outerHTML;
                            $("#tdpreview" + j).html('');
                            $("#tdpreview" + j).append(html + arrestHTML);
                            document.getElementById("tblpreview" + j).style.width = '100%';
                            $("#tr" + j).css('display', 'none');
                            $("#trpreview" + j).css('display', 'block');
                            $("#imgedit" + j).css('display', 'block');
                            $("#imgedit" + j).css('display', '');
                            //alert(j);
                            $("#tdpreview" + j + " div").css('display', 'none');

                            $(".trheader img").css('display', '');
                        } /*** end if condition ***/
                    }
                });        /*** end loop ***/
            }



            if (document.getElementById('<%=rbPrivate.ClientID %>').checked == true) {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";

            }
            else {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";

            }

            $("#dummyDIV").css('display', 'none');

            /*** Enable & Disable Author Add Block ***/
            Show_Hide_AuthorBlock_AddingButton();

        }
        function EditPanel(controlID, editImageControl) {
            var id = controlID.id.replace(/trpreview/gi, "");
            $("#trpreview" + id).css('display', 'none');

            // For Date Picker Loading....
            $("#txtDOB" + id).removeClass("hasDatepicker");
            LoadDataPickers("txtDOB" + id, "trAge" + id, "txtAge" + id);

            $("#tr" + id).css('display', 'block');
            $("#imgedit" + id).css('display', 'none');


        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="popup" style="display: none;">
            </div>
            <div id='editorPopup' style="display: none; position: absolute; margin-top: 150px;
                margin-left: 150px; z-index: 100;">
                <uc2:UCEditor ID="UCEditor1" runat="server" />
            </div>
            <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
                <div id="wrapper">
                    <div class="headernav">
                        <%=BulletinName %><asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none"
                            BorderColor="white" Style="border: 0; border-color: White!important;"></asp:TextBox>
                    </div>
                    <div style="text-align: center;">
                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                    size="2">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div id="divLoading" style="display: none; width: 300px; margin: 0 auto;">
                            <div style="text-align: center;">
                                <img src="<%=Page.ResolveClientUrl("../../images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                    color="green">Processing....</font></b>
                            </div>
                        </div>
                        <div style="width: 350px; margin: 0 auto;">
                            <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                ValidationGroup="SV" HeaderText="The following error(s) occurred:" />
                        </div>
                    </div>
                    <div>
                        <div style="margin: 0 auto; width: 100%; overflow: hidden;">
                            <asp:Label runat="server" ID="lblLogoHeader"></asp:Label>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            Media Release</div>
                        <div class="form_wrapper">
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <label style="color: Red; font-size: 16px; margin-left: 100px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Incident Number:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtStartIncidentNo" runat="server" Width="20px" MaxLength="2" onkeypress="return isNumber(event)"></asp:TextBox>
                                    -
                                    <asp:TextBox ID="txtEndIncidentNo" runat="server" Width="90px" MaxLength="6" onkeypress="return isNumber(event)"></asp:TextBox>
                                    &nbsp;
                                    <%if (txtStartIncidentNo.Text == "")
                                      { %>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStartIncidentNo"
                                        ValidationGroup="SV" ErrorMessage="Incident Number is mandatory.">*</asp:RequiredFieldValidator>
                                    <%} %>
                                    <%else if (txtEndIncidentNo.Text == "")
                                      { %>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEndIncidentNo"
                                        ValidationGroup="SV" ErrorMessage="Incident Number is mandatory.">*</asp:RequiredFieldValidator>
                                    <%} %>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Incident Date:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtIncidentDate" runat="server"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtIncidentDate"
                                        WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                        ControlToValidate="txtIncidentDate" ValidationGroup="SV" ErrorMessage="Incident Date is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="txtIncidentDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid Date Format of Date.">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIncidentDate"
                                        Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Incident Time:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtIncidentTime" runat="server"></asp:TextBox>
                                    <%--placeholder="hh.mmAM/PM"--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtIncidentTime"
                                        ValidationGroup="SV" ErrorMessage="Incident Time is mandatory.">*</asp:RequiredFieldValidator>
                                    <%--  <asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="Invalid Time Format"
                                        Display="Dynamic" ValidationGroup="SV" ControlToValidate="txtIncidentTime" ValidationExpression="^([1-9]|1[0-2]|0[1-9]){1}(.[0-5][0-9][aApP][mM]){1}$">*
                                    </asp:RegularExpressionValidator>--%>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Incident Location:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtLocation" runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLocation"
                                        ValidationGroup="SV" ErrorMessage="Incident Location is mandatory.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <div id='divMain' class="avatar" style="margin-left: 5px; border-width: 1px;">
                                        <!--min-height: 180px;
                                        width: 505px; max-height: 600px; overflow: auto;-->
                                        <asp:Label ID="lblEditText" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; margin: 5px 0px 0px 337px;">
                                <img style="cursor: pointer;" src="../../Images/AddPerson.png" alt="Add Person" onclick="AddPerson();" /><br />
                                <img style="cursor: pointer;" src="../../Images/AddVehicle.png" alt="Add Vehicle"
                                    onclick="AddVehicle();" /><br />
                                <img style="cursor: pointer;" src="../../Images/ImageBlock.png" alt="Add Image" onclick="AddBlocks('DIV_IMAGE');" /><br />
                                <img style="cursor: pointer;" src="../../Images/TextBlock.png" alt="Add Text" onclick="AddBlocks('DIV_TEXT');" /><br />
                                <img id="imgAddAuthor" style="cursor: pointer;" src="../../Images/AddAuthor.png"
                                    alt="Add Author" onclick="AddBlocks('DIV_TEXT_AUTHOR');" /><br />
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Expiration Date & Time:</label></div>
                                <div class="right_fields" style="width: 470px;">
                                    <table width="85%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                    <colgroup>
                                            <col width="120px" />
                                            <col width="*" />
                                        </colgroup>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtExpires" runat="server" Width="100px"
                                                    Height="18px" onChange="ShowExTimeDiv();"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txtExpires"
                                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExpires" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format of Expiration Date.">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExpires" Format="MM/dd/yyyy"
                                                    CssClass="MyCalendar" />
                                            </td>
                                            <td>
                                             <TimerUC:TimeControl ID="ExpiryTimeControl1" runat="server" Enabled="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <%if (Session["IsLiteVersion"] == null || Convert.ToBoolean(Session["IsLiteVersion"]) == false)
                              { %>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <label id="divCall" runat="server">
                                        <asp:CheckBox ID="chkCall" runat="server" />
                                        Display Call Button</label>
                                    <br />
                                    <label id="divContactUs" runat="server">
                                        <asp:CheckBox ID="chkContact" runat="server" />
                                        Display Contact Us Button</label>
                                    <br />
                                </div>
                            </div>
                            <%} %>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 10px 0px 0px 0px;">
                                        <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                            onclick="javascript:ShowPublish('1','true')" />
                                        <label>
                                            Private</label>
                                        <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2','true')" />
                                        <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                        <div style="margin: 10px 0px 0px 10px; display: none;" id="divpublish">
                                            <div id="divSchedulePublish" style="display: block;">
                                                <font color="red">*</font>
                                                <label style="font-size: 14px;">
                                                    Publish Date:</label>
                                                <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                    ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                    runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                            </div>
                                            <% if ((Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "") || hdnPermissionType.Value == "P")
                                               { %>
                                            <br />
                                            <%if (hdnFacebook.Value == "")
                                              { %>
                                            <asp:CheckBox ID="chkFbAutoPost" runat="server" Text="Auto post on facebook" Style="font-size: 14px;
                                                padding-left: 4px;" /><br />
                                            <%} %>
                                            <%if (hdnTwitter.Value == "")
                                              { %>
                                            <asp:CheckBox ID="chkTwrAutoPost" runat="server" Text="Auto post on twitter" Style="font-size: 14px;
                                                padding-left: 4px;" />
                                            <%} %>
                                            <%} %>
                                            <asp:HiddenField ID="hdnIsAlreadyPublished" runat="server" Value="0" />
                                            <asp:HiddenField ID="hdnFacebook" runat="server" />
                                            <asp:HiddenField ID="hdnTwitter" runat="server" />
                                            <asp:HiddenField ID="hdnPublishDate" runat="server" />
                                            <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                            <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                            <asp:HiddenField ID="hdnArchive" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 450px;">
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" border="0" ValidationGroup="SV"
                                        OnClick="BtnSave_Click" OnClientClick="return SaveHTMLData()" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return PreviewHTML('1');"><img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <input type="hidden" value="2" id="DivIds" />
                <input type="hidden" value="2" id="VehicleDivIds" />
                <input type="hidden" id="CountDivIds" />
                <asp:HiddenField runat="server" ID="hdnEditHTML" />
                <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
                <asp:HiddenField runat="server" ID="hdnEditXML" />
                <input type="hidden" id="hdnChanges" value="false" />
                <input type="hidden" id="editDivCheck" value="" />
                <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
                <asp:HiddenField ID="hdnTimePicker" runat="server" />
                <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
                <asp:HiddenField runat="server" ID="hdnBlockType" />
                <asp:HiddenField runat="server" ID="hdnImageTextType" />
                <input type="hidden" id="hdnalignindex" />
                <asp:HiddenField runat="server" ID="hdnCompleted" />
                <asp:HiddenField runat="server" ID="hdnPrivate" />
                <asp:HiddenField runat="server" ID="hdnExDate" />
                <asp:HiddenField runat="server" ID="hdnDeleteId" />
                <div id='dummyDIV' style="display: none;">
                    <asp:Label runat="server" ID='lbldummy'></asp:Label>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblBulletinPreview" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popupBulletinpreview" runat="server" TargetControlID="lblBulletinPreview"
                PopupControlID="pnlpreviewBulletin" BackgroundCssClass="modal" CancelControlID="imgclosepreviewpopup"
                BehaviorID="BulletinPreview">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlpreviewBulletin" runat="server" Style="display: none" Width="750px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                padding-top: 10px" align="left" colspan="2">
                                <asp:Label ID="lblbulletinamme" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; padding: 10px;" colspan="2">
                                <div style="overflow-y: auto; height: 500px; position: relative; width: auto; padding-right: 30px;">
                                    <asp:Label ID="lblpreview" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
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
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"> Your
                                                        request is in progress, please don't refresh or close window. </font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <%--IMAGE GALLERY * RESIZE IMAGE--%>
            <asp:Label ID="lblbulletinimage" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popbulletinimage" runat="server" TargetControlID="lblbulletinimage"
                PopupControlID="pnlbulletinimage" BackgroundCssClass="modal" BehaviorID="popupimage"
                CancelControlID="imcloseimagepopup">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlbulletinimage" runat="server" Style="display: none" Width="800px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imcloseimagepopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid">
                                <div id="DIDIFrm">
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
        <ContentTemplate>
            <div class="largetxt">
                Media Release
            </div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
