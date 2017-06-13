<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCCDetails.ascx.cs"
Inherits="USPDHUB.Controls.EditCCDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style>
    .paymenttbl { background: url(images/patmentBox-Bg.gif) top left repeat-y; height: 100%; font-family: Arial, Helvetica, sans-serif; }
    .paymentBoxtbl { background: url(images/payment_BoxBgImg.gif) top left repeat-y; height: 100%; font-family: Arial, Helvetica, sans-serif; padding-left: 10px; padding-bottom: 10px; }
    .paymentpadding { padding-left: 10px; padding-right: 15px; }
    .paymenttbltitle { font-size: 15px; font-weight: bold; color: #1169ac; padding-top: 15px; }
    .paymentoptions { font-size: 12px; color: #232323; padding-left: 10px; margin-top: 5px; margin-bottom: 5px; }
    .paymentdetails { font-size: 12px; color: #232323; padding-left: 15px; font-weight: bold; line-height: 26px; }
    .paymentdetails td.nobold { font-weight: normal; }
    .paymentdetails td.rowclr { background-color: #A3CA6D; }
    .paymentdetails td.grey { color: #666666; }
    .paymentdetails td.smallfont { color: #999999; font-size: 11px; }
    .paymentdetails span { font-size: 12px; color: #000; font-weight: bold; }
    .button_btn { font-size: 12px; background-color: #1784c4; border: 1px solid #0d7cbd; overflow: visible; padding: 2px 10px 2px 10px; color: #FFFFFF; font-weight: bold; cursor: pointer; }
    .paymentcaption { color: #1169ac; font-size: 17px; font-family: Georgia, "Times New Roman", Times, serif; padding-top: 17px; padding-bottom: 10px; }
    .paymentcaptiontbl { color: #1169ac; /*color:#000000*/; font-size: 14px; font-family: Arial, Helvetica, sans-serif; } 
    .paymentcaptiontbl td.data { padding-bottom: 10px; color: #333333; }
    .paymentcaptiontbl td.tilte { color: #1169ac; /*color:#000000;*/ font-size: 15px; font-weight: bold; padding-bottom: 10px; } 
    .bgcontent { padding: 10px; background-color: #fcf9f9; border: 1px solid #efefef; }
    .payment-paddtop20 { padding-top: 20px; }
        
    .textwatermark
    {
        background-repeat: no-repeat;
        background-color: #FFF;
        font-family: Tahoma, Geneva, sans-serif;
    
        color: #818181;
        border: solid 1px #00979c;
        text-decoration: none;
        font-weight: normal; 
        background-position: left center;
    }
</style>
<asp:Panel ID="pnlcarddetails" runat="server" Width="100%">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
        <colgroup>
            <col width="38%" />
            <col width="*" />
        </colgroup>
        <tr>
            <td>
                <font color="#FF0000">* Marked fields are mandatory.</font>
            </td>
        </tr>
        <tr>
            <td class="grey">
                Enter your credit card details to finish payment process.
            </td>
        </tr>
        <tr>
            <td align='center'>
                <asp:Label runat="server" ID='lblmsg' ForeColor="Red" Font-Size="14px"></asp:Label>
                <asp:Label runat="server" ID='lblerror' ForeColor="Red" Font-Size="14px"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
        <colgroup>
            <col width="60%" />
            <col width="*" />
        </colgroup>
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>Card Type:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCardType" runat="server" ValidationGroup="CC" Width="150px">
                                <asp:ListItem Value="0" Text="Select Card Type"></asp:ListItem>
                                <asp:ListItem Value="Visa" Text="Visa"></asp:ListItem>
                                <asp:ListItem Value="MasterCard" Text="MasterCard"></asp:ListItem>
                                <asp:ListItem Value="American Express" Text="American Express"></asp:ListItem>
                                <asp:ListItem Value="Discover" Text="Discover"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVddlct" runat="server" ControlToValidate="ddlCardType"
                                                        Display="Dynamic" SetFocusOnError="true" InitialValue="0" Font-Size="X-Large"
                                                        ValidationGroup="CC">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>First Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtfirstName" runat="server" MaxLength="32" ValidationGroup="CC"
                                         class="textfield" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqfirstname" runat="server" ControlToValidate="txtfirstName"
                                                        Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="CC">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>Last Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtlastname" runat="server" MaxLength="32" ValidationGroup="CC"
                                         class="textfield" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqlastname" runat="server" ControlToValidate="txtlastname"
                                                        Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="CC">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>Card Number:
                        </td>
                        <td>
                            <cc1:TextBoxWatermarkExtender ID="waterCCNumber" runat="server" TargetControlID="txtcreditCardNumber"
                                                          WatermarkCssClass="textwatermark" WatermarkText='xxxx'>
                            </cc1:TextBoxWatermarkExtender>
                            <asp:TextBox ID="txtcreditCardNumber" runat="server" MaxLength="19" ValidationGroup="CC"
                                         class="textfield" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqcardnumber" Font-Size="X-Large" runat="server"
                                                        ControlToValidate="txtcreditCardNumber" Display="Dynamic" SetFocusOnError="true"
                                                        ValidationGroup="CC">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                    <colgroup>
                        <col width="54%" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>Expiration Date(mm/yy):
                        </td>
                        <td>
                            <asp:TextBox ID="txtexpmonth" runat="server" Width="30px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqmonth" runat="server" ControlToValidate="txtexpmonth"
                                                        Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="CC">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regMonthValidate" SetFocusOnError="true" ControlToValidate="txtexpmonth"
                                                            runat="server" Display="Dynamic" ValidationExpression="^((0[1-9])|(1[0-2]))$"
                                                            Font-Size="X-Large" ValidationGroup="CC">*</asp:RegularExpressionValidator>&nbsp;&nbsp;
                            / &nbsp;&nbsp;
                            <asp:TextBox ID="txtexpyear" runat="server" Width="30px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqyear" runat="server" ControlToValidate="txtexpyear"
                                                        Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="CC">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td class="smallfont">
                            Ex: 01 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ex:
                            11
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>Card Verification Number:
                        </td>
                        <td class="smallfont">
                            <asp:TextBox ID="txtcvv2Number" runat="server" Width="30px" MaxLength="4" ValidationGroup="CC"
                                         class="textfield"></asp:TextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="reqcvv" Font-Size="X-Large"
                                                        runat="server" ControlToValidate="txtcvv2Number" Display="Dynamic" ValidationGroup="CC">*</asp:RequiredFieldValidator>
                            <a href="javascript:openWin('<%=Page.ResolveClientUrl("~/secure/CardVerification.htm")%>')">
                                <img src="<%=Page.ResolveClientUrl("~/Images/help.gif")%>"
                                     border="0" style="vertical-align: middle;" />
                            </a>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table width="270px" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                    <colgroup>
                        <col width="45%" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>Address 1:
                        </td>
                        <td>
                            <asp:TextBox ID="txtaddress1" runat="server" Width="150px" MaxLength="100" ValidationGroup="CC"
                                         class="textfield"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqaddress1" SetFocusOnError="true" runat="server"
                                                        ControlToValidate="txtaddress1" Display="Dynamic" ValidationGroup="CC" Font-Size="X-Large">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table width="270px" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                    <colgroup>
                        <col width="45%" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>
                            <font color="#FF0000">&nbsp;</font>Address 2:
                        </td>
                        <td>
                            <asp:TextBox ID="txtaddress2" runat="server" MaxLength="100" class="textfield" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>City:
                        </td>
                        <td>
                            <asp:TextBox ID="txtcity" runat="server" MaxLength="40" ValidationGroup="CC" class="textfield"
                                         Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqcity" SetFocusOnError="true" runat="server" ControlToValidate="txtcity"
                                                        Display="Dynamic" ValidationGroup="CC" Font-Size="X-Large">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>State:
                        </td>
                        <td>
                            <asp:DropDownList ID="DrpState" runat="server" ValidationGroup="CC" Width="150px">
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
                            <asp:RequiredFieldValidator ID="reqstate" runat="server" ControlToValidate="DrpState"
                                                        Display="Dynamic" InitialValue="0" SetFocusOnError="true" ValidationGroup="CC"
                                                        Font-Size="X-Large">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table width="270px" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                    <colgroup>
                        <col width="35%" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>Zip Code:
                        </td>
                        <td>
                            <asp:TextBox ID="txtzip" runat="server" Width="50px" MaxLength="10" ValidationGroup="CC"
                                         class="textfield80"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqzipcode" runat="server" ControlToValidate="txtzip"
                                                        Display="Dynamic" ValidationGroup="CC" SetFocusOnError="true" Font-Size="X-Large">*</asp:RequiredFieldValidator>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font color="#FF0000">*</font>Country:
                        </td>
                        <td>
                            <span>United States</span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="grey" style="line-height: 16px;">
                <font color="#FF0000">Note: </font>Card verification number will be the last 3 digits
                on the back of your card. For American Express cards it will be a 4 digit number
                on the face of your card.
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button runat="server" ID="PayButton" Text="Submit" OnClick="PayButton_Click"
                            ValidationGroup="CC" class="button_btn"></asp:Button>&nbsp;
                <asp:Button ID="btncancelcreditcard" runat="server" Text="Cancel" OnClick="btncancelcreditcard_Click"
                            class="button_btn" />
            </td>
        </tr>
    </table>
</asp:Panel>
<script type="text/javascript">
    function checkDate() {
        var txtYear = document.getElementById('<%=txtexpyear.ClientID %>');
        var today = new Date()
        var year = today.getYear()
        if (txtYear.value.length == 4) {
            if (txtYear.value < year) {
                alert("Please enter valid year.");
                document.getElementById('<%=txtexpyear.ClientID %>').focus();
                return false;
            }
        }
    }
    
    function ValidateCCDetails() {
        alert('You have entered incorrect details. Please check the details once.');
        return false;
    }
</script>
