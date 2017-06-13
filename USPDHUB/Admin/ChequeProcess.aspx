<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ChequeProcess.aspx.cs" Inherits="USPDHUB.Admin.ChequeProcess" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../css/reveal.css" rel="stylesheet" type="text/css" />
    <link href="../css/buttonstyles.css" rel="stylesheet" type="text/css" />
    <script src="<%=Page.ResolveClientUrl("~/jquery.js")%>" type="text/javascript"></script>
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
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div>
                <div class="clear15">
                </div>
                <div class="adminpagehead">
                    Payment Information</div>
                <div align="center">
                    <img src="../images/Admin/shadow-title.png" /></div>
                <div class="adminformwrap">
                    <div class="clear10">
                    </div>
                    <div class="errormsg_text">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                    <div style="text-align: center;">
                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:HiddenField ID="hdnVertical" runat="server" />
                        <asp:HiddenField ID="hdnDomain" runat="server" />
                        <asp:HiddenField ID="hdnPCPercent" runat="server" />
                    </div>
                    <div class="clear15">
                    </div>
                    <div class="labeladm">
                        <strong>Subscription Type:</strong></div>
                    <div class="txtfildwrap2" align="left">
                        <asp:DropDownList ID="ddlSubscriptions" runat="server" CssClass="selectmen-big" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlSubscriptions_OnSelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="clear15">
                    </div>
                    <div class="labeladm">
                        Promo Code:
                    </div>
                    <div class="txtfildwrap2" align="left">
                        <asp:TextBox ID="txtPromoCode" runat="server" class="textfieldadm2"></asp:TextBox>&nbsp;&nbsp;<asp:Button
                            ID="btnValidatePromo" runat="server" Text="Validate" CausesValidation="false"
                            OnClick="btnValidatePromo_Click" />
                    </div>
                    <div class="clear15">
                    </div>
                    <div class="divwrap">
                        <div class="csdiv-heads">
                            Invoice Details</div>
                        <div class="csdivwrap">
                            <div class="clear15">
                            </div>
                            <div class="labeladm">
                                Subscription Amount:</div>
                            <div class="payalign">
                                <strong>$
                                    <asp:Label ID="lblCheckSubAmount" runat="server" Text="0.00"></asp:Label></strong></div>
                            <div class="clear10">
                            </div>
                            <asp:Panel ID="pnlcheckOneTimeFee" runat="server">
                                <div class="labeladm">
                                    One Time Setup Fee:</div>
                                <div>
                                    <strong>$
                                        <asp:Label ID="lblCheckOneTime" runat="server" Text="0.00"></asp:Label></strong></div>
                                <div class="clear10">
                                </div>
                            </asp:Panel>
                            <div class="labeladm">
                                Subtotal:</div>
                            <div>
                                <strong>$
                                    <asp:Label ID="lblCheckSub" Text="0.00" runat="server"></asp:Label></strong></div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Discount:</div>
                            <div class="payalign">
                                <strong>$
                                    <asp:Label ID="lblCheckDiscount" runat="server" Text="0.00"></asp:Label></strong></div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Total Amount:</div>
                            <div>
                                <strong>$
                                    <asp:Label ID="lblCheckTotal" runat="server"></asp:Label></strong></div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                PO # (if any):</div>
                            <div>
                                <asp:TextBox ID="txtPurchaseOrder" runat="server" MaxLength="50" CssClass="textfieldadm2"></asp:TextBox></div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Email to send Invoice:</div>
                            <div>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="textfieldadm2"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator3" SetFocusOnError="true" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ValidationGroup="V" Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Billing First Name:</div>
                            <div>
                                <asp:TextBox ID="txtContactName" runat="server" CssClass="textfieldadm2"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator4" SetFocusOnError="true" runat="server" ControlToValidate="txtContactName"
                                    Display="Dynamic" ValidationGroup="V" Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Billing Last Name:</div>
                            <div>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="textfieldadm2"></asp:TextBox></div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Billing Address:</div>
                            <div>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="textfieldadm2"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator5" SetFocusOnError="true" runat="server" ControlToValidate="txtAddress"
                                    Display="Dynamic" ValidationGroup="V" Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Billing City:</div>
                            <div>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="textfieldadm2"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator8" SetFocusOnError="true" runat="server" ControlToValidate="txtCity"
                                    Display="Dynamic" ValidationGroup="V" Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Billing State</div>
                            <div>
                                <asp:DropDownList ID="ddlState" runat="server" ValidationGroup="V" Width="150" Style="padding: 2px;"
                                    ClientIDMode="Static">
                                    <asp:ListItem Text="Select State" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="AK" Value="AK"></asp:ListItem>
                                    <asp:ListItem Text="AL" Value="AL"></asp:ListItem>
                                    <asp:ListItem Text="AR" Value="AR"></asp:ListItem>
                                    <asp:ListItem Text="AZ" Value="AZ"></asp:ListItem>
                                    <asp:ListItem Text="CA" Value="CA"></asp:ListItem>
                                    <asp:ListItem Text="CO" Value="CO"></asp:ListItem>
                                    <asp:ListItem Text="CT" Value="CT"></asp:ListItem>
                                    <asp:ListItem Text="DC" Value="DC"></asp:ListItem>
                                    <asp:ListItem Text="DE" Value="DE"></asp:ListItem>
                                    <asp:ListItem Text="FL" Value="FL"></asp:ListItem>
                                    <asp:ListItem Text="GA" Value="GA"></asp:ListItem>
                                    <asp:ListItem Text="HI" Value="HI"></asp:ListItem>
                                    <asp:ListItem Text="IA" Value="IA"></asp:ListItem>
                                    <asp:ListItem Text="ID" Value="ID"></asp:ListItem>
                                    <asp:ListItem Text="IL" Value="IL"></asp:ListItem>
                                    <asp:ListItem Text="IN" Value="IN"></asp:ListItem>
                                    <asp:ListItem Text="KS" Value="KS"></asp:ListItem>
                                    <asp:ListItem Text="KY" Value="KY"></asp:ListItem>
                                    <asp:ListItem Text="LA" Value="LA"></asp:ListItem>
                                    <asp:ListItem Text="MA" Value="MA"></asp:ListItem>
                                    <asp:ListItem Text="MD" Value="MD"></asp:ListItem>
                                    <asp:ListItem Text="ME" Value="ME"></asp:ListItem>
                                    <asp:ListItem Text="MI" Value="MI"></asp:ListItem>
                                    <asp:ListItem Text="MN" Value="MN"></asp:ListItem>
                                    <asp:ListItem Text="MO" Value="MO"></asp:ListItem>
                                    <asp:ListItem Text="MS" Value="MS"></asp:ListItem>
                                    <asp:ListItem Text="MT" Value="MT"></asp:ListItem>
                                    <asp:ListItem Text="NC" Value="NC"></asp:ListItem>
                                    <asp:ListItem Text="ND" Value="ND"></asp:ListItem>
                                    <asp:ListItem Text="NE" Value="NE"></asp:ListItem>
                                    <asp:ListItem Text="NH" Value="NH"></asp:ListItem>
                                    <asp:ListItem Text="NJ" Value="NJ"></asp:ListItem>
                                    <asp:ListItem Text="NM" Value="NM"></asp:ListItem>
                                    <asp:ListItem Text="NV" Value="NV"></asp:ListItem>
                                    <asp:ListItem Text="NY" Value="NY"></asp:ListItem>
                                    <asp:ListItem Text="OH" Value="OH"></asp:ListItem>
                                    <asp:ListItem Text="OK" Value="OK"></asp:ListItem>
                                    <asp:ListItem Text="OR" Value="OR"></asp:ListItem>
                                    <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                                    <asp:ListItem Text="RI" Value="RI"></asp:ListItem>
                                    <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                                    <asp:ListItem Text="SD" Value="SD"></asp:ListItem>
                                    <asp:ListItem Text="TN" Value="TN"></asp:ListItem>
                                    <asp:ListItem Text="TX" Value="TX"></asp:ListItem>
                                    <asp:ListItem Text="UT" Value="UT"></asp:ListItem>
                                    <asp:ListItem Text="VA" Value="VA"></asp:ListItem>
                                    <asp:ListItem Text="VT" Value="VT"></asp:ListItem>
                                    <asp:ListItem Text="WA" Value="WA"></asp:ListItem>
                                    <asp:ListItem Text="WI" Value="WI"></asp:ListItem>
                                    <asp:ListItem Text="WV" Value="WV"></asp:ListItem>
                                    <asp:ListItem Text="WY" Value="WY"></asp:ListItem>
                                    <asp:ListItem Text="AA" Value="AA"></asp:ListItem>
                                    <asp:ListItem Text="AE" Value="AE"></asp:ListItem>
                                    <asp:ListItem Text="AP" Value="AP"></asp:ListItem>
                                    <asp:ListItem Text="AS" Value="AS"></asp:ListItem>
                                    <asp:ListItem Text="FM" Value="FM"></asp:ListItem>
                                    <asp:ListItem Text="GU" Value="GU"></asp:ListItem>
                                    <asp:ListItem Text="MH" Value="MH"></asp:ListItem>
                                    <asp:ListItem Text="MP" Value="MP"></asp:ListItem>
                                    <asp:ListItem Text="PR" Value="PR"></asp:ListItem>
                                    <asp:ListItem Text="PW" Value="PW"></asp:ListItem>
                                    <asp:ListItem Text="VI" Value="VI"></asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                                <asp:RequiredFieldValidator ID="reqstate" runat="server" ControlToValidate="ddlState"
                                    Display="Dynamic" Font-Size="X-Large" InitialValue="0" SetFocusOnError="true"
                                    ValidationGroup="V">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Billing Zip Code:</div>
                            <div>
                                <asp:TextBox ID="txtzip" runat="server" MaxLength="5" CssClass="textfieldadm2" ClientIDMode="Static"
                                    onkeypress="return isNumber(event)"></asp:TextBox>
                                &nbsp;
                                <asp:RequiredFieldValidator ID="reqzipcode" runat="server" ControlToValidate="txtzip"
                                    Display="Dynamic" Font-Size="X-Large" SetFocusOnError="true" ValidationGroup="V">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                                    Display="Dynamic" Font-Size="X-Large" ControlToValidate="txtzip" ValidationExpression="^[0-9]{5,5}$"
                                    SetFocusOnError="True" ValidationGroup="V">*</asp:RegularExpressionValidator>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Billing Phone Number:</div>
                            <div>
                                <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtPhone"
                                    WatermarkText="xxx-xxx-xxxx" WatermarkCssClass="textfieldadm2" runat="server">
                                </cc1:TextBoxWatermarkExtender>
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="textfieldadm2"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator6" SetFocusOnError="true" runat="server" ControlToValidate="txtPhone"
                                    Display="Dynamic" ValidationGroup="V" Font-Size="X-Large">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="regExpValPhone" runat="server" ControlToValidate="txtPhone" SetFocusOnError="true"
                                        Font-Size="X-Large" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$" ValidationGroup="V"
                                        Display="Dynamic">*</asp:RegularExpressionValidator>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Billing Email ID:</div>
                            <div>
                                <asp:TextBox ID="txtEmailID" runat="server" CssClass="textfieldadm2"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator7" SetFocusOnError="true" runat="server" ControlToValidate="txtEmailID"
                                    Display="Dynamic" ValidationGroup="V" Font-Size="X-Large">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="regExpValEmail" runat="server" ControlToValidate="txtEmailID" SetFocusOnError="true"
                                        Font-Size="X-Large" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="V">*</asp:RegularExpressionValidator>
                            </div>
                            <div class="clear10">
                            </div>
                            <div class="labeladm">
                                Custom Notes:</div>
                            <div>
                                <asp:TextBox ID="txtCustomNotes" runat="server" TextMode="MultiLine" Height="100px"></asp:TextBox>
                            </div>
                            <div class="clear10">
                            </div>
                            <div style="height: 7px;">
                            </div>
                            <div align="right">
                                <asp:LinkButton ID="lnkInvoice" runat="server" ValidationGroup="V" OnClick="lnkInvoice_OnClick"><img src="../images/Admin/candsinvoice.png" alt="" /></asp:LinkButton>
                            </div>
                            <div class="clear10">
                            </div>
                        </div>
                    </div>
                    <asp:Panel ID="pnlCheckPayment" runat="server">
                        <div class="divwrap">
                            <div class="csdiv-heads">
                                Payment Details</div>
                            <div class="csdivwrap">
                                <div class="clear10">
                                </div>
                                <div class="labeladm">
                                    Invoice Date:</div>
                                <div>
                                    <strong>
                                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label></strong></div>
                                <div class="clear10">
                                </div>
                                <div class="labeladm">
                                    Invoice Amount:</div>
                                <div>
                                    <strong>$
                                        <asp:Label ID="lblInvoiceAmt" runat="server"></asp:Label></strong></div>
                                <div class="clear10">
                                </div>
                                <div class="labeladm">
                                    Check Number:</div>
                                <div>
                                    <asp:TextBox ID="txtCheckNum" runat="server" CssClass="textfieldadm2"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator2" SetFocusOnError="true" runat="server" ControlToValidate="txtCheckNum"
                                        Display="Dynamic" ValidationGroup="C" Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                                <div class="clear10">
                                </div>
                                <div class="labeladm">
                                    Check Amount:</div>
                                <div>
                                    <asp:TextBox ID="txtCheckAmt" runat="server" CssClass="textfieldadm2"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" SetFocusOnError="true" runat="server" ControlToValidate="txtCheckAmt"
                                        Display="Dynamic" ValidationGroup="C" Font-Size="X-Large">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator1" SetFocusOnError="true" ControlToValidate="txtCheckAmt"
                                            runat="server" Display="Dynamic" ValidationExpression="^\d*\.?\d\d$" ValidationGroup="C">Enter valid amount.</asp:RegularExpressionValidator></div>
                                <div class="clear10">
                                </div>
                                <div align="right">
                                    <asp:LinkButton ID="lnkProcessCheck" runat="server" ValidationGroup="C" OnClick="lnkProcessCheck_OnClick"><img src="../images/Admin/applypayment.png" alt="" /></asp:LinkButton>
                                </div>
                                <div class="clear10">
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="clear15">
                    </div>
                    <div class="clear10">
                    </div>
                </div>
                <div class="clear41">
                </div>
                <div class="submitadm">
                    <asp:LinkButton ID="lnkNotes" runat="server" CausesValidation="false" TabIndex="9"
                        OnClientClick="return ShortCut();"><img src="../images/Admin/notes.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkbNotes" runat="server" CausesValidation="false" Visible="false"
                        TabIndex="9" OnClientClick="return ShortCut();"><img src="../images/Admin/NewNotes.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkMainScreen" runat="server" CausesValidation="false" OnClick="lnkMainScreen_OnClick"><img src="../images/Admin/gtmscreen-btn.png" alt="" /></asp:LinkButton>
                    <asp:HiddenField ID="hdnNotesCnt" runat="server" />
                    <asp:HiddenField ID="hdnSetupFee" runat="server" />
                    <asp:HiddenField ID="hdnSetupSID" runat="server" />
                    <asp:HiddenField ID="hdnProductId" runat="server" />
                </div>
            </div>
            <div>
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
                                    <asp:ImageButton ID="imgclse" runat="server" CausesValidation="false" ImageUrl="~/images/admin/close.png" />
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
                <asp:Label ID="lblInvoicePop" runat="server"></asp:Label>
                <cc1:ModalPopupExtender ID="ModalInvoicePop" runat="server" TargetControlID="lblInvoicePop"
                    PopupControlID="pnlInvoicePop" BackgroundCssClass="modal" CancelControlID="imgInvoiceClose">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlInvoicePop" runat="server" Style="display: none" Width="600px">
                    <table cellpadding="0" cellspacing="0" class="reveal-modal" style="top: 0px; margin-left: -445px;
                        padding: 0px;">
                        <tbody>
                            <tr>
                                <td align="left">
                                    <div class="pageheading">
                                        &nbsp; Invoice for:
                                        <asp:Label ID="lblInvoiceEmailtTo" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td align="right" style="padding: 5px 10px 0px 10px;">
                                    <asp:ImageButton ID="imgInvoiceClose" runat="server" CausesValidation="false" ImageUrl="~/images/admin/close.png" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 500px; position: relative; width: 960px; padding-right: 30px;
                                        overflow-x: auto;">
                                        <asp:Label ID="lblInvoicePreview" runat="server" Width="300px" Height="500px"></asp:Label>
                                    </div>
                                    <asp:HiddenField ID="hdnContactname" runat="server" />
                                    <asp:HiddenField ID="hdnInvoiceLocation" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:LinkButton ID="lnkSendInvoice" runat="server" Text="Send" CssClass="btn btn-default"
                                        OnClick="lnkSendInvoice_OnClick"></asp:LinkButton>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function ShortCut() {
            var modalDialog = $find("createshortcut");
            //var iframe = document.getElementById('frmShortcut');
            modalDialog.show();
            return false;
        }
    </script>
</asp:Content>
