<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="BannerAdsUpload.aspx.cs" Inherits="USPDHUB.Business.MyAccount.BannerAdsUpload" %>

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
            width: 300px;
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
            margin: 0px auto;
            text-align: center;
            line-height: 100px;
            background: #f5f5f5;
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
        .cropselectionlimits, .cropselectionlimits-up, .cropselectionlimits-down
        {
            position: absolute;
            padding: 2px 5px;
            background-color: #FEFEFD; /*opacity:0.7;*/
            color: #000;
            z-index: 1000;
        }
        .cropselectionlimits-up:before
        {
            z-index: -1;
            position: absolute;
            top: -22%;
            left: 70%;
            margin-left: -25%;
            content: '';
            width: 0;
            height: 0;
            border-left: 5px solid transparent;
            border-right: 5px solid transparent;
            border-bottom: 5px solid #FEFEFD;
        }
        
        .cropselectionlimits-down:after
        {
            z-index: -1;
            position: absolute;
            top: 98.1%;
            left: 70%;
            margin-left: -25%;
            content: '';
            width: 0;
            height: 0;
            border-top: solid 5px #FEFEFD;
            border-left: solid 5px transparent;
            border-right: solid 5px transparent;
        }
         .fileready
        {
            color: Green;
            font-weight: bold;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlVideo" runat="server" Width="953px" CssClass="modalPopup">
                <asp:HiddenField ID="hdnUploadTye" runat="server" />
                <asp:HiddenField runat="server" ID="hdnImageName" />
                <asp:HiddenField runat="server" ID="hdnCropImgName" />
                <asp:HiddenField ID="hdnSlotNumber" runat="server" />
                <asp:HiddenField ID="hdnBannerId" runat="server" Value="0" />
                <table cellpadding="0" cellspacing="0" class="upload-table">
                    <tr>
                        <td valign="top">
                            <div class="header">
                                <asp:Label ID="lblHeader" runat="server" Text="Upload Image"></asp:Label>
                            </div>
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tr>
                                    <td style="padding: 10px;" align="center">
                                        <asp:Label ID="lblerrormsg" runat="server" Style="line-height: 20px;"></asp:Label><br />
                                        <asp:Label ID="lblShowPreview" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px;" align="center">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../Images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlUpload" runat="server">
                                <table class="body" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td colspan="2">
                                                <div id="drop_zone">
                                                    Drop file here</div>
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
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:FileUpload ID="FUUserImages" CssClass="fileready" runat="server" onchange="SetFileName();" Width="295px" />
                                                <br />
                                                <span class="profile-caption red-color">NOTE: Please use gif, jpeg, png or bmp files
                                                    only.</span>
                                                <br />
                                                <span style="color: #DC7224; font-weight: bold; margin-left: -90px;">Banner Ad Size:</span>
                                                <b>700px X 140px</b>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:LinkButton runat="server" ID="lnkBack1" Text="Back" CssClass="btn btn-submit"
                                                    OnClick="lnkBack_OnClick"></asp:LinkButton>
                                                &nbsp;&nbsp;
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
                            </asp:Panel>
                            <asp:Panel ID="pnlSubmit" runat="server">
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="padding-top: 10px;" align="center">
                                                <asp:Label ID="lblImg" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="center">
                                                <span style="margin-right: 230px; font-weight: bold;">Enter Link: </span>
                                                <br />
                                                <asp:TextBox runat="server" ID="txtLinkUrl" Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none;" align="center">
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkResize" Text="Resize Images" CssClass="btn"
                                                    OnClick="lnkResizeImage_OnClick" Style="display: none;"></asp:LinkButton>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <br />
                                                <span style="text-align: left; line-height: 20px;">Note: If you are satisfied with your
                                                    image, please select Submit. </span>
                                                <br />
                                                <asp:LinkButton runat="server" ID="lnkBack2" Text="Back" CssClass="btn btn-submit"
                                                    OnClick="lnkBack_OnClick"></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton runat="server" ID="lnkCancel" Text="Cancel" CssClass="btn btn-submit"
                                                    OnClick="lnkCancel_OnClick"></asp:LinkButton>
                                                &nbsp;&nbsp;
                                                <asp:LinkButton runat="server" ID="lnkSubmit" ValidationGroup="U" Text="Submit" CssClass="btn btn-submit"
                                                    OnClick="btnSubmit_OnClick" OnClientClick="return ValidateLinkUrl('1');"></asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                                                        runat="server" ID="lnkTryAgain" Text="Reset Crop Area" CssClass="btn btn-submit"
                                                        OnClick="lnkTryAgain_OnClick"></asp:LinkButton>
                                                <br />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlLink" runat="server">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0" class="body" style="width: 320px;"
                                    align="center">
                                    <tr>
                                        <td style="text-align: left;">
                                            <b>Enter link: </b>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtAdLink" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <asp:LinkButton runat="server" ID="LinkButton1" Text="Back" CssClass="btn btn-submit"
                                                OnClick="lnkBack_OnClick" Style="line-height: 22px;"></asp:LinkButton>
                                            &nbsp;&nbsp;
                                            <asp:LinkButton runat="server" ID="lnkUpadteLink" Text="Submit" CssClass="btn btn-submit"
                                                OnClick="lnkUpadteLink_OnClick" OnClientClick="return ValidateLinkUrl('2');"
                                                Style="line-height: 20px;"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" style="width: auto;">
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="BannerAdModalPopup" runat="server" TargetControlID="lblpre"
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
                                                                    <td align="center">
                                                                        <div style="width: 320px; height: 64px; overflow: hidden; border: 1px solid #B7521E;">
                                                                            <img id="imgPreview" />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="border-bottom: 1px solid #7C786A; padding-top: 10px;">
                                                                        <%--      <span style="color: #DC7224; font-weight: bold; font-size: 14px;">Recommended:</span>
                                                                        <b>700px x 140px</b>--%>
                                                                        <div style="font-size: 14px; line-height: 20px;">
                                                                            <div style="display: none;">
                                                                                Max Crop Area Size:
                                                                                <asp:Label runat="server" ID="lblMaxWidth_Height" Font-Bold="true"></asp:Label>
                                                                                <span style="color: #00AAA0; font-weight: bold;">Selected Crop Area Size:</span>
                                                                                <asp:Label runat="server" ID="lblCurrentWidth_Height"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 10px;" align="center">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="90%">
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <div style="width: 740px; height: 420px; overflow: auto; visibility: visible; display: block;">
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
        }
        function UploadFiles() {
            document.getElementById("<%=lblerrormsg.ClientID %>").innerHTML = '';
            document.getElementById("<%=pnlShowLoader.ClientID %>").style.display = "block";
            if (document.getElementById("<%=hdnUploadTye.ClientID %>").value == "drop") {
                var RootPath = '<%=RootPath %>';
                var PID = '<%=ProfileID %>';
                var xhr = new XMLHttpRequest();
                xhr.open('POST', RootPath + '/Business/MyAccount/UploadBGImages.ashx?savepath=TempBannerImages&PID=' + PID);
                xhr.onload = function () {
                    if (xhr.status === 200) {
                        var reponse = xhr.response;
                        var path = RootPath + "/Upload/TempBannerImages/" + reponse;
                        document.getElementById("<%=hdnImageName.ClientID %>").value = reponse;
                        if (document.getElementById("<%=pnlSubmit.ClientID %>").style.display == 'none')
                            document.getElementById("<%=pnlSubmit.ClientID %>").style.display = "block";
                        document.getElementById("<%=lblImg.ClientID %>").innerHTML = "<IMG width='320px' src='" + path + "' />";
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
        var definedCropW = 0;
        var row_str = '<div class="cropselectionlimits">##Width##px x ##Height##px</div>';
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
            definedCropW = definedCropWidth;
            // *** Calculating original image width based on height *** //
            if (imgHeight < basedHeight)
                basedHeight = imgHeight;
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
                aspectRatio: 100 / 20,
                allowResize: true

            });
        }
        function showPreview(coords) {
            if (parseInt(coords.w) > 0) {
                cordsheight = Math.round(Number((coords.h * dummyHeight) / basedHeight));
                cordsheight = (coords.h <= minCropHeight ? (definedCropW / 5) : cordsheight)
                cordswidth = cordsheight * 5;
                cordsX = Math.round(Number((coords.x * dummyHeight) / basedHeight));
                cordsY = Math.round(Number((coords.y * dummyHeight) / basedHeight));
                document.getElementById("<%=hdnx.ClientID %>").value = cordsX;
                document.getElementById("<%=hdny.ClientID %>").value = cordsY
                document.getElementById("<%=hdnw.ClientID %>").value = cordswidth > originalMaxCropWidth ? originalMaxCropWidth : cordswidth;
                document.getElementById("<%=hdnh.ClientID %>").value = cordsheight > originalMaxCropHeight ? originalMaxCropHeight : cordsheight;
                $('.cropselectionlimits').remove();
                $(".jcrop-holder").append(row_str.replace("##Width##", cordswidth).replace("##Height##", cordsheight));
                if (coords.y > 25) {
                    $('.cropselectionlimits').css('margin-top', coords.y - 30 + 'px').css('margin-left', (coords.x + Math.round(coords.w / 2)) - 5 - Math.round($('.cropselectionlimits').width() / 2));
                    $('.cropselectionlimits').addClass("cropselectionlimits-down");
                }
                else {
                    $('.cropselectionlimits').css('margin-top', coords.y + coords.h + 9 + 'px').css('margin-left', (coords.x + Math.round(coords.w / 2)) - 5 - Math.round($('.cropselectionlimits').width() / 2));
                    $('.cropselectionlimits').addClass("cropselectionlimits-up");
                }
                var rx = 320 / coords.w;
                var ry = 64 / coords.h;
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

        function ValidateLinkUrl(type) {
            var theurl = document.getElementById('<%=txtLinkUrl.ClientID %>').value;
            if (type == '2')
                theurl = document.getElementById('<%=txtAdLink.ClientID %>').value;
            if (theurl != "") {
                if (theurl != "" && !/^https?:\/\//i.test(theurl)) {
                    theurl = 'http://' + theurl;
                }
                if (type == '2')
                    document.getElementById('<%=txtAdLink.ClientID %>').value = theurl
                else
                    document.getElementById('<%=txtLinkUrl.ClientID %>').value = theurl
                var tomatch = /[http|https]:\/\/[A-Za-z0-9\.-]{3,}\.[A-Za-z]{2,}/
                if (!tomatch.test(theurl)) {
                    window.alert("Please enter a valid link.");
                    return false;
                }
            }
            return true;
        }
    </script>
</asp:Content>
