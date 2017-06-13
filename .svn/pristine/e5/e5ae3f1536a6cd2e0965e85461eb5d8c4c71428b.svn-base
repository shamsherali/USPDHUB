<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" Inherits="Business_MyAccount_SendEvent"
    CodeBehind="SendEvent.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <script type="text/javascript">
        var count = 0;
        function checkemailcount(id) {
            var end = id.value.substring(id.value.length - 1, id.value.length);
            var str = id.value.split(",");

            if (end == ",") {
                count = str.length - 1;
            }
            else {
                count = str.length;
            }
            if (id.value == "") {
                count = 0;
            }
//            var userid = $get('<%=hdnuserid.ClientID %>').value;
//            var daylimit = $get('<%=hdnlimit.ClientID %>').value;
//            PageMethods.ValidateSendrSchedule(id.value, userid, daylimit, OnSuccess, OnFail);
//            $get('<%=txtemailsperday.ClientID %>').value = "";
//            $get('<%=lblselectedcontactcount.ClientID %>').innerHTML = count;
        }
        function OnSuccess(result) {
            if (result == 1 & count != 0) {
                $get('<%=pnltext.ClientID %>').style.display = "";
                $get('<%=lnkSchEmail.ClientID %>').style.display = "";
                $get('<%=lnkSendmail.ClientID %>').style.display = "none";
                $get('<%=rbtnemailsperday.ClientID %>').checked = true;
                $get('<%=rbtnall.ClientID %>').checked = false;
                $get('<%=rbtnall.ClientID %>').setAttribute('disabled', 'disabled');
                $get('<%=txtemailsperday.ClientID %>').removeAttribute('disabled');
                $get('<%=hdncheckcontact.ClientID %>').value == "";
            }
            if (result == 2 & count != 0) {
                $get('<%=pnltext.ClientID %>').style.display = "";
                $get('<%=txtemailsperday.ClientID %>').setAttribute('disabled', 'disabled');
                $get('<%=rbtnall.ClientID %>').removeAttribute('disabled');
                $get('<%=rbtnall.ClientID %>').checked = true;
                $get('<%=rbtnemailsperday.ClientID %>').checked = false;
                $get('<%=lnkSchEmail.ClientID %>').style.display = "none";
                $get('<%=lnkSendmail.ClientID %>').style.display = "";
                $get('<%=hdncheckcontact.ClientID %>').value == "";
            }
            if (count == 0) {
                $get('<%=txtemailsperday.ClientID %>').setAttribute('disabled', 'disabled');
                $get('<%=lblselectedcontactcount.ClientID %>').innerHTML = "";
                $get('<%=pnltext.ClientID %>').style.display = "none";
                $get('<%=lnkSchEmail.ClientID %>').style.display = "none";
                $get('<%=lnkSendmail.ClientID %>').style.display = "none";
                $get('<%=rbtnall.ClientID %>').checked = false;
                $get('<%=rbtnemailsperday.ClientID %>').checked = false;
            }
        }
        function OnFail() { }

        function checkDayscount(id) {
            if (document.getElementById('<%= rbtnemailsperday.ClientID%>').checked) {
                var emailperdaycount = id.value;
                emailperdaycount = emailperdaycount.replace(/,/g, "");
                var strRegex = /^(\d{0,9}(\.\d{4})?)$/;
                if (strRegex.test(emailperdaycount)) {
                    var totalemailsCount = document.getElementById('<%= lblselectedcontactcount.ClientID%>').innerHTML;
                    var str = Math.round(totalemailsCount / emailperdaycount);
                    if ((totalemailsCount / emailperdaycount) > str) {
                        str = str + 1;
                    }
                    document.getElementById('<%=pnlApprSendDays.ClientID %>').style.display = "";
                    document.getElementById('<%=lblApprSendDays.ClientID %>').innerHTML = str;
                }
            }
        }
        function GetConfirmEmailContacts() {
            if ('<%= IsEmailContact %>' == 'False') {
                var msg = "The Email Contacts module is not included in your current subscription. The Email Contacts and Reporting module is available for purchase in the Market Place or you may manually enter your contacts in the field provided.";
                alert(msg);
                return false;
            }
            else {
                return true;
            }
        }

        function validateRemainingMails() {
            if ('<%=IsScheduleEmail %>' == 'False') {
                if (document.getElementById('<%= rbtnall.ClientID%>').checked) {
                    return true;
                }
                if (document.getElementById('<%= rbtnemailsperday.ClientID%>').checked) {
                    var msg = "The Scheduling Module is not included in your current subscription. The Scheduling Module is available for purchase in the Market Place.";
                    alert(msg);
                    return false;
                }
            }
            else {

                return true;
            }
            if (Page_ClientValidate('g') && Page_IsValid) {
//                var RemainingEmails = document.getElementById('<%=hdnRemainingEmails.ClientID %>').value;
//                var selectedEmails = document.getElementById('<%=hdnSelectedEmails.ClientID %>').value;
//                if (parseInt(RemainingEmails) < parseInt(selectedEmails)) {
//                    var msg = "Sorry, " + RemainingEmails + " email(s) are available to you. You have selected " + selectedEmails + " email(s). Please select less than or equal to " + RemainingEmails + " email(s).";
//                    alert(msg);
//                    return false;
//                }
            }
        }

        function CallJquery() {
            document.getElementById('DIDIFrm').innerHTML = "";
            document.getElementById('DIDIFrm').innerHTML = "<iframe src=\"https://player.vimeo.com/video/36113068\" width=\"500\" height=\"340\" frameborder=\"0\" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>";
            $(document).ready(function () {
                $("a.modal1").click(function (e) {
                    e.preventDefault();
                    //Get the A tag
                    var id = $(this).attr('href');
                    $(id).fadeTo("slow", 1.0);

                });
                //if close button is clicked
                $('.window .navigate').click(function (e) {
                    document.getElementById('DIDIFrm').innerHTML = "";
                    $('.window').hide();
                });
            });
        }
        var browserName = navigator.appName;
        if (browserName != "Microsoft Internet Explorer") {
            $(document).ready(function () {
                document.getElementById('DIDIFrm').innerHTML = "";
                document.getElementById('DIDIFrm').innerHTML = "<iframe src=\"https://player.vimeo.com/video/36113068\" width=\"500\" height=\"375\" frameborder=\"0\" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>";
                $("a.modal1").click(function (e) {
                    e.preventDefault();
                    //Get the A tag
                    var id = $(this).attr('href');
                    $(id).fadeTo("slow", 1.0);

                });
                //if close button is clicked
                $('.window .navigate').click(function (e) {
                    document.getElementById('DIDIFrm').innerHTML = "";
                    $('.window').hide();
                });
            });
        }

    </script>
    <style type="text/css">
        .cursor
        {
            cursor: hand;
        }
        .navy20
        {
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
        }
        .navy16
        {
            color: #2F348F;
            font-size: 14px;
            line-height: 22px;
            font-family: Arial;
        }
        .black16
        {
            color: #333;
            font-size: 16px;
            line-height: 22px;
            font-family: Arial;
        }
        .black16normal
        {
            color: #000;
            font-size: 14px;
            line-height: 22px;
            font-family: Arial;
        }
        .sendcontactsbutton
        {
            background: url(../../images/Dashboard/sendcontactsbutton_bg.png) no-repeat;
            width: 149px;
            height: 32px;
            color: #fff;
            font-size: 14px;
            text-align: center;
            border: 0px;
            font-weight: bold;
        }
        .txtarea11
        {
            font-size: 14px;
            color: #000;
            border: #D3D3D3 2px solid;
            font-family: Arial;
            resize: none;
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
            margin-top: 11%;
            margin-left: 34%;
        }
    </style>
    <script type="text/javascript">
        var browserName = navigator.appName;
        if (browserName != "Microsoft Internet Explorer") {
            $(document).ready(function () {
                $("a.modal1").click(function (e) {
                    e.preventDefault();
                    //Get the A tag
                    var id = $(this).attr('href');
                    $(id).fadeTo("slow", 1.0);

                });
                //if close button is clicked
                $('.window .navigate').click(function (e) {
                    $('.window').hide();
                });
            });
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <asp:HiddenField runat="server" ID="hdnURLPath" />
                                        <td style="height: 32px; font-size: 18px; color: #EC2027; margin-bottom: 5px; margin-top: 5px;
                                            font-weight: bold;" valign="top">
                                            Email Content <a href="javascript:ModalHelpPopup('Email Content',140,'');">
                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" style='border: 0px;' /></a>
                                        </td>
                                        <td class="navy20" valign="top" align="center" style="padding-left: 500px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding-right: 70px;" colspan="2">
                                            <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table cellpadding="0px" cellspacing="0" border="0" style="font-family: Arial; font-size: 10px;
                                                font-weight: normal;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblmess" runat="server" ForeColor="Green" Font-Size="Medium"></asp:Label><br />
                                                        <asp:Label ID="lblmsg" runat="server" align="center"></asp:Label><asp:Label ID="lblSchmails"
                                                            runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
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
                            <table style="background-color: #fff; border: 1px solid #F0F0F0;" cellspacing="0"
                                cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" style="padding: 10px;">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-top: 0px">
                                                            <asp:Panel ID="pnlcompose" runat="server" Width="100%">
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="padding-bottom: 10px;">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td colspan="2" height="30" class="navy20">
                                                                                Step 1: Select Recipients
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border-left: 1px solid #04519D;
                                                                                                border-right: 1px solid #04519D; border-bottom: 1px solid #04519D;">
                                                                                                <tr>
                                                                                                    <td colspan="2" style="background: url(../../images/Dashboard/header_sendemail.gif) repeat-x;
                                                                                                        height: 50px; border: 1px solid #04519D; padding: 0px 0px 0px 10px;">
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <img align="absmiddle" src="../../images/Dashboard/contacts.png" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Button ID="lnkimportcontacts" OnClick="lnkimportcontacts_Click" runat="server"
                                                                                                                        TabIndex="2" ToolTip="Select Contacts" CausesValidation="false" CssClass="sendcontactsbutton"
                                                                                                                        Text="Select Contacts" OnClientClick="return GetConfirmEmailContacts();"></asp:Button>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="center" style="padding: 0px 0px 0px 10px;">
                                                                                                        <span class="navy16" style="padding: 0px 0px 0px 0px;">or<br />
                                                                                                            Enter Manually<br />
                                                                                                        </span><span class="black16" align="left">Note: Please separate addresses with a comma.</span>
                                                                                                    </td>
                                                                                                    <td valign="middle" style="padding: 8px 0px 0px 0px;">
                                                                                                        <asp:TextBox ID="txtto" TabIndex="1" runat="server" Width="350px" Height="90px" CssClass="txtarea11"
                                                                                                            TextMode="MultiLine" onblur="checkemailcount(this)" ValidationGroup="g"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="g"
                                                                                                            ControlToValidate="txtto" ErrorMessage="Select Recipients is mandatory." Display="Dynamic">*</asp:RequiredFieldValidator>
                                                                                                        <br />
                                                                                                        <asp:Panel ID="pnltext" runat="server">
                                                                                                            <span style="padding-left: 80px; font-weight: bold;">You have selected
                                                                                                                <asp:Label ID="lblselectedcontactcount" runat="server"></asp:Label>&nbsp;contact(s).</span>
                                                                                                        </asp:Panel>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="middle" style="padding: 0px 0px 0px 5px;" width="200px" align="center">
                                                                                            <asp:Label ID="lblUpdatethumb" runat="server" Text="No Update Thumbnail"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <%--<tr>
                                                                            <td colspan="2" style="padding-top: 10px;">
                                                                                <span style="font-weight: bold; padding-right: 10px;">Monthly Emails:</span>
                                                                                <asp:Label ID="lblRemainingEmailsCount" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                            </td>
                                                                        </tr>--%>
                                                                        <tr>
                                                                            <td colspan="2" height="30" class="navy20" style="padding: 8px 0px 0px 0px;">
                                                                                Step 2: Enter Subject Line
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="padding: 5px 0px 0px 0px;">
                                                                                <asp:TextBox ID="txtsubject" TabIndex="2" runat="server" Width="815px" ValidationGroup="g"
                                                                                    MaxLength="100" CssClass="txtarea11"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="req1" runat="server" ValidationGroup="g" Display="Dynamic"
                                                                                    ControlToValidate="txtsubject" ErrorMessage="Subject is mandatory.">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="35" class="navy20" width="300">
                                                                                Step 3: Select Email Start Date
                                                                            </td>
                                                                            <td height="35" class="navy20" width="520" style=" display:none;">
                                                                                Step 4: Select Send Timing
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td width="300" valign="top">
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="90%" style="border: 1px solid #04519D;
                                                                                                padding: 10px;">
                                                                                                <tr>
                                                                                                    <td class="black16normal">
                                                                                                        Enter the date to begin sending
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="padding: 8px;">
                                                                                                        <span style="font-size: 13px; line-height: 22px;"><b>Start Date</b></span><br />
                                                                                                        <asp:TextBox ID="txtSendingDate" runat="server" ValidationGroup="g" TabIndex="3"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                            ID="reqdate" runat="server" ControlToValidate="txtSendingDate" Display="Dynamic"
                                                                                                            ValidationGroup="g" ErrorMessage="Date is mandatory.">*</asp:RequiredFieldValidator>
                                                                                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtSendingDate"
                                                                                                            Display="Dynamic" ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                                                                                            SetFocusOnError="True" ErrorMessage="Invalid Date Format" ValidationGroup="g"></asp:RegularExpressionValidator><br />
                                                                                                        <b>(MM/DD/YYYY)</b>
                                                                                                        <cc1:CalendarExtender ID="calex" runat="server" TargetControlID="txtSendingDate"
                                                                                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top" width="520" style=" display:none;">
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #04519D;
                                                                                                padding: 10px 0px 10px 0px;">
                                                                                                <colgroup>
                                                                                                    <col width="180px" />
                                                                                                    <col width="40px" />
                                                                                                    <col width="*" />
                                                                                                </colgroup>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                                                            <tr>
                                                                                                                <td style="padding: 0px 0px 0px 10px;">
                                                                                                                    <asp:RadioButton ID="rbtnall" runat="server" Text=" " GroupName="rbtnsendrschedule"
                                                                                                                        AutoPostBack="true" OnCheckedChanged="rbtnall_SelectedIndexChanged" TabIndex="4" />
                                                                                                                </td>
                                                                                                                <td style="padding: 10px; line-height: 18px;" class="black16normal">
                                                                                                                    Send to all<br />
                                                                                                                    selected contacts<br />
                                                                                                                    at one time
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td align="center" style="color: #000; font-size: 20px; font-weight: bold;">
                                                                                                        OR
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" style="padding: 0px 10px 0px 50px;">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                                <td class="black16normal" style="padding-left: 10px; padding-top: 15px;">
                                                                                                                    Send to
                                                                                                                    <asp:DropDownList ID="ddltime" runat="server" TabIndex="8" Visible="false">
                                                                                                                        <asp:ListItem Text="Select Schedule Time" Value="0"></asp:ListItem>
                                                                                                                        <asp:ListItem Text="3 a.m Pacific Standard Time" Value="3AM" Selected="True"></asp:ListItem>
                                                                                                                        <asp:ListItem Text="9 a.m Pacific Standard Time" Value="9AM"></asp:ListItem>
                                                                                                                        <asp:ListItem Text="3 p.m Pacific Standard Time" Value="3PM"></asp:ListItem>
                                                                                                                        <asp:ListItem Text="9 p.m Pacific Standard Time" Value="9PM"></asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="padding: 0px 0px 10px 0px;">
                                                                                                                    <asp:RadioButton ID="rbtnemailsperday" runat="server" AutoPostBack="true" Text=" "
                                                                                                                        GroupName="rbtnsendrschedule" OnCheckedChanged="rbtnemailsperday_SelectedIndexChanged"
                                                                                                                        TabIndex="5" onclick="CPcheckpostback()" />
                                                                                                                </td>
                                                                                                                <td style="padding-left: 10px;">
                                                                                                                    <asp:TextBox ID="txtemailsperday" runat="server" MaxLength="5" TabIndex="6" onblur="checkDayscount(this);"></asp:TextBox><br />
                                                                                                                    <asp:Label ID="lblstatic" runat="server" Text="Up to 1,000 per day" Font-Bold="true"></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                </td>
                                                                                                                <td class="black16normal" style="padding-left: 10px;">
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="2" style="font-weight: bold; padding-left: 10px;">
                                                                                                                    <asp:Panel ID="pnlApprSendDays" runat="server">
                                                                                                                        Approximate send time is
                                                                                                                        <asp:Label ID="lblApprSendDays" runat="server"></asp:Label>
                                                                                                                        days.
                                                                                                                    </asp:Panel>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td height="30" class="navy20">
                                                                                        Step 4: Add Links That Will Appear on Your Email
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #04519D; padding:20px;">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div style="display:block; margin-left:auto; margin-right:auto; width:250px;">
                                                                                                        <asp:CheckBox runat="server" ID="chkStoreLinks" Text="  App Store Links" Visible="false" style="padding-right:30px;">
                                                                                                        </asp:CheckBox>
                                                                                                        <asp:CheckBox runat="server" ID="chkContactus"></asp:CheckBox>&nbsp;<asp:Label runat="server"
                                                                                                            ID="lblContactus" Text="Contact Us"></asp:Label>
                                                                                                        <div style="display: none;">
                                                                                                            <asp:CheckBox runat="server" ID="chkduplicatecont" Checked="true"></asp:CheckBox>&nbsp;<asp:Label
                                                                                                                runat="server" ID="lblduplicate" Text="Remove duplicates before sending."></asp:Label></div>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" colspan="3" style="padding-top: 10px;">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <colgroup>
                                                                                    <col width="100px;" />
                                                                                    <col width="*" />
                                                                                </colgroup>
                                                                                <tr>
                                                                                    <td align="left" style="padding-right: 10px;" valign="middle">
                                                                                        <asp:HiddenField ID="hdnlimit" runat="server" />
                                                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                                        <asp:HiddenField ID="hdnRemainingEmails" Value="0" runat="server" />
                                                                                        <asp:HiddenField ID="hdnSelectedEmails" Value="0" runat="server" />
                                                                                    </td>
                                                                                    <td style="padding-top: 5px; padding-left: 170px;" align="left">
                                                                                        <asp:LinkButton ID="lnkCancelMail" runat="server" OnClick="lnkCancelMail_Click" CausesValidation="false"
                                                                                            TabIndex="9"><img src="../../images/Dashboard/cancel_button.gif" alt=""/></asp:LinkButton>
                                                                                        <asp:LinkButton ID="lnktestbusinessUpdate" runat="server" OnClick="lnktestbusinessUpdate_Click"
                                                                                            CausesValidation="false" TabIndex="10"><img src="../../images/Dashboard/send-testemail.png" alt=""/></asp:LinkButton>
                                                                                        <asp:LinkButton ID="lnkSendmail" runat="server" OnClick="lnkSendmail_Click" ValidationGroup="g"
                                                                                            TabIndex="11" OnClientClick="return validateRemainingMails();"><img src="../../images/Dashboard/send_button.gif" alt=""/></asp:LinkButton>
                                                                                        <asp:LinkButton ID="lnkSchEmail" runat="server" OnClick="lnkSchEmail_Click" ValidationGroup="g"
                                                                                            TabIndex="11" OnClientClick="return validateRemainingMails();"><img src="../../images/Dashboard/scheduleandsend_button.gif" alt="" /></asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table width="100%" class="inputgrid">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblEmailsch" runat="server" ForeColor="red"></asp:Label><br />
                                                                            <asp:Label ID="lblsendingDate" runat="server" ForeColor="green" nowrap></asp:Label>
                                                                            <asp:Label ID="lblerror" runat="server" ForeColor="red"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblc"
                                PopupControlID="pnlpopup" BackgroundCssClass="modal" CancelControlID="imglogin">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlpopup" runat="server" Width="100%">
                                <table style="padding-right: 10px" class="popuptable" cellspacing="0" cellpadding="0"
                                    width="800" align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnldiscontact" runat="server" Width="100%">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td class="header">
                                                                    Select Contacts
                                                                </td>
                                                                <td align="right">
                                                                    <asp:ImageButton ID="imglogin" OnClick="imclose_Click" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                        CausesValidation="false"></asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <iframe id="frmcontacts" runat="server" src="ContactManagement.aspx" frameborder="0"
                                                                        width="800px;" height="500px;" scrolling="no"></iframe>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnlnocotnact" runat="server" Width="100%">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <colgroup>
                                                            <col width="30%" />
                                                            <col width="*" />
                                                        </colgroup>
                                                        <tbody>
                                                            <tr>
                                                                <td style="padding-top: 12px" class="header" colspan="2">
                                                                    We are sorry, but you do not have any contacts in your contact lists.
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnenhance" OnClick="btnenhance_Click" runat="server" Text="Add Contacts">
                                                                    </asp:Button>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btndashboard" OnClick="btndashboard_Click" runat="server" Text="No Thanks">
                                                                    </asp:Button>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="popuplabel" colspan="2">
                                                                    Add Contacts: Add contacts to your contact lists.
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="popuplabel" colspan="2">
                                                                    No Thanks: Manually enter email addresses.
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Label ID="lblc" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblpre"
                                PopupControlID="pnlpopup1" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlpopup1" runat="server" Width="100%">
                                <table cellspacing="0" cellpadding="0" border="0" style="background-color: White;
                                    padding-left: 10px;" width="740px" align="center">
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px; padding-right: 20px;">
                                            <asp:ImageButton ID="imglogin1" OnClick="imclose_Click" runat="server" ImageUrl="~/images/popup_close.gif"
                                                CausesValidation="false"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 20px; padding-right: 10px;">
                                            <div style="height: 500px; overflow: auto; position: relative;">
                                                <asp:Label ID="lblPreviewHTML" runat="server" CssClass="hyperlink"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <td>
                        <asp:Label ID="lblsendtest" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblcsendtest" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" BackgroundCssClass="modal"
                            PopupControlID="pnlsendnewstest" TargetControlID="lblcsendtest" CancelControlID="imglogin4">
                        </cc1:ModalPopupExtender>
                        <asp:Panel Style="display: none" ID="pnlsendnewstest" runat="server" Width="100%"
                            DefaultButton="btntestsend">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                                <colgroup>
                                                    <col width="25%" />
                                                    <col width="*" />
                                                </colgroup>
                                                <tbody>
                                                    <tr style="padding-top: 20px;">
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td align="right">
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin4" OnClick="imclose_Click" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </td>
                                                    </tr>
                                                    <tr style="padding-top: 20px;">
                                                        <td>
                                                            Enter Email Address:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttestemail" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="reqtest" runat="server" ValidationGroup="t" ControlToValidate="txttestemail"
                                                                Display="Dynamic">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="t"
                                                                ControlToValidate="txttestemail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                SetFocusOnError="True" ErrorMessage="Invalid Email Format "></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr style="padding-top: 20px;">
                                                        <td>
                                                            Enter Subject:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMailSubject" Text="Test Event Campaign" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="padding-top: 20px; padding-bottom: 10px;">
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btntestsend" runat="server" OnClick="btntestsend_Click" Text="Send Test Event"
                                                                ValidationGroup="t" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <div style="visibility: hidden">
                <asp:Button ID="btnclick" runat="server" OnClick="btnclick_Click" CausesValidation="false" />
                <asp:Button ID="btncancelpop" runat="server" OnClick="btncancelpop_Click" CausesValidation="false" />
            </div>
            <asp:HiddenField ID="hdncheckcontact" runat="server" />
            <asp:HiddenField ID="hdnuserid" runat="server" />
            <asp:HiddenField ID="hdncheckpostback" runat="server" />
            <script type="text/javascript">
                function CheckControls() {

                    if (document.getElementById('<%=hdncheckcontact.ClientID %>').value == "1") {
                        document.getElementById('<%=pnltext.ClientID %>').style.display = "";
                        document.getElementById('<%=lnkSchEmail.ClientID %>').style.display = "";
                        document.getElementById('<%=lnkSendmail.ClientID %>').style.display = "none";
                        document.getElementById('<%=rbtnemailsperday.ClientID %>').checked = true;
                        document.getElementById('<%=rbtnall.ClientID %>').checked = false;
                        document.getElementById('<%=rbtnall.ClientID %>').setAttribute('disabled', 'disabled');
                        document.getElementById('<%=txtemailsperday.ClientID %>').removeAttribute('disabled');
                        document.getElementById('<%=hdncheckcontact.ClientID %>').value == "";
                    }
                    else if (document.getElementById('<%=hdncheckcontact.ClientID %>').value == "2") {

                        document.getElementById('<%=pnltext.ClientID %>').style.display = "";
                        document.getElementById('<%=txtemailsperday.ClientID %>').setAttribute('disabled', 'disabled');
                        document.getElementById('<%=rbtnall.ClientID %>').removeAttribute('disabled');
                        document.getElementById('<%=rbtnall.ClientID %>').checked = true;
                        document.getElementById('<%=rbtnemailsperday.ClientID %>').checked = false;
                        document.getElementById('<%=lnkSchEmail.ClientID %>').style.display = "none";
                        document.getElementById('<%=lnkSendmail.ClientID %>').style.display = "";
                        document.getElementById('<%=hdncheckcontact.ClientID %>').value == "";
                    }
                    else {
                        document.getElementById('<%=pnltext.ClientID %>').style.display = "none";
                    }
                }

                function validateradiobutton(value) {


                    if (document.getElementById('<%=txtto.ClientID %>').value != "") {

                        var end = document.getElementById('<%=txtto.ClientID %>').value.substring(document.getElementById('<%=txtto.ClientID %>').value.length - 1, document.getElementById('<%=txtto.ClientID %>').value.length);
                        var str = document.getElementById('<%=txtto.ClientID %>').value.split(",");
                        var count = 0
                        if (end == ",") {
                            count = str.length - 1;
                        }
                        else {
                            count = str.length;
                        }
                        document.getElementById('<%=lblselectedcontactcount.ClientID %>').innerHTML = count;
                        document.getElementById('<%=pnltext.ClientID %>').style.display = "";
                    }
                    else {

                        // document.getElementById('<%=txtemailsperday.ClientID %>').value="";  
                        document.getElementById('<%=pnltext.ClientID %>').style.display = "none";
                    }
                    if (value == "0") {
                        document.getElementById('<%=txtemailsperday.ClientID %>').value = "";
                        document.getElementById('<%=txtemailsperday.ClientID %>').setAttribute('disabled', 'disabled');

                    }
                    else {
                        document.getElementById('<%=txtemailsperday.ClientID %>').removeAttribute('disabled');

                    }
                }
                function CPcheckpostback() {
                    document.getElementById('<%=hdncheckpostback.ClientID %>').value = "1";
                    __doPostBack('<%=rbtnemailsperday.ClientID %>', '')
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
