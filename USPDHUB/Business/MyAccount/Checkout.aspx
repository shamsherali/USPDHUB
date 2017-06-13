<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="Checkout.aspx.cs" Inherits="USPDHUB.Business.MyAccount.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/marketplace.css" rel="stylesheet" type="text/css" />
    <div class="clear">
    </div>
    <div class="heading">
        Market Place
    </div>
    <div id="checkoutwrap">
        <div id="checkout">
            <div id="checkoutapp">
                <img src="<%=Page.ResolveClientUrl("~/images/Store/subrenl.png")%>" width="85" height="85"></div>
            <div id="checkout-apptext">
                <div class="head">
                    Sub Apps</div>
                <br>
                Sub Apps brings you to be affiliated with your other departments, offices, user
                groups.<br />
            </div>
            <div class="clear">
            </div>
        </div>
        <!--checkout-->
    </div>
    <!--checkoutwrap-->
    <div class="clear10">
    </div>
    <div id="checkoutwrap">
        <div id="checkout">
            <div id="checkoutapp">
            </div>
            <div id="checkout-apptext">
                <div class="adminformwrap">
                    <form action="" method="get">
                    <div class="clear15">
                    </div>
                    <div class="labeldsh">
                        Each Sub account cost</div>
                    <div class="txtfildwrapdsh">
                        <strong>$500</strong></div>
                    <div class="clear10">
                    </div>
                    <div class="labeldsh">
                        How many sub apps you want to enable now?</div>
                    <div class="txtfildwrapdsh">
                        <asp:TextBox ID="txtSubAppsCount" runat="server" class="txtfilddsh-count" Text="1"
                            onkeyup="return AutoEnterSubAppsBill()"></asp:TextBox>
                        &nbsp;&nbsp;(<b>Max limit:
                            <%=hdnSubAppsCount.Value%></b>)
                    </div>
                    <div class="clear10">
                    </div>
                    <div class="labeldsh">
                        Total Billable Amount</div>
                    <div class="txtfildwrapdsh">
                        $<asp:TextBox class="txtfilddsh-billable" runat="server" ID="txtSubAppsBill" Text="500"></asp:TextBox>&nbsp;&nbsp;
                        <asp:LinkButton ID="lnkCancel" runat="server" OnClick="lnkCancel_Click">
                        <img src="<%=Page.ResolveClientUrl("~/images/Store/form-cancel.png")%>"  width="81" height="31" /></asp:LinkButton>
                        <asp:LinkButton ID="lnkPay" runat="server" OnClientClick="return CheckSubApps()" OnClick="lnkPay_Click" >
                        <img src="<%=Page.ResolveClientUrl("~/images/Store/continuetopay.png")%>"  width="136" height="31" /></asp:LinkButton>
                    </div>
                    <div class="clear10">
                    </div>
                    </form>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <!--checkout-->
    </div>
    <asp:HiddenField ID="hdnSubAppsCount" runat="server" />
    <script type="text/javascript">
        function AutoEnterSubAppsBill() {
            var subAppsCount = document.getElementById("<%=txtSubAppsCount.ClientID %>").value;
            var totalBill = document.getElementById("<%=txtSubAppsBill.ClientID %>").value;
            var SubAppsCount_WebConfig = parseInt(document.getElementById("<%=hdnSubAppsCount.ClientID %>").value);
            if (isNaN(subAppsCount)) {
                alert("Only numbers should be allowed.")
                document.getElementById("<%=txtSubAppsCount.ClientID %>").value = "";
                return false;
            }
            else if (parseInt(subAppsCount) > parseInt(SubAppsCount_WebConfig))
            {
                alert("The number of sub apps cannot exceed than " + SubAppsCount_WebConfig + ".");
                document.getElementById("<%=txtSubAppsCount.ClientID %>").value = subAppsCount.substring(0, subAppsCount.length - 1);
                return false;
            }
            else if (subAppsCount != "" && subAppsCount != null) {
                var calculateAmount = parseInt(subAppsCount) * 500;
                document.getElementById("<%=txtSubAppsBill.ClientID %>").value = calculateAmount;
                return true;
            }
            else {
                document.getElementById("<%=txtSubAppsCount.ClientID %>").value = ""
                document.getElementById("<%=txtSubAppsBill.ClientID %>").value = "";
                return true;
            }
        }
        function CheckSubApps() {
            var subAppsCount = document.getElementById("<%=txtSubAppsCount.ClientID %>").value;
            if (subAppsCount == "" || subAppsCount == null) {
                alert("The number of sub apps is mandatory.");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>
