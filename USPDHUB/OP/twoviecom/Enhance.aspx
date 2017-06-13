<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enhance.aspx.cs" Inherits="USPDHUB.OP.twoviecom.Enhance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .paymenttbl { background:url(/images/secure/patmentBox-Bg.gif) top left repeat-y; height:100%;font-family:Arial, Helvetica, sans-serif;}
        .paymentBoxtbl { background:url(/images/secure/payment_BoxBgImg.gif) top left repeat-y; height:100%;font-family:Arial, Helvetica, sans-serif; padding-left:10px; padding-bottom:10px;}
        .paymentpadding { padding-left:10px; padding-right:15px;}
        .paymenttbltitle{ font-size:15px; font-weight:bold; color:#1169ac; padding-top:15px;}
        .paymentoptions { font-size:12px; color:#232323; padding-left:10px; margin-top:5px; margin-bottom:5px;}
        .paymentdetails { font-size:12px; color:#232323; padding-left:15px; font-weight:bold; line-height:26px;}
        .paymentdetails td.nobold { font-weight:normal;}
        .paymentdetails td.rowclr { background-color:#A3CA6D;}
        .paymentdetails td.grey { color:#666666;}
        .paymentdetails td.smallfont { color:#999999; font-size:11px;}
        .paymentdetails span{ font-size:12px; color:#000; font-weight:bold;}
        .button_btn { font-size:12px; background-color:#1784c4; border:1px solid #0d7cbd; overflow:visible; padding:2px 10px 2px 10px; color:#FFFFFF; font-weight:bold; cursor:pointer;}
        .paymentcaption { color:#1169ac; font-size:17px; font-family:Georgia, "Times New Roman", Times, serif; padding-top:17px; padding-bottom:10px; }
        .paymentcaptiontbl { color:#1169ac; /*color:#000000*/; font-size:14px; font-family:Arial, Helvetica, sans-serif;} 
        .paymentcaptiontbl td.data{ padding-bottom:10px; color:#333333;}
        .paymentcaptiontbl td.tilte{ color:#1169ac; /*color:#000000;*/ font-size:15px; font-weight:bold; padding-bottom:10px; } 
        .bgcontent { padding:10px;  background-color:#fcf9f9; border:1px solid #efefef; }
        .payment-paddtop20 { padding-top:20px;}
        .PackageChange
        {
            text-decoration: underline; 
            font-size:12px;
            color: #F15A29;
            font-weight:normal;
        }
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Mobile App for instant two way communication for organizations and their customers</title>
    <link href="/css/schoolhub.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function openWin(url) {
            window.open(url, "composerwindow", "toolbar=no,width=600,height=655,status=no,scrollbars=no,resize=no,menubar=no");
        }
        function OpenPlansandPrice(url) {
            window.open(url, "composerwindow", "toolbar=no,width=950,height=600,status=no,scrollbars=yes,resize=no,menubar=no");
        }
    </script>
    <script language="javascript" type="text/javascript">
        history.forward();
    </script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="top" style="min-height: 525px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-width">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="main-nav">
                                            <tr>
                                                <td align="left" width="238" style="padding-top: 25px;">
                                                    <img src="<%=Page.ResolveClientUrl("~/images/TVOuterImages/logo.png")%>" alt="TwoVie"
                                                        title="inSchoolHub" width="227" height="123" border="0" />
                                                </td>
                                                <td align="center" style="padding-top: 25px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 26px;">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="maingeading" style="padding-bottom: 15px; line-height: 49px; padding-left: 15px;
                                                                background-image: url(<%=Page.ResolveClientUrl("~/images/Secure/paymentbg.gif")%>);
                                                                background-repeat: no-repeat; width: 895px; height: 49px;">
                                                                Payment Details
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <colgroup>
                                                            <col width="508px" />
                                                            <col width="10px" />
                                                            <col width="*" />
                                                        </colgroup>
                                                        <tr>
                                                            <td colspan="3" valign="top">
                                                                <asp:Panel ID="pnlFreeUpgrade" runat="server" Visible="false">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Secure/payment_TopBoxImg.gif")%>" width="900"
                                                                                    height="6" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Secure/payment_bottomBoxImg.gif")%>"
                                                                                    width="900" height="6" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div id="divpayment" runat="server">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymenttbl">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <img src="<%=Page.ResolveClientUrl("~/images/Secure/patmentBox-Top.gif")%>" width="508"
                                                                                                height="7" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentpadding">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                                                            <colgroup>
                                                                                                                <col width="38%" />
                                                                                                                <col width="*" />
                                                                                                            </colgroup>
                                                                                                            <tr>
                                                                                                                <td valign="top">
                                                                                                                    <strong>Subscription Type:</strong>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                                                                        <%if (hdnIsSubAccount.Value == "")
                                                                                                                          { %>
                                                                                                                        <tr>
                                                                                                                            <td>
                                                                                                                                <asp:RadioButton ID="rbMonthNonBrand" runat="server" AutoPostBack="true" GroupName="S"
                                                                                                                                    Checked="true" OnCheckedChanged="Subscription_CheckedChanged" />
                                                                                                                                Non-Branded App Monthly - $162
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td>
                                                                                                                                <asp:RadioButton ID="rbAnnualNonBrand" runat="server" AutoPostBack="true" GroupName="S"
                                                                                                                                    OnCheckedChanged="Subscription_CheckedChanged" />
                                                                                                                                Non-Branded App Annual - $1699
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td>
                                                                                                                                <asp:RadioButton ID="rbAnnualBrand" runat="server" AutoPostBack="true" GroupName="S"
                                                                                                                                    OnCheckedChanged="Subscription_CheckedChanged" />
                                                                                                                                Branded App Annual - $1699
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <%}
                                                                                                                          else
                                                                                                                          { %>
                                                                                                                        <tr>
                                                                                                                            <td valign="top" style="font-weight: bold; font-size: 16px; color: Green;">
                                                                                                                                Sub App - $<%=System.Configuration.ConfigurationManager.AppSettings["twoviepkgSub"] %>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <%} %>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <%--<tr>
                                                                                                                <td>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                                <td style="padding-top: 10px;">
                                                                                                                    <%if (!ddlSubscriptions.SelectedItem.Text.Contains("Branded App") && hdnIsSubAccount.Value=="")
                                                                                                                      { %>
                                                                                                                    <asp:RadioButton ID="rbMonth" runat="server" GroupName="M" AutoPostBack="true" Checked="true"
                                                                                                                        OnCheckedChanged="RbMonthCheckedChanged" />
                                                                                                                    Monthly
                                                                                                                    <%} %>
                                                                                                                    <asp:RadioButton ID="rbYear" runat="server" GroupName="M" AutoPostBack="true" OnCheckedChanged="RbMonthCheckedChanged" />
                                                                                                                    Annually
                                                                                                                </td>
                                                                                                            </tr>--%>
                                                                                                        </table>
                                                                                                        <%if (rbAnnualBrand.Checked)
                                                                                                          {%>
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-top: 20px;">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <b>Note:</b> We will contact you shortly to collect information needed to create
                                                                                                                    your branded app.
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                        <%} %>
                                                                                                        <asp:Panel ID="pnlPricePlan" runat="server">
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymenttbltitle">
                                                                                                                <colgroup>
                                                                                                                    <col width="17px" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <img src="<%=Page.ResolveClientUrl("~/images/secure/payment_arrow.gif")%>" width="14"
                                                                                                                            height="14" />
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        Membership Details for
                                                                                                                        <%if (rbMonthNonBrand.Checked && hdnIsSubAccount.Value == "")
                                                                                                                          { %>
                                                                                                                        Monthly
                                                                                                                        <%}
                                                                                                                          else
                                                                                                                          {%>
                                                                                                                        Annual
                                                                                                                        <%} %>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                                                                                                                <colgroup>
                                                                                                                    <col width="25%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <asp:Label ID="lblPromoerror" runat="server" Style="color: Red;"></asp:Label>
                                                                                                                        <asp:Label ID="lblErroMessage" runat="server" Style="color: Red;"></asp:Label>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </asp:Panel>
                                                                                                        <asp:Panel ID="pnlregpay" runat="server">
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                                                                                                                <colgroup>
                                                                                                                    <col width="38%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Membership Fee:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <span style="font-size: 14px;">$<asp:Label ID="lblsubscr1" runat="server"></asp:Label></span>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Discount:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <span style="color: Red;">($<asp:Label ID="lblDiscount" runat="server" Style="color: Red;"></asp:Label>)</span>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        Subtotal:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <span style="font-size: 14px;">$<asp:Label ID="lblSubTotal" runat="server"></asp:Label></span>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <asp:Panel ID="pnlOneTimeSetup" runat="server">
                                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                <colgroup>
                                                                                                                                    <col width="38%" />
                                                                                                                                    <col width="*" />
                                                                                                                                </colgroup>
                                                                                                                                <tr>
                                                                                                                                    <td>
                                                                                                                                        One Time Setup Fee:
                                                                                                                                    </td>
                                                                                                                                    <td>
                                                                                                                                        <span style="font-size: 14px;">$<asp:Label ID="lblOneTimeFee" runat="server" Text="750.00"></asp:Label></span>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </asp:Panel>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td class="rowclr">
                                                                                                                        Total Invoice Amount:
                                                                                                                    </td>
                                                                                                                    <td class="rowclr">
                                                                                                                        <span style="font-size: 14px;">$<asp:Label ID="lblsubscAmount" runat="server" Style="font-size: 14px;"></asp:Label></span>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td class="rowclr" style="font-size: 11px; line-height: 16px; padding-bottom: 3px;">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td class="rowclr" style="font-size: 11px; line-height: 16px; padding-bottom: 3px;">
                                                                                                                        <span style="font-size: 11px;">&nbsp;&nbsp;(Credit card payment supports U.S. currency
                                                                                                                            only.)</span>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="padding-top: 5px;">
                                                                                                                        We Accept:
                                                                                                                    </td>
                                                                                                                    <td style="padding-top: 5px;">
                                                                                                                        <img src="<%=Page.ResolveClientUrl("~/images/Secure/footer-icon1.gif")%>" width="43"
                                                                                                                            height="29" />
                                                                                                                        <img src="<%=Page.ResolveClientUrl("~/images/Secure/footer-icon2.gif")%>" width="43"
                                                                                                                            height="29" />
                                                                                                                        <img src="<%=Page.ResolveClientUrl("~/images/Secure/footer-icon3.gif")%>" width="43"
                                                                                                                            height="29" />
                                                                                                                        <img src="<%=Page.ResolveClientUrl("~/images/Secure/discover.gif")%>" width="43"
                                                                                                                            height="29" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </asp:Panel>
                                                                                                        <asp:Panel ID="pnlcarddetails" runat="server" Width="100%">
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                                                                                                                <colgroup>
                                                                                                                    <col width="38%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <font color="#FF0000">* Marked fields are mandatory.</font>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="2" class="grey">
                                                                                                                        Enter your credit card details to finish payment process.
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>Card Type:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:DropDownList ID="ddlCardType" runat="server" ValidationGroup="g">
                                                                                                                            <asp:ListItem Value="0" Text="Select Card Type"></asp:ListItem>
                                                                                                                            <asp:ListItem Value="Visa" Text="Visa"></asp:ListItem>
                                                                                                                            <asp:ListItem Value="MasterCard" Text="MasterCard"></asp:ListItem>
                                                                                                                            <asp:ListItem Value="American Express" Text="American Express"></asp:ListItem>
                                                                                                                            <asp:ListItem Value="Discover" Text="Discover"></asp:ListItem>
                                                                                                                        </asp:DropDownList>
                                                                                                                        <asp:RequiredFieldValidator ID="RFVddlct" runat="server" ControlToValidate="ddlCardType"
                                                                                                                            Display="Dynamic" SetFocusOnError="true" InitialValue="0" Font-Size="X-Large"
                                                                                                                            ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>First Name:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtfirstName" runat="server" MaxLength="32" ValidationGroup="g"
                                                                                                                            class="textfield"></asp:TextBox>
                                                                                                                        <asp:RequiredFieldValidator ID="reqfirstname" runat="server" ControlToValidate="txtfirstName"
                                                                                                                            Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>Last Name:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtlastname" runat="server" MaxLength="32" ValidationGroup="g" class="textfield"></asp:TextBox>
                                                                                                                        <asp:RequiredFieldValidator ID="reqlastname" runat="server" ControlToValidate="txtlastname"
                                                                                                                            Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>Card Number:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtcreditCardNumber" runat="server" MaxLength="19" ValidationGroup="g"
                                                                                                                            class="textfield"></asp:TextBox>
                                                                                                                        <asp:RequiredFieldValidator ID="reqcardnumber" Font-Size="X-Large" runat="server"
                                                                                                                            ControlToValidate="txtcreditCardNumber" Display="Dynamic" SetFocusOnError="true"
                                                                                                                            ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                                                                                                                <colgroup>
                                                                                                                    <col width="38.3%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>Expiration Date(mm/yy):
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtexpmonth" runat="server" Width="30px"></asp:TextBox>
                                                                                                                        <asp:RequiredFieldValidator ID="reqmonth" runat="server" ControlToValidate="txtexpmonth"
                                                                                                                            Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                                                        <asp:RegularExpressionValidator ID="regMonthValidate" SetFocusOnError="true" ControlToValidate="txtexpmonth"
                                                                                                                            runat="server" Display="Dynamic" ValidationExpression="^((0[1-9])|(1[0-2]))$"
                                                                                                                            Font-Size="X-Large" ValidationGroup="g">*</asp:RegularExpressionValidator>&nbsp;&nbsp;
                                                                                                                        / &nbsp;&nbsp;
                                                                                                                        <asp:TextBox ID="txtexpyear" runat="server" Width="30px"></asp:TextBox>
                                                                                                                        <asp:RequiredFieldValidator ID="reqyear" runat="server" ControlToValidate="txtexpyear"
                                                                                                                            Display="Dynamic" SetFocusOnError="true" Font-Size="X-Large" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td class="smallfont">
                                                                                                                        Ex: 01 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ex:
                                                                                                                        17
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>Card Verification Number:
                                                                                                                    </td>
                                                                                                                    <td class="smallfont">
                                                                                                                        <asp:TextBox ID="txtcvv2Number" runat="server" Width="30px" MaxLength="4" ValidationGroup="g"
                                                                                                                            class="textfield"></asp:TextBox>
                                                                                                                        <asp:RequiredFieldValidator SetFocusOnError="true" ID="reqcvv" Font-Size="X-Large"
                                                                                                                            runat="server" ControlToValidate="txtcvv2Number" Display="Dynamic" ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                                                                                        <a href="javascript:openWin('<%=RootPath%>/CardVerification.htm')">
                                                                                                                            <img src="<%=Page.ResolveClientUrl("~/Images/help.gif")%>" border="0" style="vertical-align: middle;" /></a>
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
                                                                                                                    <td>
                                                                                                                        <asp:Label ID="lblRecurring" runat="server" Text=" Recurring Membership:"></asp:Label>
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:CheckBox ID="chkRcurring" runat="server" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymenttbltitle">
                                                                                                                <colgroup>
                                                                                                                    <col width="17px" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <img src="<%=Page.ResolveClientUrl("~/images/Secure/payment_arrow.gif")%>" width="14"
                                                                                                                            height="14" />
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        Billing Address
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                                                                                                                <colgroup>
                                                                                                                    <col width="38.3%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>Address 1:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtaddress1" runat="server" Width="200px" MaxLength="100" ValidationGroup="g"
                                                                                                                            class="textfield"></asp:TextBox>
                                                                                                                        <asp:RequiredFieldValidator ID="reqaddress1" SetFocusOnError="true" runat="server"
                                                                                                                            ControlToValidate="txtaddress1" Display="Dynamic" ValidationGroup="g" Font-Size="X-Large">*</asp:RequiredFieldValidator>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                                                                                                                <colgroup>
                                                                                                                    <col width="38%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">&nbsp;</font>Address 2:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtaddress2" runat="server" MaxLength="100" class="textfield"></asp:TextBox>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>City:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtcity" runat="server" MaxLength="40" ValidationGroup="g" class="textfield"></asp:TextBox>
                                                                                                                        <asp:RequiredFieldValidator ID="reqcity" SetFocusOnError="true" runat="server" ControlToValidate="txtcity"
                                                                                                                            Display="Dynamic" ValidationGroup="g" Font-Size="X-Large">*</asp:RequiredFieldValidator>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>State:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:DropDownList ID="DrpState" runat="server" ValidationGroup="g">
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
                                                                                                                            Display="Dynamic" InitialValue="0" SetFocusOnError="true" ValidationGroup="g"
                                                                                                                            Font-Size="X-Large">*</asp:RequiredFieldValidator>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentdetails">
                                                                                                                <colgroup>
                                                                                                                    <col width="38.3%" />
                                                                                                                    <col width="*" />
                                                                                                                </colgroup>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <font color="#FF0000">*</font>Zip Code:
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:TextBox ID="txtzip" runat="server" Width="50px" MaxLength="10" ValidationGroup="g"
                                                                                                                            class="textfield80"></asp:TextBox>
                                                                                                                        <asp:RequiredFieldValidator ID="reqzipcode" runat="server" ControlToValidate="txtzip"
                                                                                                                            Display="Dynamic" ValidationGroup="g" SetFocusOnError="true" Font-Size="X-Large">*</asp:RequiredFieldValidator>
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
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <asp:Button runat="server" ID="PayButton" Text="Submit" OnClick="PayButton_Click"
                                                                                                                            ValidationGroup="g" class="button_btn"></asp:Button>
                                                                                                                        <asp:Button ID="btncancelcreditcard" runat="server" OnClientClick="return confirm('Are you sure you want to cancel?')"
                                                                                                                            Text="Cancel" OnClick="btncancelcreditcard_Click" class="button_btn" />
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
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <img src="<%=Page.ResolveClientUrl("~/images/Secure/patmentBox-bottom.gif")%>" width="508"
                                                                                height="7" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="bgcontent">
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="paymentcaptiontbl">
                                                                                <tr>
                                                                                    <td class="tilte">
                                                                                        <img src="<%=Page.ResolveClientUrl("~/images/Secure/icon_arw.gif")%>" />
                                                                                        Your information is secure.
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="data">
                                                                                        We use maximum encryption so that your credit card and personal information are
                                                                                        safe and secure. Payments will appear on your credit card statement as Logictree
                                                                                        IT Solutions, Inc.<%if (hdnProfileExpires.Value != "No")
                                                                                                            { %><br />
                                                                                        <br />
                                                                                        <span style="font-size: 14px;">To make changes, contact us at <span style="color: Red;
                                                                                            font-weight: bold">1-800-281-0263</span> Monday - Friday 8 a.m. - 5 p.m. PST. The
                                                                                            card information you provided will be used for all future billings on your account.</span>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <span style="font-weight: bold"><i>
                                            <br />
                                            NOTE: For security purposes, once your payment has been processed a receipt will
                                            be sent to your registered email address. </i></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="bottom" style="vertical-align: baseline;">
                <!--Footer-->
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="background: none repeat scroll 0 0 #E5E5E5; color: #666666; font-size: 13px;"
                            width="100%">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-width">
                                <tr>
                                    <td align="center">
                                        <a target="_blank" href="http://www.logictreeit.com" style="text-decoration: none;">
                                            A Product of LogicTree IT</a> &nbsp;&nbsp;&nbsp;<a href="terms.html" target="_blank">Terms
                                                of Services</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <!--Footer-->
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnPromocode" runat="server" />
    <asp:HiddenField ID="hdnPlan" runat="server" />
    <asp:HiddenField ID="hdnProfileExpires" runat="server" />
    <asp:HiddenField ID="hdnStartDate" runat="server" />
    <asp:HiddenField ID="hdnEndDate" runat="server" />
    <asp:HiddenField ID="hdnsubperiod" runat="server" />
    <asp:HiddenField ID="hdnpkgamt" runat="server" Value="74.00" />
    <asp:HiddenField ID="hdnPlanPeriod" runat="server" Value="1" />
    <asp:HiddenField ID="hdnInquiryID" runat="server" />
    <asp:HiddenField ID="hdnIsSubAccount" runat="server" />
    </form>
</body>
</html>
