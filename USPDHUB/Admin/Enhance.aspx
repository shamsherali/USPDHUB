<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="Enhance.aspx.cs" Inherits="USPDHUB.Admin.Enhance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../css/reveal.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnIsSubAccount" runat="server" />
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
                            OnSelectedIndexChanged="DdlSubscriptionsChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="clear15">
                    </div>
                    <asp:Panel ID="pnlPromo" runat="server">
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
                    </asp:Panel>
                    <div class="labeladm">
                        <span class="errormsgadm">*</span>Payment Method:</div>
                    <div class="txtfildwrapadm">
                        <asp:RadioButton ID="rbCard" runat="server" GroupName="P" AutoPostBack="true" OnCheckedChanged="RbCardClick" />
                        Credit Card
                        <asp:RadioButton ID="rbCheck" runat="server" GroupName="P" AutoPostBack="true" OnCheckedChanged="RbCardClick" />
                        Bill Me
                        <asp:RadioButton ID="rbFree" runat="server" GroupName="P" AutoPostBack="true" OnCheckedChanged="RbCardClick" />
                        Free
                    </div>
                    <div class="clear10">
                    </div>
                    <asp:Panel ID="pnlNoCheck" runat="server">
                        <div class="labeladm">
                        </div>
                        <div class="txtfildwrapadm">
                            <div class="ccdivwrap">
                                <%--<%if (!ddlSubscriptions.SelectedItem.Text.Contains("Branded App") && hdnIsSubAccount.Value == "")
                                  { %>
                                <asp:RadioButton ID="rbMonth" runat="server" GroupName="M" AutoPostBack="true" Checked="true"
                                    OnCheckedChanged="RbMonthCheckedChanged" />
                                Monthly
                                <%} %>
                                <asp:RadioButton ID="rbYear" runat="server" GroupName="M" AutoPostBack="true" OnCheckedChanged="RbMonthCheckedChanged" />
                                Annually--%>
                                Membership Details for
                                <%if (!ddlSubscriptions.SelectedItem.Text.Contains("Branded App") && hdnIsSubAccount.Value == "")
                                  { %>
                                Monthly
                                <%}
                                  else
                                  {%>
                                Annual
                                <%} %>
                                <div class="clear10">
                                </div>
                                <asp:Panel ID="pnlCard" runat="server">
                                    <div class="labeladm">
                                        Subscription Amount:</div>
                                    <div class="payalign">
                                        <strong>$
                                            <asp:Label ID="lblSubscAmount" runat="server"></asp:Label></strong></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        Discount:</div>
                                    <div class="payalign">
                                        <strong>$
                                            <asp:Label ID="lblDiscount" runat="server"></asp:Label></strong></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        Subtotal:</div>
                                    <div class="payalign">
                                        <strong>$
                                            <asp:Label ID="lblTotalAmt" runat="server"></asp:Label></strong></div>
                                    <div class="clear10">
                                    </div>
                                    <asp:Panel ID="pnlOneTimeSetup" runat="server">
                                        <div class="labeladm">
                                            One Time Setup Fee:</div>
                                        <div>
                                            <strong>$
                                                <asp:Label ID="lblOneTimeFee" runat="server" Text="750.00"></asp:Label></strong></div>
                                        <div class="clear10">
                                        </div>
                                        <div class="labeladm">
                                            Total Amount:</div>
                                        <div>
                                            <strong>$
                                                <asp:Label ID="lblTotalBllAmt" runat="server"></asp:Label></strong></div>
                                        <div class="clear10">
                                        </div>
                                    </asp:Panel>
                                    <div class="labeladm">
                                        We Accept:</div>
                                    <div>
                                        <img src="../images/admin/visa.gif" width="41" height="27" />&nbsp;<img src="../images/admin/mastercardnew.gif"
                                            width="41" height="27" />&nbsp;<img src="../images/admin/americanexp.gif" width="41"
                                                height="27" />&nbsp;<img src="../images/admin/discover.gif" width="43" height="29" />
                                    </div>
                                    <div class="clear10">
                                    </div>
                                    <div class="errormsgadm1">
                                        * Marked fields are mandatory.<br />
                                        <span>Enter Credit Card details to finish Payment Process</span></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        <span class="errormsgadm">*</span>Card Type:</div>
                                    <div class="txtfildwrap2">
                                        <asp:DropDownList ID="ddlCardType" runat="server" ValidationGroup="g" CssClass="selectmen">
                                            <asp:ListItem Value="0" Text="Select Card Type"></asp:ListItem>
                                            <asp:ListItem Value="Visa" Text="Visa"></asp:ListItem>
                                            <asp:ListItem Value="MasterCard" Text="MasterCard"></asp:ListItem>
                                            <asp:ListItem Value="American Express" Text="American Express"></asp:ListItem>
                                            <asp:ListItem Value="Discover" Text="Discover"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="RFVddlct" runat="server" ControlToValidate="ddlCardType"
                                            Display="Dynamic" SetFocusOnError="true" InitialValue="0" Font-Size="X-Large"
                                            ValidationGroup="g">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        <span class="errormsgadm">*</span>First Name:</div>
                                    <div class="txtfildwrap2">
                                        <asp:TextBox ID="txtfirstName" runat="server" MaxLength="30" ValidationGroup="g"
                                            class="textfieldadm2"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="reqfirstname" runat="server" ControlToValidate="txtfirstName"
                                            Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="g">*</asp:RequiredFieldValidator></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        <span class="errormsgadm">*</span>Last Name:</div>
                                    <div class="txtfildwrap2">
                                        <asp:TextBox ID="txtlastname" runat="server" MaxLength="32" ValidationGroup="g" class="textfieldadm2"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="reqlastname" runat="server" ControlToValidate="txtlastname"
                                            Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="g">*</asp:RequiredFieldValidator></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        <span class="errormsgadm">*</span>Card Number:</div>
                                    <div class="txtfildwrap2">
                                        <asp:TextBox ID="txtcreditCardNumber" runat="server" MaxLength="19" ValidationGroup="g"
                                            class="textfieldadm2"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="reqcardnumber" Font-Size="X-Large" runat="server"
                                            ControlToValidate="txtcreditCardNumber" Display="Dynamic" SetFocusOnError="true"
                                            ValidationGroup="g">*</asp:RequiredFieldValidator></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm-ver">
                                        <span class="errormsgadm">*</span>Expiration Date (mm/dd):</div>
                                    <div class="txtfildwrap">
                                        <div class="w50">
                                            <asp:TextBox ID="txtexpmonth" runat="server" CssClass="textfieldadm2-small"></asp:TextBox>&nbsp;
                                            <asp:RequiredFieldValidator ID="reqmonth" runat="server" ControlToValidate="txtexpmonth"
                                                Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="regMonthValidate" SetFocusOnError="true" ControlToValidate="txtexpmonth"
                                                runat="server" Display="Dynamic" ValidationExpression="^((0[1-9])|(1[0-2]))$"
                                                Font-Size="X-Large" ValidationGroup="g">*</asp:RegularExpressionValidator>
                                            <span>/</span></div>
                                        <div class="w50">
                                            <asp:TextBox ID="txtexpyear" runat="server" CssClass="textfieldadm2-small"></asp:TextBox>&nbsp;
                                            <asp:RequiredFieldValidator ID="reqyear" runat="server" ControlToValidate="txtexpyear"
                                                Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="g">*</asp:RequiredFieldValidator></div>
                                        <div class="clear">
                                        </div>
                                        <div class="labeladm-ver">
                                        </div>
                                        <div class="w50m">
                                            Ex:01</div>
                                        <div class="w50m">
                                            13</div>
                                    </div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm-ver">
                                        <span class="errormsgadm">*</span>Card Verification Number:</div>
                                    <div class="txtfildwrap">
                                        <div class="w50">
                                            <asp:TextBox ID="txtcvv2Number" runat="server" MaxLength="4" ValidationGroup="g"
                                                class="textfieldadm2-small"></asp:TextBox>&nbsp;
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="reqcvv" Font-Size="X-Large"
                                                runat="server" ControlToValidate="txtcvv2Number" Display="Dynamic" ValidationGroup="g">*</asp:RequiredFieldValidator></div>
                                    </div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm-ver">
                                        <span class="errormsgadm">*</span>Recurring Membership:</div>
                                    <div class="txtfildwrap">
                                        <div class="w50">
                                            <asp:CheckBox ID="chkRecurring" runat="server" Checked="true" />
                                        </div>
                                    </div>
                                    <div class="clear10">
                                    </div>
                                    <div class="note">
                                        <span>Note:</span> Card verification number will be the last 3 digits on the back
                                        of your card. For American Express cards it will be a 4 digit number on the face
                                        of your card.
                                    </div>
                                    <div class="clear15">
                                    </div>
                                    <div class="labeladm">
                                        <strong>Billing Address</strong></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        <span class="errormsgadm">*</span>Address 1:</div>
                                    <div class="txtfildwrap2">
                                        <asp:TextBox ID="txtaddress1" runat="server" MaxLength="100" ValidationGroup="g"
                                            class="textfieldadm2"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="reqaddress1" SetFocusOnError="true" runat="server"
                                            ControlToValidate="txtaddress1" Display="Dynamic" ValidationGroup="g" Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        &nbsp;&nbsp;Address 2:</div>
                                    <div class="txtfildwrap2">
                                        <asp:TextBox ID="txtaddress2" runat="server" MaxLength="100" class="textfieldadm2"></asp:TextBox></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        <span class="errormsgadm">*</span>City:</div>
                                    <div class="txtfildwrap2">
                                        <asp:TextBox ID="txtcity" runat="server" MaxLength="40" ValidationGroup="g" class="textfieldadm2"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="reqcity" SetFocusOnError="true" runat="server" ControlToValidate="txtcity"
                                            Display="Dynamic" ValidationGroup="g" Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        <span class="errormsgadm">*</span>State:</div>
                                    <div class="txtfildwrap2">
                                        <asp:DropDownList ID="DrpState" runat="server" ValidationGroup="g" CssClass="selectmen">
                                            <asp:ListItem Value="0" Text="Select State"></asp:ListItem>
                                            <asp:ListItem Value="AK" Text="AK"></asp:ListItem>
                                            <asp:ListItem Value="AL" Text="AL"></asp:ListItem>
                                            <asp:ListItem Value="AR" Text="AR"></asp:ListItem>
                                            <asp:ListItem Value="AZ" Text="AZ"></asp:ListItem>
                                            <asp:ListItem Value="CA" Text="CA"></asp:ListItem>
                                            <asp:ListItem Value="CO" Text="CO"></asp:ListItem>
                                            <asp:ListItem Value="CT" Text="CT"></asp:ListItem>
                                            <asp:ListItem Value="DC" Text="DC"></asp:ListItem>
                                            <asp:ListItem Value="DE" Text="DE"></asp:ListItem>
                                            <asp:ListItem Value="FL" Text="FL"></asp:ListItem>
                                            <asp:ListItem Value="GA" Text="GA"></asp:ListItem>
                                            <asp:ListItem Value="HI" Text="HI"></asp:ListItem>
                                            <asp:ListItem Value="IA" Text="IA"></asp:ListItem>
                                            <asp:ListItem Value="ID" Text="ID"></asp:ListItem>
                                            <asp:ListItem Value="IL" Text="IL"></asp:ListItem>
                                            <asp:ListItem Value="IN" Text="IN"></asp:ListItem>
                                            <asp:ListItem Value="KS" Text="KS"></asp:ListItem>
                                            <asp:ListItem Value="KY" Text="KY"></asp:ListItem>
                                            <asp:ListItem Value="LA" Text="LA"></asp:ListItem>
                                            <asp:ListItem Value="MA" Text="MA"></asp:ListItem>
                                            <asp:ListItem Value="MD" Text="MD"></asp:ListItem>
                                            <asp:ListItem Value="ME" Text="ME"></asp:ListItem>
                                            <asp:ListItem Value="MI" Text="MI"></asp:ListItem>
                                            <asp:ListItem Value="MN" Text="MN"></asp:ListItem>
                                            <asp:ListItem Value="MO" Text="MO"></asp:ListItem>
                                            <asp:ListItem Value="MS" Text="MS"></asp:ListItem>
                                            <asp:ListItem Value="MT" Text="MT"></asp:ListItem>
                                            <asp:ListItem Value="NC" Text="NC"></asp:ListItem>
                                            <asp:ListItem Value="ND" Text="ND"></asp:ListItem>
                                            <asp:ListItem Value="NE" Text="NE"></asp:ListItem>
                                            <asp:ListItem Value="NH" Text="NH"></asp:ListItem>
                                            <asp:ListItem Value="NJ" Text="NJ"></asp:ListItem>
                                            <asp:ListItem Value="NM" Text="NM"></asp:ListItem>
                                            <asp:ListItem Value="NV" Text="NV"></asp:ListItem>
                                            <asp:ListItem Value="NY" Text="NY"></asp:ListItem>
                                            <asp:ListItem Value="OH" Text="OH"></asp:ListItem>
                                            <asp:ListItem Value="OK" Text="OK"></asp:ListItem>
                                            <asp:ListItem Value="OR" Text="OR"></asp:ListItem>
                                            <asp:ListItem Value="PA" Text="PA"></asp:ListItem>
                                            <asp:ListItem Value="RI" Text="RI"></asp:ListItem>
                                            <asp:ListItem Value="SC" Text="SC"></asp:ListItem>
                                            <asp:ListItem Value="SD" Text="SD"></asp:ListItem>
                                            <asp:ListItem Value="TN" Text="TN"></asp:ListItem>
                                            <asp:ListItem Value="TX" Text="TX"></asp:ListItem>
                                            <asp:ListItem Value="UT" Text="UT"></asp:ListItem>
                                            <asp:ListItem Value="VA" Text="VA"></asp:ListItem>
                                            <asp:ListItem Value="VT" Text="VT"></asp:ListItem>
                                            <asp:ListItem Value="WA" Text="WA"></asp:ListItem>
                                            <asp:ListItem Value="WI" Text="WI"></asp:ListItem>
                                            <asp:ListItem Value="WV" Text="WV"></asp:ListItem>
                                            <asp:ListItem Value="WY" Text="WY"></asp:ListItem>
                                            <asp:ListItem Value="AA" Text="AA"></asp:ListItem>
                                            <asp:ListItem Value="AE" Text="AE"></asp:ListItem>
                                            <asp:ListItem Value="AP" Text="AP"></asp:ListItem>
                                            <asp:ListItem Value="AS" Text="AS"></asp:ListItem>
                                            <asp:ListItem Value="FM" Text="FM"></asp:ListItem>
                                            <asp:ListItem Value="GU" Text="GU"></asp:ListItem>
                                            <asp:ListItem Value="MH" Text="MH"></asp:ListItem>
                                            <asp:ListItem Value="MP" Text="MP"></asp:ListItem>
                                            <asp:ListItem Value="PR" Text="PR"></asp:ListItem>
                                            <asp:ListItem Value="PW" Text="PW"></asp:ListItem>
                                            <asp:ListItem Value="VI" Text="VI"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:RequiredFieldValidator ID="reqstate" runat="server" ControlToValidate="DrpState"
                                            Display="Dynamic" InitialValue="0" SetFocusOnError="true" ValidationGroup="g"
                                            Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        <span class="errormsgadm">*</span>Zip Code:</div>
                                    <div class="txtfildwrap2">
                                        <asp:TextBox ID="txtzip" runat="server" MaxLength="10" ValidationGroup="g" class="textfieldadm2"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="reqzipcode" runat="server" ControlToValidate="txtzip"
                                            Display="Dynamic" ValidationGroup="g" SetFocusOnError="true" Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        <span class="errormsgadm">*</span>Country:</div>
                                    <div>
                                        United States</div>
                                    <div class="clear10">
                                    </div>
                                    <div class="clear15">
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlCheck" runat="server">
                        <div class="divwrap">
                            <div class="csdiv-heads">
                                Invoice Details</div>
                            <div class="csdivwrap">
                                <%--<asp:RadioButton ID="rbCheckYear" runat="server" Checked="true" GroupName="C" />
                                Annually--%>
                                Membership Details for
                                <%if (!ddlSubscriptions.SelectedItem.Text.Contains("Branded App") && hdnIsSubAccount.Value == "")
                                  { %>
                                Monthly
                                <%}
                                  else
                                  {%>
                                Annual
                                <%} %>
                                <div class="clear15">
                                </div>
                                <div class="labeladm">
                                    Subscription Amount:</div>
                                <div class="payalign">
                                    <strong>$
                                        <asp:Label ID="lblCheckSubAmount" runat="server"></asp:Label></strong></div>
                                <div class="clear10">
                                </div>
                                <div class="labeladm">
                                    Discount:</div>
                                <div class="payalign">
                                    <strong>$
                                        <asp:Label ID="lblCheckDiscount" runat="server"></asp:Label></strong></div>
                                <div class="clear10">
                                </div>
                                <div class="labeladm">
                                    Subtotal:</div>
                                <div>
                                    <strong>$
                                        <asp:Label ID="lblCheckAmt" Text="0.00" runat="server"></asp:Label></strong></div>
                                <div class="clear10">
                                </div>
                                <asp:Panel ID="pnlcheckOneTimeFee" runat="server">
                                    <div class="labeladm">
                                        One Time Setup Fee:</div>
                                    <div>
                                        <strong>$
                                            <asp:Label ID="lblCheckOneTime" runat="server" Text="750.00"></asp:Label></strong></div>
                                    <div class="clear10">
                                    </div>
                                    <div class="labeladm">
                                        Total Amount:</div>
                                    <div>
                                        <strong>$
                                            <asp:Label ID="lblCheckTotal" runat="server"></asp:Label></strong></div>
                                    <div class="clear10">
                                    </div>
                                </asp:Panel>
                                <div class="labeladm">
                                    PO No (if any):</div>
                                <div>
                                    <asp:TextBox ID="txtPurchaseOrder" runat="server" MaxLength="50" CssClass="textfieldadm2"></asp:TextBox></div>
                                <div class="clear10">
                                </div>
                                <div class="labeladm">
                                    Email to send Invoice:</div>
                                <div>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textfieldadm2"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" SetFocusOnError="true" runat="server" ControlToValidate="txtEmail"
                                        Display="Dynamic" ValidationGroup="V" Font-Size="X-Large">*</asp:RequiredFieldValidator></div>
                                <div class="clear10">
                                </div>
                                <div style="height: 7px;">
                                </div>
                                <div align="right">
                                    <asp:LinkButton ID="lnkInvoice" runat="server" ValidationGroup="V" OnClick="LnkInvoiceClick"><img src="../images/Admin/candsinvoice.png" alt="" /></asp:LinkButton>
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
                                        <asp:LinkButton ID="lnkProcessCheck" runat="server" ValidationGroup="C" OnClick="LnkProcessCheckClick"><img src="../images/Admin/applypayment.png" alt="" /></asp:LinkButton>
                                    </div>
                                    <div class="clear10">
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                    <div class="clear15">
                    </div>
                    <div class="clear10">
                    </div>
                </div>
                <div class="clear41">
                </div>
                <div class="submitadm">
                    <asp:LinkButton ID="lnkCheckOut" runat="server" ValidationGroup="g" OnClick="LnkCheckOutClick"><img src="../images/Admin/ppayment.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkActivateAcnt" runat="server" CausesValidation="false" OnClick="LnkActivateAcntClick"><img src="../images/Admin/aaccount.png" alt="" /></asp:LinkButton>
                </div>
                <div class="clear15">
                </div>
                <div class="submitadm">
                    <asp:LinkButton ID="lnkNotes" runat="server" CausesValidation="false" TabIndex="9"
                        OnClientClick="return ShortCut();"><img src="../images/Admin/notes.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkbNotes" runat="server" CausesValidation="false" Visible="false"
                        TabIndex="9" OnClientClick="return ShortCut();"><img src="../images/Admin/NewNotes.png" alt="" /></asp:LinkButton>
                    <asp:LinkButton ID="lnkMainScreen" runat="server" CausesValidation="false" OnClick="LnkMainScreenClick"><img src="../images/Admin/gtmscreen-btn.png" alt="" /></asp:LinkButton>
                    <asp:HiddenField ID="hdnNotesCnt" runat="server" />
                </div>
                <asp:HiddenField ID="hdnpkgamt" runat="server" Value="74.00" />
                <asp:HiddenField ID="hdnPlanPeriod" runat="server" Value="1" />
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
