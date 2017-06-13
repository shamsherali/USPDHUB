<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEditor.ascx.cs" Inherits="CopyPaste_POC.UCEditor" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<style type="text/css">
    #overlay
    {
    }
    .content a
    {
        text-decoration: none;
    }
    .popup123
    {
        width: 100%;
        margin: 0 auto;
        display: none;
        position: fixed;
        z-index: 102;
    }
    .content
    {
        min-width: 600px;
        width: 600px;
        min-height: 150px;
        margin: 100px auto;
        background: #f3f3f3;
        position: relative;
        z-index: 103;
        padding: 10px;
        border-radius: 5px;
        box-shadow: 0 2px 5px #000;
    }
    .content p
    {
        clear: both;
        color: #555555;
        text-align: justify;
    }
    .content p a
    {
        color: #d91900;
        font-weight: bold;
    }
    .content .x
    {
        float: right;
        left: 22px;
        position: relative;
        top: -25px;
    }
    .content .x:hover
    {
        cursor: pointer;
    }
</style>
<script>
    function PopupSubmiteTxt() {


        if (document.getElementById("hdnChanges") != null) {
            document.getElementById("hdnChanges").value = "true";
        }


        //getting selected div ID
        var controlID = document.getElementById('ids').value;

        var plainText = document.getElementById("<%=txtEditor1.ClientID %>").innerHTML;
        htmlContent = document.getElementById('htmlvalue').value.replace("</span>", "");

        //For Line Break Issue
        // plainText = plainText.replace(/\n<br>/g, "<br/>");
        //plainText = plainText.replace(/\n/g, "<br/>");

        plainText = plainText.replace(/\n/gi, "<br/>");

        if (htmlContent == "") {
            htmlContent = "<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 16px; font-family: " + document.getElementById('<%=hdnUserFont.ClientID %>').value + "; text-align: left; display: block;'>";
        }

        //alert(document.getElementById('<%=hdnUserFont.ClientID %>').value);
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

        $(".avatar").animate({ scrollTop: $(".avatar").prop("scrollHeight") }, 1000);

        return false;
    }

    function CancelEditText() {
        document.getElementById('editorPopup').style.display = 'none';
        document.getElementById('popup').style.display = 'none';

        document.getElementById('htmlvalue').value = '';
        return false;
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

        if (editHTML.indexOf("text-align:") == -1) {
            editHTML = editHTML.replace("\">", " text-align: left; display: block;\">");
        }


        var plainText = editHTML.replace(/<\/?[^>]+>/, '');
        plainText = plainText.replace(/<\/span>/gi, "");

        /*
        var HtmlWithBreaks = plainText.replace(/<BR>/gi, "\n");
        HtmlWithBreaks = HtmlWithBreaks.replace(/<BR\/>/gi, "\n");
        */

        document.getElementById("<%=txtEditor1.ClientID %>").innerHTML = plainText.trim();

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
        document.getElementById("<%=txtEditor1.ClientID %>").style.fontSize = '16px';
        document.getElementById("<%=txtEditor1.ClientID %>").style.fontFamily = document.getElementById('<%=hdnUserFont.ClientID %>').value;



        var toolBar1 = $find("<%=RadToolBar1.ClientID %>");

        var ColordropDown1 = toolBar1.get_items().getItem(2);
        ColordropDown1.set_text("Black");

        var fontsizedropDown1 = toolBar1.get_items().getItem(1);
        fontsizedropDown1.set_text("16px");

        var fontFamilyDropDown1 = toolBar1.get_items().getItem(0);
        fontFamilyDropDown1.set_text(document.getElementById('<%=hdnUserFont.ClientID %>').value);

        //6 means  Align dropdown
        var alignDropDown1 = toolBar1.get_items().getItem(6);
        alignDropDown1.set_text("Left");


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

            //6 means  Align dropdown
            var alignDropDown = toolBar.get_items().getItem(6);
            for (j = 0; j < alignDropDown.get_buttons().get_count(); j++) {
                var oldalign = alignDropDown._getAllItems()[j].get_text();

                if (editHTML.indexOf(oldalign.toLowerCase()) >= 0) {
                    //document.getElementById("<%=txtEditor1.ClientID %>").style.textalign = oldalign;
                    $("#<%=txtEditor1.ClientID %>").css("text-align", oldalign);
                    alignDropDown.set_text(oldalign);
                    break;
                }
            }

        }

        //Active bold etc buttons
        ButtonActive();
        TextBox_Height_Width_Adjust();
    }

    var links = null;

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

        var toolBar = $find("<%=RadToolBar1.ClientID %>");

        //Adding Span tags
        if (Mystring.indexOf('span') <= 0) {
            var innerText = '';
            Mystring = "<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 16px; font-family: " + document.getElementById('<%=hdnUserFont.ClientID %>').value + "; text-align: left; display: block;'>" + innerText;
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
        else if (groupName == "Align") {

            //6 means  Align dropdown
            var alignDropDown = toolBar.get_items().getItem(6);
            var newAlign = button.get_text().toLowerCase();

            for (i = 0; i < alignDropDown.get_buttons().get_count(); i++) {
                var oldAlign = alignDropDown._getAllItems()[i].get_text().toLowerCase();

                if (Mystring.indexOf(oldAlign) >= 0) {
                    Mystring = Mystring.replace("text-align: " + oldAlign, "text-align: " + newAlign);
                    $("#<%=txtEditor1.ClientID %>").css("text-align", newAlign);
                    //document.getElementById("").style.textalign = newAlign;
                    break;
                }
            }

            alignDropDown.set_text(button.get_text());
        }
        else if (commandName == "A") {

            var savedSel = saveSelection();

            var url = prompt('Enter a URL:', 'http://');

            restoreSelection(savedSel);

            document.execCommand("CreateLink", false, url);
            var links = getLinksInSelection();
            for (var i = 0; i < links.length; ++i) {
                links[i].style.fontWeight = "bold";
            }

        }

        //document.getElementById("<%=txtEditor1.ClientID %>").innerText = Mystring.replace(/<\/?[^>]+>/gi, '').replace("&yen;", "");
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


    function saveSelection() {
        if (window.getSelection) {
            sel = window.getSelection();
            if (sel.getRangeAt && sel.rangeCount) {
                var ranges = [];
                for (var i = 0, len = sel.rangeCount; i < len; ++i) {
                    ranges.push(sel.getRangeAt(i));
                }
                return ranges;
            }
        } else if (document.selection && document.selection.createRange) {
            return document.selection.createRange();
        }
        return null;
    }

    function restoreSelection(savedSel) {
        if (savedSel) {
            if (window.getSelection) {
                sel = window.getSelection();
                sel.removeAllRanges();
                for (var i = 0, len = savedSel.length; i < len; ++i) {
                    sel.addRange(savedSel[i]);
                }
            } else if (document.selection && savedSel.select) {
                savedSel.select();
            }
        }
    }

    function getLinksInSelection() {
        var selectedLinks = [];
        var range, containerEl, links, linkRange;
        if (window.getSelection) {
            sel = window.getSelection();
            if (sel.getRangeAt && sel.rangeCount) {
                linkRange = document.createRange();
                for (var r = 0; r < sel.rangeCount; ++r) {
                    range = sel.getRangeAt(r);
                    containerEl = range.commonAncestorContainer;
                    if (containerEl.nodeType != 1) {
                        containerEl = containerEl.parentNode;
                    }
                    if (containerEl.nodeName.toLowerCase() == "a") {
                        selectedLinks.push(containerEl);
                    } else {
                        links = containerEl.getElementsByTagName("a");
                        for (var i = 0; i < links.length; ++i) {
                            linkRange.selectNodeContents(links[i]);
                            if (linkRange.compareBoundaryPoints(range.END_TO_START, range) < 1 && linkRange.compareBoundaryPoints(range.START_TO_END, range) > -1) {
                                selectedLinks.push(links[i]);
                            }
                        }
                    }
                }
                linkRange.detach();
            }
        } else if (document.selection && document.selection.type != "Control") {
            range = document.selection.createRange();
            containerEl = range.parentElement();
            if (containerEl.nodeName.toLowerCase() == "a") {
                selectedLinks.push(containerEl);
            } else {
                links = containerEl.getElementsByTagName("a");
                linkRange = document.body.createTextRange();
                for (var i = 0; i < links.length; ++i) {
                    linkRange.moveToElementText(links[i]);
                    if (linkRange.compareEndPoints("StartToEnd", range) > -1 && linkRange.compareEndPoints("EndToStart", range) < 1) {
                        selectedLinks.push(links[i]);
                    }
                }
            }
        }
        return selectedLinks;
    }

   

</script>
<script type="text/javascript">
    $(document).ready(function () {

        LoadTxtBox();

    });

    function LoadTxtBox() {
        $('#<%=txtEditor1.ClientID %>').bind('paste', function () {
            var finalhtml = '';
            var before = finalhtml = document.getElementById('<%=txtEditor1.ClientID %>').innerHTML;

            setTimeout(function () {
                var after = document.getElementById('<%=txtEditor1.ClientID %>').innerHTML;
                document.getElementById('<%=txtEditor1.ClientID %>').innerHTML = before;
                after = after.replace(/<p><br><\/p>/gi, '#ParaSeparator#');
                after = after.replace(/<div><br><\/div>/gi, '#DivSeparator#');
                after = after.replace(/<br><br>/gi, '#BreakSeparator#');
                var strRegex = /<\/?([b-z]+)[^>]*>/gi;
                var strRegextarget = /<(a)([^>]+)>/gi;
                if (strRegex.test(after)) {
                    if (confirm('We will remove the styles by pasting the content. Are you \'Ok\' to continue?')) {
                        after = after.replace(/<p><br><\/p>/gi, '#ParaSeparator#');
                        finalhtml = after.replace(strRegex, '');
                        finalhtml = finalhtml.replace(strRegextarget, '<$1 target="_blank"$2>');
                    }
                }
                else {
                    finalhtml = after;
                }
                finalhtml = finalhtml.replace(/#ParaSeparator#/gi, '<p><br><\/p>');
                finalhtml = finalhtml.replace(/#DivSeparator#/gi, '<div><br><\/div>');
                finalhtml = finalhtml.replace(/#BreakSeparator#/gi, '<br><br>');
                document.getElementById('<%=txtEditor1.ClientID %>').innerHTML = finalhtml
                $('#<%=txtEditor1.ClientID %> a').attr('style', '');

            }, 0);
        });

    } // END


</script>
<table cellpadding="0" cellspacing="0" style="border: 1px solid #EEECEC; background-color: #F8F6F6;">
    <tbody>
        <tr>
            <td align="right" style="padding: 5px 10px 0px 10px;">
                <asp:ImageButton ID="imcloseeditpopup" runat="server" OnClientClick="return CancelEditText();"
                    ImageUrl="images/popup_close.gif" />
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
                                        <telerik:RadToolBarDropDown Text="<%=hdnUserFont.Value %>">
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
                                        <telerik:RadToolBarDropDown Text="16px">
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
                                        <telerik:RadToolBarDropDown Text="Left">
                                            <Buttons>
                                                <telerik:RadToolBarButton Text="Left" Group="Align">
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton Text="Justify" Group="Align">
                                                </telerik:RadToolBarButton>
                                            </Buttons>
                                        </telerik:RadToolBarDropDown>
                                        <telerik:RadToolBarButton Text="A" Font-Underline="true" CommandName="A" CheckOnClick="true"
                                            AllowSelfUnCheck="true">
                                        </telerik:RadToolBarButton>
                                    </Items>
                                </telerik:RadToolBar>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id='txtEditor1' contenteditable="true" runat='server' style="width: 500px; height: 250px;
                                color: Black; font-size: 18px; font-weight: normal; font-style: normal; text-decoration: none;
                                font-family: Arial; line-height: normal; border: 1px solid lightgray; overflow: auto;
                                padding: 3px;">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <asp:HiddenField runat="server" ID="hdnEditHTML" />
            <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
            <input type="hidden" id='ids' value='' />
            <input type="hidden" id='htmlvalue' />
            <td style="padding-bottom: 5px; padding-right: 10px; text-align: right;">
                <asp:Button ID="btneditok" runat="server" Text="Submit" OnClientClick="return PopupSubmiteTxt();" />
                <asp:Button ID="btneditcancel" runat="server" Text="Cancel" OnClientClick="return CancelEditText();" />
            </td>
        </tr>
    </tbody>
</table>
