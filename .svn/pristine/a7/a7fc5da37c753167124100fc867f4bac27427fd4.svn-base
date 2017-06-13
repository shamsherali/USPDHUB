<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnquiryDetails.aspx.cs"
    Inherits="USPDHUB.Admin.EnquiryDetails" MasterPageFile="~/AdminHome.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="Server">
    <link href="../css/reveal.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div class="clear15">
                </div>
                <div class="adminpagehead">
                    Verification Form</div>
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
                    <asp:Panel ID="pnlParent" runat="server" Visible="false">
                        <div class="labeladmenq">
                            <span class="errormsgadm">*</span>Parent Agency:</div>
                        <div class="txtfildwrapadm">
                            <asp:Label ID="lblParent" runat="server" Style="color: Green;"></asp:Label>
                        </div>
                        <div class="clear10">
                        </div>
                    </asp:Panel>
                    <div class="labeladmenq">
                        &nbsp;&nbsp;Subscription Type:</div>
                    <div class="txtfildwrapadm">
                        <asp:Label runat="server" ID="lblSubType" Font-Bold="true"></asp:Label>
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
                        </asp:RequiredFieldValidator><%--
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAgencyName"
                            ErrorMessage="Enter Valid Agency Name." SetFocusOnError="True" ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$"
                            ValidationGroup="A">*
                        </asp:RegularExpressionValidator>--%></div>
                    <div class="clear10">
                    </div>
                    <%--<div class="labeladmenq">
                        <span class="errormsgadm">&nbsp;</span>Parent Name:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtParentName" TabIndex="2" runat="server" MaxLength="500" class="txtfildadm">
                        </asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtParentName"
                            MinimumPrefixLength="1" EnableCaching="False" CompletionSetCount="1" CompletionInterval="100"
                            ServiceMethod="GetProfiles" CompletionListCssClass="autocomplete_completionListElement">
                        </cc1:AutoCompleteExtender></div>
                    <div class="clear10">
                    </div>--%>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>First Name:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtContactPerson" TabIndex="2" runat="server" MaxLength="50" class="txtfildadm">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContactPerson"
                            ErrorMessage="Contact Person is mandatory." SetFocusOnError="True" Display="Dynamic"
                            ValidationGroup="A">*
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactPerson"
                            ErrorMessage="Enter Valid Contact Person." SetFocusOnError="True" ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$"
                            ValidationGroup="A">*
                        </asp:RegularExpressionValidator></div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        &nbsp;&nbsp;Last Name:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtLastName" TabIndex="3" runat="server" MaxLength="50" class="txtfildadm">
                        </asp:TextBox>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        &nbsp;&nbsp;Title:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtTitle" TabIndex="4" runat="server" MaxLength="200" class="txtfildadm">
                        </asp:TextBox>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        &nbsp;&nbsp;How do you know about us?:</div>
                    <div class="txtfildwrapadm">
                        <asp:DropDownList ID="ddlHow" runat="server" CssClass="ddlfildadm" TabIndex="5">
                            <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                            <asp:ListItem Text="Google Search" Value="Google Search"></asp:ListItem>
                            <asp:ListItem Text="Referral" Value="Referral"></asp:ListItem>
                            <asp:ListItem Text="Sales Person" Value="Sales Person"></asp:ListItem>
                            <asp:ListItem Text="Magazine Ad" Value="Magazine Ad"></asp:ListItem>
                            <asp:ListItem Text="Trade show" Value="Trade show"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>Phone Number:</div>
                    <div class="txtfildwrapadm">
                        <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtphonenumber"
                            WatermarkText="xxx-xxx-xxxx" runat="server" WatermarkCssClass="txtfildadm">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:TextBox ID="txtphonenumber" TabIndex="6" runat="server" MaxLength="14" class="txtfildadm">
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
                        <asp:TextBox ID="txtEmail" TabIndex="7" runat="server" class="txtfildadm" Enabled="false"></asp:TextBox></div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        &nbsp;Website Address:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtWebsiteAddress" TabIndex="8" runat="server" MaxLength="150" class="txtfildadm">
                        </asp:TextBox></div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>Agency Address:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtAgencyAddress" TabIndex="9" runat="server" MaxLength="200" class="txtfildadm">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAgencyAddress"
                            ErrorMessage="Agency Address is mandatory." Font-Size="14px" ValidationGroup="A"
                            SetFocusOnError="True">*</asp:RequiredFieldValidator></div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>City:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtCity" TabIndex="10" runat="server" MaxLength="100" class="txtfildadm">
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
                        <asp:DropDownList ID="drpState" TabIndex="11" runat="server" CssClass="ddlfildadm">
                            <asp:ListItem Value="0">--Select State--</asp:ListItem>
                            <asp:ListItem Value="Alabama">Alabama</asp:ListItem>
                            <asp:ListItem Value="Alaska">Alaska</asp:ListItem>
                            <asp:ListItem Value="Arizona">Arizona</asp:ListItem>
                            <asp:ListItem Value="Arkansas">Arkansas</asp:ListItem>
                            <asp:ListItem Value="California">California</asp:ListItem>
                            <asp:ListItem Value="Colorado">Colorado</asp:ListItem>
                            <asp:ListItem Value="Connecticut">Connecticut</asp:ListItem>
                            <asp:ListItem Value="District">District of Columbia</asp:ListItem>
                            <asp:ListItem Value="Delaware">Delaware</asp:ListItem>
                            <asp:ListItem Value="Florida">Florida</asp:ListItem>
                            <asp:ListItem Value="Georgia">Georgia</asp:ListItem>
                            <asp:ListItem Value="Hawaii">Hawaii</asp:ListItem>
                            <asp:ListItem Value="Idaho">Idaho</asp:ListItem>
                            <asp:ListItem Value="Illinois">Illinois</asp:ListItem>
                            <asp:ListItem Value="Indiana">Indiana</asp:ListItem>
                            <asp:ListItem Value="Iowa">Iowa</asp:ListItem>
                            <asp:ListItem Value="Kansas">Kansas</asp:ListItem>
                            <asp:ListItem Value="Kentucky">Kentucky</asp:ListItem>
                            <asp:ListItem Value="Louisiana">Louisiana</asp:ListItem>
                            <asp:ListItem Value="Maine">Maine</asp:ListItem>
                            <asp:ListItem Value="Maryland">Maryland</asp:ListItem>
                            <asp:ListItem Value="Massachusetts">Massachusetts</asp:ListItem>
                            <asp:ListItem Value="Michigan">Michigan</asp:ListItem>
                            <asp:ListItem Value="Minnesota">Minnesota</asp:ListItem>
                            <asp:ListItem Value="Mississippi">Mississippi</asp:ListItem>
                            <asp:ListItem Value="Missouri">Missouri</asp:ListItem>
                            <asp:ListItem Value="Montana">Montana</asp:ListItem>
                            <asp:ListItem Value="Nebraska">Nebraska</asp:ListItem>
                            <asp:ListItem Value="Nevada">Nevada</asp:ListItem>
                            <asp:ListItem Value="New Hampshire">New Hampshire</asp:ListItem>
                            <asp:ListItem Value="New Jersey">New Jersey</asp:ListItem>
                            <asp:ListItem Value="New Mexico">New Mexico</asp:ListItem>
                            <asp:ListItem Value="New York">New York</asp:ListItem>
                            <asp:ListItem Value="North Carolina">North Carolina</asp:ListItem>
                            <asp:ListItem Value="North Dakota">North Dakota</asp:ListItem>
                            <asp:ListItem Value="Ohio">Ohio</asp:ListItem>
                            <asp:ListItem Value="Oklahoma">Oklahoma</asp:ListItem>
                            <asp:ListItem Value="Oregon">Oregon</asp:ListItem>
                            <asp:ListItem Value="Pennsylvania">Pennsylvania</asp:ListItem>
                            <asp:ListItem Value="Rhode Island">Rhode Island</asp:ListItem>
                            <asp:ListItem Value="South Carolina">South Carolina</asp:ListItem>
                            <asp:ListItem Value="South Dakota">South Dakota</asp:ListItem>
                            <asp:ListItem Value="Tennessee">Tennessee</asp:ListItem>
                            <asp:ListItem Value="Texas">Texas</asp:ListItem>
                            <asp:ListItem Value="Utah">Utah</asp:ListItem>
                            <asp:ListItem Value="Vermont">Vermont</asp:ListItem>
                            <asp:ListItem Value="Virginia">Virginia</asp:ListItem>
                            <asp:ListItem Value="Washington">Washington</asp:ListItem>
                            <asp:ListItem Value="West Virginia">West Virginia</asp:ListItem>
                            <asp:ListItem Value="Wisconsin">Wisconsin</asp:ListItem>
                            <asp:ListItem Value="Wyoming">Wyoming</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" SetFocusOnError="True" Font-Size="14px"
                            ValidationGroup="A" ControlToValidate="drpState" runat="server" InitialValue="0"
                            ErrorMessage="State is mandatory.">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>Country:</div>
                    <div class="txtfildwrapadm">
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="ddlfildadm" TabIndex="12">
                            <asp:ListItem Text="United States" Value="United States"></asp:ListItem>
                            <asp:ListItem Text="India" Value="India"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        <span class="errormsgadm">*</span>ZipCode:</div>
                    <div class="txtfildwrapadm">
                        <asp:TextBox ID="txtZipCode" TabIndex="13" runat="server" MaxLength="5" class="txtfildadm"
                            onkeypress="return isNumber(event)">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtZipCode"
                            ErrorMessage="ZipCode is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                            Font-Size="14px" ControlToValidate="txtZipCode" ValidationExpression="^[0-9]{5,5}$"
                            SetFocusOnError="True" ValidationGroup="A">*</asp:RegularExpressionValidator>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        &nbsp;Vertical:</div>
                    <div class="txtfildwrapadm">
                        <asp:DropDownList ID="ddlVertical" runat="server" TabIndex="14" CssClass="ddlfildadm">
                        </asp:DropDownList>
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeladmenq">
                        &nbsp;Sales Rep:</div>
                    <div class="txtfildwrapadm">
                        <asp:DropDownList ID="ddlSalesRep" runat="server" TabIndex="15" CssClass="ddlfildadm">
                        </asp:DropDownList>
                    </div>
                    <div class="clear10">
                    </div>
                </div>
                <div class="clear41">
                </div>
                <div class="clear41">
                </div>
                <div class="submitadm">
                    <asp:LinkButton ID="lnkBack" runat="server" CausesValidation="false" TabIndex="16"
                        OnClick="LnkBackClick"><img src="../images/Admin/cancel.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkSave" runat="server" OnClick="LnkSubmitClick" CausesValidation="true"
                        TabIndex="17" ValidationGroup="A"><img src="../images/Admin/save.png" alt="" /></asp:LinkButton>
                </div>
                <div class="clear10">
                </div>
                <div class="submitadm">
                    <asp:LinkButton ID="lnkNotes" runat="server" CausesValidation="false" TabIndex="18"
                        OnClientClick="return ShortCut();"><img src="../images/Admin/notes.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkbNotes" runat="server" CausesValidation="false" Visible="false"
                        TabIndex="18" OnClientClick="return ShortCut();"><img src="../images/Admin/NewNotes.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkPayment" runat="server" CausesValidation="true" TabIndex="19"
                        OnClick="LnkPaymentClick" ValidationGroup="A"><img src="../images/Admin/payment.png" alt="" /></asp:LinkButton>
                    <%--<asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" TabIndex="20"
                        OnClick="LnkAddClick"><img src="../images/Admin/addidtls.png" alt="" /></asp:LinkButton>--%>
                    <asp:LinkButton ID="lnkActivateAcnt" runat="server" CausesValidation="true" TabIndex="21"
                        Visible="false" OnClick="LnkActivateAcntClick" ValidationGroup="A"><img src="../images/Admin/aaccountnew.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkcancel" runat="server" CausesValidation="false" TabIndex="22"
                        OnClick="LnkcancelClick" Visible="false"><img src="../images/Admin/gotodashbrd.png" alt="" /></asp:LinkButton>
                </div>
                <asp:HiddenField ID="hdnFlag" runat="server" />
                <asp:HiddenField ID="hdnNotesCnt" runat="server" />
                <asp:HiddenField ID="hdnInquiryId" runat="server" />
                <asp:HiddenField ID="hdnParent" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblcreateshortcut" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popcreateshortcut" runat="server" TargetControlID="lblcreateshortcut"
                PopupControlID="pnlcreateshortcut" BackgroundCssClass="modal" BehaviorID="createshortcut"
                CancelControlID="imgclse">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlcreateshortcut" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" class="reveal-modal">
                    <tbody>
                        <tr>
                            <td align="left">
                                <div class="pageheading">
                                    &nbsp; Notes
                                </div>
                            </td>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imgclse" runat="server" OnClick="ImgclseClick" CausesValidation="false"
                                    ImageUrl="~/images/admin/close.png" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <iframe src="../ProfileIframes/AddNotes.aspx?ID=<%=InquiryId%>" frameborder="0" scrolling="no"
                                    height="500px" width="600px" style="border: 1px;" id="frmShortcut"></iframe>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div>
                    <a class="close-reveal-modal">&#215;</a></div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShortCut() {
            var modalDialog = $find("createshortcut");
            var iframe = document.getElementById('frmShortcut');
            modalDialog.show();
            return false;
        }
        function CheckProcess() {
            alert('Work in progress.')
            return false;
        }
    </script>
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
