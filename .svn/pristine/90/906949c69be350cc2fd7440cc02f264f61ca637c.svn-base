<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="CMEditBulletin.aspx.cs" ValidateRequest="false" Inherits="USPDHUB.Business.MyAccount.CMEditBulletin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="UCEditor.ascx" TagName="UCEditor" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.sortable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.droppable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.draggable.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-bubble-popup-v3.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-bubble-popup-v3.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {

            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'Places watermark across image.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }

        });

        function transform(obj) {
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
            var val = obj.value.replace(/\D/g, '');
            var newVal = '';
            if (val.length > 10) {
                val = val.substring(0, 10);
            }
            while (val.length > 3 && newVal.length <= 7) {
                newVal += val.substr(0, 3) + '-';
                val = val.substr(3);
            }
            newVal += val;
            document.getElementById("<%=txtContentPhone.ClientID %>").value = newVal;

        }

    </script>
    <style type="text/css">
        .Default.reDropDownBody
        {
            z-index: 210990 !important;
        }
        .RadToolBar.RadToolBar_Default.rwNormalWindow.rwTransparentWindow
        {
            z-index: 110000 !important;
        }
        .RadToolBar.RadToolBar_Default.rwNormalWindow.rwTransparentWindow.rwInactiveWindow
        {
            z-index: 10990 !important;
        }
        #RadToolBar1
        {
            z-index: 10990 !important;
            display: block;
        }
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
        .stepswrap1
        {
            overflow: hidden;
            border: 1px solid #ccc;
            color: #2F348F;
            margin-top: 5px;
            padding: 10px 10px 5px 5px;
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
        .navy20
        {
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
            padding: 10px 0px 5px 0px;
        }
        .navy16
        {
            color: #2F348F;
            font-size: 14px;
            line-height: 22px;
            font-weight: bold;
            font-family: Arial;
        }
        .black16
        {
            color: #000;
            font-size: 14px;
            line-height: 22px;
            font-weight: bold;
            font-family: Arial;
        }
        .black16normal
        {
            color: #000;
            font-size: 14px;
            line-height: 22px;
            font-family: Arial;
        }
        .txtarea11
        {
            font-size: 14px;
            color: #000;
            border: #D3D3D3 2px solid;
            font-family: Arial;
            resize: none;
        }
        .border
        {
            border: 1px solid #04519D;
        }
        .cursor
        {
            cursor: hand;
        }
        #boxes .window
        {
            border: solid 2px #FFCC00;
            position: absolute;
            left: 0;
            top: 0;
            width: 490px;
            height: 200px;
            display: none;
            z-index: 9999;
        }
        #boxes #dialog
        {
            width: 500px;
            height: 369px;
            padding: 10px;
            background-color: #FFFFFF;
            margin-top: 12%;
            margin-left: 31%;
        }
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
        .drop div:hover
        {
            cursor: move;
        }
    </style>
    <script type="text/javascript">
        function CountMaxLength(id, e) {
            var maxlength = 12;
            var myRegExp = new RegExp(/^[^<&]+$/);
            if (myRegExp.test(id.value)) {
                if (id.value.length > maxlength) {
                    id.value = id.value.substring(0, maxlength);
                    alert('You have exceeded the maximum of ' + maxlength + ' characters.');
                }
                document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;

                return true;
            }
            else {
                if (e != undefined && (e.keyCode == 8 || e.keyCode == 46)) {
                    //
                }
                else {
                    document.getElementById('<%=txtLocated.ClientID %>').value = id.value.replace(/[&<]/g, '')
                    alert("Please do not enter & and < characters.");
                    return false;
                }
            }
        }
        $(function () {
            $(".drop").sortable({
                connectWith: ".drop",
                scrollSpeed: 5
            });

            $(".drop").disableSelection();
        });




        var EntID = "";

        function PreviewHTML(typeID) {
            EntID = typeID;

            var imgAtleast = false;
            var locatedText = "";
            var IsLocated = false
            IsLocated = document.getElementById("<%=chkLocated.ClientID %>").checked;
            locatedText = document.getElementById("<%=txtLocated.ClientID %>").value;

            if (typeID == 2 || typeID == 3) {
                ValidatePublishDate();
                //ExDate checking
                var allddls = document.getElementsByTagName("select");
                for (k = 0; k < allddls.length; k++) {
                    var controlName = allddls[k].id;
                    if (controlName.indexOf("ddlTime") >= 0) {
                        break;
                    }
                }
                if (document.getElementById("<%=txtExDate.ClientID %>").value != "") {
                    var currentdate = new Date();
                    var fromDate = document.getElementById("<%=txtExDate.ClientID %>").value + " " + document.getElementById(controlName).value;
                    var selDate = new Date(fromDate);

                    if (selDate <= currentdate) {
                        alert('Expiration date should be later than current date.');
                        return false
                    }
                }
            }


            var trs = '';
            var tds = '';
            var getHTML = '';
            var imgTag = '';

            var divCount = $("#maintable div").size();
            if (divCount > 0) {
                var divtable = document.getElementById("maintable");
                var IsListDescription = true;

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
                                        if (IsListDescription) {
                                            document.getElementById("<%=hdnDescription.ClientID %>").value = getHTML;
                                            IsListDescription = false;
                                        }
                                        tds = tds + "<tr><td  style='page-break-inside: avoid; width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align: left;'>" + getHTML + " </td></tr>";
                                    }
                                    else {
                                        imgAtleast = true;
                                        getHTML = getHTML.replace(/videoclass/gi, 'videoclass1');
                                        var imgAlignment = document.getElementById(id).style.textAlign;
                                        tds = tds + "<tr><td  style='page-break-inside: avoid; width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align:" + imgAlignment + ";'>" + getHTML + "</td></tr>";
                                    }

                                }
                            }
                        }
                    }
                }
            }

            document.getElementById('<%=hdnRootPath.ClientID %>').value = '<%=RootPath %>';

            if (IsLocated == true && imgAtleast == false) {

                tds = "<tr><td  style='page-break-inside: avoid; width:" + 270 + "px; padding-bottom: 2px; text-align:" + "center" + ";'>" + "<IMG SRC='#LocatedImage#' />" + "</td></tr>" + tds;
            }
            if ($("#<%=txtContentPhone.ClientID %>").val() != "") {

                tds = tds + "<tr><td  style='page-break-inside: avoid; padding-top: 5px; padding-bottom: 2px; text-align:left;'><a href='tel:" + $("#<%=txtContentPhone.ClientID %>").val() + "' style='text-decoration:none;'><img style=\"vertical-align:middle\" src='" + document.getElementById('<%=hdnRootPath.ClientID %>').value + "/Images/content_call.png'/> " + $("#<%=txtContentPhone.ClientID %>").val() + "</a></td></tr>";
            }


            var PreviewHTML = "<table style='margin-left:20px;' border='0'  >" + tds + "</table>";
            var bulletinHeader = document.getElementById("<%=hdnBulletinHeader.ClientID %>").value;
            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = PreviewHTML;


            if (EntID == 1) {

                bulletinHeader = bulletinHeader.replace("#BuildHtmlForForm#", PreviewHTML);

                // Shorten URL Purpose
                document.getElementById("divLoading").style.display = "block";
                bulletinHeader = bulletinHeader.replace(/</gi, "&lt;_");
                bulletinHeader = bulletinHeader.replace(/>/gi, "&gt;_");
                bulletinHeader = bulletinHeader.replace(/'/gi, "&quots;_");

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{htmlString:'" + bulletinHeader + "',locatedText:'" + locatedText + "',IsLocated:'" + IsLocated + "'}",
                    url: "CMEditBulletin.aspx/ReplaceShortURltoHmlString",
                    dataType: "json",
                    processData: false,
                    success: function (data) {
                        bulletinHeader = data.d;

                        document.getElementById("<%=lblnewspreview.ClientID %>").innerHTML = "";
                        document.getElementById("<%=lblnewspreview.ClientID %>").innerHTML = bulletinHeader;

                        var modal = $find("BulletinPreview");
                        modal.show();

                        document.getElementById('<%=lblmess.ClientID %>').innerHTML = "";
                        document.getElementById("divLoading").style.display = "none";
                        LoadEventForPlayVideo();
                    },
                    error: function (error) {
                        //alert("ERROR:: " + error.statusText);
                        document.getElementById("divLoading").style.display = "none";
                    }
                });


                return false;
            }
            else {
                if (Page_ClientValidate('ABC')) {
                    var isCompleted = false;
                    var isPrivate = false;

                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
                    isPrivate = document.getElementById('<%=rbPublish.ClientID %>').checked;
                    var exDate = document.getElementById("<%=txtExDate.ClientID %>").value;
                    if (document.getElementById('maintable') != null) {
                        document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                    }
                    document.getElementById("<%=hdnExDate.ClientID %>").value = exDate;
                    document.getElementById("<%=hdnPublish.ClientID %>").value = document.getElementById('<%=rbPublish.ClientID %>').checked;
                    document.getElementById("<%=hdnCompleted.ClientID %>").value = isCompleted;
                    $find("<%=MPEProgress.ClientID %>").show();
                    //PageMethods.ServerSideFill(divtable.outerHTML, PreviewHTML, isCompleted, isPrivate, typeID, exDate, OnSuccess, OnFail)
                    return true;
                }
            }
        }
        function OnSuccess(result) {

            if (EntID == "2") {
                document.getElementById('<%=lblmess.ClientID %>').innerHTML = 'Content saved successfully.';
                return true;
            }
            else if (EntID == "3") {
                window.location = result;
            }
        }
        function OnFail() {
        }



        function AddBlocks(blockname) {

            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"455px\" style=\"border: 0px solid gray; " +
                                                                        "min-height: 100px;\"> " +
                                                                    "</table>";

                document.getElementById("<%=lblBulletinedit.ClientID %>").innerHTML = maintableTag;
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
            else if (blockname == "DIV_WORDCONTENT") {
                editingBlock = "<img src='../../Images/EditText.png'  style='cursor: pointer; margin-left:5px;' onclick='ShowPopup(edit" + CID + ")' />";
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




            if (blockname != "DIV_WORDCONTENT") {
                $("#maintable").append(newRow);

                //Auto scroll when add new item
                var co = document.getElementById("parentedit" + CID);
                co.focus();
            }
            LoadBlocks();

            $(".avatar").animate({ scrollTop: $(".avatar").prop("scrollHeight") }, 1000);

            //USPD - 750 Change the way add text block works
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
            if (document.getElementById("maintable") != null) {
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
            }
            if (blockname == "DIV_TEXT") {
                ShowPopup(document.getElementById("edit" + CID));
            }
            else if (blockname == "DIV_IMAGE") {
                EditImage(document.getElementById("edit" + CID));
            }
            else if (blockname == "DIV_VIDEO") {
                EditVideo(document.getElementById("edit" + CID));
            }
            else if (blockname == "DIV_WORDCONTENT") {
                EditWordContent(document.getElementById("edit" + CID));
            }
        }

        function LoadBlocks() {
            $(".drop").sortable({
                connectWith: ".drop",
                scrollSpeed: 5
            });

            $(".drop").disableSelection();
        }

        function RemoveBlock(value) {
            var divID = value.id;
            var idNumber = divID.replace("edit", "");
            divID = "parent" + divID;
            if (confirm("Are you sure you want to delete this block?")) {
                var childdivsCount = $("#tr" + idNumber + " div").size();
                $("#" + divID).remove();
                document.getElementById("hdnChanges").value = "true";
            }

            var divCount = $("#maintable div").size();
            if (divCount <= 0) {
                document.getElementById('<%= lblBulletinedit.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
            }
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
            if (document.getElementById("maintable") != null) {
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
            }
        }

        function OnTextChanged() {
            document.getElementById("hdnChanges").value = "true";
        }
        function categoryonchange() {
            document.getElementById("hdnChanges").value = "true";
        }



        //Show the Image Gallery
        function EditImage(value) {
            imgdivID = value.id;
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 32) + "&imgSrc=" + imgSrc + "&folder=Templates");
            //ifrm.style.height = "750px";
            ifrm.style.height = "650px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('DIDIFrm').appendChild(ifrm);
            document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("popupimage");
            modalDialog.show();

        }

        //Show the Video Gallery
        function EditVideo(value) {
            imgdivID = value.id;

            document.getElementById('divVideomIframe').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            var videoSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "BulletinVideoGallery.aspx?VideoSrc=" + videoSrc);
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

        //Show the Word Content IFRAME Window
        function EditWordContent(value) {
            //imgdivID = value.id;

            document.getElementById('divFrameWordContent').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            //var videoSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "/Business/MyAccount/WordContentTemplate.aspx");
            //ifrm.style.height = "750px";
            ifrm.style.height = "340px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('divFrameWordContent').appendChild(ifrm);
            // document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("WordContentPreview");
            modalDialog.show();
        }


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
            if (document.getElementById('<%= rbPublish.ClientID%>').checked) {
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

        function ShowPublicPrivate(val, ischange) {
            document.getElementById("<%=rbPublish.ClientID %>").checked = true;
            document.getElementById("<%=rbUnPublish.ClientID %>").checked = false;
        }
        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
                DisplayComplete();
            if (document.getElementById('<%=rbPublish.ClientID %>').checked) {

                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";

            }
            else {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            }

            // Disable vents for VideoBlock in Page
            DisableEventsForVideoBlocks();
            CountMaxLength(document.getElementById('<%=txtLocated.ClientID %>'));
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

        function DisplayComplete() {
            if (document.getElementById('<%= rbPublish.ClientID%>').checked) {
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                    document.getElementById('divMandatory').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                    document.getElementById('divMandatory').style.display = "none";
                }
            }
        }
        function ShowPublish(val, ischanges) {
            if (ischanges == 'true') {
                document.getElementById("hdnChanges").value = "true";
            }
            if (val == "1") {
                document.getElementById('divpublish').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
                ShowPublishSave('1');
            } else if (val == "2") {
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                    document.getElementById('divMandatory').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                    document.getElementById('divMandatory').style.display = "none";
                }
                if (ischanges == "true" && document.getElementById('<%= txtPublishDate.ClientID%>').value == "") {
                    if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
                        GetCurrentDate();
                    ShowPublishSave('2');
                }
            }
        }
        function ShowPublishSave(val) {
            if (val == "1") {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
                document.getElementById('lblMandatory').style.display = "none";
            } else if (val == "2") {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }

            }
        }
        function SaveAlert() {
            var result;

            if (document.getElementById("hdnChanges").value == "true") {
                result = confirm('Do you want to save the changes you made to the bulletin?');
                if (result) {
                    PreviewHTML('3');
                    return true;
                }
                else {
                    var urlinfo = document.getElementById('<%=hdnRootPath.ClientID %>').value + "/Business/MyAccount/ManageAddOns.aspx";
                    window.location = urlinfo;

                    return false;
                }
            }
            else {
                var urlinfo = document.getElementById('<%=hdnRootPath.ClientID %>').value + "/Business/MyAccount/ManageAddOns.aspx";
                window.location = urlinfo;

                return false;
            }
        } 

    </script>
    <script type="text/javascript">

        var IsMainBold = false;
        var IsMainItalic = false;
        var IsMainUnderLine = false;
        var MainFontFamily = "";
        var MainFontSize = "16px";

        var MainFontColor = "Black";
        function GetUserFont() {
            return document.getElementById('<%=hdnUserFont.ClientID %>').value;
        }
        //Main toolbar *** Apply for All Textboxes
        function Maintoolbar_OnClientButtonClicking(Maintoolbar, args) {
            MainFontFamily = document.getElementById('<%=hdnUserFont.ClientID %>').value;

            var divCount = $("#maintable div").size();
            if (divCount > 0) {
                var button = args.get_item();

                document.getElementById("hdnChanges").value = "true";
                document.getElementById("hdnIsTextEdits").value = "true";

                //True is UnBold && False is Bold
                //button.get_isChecked()
                //alert(button.get_commandName());

                var commandName = button.get_commandName();
                var groupName = button.get_group();


                var divtable = document.getElementById("maintable");
                var IsChecked = button.get_isChecked();

                var getHTML = '';
                //First For
                for (i = 0; i < divtable.rows.length; i++) {

                    for (j = 0; j < divtable.rows[i].cells.length; j++) {
                        for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                            //DIV Tag 
                            if (divtable.rows[i].cells[j].children[k].tagName == "DIV") {
                                var id = divtable.rows[i].cells[j].children[k].id;
                                getHTML = document.getElementById(id).innerHTML;

                                //Adding Span tags
                                if (getHTML.indexOf('span') <= 0) {
                                    getHTML = "<span style='font-weight: normal; font-style: normal; text-decoration: none; color: black; font-size: 16px; font-family: Arial;'>" + getHTML + "</span>";
                                }
                                if (getHTML.indexOf("text-align:") == -1) {
                                    editHTML = editHTML.replace("\">", " text-align: left; display: block;\">");
                                }

                                //Apply Styles one by one TextBox
                                if (commandName == "Bold") {
                                    if (IsChecked == true) {
                                        getHTML = getHTML.replace("font-weight: bold", "font-weight: normal");
                                    }
                                    else {
                                        getHTML = getHTML.replace("font-weight: normal", "font-weight: bold");
                                    }
                                } else if (commandName == "Italic") {
                                    if (IsChecked == true) {
                                        getHTML = getHTML.replace("font-style: italic", "font-style: normal");
                                    }
                                    else {
                                        getHTML = getHTML.replace("font-style: normal", "font-style: italic");
                                    }
                                }
                                else if (commandName == "Underline") {
                                    if (IsChecked == true) {
                                        getHTML = getHTML.replace("text-decoration: underline", "text-decoration: none");
                                    }
                                    else {
                                        getHTML = getHTML.replace("text-decoration: none", "text-decoration: underline");
                                    }
                                }
                                else if (groupName == "MainColor") {

                                    var toolBar = $find("<%=Maintoolbar.ClientID %>");
                                    //2 Color dropdown
                                    var colorDropDown = toolBar.get_items().getItem(3);
                                    var newColorName = button.get_text().toLowerCase();

                                    for (a = 0; a < colorDropDown.get_buttons().get_count(); a++) {
                                        var oldColor = colorDropDown._getAllItems()[a].get_text().toLowerCase();

                                        if (getHTML.indexOf(oldColor) >= 0) {
                                            getHTML = getHTML.replace("color: " + oldColor, "color: " + newColorName);
                                            break;
                                        }
                                    }
                                    colorDropDown.set_text(button.get_text());
                                }  //end main color
                                else if (groupName == "MainFontsize") {

                                    var toolBar = $find("<%=Maintoolbar.ClientID %>");
                                    //1 fontsize dropdown
                                    var fontsizeDropDown = toolBar.get_items().getItem(2);
                                    var newFontsize = button.get_text();

                                    for (a = 0; a < fontsizeDropDown.get_buttons().get_count(); a++) {
                                        var oldfontsize = fontsizeDropDown._getAllItems()[a].get_text();

                                        if (getHTML.indexOf(oldfontsize) >= 0) {
                                            getHTML = getHTML.replace("font-size: " + oldfontsize, "font-size: " + newFontsize);
                                            break;
                                        }
                                    }
                                    fontsizeDropDown.set_text(button.get_text());
                                }  //end fontsize
                                else if (groupName == "MainFontfamily") {

                                    var toolBar = $find("<%=Maintoolbar.ClientID %>");
                                    //0 fontFamily dropdown
                                    var fontFamilyDropDown = toolBar.get_items().getItem(1);
                                    var newFontFamily = button.get_text();

                                    for (a = 0; a < fontFamilyDropDown.get_buttons().get_count(); a++) {
                                        var oldfontFamily = fontFamilyDropDown._getAllItems()[a].get_text();

                                        if (getHTML.indexOf(oldfontFamily) >= 0) {
                                            getHTML = getHTML.replace("font-family: " + oldfontFamily, "font-family: " + newFontFamily);
                                            break;
                                        }
                                    }
                                    fontFamilyDropDown.set_text(button.get_text());
                                } //Font Famly
                                else if (groupName == "Align") {

                                    var toolBar = $find("<%=Maintoolbar.ClientID %>");
                                    //0 fontFamily dropdown
                                    var alignDropDown = toolBar.get_items().getItem(7);
                                    var newAlign = button.get_text().toLowerCase(); ;

                                    for (a = 0; a < alignDropDown.get_buttons().get_count(); a++) {
                                        var oldAlign = alignDropDown._getAllItems()[a].get_text().toLowerCase(); ;

                                        if (getHTML.indexOf("text-align: " + oldAlign) >= 0) {
                                            getHTML = getHTML.replace("text-align: " + oldAlign, "text-align: " + newAlign);
                                            break;
                                        }
                                    }
                                    alignDropDown.set_text(button.get_text());
                                } //Text-Align

                                document.getElementById(id).innerHTML = '';
                                document.getElementById(id).innerHTML = getHTML;
                            }

                        }
                    }
                }
            }
        }

        function ShowExTimeDiv() {
            var allddls = document.getElementsByTagName("select");
            for (k = 0; k < allddls.length; k++) {
                var controlName = allddls[k].id;
                if (controlName.indexOf("ddlTime") >= 0) {
                    break;
                }
            }

            if (document.getElementById("<%=txtExDate.ClientID %>").value == "") {
                document.getElementById(controlName).disabled = true;
            }
            else {
                document.getElementById(controlName).disabled = false;
            }
        }

        function HideRadEditorToolBar(IsHeader) {

            MainFontFamily = document.getElementById('<%=hdnUserFont.ClientID %>').value;

            var editor = $find("<%=Maintoolbar.ClientID %>");

            var toolbarItems = editor.get_allItems();

            var i = 0;
            while (i < toolbarItems.length) {
                toolbarItems[i].set_enabled(IsHeader);
                i++;
            }
            if (!IsHeader) {
                if (document.getElementById("hdnIsTextEdits").value == "true" && document.getElementById("maintable") != null) {

                    document.getElementById("<%=lblBulletinedit.ClientID %>").innerHTML = "";
                    document.getElementById("<%=lblBulletinedit.ClientID %>").innerHTML = document.getElementById("<%=hdnEditHTML.ClientID %>").value;


                    var boldButton = editor.get_items().getItem(4);
                    boldButton.set_checked(false);
                    var ItalicButton = editor.get_items().getItem(5);
                    ItalicButton.set_checked(false);
                    var UnderLineButton = editor.get_items().getItem(6);
                    UnderLineButton.set_checked(false);

                    var toolBar = $find("<%=Maintoolbar.ClientID %>");
                    //2 Color dropdown
                    var colorDropDown = toolBar.get_items().getItem(3);
                    colorDropDown.set_text(MainFontColor);

                    //1 fontsize dropdown
                    var fontsizeDropDown = toolBar.get_items().getItem(2);
                    fontsizeDropDown.set_text(MainFontSize);

                    //0 fontFamily dropdown
                    var fontFamilyDropDown = toolBar.get_items().getItem(1);
                    fontFamilyDropDown.set_text(MainFontFamily);
                    return;


                    // ---------------------------------------------------


                } // if
            } // IsHeader if
            else {
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
                if (document.getElementById("maintable") != null) {
                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = document.getElementById("maintable").outerHTML;
                }
            }
        }


    </script>
    <div id="popup" style="display: none;">
    </div>
    <div id='editorPopup' style="display: none; position: absolute; margin-top: 150px;
        margin-left: 150px; z-index: 100;">
        <uc2:UCEditor runat="server" />
    </div>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
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
                    <div id="divLoading" style="display: none; width: 300px; margin: 0 auto;">
                        <div style="text-align: center;">
                            <img src="<%=Page.ResolveClientUrl("../../images/popup_ajax-loader.gif")%>" border="0" /><b><font
                                color="green">Processing....</font></b>
                        </div>
                    </div>
                    <div style="width: 300px; margin: 0 auto;">
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                            ValidationGroup="ABC" HeaderText="The following error(s) occurred:" />
                        <asp:Label ID="lblmess" runat="server" Font-Size="Medium" ForeColor="Green"></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="contentwrap">
                    <div class="largetxt" style="text-align: left;">
                        <asp:Label runat="server" ID="lblBulletinName" CssClass="navy20" Height="25px" Width="100%"></asp:Label></div>
                    <div class="form_wrapper" style="float: none; width: auto;">
                        <div class="clear10">
                        </div>
                        <div class="fields_wrap" id="divMandatory" style="display: none;">
                            <label id="lblMandatory" style="color: Red; font-size: 16px; margin-left: 200px;">
                                * Marked fields are mandatory.</label>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="steps">
                        </div>
                        <div class="stepswrapmain">
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable" style="width: 400px;">
                                    <label>
                                        <input type="checkbox" onclick="HideRadEditorToolBar(this.checked);" />
                                        <span style="font-weight: bold;">Master Editor Applies Changes To All Text Boxes</span>
                                    </label>
                                </div>
                            </div>
                            <div class="clear0">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <telerik:RadToolBar ID="Maintoolbar" Width="472" runat="server" OnClientButtonClicking="Maintoolbar_OnClientButtonClicking"
                                        Style="padding-bottom: 30px;">
                                        <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
                                        <Items>
                                            <telerik:RadToolBarButton Text="" Font-Bold="true" CommandName="Bold" CheckOnClick="true"
                                                AllowSelfUnCheck="true" Enabled="false">
                                            </telerik:RadToolBarButton>
                                            <telerik:RadToolBarDropDown Enabled="false">
                                                <Buttons>
                                                    <telerik:RadToolBarButton Text="Arial" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Calibri" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Comic Sans MS" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Courier New" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Segoe UI" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Tahoma" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Times New Roman" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Verdana" Group="MainFontfamily">
                                                    </telerik:RadToolBarButton>
                                                </Buttons>
                                            </telerik:RadToolBarDropDown>
                                            <telerik:RadToolBarDropDown Text="16" Enabled="false">
                                                <Buttons>
                                                    <telerik:RadToolBarButton Text="11px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="12px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="14px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="16px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="18px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="20px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="22px" Group="MainFontsize">
                                                    </telerik:RadToolBarButton>
                                                </Buttons>
                                            </telerik:RadToolBarDropDown>
                                            <telerik:RadToolBarDropDown Text="Black" Enabled="false">
                                                <Buttons>
                                                    <telerik:RadToolBarButton Text="Black" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Blue" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Fuchsia" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Gray" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Green" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Red" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Yellow" Group="MainColor">
                                                    </telerik:RadToolBarButton>
                                                </Buttons>
                                            </telerik:RadToolBarDropDown>
                                            <telerik:RadToolBarButton Text="B" Font-Bold="true" CommandName="Bold" CheckOnClick="true"
                                                AllowSelfUnCheck="true" Enabled="false">
                                            </telerik:RadToolBarButton>
                                            <telerik:RadToolBarButton Text="I" Font-Italic="false" CommandName="Italic" CheckOnClick="true"
                                                AllowSelfUnCheck="true" Enabled="false">
                                            </telerik:RadToolBarButton>
                                            <telerik:RadToolBarButton Text="U" Font-Underline="true" CommandName="Underline"
                                                CheckOnClick="true" AllowSelfUnCheck="true" Enabled="false">
                                            </telerik:RadToolBarButton>
                                            <telerik:RadToolBarDropDown Text="Left" Enabled="false">
                                                <Buttons>
                                                    <telerik:RadToolBarButton Text="Left" Group="Align">
                                                    </telerik:RadToolBarButton>
                                                    <telerik:RadToolBarButton Text="Justify" Group="Align">
                                                    </telerik:RadToolBarButton>
                                                </Buttons>
                                            </telerik:RadToolBarDropDown>
                                        </Items>
                                    </telerik:RadToolBar>
                                    <div class="avatar" style="border-width: 1px; width: 470px; display: block; height: 236px;
                                        overflow: auto;">
                                        <asp:Label ID="lblBulletinedit" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; margin: 65px 0px 0px 300px;">
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_TEXT');" src="../../Images/addnewtext.png" />
                                <a id="A1" href="javascript:ModalHelpPopup('Add Text to Content',21,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                <br />
                                <br />
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_IMAGE');" src="../../Images/addnewimg.png" />
                                <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Add Image to Content Template',230,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                <br />
                                <br />
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_VIDEO');" src="../../Images/AddVideo.png" />
                                <a id="AddVideo" href="javascript:ModalHelpPopup('Add Video to Template',274,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                <br />
                                <br />
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_WORDCONTENT');" src="../../Images/AddMSWord.png" />
                                <a id="A3" href="javascript:ModalHelpPopup('Upload a Microsoft Word Document to a Content Template',314,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <span style="padding-left: 2px;">&nbsp;</span><label>
                                        <img style="vertical-align: middle" src="<%=RootPath %>/Images/content_call.png" />
                                        Number:
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <asp:TextBox ID="txtContentPhone" runat="server" CssClass="txtfild1" onkeyup="transform(this);"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    Expiration Date & Time:
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <table cellpadding="0" cellspacing="0" id='tblExTime'>
                                            <col width="120px" />
                                            <col width="*" />
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtExDate" runat="server" Width="100px" onChange="ShowExTimeDiv();"
                                                        Height="18px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtExDate"
                                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                        ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                                    <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtExDate" Format="MM/dd/yyyy"
                                                        CssClass="MyCalendar" OnClientDateSelectionChanged="OnTextChanged" />
                                                </td>
                                                <td>
                                                    <TimerUC:TimeControl ID="ExpiryTimeControl1" runat="server" Enabled="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <label runat="server" id="divCall">
                                        <asp:CheckBox ID="chkCall" runat="server" />
                                        Display Call Button</label>
                                    <br />
                                    <label id="divContactUs" runat="server">
                                        <asp:CheckBox ID="chkContact" runat="server" />
                                        Display Contact Us Button</label>
                                    <br />
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <div id="public" style="margin: 10px 0px 0px 15px;">
                                            <asp:RadioButton ID="rbUnPublish" runat="server" GroupName="Public" Checked="true"
                                                onclick="javascript:ShowPublish('1','true')" />
                                            <label>
                                                Private</label>
                                            <asp:Label ID="lblCompleted" runat="server"></asp:Label>
                                            <asp:RadioButton ID="rbPublish" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2','true')" />
                                            <asp:Label ID="lblworkprogress" runat="server"></asp:Label>
                                            <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                            <div style="margin: 10px 10px 0px 80px; display: none;" id="divpublish">
                                                <div id="divSchedulePublish" style="display: block;">
                                                    <font color="red">*</font>
                                                    <label style="font-size: 14px;">
                                                        Publish On:</label>
                                                    <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                        ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                        runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="ABC"
                                                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                        ValidationGroup="ABC" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                    <br />
                                                    <span style="padding-left: 85px;"><b>(MM/DD/YYYY)</b></span>
                                                    <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                        Format="MM/dd/yyyy" CssClass="MyCalendar" OnClientDateSelectionChanged="OnTextChanged" />
                                                </div>
                                                <% if (Session["IsPrivate"] == null && ((Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "") || hdnPermissionType.Value == "P"))
                                                   { %>
                                                <br />
                                                <%if (hdnFacebook.Value == "")
                                                  { %>
                                                <asp:CheckBox ID="chkFbAutoPost" runat="server" Text="Auto post on facebook" Style="font-size: 14px;
                                                    padding-left: 4px;" /><br />
                                                <%} %>
                                                <%if (hdnTwitter.Value == "")
                                                  { %>
                                                <asp:CheckBox ID="chkTwrAutoPost" runat="server" Text="Auto post on twitter" Style="font-size: 14px;
                                                    padding-left: 4px;" />
                                                <%} %>
                                                <%} %>
                                                <asp:HiddenField ID="hdnIsAlreadyPublished" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnFacebook" runat="server" />
                                                <asp:HiddenField ID="hdnTwitter" runat="server" />
                                                <asp:HiddenField ID="hdnPublishDate" runat="server" />
                                                <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
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
                                    <asp:CheckBox ID="chkLocated" runat="server" />
                                    <asp:TextBox runat="server" ID="txtLocated" Text="Located" MaxLength="12" onkeyup="CountMaxLength(this,event);"
                                        onChange="CountMaxLength(this,event);" />
                                    &nbsp; <a href="#">
                                        <img id='help1' src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                    <br />
                                    <span style="margin-left: 25px; font-weight: bold;">(Max Characters 12)</span>
                                    <br />
                                    <span style="margin-left: 25px; font-weight: bold;">You have
                                        <asp:Label ID="lblLength" runat="server"></asp:Label>
                                        characters left.</span>
                                    <br />
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <%if (Session["VerticalDomain"] != null && Session["VerticalDomain"].ToString().ToLower().Contains("uspdhubcom"))
                              {
                            %>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                    Category:
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px;">
                                    <asp:DropDownList ID="ddlCategories" runat="server" Width="200px" onchange="categoryonchange()">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%} %>
                            <div class="fields_wrap ">
                                <div class="left_lable">
                                </div>
                                <div class="right_fields" style="margin: 10px 0px 0px 0px;">
                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClientClick="return SaveAlert();"
                                        OnClick="BtnCancel_Click" border="0" CssClass="btn" />
                                    <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="ABC" OnClientClick="return PreviewHTML('3')"
                                        OnClick="BtnPublish_Click" border="0" CssClass="btn" />
                                    <asp:Button ID="BtnPublish" runat="server" Text="Submit" ValidationGroup="ABC" OnClientClick="return PreviewHTML('3')"
                                        OnClick="BtnPublish_Click" border="0" CssClass="btn" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return PreviewHTML('1');">
                                        <img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                                    <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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
            <input type="hidden" id='hdnBTempID' value="6" runat="server" />
            <asp:HiddenField runat="server" ID="hdnEditHTML" />
            <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
            <asp:HiddenField runat="server" ID="hdnExDate" />
            <asp:HiddenField runat="server" ID="hdnPublish" />
            <asp:HiddenField runat="server" ID="hdnCompleted" />
            <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
            <input type="hidden" id="hdnChanges" value="false" />
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
            <asp:HiddenField ID="hdnRootPath" runat="server" />
            <asp:HiddenField ID="hdnDescription" runat="server" Value="" />
            <input type="hidden" id="hdnIsTextEdits" value="false" />
            <input type="hidden" runat="server" id="hdnBulletinID" value="0" /><table cellspacing="0"
                cellpadding="0" width="100%" border="0">
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
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"> Your
                                                        request is in progress, please don't refresh or close window. </font></b>
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkPreview" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="Upda" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblWordContent" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="ModalPopupWordContent" runat="server" TargetControlID="lblWordContent"
                PopupControlID="PnlWordContent" BackgroundCssClass="modal" CancelControlID="imgcloseWordContentPreviewpopup"
                BehaviorID="WordContentPreview">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="PnlWordContent" runat="server" Style="display: none" Width="700px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgcloseWordContentPreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid">
                                <div id="divFrameWordContent">
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblBulletinPreview" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popupBulletinpreview" runat="server" TargetControlID="lblBulletinPreview"
                PopupControlID="pnlpreviewBulletin" BackgroundCssClass="modal" CancelControlID="imgclosepreviewpopup"
                BehaviorID="BulletinPreview">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlpreviewBulletin" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; padding: 10px;" colspan="2">
                                <div style="overflow-y: auto; height: 600px; position: relative;">
                                    <asp:Label ID="lblnewspreview" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
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
                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
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
                            <td class="mid">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
