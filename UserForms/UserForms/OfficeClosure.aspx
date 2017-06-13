<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficeClosure.aspx.cs"
    Title="" Inherits="UserForms.OfficeClosure" MasterPageFile="~/Admin.Master" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="UCEditor.ascx" TagName="UCEditor" TagPrefix="uc2" %>
<%@ Register Src="~/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
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
    <script src="Scripts/timepicki.js" type="text/javascript"></script>
    <link href="Styles/timepicki.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .Default.reDropDownBody
        {
            z-index: 210990 !important;
        }
        .RadToolBar.RadToolBar_Default.rwNormalWindow.rwTransparentWindow
        {
            z-index: 110000 !important;
        }
        .RadToolBar.RadToolBar_Default.rwNormalWindow.rwTransparentWindow.rwInactiveWindow
        {
            z-index: 10990 !important;
        }
        #RadToolBar1
        {
            z-index: 10990 !important;
            display: block;
        }
    </style>
    <style>
        .textboxstyle
        {
            border: 2 solid black;
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
            width: 300px;
        }
        .videodivStyle
        {
            text-align: center;
            border: 1px solid #FCB549;
            overflow: auto;
            font-family: Arial;
            font-size: 16px;
            width: 600px;
        }
        .imgdivStyle
        {
            text-align: justify;
            border: 1px solid #FCB549;
            overflow: auto;
            font-family: Arial;
            font-size: 12px;
            width: 600px;
        }
        .stepswrap1
        {
            overflow: hidden;
            border: 1px solid #ccc;
            color: #2F348F;
            margin-top: 5px;
            padding: 10px 10px 5px 5px;
        }
        #watermark
        {
            color: #d0d0d0;
            font-size: 26px;
            width: 100%;
            height: 100%;
            text-align: center;
            vertical-align: middle;
            margin-top: 40px;
        }
        .lefttable
        {
            float: left;
            text-align: right;
            width: 164px;
            padding: 3px 0px 0px 0px;
            margin: 2px 20px 0px 100px;
        }
    </style>
    <style type="text/css">
        .navy20
        {
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
            padding: 10px 0px 5px 0px;
        }
        .navy16
        {
            color: #2F348F;
            font-size: 14px;
            line-height: 22px;
            font-weight: bold;
            font-family: Arial;
        }
        .black16
        {
            color: #000;
            font-size: 14px;
            line-height: 22px;
            font-weight: bold;
            font-family: Arial;
        }
        .black16normal
        {
            color: #000;
            font-size: 14px;
            line-height: 22px;
            font-family: Arial;
        }
        .txtarea11
        {
            font-size: 14px;
            color: #000;
            border: #D3D3D3 2px solid;
            font-family: Arial;
            resize: none;
        }
        .border
        {
            border: 1px solid #04519D;
        }
        .cursor
        {
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
            margin-left: 31%;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".timepicker").timepicki();
            var starttime = '';
            var endtime = '';

        });

        var EntID = "";

        function PreviewHTML(typeID) {
            EntID = typeID;

            if (typeID == 2 || typeID == 3) {
                ValidatePublishDate();
              
               }

            var Rows = '';
            var trs = '';
            var tds = '';
            var getHTML = '';
            var imgTag = '';
            var Location = document.getElementById("<%=txtLocation.ClientID %>").value;
            var Date = document.getElementById("<%=txtAnnounceDate.ClientID %>").value;
            var StartTime = '';
            var EndTime = '';
            if (document.getElementById("<%=txtStartExHours.ClientID %>").value != "") {
                var selHours = 0;
                var selmins = 0;
                var Meridian = '';
                if (document.getElementById("<%=txtStartExHours.ClientID %>").value != '' && document.getElementById("<%=txtStartExHours.ClientID %>").value != 'Hour') {
                    selHours = document.getElementById("<%=txtStartExHours.ClientID %>").value;
                    if (document.getElementById("<%=txtStartExMinutes.ClientID %>").value != '' && document.getElementById("<%=txtStartExMinutes.ClientID %>").value != 'Minutes')
                        selmins = document.getElementById("<%=txtStartExMinutes.ClientID %>").value;
                    StartTime = selHours + ':' + selmins + ' ' + document.getElementById("<%=ddlStartExSS.ClientID %>").value;
                }
            }
            if (document.getElementById("<%=txtEndExHours.ClientID %>").value != "") {
                var selHours = 0;
                var selmins = 0;
                var Meridian = '';
                if (document.getElementById("<%=txtEndExHours.ClientID %>").value != '' && document.getElementById("<%=txtEndExHours.ClientID %>").value != 'Hour') {
                    selHours = document.getElementById("<%=txtEndExHours.ClientID %>").value;
                   
                    if (document.getElementById("<%=txtEndExMinutes.ClientID %>").value != '' && document.getElementById("<%=txtEndExMinutes.ClientID %>").value != 'Minutes')
                        selmins = document.getElementById("<%=txtEndExMinutes.ClientID %>").value;
                    EndTime = selHours + ':' + selmins + ' ' + document.getElementById("<%=ddlEndExSS.ClientID %>").value;
                }
            }
                   
                 
           
            var Email = document.getElementById("<%=txtContactEmail.ClientID %>").value;
            var PhoneNumber = document.getElementById("<%=txtPhoneNumber.ClientID %>").value;
            Rows = Rows + "<tr><td colspan='2' style='padding:5px; font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; border-bottom: 1px dashed #d1d1d1;'>Office Closure</td></tr>";
            if (Date != '') {
                Rows = Rows + "<tr><td style='page-break-inside: avoid; padding:5px; width:150px; vertical-align:top;'> Date: </td><td style='text-align:left;'>" + Date + "</td></tr>";

            }

            if (StartTime != '') {
                Rows = Rows + "<tr><td style='page-break-inside: avoid; padding:5px; width:150px; vertical-align:top;'> Start Time: </td><td style='text-align:left;'>" + StartTime + "</td></tr>";

            }
            if (EndTime != '') {
                Rows = Rows + "<tr><td style='page-break-inside: avoid; padding:5px; width:150px; vertical-align:top;'> End Time: </td><td style='text-align:left;'>" + EndTime + "</td></tr>";

            }
            if (Location != "") {
                //HTML
                Rows = Rows + "<tr><td style='page-break-inside: avoid; padding:5px; width:150px; vertical-align:top;'> Location: </td><td style='text-align:left;'>" + Location + "</td></tr>";
            }

            if (Email != '') {
                Rows = Rows + "<tr><td style='page-break-inside: avoid; padding:5px; width:150px; vertical-align:top;'> Contact Email: </td><td style='text-align:left;'>" + Email + "</td></tr>";

            }
            if (PhoneNumber != '') {
                Rows = Rows + "<tr><td style='page-break-inside: avoid; padding:5px; width:150px; vertical-align:top;'> Phone Number: </td><td style='text-align:left;'>" + PhoneNumber + "</td></tr>";

            }
            trs = trs + "<tr><td><table width=\"400px\">" + Rows + "</table></td></tr>";
            var divCount = $("#maintable div").size();
            if (divCount > 0) {
                var divtable = document.getElementById("maintable");

                var IsListDescription = true;

                for (i = 0; i < divtable.rows.length; i++) {
                    for (j = 0; j < divtable.rows[i].cells.length; j++) {
                        for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                            //DIV Tag 
                            if (divtable.rows[i].cells[j].children[k].tagName == "DIV") {
                                var id = divtable.rows[i].cells[j].children[k].id.replace("parent", "");
                                getHTML = document.getElementById(id).innerHTML;
                                if (getHTML.trim() != "") {
                                    getHTML = getHTML.replace(/SPAN/gi, 'span');
                                    if (getHTML.indexOf('<span') >= 0) {
                                        if (IsListDescription) {
                                            document.getElementById("<%=hdnDescription.ClientID %>").value = getHTML;
                                            IsListDescription = false;
                                        }
                                        tds = tds + "<td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align: left;'>" + getHTML + "</td>";
                                    }
                                    else {
                                        getHTML = getHTML.replace(/videoclass/gi, 'videoclass1');
                                        var imgAlignment = document.getElementById(id).style.textAlign;
                                        if (imgAlignment == "") imgAlignment = "center";
                                        tds = tds + "<td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align:" + imgAlignment + ";'>" + getHTML + "</td>";
                                    }
                                    if (tds != "") {
                                        trs = trs + "<tr>" + tds + "</tr>";
                                    }
                                    tds = '';
                                }
                            }
                        }
                    }

                }

            }

            var PreviewHTML = "<table style='margin-left:90px;' border='0'  >" + trs + "</table>";


            var bulletinHeader = document.getElementById("<%=hdnBulletinHeader.ClientID %>").value;
            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = PreviewHTML;


            if (EntID == 1) {
                bulletinHeader = bulletinHeader.replace("#BuildHtmlForForm#", PreviewHTML);
                document.getElementById("<%=lblnewspreview.ClientID %>").innerHTML = "";
                document.getElementById("<%=lblnewspreview.ClientID %>").innerHTML = bulletinHeader;
                document.getElementById("<%=lblbulletiname.ClientID %>").innerHTML = document.getElementById("<%=lblBulletinName.ClientID %>").innerHTML;
                var modal = $find("BulletinPreview");
                modal.show();
                document.getElementById('<%=lblmess.ClientID %>').innerHTML = "";

                return false;
            }
            else {
                if (Page_ClientValidate('EA')) {

                    if (ValidateStartDate()) {
                        var isCompleted = false;
                        var isPrivate = false;

                        document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
                        isPrivate = document.getElementById('<%=rbPrivate.ClientID %>').checked;
                        var exDate = document.getElementById("<%=txtExDate.ClientID %>").value;
                        if (document.getElementById('maintable') != null) {
                            document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                        }
                        document.getElementById("<%=hdnExDate.ClientID %>").value = exDate;
                        document.getElementById("<%=hdnPrivate.ClientID %>").value = isPrivate;
                        document.getElementById("<%=hdnCompleted.ClientID %>").value = isCompleted;

                        $find("<%=MPEProgress.ClientID %>").show();
                        //PageMethods.ServerSideFill(divtable.outerHTML, PreviewHTML, isCompleted, isPrivate, typeID, exDate, OnSuccess, OnFail)

                        return true;
                    }
                    else {

                        return false;
                    }
                }
              
            }
        }
        function OnSuccess(result) {

            if (EntID == "2") {
                document.getElementById('<%=lblmess.ClientID %>').innerHTML = 'Content saved successfully.';
                return true;
            }
            else if (EntID == "3") {
                window.location = result;
            }
        }
        function OnFail() {
        }



        function AddBlocks(blockname) {

            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"450px\" style=\"border: 0px solid gray; " +
                                                                        "min-height: 100px;\"> " +
                                                                    "</table>";

                document.getElementById("<%=lblBulletinedit.ClientID %>").innerHTML = maintableTag;
            }

            //GETTING DIVS COUNT
            var CID = 0;
            var divtable = document.getElementById('maintable');
            for (i = 0; i < divtable.rows.length; i++) {
                for (j = 0; j < divtable.rows[i].cells.length - 1; j++) {
                    for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                        CID++;
                    }
                }
            }

            // GET MAX DIV ID
            CID = CID + 1;
            for (i = CID; i <= CID; i++) {
                if (!document.getElementById("edit" + i)) {
                    break;
                }
                else {
                    CID++;
                }
            }

            var editingBlock = "";
            var className = "textdivStyle";

            if (blockname == "DIV_TEXT") {
                editingBlock = "<img src='../../Images/EditText.png'  style='cursor: pointer;padding-left:5px' onclick='ShowPopup(edit" + CID + ")' />";
            }
            else if (blockname == "DIV_IMAGE") {
                editingBlock = "<img src='../../Images/EditImage.png'  style='cursor: pointer;' onclick='EditImage(edit" + CID + ")' />";
            } else if (blockname == "DIV_WORDCONTENT") {
                editingBlock = "<img src='../../Images/EditText.png'  style='cursor: pointer; margin-left:5px;' onclick='ShowPopup(edit" + CID + ")' />";
            }



            var newRow = "<tr id='tr" + CID + "' >" +
                            "<td class='drop ui-sortable' style='min-height: 20px;'>" +
                                " <div id='parentedit" + CID + "' style='float: left; margin-top: 10px;' class='assigned' >" +
                                       "<div id='edit" + CID + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >" +
                                       "</div>" +
                                        "<div id='editsection" + CID + "' class='editsectionclass' style='float:left;' >" + editingBlock +
                                          "<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + CID + ")' />" +
                                        "</div>" +
                                "</div>" +
                         "</td>" +
                    "</tr>";

            if (blockname != "DIV_WORDCONTENT") {
                $("#maintable").append(newRow);

                //Auto scroll when add new item
                var co = document.getElementById("parentedit" + CID);
                co.focus();
            }


            //Auto scroll when add new item

            $(".avatar").animate({ scrollTop: $(".avatar").prop("scrollHeight") }, 1000);
            LoadBlocks();
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
            if (document.getElementById("maintable") != null) {
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
            }

            if (blockname == "DIV_TEXT") {
                ShowPopup(document.getElementById("edit" + CID));
            }
            else if (blockname == "DIV_IMAGE") {
                EditImage(document.getElementById("edit" + CID));
            }
            else if (blockname == "DIV_WORDCONTENT") {
                EditWordContent(document.getElementById("edit" + CID));
            }

        }
        function LoadBlocks() {
            $(".drop").sortable({
                connectWith: ".drop",
                scrollSpeed: 5
            });

            $(".drop").disableSelection();

        }
        function RemoveBlock(value) {
            var divID = value.id;
            divID = divID.replace("edit", "tr");
            if (confirm("Are you sure you want to delete this block?")) {
                $("#" + divID).remove();
                document.getElementById("hdnChanges").value = "true";
            }

            var divCount = $("#maintable div").size();
            if (divCount <= 0) {
                document.getElementById('<%= lblBulletinedit.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
            }
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
            if (document.getElementById("maintable") != null) {
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
            }
        }

        function OnTextChanged() {
            document.getElementById("hdnChanges").value = "true";
        }
        function categoryonchange() {
            document.getElementById("hdnChanges").value = "true";
        }



        //Show the Image Gallery
        function EditImage(value) {
            imgdivID = value.id;
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "BulletinsForm_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 12) + "&imgSrc=" + imgSrc + "&folder=Templates");
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

        //Show the Word Gallery
        function EditWordContent(value) {
            //imgdivID = value.id;

            document.getElementById('divFrameWordContent').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            //var videoSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "WordContentTemplate.aspx");
            //ifrm.style.height = "750px";
            ifrm.style.height = "340px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('divFrameWordContent').appendChild(ifrm);
            // document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("WordContentPreview");
            modalDialog.show();
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

        function ValidatePublishDate() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                if (document.getElementById("<%=txtPublishDate.ClientID %>").value == "") {
                    document.getElementById("<%=txtPD.ClientID %>").value = "";
                }
                else {
                    document.getElementById("<%=txtPD.ClientID %>").value = "1";
                }
            }
            else {
                document.getElementById("<%=txtPublishDate.ClientID %>").value = "";
                document.getElementById("<%=txtPD.ClientID %>").value = "1";
            }

        }

        function ValidateStartDate() {
           
            if (document.getElementById("<%=txtStartExHours.ClientID %>").value != "") {
                var selHours = 0;
                var selmins = 00;
                if (document.getElementById("<%=txtStartExHours.ClientID %>").value != '' && document.getElementById("<%=txtStartExHours.ClientID %>").value != 'Hour') {
                    selHours = parseInt(document.getElementById("<%=txtStartExHours.ClientID %>").value);
                    if (selHours > 12) {
                        alert("Invalid Time Format.");
                        return false;
                    }
                    if (document.getElementById("<%=ddlStartExSS.ClientID %>").value == 'AM' && selHours == 12)
                        selHours = 0;
                    if (document.getElementById("<%=ddlStartExSS.ClientID %>").value == 'PM' )
                        selHours += 12;
                }
                if (document.getElementById("<%=txtStartExMinutes.ClientID %>").value != '' && document.getElementById("<%=txtStartExMinutes.ClientID %>").value != 'Minutes')
                    selmins = parseInt(document.getElementById("<%=txtStartExMinutes.ClientID %>").value);

                if (selmins >= 60) {
                    alert("Invalid Time Format.");
                    return false;
                }
                starttime = selHours + selmins;
            }

            if (document.getElementById("<%=txtEndExHours.ClientID %>").value != "") {
                var selEndHours = 0;
                var selEndmins = 00;
                if (document.getElementById("<%=txtEndExHours.ClientID %>").value != '' && document.getElementById("<%=txtEndExHours.ClientID %>").value != 'Hour') {
                    selEndHours = parseInt(document.getElementById("<%=txtEndExHours.ClientID %>").value);
                    if (selEndHours > 12) {
                        alert("Invalid Time Format.");
                        return false;
                    }
                    if (document.getElementById("<%=ddlEndExSS.ClientID %>").value == 'AM' && selHours == 12)
                        selEndHours = 0;
                    if (document.getElementById("<%=ddlEndExSS.ClientID %>").value == 'PM' )
                        selEndHours += 12;
                }
                if (document.getElementById("<%=txtStartExMinutes.ClientID %>").value != '' && document.getElementById("<%=txtStartExMinutes.ClientID %>").value != 'Minutes')
                    selEndmins = parseInt(document.getElementById("<%=txtStartExMinutes.ClientID %>").value);
                endtime = selEndHours + selEndmins;
                if (selEndmins >= 60) {
                    alert("Invalid Time Format.");
                    return false;
                }
                if (starttime == endtime) {
                    alert("End time should be later than start time.");
                    return false;
                }
                else {
                    return true;
                }
               
               
               

            }

        }



        function ShowPublicPrivate(val, ischange) {
            document.getElementById("<%=rbPrivate.ClientID %>").checked = true;
            document.getElementById("<%=rbPublic.ClientID %>").checked = false;
        }
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

            // Disable vents for VideoBlock in Page
            DisableEventsForVideoBlocks();
        }

        // Disable vents for VideoBlock in Page
        function DisableEventsForVideoBlocks() {
            var links = $('.videoclass');
            for (var i = 0; i < links.length; i++) {
                links[i].addEventListener("click", function (e) {
                    //alert("NOPE!, I won't take you there haha");
                    //prevent event action
                    e.preventDefault();
                })
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
            if (ischanges == 'true') {
                document.getElementById("hdnChanges").value = "true";
            }
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
                if (ischanges == "true" && document.getElementById('<%= txtPublishDate.ClientID%>').value == "") {
                    if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
                        GetCurrentDate();
                    ShowPublishSave('2');
                }
            }
        }
        function ShowPublishSave(val) {
            if (val == "1") {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
                document.getElementById('lblMandatory').style.display = "none";
            } else if (val == "2") {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                    document.getElementById('lblMandatory').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                    document.getElementById('lblMandatory').style.display = "none";
                }

            }
        }
        function SaveAlert() {
            var result;

            if (document.getElementById("hdnChanges").value == "true") {
                result = confirm('Do you want to save the changes you made to the content?');
                if (result) {
                    PreviewHTML('3');
                    return true;
                }
                else {
                    var urlinfo = document.getElementById('<%=hdnRootPath.ClientID %>').value + "/Business/MyAccount/ManageBulletins.aspx";
                    window.location = urlinfo;

                    return false;
                }
            }
            else {
                var urlinfo = document.getElementById('<%=hdnRootPath.ClientID %>').value + "/Business/MyAccount/ManageBulletins.aspx";
                window.location = urlinfo;

                return false;
            }
        }


        function ShowExTimeDiv() {
            var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }
            if (document.getElementById("<%=txtExDate.ClientID %>").value == "" || document.getElementById("<%=txtExDate.ClientID %>").value == "MM/DD/YYYY") {
             document.getElementById(controlName).disabled = true;
            }
            else {
              document.getElementById(controlName).disabled  = false;
            }
        }

        function transform(obj) {
            // Allow: backspace, delete, tab, escape, and enter // Allow: home, end, left, right
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                return;
            }
            else {
                // Ensure that it is a number and stop the keypress
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }
            var val = obj.value.replace(/\D/g, '');
            var newVal = '';
            if (val.length > 10) {
                val = val.substring(0, 10);
            }
            while (val.length > 3 && newVal.length <= 7) {
                newVal += val.substr(0, 3) + '-';
                val = val.substr(3);
            }
            newVal += val;
            document.getElementById("<%=txtPhoneNumber.ClientID %>").value = newVal;

        }


        $(document).ready(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
        function ShowEndTime() {
            if (document.getElementById("<%=txtStartExHours.ClientID %>").value == "") {
                document.getElementById("<%=txtStartExMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlStartExSS.ClientID %>").disabled = true;
                document.getElementById("<%=txtEndExHours.ClientID %>").disabled = true;
                document.getElementById("<%=txtEndExMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlEndExSS.ClientID %>").disabled = true;
               
            }
            else {
                document.getElementById("<%=txtStartExMinutes.ClientID %>").disabled = false;
                document.getElementById("<%=ddlStartExSS.ClientID %>").disabled = false;
                document.getElementById("<%=txtEndExHours.ClientID %>").disabled = false;
            }
        }

        function ShowEndMin() {
            if (document.getElementById("<%=txtEndExHours.ClientID %>").value == "") {
                document.getElementById("<%=txtEndExMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlEndExSS.ClientID %>").disabled = true;
                document.getElementById("<%=txtEndExMinutes.ClientID %>").value = '';
              
            }
            else {
                document.getElementById("<%=txtEndExMinutes.ClientID %>").disabled = false;
               
                document.getElementById("<%=ddlEndExSS.ClientID %>").disabled = false;
                
            }
        }
        function pad(d) {
           
            if (d.value.length<2) {
                if (d.value == '0') {
                    document.getElementById("<%=txtEndExHours.ClientID %>").value = '0';
                    // return (d.value < 10) ? '0' + d.toString() : d.toString();
                }
                else {
                    document.getElementById("<%=txtEndExHours.ClientID %>").value = (d.value < 10 && d.value != 0) ? '0' + d.value : d.value;
                }
            }
        }

        function pad1(d) {
        
            if (d.value.length < 2) {
                if (d.value == '0') {
                    document.getElementById("<%=txtStartExHours.ClientID %>").value = '0';
                    // return (d.value < 10) ? '0' + d.toString() : d.toString();
                }
                else {
                    document.getElementById("<%=txtStartExHours.ClientID %>").value = (d.value < 10 && d.value != 0) ? '0' + d.value : d.value;
                }
            }
        }

    </script>
    <div id="popup" style="display: none;">
    </div>
    <div id='editorPopup' style="display: none; position: absolute; margin-top: 150px;
        margin-left: 150px; z-index: 100;">
        <uc2:UCEditor ID="UCEditor1" runat="server" />
    </div>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div id="wrapper">
                <div class="headernav">
                    <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                        Style="border: 0; border-color: White!important;"></asp:TextBox>
                    <div class="largetxt" style="text-align: left;">
                        <asp:Label runat="server" ID="lblBulletinName" CssClass="navy20" Height="25px" Width="100%"></asp:Label></div>
                </div>
                <div style="text-align: center;">
                    <asp:Label ID="lblerror" runat="server" Style="color: Red;"></asp:Label>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                        <ProgressTemplate>
                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                size="2">Processing....</font></b></ProgressTemplate>
                    </asp:UpdateProgress>
                    <div style="width: 300px; margin: 0 auto;">
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                            ValidationGroup="EA" HeaderText="The following error(s) occurred:" />
                        <asp:Label ID="lblmess" runat="server" Font-Size="Medium" ForeColor="Green"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="contentwrap">
                    <div class="largetxt">
                        Office Closure</div>
                    <div class="form_wrapper" style="float: none; width: auto;">
                        <div class="fields_wrap">
                            <label id="lblMandatory" style="color: Red; font-size: 16px; margin-left: 100px;
                                display: none;">
                                * Marked fields are mandatory.</label>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="steps">
                        </div>
                        <div class="fields_wrap ">
                            <div class="lefttable">
                                <font color="red">*</font>
                                <label>
                                    Date</label></div>
                            <div class="right_fields">
                                <asp:TextBox ID="txtAnnounceDate" runat="server"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtAnnounceDate"
                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                </cc1:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                    ControlToValidate="txtAnnounceDate" ValidationGroup="EA" ErrorMessage="Date is mandatory.">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                    ControlToValidate="txtAnnounceDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                    ValidationGroup="EA" ErrorMessage="Invalid Date Format of Date.">*</asp:RegularExpressionValidator>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAnnounceDate"
                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                            </div>
                        </div>
                        <div class="fields_wrap ">
                            <div class="lefttable">
                                <label>
                                    Start Time:</label></div>
                            <div class="right_fields">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtStartExHours" Width="50px" MaxLength="2" onChange="ShowEndTime();" onblur="pad1(this);"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" TargetControlID="txtStartExHours"
                                                WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                            </cc1:TextBoxWatermarkExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                ControlToValidate="txtStartExHours" ValidationExpression="^(1[0-2]|0?[0-9])"
                                                ValidationGroup="EA" ErrorMessage="Invalid Start Time">*</asp:RegularExpressionValidator>
                                            &nbsp; &nbsp;
                                            <asp:TextBox runat="server" ID="txtStartExMinutes" Width="50px" MaxLength="2" Enabled="false"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" TargetControlID="txtStartExMinutes"
                                                WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                            </cc1:TextBoxWatermarkExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="Dynamic"
                                                ControlToValidate="txtStartExMinutes" ValidationExpression="^[0-5]\d" ValidationGroup="EA"
                                                ErrorMessage="Invalid Start Time">*</asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlStartExSS" Width="60px" Enabled="false">
                                                <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="fields_wrap ">
                            <div class="lefttable">
                                <label>
                                    End Time:</label></div>
                            <div class="right_fields">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtEndExHours" Width="50px" MaxLength="2" Enabled="false" onChange="ShowEndMin();" onblur="pad(this);"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtEndExHours"
                                                WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                            </cc1:TextBoxWatermarkExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic"
                                                ControlToValidate="txtEndExHours" ValidationExpression="^(1[0-2]|0?[0-9])" ValidationGroup="EA"
                                                ErrorMessage="Invalid End Time">*</asp:RegularExpressionValidator>
                                               
                                            &nbsp; &nbsp;
                                            <asp:TextBox runat="server" ID="txtEndExMinutes" Width="50px" MaxLength="2" Enabled="false"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtEndExMinutes"
                                                WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                            </cc1:TextBoxWatermarkExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                                                ControlToValidate="txtEndExMinutes" ValidationExpression="^[0-5]\d" ValidationGroup="EA"
                                                ErrorMessage="Invalid End Time">*</asp:RegularExpressionValidator>
                                               
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlEndExSS" Width="60px" Enabled="false">
                                                <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="fields_wrap ">
                            <div class="lefttable">
                                <label>
                                    Location:</label></div>
                            <div class="right_fields">
                                <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                                <%--placeholder="hh.mmAM/PM"--%>
                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLocation"
                                    ErrorMessage="Location is mandatory." Display="Dynamic" ValidationGroup="EA"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <div class="fields_wrap ">
                            <div class="lefttable">
                                <label>
                                    Contact Email:</label></div>
                            <div class="right_fields">
                                <asp:TextBox ID="txtContactEmail" runat="server"></asp:TextBox>
                                <%--placeholder="hh.mmAM/PM"--%>
                                <asp:RegularExpressionValidator ID="revEmailID" runat="server" ControlToValidate="txtContactEmail"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid email."
                                    Display="Dynamic" ValidationGroup="EA" Font-Size="Small"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="fields_wrap ">
                            <div class="lefttable">
                                <label>
                                    Contact Phone Number:</label></div>
                            <div class="right_fields">
                                <asp:TextBox ID="txtPhoneNumber" onkeyup="transform(this);" runat="server" MaxLength="12"></asp:TextBox>
                                <%--placeholder="hh.mmAM/PM"--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhoneNumber"
                                    ErrorMessage="Invalid mobile number." Display="Dynamic" ValidationExpression=".{12}.*"
                                    ValidationGroup="EA"></asp:RegularExpressionValidator><br />
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="steps">
                        </div>
                        <div class="stepswrapmain">
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="clear0">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <div class="avatar" style="border-width: 1px; width: 530px; display: block; max-height: 430px;
                                        overflow: auto;">
                                        <asp:Label ID="lblBulletinedit" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div style="float: right; text-align: right; margin-right: 100px;">
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_TEXT');" src="../../Images/addnewtext.png" />
                                <a id="A1" href="javascript:ModalHelpPopup('Add Text to Content',21,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a><br />
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_IMAGE');" src="../../Images/addnewimg.png" />
                                <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Add Image to Content',20,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a><br />
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_WORDCONTENT');" src="../../Images/AddMSWord.png" />
                                <a id="A3" href="javascript:ModalHelpPopup('Upload a Microsoft Word Document to a Content Template',314,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    &nbsp; Expiration Date & Time:
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <table width="80%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                                     <tr>
                                            <td>
                                                <asp:TextBox ID="txtExDate" runat="server" Width="100px" Height="18px" onChange="ShowExTimeDiv();"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txtExDate"
                                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtExDate"
                                                    ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                                <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExDate" Format="MM/dd/yyyy"
                                                    CssClass="MyCalendar" />
                                            </td>
                                            <td>
                                                <TimerUC:TimeControl ID="ExpiryTimeControl1" runat="server" Enabled="false" />
                                            </td>
                                        </tr>
                                        </table>
                                    </div>
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
                                            <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                            <div style="margin: 10px 10px 0px 80px; display: none;" id="divpublish">
                                                <div id="divSchedulePublish" style="display: block;">
                                                    <font color="red">*</font>
                                                    <label style="font-size: 14px;">
                                                        Publish On:</label>
                                                    <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                        ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                        runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="EA"
                                                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                        ValidationGroup="EA" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                    <br />
                                                    <span style="padding-left: 85px;"><b>(MM/DD/YYYY)</b></span>
                                                    <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                        Format="MM/dd/yyyy" CssClass="MyCalendar" OnClientDateSelectionChanged="OnTextChanged" />
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
                                                <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <%if (Session["VerticalDomain"] != null && Session["VerticalDomain"].ToString().ToLower().Contains("uspdhub"))
                              {
                            %>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    Category:
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px;">
                                    <asp:DropDownList ID="ddlCategories" runat="server" Width="200px" onchange="categoryonchange()">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%} %>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px;">
                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClientClick="return SaveAlert();"
                                        OnClick="BtnPublish_Click" border="0" CssClass="btn" />
                                    <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="EA" OnClientClick="return PreviewHTML('3')"
                                        OnClick="BtnPublish_Click" border="0" CssClass="btn" />
                                    <asp:Button ID="BtnPublish" runat="server" Text="Submit" ValidationGroup="EA" OnClientClick="return PreviewHTML('3')"
                                        OnClick="BtnPublish_Click" border="0" CssClass="btn" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return PreviewHTML('1');">
                                        <img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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
                                                        request is in progress, please don't refresh or close window.</font></b></ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <input type="hidden" id='ids' value='' />
            <input type="hidden" id='htmlvalue' />
            <input type="hidden" id="editDivCheck" value="" />
            <input type="hidden" id="hdnalignindex" />
            <input type="hidden" id='hdnBTempID' value="6" runat="server" />
            <asp:HiddenField runat="server" ID="hdnEditHTML" />
            <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
            <asp:HiddenField runat="server" ID="hdnExDate" />
            <asp:HiddenField runat="server" ID="hdnPrivate" />
            <asp:HiddenField runat="server" ID="hdnCompleted" />
            <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
            <input type="hidden" id="hdnChanges" value="false" />
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
            <asp:HiddenField ID="hdnRootPath" runat="server" />
            <asp:HiddenField ID="hdnDescription" runat="server" Value="" />
            <input type="hidden" id="hdnIsTextEdits" value="false" />
            <input type="hidden" runat="server" id="hdnBulletinID" value="0" />
            <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkPreview" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblBulletinPreview" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popupBulletinpreview" runat="server" TargetControlID="lblBulletinPreview"
                PopupControlID="pnlpreviewBulletin" BackgroundCssClass="modal" CancelControlID="imgclosepreviewpopup"
                BehaviorID="BulletinPreview">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlpreviewBulletin" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                padding-top: 10px" align="left" colspan="2">
                                <asp:Label ID="lblbulletiname" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; padding: 10px;" colspan="2">
                                <div style="overflow-y: auto; height: 500px; position: relative;">
                                    <asp:Label ID="lblnewspreview" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblVideoPreview" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popupVideo" runat="server" TargetControlID="lblVideoPreview"
                PopupControlID="pnlVideoPreview" BackgroundCssClass="modal" CancelControlID="imgclosVidepepreviewpopup"
                BehaviorID="VidePreview">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlVideoPreview" runat="server" Style="display: none" Width="700px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosVidepepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid">
                                <div id="divVideomIframe">
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
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
                                <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
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
    <asp:UpdatePanel ID="Upda" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblWordContent" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="ModalPopupWordContent" runat="server" TargetControlID="lblWordContent"
                PopupControlID="PnlWordContent" BackgroundCssClass="modal" CancelControlID="imgcloseWordContentPreviewpopup"
                BehaviorID="WordContentPreview">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="PnlWordContent" runat="server" Style="display: none" Width="700px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgcloseWordContentPreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid">
                                <div id="divFrameWordContent">
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
