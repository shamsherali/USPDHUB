<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="Thankyou.aspx.cs" Inherits="USPDHUB.Business.MyAccount.Thankyou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/marketplace.css" rel="stylesheet" type="text/css" />
    <div id="paymentwrap">
        <!--checkoutwrap starts-->
        <div id="checkoutwrapper">
            <div id="paymentslider">
                <img src="<%=Page.ResolveClientUrl("~/images/Store/thankyoubar.png")%>" width="563"
                    height="67"></div>
            <br />
            <div class="heading">
                Thank You
                <asp:Label ID="lblFirstName" runat="server" CssClass="label"></asp:Label>!<br />
                <br />
                <span>Your order has been <strong>submitted.</strong></span>
            </div>
            <div id="process-two">
                <div id="infobox">
                    <div class="infocontent">
                        <div id="paymentleft">
                            <span class="lgtxt">Order Details</span><br />
                            <br />
                            <div>
                                <div id="leftlabel">
                                    Order Number:</div>
                                <div id="rightlabel">
                                    <asp:Label ID="lblOrderNum" runat="server"></asp:Label></div>
                            </div>
                            <br>
                            <div>
                                <div id="leftlabel">
                                    Order Total:</div>
                                <div id="rightlabel">
                                    $<asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
                                </div>
                            </div>
                            <br>
                            <div>
                                <div id="leftlabel">
                                    Order Date:</div>
                                <div id="rightlabel">
                                    <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                                </div>
                            </div>
                            <br>
                            <div>
                                <div id="leftlabel">
                                    Paid With:</div>
                                <div id="rightlabel">
                                    <div id="paymentright2">
                                        <asp:Label ID="lblPaidWith" runat="server"></asp:Label>
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="paymentright">
                            <span class="lgtxt">Account Information</span><br />
                            <br />
                            <asp:Label ID="lblBilling" runat="server"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        <br />
                    </div>
                </div>
            </div>
            <!--process-two div-->
        </div>
        <!--checkoutwrap ends-->
        <div class="clear">
        </div>
    </div>
    <div id="rightcolthanks">
        <div>
            <a href="javascript:PrintReceipt()" style="text-decoration: none;">
                <img src="<%=Page.ResolveClientUrl("~/images/Store/print-receipt.png")%>" style="vertical-align: text-bottom;" />&nbsp;<b>Print
                Receipt</b></a>
        </div>
        <div class="support">
            <div id="infobox">
                <div class="head">
                    Need Help?</div>
                <div class="infocontent">
                    <img src="<%=Page.ResolveClientUrl("~/images/Store/call.png")%>" style="vertical-align: text-bottom;" />&nbsp;(480)5050-8877
                    <br />
                    <div class="support">
                        <a href="mailTo:<%=hdnSupport.Value %>" style="text-decoration: none;">
                            <img src="<%=Page.ResolveClientUrl("~/images/Store/support.png")%>" style="vertical-align: text-bottom;" />&nbsp;Support</a>
                    </div>
                </div>
            </div>
        </div>
    <!--end of oder summary-->
    <div id="payment-rightcol" style="text-align: center;">
        <div class="payheading">
            <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/Default.aspx")%>">GO TO DASHBOARD<br />
            </a>
        </div>
    </div>
    <div id="rightbox">
    </div>
    </div>
    <div class="clear">
    </div>
    <asp:HiddenField ID="hdnSupport" runat="server" />
    <script type="text/javascript">
        function PrintReceipt() {
            var divToPrint = document.getElementById("process-two");
            var popupWin = window.open('', '_blank', 'width=700,height=500');
            popupWin.document.open();
            popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="../../css/marketplace.css" /><title>Print Receipt</title></head><body onload="window.print()" style="font-family: Arial,Helvetica,sans-serif;">' + divToPrint.innerHTML + '</body></html>');
            popupWin.document.close();
        }
    </script>
</asp:Content>
