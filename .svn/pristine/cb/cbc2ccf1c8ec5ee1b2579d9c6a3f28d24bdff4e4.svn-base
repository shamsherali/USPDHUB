<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="ReviewOrder.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ReviewOrder" %>

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
                <div id="checkoutwrapper">
                    <div id="paymentslider">
                        <img src="<%=Page.ResolveClientUrl("~/images/Store/paymentbar3.png")%>" width="563"
                            height="67"></div>
                    <br>
                    <span class="review">Review Your Order and Confirm Your Payment</span>
                    <br />
                    <br />
                    <div id="process-two">
                        <div id="infobox">
                            <div class="head">
                                Billing &amp; Payment Information</div>
                            <div class="infocontent">
                                <div id="paymentleft">
                                    <strong>Billing Information</strong><br>
                                    <asp:Label ID="lblBilling" runat="server"></asp:Label>
                                    <br />
                                    <asp:LinkButton ID="lnkEditBillInfo" runat="server" Style="text-decoration: none;"
                                        CausesValidation="false" OnClick="lnkEditBillInfo_Click">
                                    <img src="<%=Page.ResolveClientUrl("~/images/Store/edit-icon.png")%>" width="15"
                                        height="15" style="vertical-align: text-bottom;" />&nbsp;Edit Billing information</asp:LinkButton></div>
                                <div id="paymentright">
                                    <strong>Payment Information</strong><br>
                                    <asp:Label ID="lblCheck" runat="server"></asp:Label><br />
                                    Expires:
                                    <asp:Label ID="lblValid" runat="server"></asp:Label>
                                    <br />
                                    <img src="<%=Page.ResolveClientUrl("~/images/Store/edit-icon.png")%>" width="15"
                                        height="15" style="vertical-align: text-bottom;" >&nbsp;Edit Payment information</div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
            <div id="rightcolplace">
                <div id="payment-rightcol">
                    <div class="payheading">
                        Order Summary</div>
                    <br>
                    <br>
                    <br>
                    Total cost <span class="cost">$<asp:Label ID="lblPlaceTotal" runat="server" Text="0.00"></asp:Label></span><br>
                    <div class="line">
                    </div>
                    Total savings<span class="savings">$<asp:Label ID="lblPlaceDiscount" runat="server"
                        Text="0.00"></asp:Label></span>
                </div>
                <!--end of oder summary-->
                <div id="payment-rightcol" style="text-align: center;">
                    <div class="payheading">
                        <asp:LinkButton ID="lnkPlaceOrder" runat="server" OnClick="lnkPlaceOrder_Click">
                                <img src="<%=Page.ResolveClientUrl("~/images/Store/placeorder.png")%>" width="179"
                                    height="42"></asp:LinkButton></div>
                    <br>
                    By clicking Place Your Order you are agreeing to
                    <br>
                    the <strong>Terms and Conditions </strong>
                    <br>
                    of the following:<br>
                    <a href="#">
                        <br>
                        Universal Terms of Service Agreement Workspace Service Agreement</a><br>
                    <br>
                    <a href="#">
                        <img src="<%=Page.ResolveClientUrl("~/images/Store/truste.png")%>" width="77" height="27"></a><br>
                    <a href="#">
                        <img src="<%=Page.ResolveClientUrl("~/images/Store/verandsec.png")%>" width="138"
                            height="27"></a><br>
                </div>
                <div id="rightbox">
                    <asp:HiddenField ID="hdnVertical" runat="server" />
                </div>
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
</asp:Content>
