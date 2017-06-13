<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="MasterGallery.aspx.cs" Inherits="USPDHUB.Business.MyAccount.MasterGallery"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="../../Scripts/jquery.lightbox-0.5.js" type="text/javascript"></script>
    <link href="../../css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.Jcrop.js" type="text/javascript"></script>
    <link href="../../css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <style>
        .rounded-cornersBox
        {
            background-color: #DFE7F6;
            border: 1px solid #BED1F4;
            margin-left: 4px;
            font-family: arial;
            font-size: 12px;
            line-height: 25px;
        }
        .rounded-cornersBox td.title
        {
            font-weight: bold;
            color: #060C49;
            font-size: 20px;
        }
        .rounded-cornersBox td.title1
        {
            font-weight: bold;
            color: #060C49;
            font-size: 20px;
            border-right: 1px solid #BED1F4;
            vertical-align: top;
            padding-left: 10px;
        }
        #drop_zone
        {
            padding: 10px;
            width: 400px;
            min-height: 100px;
            max-height: 200px;
            overflow: auto;
            text-align: left;
            text-transform: uppercase;
            font-weight: bold;
            border: 1px solid #005AA0;
            outline: 0px;
        }
        .clear20
        {
            clear: both;
            height: 20px;
        }
        
        .btnnew
        {
            background: #007ad1;
            background-image: -webkit-linear-gradient(top, #007ad1, #005ba0);
            background-image: -moz-linear-gradient(top, #007ad1, #005ba0);
            background-image: -ms-linear-gradient(top, #007ad1, #005ba0);
            background-image: -o-linear-gradient(top, #007ad1, #005ba0);
            background-image: linear-gradient(to bottom, #007ad1, #005ba0);
            -webkit-border-radius: 4;
            -moz-border-radius: 4;
            border-radius: 4px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            padding: 10px 20px 10px 20px;
            border: solid #1f628d 0px;
            text-decoration: none;
            margin: 5px 0px;
            letter-spacing: 0.5px;
            cursor: pointer;
        }
        
        .btnnew:hover
        {
            background: #3cb0fd;
            background-image: -webkit-linear-gradient(top, #3cb0fd, #3498db);
            background-image: -moz-linear-gradient(top, #3cb0fd, #3498db);
            background-image: -ms-linear-gradient(top, #3cb0fd, #3498db);
            background-image: -o-linear-gradient(top, #3cb0fd, #3498db);
            background-image: linear-gradient(to bottom, #3cb0fd, #3498db);
            text-decoration: none;
            letter-spacing: 0.5px;
            cursor: pointer;
        }
        
        
        .btnneworange
        {
            background: #3cb0fd;
            background-image: -webkit-linear-gradient(top, #ffb45e, #d57300);
            background-image: -moz-linear-gradient(top, #ffb45e, #d57300);
            background-image: -ms-linear-gradient(top, #ffb45e, #d57300);
            background-image: -o-linear-gradient(top, #ffb45e, #d57300);
            background-image: linear-gradient(to bottom, #ffb45e, #d57300);
            -webkit-border-radius: 4;
            -moz-border-radius: 4;
            border-radius: 4px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            padding: 10px 20px 10px 20px;
            border: solid #f7b100 0px;
            text-decoration: none;
            margin: 5px 0px;
            letter-spacing: 0.5px;
            cursor: pointer;
        }
        
        .btnneworange:hover
        {
            background: #d57300;
            background-image: -webkit-linear-gradient(top, #d57300, #d57300);
            background-image: -moz-linear-gradient(top, #d57300, #d57300);
            background-image: -ms-linear-gradient(top, #d57300, #d57300);
            background-image: -o-linear-gradient(top, #d57300, #d57300);
            background-image: linear-gradient(to bottom, #d57300, #d57300);
            text-decoration: none;
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">

        $(function () {
            $('#gallery a').lightBox();
        });

        function displaypanel() {

            LoaddropzoneEvents();
            $('#gallery a').lightBox();

            $("[id$='cbSelectAll']").click(
             function () {
                 $("[id$='dtlistImages'] INPUT[type='checkbox']").attr('checked', $("[id$='cbSelectAll']").is(':checked'));
             });

            if (document.getElementById("<%=rbSingleUpload.ClientID %>").checked == true)
                ShowUploadPanel(1);
            else
                ShowUploadPanel(2);
        }

        function LoadImgSettings(imgWidth, imgHeight) {
            $('#imgMain').Jcrop({
                onSelect: getcroparea,
                setSelect: [0, 0, imgWidth, imgHeight],
                minSize: [50, 50],
                maxSize: [imgWidth, imgHeight],
                allowResize: true

            });
        }

        function getcroparea(c) {
            document.getElementById("<%=hdnx.ClientID %>").value = c.x;
            document.getElementById("<%=hdny.ClientID %>").value = c.y;
            document.getElementById("<%=hdnw.ClientID %>").value = c.w;
            document.getElementById("<%=hdnh.ClientID %>").value = c.h;
        };

    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            $("[id$='cbSelectAll']").click(
             function () {
                 $("[id$='dtlistImages'] INPUT[type='checkbox']").attr('checked', $("[id$='cbSelectAll']").is(':checked'));
             });

        });


        $(function () {
            $("[id*=TVAlbums] input[type=checkbox]").bind("click", function () {
                var table = $(this).closest("table");
                if (table.next().length > 0 && table.next()[0].tagName == "DIV") {
                    //Is Parent CheckBox
                    var childDiv = table.next();
                    var isChecked = $(this).is(":checked");
                    $("input[type=checkbox]", childDiv).each(function () {
                        if (isChecked) {
                            $(this).attr("checked", "checked");
                        } else {
                            $(this).removeAttr("checked");
                        }
                    });
                } else {
                    //Is Child CheckBox
                    var parentDIV = $(this).closest("DIV");
                    if ($("input[type=checkbox]", parentDIV).length == $("input[type=checkbox]:checked", parentDIV).length) {
                        $("input[type=checkbox]", parentDIV.prev()).attr("checked", "checked");
                    } else {
                        $("input[type=checkbox]", parentDIV.prev()).removeAttr("checked");
                    }
                }
            });


        })

        function ProgressBar() {
            document.getElementById("<%=lblMessage.ClientID %>").innerHTML = "";
            var filename = document.getElementById('<%=txtimagname.ClientID %>').value;
            if (filename.toString().substring(filename.length - 1) == ".") {
                alert("This file name format is not supported.");
                return false;
            } else if (filename.toString().indexOf("%") > -1) {
                alert("This file name not allowed % character.");
                return false;
            } else if (filename.toString().indexOf("#") > -1) {
                alert("The special character # not allowed in file name.");
                return false;
            }

            if ((document.getElementById('<%=SingleFileUploadControl.ClientID %>').value != "") && (document.getElementById('<%=txtimagname.ClientID %>').value != "")) {
                ShowProgressBar('2');
            }
            else {
                if ((document.getElementById('<%=SingleFileUploadControl.ClientID %>').value == "") && (document.getElementById('<%=txtimagname.ClientID %>').value == "")) {
                    alert('Please select an image to upload and enter an image name.');
                }
                else if (document.getElementById('<%=SingleFileUploadControl.ClientID %>').value == "") {
                    alert('Please select an image to upload.');
                }
                else {
                    alert('Please enter an image name.');
                }
                return false;
            }
        }

        function ShowProgressBar(Value) {
            if (Value == "1") {
                document.getElementById("DivImageGallery").style.display = "block";
            }
            else {
                document.getElementById("divUpload").style.display = "block";
            }
            return true;
        }

        function ShowUploadPanel(value) {
            //document.getElementById("<%=lblMessage.ClientID %>").innerHTML = "";
            document.getElementById("<%=hdnUploadingType.ClientID %>").value = "Browse";
            if (value == 1) {
                $("#divSingleUpload").css("display", "block");
                $("#divMultipleUpload").css("display", "none");
            }
            else {
                $("#divSingleUpload").css("display", "none");
                $("#divMultipleUpload").css("display", "block");
            }

            document.getElementById("drop_zone").style.display = "block";
        }

        function DeleteAlbum() {
            /*
            var selectedcount = 0;
            var TargetBaseControl = document.getElementById('<%= this.TVAlbums.ClientID %>');
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
            if (Inputs[iCount].type == 'checkbox') {
            if (Inputs[iCount].checked) {
            selectedcount += 1;
            if (selectedcount > 1)
            break;
            }
            }
            }

            if (selectedcount == 0) {
            alert("Please select at least one album.");
            return false;
            }
            else {
            return confirm("Are you sure you want to delete select album(s)?");
            }

            */
            return confirm("Are you sure you want to delete select album?");
            return true;
        }

        function ValidateUploadFileToAlbum() {
            document.getElementById("<%=lblMessage.ClientID %>").innerHTML = "";
            /*
            var selectedcount = 0;
            var TargetBaseControl = document.getElementById('<%= this.TVAlbums.ClientID %>');
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
            if (Inputs[iCount].type == 'checkbox') {
            if (Inputs[iCount].checked) {
            selectedcount += 1;
            if (selectedcount > 1)
            break;
            }
            }
            }

            if (selectedcount == 0) {
            alert("Please select at least one album.");
            return;
            }
            else if (selectedcount > 1) {
            alert("Multiple selections are not allowed.");
            }
            else {
            return true;
            }

            */

            if (document.getElementById("<%=hdnAlbumID.ClientID %>").value == "0") {
                alert("Please select your album.");
                return false;
            }
            else {
                ShowProgressBar(2);
                if (document.getElementById("<%=rbSingleUpload.ClientID %>").checked == true) {
                    if (document.getElementById("<%=hdnUploadingType.ClientID %>").value == "Browse") {
                        if (Page_ClientValidate('ABC')) {
                            return true;
                        }
                        else {
                            document.getElementById("divUpload").style.display = "none";
                            return false;
                        }
                    }
                    else {
                        return UploadFiles();
                    }
                } // end Single Upload checking
                else {
                    if (document.getElementById("<%=hdnUploadingType.ClientID %>").value == "Drop") {
                        return UploadFiles();
                    }
                    else {
                        return true;
                    }
                }
            }
        }

        function SetFileName() {
            var arrFileName = document.getElementById('<%= SingleFileUploadControl.ClientID %>').value.split('\\');
            var imageName = arrFileName[arrFileName.length - 1].replace(".jpeg", "").replace(".jpg", "").replace(".gif", "").replace(".png", "");
            imageName = imageName.replace("%", "");
            imageName = imageName.replace("#", "");
            document.getElementById('<%= txtimagname.ClientID %>').value = imageName;
            document.getElementById("<%=hdnUploadingType.ClientID %>").value = "Browse";
            document.getElementById("<%=btnClearDropFiles.ClientID %>").style.display = "none";
            document.getElementById("<%=lblMessage.ClientID %>").innerHTML = "";
            fileuploadOnchange();
        }

        function DeleteImagesValidations() {
            var selectedcount = 0;
            var TargetBaseControl = document.getElementById('<%= this.dtlistImages.ClientID %>');
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox') {
                    if (Inputs[iCount].checked) {
                        selectedcount += 1;
                        if (selectedcount > 1)
                            break;
                    }
                }
            }

            if (selectedcount == 0) {
                alert("Please select at least one image.");
                return false;
            }
            else {
                return confirm("Are you sure you want to delete select image(s)?");
            }
        }

        function ShowNewAlbumWindow() {

            document.getElementById("<%=txtAlbumName.ClientID %>").value = "";
            var modal = $find("NewAlbumPreview");
            modal.show();
            return false;
        } //

        function ValidateImgSelection() {

            var selectedcount = 0;
            var TargetBaseControl = document.getElementById('<%= this.dtlistImages.ClientID %>');
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox') {
                    if (Inputs[iCount].checked) {
                        selectedcount += 1;
                        if (selectedcount > 1)
                            break;
                    }
                }
            }

            if (selectedcount == 0) {
                alert("Please select at least one image.");
                return false;
            }
            else if (selectedcount > 1) {
                alert("Multiple selections are not allowed.");
                return false;
            }
            else {
                return true; ;
            }
        } //


        function ValidateOrderNumber(typeValue) {
            if (Page_ClientValidate('IMGOD')) {
                if (document.getElementById('<%=txteditordernumber.ClientID %>').value.toString().substring(0, 1) == "0") {
                    alert("Please enter the ordering number greater than 0 value.");
                    return false;
                }

                if (typeValue == 1) {
                    //ShowProgressBar();
                }
            }
            else
                return false;


        }

    </script>
    <style type="text/css">
        .datalist
        {
        }
        .datalist td
        {
            vertical-align: top;
            padding-top: 5px;
        }
    </style>
    <style>
        .popup
        {
            width: 730px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #333333;
        }
        .mid
        {
            background: #fff;
            padding: 0px 5px 5px 15px;
        }
        .sizes
        {
            width: 670px;
            vertical-align: top;
            background: #fff;
            border: #6e6e6e solid 1px;
        }
        .orange
        {
            background: #d57300;
            color: #fff;
            font-size: 13px;
            line-height: 28px;
            padding-left: 5px;
        }
        .blue
        {
            background: #005879;
            color: #fff;
            font-size: 13px;
            line-height: 28px;
            padding-left: 5px;
        }
        .blocklistcolor
        {
            background: #eaeaea;
            line-height: 28px;
            font-size: 13px;
            color: #333333;
            padding-left: 5px;
        }
        .resizelistcolor
        {
            background: #f6f6f6;
            line-height: 28px;
            font-size: 13px;
            color: #333333;
            padding-left: 5px;
        }
        .resizelogo
        {
            width: 670px;
            border: #d57300 solid 1px;
            padding: 10px;
        }
        .resizelogo1
        {
            width: 780px;
            border: #d57300 solid 1px;
            padding: 10px;
        }
        .logo
        {
            width: 200px;
            border: #005879 solid 1px;
            vertical-align: top;
        }
        body
        {
            background-color: #666666;
        }
    </style>
    <%--Drop Files Events--%>
    <script type="text/javascript">

        function LoaddropzoneEvents() {
            var target = document.getElementById("drop_zone");
            target.addEventListener("dragenter", OnDragEnter, false);
            target.addEventListener("dragover", OnDragOver, false);
            target.addEventListener("drop", OnDrop, false);

        }


        function fileuploadOnchange() {
            document.getElementById("drop_zone").style.display = "none";
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
        var IsFirst = true;

        function OnDrop(e) {
            //alert(1);
            e.stopPropagation();
            e.preventDefault();

            selectedFiles = e.dataTransfer.files;
            if (selectedFiles.length > 1 && document.getElementById("<%=rbSingleUpload.ClientID %>").checked == true) {
                alert("Multiple selections are not allowed to drop");
                return false;
            }
            else if (document.getElementById("<%=rbSingleUpload.ClientID %>").checked == true) {
                data = new FormData();
                $("#drop_zone").innerHTML = "";
                $("#drop_zone").text("");
            }


            var TotalFilesCount = parseInt(document.getElementById("hdnDropFilesCount").value) + selectedFiles.length;
            var TotalFileSize = parseInt(document.getElementById("hdnDropFileSize").value);
            for (var i = 0; i < selectedFiles.length; i++) {
                TotalFileSize = TotalFileSize + selectedFiles[i].size;
            }
            var Size_MB = (TotalFileSize / 1024) / 1024;


            if (TotalFilesCount > 10) {
                alert("You can upload max 10 files or 10 MB size files at time.");
                return false;
            }
            else if (parseFloat(Size_MB) > 10) {
                alert("You can upload max 10 files or 10 MB size files at time.");
                return false;
            }
            for (var i = 0; i < selectedFiles.length; i++) {
                data.append(selectedFiles[i].name, selectedFiles[i]);
                document.getElementById("hdnDropFilesCount").value = parseInt(document.getElementById("hdnDropFilesCount").value) + 1;
                document.getElementById("hdnDropFileSize").value = parseInt(document.getElementById("hdnDropFileSize").value) + selectedFiles[i].size;
            }

            document.getElementById("<%=btnClearDropFiles.ClientID %>").style.display = "block";
            document.getElementById("<%=hdnUploadingType.ClientID %>").value = "Drop";

            if (IsFirst) {
                $("#drop_zone").innerHTML = "";
                $("#drop_zone").text("");
                IsFirst = false;
            }

            //$("#drop_zone").innerHTML = $("#drop_zone").innerHTML.replace("Drop files here", "");

            for (i = 0; i < selectedFiles.length; i++) {
                $("#drop_zone").append(selectedFiles[i].name + "</br>");
            }
        }


        function UploadFiles() {

            if (selectedFiles != null && document.getElementById("<%=hdnUploadingType.ClientID %>").value == "Drop") {

                document.getElementById("hdnDropFilesCount").value = 0;
                document.getElementById("hdnDropFileSize").value = 0;

                var parentType = document.getElementById("<%=hdnIsParent.ClientID %>").value;
                var folderName = document.getElementById("<%=hdnAlbumUniqueName.ClientID %>").value;
                var albumID = document.getElementById("<%=hdnAlbumID.ClientID %>").value;
                var PID = '<%=ProfileID %>';

                var xhr = new XMLHttpRequest();
                xhr.open('POST', '/Business/MyAccount/UploadMasterGallery.ashx?ParentType=' + parentType + '&FolderName=' + folderName +
                '&albumID=' + albumID + '&PID=' + PID);
                //xhr.open('POST', '/UploadImages.ashx?id=100');
                xhr.onload = function () {
                    if (xhr.status === 200) {
                        //alert('all done: ' + xhr.status);

                        //var reponse = xhr.response;

                        LoaddropzoneEvents();

                        return true;

                    } else {
                        console.log('Something went terribly wrong...');
                    }
                };

                xhr.send(data);
            }
            else {
                alert("Please drop atleast one image to upload.");
                return false;
            }
        }

        function ClearDroppedFiles() {
            selectedFiles = null;
            data = new FormData();
            $("#drop_zone").innerHTML = "";
            $("#drop_zone").text("");
            document.getElementById("hdnDropFilesCount").value = 0;
            document.getElementById("hdnDropFileSize").value = 0;
            return false;
        }

    </script>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td>
                        <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td>
                                                    <div id="divUpload" style="margin-left: 150px; display:none;">
                                                        <div style="text-align: center;">
                                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                        </div>
                                                    </div>
                                                    <img style='width: auto; height: auto; vertical-align: middle' src='../../Images/CustomModulesAppIcons/Media.png'
                                                        alt=''>
                                                    <span style='vertical-align: middle'>Master Gallery</span> <span style="color: Black;
                                                        font-size: 14px; margin: 0px; padding: 0px; position: absolute; margin-left: 600px;
                                                        margin-top: 0px;"></span>
                                                </td>
                                                <td align="left">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="inputtable" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px">
                                    <table width="730px" border="0" cellpadding="0" cellspacing="0">
                                        <colgroup>
                                            <col width="22%" />
                                            <col width="*" />
                                            <col width="19%" />
                                        </colgroup>
                                        <tr>
                                            <td valign="top" style="padding: 10px;">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rbSingleUpload" runat="server" Text="Single File Upload" GroupName="uploadgroup"
                                                                Checked="true" onclick="ShowUploadPanel(1);" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rbMultipleUpload" runat="server" Text="Multiple File Upload"
                                                                GroupName="uploadgroup" onclick="ShowUploadPanel(2);" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td valign="top">
                                                <table>
                                                    <tr>
                                                        <td style="padding: 10px;">
                                                            <strong>Upload file(s) </strong>
                                                            <div id="divSingleUpload">
                                                                <table>
                                                                    <colgroup>
                                                                        <col width="120px" />
                                                                        <col width="*" />
                                                                    </colgroup>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:ValidationSummary runat="server" ID='valid' ValidationGroup="ABC" ForeColor="Red" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:FileUpload runat="server" ID="SingleFileUploadControl" Width="300px" onchange="SetFileName();" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label runat="server" Text="Image Name:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="txtimagname" Width="200px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtimagname"
                                                                                ValidationGroup="ABC" ForeColor="Red" ErrorMessage="Image Name is mandatory.">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div id="divMultipleUpload" style="display: none; margin: 10px 0px">
                                                                <input type="file" id="MultipleFileUploadControl" runat="server" multiple="multiple"
                                                                    width="300px" accept="image/png, image/jpeg, image/jpg, image/gif, image/bmp" />
                                                            </div>
                                                            <div id="drop_zone" style="margin: 10px 0px">
                                                                Drop files here</div>
                                                            <div style="float: left;">
                                                                <asp:Button runat="server" ID="btnUpload1" Text="Upload" CssClass="btnnew" OnClientClick="return ValidateUploadFileToAlbum();"
                                                                    OnClick="btnUpload1_OnClick" />
                                                                <asp:Button ID="btnClearDropFiles" runat="server" Text="Clear Drop Files" CssClass="btnnew"
                                                                    OnClientClick="return ClearDroppedFiles();" Style="display: none; margin: 10px 0px" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="clear20">
                                    </div>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background: #fff;
                                        border: #f2faff solid 5px; padding: 20px;">
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCreateAlbum" CssClass="btnnew" Text="Create Album" runat="server"
                                                    OnClientClick="return ShowNewAlbumWindow();" />
                                                <asp:Button ID="btnDeleteAlbum" CssClass="btnnew" Text="Delete Album" runat="server"
                                                    OnClientClick="return DeleteAlbum();" OnClick="btnDeleteAlbum_OnClick" Visible="false" />
                                                <div style="text-align: right; width: 40%; float: right; margin-top: 20px; font-weight: bold;">
                                                    <asp:CheckBox ID="cbSelectAll" runat="server" Text="Select All" Checked="false" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="padding-top: 10px; background: #f2faff">
                                                <%--ShowCheckBoxes="All" --%>
                                                <style>
                                                    .TVAlbums
                                                    {
                                                        background-color: none;
                                                        width: 100px;
                                                        padding: 10px;
                                                    }
                                                    .TVAlbumsseletednode
                                                    {
                                                        font-weight: bold;
                                                        width: 150px;
                                                    }
                                                    .NodeChild
                                                    {
                                                        padding: 0px;
                                                    }
                                                </style>
                                                <asp:TreeView ID="TVAlbums" runat="server" OnSelectedNodeChanged="TVAlbums_OnSelectedNodeChanged"
                                                    Style="margin: 0px 10px; font-size: 14px;" Width="170px" SelectedNodeStyle-CssClass="TVAlbumsseletednode"
                                                    NodeStyle-CssClass="NodeChild" ShowLines="true">
                                                </asp:TreeView>
                                            </td>
                                            <td valign="top" align="left">
                                                <div id="gallery" style="height: 320px; overflow-y: auto; border: solid 1px #ccc;
                                                    width: 660px;">
                                                    <asp:DataList ID="dtlistImages" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                                                        CssClass="datalist" OnItemDataBound="dtlistImages_ItemDataBound" DataKeyField="Image_ID">
                                                        <ItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="imggrid" style="border: 0px solid orange;">
                                                                <colgroup>
                                                                    <col width="10px" />
                                                                    <col width="*" />
                                                                </colgroup>
                                                                <tr class="row1">
                                                                    <td>
                                                                        <asp:CheckBox runat="server" ID="chk" />
                                                                    </td>
                                                                    <td style="vertical-align: top;">
                                                                        <asp:Label ID="imgpreview" runat="server" Text='<%#Eval("Image_Unique_Name") %>'></asp:Label><br />
                                                                        <asp:Label ID="lblImageUniqueName" Style="display: none;" runat="server" Text='<%#Eval("Image_Unique_Name") %>'></asp:Label><br />
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Image_Name") %>'></asp:Label><br />
                                                                        <asp:Label ID="lblImgID" runat="server" Style="display: none;" Text='<%#Eval("Image_ID") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                                <br />
                                                <div style="float: left; padding: 5px;">
                                                    <asp:Button ID="btnDeleteImages" runat="server" CssClass="btnneworange" Text="Delete Image"
                                                        OnClientClick="return DeleteImagesValidations();" OnClick="btnDeleteImages_OnClick" />
                                                    <asp:Button ID="btnEditImgOrder" runat="server" Visible="false" Text="Edit Image Order Number"
                                                        OnClientClick="return ValidateImgSelection();" OnClick="btnEditImgOrder_OnClick" />
                                                    <asp:Button ID="btnEditImgCaption" runat="server" Visible="false" Text="Edit Image Caption"
                                                        OnClientClick="return ValidateImgSelection();" OnClick="btnEditImgCaption_OnClick" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:HiddenField runat="server" ID="hdnAlbumID" Value="0" />
            <%--1 is Parent--%>
            <%--2 is Child--%>
            <asp:HiddenField runat="server" ID="hdnIsParent" Value="0" />
            <asp:HiddenField runat="server" ID="hdnAlbumUniqueName" />
            <asp:HiddenField runat="server" ID="hdnUploadingType" Value="Browse" />
            <input type="hidden" id="hdnDropFilesCount" value="0" />
            <input type="hidden" id="hdnDropFileSize" value="0" />
            <table border="0" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                        <cc1:ModalPopupExtender ID="CropImgModalPopup" runat="server" TargetControlID="lblpre"
                            PopupControlID="pnlpopup1" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlpopup1" runat="server" Width="50%" Style="display: none;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="popup">
                                <tr>
                                    <td>
                                        <img src="../../images/logos/top.png" width="860" height="17" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="mid">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top" align="right">
                                                    <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                        CausesValidation="false"></asp:ImageButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td align="center">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="sizes">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="1">
                                                                    <tr>
                                                                        <td colspan="2" class="orange">
                                                                            Block Scale: <span style="text-align: right; margin-left: 290px;">
                                                                                <asp:Label runat="server" ID="lblLogoType"></asp:Label>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="blocklistcolor">
                                                                            Width
                                                                        </td>
                                                                        <td class="blocklistcolor">
                                                                            <asp:Label ID="lblFixedWidth" runat="server" Text="275px"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="blocklistcolor">
                                                                            Height
                                                                        </td>
                                                                        <td class="blocklistcolor">
                                                                            <asp:Label ID="lblFixedHeight" runat="server" Text="170px"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="trShortLogooptional1">
                                                <td style="padding-left: 0px;">
                                                    <div style="float: left;">
                                                        <asp:RadioButton runat="server" ID="rbSystemResizeLogo" GroupName="rb1" Checked="true" />
                                                        <span style="font-weight: bold;">Please use the image that was resized to the recommended
                                                            size of 300px X 300px.</span>
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="resizelogo1">
                                                            <tr>
                                                                <td align="center">
                                                                    &nbsp;
                                                                    <%--   <img id="TempShortLogo" />--%>
                                                                    <asp:Label ID="lblTempShortImg" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="trShortLogooptional2">
                                                <td align="center" style="padding: 10px;" colspan="2">
                                                    <span style="color: #d57300; font-size: 18px; padding: 10px; font-weight: bold;">(OR)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 0px;">
                                                    <div style="float: left;">
                                                        <span id="trShortLogooptional3">
                                                            <asp:RadioButton runat="server" ID="rbUserCropLogo" GroupName="rb1" />
                                                            <span style="font-weight: bold;">Do it yourself by selecting the part of the image that
                                                                you wish to keep as the image.</span> </span>
                                                        <table border="0" cellpadding="0" cellspacing="0" class="resizelogo1" id='tblCropLogo'>
                                                            <tr>
                                                                <td style="padding-left: 10px;">
                                                                    <div style="width: 750px; height: 320px; overflow: auto;">
                                                                        <%-- <img id="imgMain" />--%>
                                                                        <asp:Label runat="server" ID="lblimgMain"></asp:Label>
                                                                    </div>
                                                                    <input type="hidden" id="hdnx" runat="server" />
                                                                    <input type="hidden" id="hdny" runat="server" />
                                                                    <input type="hidden" id="hdnw" runat="server" />
                                                                    <input type="hidden" id="hdnh" runat="server" />
                                                                    <asp:HiddenField runat="server" ID="hdnImgURL" />
                                                                    <asp:HiddenField ID="hdnOriginalWidth" runat="server" />
                                                                    <asp:HiddenField ID="hdnOriginalHeight" runat="server" />
                                                                    <asp:HiddenField ID="hdbTempShortLogoURL" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-top: 10px;">
                                                    <asp:LinkButton ID="lnkImageSubmit" runat="server" Width="76" Height="34" OnClick="btnCropLogo_OnClick"><img src="../../images/logos/submit.png" alt="" />
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                    <asp:LinkButton ID="lnkImageCancel" runat="server" Width="76" Height="34" OnClick="btnCropCancel_Click"><img src="../../images/logos/cancel.png" alt="" />
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/logos/bottom.png" width="860" height="17" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table border="0" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblNewAlbumWPre" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="modalPopupNewAlbum" runat="server" PopupControlID="pnlPopupNewAlbum"
                            TargetControlID="lblNewAlbumWPre" BackgroundCssClass="modal" CancelControlID="imgorderclose"
                            BehaviorID="NewAlbumPreview">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlPopupNewAlbum" runat="server" Style="display: none;">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="600px" border="0">
                                <colgroup>
                                    <col width="25%" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td align="left" class="header">
                                        New Album Name
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/popup_close.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:ValidationSummary runat="server" ID='ValidationSummary1' ValidationGroup="ABC11"
                                            ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="popuplabel" style="padding-top: 10px;" valign="top">
                                        Enter Album Name:
                                    </td>
                                    <td style="padding-top: 10px;">
                                        <asp:TextBox ID="txtAlbumName" runat="server" Width="200px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAlbumName"
                                            ValidationGroup="ABC11" ForeColor="Red" ErrorMessage="Album Name is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAlbumName"
                                            ErrorMessage="Please Enter Only Alpha Numeric." ValidationGroup="ABC11" ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 10px;">
                                        &nbsp;
                                    </td>
                                    <td style="padding-top: 10px;">
                                        <asp:Button runat="server" ID="btnAlbumSubmit" Text="Submit" OnClick="btnAlbumSubmit_OnClick"
                                            ValidationGroup="ABC11" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 25px;">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblEditOrderNoPre" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupImgOrderNo" runat="server" PopupControlID="pnlPopupEditOrderNo"
                                TargetControlID="lblEditOrderNoPre" BackgroundCssClass="modal" CancelControlID="imgorderclose">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="pnlPopupEditOrderNo" runat="server" Style="display: none;">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="600px" border="0">
                                    <colgroup>
                                        <col width="30%" />
                                        <col width="*" />
                                    </colgroup>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="header">
                                            Image Order Number
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="imgorderclose" runat="server" ImageUrl="~/images/popup_close.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Label ID="lblEditOrderNoImgPreview" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Label runat="server" ID="lblEditOrderNumberErrorMessage"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="popuplabel" style="padding-top: 10px;" valign="top">
                                            Enter Image Order Number:
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <asp:TextBox ID="txteditordernumber" runat="server" MaxLength="100" Width="150px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txteditordernumber"
                                                ErrorMessage="Please Enter Only Numbers." ValidationExpression="^\d+(\.\d+)?$"
                                                ValidationGroup="IMGOD"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 10px;">
                                            &nbsp;
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <asp:Button ID="btnUpdateImgOrderNumber" runat="server" OnClientClick="return ValidateOrderNumber(2);"
                                                Text="Update" ValidationGroup="IMGOD" OnClick="btnUpdateImgOrderNumber_OnClick" />
                                            <asp:Button ID="btnCancelImgOrderNumber" runat="server" Text="Cancel" CausesValidation="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 25px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblEditCaptionPre" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="modalWidnowEditCaption" runat="server" PopupControlID="pnlEditImgCaption"
                                TargetControlID="lblEditCaptionPre" BackgroundCssClass="modal" CancelControlID="imgorderclose">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="pnlEditImgCaption" runat="server" Style="display: none;">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="600px" border="0">
                                    <colgroup>
                                        <col width="30%" />
                                        <col width="*" />
                                    </colgroup>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="header">
                                            Edit Image Caption
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/popup_close.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Label ID="lblCaptionImgPreview" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Image ID="imgEditCaptionPreview" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="popuplabel" style="padding-top: 10px;" valign="top">
                                            Enter Image Caption:
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <asp:TextBox ID="txtEditImageCaption" runat="server" MaxLength="100" Width="300px"
                                                TextMode="MultiLine" Height="50px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 10px;">
                                            &nbsp;
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <asp:Button ID="btnEditImgCaptionUpdate" runat="server" Text="Update" OnClick="btnEditImgCaptionUpdate_OnClick" />
                                            <asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 25px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload1" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
