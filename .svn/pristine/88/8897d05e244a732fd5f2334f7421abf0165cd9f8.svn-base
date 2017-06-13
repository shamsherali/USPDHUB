<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="AppUsageReport.aspx.cs" Inherits="USPDHUB.Business.MyAccount.AppUsageReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../../Scripts/jsapi.js" language="javascript"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="webmangement_wrapper">
                <div id="webmangement_leftcol">
                    <div class="webmangement_leftcol_heading">
                        Mobile App Management
                        <asp:HiddenField ID="hdnPreviousDivID" runat="server" />
                    </div>
                    <div class="webmangement_rightcol_rowbg">
                        <div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/gen-app-settings.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/AppManagement.aspx")%>">General
                                App Settings</a></span></div>
                        <%if (IsSuperAdmin)
                          { %>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divManageLogins">
                            <img src="../../images/dashboard/manage-logins.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageAssociates.aspx")%>">Manage
                                Logins</a></span></div>
                        <%}
                          else
                          { %>
                        <div class="webmangement_rightcol_rowbg_heading14" id="div2">
                            <img src="../../images/dashboard/manage-logins.png" /><span><a href="#" onclick="ShowAssociateMSG();">Manage
                                Logins</a></span></div>
                        <%} %>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divManageWebLinks">
                            <img src="../../images/dashboard/web-links.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageWebLinks.aspx")%>">Web
                                Links</a></span></div>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divSocialMedia">
                            <img src="../../images/dashboard/Social-media.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/SocialMedia.aspx")%>">Social
                                Media</a></span>
                        </div>
                        <%--<div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/download_n.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/DownloadInstallers.aspx")%>">
                                Downloads</a></span></div>--%>
                        <div class="webmangement_rightcol_rowbg_heading13">
                            <img src="../../images/dashboard/appdownloads_h.png" /><span><a href="javascript:void(0);">App
                                Usage Report</a></span></div>
                        <%if (IsParent && IsBranded)
                          { %>
                        <div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/invitations.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/SendInvitation.aspx")%>">Setup
                                Affiliate Apps</a></span></div>
                        <%} %>
                        <%if (IsBlockedSendAccess)
                          {%>
                        <div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/blocksenders.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageBlockedSenders.aspx")%>">Manage
                                Blocked Senders</a></span></div>
                        <%}
                          else
                          {
                        %>
                        <div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/blocksenders.png" /><span> <a href="#" onclick="ShowAssociateMSG();">
                                Manage Blocked Senders</a> </span>
                        </div>
                        <%}%>
                        <div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/resource.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/WebWidget.aspx")%>">
                                Resources</a></span></div>
                    </div>
                </div>
                <div id="webmangement_rightcol">
                    <div id="divAppUsagePage">
                        <div class="webmangement_rightcol_heading">
                            App Usage Report</div>
                        <div class="clear5">
                        </div>
                        <div>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td align="center" style="color: Red; font-size: 14px; font-weight: bold;">
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                        <table cellspacing="0" cellpadding="0" width="50%" border="0">
                                            <tr>
                                                <td align="left" style="color: Red; font-size: 14px; font-weight: normal;">
                                                    <asp:ValidationSummary ID="valDownloads" runat="server" ValidationGroup="Chart" HeaderText="The following error(s) occurred:" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0" style="padding: 15px;">
                                <colgroup>
                                    <col width="38%" />
                                    <col width="31%" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td class="style1">
                                        <b>From Date:</b>&nbsp;
                                        <asp:TextBox ID="txtStartDate" runat="server" Width="100px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqdate" runat="server" ControlToValidate="txtStartDate"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="From Date is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularDate" runat="server" ControlToValidate="txtStartDate"
                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                        <cc1:CalendarExtender ID="calStart" runat="server" Enabled="True" TargetControlID="txtStartDate"
                                            Format="MM/dd/yyyy" CssClass="MyCalendar" />
                                    </td>
                                    <td>
                                        <b>To Date:</b>&nbsp;
                                        <asp:TextBox ID="txtEndDate" runat="server" Width="100px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEndDate"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="To Date is mandatory.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"
                                            ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d"
                                            ValidationGroup="Chart" Display="Dynamic" ErrorMessage="Invalid Date Format">*</asp:RegularExpressionValidator><br />
                                        <cc1:CalendarExtender ID="calEnd" runat="server" TargetControlID="txtEndDate" Format="MM/dd/yyyy"
                                            CssClass="MyCalendar" />
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Button ID="btnchart" Text="Submit" runat="server" ValidationGroup="Chart"
                                            OnClick="btnchart_Click" OnClientClick="return ShowPieChart();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
                                        <div id="chart_div" style="display: block; margin: 0 auto;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clear10">
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ChangeWebPage(id) {
            var previousID = "";
            if (document.getElementById('<%=hdnPreviousDivID.ClientID %>').value == "")
                previousID = 'divManageWebLinks';
            else
                previousID = document.getElementById('<%=hdnPreviousDivID.ClientID %>').value;
            if (id != previousID) {
                $('#' + id).removeClass('webmangement_rightcol_rowbg_heading2').addClass('webmangement_rightcol_rowbg_heading1');
                $('#' + id + 'Page').css('display', 'block');
                $('#' + previousID).removeClass('webmangement_rightcol_rowbg_heading1').addClass('webmangement_rightcol_rowbg_heading2');
                $('#' + previousID + 'Page').css('display', 'none');
                document.getElementById('<%=hdnPreviousDivID.ClientID %>').value = id;
            }
        }
        window.onload = function () {
            if (document.getElementById('<%=hdnPreviousDivID.ClientID %>').value == "") {
                $('#divManageWebLinksPage').css('display', 'block');
            }
        }
    </script>
    <script type="text/javascript">
        function ShowPieChart() {
            if (Page_ClientValidate('Chart') && Page_IsValid) {
                var startDt = document.getElementById('<%=txtStartDate.ClientID%>').value;
                var endDt = document.getElementById('<%=txtEndDate.ClientID%>').value;
                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!
                var yyyy = today.getFullYear();
                if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm }
                var today = mm + '/' + dd + '/' + yyyy;
                var ErrMsg = "";
                if (!(startDt <= today))
                    ErrMsg = "From Date should be always lesser than or equal to current Date.\n";
                if (!(endDt <= today))
                    ErrMsg = ErrMsg + "To Date should be always lesser than or equal to current Date.\n";
                if (!(startDt <= endDt))
                    ErrMsg = ErrMsg + "To Date should be always greater than or equal to From Date.";
                if (ErrMsg == "") {
                    PageMethods.ServerSidefill(startDt, endDt, OnSuccess, OnFailure);
                }
                else {
                    alert(ErrMsg);
                }

            }
            return false;
        }
        function OnSuccess(result) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'PlatForms');
            var downloadcount = 0;
            data.addColumn('number', 'Downloads');
            if (result.length > 0) {
                for (var i = 0; i < result.length; i++) {
                    data.addRow([result[i].PlatForms, result[i].Downloads]);
                    downloadcount += result[i].Downloads;
                }
                new google.visualization.PieChart(document.getElementById('chart_div')).
                draw(data,
                    {
                        width: 600,
                        height: 350,
                        title: "App Downloads between " + document.getElementById('<%=txtStartDate.ClientID%>').value + " and " + document.getElementById('<%=txtEndDate.ClientID%>').value + " - " + downloadcount
                    }
                );
            }
            else {
                document.getElementById('chart_div').style.height = "0px";
                document.getElementById('chart_div').style.width = '100%';
                document.getElementById('chart_div').innerHTML = '';
                document.getElementById('<%=lblMessage.ClientID%>').innerHTML = "No downloads between " + document.getElementById('<%=txtStartDate.ClientID%>').value + " and " + document.getElementById('<%=txtEndDate.ClientID%>').value + ".";
            }
        }
        function OnFailure(result) {
            alert("An error has been occurred while genearting the chart for app downloads.");
        }
        function ShowAssociateMSG() {
            alert('You do not have sufficient permissions.');
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="myPlaceholder">
        <script type="text/javascript">
            document.createElement('header');
            document.createElement('footer');
            document.createElement('section');
            document.createElement('aside');
            document.createElement('nav');

            function ModalPopupsAlert1(Title, Divtxt) {
                ModalPopups.Alert("jsAlert1",
              Title, Divtxt,
              {
                  okButtonText: "Close"
              });
            }
            function OnSuccess(result) {

            }
            function OnFailure(result) {
                alert(error);
            }
            function showPanel(value) {
                var modalPopupBehaviorCtrl = $find('<%=ModalPopupExtenderhelp.ClientID %>');
                modalPopupBehaviorCtrl.show();
                if (value != 0) {
                    //                    if (document.getElementById('<%=hdnhelpname.ClientID %>').value != "" & document.getElementById('<%=hdnhelpText.ClientID %>').value != "") {
                    //                        var content = document.getElementById('<%=hdnhelpText.ClientID %>').value;
                    //                        content = content.replace(/&lt;/g, "<");
                    //                        content = content.replace(/&gt;/g, ">");
                    //                        document.getElementById('<%=hdnhelpText.ClientID %>').value = content;

                    //                        document.getElementById('<%=lbltitle.ClientID %>').innerHTML = document.getElementById('<%=hdnhelpname.ClientID %>').value;
                    //                        document.getElementById('<%=lblcontent.ClientID %>').innerHTML = document.getElementById('<%=hdnhelpText.ClientID %>').value;
                    //                        if (document.getElementById('<%=hdnhelpvideo.ClientID %>').value != "") {
                    //                            document.getElementById('<%=lblvideoheading.ClientID %>').innerHTML = "Looking for demonstration? watch video:";
                    //                            document.getElementById('<%=lblvideo.ClientID %>').innerHTML = document.getElementById('<%=hdnhelpvideo.ClientID %>').value;
                    //                        }
                    //                        document.getElementById('<%=pnl2.ClientID %>').style.display = "none";
                    //                        document.getElementById('<%=pnl1.ClientID %>').style.display = "inline";
                    //                        document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                    //                    }
                    //                    else {
                    document.getElementById('<%=lblNoHelpMsg.ClientID %>').innerHTML = "";
                    document.getElementById('<%=pnl1.ClientID %>').style.display = "none";
                    document.getElementById('<%=pnl2.ClientID %>').style.display = "inline";
                    document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                    //                    }
                }
                document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
            }
            function popup() {
                document.getElementById('<%=pnl1.ClientID %>').style.display = "none";
                document.getElementById('<%=pnl2.ClientID %>').style.display = "inline";
                document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
            }

            function popupclose() {
                var modalPopupBehaviorCtrl = $find('<%=ModalPopupExtenderhelp.ClientID %>');
                modalPopupBehaviorCtrl.hide();
            }
            function ModalGlossaryPopup(Title1, DivID, Divtxt1) {
                Divtxt1 = Divtxt1.replace(/__/g, "");
                var Divtxt2 = Divtxt1.replace(/;/g, "~");
                Divtxt2 = Divtxt2.replace(/‘/g, "'");
                Divtxt2 = Divtxt2.replace(/’/g, "'");
                document.getElementById('<%=hdnGlossarydesc.ClientID %>').value = Divtxt1;
                document.getElementById('<%=hdnGlossarytext.ClientID %>').value = Title1;
                var modalPopupBehaviorCtrl = $find('<%=ModalPopupExtenderhelp.ClientID %>');
                modalPopupBehaviorCtrl.show();
                document.getElementById('<%=lbltitle1.ClientID %>').innerHTML = document.getElementById('<%=hdnGlossarytext.ClientID %>').value;
                document.getElementById('<%=lblcontent1.ClientID %>').innerHTML = document.getElementById('<%=hdnGlossarydesc.ClientID %>').value;
                document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "inline";
                document.getElementById('<%=pnl1.ClientID %>').style.display = "none";
                document.getElementById('<%=pnl2.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
                setTimeout("hide()", 0.5);
                setTimeout("displayglossary()", 0.5);
            }
            function showglossarypanel(value) {
                var modalPopupBehaviorCtrl = $find('<%=ModalPopupExtenderhelp.ClientID %>');
                modalPopupBehaviorCtrl.show();

                if (value == "1") {
                    document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "inline";
                    document.getElementById('<%=pnl1.ClientID %>').style.display = "none";
                    document.getElementById('<%=pnl2.ClientID %>').style.display = "none";
                    document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                }
                else {
                    document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                    document.getElementById('<%=pnl1.ClientID %>').style.display = "none";
                    document.getElementById('<%=pnl2.ClientID %>').style.display = "inline";
                    document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                }
                document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
            }
            /***** Glossary Commented By Suneel 05/08/2013 05:31:40 ******/
            /*****
            function popupglossary() {
            document.getElementById('<%=pnl1.ClientID %>').style.display = "none";
            document.getElementById('<%=pnl2.ClientID %>').style.display = "none";
            document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
            document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "inline";
            document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "none";
            document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
            }
            *****/
            function displayglossary() {
                document.getElementById('<%=pnl1.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "inline";
                document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
            }
            function displaygemailpanel(value) {
                document.getElementById('<%=lbltitle1.ClientID %>').innerHTML = document.getElementById('<%=hdnGlossarytext.ClientID %>').value;
                document.getElementById('<%=lblcontent1.ClientID %>').innerHTML = document.getElementById('<%=hdnGlossarydesc.ClientID %>').value;
                if (value != 1) {
                    document.getElementById('<%=lblgmsg.ClientID %>').innerHTML = "";
                    document.getElementById('<%=txtgemail.ClientID %>').value = "";
                    document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
                    document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "inline";
                    document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                }
                else {
                    document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "inline";
                    document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "none";
                    document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                }
                document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                document.getElementById('<%=pnl1.ClientID %>').style.display = "none";
                document.getElementById('<%=pnl2.ClientID %>').style.display = "none";
            }
            var Title11 = "";
            var DivID11 = "";
            var DivVideo11 = "";
            function ModalHelpPopup(Title1, DivID, divvideo) {
                Title11 = Title1;
                DivID11 = DivID;
                DivVideo11 = divvideo;
                document.getElementById('<%=hdnhelpID.ClientID %>').value = DivID11;
                PageMethods.GetHelpcontentbyHelpID(DivID, GetHelpcontentbyHelpID_Success, GetHelpcontentbyHelpID_Failure);
            }

            function GetHelpcontentbyHelpID_Success(result) {
                var searchKeyword = "";
                var Divtxt1 = result;
                Divtxt1 = Divtxt1.replace(/__/g, "");
                var content = Divtxt1.replace(/</g, "&lt;");
                content = content.replace(/>/g, "&gt;");
                document.getElementById('<%=hdnhelpText.ClientID %>').value = content;
                document.getElementById('<%=hdnhelpname.ClientID %>').value = Title11;
                document.getElementById('<%=hdnhelpvideo.ClientID %>').value = DivVideo11;
                var Divtxt2 = Divtxt1.replace(/;/g, "~");
                Divtxt2 = Divtxt2.replace(/‘/g, "'");
                Divtxt2 = Divtxt2.replace(/’/g, "'");

                var modalPopupBehaviorCtrl = $find('<%=ModalPopupExtenderhelp.ClientID %>');
                modalPopupBehaviorCtrl.show();

                if (document.getElementById('<%=hdnhelpKeyword.ClientID %>').value != "")
                    searchKeyword = document.getElementById('<%=hdnhelpKeyword.ClientID %>').value;
                document.getElementById('<%=lbltitle.ClientID %>').innerHTML = document.getElementById('<%=hdnhelpname.ClientID %>').value;
                var showcontent = document.getElementById('<%=hdnhelpText.ClientID %>').value;
                showcontent = showcontent.replace(/&lt;/g, "<");
                showcontent = showcontent.replace(/&gt;/g, ">");

                //                var arr = jQuery(showcontent).find('a').map(function () {
                //                    return $(this).attr('href');
                //                }).get();
                //                for (var hrefCount = 0; hrefCount < arr.length; hrefCount++) {
                //                    showcontent.replace(arr[hrefCount], '###Anchor' + hrefCount + '###');
                //                }
                //                showcontent = showcontent.replace(searchKeyword, '<span style="background-color:#CCE9FF;">' + searchKeyword + '</span>');
                //                
                //                for (var hrefCount = 0; hrefCount < arr.length; hrefCount++) {
                //                    showcontent.replace('###Anchor' + hrefCount + '###', arr[hrefCount]);
                //                }
                document.getElementById('<%=lblcontent.ClientID %>').innerHTML = showcontent;

                if (document.getElementById('<%=hdnhelpvideo.ClientID %>').value != "") {
                    document.getElementById('<%=lblvideoheading.ClientID %>').innerHTML = "Looking for demonstration? Watch the video:";
                    document.getElementById('<%=lblvideo.ClientID %>').innerHTML = divvideo11;
                }
                else {
                    document.getElementById('<%=lblvideoheading.ClientID %>').innerHTML = "";
                    document.getElementById('<%=lblvideo.ClientID %>').innerHTML = "";
                }
                document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
                setTimeout("hide()", 0.5);
                setTimeout("display()", 0.5);
            }
            function GetHelpcontentbyHelpID_Failure()
            { }
            function Hidepopup() {
                var modalPopupBehaviorCtrl = $find('<%=ModalPopupExtenderhelp.ClientID %>');
                modalPopupBehaviorCtrl.hide();
            }
            function hide() {
                document.getElementById('<%=pnl2.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";

            }
            function display() {
                document.getElementById('<%=pnl1.ClientID %>').style.display = "inline";
                document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
                document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "none";
            }

            function displayemailpanel(value) {
                if (document.getElementById('<%=hdnhelpname.ClientID %>') != null && document.getElementById('<%=hdnhelpText.ClientID %>') != null) {
                    document.getElementById('<%=lbltitle.ClientID %>').innerHTML = document.getElementById('<%=hdnhelpname.ClientID %>').value;
                    var content = document.getElementById('<%=hdnhelpText.ClientID %>').value;
                    content = content.replace(/&lt;/g, "<");
                    content = content.replace(/&gt;/g, ">");
                    document.getElementById('<%=lblcontent.ClientID %>').innerHTML = content;
                    if (document.getElementById('<%=hdnhelpvideo.ClientID %>').value != "") {
                        document.getElementById('<%=lblvideoheading.ClientID %>').innerHTML = "Looking for demonstration? watch video:";
                        document.getElementById('<%=lblvideo.ClientID %>').innerHTML = document.getElementById('<%=hdnhelpvideo.ClientID %>').value;
                    }
                    else {
                        document.getElementById('<%=lblvideoheading.ClientID %>').innerHTML = "";
                        document.getElementById('<%=lblvideo.ClientID %>').innerHTML = "";
                    }

                    if (value != 1) {
                        document.getElementById('<%=lblhelpmsg.ClientID %>').innerHTML = "";
                        document.getElementById('<%=txtemail.ClientID %>').value = "";
                        document.getElementById('<%=pnlemail.ClientID %>').style.display = "none";
                        document.getElementById('<%=pnl1.ClientID %>').style.display = "inline";
                        document.getElementById('<%=pnl2.ClientID %>').style.display = "none";
                    }
                    else {
                        document.getElementById('<%=pnlemail.ClientID %>').style.display = "inline";
                        document.getElementById('<%=pnl1.ClientID %>').style.display = "none";
                        document.getElementById('<%=pnl2.ClientID %>').style.display = "none";
                    }
                    document.getElementById('<%=Pnlglossary.ClientID %>').style.display = "none";
                    document.getElementById('<%=pnlglossarydesc.ClientID %>').style.display = "none";
                    document.getElementById('<%=pnlglossaryemail.ClientID %>').style.display = "none";
                }
            }
            function PrintContent() {
                //                document.getElementById('<%=imclosehelp.ClientID %>').style.display = "none";
                //                document.getElementById('tblhelpmenu').style.display = "none";
                var DocumentContainer1 = document.getElementById('<%=lbltitle.ClientID %>');
                var DocumentContainer = document.getElementById('divtoprint');
                var WindowObject = window.open('', "PrintWindow", "width=420,height=380,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes");
                WindowObject.document.writeln("<b>" + DocumentContainer1.innerHTML + "</b>" + "<br/><br/><br/><div style='width:540px;'>" + DocumentContainer.innerHTML + "</div>");
                WindowObject.document.close();
                WindowObject.focus();
                WindowObject.print();
                WindowObject.close();
            }
            function DownloadContent() {
                var DocumentContainer1 = document.getElementById('<%=lbltitle.ClientID %>');
                var DocumentContainer = document.getElementById('divtoprint');
                var WindowObject = window.open('', "PrintWindow", "width=420,height=380,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes");
                WindowObject.document.writeln("<b>" + DocumentContainer1.innerHTML + "</b>" + "<br/><br/><br/>" + DocumentContainer.innerHTML);
                WindowObject.document.close();
                WindowObject.focus();
                //WindowObject.print();
                //WindowObject.close();
            }
            function PrintgContent() {
                var DocumentContainer1 = document.getElementById('<%=lbltitle1.ClientID %>');
                var DocumentContainer = document.getElementById('glossarydivtoprint');
                var WindowObject = window.open('', "PrintWindow", "width=420,height=380,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes");
                WindowObject.document.writeln("<b>" + DocumentContainer1.innerHTML + "</b>" + "<br/><br/><br/>" + DocumentContainer.innerHTML);
                WindowObject.document.close();
                WindowObject.focus();
                WindowObject.print();
                WindowObject.close();
            }
            function CloseVersionsModal() {
                $find("<%=ModalPopupExtenderVersions.ClientID %>").hide();
            }
            function ShowVersionsPopup() {
                $find("<%=ModalPopupExtenderVersions.ClientID %>").show();
            }
        </script>
        <style type="text/css">

            .allversions ul
            {
                font-size: 14px;
                line-height: 20px;
            }
            @media print
            {
                #tblh
                {
                    display: none;
                }
                #tblti
                {
                    display: none;
                }
                #tbltab
                {
                    display: none;
                }
                #tblcolumns
                {
                    display: none;
                }
                #preview
                {
                    display: block;
                }
                #Table1
                {
                    display: none;
                }
                #footerimg
                {
                    display: none;
                }
                #site
                {
                    display: none;
                }
                #tblf
                {
                    display: none;
                }
                #pagetitle
                {
                    display: none;
                }
                #css
                {
                    display: none;
                }
            
                #tbls
                {
                    display: none;
                }
                #cphUser
                {
                    display: none;
                }
                #ctl00_cphUser_btnSearch
                {
                    display: none;
                }
                #ctl00_cphUser_grdCoupons
                {
                    display: none;
                }
                #ctl00_cphUser_grid
                {
                    display: none;
                }
                #imgprint
                {
                    display: none;
                }
                #ctl00_cphUser_ASPxPopupControl1_imgPreview
                {
                    display: block;
                }
            
                #ctl00_cphUser_ASPxPopupControl1_PWH-1
                {
                    display: none;
                }
                #ctl00_cphUser_ASPxPopupControl1_HCB-1Img
                {
                    display: none;
                }
            }
            .modal
            {
                background-color: Gray;
                filter: alpha(opacity=90);
                opacity: 0.7;
            }
            
            .mp-border
            {
                border: 12px solid #959fa7;
                margin: 0px;
            }
            .mp-title
            {
                background-color: #b9cce4;
                padding: 5px;
                border-bottom: 1px solid #8594a3;
                border-left: 1px solid #FFFFFF;
                border-right: 1px solid #FFFFFF;
                border-top: 1px solid #FFFFFF;
                font-weight: bold;
                color: #0c2947;
                padding-left: 5px;
                font-size: 12px;
            }
            .mp-title td.close
            {
                text-align: right;
                width: 35px;
            }
            .mp-bg
            {
                padding: 10px;
            }
            #container *
            {
                z-index: 2;
            }
            /*  #content * { z-index: 1;}*/
            
            .AutoExtender
            {
                list-style-type: none;
                padding: -5px 0px 0px -40px;
                margin: -5px 0px 0px -40px;
                width: 440px;
                z-index: 200001 !important;
            }
            .HelpBox
            {
                width: 370px;
                height: 20px;
                border: solid 1px #F0F0F0;
                padding: 5px;
                background-color: #FFFFFF;
                outline: none;
                color: #474747;
            }
            .HelpButton
            {
                -webkit-border-radius: 2;
                -moz-border-radius: 2;
                border-radius: 2px;
                font-family: Arial;
                border: solid #5d6061 2px;
                color: #ffffff;
                font-size: 14px;
                background: #5c5f61;
                padding: 4px 8px 4px 8px;
                text-decoration: none;
            }
            /*AutoComplete flyout */
            .autocomplete_completionListElement
            {
                margin: 0px !important;
                background-color: inherit;
                color: windowtext;
                border: buttonshadow;
                border-width: 1px;
                border-style: solid;
                cursor: 'default';
                overflow: auto;
                height: auto;
                text-align: left;
                list-style-type: none;
            }
            
            /* AutoComplete highlighted item */
            .autocomplete_highlightedListItem
            {
                background-color: #ffff99;
                color: black;
                padding: 1px;
            }
            
            /* AutoComplete item */
            .autocomplete_listItem
            {
                background-color: window;
                color: windowtext;
                padding: 1px;
            }
            /* .AutoExtender
        {
            font-family: Verdana, Helvetica, sans-serif;
            font-size: 1.0em;
            font-weight: normal;
            border: solid 1px #006699;
            line-height: 20px;
            padding: 10px;
            background-color: White;
            margin-left:10px;
        }*/
            .AutoExtenderList
            {
                border-bottom: dotted 1px #006699;
                cursor: pointer;
                color: Maroon;
                font-style: normal;
            }
            #ctl00_pnlpopuphelp td img, #ctl00_pnlpopuphelp table td
            {
            vertical-align:baseline !important;
            }
            #ctl00_TreeView1 table tr:first-child td img
            {
            vertical-align:middle !important;
            }
        </style>
    <style type="text/css">
        .style1
        {
            width: 387px;
        }
    </style>
</asp:Content>

