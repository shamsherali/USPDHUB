<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="MostWanted.aspx.cs" Inherits="USPDHUB.Business.MyAccount.MostWanted" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/flyers/jquery-ui-1.8.21.custom.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.textarea-expander.js" type="text/javascript"></script>
    <style type="text/css">
        .textdivStyle
        {
            text-align: justify;
            border: 1px solid black;
            overflow: auto;
            font-family: Arial;
            font-size: 12px;
            width: 200px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
                DisplayComplete();
            if (document.getElementById('<%=rbPrivate.ClientID %>').checked) {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
            }
        }
        function DisplayComplete() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
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
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            } else if (val == "2") {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
            }
        }
        function ShowExTimeDiv() {
            if (document.getElementById("<%=txtExDate.ClientID %>").value == "") {
                document.getElementById("<%=txtExHours.ClientID %>").disabled = true;
                document.getElementById("<%=txtExMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlExSS.ClientID %>").disabled = true;
            }
            else {
                document.getElementById("<%=txtExHours.ClientID %>").disabled = false;
                document.getElementById("<%=txtExMinutes.ClientID %>").disabled = false;
                document.getElementById("<%=ddlExSS.ClientID %>").disabled = false;
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

        function LoadDataPickers(datepickerID) {
            $("#" + datepickerID).datepicker();
        }
        function AddPanel() {
            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"470px\" style=\"border: 0px solid gray; min-height: 100px;\"></table>";
                document.getElementById("<%=lblBulletinedit.ClientID %>").innerHTML = maintableTag;
            }

            //GETTING DIVS COUNT
            var CID = 0;
            var j = 0;
            var rowscount = $('#maintable tr.trheader').length;
            if (rowscount > 0) {
                $('#maintable tr.trheader').each(function () {
                    if ($(this).attr('id').indexOf('trheader') != -1) {
                        j = parseInt($(this).attr('id').replace('trheader', ''));
                        if (j > CID)
                            CID = j;
                    }
                });
            }
            var divtable = document.getElementById('maintable');

            CID = CID + 1;
            document.getElementById('DivIds').value = CID;

            var newRow = "<tr class=\"trheader\" id='trheader" + CID + "' >" +
                                "<td style=\"border-left: 2px dashed blue; border-right: 2px dashed blue; border-Top: 2px dashed blue; border-bottom:1px solid gray;\">" +
                                    "<img align='right' src=\"../../Images/delete.png\" style='cursor: pointer; padding-right:5px;' onclick='RemovePanel(edit" + CID + ")' />&nbsp;&nbsp;" +
                                     "<img align='right' src=\"../../Images/edit.png\" style='cursor: pointer; display:none; padding-right:5px;' id='imgedit" + CID + "' onclick='EditPanel(trpreview" + CID + ")'  />&nbsp;&nbsp;" +
                                "</td>" +
                          "</tr>" +
                          "<tr id='trpreview" + CID + "' style='display:none;' ><td id='tdpreview" + CID + "'></td></tr>" +
                          "<tr id='tr" + CID + "' >" +
                                "<td>" +
                                    "<div  id=\"edit" + CID + "\"> " +
                                        "<table style='border-bottom:2px solid gray;' cellpadding=\"2\" cellspacing=\"0\" width='100%'> " +
                                            "<colgroup>" +
                                                "<col width='120px' />" +
                                                "<col width='*' />" +
                                            "</colgroup>" +
            //                                              "<tr>" + // Image Row Section
            //                                                "<td colspan='2' align='center'><span style='font-weight:bold;'><img src='../../Images/addimg.png' id='imagesection" + CID + "' onclick='AddNewImageDiv(this.id)'  style='cursor: pointer; display:none;' /></span></td>" +
            //                                            "</tr>" +
                                             "<tr>" +
                                                "<td colspan='2'>" +
                                                    "<table id='imgtable" + CID + "' cellpadding='0' cellspacing='0' >" +
                                                        "<colgroup>" +
                                                            "<col width='120px' />" +
                                                            "<col width='*' />" +
                                                        "</colgroup>" +
                                                            "<tr id='imgRow" + CID + "_1'>" + "<td>&nbsp;</td>" +
                                                                "<td>&nbsp;" + // Image Add/Edit
                                                                    "<div  id='divimage" + CID + "_1' style='min-height: 100px; float:left' class='textdivStyle'></div>&nbsp;&nbsp;" +
                                                                    "<div style='float:left; margin-left:6px;'><img src='../../Images/editimg.png'  style='cursor: pointer;' onclick='EditImage(divimage" + CID + "_1," + CID + ")'/> " +
                                                                        "<br/><img src='../../Images/deleteimg.png'  style='cursor: pointer;' onclick='DeleteImage(divimage" + CID + "_1 )' />" +
                                                                    "</div>" +
                                                                "</td>" +
                                                            "</tr>" +

                                                    "</table>" +
                                                "</td>" +
                                            "</tr>" +
                                            "<tr>" + // Name
                                                "<td><span style='font-weight:bold;'>Name</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtName" + CID + "' name='txtName" + CID + "' /> </td>" +
                                            "</tr>" +
                                            "<tr>" + // Docket
                                                "<td><span style='font-weight:bold;'>Docket</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtDocket" + CID + "' name='txtDocket" + CID + "' /> </td>" +
                                            "</tr>" +
                                             "<tr>" + // Bail Amount
                                                "<td><span style='font-weight:bold;'>Bail Amount</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtAmt" + CID + "' name='txtAmt" + CID + "' /> </td>" +
                                            "</tr>" +
                                            "<tr>" + // Sex
                                                "<td><span style='font-weight:bold;'>Sex</span></td>" +

                                                "<td><select style='width:165px' id='ddlGender" + CID + "' name='ddlGender" + CID + "' onLoad='loadGender(this.id)'><option>Select</option></select></td>" +
                                            "</tr>" +
                                             "<tr>" + // Race
                                                "<td><span style='font-weight:bold;'>Race</span></td>" +

                                                "<td><select style='width:165px' id='ddlRace" + CID + "' name='ddlRace" + CID + "' onLoad='loadRace(this.id)'><option>Select</option></select></td>" +
                                            "</tr>" +
                                             "<tr>" + // Height
                                                "<td><span style='font-weight:bold;'>Height</span></td>" +

                                                "<td><select  id='ddlFeet" + CID + "' name='ddlFeet" + CID + "' onLoad='loadFeet(this.id)'></select><label for='ddlFeet" + CID + "'>Feet</label>&nbsp;&nbsp;" +
                                                "<select  id='ddlInches" + CID + "' name='ddlInches" + CID + "' onLoad='loadInches(this.id)'><option>Select</option></select><label for='ddlInches" + CID + "'>Inches</label></td>" +
                                            "</tr>" +
                                             "<tr>" + // Weight
                                                "<td><span style='font-weight:bold;'>Weight</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtWeight" + CID + "' name='txtWeight" + CID + "' />Pounds </td>" +
                                            "</tr>" +
                                             "<tr>" + // Hair Color
                                                "<td><span style='font-weight:bold;'>Hair Color</span></td>" +

                                                "<td><select style='width:165px' id='ddlHair" + CID + "' name='ddlHair" + CID + "' onLoad='loadHair(this.id)'><option>Select</option></select></td>" +
                                            "</tr>" +
                                             "<tr>" + // Eye Color
                                                "<td><span style='font-weight:bold;'>Eye Color</span></td>" +

                                                "<td><select style='width:165px' id='ddlEye" + CID + "' name='ddlEye" + CID + "' onLoad='loadEye(this.id)'><option>Select</option></select></td>" +
                                            "</tr>" +
                                             "<tr>" + // Age
                                                "<td><span style='font-weight:bold;'>Age</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtAge" + CID + "' name='txtAge" + CID + "' /></td>" +
                                            "</tr>" +
                                            "<tr>" + // Warrant Date
                                                "<td><span style='font-weight:bold;'>Warrant Date</span></td>" +
                                                 "<td><input type='text' style='font-weight:bold;' id='txtWDate" + CID + "' name='txtWDate" + CID + "' /></td>" +
                                            "</tr>" +
                                             "<tr>" + // Wanted For
                                                "<td><span style='font-weight:bold;'>Wanted For</span></td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtWanted" + CID + "' name='txtWanted" + CID + "' /></td>" +
                                            "</tr>" +
                                             "<tr>" + // Last Known Address
                                                "<td><span style='font-weight:bold;'>Last Known Address</span></td>" +
                                                "<td> <textarea style='font-weight:bold;' id='txtAddress" + CID + "'></textarea></td>" +
                                            "</tr>" +
                                            "<tr id='trEmpty" + CID + "'>" +
                                                "<td colspan='2'>&nbsp;</td>" +
                                            "</tr>" +
                                        "</table>" +
                                    "</div>" +
                                "</td>" +
                            "</tr>";


            if (divtable.rows.length == 0) {
                $("#maintable").append(newRow);
            }
            else {
                var lastrow = CID - 1;
                $("#tr" + lastrow).after(newRow);
            }
            loadGender("ddlGender" + CID);
            loadRace("ddlRace" + CID);
            loadFeet("ddlFeet" + CID);
            loadInches("ddlInches" + CID);
            loadHair("ddlHair" + CID);
            loadEye("ddlEye" + CID);
            LoadDataPickers("txtWDate" + CID);
            //Auto scroll when add new item
            var objDiv = document.getElementById("divMain");
            objDiv.scrollTop = objDiv.scrollHeight;
        }
        function loadGender(controlID) {

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{pType: '" + "Gender" + "'}",
                url: "MostWanted.aspx/LoadDefaultData",
                dataType: "json",
                success: function (data) {
                    var genderString = data.d;
                    if (controlID != null) {
                        //Add New Block

                        var i = 0;
                        var dataObject = JSON.parse(genderString);

                        $.each(dataObject, function (id, datarow) {
                            if (dataObject[i]["Type"] == "Gender") {
                                $('#' + controlID).append($("<option></option>").attr("value", dataObject[i]["Value"]).text(dataObject[i]["Value"]));
                            }
                            i++;
                        });


                    }
                    else {//Edit Page Load All DDL
                        var divtable = document.getElementById("maintable");

                        if (divtable != null) {
                            for (x = 0; x < divtable.rows.length; ) {
                                j = divtable.rows[x].id.replace('trheader', '');
                                //We have 3rows every call 1==Header 2==preview 3==edit row
                                x = x + 3;
                                document.getElementById("dllGender" + j).options.length = 0;

                                var list = genderString.split(',');
                                for (i = 0; i < list.length; i++) {
                                    $('#dllGender' + j).append($("<option></option>").attr("value", list[i]).text(list[i]));
                                }
                            }
                        }
                    }
                }
            });
        }
        function loadRace(ddlRace) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{pType: '" + "Race" + "'}",
                url: "MostWanted.aspx/LoadDefaultData",
                dataType: "json",
                success: function (data) {
                    var genderString = data.d;
                    var i = 0;
                    var dataObject = JSON.parse(genderString);

                    $.each(dataObject, function (id, datarow) {
                        if (dataObject[i]["Type"] == "Race") {
                            $('#' + ddlRace).append($("<option></option>").attr("value", dataObject[i]["Value"]).text(dataObject[i]["Value"]));
                        }
                        i++;

                    });
                }
            });
        }
        function loadFeet(ddlFeet) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{}",
                url: "MostWanted.aspx/LoadFeetList",
                dataType: "json",
                success: function (data) {
                    var genderString = data.d;
                    var i = 0;
                    var dataObject = JSON.parse(genderString);

                    $.each(dataObject, function (id, datarow) {
                        $('#' + ddlFeet).append($("<option></option>").attr("value", dataObject[i]["Value"]).text(dataObject[i]["Value"]));
                        i++;

                    });
                }
            });
        }
        function loadInches(ddlInches) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{}",
                url: "MostWanted.aspx/LoadInchesList",
                dataType: "json",
                success: function (data) {
                    var genderString = data.d;
                    var i = 0;
                    var dataObject = JSON.parse(genderString);

                    $.each(dataObject, function (id, datarow) {
                        if (dataObject[i]["Value"] != "") {
                            $('#' + ddlInches).append($("<option></option>").attr("value", dataObject[i]["Value"]).text(dataObject[i]["Value"]));
                        }
                        i++;

                    });
                }
            });

        }
        function loadHair(ddlHair) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{pType: '" + "Hair" + "'}",
                url: "MostWanted.aspx/LoadDefaultData",
                dataType: "json",
                success: function (data) {
                    var genderString = data.d;
                    var i = 0;
                    var dataObject = JSON.parse(genderString);

                    $.each(dataObject, function (id, datarow) {
                        if (dataObject[i]["Type"] == "Hair") {
                            $('#' + ddlHair).append($("<option></option>").attr("value", dataObject[i]["Value"]).text(dataObject[i]["Value"]));
                        }
                        i++;

                    });
                }
            });
        }
        function loadEye(ddlEye) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{pType: '" + "Eyes" + "'}",
                url: "MostWanted.aspx/LoadDefaultData",
                dataType: "json",
                success: function (data) {
                    var genderString = data.d;
                    var i = 0;
                    var dataObject = JSON.parse(genderString);

                    $.each(dataObject, function (id, datarow) {
                        if (dataObject[i]["Type"] == "Eyes") {
                            $('#' + ddlEye).append($("<option></option>").attr("value", dataObject[i]["Value"]).text(dataObject[i]["Value"]));
                        }
                        i++;

                    });
                }
            });
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
                document.getElementById('<%= lblBulletinedit.ClientID%>').innerHTML = "";
            }
        }

        function EditPanel(controlID, editImageControl) {
            var id = controlID.id.replace(/trpreview/gi, "");
            $("#trpreview" + id).css('display', 'none');

            // For Date Picker Loading....
            $("#txtWDate" + id).removeAttr("class");
            $("#txtWDate" + id).datepicker();



            $("#tr" + id).css('display', 'block');
            $("#imgedit" + id).css('display', 'none');


        }
        function AddNewImageDiv(parentdivID) {
            parentdivID = parentdivID.replace("imagesection", "");
            var subDIVID = 1;
            for (i = subDIVID; i <= subDIVID; i++) {
                if (!document.getElementById("divimage" + parentdivID + "_" + i)) {
                    break;
                }
                else {
                    subDIVID++;
                }
            }
            var newRow = "<tr id='imgRow" + parentdivID + "_" + subDIVID + "'>" + "<td style='padding-top:5px;'>&nbsp;</td>" +
                                               "<td >&nbsp;" + // Image Add/Edit
                                                       "<div  id='divimage" + parentdivID + "_" + subDIVID + "' style='min-height: 100px; float:left' class='textdivStyle'>" +
                                                       "</div> &nbsp;&nbsp;<div style='float:left; margin-left:6px;'> <img src='../../Images/editimg.png'  style='cursor: pointer;' onclick='EditImage(divimage" + parentdivID + "_" + subDIVID + "," + parentdivID + ")' /> " +
                                                       " <br/><img src='../../Images/deleteimg.png'  style='cursor: pointer;' onclick='DeleteImage(divimage" + parentdivID + "_" + subDIVID + ")' /> </div>" +
                                                 "</td>" +
                                         "</tr>";
            var subImgtable = document.getElementById('imgtable' + parentdivID);
            if (subImgtable.rows.length == 0) {
                $("#imgtable" + parentdivID).append(newRow);
            }
            else {
                $("#" + subImgtable.rows[subImgtable.rows.length - 1].id).after(newRow);
            }
            //Auto scroll when add new item
            var co = document.getElementById("divimage" + parentdivID + "_" + subDIVID);
            co.focus();
        }
        function EditImage(value, parentID) {
            imgdivID = value.id;
            document.getElementById('DivIds').value = parentID;

            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            //            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 12) + "&imgSrc=" + imgSrc + "&folder=Forms");
            //            ifrm.style.height = "750px";
            ifrm.setAttribute("src", "BulletinsForm_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 32) + "&imgSrc=" + imgSrc + "&folder=Forms");
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
        function DeleteImage(imgID) {
            //var imgrowID = imgID.id.replace("divimage", "imgRow");
            // var imgCapID = imgID.id.replace("divimage", "imgCapRow");
            if (confirm("Are you sure you want to delete this image?")) {
                //  $("#" + imgrowID).remove();
                //  $("#" + imgCapID).remove();

                imgID.innerHTML = "";
                var ImgDivID = document.getElementById('DivIds').value;
                if (document.getElementById("imagesection" + ImgDivID) != null) {
                    document.getElementById("imagesection" + ImgDivID).style.display = 'block';
                }

            }
        }
        function ValidateCallDetails() {
            var reurnValue = true;
            if (Page_ClientValidate('ABC') && Page_IsValid) {
                var ExDate = document.getElementById("<%=txtExDate.ClientID %>").value;
                var ExHours = document.getElementById("<%=txtExHours.ClientID %>").value.replace("Hour", "00");
                var ExMins = document.getElementById("<%=txtExMinutes.ClientID %>").value.replace("Minutes", "00");
                var SS = document.getElementById("<%=ddlExSS.ClientID %>").value;
                if (ExDate != "") {
                    if (parseInt(ExHours) > 12) {
                        alert('Invalid expiration time format.');
                        document.getElementById("<%=txtExHours.ClientID %>").focus();
                        reurnValue = false;
                    }
                    else if (parseInt(ExMins) >= 60) {
                        alert('Invalid expiration time format.');
                        document.getElementById("<%=txtExMinutes.ClientID %>").focus();
                        reurnValue = false;
                    }
                    else {
                        var ExDate_Time = ExDate + " " + ExHours + ":" + ExMins + ":00 " + SS;
                        var todayDate = new Date();
                        ExDate_Time = new Date(ExDate_Time);
                        if (ExDate_Time < todayDate) {
                            alert('Expiration date should be later than current date.');
                            document.getElementById("<%=txtExDate.ClientID %>").focus();
                            reurnValue = false;
                        }
                    }
                }
            }
            else {
                reurnValue = false;
            }

            return reurnValue;
        }
        function SaveHTMLData() {
            //getting preview html
            if (ValidateCallDetails()) {
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
                var exDate = document.getElementById("<%=txtExDate.ClientID %>").value;
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

                var divtable = document.getElementById("maintable");
            }

            var ROWS = "";
            var previewHTMLStr = "";

            var XMLString = "";

            // Description Details
            var Description = document.getElementById("<%=txtDesc.ClientID %>").value.replace("0", "");

            //XML
            XMLString = XMLString + " Description='" + Description + "'";
            //ROWS = ROWS + "<tr><td  style='height:15px; padding:0px 5px 10px; font-weight: bold;' colspan='2'>ROCKLIN'S MOST WANTED</td></tr>";
            if (Description != "") {
                //HTML
                IsContactAdd = true;
                ROWS = ROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding-left:5px;'>" + Description + "</td></tr>";
            }

            // end Description Details
            if (ROWS != "")
                var firstBorder = " <tr><td colspan='2'><table cellpadding='0' cellspacing='0' style='width: 300px;'>" + ROWS + "</table></td></tr>";

            if (document.getElementById("maintable") != null)
                var elems = document.getElementById("maintable").getElementsByTagName("div");
            totalchildXMlString = "";
            var childTable = "";
            //Start Incident Details 
            if (divtable != "") {
                childTable = "";
                var rowsCount = $('#maintable tr.trheader').length;
                var rowCount = 0;
                $('#maintable tr.trheader').each(function () {
                    rowCount += 1;
                    i = $(this).attr('id').replace('trheader', '');
                    var childRow = "";
                    var childXMLElements = "";

                    var WarrantDate = document.getElementById("txtWDate" + i).value.trim();

                    var Name = ReplaceSpecialCharacter(document.getElementById("txtName" + i).value.trim());
                    //document.getElementById("txtName" + i).innerHTML = Name;

                    var Docket = ReplaceSpecialCharacter(document.getElementById("txtDocket" + i).value.trim());
                    //document.getElementById("txtDocket" + i).innerHTML = Docket;

                    var BailAmount = ReplaceSpecialCharacter(document.getElementById("txtAmt" + i).value.trim());
                    //document.getElementById("txtAmt" + i).innerHTML = BailAmount;

                    var Gender = ReplaceSpecialCharacter(document.getElementById("ddlGender" + i).value.trim());
                    //document.getElementById("ddlGender" + i).innerHTML = Gender;

                    var Race = ReplaceSpecialCharacter(document.getElementById("ddlRace" + i).value.trim());
                    //document.getElementById("ddlRace" + i).innerHTML = Race;

                    var Feet = ReplaceSpecialCharacter(document.getElementById("ddlFeet" + i).value.trim());
                    if (Feet == 'Select')
                        Feet = '';
                    //document.getElementById("ddlFeet" + i).innerHTML = Feet;

                    var Inches = ReplaceSpecialCharacter(document.getElementById("ddlInches" + i).value.trim());
                    if (Inches == 'Select')
                        Inches = '';


                    if (Feet == "0" && Inches == '')
                    { Feet = ''; Inches = ''; }

                    //document.getElementById("ddlInches" + i).innerHTML = Inches;

                    var Weight = ReplaceSpecialCharacter(document.getElementById("txtWeight" + i).value.trim());
                    //document.getElementById("txtWeight" + i).innerHTML = Weight;

                    var Hair = ReplaceSpecialCharacter(document.getElementById("ddlHair" + i).value.trim());
                    //document.getElementById("ddlHair" + i).innerHTML = Hair;

                    var Eye = ReplaceSpecialCharacter(document.getElementById("ddlEye" + i).value.trim());
                    //document.getElementById("ddlEye" + i).innerHTML = Eye;

                    var Age = ReplaceSpecialCharacter(document.getElementById("txtAge" + i).value.trim());
                    //document.getElementById("txtAge" + i).innerHTML = Age;

                    var Wanted = ReplaceSpecialCharacter(document.getElementById("txtWanted" + i).value.trim());
                    //document.getElementById("txtWanted" + i).innerHTML = Wanted;

                    var Address = ReplaceSpecialCharacter(document.getElementById("txtAddress" + i).value.trim());
                    document.getElementById("txtAddress" + i).innerHTML = Address;

                    //  Start Image Section Preview
                    var imgXML = "";
                    var totalimgXML = "";
                    var imgHTMLs = "";
                    var imgSectionTable = document.getElementById("imgtable" + i);
                    if (imgSectionTable.rows.length > 0) {

                        for (l = 0; l < imgSectionTable.rows.length; ) {
                            k = imgSectionTable.rows[l].id.replace('imgRow', ''); ;
                            l = l + 1;

                            var imgControl = document.getElementById("divimage" + k).innerHTML;


                            var imgURL = "";
                            if (document.getElementById("divimage" + k).getElementsByTagName("img").length > 0) {
                                var imgList = document.getElementById("divimage" + k).getElementsByTagName("img");
                                imgURL = imgList[0].src;
                            }




                            if (imgControl != "") {
                                // HTML
                                imgHTMLs = imgHTMLs + "<tr><td style='page-break-inside: avoid;'>&nbsp;</td><td style='page-break-inside: avoid; padding-top:5px;'>" + imgControl + "</td></tr>";
                                // XML
                                imgXML = imgXML + " imgURL='" + imgURL + "' ";
                            }

                            totalimgXML = totalimgXML + "<Images " + imgXML + "/>";
                            imgXML = "";
                        } //end loop image section

                        //
                        imgHTMLs = "<table cellspacing='0' cellpadding='0'>" + imgHTMLs + "</table>";
                        // HTML
                        childRow = childRow + "<tr><td valign='top' colspan='2' style='page-break-inside: avoid; padding-top:5px;'>" + imgHTMLs + "</td></tr>";
                    }
                    //  End Image Section Preview

                    if (Name != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Name:</td><td style='padding-top:5px;'><b>" + Name + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Name='" + Name + "' ";
                    }
                    if (Docket != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Docket:</td><td style='padding-top:5px;'><b>" + Docket + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Docket='" + Docket + "' ";
                    }
                    if (BailAmount != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Bail Amount:</td><td style='padding-top:5px;'><b>$" + BailAmount + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " BailAmount='" + BailAmount + "' ";
                    }
                    if (Gender != "" && Gender != "Select") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Sex:</td><td style='padding-top:5px;'><b>" + Gender + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Gender='" + Gender + "' ";
                    }
                    if (Race != "" && Race != "Select") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Race:</td><td style='padding-top:5px;'><b>" + Race + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Race='" + Race + "' ";
                    }
                    if (Feet != "") {
                        // XML
                        childXMLElements = " Feet='" + Feet + "' ";
                        Feet = Feet + "'";
                    }
                    if (Inches != "") {
                        // XML
                        childXMLElements = " '" + Inches + "' ";
                        Inches = Inches + "''";
                    }
                    if (Feet != "" || Inches != "")
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Height:</td><td style='padding-top:5px;'><b>" + Feet + Inches + "</b></td></tr>";
                    if (Weight != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Weight:</td><td style='padding-top:5px;'><b>" + Weight + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Weight='" + Weight + "' ";
                    }
                    if (Hair != "" && Hair != "Select") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Hair Color:</td><td style='padding-top:5px;'><b>" + Hair + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Hair='" + Hair + "' ";
                    }
                    if (Eye != "" && Eye != "Select") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Eye Color:</td><td style='padding-top:5px;'><b>" + Eye + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Eye='" + Eye + "' ";
                    }
                    if (Age != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Age:</td><td style='padding-top:5px;'><b>" + Age + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Age='" + Age + "' ";
                    }

                    if (WarrantDate != "") {// HTML
                        childRow = childRow + "<tr><td style='page-break-inside: avoid;'>Warrant Date:</td><td style='page-break-inside: avoid;'><b>" + WarrantDate + " </b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " WarrantDate='" + WarrantDate + "' ";
                    }
                    if (Wanted != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Wanted For:</td><td style='padding-top:5px;'><b>" + Wanted + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Wanted='" + Wanted + "' ";
                    }
                    if (Address != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Last Known Address:</td><td style='padding-top:5px;'><b>" + Address + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Address='" + Address + "' ";
                    }
                    childRow = "<table class='radius' id='tblpreview" + i + "' cellpadding='0' cellspacing='3' style='" + (rowCount == rowsCount ? "" : "border-bottom: 1px solid black; ") + "margin-top:5px; padding-left:5px; width: 300px;'><colgroup><col width='100px'/><col width='*'/></colgroup>" + childRow + "</table>";
                    //$("#tdpreview" + i).append(childRow);
                    childTable = childTable + childRow;

                    //XML Sub Elements
                    childXMLElements = "<ChildDetails " + childXMLElements + "  >" + totalimgXML + " </ChildDetails>";
                    totalchildXMlString = totalchildXMlString + childXMLElements;
                });
            } // End Loop
            //Child Tables to main table
            var secondBorder = "<tr><td colspan='2'>" + childTable + "</td></tr>";
            //

            //end preview html


            previewHTMLStr = "<table cellpadding='0' cellspacing='0' style='padding-left:0px; padding-top:5px; text-align:left; border:1px solid black;'>" + firstBorder + secondBorder + "</table>";
            var titleName = "<div id='divTitle' style=\"background: #fffdfb; overflow: hidden; width: auto; margin: 0px; padding: 15px 0px 40px 0px;\">" +
                                "<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">Rocklin's Most Wanted</div>";
            previewHTMLStr = titleName + previewHTMLStr + "</div>";

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
                    url: "MostWanted.aspx/ReplaceShortURltoHmlString",
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
        function LoadData() {
            var divtable = document.getElementById("maintable");
            if ($("#divTitle") != null) {
                $("#divTitle").css('display', 'none');
            }

            if (divtable != null) {

                $('#maintable tr.trheader').each(function () {
                    if ($(this).attr('id').indexOf('trheader') != -1) {
                        var j = $(this).attr('id').replace('trheader', '');
                        var html = document.getElementById("tblpreview" + j).outerHTML;
                        $("#tdpreview" + j).html('');
                        $("#tdpreview" + j).append(html);
                        document.getElementById("tblpreview" + j).style.width = '100%';
                        $("#tr" + j).css('display', 'none');
                        $("#trpreview" + j).css('display', 'block');
                        $("#imgedit" + j).css('display', '');
                    }
                })


            }

            document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
            document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";

            if (document.getElementById('<%=rbPrivate.ClientID %>').checked == true) {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
            }

            $("#dummyDIV").css('display', 'none');
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
                <div id="wrapper">
                    <div class="headernav">
                        <%=BulletinName %>
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
                        <div id="divLoading" style="display: none; width: 300px; margin: 0 auto;">
                            <div style="text-align: center;">
                                <img src="<%=Page.ResolveClientUrl("../../images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                    color="green">Processing....</font></b>
                            </div>
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
                            Rocklin's Most Wanted</div>
                        <div class="form_wrapper">
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <label style="color: Red; font-size: 16px; margin-left: 200px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable" style="width: 1px;">
                                </div>
                                <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="490" Height="100"
                                        Text="If you see any of these subjects in Rocklin, please call the Rocklin Police Department at (916) 625-5400."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtDesc"
                                        ValidationGroup="ABC" runat="server" ErrorMessage="Description is mandatory."
                                        Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <div id='divMain' class="avatar" style="margin-left: 20px; border-width: 1px; min-height: 100px;
                                        width: 490px; max-height: 600px; overflow: auto;">
                                        <asp:Label ID="lblBulletinedit" runat="server" placeholder="Your block goes here!!!"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; margin: 5px 0px 0px 337px;">
                                <img style="cursor: pointer;" onclick="AddPanel();" src="../../Images/add.png" />
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable" style="width: 162px;">
                                    <span style="color: Red;">&nbsp;&nbsp;</span> Expiration Date & Time:
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <table width="80%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtExDate" runat="server" Width="100px" onChange="ShowExTimeDiv();"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtExDate"
                                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                        ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                                    <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExDate" Format="MM/dd/yyyy"
                                                        CssClass="MyCalendar" />
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtExHours" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14" TargetControlID="txtExHours"
                                                        WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtExHours" ValidationExpression="^(1[0-2]|0?[1-9])" ValidationGroup="ABC"
                                                        ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                                    &nbsp; &nbsp;
                                                    <asp:TextBox runat="server" ID="txtExMinutes" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender15" TargetControlID="txtExMinutes"
                                                        WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtExMinutes" ValidationExpression="^[0-5]\d" ValidationGroup="ABC"
                                                        ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:DropDownList runat="server" ID="ddlExSS" Enabled="False" Width="60px">
                                                        <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="fields_wrap" id="divSettings" runat="server">
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
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <div id="public" style="margin: 10px 0px 0px 15px;">
                                            <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                                onclick="javascript:ShowPublish('1','true')" />
                                            <label>
                                                Private</label>
                                            <asp:Label ID="lblCompleted" runat="server"></asp:Label>
                                            <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2','true')" />
                                            <asp:Label ID="lblworkprogress" runat="server"></asp:Label>
                                            <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval SelectPublish"></asp:Label>
                                            <div style="margin: 10px 10px 0px 80px; display: none;" id="divpublish">
                                                <div id="divSchedulePublish" style="display: block;">
                                                    <font color="red">*</font>
                                                    <label style="font-size: 14px;">
                                                        Publish On:
                                                    </label>
                                                    <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                        ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPublishDate"
                                                        runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                        ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                    <span style="padding-left: 85px;"><b>(MM/DD/YYYY)</b></span>
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
                                                <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;&nbsp;</span> Category Level:
                                </div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCategories" runat="server" Width="200px" Style="display: none;">
                                    </asp:DropDownList>
                                    <strong>Most Wanted</strong>
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 450px;">
                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" border="0" CssClass="btn"
                                        CausesValidation="false" OnClick="BtnCancel_Click" />
                                    <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="ABC" border="0"
                                        CssClass="btn" OnClientClick="return SaveHTMLData()" OnClick="BtnSave_Click" />
                                    <asp:Button ID="BtnPublish" runat="server" Text="Submit" ValidationGroup="ABC" OnClientClick="return SaveHTMLData()"
                                        border="0" CssClass="btn" OnClick="BtnSave_Click" Style="display: none;" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return PreviewHTML('1');">
                                        <img src="../../images/BulletinThumbs/preview.png" width="100" height="37" ></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <input type="hidden" value="2" id="DivIds" />
                <input type="hidden" id="hdnalignindex" />
                <input type="hidden" id="editDivCheck" value="" />
                <asp:HiddenField runat="server" ID="hdnEditHTML" />
                <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
                <asp:HiddenField runat="server" ID="hdnEditXML" />
                <asp:HiddenField ID="hdnPermissionType" runat="server" />
                <asp:HiddenField runat="server" ID="hdnExDate" />
                <asp:HiddenField runat="server" ID="hdnPublish" />
                <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
                <asp:HiddenField runat="server" ID="hdnCompleted" />
                <asp:HiddenField runat="server" ID="hdnPrivate" />
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
                Rocklin's Most Wanted</div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
