<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="CheckStore.aspx.cs" Inherits="USPDHUB.Business.MyAccount.CheckStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/marketplace.css" rel="stylesheet" type="text/css" />
    <div class="heading">
        Market Place
    </div>
    <div id="storeswrap">
        <div id="store">
            <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/EnhanceBill.aspx")%>?Type=pJv3kdCrUzk=">
                <img src="<%=Page.ResolveClientUrl("~/images/Store/subrenl.png")%>" width="85" height="85"></a>
            <div class="storename">
                Subscription Renewal</div>
            <div class="storetext">
                For subscription renewals, you can renew any time which will extend etc...</div>
        </div>
        <div id="store">
            <a href="#">
                <img src="<%=Page.ResolveClientUrl("~/images/Store/customform.png")%>" width="85"
                    height="85"></a>
            <div class="storename">
                Custom Form</div>
            <div class="storetext">
                Request for a custom form design and development. This is one time charge. etc...</div>
        </div>
        <div id="storelast">
            <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/CheckOut.aspx")%>">
                <img src="<%=Page.ResolveClientUrl("~/images/Store/subapp.png")%>" width="85" height="85"></a>
            <div class="storename">
                Sub Apps</div>
            <div class="storetext">
                Buy more sub apps for your branded app. This will allow your affiliates or departments
                having individual app to communicate with their end users.</div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="clear10">
    </div>
    <div id="storeswrap">
        <div id="store">
            <%if (IsSubApp == false && IsBrandedApp == false)
              { %>
            <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/EnhanceBill.aspx")%>?Type=wxFg4x/gmmM=">
                <img src="<%=Page.ResolveClientUrl("~/images/Store/upgradebrand.png")%>" width="85"
                    height="85"></a>
            <%}
              else
              { %>
            <img src="<%=Page.ResolveClientUrl("~/images/Store/upgradebrand.png")%>" width="85"
                height="85">
            <%} %>
            <div class="storename">
                Upgrade to Branded App</div>
            <div class="storetext">
                <%if (IsSubApp)
                  { %>
                <b>You are a Sub App member. For Sub Apps members branded app is not available.</b>
                <%}
                  else if (IsBrandedApp)
                  { %>
                <b>You already have the branded app.</b>
                <%}
                  else
                  { %>
                Have your own branded app. You can upgrade your generic app to branded app with
                your own logo and app store link
                <%} %>
            </div>
        </div>
        <div id="store">
            <a href="checkout.html" target="_self">
                <img src="<%=Page.ResolveClientUrl("~/images/Store/customlogo.png")%>" width="85"
                    height="85"></a>
            <div class="storename">
                Logo Customization</div>
            <div class="storetext">
                Request for logo customization for your app</div>
        </div>
        <div id="storelast">
            <a href="checkout.html" target="_self">
                <img src="<%=Page.ResolveClientUrl("~/images/Store/requestcl.png")%>" width="85"
                    height="85"></a>
            <div class="storename">
                Request for Custom Module</div>
            <div class="storetext">
                Request for custom module design and development etc...</div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
