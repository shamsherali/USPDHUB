<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" Inherits="Business_MyAccount_ModifyProfileDetails"
    ValidateRequest="false" CodeBehind="ModifyProfileDetails.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<%@ Register Assembly="UltimateEditor" Namespace="Karamasoft.WebControls.UltimateEditor"
    TagPrefix="kswc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript">
        function blockSplChar(id) {
            id.value = filterNum(id.value)
            function filterNum(str) {

                re = /\$|@|#|~|`|\%|\*|\^|\\|\(|\)|\+|\=|\[|\_|\]|\[|\}|\{|\;|\:|\"|\<|\>|\?|\||\!|\$|/g;
                // remove special characters like "$" and "," etc...                 
                return str.replace(re, "");

            }
        }
        function blockSplChar1(id) {

            id.value = filterNum(id.value)
            function filterNum(str) {
                re = /\$|,|@|#|~|`|\%|\*|\^|\/|\&|\(|\)|\+|\=|\[|\_|\]|\[|\}|\{|\;|\:|\"|\<|\>|\?|\||\\|\!|\$|/g;
                // remove special characters like "$" and "," etc...
                return str.replace(re, "");

            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function blockChar(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_cphUser_txtphonenumber').keyup(function (event) {
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
                var val = this.value.replace(/\D/g, '');
                var newVal = '';
                if (val.length > 10) {
                    val = val.substring(0, 10)
                }
                while (val.length >= 3 && newVal.length <= 7) {
                    newVal += val.substr(0, 3) + '-';
                    val = val.substr(3);
                }
                newVal += val;
                this.value = newVal;
            });
        });
        
    </script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_cphUser_txtfaxnumber').keyup(function (event) {
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
                var val = this.value.replace(/\D/g, '');
                var newVal = '';
                if (val.length > 10) {
                    val = val.substring(0, 10)
                }
                while (val.length >= 3 && newVal.length <= 7) {
                    newVal += val.substr(0, 3) + '-';
                    val = val.substr(3);
                }
                newVal += val;
                this.value = newVal;
            });
        });
        
    </script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_cphUser_txtmobile').keyup(function (event) {
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
                var val = this.value.replace(/\D/g, '');
                var newVal = '';
                if (val.length > 10) {
                    val = val.substring(0, 10)
                }
                while (val.length >= 3 && newVal.length <= 7) {
                    newVal += val.substr(0, 3) + '-';
                    val = val.substr(3);
                }
                newVal += val;
                this.value = newVal;
            });
        });
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }      
    </script>
    <div id="TipLayer" style="visibility: hidden; position: absolute; z-index: 1000;
        top: -100">
    </div>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/main.js")%>"
        type="text/javascript"></script>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/dashboardstyle.js")%>"
        type="text/javascript"></script>
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
        <tr>
            <td class="valign-top">
                <uc3:wowmap ID="sitemaplinks" runat="server" />
                <asp:UpdatePanel ID="uppnlpopup1" runat="server">
                    <ContentTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <%lblBusinessName.Text = txtBusinessname.Text.Trim(); %>
                                <td>
                                    <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                                        Style="border: 0; border-color: White!important;"></asp:TextBox>
                                    Edit
                                    <asp:Label runat="server" ID="lblBusinessName"></asp:Label>
                                    <%--  <%=hdnVerticalName.Value %>--%>
                                </td>
                                <td class="right">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing"
                                                style="color: Green; font-size: 12px;">Processing....</span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" class="inputgrid" style="font-size: 12px;">
                                    <asp:Label ID="lblstatusmessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
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
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="margin-top">
                            <tr>
                                <td class="valign-top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td colspan="3">
                                                <%--<b>Note: Details below may be enabled to display on the App.</b>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>" width="9"
                                                    height="28">
                                            </td>
                                            <td class="new-header">
                                                App Details
                                            </td>
                                            <td>
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>" width="9"
                                                    height="28">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="profile-input">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="lable" nowrap valign="top">
                                                            Organization Name:
                                                            <asp:TextBox ID="txtBusinessname" MaxLength="50" runat="server" Width="290px" onkeyup="CountMaxLength(this,'Agency Name');"
                                                                onChange="CountMaxLength(this,'Agency Name');"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBusinessname"
                                                                runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Agency Name is mandatory.">*</asp:RequiredFieldValidator>
                                                            <br />
                                                            <span style="margin-left: 108px; font-size: normal;">You have
                                                                <asp:Label ID="lblLength" runat="server"></asp:Label>
                                                                characters left.</span><span style="margin-left: 38px;">(Max Characters 50)</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px;">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #04519D;">
                                                    <colgroup>
                                                        <col width="50%" />
                                                        <col width="*" />
                                                    </colgroup>
                                                    <tr>
                                                        <td class="lable" nowrap valign="top" colspan="2">
                                                            Address & Phone Numbers
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding-left: 5px">
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        <font color="red">*</font>Address 1:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 285px;">
                                                                        <asp:TextBox ID="txtaddress1" MaxLength="75" runat="server" Width="270px" TabIndex="3"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtaddress1"
                                                                            runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Street is mandatory.">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        Address 2:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 285px;" colspan="2">
                                                                        <asp:TextBox ID="txtaddress2" MaxLength="75" runat="server" Width="270px" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        <font color="red">*</font>City:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 285px;">
                                                                        <asp:TextBox ID="txtcity" MaxLength="75" runat="server" Width="270px" TabIndex="6"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtcity"
                                                                            runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="City is mandatory.">*</asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="g"
                                                                            runat="server" ErrorMessage="Special Characters are not Allowed for City." ControlToValidate="txtcity"
                                                                            Display="Dynamic" ValidationExpression="^\s*[a-zA-Z0-9,\s]+\s*$">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding-left: 5px;
                                                                padding-bottom: 5px;">
                                                                <colgroup>
                                                                    <col width="125px" />
                                                                    <col width="80px" />
                                                                    <col width="80px" />
                                                                    <col width="100px" />
                                                                </colgroup>
                                                                <tr>
                                                                    <td class="lable" nowrap>
                                                                        <font color="red">*</font>State:
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        <font color="red">*</font>Zip Code:
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="width: 285px;">
                                                                        <asp:TextBox ID="txtState" TabIndex="7" runat="server" Width="270px">
                                                                        </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtState"
                                                                            ErrorMessage="State is mandatory." Font-Size="14px" ValidationGroup="g" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:TextBox ID="txtzipcode" MaxLength="8" runat="server" Width="65px" Rows="7"
                                                                            TabIndex="10" onkeypress="return isNumber(event)"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtzipcode"
                                                                            runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Zip Code is mandatory.">*</asp:RequiredFieldValidator>
                                                                         <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                                                                            ControlToValidate="txtzipcode" ValidationExpression="^[0-9]{5,8}$" ValidationGroup="g"
                                                                            SetFocusOnError="True">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        <font color="red">*</font>Country:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCountry" TabIndex="11" runat="server" Width="241">
                                                                        </asp:DropDownList>
                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlCountry"
                                                                            InitialValue="0" runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Country is mandatory.">*</asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <%if (!Convert.ToBoolean(hdnIsLiteVersion.Value))
                                                                  { %>
                                                                <tr>
                                                                    <td colspan="4" class="lable" nowrap>
                                                                        <font color="red">*</font>Contact Us Form
                                                                    </td>
                                                                </tr>
                                                                <%}%>
                                                                <%-- <%if (!Convert.ToBoolean(hdnIsLiteVersion.Value))
                                                                  { %>
                                                                <tr>
                                                                    <%}
                                                                  else
                                                                  {%>
                                                                    <tr style="display: none;">
                                                                        <%}%>--%>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        Email for Communication:&nbsp;<asp:TextBox ID="txtCommEmail" runat="server" CssClass="textfield"
                                                                            Width="200px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCommEmail"
                                                                            ErrorMessage="Email for Communication is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCommEmail"
                                                                            ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                            ValidationGroup="g" SetFocusOnError="True">*</asp:RegularExpressionValidator>
                                                                        <br />
                                                                        <b>*Note: </b>All messages and tips sent by the Mobile App user (the public)<br />
                                                                        will be sent to this email.
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <colgroup>
                                                                    <col width="220px" />
                                                                    <col width="*" />
                                                                </colgroup>
                                                                <tr>
                                                                    <td colspan="2" style="font-weight: bold; font-size: 14px;">
                                                                        Preferred Number for App's One Touch Dial
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
                                                                    <td class="lable" nowrap>
                                                                        <font color="red">*</font>Phone Number:
                                                                    </td>
                                                                    <td>
                                                                        Extension:
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td width="50%" style="padding-top: 1px;">
                                                                        <cc1:TextBoxWatermarkExtender ID="txbwephonenumber" TargetControlID="txtphonenumber"
                                                                            WatermarkText="Phone Number" WatermarkCssClass="inputtextarea" runat="server">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <asp:RadioButton ID="rbPhone" runat="server" Checked="true" GroupName="Phone" />&nbsp;<font
                                                                            color="red">*</font><asp:TextBox ID="txtphonenumber" MaxLength="12" runat="server"
                                                                                Width="120px" TabIndex="12">
                                                                            </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtphonenumber"
                                                                                runat="server" SetFocusOnError="True" ValidationGroup="g" ErrorMessage="Phone Number is mandatory.">*</asp:RequiredFieldValidator>
                                                                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtextenction"
                                                                            WatermarkText="Extension" WatermarkCssClass="inputtextarea" runat="server">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <asp:TextBox ID="txtextenction" runat="server" Width="50px" MaxLength="4" TabIndex="13"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="g"
                                                                            runat="server" ControlToValidate="txtphonenumber" ErrorMessage="Enter Valid Phone Number"
                                                                            Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">*</asp:RegularExpressionValidator>
                                                                        <br />
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(xxx-xxx-xxxx)
                                                                    </td>
                                                                    <td valign="top">
                                                                        <asp:RadioButton ID="rbAlternate" runat="server" GroupName="Phone" />&nbsp;<asp:TextBox
                                                                            ID="txtAlternateCall" runat="server" Width="120px" MaxLength="12"></asp:TextBox>
                                                                        <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtAlternateCall"
                                                                            WatermarkText="Alternate Number" runat="server" WatermarkCssClass="txtfild">
                                                                        </cc1:TextBoxWatermarkExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAltmask"
                                                                            ErrorMessage="Alternate Number is mandatory." Font-Size="14px" ValidationGroup="g"
                                                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationGroup="g"
                                                                            runat="server" ControlToValidate="txtAlternateCall" ErrorMessage="Enter Valid Mobile Number"
                                                                            Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">*</asp:RegularExpressionValidator>
                                                                        <br />
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(xxx-xxx-xxxx)
                                                                        <asp:TextBox ID="txtAltmask" runat="server" Width="10px" Style="display: none;"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        Fax Number:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtfaxnumber" MaxLength="12" runat="server" Width="120px" TabIndex="14"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator33" ValidationGroup="g"
                                                                            runat="server" ControlToValidate="txtfaxnumber" ErrorMessage="Enter Valid Fax Number"
                                                                            Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        Mobile Number:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 210px" colspan="2">
                                                                        <asp:TextBox ID="txtmobile" MaxLength="12" runat="server" Width="120px" TabIndex="16">
                                                                        </asp:TextBox>
                                                                        (xxx-xxx-xxxx)
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="g"
                                                                            runat="server" Display="Dynamic" ControlToValidate="txtmobile" ErrorMessage="Enter Valid Mobile Number"
                                                                            Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">*</asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="lable">
                                                                        Select Time Zone:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:DropDownList ID="ddlTimeZone" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <%--<tr id="tralternatenumberName" runat="server" visible="false">
                                                                    <td colspan="2" class="lable" nowrap>
                                                                        Alternate Phone Number:
                                                                    </td>
                                                                </tr>
                                                                <tr id="tralternatenumberValue" runat="server" visible="false">
                                                                    <td>
                                                                        <asp:TextBox ID="txtAlternatePhone" MaxLength="13" runat="server" CssClass="medium textfield"
                                                                            TabIndex="17" Width="117px">
                                                                        </asp:TextBox>
                                                                        (xxx-xxx-xxxx)
                                                                    </td>
                                                                </tr>--%>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom: 5px;">
                                                <span style="color: #333333; font-size: 11px; font-weight: bold; padding: 3px 3px 3px 5px;">
                                                    Last Modified:</span><span style="padding-left: 100px;">
                                                        <asp:Label ID="lbllastmodified" runat="server"></asp:Label></span><asp:HiddenField
                                                            ID="hdnezSmartSite" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdntest" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdncontactname" runat="server"></asp:HiddenField>
                                                <asp:HiddenField runat="server" ID="hdnPermissionType" />
                                                <asp:HiddenField ID="hdnIsLiteVersion" runat="server" Value="false" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="profile-btntbl">
                                        <tr>
                                            <td align="center" valign="top">
                                                <asp:HiddenField ID="hdnVerticalName" runat="server" />
                                                <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Back" OnClick="btnBack_Click"
                                                    TabIndex="30" CausesValidation="false" />&nbsp;&nbsp;<asp:Button ID="btncancelupdate"
                                                        CssClass="button" runat="server" Text="Cancel" OnClick="Modify_Profile" TabIndex="30" />&nbsp;&nbsp;<asp:Button
                                                            ID="btncontinue" runat="server" Text="Update" OnClick="Modify_Continue" OnClientClick="return test('g');"
                                                            CssClass="button" ValidationGroup="g" TabIndex="31" />
                                                <asp:Button ID="btndashboard1" OnClick="btndashboard_Click" runat="server" Text="Go to Dashboard"
                                                    CausesValidation="false" TabIndex="32" CssClass="button" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function test(group) {
            var alternateCall = document.getElementById("<%=txtAlternateCall.ClientID %>").value;
            if (alternateCall == 'Alternate Number')
                alternateCall = '';
            if (document.getElementById("<%=rbPhone.ClientID %>").checked || (document.getElementById("<%=rbAlternate.ClientID %>").checked && alternateCall != "")) {
                document.getElementById("<%=txtAltmask.ClientID %>").value = "1";
            }
            if (!Page_ClientValidate(group)) {
                document.getElementById('<%=txt.ClientID %>').focus();
                document.getElementById('<%=lblstatusmessage.ClientID %>').innerHTML = '';
            }
            else {
                document.getElementById('<%=txt.ClientID %>').focus();
            }
        }
        window.onload = function () {
            CountMaxLength(document.getElementById('<%=txtBusinessname.ClientID %>'), 'Agency Name');
        }
        function CountMaxLength(id, text) {
            var maxlength = 50;

            if (id.value.length > maxlength) {
                id.value = id.value.substring(0, maxlength);
                alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
            }
            document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;
        }
        $(function () {
            $('#ctl00_cphUser_txtAlternateCall').keyup(function (event) {
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
                var val = this.value.replace(/\D/g, '');
                var newVal = '';
                if (val.length > 10) {
                    val = val.substring(0, 10)
                }
                while (val.length >= 3 && newVal.length <= 7) {
                    newVal += val.substr(0, 3) + '-';
                    val = val.substr(3);
                }
                newVal += val;
                this.value = newVal;
            });
        });
    </script>
</asp:Content>
