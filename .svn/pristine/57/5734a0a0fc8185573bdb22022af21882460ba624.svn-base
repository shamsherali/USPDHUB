<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="MemberInformation.aspx.cs" Inherits="USPDHUB.Admin.MemberInformation"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/Business/MyAccount/UCEditor.ascx" TagName="UCEditor" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function blockSplChar(id) {
            id.value = filterNum(id.value)
            function filterNum(str) {

                re = /\$|@|#|~|`|\%|\*|\^|\\|\(|\)|\+|\=|\[|\_|\]|\[|\}|\{|\;|\:|\"|\<|\>|\?|\||\!|\$|/g;
                // remove special characters like "$" and "," etc...                 
                return str.replace(re, "");

            }
        }
        function blockSplChar1(id) {

            id.value = filterNum(id.value)
            function filterNum(str) {
                re = /\$|,|@|#|~|`|\%|\*|\^|\/|\&|\(|\)|\+|\=|\[|\_|\]|\[|\}|\{|\;|\:|\"|\<|\>|\?|\||\\|\!|\$|/g;
                // remove special characters like "$" and "," etc...
                return str.replace(re, "");

            }
        }

    </script>
    <script language="javascript" type="text/javascript">
        function blockChar(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_cphUser_txtphonenumber').keyup(function (event) {
                // Allow: backspace, delete, tab, escape, and enter // Allow: home, end, left, right
                if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                    return;
                }
                else {
                    // Ensure that it is a number and stop the keypress
                    if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                        event.preventDefault();
                    }
                }
                var val = this.value.replace(/\D/g, '');
                var newVal = '';
                if (val.length > 10) {
                    val = val.substring(0, 10)
                }
                while (val.length >= 3 && newVal.length <= 7) {
                    newVal += val.substr(0, 3) + '-';
                    val = val.substr(3);
                }
                newVal += val;
                this.value = newVal;
            });
        });
        
    </script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_cphUser_txtfaxnumber').keyup(function (event) {
                // Allow: backspace, delete, tab, escape, and enter // Allow: home, end, left, right
                if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                    return;
                }
                else {
                    // Ensure that it is a number and stop the keypress
                    if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                        event.preventDefault();
                    }
                }
                var val = this.value.replace(/\D/g, '');
                var newVal = '';
                if (val.length > 10) {
                    val = val.substring(0, 10)
                }
                while (val.length >= 3 && newVal.length <= 7) {
                    newVal += val.substr(0, 3) + '-';
                    val = val.substr(3);
                }
                newVal += val;
                this.value = newVal;
            });
        });
        
    </script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_cphUser_txtmobile').keyup(function (event) {
                // Allow: backspace, delete, tab, escape, and enter // Allow: home, end, left, right
                if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                    return;
                }
                else {
                    // Ensure that it is a number and stop the keypress
                    if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                        event.preventDefault();
                    }
                }
                var val = this.value.replace(/\D/g, '');
                var newVal = '';
                if (val.length > 10) {
                    val = val.substring(0, 10)
                }
                while (val.length >= 3 && newVal.length <= 7) {
                    newVal += val.substr(0, 3) + '-';
                    val = val.substr(3);
                }
                newVal += val;
                this.value = newVal;
            });
        });
        
    </script>
    <script type="text/javascript">
        var BrowserVersion = $.browser.version;
        window.onload = function () {
            if (BrowserVersion == "10.0") {
                $('.textdivStyle img').each(function () {
                    $(this).removeAttr('width')
                    $(this).removeAttr('height');
                });
            }
        }

        $(function () {
            $(".drop").sortable({
                connectWith: ".drop",
                scrollSpeed: 5
            });

            $(".drop").disableSelection();
        });

        function DeleteLogoMessage() {

            var result = confirm(' Are you sure you want to delete this logo?');
            if (result) {
                PreviewHTML('1');
                return result;
            } else {
                return result;
            }
        }

        function ShowPreview() {

            var divCount = $("#maintable div").size();
            if (divCount > 0) {
                var myBehavior = $find("popupop");

                PreviewHTML('1');
                var HtmlBody = document.getElementById("<%=hdnPreviewHTML.ClientID %>").value;
                $get('<%=lblPreviewHTML.ClientID %>').innerHTML = HtmlBody;
                myBehavior.show();

                return false;
            }
            else {
                alert("You haven't built your description yet.");
                return false;
            }
        }

        var EntID = "";

        function PreviewHTML(type) {

            var trs = '';
            var tds = '';
            var getHTML = '';
            var PreviewHTML = '';

            document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = "";

            var divtable = document.getElementById("maintable");

            if (divtable != null) {
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
                                        var imgAlignment = document.getElementById(id).style.textAlign;
                                        tds = tds + "<tr><td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align:" + imgAlignment + ";'>" + getHTML + "</td></tr>";
                                    }

                                }
                            }
                        }
                    }

                }

                PreviewHTML = "<table style='margin-left:20px; border:1px solid black;' border='0'  >" + trs + "</table>";


                document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = PreviewHTML;
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                LoadEventForPlayVideo();
            }
        }


        function AddBlocks(blockname) {

            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"450px\" style=\"border: 0px solid gray; " +
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
                editingBlock = "<img src='../../Images/EditText.png'  style='cursor: pointer; margin-left:5px;' onclick='ShowPopup(edit" + CID + ")' />";
            }
            else if (blockname == "DIV_IMAGE") {
                editingBlock = "<img  src='../../Images/EditImage.png'  style='cursor: pointer; margin-left:5px;' onclick='EditImage(edit" + CID + ")' />";
            }
            else if (blockname == "DIV_VIDEO") {
                editingBlock = "<img  src='../../Images/EditVideo.png'  style='cursor: pointer; margin-left:5px;' onclick='EditVideo(edit" + CID + ")' />";
            }

            var newRow = "<tr id='tr" + CID + "' >" +
                            "<td class='drop ui-sortable' style='min-height: 20px;'>" +
                                " <div id='parentedit" + CID + "' style='float: left; margin-top: 10px;' class='assigned' >" +
                                       "<div id='edit" + CID + "' style='min-height: 100px; padding: 5px; float: left;' class='textdivStyle' >" +
                                       "</div>" +
                                        "<div id='editsection" + CID + "' class='editsectionclass' style='float:left;' >" + editingBlock +
                                          "<br/><img class='deleteblockclass'  src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px; margin-left:5px;' onclick='RemoveBlock(edit" + CID + ")' />" +
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
                if (document.getElementById("<%=hdnButtonType.ClientID %>").value == "home")
                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
                else
                    document.getElementById("<%=hdnEditHTML_About.ClientID %>").value = document.getElementById("maintable").outerHTML;
            }
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
            document.getElementById('divImageframe').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "/Business/MyAccount/Bulletin_ImageGallery.aspx?PID=" + document.getElementById("<%=hdnPID.ClientID %>").value + "&fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 32) + "&imgSrc=" + imgSrc + "&UID=" + document.getElementById("<%=hdnUID.ClientID %>").value);
            ifrm.style.height = "750px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('divImageframe').appendChild(ifrm);
            document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("popupimage");
            modalDialog.show();

        }   //Show the Video Gallery
        function EditVideo(value) {
            imgdivID = value.id;

            document.getElementById('divVideomIframe').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            var videoSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "/Business/MyAccount/BulletinVideoGallery.aspx?VideoSrc=" + videoSrc);
            //ifrm.style.height = "750px";
            ifrm.style.height = "180px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('divVideomIframe').appendChild(ifrm);
            document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("VidePreview");
            modalDialog.show();

        }

        function ClosePopup() {
            var Iframe = document.getElementById("IframeVideoPopup");
            Iframe.src = "";
        }


        //Show the Video Preivew
        function PlayVideo(videoUrl) {

            var Iframe = document.getElementById("IframeVideoPopup");
            var videoID = "";
            var playUrl = "";

            //url = url + "?autoplay=1";
            //Iframe.src = "//www.youtube.com/embed/DS88TwUvzjM?rel=0";
            if (videoUrl.indexOf("youtube") != -1) {
                videoID = videoUrl.match(/youtube\.com.*(\?v=|\/embed\/)(.{11})/).pop();
                playUrl = "//www.youtube.com/embed/" + videoID + "";

            }
            else if (videoUrl.indexOf("vimeo.com") != -1) {

                var match = /vimeo.*\/(\d+)/i.exec(videoUrl);
                videoID = match[1];
                playUrl = "//player.vimeo.com/video/" + videoID;
            }


            Iframe.src = playUrl;
            var modalDialog = $find("VideoPreviewPlay");
            modalDialog.show();

        }

        function LoadEventForPlayVideo() {
            $('.videoclass1').mousedown(function (event) {
                var Url = this.href;
                //alert(1);

                switch (event.which) {
                    case 1:
                        //alert('Left mouse button pressed');
                        PlayVideo(Url);
                        //$(this).attr('target','_self');
                        break;
                    case 2:
                        //alert('Middle mouse button pressed');
                        PlayVideo(Url);
                        //$(this).attr('target','_blank');
                        break;
                    case 3:
                        //alert('Right mouse button pressed');
                        PlayVideo(Url);
                        //$(this).attr('target','_blank');
                        break;
                    default:
                        //alert('You have a strange mouse');
                        PlayVideo(Url);
                        //$(this).attr('target','_self"');
                }
            });


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
        .stepswrap
        {
            overflow: hidden;
            margin: 0 auto;
            width: 488px;
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
        .tabs-list, .tabs-section
        {
            float: left;
            width: 100%;
        }
        .tabs-section
        {
            min-height: 250px;
            background-color: #FFFFFF;
            border: 1px solid #ccc;
        }
        .btn-tab
        {
            background: #f2f2f2;
            border: 1px solid #ccc;
            border-radius: 4px 4px 0 0;
            padding: 10px 20px;
            color: #00436d;
            font-weight: bold;
            font-family: Arial, sans-serif;
            font-size: 16px;
            text-decoration: none;
            display: inline-block;
        }
        .btn-tab.active
        {
            background: #0266a6;
            background: -moz-linear-gradient(#0266a6, #014068);
            background: -webkit-linear-gradient(#0266a6, #014068);
            background: -o-linear-gradient(#0266a6, #014068);
            background: -ms-linear-gradient(#0266a6, #014068);
            background: linear-gradient(#0266a6, #014068);
            filter: progid:DXImageTransform.Microsoft.gradient(GradientType=0,startColorstr='#0266a6', endColorstr='#014068');
            border-color: #014068;
            color: #fff;
        }
    </style>
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.sortable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.droppable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.draggable.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.Jcrop.js" type="text/javascript"></script>
    <link href="../css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            LoadImage();
        })


        function LoadImage() {

            var imgOriginalWidth = document.getElementById("<%=hdnOriginalWidth.ClientID %>").value;
            var imgOriginalHeight = document.getElementById("<%=hdnOriginalHeight.ClientID %>").value;
            if (document.getElementById("imgMain") != null) {
                document.getElementById("imgMain").src = document.getElementById("<%=hdnImgURL.ClientID %>").value;
                document.getElementById("imgMain").style.width = imgOriginalWidth;
                document.getElementById("imgMain").style.height = imgOriginalHeight;

                document.getElementById("imgMain").width = imgOriginalWidth;
                document.getElementById("imgMain").height = imgOriginalHeight;
            }

            var LogoWidth;
            var LogoHeight;
            if (document.getElementById("<%= rbShortLogo.ClientID %>").checked == true) {
                LogoWidth = '<%= ConfigurationManager.AppSettings.Get("ShortLogoWidth") %>';
                LogoHeight = '<%= ConfigurationManager.AppSettings.Get("ShortLogoHeight") %>';

                document.getElementById("<%=lblLogoType.ClientID %>").innerHTML = "Short Logo";
            }
            else {
                LogoWidth = '<%= ConfigurationManager.AppSettings.Get("LongLogoWidth") %>';
                LogoHeight = '<%= ConfigurationManager.AppSettings.Get("LongLogoHeight") %>';

                document.getElementById("<%=lblLogoType.ClientID %>").innerHTML = "Long Logo";
            }

            document.getElementById("<%=lblFixedWidth.ClientID %>").innerHTML = LogoWidth + "px";
            document.getElementById("<%=lblFixedHeight.ClientID %>").innerHTML = LogoHeight + "px";

            if (document.getElementById("<%=rbShortLogo.ClientID %>").checked == true) {
                $("#tblTempLogo").css("display", "block");
                $("#trShortLogooptional1").css("display", "block");
                $("#trShortLogooptional2").css("display", "block");
                $("#trShortLogooptional3").css("display", "block");
                document.getElementById("TempShortLogo").src = document.getElementById("<%=hdbTempShortLogoURL.ClientID %>").value;
            }
            else {
                $("#tblTempLogo").css("display", "none");
                $("#trShortLogooptional1").css("display", "none");
                $("#trShortLogooptional2").css("display", "none");
                $("#trShortLogooptional3").css("display", "none");
            }


            if (parseInt(imgOriginalWidth) > parseInt(LogoWidth) || parseInt(imgOriginalHeight) > parseInt(LogoHeight)) {
                LoadImgSettings(LogoWidth, LogoHeight);
            }
            else {
                document.getElementById("<%=hdnx.ClientID %>").value = 0;
                document.getElementById("<%=hdny.ClientID %>").value = 0;
                document.getElementById("<%=hdnw.ClientID %>").value = imgOriginalWidth;
                document.getElementById("<%=hdnh.ClientID %>").value = imgOriginalHeight;
            }

        }


        function LoadImgSettings(LogoWidth, LogoHeight) {
            $('#imgMain').Jcrop({
                onSelect: getcroparea,
                setSelect: [20, 20, LogoWidth, LogoHeight],
                minSize: [LogoWidth, LogoHeight],
                maxSize: [LogoWidth, LogoHeight],
                allowResize: false

            });
        }

        function SetImgURL() {
            LoadImage();
        }

        function getcroparea(c) {

            document.getElementById("<%=hdnx.ClientID %>").value = c.x;
            document.getElementById("<%=hdny.ClientID %>").value = c.y;
            document.getElementById("<%=hdnw.ClientID %>").value = c.w;
            document.getElementById("<%=hdnh.ClientID %>").value = c.h;


            //            $('#hdnx').val(c.x);
            //            $('#hdny').val(c.y);
            //            $('#hdnw').val(c.w);
            //            $('#hdnh').val(c.h);
        };

        function DisplayCropImg(IsDisplay) {
            if (IsDisplay == true) {
                $("#tblCropLogo").css("display", "block");
            }
            else {
                $("#tblCropLogo").css("display", "none");
            }
        }


    </script>
    <div id="TipLayer" style="visibility: hidden; position: absolute; z-index: 1000;
        top: -100">
    </div>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/main.js")%>"
        type="text/javascript"></script>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/dashboardstyle.js")%>"
        type="text/javascript"></script>
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
        <tr>
            <td class="valign-top">
                <uc3:wowmap ID="sitemaplinks" runat="server" />
                <asp:UpdatePanel ID="uppnlpopup1" runat="server">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                                        Style="border: 0; border-color: White!important;"></asp:TextBox>
                                    Edit Member Information
                                </td>
                                <td class="right">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing"
                                                style="color: Green; font-size: 12px;">Processing....</span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" class="inputgrid" style="font-size: 12px;">
                                    <asp:Label ID="lblstatusmessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                                    ValidationGroup="g" HeaderText="The following error(s) occurred:" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="margin-top">
                            <tr>
                                <td class="valign-top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>" width="9"
                                                    height="28">
                                            </td>
                                            <td class="new-header">
                                                App Details
                                            </td>
                                            <td>
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>" width="9"
                                                    height="28">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="profile-input">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="lable" nowrap valign="top">
                                                            Organization Name:
                                                            <asp:TextBox ID="txtBusinessname" MaxLength="50" runat="server" Width="290px" onkeyup="CountMaxLength(this,'Agency Name');"
                                                                onChange="CountMaxLength(this,'Agency Name');"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBusinessname"
                                                                runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Agency Name is mandatory.">*</asp:RequiredFieldValidator>
                                                            <a style="display: none;" id="A4" href="javascript:ModalHelpPopup('Add/Change Organization s Name',163,'');">
                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                            <br />
                                                            <span style="margin-left: 80px; font-size: normal;">You have
                                                                <asp:Label ID="lblLength" runat="server"></asp:Label>
                                                                characters left.</span><span style="margin-left: 50px;">(Max Characters 50)</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #04519D;">
                                                    <colgroup>
                                                        <col width="50%" />
                                                        <col width="*" />
                                                    </colgroup>
                                                    <tr>
                                                        <td class="lable" nowrap valign="top" colspan="2">
                                                            Address & Phone Numbers
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding-left: 5px">
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        <font color="red">*</font>Address 1:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 285px;">
                                                                        <asp:TextBox ID="txtaddress1" MaxLength="75" runat="server" Width="270px" TabIndex="3"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtaddress1"
                                                                            runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Address1 is mandatory.">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        Address 2:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 285px;" colspan="2">
                                                                        <asp:TextBox ID="txtaddress2" MaxLength="75" runat="server" Width="270px" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        <font color="red">*</font>City:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 285px;">
                                                                        <asp:TextBox ID="txtcity" MaxLength="75" runat="server" Width="270px" TabIndex="6"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtcity"
                                                                            runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="City is mandatory.">*</asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="g"
                                                                            runat="server" ErrorMessage="Special Characters are not Allowed for City." ControlToValidate="txtcity"
                                                                            Display="Dynamic" ValidationExpression="^\s*[a-zA-Z0-9,\s]+\s*$">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding-left: 5px;
                                                                padding-bottom: 5px;">
                                                                <colgroup>
                                                                    <col width="125px" />
                                                                    <col width="80px" />
                                                                    <col width="80px" />
                                                                    <col width="100px" />
                                                                </colgroup>
                                                                <tr>
                                                                    <td class="lable" nowrap>
                                                                        <font color="red">*</font>State:
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        <font color="red">*</font>Zip Code:
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtState" TabIndex="7" runat="server">
                                                                        </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtState"
                                                                            ErrorMessage="State is mandatory." Font-Size="14px" ValidationGroup="g" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:TextBox ID="txtzipcode" MaxLength="8" runat="server" Width="65px" Rows="7" TabIndex="10"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtzipcode"
                                                                            runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Zip Code is mandatory.">*</asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                                                                            SetFocusOnError="True" ControlToValidate="txtzipcode" ValidationExpression="^[0-9]{5,8}$"
                                                                            ValidationGroup="g">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        <font color="red">*</font>Country:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCountry" TabIndex="11" runat="server" Width="241">
                                                                        </asp:DropDownList>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCountry" InitialValue="0"
                                                                            runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Country is mandatory.">*</asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <colgroup>
                                                                    <col width="220px" />
                                                                    <col width="*" />
                                                                </colgroup>
                                                                <tr>
                                                                    <td class="lable" nowrap>
                                                                        <font color="red">*</font>Phone Number:
                                                                    </td>
                                                                    <td>
                                                                        Extension:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtphonenumber" MaxLength="12" runat="server" Width="120px" TabIndex="12">
                                                                        </asp:TextBox>&nbsp;(xxx-xxx-xxxx)
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtphonenumber"
                                                                            runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Phone Number is mandatory.">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtextenction" runat="server" Width="60px" MaxLength="4" TabIndex="13"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="g"
                                                                            runat="server" ControlToValidate="txtphonenumber" ErrorMessage="Enter Valid Phone Number"
                                                                            Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        Fax Number:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtfaxnumber" MaxLength="12" runat="server" Width="120px" TabIndex="14"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator33" ValidationGroup="g"
                                                                            runat="server" ControlToValidate="txtfaxnumber" ErrorMessage="Enter Valid Fax Number"
                                                                            Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        Mobile Number:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 210px" colspan="2">
                                                                        <asp:TextBox ID="txtmobile" MaxLength="12" runat="server" Width="120px" TabIndex="16">
                                                                        </asp:TextBox>
                                                                        (xxx-xxx-xxxx)
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="g"
                                                                            runat="server" Display="Dynamic" ControlToValidate="txtmobile" ErrorMessage="Enter Valid Mobile Number"
                                                                            Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable">
                                                                        Select Time Zone:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:DropDownList ID="ddlTimeZone" runat="server" Width="170px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr id="tralternatenumberName" runat="server" visible="false">
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        Alternate Phone Number:
                                                                    </td>
                                                                </tr>
                                                                <tr id="tralternatenumberValue" runat="server" visible="false">
                                                                    <td>
                                                                        <asp:TextBox ID="txtAlternatePhone" MaxLength="13" runat="server" CssClass="medium textfield"
                                                                            TabIndex="17" Width="117px">
                                                                        </asp:TextBox>
                                                                        (xxx-xxx-xxxx)
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <%-- Logo Details--%>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
                                        <tr>
                                            <td colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>" width="9"
                                                    height="28">
                                            </td>
                                            <td class="new-header">
                                                Logo Details
                                            </td>
                                            <td>
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>" width="9"
                                                    height="28">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="profile-input">
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" align="center" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td align="center" style="padding-top: 10px;">
                                                                <asp:Image ID="logo" runat="server" Visible="false"></asp:Image>
                                                            </td>
                                                            <td align='left' valign='top'>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="align-center" colspan="2">
                                                                <br />
                                                                <asp:Button ID="btnLogoDelete" OnClick="btnLogoDelete_Click" OnClientClick="return DeleteLogoMessage();"
                                                                    runat="server" Text="Delete Logo" Style="margin-bottom: 5px;"></asp:Button>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <asp:Panel ID="pnlLogoUpload" runat="server">
                                                    <table class="profile-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td class="profile-caption">
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:RadioButton runat="server" GroupName="logo" ID="rbShortLogo" Text="Short Logo"
                                                                                    Checked="true" Font-Size="14px" Font-Bold="true" />
                                                                                <asp:RadioButton runat="server" GroupName="logo" ID="rbLongLogo" Text="Long Logo"
                                                                                    Font-Size="14px" Font-Bold="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding-top: 10px;">
                                                                                <asp:FileUpload ID="logoimage" runat="server"></asp:FileUpload>
                                                                            </td>
                                                                            <td style="padding-top: 10px;">
                                                                                <asp:LinkButton ID="BtnUpdateLogo" OnClick="BtnUpdateLogo_Click" runat="server" Text="<img src='../../images/upload.gif' border='0'/>"></asp:LinkButton>
                                                                                <a href="javascript:ModalHelpPopup('Add Logo',151,'');">
                                                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" style='border: 0px;' /></a>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="profile-caption red-color">
                                                                    NOTE: Please use gif, jpeg, png or bmp files only.<br />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="tab-box" style="margin-top: 20px;">
                                        <div class="tabs-list">
                                            <asp:LinkButton class="btn-tab active" runat="server" Text="Home" ID="lnkHome" OnClick="lnkHome_OnClick"></asp:LinkButton>
                                            <asp:LinkButton runat="server" class="btn-tab" Text="About Us" ID="lnkAboutUs" OnClick="lnkAboutUs_OnClick"></asp:LinkButton>
                                        </div>
                                        <div class="tabs-section">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="profile-input">
                                                <tr>
                                                    <td>
                                                        <div id="popup" style="display: none;">
                                                        </div>
                                                        <div id='editorPopup' style="display: none; position: absolute; margin-top: 150px;
                                                            margin-left: 150px; z-index: 100;">
                                                            <uc2:UCEditor ID="UCEditor1" runat="server" />
                                                        </div>
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
                                                                <a style="display: none;" id="A1" href="javascript:ModalHelpPopup('Add Text to Profile Details',165,'');">
                                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a><br />
                                                                <br />
                                                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_IMAGE');" src="../../Images/addnewimg.png" />
                                                                <a style="display: none;" id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Add Image to Profile Details',164,'');">
                                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                                <br />
                                                                <br />
                                                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_VIDEO');" src="../../Images/AddVideo.png" />
                                                            </div>
                                                        </div>
                                                        <input type="hidden" id='ids' value='' />
                                                        <input type="hidden" id='htmlvalue' />
                                                        <input type="hidden" id="editDivCheck" value="" />
                                                        <input type="hidden" id="hdnalignindex" />
                                                        <input type="hidden" id="hdnChanges" value="false" />
                                                        <asp:HiddenField runat="server" ID="hdnEditHTML" />
                                                        <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
                                                        <asp:HiddenField runat="server" ID="hdnEditHTML_About" />
                                                        <asp:HiddenField runat="server" ID="hdnPreviewHTML_About" />
                                                        <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
                                                        <asp:HiddenField ID="hdnButtonType" runat="server" Value="home" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 20px;">
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="profile-btntbl">
                                        <tr>
                                            <td align="center" valign="top">
                                                <asp:HiddenField runat="server" ID="hdnPID" Value="0" />
                                                <asp:HiddenField runat="server" ID="hdnUID" Value="0" />
                                                <asp:HiddenField ID="hdnVerticalName" runat="server" />
                                                <asp:HiddenField ID="hdntest" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdncontactname" runat="server"></asp:HiddenField>
                                                <asp:HiddenField runat="server" ID="hdnPermissionType" />
                                                <asp:HiddenField runat="server" ID="hdnResizeImageValue" />
                                                &nbsp;&nbsp;<asp:Button ID="btncancel" CssClass="button" runat="server" Text="Cancel"
                                                    TabIndex="30" OnClick="btncancel_OnClick" />&nbsp;&nbsp;<asp:Button ID="btnUpdate"
                                                        runat="server" Text="Update" OnClick="btnUpdate_onClick" OnClientClick="return test('g');"
                                                        CssClass="button" ValidationGroup="g" TabIndex="31" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="50%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="lblprev" runat="server" visiable="false"></asp:Label>
                                    <cc1:ModalPopupExtender ID="LogoModalPopup" runat="server" TargetControlID="lblprev"
                                        PopupControlID="pnlpopup2" BackgroundCssClass="modal" CancelControlID="imgClose">
                                    </cc1:ModalPopupExtender>
                                    <asp:Panel ID="pnlpopup2" runat="server" Width="50%" Style="display: none;">
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
                                                                    CausesValidation="false" OnClick="btnResizeCancel_Click"></asp:ImageButton>
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
                                                                    <span style="font-weight: bold;">Please use the logo that was resized to the recommended
                                                                        size of 110px X 110px.</span>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="resizelogo1">
                                                                        <tr>
                                                                            <td align="center">
                                                                                &nbsp;
                                                                                <img id="TempShortLogo" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr id="trShortLogooptional2">
                                                            <td align="center" style="padding: 20px;">
                                                                <span style="color: #d57300; font-size: 18px; padding: 10px; font-weight: bold;">(OR)</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left: 0px;">
                                                                <div style="float: left;">
                                                                    <span id="trShortLogooptional3">
                                                                        <asp:RadioButton runat="server" ID="rbUserCropLogo" GroupName="rb1" />
                                                                        <span style="font-weight: bold;">Do it yourself by selecting the part of the image that
                                                                            you wish to keep as the logo.</span> </span>
                                                                    <table border="0" cellpadding="0" cellspacing="0" class="resizelogo1" id='tblCropLogo'>
                                                                        <tr>
                                                                            <td style="padding-left: 10px;">
                                                                                <div style="width: 750px; height: 220px; overflow: auto;">
                                                                                    <img id="imgMain" />
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
                                                                <asp:LinkButton ID="lnkImageCancel" runat="server" Width="76" Height="34" OnClick="btnResizeCancel_Click"><img src="../../images/logos/cancel.png" alt="" />
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
                        <%--LOGO RESIZE--%>
                        <asp:Label ID="lblnewsimage" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="popnewsletterimage" runat="server" TargetControlID="lblnewsimage"
                            PopupControlID="pnlnewsletterimage" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlnewsletterimage" runat="server" Style="display: none" Width="730px">
                            <table cellpadding="0" cellspacing="0" width="730px">
                                <tbody>
                                    <tr>
                                        <td>
                                            <div id="framediv" runat="server">
                                                <%--  <iframe id="IFRAME" src="ResizeLogo.aspx" width="730px" height="590px" scrolling="no"
                                                    frameborder="0"></iframe>--%>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="BtnUpdateLogo" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblVideoPreview" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="popupVideo" runat="server" TargetControlID="lblVideoPreview"
                            PopupControlID="pnlVideoPreview" BackgroundCssClass="modal" CancelControlID="imgclosVidepepreviewpopup"
                            BehaviorID="VidePreview">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlVideoPreview" runat="server" Style="display: none" Width="700px">
                            <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                                background-color: #F8F6F6;">
                                <tbody>
                                    <tr>
                                        <td style="padding-right: 120px;" align="right">
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td align="right" style="padding: 5px 10px 20px 10px;">
                                            <asp:ImageButton ID="imgclosVidepepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mid" style="background-color: #F8F6F6;">
                                            <div id="divVideomIframe">
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblpopupVideoPlay" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="popupVideoPlay" runat="server" TargetControlID="lblpopupVideoPlay"
                            PopupControlID="pnlVideoPlay" BackgroundCssClass="modal" CancelControlID="imgclosVidepepreviewpopup1"
                            BehaviorID="VideoPreviewPlay">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlVideoPlay" runat="server" Style="display: none" Width="600px">
                            <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                                background-color: #F8F6F6;">
                                <tbody>
                                    <tr>
                                        <td style="padding-right: 120px;" align="right">
                                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td align="right" style="padding: 5px 10px 20px 10px;">
                                            <asp:ImageButton ID="imgclosVidepepreviewpopup1" runat="server" ImageUrl="~/images/popup_close.gif"
                                                OnClientClick="ClosePopup();" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mid" style="padding-left: 30px; padding-bottom: 20px;">
                                            <iframe id="IframeVideoPopup" width="640" height="375" frameborder="0" webkitallowfullscreen
                                                mozallowfullscreen allowfullscreen></iframe>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function test(group) {
            if (!Page_ClientValidate(group)) {
                document.getElementById('<%=txt.ClientID %>').focus();
                document.getElementById('<%=lblstatusmessage.ClientID %>').innerHTML = '';
            }
            else {
                document.getElementById('<%=txt.ClientID %>').focus();
                PreviewHTML('2');
            }
        }
        window.onload = function () {
            var divCount = $("#maintable div").size();
            if (divCount <= 0) {
                document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
            }
            CountMaxLength(document.getElementById('<%=txtBusinessname.ClientID %>'), 'Agency Name');

            // Disable vents for VideoBlock in Page
            DisableEventsForVideoBlocks();
        }

        // Disable vents for VideoBlock in Page
        function DisableEventsForVideoBlocks() {
            var links = $('.videoclass');
            for (var i = 0; i < links.length; i++) {
                links[i].addEventListener("click", function (e) {
                    //alert("NOPE!, I won't take you there haha");
                    //prevent event action
                    e.preventDefault();
                })
            }
        }

        function CountMaxLength(id, text) {
            var maxlength = 50;

            if (id.value.length > maxlength) {
                id.value = id.value.substring(0, maxlength);
                alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
            }
            document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;
        }
    </script>
</asp:Content>
