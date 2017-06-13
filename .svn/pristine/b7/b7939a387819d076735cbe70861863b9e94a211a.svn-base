<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    CodeBehind="CAEventsCalendar.aspx.cs" Inherits="USPDHUB.Business.MyAccount.CAEventsCalendar"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="UCEditor.ascx" TagName="UCEditor" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script src="https://apis.google.com/js/client.js?onload=init"></script>
    <script type="text/javascript">
        function init() {
            gapi.client.setApiKey('AIzaSyANFw1rVq_vnIzT4vVOwIw3fF1qHXV7Mjw');
            gapi.client.load('urlshortener', 'v1').then(makeRequest);
        }

        var isStartDateChanged = false;
        function BindLoadEvents() {
            $(document).ready(function () {
                $("#editRepeatCal").click(function (e) {
                    ShowDialog(true);
                    ShowSummaryPop();
                    e.preventDefault();
                });
                $("#my_select").change(function () {
                    SelectRepeatType('RC');
                    ShowSummaryPop();
                });
                $("#Select0").change(function () {
                    ShowSummaryPop();
                });
                $("#Select1").change(function () {
                    ShowSummaryPop();
                });
                $("#Select2").change(function () {
                    ShowSummaryPop();
                });
                $("#Select3").change(function () {
                    ShowSummaryPop();
                });
                $("#btnClose").click(function (e) {
                    if (document.getElementById('<%=hdnAlreadyRepeat.ClientID %>').value != "1" && document.getElementById("<%=hdn3Items.ClientID %>").value == "") {
                        document.getElementById('<%=chkRepeat.ClientID %>').checked = false;
                    }
                    HideDialog();
                    e.preventDefault();
                });
                $("#btnCalCancel").click(function (e) {
                    if (document.getElementById('<%=hdnAlreadyRepeat.ClientID %>').value != "1" && document.getElementById("<%=hdn3Items.ClientID %>").value == "") {
                        document.getElementById('<%=chkRepeat.ClientID %>').checked = false;
                    }
                    HideDialog();
                    e.preventDefault();
                });
                $("#btnSubmit").click(function (e) {
                    SaveRepeatFunction();
                    HideDialog();
                    e.preventDefault();
                });
                $("#btnConfirmCancel").click(function (e) {
                    HideDialogConfirm();
                    e.preventDefault();
                });
                $("#btnConfirmClose").click(function (e) {
                    HideDialogConfirm();
                    e.preventDefault();
                });
                $("#btnOnly").click(function (e) {
                    document.getElementById('<%=hdnSeriesChangeType.ClientID %>').value = "1";
                    HideDialogConfirm();
                    e.preventDefault();
                    TriggerAction();
                });
                $("#btnFollowing").click(function (e) {
                    document.getElementById('<%=hdnSeriesChangeType.ClientID %>').value = "2";
                    HideDialogConfirm();
                    e.preventDefault();
                    TriggerAction();
                });
                $("#btnAllSeries").click(function (e) {
                    document.getElementById('<%=hdnSeriesChangeType.ClientID %>').value = "0";
                    HideDialogConfirm();
                    e.preventDefault();
                    TriggerAction();
                });

            });
        }
        function ShowPublish(val, type) {
            if (document.getElementById('<%= lblEditText.ClientID%>').innerHTML == "") {
                document.getElementById('<%= lblEditText.ClientID%>').innerHTML = "<div id='watermark'>Your block goes here!!!</div>";
            }

            if (val == "1") {
                document.getElementById('<%=btnSaveExit.ClientID %>').value = "Save";
                document.getElementById('divpublish').style.display = "none";
                document.getElementById('<%= txtPublishDate.ClientID%>').value = '';
            } else if (val == "2") {

                document.getElementById('<%=btnSaveExit.ClientID %>').value = "Submit";
                document.getElementById('divpublish').style.display = "block";
                if ('<%= IsScheduleEmails %>' == 'True') {
                    document.getElementById('divSchedulePublish').style.display = "block";
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                if (document.getElementById('<%= txtPublishDate.ClientID%>').value == "")
                    GetCurrentDate();
            }
            if (type == "1")
                BindRepeatDetails();
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


        function CheckDataChanges() {
            if (document.getElementById("<%=hdnAlreadyRepeat.ClientID %>").value != "" && document.getElementById("<%=chkRepeat.ClientID %>").checked == true) {
                var startDate = GetSelectedDates("Start");
                var endDate = GetSelectedDates("End");
                var expireDate = GetSelectedDates("Expire");
                $.ajax({
                    type: "POST",
                    url: "EventsCalendar.aspx/CheckDataChanges",
                    data: '{eventId: "' + $("#<%=hdnEventID.ClientID%>")[0].value + '",eventTitle: "' + $("#<%=txtEventName.ClientID%>")[0].value + '",StartDate: "' + startDate + '",endDate: "' + endDate + '",expireDate: "' + expireDate + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    }
                });

                function OnSuccess(response) {
                    if (response.d)
                        document.getElementById("<%=hdnDataChanged.ClientID %>").value = "1";
                }
            }
        }
        function GetSelectedDates(type) {
            var seldate = '';
            var startHalfs = 'AM';
            if (type == "Start" && document.getElementById("<%=txtStartDate.ClientID %>").value != "") {
                if (document.getElementById("<%=txtStrHours.ClientID %>").value != "" && document.getElementById("<%=txtStrHours.ClientID %>").value != "Hour")
                    startHour = document.getElementById("<%=txtStrHours.ClientID %>").value;
                else
                    startHour = "00";

                if (document.getElementById("<%=txtStrMins.ClientID %>").value != "" && document.getElementById("<%=txtStrMins.ClientID %>").value != "Minutes")
                    startMins = document.getElementById("<%=txtStrMins.ClientID %>").value + ":00";
                else
                    startMins = "00:00"
                if (startHour != "00" || startMins != "00:00") {
                    var parm1 = document.getElementById("<%=ddlStrAPM.ClientID%>");
                    startHalfs = parm1.options[parm1.selectedIndex].text;
                }
                seldate = document.getElementById("<%=txtStartDate.ClientID %>").value + " " + startHour + ":" + startMins + " " + startHalfs;
            }
            if (type == "End" && document.getElementById("<%=txtEndDate.ClientID %>").value != "") {
                if (document.getElementById("<%=txtEndHours.ClientID %>").value != "" && document.getElementById("<%=txtEndHours.ClientID %>").value != "Hour")
                    startHour = document.getElementById("<%=txtEndHours.ClientID %>").value;
                else
                    startHour = "00";

                if (document.getElementById("<%=txtEndMins.ClientID %>").value != "" && document.getElementById("<%=txtEndMins.ClientID %>").value != "Minutes")
                    startMins = document.getElementById("<%=txtEndMins.ClientID %>").value + ":00";
                else
                    startMins = "00:00"
                if (startHour != "00" || startMins != "00:00") {
                    var parm1 = document.getElementById("<%=ddlEndAPM.ClientID%>");
                    startHalfs = parm1.options[parm1.selectedIndex].text;
                }
                seldate = document.getElementById("<%=txtEndDate.ClientID %>").value + " " + startHour + ":" + startMins + " " + startHalfs;
            }
            if (type == "Expire" && document.getElementById("<%=txtExDate.ClientID %>").value != "") {
                if (document.getElementById("<%=txtExHours.ClientID %>").value != "" && document.getElementById("<%=txtExHours.ClientID %>").value != "Hour")
                    startHour = document.getElementById("<%=txtExHours.ClientID %>").value;
                else
                    startHour = "00";

                if (document.getElementById("<%=txtExMinutes.ClientID %>").value != "" && document.getElementById("<%=txtExMinutes.ClientID %>").value != "Minutes")
                    startMins = document.getElementById("<%=txtExMinutes.ClientID %>").value + ":00";
                else
                    startMins = "00:00"
                if (startHour != "00" || startMins != "00:00") {
                    var parm1 = document.getElementById("<%=ddlExSS.ClientID%>");
                    startHalfs = parm1.options[parm1.selectedIndex].text;
                }
                seldate = document.getElementById("<%=txtExDate.ClientID %>").value + " " + startHour + ":" + startMins + " " + startHalfs;
            }
            return seldate;
        }
    </script>
    <script type="text/javascript">
        var firstLoad = 1;

        function ShowPreview() {

            var divCount = $("#maintable div").size();
            if (divCount > 0) {
                var myBehavior = $find("popupop");
                var profileid = '<%=ProfileId %>';
                var userid = '<%=UserID %>';

                PreviewHTML('1');
                // Begin Start Date
                var startdate = document.getElementById("<%=txtStartDate.ClientID %>").value;

                var startHour = null;
                var startMins = null;
                if (document.getElementById("<%=txtStrHours.ClientID %>").value != "" && document.getElementById("<%=txtStrHours.ClientID %>").value != "Hour")
                    startHour = document.getElementById("<%=txtStrHours.ClientID %>").value;
                else
                    startHour = "12";

                if (document.getElementById("<%=txtStrMins.ClientID %>").value != "" && document.getElementById("<%=txtStrMins.ClientID %>").value != "Minutes")
                    startMins = document.getElementById("<%=txtStrMins.ClientID %>").value + ":00";
                else
                    startMins = "00:00"
                var parm1 = document.getElementById("<%=ddlStrAPM.ClientID%>");
                var startHalfs = parm1.options[parm1.selectedIndex].text;
                var startDateTime = startdate + " " + startHour + ":" + startMins + " " + startHalfs;

                if (startdate != "")
                    var fullStartDate = new Date(startDateTime).format('MMM dd yyyy hh:mm tt');
                //end Start Date

                // Begin End Date
                var enddate = document.getElementById("<%=txtEndDate.ClientID %>").value;
                var endHour = null;
                var endMins = null;
                if (document.getElementById("<%=txtEndHours.ClientID %>").value != "" && document.getElementById("<%=txtEndHours.ClientID %>").value != "Hour")
                    endHour = document.getElementById("<%=txtEndHours.ClientID %>").value;
                else
                    endHour = "12";
                if (document.getElementById("<%=txtEndMins.ClientID %>").value != "" && document.getElementById("<%=txtEndMins.ClientID %>").value != "Minutes")
                    endMins = document.getElementById("<%=txtEndMins.ClientID %>").value + ":00";
                else
                    endMins = "00:00";
                var parm2 = document.getElementById("<%=ddlEndAPM.ClientID%>");
                var endHalfs = parm2.options[parm2.selectedIndex].text;
                var endDateTime = enddate + " " + endHour + ":" + endMins + " " + endHalfs;
                var fullEndDate = new Date(endDateTime).format('MMM dd yyyy hh:mm tt');
                //End of End Date

                var HtmlBody = document.getElementById("<%=hdnPreviewHTML.ClientID %>").value;

                var dtEventStartDate = "";
                var dtEventEndDate = "";
                if (startdate != "")
                    dtEventStartDate = fullStartDate;

                if (new Date(fullStartDate) != "" && new Date(fullEndDate) != "") {
                    if (new Date(fullStartDate) <= new Date(fullEndDate)) {
                        if (new Date(fullStartDate) != new Date(fullEndDate))
                            dtEventEndDate = " to " + fullEndDate;
                    }
                    else {
                        alert("End date and time should be later than or equal to start date and time.");
                        return false;
                    }
                }


                HtmlBody = "<html><head></head><body><table width='100%' border='0' cellspacing='0' cellpadding='0' style='border: solid 2px #F4EBEB;'> <tr><td colspan='2' style='padding:10px;'>" + dtEventStartDate + dtEventEndDate + "</td></tr><tr><td colspan='2' style='padding:30px;'>" + HtmlBody + "</td></tr></table></body></html>";

                // Shorten URL Purpose
                document.getElementById("divLoading").style.display = "block";
                HtmlBody = HtmlBody.replace(/</gi, "&lt;_");
                HtmlBody = HtmlBody.replace(/>/gi, "&gt;_");
                HtmlBody = HtmlBody.replace(/'/gi, "&quots;_");

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{htmlString:'" + HtmlBody + "'}",
                    url: "EventsCalendar.aspx/ReplaceShortURltoHmlString",
                    dataType: "json",
                    processData: false,
                    success: function (data) {
                        HtmlBody = data.d;

                        $get('<%=lblueventnamepreview.ClientID%>').innerHTML = $get('<%=txtEventName.ClientID%>').value;
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



                /*
                PageMethods.ShowPreview(HtmlBody, profileid, userid, startdate, enddate, OnSuccess, OnFail);
                function OnSuccess(result) {
                $get('<%=lblueventnamepreview.ClientID%>').innerHTML = $get('<%=txtEventName.ClientID%>').value;
                $get('<%=lblPreviewHTML.ClientID %>').innerHTML = result;
                myBehavior.show();
                return false;
                }
                function OnFail() { return false; }
                */
                return false;
            }
            else {
                alert("You haven't built your event yet.");
                return false;
            }
        }

        var EntID = "";

        function ValidateDuplicateShare() {
            var errMsg = "";
            var facebook = document.getElementById("<%=hdnFacebook.ClientID %>").value;
            var twitter = document.getElementById("<%=hdnTwitter.ClientID %>").value;
            if (document.getElementById("<%=chkFbAutoPost.ClientID %>")) {
                var chkFacebook = document.getElementById("<%=chkFbAutoPost.ClientID %>").checked;
                if (chkFacebook == true) {
                    if (facebook == "false")
                        errMsg += "This title has already been sent to facebook. \n";
                }
            }
            if (document.getElementById("<%=chkTwrAutoPost.ClientID %>")) {
                var chkTwitter = document.getElementById("<%=chkTwrAutoPost.ClientID %>").checked;
                if (chkTwitter == true) {
                    if (twitter == "false")
                        errMsg += "This title has already been sent to twitter.";
                }
            }
            if (errMsg != "") {
                alert(errMsg);
                return false;
            }
            else
                return true;
        }

        function PreviewHTML(type) {
            ValidatePublishDate();
            if (!Page_ClientValidate('group')) {
                return;
            }
            else {
                var errormsg = ValidateDate();
                if (errormsg == '') {
                    if (type == '2') {
                        var socialMedia = ValidateDuplicateShare();
                        if (socialMedia == true) {
                            //ExDate checking
                            if (document.getElementById("<%=txtExDate.ClientID %>").value != "") {
                                var currentdate = new Date();
                                var fromDate = document.getElementById("<%=txtExDate.ClientID %>").value;
                                var selDate = new Date(fromDate);
                                var selHours = 0;
                                var selmins = 0;
                                if (document.getElementById("<%=txtExHours.ClientID %>").value != '' && document.getElementById("<%=txtExHours.ClientID %>").value != 'Hour') {
                                    selHours = parseInt(document.getElementById("<%=txtExHours.ClientID %>").value);
                                    if (selHours > 12) {
                                        alert("Invalid Date Format.");
                                        return false;
                                    }
                                    if (document.getElementById("<%=ddlExSS.ClientID %>").value == 'AM' && selHours == 12)
                                        selHours = 0;
                                    if (document.getElementById("<%=ddlExSS.ClientID %>").value == 'PM' && selHours < 12)
                                        selHours = 12;
                                }
                                if (document.getElementById("<%=txtExMinutes.ClientID %>").value != '' && document.getElementById("<%=txtExMinutes.ClientID %>").value != 'Minutes')
                                    selmins = parseInt(document.getElementById("<%=txtExMinutes.ClientID %>").value);
                                if (selmins >= 60) {
                                    alert("Invalid Date Format.");
                                    return false;
                                }
                                selDate.setHours(selHours, selmins, 0);
                                if (selDate <= currentdate) {
                                    alert('Expiration date should be later than current date.');
                                    return false
                                }
                            }
                            //end exdate checking                
                        }
                        else {
                            return false;
                        }
                    }
                    var trs = '';
                    var tds = '';
                    var getHTML = '';
                    var PreviewHTML = '';
                    var IsListDescription = true;

                    var divtable = document.getElementById("maintable");

                    if (divtable != null) {
                        for (i = 0; i < divtable.rows.length; i++) {
                            for (j = 0; j < divtable.rows[i].cells.length; j++) {
                                for (k = 0; k < divtable.rows[i].cells[j].children.length; k++) {
                                    //DIV Tag 
                                    if (divtable.rows[i].cells[j].children[k].tagName == "DIV") {
                                        var id = divtable.rows[i].cells[j].children[k].id;
                                        getHTML = document.getElementById(id).innerHTML;
                                        if (getHTML.indexOf('<span') >= 0) {
                                            if (IsListDescription) {
                                                document.getElementById("<%=hdnDescription.ClientID %>").value = getHTML;
                                                IsListDescription = false;
                                            }

                                            tds = tds + "<td  style='page-break-inside: avoid; width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align: left;'>" + getHTML + "</td>";
                                        }
                                        else {
                                            getHTML = getHTML.replace(/videoclass/gi, 'videoclass1');
                                            var imgAlignment = document.getElementById(id).style.textAlign;
                                            tds = tds + "<td  style='page-break-inside: avoid; width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align:" + imgAlignment + ";'>" + getHTML + "</td>";
                                        }
                                    }
                                }
                            }
                            trs = trs + "<tr>" + tds + "</tr>";
                            tds = '';
                        }

                        PreviewHTML = "<table style='word-wrap: break-word; margin-left:20px; border:1px solid black;' border='0'  >" + trs + "</table>";

                        document.getElementById("<%=hdnPreviewHTML.ClientID %>").value = PreviewHTML;
                        document.getElementById("<%=hdnEditHTML.ClientID %>").value = divtable.outerHTML;
                    }

                    // *** Uncomment once we enable recurring *** //
                    //                    if (type == '2') {
                    //                        if (document.getElementById("<%=hdnAlreadyRepeat.ClientID %>").value == "1" && document.getElementById("<%=chkRepeat.ClientID %>").checked == true) {
                    //                            $("#trAllSeries").show();
                    //                            if (isStartDateChanged) {
                    //                                $("#trAllSeries").hide();
                    //                                ShowDialogConfirm(true);
                    //                            }
                    //                            else //if (document.getElementById("<%=hdnCalChanged.ClientID %>").value == "1") {
                    //                                ShowDialogConfirm(true);
                    //                            //}                        
                    //                            return false;
                    //                        }
                    //                        else {
                    //                            $find("<%=MPEProgress.ClientID %>").show();
                    //                            return true;
                    //                        }
                    //                    }                        
                    //                    return true;
                    // *** End uncomment once we enable recurring  AND REMOVE below if function and return true*** //
                    if (type == '2') {
                        $find("<%=MPEProgress.ClientID %>").show();
                    }
                    return true;
                }
                else {
                    alert(errormsg);
                    return false;
                }
            }
        }


        function AddBlocks(blockname) {

            if (document.getElementById('maintable') == null) {
                var maintableTag = "<table id='maintable' cellpadding=\"2\" cellspacing=\"2\" width=\"400px\" style=\"border: 0px solid gray; " +
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
                editingBlock = "<img src='../../Images/EditText.png'  style='cursor: pointer;' onclick='ShowPopup(edit" + CID + ")' />";
            }
            else if (blockname == "DIV_IMAGE") {
                editingBlock = "<img src='../../Images/EditImage.png'  style='cursor: pointer;' onclick='EditImage(edit" + CID + ")' />";
            }
            else if (blockname == "DIV_VIDEO") {
                editingBlock = "<img  src='../../Images/EditVideo.png'  style='cursor: pointer; margin-left:5px;' onclick='EditVideo(edit" + CID + ")' />";
            }

            var newRow = "<tr id='tr" + CID + "'>" +
                        "<td>" +
                            "<div id='edit" + CID + "' style='min-height: 100px; padding: 5px;' class='textdivStyle'>" +
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
        }

        //Show the Image Gallery
        function EditImage(value) {
            imgdivID = value.id;
            document.getElementById('divImageframe').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML;

            ifrm.setAttribute("src", "Bulletin_ImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 32) + "&imgSrc=" + imgSrc);
            //ifrm.style.height = "750px";
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
        window.onload = function () {

            CountMaxLength(document.getElementById('<%=txtEventName.ClientID %>'), 'event name');
            //ShowDateTimeDiv('1'); // *** uncomment if start date onchange event not change onload *** //
            //ShowDateTimeDiv('2')

            // Disable vents for VideoBlock in Page
            DisableEventsForVideoBlocks();
        }
        function CountMaxLength(id, text) {
            var maxlength = 150;

            if (id.value.length > maxlength) {
                id.value = id.value.substring(0, maxlength);
                alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
            }
            document.getElementById('<%=lblCount.ClientID %>').innerHTML = maxlength - id.value.length;
            //alert(document.getElementById("ctl00_cphUser_txtNoticication"));    

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

        function ShowExTimeDiv() {
            if (document.getElementById("<%=txtExDate.ClientID %>").value == "") {
                document.getElementById("<%=txtExHours.ClientID %>").disabled = true;
                document.getElementById("<%=txtExMinutes.ClientID %>").disabled = true;
                document.getElementById("<%=ddlExSS.ClientID %>").disabled = true;
            }
            else {
                document.getElementById("<%=txtExHours.ClientID %>").disabled = false;
                document.getElementById("<%=txtExMinutes.ClientID %>").disabled = false;
                document.getElementById("<%=ddlExSS.ClientID %>").disabled = false;
            }
        }
        function ShowDateTimeDiv(val) {
            //For Start Date
            if (val == "1") {
                if (document.getElementById("<%=txtStartDate.ClientID %>").value == "") {
                    document.getElementById("<%=txtStrHours.ClientID %>").disabled = true;
                    document.getElementById("<%=txtStrMins.ClientID %>").disabled = true;
                    document.getElementById("<%=ddlStrAPM.ClientID %>").disabled = true;
                }
                else {
                    document.getElementById("<%=txtStrHours.ClientID %>").disabled = false;
                    document.getElementById("<%=txtStrMins.ClientID %>").disabled = false;
                    document.getElementById("<%=ddlStrAPM.ClientID %>").disabled = false;
                }
                if (firstLoad == 0) {
                    document.getElementById('<%=txtEndDate.ClientID %>').value = document.getElementById('<%=txtStartDate.ClientID %>').value;
                }
                else {
                    if (document.getElementById('<%=txtEndDate.ClientID %>').value == "")
                        document.getElementById('<%=txtEndDate.ClientID %>').value = document.getElementById('<%=txtStartDate.ClientID %>').value;
                    firstLoad = 0;
                }
                document.getElementById("<%=txtEndHours.ClientID %>").disabled = false;
                document.getElementById("<%=txtEndMins.ClientID %>").disabled = false;
                document.getElementById("<%=ddlEndAPM.ClientID %>").disabled = false;

                if (document.getElementById("<%=hdnEventDates.ClientID %>").value != "") {
                    var eventDates = document.getElementById("<%=hdnEventDates.ClientID %>").value.split("##SP##");
                    var eventPrevStart = eventDates[0];
                    if (eventPrevStart != document.getElementById("<%=txtStartDate.ClientID %>").value)
                        isStartDateChanged = true;
                    else
                        isStartDateChanged = false;
                }
                if (document.getElementById("<%=hdn3Items.ClientID %>").value != "" || document.getElementById("<%=hdn3Itemsold.ClientID %>").value != "") {
                    if (document.getElementById("<%=chkRepeat.ClientID %>").checked) {
                        var id = $('#my_select :selected').val();
                        var startdateID = "txtRepeatStart"; // // *** id + "Start"; *** // //
                        $('#' + startdateID).val(document.getElementById("<%=txtStartDate.ClientID %>").value);
                        var repeatOn = document.getElementById("<%=hdnRepeatOn.ClientID %>").value.split(',');
                        var daysCount = 0;
                        if (repeatOn.length > 0) {
                            for (var i = 0; i < repeatOn.length; i++) {
                                if (repeatOn[i] == 1)
                                    daysCount += 1;
                            }
                        }
                        if ((daysCount == 0 || daysCount == 1) && id == "1") {
                            SetDefaultWeekly();
                        }
                        SaveRepeatFunction();
                    }
                }
            }
            //For End Date
            if (val == "2") {
                if (document.getElementById("<%=txtEndDate.ClientID %>").value == "") {
                    document.getElementById("<%=txtEndHours.ClientID %>").disabled = true;
                    document.getElementById("<%=txtEndMins.ClientID %>").disabled = true;
                    document.getElementById("<%=ddlEndAPM.ClientID %>").disabled = true;
                }
                else {
                    document.getElementById("<%=txtEndHours.ClientID %>").disabled = false;
                    document.getElementById("<%=txtEndMins.ClientID %>").disabled = false;
                    document.getElementById("<%=ddlEndAPM.ClientID %>").disabled = false;
                }
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
    <script type="text/javascript">
        function ValidateDate() {
            // Begin Start Date
            var startdate = document.getElementById("<%=txtStartDate.ClientID %>").value;
            var startHour = "12";
            var startMins = "00";
            var errormsg = '';
            var parm1 = document.getElementById("<%=ddlStrAPM.ClientID%>");
            var startHalfs = parm1.options[parm1.selectedIndex].text;
            var sdCount = 2;
            if (document.getElementById("<%=txtStrHours.ClientID %>").value != "" && document.getElementById("<%=txtStrHours.ClientID %>").value != "Hour")
                startHour = document.getElementById("<%=txtStrHours.ClientID %>").value;
            else
                sdCount = sdCount - 1;
            if (document.getElementById("<%=txtStrMins.ClientID %>").value != "" && document.getElementById("<%=txtStrMins.ClientID %>").value != "Minutes")
                startMins = document.getElementById("<%=txtStrMins.ClientID %>").value;
            else
                sdCount = sdCount - 1;
            if (startHalfs == "PM" && sdCount == 0)
                errormsg = 'Please enter timings for start date.';
            if (errormsg == '') {
                var startDateTime = startdate + " " + startHour + ":" + startMins + " " + startHalfs;
                //end Start Date

                // Begin End Date
                var enddate = document.getElementById("<%=txtEndDate.ClientID %>").value;
                var endHour = "12";
                var endMins = "00";
                var edCount = 2;
                var parm2 = document.getElementById("<%=ddlEndAPM.ClientID%>");
                var endHalfs = parm2.options[parm2.selectedIndex].text;
                if (document.getElementById("<%=txtEndHours.ClientID %>").value != "" && document.getElementById("<%=txtEndHours.ClientID %>").value != "Hour")
                    endHour = document.getElementById("<%=txtEndHours.ClientID %>").value;
                else
                    edCount = edCount - 1;
                if (document.getElementById("<%=txtEndMins.ClientID %>").value != "" && document.getElementById("<%=txtEndMins.ClientID %>").value != "Minutes")
                    endMins = document.getElementById("<%=txtEndMins.ClientID %>").value;
                else
                    edCount = edCount - 1;
                if (endHalfs == "PM" && edCount == 0)
                    errormsg = 'Please enter timings for end date.';
                if (errormsg == '') {
                    var endDateTime = enddate + " " + endHour + ":" + endMins + " " + endHalfs;
                    //End of End Date

                    if (parseInt(startHour) > 12 || parseInt(startMins) > 59)
                        errormsg = "Please enter valid timings for start date.";
                    if (startHalfs == "PM") {
                        if (parseInt(startHour) <= 0) {
                            errormsg = "Please enter valid timings for start date.";
                        }
                    }
                    if (parseInt(endHour) > 12 || parseInt(endMins) > 59)
                        errormsg = "Please enter valid timings for end date.";
                    if (endHalfs == "PM" && parseInt(endHour) <= 0) {
                        errormsg = "Please enter valid timings for end date.";
                    }
                    if ((new Date(startDateTime)) > (new Date(endDateTime)))
                        errormsg = "End date and time should be later than or equal to start date and time.";
                }
            }
            return errormsg;
        }
        $("#txtStartDate").change(
            function () {

            }
        );
        
    </script>
    <style>
        .summarybold
        {
        	font-size:14px;
        	font-weight:bold;
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
        .stepwrapmain
        {
            width: 700px;
            vertical-align:top;
            position:fixed;
        }
     .right_buttons1
        {
            position: relative;
            top: -116px;
            left:0;
            height:0px;
            right:0px;
            float:right;
            margin-left:0px;
            margin-right:36px;
            vertical-align: top;
        }
        
        @-moz-document url-prefix() { 
        .right_buttons1
        {
            position: relative;
            top: -116px; 
            height:0px;
            left:0;
            float:right;
            right:0px;
            margin-left:0px;
            margin-right:36px;
            vertical-align: top;
        }
        }
        .stepswrap
        {
            overflow: hidden;
            margin: 0 auto;
            width: 488px;
            position: relative;
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
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <link href="../../css/repeatcal.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery.datepicker.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(BindLoadEvents);
            </script>
            <div id="popup" style="display: none;">
            </div>
            <div id='editorPopup' style="display: none; position: absolute; margin-top: 150px;
                margin-left: 150px; z-index: 100;">
                <uc2:UCEditor ID="UCEditor1" runat="server" />
            </div>
            <asp:Panel ID="Panel1" DefaultButton="btnSaveExit" runat="server">
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
                                ValidationGroup="group" HeaderText="The following error(s) occurred:" />
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="contentwrap">
                        <div class="largetxt">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            <%--Event Calendar--%></div>
                        <div class="form_wrapper" style="float: none; width: auto;">
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <label style="color: Red; font-size: 16px; margin-left: 200px;">
                                    * Marked fields are mandatory.</label>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="steps">
                                <span style="color: Red; font-size: 16px; vertical-align: middle;">*</span> Step
                                1: Name Your Event <a href="javascript:ModalHelpPopup('Create Event',145,'');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a></div>
                            <div class="stepswrapmain">
                                <div class="stepswrap">
                                    <div class="fields_wrap">
                                        <div class="right_fields" style="width: 488px;">
                                            <asp:HiddenField ID="hdnEventID" runat="server" />
                                            <asp:TextBox ID="txtEventName" runat="server" Width="477px" CssClass="txtfild1" MaxLength="150"
                                                onkeyup="CountMaxLength(this,'event name');" onChange="CountMaxLength(this,'event name');"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_pct" runat="server" ControlToValidate="txtEventName"
                                                ValidationGroup="group" Display="Dynamic" ErrorMessage="Please enter a title for your Event.">*</asp:RequiredFieldValidator>
                                            <div style="width: 510px; margin: 0px 0px 0px 0px; clear: both;">
                                                <label>
                                                    <asp:Label runat="server" ID="lblCount" Text="150"></asp:Label>
                                                    Characters remaining.
                                                </label>
                                                <label style="margin-left: 165px;">
                                                    (150 characters max)
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="steps">
                                    Step 2: Enter Event Dates</div>
                                <div class="stepswrap1">
                                    <div class="fields_wrap">
                                        <div class="right_fields" style="width: 470px;">
                                            <table class="border" width="100%" cellpadding="5">
                                                <colgroup>
                                                    <col width="32.5%" />
                                                    <col width="*" />
                                                </colgroup>
                                                <tr>
                                                    <td class="lable" valign="top">
                                                        <span style="color: Red; font-size: 16px; vertical-align: middle;">*</span> Event
                                                        Start Date & Time
                                                    </td>
                                                    <td align="left">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td valign="top" align="left" style="width: 110px;">
                                                                    <asp:TextBox ID="txtStartDate" runat="server" TabIndex="2" ValidationGroup="group"
                                                                        Width="90px" onChange="ShowDateTimeDiv('1');"></asp:TextBox>
                                                                    <%--<b>(MM/DD/YYYY)</b>||onchange="javascript:AddEndDate(this);"--%>
                                                                    <cc1:CalendarExtender ID="calex" runat="server" CssClass="MyCalendar" Format="MM/dd/yyyy"
                                                                        TargetControlID="txtStartDate">
                                                                    </cc1:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" runat="server"
                                                                        ControlToValidate="txtStartDate" ValidationGroup="group" Display="Dynamic" Text="*"
                                                                        ErrorMessage="Please enter Event Start Date."></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtStartDate"
                                                                        Display="Dynamic" ErrorMessage="Invalid Date Format" SetFocusOnError="True" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                        ValidationGroup="group"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:TextBox runat="server" ID="txtStrHours" Width="50px" Enabled="false" MaxLength="2"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtStrHours"
                                                                        WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtStrHours" ValidationExpression="^(1[0-2]|0[1-9]|[0-9])$"
                                                                        ValidationGroup="group" ErrorMessage="Invalid Start Time">*</asp:RegularExpressionValidator>
                                                                    &nbsp;
                                                                    <asp:TextBox runat="server" ID="txtStrMins" Width="50px" Enabled="false" MaxLength="2"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtStrMins"
                                                                        WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtStrMins" ValidationExpression="^([0-5][0-9]|[0-9])$" ValidationGroup="group"
                                                                        ErrorMessage="Invalid Start Time">*</asp:RegularExpressionValidator>
                                                                </td>
                                                                <td valign="top" style="padding: 1px;">
                                                                    <asp:DropDownList runat="server" ID="ddlStrAPM" Enabled="false" Width="60px" Height="23px">
                                                                        <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="lable" nowrap valign="top" style="padding-top: 2px;">
                                                        <span style="color: Red; font-size: 16px; vertical-align: middle;">*</span> Event
                                                        End Date & Time&nbsp;
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td valign="top" style="width: 110px;">
                                                                    <asp:TextBox ID="txtEndDate" runat="server" TabIndex="2" ValidationGroup="group"
                                                                        Width="90px" onChange="ShowDateTimeDiv('2');"></asp:TextBox>
                                                                    <%--<b>(MM/DD/YYYY)</b>--%>
                                                                    <cc1:CalendarExtender ID="CalextEnddate" runat="server" CssClass="MyCalendar" Format="MM/dd/yyyy"
                                                                        TargetControlID="txtEndDate">
                                                                    </cc1:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEndDate"
                                                                        ValidationGroup="group" SetFocusOnError="true" Display="Dynamic" Text="*" ErrorMessage="Please enter Event End Date."></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true"
                                                                        runat="server" ControlToValidate="txtEndDate" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                                                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                        ValidationGroup="group"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:TextBox runat="server" ID="txtEndHours" Width="50px" Enabled="false" MaxLength="2"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txtEndHours"
                                                                        WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtEndHours" ValidationExpression="^(1[0-2]|0[1-9]|[0-9])$"
                                                                        ValidationGroup="group" ErrorMessage="Invalid End Time">*</asp:RegularExpressionValidator>
                                                                    &nbsp;
                                                                    <asp:TextBox runat="server" ID="txtEndMins" Width="50px" Enabled="false" MaxLength="2"></asp:TextBox>
                                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" TargetControlID="txtEndMins"
                                                                        WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                                    </cc1:TextBoxWatermarkExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                                                                        ControlToValidate="txtEndMins" ValidationExpression="^([0-5][0-9]|[0-9])$" ValidationGroup="group"
                                                                        ErrorMessage="Invalid End Time">*</asp:RegularExpressionValidator>
                                                                </td>
                                                                <td valign="top" style="padding: 1px;">
                                                                    <asp:DropDownList runat="server" ID="ddlEndAPM" Enabled="false" Width="60px" Height="23px">
                                                                        <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <!-- remove style="display:none below to enable recurring and go to there where ---// *** Uncomment once we enable recurring *** // this has in javascript-->
                                                        <asp:Panel ID="pnlRepeatShow" runat="server" Style="display: none;">
                                                            <asp:CheckBox ID="chkRepeat" runat="server" OnClick="ShowRepeat(this);" />
                                                            Repeat<span id="repeatSummary" class="ep-recl-summary"></span><div id="divEditCal"
                                                                style="display: none;" class="cal-edit">
                                                                <a class="lk" id="editRepeatCal" href="javascript:void(0)" style="">Edit</a></div>
                                                        </asp:Panel>
                                                        <asp:HiddenField ID="hdnEventDates" runat="server" />
                                                        <asp:HiddenField ID="hdnCurrentDate" runat="server" />
                                                        <asp:HiddenField ID="hdnSeriesChangeType" runat="server" Value="0" />
                                                        <asp:HiddenField ID="hdnAlreadyRepeat" runat="server" Value="0" />
                                                        <asp:HiddenField ID="hdn3Items" runat="server" />
                                                        <asp:HiddenField ID="hdnEndOn" runat="server" />
                                                        <asp:HiddenField ID="hdnRepeatOn" runat="server" />
                                                        <asp:HiddenField ID="hdnRepeatBy" runat="server" />
                                                        <asp:HiddenField ID="hdn3Itemsold" runat="server" />
                                                        <asp:HiddenField ID="hdnEndOnold" runat="server" />
                                                        <asp:HiddenField ID="hdnRepeatOnold" runat="server" />
                                                        <asp:HiddenField ID="hdnRepeatByold" runat="server" />
                                                        <asp:HiddenField ID="hdnCalChanged" runat="server" />
                                                        <asp:HiddenField ID="hdnDataChanged" runat="server" />
                                                        <asp:HiddenField ID="hdnIsAlreadyPublished" runat="server" Value="0" />
                                                        <asp:HiddenField ID="hdnFacebook" runat="server" />
                                                        <asp:HiddenField ID="hdnTwitter" runat="server" />
                                                        <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="clear10">
                                </div>
                                <div class="steps">
                                    Step 3: Build Your Event</div>
                                <div style="width: 700px; margin: 0px 0px 0px 212px;">
                                    <div class="stepswrap1" style="float: left;">
                                        <div class="fields_wrap">
                                            <div class="left_lable">
                                                <font color="red"></font>
                                                <label>
                                                </label>
                                            </div>
                                            <div style="text-align: right; float: left;">
                                                <div class="avatar" style="border-width: 0px; width: 468px; display: block; max-height: 400px;
                                                    overflow: auto;">
                                                    <asp:Label ID="lblEditText" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="text-align: right; float: left; margin: 16px 0px 0px 10px;">
                                        <img style="cursor: pointer;" onclick="AddBlocks('DIV_TEXT');" src="../../Images/addnewtext.png" />
                                        <a id="A1" href="javascript:ModalHelpPopup('Add Text to Event',58,'');">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a><br />
                                        <br />
                                        <img style="cursor: pointer;" onclick="AddBlocks('DIV_IMAGE');" src="../../Images/addnewimg.png" />
                                        <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Add Image to Template',193,'');">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                        <br />
                                        <br />
                                        <img style="cursor: pointer;" onclick="AddBlocks('DIV_VIDEO');" src="../../Images/AddVideo.png" />
                                        <a id="AddVideo" href="javascript:ModalHelpPopup('Add Video to Template',274,'');">
                                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                    </div>
                                </div>
                                <div class="clear10">
                                </div>
                                <div class="steps">
                                    Step 4: Choose Status</div>
                                <div class="stepswrap1">
                                    <div class="fields_wrap">
                                        <div class="left_lable">
                                            <label>
                                            </label>
                                        </div>
                                        <div class="right_fields" style="width: 470px;">
                                            <div style="margin: 0px 0px 0px 0px;">
                                                <table width="100%" cellpadding="0" cellspacing="0" id='tblExTime'>
                                                    <tr>
                                                        <td>
                                                            <label>
                                                                Expiration Date & Time:
                                                            </label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtExDate" runat="server" Width="100px" onChange="ShowExTimeDiv();"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtExDate"
                                                                ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                ValidationGroup="group" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExDate"
                                                                Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtExHours" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14" TargetControlID="txtExHours"
                                                                WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                            </cc1:TextBoxWatermarkExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server"
                                                                Display="Dynamic" ControlToValidate="txtExHours" ValidationExpression="^(1[0-2]|0?[1-9])"
                                                                ValidationGroup="group" ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                                            &nbsp; &nbsp;
                                                            <asp:TextBox runat="server" ID="txtExMinutes" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender15" TargetControlID="txtExMinutes"
                                                                WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                            </cc1:TextBoxWatermarkExtender>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" Display="Dynamic"
                                                                ControlToValidate="txtExMinutes" ValidationExpression="^[0-5]\d" ValidationGroup="group"
                                                                ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                            <asp:DropDownList runat="server" ID="ddlExSS" Enabled="False" Width="60px">
                                                                <asp:ListItem Text="AM" Value="AM" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="steps">
                                    </div>
                                    <div class="fields_wrap">
                                        <div class="left_lable">
                                            <label>
                                            </label>
                                        </div>
                                        <div class="right_fields" style="width: 470px; margin-left: 150px;">
                                            <label runat="server" id="divCall">
                                                <asp:CheckBox ID="chkCall" runat="server" />
                                                Display Call Button</label>
                                            <br />
                                            <label id="divContactUs" runat="server">
                                                <asp:CheckBox ID="chkContact" runat="server" />
                                                Display Contact Us Button</label>
                                        </div>
                                    </div>
                                    <div class="fields_wrap">
                                        <div class="left_lable">
                                            <label>
                                            </label>
                                        </div>
                                        <div class="right_fields" style="width: 470px; margin-left: 150px;">
                                            <div style="margin: 0px 0px 0px 0px;">
                                                <asp:RadioButton ID="rbPrivate" runat="server" GroupName="Public" Checked="true"
                                                    onclick="javascript:ShowPublish('1','0')" />
                                                <label>
                                                    Private</label>
                                                <asp:RadioButton ID="rbPublic" runat="server" GroupName="Public" onclick="javascript:ShowPublish('2','0')" />
                                                <asp:Label ID="lblPublish" runat="server" Text="Publish" CssClass="approval"></asp:Label>
                                                <div style="margin: 10px 0px 0px 80px; display: none;" id="divpublish">
                                                    <div id="divSchedulePublish" style="display: block;">
                                                        <font color="red">*</font>
                                                        <label style="font-size: 14px;">
                                                            Publish Date:</label>
                                                        <asp:TextBox ID="txtPublishDate" runat="server" Width="75"></asp:TextBox><asp:TextBox
                                                            ID="txtPD" runat="server" Width="0" Height="0" BorderStyle="None" Style="display: none;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPD"
                                                            runat="server" ErrorMessage="Publish Date is mandatory." Display="Dynamic" ValidationGroup="group"
                                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="REPublishDate" runat="server" Display="Dynamic"
                                                            ControlToValidate="txtPublishDate" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                            ValidationGroup="group" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator>
                                                        <br />
                                                        <span style="padding-left: 91px;"><b>(MM/DD/YYYY)</b></span><br />
                                                        <cc1:CalendarExtender ID="calPublish" runat="server" TargetControlID="txtPublishDate"
                                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
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
                                                    <asp:HiddenField ID="hdnPublishDate" runat="server" />
                                                    <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
                                                </div>
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
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                                        Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSaveExit" runat="server" Text="Save" CssClass="btn" border="0"
                                        OnClick="btnSaveExit_Click" ValidationGroup="group" OnClientClick="return PreviewHTML('2');" />
                                    <asp:LinkButton ID="lnkPreview" runat="server" OnClientClick="return ShowPreview();">
                                    <img src="../../images/BulletinThumbs/preview.png"  width="100" height="37"></asp:LinkButton>
                                    <div style="display: none;">
                                        <asp:Button ID="btnSubmitChanges" runat="server" Text="Save" CssClass="btn" border="0"
                                            OnClick="btnSaveExit_Click" CausesValidation="false" /></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div id="overlayconfirm" class="confirm_dialog_overlay">
            </div>
            <div id="dialogconfirm" class="confirm_dialog">
                <div class="ep-es-dialog-title">
                    <span class="ep-es-dialog-title-text" role="heading">Edit recurring event</span>
                    <a id="btnConfirmClose" class="modalCloseImg" title="Close"></a>
                </div>
                <div class="ep-es-dialog-content">
                    <div class="ep-es">
                        <p>
                            Would you like to change only this event, all events in the series, or this and
                            all following events in the series?</p>
                        <table class="ep-es-buttons">
                            <tbody>
                                <tr>
                                    <td class="ep-es-button-cell">
                                        <div class="goog-inline-block">
                                            <input id="btnOnly" type="button" value="Only this event" class="goog-imageless-button-content" />
                                        </div>
                                    </td>
                                    <td class="ep-es-explanation-cell">
                                        <p>
                                            All other events in the series will remain the same.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ep-es-button-cell">
                                        <div class="goog-inline-block">
                                            <input id="btnFollowing" type="button" value="Following events" class="goog-imageless-button-content" />
                                        </div>
                                    </td>
                                    <td class="ep-es-explanation-cell">
                                        <p>
                                            This and all the following events will be changed.</p>
                                        <p class="ep-es-warning">
                                            Any changes to future events will be lost.</p>
                                    </td>
                                </tr>
                                <tr id="trAllSeries">
                                    <td class="ep-es-button-cell">
                                        <div class="goog-inline-block">
                                            <input id="btnAllSeries" type="button" value="All events" class="goog-imageless-button-content" />
                                        </div>
                                    </td>
                                    <td class="ep-es-explanation-cell">
                                        <p>
                                            All events in the series will be changed.</p>
                                        <p class="ep-es-warning">
                                            Any changes made to other events will be kept.</p>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="ep-es-cancel-button">
                            <input id="btnConfirmCancel" type="button" value="Cancel this change" class="goog-imageless-button-content" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="overlay" class="web_dialog_overlay">
            </div>
            <div id="dialog" class="web_dialog">
                <div>
                    <h3>
                        Repeat</h3>
                    <a id="btnClose" class="modalCloseImg" title="Close"></a>
                    <div class="ep-recl-dialog" id="divRepeat">
                        <div class="ep-recl-dialog-content">
                            <div>
                                <table class="ep-rec">
                                    <tbody>
                                        <tr>
                                            <th>
                                                Repeats:
                                            </th>
                                            <td>
                                                <select id="my_select">
                                                    <option value="0" id="0" title="Daily">Daily</option>
                                                    <option value="1" id="1" title="Weekly">Weekly</option>
                                                    <option value="2" id="2" title="Monthly">Monthly</option>
                                                    <option value="3" id="3" title="Yearly">Yearly</option>
                                                </select>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div id="divDaily">
                                    <table class="ep-rec">
                                        <tbody>
                                            <tr>
                                                <th>
                                                    Repeat every:
                                                </th>
                                                <td>
                                                    <select id="Select0">
                                                        <option value="1">1</option>
                                                        <option value="2">2</option>
                                                        <option value="3">3</option>
                                                        <option value="4">4</option>
                                                        <option value="5">5</option>
                                                        <option value="6">6</option>
                                                        <option value="7">7</option>
                                                        <option value="8">8</option>
                                                        <option value="9">9</option>
                                                        <option value="10">10</option>
                                                        <option value="11">11</option>
                                                        <option value="12">12</option>
                                                        <option value="13">13</option>
                                                        <option value="14">14</option>
                                                        <option value="15">15</option>
                                                        <option value="16">16</option>
                                                        <option value="17">17</option>
                                                        <option value="18">18</option>
                                                        <option value="19">19</option>
                                                        <option value="20">20</option>
                                                        <option value="21">21</option>
                                                        <option value="22">22</option>
                                                        <option value="23">23</option>
                                                        <option value="24">24</option>
                                                        <option value="25">25</option>
                                                        <option value="26">26</option>
                                                        <option value="27">27</option>
                                                        <option value="28">28</option>
                                                        <option value="29">29</option>
                                                        <option value="30">30</option>
                                                    </select>
                                                    <label>
                                                        days</label>
                                                </td>
                                            </tr>
                                            <tr tabindex="0" style="display: none;">
                                                <th id=":2s.rstart-label">
                                                    Starts on:
                                                </th>
                                                <td>
                                                    <input id="0Start" size="10" disabled="" autocomplete="off">
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <th class="ep-rec-ends-th">
                                                    Ends:
                                                </th>
                                                <td>
                                                    <span class="ep-rec-ends-opt">
                                                        <input id="radio0occurance" type="radio" title="Ends after a number of occurrences"
                                                            checked="checked" name="radi0" onclick="ChangeEnds('0','1','5','');">
                                                        <label title="Ends after a number of occurrences" for=":2s.endson_count">
                                                            After
                                                            <input id="txt0occurance" title="Occurrences" value="5" size="3">
                                                            occurrences
                                                        </label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span
                                                            class="ep-rec-ends-opt">
                                                            <input id="radio0until" type="radio" title="Ends on a specified date" name="radi0"
                                                                onclick="ChangeEnds('0','2','','');">
                                                            <label title="Ends on a specified date" for=":2s.endson_until">
                                                                On
                                                                <input id="txt0until" title="Specified date" data-select="datepicker" disabled=""
                                                                    value="" size="10" autocomplete="off">
                                                            </label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <th>
                                                    Summary:
                                                </th>
                                                <td class="ep-rec-summary">
                                                    <span id="summary0" class="summarybold"></span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div id="divWeekly" style="display: none;">
                                    <table class="ep-rec">
                                        <tbody>
                                            <tr>
                                                <th>
                                                    Repeat every:
                                                </th>
                                                <td>
                                                    <select id="Select1">
                                                        <option value="1">1</option>
                                                        <option value="2">2</option>
                                                        <option value="3">3</option>
                                                        <option value="4">4</option>
                                                        <option value="5">5</option>
                                                        <option value="6">6</option>
                                                        <option value="7">7</option>
                                                        <option value="8">8</option>
                                                        <option value="9">9</option>
                                                        <option value="10">10</option>
                                                        <option value="11">11</option>
                                                        <option value="12">12</option>
                                                        <option value="13">13</option>
                                                        <option value="14">14</option>
                                                        <option value="15">15</option>
                                                        <option value="16">16</option>
                                                        <option value="17">17</option>
                                                        <option value="18">18</option>
                                                        <option value="19">19</option>
                                                        <option value="20">20</option>
                                                        <option value="21">21</option>
                                                        <option value="22">22</option>
                                                        <option value="23">23</option>
                                                        <option value="24">24</option>
                                                        <option value="25">25</option>
                                                        <option value="26">26</option>
                                                        <option value="27">27</option>
                                                        <option value="28">28</option>
                                                        <option value="29">29</option>
                                                        <option value="30">30</option>
                                                    </select>
                                                    <label>
                                                        weeks</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    Repeat on:
                                                </th>
                                                <td id=":2l.checkboxes">
                                                    <div>
                                                        <span class="ep-rec-dow">
                                                            <input id="chkSUN" value="1" type="checkbox" title="Sunday" aria-label="Repeat on Sunday"
                                                                name="SU" onchange="ShowSummaryPop();" />
                                                            <label title="Sunday" for=":2l.dow0">
                                                                S</label>
                                                        </span><span class="ep-rec-dow">
                                                            <input id="chkMON" value="2" type="checkbox" title="Monday" aria-label="Repeat on Monday"
                                                                name="MO" onchange="ShowSummaryPop();" />
                                                            <label title="Monday" for=":2l.dow1">
                                                                M</label>
                                                        </span><span class="ep-rec-dow">
                                                            <input id="chkTUE" value="3" type="checkbox" title="Tuesday" aria-label="Repeat on Tuesday"
                                                                name="TU" onchange="ShowSummaryPop();" />
                                                            <label title="Tuesday" for=":2l.dow2">
                                                                T</label>
                                                        </span><span class="ep-rec-dow">
                                                            <input id="chkWED" value="4" type="checkbox" title="Wednesday" aria-label="Repeat on Wednesday"
                                                                name="WE" onchange="ShowSummaryPop();" />
                                                            <label title="Wednesday" for=":2l.dow3">
                                                                W</label>
                                                        </span><span class="ep-rec-dow">
                                                            <input id="chkTHU" value="5" type="checkbox" title="Thursday" aria-label="Repeat on Thursday"
                                                                name="TH" onchange="ShowSummaryPop();" />
                                                            <label title="Thursday" for=":2l.dow4">
                                                                T</label>
                                                        </span><span class="ep-rec-dow">
                                                            <input id="chkFRI" value="6" type="checkbox" title="Friday" aria-label="Repeat on Friday"
                                                                name="FR" onchange="ShowSummaryPop();" />
                                                            <label title="Friday" for=":2l.dow5">
                                                                F</label>
                                                        </span><span class="ep-rec-dow">
                                                            <input id="chkSAT" value="7" type="checkbox" title="Saturday" aria-label="Repeat on Saturday"
                                                                name="SA" onchange="ShowSummaryPop();" />
                                                            <label title="Saturday" for=":2l.dow6">
                                                                S</label>
                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr tabindex="0" style="display: none;">
                                                <th id=":2l.rstart-label">
                                                    Starts on:
                                                </th>
                                                <td>
                                                    <input id="1Start" size="10" disabled="" aria-labelledby=":2l.rstart-label" autocomplete="off">
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <th class="ep-rec-ends-th">
                                                    Ends:
                                                </th>
                                                <td>
                                                    <span class="ep-rec-ends-opt">
                                                        <input id="radio1occurance" type="radio" title="Ends after a number of occurrences"
                                                            checked="checked" name="radio1" onclick="ChangeEnds('1','1','5','');">
                                                        <label title="Ends after a number of occurrences" for=":2l.endson_count">
                                                            After
                                                            <input id="txt1occurance" title="Occurrences" value="5" size="3">
                                                            occurrences
                                                        </label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span
                                                            class="ep-rec-ends-opt">
                                                            <input id="radio1until" type="radio" title="Ends on a specified date" name="radio1"
                                                                onclick="ChangeEnds('1','2','','');">
                                                            <label title="Ends on a specified date" for=":2l.endson_until">
                                                                On
                                                                <input id="txt1until" title="Specified date" data-select="datepicker" disabled=""
                                                                    value="" size="10" autocomplete="off">
                                                            </label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <th>
                                                    Summary:
                                                </th>
                                                <td class="ep-rec-summary">
                                                    <span id="summary1" class="summarybold"></span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div id="divMonthly" style="display: none;">
                                    <table class="ep-rec">
                                        <tbody>
                                            <tr>
                                                <th>
                                                    Repeat every:
                                                </th>
                                                <td>
                                                    <select id="Select2">
                                                        <option value="1">1</option>
                                                        <option value="2">2</option>
                                                        <option value="3">3</option>
                                                        <option value="4">4</option>
                                                        <option value="5">5</option>
                                                        <option value="6">6</option>
                                                        <option value="7">7</option>
                                                        <option value="8">8</option>
                                                        <option value="9">9</option>
                                                        <option value="10">10</option>
                                                        <option value="11">11</option>
                                                        <option value="12">12</option>
                                                        <option value="13">13</option>
                                                        <option value="14">14</option>
                                                        <option value="15">15</option>
                                                        <option value="16">16</option>
                                                        <option value="17">17</option>
                                                        <option value="18">18</option>
                                                        <option value="19">19</option>
                                                        <option value="20">20</option>
                                                        <option value="21">21</option>
                                                        <option value="22">22</option>
                                                        <option value="23">23</option>
                                                        <option value="24">24</option>
                                                        <option value="25">25</option>
                                                        <option value="26">26</option>
                                                        <option value="27">27</option>
                                                        <option value="28">28</option>
                                                        <option value="29">29</option>
                                                        <option value="30">30</option>
                                                    </select>
                                                    <label>
                                                        months</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    Repeat by:
                                                </th>
                                                <td>
                                                    <span class="">
                                                        <input id="radio2Day" type="radio" title="Repeat by day of the month" aria-label="Repeat by day of the month"
                                                            checked="" name="repeatbyWeek" onclick="ShowSummaryPop();">
                                                        <label title="Repeat by day of the month" for=":2y.domrepeat">
                                                            day of the month</label>
                                                    </span><span class="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="radio2DayWeek"
                                                        type="radio" title="Repeat by day of the week" aria-label="Repeat by day of the week"
                                                        name="repeatbyWeek" onclick="ShowSummaryPop();">
                                                        <label title="Repeat by day of the week" for=":2y.dowrepeat">
                                                            day of the week</label>
                                                    </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr tabindex="0" style="display: none;">
                                                <th id=":2y.rstart-label">
                                                    Starts on:
                                                </th>
                                                <td>
                                                    <input id="2Start" size="10" disabled="" aria-labelledby=":2y.rstart-label" autocomplete="off">
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <th class="ep-rec-ends-th">
                                                    Ends:
                                                </th>
                                                <td>
                                                    <span class="ep-rec-ends-opt">
                                                        <input id="radio2occurance" type="radio" title="Ends after a number of occurrences"
                                                            checked="checked" name="radio2" onclick="ChangeEnds('2','1','5','');">
                                                        <label title="Ends after a number of occurrences" for=":2y.endson_count">
                                                            After
                                                            <input id="txt2occurance" title="Occurrences" value="5" size="3">
                                                            occurrences
                                                        </label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span
                                                            class="ep-rec-ends-opt">
                                                            <input id="radio2until" type="radio" title="Ends on a specified date" aria-label="Ends on a specified date"
                                                                name="radio2" onclick="ChangeEnds('2','2','','');">
                                                            <label title="Ends on a specified date" for=":2y.endson_until">
                                                                On
                                                                <input id="txt2until" title="Specified date" data-select="datepicker" disabled=""
                                                                    value="" size="10" autocomplete="off">
                                                            </label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                </td>
                                            </tr>
                                            <tr id=":2y.recsummary" tabindex="0" style="display: none;">
                                                <th>
                                                    Summary:
                                                </th>
                                                <td class="ep-rec-summary">
                                                    <span id="summary2" class="summarybold"></span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div id="divYearly" style="display: none;">
                                    <table class="ep-rec">
                                        <tbody>
                                            <tr>
                                                <th>
                                                    Repeat every:
                                                </th>
                                                <td>
                                                    <select id="Select3">
                                                        <option value="1">1</option>
                                                        <option value="2">2</option>
                                                        <option value="3">3</option>
                                                        <option value="4">4</option>
                                                        <option value="5">5</option>
                                                        <option value="6">6</option>
                                                        <option value="7">7</option>
                                                        <option value="8">8</option>
                                                        <option value="9">9</option>
                                                        <option value="10">10</option>
                                                        <option value="11">11</option>
                                                        <option value="12">12</option>
                                                        <option value="13">13</option>
                                                        <option value="14">14</option>
                                                        <option value="15">15</option>
                                                        <option value="16">16</option>
                                                        <option value="17">17</option>
                                                        <option value="18">18</option>
                                                        <option value="19">19</option>
                                                        <option value="20">20</option>
                                                        <option value="21">21</option>
                                                        <option value="22">22</option>
                                                        <option value="23">23</option>
                                                        <option value="24">24</option>
                                                        <option value="25">25</option>
                                                        <option value="26">26</option>
                                                        <option value="27">27</option>
                                                        <option value="28">28</option>
                                                        <option value="29">29</option>
                                                        <option value="30">30</option>
                                                    </select>
                                                    <label>
                                                        years</label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    Repeat by:
                                                </th>
                                                <td>
                                                    <span class="">
                                                        <input id="radio3Day" type="radio" title="Repeat by same day each year" aria-label="Repeat by same day each year"
                                                            checked="" name="repeatby" onclick="ShowSummaryPop();">
                                                        <label title="same day each year" for=":2y.domrepeat">
                                                            same day each year</label>
                                                    </span><span class="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="radio3DayWeek"
                                                        type="radio" title="Repeat by same week each year" aria-label="Repeat by same week each year"
                                                        name="repeatby" onclick="ShowSummaryPop();">
                                                        <label title="Repeat by same week each year" for=":2y.dowrepeat">
                                                            same week each year</label>
                                                    </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr tabindex="0" style="display: none;">
                                                <th id=":3n.rstart-label">
                                                    Starts on:
                                                </th>
                                                <td>
                                                    <input id="3Start" size="10" disabled="" aria-labelledby=":3n.rstart-label" autocomplete="off">
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <th class="ep-rec-ends-th">
                                                    Ends:
                                                </th>
                                                <td>
                                                    <span class="ep-rec-ends-opt">
                                                        <input id="radio3occurance" type="radio" title="Ends after a number of occurrences"
                                                            checked="checked" name="radio3" onclick="ChangeEnds('3','1','5','');">
                                                        <label title="Ends after a number of occurrences" for=":3n.endson_count">
                                                            After
                                                            <input id="txt3occurance" title="Occurrences" value="5" size="3">
                                                            occurrences
                                                        </label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span
                                                            class="ep-rec-ends-opt">
                                                            <input id="radio3until" type="radio" title="Ends on a specified date" aria-label="Ends on a specified date"
                                                                name="radio3" onclick="ChangeEnds('3','2','','');">
                                                            <label title="Ends on a specified date" for=":3n.endson_until">
                                                                On
                                                                <input id="txt3until" title="Specified date" data-select="datepicker" disabled=""
                                                                    value="" size="10" autocomplete="off">
                                                            </label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                </td>
                                            </tr>
                                            <tr id=":3n.recsummary" tabindex="0" style="display: none;">
                                                <th>
                                                    Summary:
                                                </th>
                                                <td class="ep-rec-summary">
                                                    <span id="summary3" class="summarybold"></span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <table class="ep-rec">
                                    <tbody>
                                        <tr tabindex="0">
                                            <th id="Th1">
                                                Starts on:
                                            </th>
                                            <td>
                                                <input id="txtRepeatStart" size="10" disabled="" autocomplete="off">
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="ep-rec-ends-th">
                                                Ends:
                                            </th>
                                            <td>
                                                <span class="ep-rec-ends-opt">
                                                    <input id="rbOccurrence" type="radio" title="Ends after a number of occurrences"
                                                        checked="checked" name="radioends" onclick="ChangeEndsNew('1','5');">
                                                    <label title="Ends after a number of occurrences" for="rbOccurrence">
                                                        After
                                                        <input id="txtOccurrence" title="Occurrences" value="5" size="3">
                                                        occurrences
                                                    </label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span
                                                        class="ep-rec-ends-opt">
                                                        <input id="rbUntil" type="radio" title="Ends on a specified date" name="radioends"
                                                            onclick="ChangeEndsNew('2','');">
                                                        <label title="Ends on a specified date" for="rbUntil">
                                                            On
                                                            <input id="txtUntilDate" title="Specified date" data-select="datepicker" disabled=""
                                                                value="" size="10" autocomplete="off">
                                                        </label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                Summary:
                                            </th>
                                            <td class="ep-rec-summary">
                                                <span id="eventSummary" class="summarybold"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                            </th>
                                            <td class="ep-rec-buttons-padding">
                                                <div>
                                                    <input id="btnSubmit" type="button" value="Done" />
                                                    <input id="btnCalCancel" type="button" value="Cancel" />
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <script src="../../Scripts/jquery.datepicker.js" type="text/javascript"></script>
            <script type="text/javascript">
                var weekday = '';
                var untilDate = '';
                function TriggerAction() {
                    document.getElementById('<%=btnSubmitChanges.ClientID %>').click();
                    $find("<%=MPEProgress.ClientID %>").show();
                }
                function ShowDialog(modal) {
                    $("#overlay").show();
                    $("#dialog").fadeIn(300);

                    if (modal) {
                        $("#overlay").unbind("click");
                    }
                    else {
                        $("#overlay").click(function (e) {
                            HideDialog();
                        });
                    }
                }

                function HideDialog() {
                    $("#overlay").hide();
                    $("#dialog").fadeOut(300);
                }
                function ShowDialogConfirm(modal) {
                    $("#overlayconfirm").show();
                    $("#dialogconfirm").fadeIn(300);

                    if (modal) {
                        $("#overlayconfirm").unbind("click");
                    }
                    else {
                        $("#overlayconfirm").click(function (e) {
                            HideDialog();
                        });
                    }
                }

                function HideDialogConfirm() {
                    $("#overlayconfirm").hide();
                    $("#dialogconfirm").fadeOut(300);
                }

                function BindRepeatDetails() {
                    if (document.getElementById('<%=hdnAlreadyRepeat.ClientID %>').value == "1") {
                        BindChanges('Load');
                    }
                }
                function BindChanges(type) {
                    $("#divDaily").hide(); $("#divWeekly").hide(); $("#divMonthly").hide(); $("#divYearly").hide();
                    // *** Binding Repeats, Repeat Every and StartsOn *** //
                    var repeats = document.getElementById('<%=hdn3Itemsold.ClientID %>').value.split("##SP##");
                    var repeatOn = document.getElementById('<%=hdnRepeatOnold.ClientID %>').value.split(",");
                    var repeatBy = document.getElementById('<%=hdnRepeatByold.ClientID %>').value;
                    var ends = document.getElementById('<%=hdnEndOnold.ClientID %>').value.split("##SP##");
                    if (document.getElementById('<%=hdn3Items.ClientID %>').value != "" && type == "Bind") {
                        repeats = document.getElementById('<%=hdn3Items.ClientID %>').value.split("##SP##");
                        repeatOn = document.getElementById('<%=hdnRepeatOn.ClientID %>').value.split(",");
                        repeatBy = document.getElementById('<%=hdnRepeatBy.ClientID %>').value;
                        ends = document.getElementById('<%=hdnEndOn.ClientID %>').value.split("##SP##");
                    }

                    if (repeats.length > 0) {
                        var id = repeats[0];
                        if (repeatBy != "") {
                            var repeatDay = "#radio" + id + "Day";
                            var repeatDayWeek = "#radio" + id + "DayWeek";
                            if (repeatBy == '0')
                                $(repeatDay).attr('checked', "checked");
                            else
                                $(repeatDayWeek).attr('checked', "checked");
                        }
                        $('#my_select option[value=' + id + ']').attr('selected', 'selected');
                        var divID = 'divDaily';
                        if (id == '1')
                            divID = 'divWeekly';
                        else if (id == '2')
                            divID = 'divMonthly';
                        else if (id == '3')
                            divID = 'divYearly';
                        $("#" + divID).show();
                        var intervalID = 'Select' + id;
                        $('#' + intervalID + ' option[value=' + repeats[1] + ']').attr('selected', 'selected');
                        // // *** var startdateID = id + "Start"; *** // //
                        // // *** $('#' + startdateID).val(repeats[2]); *** // //
                        $('#txtRepeatStart').val(repeats[2]);
                        // *** Binding Ends *** //  
                        // // *** var occuranceID = "#radio" + id + "occurance";
                        // // *** var untilID = "#radio" + id + "until"; *** // //
                        // // *** var txtoccurance = "#txt" + id + "occurance"; *** // //
                        // // *** var txtuntil = "#txt" + id + "until"; *** // //                  
                        var occuranceID = "#rbOccurrence";
                        var untilID = "#rbUntil";
                        var txtoccurance = "#txtOccurrence";
                        var txtuntil = "#txtUntilDate";
                        if (ends[0] == "1") {
                            $(untilID).removeAttr('checked');
                            $(occuranceID).attr('checked', "checked");
                            $(txtoccurance).removeAttr("disabled");
                            $(txtuntil).attr("disabled", "disabled");
                            $(txtoccurance).val(ends[1]);
                            $(txtuntil).val('');
                        }
                        else {
                            $(occuranceID).removeAttr('checked');
                            $(untilID).attr('checked', "checked");
                            $(txtoccurance).attr("disabled", "disabled");
                            $(txtuntil).removeAttr("disabled");
                            $(txtoccurance).val('');
                            $(txtuntil).val(ends[1]);
                        }
                        weekday = '';
                        if (repeatOn.length > 0) {
                            if (repeatOn[0] == '1') {
                                $("#chkSUN").attr("checked", "checked");
                            }
                            if (repeatOn[1] == '1') {
                                $("#chkMON").attr("checked", "checked");
                            }
                            if (repeatOn[2] == '1') {
                                $("#chkTUE").attr("checked", "checked");
                            }
                            if (repeatOn[3] == '1') {
                                $("#chkWED").attr("checked", "checked");
                            }
                            if (repeatOn[4] == '1') {
                                $("#chkTHU").attr("checked", "checked");
                            }
                            if (repeatOn[5] == '1') {
                                $("#chkFRI").attr("checked", "checked");
                            }
                            if (repeatOn[6] == '1') {
                                $("#chkSAT").attr("checked", "checked");
                            }
                            GetRepeatOn(id);
                        }
                        ShowSummary(id, repeats[1], ends[0], ends[1], weekday, 'repeatSummary');
                    }
                    else {
                        $("#divEditCal").hide();
                        $("#repeatSummary").text('');
                    }
                }
                function ShowRepeat(chkRepeat) {
                    if (chkRepeat.checked) {
                        SelectRepeatType('CH');
                        ShowSummaryPop();
                    }
                    else {
                        $("#divEditCal").hide();
                        $("#repeatSummary").text('');
                    }
                }
                function SelectRepeatType(type) {
                    if (document.getElementById("<%=txtStartDate.ClientID %>").value != "" && document.getElementById("<%=txtEndDate.ClientID %>").value != "") {
                        if (type == 'RC') {
                            SetDefaultDaily();
                            SetDefaultWeekly();
                            SetDefaultMonthly();
                            SetDefaultYearly();
                            BindSelection();
                            var repeat = 0;
                            var hasRepeat
                            if (document.getElementById('<%=hdn3Items.ClientID %>').value != "") {
                                repeat = document.getElementById('<%=hdn3Items.ClientID %>').value.split("##SP##");
                                repeat = 1;
                            }
                            else if (document.getElementById('<%=hdn3Itemsold.ClientID %>').value != "") {
                                repeat = document.getElementById('<%=hdn3Itemsold.ClientID %>').value.split("##SP##");
                                repeat = 1;
                            }
                            if (repeat == 1 && repeat.length > 0) {
                                if (repeat[0] == $('#my_select :selected').val())
                                    BindChanges("Bind");
                            }
                        }
                        else {
                            if (document.getElementById('<%=hdn3Items.ClientID %>').value == "" && document.getElementById('<%=hdn3Itemsold.ClientID %>').value == "") {
                                ShowDialog(true);
                                BindSelection();
                            }
                            else {
                                BindChanges("Bind");
                            }
                        }
                    }
                    else {
                        document.getElementById("<%=chkRepeat.ClientID %>").checked = false;
                        alert('Please select a start date.');
                    }
                }
                function BindSelection() {
                    var id = $('#my_select :selected').val();
                    $("#divDaily").hide(); $("#divWeekly").hide(); $("#divMonthly").hide(); $("#divYearly").hide();
                    var divID = 'divDaily';

                    if (id == '1')
                        divID = 'divWeekly';
                    else if (id == '2')
                        divID = 'divMonthly';
                    else if (id == '3')
                        divID = 'divYearly';
                    $("#" + divID).show();
                    var startdateID = "txtRepeatStart"; // // *** id + "Start"; *** // //
                    $('#' + startdateID).val(document.getElementById("<%=txtStartDate.ClientID %>").value);
                }
                function SetDefaultDaily() {
                    // // *** $("#radio0until").removeAttr("checked"); *** // //
                    // // *** $("#radio0occurance").removeAttr("checked"); *** // //
                    // // *** $("#radio0occurance").attr("checked", "checked"); *** // //
                    // // *** $("#txt0until").removeAttr("disabled"); *** // //
                    // // *** $("#txt0until").val(''); *** // //
                    // // *** $("#txt0occurance").removeAttr("disabled"); *** // //
                    // // *** $("#txt0until").attr("disabled", "disabled"); *** // //
                    // // *** $("#txt0occurance").val("5"); *** // //
                    $("#Select0 option[value=1]").attr("selected", "selected");
                }
                function SetDefaultWeekly() {
                    // // *** $("#radio1until").removeAttr("checked"); *** // //
                    // // *** $("#radio1occurance").removeAttr("checked"); *** // //
                    // // *** $("#radio1occurance").attr("checked", "checked"); *** // //
                    // // *** $("#txt1until").removeAttr("disabled"); *** // //
                    // // *** $("#txt1until").val(''); *** // //
                    // // *** $("#txt1occurance").removeAttr("disabled"); *** // //
                    // // *** $("#txt1until").attr("disabled", "disabled"); *** // //
                    // // *** $("#txt1occurance").val("5"); *** // //
                    $("#Select1 option[value=1]").attr("selected", "selected");
                    $("#chkSUN").removeAttr("checked");
                    $("#chkMON").removeAttr("checked");
                    $("#chkTUE").removeAttr("checked");
                    $("#chkWED").removeAttr("checked");
                    $("#chkTHU").removeAttr("checked");
                    $("#chkFRI").removeAttr("checked");
                    $("#chkSAT").removeAttr("checked");
                    var dateArray = $("#txtRepeatStart").val().split('/');
                    var startDate = new Date(dateArray[2], dateArray[0] - 1, dateArray[1]);
                    $("#chk" + GetDayNameShort(startDate)).attr("checked", "checked"); ;
                }
                function SetDefaultMonthly() {
                    $("#radio2Day").removeAttr("checked");
                    $("#radio2DayWeek").removeAttr("checked");
                    $("#radio2Day").attr("checked", "checked");
                    // // *** $("#radio2until").removeAttr("checked"); *** // //
                    // // *** $("#radio2occurance").removeAttr("checked"); *** // //
                    // // *** $("#radio2occurance").attr("checked", "checked"); *** // //
                    // // *** $("#txt2until").removeAttr("disabled"); *** // //
                    // // *** $("#txt2until").val(''); *** // //
                    // // *** $("#txt2occurance").removeAttr("disabled"); *** // //
                    // // *** $("#txt2until").attr("disabled", "disabled"); *** // //
                    // // *** $("#txt2occurance").val("5");
                    $("#Select2 option[value=1]").attr("selected", "selected");
                }
                function SetDefaultYearly() {
                    $("#radio3Day").removeAttr("checked");
                    $("#radio3DayWeek").removeAttr("checked");
                    $("#radio3Day").attr("checked", "checked");
                    // // *** $("#radio3until").removeAttr("checked"); *** // //
                    // // *** $("#radio3occurance").removeAttr("checked"); *** // //
                    // // *** $("#radio3occurance").attr("checked", "checked"); *** // //
                    // // *** $("#txt3until").removeAttr("disabled"); *** // //
                    // // *** $("#txt3until").val(''); *** // //
                    // // *** $("#txt3occurance").removeAttr("disabled"); *** // //
                    // // *** $("#txt3until").attr("disabled", "disabled"); *** // //
                    // // *** $("#txt3occurance").val("5"); *** // //
                    $("#Select3 option[value=1]").attr("selected", "selected");
                }
                function ShowSummaryPop() {
                    var id = $('#my_select :selected').val();
                    var summaryid = "eventSummary"; // // *** "summary" + id; *** // //
                    var intervalID = 'Select' + id;
                    var occuranceID = "rbOccurrence";  // // *** "radio" + id + "occurance"; *** // //
                    var ends1 = "1";
                    var ends2 = "5";
                    if ($("#" + occuranceID).attr("checked"))
                        ends2 = $("#txtOccurrence").val(); // // *** $("#txt" + id + "occurance").val(); *** // //
                    else {
                        ends1 = "2";
                        ends2 = $("#txtUntilDate").val(); // // *** $("#txt" + id + "until").val(); *** // //
                    }
                    GetRepeatOn(id);
                    var repeatx = $('#' + intervalID + ' :selected').val();
                    endson = ends1 + "##SP##" + ends2;
                    ShowSummary(id, repeatx, ends1, ends2, weekday, summaryid);
                }
                function ShowSummary(selid, repeatx, ends1, ends2, weekdays, summaryId) {
                    var repeatSummary = ' ';
                    if (ends1 == '1' && ends2 == '1') {
                        repeatSummary = repeatSummary + 'once ';
                    }
                    else {
                        if (selid == '0') {
                            if (repeatx != '1')
                                repeatSummary = repeatSummary + 'Every ' + repeatx + ' days, ';
                            else
                                repeatSummary = repeatSummary + ' Daily, ';
                        }
                        else if (selid == '1') {
                            if (repeatx != '1')
                                repeatSummary = repeatSummary + 'Every ' + repeatx + ' weeks on ' + weekdays + ', ';
                            else
                                repeatSummary = repeatSummary + ' Weekly on ' + weekdays + ', ';
                        }
                        else if (selid == '2') {
                            if (repeatx != '1')
                                repeatSummary = repeatSummary + 'Every ' + repeatx + ' months on ' + WeekAndDay(selid) + ', ';
                            else
                                repeatSummary = repeatSummary + ' Monthly on ' + WeekAndDay(selid) + ', ';
                        }
                        else if (selid == '3') {
                            if (repeatx != '1')
                                repeatSummary = repeatSummary + 'Every ' + repeatx + ' years on ' + WeekAndDay(selid) + ', ';
                            else
                                repeatSummary = repeatSummary + ' Annually  on ' + WeekAndDay(selid) + ', ';
                        }
                        if (ends1 == '1')
                            repeatSummary = repeatSummary + ends2 + ' times ';
                        else {
                            var endsdate = ends2.split("/");
                            repeatSummary = repeatSummary + 'until ' + GetMonthName(endsdate) + ' ' + endsdate[1] + ', ' + endsdate[2];
                        }
                    }
                    if (summaryId.indexOf('repeatSummary') != -1) {
                        if ($.trim(repeatSummary) != '')
                            $("#divEditCal").show();
                        else
                            $("#divEditCal").hide();
                    }
                    $("#" + summaryId).text(repeatSummary);
                }
                function GetWeekofDay() {
                    var weekdays = new Array(7);
                    weekdays[0] = "Sunday"; weekdays[1] = "Monday"; weekdays[2] = "Tuesday"; weekdays[3] = "Wednesday";
                    weekdays[4] = "Thursday"; weekdays[5] = "Friday"; weekdays[6] = "Saturday";
                    var dayName = weekdays[d.getDay()];
                    return dayName;
                }
                function WeekAndDay(id) {
                    var datearray = document.getElementById("<%=txtStartDate.ClientID %>").value.split("/");
                    var monthNameYearly = " in " + GetMonthName(datearray);
                    var selRepeatType = "#radio2Day";
                    if (id == '3')
                        selRepeatType = "#radio3Day";
                    if ($(selRepeatType).attr("checked"))
                        return ((id == '3' ? (' ' + GetMonthName(datearray) + ' ') : ('day ')) + datearray[1]);
                    var date = new Date(datearray[2], datearray[0] - 1, datearray[1]);
                    days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
                    prefixes = ['first', 'second', 'third', 'fourth', 'Last'];
                    return 'the ' + prefixes[0 | date.getDate() / 7] + ' ' + days[date.getDay()] + (id == '3' ? monthNameYearly : '');
                }
                function GetDayNameShort(d) {
                    var weekdays = new Array(7);
                    weekdays[0] = "SUN"; weekdays[1] = "MON"; weekdays[2] = "TUE"; weekdays[3] = "WED";
                    weekdays[4] = "THU"; weekdays[5] = "FRI"; weekdays[6] = "SAT";
                    var dayName = weekdays[d.getDay()];
                    return dayName;
                }
                function GetDayName(d) {
                    var weekdays = new Array(7);
                    weekdays[0] = "Sunday"; weekdays[1] = "Monday"; weekdays[2] = "Tuesday"; weekdays[3] = "Wednesday";
                    weekdays[4] = "Thursday"; weekdays[5] = "Friday"; weekdays[6] = "Saturday";
                    var dayName = weekdays[d.getDay()];
                    return dayName;
                }
                function GetMonthName(datearray) {
                    var d = new Date(datearray[2], datearray[0] - 1, datearray[1]);
                    var montharray = new Array(12);
                    montharray[0] = "Jan"; montharray[1] = "Feb"; montharray[2] = "Mar"; montharray[3] = "Apr"; montharray[4] = "May"; montharray[5] = "Jun";
                    montharray[6] = "Jul"; montharray[7] = "Aug"; montharray[8] = "Sep"; montharray[9] = "Oct"; montharray[10] = "Nov"; montharray[11] = "Dec";
                    var monthName = montharray[d.getMonth()];
                    return monthName;
                }
                function GetRepeatOn(id) {
                    var repeaton = '';
                    weekday = '';
                    if (id == "1") {
                        if ($("#chkSUN").attr("checked")) {
                            repeaton = "1,";
                            weekday = "Sun";
                        }
                        else
                            repeaton = "0,";
                        if ($("#chkMON").attr("checked")) {
                            repeaton = repeaton + "1,";
                            weekday = (weekday != '' ? weekday + ',' : '') + "Mon";
                        }
                        else
                            repeaton = repeaton + "0,";
                        if ($("#chkTUE").attr("checked")) {
                            repeaton = repeaton + "1,";
                            weekday = (weekday != '' ? weekday + ',' : '') + "Tue";
                        }
                        else
                            repeaton = repeaton + "0,";
                        if ($("#chkWED").attr("checked")) {
                            repeaton = repeaton + "1,";
                            weekday = (weekday != '' ? weekday + ',' : '') + "Wed";
                        }
                        else
                            repeaton = repeaton + "0,";
                        if ($("#chkTHU").attr("checked")) {
                            repeaton = repeaton + "1,";
                            weekday = (weekday != '' ? weekday + ',' : '') + "Thu";
                        }
                        else
                            repeaton = repeaton + "0,";
                        if ($("#chkFRI").attr("checked")) {
                            repeaton = repeaton + "1,";
                            weekday = (weekday != '' ? weekday + ',' : '') + "Fri";
                        }
                        else
                            repeaton = repeaton + "0,";
                        if ($("#chkSAT").attr("checked")) {
                            repeaton = repeaton + "1,";
                            weekday = (weekday != '' ? weekday + ',' : '') + "Sat";
                        }
                        else
                            repeaton = repeaton + "0,";
                        repeaton = repeaton + '0';
                    }
                    if (repeaton == '0,1,1,1,1,1,0,0')
                        weekday = "weekdays";
                    return repeaton;
                }
                function GetUntilDate(id) {
                    var startdateID = "#txtRepeatStart";  // // *** "#" + id + "Start"; *** // //
                    var intervalID = 'Select' + id;
                    var repeatx = $('#' + intervalID + ' :selected').val();
                    var endsdate = $(startdateID).val().split("/");
                    var currentDate = new Date(endsdate[2], endsdate[0] - 1, endsdate[1]);
                    var addmonths = 0;
                    if (id == '0') {
                        addmonths = parseInt(repeatx) * 5;
                        currentDate.setDate(currentDate.getDate() + addmonths);
                    }
                    else if (id == '1') {
                        addmonths = (parseInt(repeatx) * 7) * 5;
                        currentDate.setDate(currentDate.getDate() + addmonths);
                    }
                    else if (id == '2') {
                        addmonths = parseInt(repeatx) * 35;
                        currentDate.setMonth(currentDate.getMonth() + addmonths);
                    }
                    else if (id == '3') {
                        addmonths = parseInt(repeatx) * 5;
                        currentDate.setYear(currentDate.getFullYear() + addmonths);
                    }
                    return [(currentDate.getMonth() + 1).padLeft(), currentDate.getDate().padLeft(), currentDate.getFullYear()].join('/');
                }
                function SaveRepeatFunction() {
                    var id = $('#my_select :selected').val();
                    var intervalID = 'Select' + id;
                    var occuranceID = "rbOccurrence";  // // *** "radio" + id + "occurance"; *** // //
                    var ends1 = "1";
                    var ends2 = "5";
                    if ($("#" + occuranceID).attr("checked"))
                        ends2 = $("#txtOccurrence").val();  // // *** $("#txt" + id + "occurance").val(); *** // //
                    else {
                        ends1 = "2";
                        ends2 = $("#txtUntilDate").val();  // // *** $("#txt" + id + "until").val(); *** // //
                    }
                    var repeatby = '';
                    weekday = '';
                    var repeaton = GetRepeatOn(id);
                    if (id == "2" || id == "3") {
                        repeatby = '0';
                        if ($("#radio" + id + "DayWeek").attr("checked"))
                            repeatby = '1';
                    }
                    var repeatx = $('#' + intervalID + ' :selected').val();
                    endson = ends1 + "##SP##" + ends2;
                    ShowSummary(id, repeatx, ends1, ends2, weekday, 'repeatSummary');
                    document.getElementById("<%=hdn3Items.ClientID %>").value = id + "##SP##" + repeatx + "##SP##" + document.getElementById("<%=txtStartDate.ClientID %>").value;
                    document.getElementById("<%=hdnEndOn.ClientID %>").value = endson;
                    document.getElementById("<%=hdnRepeatOn.ClientID %>").value = repeaton;
                    document.getElementById("<%=hdnRepeatBy.ClientID %>").value = repeatby;
                    if (document.getElementById("<%=hdnAlreadyRepeat.ClientID %>").value == "1") {
                        if ((document.getElementById("<%=hdn3Items.ClientID %>").value != document.getElementById("<%=hdn3Itemsold.ClientID %>").value) ||
                                (document.getElementById("<%=hdnEndOn.ClientID %>").value != document.getElementById("<%=hdnEndOnold.ClientID %>").value) ||
                                (document.getElementById("<%=hdnRepeatOn.ClientID %>").value != document.getElementById("<%=hdnRepeatOnold.ClientID %>").value) ||
                                (document.getElementById("<%=hdnRepeatBy.ClientID %>").value != document.getElementById("<%=hdnRepeatByold.ClientID %>").value)) {
                            document.getElementById("<%=hdnCalChanged.ClientID %>").value = "1";
                        }
                        else
                            document.getElementById("<%=hdnCalChanged.ClientID %>").value = "";
                    }
                    //alert(document.getElementById("<%=hdn3Items.ClientID %>").value + "             " + document.getElementById("<%=hdnEndOn.ClientID %>").value + "           " + document.getElementById("<%=hdnRepeatOn.ClientID %>").value);
                }
                function ChangeEndsNew(type, occurrence) {
                    var id = $('#my_select :selected').val();
                    var occuranceID = "txtOccurrence";
                    var untilID = "txtUntilDate";
                    untilDate = '';
                    if (type == '2') {
                        untilDate = GetUntilDate(id);
                        $("#" + untilID).removeAttr("disabled");
                        $("#" + occuranceID).attr("disabled", "disabled");
                    }
                    else {
                        $("#" + occuranceID).removeAttr("disabled");
                        $("#" + untilID).attr("disabled", "disabled");
                    }
                    $("#" + untilID).val(untilDate);
                    $('#' + occuranceID).val(occurrence);
                    ShowSummaryPop();
                }
                function ChangeEnds(id, type, occurance, date) {
                    var occuranceID = "txt" + id + "occurance";
                    var untilID = "txt" + id + "until";
                    untilDate = '';
                    if (type == '2') {
                        untilDate = GetUntilDate(id);
                        $("#" + untilID).removeAttr("disabled");
                        $("#" + occuranceID).attr("disabled", "disabled");
                    }
                    else {
                        $("#" + occuranceID).removeAttr("disabled");
                        $("#" + untilID).attr("disabled", "disabled");
                    }
                    $("#" + untilID).val(untilDate);
                    $('#' + occuranceID).val(occurance);
                    ShowSummaryPop();
                }
                function CheckRepeatLimit(ends1, ends2, id, repeatx) {
                    if (ends1 == "1") {
                        var ends2int = parseInt(ends2);
                        if (ends2int > 30)
                            return false;
                    }
                    else if (ends2 == "2") {
                        var ends2array = ends2.split("##SP##")
                        var selDate = new Date(ends2array[2], ends2array[0] - 1, ends2array[1]);
                        var datenow = new Date();
                        var datelimit = d.setFullYear(datenow.getFullYear() + 10);
                    }
                }  
            </script>
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
                                        <asp:Label ID="lblueventnamepreview" runat="server"></asp:Label>
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
    <input type="hidden" id='ids' value='' />
    <input type="hidden" id='htmlvalue' />
    <input type="hidden" id="editDivCheck" value="" />
    <input type="hidden" id="hdnalignindex" />
    <input type="hidden" id="hdnChanges" value="false" />
    <asp:HiddenField runat="server" ID="hdnEditHTML" />
    <asp:HiddenField runat="server" ID="hdnPreviewHTML" />
    <asp:HiddenField ID="hdnChangeStartDate" runat="server" />
    <asp:HiddenField runat="server" ID="hdnURLPath" />
    <asp:HiddenField ID="hdnPermissionType" runat="server" />
    <asp:HiddenField ID="hdnDescription" runat="server" Value="" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
