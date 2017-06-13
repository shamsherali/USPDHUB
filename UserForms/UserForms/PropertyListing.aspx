<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="PropertyListing.aspx.cs" Inherits="UserForms.PropertyListing" ValidateRequest="false"
    EnableEventValidation="false" %>

<%@ Register Src="~/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <script src="Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.sortable.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.droppable.js" type="text/javascript"></script>
    <script src="Scripts/flyers/jquery.ui.draggable.js" type="text/javascript"></script>
    <link href="css/Bulletins.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .textdivStyle
        {
            text-align: left;
            border: 1px solid #FCB549;
            overflow: auto;
            font-family: Arial;
            font-size: 16px;
            width: 300px;
        }
        .weblink
        {
            width: 100px;
            display: block;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            LoadBlocks();
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
        function AddBlocks(blockname) {
            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"490px\" style=\"border: 0px solid gray; min-height: 100px;\"></table>";
                document.getElementById("<%=lblEditText.ClientID %>").innerHTML = maintableTag;
            }

            var divtable = document.getElementById('maintable');
            var lastrow = 1;
            if ($('#maintable tr').length > 0) {
                $('#maintable .DivImages').each(function () {
                    lastrow = $(this).attr("id").replace('edit', '').replace('tr', '');
                });
            }
            var CID = 1;
            for (i = CID; i <= CID; i++) {
                if (!document.getElementById("trheader" + i)) {
                    break;
                }
                else {
                    CID++;
                }
            }
            var appendRow = "";
            if (blockname == "DIV_IMAGE") {

                appendRow = "<tr id='tr" + CID + "' >" +
                               "<td class='drop ui-sortable'>" +
                                "<div id='trheader" + CID + "' >" +
                                    "<div id=\"edit" + CID + "\" style='float: left; margin-top: 10px;' class='DivImages'> " +
                                           "<div id='ImageSubEdit" + CID + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >" +
                                           "</div>" +
                                            "<div id='ImageEditSection" + CID + "' class='editsectionclass' style='float:left;' >" +
                                            "&nbsp;<img src='../../Images/EditImage.png'  style='cursor: pointer;' onclick='EditImage(ImageSubEdit" + CID + ")' />" +
                                            "<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(trheader" + CID + "," + CID + ")' />" +
                                            "</div>" +
                                            "<div id='ImageCaptionEdit" + CID + "' style='float: left; margin-top: 10px;' >" +
                                            "<span style='font-weight:bold;float:left;'>Image Caption</span>" +
                                            "&nbsp;&nbsp;<input type='text' style='font-weight:bold;' id='txtCaption" + CID + "' name='txtCaption" + CID + "' />" +
                                            "</div>" +

                                     "</div>" + //EDIT DIV

                                  "</div>" + //HEADER DIV
                                "</td>" +
                            "</tr>";

            } // DIV Image END

            if (divtable.rows.length == 0) {
                $("#maintable").append(appendRow);
            }
            else {
                $("#tr" + lastrow).after(appendRow);
            }
            var scrollId = $("#tr" + CID);
            var avatarHeight = $(".avatar").height();
            $('html,body').animate({ scrollTop: scrollId.offset().top }, 1000);

            LoadBlocks();
            if (blockname == "DIV_IMAGE") {
                EditImage(document.getElementById("ImageSubEdit" + CID));
            }
        }
        function LoadBlocks() {
            var fixHelperModified = function (e, tr) {
                tr.children().each(function () {
                    $(this).width($(this).width());
                });
                return tr;
            },
            updateIndex = function (e, ui) {
            };
            $("#maintable tbody").sortable({
                connectWith: ".drop",
                helper: fixHelperModified,
                stop: updateIndex
            }).disableSelection();
        }

        //Show the Image Gallery
        function EditImage(value) {
            var imgdivID = value.id;
            imgSrc = document.getElementById(imgdivID).innerHTML;
            ShowImageModal(imgSrc, imgdivID);
        }
        //Show the Image Gallery
        function EditDefaultImage(imgdivID) {
            imgSrc = document.getElementById(imgdivID).innerHTML.trim();
            ShowImageModal(imgSrc, imgdivID);
        }
        function ShowImageModal(imgSrc, imgdivID) {
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 32) + "&imgSrc=" + imgSrc + "&folder=Templates");
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
                if ($('#tr"++" t').length == 0) {
                    $("#tr" + CID).remove();
                }
            }
        }
        function BindImages() {
            if (document.getElementById('divDefaultProperty').innerHTML.indexOf('img') != -1 || document.getElementById('divDefaultProperty').innerHTML.indexOf('IMG') != -1) {
                document.getElementById("<%=hdnDefaultProperty.ClientID %>").value = $('#divDefaultProperty img').attr('src');
            }
            if (document.getElementById('divDefaultProperty').innerHTML.indexOf('href=') != -1) {
                document.getElementById("<%=hdnDPLink.ClientID %>").value = $('#divDefaultProperty a').attr('href');
            }
        }
        function DisplayImage() {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
            {
                if (document.getElementById("<%=hdnDefaultProperty.ClientID %>").value != "") {
                    document.getElementById("imgDelete1").style.display = "block";
                    if (document.getElementById("<%=hdnDPLink.ClientID %>").value == "")
                        document.getElementById('divDefaultProperty').innerHTML = "<img src='" + document.getElementById("<%=hdnDefaultProperty.ClientID %>").value + "' />";
                    else
                        document.getElementById('divDefaultProperty').innerHTML = "<a href='" + document.getElementById("<%=hdnDPLink.ClientID %>").value + "' target='_blank'><img src='" + document.getElementById("<%=hdnDefaultProperty.ClientID %>").value + "' /></a>";
                }
            }
        }
        function ShowWatermark(value) {
            if (value.checked) {
                document.getElementById("imgwatermark").style.display = "block";
            }
            else {
                document.getElementById("imgwatermark").style.display = "none";
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
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
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
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                document.getElementById('divpublish').style.display = "block";
                ShowPublish('2');
            }
            ShowExTimeDiv();
        }

        function PreviewHTML(type) {

            //Type 1:: Preview 
            // Type 2:: Save

            //Web Link Validation
            var webLink = document.getElementById('<%=txtWeb.ClientID %>').value;
            if (webLink != "") {
                var tomatch = /((ftp|http|https):\/\/)?([A-Za-z0-9\.-]{3,}\.[A-Za-z]{2,})/
                if (!tomatch.test(webLink)) {
                    alert("Invalid Web Link.");
                    return false;
                }
            }
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
                divtable = document.getElementById("maintable");
            }
            var ROWS = "";
            var printROWS = "";
            var newROWS = "";
            var newprintROWS = "";
            var previewHTMLStr = "";
            var printHTMLStr = "";
            var XMLString = "";
            BindImages();
            //Address
            var Address = document.getElementById("<%=txtAddress.ClientID %>").value;
            var defaultProperty = document.getElementById("<%=hdnDefaultProperty.ClientID %>").value;
            var dpLink = document.getElementById("<%=hdnDPLink.ClientID %>").value;
            //XML
            XMLString = XMLString + " Address='" + Address + "'";
            XMLString = XMLString + " DefaultImg='" + defaultProperty + "'";
            XMLString = XMLString + " DefaultImgLink='" + dpLink + "'";
            if (Address != "") {
                //HTML
                ROWS = ROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:110px; vertical-align:top;'> Address: </td><td style='padding-top:5px;'>" + Address + "</td></tr>";

                //Print HTML
                printROWS = printROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:120px; vertical-align:top;'> Address: </td><td style='padding-top:5px;'>" + Address + "</td></tr>";
            }
            // *** If uploaded the image *** //
            if (defaultProperty != "") {
                ROWS = ROWS + "<tr><td colspan='2' align='center' style='page-break-inside: avoid; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%;'>";
                if (dpLink == "") {
                    ROWS = ROWS + "<img src=\"" + defaultProperty + "\"/>";
                    // PDF Print HTML
                    printROWS = printROWS + "<tr><td colspan='2'><div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><img src=\"" + defaultProperty + "\"/></div><br/></td></tr> ";
                }
                else {
                    ROWS = ROWS + "<a href='" + dpLink + "' target='_blank'><img src='" + defaultProperty + "'/></a>";
                    // PDF Print HTML
                    printROWS = printROWS + "<div style=\"page-break-inside: avoid; float: left; text-align:center; margin: 20px auto; border: 1px solid #dddddd;padding: 0px; width:100%; \"><a href='" + dpLink + "' target='_blank'><img src='" + defaultProperty + "'/></a></div>";
                }
                ROWS = ROWS + "</td></tr>";
            }
            var thirdBorder = "";
            var sencodBoder = "";
            var fourthBoder = "";
            var printfourthBoder = "";
            var firstBorder = "";
            var printfirstBorder = "";
            var printsecondBorder = "";
            var printthirdBorder = "";
            if (ROWS != "")
                firstBorder = "<tr><td colspan='2'><table cellpadding='0' cellspacing='0' style='width:300px;'>" + ROWS + "</table></td></tr>";
            //Print HTML
            if (printROWS != "")
                printfirstBorder = "<tr><td colspan='2' style='page-break-inside: avoid;'><table cellpadding='0' cellspacing='0' style='width:100%'>" + printROWS + "</table></td></tr>";
            //Additional Details 1
            var Details1 = document.getElementById("<%=txtAddDetails1.ClientID %>").value;

            //XML
            XMLString = XMLString + " Details1='" + Details1.replace(/'/gi, "&apos;").replace(/&/gi, "&amp;") + "'";

            if (Details1 != "") {
                //HTML
                newROWS = newROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px;  vertical-align:top;'> Additional Details: </td></tr>";
                newROWS = newROWS + "<tr><td colspan='2' style='page-break-inside: avoid; text-align:justify; padding:5px; vertical-align:top;'> " + Details1 + "</td></tr>";

                //Print HTML
                newprintROWS = newprintROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px;  vertical-align:top;'> Additional Details: </td></tr>";
                newprintROWS = newprintROWS + "<tr><td colspan='2' style='page-break-inside: avoid; text-align:justify; padding:5px; vertical-align:top;'> " + Details1 + "</td></tr>";
            }

            //Price
            var Price = document.getElementById("<%=txtPrice.ClientID %>").value;

            //XML
            XMLString = XMLString + " Price='" + Price + "'";

            if (Price != "") {
                //HTML
                newROWS = newROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:110px; vertical-align:top;'> Price: </td><td style='padding-top:5px;'>$ " + Price + "</td></tr>";

                //Print HTML
                newprintROWS = newprintROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:120px; vertical-align:top;'> Price: </td><td style='padding-top:5px;'>$ " + Price + "</td></tr>";
            }

            //Square Feet
            var SquareFeet = document.getElementById("<%=txtFeet.ClientID %>").value;

            //XML
            XMLString = XMLString + " SquareFeet='" + SquareFeet + "'";

            if (SquareFeet != "") {
                //HTML
                newROWS = newROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:110px; vertical-align:top;'> Square Feet: </td><td style='padding-top:5px;'>" + SquareFeet + "</td></tr>";

                //Print HTML
                newprintROWS = newprintROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:120px; vertical-align:top;'> Square Feet: </td><td style='padding-top:5px;'>" + SquareFeet + "</td></tr>";
            }

            //Bedrooms
            var Bedrooms = document.getElementById("<%=txtBedrooms.ClientID %>").value;

            //XML
            XMLString = XMLString + " Bedrooms='" + Bedrooms + "'";

            if (Bedrooms != "") {
                //HTML
                newROWS = newROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:110px; vertical-align:top;'> Bedrooms: </td><td style='padding-top:5px;'>" + Bedrooms + "</td></tr>";

                //Print HTML
                newprintROWS = newprintROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:120px; vertical-align:top;'> Bedrooms: </td><td style='padding-top:5px;'>" + Bedrooms + "</td></tr>";
            }

            //Bathrooms
            var Bathrooms = document.getElementById("<%=txtBathrooms.ClientID %>").value;

            //XML
            XMLString = XMLString + " Bathrooms='" + Bathrooms + "'";

            if (Bathrooms != "") {
                //HTML
                newROWS = newROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:110px; vertical-align:top;'> Bathrooms: </td><td style='padding-top:5px;'>" + Bathrooms + "</td></tr>";

                //Print HTML
                newprintROWS = newprintROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:120px; vertical-align:top;'> Bathrooms: </td><td style='padding-top:5px;'>" + Bathrooms + "</td></tr>";
            }

            //Status
            var Status = document.getElementById("<%=txtStatus.ClientID %>").value;

            //XML
            XMLString = XMLString + " Status='" + Status + "'";

            if (Status != "") {
                //HTML
                newROWS = newROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:110px; vertical-align:top;'> Status: </td><td style='padding-top:5px;'>" + Status + "</td></tr>";

                //Print HTML
                newprintROWS = newprintROWS + "<tr><td style='page-break-inside: avoid; padding:5px; width:120px; vertical-align:top;'> Status: </td><td style='padding-top:5px;'>" + Status + "</td></tr>";
            }

            //Additional Details 2
            var Details2 = document.getElementById("<%=txtAddDetails2.ClientID %>").value;

            //XML
            XMLString = XMLString + " Details2='" + Details2.replace(/'/gi, "&apos;").replace(/&/gi, "&amp;") + "'";

            if (Details2 != "") {
                //HTML
                newROWS = newROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px;  vertical-align:top;'> Additional Details: </td></tr>";
                newROWS = newROWS + "<tr><td colspan='2' style='page-break-inside: avoid; text-align:justify; padding:5px; vertical-align:top;'> " + Details2 + "</td></tr>";

                //Print HTML
                newprintROWS = newprintROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px; vertical-align:top;'> Additional Details: </td></tr>";
                newprintROWS = newprintROWS + "<tr><td colspan='2' style='page-break-inside: avoid; text-align:justify; padding:5px; vertical-align:top;'> " + Details2 + "</td></tr>";
            }

            //Web Link
            var WebLink = document.getElementById("<%=txtWeb.ClientID %>").value;

            //XML
            XMLString = XMLString + " WebLink='" + WebLink + "'";

            if (WebLink != "") {

                //HTML
                if (WebLink.toString().indexOf("http") != -1) {
                    newROWS = newROWS + "<tr><td align='center' colspan='2' style='page-break-inside: avoid; padding-top:5px; padding-bottom:5px; vertical-align:top;'> <a href='" + WebLink + "' class='weblink' target='_blank'><img src='<%=RootPath %>/Images/AddInfo.png' /></a> </td></tr>";
                    //Print HTML
                    newprintROWS = newprintROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px;  vertical-align:top;'> <a href='" + WebLink + "' class='weblink' target='_blank'><img src='<%=RootPath %>/Images/AddInfo.png' /></a> </td></tr>";
                }
                else {
                    newROWS = newROWS + "<tr><td  align='center' colspan='2' style='page-break-inside: avoid; padding:5px;  vertical-align:top;'> <a href='http://" + WebLink + "' class='weblink' target='_blank'><img src='<%=RootPath %>/Images/AddInfo.png' /></a> </td></tr>";
                    //Print HTML
                    newprintROWS = newprintROWS + "<tr><td colspan='2' style='page-break-inside: avoid; padding:5px;  vertical-align:top;'> <a href='http://" + WebLink + "' class='weblink' target='_blank'><img src='<%=RootPath %>/Images/AddInfo.png' /></a> </td></tr>";
                }

            }

            if (document.getElementById("maintable") != null)
                var elems = document.getElementById("maintable").getElementsByTagName("div");

            var i = 0;
            totalchildXMlString = "";
            var childTable = "";

            var totalPrintHTML = "";
            if ($('#maintable tr').length > 0) {
                $('#maintable .DivImages').each(function () {

                    i = $(this).attr('id').replace('edit', '');
                    if ($(this).attr("class") == 'DivImages') // *** Start of Images
                    {
                        var imgControl = "";
                        if (document.getElementById("ImageSubEdit" + i) != null)
                            imgControl = document.getElementById("ImageSubEdit" + i).innerHTML;

                        // Image HTML
                        var childRow = "<tr><td colspan='2' style='padding-top:2px;'>" + imgControl + "</td></tr>";
                        //Print HTML
                        var printHTML = "<tr><td colspan='2' style='padding-top:2px; page-break-inside: avoid;'>" + imgControl + "</td></tr>";

                        var childXMLElements = "";

                        //Image Caption
                        var Caption = ReplaceSpecialCharacter(document.getElementById("txtCaption" + i).value.trim());


                        if (Caption != "") {

                            // HTML
                            childRow = childRow + "<tr><td valign='top' style='width:110px; page-break-inside: avoid; padding:5px;'>Image Caption:</td><td style='padding-top:5px;'><b>" + Caption + "</b></td></tr>";
                            //Print HTML
                            printHTML = printHTML + "<tr><td valign='top' style='width:110px; page-break-inside: avoid; padding:5px;'>Image Caption:</td><td style='padding-top:5px;'><b>" + Caption + "</b></td></tr>";
                            // XML
                            childXMLElements = childXMLElements + " Caption='" + Caption + "' ";

                        }

                        //XML Sub Elements
                        totalchildXMlString = totalchildXMlString + childXMLElements;

                        childRow = "<table class='radius' id='tblpreviewimages' cellpadding='0' cellspacing='0' style='margin-top:5px; width: 300px;'>" + childRow + "</table>"
                        //Print HTML
                        printHTML = "<table class='radius' id='tblprintimages' cellpadding='0' cellspacing='0' style='margin-top:5px;' width='100%'>" + printHTML + "</table>"
                        childTable = childTable + childRow;
                        //Print HTML
                        totalPrintHTML = totalPrintHTML + printHTML;

                    } // *** End of Images

                });   // *** End of foreach for each class of blocks

                sencodBoder = "<tr><td colspan='2'><table cellpadding='0' cellspacing='0' style='width: 300px;'>" + childTable + "</table></td></tr>";
                printsecondBorder = "<tr><td colspan='2' style='page-break-inside: avoid;'><table cellpadding='0' cellspacing='0' width='100%'>" + totalPrintHTML + "</table></td></tr>";
            }

            if (newROWS != "")
                thirdBorder = "<tr><td colspan='2'><table cellpadding='0' cellspacing='0' style='width:300px;'>" + newROWS + "</table></td></tr>";

            var contentPhone = document.getElementById("<%=txtContentPhone.ClientID %>").value;
            XMLString = XMLString + " ContentCall='" + contentPhone + "'";
            if (contentPhone != "") {
                //HTML
                fourthBoder = "<tr><td style='page-break-inside: avoid; color: #353535; padding:2px 0px 5px 5px;' colspan='2'><a href='tel:" + contentPhone + "' style='text-decoration:none;'><img style=\"vertical-align:middle\" src='<%=RootPath %>/Images/content_call.png'/> " + contentPhone + "</a></td></tr></tr>"

                //Print HTML<div style=\"page-break-inside: avoid; float: left; width: 600px;\"><a href='tel:" + txtContentPhone.Text.Trim() + "'><img src='" + RootPath + "/Images/content_call.png'/> " + txtContentPhone.Text.Trim() + "</a></div>
                printfourthBoder = "<tr><td colspan='2' style='page-break-inside: avoid; text-align:justify; padding:5px; vertical-align:top;'><a href='tel:" + contentPhone + "' style='text-decoration:none;'><img style=\"vertical-align:middle\" src='<%=RootPath %>/Images/content_call.png'/> " + contentPhone + "</a></td></tr>";
            }
            //Print HTML
            if (newprintROWS != "")
                printthirdBorder = "<tr><td colspan='2' style='page-break-inside: avoid;'><table cellpadding='0' cellspacing='0' style='width:100%'>" + newprintROWS + "</table></td></tr>"
            /*** end preview html ***/

            /*** final html string ***/
            previewHTMLStr = "<table cellpadding='0' cellspacing='0' style='padding-left:0px; text-align:left; border:1px solid black;'>" + firstBorder + thirdBorder + sencodBoder + fourthBoder + "</table>";

            //Print HTML
            printHTMLStr = "<br/><br/><table cellpadding='0' cellspacing='0' style='padding-left:0px; margin-top:20px; text-align:left; border:1px solid black;'>" + printfirstBorder + printthirdBorder + printsecondBorder + printfourthBoder + "</table>";

            //Preview HTMl
            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = previewHTMLStr;
            //Edit HTML
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
            //Print HTML
            document.getElementById("<%=hdnPrintHTML.ClientID %>").value = printHTMLStr;

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
                    url: "PropertyListing.aspx/ReplaceShortURltoHmlString",
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
            var returnValue = true;
            if (Page_ClientValidate('SV') && Page_IsValid) {
                //Web Link Validation
                var webLink = document.getElementById('<%=txtWeb.ClientID %>').value;
                if (webLink != "") {
                    var tomatch = /((ftp|http|https):\/\/)?([A-Za-z0-9\.-]{3,}\.[A-Za-z]{2,})/
                    if (!tomatch.test(webLink)) {
                        alert("Invalid Web Link.");
                        return false;
                    }
                }
                var allddls = document.getElementsByTagName("select");
                for (k = 0; k < allddls.length; k++) {
                    var controlName = allddls[k].id;
                    if (controlName.indexOf("ddlTime") >= 0) {
                        break;
                    }
                }
                var ExDate = document.getElementById("<%=txtExpires.ClientID %>").value;


                if (ExDate != "") {

                    var ExDate_Time = ExDate + " " + document.getElementById(controlName).value;
                    var todayDate = new Date();
                    ExDate_Time = new Date(ExDate_Time);
                    if (ExDate_Time < todayDate) {
                        alert('Expiration date should be later than current date.');
                        document.getElementById("<%=txtExpires.ClientID %>").focus();
                        returnValue = false;

                    }
                }
            }
            else {
                returnValue = false;
            }
            return returnValue;
        }
        function LoadData() {
            if (document.getElementById('<%=rbPrivate.ClientID %>').checked == true) {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";
            }
            else {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";
            }
        }
        function FirstImageDelete() {
            if (confirm("Are you sure you want to delete this image?")) {
                document.getElementById('divDefaultProperty').innerHTML = "";
                document.getElementById("imgDelete1").style.display = "none";
                document.getElementById("<%=hdnDefaultProperty.ClientID %>").value = "";
            }
            return false;
        }
        function closePopup() {

            $find("BulletinPreview").hide();
            return false;
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 44 && charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;

            return true;
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
            document.getElementById("<%=txtContentPhone.ClientID %>").value = newVal;

        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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
                    <div class="header">
                        <div style="margin: 0 auto; width: 100%; overflow: hidden;">
                            <asp:Label runat="server" ID="lblLogoHeader"></asp:Label>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            Property Listing</div>
                        <div class="form_wrapper">
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <label style="color: Red; font-size: 16px; margin-left: 100px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Address:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress"
                                        ValidationGroup="SV" ErrorMessage="Address is mandatory.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Additional Details:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtAddDetails1" runat="server" MaxLength="300" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="browseimg_wrap">
                                <div id='imgwatermark' style="position: absolute; display: none; text-align: center;">
                                </div>
                                <div class="avatar" style="text-align: center;">
                                    <div id="divDefaultProperty" style="width: 310px; min-height: 140px; display: block;">
                                    </div>
                                    <asp:HiddenField ID="hdnDefaultProperty" runat="server" />
                                    <asp:HiddenField ID="hdnDPLink" runat="server" />
                                </div>
                                <label>
                                    <img style="cursor: pointer;" onclick="EditDefaultImage('divDefaultProperty');" src="../../Images/Dashboard/Browseimg.png" />
                                </label>
                                <div style="float: right; margin-left: 0px;">
                                    <a href="javascript:ModalHelpPopup('Add Image to Content',20,'');">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                </div>
                                <div id="imgDelete1" style="margin-top: 5px; display: none;">
                                    <asp:Button ID="btnImgDelete1" runat="server" CausesValidation="false" border="0"
                                        CssClass="btn" Text="Delete Image" OnClientClick="return FirstImageDelete();"
                                        Width="151px" />
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Price:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtPrice" runat="server" CssClass="txtfild1" oncopy="return false"
                                        onpaste="return false" oncut="return false" onkeypress='return isNumberKey(event)'></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Square Feet:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtFeet" runat="server" CssClass="txtfild1" oncopy="return false"
                                        onpaste="return false" oncut="return false" onkeypress='return isNumberKey(event)'></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Bedrooms:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtBedrooms" runat="server" CssClass="txtfild1" oncopy="return false"
                                        onpaste="return false" oncut="return false" onkeypress='return event.charCode >= 48 && event.charCode <= 57'></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Bathrooms:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtBathrooms" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <font color="red">*</font>
                                    <label>
                                        Status:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtStatus" runat="server" CssClass="txtfild1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStatus"
                                        ValidationGroup="SV" ErrorMessage="Status is mandatory.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Additional Details:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtAddDetails2" runat="server" MaxLength="300" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Web Link:</label></div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtWeb" runat="server" CssClass="txtfild1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <div id='divMain' class="avatar" style="margin-left: 5px; border-width: 1px; min-height: 180px;
                                        width: 507px;">
                                        <asp:Label ID="lblEditText" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; margin: 5px 0px 0px 337px;">
                                <img style="cursor: pointer;" src="../../Images/ImageBlock.png" alt="Add Image" onclick="AddBlocks('DIV_IMAGE');" /><br />
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        <img style="vertical-align: middle" src="<%=RootPath %>/Images/content_call.png" />
                                        Number:
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <asp:TextBox ID="txtContentPhone" runat="server" CssClass="txtfild1" onkeyup="transform(this);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Expiration Date & Time:</label></div>
                                <div class="right_fields" style="width: 470px;">
                                    <table width="85%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtExpires" runat="server" onChange="ShowExTimeDiv();"></asp:TextBox>
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
                            <div class="fields_wrap " style="display: none;">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        Category:</label></div>
                                <div class="right_fields">
                                    <asp:DropDownList ID="ddlCategories" runat="server" Width="200px">
                                    </asp:DropDownList>
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
                                    <asp:LinkButton ID="lnkPreview" CausesValidation="false" runat="server" OnClientClick="return PreviewHTML('1');"><img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField runat="server" ID="hdnEditHTML" />
                <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
                <asp:HiddenField runat="server" ID="hdnEditXML" />
                <asp:HiddenField runat="server" ID="hdnPrintHTML" />
                <input type="hidden" id="editDivCheck" value="" />
                <input type="hidden" id="hdnalignindex" />
                <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
                <asp:HiddenField runat="server" ID="hdnCompleted" />
                <asp:HiddenField runat="server" ID="hdnPrivate" />
                <asp:HiddenField runat="server" ID="hdnExDate" />
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
                                <asp:ImageButton ID="imgclosepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif"
                                    OnClientClick="return closePopup()" />
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
                                <div style="overflow-y: auto; height: 500px; position: relative; width: auto; padding-right: 0px;">
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
                Security Pacific
            </div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
