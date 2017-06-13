<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.master" Inherits="Business_MyAccount_ModifyUserDetails"
    CodeBehind="ModifyUserDetails.aspx.cs" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <style>
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
        .couponcode
        {
            width: 100px;
        }
        .couponcode:hover .coupontooltip
        {
            display: block;
        }
        .couponcode span
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            margin-left: 10px;
            margin-bottom: 100px;
            border: 1px dashed #297CCF;
            padding: 10px;
            position: absolute;
            z-index: 1000;
            width: 360px;
            height: 30px;
            color: Black;
        }
    </style>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpCheck" runat="server">
        <ContentTemplate>
            <table width="100%" class="page-top" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                            <tr>
                                <td class="valign-top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblfirstname" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="margin-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td style="font-size: 13px; font-weight: bold;" class="lable" colspan="3">
                                                *Note: Registration details will not be displayed on App.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img height="28" src='../../Images/Dashboard/head-left.gif' width="9" />
                                            </td>
                                            <td class="new-header">
                                                Account Details
                                            </td>
                                            <!-- Issue No 670, Suresh-->
                                            <td>
                                                <img height="28" src='../../Images/Dashboard/head-right.gif' width="9" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="profile-input">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="inputgrid nomargin-bottom">
                                                    <colgroup>
                                                        <col width="175">
                                                        <col width="260">
                                                        <col width="175">
                                                        <col width="*">
                                                    </colgroup>
                                                    <tr class="row2">
                                                        <td class="lable">
                                                            Login ID:
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtusername" runat="server" CssClass="textfield" Width="200px" ReadOnly="true"></asp:TextBox>
                                                            *
                                                            <%--Your login ID will not change.--%>
                                                            <asp:Button ID="btnChangeloginID" Text="Change" runat="server" OnClick="btnChangeloginID_OnClick"
                                                                Style="font-size: 13px;" />
                                                        </td>
                                                    </tr>
                                                    <%-- <tr class="row2">
                                                        <td>
                                                        </td>
                                                        <td valign="top" colspan="3" style="margin: 0px;">
                                                            <strong>Note : </strong>All administrative communications, such as change password,
                                                            forgot password, invoices and other messages sent directly from the
                                                            <%=hdnVerticalName.Value%>
                                                            team, will be sent to the login ID email address.
                                                        </td>
                                                    </tr>--%>
                                                    <tr class="row2">
                                                        <td class="lable" style="vertical-align: middle;">
                                                            First Name:
                                                        </td>
                                                        <td style="vertical-align: middle; padding-right: 0px;">
                                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="medium textfield" Width="220px"
                                                                TabIndex="8"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                                                    Display="Dynamic" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First name is mandatory."
                                                                    ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                            <%if (Convert.ToBoolean(hdnIsLiteVersion.Value))
                                                              { %>
                                                            <span class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip">Contact Name should be the administrator that customer
                                                                    <br />
                                                                    service would contact about your account details.</span></span>
                                                            <%}
                                                              else
                                                              { %>
                                                            <a id="A2" href="javascript:ModalHelpPopup('Change Contact Name',136,'');">
                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                            <%} %>
                                                        </td>
                                                        <td class="lable" style="vertical-align: middle;">
                                                            Last Name:
                                                        </td>
                                                        <td style="vertical-align: middle;">
                                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="medium textfield" Width="220px"
                                                                TabIndex="9"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                                                    runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name is mandatory."
                                                                    ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr class="row1">
                                                        <td class="lable" style="vertical-align: middle;">
                                                            Street Address:
                                                        </td>
                                                        <td style="vertical-align: middle;">
                                                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="medium textfield" Width="220px"
                                                                TabIndex="11"></asp:TextBox>
                                                            <%if (Convert.ToBoolean(hdnIsLiteVersion.Value))
                                                              { %>
                                                            <span class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip" style="width: 200px;">This address will be used for administrative
                                                                    correspondence.</span></span>
                                                            <%}
                                                              else
                                                              { %>
                                                            <a id="A1" href="javascript:ModalHelpPopup('Change Contact Address',135,'');">
                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                            <%} %>
                                                        </td>
                                                        <td class="lable" style="vertical-align: middle;">
                                                            Address 2:
                                                        </td>
                                                        <td style="vertical-align: middle;">
                                                            <asp:TextBox ID="txtAddress2" runat="server" Width="220px" CssClass="medium textfield"
                                                                TabIndex="12"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr class="row2">
                                                        <td class="lable" style="vertical-align: middle;">
                                                            City:
                                                        </td>
                                                        <td style="vertical-align: middle; padding-right: 0px;">
                                                            <asp:TextBox ID="txtCity" runat="server" CssClass="medium textfield" Width="220px"
                                                                TabIndex="13"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                                                                    runat="server" ControlToValidate="txtCity" ErrorMessage="City is mandatory."
                                                                    ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="lable" style="vertical-align: middle;">
                                                            State/Province:
                                                        </td>
                                                        <td style="vertical-align: middle;">
                                                            <asp:TextBox ID="txtState" runat="server" CssClass="medium textfield" Width="220px"
                                                                TabIndex="14" ValidationGroup="userValidation"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtState"
                                                                ErrorMessage="State is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                            <%--<asp:DropDownList ID="drpState" runat="server" TabIndex="14" ValidationGroup="userValidation"
                                                                Width="120px">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="drpState"
                                                                InitialValue="0" ErrorMessage="State is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr class="row1">
                                                        <td class="lable" style="height: 24px; vertical-align: middle;">
                                                            Zip/Postal Code:
                                                        </td>
                                                        <td style="height: 24px; vertical-align: middle;">
                                                            <asp:TextBox ID="txtZipCode" MaxLength="8" runat="server" CssClass="medium textfield"
                                                                onkeypress="return isNumber(event)" TabIndex="15" ValidationGroup="userValidation"
                                                                Width="100px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtZipCode"
                                                                ErrorMessage="Zip code is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                                                                ControlToValidate="txtZipCode" ValidationExpression="^[0-9]{5,8}$" ValidationGroup="g">*</asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="lable" style="height: 24px; vertical-align: middle;">
                                                            Country:
                                                        </td>
                                                        <td style="height: 24px; vertical-align: middle;">
                                                            <asp:DropDownList ID="ddlCountry" runat="server" Width="120px" CssClass="medium textfield"
                                                                TabIndex="14" ValidationGroup="userValidation">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCountry"
                                                                ErrorMessage="Country is mandatory." InitialValue="0" ValidationGroup="g">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr class="row2">
                                                        <td class="lable" style="vertical-align: middle;">
                                                            Phone Number:
                                                        </td>
                                                        <td colspan="3" style="vertical-align: middle;">
                                                            <asp:TextBox ID="txtPhone" MaxLength="13" runat="server" CssClass="medium textfield"
                                                                TabIndex="16" ValidationGroup="userValidation" Width="117px">
                                                            </asp:TextBox>(xxx-xxx-xxxx)<asp:RegularExpressionValidator ID="RegularExpressionValidator6"
                                                                runat="server" ControlToValidate="txtPhone" ErrorMessage="Enter Valid Phone Number"
                                                                Font-Size="XX-Small" Display="Dynamic" ValidationGroup="g" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">*
                                                            </asp:RegularExpressionValidator>
                                                            <%if (Convert.ToBoolean(hdnIsLiteVersion.Value))
                                                              { %>
                                                            <span class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip" style="height: 50px;">Contact Phone Number should be the
                                                                    number customer service would call for administrative information about your account.</span></span>
                                                            <%}
                                                              else
                                                              { %>
                                                            <a id="A3" href="javascript:ModalHelpPopup('Change Contact Phone Number',137,'');">
                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                            <%} %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" class="profile-btntbl">
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hdnCommEmail" runat="server" />
                                                <asp:HiddenField ID="hdnVerticalName" runat="server" />
                                                <asp:HiddenField ID="hdnIsLiteVersion" runat="server" Value="false" />
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="19" OnClick="UserUpdate_Click"
                                                    ValidationGroup="g" />
                                                <asp:Button ID="btndashboard1" OnClick="btndashboard_Click" runat="server" Text="Go to Dashboard"
                                                    CausesValidation="false" />
                                                <%--Issue 769 <asp:Button ID="btnCancel" runat="server"  Text="Cancel" TabIndex="20" CausesValidation="false"  OnClick="UserCancel_Click"/>
                <asp:Button ID="btndashboard" runat="server" Text="Go To Dashboard" OnClick="btndashboard_Click" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td>
                        <img height="28" src='../../Images/Dashboard/head-left.gif' width="9" />
                    </td>
                    <td class="new-header">
                        Account Details
                    </td>
                    <!-- Issue No 670, Suresh-->
                    <td>
                        <img height="28" src='../../Images/Dashboard/head-right.gif' width="9" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblChangeLoginID" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="LoginIDModal" runat="server" TargetControlID="lblChangeLoginID"
                PopupControlID="pnlLoginIDChange" BackgroundCssClass="modal" CancelControlID="imgclosepreviewpopup"
                BehaviorID="ChangeLoginID">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlLoginIDChange" runat="server" Style="display: none" Width="420px">
                <table class="popuptable" cellspacing="0" cellpadding="3" width="420px" align="center"
                    border="0">
                    <tbody>
                        <tr>
                            <td style="font-size: 14px; color: Green;">
                                <strong>Change Primary Login ID</strong>
                            </td>
                            <td style="padding-right: 80px;" align="right">
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
                            <td colspan="3">
                                <table>
                                    <tr>
                                        <td>
                                            Current Login ID :
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtExistLoginID" runat="server" ReadOnly="true" Width="200px" tooltipText="Valid email address required. Your email address will be your login ID.">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            New Login ID :
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Disabled" Width="200px"
                                                onblur="return ServerSidefill(this.id);" tooltipText="Valid email address required. Your email address will be your login ID.">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                                ErrorMessage="Email Address of Contact Person is mandatory." Font-Size="14px"
                                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="A">*
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                                Font-Size="14px" ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="A" SetFocusOnError="True">*
                                            </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding-bottom: 5px; padding-top: 5px;">
                                            <div class="txtfildwraps">
                                                <div style="float: right;">
                                                    <div style="display: none;" id="Progress" class="CheckUsername">
                                                        <img src='../../images/popup_ajax-loader.gif' /><b><font color="green">Processing....</font></b></div>
                                                    <asp:Label ID="lblUserNameCheck" runat="server" Font-Size="14px" Font-Names="arial"
                                                        Width="263px" ForeColor="green"></asp:Label>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="2" style="padding-bottom: 5px; padding-top: 5px;">
                                            <asp:Button ID="Button1" runat="server" Text="Update" ValidationGroup="A" OnClick="btnLoginIDUpdate_OnClick" />&nbsp;
                                            <asp:Button ID="Button2" runat="server" Text="Cancel" onblur="ClosePopupWindow();"
                                                CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function ClosePopupWindow() {

            var modal = $find("ChangeLoginID");
            modal.hide();

        }
        var divstyle = new String();
        function ServerSidefill(id) {
            if (document.getElementById('<%=txtEmail.ClientID%>').value.replace(/ /g, '') != '') {
                divstyle = document.getElementById("Progress").style.visibility;
                if (divstyle.toLowerCase() == "none" || divstyle == "") {
                    document.getElementById("Progress").style.display = "block";
                }
                else {
                    document.getElementById("Progress").style.display = "none";
                }


                var idvalue = '';
                idvalue = $get(id).value;
                if (idvalue != '') {
                    var typeval = PageMethods.ServerSidefill(idvalue, OnSuccess, OnFailure);
                }
            }
        }
        function OnSuccess(result) {
            if (result == '1') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=green>Email address is available.</font>';
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '2') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Email address is already in use; please use a different one.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '3') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Please enter a valid Email Address.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '4') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Email address is already associated with another user.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
        }
        function OnFailure(result) {
            if (result.get_message() != "The server method 'ServerSidefill' failed.") {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>An error occured.</font>';
            }
            document.getElementById("Progress").style.display = "none";
        }

        function Focus(objname, waterMarkText) {
            obj = document.getElementById(objname);
            if (obj.value == waterMarkText) {
                obj.value = "";
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_cphUser_txtPhone').keyup(function (event) {
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
</asp:Content>
