<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="ManageBGImages.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.ManageBGImages" %>

<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>"></script>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/main.js")%>"
        type="text/javascript"></script>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/dashboardstyle.js")%>"
        type="text/javascript"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="../../Scripts/jquery.Jcrop.js" type="text/javascript"></script>
    <link href="../../css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .datalist
        {
        }
        .datalist td
        {
            vertical-align: top;
            padding-top: 5px;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 300px;
            border: 0px solid #0DA9D0;
            border-radius: 6px;
            padding: 0;
        }
        .modalPopup .header
        {
            color: #454545;
            line-height: normal;
            text-align: center;
            font-weight: bold;
            border-bottom: 1px solid #999;
            font-size: 20px;
            height: auto;
            padding: 0 0 5px;
        }
        .modalPopup .body
        {
            min-height: 200px;
            line-height: 30px;
            text-align: center;
        }
        .btn
        {
            -webkit-border-radius: 3;
            -moz-border-radius: 3;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            background: #3498db;
            padding: 6px 25px;
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
        #drop_zone
        {
            padding: 10px;
            width: 100%;
            min-height: 100px;
            max-height: 200px;
            overflow: auto;
            text-align: left;
            text-transform: uppercase;
            font-weight: bold;
            border: 1px solid #ccc;
            outline: 0px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            box-sizing: border-box;
        }
        .upload-table
        {
            padding: 20px 40px 15px;
            box-sizing: border-box;
            width: 100%;
        }
        .divider
        {
            border-left: 0px solid #ccc;
            background: #f9f9f9;
        }
        #drop_zone
        {
            background: #f5f5f5;
        }
        .phone-no
        {
            font-size: 22px;
            padding-bottom: 10px;
        }
        .btn-submit
        {
            margin: 20px 0 0;
        }
        .col-1
        {
            padding-right: 15px;
            width: 340px;
        }
        
        #gallery img
        {
            max-width: 100%;
        }
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
        body
        {
            background-color: #666666;
        }
        #slideshow > div
        {
            position: absolute;
        }
    </style>
    <script type="text/javascript">
        var row_str = '<div style="background-color:#f1f1f1;" class="divToggleTop">&nbsp;</div>';
        function toggle_visibility(id) {
            if (document.getElementById(id).style.display == "none") {
                document.getElementById(id).style.display = "block";
                document.getElementById('<%=hdnToggle.ClientID %>').value = "0";
            }
            else {
                if (document.getElementById('<%=hdnToggle.ClientID %>').value == "0") {
                    $("#tabNavigation").append(row_str);
                    $(".divToggleTop").height($("#divMobileFooter").height() + $("#divMobileHeader").height() - $("#divMobileNav").height() + 20);
                    document.getElementById('<%=hdnToggle.ClientID %>').value = "1";
                }
                else {
                    $('.divToggleTop').remove();
                    document.getElementById(id).style.display = "none";
                }
            }
        }
        function BindLoadEvents() {
            var bannerAds = document.getElementsByClassName("banneraddrotator");
            if (bannerAds.length > 1) {
                $("#slideshow > div:gt(0)").hide();
                myTimer = setInterval(PlayBanners, 3000);
            }
            else {
                $("#slideshow:first-child").attr("display", "block");
            }
        }
        function PlayBanners() {
            $('#slideshow > div:first').fadeOut(1000).next().fadeIn(1000).end().appendTo('#slideshow');
        }
        $(function () {
            BindLoadEvents();
            CallingLightBox();
        });
        function CallingLightBox() {
            LoaddropzoneEvents();
        }
        function LoaddropzoneEvents() {
            var target = document.getElementById("drop_zone");
            if (target != null) {
                target.addEventListener("dragenter", OnDragEnter, false);
                target.addEventListener("dragover", OnDragOver, false);
                target.addEventListener("drop", OnDrop, false);
            }
        }
        window.onload = function () {
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

            document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML = "";

            e.stopPropagation();
            e.preventDefault();
            selectedFiles = e.dataTransfer.files;
            $("#drop_zone").innerHTML = "";
            $("#drop_zone").text("");
            if (selectedFiles.length > 1) {
                return alert("Multiple files are not support.");
            }

            var fileName = selectedFiles[0].name;
            var imageExtension = fileName.substr(fileName.lastIndexOf("."), fileName.length).toLowerCase();
            if (imageExtension == ".jpg" || imageExtension == ".jpeg" || imageExtension == ".gif" || imageExtension == ".png" || imageExtension == ".bmp") {

                data = new FormData();
                for (i = 0; i < selectedFiles.length; i++) {
                    data.append(selectedFiles[i].name, selectedFiles[i]);

                    document.getElementById("<%=hdnImageName.ClientID %>").value = selectedFiles[i].name;
                    $("#drop_zone").append(selectedFiles[i].name + "</br>");
                }

            }
            else {
                document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML = "<font color='red'>Your image is not in the correct file format; please use .jpeg, .jpg, .gif, .png or .bmp only.</font>";
                return;
            }

            document.getElementById("<%=hdnUploadTye.ClientID %>").value = "drop";
        } // end 

        function UploadFiles() {
            document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML = '';
            document.getElementById("<%=pnlShowLoader.ClientID %>").style.display = "block";
            if (document.getElementById("<%=hdnUploadTye.ClientID %>").value == "drop") {
                var RootPath = '<%=RootPath %>';
                var PID = '<%=ProfileID %>';
                var xhr = new XMLHttpRequest();
                xhr.open('POST', RootPath + '/Business/MyAccount/UploadBGImages.ashx?PID=' + PID);
                xhr.onload = function () {
                    if (xhr.status === 200) {
                        var reponse = xhr.response;
                        var path = RootPath + "/upload/TempBGImages/" + reponse;
                        document.getElementById("<%=hdnImageName.ClientID %>").value = reponse;
                        if (document.getElementById("<%=pnlSubmit.ClientID %>").style.display == 'none')
                            document.getElementById("<%=pnlSubmit.ClientID %>").style.display = "block";
                        document.getElementById("<%=lblImg.ClientID %>").innerHTML = "<IMG width='150px' src='" + path + "' />";
                        document.getElementById("<%=lnkResize.ClientID %>").click()
                        document.getElementById("<%=pnlShowLoader.ClientID %>").style.display = "none";

                    } else {
                        console.log('Something went terribly wrong...');
                    }
                };
                xhr.send(data);
                return false;
            }
            else {
                return true;
            }
        }
        function SetFileName() {
            document.getElementById("<%=hdnUploadTye.ClientID %>").value = "upload";
        }
        var dummyWidth = 0;
        var dummyHeight = 0;
        var maxCropWidth = 0;
        var maxCropHeight = 0;
        var minCropWidth = 0;
        var minCropHeight = 0;
        var cordswidth = 0;
        var cordsheight = 0;
        var cordsX = 0;
        var cordsY = 0;
        var resizedWidth = 0;
        var basedHeight = 410;
        var originalMaxCropWidth = 0;
        var originalMaxCropHeight = 0;
        var basedHeight = 410;
        // Crop BG Image
        function BGImgSettings(definedCropWidth, definedCropHeight, cropWidth, cropHeight, imgWidth, imgHeight) {
            //Preview Thumb
            var targetImg = document.getElementById("jcrop_target");
            var previewImg = document.getElementById("imgPreview");
            previewImg.src = document.getElementById("<%=hdnImgURL.ClientID %>").value;
            targetImg.src = document.getElementById("<%=hdnImgURL.ClientID %>").value;
            document.getElementById("<%=lblMaxWidth_Height.ClientID %>").innerHTML = cropWidth + " x " + cropHeight;
            dummyWidth = imgWidth;
            dummyHeight = imgHeight;
            originalMaxCropWidth = cropWidth;
            originalMaxCropHeight = cropHeight;
            // *** Calculating original image width based on height *** //
            resizedWidth = Math.round(Number((imgWidth * basedHeight) / imgHeight));
            targetImg.width = previewImg.width = resizedWidth;
            targetImg.height = previewImg.height = basedHeight;
            targetImg.style.width = previewImg.style.width = resizedWidth;
            targetImg.style.height = previewImg.style.height = basedHeight;
            // *** Calculating crop settings *** //
            maxCropHeight = Math.round(Number((cropHeight * basedHeight) / imgHeight));
            maxCropWidth = Math.round(Number((cropWidth * basedHeight) / imgHeight));
            minCropHeight = Math.round(Number((definedCropHeight * basedHeight) / imgHeight));
            minCropWidth = Math.round(Number((definedCropWidth * basedHeight) / imgHeight));
            var initialmarginleft = Math.round(Number((resizedWidth - minCropWidth) / 2));
            var initialmargintop = Math.round(Number((basedHeight - minCropHeight) / 2));
            $('#jcrop_target').Jcrop({
                onChange: showPreview,
                onSelect: showPreview,
                onRelease: hidePreview,
                setSelect: [initialmarginleft, initialmargintop, initialmarginleft + minCropWidth, initialmargintop + minCropHeight],
                minSize: [minCropWidth, minCropHeight],
                maxSize: [maxCropWidth, maxCropHeight],
                aspectRatio: 100 / 125,
                allowResize: true

            });
        }
        function showPreview(coords) {
            if (parseInt(coords.w) > 0) {
                cordswidth = Math.round(Number((coords.w * dummyHeight) / basedHeight));
                cordsheight = Math.round(Number((coords.h * dummyHeight) / basedHeight));
                cordsX = Math.round(Number((coords.x * dummyHeight) / basedHeight));
                cordsY = Math.round(Number((coords.y * dummyHeight) / basedHeight));
                document.getElementById("<%=hdnx.ClientID %>").value = cordsX;
                document.getElementById("<%=hdny.ClientID %>").value = cordsY
                document.getElementById("<%=hdnw.ClientID %>").value = cordswidth > originalMaxCropWidth ? originalMaxCropWidth : cordswidth;
                document.getElementById("<%=hdnh.ClientID %>").value = cordsheight > originalMaxCropHeight ? originalMaxCropHeight : cordsheight;
                document.getElementById("<%=lblCurrentWidth_Height.ClientID %>").innerHTML = cordswidth + " x " + cordsheight;
                var rx = 150 / coords.w;
                var ry = 225 / coords.h;
                $('#imgPreview').css({
                    width: Math.round(rx * resizedWidth) + 'px',
                    height: Math.round(ry * basedHeight) + 'px',
                    marginLeft: '-' + Math.round(rx * coords.x) + 'px',
                    marginTop: '-' + Math.round(ry * coords.y) + 'px'
                }).show();
            }
        }

        function hidePreview() {
            $('#imgPreview').stop().fadeOut('fast');
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlVideo" runat="server" Width="953px" CssClass="modalPopup">
                <asp:HiddenField ID="hdnUploadTye" runat="server" />
                <asp:HiddenField runat="server" ID="hdnImageName" />
                <asp:HiddenField runat="server" ID="hdnCropImgName" />
                <asp:HiddenField ID="hdnToggle" runat="server" Value="0" />
                <table cellpadding="0" cellspacing="0" class="upload-table">
                    <tr>
                        <td valign="top" class="col-1">
                            <div class="header">
                                Upload Image
                            </div>
                            <br />
                            <br />
                            <table class="body" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tbody>
                                    <tr>
                                        <td style="line-height: 20px;">
                                            <asp:Label ID="lblerrormsg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div id="drop_zone">
                                                Drop files here</div>
                                            <div style="float: left;">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>(OR )</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:FileUpload ID="FUUserImages" runat="server" onchange="SetFileName();" />
                                            <br />
                                            <span class="profile-caption red-color">NOTE: Please use gif, jpeg, png or bmp files
                                                only.</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel runat="server" ID="pnlShowLoader" Style="display: none;">
                                                <div style="text-align: center;">
                                                    <img src="<%=Page.ResolveClientUrl("../../Images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                                        color="green">Processing....</font></b>
                                                </div>
                                            </asp:Panel>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../Images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:LinkButton ID="btnUpload" runat="server" Text="Upload" CssClass="btnorange"
                                                OnClientClick="return UploadFiles();" OnClick="btnUpload_OnClick"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblError"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:Panel ID="pnlSubmit" runat="server">
                                <table class="body" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="padding-top: 10px;">
                                                <asp:Label ID="lblImg" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lbloriginalWidthk" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkResize" Text="Resize Images" CssClass="btn"
                                                    OnClick="lnkResizeImage_OnClick" Style="display: none;"></asp:LinkButton>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <span style="text-align: left; line-height: 20px;">Note: If you are satisfied with your
                                                    image, please select Submit. </span>
                                                <br />
                                                <asp:LinkButton runat="server" ID="lnkSubmit" Text="Submit" CssClass="btn btn-submit"
                                                    OnClick="btnSubmit_OnClick"></asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton runat="server"
                                                        ID="lnkTryAgain" Text="Reset Crop Area" CssClass="btn btn-submit" OnClick="lnkTryAgain_OnClick"></asp:LinkButton>
                                                <br />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                        <td valign="top" class="divider">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <div id="gallery" style="border: solid 0px #4684C5; padding: 25px 10px 10px; width: 330px;
                                            margin: 0px auto;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Panel ID="pnlDeleteTop" runat="server">
                                                            Remove Background Image From App
                                                            <asp:LinkButton ID="lnkDeleteTop" runat="server" CssClass="btnorange" Text="Delete"
                                                                OnClientClick="return confirm('Are you sure you want to delete this?')" OnClick="lnkDelete_OnClick"
                                                                Style="margin-top: 10px;"></asp:LinkButton>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlCancelTop" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        Cancel uploaded image and try a different image.
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="padding-top: 10px;">
                                                                        <asp:LinkButton ID="lnkCancelTop" runat="server" CssClass="btnorange" Text="Cancel"
                                                                            OnClientClick="return CancelUpload();" OnClick="lnkCancel_OnClick" Style="margin-top: 20px;"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="ltrBGImagePreview" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <b>Note:</b> Click the tab above the buttons to expand
                                                        <br />
                                                        or collapse and view the entire image.
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" style="width: auto;">
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="BGModalPopup" runat="server" TargetControlID="lblpre"
                                PopupControlID="pnlpopup1" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel ID="pnlpopup1" runat="server" Width="50%" Style="display: none;">
                                <table border="0" align="center" cellpadding="0" cellspacing="0" class="popup">
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
                                                <tr>
                                                    <td style="padding-left: 0px;">
                                                        <div style="float: left;">
                                                            <table border="0" cellpadding="0" cellspacing="0" class="resizelogo1" id='tblCropLogo'>
                                                                <tr>
                                                                    <td>
                                                                        <div style="display: none;">
                                                                            Max Crop Area Size:
                                                                            <asp:Label runat="server" ID="lblMaxWidth_Height" Font-Bold="true"></asp:Label>
                                                                            Selected Crop Area Size:
                                                                            <asp:Label runat="server" ID="lblCurrentWidth_Height" Font-Bold="true"></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-left: 10px;" align="center">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="90%">
                                                                            <tr>
                                                                                <td>
                                                                                    <div style="width: auto; height: 420px; overflow: auto; visibility: visible; display: block;">
                                                                                        <img id="jcrop_target" style="visibility: visible; display: block;" />
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
                                                                                <td valign="top" align="center" style="border-left: 1px solid #B85750; padding-left: 15px">
                                                                                    <div style="width: 150px; height: 225px; overflow: hidden; margin-left: 5px; border: 2px solid #B7521E;">
                                                                                        <img id="imgPreview" />
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="padding-top: 10px;">
                                                        <asp:LinkButton ID="lnkImageSubmit" runat="server" Width="76" Height="34" OnClick="btnCrop_OnClick"><img src="../../images/logos/submit.png" alt="" />
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
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function CancelUpload() {
            return confirm('Are you sure you want to cancel this?');
        }
    </script>
</asp:Content>
