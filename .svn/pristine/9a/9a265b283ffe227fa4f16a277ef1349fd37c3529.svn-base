<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="PoliceActivityNew.aspx.cs" Inherits="USPDHUB.Business.MyAccount.PoliceActivityNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/flyers/jquery-ui-1.8.21.custom.js" type="text/javascript"></script>
    <link type="text/css" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.9/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" />
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.min.js"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var CID = 0;

        function AddIncidentPanel() {

            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"450px\" style=\"border: 0px solid gray; " +
                                                                        "min-height: 100px;\"> " +
                                                                    "</table>";

                document.getElementById("<%=lblBulletinedit.ClientID %>").innerHTML = maintableTag;
            }


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

            document.getElementById('DivIds').value = CID;
            var newRow = "<tr class=\"trheader\" id='trheader" + CID + "' >" +
                                "<td style=\"border-left: 2px dashed blue; border-right: 2px dashed blue; border-Top: 2px dashed blue; border-bottom:1px solid gray;\">" +
                                    "<span style='font-size:20px; margin-top:20px;'><b>&nbsp;&nbsp;Activity&nbsp;&nbsp;</b></span>" +
                                    "<img align='right' src=\"../../Images/del_act.jpg\" style='cursor: pointer; padding-right:5px;' onclick='RemoveIncidentPanel(edit" + CID + ")' />&nbsp;&nbsp;" +
                                    "<img align='right' src=\"../../Images/edit_act.jpg\" style='cursor: pointer; display:none; padding-right:5px;' id='imgeditIncident" + CID + "' onclick='EditIncidentPanel(trpreview" + CID + ")'  />&nbsp;&nbsp;" +
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
                                            "<tr>" +
                                                "<td >Date Occurred</td>" +
                                                "<td><input type='text' style='font-weight:bold;' id='txtStartDate" + CID + "' name='txtDate" + CID + "' /> &nbsp;&nbsp;</br>" +
                                                " <input type='text' style='font-weight:bold;' id='txtendDate" + CID + "' name='txtendDate" + CID + "' /></td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td><span style='font-weight:bold;'>Location</span></td>" +
                                                "<td> <input type='text' style='font-weight:bold;' id='txtLocation" + CID + "'/></td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td><span style='font-weight:bold;'>Description </span></td>" +
                                                "<td><textarea style='width: 345px; font-weight:bold;' id='txtDescription" + CID + "'></textarea></td>" +
                                            "</tr>" +
                                            "<tr>" +
                                                "<td><span style='font-weight:bold;'>Additional Details</span></td>" +
                                                "<td><textarea style='width: 345px;' id='txtAddDetails" + CID + "'></textarea></td>" +
                                            "</tr>" +
                                            "<tr>" +
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
                                                                "<td>&nbsp;" +
                                                                    "<div  id='divimage" + CID + "_1' style='min-height: 100px; float:left' class='textdivStyle'></div>&nbsp;&nbsp;" +
                                                                    "<div style='float:left; margin-left:6px;'><img src='../../Images/editimg.png'  style='cursor: pointer;' onclick='EditImage(divimage" + CID + "_1," + CID + ")'/> " +
                                                                        "<br/><img src='../../Images/deleteimg.png'  style='cursor: pointer;' onclick='DeleteImage(divimage" + CID + "_1 )' />" +
                                                                    "</div>" +
                                                                "</td>" +
                                                            "</tr>" +
                                                              "<tr id='imgCapRow" + CID + "_1'>" + // Image Caption
                                                                "<td style='padding-top:5px; padding-bottom:5px;'><span>Image Caption</span></td>" +
                                                                "<td style='padding-top:20px'> <input type=\"text\" id='imgCaption" + CID + "' />" +
                                                                "</td>" +
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
                $("#" + divtable.rows[0].id).before(newRow);
            }
            $("#date").date
            //Auto scroll when add new item
            var co = document.getElementById("edit" + CID);
            // co.focus();
            $("#" + "txtStartDate" + CID).datepicker();
            $("#" + "txtendDate" + CID).datepicker();

        }

        // Delete Call Header Row & Preview & Edit html
        function RemoveIncidentPanel(value) {
            var divID = value.id;
            var trID = divID.replace("edit", "tr");
            var trHeaderID = divID.replace("edit", "trheader");
            var trpreviewID = divID.replace("edit", "trpreview");

            if (confirm("Are you sure you want to delete this activity?")) {
                $("#" + trID).remove();
                $("#" + trHeaderID).remove();
                $("#" + trpreviewID).remove();
            }
            var divCount = $("#maintable tr").size();
            if (divCount <= 0) {
                document.getElementById('<%= lblBulletinedit.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
            }
        }



        function EditIncidentPanel(controlID, editImageControl) {
            var id = controlID.id.replace(/trpreview/gi, "");
            $("#trpreview" + id).css('display', 'none');
            $("#tr" + id).css('display', 'block');
            $("#imgeditcall" + id).css('display', 'none');
            $("#txtStartDate" + id).removeAttr("class");
            $("#txtendDate" + id).removeAttr("class");
            $("#txtStartDate" + id).datepicker();
            $("#txtendDate" + id).datepicker();

            $("#tr" + id).css('display', 'block');
            $("#imgeditIncident" + id).css('display', 'none');

            //document.getElementById("ddlcallhour" + id).value = document.getElementById("ddlcallhour" + id).value;
        }
        function DeleteImage(imgID) {
            var imgrowID = imgID.id.replace("divimage", "imgRow");
            var imgCapID = imgID.id.replace("divimage", "imgCapRow");

            var imagesectionID = imgID.id.replace("divimage", "imagesection");


            if (confirm("Are you sure you want to delete this image?")) {
                $("#" + imgrowID).remove();
                $("#" + imgCapID).remove();

                var ImgDivID = document.getElementById('DivIds').value;
                if (document.getElementById(imagesectionID) != null) {
                    document.getElementById(imagesectionID).style.display = 'block';
                }
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
                                          "<tr id='imgCapRow" + parentdivID + "_" + subDIVID + "' >" + // Image Caption
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
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });

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
            var fromDate = document.getElementById("<%=txtFromHours.ClientID %>").value.trim();
            var toDate = document.getElementById("<%=txtToDate.ClientID %>").value;
            if (fromDate != "") {
                //HTML
                ROWS = "<tr><td align='center' style='padding-top:5px; padding-left:5px;'>From Date:</td><td   style='padding-left:5px;'>" + fromDate + "</td></tr>";
                //XML
                XMLString = " FromDate= '" + fromDate + "'  ";
            }
            if (toDate != "") {
                //HTML
                ROWS = ROWS + "<tr><td  style='padding-top:5px; padding-left:5px;'>To Date:</td><td   style='padding-left:5px;'>" + toDate + "</td></tr>";
                //XML
                XMLString = XMLString + " ToDate= '" + toDate + "'  ";
            }



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

                    var Date = document.getElementById("txtStartDate" + i).value.trim();
                    var endDate = "";
                    if (document.getElementById("txtendDate" + i) != null) {
                        endDate = document.getElementById("txtendDate" + i).value.trim();
                    }
                    var Location = ReplaceSpecialCharacter(document.getElementById("txtLocation" + i).value.trim());
                    document.getElementById("txtLocation" + i).value = Location;

                    var Description = ReplaceSpecialCharacter(document.getElementById("txtDescription" + i).value.trim());
                    document.getElementById("txtDescription" + i).innerHTML = Description;

                    var AdditionalDetails = ReplaceSpecialCharacter(document.getElementById("txtAddDetails" + i).value.trim());
                    document.getElementById("txtAddDetails" + i).innerHTML = AdditionalDetails;

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
                    if (Location != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid;padding-top:5px;'>Location:</td><td style='page-break-inside: avoid;padding-top:5px;'><b>" + Location + "</b></td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Location='" + Location + "' ";
                    }
                    if (AdditionalDetails != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid;padding-top:5px;'>Additional Details:</td><td style='page-break-inside: avoid;padding-top:5px; font-weight:bold;'>" + AdditionalDetails.replace(/\n/gi, "<br/>") + "</td></tr>";
                        // XML
                        childXMLElements = childXMLElements + " Additional Details='" + AdditionalDetails + "' ";
                    }
                    if (Description != "") {
                        // HTML
                        childRow = childRow + "<tr><td valign='top' style='page-break-inside: avoid;padding-top:5px; padding-left: 0px;'>Description:</td><td style='page-break-inside: avoid;padding-top:5px; font-weight:bold;'> " + Description.replace(/\n/gi, "<br/>") + "</td></tr>";
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
                            var Caption = ReplaceSpecialCharacter(document.getElementById("imgCaption" + i).value.trim());

                            var imgURL = "";
                            if (document.getElementById("divimage" + k).getElementsByTagName("img").length > 0) {
                                var imgList = document.getElementById("divimage" + k).getElementsByTagName("img");
                                imgURL = imgList[0].src;
                            }

                            var Caption = ReplaceSpecialCharacter(document.getElementById("imgCaption" + i).value.trim());
                            imgControl = imgControl.replace("/>", " alt='" + Caption + "' title='" + Caption + "' >");
                            imgControl = imgControl.replace(">", " alt='" + Caption + "' title='" + Caption + "' >")

                            if (imgControl != "") {
                                // HTML
                                imgHTMLs = imgHTMLs + "<tr><td style='page-break-inside: avoid;'>&nbsp;</td><td style='page-break-inside: avoid; padding-top:5px;'>" + imgControl + "</td></tr>";
                                // XML
                                imgXML = imgXML + " imgURL='" + imgURL + "' ";
                            }
                            if (Caption != "") {
                                // HTML
                                imgHTMLs = imgHTMLs + "<tr><td style='page-break-inside: avoid;padding-top:5px; padding-bottom:5px; padding-left:5px;' colspan='2'>Image Caption:" + Caption + "</td></tr>";
                                // XML
                                imgXML = imgXML + " imgCaption='" + Caption + "' ";
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


                    childRow = "<table class='radius' id='tblpreview" + i + "' cellpadding='0' cellspacing='3' style='border:1px solid black; margin-top:5px;padding-left:5px;  width: 300px;'><colgroup><col width='100px'/><col width='*'/></colgroup>" + childRow + "</table>";
                    //$("#tdpreview" + i).append(childRow);
                    childTable = childTable + childRow;

                    //XML Sub Elements
                    childXMLElements = "<ChildDetails " + childXMLElements + "  >" + totalimgXML + " </ChildDetails>";
                    totalchildXMlString = totalchildXMlString + childXMLElements;

                });
            } // End Loop
            //Child Tables to main table
            var thirdBorder = "<tr><td colspan='2'>" + childTable + "</td></tr>";


            //end preview html

            previewHTMLStr = "<table cellpadding='0' cellspacing='0' style='padding-left:60px; padding-top:10px;padding-right:5px; text-align:left;'>" + thirdBorder + "</table>";
            var titleName = "<div id='divTitle' style=\"background: #fffdfb; overflow: hidden; width: auto; margin: 0px; padding: 15px 0px 40px 0px;\">" +
                                "<div style=\"font-size: 26px; line-height: 28px; font-weight: normal; color: #f15b29; text-align: center; padding: 0px 0px 10px 0px; border-bottom: 1px dashed #d1d1d1;\">Police Activity </div>";
            previewHTMLStr = titleName + previewHTMLStr + "</div>";


            //Preview HTMl
            document.getElementById("<%=hdnHtmlString.ClientID %>").value = previewHTMLStr;

            //Edit HTML
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;

            //Final XML String
            XMLString = "<Bulletins><CrimeDetails " + XMLString + " /> " + totalchildXMlString + " </Bulletins>";
            document.getElementById("<%=hdnEditXML.ClientID %>").value = XMLString;


            if (type == "1") {
                var bulletinHeader = document.getElementById("<%=hdnBulletinHeader.ClientID %>").value;
                bulletinHeader = bulletinHeader.replace("#BuildHtmlForForm#", previewHTMLStr);

                // Shorten URL Purpose

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

                        document.getElementById("<%=lblPreview.ClientID %>").innerHTML = "";
                        document.getElementById("<%=lblPreview.ClientID %>").innerHTML = previewHTMLStr;
                        document.getElementById("<%=lblbulletinamme.ClientID %>").innerHTML = document.getElementById("<%=lblBulletinName.ClientID %>").innerHTML;

                        var modal = $find("Preview");
                        modal.show();

                        //document.getElementById("divLoading").style.display = "none";

                    },
                    error: function (error) {
                        //alert("ERROR:: " + error.statusText);
                        document.getElementById("divLoading").style.display = "none";
                    }
                });


                return false;
            }
        }


        function ValidateCallDetails() {
            var reurnValue = true;
            if (Page_ClientValidate('ABC') && Page_IsValid) {
                var ExDate = document.getElementById("<%=txtExpires.ClientID %>").value;
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
                            document.getElementById("<%=txtExpires.ClientID %>").focus();
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
            if (ValidateCallDetails()) {
                var divtable = document.getElementById("maintable");
                var returnval = true;
                if (divtable != null) {
                    if (divtable != "") {
                        childTable = "";
                        $('#maintable tr.trheader').each(function () {
                            if (returnval == true) {
                                var i = $(this).attr('id').replace('trheader', '');
                                var startDate = document.getElementById("txtStartDate" + i).value.trim();
                                var endDate = "";
                                if (document.getElementById("txtendDate" + i) != null) {
                                    endDate = document.getElementById("txtendDate" + i).value.trim();
                                }
                                if (endDate != "" && startDate == "") {
                                    alert("Please enter the First Date Occurred.");
                                    document.getElementById("txtStartDate" + i).focus();
                                    returnval = false;
                                }
                                else if (startDate != "" && endDate != "") {
                                    var startDatespl = startDate.split("/");
                                    var endDatespl = endDate.split("/")
                                    var dateOne = new Date(startDatespl[2], startDatespl[0], startDatespl[1]); //Year, Month, Date
                                    var dateTwo = new Date(endDatespl[2], endDatespl[0], endDatespl[1]); //Year, Month, Date

                                    if (dateOne > dateTwo) {
                                        alert("Second Date Occurred should be later than or equal to First Date Occurred.");
                                        document.getElementById("txtStartDate" + i).focus();
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
                    //Remove preview divs getting only Edit html(input values)
                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                }




                var isCompleted = false;
                var isPrivate = false;

                isPrivate = document.getElementById('<%=rbPrivate.ClientID %>').checked;
                var exDate = document.getElementById("<%=txtExpires.ClientID %>").value;
                document.getElementById("<%=hdnExDate.ClientID %>").value = exDate;

                $find("<%=MPEProgress.ClientID %>").show();
                return true;
            }
            else {
                return false;
            }
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
                        $("#imgeditIncident" + j).css('display', 'block');
                    }
                })
            }
            document.getElementById('<%=btnSave.ClientID %>').style.display = "none";

            if (document.getElementById('<%=rbPrivate.ClientID %>').checked == true) {
                document.getElementById('<%=btnSave.ClientID %>').style.display = "block";

            }
            else {
                document.getElementById('<%=btnSave.ClientID %>').style.display = "none";

            }
            $("#dummyDIV").css('display', 'none');
        }

    </script>
    <script type="text/javascript">
        function ShowFromTimeDiv() {
            if (document.getElementById("<%=txtFromDate.ClientID %>").value == "") {
                document.getElementById("<%=txtFromHours.ClientID %>").disabled = true;
                document.getElementById("<%=txtFromMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlFromSS.ClientID %>").disabled = true;
            }
            else {
                document.getElementById("<%=txtFromHours.ClientID %>").disabled = false;
                document.getElementById("<%=txtFromMinutes.ClientID %>").disabled = false;
                document.getElementById("<%=ddlFromSS.ClientID %>").disabled = false;
            }
        }
        function ShowToTimeDiv() {
            if (document.getElementById("<%=txtToDate.ClientID %>").value == "") {
                document.getElementById("<%=txtToHours.ClientID %>").disabled = true;
                document.getElementById("<%=txtToMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlToSS.ClientID %>").disabled = true;
            }
            else {
                document.getElementById("<%=txtToHours.ClientID %>").disabled = false;
                document.getElementById("<%=txtToMinutes.ClientID %>").disabled = false;
                document.getElementById("<%=ddlToSS.ClientID %>").disabled = false;
            }
        }
        function ShowExTimeDiv() {
            if (document.getElementById("<%=txtExpires.ClientID %>").value == "") {
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
        function ShowPublish(val) {
            if (val == "1") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";
                document.getElementById('divpublish').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
            } else if (val == "2") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
                    GetCurrentDate();
            }
        }
        function EditImage(imgdivID, parentID) {

            imgdivID = imgdivID.id;
            document.getElementById('DivIds').value = parentID;

            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "BulletinsForm_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 22) + "&imgSrc=" + imgSrc);
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
        function BindImages(typeValue) {
            if (document.getElementById('divDefaultPerson').innerHTML.indexOf('img') != -1 || document.getElementById('divDefaultPerson').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnDefaultPerson.ClientID %>").value = $('#divDefaultPerson img').attr('src');
            }
            if (document.getElementById('divDefaultPerson').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnLink.ClientID %>").value = $('#divDefaultPerson a').attr('href');
            }
            ValidatePublishDate();
            //ExDate checking
            if (document.getElementById("<%=txtExpires.ClientID %>").value != "" && typeValue == 1) {
                var currentdate = new Date();
                var fromDate = document.getElementById("<%=txtExpires.ClientID %>").value;
                var selDate = new Date(fromDate);
                var selHours = 0;
                var selmins = 0;
                if (document.getElementById("<%=txtExHours.ClientID %>").value != '' && document.getElementById("<%=txtExHours.ClientID %>").value != 'Hour') {
                    selHours = parseInt(document.getElementById("<%=txtExHours.ClientID %>").value);
                    if (selHours > 12) {
                        alert("Invalid Date Format.");
                        return;
                    }
                    if (document.getElementById("<%=ddlExSS.ClientID %>").value == 'AM' && selHours == 12)
                        selHours = 0;
                    if (document.getElementById("<%=ddlExSS.ClientID %>").value == 'PM' && selHours < 12)
                        selHours += 12;
                }
                if (document.getElementById("<%=txtExMinutes.ClientID %>").value != '' && document.getElementById("<%=txtExMinutes.ClientID %>").value != 'Minutes')
                    selmins = parseInt(document.getElementById("<%=txtExMinutes.ClientID %>").value);

                if (selmins >= 60) {
                    alert("Invalid Date Format.");
                    return;
                }
                selDate.setHours(selHours, selmins, 0);
                if (selDate <= currentdate) {
                    alert('Expiration date should be later than current date.');
                    return false
                }
            }
            //end exdate checking

            if (typeValue == "1") {
                if (Page_ClientValidate('SV') == true && Page_IsValid == true)
                    $find("<%=MPEProgress.ClientID %>").show();
            }

        }
        function DisplayImage() {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null) {  //roles & permissions..
                DisplayComplete();

                var imgHyperLink = document.getElementById("<%=hdnLink.ClientID %>").value;
                var ImgURL = document.getElementById("<%=hdnDefaultPerson.ClientID %>").value;

                if (ImgURL != "") {
                    document.getElementById("imgDelete1").style.display = "block";
                }
                if (imgHyperLink == "") {
                    if (ImgURL != "")
                        document.getElementById('divDefaultPerson').innerHTML = "<img src='" + ImgURL + "' />";
                }
                else {
                    document.getElementById('divDefaultPerson').innerHTML = "<a href='" + imgHyperLink + "' target='_blank'><img style='vertical-align:bottom;' src='" + ImgURL + "' border='0' /></a>";
                }
            }
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

        function FirstImageDelete() {
            if (confirm("Are you sure you want to delete this image?")) {
                document.getElementById('divDefaultPerson').innerHTML = "";
                document.getElementById("imgDelete1").style.display = "none";
                document.getElementById("<%=hdnDefaultPerson.ClientID %>").value = "";
            }
            return false;
        }
    </script>
    <style type="text/css">
        .ui-datepicker-header
        {
            background: #A4A4A4;
        }
        .date
        {
            text-align: justify;
        }
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
            width: 300px;
        }
        .imgdivStyle
        {
            text-align: justify;
            border: 1px solid black;
            overflow: auto;
            font-family: Arial;
            font-size: 12px;
        }
        
        .tr
        {
            font-family: Arial;
        }
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
            background: #eeeeee url(../../images/BulletinThumbs/header_bg.gif) repeat-x;
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
            color: #9a9a9a;
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div id="wrapper">
                    <div class="headernav">
                        <asp:Label ID="lblBulletinName" runat="server"></asp:Label><asp:TextBox ID="txt"
                            runat="server" Width="0" BorderStyle="none" BorderColor="white" Style="border: 0;
                            border-color: White!important;"></asp:TextBox>
                    </div>
                    <div style="text-align: center;">
                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                    size="2">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div style="width: 300px; margin: 0 auto;">
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
                            Police Activity</div>
                        <div class="browseimg_wrap">
                            <%--      <div class="avatar" style="text-align: center;">
                                <%--<div id='divDefaultPerson' style="width: 310px; min-height: 140px; display: block;">
                                </div>
                               
                            </div>
                            <%-- <label>
                                <img style="cursor: pointer;" onclick="EditImage('divDefaultPerson');" src="../../Images/Dashboard/Browseimg.png" />
                            </label>
                            <%-- <div style="float: right; margin-left: 0px;">
                                <a id="ViewMessagesTips" href="javascript:ModalHelpPopup('Add Image to Content',20,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                            </div>--%>
                            <div id="imgDelete1" style="margin-top: 5px; display: none;">
                                <asp:Button ID="btnImgDelete1" runat="server" CausesValidation="false" border="0"
                                    CssClass="btn" Text="Delete Image" OnClientClick="return FirstImageDelete();"
                                    Width="151px" />
                            </div>
                        </div>
                        <div class="form_wrapper">
                            <div class="fields_wrap">
                                <label style="color: Red; font-size: 16px; margin-left: 100px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Date:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtBulletinDate" runat="server" CssClass="txtfild1" Width="150px"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" TargetControlID="txtBulletinDate"
                                        WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                        ControlToValidate="txtBulletinDate" ValidationGroup="SV" ErrorMessage="Date is mandatory.">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic"
                                        ControlToValidate="txtBulletinDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                        ValidationGroup="SV" ErrorMessage="Invalid Date Format of Date.">*</asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBulletinDate"
                                        Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        Date and Time of
                                        <br />
                                        &nbsp;&nbsp; Activity:</label></div>
                                <div class="right_fields">
                                    <table width="100%">
                                        <tr>
                                            <td valign="bottom">
                                                <label>
                                                    From : &nbsp;</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDate" runat="server" onchange="ShowFromTimeDiv();" CssClass="txtfild1"
                                                    Width="95px"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" TargetControlID="txtFromDate"
                                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtFromDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format.">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate"
                                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                            </td>
                                            <td style="height: 30px;">
                                                <%--<asp:DropDownList ID="ddlFrom" runat="server" Width="100px">
                                                </asp:DropDownList>--%>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtFromHours" Enabled="False" Width="35px" MaxLength="2"></asp:TextBox>
                                                            <span style="font-weight: bold;">Hour</span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtFromMinutes" Enabled="False" Width="35px" MaxLength="2"></asp:TextBox>
                                                            <span style="font-weight: bold;">Minutes</span>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="ddlFromSS" Width="55px" Enabled="False">
                                                                <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    To : &nbsp;</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtToDate" runat="server" onchange="ShowToTimeDiv();" CssClass="txtfild1"
                                                    Width="95px"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" TargetControlID="txtToDate"
                                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtToDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format.">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate"
                                                    Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                            </td>
                                            <td style="height: 30px;">
                                                <%--<asp:DropDownList ID="ddlTo" runat="server" Width="100px">
                                                </asp:DropDownList>--%>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtToHours" Enabled="False" Width="35px" MaxLength="2"></asp:TextBox>
                                                            <span style="font-weight: bold;">Hour</span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtToMinutes" Enabled="False" Width="35px" MaxLength="2"></asp:TextBox>
                                                            <span style="font-weight: bold;">Minutes</span>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="ddlToSS" Width="55px" Enabled="False">
                                                                <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <div id="divpreview" class="avatar" style="margin-left: 20px; border-width: 1px;
                                        min-height: 100px; width: 470px; max-height: 600px; overflow: auto;">
                                        <asp:Label ID="lblBulletinedit" runat="server" Text="<div id='watermark'>Your block goes here!!!</div>"></asp:Label>
                                        <span id="dispalyOnSave"></span>
                                        <%--  <table id='maintable' cellpadding="5" width="99%" cellspacing="0" style="border: 0px solid black;">
                                        </table>--%>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; margin: 5px 0px 0px 320px;">
                                <img style="cursor: pointer;" onclick="AddIncidentPanel();" src="../../Images/add_act.jpg" />
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span>
                                    <label>
                                        Expiration Date & Time:</label></div>
                                <div class="right_fields" style="width: 470px;">
                                    <table width="60%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtExpires" runat="server" CssClass="txtfild1" Width="90px" onChange="ShowExTimeDiv();"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtExpires"
                                                    WatermarkText="MM/DD/YYYY" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExpires" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="SV" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExpires" Format="MM/dd/yyyy"
                                                    CssClass="MyCalendar" />
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtExHours" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14" TargetControlID="txtExHours"
                                                    WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExHours" ValidationExpression="^(1[0-2]|0?[1-9])" ValidationGroup="SV"
                                                    ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                                &nbsp;
                                                <asp:TextBox runat="server" ID="txtExMinutes" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender15" TargetControlID="txtExMinutes"
                                                    WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                </cc1:TextBoxWatermarkExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtExMinutes" ValidationExpression="^[0-5]\d" ValidationGroup="SV"
                                                    ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlExSS" Enabled="False" Width="60px">
                                                    <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <label runat="server" id="divCall">
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
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 10px 0px 0px 0px;">
                                        <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                            onclick="javascript:ShowPublish('1')" />
                                        <label>
                                            Private</label>
                                        <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2')" />
                                        <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                        <div style="margin: 10px 0px 0px 10px; display: none;" id="divpublish">
                                            <div id="divSchedulePublish" style="display: block;">
                                                <font color="red">*</font>
                                                <label style="font-size: 14px;">
                                                    Publish Date:</label>
                                                <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                    ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="SV"
                                                SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
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
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Category:</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCategories" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 450px;">
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" border="0" OnClick="btnSave_Click"
                                        ValidationGroup="SV" OnClientClick="return SaveHTMLData();" />
                                    <asp:LinkButton ID="lnkPreview" OnClientClick="return PreviewHTML('1');" runat="server"><img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                    <input type="hidden" id="editDivCheck" value="" />
                                    <input type="hidden" id='hdnFormImgPath' />
                                    <input type="hidden" value="2" id="DivIds" />
                                    <input type="hidden" id="hdnalignindex" />
                                    <asp:HiddenField runat="server" ID="hdnExDate" />
                                    <asp:HiddenField runat="server" ID="hdnEditHTML" />
                                    <asp:HiddenField runat="server" ID="hdnDisplayOnSave" />
                                    <asp:HiddenField ID="hdnHtmlString" runat="server" />
                                    <asp:HiddenField runat="server" ID="hdnEditXML" />
                                    <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
                                    <asp:HiddenField ID="hdnArchive" runat="server" />
                                    <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                    <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                    <asp:HiddenField ID="hdnDefaultPerson" runat="server" />
                                    <asp:HiddenField ID="hdnLink" runat="server" />
                                    <div id='dummyDIV' style="display: none;">
                                        <asp:Label runat="server" ID='lbldummy'></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblMfdDate" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modal"
                            PopupControlID="pnlMfdDate" TargetControlID="lblMfdDate" CancelControlID="imglogin11"
                            BehaviorID="Preview">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlMfdDate" runat="server" Style="display: block" Width="100%">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="580px" align="center"
                                border="0">
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress10" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="imglogin11" runat="server" ImageUrl="~/images/popup_close.gif"
                                            CausesValidation="false"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                        padding-top: 10px" align="left" colspan="2">
                                        <asp:Label ID="lblbulletinamme" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding: 10px;">
                                        <div style="height: 500px; overflow-y: auto; border: solid 1px #4684C5;">
                                            <asp:Label ID="lblPreview" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <%--IMAGE GALLERY * RESIZE IMAGE  --%>
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
                    </td>
                </tr>
            </table>
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkPreview" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
