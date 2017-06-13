<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="BulletinFlyer.aspx.cs" Inherits="UserForms.BulletinFlyer" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="UCEditor.ascx" TagName="UCEditor" TagPrefix="uc2" %>
<%@ Register Src="~/TimeControl.ascx" TagName="TimeControl" TagPrefix="TimerUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.sortable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.droppable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.draggable.js" type="text/javascript"></script>
    <link href="../../Styles/Bulletins.css" rel="stylesheet" type="text/css" />
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
    </style>
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
            width: 600px;
        }
        .videodivStyle
        {
            text-align: center;
            border: 1px solid #FCB549;
            overflow: auto;
            font-family: Arial;
            font-size: 16px;
            width: 600px;
        }
        .imgdivStyle
        {
            text-align: justify;
            border: 1px solid #FCB549;
            overflow: auto;
            font-family: Arial;
            font-size: 12px;
            width: 600px;
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
    </style>
    <style type="text/css">
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
    </style>
    <script type="text/javascript">

     
        var EntID = "";

        function PreviewHTML(typeID) {
            EntID = typeID;

            if (typeID == 2 || typeID == 3) {
                ValidatePublishDate();
                //ExDate checking
                if (document.getElementById("<%=txtExDate.ClientID %>").value != "") {
                    var allddls = document.getElementsByTagName("select");
                    for (k = 0; k < allddls.length; k++) {
                        var controlName = allddls[k].id;
                        if (controlName.indexOf("ddlTime") >= 0) {
                            break;
                        }
                    }
                    var currentdate = new Date();
                    var fromDate = document.getElementById("<%=txtExDate.ClientID %>").value + " " + document.getElementById(controlName).value;
                    var selDate = new Date(fromDate);
                    var selHours = 0;
                    var selmins = 0;

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
                                var id = divtable.rows[i].cells[j].children[k].id;
                                getHTML = document.getElementById(id).innerHTML;
                                if (getHTML.trim() != "") {
                                    getHTML = getHTML.replace(/SPAN/gi, 'span');
                                    if (getHTML.indexOf('<span') >= 0) {
                                        if (IsListDescription) {
                                            document.getElementById("<%=hdnDescription.ClientID %>").value = getHTML;
                                            IsListDescription = false;
                                        }
                                        tds = tds + "<td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align: left;'>" + getHTML + "</td>";
                                    }
                                    else {
                                        getHTML = getHTML.replace(/videoclass/gi, 'videoclass1');
                                        var imgAlignment = document.getElementById(id).style.textAlign;
                                        if (imgAlignment == "") imgAlignment = "center";
                                        tds = tds + "<td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align:" + imgAlignment + ";'>" + getHTML + "</td>";
                                    }
                                }
                            }
                        }
                    }
                    if (tds != "") {
                        trs = trs + "<tr>" + tds + "</tr>";
                    }
                    tds = '';
                }

            }

            var PreviewHTML = "<table style='margin-left:20px;' border='0'  >" + trs + "</table>";


            var bulletinHeader = document.getElementById("<%=hdnBulletinHeader.ClientID %>").value;
            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = PreviewHTML;


            if (EntID == 1) {

                bulletinHeader = bulletinHeader.replace("#BuildHtmlForForm#", PreviewHTML);
                document.getElementById("<%=lblnewspreview.ClientID %>").innerHTML = "";
                document.getElementById("<%=lblnewspreview.ClientID %>").innerHTML = bulletinHeader;

                var modal = $find("BulletinPreview");
                modal.show();

                LoadEventForPlayVideo();
                document.getElementById('<%=lblmess.ClientID %>').innerHTML = "";


                return false;
            }
            else {
                if (Page_ClientValidate('ABC')) {
                    var isCompleted = false;
                    var isPrivate = false;

                    document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";
                    isPrivate = document.getElementById('<%=rbPrivate.ClientID %>').checked;
                    var exDate = document.getElementById("<%=txtExDate.ClientID %>").value;
                    if (document.getElementById('maintable') != null) {
                        document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                    }
                    document.getElementById("<%=hdnExDate.ClientID %>").value = exDate;
                    document.getElementById("<%=hdnPrivate.ClientID %>").value = isPrivate;
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
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"700px\" style=\"border: 0px solid gray; " +
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
            var className = "textdivStyle";

            if (blockname == "DIV_TEXT") {
                editingBlock = "<img src='../../Images/EditText.png'  style='cursor: pointer;' onclick='ShowPopup(edit" + CID + ")' />";
            }
            else if (blockname == "DIV_IMAGE") {
                editingBlock = "<img src='../../Images/EditImage.png'  style='cursor: pointer;' onclick='EditImage(edit" + CID + ")' />";
            } else if (blockname == "DIV_VIDEO") {
                className = "videodivStyle";
                editingBlock = "<img  src='../../Images/EditVideo.png'  style='cursor: pointer; margin-left:5px;' onclick='EditVideo(edit" + CID + ")' />";
            }

            var newRow = "<tr id='tr" + CID + "'>" +
                        "<td>" +
                            "<div id='edit" + CID + "' style='min-height: 100px; padding: 5px;' class='" + className + "'>" +
                            "</div>" +
                         "</td>" +
                        "<td >" +
                            editingBlock +
                            "<br/><img src='../../Images/Remove.png'  style='cursor: pointer; padding-top: 5px;' onclick='RemoveBlock(edit" + CID + ")' />" +
                        "</td>" +
                    "</tr>";



            $("#maintable").append(newRow);

            //Auto scroll when add new item
            var co = document.getElementById("edit" + CID);
            co.focus();

            $(".avatar").animate({ scrollTop: $(".avatar").prop("scrollHeight") }, 1000);

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

        }

        function RemoveBlock(value) {
            var divID = value.id;
            divID = divID.replace("edit", "tr");
            if (confirm("Are you sure you want to delete this block?")) {
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

            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 12) + "&imgSrc=" + imgSrc + "&folder=Templates");
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
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
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
            document.getElementById("<%=rbPrivate.ClientID %>").checked = true;
            document.getElementById("<%=rbPublic.ClientID %>").checked = false;
        }
        window.onload = function () {
            if (document.getElementById('<%= hdnPermissionType.ClientID%>') != "" && document.getElementById('<%= hdnPermissionType.ClientID%>') != null)  //roles & permissions..
                DisplayComplete();
            if (document.getElementById('<%=rbPrivate.ClientID %>').checked) {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "block";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%=BtnSave.ClientID %>').style.display = "none";
                document.getElementById('<%=BtnPublish.ClientID %>').style.display = "block";
            }

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


        function DisplayComplete() {
            if (document.getElementById('<%= rbPublic.ClientID%>').checked) {
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
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
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
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
                    document.getElementById('lblMandatory').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                    document.getElementById('lblMandatory').style.display = "none";
                }
                
            }
        }
        function SaveAlert() {
            var result;

            if (document.getElementById("hdnChanges").value == "true") {
                result = confirm('Do you want to save the changes you made to the content?');
                if (result) {
                    PreviewHTML('3');
                    return true;
                }
                else {
                    var urlinfo = document.getElementById('<%=hdnRootPath.ClientID %>').value + "/Business/MyAccount/ManageBulletins.aspx";
                    window.location = urlinfo;

                    return false;
                }
            }
            else {
                var urlinfo = document.getElementById('<%=hdnRootPath.ClientID %>').value + "/Business/MyAccount/ManageBulletins.aspx";
                window.location = urlinfo;

                return false;
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
            if (document.getElementById("<%=txtExDate.ClientID %>").value == "" || document.getElementById("<%=txtExDate.ClientID %>").value == "MM/DD/YYYY") {
                document.getElementById(controlName).disabled = true;
            }
            else {
                document.getElementById(controlName).disabled = false;
            }
        }

        $(document).ready(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
    </script>
    <div id="popup" style="display: none;">
    </div>
    <div id='editorPopup' style="display: none; position: absolute; margin-top: 150px;
        margin-left: 150px; z-index: 100;">
        <uc2:UCEditor ID="UCEditor1" runat="server" />
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
                        <div class="fields_wrap">
                            <label id="lblMandatory" style="color: Red; font-size: 16px; margin-left: 100px;
                                display: none;">
                                * Marked fields are mandatory.</label>
                        </div>
                        <div class="clear10">
                        </div>
                        <div class="steps">
                        </div>
                        <div class="stepswrapmain">
                            <div style="float: left; width: 770px; text-align: right; margin-left: 100px;">
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_TEXT');" src="../../Images/addnewtext.png" />
                                <a id="A1" href="javascript:ModalHelpPopup('Add Text to Content',21,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_IMAGE');" src="../../Images/addnewimg.png" />
                                <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Add Image to Content',20,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_VIDEO');" src="../../Images/AddVideo.png" />
                                <a id="AddVideo" href="javascript:ModalHelpPopup('Add Video to Template',274,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                            </div>
                            <div class="clear0">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <div class="avatar" style="border-width: 1px; min-height: 100px; width: 780px; display: block;
                                        max-height: 400px; overflow: auto;">
                                        <asp:Label ID="lblBulletinedit" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    &nbsp; Expiration Date & Time:
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <table width="80%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtExDate" runat="server" Width="100px" onChange="ShowExTimeDiv();"></asp:TextBox>
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
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <label>
                                    </label>
                                </div>
                                <div class="right_fields">
                                    <div style="margin: 0px 0px 0px 0px;">
                                        <div id="public" style="margin: 10px 0px 0px 15px;">
                                            <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                                onclick="javascript:ShowPublish('1','true')" />
                                            <label>
                                                Private</label>
                                            <asp:Label ID="lblCompleted" runat="server"></asp:Label>
                                            <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2','true')" />
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
                                                <% if ((Session["C_USER_ID"] == null || Session["C_USER_ID"].ToString() == "") || hdnPermissionType.Value == "P")
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
                                                <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="clear10">
                            </div>
                            <%if (Session["VerticalDomain"] != null && Session["VerticalDomain"].ToString().ToLower().Contains("uspdhub"))
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
                                        OnClick="BtnPublish_Click" border="0" CssClass="btn" />
                                    <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="ABC" OnClientClick="return PreviewHTML('3')"
                                        OnClick="BtnPublish_Click" border="0" CssClass="btn" />
                                    <asp:Button ID="BtnPublish" runat="server" Text="Submit" ValidationGroup="ABC" OnClientClick="return PreviewHTML('3')"
                                        OnClick="BtnPublish_Click" border="0" CssClass="btn" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return PreviewHTML('1');">
                                        <img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
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
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                                        request is in progress, please don't refresh or close window.</font></b>
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
            <input type="hidden" id='ids' value='' />
            <input type="hidden" id='htmlvalue' />
            <input type="hidden" id="editDivCheck" value="" />
            <input type="hidden" id="hdnalignindex" />
            <input type="hidden" id='hdnBTempID' value="6" runat="server" />
            <asp:HiddenField runat="server" ID="hdnEditHTML" />
            <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
            <asp:HiddenField runat="server" ID="hdnExDate" />
            <asp:HiddenField runat="server" ID="hdnPrivate" />
            <asp:HiddenField runat="server" ID="hdnCompleted" />
            <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
            <input type="hidden" id="hdnChanges" value="false" />
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
            <asp:HiddenField ID="hdnRootPath" runat="server" />
            <asp:HiddenField ID="hdnDescription" runat="server" Value="" />
            <input type="hidden" id="hdnIsTextEdits" value="false" />
            <input type="hidden" runat="server" id="hdnBulletinID" value="0" />
            <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkPreview" EventName="Click" />
        </Triggers>
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
