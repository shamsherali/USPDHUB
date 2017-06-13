<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WordContentTemplate.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.WordContentTemplate" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body style="font-family: Segoe UI; font-size: 14px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
            <script src="../../Scripts/flyers/jquery.ui.core.js" type="text/javascript"></script>
            <script src="../../Scripts/flyers/jquery.ui.widget.js" type="text/javascript"></script>
            <script src="../../Scripts/flyers/jquery.ui.mouse.js" type="text/javascript"></script>
            <script src="../../Scripts/flyers/jquery.ui.sortable.js" type="text/javascript"></script>
            <script src="../../Scripts/flyers/jquery.ui.droppable.js" type="text/javascript"></script>
            <script src="../../Scripts/flyers/jquery.ui.draggable.js" type="text/javascript"></script>
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

                    $("#divLoading").css("display", "none");
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

                    $("#divLoading").css("display", "block");

                    if (selectedFiles != null) {
                        if (selectedFiles.length > 0) {

                            var xhr = new XMLHttpRequest();

                            xhr.open('POST', '/Business/MyAccount/UploadWordContent.ashx?PID=' + '<%=ProfileID %>');
                            xhr.onload = function () {
                                if (xhr.status === 200) {
                                    //alert('all done: ' + xhr.status);

                                    //$("#divLoading").css("display", "none");

                                    var reponse = xhr.response;
                                    $("#<%=hdnFileName.ClientID %>").val("");
                                    $("#<%=hdnFileName.ClientID %>").val(reponse);
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
                            $("#divLoading").css("display", "none");
                            alert("Please select atleast one file to upload.");
                        }
                        return false;
                    }
                }


                //RedirectoParentWIndow
                function RedirectToParentWindow() {
                    var lblEditText = parent.document.getElementById("maintable").outerHTML;
                    var htmlRowResult = document.getElementById("<%=hdnHTMLResult.ClientID %>").value;

                    parent.$("#maintable").append(htmlRowResult);

                    parent.LoadBlocks();
                    parent.$(".avatar").animate({ scrollTop: parent.$(".avatar").prop("scrollHeight") }, 1000);

                    $("#divLoading").css("display", "none");
                    parent.$find('WordContentPreview').hide();


                }

            </script>
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
                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
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
                    <div style="width: 700px; margin: 0px 0px 0px 0px;">
                        <div style="text-align: right; float: left">
                            <table border="0" style="border: 2px solid lightblue; width: 585px;">
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
                                                <img src="<%=Page.ResolveClientUrl("~/Images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                                    color="green">Processing....</font></b>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center;">
                                        <span class="profile-caption red-color">NOTE: Please use .doc or .docx only.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:LinkButton runat="server" ID="btnUpload" Text="Upload" CssClass="btn" OnClientClick="return UploadFiles();"
                                            OnClick="btnUpload_OnClick"></asp:LinkButton>
                                        <asp:Button runat="server" ID="btnUploadDummmy" OnClick="btnUpload1_OnClick" Style="display: none;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                    </td>
                                </tr>
                            </table>
                            <input type="hidden" id="hdnType" value="1" />
                            <asp:HiddenField runat="server" ID="hdnFileName" />
                            <asp:HiddenField runat="server" ID="hdnHTMLResult" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
