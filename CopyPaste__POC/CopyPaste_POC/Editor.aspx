<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="CopyPaste_POC.Editor"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UCEditor.ascx" TagName="UCEditor" TagPrefix="uc2" %>
<%@ Register Src="UCPayPalEditor.ascx" TagName="UCPayPalEditor" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body style="font-family: Segoe UI; font-size: 14px;">
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <script src="flyers/jquery-1.7.2.js" type="text/javascript"></script>
            <script src="flyers/jquery.ui.core.js" type="text/javascript"></script>
            <script src="flyers/jquery.ui.widget.js" type="text/javascript"></script>
            <script src="flyers/jquery.ui.mouse.js" type="text/javascript"></script>
            <script src="flyers/jquery.ui.sortable.js" type="text/javascript"></script>
            <script src="flyers/jquery.ui.droppable.js" type="text/javascript"></script>
            <script src="flyers/jquery.ui.draggable.js" type="text/javascript"></script>
            <script type="text/javascript">

                //***Added for showing watermark symbol if AbousUs content Empty 06/19/2013.***//
                function ShowPublish(val) {
                    if (document.getElementById('<%= lblEditText.ClientID%>').innerHTML == "") {
                        document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
                    }
                }

                $(function () {
                    $(".drop").sortable({
                        connectWith: ".drop",
                        scrollSpeed: 5
                    });

                    $(".drop").disableSelection();
                });


                function ShowPreview() {

                    var divCount = $("#maintable div").size();
                    if (divCount > 0) {


                        PreviewHTML();
                        var HtmlBody = document.getElementById("<%=hdnPreviewHTML.ClientID %>").value;


                        // Shorten URL Purpose
                        document.getElementById("divLoading").style.display = "block";


                        document.getElementById("<%=lblPreviewHTML.ClientID %>").innerHTML = "";
                        var myBehavior = $find("popupop");
                        $get('<%=lblPreviewHTML.ClientID %>').innerHTML = HtmlBody;
                        myBehavior.show();

                        document.getElementById("divLoading").style.display = "none";

                        return false;

                    }
                    else {
                        alert("You haven't built your content yet.");
                        return false;
                    }
                }

                function SaveContent() {
                    if ($("#<%=txtContentTitle.ClientID %>").val() == "") {
                        alert("Please enter the Content Title.");
                        return false;
                    }
                    else {
                        PreviewHTML();
                        return true;
                    }
                }

                var EntID = "";

                function PreviewHTML() {
                    document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = "";
                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";

                    var trs = '';
                    var tds = '';
                    var getHTML = '';
                    var imgTag = '';

                    var divCount = $("#maintable div").size();
                    if (divCount > 0) {
                        var divtable = document.getElementById("maintable");

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
                                                tds = tds + "<tr><td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align: left;'>" + getHTML + " </td></tr>";
                                            }
                                            else {
                                                var imgAlignment = document.getElementById(id).style.textAlign;
                                                tds = tds + "<tr><td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align:" + imgAlignment + ";'>" + getHTML + "</td></tr>";
                                            }

                                        } // getHTML
                                    } // If divTable
                                } //for k
                            } // for j
                        } // for i

                        var PreviewHTML = "<table style='margin-left:20px; border:1px solid black;' border='0'  >" + tds + "</table>";
                        document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = PreviewHTML;
                        document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                    }

                }

                function AddBlocks(blockname) {

                    if (document.getElementById('maintable') == null) {
                        var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"460px\" style=\"border: 0px solid gray; " +
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
                        editingBlock = "<img src='Images/EditText.png'  style='cursor: pointer; margin-left:5px;' onclick='ShowPopup(edit" + CID + ")' />";
                    }
                    else if (blockname == "DIV_IMAGE") {
                        editingBlock = "<img  src='Images/EditImage.png'  style='cursor: pointer; margin-left:5px;' onclick='EditImage(edit" + CID + ")' />";
                    }
                    else if (blockname == "DIV_PAYPAL") {
                        editingBlock = "<img  src='Images/editpaypalbtn.png'  style='cursor: pointer; margin-left:5px;' onclick='ShowPayPalPopup(edit" + CID + ")' />";
                    }

                    var newRow = "<tr id='tr" + CID + "' >" +
                            "<td class='drop ui-sortable' style='min-height: 20px;'>" +
                                " <div id='parentedit" + CID + "' style='float: left; margin-top: 10px;' class='assigned' >" +
                                       "<div id='edit" + CID + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >" +
                                       "</div>" +
                                        "<div id='editsection" + CID + "' class='editsectionclass' style='float:left;' >" + editingBlock +
                                          "<br/><img class='deleteblockclass'  src='Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + CID + ")' />" +
                                        "</div>" +
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
                    $(".avatar").animate({ scrollTop: $(".avatar").prop("scrollHeight") }, 1000);
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

                    ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 12) + "&imgSrc=" + imgSrc);
                    ifrm.style.height = "750px";
                    ifrm.style.width = "100%";
                    ifrm.style.border = "0px";
                    ifrm.scrolling = "no";
                    ifrm.frameBorder = "0";
                    document.getElementById('DIDIFrm').appendChild(ifrm);
                    document.getElementById('editDivCheck').value = imgdivID;

                    var modalDialog = $find("popupimage");
                    modalDialog.show();

                }

                function RemoveBlock(value) {
                    var divID = value.id;
                    var idNumber = divID.replace("edit", "");
                    divID = "parent" + divID;
                    if (confirm("Are you sure you want to delete this block?")) {
                        var childdivsCount = $("#tr" + idNumber + " div").size();
                        $("#" + divID).remove();
                        if (childdivsCount == 3) {
                            $("#tr" + idNumber).remove();
                        }

                    }

                    var divCount = $("#maintable div").size();
                    if (divCount <= 0) {
                        document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
                    }
                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
                    if (document.getElementById("maintable") != null) {
                        document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
                    }
                }

                function highlightdiv(divID) {
                    //document.getElementById(divID).style.border = "2px solid blue";
                    $('#' + divID).select();
                }
                function RemoveHightlight(divID) {
                    document.getElementById(divID).style.border = "1px solid black";
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
                    font-size: 16px;
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
                    margin-top: 50px;
                    height: 100px;
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
                    top: 42%;
                    left: 72%;
                    margin-left: 3px;
                    vertical-align: top;
                }
                
                .stepswrap
                {
                    overflow: hidden;
                    margin: 0 auto;
                    width: 488px;
                    position: relative;
                    color: #2F348F;
                }
                .stepswrap0
                {
                    width: 468px;
                }
                .stepswrap1
                {
                    overflow: hidden;
                    margin: 4px auto;
                    width: 468px;
                    border: 1px solid #ccc;
                    color: #2F348F;
                    padding: 5px 10px 5px 5px;
                    min-height: 150px;
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
                    height: 50px !important;
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
            <style>
                .drop div:hover
                {
                    cursor: move;
                }
            </style>
            <style>
                body
                {
                    padding: 10px;
                    font: 14px/18px Calibri;
                }
                .bold
                {
                    font-weight: bold;
                }
                td
                {
                    padding: 5px;
                }
                p, output
                {
                    margin: 10px 0 0 0;
                }
                #drop_zone
                {
                    padding: 10px;
                    width: 400px;
                    overflow: auto;
                    text-align: left;
                    text-transform: uppercase;
                    font-weight: bold;
                    border: 3px dashed #898;
                    height: 50px;
                }
                .btn
                {
                    -webkit-border-radius: 3;
                    -moz-border-radius: 3;
                    border-radius: 3px;
                    font-family: Arial;
                    color: #ffffff;
                    font-size: 15px;
                    background: #3498db;
                    padding: 10px 20px;
                    text-decoration: none;
                    font-weight: normal;
                    display: inline-block;
                }
                
                .btn:hover
                {
                    background: #3cb0fd;
                    text-decoration: none;
                }
                
                .btnorange
                {
                    -webkit-border-radius: 3;
                    -moz-border-radius: 3;
                    border-radius: 3px;
                    font-family: Arial;
                    color: #ffffff;
                    font-size: 15px;
                    background: #DC7224;
                    padding: 10px 20px;
                    color: #fff !important;
                    text-decoration: none !important;
                    font-weight: normal;
                }
                
                .btnorange:hover
                {
                    background: #3cb0fd;
                    text-decoration: none;
                }
                
                .btnsave
                {
                    background: url(images/button_bg.gif) repeat-x;
                    height: 37px;
                    float: left;
                    border: 1px solid #dcdcdc;
                    margin: 0px 6px 0px 0px;
                    cursor: hand;
                    cursor: pointer;
                    padding: 0px 20px;
                    font-size: 16px; /* color: #464646; */
                    -moz-border-radius: 4px;
                    -webkit-border-radius: 4px;
                    border-radius: 4px;
                    -khtml-border-radius: 4px;
                    text-shadow: 1px 1px 1px #f2f2f2;
                }
            </style>
            <script type="text/javascript">

                function LoaddropzoneEvents() {

                    var target = document.getElementById("drop_zone");
                    target.addEventListener("dragenter", OnDragEnter, false);
                    target.addEventListener("dragover", OnDragOver, false);
                    target.addEventListener("drop", OnDrop, false);

                    $(".drop").sortable({
                        connectWith: ".drop",
                        scrollSpeed: 5
                    });

                    $(".drop").disableSelection();

                }


                function fileuploadOnchange(vfilePath) {
                    var _validFileFlag = false;
                    document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML = '';
                    var reg = /([^\s]+(?=.(doc|docx)).\2)/gm;
                    if (reg.test(vfilePath) == false) {
                        document.getElementById("<%= fileupload.ClientID %>").value = '';
                        document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML = "<font color='red'>Your file is not in the correct file format; please use .doc or .docx only.</font>";
                    }
                    else {
                        document.getElementById("hdnType").value = "1";
                        document.getElementById("drop_zone").style.display = "none";
                        $("#trOR").css("display", "none");
                    }
                }

                window.onload = function () {
                    //alert(1);
                    LoaddropzoneEvents();


                }

                function OnDragEnter(e) {
                    e.stopPropagation();
                    e.preventDefault();
                }

                function OnDragOver(e) {
                    e.stopPropagation();
                    e.preventDefault();
                }

                var selectedFiles;
                var data = new FormData();

                function OnDrop(e) {
                    //alert(1);
                    e.stopPropagation();
                    e.preventDefault();
                    document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML = '';
                    selectedFiles = e.dataTransfer.files;
                    if (selectedFiles.length > 1) {
                        return alert("Multiple files are not support.");
                    }
                    // || fileExtension == ".jpg" || fileExtension == ".JPG" || fileExtension == ".JPEG"
                    //|| fileExtension == ".jpeg" || fileExtension == ".GIF" || fileExtension == ".gif"
                    //|| fileExtension == ".png" || fileExtension == ".PNG || fileExtension == ".pdf"
                    var fileName = selectedFiles[0].name;
                    var fileExtension = fileName.substr(fileName.lastIndexOf("."), fileName.length).toLowerCase();
                    if (fileExtension == ".doc" || fileExtension == ".docx") {                        
                        data = new FormData();
                        document.getElementById("hdnType").value = "2";
                        document.getElementById("truploadFile").style.display = "none";
                        $("#trOR").css("display", "none");

                        for (var i = 0; i < selectedFiles.length; i++) {
                            data.append(selectedFiles[i].name, selectedFiles[i]);
                        }

                        $("#drop_zone").innerHTML = "";
                        $("#drop_zone").text("");


                        for (i = 0; i < selectedFiles.length; i++) {
                            $("#drop_zone").append(selectedFiles[i].name + "</br>");
                        }
                    }
                    else {
                        document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML = "<font color='red'>Your file is not in the correct file format; please use .doc or .docx only.</font>";
                        return;
                    }

                }


                function UploadFiles() {
                    if (selectedFiles != null) {
                        if (selectedFiles.length > 0) {

                            $("#divLoading").css("display", "block");

                            var xhr = new XMLHttpRequest();

                            xhr.open('POST', 'UploadImages.ashx?PID=' + '<%=ProfileID %>');
                            xhr.onload = function () {
                                if (xhr.status === 200) {
                                    //alert('all done: ' + xhr.status);

                                    $("#divLoading").css("display", "none");

                                    var reponse = xhr.response;
                                    $("#<%=hdnImgName.ClientID %>").val("");
                                    $("#<%=hdnImgName.ClientID %>").val(reponse);
                                    LoaddropzoneEvents();
                                    $("#<%=btnUploadDummmy.ClientID %>").click();

                                    selectedFiles = null;

                                } else {
                                    alert('Something went terribly wrong...');
                                }
                            };

                            xhr.send(data);

                        }
                        else {
                            alert("Please select atleast one file to upload.");
                        }
                        return false;
                    }
                }
            </script>
            <div id="popup" style="display: none;">
            </div>
            <div id='editorPopup' style="display: none; position: fixed; margin-top: 150px; margin-left: 150px;
                z-index: 100;">
                <uc2:UCEditor ID="UCEditor1" runat="server" />
            </div>
            <div id='paypalPopup' style="display: none; position: fixed; margin-top: 150px; margin-left: 150px;
                z-index: 100;">
                <uc3:UCPayPalEditor id="UCPayPalEditor1" runat="server" />
            </div>
            <div id="wrapper">
                <div class="headernav">
                    <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                        Style="border: 0; border-color: White!important;"></asp:TextBox>
                </div>
                <div style="text-align: center;">
                    <asp:Label ID="lblerror" runat="server" ForeColor="Green" Font-Size="14px"></asp:Label>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                        <ProgressTemplate>
                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                size="2">Processing....</font></b>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div id="divLoading" style="display: none; width: 300px; margin: 0 auto;">
                        <div style="text-align: center;">
                            <img src="<%=Page.ResolveClientUrl("images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                color="green">Processing....</font></b>
                        </div>
                    </div>
                    <div style="width: 300px; margin: 0 auto;">
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                            ValidationGroup="group" HeaderText="The following error(s) occurred:" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="contentwrap">
                    <div style="width: 700px; margin: 0px 0px 0px 212px;">
                        <div style="text-align: right; float: left">
                            <table border="0" style="border: 2px solid lightblue; width: 650px;">
                                <colgroup>
                                    <col width="200px" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="lblerrormsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <div id="drop_zone">
                                            Drop file here</div>
                                    </td>
                                </tr>
                                <tr id="trOR">
                                    <td align="center" colspan="2">
                                        <b>(OR )</b>
                                    </td>
                                </tr>
                                <tr id="truploadFile">
                                    <td>
                                        <strong>Upload File: </strong>
                                    </td>
                                    <td align="left">
                                        <asp:FileUpload ID="fileupload" runat="server" onchange="fileuploadOnchange(this.value);" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Panel runat="server" ID="pnlShowLoader" Style="display: none;">
                                            <div style="text-align: center;">
                                                <img src="<%=Page.ResolveClientUrl("Images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                                    color="green">Processing....</font></b>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:LinkButton runat="server" ID="btnUpload" Text="Upload" CssClass="btn" OnClick="btnUpload_OnClick"
                                            OnClientClick="return UploadFiles();"></asp:LinkButton>
                                        <asp:Button runat="server" ID="btnUploadDummmy" OnClick="btnUpload1_OnClick" Style="display: none;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Panel runat="server" ID="pnlPDFOption" Visible="false" Width="500px" Style="margin-top: 10px;">
                                            <div style="border: 1px solid black; padding: 10px;">
                                                <div>
                                                    <asp:RadioButton runat="server" ID="RBConvertoContent" Text="Convert to Content"
                                                        GroupName="groupConvert" Checked="true" />
                                                    &nbsp;
                                                    <asp:RadioButton runat="server" ID="RBConvertImages" Text="Convert to Images" GroupName="groupConvert" /></div>
                                                <br />
                                                <asp:LinkButton runat="server" ID="btnProccedPDF" Text="Procced" CssClass="btnorange"
                                                    OnClick="btnProccedPDF_OnClick"></asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton runat="server" ID="lnkCancelProcced" Text="Cancel" CssClass="btn"
                                                    OnClick="lnkCancelProcced_OnClick"></asp:LinkButton>
                                                <br />
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <input type="hidden" id="hdnType" value="1" />
                            <asp:HiddenField runat="server" ID="hdnImgName" />
                            <asp:HiddenField runat="server" ID="hdnCustModuleTemplateID" />
                            <asp:HiddenField runat="server" ID="hdnModuleTemplateID" />
                        </div>
                        <div class="stepswrap0" style="float: left; margin-top: 15px;">
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <font color="red"></font>
                                    <label>
                                    </label>
                                </div>
                                <div style="text-align: right; float: left">
                                    <b>Module Name: </b>
                                    <asp:DropDownList ID="ddlContentModuleNames" runat="server" Width="250px">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="fields_wrap" style="margin-top: 30px;">
                                <div class="left_lable">
                                    <font color="red"></font>
                                    <label>
                                    </label>
                                </div>
                                <div style="text-align: right; float: left">
                                    <b>Content Title: &nbsp;</b>
                                    <asp:TextBox ID="txtContentTitle" runat="server" Width="250px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="stepswrap1" style="float: left; margin-top: 15px;">
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <font color="red"></font>
                                    <label>
                                    </label>
                                </div>
                                <div style="text-align: right; float: left">
                                    <div class="avatar" style="border-width: 0px; min-height: 50px; width: 478px; display: block;
                                        max-height: 400px; overflow: auto;">
                                        <asp:Label ID="lblEditText" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="text-align: right; float: left; margin: 16px 0px 0px 10px;">
                            <img style="cursor: pointer;" onclick="AddBlocks('DIV_TEXT');" src="Images/addnewtext.png" />
                            <br />
                            <br />
                            <img style="cursor: pointer;" onclick="AddBlocks('DIV_IMAGE');" src="../../Images/addnewimg.png" />
                           <%-- <br />
                            <br />
                            <img style="cursor: pointer;" onclick="AddBlocks('DIV_PAYPAL');" src="../../Images/AddPaypalbtn.png" />--%>
                        </div>
                        <br />
                        <div class="fields_wrap" style="width: 500px;">
                            <div class="left_lable">
                            </div>
                            <div class="right_fields" style="margin: 10px 0px 0px 0px;">
                                <asp:Button ID="BtnSave" runat="server" Text="Submit" ValidationGroup="ABC" OnClientClick="return SaveContent();"
                                    border="0" CssClass="btnsave" OnClick="BtnSave_OnClick" />
                                <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return ShowPreview();">
                                        <img src="images/preview.png" width="100" height="37"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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
                                                        <img src="images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 20px; padding-top: 10px" align="right">
                                                <asp:ImageButton ID="imglogin5" OnClientClick="return false;" runat="server" CausesValidation="false"
                                                    ImageUrl="images/popup_close.gif"></asp:ImageButton>
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
            <input type="hidden" id="hdnChanges" value="false" />
            <asp:HiddenField runat="server" ID="hdnEditHTML" />
            <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
            <asp:HiddenField runat="server" ID="hdnPermissionType" />
            <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
