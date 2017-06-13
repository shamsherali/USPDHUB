<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    Inherits="Business_MyAccount_EditUpdate" ValidateRequest="false" CodeBehind="EditUpdate.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript">

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
            if (document.getElementById('<%= lblEditText.ClientID%>').innerHTML == "") {
                document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
            }


            if (val == "1") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Save";
                document.getElementById('divpublish').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
            } else if (val == "2") {
                document.getElementById('<%=btnSave.ClientID %>').value = "Submit";
                document.getElementById('divpublish').style.display = "block";
                if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
                    GetCurrentDate();
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
    </script>
    <script type="text/javascript">

        function PopupSubmiteTxt() {

            //getting selected div ID
            var controlID = document.getElementById('ids').value;

            var plainText = document.getElementById("<%=txtEditor1.ClientID %>").value;
            htmlContent = document.getElementById('htmlvalue').value.replace("</span>", "");
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

            return false;
        }

        function CancelEditText() {
            document.getElementById('editorPopup').style.display = 'none';
            document.getElementById('htmlvalue').value = '';
            return false;
        }

        function ShowPreview() {

            var divCount = $("#maintable div").size();
            if (divCount > 0) {
                var myBehavior = $find("popupop");
                var profileid = '<%=ProfileID %>';
                var userid = '<%=UserID %>';

                PreviewHTML('1');

                var HtmlBody = document.getElementById("<%=hdnPreviewHTML.ClientID %>").value;
                HtmlBody = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'><tr><td colspan='2' style='padding:30px;'>" + HtmlBody + "</td></tr></table></body></html>";

                if ($get('<%=txtUpdateName.ClientID%>').value != "The title appears on your App") {
                    $get('<%=lblupdatenamepreview.ClientID%>').innerHTML = $get('<%=txtUpdateName.ClientID%>').value;
                }
                $get('<%=lblPreviewHTML.ClientID %>').innerHTML = HtmlBody;
                myBehavior.show();

                /*
                PageMethods.GetPreviewTable(HtmlBody, profileid, userid, OnSuccess, OnFail);
              
                function OnSuccess(result) {
                alert(result);
                if ($get('<%=txtUpdateName.ClientID%>').value != "The title appears on your App") {
                $get('<%=lblupdatenamepreview.ClientID%>').innerHTML = $get('<%=txtUpdateName.ClientID%>').value;
                }
                $get('<%=lblPreviewHTML.ClientID %>').innerHTML = result;
                myBehavior.show();
                  
                return false;
                }
                function OnFail() { return false; }
                */

                return false;
            }
            else {
                alert("You haven't built your content yet.");
                return false;
            }
        }

        var EntID = "";

        function PreviewHTML(type) {
            if (type == '2') {
                ValidatePublishDate();

                if (!Page_ClientValidate('group')) {
                    return;
                }
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
                            selHours += 12;
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
                //end exdate checking
            }

            var trs = '';
            var tds = '';
            var getHTML = '';
            var PreviewHTML = '';

            var IsListDescription = true;

            var divtable = document.getElementById("maintable");
            if (divtable != null) {
                for (i = 0; i < divtable.rows.length; i++) {
                    for (j = 0; j < divtable.rows[i].cells.length; j++) {
                        for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                            //DIV Tag 
                            if (divtable.rows[i].cells[j].children[k].tagName == "DIV") {
                                var id = divtable.rows[i].cells[j].children[k].id;
                                getHTML = document.getElementById(id).innerHTML;
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
                    trs = trs + "<tr>" + tds + "</tr>";
                    tds = '';
                }

                PreviewHTML = "<table style='margin-left:20px; border:1px solid black;' border='0'  >" + trs + "</table>";
                document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = PreviewHTML;
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;


            }

            if (type == '2')
                $find("<%=MPEProgress.ClientID %>").show();

        }

        function ShowPopup(value) {

            controlID = value.id;
            document.getElementById('ids').value = controlID;

            /*
            document.getElementById('divTextEditor').innerHTML = "";
            ifrm = document.createElement("IFRAME");

            ifrm.setAttribute("src", "CustomTextEditor.aspx");
            ifrm.style.height = "400px";
            ifrm.style.width = "600px";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('divTextEditor').appendChild(ifrm);

            var modalDialog = $find("popupeditor");
            modalDialog.show();
            */

            document.getElementById('editorPopup').style.display = 'block';


            var editHTML = document.getElementById(controlID).innerHTML;

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
            document.getElementById('htmlvalue').value = Mystring;
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


        function AddBlocks(blockname) {

            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"400px\" style=\"border: 0px solid gray; " +
                                                                        "min-height: 100px;\"> " +
                                                                    "</table>";

                document.getElementById("<%=lblEditText.ClientID %>").innerHTML = maintableTag;
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
                editingBlock = "<img src='../../Images/EditText.png'  style='cursor: pointer;' onclick='ShowPopup(edit" + CID + ")' />";
            }
            else if (blockname == "DIV_IMAGE") {
                editingBlock = "<img src='../../Images/EditImage.png'  style='cursor: pointer;' onclick='EditImage(edit" + CID + ")' />";
            }

            var newRow = "<tr id='tr" + CID + "'>" +
                        "<td>" +
                            "<div id='edit" + CID + "' style='min-height: 100px; padding: 5px;' class='textdivStyle'>" +
                            "</div>" +
                         "</td>" +
                        "<td >" +
                            editingBlock +
                            "<br/><img src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px;' onclick='RemoveBlock(edit" + CID + ")' />" +
                        "</td>" +
                    "</tr>";



            $("#maintable").append(newRow);

            //Auto scroll when add new item
            var co = document.getElementById("edit" + CID);
            co.focus();
        }

        //Show the Image Gallery
        function EditImage(value) {
            imgdivID = value.id;
            document.getElementById('divImageframe').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

//            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 12) + "&imgSrc=" + imgSrc);
//            ifrm.style.height = "750px";
            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 32) + "&imgSrc=" + imgSrc);
            ifrm.style.height = "650px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('divImageframe').appendChild(ifrm);
            document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("popupimage");
            modalDialog.show();

        }

        function RemoveBlock(value) {
            var divID = value.id;
            divID = divID.replace("edit", "tr");
            if (confirm("Are you sure you want to delete this block?")) {
                $("#" + divID).remove();
            }

            var divCount = $("#maintable div").size();
            if (divCount <= 0) {
                document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
            }
        }

        function highlightdiv(divID) {
            //document.getElementById(divID).style.border = "2px solid blue";
            $('#' + divID).select();
        }
        function RemoveHightlight(divID) {
            document.getElementById(divID).style.border = "1px solid black";
        }
        window.onload = function () {

            CountMaxLength(document.getElementById('<%=txtUpdateName.ClientID %>'), 'content name');

        }
        function CountMaxLength(id, text) {
            var maxlength = 150;
            var Content = id.value;
            var TextLength = id.value.length;
            if (Content == 'The title appears on your App')
                TextLength = 0;
            if (TextLength > maxlength) {
                id.value = id.value.substring(0, maxlength);
                alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
            }
            document.getElementById('<%=lblCount.ClientID %>').innerHTML = maxlength - TextLength;
            //alert(document.getElementById("ctl00_cphUser_txtNoticication"));    

        }
    </script>
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
        .watermarkClass
        {
            color: #d0d0d0;
            height: 24px;
        }
        .stepwrapmain
        {
            width: 700px;
            vertical-align: top;
            position: fixed;
        }
        .right_buttons1
        {
            position: absolute;
            top: 60%;
            left:72%;
            margin-left:3px;
            vertical-align: top;
        }
        
        @-moz-document url-prefix() { 
        .right_buttons1
        {
            position: absolute;
            top: 56%;
            left:72%;
            margin-left:3px;
            vertical-align: top;
        }
        }
        
        .stepswrap
        {
            overflow: hidden;
            margin: 0 auto;
            width: 488px;
            position: relative;
            color: #2F348F;
        }
        .stepswrap1
        {
            overflow: hidden;
            margin: 4px auto;
            width: 468px;
            border: 1px solid #ccc;
            color: #2F348F;
            padding: 5px 10px 5px 5px;
        }
        .steps
        {
            margin: 0px 0px 0px 211px;
            font-size: 15px;
            font-family: Arial;
            color: #2F348F;
            font-weight: bold;
        }
    </style>
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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
                                                    OnClientButtonClicked="OnClientButtonClicked">
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
                                                font-size: 14px; font-weight: normal; font-style: normal; text-decoration: none;
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
            <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
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
                                ValidationGroup="group" HeaderText="The following error(s) occurred:" />
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            Updates</div>
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
                                <span style="color: Red; font-size: 16px;">*</span> Step 1: Name Your Content <a
                                    href="javascript:ModalHelpPopup('Create Content',161,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a></div>
                            <div class="stepswrapmain">
                                <div class="stepswrap">
                                    <div class="fields_wrap">
                                        <div class="right_fields">
                                            <asp:TextBox ID="txtUpdateName" runat="server" Width="479px" CssClass="txtfild1"
                                                MaxLength="150" onkeyup="CountMaxLength(this,'content name');" onChange="CountMaxLength(this,'content name');"></asp:TextBox>
                                            <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtUpdateName"
                                                BehaviorID="WaterMarkTextSize" WatermarkText="The title appears on your App"
                                                runat="server" WatermarkCssClass="watermarkClass">
                                            </cc1:TextBoxWatermarkExtender>
                                            <asp:RequiredFieldValidator ID="RFV_pct" runat="server" ControlToValidate="txtUpdateName"
                                                ValidationGroup="group" ErrorMessage="Please&amp;nbsp;enter&amp;nbsp;Content&amp;nbsp;Name.">*</asp:RequiredFieldValidator>
                                            <div style="width: 510px; margin: 0px 0px 0px 0px;">
                                                <label>
                                                    <asp:Label runat="server" ID="lblCount" Text="150"></asp:Label>
                                                    Characters remaining.
                                                </label>
                                                <label style="margin-left: 165px;">
                                                    (150 characters max)
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clear10">
                                </div>
                                <div class="steps">
                                    Step 2: Build Your Content</div>
                                <div style="width: 700px; margin: 0px 0px 0px 212px;">
                                    <div class="stepswrap1" style="float: left;">
                                        <div class="fields_wrap">
                                            <div class="left_lable">
                                                <font color="red"></font>
                                                <label>
                                                </label>
                                            </div>
                                            <div style="text-align: right; float: left">
                                                <div class="avatar" style="border-width: 0px; min-height: 100px; width: 468px; display: block;
                                                    max-height: 400px; overflow: auto;">
                                                    <asp:Label ID="lblEditText" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="text-align: right; float: left; margin: 16px 0px 0px 10px;">
                                        <img style="cursor: pointer;" onclick="AddBlocks('DIV_TEXT');" src="../../Images/addnewtext.png" />
                                        <a href="javascript:ModalHelpPopup('Add Text to Content',116,'');">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                        <br />
                                        <br />
                                        <img style="cursor: pointer;" onclick="AddBlocks('DIV_IMAGE');" src="../../Images/addnewimg.png" />
                                        <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Add Image to Content',115,'');">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                    </div>
                                    <div style="text-align: right; float: left; margin: 75px 0px 0px 5px;">
                                    </div>
                                </div>
                                <div class="clear10">
                                </div>
                                <div class="steps">
                                    Step 3: Choose Status</div>
                                <div class="steps">
                                </div>
                                <div class="stepswrap1">
                                    <div class="fields_wrap">
                                        <div class="left_lable">
                                            <label>
                                            </label>
                                        </div>
                                        <div class="right_fields" style="width: 470px;">
                                            <div style="margin: 0px 0px 0px 0px;">
                                                <table width="100%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                                    <tr>
                                                        <td>
                                                            <label>
                                                                Expiration Date & Time:
                                                            </label>
                                                        </td>
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
                                    <div class="steps">
                                    </div>
                                    <div class="fields_wrap">
                                        <div class="left_lable">
                                            <label>
                                            </label>
                                        </div>
                                        <div class="right_fields" style="width: 470px; margin-left: 150px;">
                                            <label runat="server" id="divCall">
                                                <asp:CheckBox ID="chkCall" runat="server" />
                                                Display Call Button</label>
                                            <br />
                                            <label id="divContactUs" runat="server">
                                                <asp:CheckBox ID="chkContact" runat="server" />
                                                Display Contact Us Button</label>
                                        </div>
                                    </div>
                                    <div class="fields_wrap">
                                        <div class="left_lable">
                                            <label>
                                            </label>
                                        </div>
                                        <div class="right_fields" style="width: 470px; margin-left: 150px;">
                                            <div style="margin: 0px 0px 0px 0px;">
                                                <div id="public" style="margin: 10px 0px 0px 5px;">
                                                    <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                                        onclick="javascript:ShowPublish('1')" />
                                                    <label>
                                                        Private</label>
                                                    <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2')" />
                                                    <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                                    <div style="margin: 10px 10px 0px 80px; display: none;" id="divpublish">
                                                        <font color="red">*</font>
                                                        <label style="font-size: 14px;">
                                                            Publish Date:</label>
                                                        <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                            ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                            runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="group"
                                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                            ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                            ValidationGroup="group" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                        <br />
                                                        <span style="padding-left: 91px;"><b>(MM/DD/YYYY)</b></span>
                                                        <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                        <asp:HiddenField ID="hdnPublishDate" runat="server" />
                                                        <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
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
                                <div class="right_fields" style="margin: 10px 0px 0px 0px;">
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" border="0" OnClick="btnSave_Click"
                                        ValidationGroup="group" OnClientClick="return PreviewHTML('2');" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return ShowPreview();">
                                    <img src="../../images/BulletinThumbs/preview.png"  width="100" height="37"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblpre"
                        PopupControlID="pnlpopup1" BackgroundCssClass="modal" BehaviorID="popupop" CancelControlID="imglogin5">
                    </cc1:ModalPopupExtender>
                    <asp:Panel Style="display: none" ID="pnlpopup1" runat="server" Width="100%">
                        <table style="padding-left: 10px; background-color: white" cellspacing="0" cellpadding="0"
                            width="450" align="center" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-right: 20px; padding-top: 10px" align="right">
                                        <asp:ImageButton ID="imglogin5" OnClientClick="return false;" runat="server" CausesValidation="false"
                                            ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; color: green;
                                        padding-top: 10px" align="left">
                                        <asp:Label ID="lblupdatenamepreview" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-right: 10px; padding-bottom: 20px">
                                        <div style="overflow: auto; position: relative; height: 500px">
                                            <asp:Label ID="lblPreviewHTML" runat="server"></asp:Label>
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
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"> Your request is in progress, please don't refresh or close window. </font></b>
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
                        <div id="divImageframe">
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
    <input type="hidden" id="hdnChanges" value="false" />
    <asp:HiddenField runat="server" ID="hdnEditHTML" />
    <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
    <asp:HiddenField ID="hdnPermissionType" runat="server" />
    <asp:HiddenField ID="hdnDescription" runat="server" Value="" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
