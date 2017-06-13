<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="EnhanceBill.aspx.cs" Inherits="USPDHUB.Business.MyAccount.EnhanceBill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/EditBillingInfo.ascx" TagName="EditBillInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/marketplace.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="heading">
                Market Place
            </div>
            <div align="center">
                <asp:Label ID="lblBillEditMsg" runat="server"></asp:Label>
            </div>
            <div id="paymentwrap">
                <!--checkoutwrap starts-->
                <div id="checkoutwrapper">
                    <div id="paymentslider">
                        <img src="<%=Page.ResolveClientUrl("~/images/Store/paymentbar.png")%>" width="563"
                            height="67"><br /> <asp:Label ID="lblError" style="color:Red;" runat="server"></asp:Label></div>
                    <div id="process-two">
                        <div id="infobox">
                            <div class="head">
                                Billing Information</div>
                            <div class="infocontent">
                                <asp:Label ID="lblBilling" runat="server"></asp:Label>
                                <br />
                                <asp:LinkButton ID="lnkEditBillInfo" runat="server" Style="text-decoration: none;"
                                    CausesValidation="false" OnClick="lnkEditBillInfo_Click">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Store/edit-icon.png")%>" width="15"
                                    height="15" style="vertical-align: text-bottom;" >&nbsp;Edit Billing information</asp:LinkButton>
                            </div>
                        </div>
                        <%if (RequestType == 1)
                          { %>
                        <div id="infobox">
                            <div class="head">
                                Subscription Type</div>
                        </div>
                        <%} %>
                        <div id="infobox">
                            <div class="head">
                                Payment Information</div>
                            <div class="infocontent">
                                <%if (ddlPreferred.Items.Count > 0)
                                  { %>
                                <div>
                                    <asp:RadioButton ID="rbPreferred" runat="server" GroupName="Billing" Checked="true"
                                        onclick="VisiblePreferred('1');" />
                                    Preferred Payment Method<br />
                                    <asp:DropDownList ID="ddlPreferred" runat="server" CssClass="paymentselect">
                                    </asp:DropDownList>
                                </div>
                                <div class="divider">
                                </div>
                                <%} %>
                                <div>
                                    <asp:RadioButton ID="rbCard" runat="server" GroupName="Billing" onclick="VisiblePreferred('2');" />
                                    Credit/Debit/Prepaid Card<br />
                                    <div class="clear5">
                                    </div>
                                    <asp:Panel ID="pnlCard" runat="server" Style="display: none">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Store/cards.png")%>" width="284" height="28">
                                        <br />
                                        <div class="clear5">
                                        </div>
                                        <div id="paymentformwrap">
                                            <div>
                                                <div>
                                                    Card Type:
                                                    <br />
                                                    <asp:DropDownList ID="ddlCardType" runat="server" ValidationGroup="g" CssClass="paymentselect">
                                                        <asp:ListItem Value="" Text="Select Card Type"></asp:ListItem>
                                                        <asp:ListItem Value="Visa" Text="Visa"></asp:ListItem>
                                                        <asp:ListItem Value="MasterCard" Text="MasterCard"></asp:ListItem>
                                                        <asp:ListItem Value="American Express" Text="American Express"></asp:ListItem>
                                                        <asp:ListItem Value="Discover" Text="Discover"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVddlct" runat="server" ControlToValidate="ddlCardType"
                                                        Display="Dynamic" SetFocusOnError="true" InitialValue="0" Font-Size="X-Large"
                                                        ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                </div>
                                                <div id="paymentleft">
                                                    Card Number:<br>
                                                    <asp:TextBox ID="txtCard" runat="server" CssClass="paymenttxtfld"></asp:TextBox>
                                                </div>
                                                <div id="paymentright">
                                                    Security Code (Optional)&nbsp;<img src="<%=Page.ResolveClientUrl("~/images/Store/help.png")%>"
                                                        width="18" height="18"><br />
                                                    <asp:TextBox ID="txtNumber" runat="server" CssClass="paymenttxtfld"></asp:TextBox>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div>
                                                    Name on Card:<br />
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="paymenttxtfld"></asp:TextBox>
                                                </div>
                                                <div id="paymentleft">
                                                    Expiration:<br />
                                                    <asp:DropDownList ID="ddlMonth" runat="server" class="paymentselect">
                                                        <asp:ListItem Text="01 - JAN" Value="01"></asp:ListItem>
                                                        <asp:ListItem Text="02 - FEB" Value="02"></asp:ListItem>
                                                        <asp:ListItem Text="03 - MAR" Value="03"></asp:ListItem>
                                                        <asp:ListItem Text="04 - APR" Value="04"></asp:ListItem>
                                                        <asp:ListItem Text="05 - MAY" Value="05"></asp:ListItem>
                                                        <asp:ListItem Text="06 - JUN" Value="06"></asp:ListItem>
                                                        <asp:ListItem Text="07 - JUL" Value="07"></asp:ListItem>
                                                        <asp:ListItem Text="08 - AUG" Value="08"></asp:ListItem>
                                                        <asp:ListItem Text="09 - SEP" Value="09"></asp:ListItem>
                                                        <asp:ListItem Text="10 - OCT" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="11 - NOV" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="12 - DEC" Value="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlYear" runat="server" class="paymentselect">
                                                        <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                                        <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <div id="infobox">
                            <div class="head">
                                Discount Information</div>
                            <div class="infocontent">
                                Enter if you have any Promo code or Discount code<br>
                                <asp:TextBox ID="txtPromo" runat="server" CssClass="paymenttxtfld"></asp:TextBox>&nbsp;&nbsp;<asp:Button
                                    ID="btnValidatePromo" runat="server" Text="Validate" CausesValidation="false"
                                    OnClick="btnValidatePromo_Click" />
                                <br />
                                <asp:Label ID="lblPromoError" runat="server" Style="color: Red;"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <!--process-two div-->
                </div>
                <!--checkoutwrap ends-->
                <div class="clear">
                </div>
            </div>
            <div id="rightcol" style="font-size: 13px;">
                <asp:Panel ID="pnlTwovieSucription" runat="server" Visible="false">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <colgroup>
                            <col width="38%" />
                            <col width="*" />
                        </colgroup>
                        <tr>
                            <td valign="top">
                                <strong>Subscription Type:</strong>
                                <asp:HiddenField ID="hdnPlanPeriod" runat="server" Value="1" />
                            </td>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rbMonthNonBrand" runat="server" AutoPostBack="true" GroupName="S"
                                        Checked="true" OnCheckedChanged="Subscription_CheckedChanged" />
                                    Non-Branded App Monthly - $<%=System.Configuration.ConfigurationManager.AppSettings["twoviepkg"] %></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rbAnnualNonBrand" runat="server" AutoPostBack="true" GroupName="S"
                                        OnCheckedChanged="Subscription_CheckedChanged" />
                                    Non-Branded App Annual - $<%=System.Configuration.ConfigurationManager.AppSettings["twoviepkgAnnual"] %></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rbAnnualBrand" runat="server" AutoPostBack="true" GroupName="S"
                                        OnCheckedChanged="Subscription_CheckedChanged" />
                                    Branded App Annual - $<%=System.Configuration.ConfigurationManager.AppSettings["twoviepkgBranded"] %></td>
                            </tr>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div id="payment-rightcol">
                    <div class="payheading">
                        Order Summary</div>
                    <br />
                    <br />
                    <br />
                    Total cost <span class="cost">$<asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label></span><br />
                    <div class="line">
                    </div>
                    Total savings<span class="savings">$<asp:Label ID="lblDiscount" runat="server" Text="0.00"></asp:Label></span>
                </div>
                <!--end of oder summary-->
                <div id="payment-rightcol" style="text-align: center;">
                    <div class="payheading">
                    </div>
                    <a href="#">
                        <img src="<%=Page.ResolveClientUrl("~/images/Store/truste.png")%>" width="77" height="27"></a><br>
                    <a href="#">
                        <img src="<%=Page.ResolveClientUrl("~/images/Store/verandsec.png")%>" width="138"
                            height="27"></a><br>
                    <br>
                    You will not be billed yet.<br>
                    <br>
                    <asp:LinkButton ID="lnkContinue" runat="server" OnClick="lnkContinue_Click">
                        <img src="<%=Page.ResolveClientUrl("~/images/Store/continue.png")%>" width="179"
                            height="42"></a></asp:LinkButton>
                    <br>
                </div>
                <div id="rightbox">
                </div>
                <asp:HiddenField ID="hdnVertical" runat="server" />
                <asp:HiddenField ID="hdnTotal" runat="server" />
            </div>
            <div class="clear">
            </div>
            <div>
                <asp:Label ID="lblEditBillInfo" runat="server" visiable="false"></asp:Label>
                <cc1:ModalPopupExtender ID="mpeEditBillInfo" runat="server" TargetControlID="lblEditBillInfo"
                    PopupControlID="pnlEditBillInfo" BackgroundCssClass="modal" CancelControlID="imglogin5">
                </cc1:ModalPopupExtender>
                <asp:Panel Style="display: none;" ID="pnlEditBillInfo" runat="server" Width="100%">
                    <table style="padding-left: 10px; background-color: white;" cellspacing="0" cellpadding="0"
                        width="450px" align="center" border="0">
                        <tbody>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right: 20px; padding-top: 10px" align="right">
                                    <asp:ImageButton ID="imglogin5" OnClick="ImcloseClick" runat="server" CausesValidation="false"
                                        ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <uc1:EditBillInfo ID="editBillInfo" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function VisiblePreferred(type) {
            if (type == "1")
                document.getElementById('<%=pnlCard.ClientID %>').style.display = 'none'
            else
                document.getElementById('<%=pnlCard.ClientID %>').style.display = 'block'
        }
    </script>
</asp:Content>
