<%@ Page Title="" Language="C#" MasterPageFile="~/PaidTools.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="ContentDownload.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ContentDownload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
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
            font-size: 16px;
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
    </style>
    <script type="text/javascript">

        var EntID = "";

        function PreviewHTML(typeID) {
            EntID = typeID;

            if (typeID == 2 || typeID == 3) {
                if (!$.trim($('#edit1').html()).length) {
                    alert('Please upload Image.');
                    return false;
                }
                ValidatePublishDate();
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
                                        tds = tds + "<tr><td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align: left;'>" + getHTML + " </td></tr>";
                                    }
                                    else {
                                        getHTML = getHTML.replace(/videoclass/gi, 'videoclass1');
                                        var imgAlignment = document.getElementById(id).style.textAlign;
                                        tds = tds + "<tr><td  style='width:" + (document.getElementById(id).offsetWidth - 12) + "px; padding-bottom: 2px; text-align:" + imgAlignment + ";'>" + getHTML + "</td></tr>";
                                    }

                                }
                            }
                        }
                    }

                }
            }

            //Dynamically Add Download Icon
            var downloadUrl = document.getElementById("<%=txtPDFLink.ClientID %>").value;
            var myRegExp = '^https?://(?:[a-z0-9\-]+\.)+[a-z]{2,6}(?:/[^/#?]+)+\.(?:pdf|PDF)$';
            var RootPath = '<%=RootPath %>';
            if (downloadUrl != "") {
                if (downloadUrl.match(myRegExp)) {
                    tds = tds + "<tr> " +
                          "<td  style='page-break-inside: avoid; padding-bottom: 2px; text-align: center;'><a href='" + RootPath + "/DownloadItems.aspx?DownloadFile=" + downloadUrl + "'><IMG border='0' src='" + RootPath + "/Images/Dashboard/donwloadcontent.png' /></a></td></tr>";
                }
                else {
                    tds = tds + "<tr> " +
                          "<td  style='page-break-inside: avoid; padding-bottom: 2px; text-align: center;'><a href='" + downloadUrl + "' target='_blank'><IMG border='0' src='" + RootPath + "/Images/Dashboard/donwloadcontent.png' /></a></td></tr>";
                }
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
                    data: "{htmlString:'" + bulletinHeader + "'}",
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

                    },
                    error: function (error) {
                        //alert("ERROR:: " + error.statusText);
                        document.getElementById("divLoading").style.display = "none";
                    }
                });

                return false;
            } // end IF
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

                    return true;
                }
            }
        }

        function Download() {

            alert(document.getElementById("hdnDownloadPDFurl").value);

            //document.getElementById("<%=btndummyDownload.ClientID %>").click();
            document.getElementById('<%=my_iframe.ClientID %>').src = document.getElementById("hdnDownloadPDFurl").value;


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

            $(".deleteblockclass").css("display", "none");
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
                } else {

                    document.getElementById('divSchedulePublish').style.display = "none";
                }
                document.getElementById('lblMandatory').style.display = "block";
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
        $(document).ready(function () {
            if ('<%= IsScheduleEmails %>' == 'False') {
                if (document.getElementById('<%= hdnPermissionType.ClientID%>').value == "A")
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Submit for approval";
                else
                    document.getElementById('<%= lblPublish.ClientID%>').innerHTML = "Publish Now";
            }
        });
    </script>
    <style>
        .drop div:hover
        {
            cursor: move;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <iframe id="my_iframe" runat="server" style="display: none;" />
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
                    <div>
                    </div>
                    <div class="largetxt" style="text-align: left;">
                        <asp:Label runat="server" ID="lblBulletinName" CssClass="navy20" Height="25px" Width="100%"></asp:Label></div>
                    <div class="form_wrapper" style="float: none; width: auto;">
                        <div class="clear10">
                        </div>
                        <div class="fields_wrap">
                            <label id="lblMandatory" style="color: Red; font-size: 16px; margin-left: 200px;
                                display: none;">
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
                                        <div class="largetxt" style="text-align: center; padding-left: 110px; height: 35px;
                                            border-bottom: none;">
                                            Newsletter Download
                                        </div>
                                    </label>
                                </div>
                            </div>
                            <div class="clear0">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable">
                                    <div class="avatar" style="border-width: 1px; width: 470px; display: block; max-height: 430px;
                                        overflow: auto;">
                                        <asp:Label ID="lblBulletinedit" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; margin: 65px 0px 0px 300px; display: none;">
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="fields_wrap">
                                <div class="left_lable" style="width: 300px;">
                                    <b>Copy & Paste the pdf link for download: </b>
                                    <br />
                                    <asp:TextBox runat="server" ID="txtPDFLink" Width="470px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPDFLink"
                                        runat="server" ErrorMessage="PDF Link is mandatory." Display="Dynamic" ValidationGroup="ABC"
                                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPDFLink"
                                        ValidationExpression="^https?://(?:[a-z0-9\-]+\.)+[a-z]{2,6}(?:/[^/#?]+)+\.(?:pdf|PDF)$"
                                        ValidationGroup="ABC" ErrorMessage="Invalid Path">*</asp:RegularExpressionValidator>--%>
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
                                                    <asp:TextBox runat="server" ID="txtExHours" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender14" TargetControlID="txtExHours"
                                                        WatermarkText="Hour" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtExHours" ValidationExpression="^(1[0-2]|0?[1-9])" ValidationGroup="ABC"
                                                        ErrorMessage="Invalid Time Format">*</asp:RegularExpressionValidator>
                                                    &nbsp; &nbsp;
                                                    <asp:TextBox runat="server" ID="txtExMinutes" Width="50px" Enabled="False" MaxLength="2"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender15" TargetControlID="txtExMinutes"
                                                        WatermarkText="Minutes" runat="server" WatermarkCssClass="watermarkbulletindate">
                                                    </cc1:TextBoxWatermarkExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                        ControlToValidate="txtExMinutes" ValidationExpression="^[0-5]\d" ValidationGroup="ABC"
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
                                    <asp:Button ID="btndummyDownload" runat="server" OnClick="btndummyDownload_OnClick"
                                        Style="display: none;" />
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
            <asp:HiddenField runat="server" ID="hdnPrivate" />
            <asp:HiddenField runat="server" ID="hdnCompleted" />
            <asp:HiddenField runat="server" ID="hdnBulletinHeader" />
            <input type="hidden" id="hdnChanges" value="false" />
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
            <asp:HiddenField ID="hdnRootPath" runat="server" />
            <asp:HiddenField ID="hdnDescription" runat="server" Value="" />
            <input type="hidden" id="hdnIsTextEdits" value="false" />
            <input type="hidden" runat="server" id="hdnBulletinID" value="0" />
            <asp:HiddenField ID="hdnPublishTitle" runat="server" Value="Publish" />
            <asp:HiddenField ID="hdnUserFont" runat="server" Value="Arial" />
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
