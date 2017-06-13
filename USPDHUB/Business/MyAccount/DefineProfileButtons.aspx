<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="DefineProfileButtons.aspx.cs" Inherits="USPDHUB.Business.MyAccount.DefineProfileButtons" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript">
        function CharacterCount() {
            var count = document.getElementById('<%=txtTabName.ClientID %>').value.length;
            document.getElementById("<%=txtcount.ClientID %>").value = (30 - count);
        }

        function ShowCustomTabPanel(control, pageNo) {

            document.getElementById("<%=lblMessage.ClientID %>").innerHTML = '';
            var strName = control.options[control.selectedIndex].value;
            // custom tab show
            if (strName == "Custom Tab") {
                document.getElementById("ctl00_cphUser_divcustomtab").style.display = "block";
                document.getElementById("divApplySite").style.display = "none";
            } else {
                document.getElementById("ctl00_cphUser_divcustomtab").style.display = "none";
                document.getElementById("divApplySite").style.display = "block";
            }


            // Previous alrets showing...
            var PretabName = document.getElementById("<%=pagename.ClientID %>").value;

            document.getElementById("<%=pagename.ClientID %>").value = pageNo;

            var message = "Unsaved edits will be lost. Do you want to continue?";
            if (PretabName != '') {
                if (pageNo != 'Page 1') {
                    var ddlhome = document.getElementById("<%=ddlhome.ClientID %>");
                    preID = ddlhome.options[ddlhome.selectedIndex].value;
                    //confirmation alerts
                    if (preID == "Custom Tab" && strName == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlhome, document.getElementById("<%=HiddenField1.ClientID %>").value);
                        }
                        else {
                            //document.getElementById("<%=pagename.ClientID %>").value = 'Page 1';
                        }
                    }
                    else if (preID == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlhome, document.getElementById("<%=HiddenField1.ClientID %>").value);
                        }
                        else {
                            document.getElementById("ctl00_cphUser_divcustomtab").style.display = "block";
                            document.getElementById("<%=pagename.ClientID %>").value = 'Page 1';
                        }
                    }
                }

                if (pageNo != 'Page 2') {
                    var ddlabout = document.getElementById("<%=ddlabout.ClientID %>");
                    preID = ddlabout.options[ddlabout.selectedIndex].value;
                    //  //confirmation alerts
                    if (preID == "Custom Tab" && strName == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlabout, document.getElementById("<%=HiddenField2.ClientID %>").value);
                        }
                        else {
                            //document.getElementById("<%=pagename.ClientID %>").value = 'Page 2';
                        }
                    }
                    else if (preID == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlabout, document.getElementById("<%=HiddenField2.ClientID %>").value);
                        }
                        else {
                            document.getElementById("ctl00_cphUser_divcustomtab").style.display = "block";
                            document.getElementById("<%=pagename.ClientID %>").value = 'Page 2';
                        }
                    }
                }

                if (pageNo != 'Page 3') {
                    var ddlmedia = document.getElementById("<%=ddlmedia.ClientID %>");
                    preID = ddlmedia.options[ddlmedia.selectedIndex].value;

                    //  //confirmation alerts
                    if (preID == "Custom Tab" && strName == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlmedia, document.getElementById("<%=HiddenField3.ClientID %>").value);
                        }
                        else {
                            //document.getElementById("<%=pagename.ClientID %>").value = 'Page 3';
                        }
                    }
                    else if (preID == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlmedia, document.getElementById("<%=HiddenField3.ClientID %>").value);
                        }
                        else {
                            document.getElementById("ctl00_cphUser_divcustomtab").style.display = "block";
                            document.getElementById("<%=pagename.ClientID %>").value = 'Page 3';
                        }
                    }
                }

                if (pageNo != 'Page 4') {
                    var ddlupdates = document.getElementById("<%=ddlupdates.ClientID %>");
                    preID = ddlupdates.options[ddlupdates.selectedIndex].value;
                    //  //confirmation alerts
                    if (preID == "Custom Tab" && strName == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlupdates, document.getElementById("<%=HiddenField4.ClientID %>").value);
                        }
                        else {
                            //document.getElementById("<%=pagename.ClientID %>").value = 'Page 4';
                        }
                    }
                    else if (preID == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlupdates, document.getElementById("<%=HiddenField4.ClientID %>").value);
                        }
                        else {
                            document.getElementById("ctl00_cphUser_divcustomtab").style.display = "block";
                            document.getElementById("<%=pagename.ClientID %>").value = 'Page 4';
                        }
                    }
                }

                if (pageNo != 'Page 5') {

                    var ddleventcal = document.getElementById("<%=ddleventcal.ClientID %>");
                    preID = ddleventcal.options[ddleventcal.selectedIndex].value;
                    //  //confirmation alerts
                    if (preID == "Custom Tab" && strName == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlnetowrk, document.getElementById("<%=HiddenField5.ClientID %>").value);
                        }
                        else {
                            //document.getElementById("<%=pagename.ClientID %>").value = 'Page 5';
                        }
                    }
                    else if (preID == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddleventcal, document.getElementById("<%=HiddenField5.ClientID %>").value);
                        }
                        else {
                            document.getElementById("ctl00_cphUser_divcustomtab").style.display = "block";
                            document.getElementById("<%=pagename.ClientID %>").value = 'Page 5';
                        }
                    }
                }
                if (pageNo != 'Page 6') {

                    var ddlbulletin = document.getElementById("<%=ddlbulletin.ClientID %>");
                    preID = ddlbulletin.options[ddlbulletin.selectedIndex].value;
                    //confirmation alerts
                    if (preID == "Custom Tab" && strName == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlbulletin, document.getElementById("<%=HiddenField6.ClientID %>").value);
                        }
                        else {
                            //document.getElementById("<%=pagename.ClientID %>").value = 'Page 6';
                        }
                    }
                    else if (preID == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlbulletin, document.getElementById("<%=HiddenField6.ClientID %>").value);
                        }
                        else {
                            document.getElementById("ctl00_cphUser_divcustomtab").style.display = "block";
                            document.getElementById("<%=pagename.ClientID %>").value = 'Page 6';
                        }
                    }
                }
                if (pageNo != 'Page 7') {

                    var ddlweblinks = document.getElementById("<%=ddlweblinks.ClientID %>");
                    preID = ddlweblinks.options[ddlweblinks.selectedIndex].value;
                    //confirmation alerts
                    if (preID == "Custom Tab" && strName == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlbulletin, document.getElementById("<%=HiddenField7.ClientID %>").value);
                        }
                        else {
                            //document.getElementById("<%=pagename.ClientID %>").value = 'Page 7';
                        }
                    }
                    else if (preID == "Custom Tab") {
                        var result = confirm(message);
                        if (result == true) {
                            SetDDLValue(ddlbulletin, document.getElementById("<%=HiddenField7.ClientID %>").value);
                        }
                        else {
                            document.getElementById("ctl00_cphUser_divcustomtab").style.display = "block";
                            document.getElementById("<%=pagename.ClientID %>").value = 'Page 7';
                        }
                    }
                }
            }


            if (strName != "Custom Tab") {
                if (pageNo == 'Page 1') {
                    document.getElementById("<%=HiddenField1.ClientID %>").value = strName;
                }
                else if (pageNo == 'Page 2') {
                    document.getElementById("<%=HiddenField2.ClientID %>").value = strName;
                }
                else if (pageNo == 'Page 3') {
                    document.getElementById("<%=HiddenField3.ClientID %>").value = strName;
                }
                else if (pageNo == 'Page 4') {
                    document.getElementById("<%=HiddenField4.ClientID %>").value = strName;
                }
                else if (pageNo == 'Page 5') {
                    document.getElementById("<%=HiddenField5.ClientID %>").value = strName;
                }
                else if (pageNo == 'Page 6') {
                    document.getElementById("<%=HiddenField6.ClientID %>").value = strName;
                }
                else if (pageNo == 'Page 7') {
                    document.getElementById("<%=HiddenField7.ClientID %>").value = strName;
                }
            }
        }

        function SetDDLValue(contorlID, selectext) {
            for (i = 0; i < contorlID.options.length; i++) {
                if (contorlID.options[i].value == selectext) {
                    contorlID.options[i].selected = true;
                    // document.getElementById("<%=pagename.ClientID %>").value = 'Page ' + (i + 1);
                    break;
                }
            }
        }
        function ChangepreviousDDL(pageNo) {
            if (pageNo != "Custom Tab") {
                if (pageNo == 'Page 1') {
                    SetDDLValue(document.getElementById("<%=ddlhome.ClientID %>"), document.getElementById("<%=HiddenField1.ClientID %>").value);
                }
                else if (pageNo == 'Page 2') {
                    SetDDLValue(document.getElementById("<%=ddlabout.ClientID %>"), document.getElementById("<%=HiddenField2.ClientID %>").value);
                }
                else if (pageNo == 'Page 3') {
                    SetDDLValue(document.getElementById("<%=ddlmedia.ClientID %>"), document.getElementById("<%=HiddenField3.ClientID %>").value);
                }
                else if (pageNo == 'Page 4') {
                    SetDDLValue(document.getElementById("<%=ddlupdates.ClientID %>"), document.getElementById("<%=HiddenField4.ClientID %>").value);
                }
                else if (pageNo == 'Page 5') {
                    SetDDLValue(document.getElementById("<%=ddleventcal.ClientID %>"), document.getElementById("<%=HiddenField5.ClientID %>").value);
                }
                else if (pageNo == 'Page 6') {
                    SetDDLValue(document.getElementById("<%=ddlbulletin.ClientID %>"), document.getElementById("<%=HiddenField6.ClientID %>").value);
                }
                else if (pageNo == 'Page 7') {
                    SetDDLValue(document.getElementById("<%=ddlweblinks.ClientID %>"), document.getElementById("<%=HiddenField7.ClientID %>").value);
                }
            }
        }

        function validate() {
            var ddlhome = document.getElementById("<%=ddlhome.ClientID %>");
            var hometabname = ddlhome.options[ddlhome.selectedIndex].value;

            var ddlabout = document.getElementById("<%=ddlabout.ClientID %>");
            var abouttabname = ddlabout.options[ddlabout.selectedIndex].value;

            var ddlmedia = document.getElementById("<%=ddlmedia.ClientID %>");
            var mediatabname = ddlmedia.options[ddlmedia.selectedIndex].value;

            var ddlupdates = document.getElementById("<%=ddlupdates.ClientID %>");
            var updatetabname = ddlupdates.options[ddlupdates.selectedIndex].value;

            var ddleventcal = document.getElementById("<%=ddleventcal.ClientID %>");
            var eventcaltabname = ddleventcal.options[ddleventcal.selectedIndex].value;

            var ddlbulletin = document.getElementById("<%=ddlbulletin.ClientID %>");
            var bulletintabname = ddlbulletin.options[ddlbulletin.selectedIndex].value;

            var ddlweblinks = document.getElementById("<%=ddlweblinks.ClientID %>");
            var weblinkstabname = ddlweblinks.options[ddlweblinks.selectedIndex].value;

            if (hometabname == "Custom Tab") {
                alert("Please select another tab name for Home.");
                return false;
            }
            else if (abouttabname == "Custom Tab") {
                alert("Please select another tab name for About Us.");
                return false;
            }
            else if (mediatabname == "Custom Tab") {
                alert("Please select another tab name for Media.");
                return false;
            }
            else if (updatetabname == "Custom Tab") {
                alert("Please select another tab name for Updates.");
                return false;
            }
            else if (eventcaltabname == "Custom Tab") {
                alert("Please select another tab name for Event Calendar.");
                return false;
            }
            else if (bulletintabname == "Custom Tab") {
                alert("Please select another tab name for Bulletins.");
                return false;
            }
            else if (weblinkstabname == "Custom Tab") {
                alert("Please select another tab name for Web Links.");
                return false;
            }
            else {
                //order no Equence
                // *** Hard coded to remove once affiliates are active in menu *** //
                for (i = 1; i <= 7; i++) {
                    var name1 = "ctl00_cphUser_ddl" + i;
                    var drd1 = document.getElementById(name1);
                    for (j = 1; j <= 7; j++) {
                        var name2 = "ctl00_cphUser_ddl" + j;
                        var drd2 = document.getElementById(name2);
                        if (drd1 != drd2) {
                            if (drd1.options[drd1.selectedIndex].value == drd2.options[drd2.selectedIndex].value) {
                                alert('Please check the order sequence.');
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
        }

        function ShortCut() {
            var modalDialog = $find("createshortcut");
            var iframe = document.getElementById('frmShortcut');
            var innerDoc = iframe.contentDocument || iframe.contentWindow.document;
            innerDoc.getElementById('chkCreate').checked = false;
            modalDialog.show();
        }

    </script>
    <script type="text/javascript">
        function ValidateOrderNo(control) {
            var strName = control.options[control.selectedIndex].value;

            var ddl1 = document.getElementById("<%=ddl1.ClientID %>");
            var ddl2 = document.getElementById("<%=ddl2.ClientID %>");
            var ddl3 = document.getElementById("<%=ddl3.ClientID %>");
            var ddl4 = document.getElementById("<%=ddl4.ClientID %>");
            var ddl5 = document.getElementById("<%=ddl5.ClientID %>");
            var ddl6 = document.getElementById("<%=ddl6.ClientID %>");
            var ddl7 = document.getElementById("<%=ddl7.ClientID %>");
            if (ddl1 != control && strName == ddl1.options[ddl1.selectedIndex].value) {
                alert('Please check the order sequence.');
                return false;
            }
            else if (ddl2 != control && strName == ddl2.options[ddl2.selectedIndex].value) {
                alert('Please check the order sequence.');
                return false;
            }
            else if (ddl3 != control && strName == ddl3.options[ddl3.selectedIndex].value) {
                alert('Please check the order sequence.');
                return false;
            }
            else if (ddl4 != control && strName == ddl4.options[ddl4.selectedIndex].value) {
                alert('Please check the order sequence.');
                return false;
            }
            else if (ddl5 != control && strName == ddl5.options[ddl5.selectedIndex].value) {
                alert('Please check the order sequence.');
                return false;
            }
            else if (ddl6 != control && strName == ddl6.options[ddl6.selectedIndex].value) {
                alert('Please check the order sequence.');
                return false;
            }
            else if (ddl7 != control && strName == ddl7.options[ddl7.selectedIndex].value) {
                alert('Please check the order sequence.');
                return false;
            }
            else {
                return true;
            }
        }
        function ShowAssociateMSG() {
            alert('You do not have sufficient permissions.');
            return false;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="text-align: center;">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="Medium"></asp:Label>
            </div>
            <div id="webmangement_wrapper">
                <div id="webmangement_leftcol">
                    <div class="webmangement_leftcol_heading">
                        Mobile App Management
                        <asp:HiddenField ID="hdnPreviousDivID" runat="server" />
                        <asp:HiddenField ID="hdnPermissionType" runat="server" />
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
                        <div class="webmangement_rightcol_rowbg_heading14" id="div1">
                            <img src="../../images/dashboard/manage-logins.png" /><span><a href="#" onclick="ShowAssociateMSG();">Manage
                                Logins</a></span></div>
                        <%} %>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divManageWebLinks">
                            <img src="../../images/dashboard/web-links.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageWebLinks.aspx")%>">Web
                                Links</a></span></div>
                        <%--<div class="webmangement_rightcol_rowbg_heading14" id="divShortcut">
                            <img src="../../images/dashboard/create-destop-shortcut.png" /><span><a href="javascript:ShortCut();">Create
                                Desktop Shortcut</a></span>
                        </div>--%>
                        <div class="webmangement_rightcol_rowbg_heading14" id="divSocialMedia">
                            <img src="../../images/dashboard/Social-media.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/SocialMedia.aspx")%>">Social
                                Media</a></span>
                        </div>
                        <%--<div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/download_n.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/DownloadInstallers.aspx")%>">
                                Downloads</a></span></div>--%>
                        <div class="webmangement_rightcol_rowbg_heading14">
                            <img src="../../images/dashboard/appdownloads.png" /><span><a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/AppUsageReports.aspx")%>">App
                                Usage Report</a></span></div>
                        <%if (IsParent)
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
                            <img src="../../images/dashboard/resource.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/WebWidget.aspx")%>">
                                Resources</a></span></div>
                    </div>
                </div>
                <div id="webmangement_rightcol">
                    <div class="webmangement_rightcol_heading">
                        Manage Buttons</div>
                    <div id="webmangement_rightcol1">
                        <div class="selectwrap">
                            <div class="selectmenu">
                                Home
                                <asp:DropDownList runat="server" ID="ddlhome" class="select" onchange="ShowCustomTabPanel(this,'Page 1');">
                                </asp:DropDownList>
                            </div>
                            <div class="checkbox" style="display: none;">
                                Tab Order
                                <br>
                                <asp:DropDownList ID="ddl1" runat="server" Enabled="false" class="select" Width="60">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="selectwrap">
                            <div class="selectmenu">
                                About Us
                                <asp:DropDownList runat="server" ID="ddlabout" class="select" onchange="ShowCustomTabPanel(this,'Page 2');">
                                </asp:DropDownList>
                            </div>
                            <div class="checkbox1" style="display: none;">
                                <asp:DropDownList ID="ddl2" runat="server" class="select" Width="60">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="selectwrap">
                            <div class="selectmenu">
                                Updates
                                <asp:DropDownList runat="server" ID="ddlupdates" class="select" onchange="ShowCustomTabPanel(this,'Page 4');">
                                </asp:DropDownList>
                                <asp:CheckBox runat="server" ID='chkupdates' AutoPostBack="true" Checked="true" OnCheckedChanged="chkupdates_CheckedChanged"
                                    Visible="false" />
                            </div>
                            <div class="checkbox1" style="display: none;">
                                <asp:DropDownList ID="ddl4" runat="server" class="select" Width="60">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="selectwrap">
                            <div class="selectmenu">
                                Gallery
                                <asp:DropDownList runat="server" ID="ddlmedia" class="select" onchange="ShowCustomTabPanel(this,'Page 3');">
                                </asp:DropDownList>
                                <asp:CheckBox runat="server" AutoPostBack="true" ID='chkmedia' Checked="true" OnCheckedChanged="chkmedia_CheckedChanged"
                                    Visible="false" />
                            </div>
                            <div class="checkbox1" style="display: none;">
                                <asp:DropDownList ID="ddl3" runat="server" class="select" Width="60">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="selectwrap">
                            <div class="selectmenu">
                                Events</p><asp:DropDownList ID="ddleventcal" runat="server" class="select" onchange="ShowCustomTabPanel(this,'Page 5');">
                                </asp:DropDownList>
                                <asp:CheckBox runat="server" ID='chkeventcal' AutoPostBack="true" Checked="true"
                                    OnCheckedChanged="chkeventcal_CheckedChanged" Visible="false" />
                            </div>
                            <div class="checkbox1" style="display: none;">
                                <asp:DropDownList ID="ddl5" runat="server" class="select" Width="60">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="selectwrap">
                            <div class="selectmenu">
                                Bulletins</p><asp:DropDownList ID="ddlbulletin" runat="server" class="select" onchange="ShowCustomTabPanel(this,'Page 6');">
                                </asp:DropDownList>
                                <asp:CheckBox runat="server" ID='chkbulletin' AutoPostBack="true" Checked="true"
                                    OnCheckedChanged="chkbulletin_CheckedChanged" Visible="false" />
                            </div>
                            <div class="checkbox1" style="display: none;">
                                <asp:DropDownList ID="ddl6" runat="server" class="select" Width="60">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="selectwrap">
                            <div class="selectmenu">
                                Web Links</p><asp:DropDownList ID="ddlweblinks" runat="server" class="select" onchange="ShowCustomTabPanel(this,'Page 7');">
                                </asp:DropDownList>
                                <asp:CheckBox runat="server" ID='chkweblinks' AutoPostBack="true" Checked="true"
                                    OnCheckedChanged="chkweblinks_CheckedChanged" Visible="false" />
                            </div>
                            <div class="checkbox1" style="display: none;">
                                <asp:DropDownList ID="ddl7" runat="server" class="select" Width="60">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clear10">
                        </div>
                    </div>
                    <div id="webmangement_rightcol2">
                        <div style="height: 280px;">
                            <div id='divcustomtab' runat="server" style="display: none;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-top: 10px;">
                                            *Note: New tab names are submitted for review. Approved tab names will appear 48
                                            hours after submission.
                                        </td>
                                    </tr>
                                </table>
                                <table width="81%" style="margin-left: 58px; margin-top: 10px;">
                                    <tr>
                                        <td align="left" style="font-size: 16px; font-weight: bold; color: Black;">
                                            Tab Name
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox runat="server" ID="txtTabName" Width="190" MaxLength="30" BorderColor="#D9D9D9"
                                                BorderStyle="Solid" onkeyup="CharacterCount()" BorderWidth="1" Height="25" Font-Size="14px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTabName"
                                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <strong>Character Count</strong>
                                            <asp:TextBox ID="txtcount" Width="20" runat="server" ReadOnly="true" Text="30"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-right: 45px;">
                                            <asp:ImageButton ID="btnSubmit" ImageUrl="../../images/Dashboard/submit.gif" runat="server"
                                                OnClick="btnSubmit_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="divApplySite">
                            <asp:LinkButton ID="lnkApply" runat="server" OnClick="btnApply_Click" ValidationGroup="Validate"><img src="../../images/Dashboard/applytosite.gif" /></asp:LinkButton>
                            <a id="A3" href="javascript:ModalHelpPopup('Change Button Name',153,'');">
                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                        </div>
                    </div>
                </div>
                <asp:HiddenField runat="server" ID="pagename" />
                <asp:HiddenField runat="server" ID="HiddenField1" />
                <asp:HiddenField runat="server" ID="HiddenField2" />
                <asp:HiddenField runat="server" ID="HiddenField3" />
                <asp:HiddenField runat="server" ID="HiddenField4" />
                <asp:HiddenField runat="server" ID="HiddenField5" />
                <asp:HiddenField runat="server" ID="HiddenField6" />
                <asp:HiddenField runat="server" ID="HiddenField7" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblcreateshortcut" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popcreateshortcut" runat="server" TargetControlID="lblcreateshortcut"
                PopupControlID="pnlcreateshortcut" BackgroundCssClass="modal" BehaviorID="createshortcut"
                CancelControlID="imgclose">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlcreateshortcut" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="80%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="left">
                                <div class="pageheading">
                                    &nbsp; Create Shortcut
                                </div>
                            </td>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imgclose" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid" style="padding: 5px; text-align: center;">
                                <div style="text-align: center;">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Font-Names="arial" Font-Size="14px"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <iframe src="../../ProfileIframes/UrlShortCut.aspx" frameborder="0" scrolling="no"
                                    height="100%" width="100%" style="border: 0px;" id="frmShortcut"></iframe>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
