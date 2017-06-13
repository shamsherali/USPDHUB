<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLite.master" AutoEventWireup="true"
    CodeBehind="LiteDashboard.aspx.cs" Inherits="USPDHUB.Business.MyAccount.LiteDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/EditCCDetails.ascx" TagName="CCDetails" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="Server">
    <style type="text/css">
        #Videowrap
        {
            width: 230px;
            height: 170px;
        }
        #Video
        {
            border: 1px solid #00AAA0;
            height: 200px;
            display: table;
        }
        #Video .img
        {
            vertical-align: middle;
            display: table-cell;
        }
        #Video img
        {
            width: 200px;
            vertical-align: middle;
        }
        .videotitle
        {
            padding-top: 3px;
            color: #FF7A5A;
            font-weight: bold;
        }
        #Videowrap label
        {
            line-height: 14px;
            font-size: 12px;
        }
        .couponcode
        {
            width: 100px;
        }
        .couponcode:hover .coupontooltip
        {
            display: inline-block;
        }
        .coupontooltip
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            margin-left: 10px;
            margin-bottom: 100px;
            border: 1px dashed #297CCF;
            padding: 10px;
            line-height:20px;
            position: absolute;
            z-index: 1000;
            width: 320px;
            height: 80px;
            color: Black;
        }
        #ctl00_lblcontent table
        {
            display:block;
        }
         #ctl00_lblcontent table tr td:first-child
        {
            padding-right:3px;
        }
    </style>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <div class="container-fluid timebar">
        <div class="container" style="padding-right: 0px;">
            <div class="timebarlist" id="timebarlist">
                <div class="timebardate">
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                </div>
                <div class="timebartime">
                    <asp:Label ID="lblTime" runat="server"></asp:Label><%if (Session["IsSponsor"] == null)
                                                                         { %>
                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/downarrow.png")%>" border="0"
                        id="imgSlideZones" />
                    <%} %>
                    <div class="slidedown" align="center">
                        <span>Select Your Time Zone:</span>
                        <asp:DropDownList ID="ddlTimeZones" runat="server" CssClass="dropdown">
                        </asp:DropDownList>
                        <br />
                        <input type="button" id="btnTimeSubmit" value="Submit" onclick="SaveZone();" class="slidedownsubmit" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%if ((Convert.ToInt32(lblTotalSMSOptIns.Text) > Convert.ToInt32(lblRemainingSMS.Text)) || lblDownloadExpiry.Text == "Yes" || ltrNotifications.Text != "")
      { %>
    <div class="container">
        <div class="row accountnotif">
            <header>
            <a href="javascript:void(0);" onclick="toggle_visibility('divNotify');"><img src="../../images/Dashboard/maximise.png" width="9" height="7" alt="max" style="margin:10px 0px 10px 0px;"></a>
                <h3>
                    Account Notifications &nbsp;&nbsp; <span class="couponcode">
                                        <img border="0" src="../../images/liteimages/Account-Notifications-Help.png" />
                                        <span class="coupontooltip">Account Notifications are communications<br /> from LogicTree IT about your subscription or other important messages. </span></span>
                    </h3>                    
            </header>
            <div class="col-lg-13 col-lg-offset-13 accountnotifcontent" id="divNotify">
                <asp:Literal ID="ltrNotifications" runat="server"></asp:Literal>
                <asp:UpdatePanel ID="uppnlpopuphelp" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="lnkDownload" />
                    </Triggers>
                    <ContentTemplate>
                        <% if (lblDownloadExpiry.Text == "Yes")
                           { %>
                        <p>
                            <img src="<%=Page.ResolveClientUrl("~/images/liteimages/star.png")%>" />
                            Welcome to inSchoolALERT.
                            <asp:LinkButton ID="lnkDownload" runat="server" Text="Click here" CausesValidation="false"
                                OnClick="lnkDownload_OnClick"></asp:LinkButton>
                            to download your setup instructions.
                        </p>
                        <%} %>
                        <asp:Label runat="server" ID="lblDownloadExpiry" Style="display: none;"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%if (Convert.ToInt32(lblTotalSMSOptIns.Text) > Convert.ToInt32(lblRemainingSMS.Text))
                  { %>
                <p>
                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages/star.png")%>" />
                    You have
                    <asp:Label ID="lblRemainingSMS" runat="server" Text="0"></asp:Label>
                    text messages left,
                    <asp:LinkButton ID="lnkBuyMore" runat="server" Text="Buy More" OnClick="lnkBuyMore_Click"
                        CausesValidation="false"></asp:LinkButton>.
                </p>
                <%} %>
                <asp:Label runat="server" ID="lblTotalSMSOptIns" Text="0" Style="display: none;"></asp:Label>
            </div>
        </div>
    </div>
    <%} %>
    <div class="container">
        <div class="row dashtabs">
            <div class="col-lg-6 col-md-6">
                <div class="row dashboxrow">
                    <div class="contacts dashbox">
                        <h4>
                            Contacts</h4>
                        <p>
                            Setup and manage your contacts for use with call buttons.</p>
                        <div class="clearfix">
                            <img src="<%=Page.ResolveClientUrl("~/images/liteimages/contacts.png")%>" /></div>
                        <div class="row boxicons">
                            <div class="col-lg-4 col-sm-4 text-left">
                                <a href="javascript:void(0)" onclick="ShowLiteVideos('Contacts')" title="Getting Started">
                                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages//play_icon.png")%>" />How
                                    to Video</a>
                            </div>
                            <div class="col-lg-4 col-sm-4">
                                <a href="javascript:HighlightKeyword('Contacts');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages/help_icon.png")%>" />Help</a>
                            </div>
                            <div class="col-md-4 col-sm-4 text-right">
                                <asp:LinkButton ID="lnkContacts" runat="server" class="setupbtn expiryStatus" OnClick="lnkContacts_Click"
                                    CausesValidation="false">Manage</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6">
                <div class="row dashboxrow">
                    <div class="callbtns dashbox">
                        <h4>
                            Call Buttons</h4>
                        <p>
                            Create and manage the buttons in your directory.</p>
                        <div class="clearfix">
                            <img src="<%=Page.ResolveClientUrl("~/images/liteimages/Call-Buttons.png")%>" /></div>
                        <div class="row boxicons">
                            <div class="col-lg-4 col-sm-4 text-left">
                                <a href="javascript:void(0)" onclick="ShowLiteVideos('CallButton')" title="Getting Started">
                                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages/play_icon.png")%>" />How
                                    to Video</a>
                            </div>
                            <div class="col-lg-4 col-sm-4">
                                <a href="javascript:HighlightKeyword('Call Buttons');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages/help_icon.png")%>" />Help</a>
                            </div>
                            <div class="col-lg-4 col-sm-4 text-right">
                                <a href="ManageDirect.aspx?ID=<%=hdnCallAddOnId.Value %>&Type=CallAddOns" class="setupbtn expiryStatus">
                                    Manage</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6">
                <div class="row dashboxrow">
                    <div class="manageinvitations dashbox">
                        <h4>
                            Manage Invitations</h4>
                        <p>
                            Send call button invitations and manage registered users.</p>
                        <div class="clearfix">
                            <img src="<%=Page.ResolveClientUrl("~/images/liteimages/Manage-Invitations.png")%>" /></div>
                        <div class="row boxicons">
                            <div class="col-lg-4 col-sm-4 text-left">
                                <a href="javascript:void(0)" onclick="ShowLiteVideos('Invitations')" title="Getting Started">
                                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages/play_icon.png")%>" />How
                                    to Video</a>
                            </div>
                            <div class="col-lg-4 col-sm-4">
                                <a href="javascript:HighlightKeyword('Manage Invitations');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages/help_icon.png")%>" />Help</a>
                            </div>
                            <div class="col-lg-4 col-sm-4 text-right">
                                <asp:LinkButton ID="lnkInvitations" runat="server" class="setupbtn expiryStatus" OnClick="lnkInvitations_Click"
                                    CausesValidation="false" >Manage</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6">
                <div class="row dashboxrow">
                    <div class="managenotifications dashbox">
                        <h4>
                            Manage Notifications</h4>
                        <p>
                            Schedule and send push notifications and text messages here.</p>
                        <div class="clearfix">
                            <img src="<%=Page.ResolveClientUrl("~/images/liteimages/Manage-Notifications.png")%>" /></div>
                        <div class="row boxicons">
                            <div class="col-lg-4 col-sm-4 text-left">
                                <a href="javascript:void(0)" onclick="ShowLiteVideos('Notifications')" title="Getting Started">
                                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages/play_icon.png")%>" />How
                                    to Video</a>
                            </div>
                            <div class="col-lg-4 col-sm-4">
                                <a href="javascript:HighlightKeyword('Send Notifications,View SMS,Schedule,');">
                                    <img src="<%=Page.ResolveClientUrl("~/images/liteimages/help_icon.png")%>" />Help</a>
                            </div>
                            <div class="col-lg-4 col-sm-4 text-right">
                                <a href="SendAppNotifications.aspx" class="setupbtn expiryStatus">Manage</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:LinkButton ID='lnkUpdateCredicard' runat='server' Text='Click Here' ForeColor='Blue'
            OnClick='lnkUpdateCredicard_OnClick' Style="display: none"></asp:LinkButton>
    </div>
    <table width="100%" class="modalmargin">
        <tr>
            <td>
                <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblpre"
                    PopupControlID="pnlVideos" BackgroundCssClass="popupmodal">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlVideos" runat="server" Width="100%" Style="display: none;">
                    <table style="background-color: White" cellspacing="0" cellpadding="0" width="770"
                        align="center" border="0">
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
                            <td style="padding: 5px;" align="right">
                                <a href="javascript:void(0);" onclick="CloseModal();">
                                    <img src="../../images/popup_close.gif" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel Style="display: none" ID="pnlVideolist" runat="server" Width="100%">
                                    <table style="background-color: White" cellspacing="0" cellpadding="0" width="100%"
                                        border="0">
                                        <tr>
                                            <td>
                                                <div style="overflow: scroll; overflow-x: hidden; height: 380px;">
                                                    <div id="dlGridVideos">
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel Style="display: none" ID="pnlpopup1" runat="server" Width="100%">
                                    <table style="background-color: White" cellspacing="0" cellpadding="0" width="100%"
                                        border="0">
                                        <tbody>
                                            <tr>
                                                <td style="padding: 5px;">
                                                    <label id="lblVideoTitle" style="color: Green; font-weight: bold;" />
                                                </td>
                                                <td align="right" style="padding-right: 20px;">
                                                    <a href="javascript:ShowVideosList();" style="color:#E45641; font-weight:bold;">Show Videos</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-bottom: 15px;" colspan="2">
                                                    <iframe id="IframeVideoPopup" width="640" height="375" frameborder="0" webkitallowfullscreen
                                                        mozallowfullscreen allowfullscreen></iframe>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:Panel>
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
                <asp:Label ID="lblpre5" runat="server"></asp:Label>
                <cc1:ModalPopupExtender ID="CCDetailsModalPopup" runat="server" TargetControlID="lblpre5"
                    PopupControlID="pnlpopup5" BackgroundCssClass="modal">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlpopup5" runat="server" Width="50%" Style="display: none;">
                    <table class="inputgrid nomargin-bottom">
                        <tr>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td id='tds' runat="server">
                                <uc2:CCDetails ID="CCDetails1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblFeatures" runat="server" visiable="false"></asp:Label>
                <cc1:ModalPopupExtender ID="ModalPopupExtenderFeatures" runat="server" TargetControlID="lblFeatures"
                    PopupControlID="pnlFeatures" BackgroundCssClass="popupmodal">
                </cc1:ModalPopupExtender>
                <asp:Panel Style="display: none" ID="pnlFeatures" runat="server" Width="100%">
                    <table style="background-color: White; padding: 10px; display: block; border: 5px solid #0491b6;"
                        cellspacing="0" cellpadding="0" width="450" align="center" border="0">
                        <tbody>
                            <tr>
                                <td style="padding-right: 0px; padding-top: 0px" align="right">
                                    <a href="javascript:void(0);" onclick="CloseFeaturesModal();">
                                        <img src="../../images/popup_close.gif" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="font-weight: bold;">
                                    Note!
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Please be advised that the <u>call directory button will not display</u> on the
                                    smart phones of the people who have downloaded the inSchoolALERT App and chosen
                                    your school as a Favorite <u>until you have sent an invitation</u> for them to view
                                    the button on their device.
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnTimeZoneID" runat="server" />
    <asp:HiddenField ID="hdnCallAddOnId" runat="server" />
    <asp:HiddenField runat="server" ID="hdnLaunchPlay" />
    <asp:HiddenField runat="server" Value="false" ID="hdnEpireStatus" />
    <script type="text/javascript">
        var slidevalue = '';
        $(document).ready(function () {
            $("#imgSlideZones").click(function () {
                if (slidevalue == '') {
                    $('.slidedown').slideDown('slow', 'swing')
                    slidevalue = '1';
                }
                else {
                    $('.slidedown').slideUp('slow', 'swing')
                    slidevalue = '';
                }
            });

            $('.expiryStatus').click(function () {                
                if ($('#<%=hdnEpireStatus.ClientID%>').val() == "true") {
                    alert('Your subscription has expired.');
                    return false;
                }
            });
        });
        function SaveZone() {
            $('.slidedown').slideUp('slow', 'swing')
            slidevalue = '';
            var timeZoneID = document.getElementById("<%=ddlTimeZones.ClientID%>").options[document.getElementById("<%=ddlTimeZones.ClientID%>").selectedIndex].value;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{'selZoneID': '" + timeZoneID + "' }",
                url: "Default.aspx/GetProfileID",
                dataType: "json",
                success: function (response) {
                    document.getElementById("<%=hdnTimeZoneID.ClientID %>").value = response.d;
                    doSomething();
                }
            });
        }
        function toggle_visibility(id) {
            if (document.getElementById(id).style.display == "none") {
                document.getElementById(id).style.display = "block";
            }
            else {
                document.getElementById(id).style.display = "none";
            }
        }
        function doSomething() {
            var days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]
            var currentTime;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/GetUserTimeZoneDashboard",
                dataType: "json",
                success: function (response) {
                    currentTime = new Date(response.d);
                    var month = currentTime.getMonth() + 1;
                    var day = currentTime.getDate();
                    var year = currentTime.getFullYear();
                    var hours = currentTime.getHours()
                    var minutes = currentTime.getMinutes()
                    if (minutes < 10)
                        minutes = "0" + minutes;
                    var hr = hours;
                    var dd = "A.M";
                    if (hr >= 12) {
                        hr = hours - 12;
                        dd = "P.M";
                    }
                    if (hr == 0) {
                        hr = 12;
                    }
                    var time = hr + ":" + minutes + " " + dd;
                    document.getElementById('<%=lblTime.ClientID %>').innerHTML = time + " " + document.getElementById("<%=hdnTimeZoneID.ClientID %>").value;
                    document.getElementById('<%=lblDate.ClientID %>').innerHTML = days[currentTime.getDay()] + ", " + month + "/" + day + "/" + year;
                    setTimeout(doSomething, 60000); //Then set it to run again after 6 seconds
                }
            });
        }
        window.onload = function () {
            doSomething(); //Make sure the function fires as soon as the page is loaded   
            if (document.getElementById("<%=hdnLaunchPlay.ClientID %>").value == "Yes") {
                ShowVersionPopup();
                UpdateLaunchPlay('Launch');
            }
        }
        function ShowVersionPopup() {
            $find("<%=ModalPopupExtenderFeatures.ClientID %>").show();
        }
        function UpdateLaunchPlay(playType) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                data: "{playType:'" + playType + "'}",
                url: "Default.aspx/UpdateLaunchPlay",
                dataType: "json",
                success: function (response) {
                    var response = response.d;
                }
            });
        }
        function CloseFeaturesModal() {
            $find("<%=ModalPopupExtenderFeatures.ClientID %>").hide();
        }
        function ShowVideoPopup(url, videotitle) {
            document.getElementById('<%=pnlVideolist.ClientID %>').style.display = "none";
            document.getElementById('<%=pnlpopup1.ClientID %>').style.display = "block";
            document.getElementById('lblVideoTitle').innerHTML = videotitle;
            var Iframe = document.getElementById("IframeVideoPopup");
            Iframe.src = "http://player.vimeo.com/video/" + url;
            $find("<%=ModalPopupExtender2.ClientID %>").show();
        }
        function CloseModal() {
            var Iframe = document.getElementById("IframeVideoPopup");
            Iframe.src = '';
            $find("<%=ModalPopupExtender2.ClientID %>").hide();
        }
        function fireServerButtonEvent() {
            document.getElementById("<%=lnkUpdateCredicard.ClientID %>").click();
        }
        function ShowLiteVideos(blockType) {
            var strSdata = "{VideoType:'" + blockType + "'}";
            $find("<%=ModalPopupExtender2.ClientID %>").show();
            $("#dlGridVideos").empty();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "LiteDashboard.aspx/BindVideosData",
                data: strSdata,
                dataType: "json",
                success: function (data) {
                    var strdata = "";
                    if (data.d.length > 0) {
                        for (var i = 0; i < data.d.length; i++) {
                            if (i == 0) {
                                ShowVideoPopup(data.d[i].Url, data.d[i].Title)
                            }
                            document.getElementById('<%=pnlVideolist.ClientID %>').style.display = "block";
                            document.getElementById('<%=pnlpopup1.ClientID %>').style.display = "none";
                            strdata = strdata + "<div style='float:left; margin:10px;'><div id='Videowrap'><div id='Video' style='height:153px;'><a id='videoURL' href='javascript:void(0)' onclick='ShowVideoPopup(" + data.d[i].Url + ",\"" + data.d[i].Title + "\")'><img id='lblThumbnailUrl' src='" + data.d[i].Thumb_Url + "' CssClass='img'/></a></div>";
                            strdata = strdata + "<div class='videotitle'><label id='lblTitle'>" + data.d[i].Title + "</label></div>";
                            strdata = strdata + "<div class='clear'></div></div><div class='clear'></div></div>";
                        }
                        $("#dlGridVideos").append(strdata);
                    }
                },
                error: function (result) {
                    alert("Error Occured.");
                }
            });
        }
        function ShowVideosList() {
            document.getElementById('<%=pnlVideolist.ClientID %>').style.display = "block";
            document.getElementById('<%=pnlpopup1.ClientID %>').style.display = "none";
        }
    </script>
</asp:Content>
