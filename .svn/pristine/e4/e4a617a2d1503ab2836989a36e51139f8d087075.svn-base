<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    EnableEventValidation="true" ValidateRequest="false" CodeBehind="CMSheriffCrimeHighlights.aspx.cs"
    Inherits="UserForms.CMSheriffCrimeHighlights" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../Styles/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="../../Styles/Bulletins.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/flyers/jquery-ui-1.8.21.custom.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.textarea-expander.js" type="text/javascript"></script>
    <script type="text/javascript">
        function LoadDataPickers(datepickerID) {
            $("#" + datepickerID).datepicker();
        }
    </script>
    <script type="text/javascript">
        $(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
            $('#ctl00_cphUser_txtPhone').keyup(function (event) {
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
                var val = this.value.replace(/\D/g, '');
                var newVal = '';
                if (val.length > 10) {
                    val = val.substring(0, 10)
                }
                while (val.length >= 3 && newVal.length <= 7) {
                    newVal += val.substr(0, 3) + '-';
                    val = val.substr(3);
                }
                newVal += val;
                this.value = newVal;
            });
        });
    </script>
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
        }
    </style>
    <style>
        .lightText
        {
            color: #9B9B9B;
        }
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
            text-align: justify;
            border: 1px solid black;
            overflow: auto;
            font-family: Arial;
            font-size: 12px;
            width: 200px;
        }
        .imgdivStyle
        {
            text-align: justify;
            border: 1px solid black;
            overflow: auto;
            font-family: Arial;
            font-size: 12px;
        }
        .lightText
        {
            color: #9B9B9B;
        }
    </style>
    <style type="text/css">
        .radius
        {
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
        }
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
    </style>
    <%--Application COntrol Style--%>
    <style>
        body, h1, h2, h3, h4, h5, h6
        {
            margin: 0px;
            padding: 0px;
            font-family: Arial, Helvetica, sans-serif;
            outline: 0px;
            border: 0px;
        }
        .clear
        {
            clear: both;
        }
        .clear10
        {
            clear: both;
            height: 10px;
        }
        #wrapper
        {
            width: 100%;
            margin: 0 auto;
            padding: 0px;
            border: 1px solid #fff;
        }
        .header
        {
            background: #eeeeee url(../images/BulletinThumbs/header_bg.gif) repeat-x;
            min-height: 74px;
            padding: 20px 0px;
        }
        .datawrap
        {
            margin: 0 auto;
            width: 500px;
            overflow: hidden;
        }
        .logo
        {
            float: left;
            margin: 0px 0px 0px 50px;
        }
        .txtwrap
        {
            float: left;
            margin: 0px 0px 0px 30px;
        }
        h1
        {
            font-size: 28px;
            line-height: 25px;
            font-weight: bold;
            color: #fcb040;
            text-align: center;
        }
        h2
        {
            font-size: 18px;
            line-height: 28px;
            font-weight: normal;
            color: #6e7723;
            text-align: center;
        }
        h4
        {
            font-size: 16px;
            line-height: 28px;
            font-weight: bold;
            color: #383838;
            text-align: center;
        }
        .contentwrap
        {
            background: #fffdfb;
            overflow: hidden;
            padding: 15px 10px 40px 10px;
        }
        
        .largetxt
        {
            font-size: 26px;
            line-height: 28px;
            font-weight: normal;
            color: #f15b29;
            text-align: center;
            padding: 0px 0px 10px 0px;
            border-bottom: 1px dashed #d1d1d1;
        }
        .browseimg_wrap
        {
            margin: 0px auto;
            width: 500px;
            overflow: hidden;
            padding: 20px 0px 20px 70px;
        }
        .avatar
        {
            margin: 0px 20px 0px 0px;
            float: left;
            border: 1px solid #dddddd;
            padding: 0px;
        }
        .browse_btn
        {
            float: left;
            outline: 0px;
            margin: 10px 0px 0px 0px;
        }
        
        label
        {
            color: #313131;
            font-size: 14px;
            text-align: left;
        }
        .label1
        {
            color: #313131;
            font-size: 15px;
            text-align: left;
        }
        .txtfildwrap
        {
            border: 1px solid #cccccc;
            height: 30px;
            width: 330px;
            margin: 5px 0px 30px 0px;
        }
        .txtfildwrap img
        {
            float: right;
        }
        .txtfild
        {
            color: #555555;
            width: 208px;
            float: left;
            border: none;
            outline: none;
            padding: 4px 0px 0px 4px;
        }
        input[type="checkbox"]
        {
            display: inline;
        }
        .signin_btn
        {
            float: right;
            width: 92px;
            height: 35px;
            margin: 0px 47px 0px 0px;
        }
        .remember_txt
        {
            float: left;
            color: #848484;
            font-size: 12px;
            text-align: left;
        }
        /*Form Styles*/
        
        .form_wrapper
        {
            overflow: hidden;
            width: 752px;
            float: left;
        }
        .fields_wrap
        {
            width: 100%;
            margin: 0px 0px;
        }
        .left_lable
        {
            float: left;
            text-align: left;
            width: 160px;
            padding: 3px 0px 0px 0px;
            margin: 2px 20px 0px 100px;
        }
        .right_fields
        {
            color: #353535;
            float: left;
            padding: 3px 0px 0px 0px;
            font-size: 12px;
            margin: 2px 0px;
            width: 400px;
        }
        /*.right_buttons
{
    color: #353535;
    float: right;
    padding: 3px 0px 0px 0px;
    font-size: 12px;
    margin: -135px 0px;
    width: 200px;
    height:100px;
}*/
        .txtfild1
        {
            color: #555555;
            height: 24px;
            width: 248px;
            background: #fff;
            border: 1px solid #d7d7d7;
            outline: none;
            color: #313131;
            font-size: 13px;
            text-align: left;
            padding: 4px 0px 0px 4px;
        }
        .txtfild2
        {
            color: #555555;
            height: 24px;
            width: 73px;
            float: left;
            color: #313131;
            font-size: 13px;
            text-align: left;
            background: #fff;
            border: 1px solid #d7d7d7;
            outline: none;
            padding: 4px 0px 0px 4px;
        }
        textarea
        {
            min-height: 60px;
            font-size: 13px;
            text-align: left;
            width: 252px;
            border: 1px solid #d7d7d7;
            resize: none;
            clear: both;
            background: #fff;
            font-family: Arial, Helvetica, sans-serif;
            outline: none;
            padding: 4px 0px 0px 0px;
            margin: 0px 0px 4px 0px;
        }
        select
        {
            color: #555555;
            height: 24px;
            width: 82px;
            color: #313131;
            font-size: 13px;
            text-align: left;
            border: 1px solid #c9c9c9;
            outline: none;
            margin: 0px 4px 0px 0px;
            background: #fff;
        }
        .select1
        {
            color: #555555;
            height: 28px;
            width: 170px;
            float: left;
            border: 1px solid #c9c9c9;
            outline: none;
            margin: 0px 4px 0px 0px;
            background: #fff;
            padding: 3px;
        }
        
        .row3
        {
            background: #fffcf9;
            margin: 2px 0px;
            overflow: hidden;
            min-height: 30px;
            padding: 10px 0px 10px 0px;
        }
        .row4
        {
            background: #f8f8f8;
            overflow: hidden;
            margin: 2px 0px;
            min-height: 30px;
            padding: 10px 0px 10px 0px;
        }
        .btn
        {
            background: url(../../images/BulletinThumbs/button_bg.gif) repeat-x;
            height: 37px;
            float: left;
            border: 1px solid #dcdcdc;
            margin: 0px 6px 0px 0px;
            cursor: hand;
            cursor: pointer;
            padding: 0px 20px;
            font-size: 16px; /*color: #464646;*/
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px; /* future proofing */
            -khtml-border-radius: 4px; /* for old Konqueror browsers */
            text-shadow: 1px 1px 1px #f2f2f2;
        }
        #preview
        {
            left: 43%;
            margin: 0 auto;
            position: absolute;
            z-index: 999;
            top: 200px;
            background-color: #E9E9E9;
        }
        .closebtn
        {
            margin: 0;
            padding: 0;
            position: absolute;
            right: -7px;
            top: -10px;
        }
        .black_overlay
        {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 1540px;
            background-color: black;
            z-index: 800;
            opacity: 0.7;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=70)";
            filter: alpha(opacity=70);
        }
        /* *** Adding style for file upload *** */
        .file-upload
        {
            overflow: hidden;
            display: inline-block;
            position: relative;
            vertical-align: middle;
            text-align: center; /* Cosmetics */
            border: 1px solid #cfcfcf;
            background: #e2e2e2; /* Nice if your browser can do it */
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            cursor: pointer;
        }
        
        .file-upload:hover
        {
            background: #e9e9e9;
        }
        
        .file-upload.focus
        {
            outline: 1px solid yellow;
        }
        
        .file-upload input
        {
            position: absolute;
            top: 0;
            left: 0;
            margin: 0;
            font-size: 10pt; /* Loses tab index in webkit if width is set to 0 */
            opacity: 0;
            filter: alpha(opacity=0);
        }
        
        .file-upload strong
        {
            padding-top: 5px;
            font-size: 9pt;
            font-weight: normal;
        }
        
        .file-upload span
        {
            position: absolute;
            top: 0;
            left: 0;
            z-index: 100;
            display: inline-block; /* Adjust button text vertical alignment */
            padding-top: 5px;
        }
        
        /* Adjust the button size */
        .file-upload
        {
            height: 22px;
        }
        .file-upload, .file-upload span
        {
            width: 75px;
        }
        .headernav
        {
            color: #2F348F;
            font-family: Arial;
            font-size: 16px;
            font-weight: bold;
        }
        .highlightLabel
        {
            color: red;
        }
        .watermarkbulletindate
        {
            color: Gray;
        }
        .headerdropdown
        {
            padding-left: 75px;
            color: #555555;
            height: 28px;
            width: 170px;
            float: left;
            border: 1px solid #c9c9c9;
            outline: none;
            margin: 0px 4px 0px 0px;
            background: #fff;
        }
    </style>
    <%--  AddIncidentPanel--%>
    <script type="text/javascript">

        // Delete Call Header Row & Preview & Edit html
        function RemoveIncidentPanel(value) {
            var divID = value.id;
            var trID = divID.replace("edit", "tr");
            var trHeaderID = divID.replace("edit", "trheader");
            var trpreviewID = divID.replace("edit", "trpreview");

            if (confirm("Are you sure you want to delete this incident?")) {
                $("#" + trID).remove();
                $("#" + trHeaderID).remove();
                $("#" + trpreviewID).remove();
            }
            var divCount = $("#maintable tr").size();
            if (divCount <= 0) {
                document.getElementById('<%= lblBulletinedit.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
            }
        }

        function AddIncidentPanel() {

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
            //            for (i = 0; i < divtable.rows.length; i++) {
            //                for (j = 0; j < divtable.rows[i].cells.length - 1; j++) {
            //                    for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
            //                        CID++;
            //                    }
            //                }
            //            }

            //            // GET MAX DIV ID
            //            CID = CID + 1;
            //            for (i = CID; i <= CID; i++) {
            //                alert(i);
            //                if (!document.getElementById("edit" + i)) {
            //                    break;
            //                }
            //                else {
            //                    CID++;
            //                }
            //            }
            CID = CID + 1;
            document.getElementById('DivIds').value = CID;

            var newRow = "<tr class=\"trheader\" id='trheader" + CID + "' >" +
                                "<td style=\"border-left: 2px dashed blue; border-right: 2px dashed blue; border-Top: 2px dashed blue; border-bottom:1px solid gray;\">" +
                                    "<span style='font-size:20px; margin-top:20px;'><b>&nbsp;&nbsp;Incident&nbsp;&nbsp;</b></span>" +
                                    "<img align='right' src=\"../../Images/del_inc.png\" style='cursor: pointer; padding-right:5px;' onclick='RemoveIncidentPanel(edit" + CID + ")' />&nbsp;&nbsp;" +
                                    "<img align='right' src=\"../../Images/edit_inc.png\" style='cursor: pointer; display:none; padding-right:5px;' id='imgeditIncident" + CID + "' onclick='EditIncidentPanel(trpreview" + CID + ")'  />&nbsp;&nbsp;" +
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
                                            "<tr>" + // Date
                                                "<td>Date Occurred</td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtDate" + CID + "' name='txtDate" + CID + "' /> &nbsp;&nbsp; <input type='text' style='font-weight:bold;' id='txtendDate" + CID + "' name='txtendDate" + CID + "' /></td>" +
                                            "</tr>" +
                                            "<tr>" + // Title
                                                "<td><span style='font-weight:bold;'>Crime</span></td>" +
                                                "<td> <textarea style='width: 345px; font-weight:bold;' id='txtTitle" + CID + "'></textarea></td>" +
                                            "</tr>" +
                                            "<tr>" + // Address
                                                "<td><span style='font-weight:bold;'>Address</span></td>" +
                                                "<td><textarea style='width: 345px; font-weight:bold;' id='txtAddress" + CID + "'></textarea></td>" +
                                            "</tr>" +
                                            "<tr>" + // Description
                                                "<td><span style='font-weight:bold;'>Description</span></td>" +
                                                "<td><textarea style='width: 345px;' id='txtDescription" + CID + "'></textarea></td>" +
                                            "</tr>" +
                                            "<tr>" + // Image Row Section
                                                "<td colspan='2' align='center'><span style='font-weight:bold;'><img src='../../Images/addimg.png' id='imagesection" + CID + "' onclick='AddNewImageDiv(this.id)'  style='cursor: pointer; display:none;' /></span></td>" +
                                            "</tr>" +
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
                                                            "<tr id='imgCapRow" + CID + "_1'>" + // Image Caption
                                                                "<td style='padding-top:5px; padding-bottom:5px;'><span>Image Caption</span></td>" +
                                                                "<td style='padding-top:5px; padding-bottom:5px;'><input type='text' style='width: 325px;' id='imgCaption" + CID + "_1' /></td>" +
                                                            "</tr>" +
                                                    "</table>" +
                                                "</td>" +
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
                //$("#" + divtable.rows[divtable.rows.length - 1].id).after(newRow);
                var lastrow = CID - 1;
                $("#tr" + lastrow).after(newRow);
            }

            //Auto scroll when add new item
            //var co = document.getElementById("txtEmpty" + CID);

            var objDiv = document.getElementById("divMain");
            objDiv.scrollTop = objDiv.scrollHeight;

            //$("#edit" + CID).animate({ scrollTop: $(document).height() }, 1000);


            // Show Date Picker 
            LoadDataPickers("txtDate" + CID);
            LoadDataPickers("txtendDate" + CID);

            TextAreaBoxHeightSet("txtDescription" + CID);
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
                                                       "</div> &nbsp;&nbsp;<div style='float:left; margin-left:10px;'> <img src='../../Images/editimg.png'  style='cursor: pointer;' onclick='EditImage(divimage" + parentdivID + "_" + subDIVID + "," + parentdivID + ")' /> " +
                                                       " <br/><img src='../../Images/deleteimg.png'  style='cursor: pointer;' onclick='DeleteImage(divimage" + parentdivID + "_" + subDIVID + ")' /> </div>" +
                                                 "</td>" +
                                         "</tr>" +
                                          "<tr id='imgCapRow" + parentdivID + "_" + subDIVID + "'>" + // Image Caption
                                                     "<td style='padding-top:5px; padding-bottom:5px;'> <span> Image Caption </span>  </td> <td style='padding-top:5px;  padding-bottom:5px;'> <input type='text' style='width: 325px; ' id='imgCaption" + parentdivID + "_" + subDIVID + "' /> </td> " +
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

        //Show the Image Gallery
        function EditImage(value, parentID) {
            imgdivID = value.id;
            document.getElementById('DivIds').value = parentID;

            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            //            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 12) + "&imgSrc=" + imgSrc + "&folder=Forms");
            //            ifrm.style.height = "750px";
            ifrm.setAttribute("src", "BulletinsForm_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 12) + "&imgSrc=" + imgSrc + "&folder=Forms");
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
            var imgrowID = imgID.id.replace("divimage", "imgRow");
            var imgCapID = imgID.id.replace("divimage", "imgCapRow");
            if (confirm("Are you sure you want to delete this image?")) {
                $("#" + imgrowID).remove();
                $("#" + imgCapID).remove();

                var ImgDivID = document.getElementById('DivIds').value;
                if (document.getElementById("imagesection" + ImgDivID) != null) {
                    document.getElementById("imagesection" + ImgDivID).style.display = 'block';
                }
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

        function ShowPublicPrivate(val, ischange) {
            document.getElementById("<%=rbPublish.ClientID %>").checked = true;
            document.getElementById("<%=rbUnPublish.ClientID %>").checked = false;
        }
        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
                DisplayComplete();
            if (document.getElementById('<%=rbPublish.ClientID %>').checked) {

                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";

            }
            else {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            }
        }
        function DisplayComplete() {
            if (document.getElementById('<%= rbPublish.ClientID%>').checked)
                document.getElementById('divpublish').style.display = "block";
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
                if (ischanges == "true" && document.getElementById('<%= txtPublishDate.ClientID%>').value == "") {
                    if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
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
                document.getElementById(controlName).disabled = false;
            }
        }

    </script>
    <%--Edit & Load & Save Incident Details--%>
    <script type="text/javascript">

        function TextAreaBoxHeightSet(txtID) {

            /*
            $('textarea').change(function () {
            var ids = this.id;
            alert(ids);
            if (ids.indexOf('txtDescription') != -1) {
            $("#" + ids).height(10);
            $("#" + ids).height($("#" + ids).prop('scrollHeight'));
            }
            });

            if (txtID != null) {
            $("#" + txtID).height($("#" + txtID).prop('scrollHeight'));
            }
            */

            $('#' + txtID).TextAreaExpander();
        }

        function EditIncidentPanel(controlID, editImageControl) {
            var id = controlID.id.replace(/trpreview/gi, "");
            $("#trpreview" + id).css('display', 'none');

            // For Date Picker Loading....
            $("#txtDate" + id).removeAttr("class");
            $("#txtDate" + id).datepicker();

            $("#txtendDate" + id).removeAttr("class");
            $("#txtendDate" + id).datepicker();


            $("#tr" + id).css('display', 'block');
            $("#imgeditIncident" + id).css('display', 'none');

            TextAreaBoxHeightSet("txtDescription" + id);
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
                        $("#imgeditIncident" + j).css('display', '');
                    }
                })
                //                for (x = 0; x < divtable.rows.length; ) {
                //                    j = divtable.rows[x].id.replace('trheader', '');
                //                    //We have 3rows every call 1==Header 2==preview 3==edit row
                //                    x = x + 3;
                //                    alert(j);
                //                    var html = document.getElementById("tblpreview" + j).outerHTML;
                //                    $("#tdpreview" + j).append(html);
                //                    document.getElementById("tblpreview" + j).style.width = '100%';

                //                }

                //                for (x = 0; x < divtable.rows.length; ) {
                //                    j = divtable.rows[x].id.replace('trheader', '');

                //                    //We have 3rows every call 1==Header 2==preview 3==edit row
                //                    x = x + 3;
                //                    $("#tr" + j).css('display', 'none');
                //                    $("#trpreview" + j).css('display', 'block');
                //                    $("#imgeditIncident" + j).css('display', '');

                //                }

            }

            document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
            document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";

            if (document.getElementById('<%=rbUnPublish.ClientID %>').checked == true) {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
            }

            $("#dummyDIV").css('display', 'none');
        }



        function ValidateCallDetails() {

            var reurnValue = true;
            if (Page_ClientValidate('ABC') && Page_IsValid) {
                var ExDate = document.getElementById("<%=txtExDate.ClientID %>").value;

                if (ExDate != "") {
                    var allddls = document.getElementsByTagName("select");
                    for (k = 0; k < allddls.length; k++) {
                        var controlName = allddls[k].id;
                        if (controlName.indexOf("ddlTime") >= 0) {
                            break;
                        }
                    }

                    var ExDate_Time = ExDate + " " + document.getElementById(controlName).value;
                    var todayDate = new Date();
                    ExDate_Time = new Date(ExDate_Time);
                    if (ExDate_Time < todayDate) {
                        alert('Expiration date should be later than current date.');
                        document.getElementById("<%=txtExDate.ClientID %>").focus();
                        reurnValue = false;
                        return;
                    }

                }

                reurnValue = true;
            }
            else {
                reurnValue = false;
            }

            return reurnValue;
        }

        // Save Data
        function SaveHTMLData() {
            //getting preview html
            if (ValidateCallDetails()) {

                //                if (document.getElementById("maintable") != null)
                //                    var elems = document.getElementById("maintable").getElementsByTagName("div");
                //Validate the Crime Dates
                var divtable = document.getElementById("maintable");
                var returnval = true;
                if (divtable != null) {

                    if (divtable != "") {
                        childTable = "";
                        $('#maintable tr.trheader').each(function () {
                            if (returnval == true) {
                                //                            var value = elems[x].id;

                                //                            if (value.startsWith("edit")) {
                                //                                i = value.replace('edit', '');
                                //                            }
                                //                            else {
                                //                                continue;
                                //                            }
                                //                            //We have 3rows every call 1==Header 2==preview 3==edit row
                                //                            x = x + 3;
                                var i = $(this).attr('id').replace('trheader', '');
                                var startDate = document.getElementById("txtDate" + i).value.trim();
                                var endDate = "";
                                if (document.getElementById("txtendDate" + i) != null) {
                                    endDate = document.getElementById("txtendDate" + i).value.trim();
                                }
                                if (endDate != "" && startDate == "") {
                                    alert("Please enter the First Date Occurred.");
                                    document.getElementById("txtDate" + i).focus();
                                    returnval = false;
                                }
                                else if (startDate != "" && endDate != "") {
                                    var startDatespl = startDate.split("/");
                                    var endDatespl = endDate.split("/")
                                    var dateOne = new Date(startDatespl[2], startDatespl[0], startDatespl[1]); //Year, Month, Date
                                    var dateTwo = new Date(endDatespl[2], endDatespl[0], endDatespl[1]); //Year, Month, Date

                                    if (dateOne > dateTwo) {
                                        alert("Second Date Occurred should be later than or equal to First Date Occurred.");
                                        document.getElementById("txtDate" + i).focus();
                                        returnval = false;
                                    }
                                }
                                else {
                                    returnval = true;
                                }
                            }
                            else {
                                return false;
                            }
                        });
                    }
                }
                //
                if (returnval == false)
                    return false;
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
                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                }

                var isCompleted = false;
                var exDate = document.getElementById("<%=txtExDate.ClientID %>").value;
                document.getElementById("<%=hdnExDate.ClientID %>").value = exDate;
                document.getElementById("<%=hdnPublish.ClientID %>").value = document.getElementById('<%=rbPublish.ClientID %>').checked;
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

                var divtable = document.getElementById("maintable");
            }

            var ROWS = "";
            var previewHTMLStr = "";

            var XMLString = "";

            // bulletin & login name
            var fromDate = document.getElementById("<%=txtFromDate.ClientID %>").value.trim();
            var toDate = document.getElementById("<%=txtToDate.ClientID %>").value;
            if (fromDate != "") {
                //HTML
                ROWS = "<tr><td style='padding-top:5px; padding-left:5px;'>From Date:</td><td   style='padding-left:5px;'>" + fromDate + "</td></tr>";
                //XML
                XMLString = " FromDate= '" + fromDate + "'  ";
            }
            if (toDate != "") {
                //HTML
                ROWS = ROWS + "<tr><td  style='padding-top:5px; padding-left:5px;'>To Date:</td><td   style='padding-left:5px;'>" + toDate + "</td></tr>";
                //XML
                XMLString = XMLString + " ToDate= '" + toDate + "'  ";
            }

            var IsSubmittedBy = false;
            // Submitted By :: Officer Type 1
            var submittedBy1 = document.getElementById("<%=ddlSubmitBy1.ClientID %>").value;
            var asscoiate1 = document.getElementById("<%=ddlAssociates1.ClientID %>").value;

            if (submittedBy1.toString().trim() != "") {
                IsSubmittedBy = true;
                ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>Submitted by: </td><td   style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy1 + "&nbsp;" + asscoiate1 + "</td></tr>";
            }
            XMLString = XMLString + "  Officer1= '" + submittedBy1 + "' Associates1= '" + asscoiate1 + "' ";

            // Submitted By :: Officer Type 2
            var submittedBy2 = document.getElementById("<%=ddlSubmitBy2.ClientID %>").value;
            var asscoiate2 = document.getElementById("<%=ddlAssociates2.ClientID %>").value;

            if (submittedBy2.toString().trim() != "") {
                if (IsSubmittedBy == false) {
                    IsSubmittedBy = true;
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>Submitted by: </td><td   style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy2 + "&nbsp; " + asscoiate2 + "</td></tr>";
                } else {
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>&nbsp;</td><td  style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy2 + "&nbsp;" + asscoiate2 + "</td></tr>";
                }
            }
            XMLString = XMLString + "  Officer2= '" + submittedBy2 + "' Associates2= '" + asscoiate2 + "' ";

            // Submitted By :: Officer Type 3
            var submittedBy3 = document.getElementById("<%=ddlSubmitBy3.ClientID %>").value;
            var asscoiate3 = document.getElementById("<%=ddlAssociates3.ClientID %>").value;

            if (submittedBy3.toString().trim() != "") {
                if (IsSubmittedBy == false) {
                    IsSubmittedBy = true;
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>Submitted by: </td><td  style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy3 + "&nbsp; " + asscoiate3 + "</td></tr>";
                }
                else {
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>&nbsp;</td><td  style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy3 + "&nbsp;" + asscoiate3 + "</td></tr>";
                }
            }
            XMLString = XMLString + "  Officer3= '" + submittedBy3 + "' Associates3= '" + asscoiate3 + "' ";

            // Submitted By :: Officer Type 4
            var submittedBy4 = document.getElementById("<%=ddlSubmitBy4.ClientID %>").value;
            var asscoiate4 = document.getElementById("<%=ddlAssociates4.ClientID %>").value;

            if (submittedBy4.toString().trim() != "") {
                if (IsSubmittedBy == false) {
                    IsSubmittedBy = true;
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>Submitted by: </td><td  style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy4 + "&nbsp;" + asscoiate4 + "</td></tr>";
                }
                else {
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>&nbsp;</td><td  style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy4 + "&nbsp; " + asscoiate4 + "</td></tr>";
                }
            }
            XMLString = XMLString + "  Officer4= '" + submittedBy4 + "' Associates4= '" + asscoiate4 + "' ";

            // Submitted By :: Officer Type 5
            var submittedBy5 = document.getElementById("<%=ddlSubmitBy5.ClientID %>").value;
            var asscoiate5 = document.getElementById("<%=ddlAssociates5.ClientID %>").value;

            if (submittedBy5.toString().trim() != "") {
                if (IsSubmittedBy == false) {
                    IsSubmittedBy = true;
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>Submitted by: </td><td  style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy5 + "&nbsp; " + asscoiate5 + "</td></tr>";
                }
                else {
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>&nbsp;</td><td  style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy5 + "&nbsp;" + asscoiate5 + "</td></tr>";
                }
            }
            XMLString = XMLString + "  Officer5= '" + submittedBy5 + "' Associates5= '" + asscoiate5 + "' ";

            // Submitted By :: Officer Type 6
            var submittedBy6 = document.getElementById("<%=ddlSubmitBy6.ClientID %>").value;
            var asscoiate6 = document.getElementById("<%=ddlAssociates6.ClientID %>").value;

            if (submittedBy6.toString().trim() != "") {
                if (IsSubmittedBy == false) {
                    IsSubmittedBy = true;
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>Submitted by: </td><td  style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy6 + "&nbsp;" + asscoiate6 + "</td></tr>";
                }
                else {
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-top:5px; padding-left:5px;'>&nbsp;</td><td  style='page-break-inside: avoid; padding-left:5px;'> " + submittedBy6 + "&nbsp; " + asscoiate6 + "</td></tr>";
                }
            }
            XMLString = XMLString + "  Officer6= '" + submittedBy6 + "' Associates6= '" + asscoiate6 + "' ";

            // Contact Person Details
            var ContactTitle = document.getElementById("<%=ddlContactTitle.ClientID %>").value.replace("0", "");
            var ContactName = document.getElementById("<%=ddlContactName.ClientID %>").value.replace("0", "");
            var EmailID = document.getElementById("<%=txtEmailID.ClientID %>").value.replace("Email ID", "");
            var PhoneNumber = document.getElementById("<%=txtPhone.ClientID %>").value.replace("Phone Number(xxx-xxx-xxxx)", "");

            var IsContactAdd = false;
            //XML
            XMLString = XMLString + " ContactTitle= '" + ContactTitle + "' ContactName= '" + ContactName + "'  ";
            ROWS = ROWS + "<tr><td  style='height:15px;' colspan='2'>&nbsp;</td></tr>";
            if (ContactTitle != "" || ContactName != "") {
                //HTML
                IsContactAdd = true;
                ROWS = ROWS + "<tr><td style='page-break-inside: avoid; padding-left:5px;'>Contact Person:</td><td style='page-break-inside: avoid;'>" + ContactTitle + "&nbsp;" + ContactName + "</td></tr>";
            }

            //XML
            XMLString = XMLString + " EmailID= '" + EmailID + "'   ";
            if (EmailID != "") {
                if (IsContactAdd == false) {
                    IsContactAdd = true;
                    ROWS = ROWS + "<tr><td style='page-break-inside: avoid; padding-left:5px;'>Contact Person:</td><td style='page-break-inside: avoid;'>" + EmailID + "</td></tr>";
                }
                else {
                    //HTML
                    ROWS = ROWS + "<tr><td style='page-break-inside: avoid;'>&nbsp;</td><td style='page-break-inside: avoid;'>" + EmailID + "</td></tr>";
                }
            }

            //XML
            XMLString = XMLString + " PhoneNumber= '" + PhoneNumber + "'   ";
            if (PhoneNumber != "") {
                //HTML
                if (IsContactAdd == false) {
                    ROWS = ROWS + "<tr><td  style='page-break-inside: avoid; padding-left:5px;'>Contact Person:</td><td style='margin:0px; padding:0px;'>" + PhoneNumber + "</td></tr>";
                }
                else {
                    ROWS = ROWS + "<tr><td style='page-break-inside: avoid; margin:0px; padding:0px;'>&nbsp;</td><td style='margin:0px; padding:0px;'>" + PhoneNumber + "</td></tr>";
                }
            }
            ROWS = ROWS + "<tr><td  style='height:10px;' colspan='2'></td></tr>";
            // end Contact Person Details

            var firstBorder = " <tr><td colspan='2'><table cellpadding='0' cellspacing='0' style='border: 2px solid black; width: 300px;'>" + ROWS + "</table></td></tr>";
            // End First Border Controls

            // Start Second Border Controls
            var secondROWS = "";
            var secondBorder = "";

            var TotalIncidents = document.getElementById("<%=txtTotalIncidents.ClientID %>").value;
            if (TotalIncidents != "") {
                //HTML
                secondROWS = "<tr><td style='page-break-inside: avoid;'>Total Incidents:</td><td style='page-break-inside: avoid;'>" + TotalIncidents + "</td></tr>";
                //XML
                XMLString = XMLString + " TotalIncidents= '" + TotalIncidents + "'  ";
            }
            var OfficerInitiatedActivity = document.getElementById("<%=txtOfficerInitiatedActivity.ClientID %>").value;
            if (OfficerInitiatedActivity != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>Officer Initiated Activity:</td><td style='page-break-inside: avoid;'>" + OfficerInitiatedActivity + "</td></tr>";
                //XML
                XMLString = XMLString + " OfficerInitiatedActivity= '" + OfficerInitiatedActivity + "'  ";
            }
            var CallsforService = document.getElementById("<%=txtCallsforService.ClientID %>").value;
            if (CallsforService != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>Calls for Service:</td><td style='page-break-inside: avoid;'>" + CallsforService + "</td></tr>";
                //XML
                XMLString = XMLString + " CallsforService= '" + CallsforService + "'  ";
            }
            var ArrestsMisdemeanor = document.getElementById("<%=txtArrestsMisdemeanor.ClientID %>").value;
            if (ArrestsMisdemeanor != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>Arrests - Misdemeanor:</td><td style='page-break-inside: avoid;'>" + ArrestsMisdemeanor + "</td></tr>";
                //XML
                XMLString = XMLString + " ArrestsMisdemeanor= '" + ArrestsMisdemeanor + "'  ";
            }
            var ArrestsFelony = document.getElementById("<%=txtArrestsFelony.ClientID %>").value;
            if (ArrestsFelony != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>Arrests - Felony:</td><td style='page-break-inside: avoid;'>" + ArrestsFelony + "</td></tr>";
                //XML
                XMLString = XMLString + " ArrestsFelony= '" + ArrestsFelony + "'  ";
            }
            var CasesWritten = document.getElementById("<%=txtCasesWritten.ClientID %>").value;
            if (CasesWritten != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>Cases Written:</td><td style='page-break-inside: avoid;'>" + CasesWritten + "</td></tr>";
                //XML
                XMLString = XMLString + " CasesWritten= '" + CasesWritten + "'  ";
            }
            var TrafficStops = document.getElementById("<%=txtTrafficStops.ClientID %>").value;
            if (TrafficStops != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>Traffic Stops:</td><td style='page-break-inside: avoid;'>" + TrafficStops + "</td></tr>";
                //XML
                XMLString = XMLString + " TrafficStops= '" + TrafficStops + "'  ";
            }
            var Citations = document.getElementById("<%=txtCitations.ClientID %>").value;
            if (Citations != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>Citations:</td><td style='page-break-inside: avoid;'>" + Citations + "</td></tr>";
                //XML
                XMLString = XMLString + " Citations= '" + Citations + "'  ";
            }
            var DUIArrests = document.getElementById("<%=txtDUIArrests.ClientID %>").value;
            if (DUIArrests != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>DUI Arrests:</td><td style='page-break-inside: avoid;'>" + DUIArrests + "</td></tr>";
                //XML
                XMLString = XMLString + " DUIArrests= '" + DUIArrests + "'  ";
            }
            var Accidents = document.getElementById("<%=txtAccidents.ClientID %>").value;
            if (Accidents != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>Accidents:</td><td style='page-break-inside: avoid;'>" + Accidents + "</td></tr>";
                //XML
                XMLString = XMLString + " Accidents= '" + Accidents + "'  ";
            }
            var AccidentCriminal = document.getElementById("<%=txtAccidentCriminal.ClientID %>").value;
            if (AccidentCriminal != "") {
                //HTML
                secondROWS = secondROWS + "<tr><td style='page-break-inside: avoid;'>Accident - Criminal:</td><td style='page-break-inside: avoid;'>" + AccidentCriminal + "</td></tr>";
                //XML
                XMLString = XMLString + " AccidentCriminal= '" + AccidentCriminal + "'  ";
            }

            var secondBorder = "";
            if (secondROWS != "") {
                secondBorder = " <tr><td colspan='2'><table cellpadding='3' cellspacing='3' style='margin-top:5px; border: 2px solid black; width: 300px;'><colgroup><col width='180px'/><col width='*'/></colgroup>" + secondROWS + "</table></td></tr>";
            }
            // End First Border Controls

            //
            if (document.getElementById("maintable") != null)
                var elems = document.getElementById("maintable").getElementsByTagName("div");
            totalchildXMlString = "";
            var childTable = "";
            //Start Incident Details 
            if (divtable != "") {
                childTable = "";
                $('#maintable tr.trheader').each(function () {
                    //                    var value = elems[x].id;

                    //                    if (value.startsWith("edit")) {
                    //                        i = value.replace('edit', '');
                    //                    }
                    //                    else {
                    //                        continue;
                    //                    }
                    //                    //We have 3rows every call 1==Header 2==preview 3==edit row
                    //                    x = x + 3;

                    i = $(this).attr('id').replace('trheader', '');
                    var childRow = "";
                    var childXMLElements = "";

                    var Date = document.getElementById("txtDate" + i).value.trim();
                    var endDate = "";
                    if (document.getElementById("txtendDate" + i) != null) {
                        endDate = document.getElementById("txtendDate" + i).value.trim();
                    }
                    var Title = ReplaceSpecialCharacter(document.getElementById("txtTitle" + i).value.trim());
                    document.getElementById("txtTitle" + i).innerHTML = Title;

                    var Address = ReplaceSpecialCharacter(document.getElementById("txtAddress" + i).value.trim());
                    document.getElementById("txtAddress" + i).innerHTML = Address;

                    var Description = ReplaceSpecialCharacter(document.getElementById("txtDescription" + i).value.trim());
                    document.getElementById("txtDescription" + i).innerHTML = Description;

                    if (Date != "" && endDate != "") {
                        // HTML
                        childRow = childRow + "<tr><td style='page-break-inside: avoid;'>Date Occurred:</td><td style='page-break-inside: avoid;'><b>" + Date + " - " + endDate + " </b></td></tr>";
                        // XML
                        childXMLElements = " Date='" + Date + "' EndDate='" + endDate + "' ";
                    }
                    else if (Date != "") {// HTML
                        childRow = childRow + "<tr><td style='page-break-inside: avoid;'>Date Occurred:</td><td style='page-break-inside: avoid;'><b>" + Date + " </b></td></tr>";
                        // XML
                        childXMLElements = " Date='" + Date + "' EndDate='' ";
                    }
                    else if (endDate != "") {
                        // HTML
                        childRow = childRow + "<tr><td style='page-break-inside: avoid;'>Date Occurred:</td><td style='page-break-inside: avoid;'><b>" + endDate + " </b></td></tr>";
                        // XML
                        childXMLElements = " Date='' EndDate='" + endDate + "' ";
                    }
                    if (Title != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Crime:</td><td style='page-break-inside: avoid; padding-top:5px;'><b>" + Title + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Title='" + Title + "' ";
                    }
                    if (Address != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid; padding-top:5px;'>Address:</td><td style='page-break-inside: avoid; padding-top:5px; font-weight:bold;'>" + Address.replace(/\n/gi, "<br/>") + "</td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Address='" + Address + "' ";
                    }
                    if (Description != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid;padding-top:5px; padding-left: 0px;' colspan='2'> " + Description.replace(/\n/gi, "<br/>") + "</td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Description='" + Description + "' ";
                    }

                    //  Start Image Section Preview
                    var imgXML = "";
                    var totalimgXML = "";
                    var imgHTMLs = "";
                    var imgSectionTable = document.getElementById("imgtable" + i);
                    if (imgSectionTable.rows.length > 0) {

                        for (l = 0; l < imgSectionTable.rows.length; ) {
                            k = imgSectionTable.rows[l].id.replace('imgRow', ''); ;
                            l = l + 2;

                            var imgControl = document.getElementById("divimage" + k).innerHTML;
                            var imgCaption = ReplaceSpecialCharacter(document.getElementById("imgCaption" + k).value.trim());

                            var imgURL = "";
                            if (document.getElementById("divimage" + k).getElementsByTagName("img").length > 0) {
                                var imgList = document.getElementById("divimage" + k).getElementsByTagName("img");
                                imgURL = imgList[0].src;
                            }

                            var imgCaption = ReplaceSpecialCharacter(document.getElementById("imgCaption" + k).value.trim());
                            imgControl = imgControl.replace("/>", " alt='" + imgCaption + "' title='" + imgCaption + "' >");
                            imgControl = imgControl.replace(">", " alt='" + imgCaption + "' title='" + imgCaption + "' >")


                            if (imgControl != "") {
                                // HTML
                                imgHTMLs = imgHTMLs + "<tr><td style='page-break-inside: avoid;'>&nbsp;</td><td style='page-break-inside: avoid; padding-top:5px;'>" + imgControl + "</td></tr>";
                                // XML
                                imgXML = imgXML + " imgURL='" + imgURL + "' ";
                            }
                            if (imgCaption != "") {
                                // HTML
                                imgHTMLs = imgHTMLs + "<tr><td style='page-break-inside: avoid; padding-top:5px; padding-bottom:5px; padding-left:5px;' colspan='2'>" + imgCaption + "</td></tr>";
                                // XML
                                imgXML = imgXML + " imgCaption='" + imgCaption + "' ";
                            }

                            totalimgXML = totalimgXML + "<Images " + imgXML + "/>";
                            imgXML = "";
                        } //end loop image section

                        //
                        imgHTMLs = "<table cellspacing='0' cellpadding='0'>" + imgHTMLs + "</table>";
                        // HTML
                        childRow = childRow + "<tr><td valign='top' colspan='2' style='padding-top:5px;'>" + imgHTMLs + "</td></tr>";
                    }
                    //  End Image Section Preview


                    childRow = "<table class='radius' id='tblpreview" + i + "' cellpadding='0' cellspacing='3' style='border:1px solid black; margin-top:5px; padding-left:5px; width: 300px;'><colgroup><col width='100px'/><col width='*'/></colgroup>" + childRow + "</table>";
                    //$("#tdpreview" + i).append(childRow);
                    childTable = childTable + childRow;

                    //XML Sub Elements
                    childXMLElements = "<ChildDetails " + childXMLElements + "  >" + totalimgXML + " </ChildDetails>";
                    totalchildXMlString = totalchildXMlString + childXMLElements;

                });
            } // End Loop
            //Child Tables to main table
            var thirdBorder = "<tr><td colspan='2'>" + childTable + "</td></tr>";
            //

            //end preview html


            previewHTMLStr = "<table cellpadding='0' cellspacing='0' style='padding-left:0px; padding-top:10px; text-align:left;'>" + firstBorder + secondBorder + thirdBorder + "</table>";
            var titleName = "<div id='divTitle' style=\"background: #fffdfb; overflow: hidden; width: auto; margin: 0px; padding: 15px 0px 0px 0px;\">" +
                                "<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">Crime Report</div>";
            previewHTMLStr = titleName + previewHTMLStr + "</div>";

            //Preview HTMl
            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = previewHTMLStr;
            //Edit HTML
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;

            //Final XML String
            XMLString = "<Bulletins><CrimeDetails " + XMLString + " /> " + totalchildXMlString + " </Bulletins>";
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
                    url: "CMCrimeHighlights.aspx/ReplaceShortURltoHmlString",
                    dataType: "json",
                    processData: false,
                    success: function (data) {
                        bulletinHeader = data.d;

                        document.getElementById("<%=lblpreview.ClientID %>").innerHTML = "";
                        document.getElementById("<%=lblpreview.ClientID %>").innerHTML = bulletinHeader;
                        document.getElementById("<%=lblbulletinamme.ClientID %>").innerHTML = document.getElementById("<%=lblBulletinName.ClientID %>").innerHTML;

                        var modal = $find("BulletinPreview");
                        modal.show();

                        document.getElementById("divLoading").style.display = "none";

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
    
    </script>
    <div id="popup" class="popup" style="width: 100%; display: none;">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="wrapper">
                <div class="headernav">
                    <asp:Label ID="lblBulletinName" runat="server"></asp:Label>
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
                    <div style="width: 300px; margin: 0 auto;">
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                            ValidationGroup="ABC" HeaderText="The following error(s) occurred:" />
                        <asp:Label ID="lblmess" runat="server" Font-Size="Medium" ForeColor="Green"></asp:Label>
                    </div>
                </div>
                <div>
                    <div style="margin: 0 auto; overflow: hidden;">
                        <div style="margin: 0px auto; width: 0px; float: right; margin-right: 65px;">
                            <asp:Label ID="lblAdditionalLogo" Text="fdsf" runat="server"></asp:Label></div>
                        <asp:Label runat="server" ID="lblLogoHeader"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="contentwrap">
                <div class="largetxt">
                    Crime Report</div>
                <div class="form_wrapper" style="float: none; width: auto;">
                    <div class="clear10">
                    </div>
                    <div class="fields_wrap">
                        <label style="color: Red; font-size: 16px; margin-left: 200px;">
                            * Marked fields are mandatory.</label>
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
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 80px;">
                                <span style="color: Red;">*&nbsp;</span>From Date:
                            </div>
                            <div class='right_fields' style="width: 170px;">
                                <asp:TextBox ID="txtFromDate" runat="server" Width="150px" Height="19px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFromDate"
                                    ValidationGroup="ABC" ForeColor="Red" ErrorMessage="From Date is mandatory.">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFromDate"
                                    ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                    ValidationGroup="ABC" ErrorMessage="Invalid Date Format" Display="Dynamic">*</asp:RegularExpressionValidator><br />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                            </div>
                            <div class="left_lable" style="width: 80px; margin: 5px 0px 0px 5px; padding: 0px;">
                                <span style="color: Red;">*&nbsp;</span> To Date:
                            </div>
                            <div class='right_fields' style="width: 170px;">
                                <asp:TextBox ID="txtToDate" runat="server" Width="150px" Height="19px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate"
                                    ValidationGroup="ABC" ForeColor="Red" ErrorMessage="To Date is mandatory." Display="Dynamic">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtToDate"
                                    ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                    ValidationGroup="ABC" ErrorMessage="Invalid Date Format" Display="Dynamic">*</asp:RegularExpressionValidator><br />
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDate"
                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable">
                                <span style="color: Red; margin-left: 5px;">&nbsp;</span>Submitted by:
                            </div>
                            <div class='right_fields'>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 0px;">
                        </div>
                        <div class="fields_wrap" style="margin-top: 0px; padding-top: 0px;">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:DropDownList ID="ddlSubmitBy1" runat="server" Width="180px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlAssociates1" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 0px;">
                        </div>
                        <div class="fields_wrap" style="margin-top: 0px; padding-top: 0px;">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:DropDownList ID="ddlSubmitBy2" runat="server" Width="180px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlAssociates2" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 0px;">
                        </div>
                        <div class="fields_wrap" style="margin-top: 0px; padding-top: 0px;">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:DropDownList ID="ddlSubmitBy3" runat="server" Width="180px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlAssociates3" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 0px;">
                        </div>
                        <div class="fields_wrap" style="margin-top: 0px; padding-top: 0px;">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:DropDownList ID="ddlSubmitBy4" runat="server" Width="180px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlAssociates4" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 0px;">
                        </div>
                        <div class="fields_wrap" style="margin-top: 0px; padding-top: 0px;">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:DropDownList ID="ddlSubmitBy5" runat="server" Width="180px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlAssociates5" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 0px;">
                        </div>
                        <div class="fields_wrap" style="margin-top: 0px; padding-top: 0px;">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:DropDownList ID="ddlSubmitBy6" runat="server" Width="180px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlAssociates6" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 5px; padding-top: 5px; height: 0px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable">
                                <span style="color: Red; margin-left: 5px;">&nbsp;</span>Contact Person:
                            </div>
                            <div class='right_fields'>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 5px; padding-top: 1px; height: 0px;">
                        </div>
                        <div class="fields_wrap" style="margin-top: 2px; padding-top: 0px;">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:DropDownList ID="ddlContactTitle" runat="server" Width="180px">
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddlContactTitle"
                                        InitialValue="0" ErrorMessage="Please Select Title" ValidationGroup="ABC">*</asp:RequiredFieldValidator>--%>
                                &nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlContactName" runat="server" Width="200px">
                                </asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlContactName"
                                        InitialValue="0" ErrorMessage="Please Select Name" ValidationGroup="ABC">*</asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 5px; padding-top: 1px;">
                        </div>
                        <div class="fields_wrap" style="margin-top: 0px; padding-top: 0px;">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtEmailID" Width="180px" Height="19px"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtEmailID"
                                    WatermarkText="Email ID" WatermarkCssClass="lightText" />
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                    ControlToValidate="txtEmailID" ErrorMessage="Invalid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 5px; padding-top: 1px; margin-top: 5px; height: 0px;">
                        </div>
                        <div class="fields_wrap" style="margin-top: 5px; padding-top: 0px;">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox ID="txtPhone" runat="server" MaxLength="13" Width="180px" Height="19px"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtPhone"
                                    WatermarkText="Phone Number(xxx-xxx-xxxx)" WatermarkCssClass="lightText" />
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                    ControlToValidate="txtPhone" ErrorMessage="Invalid Phone Number" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                                    ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtTotalIncidents" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ControlToValidate="txtTotalIncidents" ErrorMessage="Please Enter Only Numbers"
                                    ValidationExpression="^\d+$" ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Total Incidents</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtOfficerInitiatedActivity" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                    ControlToValidate="txtOfficerInitiatedActivity" ErrorMessage="Please Enter Only Numbers"
                                    ValidationExpression="^\d+$" ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Officer Initiated Activity</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtCallsforService" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                                    ControlToValidate="txtCallsforService" ErrorMessage="Please Enter Only Numbers"
                                    ValidationExpression="^\d+$" ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Calls for Service</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtArrestsMisdemeanor" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                    ControlToValidate="txtArrestsMisdemeanor" ErrorMessage="Please Enter Only Numbers"
                                    ValidationExpression="^\d+$" ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Arrests - Misdemeanor</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtArrestsFelony" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"
                                    ControlToValidate="txtArrestsFelony" ErrorMessage="Please Enter Only Numbers"
                                    ValidationExpression="^\d+$" ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Arrests - Felony</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtCasesWritten" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                    ControlToValidate="txtCasesWritten" ErrorMessage="Please Enter Only Numbers"
                                    ValidationExpression="^\d+$" ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Cases Written</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtTrafficStops" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                    ControlToValidate="txtTrafficStops" ErrorMessage="Please Enter Only Numbers"
                                    ValidationExpression="^\d+$" ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Traffic Stops</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtCitations" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                    ControlToValidate="txtCitations" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"
                                    ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Citations</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtDUIArrests" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                    ControlToValidate="txtDUIArrests" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"
                                    ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    DUI Arrests</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtAccidents" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                    ControlToValidate="txtAccidents" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$"
                                    ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Accidents</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <asp:TextBox runat="server" ID="txtAccidentCriminal" Width="50px" MaxLength="4"></asp:TextBox>
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                    ControlToValidate="txtAccidentCriminal" ErrorMessage="Please Enter Only Numbers"
                                    ValidationExpression="^\d+$" ValidationGroup="ABC">*</asp:RegularExpressionValidator>
                                <label>
                                    Accident - Criminal</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width: 1px;">
                            </div>
                            <div class='right_fields' style="width: 600px; margin-top: 0px; padding-top: 0px;">
                                <label style="font-weight: bold; text-decoration: underline; font-size: 19px;">
                                    Crime Highlights</label>
                            </div>
                        </div>
                        <div class="clear10" style="margin-top: 1px; padding-top: 1px; height: 5px;">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable">
                                <div id='divMain' class="avatar" style="margin-left: 20px; border-width: 1px; min-height: 100px;
                                    width: 490px; max-height: 600px; overflow: auto;">
                                    <asp:Label ID="lblBulletinedit" runat="server" Text="<div id='watermark'>Your block goes here!!!</div>"></asp:Label>
                                    <%-- <table id='maintable' cellpadding="5" width="99%" cellspacing="0" style="border: 0px solid black;">
                                        </table>--%>
                                </div>
                            </div>
                        </div>
                        <div style="float: left; margin: 5px 0px 0px 340px;">
                            <img style="cursor: pointer;" onclick="AddIncidentPanel();" src="../../Images/add_inc.png" />
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="steps">
                        </div>
                        <div class="fields_wrap">
                            <div class="left_lable" style="width:165px;">
                                <span style="color: Red;">&nbsp;&nbsp;</span> Expiration Date & Time:
                            </div>
                            <div class="right_fields">
                                <div style="margin: 0px 0px 0px 0px;">
                                    <table cellpadding="0" cellspacing="0" id='tblExTime'>
                                        <colgroup>
                                            <col width="120px" />
                                            <col width="*" />
                                        </colgroup>
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
                        <div class="fields_wrap">
                            <div class="left_lable">
                                <label>
                                </label>
                            </div>
                            <div class="right_fields">
                                <div style="margin: 0px 0px 0px 0px;">
                                    <div id="public" style="margin: 10px 0px 0px 15px;">
                                        <asp:RadioButton ID="rbUnPublish" runat="server" GroupName="Public" Checked="true"
                                            onclick="javascript:ShowPublish('1','true')" />
                                        <label>
                                            Private</label>
                                        <asp:Label ID="lblCompleted" runat="server"></asp:Label>
                                        <asp:RadioButton ID="rbPublish" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2','true')" />
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
                                                    runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <br />
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
                                            <asp:HiddenField ID="hdnPublishDate" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="steps">
                    </div>
                    <%if (Session["VerticalDomain"] != null && Session["VerticalDomain"].ToString().ToLower().Contains("uspdhubcom"))
                      {
                    %>
                    <div class="fields_wrap " style="display: none;">
                        <div class="left_lable">
                            Category:
                        </div>
                        <div class="right_fields" style="margin: 10px 0px 0px 0px;">
                            <asp:DropDownList ID="ddlCategories" runat="server" Width="200px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%} %>
                    <div class="clear10">
                    </div>
                    <div class="fields_wrap ">
                        <div class="left_lable">
                        </div>
                        <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 500px;">
                            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" border="0" CssClass="btn"
                                OnClick="BtnCancel_Click" CausesValidation="false" />
                            <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="ABC" OnClientClick="return SaveHTMLData()"
                                border="0" CssClass="btn" OnClick="BtnSave_Click" />
                            <asp:Button ID="BtnPublish" runat="server" Text="Submit" ValidationGroup="ABC" OnClientClick="return SaveHTMLData()"
                                border="0" CssClass="btn" OnClick="BtnPublish_Click" Style="display: none;" />
                            <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return PreviewHTML('1');">
                                        <img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                            <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" ValidationGroup="ABC"
                                OnClientClick="return SaveHTMLData()" border="0" CssClass="btn" OnClick="btnDashboard_OnClick" />
                        </div>
                    </div>
                </div>
            </div>
            <input type="hidden" id='ids' value='' />
            <input type="hidden" value="2" id="DivIds" />
            <asp:HiddenField runat="server" ID="hdnEditHTML" />
            <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
            <asp:HiddenField runat="server" ID="hdnEditXML" />
            <asp:HiddenField runat="server" ID="hdnExDate" />
            <asp:HiddenField runat="server" ID="hdnPrivate" />
            <asp:HiddenField runat="server" ID="hdnCompleted" />
            <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
            <asp:HiddenField ID="hdnIncidentHTML" runat="server" />
            <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
            <input type="hidden" id="hdnalignindex" />
            <input type="hidden" id="editDivCheck" value="" />
            <input type="hidden" id="hdnChanges" value="false" />
            <input type="hidden" id="hdnImageURL" value="" />
            <asp:HiddenField runat="server" ID="hdnPublish" />
            <asp:HiddenField ID="hdnDescription" runat="server" Value="" />
            <div id='dummyDIV' style="display: none;">
                <asp:Label runat="server" ID='lbldummy'></asp:Label>
            </div>
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
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
