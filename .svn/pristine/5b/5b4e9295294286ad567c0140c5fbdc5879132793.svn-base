<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="EditBulletin.aspx.cs" Inherits="USPDHUB.Business.MyAccount.EditBulletin"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.sortable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.droppable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.draggable.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
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
            font-size: 14px;
            width: 300px;
        }
        .imgdivStyle
        {
            text-align: justify;
            border: 1px solid #FCB549;
            overflow: auto;
            font-family: Arial;
            font-size: 12px;
            width: 300px;
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
    <style>
        .portlet-header
        {
            margin: 0.3em;
            padding-bottom: 4px;
            padding-left: 0.2em;
        }
        .portlet-header .ui-icon
        {
            float: right;
        }
        .portlet-content
        {
            padding: 0.4em;
        }
        .ui-sortable-placeholder
        {
            border: 2px solid #2F348F;
            visibility: visible !important;
            height: 150px !important;
        }
        .drop
        {
            vertical-align: top;
            background: #fafafa;
            width: 245px;
            height: auto;
        }
        .assigned
        {
        }
    </style>
    <script type="text/javascript">

        function PopupSubmiteTxt() {

            document.getElementById("hdnChanges").value = "true";


            //getting selected div ID
            var controlID = document.getElementById('ids').value;

            var plainText = document.getElementById("<%=txtEditor1.ClientID %>").value;
            htmlContent = document.getElementById('htmlvalue').value.replace("</span>", "");

            //For Line Break Issue
            // plainText = plainText.replace(/\n<br>/g, "<br/>");
            //plainText = plainText.replace(/\n/g, "<br/>");

            plainText = plainText.replace(/\n/gi, "<br/>");

            if (htmlContent == "") {
                htmlContent = "<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 14px; font-family: Arial;'>";
            }

            htmlContent = htmlContent + plainText + "</span>";

            htmlContent = htmlContent.replace("&yen;", "")
            document.getElementById(controlID).innerHTML = '';
            document.getElementById(controlID).innerHTML = htmlContent;

            document.getElementById('htmlvalue').value = '';
            //closeing modal popup
            CancelEditText();
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
            if (document.getElementById("maintable") != null) {
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
            }
            return false;
        }

        function CancelEditText() {
            document.getElementById('editorPopup').style.display = 'none';
            document.getElementById('popup').style.display = 'none';

            document.getElementById('htmlvalue').value = '';
            return false;
        }

        var EntID = "";

        function PreviewHTML(typeID) {
            EntID = typeID;

            if (typeID == 2 || typeID == 3) {
                ValidatePublishDate();
                //ExDate checking
                if (document.getElementById("<%=txtExDate.ClientID %>").value != "") {
                    var currentdate = new Date();
                    var fromDate = document.getElementById("<%=txtExDate.ClientID %>").value;
                    var selDate = new Date(fromDate);
                    var selHours = 0;
                    var selmins = 0;
                    if (document.getElementById("<%=txtExHours.ClientID %>").value != '' && document.getElementById("<%=txtExHours.ClientID %>").value != 'Hour') {
                        selHours = parseInt(document.getElementById("<%=txtExHours.ClientID %>").value);
                        if (selHours > 12) {
                            alert("Invalid Date Format.");
                            return false;
                        }
                        if (document.getElementById("<%=ddlExSS.ClientID %>").value == 'AM' && selHours == 12)
                            selHours = 0;
                        if (document.getElementById("<%=ddlExSS.ClientID %>").value == 'PM' && selHours < 12)
                            selHours = 12;
                    }
                    if (document.getElementById("<%=txtExMinutes.ClientID %>").value != '' && document.getElementById("<%=txtExMinutes.ClientID %>").value != 'Minutes')
                        selmins = parseInt(document.getElementById("<%=txtExMinutes.ClientID %>").value);
                    if (selmins >= 60) {
                        alert("Invalid Date Format.");
                        return false;
                    }
                    selDate.setHours(selHours, selmins, 0);
                    if (selDate <= currentdate) {
                        alert('Expiration date should be later than current date.');
                        return false
                    }
                }
            }


            var trs = '';
            var tds = '';
            var getHTML = '';
            var imgTag = '';

            var divCount = $("#maintable div").size();
            if (divCount > 0) {
                var divtable = document.getElementById("maintable");

                if (document.getElementById('<%=hdnBTempID.ClientID %>').value >= 6) {
                    for (i = 0; i < divtable.rows.length; i++) {
                        for (j = 0; j < divtable.rows[i].cells.length; j++) {
                            for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                                //DIV Tag 
                                if (divtable.rows[i].cells[j].children[k].tagName == "DIV") {
                                    var id = divtable.rows[i].cells[j].children[k].id;
                                    getHTML = document.getElementById(id).innerHTML;
                                    //alert(getHTML);
                                    var colSpan = "2";
                                    var divWidth = 300;

                                    //11 means 11 Template checking
                                    var imgAlignment = 'right';
                                    if (document.getElementById('<%=hdnBTempID.ClientID %>').value == 11) {
                                        if (getHTML.indexOf('<img') >= 0) {
                                            imgAlignment = document.getElementById(id).style.textAlign;
                                            getHTML = getHTML.replace("vertical-align: bottom;", "vertical-align: bottom; float: " + imgAlignment + "; margin-left: 2px; margin-right: 2px;");
                                        }
                                    }
                                    else {
                                        if (getHTML.indexOf('<img') >= 0) {
                                            imgAlignment = 'left';
                                            imgAlignment = document.getElementById(id).style.textAlign;
                                            getHTML = getHTML.replace("vertical-align: bottom;", "vertical-align: bottom; float: " + imgAlignment + "; margin-left: 2px; margin-right: 2px;");
                                        }
                                    }

                                    if (i == 0) {
                                        imgTag = getHTML;
                                    }
                                    else {
                                        var imgAlign = 'justify';

                                        if (getHTML.indexOf('<span') >= 0) {
                                            tds = tds + "<td colSpan='" + colSpan + "'  style='width:" + (divWidth) + "px; padding-bottom: 2px; text-align:left;'>" + imgTag + getHTML + "</td>";
                                            imgTag = '';
                                        }
                                        else {
                                            imgAlign = document.getElementById(id).style.textAlign;
                                            if (imgTag.replace(/<\/?[^>]+>/gi, '') != '') {
                                                imgAlign = 'justify';
                                            }
                                            tds = tds + "<td valign='top' colSpan='" + colSpan + "'  style='width:" + (divWidth) + "px; padding-bottom: 2px; text-align: " + imgAlign + ";'>" + getHTML + imgTag + "</td>";
                                            imgTag = '';
                                        }
                                    }

                                }
                            }
                        }
                        if (i == 0) {


                        }
                        else {
                            trs = trs + "<tr>" + tds + "</tr>";
                            tds = '';
                        }

                    }
                } // TempID >=11 else part
                else {

                    var IsListDescription = true;

                    for (i = 0; i < divtable.rows.length; i++) {
                        for (j = 0; j < divtable.rows[i].cells.length; j++) {
                            for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                                //DIV Tag 
                                if (divtable.rows[i].cells[j].children[k].tagName == "DIV") {
                                    var id = divtable.rows[i].cells[j].children[k].id;
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
                                            var imgAlignment = document.getElementById(id).style.textAlign;
                                            tds = tds + "<td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align:" + imgAlignment + ";'>" + getHTML + "</td>";
                                        }
                                    }
                                }
                            }
                        }
                        if (tds != "") {
                            trs = trs + "<tr>" + tds + "</tr>";
                        }
                        tds = '';
                    }
                }
            }

            var PreviewHTML = "<table style='margin-left:20px;' border='0'  >" + trs + "</table>";


            var bulletinHeader = document.getElementById("<%=hdnBulletinHeader.ClientID %>").value;
            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = PreviewHTML;


            if (EntID == 1) {

                bulletinHeader = bulletinHeader.replace("#BuildHtmlForForm#", PreviewHTML);
                document.getElementById("<%=lblnewspreview.ClientID %>").innerHTML = "";
                document.getElementById("<%=lblnewspreview.ClientID %>").innerHTML = bulletinHeader;

                var modal = $find("BulletinPreview");
                modal.show();


                document.getElementById('<%=lblmess.ClientID %>').innerHTML = "";


                return false;
            }
            else {
                if (Page_ClientValidate('ABC')) {
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

                    //PageMethods.ServerSideFill(divtable.outerHTML, PreviewHTML, isCompleted, isPrivate, typeID, exDate, OnSuccess, OnFail)
                    return true;
                }
            }
        }
        function OnSuccess(result) {

            if (EntID == "2") {
                document.getElementById('<%=lblmess.ClientID %>').innerHTML = 'Bulletin saved successfully.';
                return true;
            }
            else if (EntID == "3") {
                window.location = result;
            }
        }
        function OnFail() {
        }

        function ShowPopup(value) {
            controlID = value.id;
            document.getElementById('ids').value = controlID;

            document.getElementById('editorPopup').style.display = 'block';
            document.getElementById('popup').style.display = 'block';

            var editHTML = document.getElementById(controlID).innerHTML;
            //            if (editHTML.indexOf('<br>') >= 0) {
            //                editHTML = editHTML.replace("<br>", "\n");
            //            }

            editHTML = editHTML.replace("begin_of_the_skype_highlighting", "");
            editHTML = editHTML.replace("&nbsp;FREE&nbsp;", "");
            editHTML = editHTML.replace("end_of_the_skype_highlighting", "");
            editHTML = editHTML.replace("&amp;", "&");
            var plainText = editHTML.replace(/<\/?[^>]+>/, '');
            plainText = plainText.replace(/<\/span>/gi, "");

            var HtmlWithBreaks = plainText.replace(/<BR>/gi, "\n");
            HtmlWithBreaks = HtmlWithBreaks.replace(/<BR\/>/gi, "\n");
            document.getElementById("<%=txtEditor1.ClientID %>").value = HtmlWithBreaks.trim();

            document.getElementById("<%=txtEditor1.ClientID %>").focus();
            //Remove plain Text Store only html tags
            document.getElementById('htmlvalue').value = editHTML.trim().replace(plainText, "");

            //Setting styles for Textboxes
            if (editHTML.indexOf('font-weight: bold') <= 0) {
                document.getElementById("<%=txtEditor1.ClientID %>").style.fontWeight = 'normal';
            }
            else {
                document.getElementById("<%=txtEditor1.ClientID %>").style.fontWeight = 'bold';
            }
            if (editHTML.indexOf("font-style: italic") <= 0) {
                document.getElementById("<%=txtEditor1.ClientID %>").style.fontStyle = 'normal';
            }
            else {
                document.getElementById("<%=txtEditor1.ClientID %>").style.fontStyle = 'italic';
            }

            if (editHTML.indexOf("text-decoration: underline") <= 0) {
                document.getElementById("<%=txtEditor1.ClientID %>").style.textDecoration = 'none';
            }
            else {
                document.getElementById("<%=txtEditor1.ClientID %>").style.textDecoration = 'underline';
            }

            document.getElementById("<%=txtEditor1.ClientID %>").style.color = 'black';
            document.getElementById("<%=txtEditor1.ClientID %>").style.fontSize = '14px';
            document.getElementById("<%=txtEditor1.ClientID %>").style.fontFamily = 'arial';



            var toolBar1 = $find("<%=RadToolBar1.ClientID %>");

            var ColordropDown1 = toolBar1.get_items().getItem(2);
            ColordropDown1.set_text("Black");

            var fontsizedropDown1 = toolBar1.get_items().getItem(1);
            fontsizedropDown1.set_text("14px");

            var fontFamilyDropDown1 = toolBar1.get_items().getItem(0);
            fontFamilyDropDown1.set_text("Arial");


            if (editHTML.trim() == "") {

            }
            else {

                var toolBar = $find("<%=RadToolBar1.ClientID %>");
                //2 means  Color dropdown
                var ColordropDown = toolBar.get_items().getItem(2);
                for (i = 0; i < ColordropDown.get_buttons().get_count(); i++) {
                    var oldColor = ColordropDown._getAllItems()[i].get_text().toLowerCase();

                    if (editHTML.indexOf(oldColor) >= 0) {
                        document.getElementById("<%=txtEditor1.ClientID %>").style.color = oldColor;
                        ColordropDown.set_text(ColordropDown._getAllItems()[i].get_text());
                        break;
                    }
                }

                //1 means  fontsize dropdown
                var fontsizedropDown = toolBar.get_items().getItem(1);
                for (j = 0; j < fontsizedropDown.get_buttons().get_count(); j++) {
                    var oldfontsize = fontsizedropDown._getAllItems()[j].get_text();

                    if (editHTML.indexOf(oldfontsize) >= 0) {
                        document.getElementById("<%=txtEditor1.ClientID %>").style.fontSize = oldfontsize;
                        fontsizedropDown.set_text(oldfontsize);
                        break;
                    }
                }

                //0 means  fontFamily dropdown
                var fontFamilyDropDown = toolBar.get_items().getItem(0);
                for (j = 0; j < fontFamilyDropDown.get_buttons().get_count(); j++) {
                    var oldfontFamily = fontFamilyDropDown._getAllItems()[j].get_text();

                    if (editHTML.indexOf(oldfontFamily) >= 0) {
                        document.getElementById("<%=txtEditor1.ClientID %>").style.fontFamily = oldfontFamily;
                        fontFamilyDropDown.set_text(oldfontFamily);
                        break;
                    }
                }
            }

            //Active bold etc buttons
            ButtonActive();
            TextBox_Height_Width_Adjust();
        }


        //Indivisual Textboxes
        function OnClientButtonClicking(toolbar, args) {
            var button = args.get_item();

            //button.get_text() //Getting Text
            var commandName = button.get_commandName();
            var groupName = button.get_group();

            // Mystring = GetLatestHTML();
            Mystring = document.getElementById('htmlvalue').value;
            Mystring = Mystring.replace("</span>", "");
            //htmlContent = htmlContent.replace("</span>", plainText + "</span>");

            //Adding Span tags
            if (Mystring.indexOf('span') <= 0) {
                var innerText = '';
                Mystring = "<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 14px; font-family: Arial;'>" + innerText;
            }

            if (commandName == "Bold") {
                if (Mystring.indexOf('font-weight: bold') >= 0) {
                    Mystring = Mystring.replace("font-weight: bold", "font-weight: normal");
                    document.getElementById("<%=txtEditor1.ClientID %>").style.fontWeight = 'normal';
                }
                else {
                    Mystring = Mystring.replace("font-weight: normal", "font-weight: bold");
                    document.getElementById("<%=txtEditor1.ClientID %>").style.fontWeight = 'bold';
                }
            } else if (commandName == "Italic") {
                if (Mystring.indexOf("font-style: italic") >= 0) {
                    Mystring = Mystring.replace("font-style: italic", "font-style: normal");
                    document.getElementById("<%=txtEditor1.ClientID %>").style.fontStyle = 'normal';
                }
                else {
                    Mystring = Mystring.replace("font-style: normal", "font-style: italic");
                    document.getElementById("<%=txtEditor1.ClientID %>").style.fontStyle = 'italic';
                }
            }
            else if (commandName == "Underline") {
                if (Mystring.indexOf("text-decoration: underline") >= 0) {
                    Mystring = Mystring.replace("text-decoration: underline", "text-decoration: none");
                    document.getElementById("<%=txtEditor1.ClientID %>").style.textDecoration = 'none';
                }
                else {
                    Mystring = Mystring.replace("text-decoration: none", "text-decoration: underline");
                    document.getElementById("<%=txtEditor1.ClientID %>").style.textDecoration = 'underline';
                }
            }
            else if (groupName == "Color") {

                var toolBar = $find("<%=RadToolBar1.ClientID %>");
                //2 means  Color dropdown
                var colordropDown = toolBar.get_items().getItem(2);
                var newColorName = button.get_text().toLowerCase();

                for (i = 0; i < colordropDown.get_buttons().get_count(); i++) {
                    var oldColor = colordropDown._getAllItems()[i].get_text().toLowerCase();

                    if (Mystring.indexOf(oldColor) >= 0) {
                        Mystring = Mystring.replace("color: " + oldColor, "color: " + newColorName);
                        document.getElementById("<%=txtEditor1.ClientID %>").style.color = newColorName;
                        break;
                    }
                }
                colordropDown.set_text(button.get_text());
            }
            else if (groupName == "Fontsize") {

                var toolBar = $find("<%=RadToolBar1.ClientID %>");
                //1 means  Fontsize dropdown
                var fontsizedropDown = toolBar.get_items().getItem(1);
                var newFontsize = button.get_text().toLowerCase();

                for (i = 0; i < fontsizedropDown.get_buttons().get_count(); i++) {
                    var oldFontsize = fontsizedropDown._getAllItems()[i].get_text().toLowerCase();

                    if (Mystring.indexOf(oldFontsize) >= 0) {
                        Mystring = Mystring.replace("font-size: " + oldFontsize, "font-size: " + newFontsize);
                        document.getElementById("<%=txtEditor1.ClientID %>").style.fontSize = newFontsize;
                        break;
                    }
                }
                fontsizedropDown.set_text(button.get_text());
            }
            else if (groupName == "Fontfamily") {

                var toolBar = $find("<%=RadToolBar1.ClientID %>");
                //0 means  FontFamily dropdown
                var fontFamilyDropDown = toolBar.get_items().getItem(0);
                var newFontFamily = button.get_text();

                for (i = 0; i < fontFamilyDropDown.get_buttons().get_count(); i++) {
                    var oldFontFamily = fontFamilyDropDown._getAllItems()[i].get_text();

                    if (Mystring.indexOf(oldFontFamily) >= 0) {
                        Mystring = Mystring.replace("font-family: " + oldFontFamily, "font-family: " + newFontFamily);
                        document.getElementById("<%=txtEditor1.ClientID %>").style.fontFamily = newFontFamily;
                        break;
                    }
                }

                fontFamilyDropDown.set_text(button.get_text());
            }


            //document.getElementById("<%=txtEditor1.ClientID %>").innerText = Mystring.replace(/<\/?[^>]+>/gi, '').replace("&yen;", "");
            document.getElementById('htmlvalue').value = Mystring;


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
            if (blockname == "DIV_TEXT") {
                editingBlock = "<img class='editblockclass' src='../../Images/EditText.png'  style='cursor: pointer; margin-left:5px;' onclick='ShowPopup(edit" + CID + ")' />";
            }
            else if (blockname == "DIV_IMAGE") {
                editingBlock = "<img class='editblockclass' src='../../Images/EditImage.png'  style='cursor: pointer; margin-left:5px;' onclick='EditImage(edit" + CID + ")' />";
            }

            var newRow = "<tr id='tr" + CID + "'>" +
                            "<td class='drop' style='min-height: 20px;'>" +
                                " <div id='parentedit" + CID + "' style='float: left; margin-top: 10px;' class='assigned' >" +
                                       "<div id='edit" + CID + "' style='min-height: 100px; padding: 5px; float: left; ' class='textdivStyle'>" +
                                       "</div>" +
                                          editingBlock +
                                          "<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + CID + ")' />" +
                                "</div>" +
                         "</td>" +
                    "</tr>";



            $("#maintable").append(newRow);

            //Auto scroll when add new item
            var co = document.getElementById("parentedit" + CID);
            co.focus();
            LoadBlocks();

            document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
            if (document.getElementById("maintable") != null) {
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
            }
        }

        function LoadBlocks() {
            $(".drop").sortable({
                connectWith: ".drop",
                scrollSpeed: 5
            });
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

        function OnClientButtonClicked(toolbar, args) {
            ButtonActive();
            TextBox_Height_Width_Adjust();
        }

        function TextBox_Height_Width_Adjust() {
            //For Line-hight Problem (from 11px to 22px problem size)
            if (document.getElementById("<%=txtEditor1.ClientID %>").style.width == "500px") {
                document.getElementById("<%=txtEditor1.ClientID %>").style.width = "499px";
            }
            else {
                document.getElementById("<%=txtEditor1.ClientID %>").style.width = "500px"
            }

            if (document.getElementById("<%=txtEditor1.ClientID %>").style.height == "250px") {
                document.getElementById("<%=txtEditor1.ClientID %>").style.height = "249px";
            }
            else {
                document.getElementById("<%=txtEditor1.ClientID %>").style.height = "250px"
            }
        }

        function OnClientCheckedStateChanged(sender, args) {
            // ButtonActive();
        }

        function ButtonActive() {
            var toolBar = $find("<%=RadToolBar1.ClientID %>");
            var boldButton = toolBar.findItemByText('B');
            var italicButton = toolBar.findItemByText('I');
            var underlineButton = toolBar.findItemByText('U');


            //Checking BOLD
            if (document.getElementById("<%=txtEditor1.ClientID %>").style.fontWeight == 'bold') {
                //boldButton.check(true);
                boldButton.set_checked(true);
                boldButton.set_imageUrl('../../Images/mark.png');

                //css
                boldButton.set_checkedCssClass('rtbChecked');
                boldButton.set_focusedCssClass('rtbChecked');
                boldButton.set_hoveredCssClass('rtbChecked');
                boldButton.set_clickedCssClass('rtbChecked');
                boldButton._element.className = 'rtbItem rtbBtn rtbChecked ';
            }
            else {
                boldButton.set_checked(false);
                boldButton.set_imageUrl('');
                //css
                boldButton.set_checkedCssClass('');
                boldButton.set_focusedCssClass('');
                boldButton.set_hoveredCssClass('');
                boldButton.set_clickedCssClass('');
            }

            //Checking Italic
            if (document.getElementById("<%=txtEditor1.ClientID %>").style.fontStyle == 'italic') {
                italicButton.set_checked(true);
                italicButton.set_imageUrl('../../Images/mark.png');
                //css
                italicButton.set_checkedCssClass('rtbChecked');
                italicButton.set_focusedCssClass('rtbChecked');
                italicButton.set_hoveredCssClass('rtbChecked');
                italicButton.set_clickedCssClass('rtbChecked');
                italicButton._element.className = 'rtbItem rtbBtn rtbChecked ';
            }
            else {
                italicButton.set_checked(false);
                italicButton.set_imageUrl('');
                //css
                italicButton.set_checkedCssClass('');
                italicButton.set_focusedCssClass('');
                italicButton.set_hoveredCssClass('');
                italicButton.set_clickedCssClass('');
            }

            //Checking Underline
            if (document.getElementById("<%=txtEditor1.ClientID %>").style.textDecoration == 'underline') {
                underlineButton.set_checked(true);
                underlineButton.set_imageUrl('../../Images/mark.png');
                //css
                underlineButton.set_checkedCssClass('rtbChecked');
                underlineButton.set_focusedCssClass('rtbChecked');
                underlineButton.set_hoveredCssClass('rtbChecked');
                underlineButton.set_clickedCssClass('rtbChecked');
            }
            else {
                underlineButton.set_checked(false);
                underlineButton.set_imageUrl('');
                //css
                underlineButton.set_focusedCssClass('');
                underlineButton.set_checkedCssClass('');
                underlineButton.set_hoveredCssClass('');
                underlineButton.set_clickedCssClass('');
            }


        }

        //Show the Image Gallery
        function EditImage(value) {
            imgdivID = value.id;
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 12) + "&imgSrc=" + imgSrc + "&folder=Templates");
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


        function GetCurrentDate() {
            var date = new Date,
            dformat = [(date.getMonth() + 1).padLeft(), date.getDate().padLeft(), date.getFullYear()].join('/');
            return dformat;
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

        }
        function DisplayComplete() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked)
                document.getElementById('divpublish').style.display = "block";
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

                if (ischanges == "true" && document.getElementById('<%= txtPublishDate.ClientID%>').value == "") {
                    if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
                        document.getElementById('<%= txtPublishDate.ClientID%>').value = GetCurrentDate();
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
                document.getElementById('lblMandatory').style.display = "block";
            }
        }
        function SaveAlert() {
            var result;

            if (document.getElementById("hdnChanges").value == "true") {
                result = confirm('Do you want to save the changes you made to the bulletin?');
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

    </script>
    <script type="text/javascript">

        var IsMainBold = false
        var IsMainItalic = false;
        var IsMainUnderLine = false;
        var MainFontFamily = "Arial";
        var MainFontSize = "12px";
        var MainFontColor = "Black";

        //Main toolbar *** Apply for All Textboxes
        function Maintoolbar_OnClientButtonClicking(Maintoolbar, args) {
            var divCount = $("#maintable div").size();
            if (divCount > 0) {
                var button = args.get_item();

                document.getElementById("hdnChanges").value = "true";
                document.getElementById("hdnIsTextEdits").value = "true";

                //True is UnBold && False is Bold
                //button.get_isChecked()
                //alert(button.get_commandName());

                var commandName = button.get_commandName();
                var groupName = button.get_group();


                var divtable = document.getElementById("maintable");
                var IsChecked = button.get_isChecked();

                var getHTML = '';
                //First For
                for (i = 0; i < divtable.rows.length; i++) {

                    for (j = 0; j < divtable.rows[i].cells.length; j++) {
                        for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                            //DIV Tag 
                            if (divtable.rows[i].cells[j].children[k].tagName == "DIV") {
                                var id = divtable.rows[i].cells[j].children[k].id;
                                getHTML = document.getElementById(id).innerHTML;

                                //Adding Span tags
                                if (getHTML.indexOf('span') <= 0) {
                                    getHTML = "<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 14px; font-family: Arial;'>" + getHTML + "</span>";
                                }

                                //Apply Styles one by one TextBox
                                if (commandName == "Bold") {
                                    if (IsChecked == true) {
                                        getHTML = getHTML.replace("font-weight: bold", "font-weight: normal");
                                    }
                                    else {
                                        getHTML = getHTML.replace("font-weight: normal", "font-weight: bold");
                                    }
                                } else if (commandName == "Italic") {
                                    if (IsChecked == true) {
                                        getHTML = getHTML.replace("font-style: italic", "font-style: normal");
                                    }
                                    else {
                                        getHTML = getHTML.replace("font-style: normal", "font-style: italic");
                                    }
                                }
                                else if (commandName == "Underline") {
                                    if (IsChecked == true) {
                                        getHTML = getHTML.replace("text-decoration: underline", "text-decoration: none");
                                    }
                                    else {
                                        getHTML = getHTML.replace("text-decoration: none", "text-decoration: underline");
                                    }
                                }
                                else if (groupName == "MainColor") {

                                    var toolBar = $find("<%=Maintoolbar.ClientID %>");
                                    //2 Color dropdown
                                    var colorDropDown = toolBar.get_items().getItem(3);
                                    var newColorName = button.get_text().toLowerCase();

                                    for (a = 0; a < colorDropDown.get_buttons().get_count(); a++) {
                                        var oldColor = colorDropDown._getAllItems()[a].get_text().toLowerCase();

                                        if (getHTML.indexOf(oldColor) >= 0) {
                                            getHTML = getHTML.replace("color: " + oldColor, "color: " + newColorName);
                                            break;
                                        }
                                    }
                                    colorDropDown.set_text(button.get_text());
                                }  //end main color
                                else if (groupName == "MainFontsize") {

                                    var toolBar = $find("<%=Maintoolbar.ClientID %>");
                                    //1 fontsize dropdown
                                    var fontsizeDropDown = toolBar.get_items().getItem(2);
                                    var newFontsize = button.get_text();

                                    for (a = 0; a < fontsizeDropDown.get_buttons().get_count(); a++) {
                                        var oldfontsize = fontsizeDropDown._getAllItems()[a].get_text();

                                        if (getHTML.indexOf(oldfontsize) >= 0) {
                                            getHTML = getHTML.replace("font-size: " + oldfontsize, "font-size: " + newFontsize);
                                            break;
                                        }
                                    }
                                    fontsizeDropDown.set_text(button.get_text());
                                }  //end fontsize
                                else if (groupName == "MainFontfamily") {

                                    var toolBar = $find("<%=Maintoolbar.ClientID %>");
                                    //0 fontFamily dropdown
                                    var fontFamilyDropDown = toolBar.get_items().getItem(1);
                                    var newFontFamily = button.get_text();

                                    for (a = 0; a < fontFamilyDropDown.get_buttons().get_count(); a++) {
                                        var oldfontFamily = fontFamilyDropDown._getAllItems()[a].get_text();

                                        if (getHTML.indexOf(oldfontFamily) >= 0) {
                                            getHTML = getHTML.replace("font-family: " + oldfontFamily, "font-family: " + newFontFamily);
                                            break;
                                        }
                                    }
                                    fontFamilyDropDown.set_text(button.get_text());
                                } //Font Famly

                                document.getElementById(id).innerHTML = '';
                                document.getElementById(id).innerHTML = getHTML;
                            }

                        }
                    }
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

        function HideRadEditorToolBar(IsHeader) {
            var editor = $find("<%=Maintoolbar.ClientID %>");

            var toolbarItems = editor.get_allItems();

            var i = 0;
            while (i < toolbarItems.length) {
                toolbarItems[i].set_enabled(IsHeader);
                i++;
            }
            if (!IsHeader) {
                if (document.getElementById("hdnIsTextEdits").value == "true" && document.getElementById("maintable") != null) {

                    document.getElementById("<%=lblBulletinedit.ClientID %>").innerHTML = "";
                    document.getElementById("<%=lblBulletinedit.ClientID %>").innerHTML = document.getElementById("<%=hdnEditHTML.ClientID %>").value;
                    return;


                    var divtable = document.getElementById("maintable");
                    var boldButton = editor.get_items().getItem(4);
                    boldButton.set_checked(false);
                    var ItalicButton = editor.get_items().getItem(5);
                    ItalicButton.set_checked(false);
                    var UnderLineButton = editor.get_items().getItem(6);
                    UnderLineButton.set_checked(false);

                    var getHTML = '';
                    //First For
                    for (i = 0; i < divtable.rows.length; i++) {

                        for (j = 0; j < divtable.rows[i].cells.length; j++) {
                            for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                                //DIV Tag 
                                if (divtable.rows[i].cells[j].children[k].tagName == "DIV") {
                                    var id = divtable.rows[i].cells[j].children[k].id;
                                    getHTML = document.getElementById(id).innerText;

                                    //Adding Span tags

                                    getHTML = "<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 14px; font-family: Arial;'>" + getHTML + "</span>";


                                    var toolBar = $find("<%=Maintoolbar.ClientID %>");
                                    //2 Color dropdown
                                    var colorDropDown = toolBar.get_items().getItem(3);
                                    colorDropDown.set_text(MainFontColor);

                                    //1 fontsize dropdown
                                    var fontsizeDropDown = toolBar.get_items().getItem(2);
                                    fontsizeDropDown.set_text(MainFontSize);

                                    //0 fontFamily dropdown
                                    var fontFamilyDropDown = toolBar.get_items().getItem(1);
                                    fontFamilyDropDown.set_text(MainFontFamily);

                                    document.getElementById(id).innerHTML = '';
                                    document.getElementById(id).innerHTML = getHTML;
                                } //if

                            } //k
                        } //j                        
                    } //i // End for loop

                } // if
            } // IsHeader if
            else {
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
                if (document.getElementById("maintable") != null) {
                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
                }
            }
        }


    </script>
    <div id="popup" style="display: none;">
    </div>
    <div id='editorPopup' style="display: none; position: absolute; margin-top: 150px;
        margin-left: 150px; z-index: 100;">
        <table cellpadding="0" cellspacing="0" style="border: 1px solid #EEECEC; background-color: #F8F6F6;">
            <tbody>
                <tr>
                    <td align="right" style="padding: 5px 10px 0px 10px;">
                        <asp:ImageButton ID="imcloseeditpopup" runat="server" OnClientClick="return CancelEditText();"
                            ImageUrl="~/images/popup_close.gif" />
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px;">
                        <table>
                            <tr>
                                <td>
                                    <div>
                                        <telerik:RadToolBar ID="RadToolBar1" runat="server" OnClientButtonClicking="OnClientButtonClicking"
                                            OnClientButtonClicked="OnClientButtonClicked" OnClientCheckedStateChanged="OnClientCheckedStateChanged">
                                            <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
                                            <Items>
                                                <telerik:RadToolBarDropDown Text="Arial">
                                                    <Buttons>
                                                        <telerik:RadToolBarButton Text="Arial" Group="Fontfamily">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Calibri" Group="Fontfamily">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Comic Sans MS" Group="Fontfamily">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Courier New" Group="Fontfamily">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Segoe UI" Group="Fontfamily">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Tahoma" Group="Fontfamily">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Times New Roman" Group="Fontfamily">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Verdana" Group="Fontfamily">
                                                        </telerik:RadToolBarButton>
                                                    </Buttons>
                                                </telerik:RadToolBarDropDown>
                                                <telerik:RadToolBarDropDown Text="14px">
                                                    <Buttons>
                                                        <telerik:RadToolBarButton Text="11px" Group="Fontsize">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="12px" Group="Fontsize">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="14px" Group="Fontsize">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="16px" Group="Fontsize">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="18px" Group="Fontsize">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="20px" Group="Fontsize">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="22px" Group="Fontsize">
                                                        </telerik:RadToolBarButton>
                                                    </Buttons>
                                                </telerik:RadToolBarDropDown>
                                                <telerik:RadToolBarDropDown Text="Black">
                                                    <Buttons>
                                                        <%--<telerik:RadToolBarButton Text="Black" Group="Color">
                                                        </telerik:RadToolBarButton>--%>
                                                        <telerik:RadToolBarButton Text="Black" Group="Color">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Blue" Group="Color">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Fuchsia" Group="Color">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Gray" Group="Color">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Green" Group="Color">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Red" Group="Color">
                                                        </telerik:RadToolBarButton>
                                                        <telerik:RadToolBarButton Text="Yellow" Group="Color">
                                                        </telerik:RadToolBarButton>
                                                    </Buttons>
                                                </telerik:RadToolBarDropDown>
                                                <telerik:RadToolBarButton Text="B" Font-Bold="true" CommandName="Bold" CheckOnClick="true"
                                                    AllowSelfUnCheck="true">
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton Text="I" Font-Italic="false" CommandName="Italic" CheckOnClick="true"
                                                    AllowSelfUnCheck="true">
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton Text="U" Font-Underline="true" CommandName="Underline"
                                                    CheckOnClick="true" AllowSelfUnCheck="true">
                                                </telerik:RadToolBarButton>
                                            </Items>
                                        </telerik:RadToolBar>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea id='txtEditor1' runat="server" style="width: 500px; height: 250px; color: Black;
                                        font-size: 18px; font-weight: normal; font-style: normal; text-decoration: none;
                                        font-family: Arial; line-height: normal;"></textarea>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="padding-bottom: 5px; padding-right: 10px; text-align: right;">
                        <asp:Button ID="btneditok" runat="server" Text="Submit" OnClientClick="return PopupSubmiteTxt();" />
                        <asp:Button ID="btneditcancel" runat="server" Text="Cancel" OnClientClick="return CancelEditText();" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
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
                    <div style="width: 300px; margin: 0 auto;">
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                            ValidationGroup="ABC" HeaderText="The following error(s) occurred:" />
                        <asp:Label ID="lblmess" runat="server" Font-Size="Medium" ForeColor="Green"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="contentwrap">
                    <div class="largetxt" style="text-align: left;">
                        <asp:Label runat="server" ID="lblBulletinName" CssClass="navy20" Height="25px" Width="100%"></asp:Label></div>
                    <div class="form_wrapper" style="float: none; width: auto;">
                        <div class="clear10">
                        </div>
                        <div class="fields_wrap">
                            <label id="lblMandatory" style="color: Red; font-size: 16px; margin-left: 200px;
                                display: none;">
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
                            <div class="fields_wrap ">
                                <div class="left_lable" style="width: 400px;">
                                    <label>
                                        <input type="checkbox" onclick="HideRadEditorToolBar(this.checked);" />
                                        <span style="font-weight: bold;">Master Editor Applies Changes To All Text Boxes</span>
                                    </label>
                                </div>
                            </div>
                            <div class="clear0">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <telerik:RadToolBar ID="Maintoolbar" Width="472" runat="server" OnClientButtonClicking="Maintoolbar_OnClientButtonClicking"
                                        Style="padding-bottom: 30px;">
                                        <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
                                        <Items>
                                            <telerik:RadToolBarButton Text="" Font-Bold="true" CommandName="Bold" CheckOnClick="true"
                                                AllowSelfUnCheck="true" Enabled="false">
                                            </telerik:RadToolBarButton>
                                            <telerik:RadToolBarDropDown Text="Arial" Enabled="false">
                                                <Buttons>
                                                    <telerik:RadToolBarButton Text="Arial" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Calibri" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Comic Sans MS" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Courier New" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Segoe UI" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Tahoma" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Times New Roman" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Verdana" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                </Buttons>
                                            </telerik:RadToolBarDropDown>
                                            <telerik:RadToolBarDropDown Text="14" Enabled="false">
                                                <Buttons>
                                                    <telerik:RadToolBarButton Text="11px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="12px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="14px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="16px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="18px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="20px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="22px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                </Buttons>
                                            </telerik:RadToolBarDropDown>
                                            <telerik:RadToolBarDropDown Text="Black" Enabled="false">
                                                <Buttons>
                                                    <telerik:RadToolBarButton Text="Black" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Blue" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Fuchsia" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Gray" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Green" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Red" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Yellow" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                </Buttons>
                                            </telerik:RadToolBarDropDown>
                                            <telerik:RadToolBarButton Text="B" Font-Bold="true" CommandName="Bold" CheckOnClick="true"
                                                AllowSelfUnCheck="true" Enabled="false">
                                            </telerik:RadToolBarButton>
                                            <telerik:RadToolBarButton Text="I" Font-Italic="false" CommandName="Italic" CheckOnClick="true"
                                                AllowSelfUnCheck="true" Enabled="false">
                                            </telerik:RadToolBarButton>
                                            <telerik:RadToolBarButton Text="U" Font-Underline="true" CommandName="Underline"
                                                CheckOnClick="true" AllowSelfUnCheck="true" Enabled="false">
                                            </telerik:RadToolBarButton>
                                        </Items>
                                    </telerik:RadToolBar>
                                    <div class="avatar" style="border-width: 1px; min-height: 100px; width: 470px; display: block;
                                        max-height: 400px; overflow: auto;">
                                        <asp:Label ID="lblBulletinedit" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; margin: 65px 0px 0px 300px;">
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_TEXT');" src="../../Images/addnewtext.png" />
                                <a id="A1" href="javascript:ModalHelpPopup('Add Text to Bulletin',21,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                <br />
                                <br />
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_IMAGE');" src="../../Images/addnewimg.png" />
                                <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Add Image to Bulletin',20,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    Expiration Date & Time:
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
                                                        CssClass="MyCalendar" OnClientDateSelectionChanged="OnTextChanged" />
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtExHours" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14" TargetControlID="txtExHours"
                                                        WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtExHours" ValidationExpression="^[0-9]*$" ValidationGroup="ABC"
                                                        ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                                    &nbsp; &nbsp;
                                                    <asp:TextBox runat="server" ID="txtExMinutes" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender15" TargetControlID="txtExMinutes"
                                                        WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtExMinutes" ValidationExpression="^[0-9]*$" ValidationGroup="ABC"
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
                            <div class="steps">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <label runat="server" id="divCall">
                                        <asp:CheckBox ID="chkCall" runat="server" Checked="true" />
                                        Display Call Button</label>
                                    <br />
                                    <label id="divContactUs" runat="server">
                                        <asp:CheckBox ID="chkContact" runat="server" Checked="true" />
                                        Display Contact Us Button</label>
                                    <br />
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
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
                                                Unpublish</label>
                                            <asp:Label ID="lblCompleted" runat="server"></asp:Label>
                                            <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2','true')" />
                                            <asp:Label ID="lblworkprogress" runat="server"></asp:Label>
                                            <label>
                                                Publish</label>
                                            <div style="margin: 10px 10px 0px 80px; display: none;" id="divpublish">
                                                <font color="red">*</font>
                                                <label style="font-size: 14px;">
                                                    Publish On:</label>
                                                <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                    ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                    runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="ABC"
                                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                    ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                    ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                <br />
                                                <span style="padding-left: 85px;"><b>(MM/DD/YYYY)</b></span>
                                                <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                    Format="MM/dd/yyyy" CssClass="MyCalendar" OnClientDateSelectionChanged="OnTextChanged" />
                                                <asp:HiddenField ID="hdnPublishDate" runat="server" />
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
                                    <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="ABC" OnClientClick="return PreviewHTML('3')"
                                        OnClick="BtnPublish_Click" border="0" CssClass="btn" />
                                    <asp:Button ID="BtnPublish" runat="server" Text="Submit" ValidationGroup="ABC" OnClientClick="return PreviewHTML('3')"
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
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; padding: 10px;" colspan="2">
                                <div style="overflow-y: auto; height: 600px; position: relative;">
                                    <asp:Label ID="lblnewspreview" runat="server"></asp:Label></div>
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
