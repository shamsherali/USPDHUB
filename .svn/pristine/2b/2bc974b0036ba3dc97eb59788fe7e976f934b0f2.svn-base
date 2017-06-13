<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bulletin_ImagegalleryNew.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.Bulletin_ImagegalleryNew" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/CommonMasterGallery.ascx" TagName="CommonMasterGallery"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
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
            height: 2px;
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
            $('#gallery11 a').lightBox();


        });

        function displaypanel() {

            //            alert(1);
            LoaddropzoneEvents();


            $("[id$='cbSelectAll']").click(
             function () {
                 $("[id$='dtlistImages'] INPUT[type='checkbox']").attr('checked', $("[id$='cbSelectAll']").is(':checked'));
             });

            //             alert(2);
            if (document.getElementById("<%=rbSystem.ClientID %>").checked == true)
                ShowUploadPanel(1);
            else
                ShowUploadPanel(2);
        }

        var IsFirst = true;

        function LoadImgSettings(imgWidth, imgHeight) {
            IsFirst = true;
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

            if (IsFirst == false) {
                document.getElementById("<%=rbUserCropLogo.ClientID %>").checked = true;
            }
            IsFirst = false;
        };
         

    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            $("[id$='cbSelectAll']").click(
             function () {
                 $("[id$='dtlistImages'] INPUT[type='checkbox']").attr('checked', $("[id$='cbSelectAll']").is(':checked'));
             });

        });



        function ProgressBar() {
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
            if (document.getElementById("divUpload") != null)
                document.getElementById("divUpload").style.display = "none";

            if (document.getElementById("DivImageGallery") != null)
                document.getElementById("DivImageGallery").style.display = "none";


            if (Value == "1") {
                //document.getElementById("DivImageGallery").style.display = "block";
                if (document.getElementById("divUpload") != null)
                    document.getElementById("divUpload").style.display = "none";
            }
            else {

                //document.getElementById("divUpload").style.display = "block";

            }
            return true;
        }

        function ShowUploadPanel(value) {
            if (value == 1) {
                $("#divSystemUpload").css("display", "block");
                $("#divMasterGalleryUpload").css("display", "none");
            }
            else {
                $("#divSystemUpload").css("display", "none");
                $("#divMasterGalleryUpload").css("display", "block");
            }


        }


        function SetFileName() {
            var arrFileName = document.getElementById('<%= SingleFileUploadControl.ClientID %>').value.split('\\');
            var imageName = arrFileName[arrFileName.length - 1].replace(".jpeg", "").replace(".jpg", "").replace(".gif", "").replace(".png", "");
            imageName = imageName.replace("%", "");
            imageName = imageName.replace("#", "");
            document.getElementById('<%= txtimagname.ClientID %>').value = imageName;
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

        function ValidateUploadFile() {

            if (document.getElementById("<%=rbSystem.ClientID %>").checked == true) {
                if (document.getElementById("<%=hdnUploadingType.ClientID %>").value == "Browse") {
                    if (Page_ClientValidate('ABC')) {
                        return true;
                    }
                    else {
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

        function ValidateImgSelection_MasterGallery() {

            document.getElementById("<%=hdnOpenMasterWindow.ClientID %>").value = "";
            return true; ;
        } //



        function ShowMasterGalleryWindow() {
            //            var window = $find("MasterGalleryPre");
            //            window.show();
            document.getElementById("<%=hdnOpenMasterWindow.ClientID %>").value = "1";
            document.getElementById("<%=pnlImages.ClientID %>").style.display = "none";

            displaypanel();
            return true;
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
            width: 740px;
            border: #d57300 solid 1px;
            padding: 10px;
        }
        .resizelogo1
        {
            width: 730px;
            border: #d57300 solid 1px;
            padding: 10px;
        }
        .logo
        {
            width: 200px;
            border: #005879 solid 1px;
            vertical-align: top;
        }
        body1
        {
            background-color: #666666;
        }
    </style>
    <%--Drop Files Events--%>
    <script type="text/javascript">

        function LoaddropzoneEvents() {
            var target = document.getElementById("drop_zone");
            if (target != null) {
                target.addEventListener("dragenter", OnDragEnter, false);
                target.addEventListener("dragover", OnDragOver, false);
                target.addEventListener("drop", OnDrop, false);
            }

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
            if (selectedFiles.length > 1 && document.getElementById("<%=rbSystem.ClientID %>").checked == true) {
                alert("Multiple selections are not allowed to drop");
                return false;
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

                ShowProgressBar(2);

                document.getElementById("hdnDropFilesCount").value = 0;
                document.getElementById("hdnDropFileSize").value = 0;

                var parentType = "1";
                var folderName = "";
                var albumID = document.getElementById("<%=hdnAlbumID.ClientID %>").value;
                var PID = '<%=ProfileID %>';

                var xhr = new XMLHttpRequest();
                xhr.open('POST', '/Business/MyAccount/UploadContentGallery.ashx?ParentType=' + parentType + '&FolderName=' + folderName +
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

        function DisplayImgResizePanel(value) {
            if (value == 1) {
                $("#tblSystemResize").css("display", "block");
                $("#tblCrop").css("display", "none");
            }
            else {
                $("#tblSystemResize").css("display", "none");
                $("#tblCrop").css("display", "block");
            }
        }

    </script>
</head>
<body>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlImages" Width="900px">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px">
                                        <table width="750px" border="0" cellpadding="0" cellspacing="0">
                                            <colgroup>
                                                <col width="22%" />
                                                <col width="*" />
                                                <col width="19%" />
                                            </colgroup>
                                            <tr>
                                                <td valign="top" style="padding-top: 10px;">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbSystem" runat="server" Text="From System" GroupName="uploadgroup"
                                                                    Checked="true" onclick="ShowUploadPanel(1);" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbMasterGallery" runat="server" Text="From Master Gallery" GroupName="uploadgroup"
                                                                    onclick="ShowUploadPanel(2);" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td valign="top">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <div id="divUpload" style="display: none;">
                                                                    <div style="text-align: center;">
                                                                        <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/ezSmartAjax.gif")%>" border="0" /><b><font
                                                                            color="green">Processing....</font></b>
                                                                    </div>
                                                                </div>
                                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                                    <ProgressTemplate>
                                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px;">
                                                                <div id="divSystemUpload">
                                                                    <strong>Upload file(s) </strong>
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
                                                                                <asp:Label ID="Label1" runat="server" Text="Image Name:"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtimagname" Width="200px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtimagname"
                                                                                    ValidationGroup="ABC" ForeColor="Red" ErrorMessage="Image Name is mandatory.">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <div id="drop_zone" style="margin: 10px 0px">
                                                                                    Drop files here</div>
                                                                                <div style="float: left;">
                                                                                    <asp:Button runat="server" ID="btnUpload1" Text="Upload" CssClass="btnnew" OnClientClick="return ValidateUploadFile();"
                                                                                        OnClick="btnUpload1_OnClick" />
                                                                                    <asp:Button ID="btnClearDropFiles" runat="server" Text="Clear Drop Files" CssClass="btnnew"
                                                                                        OnClientClick="return ClearDroppedFiles();" Style="display: none; margin: 10px 0px" />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div id="divMasterGalleryUpload" style="display: none; margin: 10px 0px">
                                                                    <asp:Button ID="Button1" runat="server" Text="Browse from Master Gallery" CssClass="btnnew"
                                                                        OnClientClick="return ShowMasterGalleryWindow();" OnClick="btnOpenMasterGalleryWindow_OnClick" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<div class="clear20">
                                        </div>--%>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background: #fff;
                                            border: #f2faff solid 5px; padding: 20px; padding-top: 1px;">
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <div style="width: 100%; float: left; margin-top: 10px; font-weight: bold;">
                                                        <asp:CheckBox ID="cbSelectAll" runat="server" Text="Select All" Checked="false" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" style="padding-top: 10px; background: #f2faff">
                                                </td>
                                                <td valign="top" align="left">
                                                    <div id="gallery11" style="height: 320px; overflow-y: auto; border: solid 1px #ccc;
                                                        width: 100%">
                                                        <asp:DataList ID="dtlistImages" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
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
                                                                            <asp:ImageButton ID="ImgUserImg" runat="server" ImageUrl='<%#Eval("Image_Unique_Name") %>'
                                                                                Height="130px" Width="130px" OnClick="ImgUserImg_Click" OnClientClick="return ShowProgressBar('2')"
                                                                                CausesValidation="false" />
                                                                            <asp:Label ID="imgpreview" runat="server" Text='<%#Eval("Image_Unique_Name") %>'
                                                                                Style="display: none;"></asp:Label><br />
                                                                            <asp:Label ID="lblImageUniqueName" Style="display: none;" runat="server" Text='<%#Eval("Image_Unique_Name") %>'></asp:Label><br />
                                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Image_Name") %>'></asp:Label><br />
                                                                             <asp:Label ID="lblimgdate" runat="server" Text='<%# Eval("Image_Date", "{0:MM/dd/yy hh:mm tt}") %>'></asp:Label><br />
                                                                            <asp:Label ID="lblImgID" runat="server" Style="display: none;" Text='<%#Eval("Image_ID") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                    <div style="float: left; padding: 5px;">
                                                        <asp:Button ID="btnDeleteImages" runat="server" CssClass="btnneworange" Text="Delete Image"
                                                            OnClientClick="return DeleteImagesValidations();" OnClick="btnDeleteImages_OnClick" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 500px;">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlImgResize">
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
                                        <div id="DivImageGallery" style="display: none;">
                                            <div style="text-align: center;">
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/ezSmartAjax.gif")%>" border="0" /><b><font
                                                    color="green">Processing....</font></b>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnImageGallery" runat="server" Text="Image Gallery" OnClick="btnImageGallery_OnClick"
                                            CausesValidation="false" OnClientClick="return ShowProgressBar('1');" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-top: 10px;">
                                        You may hyperlink the image by typing the web address in the box.
                                        <asp:TextBox ID="txtwebaddress" runat="server" Text="http://" Width="250px"></asp:TextBox><br />
                                    </td>
                                </tr>
                                <tr id="trShortLogooptional1">
                                    <td style="padding-left: 0px; padding-top: 10px;">
                                        <div style="float: left;">
                                            <asp:RadioButton runat="server" ID="rbSystemResizeLogo" GroupName="rb1" Checked="true"
                                                onclick="DisplayImgResizePanel(1);" />
                                            <span style="font-weight: bold;">Automatic System Resize </span>
                                            <br />
                                            <asp:RadioButton runat="server" ID="rbUserCropLogo" GroupName="rb1" onclick="DisplayImgResizePanel(2);" />
                                            <span style="font-weight: bold;">Select to Crop </span></span>
                                            <table id="tblSystemResize" border="0" cellpadding="5" cellspacing="0" class="resizelogo1">
                                                <tr>
                                                    <td align="center">
                                                        <div style="max-height: 380px; overflow-y: auto; margin: 0px; padding: 0px; text-align: center;">
                                                            <%--   <img id="TempShortLogo" />--%>
                                                            <asp:Label ID="lblTempShortImg" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 0px; padding-top: 10px;">
                                        <div style="float: left;">
                                            <span id="trShortLogooptional3">
                                                <table border="0" cellpadding="0" cellspacing="0" class="resizelogo1" id='tblCrop'
                                                    style="display: none;">
                                                    <tr>
                                                        <td style="padding-left: 10px;">
                                                            <div style="width: 700px; height: 380px; overflow: auto;">
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
                                        <asp:LinkButton ID="lnkImageSubmit" runat="server" Width="76" Height="34" OnClientClick="return CheckImageSizeing()"
                                            OnClick="btnCropLogo_OnClick"><img src="../../images/logos/submit.png" alt="" />
                                        </asp:LinkButton>
                                        &nbsp;
                                        <%-- <asp:LinkButton ID="lnkImageCancel" runat="server" Width="76" Height="34" OnClick="btnCropCancel_Click"><img src="../../images/logos/cancel.png" alt="" />
                                        </asp:LinkButton>--%>
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
            <asp:HiddenField runat="server" ID="hdnAlbumID" Value="0" />
            <asp:HiddenField runat="server" ID="hdnOpenMasterWindow" />
            <%--1 is Parent--%>
            <%--2 is Child--%>
            <asp:HiddenField runat="server" ID="hdnUploadingType" Value="Browse" />
            <input type="hidden" id="hdnDropFilesCount" value="0" />
            <input type="hidden" id="hdnDropFileSize" value="0" />
            <asp:HiddenField runat="server" ID="hdnResizeImageValue" />
            <asp:HiddenField ID="hdnheight" runat="server" />
            <asp:HiddenField ID="hdnwidth" runat="server" />
            <asp:HiddenField ID="hdnCheck" runat="server" Value="0" />
            <asp:HiddenField ID="hdnClose" runat="server" />
            <asp:HiddenField ID="CheckWidth" runat="server" Value="0" />
            <script type="text/javascript" language="javascript">

                function ImageAddtoBlock() {

                    RImgURL = document.getElementById('hdnResizeImageValue').value;
                    RImgURLHeight = document.getElementById('hdnheight').value;
                    RImgURLWidth = document.getElementById('hdnwidth').value;
                    ImgDivID = parent.document.getElementById('editDivCheck').value;
                    ImgDivID1 = ImgDivID;

                    // From Crime Heightlights Page
                    if (parent.document.getElementById('DivIds') != null) {
                        if (parent.document.getElementById("imagesection" + parent.document.getElementById('DivIds').value) != null) {
                            parent.document.getElementById("imagesection" + parent.document.getElementById('DivIds').value).style.display = 'block';
                        }
                    }
                    //end

                    if (document.getElementById('txtwebaddress').value != "" && document.getElementById('txtwebaddress').value != "http://") {
                        parent.document.getElementById(ImgDivID1).innerHTML = "<a href='" + document.getElementById('txtwebaddress').value + "' target='_blank'><img style='vertical-align:bottom;' src='" + RImgURL + "' border='0'    /></a>";
                    }
                    else {

                        parent.document.getElementById(ImgDivID1).innerHTML = "<img style='vertical-align:bottom;' src='" + RImgURL + "' border='0'   />";
                    }

                    // From Bulletin Forms Image Delete Button Displaying.....
                    if ((ImgDivID1 == "divDefaultPerson" || ImgDivID1 == "divMissingVeh") && parent.document.getElementById("imgDelete1") != null) {
                        parent.document.getElementById("imgDelete1").style.display = "block";
                    }
                    else if (ImgDivID1 == "divAnotherImg" && parent.document.getElementById("imgDelete2") != null) {
                        parent.document.getElementById("imgDelete2").style.display = "block";
                    }

                    parent.document.getElementById('editDivCheck').value = '';
                    document.getElementById('hdnResizeImageValue').value = '';
                    document.getElementById('hdnheight').value = '';
                    document.getElementById('hdnClose').value = '';
                    document.getElementById('hdnwidth').value = '';
                    parent.$find('popupimage').hide();

                }

                function CheckImageSizeing() {

                    var theurl = document.getElementById('txtwebaddress').value;
                    if (theurl != "" && theurl != "http://") {
                        var tomatch = /[http|https]:\/\/[A-Za-z0-9\.-]{3,}\.[A-Za-z]{2,}/
                        if (!tomatch.test(theurl)) {
                            window.alert("URL invalid. Try again.");
                            return false;
                        }
                    }
                } //end function
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload1" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblMasterGalleryPre" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="modalWindowMasterGallery" runat="server" PopupControlID="pnlPoupMasterGallery"
                            TargetControlID="lblMasterGalleryPre" BackgroundCssClass="modal" BehaviorID="MasterGalleryPre">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlPoupMasterGallery" runat="server" Style="display: none; background-color: lightgray;">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="600px" border="0"
                                style="z-index: -1;">
                                <colgroup>
                                    <col width="30%" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="header">
                                        Select Image
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="ImgCloseMasterGalleryWindow" runat="server" ImageUrl="~/images/popup_close.gif"
                                            OnClick="ImgCloseMasterGalleryWindow_OnClick" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 25px;" align="center">
                                        <uc3:CommonMasterGallery ID="CommonMasterGallery1" runat="server" />
                                        <br />
                                        <div style="float: left; padding: 5px; margin-left: 300px;">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btnneworange" Text="Submit" OnClientClick="return ValidateImgSelection_MasterGallery()"
                                                OnClick="btnSubmit_OnClick" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
