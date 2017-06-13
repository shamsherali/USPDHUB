<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    Inherits="Business_MyAccount_ProfileDescription" ValidateRequest="false" CodeBehind="ProfileDescription.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="UCEditor.ascx" TagName="UCEditor" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript">

        var BrowserVersion = $.browser.version;
        window.onload = function () {
            if (BrowserVersion == "10.0") {
                $('.textdivStyle img').each(function () {
                    $(this).removeAttr('width')
                    $(this).removeAttr('height');
                });
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
                var myBehavior = $find("popupop");

                PreviewHTML('1');
                var HtmlBody = document.getElementById("<%=hdnPreviewHTML.ClientID %>").value;

                // Shorten URL Purpose
                document.getElementById("divLoading").style.display = "block";
                HtmlBody = HtmlBody.replace(/</gi, "&lt;_");
                HtmlBody = HtmlBody.replace(/>/gi, "&gt;_");
                HtmlBody = HtmlBody.replace(/'/gi, "&quots;_");

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{htmlString:'" + HtmlBody + "'}",
                    url: "ProfileDescription.aspx/ReplaceShortURltoHmlString",
                    dataType: "json",
                    processData: false,
                    success: function (data) {
                        HtmlBody = data.d;

                        document.getElementById("<%=lblPreviewHTML.ClientID %>").innerHTML = "";

                        $get('<%=lblPreviewHTML.ClientID %>').innerHTML = HtmlBody;
                        myBehavior.show();

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
                alert("You haven't built your description yet.");
                return false;
            }
        }

        var EntID = "";

        function PreviewHTML(type) {

            document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = "";
            document.getElementById("<%=hdnEditHTML.ClientID %>").value = "";

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
                                        tds = tds + "<tr><td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align: left;'>" + getHTML + " </td></tr>";
                                    }
                                    else {
                                        getHTML = getHTML.replace(/videoclass/gi, 'videoclass1');
                                        var imgAlignment = document.getElementById(id).style.textAlign;
                                        tds = tds + "<tr><td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align:" + imgAlignment + ";'>" + getHTML + "</td></tr>";
                                    }

                                } // getHTML
                            } // If divTable
                        } //for k
                    } // for j
                } // for i

                var PreviewHTML = "<table style='margin-left:20px;' border='0'  >" + tds + "</table>";
                document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = PreviewHTML;
                document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
            } // if divcount
            if (type == '2')
                $find("<%=MPEProgress.ClientID %>").show();
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

            $(".avatar").animate({ scrollTop: $(".avatar").prop("scrollHeight") }, 1000);
            LoadBlocks();
           

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

        //Show the Image Gallery
        function EditImage(value) {
            imgdivID = value.id;
            document.getElementById('divImageframe').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 32) + "&imgSrc=" + imgSrc);
            ifrm.style.height = "650px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('divImageframe').appendChild(ifrm);
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

        function RemoveBlock(value) {
            var divID = value.id;
            var idNumber = divID.replace("edit", "");
            divID = "parent" + divID;
            if (confirm("Are you sure you want to delete this block?")) {
                var childdivsCount = $("#tr" + idNumber + " div").size();
                $("#" + divID).remove();

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
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.sortable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.droppable.js" type="text/javascript"></script>
    <script src="../../Scripts/flyers/jquery.ui.draggable.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="popup" style="display: none;">
            </div>
            <div id='editorPopup' style="display: none; position: absolute; margin-top: 150px;
                margin-left: 150px; z-index: 100;">
                <uc2:UCEditor runat="server" />
            </div>
            <asp:Panel ID="Panel1" DefaultButton="btnSave" runat="server">
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
                                <img src="<%=Page.ResolveClientUrl("../../images/popup_ajax-loader.gif")%>" border="0" /><b><font
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
                        <div class="largetxt">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            <span style="color: Black; font-size: 14px; margin: 0px; padding: 0px; position: absolute;
                                margin-left: 215px;">
                                <asp:Label runat="server" ID="lblOn" Visible="false" Font-Bold="true">Displayed on App: <font class="showonapp">On</font></asp:Label>
                                <asp:Label runat="server" ID="lblOff" Visible="false" Font-Bold="true">Displayed on App: <font class="showoffapp">Off</font></asp:Label>
                            </span>
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
                                        <div class="avatar" style="border-width: 0px; width: 468px; display: block;
                                            max-height: 400px; overflow: auto;">
                                            <asp:Label ID="lblEditText" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="text-align: right; float: left; margin: 16px 0px 0px 10px;">
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_TEXT');" src="../../Images/addnewtext.png" />
                                <a id="A1" href="javascript:ModalHelpPopup('Add Text to Profile Details',165,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a><br />
                                <br />
                                <img style="cursor: pointer;" onclick="AddBlocks('DIV_IMAGE');" src="../../Images/addnewimg.png" />
                                <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Add Image to Description',191,'');">
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
                        </div>
                        <div class="fields_wrap ">
                            <div class="right_fields" style="margin: 10px 0px 0px 220px; width: 430px;">
                                <asp:Button ID="btnBack" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                    Text="Back" OnClick="btnBack_Click" />
                                <asp:Button ID="Button1" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                    Text="Cancel" OnClick="Modify_Profile" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" border="0" OnClick="Modify_Continue"
                                    ValidationGroup="group" OnClientClick="return PreviewHTML('2');" />
                                <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return ShowPreview();">
                                    <img src="../../images/BulletinThumbs/preview.png"  width="100" height="37"></asp:LinkButton>
                                <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" CssClass="btn" border="0"
                                    CausesValidation="false" Style="float: right;" OnClick="btnDashboard_OnClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"> Your request is in progress, please don't refresh or close window. </font></b>
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
    <input type="hidden" id='ids' value='' />
    <input type="hidden" id='htmlvalue' />
    <input type="hidden" id="editDivCheck" value="" />
    <input type="hidden" id="hdnalignindex" />
    <input type="hidden" id="hdnChanges" value="false" />
    <asp:HiddenField runat="server" ID="hdnEditHTML" />
    <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
    <asp:HiddenField runat="server" ID="hdnPermissionType" />
    <asp:HiddenField runat="server" ID="hdnHomePermission" />
    <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div class="largetxt">
                Profile Details</div>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
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
                                <asp:ImageButton ID="imgclosVidepepreviewpopup1" runat="server" ImageUrl="~/images/popup_close.gif" OnClientClick="ClosePopup();"  />
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
</asp:Content>
