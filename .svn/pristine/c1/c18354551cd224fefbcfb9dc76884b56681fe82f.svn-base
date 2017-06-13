<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEditor.ascx.cs" Inherits="UserForms.UCEditor" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link href="../../css/repeatcal.css" rel="stylesheet" type="text/css" />
<script>
    function SaveLink() {
        var url = $('#txtUrl').val();
        if (url != "" && !/^https?:\/\//i.test(url)) {
            url = 'http://' + url;
        }
        if (ValidateUrl(url)) {
            var hidVal = $('#hdnValue').val();
            if (hidVal != "") {
                doRestore();
                document.execCommand("CreateLink", false, url);
                var links = getLinksInSelection();
            }
            else {
                doRestore();
                var str = $('#txtDisplay').val();
                var result = str.link(url);
                var mydiv = document.getElementById("<%=txtEditor1.ClientID %>");
                pasteHtmlAtCaret(result);
            }
            return true;
        }
    }
    function ShowDialog(modal) {
        $("#overlay").show();
        $("#dialog").fadeIn(300);
        if (modal) {
            $("#overlay").unbind("click");
        }
        else {
            $("#overlay").click(function (e) {
                HideDialog();
            });
        }
    }
    function HideDialog() {
        $('#txtUrl').val('');
        $('#txtDisplay').val('');
        $("#overlay").hide();
        $("#dialog").fadeOut(300);
    }
    function PopupSubmiteTxt() {
        if (document.getElementById("hdnChanges") != null) {
            document.getElementById("hdnChanges").value = "true";
        }
        //getting selected div ID
        var controlID = document.getElementById('ids').value;
        var plainText = document.getElementById("<%=txtEditor1.ClientID %>").innerHTML;
        htmlContent = document.getElementById('htmlvalue').value.replace("</span>", "");
        plainText = plainText.replace(/\n/gi, "<br/>");
        var strRegextarget = /<(a)([^>]+)>/gi;
        plainText = plainText.replace(strRegextarget, '<$1 target="_blank"$2>');
        if (htmlContent == "") {
            htmlContent = "<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 16px; font-family: " + document.getElementById('<%=hdnUserFont.ClientID %>').value + "; text-align: left; display: block;'>";
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
    function ShowPopup(value) {
        
        controlID = value.id;
        document.getElementById('ids').value = controlID;
        document.getElementById('editorPopup').style.display = 'block';
        document.getElementById('popup').style.display = 'block';
        var editHTML = document.getElementById(controlID).innerHTML;
        editHTML = editHTML.replace("begin_of_the_skype_highlighting", "");
        editHTML = editHTML.replace("&nbsp;FREE&nbsp;", "");
        editHTML = editHTML.replace("end_of_the_skype_highlighting", "");
        editHTML = editHTML.replace("&amp;", "&");
        if (editHTML.indexOf("text-align:") == -1) {
            editHTML = editHTML.replace("\">", " text-align: left; display: block;\">");
        }
        
        var plainText = editHTML.replace(/<\/?[^>]+>/, '');
        plainText = plainText.replace(/<\/span>/gi, "");
        //        plainText = plainText + "<div></div>" ;

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
        var w = $(window);
        $('.editorpopup').css({
            'position': 'fixed',
            'top': w.height() / 2 - $('.editorpopup').height() / 2 + "px",
            'left': w.width() / 2 - $('.editorpopup').width() / 2 + "px"
        });
        //Active bold etc buttons
        ButtonActive();
        TextBox_Height_Width_Adjust();
    }
    //Indivisual Textboxes
    function OnClientButtonClicking(toolbar, args) {
        var button = args.get_item();
        var commandName = button.get_commandName();
        var groupName = button.get_group();
        Mystring = document.getElementById('htmlvalue').value;
        Mystring = Mystring.replace("</span>", "");
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

            doSave();
            var displayText = saveSelectionValue();
            var linkurl = "";
            var $node = $(getSelectionStartNode());
            if ($node.is('a')) {
                displayText = $node.text();
                linkurl = $node.attr('href');
            }
            else {
                var isLink = itemIsLinked();
                if (isLink[0]) {
                    if (isLink[1].startContainer.parentNode.text != undefined) {
                        displayText = isLink[1].startContainer.parentNode.text;
                        linkurl = isLink[1].startContainer.parentNode.href;
                    }
                    else {
                        displayText = isLink[1].endContainer.parentNode.text;
                        linkurl = isLink[1].endContainer.parentNode.href;
                    }
                }
                else {
                    var html = displayText;
                    var el = document.getElementById("<%=txtEditor1.ClientID %>");
                    var range = window.getSelection().getRangeAt(0);
                    if (typeof window.getSelection != "undefined") {
                        var sel = window.getSelection();
                        if (sel.rangeCount) {
                            var container = document.createElement("div");
                            for (var i = 0, len = sel.rangeCount; i < len; ++i) {
                                container.appendChild(sel.getRangeAt(i).cloneContents());
                            }
                            html = container.innerHTML;
                        }
                    } else if (typeof document.selection != "undefined") {
                        if (document.selection.type == "Text") {
                            html = document.selection.createRange().htmlText;
                        }
                    }
                    if (html.indexOf('href=') !== -1) {

                        var match = /<a\s+[^>]*href="([^"]*)"[^>]*>(.*)<\/a>/i.exec(html);
                        linkurl = match[1];
                        displayText = match[2];
                    }
                }
            }
            $('#txtDisplay').val(displayText);
            $('#txtUrl').val(linkurl);
            $('#hdnValue').val(displayText);
            ShowDialog(true);
        }
        else if (commandName == "UL") {
            doSave();
            doRestore();
            document.execCommand('Unlink');
        }
        document.getElementById('htmlvalue').value = Mystring;
    }
    function itemIsLinked() {
        if (window.getSelection().toString() != "") {
            var selection = window.getSelection().getRangeAt(0);
            if (selection) {
                if (selection.startContainer.parentNode.tagName === 'A' || selection.endContainer.parentNode.tagName === 'A') {
                    return [true, selection];
                } else { return false; }
            } else { return false; }
        }
        else { return false; }
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
    /*Insert Customize Link*/
    function saveSelectionValue() {
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
            var range = document.selection.createRange();
            return range;
        }
        return null;
    }

    function getSelectionStartNode() {
        if (window.getSelection) { // should work in webkit/ff
            var node = window.getSelection().anchorNode;
            var startNode = (node.nodeName == "#text" ? node.parentNode : node);
            return startNode;
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



    var saveSelection, restoreSelection;

    if (window.getSelection && document.createRange) {

        saveSelection = function (containerEl) {
            var range = window.getSelection().getRangeAt(0);
            var preSelectionRange = range.cloneRange();
            preSelectionRange.selectNodeContents(containerEl);
            preSelectionRange.setEnd(range.startContainer, range.startOffset);
            var start = preSelectionRange.toString().length;

            return {
                start: start,
                end: start + range.toString().length
            }
        };



        restoreSelection = function (containerEl, savedSel) {
            var charIndex = 0, range = document.createRange();
            range.setStart(containerEl, 0);
            range.collapse(true);
            var nodeStack = [containerEl], node, foundStart = false, stop = false;

            while (!stop && (node = nodeStack.pop())) {
                if (node.nodeType == 3) {
                    var nextCharIndex = charIndex + node.length;
                    if (!foundStart && savedSel.start >= charIndex && savedSel.start <= nextCharIndex) {
                        range.setStart(node, savedSel.start - charIndex);
                        foundStart = true;
                    }
                    if (foundStart && savedSel.end >= charIndex && savedSel.end <= nextCharIndex) {
                        range.setEnd(node, savedSel.end - charIndex);
                        stop = true;
                    }
                    charIndex = nextCharIndex;
                } else {
                    var i = node.childNodes.length;
                    while (i--) {
                        nodeStack.push(node.childNodes[i]);
                    }
                }
            }

            var sel = window.getSelection();
            sel.removeAllRanges();
            sel.addRange(range);
        }
    } else if (document.selection && document.body.createTextRange) {
        saveSelection = function (containerEl) {
            var selectedTextRange = document.selection.createRange();
            var preSelectionTextRange = document.body.createTextRange();
            preSelectionTextRange.moveToElementText(containerEl);
            preSelectionTextRange.setEndPoint("EndToStart", selectedTextRange);
            var start = preSelectionTextRange.text.length;

            return {
                start: start,
                end: start + selectedTextRange.text.length
            }
        };

        restoreSelection = function (containerEl, savedSel) {
            var textRange = document.body.createTextRange();
            textRange.moveToElementText(containerEl);
            textRange.collapse(true);
            textRange.moveEnd("character", savedSel.end);
            textRange.moveStart("character", savedSel.start);
            textRange.select();
        };
    }

    var savedSelection;

    function doSave() {
        savedSelection = saveSelection(document.getElementById("<%=txtEditor1.ClientID %>"));

    }

    function doRestore() {
        if (savedSelection) {
            restoreSelection(document.getElementById("<%=txtEditor1.ClientID %>"), savedSelection);
        }
    }

    function pasteHtmlAtCaret(html) {
        var sel, range;
        if (window.getSelection) {
            // IE9 and non-IE
            sel = window.getSelection();
            if (sel.getRangeAt && sel.rangeCount) {
                range = sel.getRangeAt(0);
                range.deleteContents();
                // Range.createContextualFragment() would be useful here but is
                // non-standard and not supported in all browsers (IE9, for one)
                var el = document.createElement("div");
                el.innerHTML = html;
                var frag = document.createDocumentFragment(), node, lastNode;
                while ((node = el.firstChild)) {
                    lastNode = frag.appendChild(node);
                }
                range.insertNode(frag);
                // Preserve the selection
                if (lastNode) {
                    range = range.cloneRange();
                    range.setStartAfter(lastNode);
                    range.collapse(true);
                    sel.removeAllRanges();
                    sel.addRange(range);
                }
            }
        } else if (document.selection && document.selection.type != "Control") {
            // IE < 9
            document.selection.createRange().pasteHTML(html);
        }
    }
    function ValidateUrl(url) {
        var myRegExp = /^(?:(?:https?):\/\/)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3}){3})(?!127(?:\.\d{1,3}){3})(?!169\.254(?:\.\d{1,3}){2})(?!192\.168(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]+-?)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]+-?)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/[^\s]*)?$/i;
        var validmsg = "";
        if ($('#txtDisplay').val().trim() == "")
            validmsg = "Please enter text to display.\n\r";
        if (url != "") {
            if (!myRegExp.test(url))
                validmsg += "URL invalid. Try again.";
        }
        else
            validmsg += "Please enter a url to link.";
        if (validmsg == "")
            return true;
        else {
            alert(validmsg);
            return false;
        }
    }
    $(document).ready(function () {
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
                    if (confirm('All formatting will be removed. Select \'Ok\' to continue.')) {
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

        /*
        $('#<%=txtEditor1.ClientID %>').bind('keypress', function (e) {
        if (navigator.appVersion.indexOf("MSIE") != -1 || navigator.appVersion.indexOf("Trident") != -1 || navigator.appVersion.indexOf("Edge") != -1) {
        if (e.which == 13) {
        //e.preventDefault();
        //insert the paragraph after this element.
        //$(window.getSelection().anchorNode.parentNode).after("<div id='newParagraph'></div>");
        //pasteHtmlAtCaret("<div id='newParagraph'></div>");
        //                    if (window.getSelection) {
        //                        var selection = window.getSelection(),
        //                        range = selection.getRangeAt(0),
        //                        br = document.createElement("br"),
        //                        textNode = document.createTextNode("\u00a0"); //Passing " " directly will not end up being shown correctly
        //                        range.deleteContents(); //required or not?
        //                        range.insertNode(br);
        //                        range.collapse(false);
        //                        range.insertNode(textNode);
        //                        range.selectNodeContents(textNode);

        //                        selection.removeAllRanges();
        //                        selection.addRange(range);
        //                        return false;
        //                    }
        }
        }
        });

        */
        $("#btnClose").click(function (e) {
            HideDialog();
            e.preventDefault();
        });
        $("#btnCalCancel").click(function (e) {
            HideDialog();
            e.preventDefault();
        });
        $("#btnSubmit").click(function (e) {
            if (SaveLink()) {
                HideDialog();
                e.preventDefault();
            }
        });
    });
</script>
<input type="hidden" id="hdnValue" />
<div id="overlay" class="editor_dialog_overlay">
</div>
<div id="dialog" class="editor_dialog">
    <div>
        <div class="ed-headerrow">
            <span class="ed-header-title">Edit Link</span><a id="btnClose" class="modalCloseImg"
                title="Close"></a></div>
        <div class="ed-recl-dialog">
            <div class="ed-recl-dialog-content">
                <div>
                    <table class="ed-rec">
                        <tbody>
                            <tr tabindex="0">
                                <th>
                                    Text to display:
                                </th>
                                <td>
                                    <input type="text" style="width: 300px" id="txtDisplay" />
                                </td>
                            </tr>
                            <tr>
                                <th class="ed-rec-ends-th">
                                    Link to :
                                </th>
                                <td>
                                    <input type="text" style="width: 400px" id="txtUrl" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                </th>
                                <td class="ed-rec-buttons-padding">
                                    <div>
                                        <input id="btnSubmit" type="button" value="Ok" />
                                        <input id="btnCalCancel" type="button" value="Cancel" />
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
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
                                                 <telerik:RadToolBarButton Text="Brown" Group="Color" Value="rgb(93, 73, 4)">
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton Text="Gold" Group="Color" Value="rgb(214, 177, 56)">
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
                                        <telerik:RadToolBarButton ImageUrl="../../images/Link.png" CommandName="A" CheckOnClick="true"
                                            ToolTip="link" AllowSelfUnCheck="true">
                                        </telerik:RadToolBarButton>
                                        <telerik:RadToolBarButton ImageUrl="../../images/Unlink1.png" CommandName="UL" CheckOnClick="true"
                                            ToolTip="Unlink" AllowSelfUnCheck="true">
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
