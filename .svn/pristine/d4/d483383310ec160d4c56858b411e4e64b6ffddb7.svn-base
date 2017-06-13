<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="CreateFreeAccount.aspx.cs" Inherits="USPDHUB.Admin.CreateFreeAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../css/reveal.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function PhoneNumberFormat(str) {
            if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                return;
            }
            else {
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                    event.preventDefault();
                }
            }
            var val = str.value.replace(/\D/g, '');
            var newVal = '';
            if (val.length > 10) {
                val = val.substring(0, 10)
            }
            while (val.length >= 3 && newVal.length <= 7) {
                newVal += val.substr(0, 3) + '-';
                val = val.substr(3);
            }
            newVal += val;
            str.value = newVal;
        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }    
    </script>
    <asp:ScriptManager ID="smgr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div class="clear15">
                </div>
                <div class="adminpagehead">
                    Create Free Account</div>
                <div align="center">
                    <img src="../images/Admin/shadow-title.png" title="USPD HUB" alt="USPD HUB" /></div>
                <div class="clear15">
                </div>
                <div class="adminformwrap">
                    <div class="clear15">
                    </div>
                    <div class="successmsg_text">
                        <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                    </div>
                    <div class="clear15">
                    </div>
                    <div style="text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <div class="clear15">
                    </div>
                    <div>
                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                            HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>Country:</div>
                    <div class="txtfildwrapadm">
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="ddlfildadm" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            <asp:ListItem Text="United States" Value="United States"></asp:ListItem>
                            <asp:ListItem Text="India" Value="India"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        &nbsp;Vertical:</div>
                    <div class="txtfildwrapadm">
                        <asp:DropDownList ID="ddlVertical" runat="server" CssClass="ddlfildadm" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlVertical_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="clear10">
                    </div>
                    <%-- <div class="labeladmenq">
                        <span class="errormsgadm">&nbsp;</span>Subscription Type:</div>
                    <div class="txtfildwrapadm">
                        <asp:DropDownList ID="ddlSubscriptions" runat="server" CssClass="ddlfildadm">
                        </asp:DropDownList>
                    </div>--%>
                    <div class="labeladmenq">
                        <span class="errormsgadm">&nbsp;</span>Package Type:</div>
                    <div class="txtfildwrapadm">
                        <asp:DropDownList ID="ddlSubscriptions" runat="server" CssClass="ddlfildadm" OnSelectedIndexChanged="ddlSubscriptions_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm"></span>Subscription Period:
                    </div>
                    <div style="text-align: center; width: 500px; color: black;">
                        <div>
                            <asp:RadioButton runat="server" ID="subscrptnPeriodmnthly" Text="Monthly" GroupName="SubscrptnType"
                                Checked="true" />$-<asp:Label ID="lblMnthly" runat="server"></asp:Label>(Includes Setup Fee)
                        </div>
                    <div style="padding-left: 40px;">
                        <asp:RadioButton runat="server" ID="subscrptnPeriodyrly" Text="Yearly" GroupName="SubscrptnType" />
                        $-<asp:Label ID="lblyearly" runat="server"></asp:Label>(Includes Setup Fee)</div>
                </div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    <span class="errormsgadm">*</span>Agency Name:</div>
                <div class="txtfildwrapadm">
                    <asp:TextBox ID="txtAgencyName" TabIndex="1" runat="server" MaxLength="500" class="txtfildadm">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAgencyName"
                        ErrorMessage="Agency Name is mandatory." SetFocusOnError="True" Display="Dynamic"
                        ValidationGroup="A">*
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAgencyName"
                        ErrorMessage="Enter Valid Agency Name." SetFocusOnError="True" ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$"
                        ValidationGroup="A">*
                    </asp:RegularExpressionValidator></div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    <span class="errormsgadm">*</span>First Name:</div>
                <div class="txtfildwrapadm">
                    <asp:TextBox ID="txtContactPerson" TabIndex="2" runat="server" MaxLength="50" class="txtfildadm">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContactPerson"
                        ErrorMessage="First Name is mandatory." SetFocusOnError="True" Display="Dynamic"
                        ValidationGroup="A">*
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactPerson"
                        ErrorMessage="Enter Valid First Name." SetFocusOnError="True" ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$"
                        ValidationGroup="A">*
                    </asp:RegularExpressionValidator></div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    &nbsp;Last Name:</div>
                <div class="txtfildwrapadm">
                    <asp:TextBox ID="txtLastName" TabIndex="3" runat="server" MaxLength="50" class="txtfildadm">
                    </asp:TextBox></div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    <span class="errormsgadm">*</span>Phone Number:</div>
                <div class="txtfildwrapadm">
                    <%--  <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtphonenumber"
                            WatermarkText="xxx-xxx-xxxx" runat="server" WatermarkCssClass="txtfildadm">
                        </cc1:TextBoxWatermarkExtender>--%>
                    <asp:TextBox ID="txtphonenumber" TabIndex="4" runat="server" MaxLength="14" class="txtfildadm"
                        onkeyup="PhoneNumberFormat(this)">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtphonenumber"
                        ErrorMessage="Phone Number is mandatory." Font-Size="14px" ValidationGroup="A"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtphonenumber"
                        ErrorMessage="Enter Valid Phone Number." ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                        SetFocusOnError="True" Font-Size="14px" ValidationGroup="A">*
                    </asp:RegularExpressionValidator></div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    <span class="errormsgadm">*</span>Username:</div>
                <div class="txtfildwrapadm">
                    <asp:TextBox ID="txtEmail" TabIndex="5" runat="server" class="txtfildadm" onblur="return ServerSidefill(this.id);"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Username is mandatory." Font-Size="14px" Display="Dynamic" SetFocusOnError="True"
                        ValidationGroup="A">*
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmail"
                        Font-Size="14px" ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="A" SetFocusOnError="True">*</asp:RegularExpressionValidator><br />
                </div>
                <div class="clear">
                </div>
                <div class="txtfildwraps">
                    <div style="float: right;">
                        <div style="display: none;" id="Progress" class="CheckUsername">
                            <img src='../../images/popup_ajax-loader.gif' /><b><font color="green">Processing....</font></b></div>
                        <asp:Label ID="lblUserNameCheck" runat="server" Font-Size="14px" Font-Names="arial"
                            Width="500px" ForeColor="green"></asp:Label>
                    </div>
                </div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    <span class="errormsgadm">*</span>Agency Address1:</div>
                <div class="txtfildwrapadm">
                    <asp:TextBox ID="txtAgencyAddress" TabIndex="6" runat="server" MaxLength="200" class="txtfildadm">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAgencyAddress"
                        ErrorMessage="Agency Address is mandatory." Font-Size="14px" ValidationGroup="A"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator></div>
                <div class="clear10">
                </div>
                  <div class="labeladmenq">
                    <span class="errormsgadm">*</span>Agency Address2:</div>
                <div class="txtfildwrapadm">
                    <asp:TextBox ID="txtAgencyAddress2" TabIndex="6" runat="server" MaxLength="200" class="txtfildadm">
                    </asp:TextBox>
                    </div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    <span class="errormsgadm">*</span>City:</div>
                <div class="txtfildwrapadm">
                    <asp:TextBox ID="txtCity" TabIndex="7" runat="server" MaxLength="100" class="txtfildadm">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCity"
                        ErrorMessage="City is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCity"
                        ErrorMessage="Enter Valid City." ValidationExpression="^[a-zA-Z ]+$" SetFocusOnError="True"
                        Font-Size="14px" ValidationGroup="A">*
                    </asp:RegularExpressionValidator></div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    <span class="errormsgadm">*</span>State:</div>
                <div class="txtfildwrapadm">
                    <asp:TextBox ID="drpState" runat="server" TabIndex="8" class="txtfildadm"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" SetFocusOnError="True" Font-Size="14px"
                        ValidationGroup="A" ControlToValidate="drpState" runat="server" InitialValue="0"
                        ErrorMessage="State is mandatory.">*</asp:RequiredFieldValidator>
                </div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    <span class="errormsgadm">*</span>ZipCode:</div>
                <div class="txtfildwrapadm">
                    <asp:TextBox ID="txtZipCode" TabIndex="9" runat="server" MaxLength="5" class="txtfildadm"
                        onkeypress="return isNumber(event)">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtZipCode"
                        ErrorMessage="ZipCode is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                        Font-Size="14px" ValidationGroup="A" SetFocusOnError="True" ControlToValidate="txtZipCode"
                        ValidationExpression="^[0-9]{5,5}$">*</asp:RegularExpressionValidator>
                </div>
                <div class="clear10">
                </div>
                <div class="labeladmenq">
                    <span class="errormsgadm"></span>Turn on/off email:</div>
                <div class="txtfildwrapadm">
                    <asp:CheckBox ID="chkTurnOnOffEmails" runat="server" />(Note: Please select beside
                    checkbox to receive email)
                </div>
                <div class="clear10">
                </div>
            </div>
            <div class="clear41">
            </div>
            <div class="clear41">
            </div>
            <div class="submitadm">
                <asp:Button ID="btnGotoAppStore" runat="server" TabIndex="10" ValidationGroup="A"
                    CausesValidation="true" Text="Go to Store" OnClick="btnGotoStore" />
                <asp:Button ID="btnActivate" runat="server" TabIndex="11" ValidationGroup="A" CausesValidation="true"
                    Text="Activate" OnClick="btnActivateAccount" />
                <asp:Button ID="btnCancel" runat="server" TabIndex="12" CausesValidation="false"
                    Text="Cancel" OnClick="btnCancelAccount" />
            </div>
            <div class="clear10">
                <asp:HiddenField ID="hdnBrandedID" runat="server" />
                <asp:HiddenField ID="hdnBrandedAmt" runat="server" Value="0.00" />
                <asp:HiddenField ID="hdnInquiryId" runat="server" />
                <asp:HiddenField ID="hdnUserDomain" runat="server" />
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
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
                var Countrys = '';
                var parm1 = document.getElementById('<%=ddlCountry.ClientID%>');
                Countrys = parm1.options[parm1.selectedIndex].text;
                var Verticals = '';
                var parm2 = document.getElementById('<%=ddlVertical.ClientID%>');
                Verticals = parm2.options[parm2.selectedIndex].text;

                if (idvalue != '') {
                    var typeval = PageMethods.ServerSidefill(idvalue, Countrys, Verticals, OnSuccess, OnFailure);
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
            $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>An error occured.</font>';
            document.getElementById("Progress").style.display = "none";
        }

        function Focus(objname, waterMarkText) {
            obj = document.getElementById(objname);
            if (obj.value == waterMarkText) {
                obj.value = "";
            }
        }
    </script>
</asp:Content>
