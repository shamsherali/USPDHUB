<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" Inherits="Business_MyAccount_ImportContacts"
    CodeBehind="ImportContacts.aspx.cs" %>

<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WowAds.ascx" TagName="wowads" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <div id="TipLayer" style="visibility: hidden; position: absolute; z-index: 1000;
        top: -100">
    </div>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/main.js")%>"
        type="text/javascript"></script>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/dashboardstyle.js")%>"
        type="text/javascript"></script>
    <script type="text/javascript">
        function CheckChekBox(frm) {
            // loop through all elements
            // *** Issue 955 *** //
            var CheckedContacts = 0;
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("drplist") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].value > 0) {
                        // loop through all elements
                        for (i = 0; i < frm.length; i++) {
                            // Look for our checkboxes only
                            if (frm.elements[i].name.indexOf("CheckBox1") != -1) {
                                // If any are checked then confirm alert, otherwise nothing happens
                                if (frm.elements[i].checked) {
                                    CheckedContacts = CheckedContacts + 1;
                                }
                            }
                        }
                    }
                }
            }
            // *** End Issue 955 *** //
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("drplist") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].value > 0) {

                        // loop through all elements
                        for (i = 0; i < frm.length; i++) {
                            // Look for our checkboxes only
                            if (frm.elements[i].name.indexOf("CheckBox1") != -1) {
                                // If any are checked then confirm alert, otherwise nothing happens
                                if (frm.elements[i].checked) {
                                    //check if the permissions checkbox has been selected or not. If not, alert and return false.
                                    if (document.getElementById('<%=chkauthorize.ClientID%>').checked == true) {
                                        document.getElementById('<%=hdnContactscount.ClientID%>').value = CheckedContacts;
                                        return true;
                                    } else {
                                        alert("Please select the above checkbox to add these contacts to your contacts list.");
                                        return false;
                                    }
                                }
                            }
                        }
                        alert('Please select at least one checkbox to add contacts');
                        return false
                    }
                }
            }
            alert('Please select a group to add contacts');
            return false

        }
        function SelectGroup() {
            var ddlgroup = document.getElementById("<%=drpgroup.ClientID%>");
            if (ddlgroup.selectedIndex == 0) {
                alert('Please select a group to add contacts');
                return false;
            }
            else {
                if (document.getElementById('<%=chkauthorize.ClientID%>').checked == true) {
                    if (document.getElementById('<%=chkMobile.ClientID%>') != null) {
                        if (document.getElementById('<%=chkMobile.ClientID%>').checked == false) {
                            if (confirm("If you want to receive messages click on cancel and select the first check box."))
                                return true;
                            else
                                return false;
                        }
                    }
                } else {
                    alert("Please select the above checkbox to add these contacts to your contacts list.");
                    return false;
                }
            }
        }
        function validateName(id) {

            // loop through all elements
            var obj, Groupname, strlen, validChar;
            obj = document.getElementById(id);
            Groupname = obj.value;
            validChar = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890 ';

            strlen = Groupname.length;
            // Now scan string for illegal characters
            for (var i = 0; i < strlen; i++) {
                if (validChar.indexOf(Groupname.charAt(i)) < 0) {
                    alert("Group name cannot contain special characters.");
                    i = strlen;
                    obj.focus();
                }
            }
            // end scanning loop
        }
   
    </script>
    <script type="text/javascript">
        function checkSelects(value, index, obj) {
            var sels;
            var i;

            if (value != '------- Select Appropriate Item ------') {
                sels = document.getElementsByTagName('select');

                for (i = 0; i < sels.length; i++) {
                    if (i != index) {
                        if (sels[i].value == value) {
                            alert("This item has already been selected; please choose a different one.");
                            obj.selectedIndex = 0;
                            i = sels.length;
                        }
                    }
                }
            }
        }

    </script>
    <script type="text/javascript">
        function SelectAll(id) {
            var frm = document.forms[0];
            for (i = 0; i < frm.elements.length; i++) {

                if (frm.elements[i].type == "checkbox") {
                    if (frm.elements[i].id != "ctl00_cphUser_chkauthorize") {
                        frm.elements[i].checked = document.getElementById(id).checked;
                    }
                }
            }
        }
        function SelectCkhBox() {
            if (document.getElementById('<%=chkauthorize.ClientID%>').checked == true) {
                return true;
            }
            else {
                alert("Please select the above checkbox to add these contacts to your contacts list.");
                return false;
            }
        }
        function TABLE1_onclick() {

        }

    </script>
    <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td align="center">
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                        <ProgressTemplate>
                            <img src="../../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
        </tbody>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="inputtable nomargin-bottom" cellspacing="0" cellpadding="0" width="100%"
                border="0">
                <tbody>
                    <tr>
                        <td style="font-size: 18px; font-family: Georgia,Times New Roman; height: 32px; padding-left: 10px;">
                            <font color="green"><b>Import Contacts</b></font><asp:HiddenField ID="hdnContactscount"
                                runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdnGroupname" runat="server" />
                            <asp:HiddenField ID="hdnGroupsCount" runat="server" />
                            <asp:HiddenField ID="hdnIsPrivateModule" runat="server" Value="false" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblmess" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="30%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:ValidationSummary runat="server" ID="VSCsv" ValidationGroup="A" HeaderText="The following error occurred:" />
                                    </td>
                                </tr>
                            </table>
                            <table width="30%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:ValidationSummary ID="ContactsValidation" runat="server" HeaderText="The following error occurred:"
                                            ValidationGroup="g" />
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
                        <td style="padding-top: 10px">
                            <asp:Panel ID="pnl1" runat="server">
                                <table width="580" align="center" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <table align="center" border="0" width="620" cellspacing="0" cellpadding="0">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:Panel ID="pnlcsvservice" runat="server">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-color: #f3f8fd;
                                                                        height: 140px;">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="center" style="font-size: 18px; color: green" colspan="2">
                                                                                    <br />
                                                                                    <strong>Upload CSV file to Import Contacts</strong>
                                                                                </td>
                                                                            </tr>
                                                                            <tr valign="top">
                                                                                <td>
                                                                                    <div style="text-align: right;">
                                                                                        <strong>Upload CSV file </strong>
                                                                                    </div>
                                                                                </td>
                                                                                <td style="text-align: left; padding-left: 20px;">
                                                                                    <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                                                                                </td>
                                                                            </tr>
                                                                            <tr valign="top">
                                                                                <td colspan="2">
                                                                                  <b>Note:</b> Please make sure mobile numbers,if any,are in xxx-xxx-xxxx format in your uploaded file.
                                                                                </td>
                                                                            </tr>
                                                                            <tr valign="top">
                                                                                <td colspan="2" align="center">
                                                                                    <asp:Button ID="CSVSubmit" OnClick="CSVSubmit_Click" runat="server" Text="Upload"
                                                                                        CssClass="bold" CausesValidation="False"></asp:Button>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="color: red" align="center">
                                                <asp:Label ID="lblError" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table class="profile-btntbl" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td class="align-center">
                                                <asp:Button ID="btndashboard1" OnClick="btndashboard1_Click" runat="server" Text="Go to Dashboard"
                                                    CausesValidation="false"></asp:Button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Panel align="center" ID="pnlimpcolumns" runat="server" Visible="false">
                                <table border="0" align="center" bgcolor="#eeeeee">
                                    <tr>
                                        <td>
                                            <%if (Filename != "" && Filename != null)
                                              { %>
                                            <%=Filenametext%>
                                            <asp:LinkButton ID="lnkchangefile" Font-Size="Medium" runat="server" Text="click here"
                                                OnClick="lnkchangefile_Click"></asp:LinkButton>
                                            <%=Filenametexttext%>
                                            <%} %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <table border="0" cellpadding="0" cellspacing="0" style="line-height: 25px;">
                                                <tr>
                                                    <td align="left">
                                                        <strong>Email:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlemail" runat="server" onchange="checkSelects(this.value, 0, this);">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator InitialValue="------- Select Appropriate Item ------"
                                                            ControlToValidate="ddlemail" ID="RFVEmail" runat="server" ErrorMessage="Email is mandatory."
                                                            ValidationGroup="A">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-right: 100px;">
                                                        <strong>First Name:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlfirstname" runat="server" onchange="checkSelects(this.value, 1, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>Last Name:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddllastname" runat="server" onchange="checkSelects(this.value, 2, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>Company Name:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlcompanyname" runat="server" onchange="checkSelects(this.value, 3, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>Address:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddladdress" runat="server" onchange="checkSelects(this.value, 4, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>City:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlcity" runat="server" onchange="checkSelects(this.value, 5, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>State:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlstate" runat="server" onchange="checkSelects(this.value, 6, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>Zip Code:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlzipcode" runat="server" onchange="checkSelects(this.value, 7, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>Phone Number:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlphone" runat="server" onchange="checkSelects(this.value, 8, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>Mobile Number:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlmobile" runat="server" onchange="checkSelects(this.value, 9, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>Fax Number:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlfax" runat="server" onchange="checkSelects(this.value, 10, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <strong>Group Name:</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGroupName" runat="server" onchange="checkSelects(this.value, 11, this);">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="Submit1" Text="Continue" runat="server" OnClick="Submit1_Click" ValidationGroup="A" />
                                            <asp:Button ID="Cancelcontacts" Text="Cancel" runat="server" CausesValidation="false"
                                                OnClick="Cancelcontacts_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="color: red" align="center">
                                            <asp:Label ID="lblerrormsg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <table>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlSelectedGroups" runat="server" Visible="false" align="center">
                                <table align="center">
                                    <tr>
                                        <td align="center">
                                            <font size='3' color='green'>You have mapped the data to create the groups listed below.</font>
                                        </td>
                                    </tr>
                                </table>
                                <div style="height: 320px; width: 600px; overflow-y: auto; border: solid 2px #D06F08;">
                                    <table align="left" style="text-align: left;">
                                        <tr>
                                            <td>
                                                <br />
                                                <span runat="server" id="spnGroups" style="max-height: 100px; overflow: scroll;">
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table align="center">
                                    <tr>
                                        <td>
                                            <font size='3' color='green'>If the groups are correct, click 'Proceed'. Click 'Remap
                                                Data' to reset.</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClick="btnProceed_Click" />
                                            <asp:Button ID="btnRemap" runat="server" Text="Remap Data" OnClick="btnRemap_Click" />
                                            <asp:Button ID="btnproceedcancel" runat="server" Text="Cancel" OnClick="btnyahoocancel_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnl2" runat="server" Visible="false">
                                <table cellspacing="1" cellpadding="4" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="Label2" runat="server" Font-Size="XX-Small"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="Label3" runat="server" Height="16px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <%if (tdSelectGroup.Visible == true)
                                                  { %>
                                                <b>Step 1. Select the group you wish to add contacts to from the drop down menu or create
                                                    a new group.</b><br />
                                                <b>Step 2. Select the check box confirming these contacts have agreed to receive email
                                                    from you.</b><br />
                                                <b>Step 3. Click 'Continue'.</b>
                                                <%}
                                                  else
                                                  { %>
                                                <b>Step 1. Select the check box confirming these contacts have agreed to receive email
                                                    from you.</b><br />
                                                <b>Step 2. Click 'Continue'.</b>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom: 10px" id="tdSelectGroup" runat="server">
                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 400px; height: 150px;
                                                    margin-left: 10px; border: #cccccc solid 1px; padding: 8px;">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <colgroup>
                                                                    <col width="57%" />
                                                                    <col width="*" />
                                                                </colgroup>
                                                                <tbody>
                                                                    <tr style="padding-top: 10px">
                                                                        <td>
                                                                            <span id="spnGrpContact" runat="server" style="font-weight: bold; color: #0b689d;
                                                                                font-family: verdana">Select a group to add contacts</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="drpgroup" runat="server" OnSelectedIndexChanged="drpgroup_SelectedIndexChanged"
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="height: 25px;">
                                                                        <td>
                                                                        </td>
                                                                        <td style="font-size: 20px; color: #F97D10; padding: 6px 0px 6px 0px;">
                                                                            <b>
                                                                                <asp:Label runat="server" ID="lblOR" Text="OR"></asp:Label></b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-weight: bold; color: #0b689d; font-family: verdana; vertical-align: baseline;">
                                                                            Create a group to add contacts
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtgroup" runat="server" ValidationGroup="g" MaxLength="15"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="reqgroup1" runat="server" ControlToValidate="txtgroup"
                                                                                ValidationGroup="g" ErrorMessage="Group Name Required.">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td style="padding-top: 7px;">
                                                                            <asp:Button ID="btnAddGroup" OnClick="btnAddGroup_Click" runat="server" Text="Create Group"
                                                                                ValidationGroup="g"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td id="SelectGroupnone" runat="server" visible="false">
                                            </td>
                                            <td align="left" valign="top">
                                                <table style="width: 380px; height: 150px; margin-left: 8px; border: #cccccc solid 1px;
                                                    padding: 8px;">
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="pnlcsvgrd" runat="server" Visible="false">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="97%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <asp:Label ID="lblerrorgroup" runat="server"></asp:Label>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblcsvcontacts" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <%if (CheckMobile == 1)
                                                      { %>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chkMobile" runat="server" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;These contacts have agreed to receive text messages.
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chkauthorize" runat="server" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;These contacts have agreed to receive email.
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Button ID="btncsvcontacts" runat="server" OnClick="btnmail_Click" OnClientClick="return SelectGroup()"
                                                                Text="Continue" />
                                                            <asp:Button ID="btncsvGrpContact" runat="server" OnClick="btnmail_Click" OnClientClick="return SelectCkhBox()"
                                                                Text="Continue" />
                                                            <asp:Button ID="Button2" runat="server" OnClick="btnyahoocancel_Click" Text="Cancel" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Panel ID="pnlmailgrid" runat="server" Visible="false">
                                                    <div style="border-right: 2px; border-top: 2px; border-left: 2px; width: 850px; border-bottom: 2px;
                                                        height: 500px; overflow: scroll;">
                                                        <asp:GridView ID="grdmailcontacts" runat="server" CssClass="datagrid2" Width="100%"
                                                            AutoGenerateColumns="False" OnRowDataBound="grdmailcontacts_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <img src="<%=Page.ResolveClientUrl("~/Images/emailarrow.gif")%>" width="17px" height="8"
                                                                            border="0" />
                                                                        <asp:CheckBox ID="chkSelectAll" runat="server"></asp:CheckBox>Select All
                                                                    </HeaderTemplate>
                                                                    <ItemStyle Width="100px" CssClass="align-center"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Email" HeaderText="Email">
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Group">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="drplist" runat="server">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="title1"></HeaderStyle>
                                                        </asp:GridView>
                                                    </div>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Label Style="font-weight: bold; font-size: 13px; color: green; font-family: Verdana"
                                                    ID="lblmsgprnt" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlmessage" runat="server">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <colgroup>
                                        <col width="50%" />
                                        <col width="*" />
                                    </colgroup>
                                    <tbody>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 5px; padding-left: 5px; font-size: 18px; padding-bottom: 10px;
                                                color: green; padding-top: 5px; font-family: Arial" align="center" colspan="2">
                                                <asp:Label ID="lblsuccessmess" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="padding-bottom: 15px; padding-top: 15px">
                                            <td align="right">
                                                <asp:Button ID="btnAddMoreContacts" OnClick="btnAddMoreContacts_Click" runat="server"
                                                    Text="Add More Contacts"></asp:Button>
                                            </td>
                                            <td style="padding-left: 10px">
                                                <asp:Button ID="btnDashBoard" OnClick="btnDashBoard_Click" runat="server" Text="View Contacts">
                                                </asp:Button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="CSVSubmit" />
        </Triggers>
    </asp:UpdatePanel>
    <input type="hidden" id="hdnCsvName" runat="server" />
    <asp:HiddenField ID="hdnPermissionType" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: Green;">
                Import Contacts
            </div>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
