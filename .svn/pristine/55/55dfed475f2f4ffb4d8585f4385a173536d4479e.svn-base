<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="MobileAppAlerts.aspx.cs"
    Inherits="Business_MyAccount_MobileAppAlerts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/UcPageSize.ascx" TagName="PageSize" TagPrefix="UcPageSize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <%--<link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">
        // -- ***  Uncomment this script and redirect(),ShowImage() function as well when we work on 1243 ***  --
        //        $(document).ready(function () {

        //            $("#ctl00_cphUser_Button1").on('click', function () {
        //            $("#contentDiv").toggleClass('clicked');
        //            });

        //        });
        //        function redirect(mailLink) {

        //            if (document.getElementById('<%=RBNone.ClientID%>').checked) {
        //                var mailtolink = mailLink + document.getElementById('<%= hdnSelectedContactMailID.ClientID%>').value + "&body=" + "";
        //            }
        //            else {
        //                var mailtolink = mailLink + document.getElementById('<%= hdnSelectedContactMailID.ClientID%>').value + "&body=" + $('#ctl00_cphUser_rbCList').find(":checked").val();

        //            }

        //            window.open(mailtolink);
        //            return false;

        //        }
        //        function ShowImage(imagePath) {
        //            //alert(imagePath);
        //            var modal = $find("lblbig");
        //            modal.show();
        //        }

        function show() {

            $("#tableReply").css("display", "none");
            $("#chooseAnAction").css("display", "block");
            return false;
        }
        function Print(id, Flag) {
            var url = 'PrintMessages.aspx?MID=' + id + '&Flag=' + Flag;
            window.open(url, '', "height=650,scrollbars=no,toolbars=yes,status=yes,resizable=yes").focus();
            return false;
        }

        function SelectAllMsgs(headerchk) {
            var grdNewsletercheck = document.getElementById('<%=grdNewsletercontacts.ClientID%>');
            var i;
            if (headerchk.checked) {
                for (i = 0; i < grdNewsletercheck.rows.length; i++) {
                    var inputs = grdNewsletercheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
            }
            else {
                for (i = 0; i < grdNewsletercheck.rows.length; i++) {
                    var inputs = grdNewsletercheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }

        function SelectMsgscheckboxes(header) {
            var count = 0;
            var rowcount = 0;
            var grdTipscheck = document.getElementById('<%= this.grdNewsletercontacts.ClientID %>');
            var headerchk = document.getElementById(header);
            var Inputs = grdTipscheck.getElementsByTagName("input");
            var itemCheckBox = "chkMessages";
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox'
                    && Inputs[n].id.indexOf(itemCheckBox, 0) >= 0) {
                    if (Inputs[n].checked)
                        count++;
                    rowcount++;
                }
            }
            if (count == rowcount) {
                headerchk.checked = true;
            }
            else {
                headerchk.checked = false;
            }

        }

        function SelectAllTips(headerchk) {
            var grdTipscheck = document.getElementById('<%=GrdTips.ClientID%>');
            var i;
            if (headerchk.checked) {
                for (i = 0; i < grdTipscheck.rows.length; i++) {
                    var inputs = grdTipscheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
            }
            else {
                for (i = 0; i < grdTipscheck.rows.length; i++) {
                    var inputs = grdTipscheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        function RedirectailTo() {
            var mailToUser = document.getElementById('<%=hdnSelectedContactMailID.ClientID %>').value;
            var mailTolink = "mailto:" + mailToUser;

            if (!document.getElementById('<%=RBNone.ClientID %>').checked) {
                mailTolink = mailTolink + "?body=" + $('#ctl00_cphUser_rbCList').find(":checked").val();
            }
            window.location.href = mailTolink;
            closeDivPopup();

            return false;
        }
        function SelectTipscheckboxes(header) {
            var count = 0;
            var rowcount = 0;
            var grdTipscheck = document.getElementById('<%= this.GrdTips.ClientID %>');
            var headerchk = document.getElementById(header);
            var Inputs = grdTipscheck.getElementsByTagName("input");
            var itemCheckBox = "chkTips";
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox'
                    && Inputs[n].id.indexOf(itemCheckBox, 0) >= 0) {
                    if (Inputs[n].checked)
                        count++;
                    rowcount++;
                }
            }
            if (count == rowcount) {
                headerchk.checked = true;
            }
            else {
                headerchk.checked = false;
            }

        }

        function SelectallPrivatecheckboxes(header) {
            var count = 0;
            var rowcount = 0;
            var grdPrivateCallcheck = document.getElementById('<%= this.grdPrivateCallHistory.ClientID %>');
            var headerchk = document.getElementById(header);
            var Inputs = grdPrivateCallcheck.getElementsByTagName("input");
            var itemCheckBox = "chkPrivateCalls";
            for (var n = 0; n < Inputs.length; ++n) {
                if (Inputs[n].type == 'checkbox'
                    && Inputs[n].id.indexOf(itemCheckBox, 0) >= 0) {
                    if (Inputs[n].checked)
                        count++;
                    rowcount++;
                }
            }
            if (count == rowcount) {
                headerchk.checked = true;
            }
            else {
                headerchk.checked = false;
            }

        }
        function Confirmationbox(frm, type) {
            var result = false;
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("chkMessages") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
                if (frm.elements[i].name.indexOf("chkTips") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
                if (frm.elements[i].name.indexOf("chkPrivateCalls") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        result = true;
                    }
                }
            }
            var msg = '';
            if (result) {
                msg = 'Are you sure you want to delete selected items?';
                if (type == '2')
                    msg = 'Are you sure you want to block selected senders?';
                return confirm(msg);
            }
            else {
                msg = 'Please select at least one checkbox to delete.';
                if (type == '2')
                    msg = 'Please select at least one checkbox to block senders.';
                alert(msg);
                return false;
            }
        }

        var overlay = $('<div id="overlay"></div>');
        function ShowCannedMessage(contactMailID) {
            /*
            if (document.getElementById("<%=rbCList.ClientID %>") != null)
            document.getElementById("<%=lblErrorMessage1.ClientID %>").innerHTML = "";

            if (document.getElementById("<%=rbCList.ClientID %>") != null)
            document.getElementById("<%=rbCList.ClientID %>").selectedIndex = -1;
            */

            // var x = event.clientX;
            //var y = event.clientY;
            $("#divCannedMessage").css("display", "block")

            overlay.show();
            overlay.appendTo(document.body);
            if (document.getElementById("<%=hdnSelectedContactMailID.ClientID %>") != null)
                document.getElementById("<%=hdnSelectedContactMailID.ClientID %>").value = contactMailID;

            document.getElementById("<%=RBNone.ClientID %>").checked = true;
            $('#<%=rbCList.ClientID%> input').attr('checked', false);
        }

        function ValidateMessages() {

            /*
            var sel = document.getElementById("<%=rbCList.ClientID %>");
            if (document.getElementById("<%=RBNone.ClientID %>").checked == false && sel.selectedIndex == -1) {

            document.getElementById("<%=lblErrorMessage1.ClientID %>").innerHTML = "Please select a canned message.";
            setTimeout(function () {
            if (document.getElementById("<%=lblErrorMessage1.ClientID %>") != null) {
            document.getElementById("<%=lblErrorMessage1.ClientID %>").innerHTML = "";
            }
            }, 3 * 1000);

            return false;
            }
            else {

            closeDivPopup();
            return true;
            }
            */

            closeDivPopup();
            return true;
        }

        function closeDivPopup() {

            $("#divCannedMessage").css("display", "none");
            overlay.appendTo(document.body).remove();

        } // END function


        //          window.onload = function () {
        //            $("#<%=rbCList.ClientID%> input").change(function () {
        //                
        //                document.getElementById("<%=RBNone.ClientID %>").checked = false;
        //            });
        //            $("#<%=RBNone.ClientID%>").change(function () {
        //               
        //                $('#<%=rbCList.ClientID%> input').attr('checked', false);

        //            });
        //          }


        function changeRadio() {
            $('#<%=rbCList.ClientID%> input').attr('checked', false);
        }

        function changeRadioList() {
            document.getElementById("<%=RBNone.ClientID %>").checked = false;
        }


        /*    ---------- public call history  -------   */


        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            Show_Hide_ReplyButton();
        });

        window.onload = (function () {
            //Show_Hide_ReplyButton();
        });

        function Show_Hide_ReplyButton() {
            var ele1 = $("#<%=grdPrivateCallHistory.ClientID %> .replyclass");
            //alert(ele.length);
            for (i = 0; i < ele1.length; i++) {

                var emailID = $("#" + ele1[i].id).text();
                if (emailID == "") {
                    $("#" + ele1[i].id).css("display", "none");
                }
                else {
                    var imgControl = "<img id=\"imgReply\"  style=\"cursor:pointer;\" src=\"../../Images/Dashboard/reply.png\" onclick=\"ShowCannedMessage('" + emailID + "')\" />";
                    //$("#" + ele[i].id).text(imgControl);
                    //alert(imgControl);
                    document.getElementById(ele1[i].id).innerHTML = imgControl;
                }
            }
        }


    </script>
    <style type="text/css">
        .btn
        {
            background: #3498db;
            background-image: -webkit-linear-gradient(top, #3498db, #2980b9);
            background-image: -moz-linear-gradient(top, #3498db, #2980b9);
            background-image: -ms-linear-gradient(top, #3498db, #2980b9);
            background-image: -o-linear-gradient(top, #3498db, #2980b9);
            background-image: linear-gradient(to bottom, #3498db, #2980b9);
            -webkit-border-radius: 20;
            -moz-border-radius: 20;
            border-radius: 20px;
            font-family: Arial;
            color: #ffffff;
            font-size: 15px;
            padding: 10px 20px 10px 20px;
            text-decoration: none;
        }
        
        .btn:hover
        {
            background: #3cb0fd;
            background-image: -webkit-linear-gradient(top, #3cb0fd, #3498db);
            background-image: -moz-linear-gradient(top, #3cb0fd, #3498db);
            background-image: -ms-linear-gradient(top, #3cb0fd, #3498db);
            background-image: -o-linear-gradient(top, #3cb0fd, #3498db);
            background-image: linear-gradient(to bottom, #3cb0fd, #3498db);
            text-decoration: none;
        }
        .clicked
        {
            width: 300px !important;
        }
        .UnreadInquiry
        {
            background-color: #d2e5fa;
            font-weight: bold;
        }
        .readInquiry
        {
            background-color: #FFFFFF;
        }
        .tabs
        {
            border: 2px solid Orange;
            width: 98%;
        }
        .buttonsOverLine
        {
            background: #3b86d4;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            padding: 6px 6px 6px 6px;
            text-decoration: none;
            margin: 0px 0px -6px 0px;
            border-color: transparent;
            cursor: pointer;
            width: 150px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
        }
        .ActiveButton
        {
            background: #0d4884;
            font-family: Arial;
            font-weight: bold;
            color: #ffffff;
            font-size: 16px;
            padding: 6px 6px 6px 6px;
            text-decoration: none;
            margin: 0px 0px -6px 0px;
            cursor: pointer;
            border-color: transparent;
            width: 150px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
        }
        /**** Tool Tip Decoration ****/.couponcode
        {
            /*width: 50px;*/
        }
        .couponcode:hover .coupontooltip
        {
            display: block;
        }
        .coupontooltip
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            border: 1px dashed #297CCF;
            position: absolute;
            padding: 6px;
            z-index: 1000;
            width: 300px;
            height: auto;
            color: Black;
            text-align: left;
        }
    </style>
    <style type="text/css">
        #overlay
        {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #000;
            filter: alpha(opacity=70);
            -moz-opacity: 0.7;
            -khtml-opacity: 0.7;
            opacity: 0.7;
            z-index: 100;
        }
        .content a
        {
            text-decoration: none;
        }
        .popup
        {
            width: 100%;
            margin: 0 auto;
            position: fixed;
            z-index: 101;
        }
        .content
        {
            min-width: 300px;
            width: 600px;
            min-height: 130px;
            margin-left: 150px;
            background: #f3f3f3;
            position: relative;
            z-index: 103;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 0 2px 5px #000;
        }
        .content p
        {
            clear: both;
            color: #555555;
            text-align: justify;
        }
        .content p a
        {
            color: #d91900;
            font-weight: bold;
        }
        .content .x
        {
            float: right;
            left: 22px;
            position: relative;
            top: -25px;
        }
        .content .x:hover
        {
            cursor: pointer;
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
            padding: 9px 20px;
            color: #fff !important;
            text-decoration: none !important;
            font-weight: normal;
        }
        
        .btnorange:hover
        {
            background: #3cb0fd;
            text-decoration: none;
        }
        .img
        {
            padding-bottom: 10px;
            padding-left: 30px;
        }
        .showingMsgButton
        {
            color: #c7212b;
            font-weight: bold;
            padding-left: 8px;
            font-size: 18px;
        }
        .paginationClass span
        {
            font-weight: bold;
            font-size: 14px;
            color: White;
            border: 1px solid #f15a29;
            padding: 0px 5px;
            background-color: #FFCC00;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnSelectedContactMailID" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hdnShowingContact" runat="server" Value="0" />
            <asp:HiddenField ID="hdnShowingTips" runat="server" Value="0" />
            <asp:HiddenField ID="hdnShowingPrivateMsg" runat="server" Value="0" />
            <asp:HiddenField ID="hdnMessagesCount" runat="server" Value="0" />
            <asp:HiddenField ID="hdnPageSize_Messages" runat="server" Value="5" />
            <asp:HiddenField ID="hdnPageSize_Tips" runat="server" Value="5" />
            <asp:HiddenField ID="hdnPageSize_PrivateCalls" runat="server" Value="5" />
            <asp:HiddenField ID="hdnPageIndex_Contact" runat="server" Value="0" />
            <asp:HiddenField ID="hdnPageIndex_Tips" runat="server" Value="0" />
            <asp:HiddenField ID="hdnPageIndex_PrivateCalls" runat="server" Value="0" />
            <div id="divCannedMessage" style="display: none;">
                <div class='popup'>
                    <div id="contentDiv" class='content'>
                        <img src='../../images/x.png' alt='quit' class='x' id='x' onclick="closeDivPopup();" />
                        <br />
                        <table id="tableReply" width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="page-title">
                                        Reply To App Messages
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Enter a custom message or select a canned message.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMessage1" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="border: 1px solid #DFE7F6; height: 200px; overflow-y: scroll; overflow-x: hidden;
                                        width: 600px; margin-top: 5px; margin-left: 5px;">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-left: 3px;">
                                                    <asp:RadioButton ID="RBNone" runat="server" Text="Enter your message" GroupName="rbCM"
                                                        Checked="true" onchange="changeRadio()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 7px; padding-bottom: 3px;">
                                                    <b>Canned Messages</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList runat="server" ID="rbCList" GroupName="rbCM" onchange="changeRadioList()">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="Button1" runat="server" Text="Reply" OnClick="btnReply_OnClick" OnClientClick="return RedirectailTo();" /><!--OnClientClick="return show();" -->
                                </td>
                            </tr>
                        </table>
                        <table id="chooseAnAction" width="50%" border="0" cellpadding="0" cellspacing="0"
                            style="display: none; padding-right: 25px">
                            <tr>
                                <td>
                                    <div class="page-title">
                                        Choose an Action
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnGmail" runat="server" OnClientClick="return redirect('https://mail.google.com/mail/?view=cm&fs=1&to=');"><img src="../../Images/Gmail.png"   class="img"/></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnYahoo" runat="server" OnClientClick="return redirect('http://compose.mail.yahoo.com/?to=');"><img src="../../Images/Yahoomail.png" class="img" /></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnAOL" runat="server" OnClientClick="return redirect('http://mail.aol.com/mail/compose-message.aspx?to=');"><img class="img"
                                         src="../../Images/AOL.png"  /></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkbtnHotMail" runat="server" OnClientClick="return redirect('https://mail.live.com/default.aspx?rru=compose&to=');"><img class="img" src="../../Images/HotMail.png" /></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="update2" runat="server">
                <ContentTemplate>
                    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                        <tr>
                            <td class="valign-top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p style="font-size: 18px; margin-left: 10px; margin-bottom: 5px;">
                                                App Messages
                                            </p>
                                            <span style="margin-left: 0px; display: none;">
                                                <asp:Button ID="btnMsgs" Text="App Messages" runat="server" CssClass="ActiveButton"
                                                    OnClick="btnMsgs_Click" />
                                                <%if (Convert.ToBoolean(Session["IsLiteVersion"]) == false)
                                                  {%>
                                                <asp:Button ID="btnInquiries" Text="Email Messages" runat="server" CssClass="buttonsOverLine"
                                                    OnClick="btnInquiries_Click" />
                                                <%} %>
                                            </span>
                                        </td>
                                        <td style="padding-right: 70px;">
                                            <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton runat="server" ID="lnkCannedMessage" Style="display: none;" Text="Canned Messages"
                                                CssClass="btnorange" OnClick="lnkCannedMessage_OnClick"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="inputtable">
                                    <tr>
                                        <td valign="top">
                                            <table border="0" cellpadding="10" cellspacing="0" width="100%">
                                                <colgroup>
                                                    <col width="100px" />
                                                    <col width="100px" />
                                                    <col width="*" />
                                                </colgroup>
                                                <tr>
                                                    <td>
                                                        <div style="height: 27px; background-color: #d2e5fa; width: 27px; float: left;">
                                                        </div>
                                                        &nbsp;
                                                        <div style="float: left; margin-top: 5px;">
                                                            &nbsp; Unread</div>
                                                    </td>
                                                    <td>
                                                        <div style="height: 25px; background-color: #FFFFFF; width: 27px; border: 1px solid;
                                                            float: left;">
                                                        </div>
                                                        &nbsp;
                                                        <div style="float: left; margin-top: 5px;">
                                                            &nbsp; Read</div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%if (isHavingContactButton == true && IsShowContactusGrid == true && Convert.ToInt32(hdnMessagesCount.Value.Split('|')[0]) > 0)
                                      {%>
                                    <tr>
                                        <td>
                                            <p class="showingMsgButton">
                                                <asp:Label ID="lblContactUs" runat="server"></asp:Label>
                                                - Messages</p>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnkCurrentForContacts" runat="server" OnClick="lnkCurrent_Click"
                                                            CausesValidation="false" Text="<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>"></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkArchiveForContacts" runat="server" CausesValidation="false"
                                                            OnClick="lnkGetArchive_Click" Text="<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>"></asp:LinkButton>
                                                        <div style="float: right; margin-right: 3px;">
                                                            Page Size
                                                            <UcPageSize:PageSize ID="PageSizes_Messages" runat="server" />
                                                        </div>
                                                        <asp:GridView ID="grdNewsletercontacts" runat="server" DataKeyNames="Message_ID"
                                                            AllowSorting="true" AutoGenerateColumns="False" AllowPaging="true" Width="100%"
                                                            OnPageIndexChanging="grdNewsletercontacts_PageIndexChanging" OnRowDataBound="grdNewsletercontacts_RowDataBound"
                                                            CssClass="datagrid2" OnSorting="grdNewsletercontacts_Sorting" PageSize="4">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="chkSelectAllMsgs" runat="server" Text="Select All" onclick="SelectAllMsgs(this);"
                                                                            OnCheckedChanged="ChkSelectAllMsgsCheckedChanged" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkMessages" runat="server" OnCheckedChanged="ChkMessagesCheckedChanged" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="12%" />
                                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" Width="12%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reference Id" SortExpression="ReferenceID">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkcontactname" runat="server" Text='<%# "CS" +Eval("ReferenceID").ToString() %>'
                                                                            ToolTip="View message details" CommandArgument='<%# Eval("Message_ID") %>' OnClick="lnkcontactname_Click"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="9%" />
                                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="10%" />
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderText="Subject">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkcontactname" runat="server" Text='<%#Eval("Subject") %>' ToolTip="View message details"
                                                                            CommandArgument='<%# Eval("Message_ID") %>' OnClick="lnkcontactname_Click"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="12%"/>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Message">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("Message") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="30%" />
                                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" Width="12%" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Device_Blocked" HeaderText="Device Blocked" ItemStyle-Width="15%" />
                                                                <asp:BoundField DataField="CREATED_DT" HeaderText="Date &amp; Time Sent" SortExpression="DateSent"
                                                                    DataFormatString="{0:MM/dd/yyyy hh:mm tt}" ItemStyle-Width="20%" />
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblchecked" runat="server" Text='<%#Eval("User_Read_Flag") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkECdelete" runat="server" CommandArgument='<%# Eval("Message_ID") %>'
                                                                            OnClick="lnkdelete_Click" Text="<img src='../../Images/Dashboard/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"
                                                                            CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this message?');"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Print">
                                                                    <ItemTemplate>
                                                                        <img id="lnkprint" onclick='<%# string.Format("javascript:Print(\"{0}\",\"{1}\")", Eval("Message_ID"),"M") %>'
                                                                            src='../../Images/Dashboard/printer.png' width='20px' height='20px' title='Print'
                                                                            border='0' style="cursor: pointer;"></img>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Archive">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkArchive" runat="server" CommandArgument='<%# Eval("Message_ID") %>'
                                                                            ToolTip="Archive" OnClientClick="return confirm('Are you sure you want to move message to Archive?');"
                                                                            OnClick="lnkArchiveContacts_Click" Text="" CausesValidation="false">
                                                                    <img alt="Archive" src="../../Images/Dashboard/archive.png" width='25px' height='25px' />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reply">
                                                                    <ItemTemplate>
                                                                        <%--<asp:Label ID="lblReply" runat="server"></asp:Label>--%>
                                                                        <asp:LinkButton ID="lnkReply" runat="server" Text='' ToolTip="Reply" CommandArgument='<%# Eval("Message_ID") %>'
                                                                            OnClick="lnkcontactname_Click">
                                                                            <img alt="reply" src="../../Images/Dashboard/reply.png"/>
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Font-Size="12px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Current" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkArchiveToCurrent" runat="server" CommandArgument='<%# Eval("Message_ID") %>'
                                                                            ToolTip="Current" OnClientClick="return confirm('Are you sure you want to move message to Current?');"
                                                                            OnClick="lnkContactArchiveToCurrent_Click" Text="" CausesValidation="false">
                                                                    <img alt="Archive" src="../../Images/Dashboard/archive.png" width='25px' height='25px' />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <asp:Label ID="lblBUempty" runat="server" Text="There are no mobile app messages at this time."
                                                                    Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="title1" />
                                                            <PagerStyle CssClass="paginationClass" />
                                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First"
                                                                LastPageText="Last" />
                                                        </asp:GridView>
                                                        <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                        <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <%if (isHavingTipsButton == true && IsShowTipsGrid == true && Convert.ToInt32(hdnMessagesCount.Value.Split('|')[1]) > 0)
                                      { %>
                                    <tr>
                                        <td>
                                            <br />
                                            <p class="showingMsgButton">
                                                <asp:Label ID="lblTipsTitle" runat="server" Text=""></asp:Label>
                                                - Messages</p>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnkCurrentForTips" runat="server" OnClick="lnkCurrentForTips_Click"
                                                            CausesValidation="false" Text="<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>"></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkArchiveForTips" runat="server" CausesValidation="false" OnClick="lnkArchiveForTips_Click"
                                                            Text="<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>"></asp:LinkButton>
                                                        <div style="float: right; margin-right: 3px;">
                                                            Page Size
                                                            <UcPageSize:PageSize ID="PageSize_Tips" runat="server" />
                                                        </div>
                                                        <asp:GridView ID="GrdTips" runat="server" DataKeyNames="Message_ID" AllowSorting="true"
                                                            AutoGenerateColumns="False" AllowPaging="true" Width="100%" OnPageIndexChanging="GrdTips_PageIndexChanging"
                                                            OnRowDataBound="GrdTips_RowDataBound" CssClass="datagrid2" OnSorting="GrdTips_Sorting"
                                                            PageSize="4">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="chkSelectAllTips" runat="server" Text="Select All" onclick="SelectAllTips(this);"
                                                                            OnCheckedChanged="ChkSelectAllTipsCheckedChanged" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkTips" runat="server" OnCheckedChanged="ChkTipsCheckedChanged" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="12%" />
                                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" Width="12%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reference Id" SortExpression="ReferenceID">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnktips" runat="server" Text='<%# "TS" +Eval("ReferenceID").ToString() %>'
                                                                            ToolTip="View tip details" CommandArgument='<%# Eval("Message_ID") %>' OnClick="lnktips_Click"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="9%" />
                                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="10%" />
                                                                </asp:TemplateField>
                                                                <%-- <asp:TemplateField HeaderText="Subject">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnktips" runat="server" Text='<%#Eval("Subject") %>' ToolTip="View tip details"
                                                                            CommandArgument='<%# Eval("Message_ID") %>' OnClick="lnktips_Click"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="20%" />
                                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="10%"/>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Message">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("Message") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="30%" />
                                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Device_Blocked" HeaderText="Device Blocked" ItemStyle-Width="15%" />
                                                                <asp:BoundField DataField="CREATED_DT" HeaderText="Date &amp; Time Sent" SortExpression="DateSent"
                                                                    DataFormatString="{0:MM/dd/yyyy hh:mm tt}" ItemStyle-Width="18%" />
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblchecked" runat="server" Text='<%#Eval("User_Read_Flag") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkTipdelete" runat="server" CommandArgument='<%# Eval("Message_ID") %>'
                                                                            OnClick="lnkTipdelete_Click" Text="<img src='../../Images/Dashboard/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"
                                                                            CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this tip?');"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Print">
                                                                    <ItemTemplate>
                                                                        <img id="lnktipprint" onclick='<%# string.Format("javascript:Print(\"{0}\",\"{1}\")", Eval("Message_ID"),"T") %>'
                                                                            src='../../Images/Dashboard/printer.png' width='20px' height='20px' title='Print'
                                                                            border='0' style="cursor: pointer;"></img>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Archive">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkTipsArchive" runat="server" CommandArgument='<%# Eval("Message_ID") %>'
                                                                            ToolTip="Archive" OnClientClick="return confirm('Are you sure you want to move message to Archive?');"
                                                                            OnClick="lnkTipsArchive_Click" Text="" CausesValidation="false">
                                                                    <img alt="Archive" src="../../Images/Dashboard/archive.png" width='25px' height='25px' />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reply">
                                                                    <ItemTemplate>
                                                                        <%--<asp:Label ID="lblReply" runat="server" Text=""></asp:Label>--%>
                                                                        <asp:LinkButton ID="lnkReply" runat="server" ToolTip="Reply" CommandArgument='<%# Eval("Message_ID") %>'
                                                                            OnClick="lnktips_Click">
                                                                            <img alt="reply" src="../../Images/Dashboard/reply.png"/>
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Font-Size="12px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Current" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkArchiveToCurrentTips" runat="server" CommandArgument='<%# Eval("Message_ID") %>'
                                                                            ToolTip="Current" OnClientClick="return confirm('Are you sure you want to move message to Current?');"
                                                                            OnClick="lnkContactArchiveToCurrentTips_Click" Text="" CausesValidation="false">
                                                                    <img alt="Archive" src="../../Images/Dashboard/archive.png" width='25px' height='25px' />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <asp:Label ID="lblBUempty" runat="server" Text="There are no mobile app tips at this time."
                                                                    Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="title1" />
                                                            <PagerStyle CssClass="paginationClass" />
                                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First"
                                                                LastPageText="Last" />
                                                        </asp:GridView>
                                                    </td>
                                                    <asp:HiddenField ID="hdnsortcnt" runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnsortdir" runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnPermissionType" runat="server" Value="1"></asp:HiddenField>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <%if (isHavingPrivateCallButton == true && IsShowPrivateCallsGrid == true && Convert.ToInt32(hdnMessagesCount.Value.Split('|')[2]) > 0)
                                      { %>
                                    <tr>
                                        <td>
                                            <br />
                                            <p class="showingMsgButton">
                                                <asp:Label ID="lblPrivateCallButtonTitle" runat="server" Text="Private call"></asp:Label>
                                                - Messages</p>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="datagrid nomargin-bottom">
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnkCurrentForPrivateMsg" runat="server" OnClick="lnkCurrentForPrivateMsg_Click"
                                                            CausesValidation="false" Text="<img src='../../Images/Dashboard/current_h.gif' title='Current' border='0'/>"></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkArchiveForPrivateMsg" runat="server" CausesValidation="false"
                                                            OnClick="lnkArchiveForPrivateMsg_Click" Text="<img src='../../Images/Dashboard/archive_h.gif' title='Archive' border='0'/>"></asp:LinkButton>
                                                        <div style="float: right; margin-right: 3px;">
                                                            Page Size
                                                            <UcPageSize:PageSize ID="PageSize_PrivateCall" runat="server" />
                                                        </div>
                                                        <asp:GridView ID="grdPrivateCallHistory" runat="server" DataKeyNames="CallAddOnsHistoryID"
                                                            AllowSorting="true" AutoGenerateColumns="False" AllowPaging="true" Width="100%"
                                                            OnPageIndexChanging="grdPrivateCallHistory_PageIndexChanging" OnRowDataBound="grdPrivateCallHistory_RowDataBound"
                                                            OnSorting="grdPrivateCallHistory_Sorting" CssClass="datagrid2" PageSize="4">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="chkSelectAllPrivateCalls" runat="server" Text="Select All" onclick="SelectAllPrivateCalls(this);" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkPrivateCalls" runat="server" OnCheckedChanged="chkPrivateCallsCheckedChanged" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="10%" />
                                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" Width="12%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reference Id" SortExpression="ReferenceID">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnk" runat="server" Text='<%# "PC" +Eval("ReferenceID").ToString() %>'
                                                                            ToolTip="View Call details" CommandArgument='<%# Eval("CallAddOnsHistoryID") %>'
                                                                            OnClick="lnkPrivateCall_Click"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="9%" />
                                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="TabName" HeaderText="Tab Name" ItemStyle-Width="12%" />
                                                                <asp:TemplateField HeaderText="Message">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPCallMessage" runat="server" Text='<%#Eval("CustomPredefinedMessage") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="20%" />
                                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="12px" Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Button Title">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" Width="15%" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="IsBlocked" HeaderText="Device Blocked" Visible="false"
                                                                    ItemStyle-Width="15%" />
                                                                <asp:BoundField DataField="CreatedDate" HeaderText="Date &amp; Time Sent" SortExpression="DateSent"
                                                                    DataFormatString="{0:MM/dd/yyyy hh:mm tt}" ItemStyle-Width="40%" />
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblprivatecallflag" runat="server" Text='<%#Eval("isRead") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkPrivateCallDelete" runat="server" CommandArgument='<%# Eval("CallAddOnsHistoryID") %>'
                                                                            Text="<img src='../../Images/Dashboard/icon_delete.gif'width='25px' height='25px' title='Delete' border='0'"
                                                                            CausesValidation="false" OnClick="lnkPrivateCalldelete_Click" OnClientClick="return confirm('Are you sure you want to delete this call?');"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" Width="44%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Print">
                                                                    <ItemTemplate>
                                                                        <img id="lnkPrivateCallprint" onclick='<%# string.Format("javascript:Print(\"{0}\",\"{1}\")", Eval("CallAddOnsHistoryID"),"PrivateCall") %>'
                                                                            src='../../Images/Dashboard/printer.png' width='20px' height='20px' title='Print'
                                                                            border='0' style="cursor: pointer;"></img>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" Width="44%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Archive">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkArchivePrivate" runat="server" CommandArgument='<%# Eval("CallAddOnsHistoryID") %>'
                                                                            ToolTip="Archive" OnClientClick="return confirm('Are you sure you want to move message to Archive?');"
                                                                            OnClick="lnkArchivePrivat_Click" Text="" CausesValidation="false">
                                                                    <img alt="Archive" src="../../Images/Dashboard/archive.png" width='25px' height='25px' />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" Width="44%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Reply">
                                                                    <ItemTemplate>
                                                                        <%--<asp:Label ID="lblReply1" CssClass="replyclass" runat="server" Text='<%# Eval("ContactEmail") %>' />
                                                                        <asp:Label ID="lblReply" runat="server" Text="" Style="display: none;"></asp:Label>--%>
                                                                        <asp:LinkButton ID="lnkReply" runat="server" ToolTip="Reply" CommandArgument='<%# Eval("CallAddOnsHistoryID") %>'
                                                                            OnClick="lnkPrivateCall_Click">
                                                                            <img alt="reply" src="../../Images/Dashboard/reply.png"/>
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Font-Size="12px" Width="44%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Current" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkArchiveToCurrentPrivate" runat="server" CommandArgument='<%# Eval("CallAddOnsHistoryID") %>'
                                                                            ToolTip="Current" OnClientClick="return confirm('Are you sure you want to move message to Current?');"
                                                                            OnClick="lnkArchiveToCurrentPrivate_Click" Text="" CausesValidation="false">
                                                                    <img alt="current" src="../../Images/Dashboard/archive.png" width='25px' height='25px' />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Font-Size="12px" Width="15%" />
                                                                    <HeaderStyle Font-Size="12px" Width="44%" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <asp:Label ID="lblBUempty" runat="server" Text="There are no calls at this time."
                                                                    Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="title1" />
                                                            <PagerStyle CssClass="paginationClass" />
                                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First"
                                                                LastPageText="Last" />
                                                        </asp:GridView>
                                                    </td>
                                                    <asp:HiddenField ID="hdnPrivateCallSortCount" runat="server"></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnPrivateCallSortDir" runat="server"></asp:HiddenField>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <%if (hdnMessagesCount.Value == "0|0|0")
                                      {%>
                                    <tr>
                                        <td align="center" style="height: 50px; font-size: 13px; color: red;">
                                            <%--There are no app messages at this time.--%>
                                            There are no App Messages at this time.
                                        </td>
                                    </tr>
                                    <%}
                                      else
                                      { %>
                                    <tr>
                                        <td>
                                            <table border="0" width="100%" cellpadding="0" cellspacing="0" id="tblDeleteBlockBtns">
                                                <tr>
                                                    <td style="padding-left: 5px;">
                                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                                    </td>
                                                    <td align="right" style="padding-right: 5px;">
                                                        <%if (hdnPermissionType.Value != "")
                                                          { %>
                                                        <span class="couponcode" style="display: none;">
                                                            <img border="0" src="../../images/Dashboard/new.png" />
                                                            <span class="coupontooltip" style="margin: -132px 10px 0px 174px;">If you receive prank
                                                                or abusive messages you have the ability to block the messages sent from that particular
                                                                device. Blocked users will still be able to use your App but are unable to send
                                                                messages.</span> </span>
                                                        <asp:Button ID="btnBlockUsers" Style="display: none;" runat="server" Text="Block Sender"
                                                            OnClick="btnBlockUsers_Click" Visible="false" />
                                                        <%} %>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%} %>
                                    <tr>
                                        <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                            <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Back" OnClick="btnBack_Click"
                                                CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modal"
                                                    TargetControlID="lbl" CancelControlID="imclose" PopupControlID="pnlpopup">
                                                </cc1:ModalPopupExtender>
                                                <asp:Panel Style="display: none" ID="pnlpopup" runat="server">
                                                    <table style="width: 600px; text-align: left;" class="popuptable" cellspacing="0"
                                                        cellpadding="0" border="0" align="center">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <table cellspacing="3" cellpadding="1" width="100%" border="0">
                                                                        <colgroup>
                                                                            <col width="135" />
                                                                            <col width="*" />
                                                                        </colgroup>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="header" align="left" colspan="2">
                                                                                    <asp:Label ID="lblheader" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td align="right">
                                                                                    <asp:ImageButton ID="imclose" OnClick="btnclose_Click" runat="server" ImageUrl="~/images/popup_close.gif">
                                                                                    </asp:ImageButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    User Name:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblfn" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    Contact Email:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblemail" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px" nowrap>
                                                                                    Phone Number:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblphone" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px; vertical-align: top">
                                                                                    <asp:Label ID="lblmess" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lbldescription" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px; vertical-align: top">
                                                                                    Location:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Button runat="server" ID="btnCopyImg" Text="Copy to Image Gallery" OnClientClick="return ShowImageGallary();" />
                                                                                    <asp:HiddenField runat="server" ID="hdnImgName" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" align="center">
                                                                                    <asp:Label ID="lblImg" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="modal"
                                                    TargetControlID="lblPublic" CancelControlID="ImageButtonclose" PopupControlID="pnlPublicCall">
                                                </cc1:ModalPopupExtender>
                                                <asp:Panel Style="display: none" ID="pnlPublicCall" runat="server">
                                                    <table style="width: 600px; text-align: left;" class="popuptable" cellspacing="0"
                                                        cellpadding="0" border="0" align="center">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <table cellspacing="3" cellpadding="1" width="100%" border="0">
                                                                        <colgroup>
                                                                            <col width="135" />
                                                                            <col width="*" />
                                                                        </colgroup>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="header" nowrap align="left" colspan="2">
                                                                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td align="right">
                                                                                    <asp:ImageButton ID="ImageButtonclose" OnClick="btnclosepopup_Click" runat="server"
                                                                                        ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    Contact Name:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblContactName" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    Contact Email:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblContactEmail" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    Phone Number:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblPhoneNum" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    Custom message:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblCustomMsg" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    <asp:Label ID="lbllocationtext" runat="server" Text="Location:"></asp:Label>
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblPublicCallLocation" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trPublicImg" runat="server">
                                                                                <td style="font-size: 14px">
                                                                                    <asp:Label ID="lblimagetext" runat="server" Text="Image:"></asp:Label>
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="imgPublicImage" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px; vertical-align: top">
                                                                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:Button runat="server" ID="btncopyImgtogalry" Text="Copy to Image Gallery" OnClientClick="return ShowImageGallary1();" />
                                                                                    <asp:HiddenField runat="server" ID="HiddenField1" />
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Label ID="lbl" runat="server"></asp:Label>
                                                <asp:Label ID="lblPublic" runat="server"></asp:Label>
                                                <cc1:ModalPopupExtender ID="ModalPopupExtender4" runat="server" BackgroundCssClass="modal"
                                                    TargetControlID="lblprivatecall" CancelControlID="ImageButtonclose" PopupControlID="pnlPrivateCall">
                                                </cc1:ModalPopupExtender>
                                                <asp:Panel Style="display: none" ID="pnlPrivateCall" runat="server">
                                                    <table style="width: 600px; text-align: left;" class="popuptable" cellspacing="0"
                                                        cellpadding="0" border="0" align="center">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <table cellspacing="3" cellpadding="1" width="100%" border="0">
                                                                        <colgroup>
                                                                            <col width="135" />
                                                                            <col width="*" />
                                                                        </colgroup>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="header" nowrap align="left" colspan="2">
                                                                                    <asp:Label ID="lblPrivatetitle" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td align="right">
                                                                                    <asp:ImageButton ID="ImgButtonclose" OnClick="btnclosepopup_Click" runat="server"
                                                                                        ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    Contact Name:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblPrivateName" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    Contact Email:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblPrivateEmail" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    Phone Number:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblPrivateNumber" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    Custom message:
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblprivateCallMsg" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 14px">
                                                                                    <asp:Label ID="lblPrivatelocationtext" runat="server" Text="Location:"></asp:Label>
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="lblPrivatelocation" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trPrivateImg" runat="server">
                                                                                <td style="font-size: 14px">
                                                                                    <asp:Label ID="lblPrivateimagetext" runat="server" Text="Image:"></asp:Label>
                                                                                </td>
                                                                                <td style="padding-left: 10px; font-size: 14px; color: #2b60de;">
                                                                                    <asp:Label ID="imgPrivateImage" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <%--<tr>
                                                                        <td colspan="2">
                                                                            <asp:Button runat="server" ID="Button2" Text="Copy to Image Gallery" OnClientClick="return ShowImageGallary1();" />
                                                                            <asp:HiddenField runat="server" ID="HiddenField2" />
                                                                        </td>
                                                                    </tr>--%>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Label ID="Label14" runat="server"></asp:Label>
                                                <asp:Label ID="lblprivatecall" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <td>
                        <asp:Label ID="lblviewc" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" BackgroundCssClass="modal"
                            PopupControlID="pnlviewcouponsenthis" TargetControlID="lblviewc" BehaviorID="lblbig"
                            CancelControlID="imgclose">
                        </cc1:ModalPopupExtender>
                        <asp:Panel Style="display: none" ID="pnlviewcouponsenthis" runat="server" Width="100%">
                            <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:ImageButton ID="imgclose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                CausesValidation="false"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div style="overflow-y: auto; height: 500px;">
                                                                <img id="imgbig" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div class="page-title">
                App Messages
            </div>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function AlertBlock() {
            return confirm('Are you sure you want to block the selected senders?');
        }
        function ShowImageGallary() {
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            ifrm.setAttribute("src", "ImageGallery.aspx?TipsimgName=" + document.getElementById("<%=hdnImgName.ClientID %>").value);
            ifrm.style.height = "650px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('DIDIFrm').appendChild(ifrm);

            var modalDialog = $find("popupimage");
            modalDialog.show();

            return false;
        }
        function ShowImageGallary1() {
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            ifrm.setAttribute("src", "ImageGallery.aspx?SmartConnectimgName=" + document.getElementById("<%=hdnImgName.ClientID %>").value);
            ifrm.style.height = "650px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('DIDIFrm').appendChild(ifrm);

            var modalDialog = $find("popupimage");
            modalDialog.show();

            return false;
        }

        /*--private call history--*/
        function SelectAllPrivateCalls(headerchk) {
            var grdPrivateCalls = document.getElementById('<%=grdPrivateCallHistory.ClientID%>');
            var i;
            if (headerchk.checked) {
                for (i = 0; i < grdPrivateCalls.rows.length; i++) {
                    var inputs = grdPrivateCalls.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
            }
            else {
                for (i = 0; i < grdPrivateCalls.rows.length; i++) {
                    var inputs = grdPrivateCalls.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }



        }
    </script>
</asp:Content>
