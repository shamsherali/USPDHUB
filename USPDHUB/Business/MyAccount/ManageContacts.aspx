<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" Inherits="Business_MyAccount_ManageContacts"
    EnableEventValidation="false" ValidateRequest="false" CodeBehind="ManageContacts.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="all" href="../../css/styles.css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-bubble-popup-v3.min.js" type="text/javascript"></script>
    <link href="../../css/accordion/jquery.ui.base.css" rel="stylesheet" type="text/css" />
    <link href="../../css/accordion/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-bubble-popup-v3.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.min.js"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: '<p style="line-height:18px; text-align:left; font-size:14px;">If you have multiple Private Buttons and you have individuals <br/> that are normally included in more than one Private Button, <br/>they may be entered as Common Contacts.</p><br/><p style="line-height:18px; text-align:left; font-size:14px;">"Common" group is set up automatically by the system. <br/>The entry of contact information in this group makes them<br/> available to all private groups when you prepare to send<br/> invitations to view the Private Buttons on their phones.</p>',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
        });
        function change(obj) {
            document.getElementById('<%= hdncheck.ClientID %>').value = "1";
        }
        function ConfirmUpdate(frm) {

            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("CheckBox1") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {

                        if (document.getElementById('<%= hdncheck.ClientID %>').value == "") {
                            alert('Please change at least one contact group to update');
                            return false;
                        }
                        else
                            return confirm('Are you sure you want to update your selection(s)?');
                    }
                }
            }
            alert('Please select at least one checkbox to update.');
            return false

        }
        function confirmDeleteDuplicate(frm) {
            // loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("CheckBox1") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        return confirm('Are you sure you want to delete your selection(s)?')
                    }
                }
            }
            alert('Please select at least one checkbox to delete');
            return false
        }
    </script>
    <div id="TipLayer" style="visibility: hidden; position: absolute; z-index: 1000;
        top: -100">
    </div>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/main.js")%>"
        type="text/javascript"></script>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/dashboardstyle.js")%>"
        type="text/javascript"></script>
    <script type="text/javascript">
        function HideValue(ID) {
            ID.title = '';
        }      
    </script>
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: '<p style="line-height:18px; text-align:left; font-size:14px;">If you have multiple Private Buttons and you have individuals <br/> that are normally included in more than one Private Button, <br/>they may be entered as Common Contacts.</p><br/><p style="line-height:18px; text-align:left; font-size:14px;">"Common" group is set up automatically by the system. <br/>The entry of contact information in this group makes them<br/> available to all private groups when you prepare to send<br/> invitations to view the Private Buttons on their phones.</p>',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
        });

    </script>
    <script language="javascript" type="text/javascript">
        function confirmDelete(frm) {
            // loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("chkcontact") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        return confirm('Are you sure you want to delete your selection(s)?')
                    }
                }
            }
            alert('Please select at least one contact to delete');
            return false
        }

        function confirmexport(frm) {
            // loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("chkcontact") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        return confirm('Are you sure you want to export your contacts?');
                    }
                }
            }
            alert('Please select at least one contact to export.');
            return false
        }

        function ConfirmGroupDelete() {
            var GroupValue = document.getElementById('<%= hdnGroupID.ClientID %>').value;
            if (GroupValue != "") {
                if (GroupValue != "1" & GroupValue != "13" & GroupValue != "14" & GroupValue != "0") {
                    if (document.getElementById('<%=hdnCheckContactCount.ClientID %>').value != "") {
                        return confirm('Deleting this group will also delete the associated contacts. Do you want to continue?');
                    }
                    else {
                        return confirm('Are you sure you want to delete the selected group?');
                    }
                }
                else {
                    alert('You cannot delete System groups.');
                    return false;
                }
            }
            else {
                alert('Please select a group to delete.');
                return false;
            }
        }

        function CheckEditBuiltin() {

            var GroupValue = document.getElementById('<%= hdnGroupID.ClientID %>').value;
            if (document.getElementById('<%=txtcontactgroupname.ClientID %>').value != "") {
                if (GroupValue != "") {
                    if (GroupValue != "1" & GroupValue != "13" & GroupValue != "14" & GroupValue != "0") {
                        if (document.getElementById('<%=txtcontactgroupname.ClientID %>').value != "") {
                            return true
                        }
                        alert('Group name is mandatory.');
                        return false
                    }
                    else {
                        alert('You cannot edit System groups.');
                        return false;
                    }
                }
                return true;
            }
            alert('Group Name is mandatory.');
            return false;

        }

        function confirmmove(frm) {
            if (document.getElementById('<%=DDLMovingGroup.ClientID %>').value != "") {
                if (document.getElementById('<%=DDLMovingGroup.ClientID %>').value != document.getElementById('<%=hdnGroupID.ClientID %>').value) {
                    // loop through all elements
                    for (i = 0; i < frm.length; i++) {
                        // Look for our checkboxes only
                        if (frm.elements[i].name.indexOf("chkcontact") != -1) {
                            // If any are checked then confirm alert, otherwise nothing happens
                            if (frm.elements[i].checked) {
                                return confirm('Are you sure you want to move your selection(s)?')
                            }
                        }
                    }
                    alert('Please select at least one contact to move.');
                    return false
                }
                else {
                    alert('You cannot move the contacts to the same group.');
                    return false
                }
            }
            else {
                alert('Please select a group to move.');
                return false
            }
        }

        function SetEnd(TB) {
            if (TB.createTextRange) {
                var FieldRange = TB.createTextRange();
                FieldRange.moveStart('character', TB.value.length);
                FieldRange.collapse();
                FieldRange.select();
            }
        }

        function checkdata() {
            if (document.getElementById('<%=txtSearchContact.ClientID %>').value != "") {
                return true;
            }
            else {
                alert('Please enter keyword to search.');
                return false;
            }
        }

    
    </script>
    <script type="text/javascript">
        function FormatPhoneNumber(id, event, Vtype) {
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
            val = id.value.replace(/\D/g, '');
            var newVal = '';
            if (val.length > 10) {
                val = val.substring(0, 10)
            }
            while (val.length >= 3 && newVal.length <= 7) {
                newVal += val.substr(0, 3) + '-';
                val = val.substr(3);
            }
            newVal += val;
            id.value = newVal;
            if (newVal.length == 12) {
                if (newVal.length == 12) {
                    window.setTimeout(function () { id.focus(); }, 0);
                }
                if (Vtype == "3") {
                    document.getElementById('<%=trMobile.ClientID %>').style.display = "none";
                }
            }
            else {

                if (Vtype == "3") {
                    document.getElementById('<%=trMobile.ClientID %>').style.display = "none";

                }

            }
        }
    </script>
    <script language="javascript" type="text/javascript">

        function setScroll(val) {
            document.getElementById("<%=scrollPos.ClientID %>").value = val.scrollTop;
        }
        function scrollTo(what) {
            //$("#<%=lnkgroupAll.ClientID %>").css("display", "none");
            document.getElementById("<%=mycustomscroll.ClientID %>").scrollTop = document.getElementById("<%=scrollPos.ClientID %>").value;
        }

    </script>
    <style type="text/css">
        .infoinput
        {
            width: 150px;
        }
    </style>
    <asp:UpdatePanel ID="uppnlpopup" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0"
                style="background: none;">
                <tbody>
                    <tr>
                        <td>
                            <!-- Issue 852 added panel(pnl) to fix this issue-->
                            <asp:Panel ID="pnl" runat="server" DefaultButton="btnsearch">
                                <table class="profile-1stlevel" cellspacing="0" cellpadding="0" width="100%" border="0"
                                    <%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                      { %> style="padding-left: 0px;" <%} %>>
                                    <tbody>
                                        <tr>
                                            <td valign="top" width="300px;" style="text-decoration: none; text-align: left;">
                                                <font <%if (Convert.ToBoolean(hdnIsPrivateModule.Value) == false)
                                                                      { %> color="green">Manage<%}
    else
    { %>color="#FF9900;"><img src="../../Images/Dashboard/lock.png" width="25" height="25" />
                                                    Private Module<%} %>&nbsp Contacts - 
                                                    <asp:Label ID="lblButtonName" runat="server"></asp:Label></font>
                                                <asp:HiddenField ID="hdnIsPrivateModule" runat="server" Value="false" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td align="center" style="color: Red; font-size: 14px; font-weight: bold;">
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                                        size="2">Processing....</font></b></ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:Label ID="lblnoduplicatescont" runat="server"></asp:Label>
                                            <asp:Label ID="lblMoveMessage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td align="center" <%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                      { %>style="background-color: #f5f5f5; padding-bottom: 15px;"
                                            <%} %>>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="page-width">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                                                            <colgroup>
                                                                <col width="204px" />
                                                                <col width="5px" />
                                                                <col width="270px" />
                                                                <col width="5px" />
                                                                <col width="*" />
                                                            </colgroup>
                                                            <tr>
                                                                <td colspan="5" align="right">
                                                                    <%if (Convert.ToBoolean(hdnIsPrivateModule.Value) == false)
                                                                      { %>
                                                                    <asp:Button ID="lnkImportContactsmore" runat="server" Text="Import Contacts" OnClick="lnkImportContacts_Click"
                                                                        CssClass="mailbtn" UseSubmitBehavior="false" />
                                                                    <a href="javascript:ModalHelpPopup('Import Contacts Using CSV Files',143,'');">
                                                                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a><%} %>&nbsp;<asp:Button
                                                                            ID="btnduplicate" runat="server" Text="Manage Duplicates" CssClass="mailbtn"
                                                                            OnClick="btnduplicate_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <table border="0" cellpadding="0" cellspacing="0" class="mailtbl" width="100%">
                                                                        <tr>
                                                                            <td class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>ContactStepHeaderP<%} else{ %>ContactStepHeader<%} %>">
                                                                                Step 1: Select a group
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>headingP<%} else { %>heading<%} %>">
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="1">
                                                                                    <tr>
                                                                                        <td style="padding-right: 45px;">
                                                                                            Groups
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <%if (Convert.ToBoolean(hdnIsPrivateModule.Value) == false)
                                                                                              { %>
                                                                                            <asp:Button ID="btnAddGroup" runat="server" CausesValidation="false" CssClass="mailbtn"
                                                                                                OnClick="btnAddGroup_Click" Text="Add Group" />
                                                                                            <%} %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td <%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                      { %>style="background-color: #CCFFFF;" <%} %>="" class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>borderP<%} else{ %>border<%} %>">
                                                                                <div id="mycustomscroll" class="flexcroll" style="height: 384px; width: 204px; overflow: scroll;
                                                                                    overflow-x: hidden;">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" style="padding: 5px;" width="100%">
                                                                                        <tr>
                                                                                            <td style="padding-left: 8px;">
                                                                                                <asp:LinkButton ID="lnkgroupAll" runat="server" CommandArgument="ALL" CssClass="groupslink"
                                                                                                    OnClick="lnkgroup_Click" Style="display: block;" Text="All"></asp:LinkButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <%if (Convert.ToBoolean(hdnIsPrivateModule.Value) == false)
                                                                                                  { %>
                                                                                                <asp:GridView ID="GrdBuiltinGroups" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                                                    BorderWidth="0" DataKeyNames="Contact_Group_ID" GridLines="None" PageSize="500"
                                                                                                    Width="100%">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderStyle-CssClass="groupshead" HeaderText="System Groups">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGType" runat="server" Text='<%#Eval("GroupType") %>' Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblIsMasterGroup" runat="server" Text='<%#Eval("IsMasterGroup") %>'
                                                                                                                    Visible="false"></asp:Label>
                                                                                                                <asp:LinkButton ID="lnkgroup" runat="server" CommandArgument='<%#Eval("Contact_Group_ID") %>'
                                                                                                                    CssClass="groupslink" OnClick="lnkgroup_Click" onmouseover="HideValue(this)"
                                                                                                                    Text='<%#Eval("Contact_Group_name") %>' ToolTip='<%#Eval("CID") %>'></asp:LinkButton>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                                <%} %>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <%if (Convert.ToBoolean(hdnIsPrivateModule.Value) == false)
                                                                                                  { %>
                                                                                                <asp:GridView ID="dgContactGroups" runat="server" AutoGenerateColumns="False" BorderWidth="0"
                                                                                                    DataKeyNames="Contact_Group_ID,GroupType" GridLines="None" Width="100%">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderStyle-CssClass="groupshead" HeaderText="Custom Groups">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGType" runat="server" Text='<%#Eval("GroupType") %>' Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblIsMasterGroup" runat="server" Text='<%#Eval("IsMasterGroup") %>'
                                                                                                                    Visible="false"></asp:Label>
                                                                                                                <asp:LinkButton ID="lnkgroup" runat="server" CommandArgument='<%#Eval("Contact_Group_ID") %>'
                                                                                                                    CssClass="groupslink" OnClick="lnkgroup_Click" onmouseover="HideValue(this)"
                                                                                                                    Text='<%#Eval("Contact_Group_name") %>' ToolTip='<%#Eval("CID") %>'></asp:LinkButton>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                                <%} %>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>
                                                                                                <asp:GridView ID="dgPrivateModuleGroup" runat="server" AutoGenerateColumns="False"
                                                                                                    BorderWidth="0" DataKeyNames="Contact_Group_ID,GroupType" GridLines="None" Width="100%">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderStyle-CssClass="groupsheadP" HeaderText="Private Module Groups&lt;span style=&quot;margin-left:10px; padding-top:10px;&quot;&gt;&lt;a href=&quot;#&quot;&gt;&lt;img id=&quot;help1&quot; src=&quot;../../images/Dashboard/new.png&quot; /&gt;&lt;/a&gt;&lt;/span&gt;">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblGType" runat="server" Text='<%#Eval("GroupType") %>' Visible="false"></asp:Label>
                                                                                                                <asp:Label ID="lblIsMasterGroup" runat="server" Text='<%#Eval("IsMasterGroup") %>'
                                                                                                                    Visible="false"></asp:Label>
                                                                                                                <asp:LinkButton ID="lnkgroup" runat="server" CommandArgument='<%#Eval("Contact_Group_ID") %>'
                                                                                                                    CssClass="groupslink" OnClick="lnkgroup_Click" onmouseover="HideValue(this)"
                                                                                                                    Text='<%#Eval("Contact_Group_name") %>' ToolTip='<%#Eval("CID") %>'></asp:LinkButton>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                                <%} %>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td valign="top">
                                                                    <table border="0" cellpadding="0" cellspacing="0" class="mailtbl" width="100%">
                                                                        <tr>
                                                                            <td class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>ContactStepHeaderP<%} else{ %>ContactStepHeader<%} %>">
                                                                                Step 2: Select one or more contacts
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>headingP<%} else { %>heading<%} %>">
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="1">
                                                                                    <tr>
                                                                                        <td style="padding-right: 90px;">
                                                                                            Contacts
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnPnlCAddContact" runat="server" CausesValidation="false" CssClass="mailbtn"
                                                                                                OnClick="btnAddContact_Click" Text="Add Contact" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <input id="scrollPos" runat="server" type="hidden" value="0" />
                                                                            <td class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>borderP<%} else{ %>border<%} %>">
                                                                                <table border="0" cellpadding="0" cellspacing="0" class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>seachareaP<%} else{ %>seacharea<%} %>" width="100%">
                                                                                    <tr>
                                                                                        <td style="padding-top: 10px; padding-bottom: 10px;">
                                                                                            <strong style="padding-left: 5px; width: 70px;">Contact Search:</strong>&nbsp;&nbsp;<asp:TextBox
                                                                                                ID="txtSearchContact" runat="server" Style="margin-left: 8px;" Width="100px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="padding-right: 5px;">
                                                                                            <asp:Button ID="btnsearch" runat="server" CssClass="seachareabtn" OnClick="btnsearch_Click"
                                                                                                OnClientClick="return checkdata()" Text="GO" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="height: 38px; display: none;">
                                                                                        <td style="padding-top: 10px; padding-bottom: 10px;">
                                                                                            <strong style="padding-left: 5px; width: 70px;">Contact Move to:</strong>&nbsp;&nbsp;
                                                                                            <asp:DropDownList ID="ddlGroup1" runat="server" ValidationGroup="C" Width="115px">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="padding-right: 5px;">
                                                                                            <asp:Button ID="btmMoveContact" runat="server" OnClick="btmMoveContact_OnClick" Style="border: 1px solid #ffc292;
                                                                                                font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold;
                                                                                                overflow: visible; background-color: #F0AC34;" Text="Move" Width="50px" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table <%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                      { %>style="background-color: #CCFFFF;" <%} %>="" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div id="mycustomscroll" runat="server" class="flexcroll Scroller" onscroll="javascript:setScroll(this);"
                                                                                                style="height: 340px; width: 290px; overflow: scroll;">
                                                                                                <div style="height: 5px;">
                                                                                                    &nbsp;</div>
                                                                                                <asp:Label ID="lblpageload" runat="server" nowrap="nowrap" Style="padding-left: 5px;
                                                                                                    padding-top: 10px;"></asp:Label>
                                                                                                <asp:GridView ID="grdusercontacts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                                                                                    BorderWidth="0" CssClass="Allleft" DataKeyNames="contactid" GridLines="None"
                                                                                                    OnPageIndexChanging="grdusercontacts_PageIndexChanging" PagerSettings-Position="TopAndBottom"
                                                                                                    PagerStyle-Width="30px" PageSize="500" Width="100%">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField>
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="True" CssClass="Allleft"
                                                                                                                    OnCheckedChanged="chkSelectAll_CheckedChanged" onclick="ProcessWaiting(this)"
                                                                                                                    Text="&lt;font style='color:#4BB4D2; font-size:13px; font-weight:bold;'&gt;All&lt;/font&gt;" />
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:CheckBox ID="chkcontact" runat="server" AutoPostBack="True" Checked='<%# Convert.ToBoolean(Convert.ToInt32(Eval("checkvalue").ToString())) %>'
                                                                                                                    OnCheckedChanged="chkcontact_CheckedChanged" onclick="ProcessWaiting(this)" onmouseover="HideValue(this)"
                                                                                                                    Text='<%# Eval("name") %>' ToolTip='<%# Eval("ContactID") %>' /><br />
                                                                                                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("email") %>' Style="padding-left: 21px;
                                                                                                                    font-size: 14px"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="itemcls" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <span style="padding-left: 5px;">No contacts found </span>
                                                                                                    </EmptyDataTemplate>
                                                                                                    <PagerStyle CssClass="PageContactManage" />
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>ContactStepHeaderP<%} else{ %>ContactStepHeader<%} %>">
                                                                                Step 3: Actions
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td <%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                      { %>style="background-color: #CCFFFF;" <%} %>="">
                                                                                <asp:Panel ID="PnlAddEditContacts" runat="server" Width="100%">
                                                                                    <table <%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                      { %>style="background-color: #CCFFFF;" <%} %>="" border="0" cellpadding="0" cellspacing="0" class="mailtbl"
                                                                                        width="100%">
                                                                                        <tr>
                                                                                            <td class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>border1P<%} else{ %>border1<%} %>">
                                                                                                <table border="0" cellpadding="0" cellspacing="0" class="mailcontent" width="100%">
                                                                                                    <tr>
                                                                                                        <td class="ContactEditInfo">
                                                                                                            Contact Information
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblerror" runat="server"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                                <colgroup>
                                                                                                                    <col width="28%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td align="center" colspan="2" style="padding-bottom: 10px;">
                                                                                                                        <asp:Label ID="lblContacts" runat="server"></asp:Label>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Contact Group:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:DropDownList ID="DDLContactGroups" runat="server" ValidationGroup="C" Width="155px">
                                                                                                                        </asp:DropDownList>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        First Name:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtFirstname" runat="server" CssClass="infoinput"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Last Name:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtLastname" runat="server" CssClass="infoinput"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Email:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="infoinput" ValidationGroup="C"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Company Name:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtcompanyname" runat="server" CssClass="infoinput" ValidationGroup="C"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Address:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="infoinput"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        City:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtCity" runat="server" CssClass="infoinput"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        State:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtState" runat="server" CssClass="infoinput"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Zip Code:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtZipcode" runat="server" CssClass="infoinput"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Landline:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="infoinput" MaxLength="12"></asp:TextBox>
                                                                                                                        &nbsp;(xxx-xxx-xxxx)
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Mobile:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="infoinput" MaxLength="12"></asp:TextBox>
                                                                                                                        &nbsp;(xxx-xxx-xxxx)
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr id="trMobile" runat="server" style="display: none">
                                                                                                                    <td colspan="2">
                                                                                                                        <table border="0" cellpadding="0" cellspacing="0" style="line-height: 115%; font-size: 13px;"
                                                                                                                            width="100%">
                                                                                                                            <colgroup>
                                                                                                                                <col width="10%" />
                                                                                                                                <col width="*" />
                                                                                                                            </colgroup>
                                                                                                                            <tr>
                                                                                                                                <td style="padding-top: 3px; padding-bottom: 5px;" valign="top">
                                                                                                                                    <asp:CheckBox ID="chkMobile" runat="server" Checked="true" />
                                                                                                                                </td>
                                                                                                                                <td style="padding-top: 5px; padding-bottom: 5px;">
                                                                                                                                    This contact has agreed to receive text messages.
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Fax:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtFax" runat="server" CssClass="infoinput" MaxLength="12"></asp:TextBox>
                                                                                                                        &nbsp;(xxx-xxx-xxxx)
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <%if (UpdateContact != "1")
                                                                                                              { %>
                                                                                                            <table border="0" cellpadding="0" cellspacing="0" style="line-height: 115%; font-size: 13px;"
                                                                                                                width="100%">
                                                                                                                <colgroup>
                                                                                                                    <col width="10%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td valign="top">
                                                                                                                        &nbsp;
                                                                                                                        <asp:CheckBox ID="chkauthorize" runat="server" />
                                                                                                                    </td>
                                                                                                                    <td style="padding-top: 3px;">
                                                                                                                        This contact has agreed to receive emails and SMS(text messages).
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <%} %>
                                                                                                            <table border="0" cellpadding="0" cellspacing="0" class="mailcontent" width="100%">
                                                                                                                <colgroup>
                                                                                                                    <col width="27%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td style="padding-top: 5px;">
                                                                                                                        <asp:Button ID="btnAddUpdateContact" runat="server" CssClass="mailbtn" OnClick="btnAddUpdateContact_Click"
                                                                                                                            OnClientClick="return CheckUserContactData()" ValidationGroup="C" />
                                                                                                                        &nbsp;
                                                                                                                        <asp:Button ID="btnDeleteaContact" runat="server" CssClass="mailbtn" OnClick="btnDeleteaContact_Click"
                                                                                                                            OnClientClick="return confirm('Are you sure you want to delete this contact?')"
                                                                                                                            Text="Delete Contact" />
                                                                                                                        &nbsp;
                                                                                                                        <%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                                          { %>
                                                                                                                        <input class="mailbtnP" type="button" value="Cancel" onclick="ResetContactData();" />
                                                                                                                        <%}
                                                                                                                          else
                                                                                                                          {%>
                                                                                                                        <input class="mailbtn" type="button" value="Cancel" onclick="ResetContactData();" />
                                                                                                                        <%} %>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="PnlAddEditGroups" runat="server" Width="100%">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" class="mailtbl" width="100%">
                                                                                        <tr>
                                                                                            <td class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>border1P<%} else{ %>border1<%} %>">
                                                                                                <table border="0" cellpadding="0" cellspacing="0" class="mailcontent" width="100%">
                                                                                                    <tr>
                                                                                                        <td class="ContactEditInfo">
                                                                                                            Contact Group Information <a id="Anchor" href="javascript:ModalHelpPopup('Add Group',141,'');">
                                                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" />
                                                                                                            </a>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <table border="0" cellpadding="0" cellspacing="0" class="mailcontent" width="100%">
                                                                                                                <colgroup>
                                                                                                                    <col width="30%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td align="center" colspan="2" style="padding-bottom: 10px;">
                                                                                                                        <asp:Label ID="lblgroupName" runat="server"></asp:Label>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td valign="top">
                                                                                                                        Group Name:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtcontactgroupname" runat="server" MaxLength="15" Width="120px"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="padding-top: 10px;" valign="top">
                                                                                                                        Group Description:
                                                                                                                    </td>
                                                                                                                    <td style="padding-top: 10px;">
                                                                                                                        <asp:TextBox ID="txtcontactgroupdes" runat="server" Height="50px" MaxLength="300"
                                                                                                                            Style="resize: none;" TextMode="MultiLine" Width="210px"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="padding-top: 10px;">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td style="padding-top: 10px;">
                                                                                                                        <asp:Button ID="btnAddEditContactGroup" runat="server" CssClass="mailbtn" OnClick="btnAddEditContactGroup_Click"
                                                                                                                            OnClientClick="return CheckEditBuiltin()" ValidationGroup="C" />
                                                                                                                        &nbsp;
                                                                                                                        <asp:Button ID="btnDeleteGroup" runat="server" CssClass="mailbtn" OnClick="btnDeleteGroup_Click"
                                                                                                                            OnClientClick="return ConfirmGroupDelete()" Text="Delete Group" />
                                                                                                                        &nbsp;
                                                                                                                        <%if (hdnGroupID.Value != "1" & hdnGroupID.Value != "13" & hdnGroupID.Value != "14" & hdnGroupID.Value != "0" & txtcontactgroupname.Text != System.Configuration.ConfigurationManager.AppSettings.Get("ReportsInquiryGroupName"))
                                                                                                                          { %>
                                                                                                                        <%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                                          { %>
                                                                                                                        <input class="mailbtnP" type="button" value="Cancel" onclick="ResetGroupData();" />
                                                                                                                        <%}
                                                                                                                          else
                                                                                                                          { %>
                                                                                                                        <input class="mailbtn" type="button" value="Cancel" onclick="ResetGroupData();" />
                                                                                                                        <%} %><%} %>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="PnlMoreContacts" runat="server" Width="100%">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" class="mailtbl" width="100%">
                                                                                        <tr>
                                                                                            <td class="<%if (Convert.ToBoolean(hdnIsPrivateModule.Value))
                                                                                                  { %>border1P<%} else{ %>border1<%} %>">
                                                                                                <table border="0" cellpadding="0" cellspacing="0" class="mailcontent" width="100%">
                                                                                                    <tr>
                                                                                                        <td class="ContactEditInfo">
                                                                                                            <asp:Label ID="lblheadingmoreconatacts" runat="server"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblmore" runat="server" Style="padding-bottom: 10px;"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <table border="0" cellpadding="0" cellspacing="0" class="mailcontent" width="100%">
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <asp:Label ID="lblmorecontacts" runat="server" CssClass="contactlabel"></asp:Label>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Panel ID="PnlActions" runat="server">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" class="mailcontent" width="100%">
                                                                                                                    <colgroup>
                                                                                                                        <col width="28%" />
                                                                                                                        <col width="*" />
                                                                                                                    </colgroup>
                                                                                                                    <tr>
                                                                                                                        <td valign="top">
                                                                                                                            Delete Contacts:
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:Button ID="BtnDeleteContacts" runat="server" CssClass="mailbtn" OnClick="BtnDeleteContacts_Click"
                                                                                                                                OnClientClick="return confirmDelete (this.form)" Text="Delete Contacts" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td style="padding-top: 10px;" valign="top">
                                                                                                                            Move Contacts to:
                                                                                                                        </td>
                                                                                                                        <td style="padding-top: 10px;">
                                                                                                                            <asp:DropDownList ID="DDLMovingGroup" runat="server" CssClass="contactmovelist" ValidationGroup="M">
                                                                                                                            </asp:DropDownList>
                                                                                                                            <asp:RequiredFieldValidator ID="reqMovinggroup" runat="server" ControlToValidate="DDLMovingGroup"
                                                                                                                                InitialValue="0" ValidationGroup="M">*</asp:RequiredFieldValidator>
                                                                                                                            &nbsp;
                                                                                                                            <asp:Button ID="btnMoveGroupContacts" runat="server" CssClass="mailbtn" OnClick="btnMoveGroupContacts_Click"
                                                                                                                                OnClientClick="return confirmmove (this.form)" Text="Move" ValidationGroup="M" />
                                                                                                                            <a href="javascript:ModalHelpPopup('Move Contacts to a Different Group',144,'');">
                                                                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" />
                                                                                                                            </a>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td style="padding-top: 10px;">
                                                                                                                            Export Contacts:
                                                                                                                        </td>
                                                                                                                        <td style="padding-top: 10px;">
                                                                                                                            <asp:Button ID="lnkExport" runat="server" CssClass="mailbtn" OnClick="BtnExportContacts_Click"
                                                                                                                                OnClientClick="return confirmexport (this.form) " Text="Export" />
                                                                                                                            <a href="javascript:ModalHelpPopup('Export Contacts to Excel',142,'');">
                                                                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" />
                                                                                                                            </a>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </asp:Panel>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:Label ID="lblas" runat="server"></asp:Label>
                                                                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modal"
                                                                        PopupControlID="pnlpopup" TargetControlID="lblas">
                                                                    </cc1:ModalPopupExtender>
                                                                    <asp:Panel ID="pnlpopup" runat="server" Style="display: none;" Width="60%">
                                                                        <table cellpadding="0" cellspacing="0" class="popuptable" style="border: 1px solid #23c0ef;"
                                                                            width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <asp:LinkButton ID="lnkclose" runat="server" OnClick="lnkclose_Click" OnClientClick="return CheckPopupChange()"><img src="../../images/popup_close.gif" alt="" /></asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="padding-bottom: 20px;">
                                                                                        <font color="green" size="4px"><b>Duplicate contacts</b></font>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                                                            <ProgressTemplate>
                                                                                                <img src="../../images/popup_ajax-loader.gif" border="0" />
                                                                                                <b><font color="green">Processing....</font></b>
                                                                                            </ProgressTemplate>
                                                                                        </asp:UpdateProgress>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" style="padding-bottom: 10px;">
                                                                                        <asp:Label ID="lblcmessage" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #23c0ef;"
                                                                                            width="100%">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div style="height: 500px; overflow-y: scroll; overflow-x: none">
                                                                                                        <asp:GridView ID="Grdduplicate" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                                                                                                            CssClass="datagrid2" DataKeyNames="ContactID" OnRowDataBound="Grdduplicate_RowDataBound"
                                                                                                            PageSize="10" Width="100%">
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField>
                                                                                                                    <ItemStyle CssClass="align-center" Width="85px" />
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:BoundField DataField="Firstname" HeaderText="First Name" />
                                                                                                                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                                                                                                <asp:BoundField DataField="Email" HeaderText="Email ID" />
                                                                                                                <asp:TemplateField HeaderText="Group Name ">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblIsPrivate" runat="server" Text='<%# Bind("GroupType") %>' Visible="false"></asp:Label>
                                                                                                                        <asp:Label ID="lblcontactgroupID" runat="server" Text='<%# Bind("Contact_Group_Name") %>'></asp:Label>
                                                                                                                        <asp:DropDownList ID="ddlCGroup" runat="server" onchange="change(this)">
                                                                                                                        </asp:DropDownList>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField Visible="false">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblcheckvalue" runat="server" Text='<%# Bind("checkvalue") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField Visible="false">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="lblcontactID" runat="server" Text='<%# Bind("ContactID") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                            <EmptyDataTemplate>
                                                                                                                <span style="padding-left: 5px;">No duplicate contacts. </span>
                                                                                                            </EmptyDataTemplate>
                                                                                                            <HeaderStyle CssClass="title1" />
                                                                                                        </asp:GridView>
                                                                                                        <div id="dvPaging" runat="server">
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" style="padding-top: 10px;">
                                                                                        <asp:HiddenField ID="hdncheck" runat="server" />
                                                                                        <asp:Button ID="btndelete" runat="server" CssClass="mailbtn" OnClick="btndelete_Click"
                                                                                            OnClientClick="return confirmDeleteDuplicate (this.form)" Text="Delete" />
                                                                                        <asp:Button ID="btnupdate" runat="server" CssClass="mailbtn" OnClick="btnupdate_Click"
                                                                                            OnClientClick="return ConfirmUpdate(this.form)" Text="Update" />
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table align="center" border="0" cellpadding="0" cellspacing="0" class="profile-btntbl"
                                                width="93%">
                                                <tbody>
                                                    <tr>
                                                        <td class="align-center">
                                                            <% if (Convert.ToBoolean(hdnIsPrivateModule.Value) == true)
                                                               { %>
                                                            <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click"  style="margin-right:30px;"/>
                                                            <%} %>
                                                            <asp:Button ID="btndashboard" runat="server" CausesValidation="false" OnClick="btndashboard_Click"
                                                                Text="Dashboard" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdnContactID" runat="server" />
                                <asp:HiddenField ID="hdnGroupID" runat="server" />
                                <asp:HiddenField ID="hdnGroupprimarykey" runat="server" />
                                <asp:HiddenField ID="hdnGroupName" runat="server" />
                                <asp:HiddenField ID="hdnCheckContactCount" runat="server" />
                                <asp:HiddenField ID="hdnSearchText" runat="server" />
                                <asp:HiddenField ID="hdncheckchange" runat="server" />
                                <asp:HiddenField ID="hdnPrevPg" Value="1" runat="server" />
                                <asp:HiddenField ID="hdnCurPg" Value="1" runat="server" />
                                <asp:HiddenField ID="hdnreset" runat="server" />
                                <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                <asp:HiddenField ID="hdnGroupType" runat="server" />
                                <asp:HiddenField ID="hdnIsMasterGroup" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkExport" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function CheckUserContactData() {

            if (document.getElementById('<%=DDLContactGroups.ClientID %>').value != "" && document.getElementById('<%=DDLContactGroups.ClientID %>').value != "0") {

                if (document.getElementById("<%= btnAddUpdateContact.ClientID %>").value == 'Add') {

                    if ((document.getElementById('<%=txtEmail.ClientID %>').value != "") && (document.getElementById('<%=chkauthorize.ClientID%>').checked == true)) {
                        if ((document.getElementById('<%=txtMobile.ClientID %>').value != "") || (document.getElementById('<%=txtFax.ClientID %>').value != "") || (document.getElementById('<%=txtPhone.ClientID %>').value != "")) {
                            var errmsg = "";
                            if ((!(document.getElementById('<%=txtPhone.ClientID %>').value.length == 12)) && document.getElementById('<%=txtPhone.ClientID %>').value != "") {
                                errmsg += "Enter a Valid Land line Number.\n";
                            }
                            if ((!(document.getElementById('<%=txtMobile.ClientID %>').value.length == 12)) && document.getElementById('<%=txtMobile.ClientID %>').value != "") {
                                errmsg += "Enter a Valid Mobile Number.\n";
                            }
                            if ((!(document.getElementById('<%=txtFax.ClientID %>').value.length == 12)) && document.getElementById('<%=txtFax.ClientID %>').value != "") {
                                errmsg += "Enter a Valid Fax Number.";
                            }
                            if (errmsg == "") {
                            }
                            else {
                                alert(errmsg);
                                return false;
                            }
                        }


                        else if ((document.getElementById('<%=hdnIsPrivateModule.ClientID %>').value == "true") && (document.getElementById('<%=txtMobile.ClientID %>').value == "")) {
                            alert('Mobile Number is mandatory.')
                            return false;
                        }
                        //                        if ((document.getElementById('<%=txtMobile.ClientID %>').value != "") && (document.getElementById('<%=chkMobile.ClientID%>').checked == true)) {
                        //                            return true
                        //                        }
                        //                        else if ((document.getElementById('<%=txtMobile.ClientID %>').value != "") && (document.getElementById('<%=chkMobile.ClientID%>').checked == false)) {
                        //                            alert('Please select the first check box to import mobile number in to your contacts list.')
                        //                            return false;
                        //                        }
                        //                        else
                        return true;
                    }
                    else if ((document.getElementById('<%=txtEmail.ClientID %>').value != "") && (document.getElementById('<%=chkauthorize.ClientID%>').checked == false)) {
                        if (document.getElementById('<%=hdnIsPrivateModule.ClientID %>').value == "false") {
                            alert('Please check the box above the Add button to include this contact.');
                            return false;
                        }
                        else {
                            if (document.getElementById('<%=txtMobile.ClientID %>').value != "") {
                                if ((!(document.getElementById('<%=txtMobile.ClientID %>').value.length == 12))) {
                                    alert('Please enter valid mobile number.');
                                    return false;

                                }
                                else {
                                    alert('Please check the box above the Add button to include this contact.');
                                    return false;
                                }
                            }
                            else {
                                alert('Mobile Number is mandatory.')
                                return false;
                            }
                        }

                    }
                    else {
                        alert('Email Address is mandatory.');
                        return false
                    }
                }

            }
            else {
                if (document.getElementById('<%=DDLContactGroups.ClientID %>').value == "0")
                    alert('You cannot add a contact to Opt-out. Please select another group.');
                else
                    alert('Group name is mandatory.');
                return false
            }
            if (document.getElementById("<%= btnAddUpdateContact.ClientID %>").value == 'Update') {
                if (document.getElementById('<%=txtEmail.ClientID %>').value == "") {
                    alert('Email Address is mandatory.');
                    return false;
                }
                if (document.getElementById('<%=hdnIsPrivateModule.ClientID %>').value == "true") {
                    if (document.getElementById('<%=txtMobile.ClientID %>').value == "") {
                        alert('Mobile Number is mandatory.')
                        return false;
                    }
                    if ((!(document.getElementById('<%=txtMobile.ClientID %>').value.length == 12)) && document.getElementById('<%=txtMobile.ClientID %>').value != "") {
                        alert('Please enter valid mobile number.');
                        return false;
                    }
                }
            }
        }

        //        function CheckPhoneOrFax(CID, Vtype) {
        //            if (CID.value != "") {
        //                var no = /^[0-9]\d{2}-\d{3}-\d{4}$/;
        //                if (!no.test(CID.value)) {
        //                    if (Vtype == "1") {
        //                        document.getElementById('<%=txtPhone.ClientID %>').value = "";
        //                        alert("Please enter valid phone number.");
        //                    }
        //                    if (Vtype == "2") {
        //                        document.getElementById('<%=txtFax.ClientID %>').value = "";
        //                        alert("Please enter valid fax number.");
        //                    }
        //                    if (Vtype == "3") {
        //                        document.getElementById('<%=txtMobile.ClientID %>').value = "";
        //                        alert("Please enter valid mobile number.");
        //                    }
        //                    window.setTimeout(function () { CID.focus(); }, 0);
        //                }
        //                else {
        //                    if (Vtype == "3") {
        //                        document.getElementById('<%=trMobile.ClientID %>').style.display = "";
        //                    }
        //                }

        //            }
        //            else {
        //                if (Vtype == "3") {
        //                    document.getElementById('<%=trMobile.ClientID %>').style.display = "none";
        //                }
        //            }
        //        }
        function ShowDiv() {
            if (document.getElementById('<%=trMobile.ClientID %>') != null)
                document.getElementById('<%=trMobile.ClientID %>').style.display = "none";
        }
        function CheckZipCode(ZID) {
            if (ZID.value != "") {
                var no = /(^\d{5}$)/;
                if (!no.test(ZID.value)) {
                    document.getElementById('<%=txtZipcode.ClientID %>').value = "";
                    alert("Please enter valid zip code.");
                    window.setTimeout(function () { ZID.focus(); }, 0);
                }
            }
        }
        function CheckEmailID(EID) {
            if (EID.value != "") {
                var no = /(\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)/;
                if (!no.test(EID.value)) {
                    document.getElementById('<%=txtEmail.ClientID %>').value = "";
                    alert("Please enter valid email address.");
                    window.setTimeout(function () { EID.focus(); }, 0);
                }
            }
        }


        function CheckPopupChange() {
            if (document.getElementById('<%=hdncheckchange.ClientID %>').value != '') {
                document.getElementById('<%=hdncheckchange.ClientID %>').value = '';
                return true;
            }
            else {
                document.getElementById('<%=hdncheckchange.ClientID %>').value = '';
                var modalPopupBehaviorCtrl = $find('<%=ModalPopupExtender1.ClientID %>');
                modalPopupBehaviorCtrl.hide();
                return false;
            }
        }

        function ProcessWaiting(ctrl) {

            //       var i ;
            //       document.getElementById('ctl00_cphUser_grdusercontacts_ctl02_chkSelectAll').disabled = true;
            //       for (i = 1; i < document.getElementById('ctl00_cphUser_grdusercontacts').getElementsByTagName('input').length; i++) {

            //           if (document.getElementById('ctl00_cphUser_grdusercontacts').getElementsByTagName('input')[i].id != ctrl.id)
            //               document.getElementById('ctl00_cphUser_grdusercontacts').getElementsByTagName('input')[i].disabled = true;
            //       }
        }

    </script>
    <script type="text/javascript">
        function ResetContactData() {
            var serverVariable = document.getElementById('<%=hdnreset.ClientID %>').value;
            if (serverVariable != "") {
                var SplitString = serverVariable.split(',|');
                document.getElementById('<%=DDLContactGroups.ClientID %>').selectedIndex = SplitString[11];
                document.getElementById('<%=txtFirstname.ClientID %>').value = SplitString[0];
                document.getElementById('<%=txtLastname.ClientID %>').value = SplitString[1];
                document.getElementById('<%=txtEmail.ClientID %>').value = SplitString[2];
                document.getElementById('<%=txtcompanyname.ClientID %>').value = SplitString[3];
                document.getElementById('<%=txtAddress.ClientID %>').value = SplitString[4];
                document.getElementById('<%=txtCity.ClientID %>').value = SplitString[5];
                document.getElementById('<%=txtState.ClientID %>').value = SplitString[6];
                document.getElementById('<%=txtZipcode.ClientID %>').value = SplitString[7];
                document.getElementById('<%=txtPhone.ClientID %>').value = SplitString[8];
                document.getElementById('<%=txtFax.ClientID %>').value = SplitString[9];
                document.getElementById('<%=txtMobile.ClientID %>').value = SplitString[10];
            }
        }
        function ResetGroupData() {
            var serverVariable = document.getElementById('<%=hdnreset.ClientID %>').value;
            if (serverVariable != "") {
                var SplitString = serverVariable.split(',');
                document.getElementById('<%=txtcontactgroupname.ClientID %>').value = SplitString[0];
                document.getElementById('<%=txtcontactgroupdes.ClientID %>').value = SplitString[1];
            }
        }

    
    </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: Green;">
                Manage Contacts
            </div>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
