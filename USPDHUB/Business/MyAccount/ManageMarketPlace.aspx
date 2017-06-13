<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="ManageMarketPlace.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageMarketPlace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <div id="webmangement_wrapper">
        <div id="divGeneralAppSettingsPage">
            <div class="clear10">
            </div>
            <%if (Convert.ToBoolean(Session["IsLiteVersion"]) == false)
              { %>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>Market Place</span><br />
                    Renew your membership, purchase additional modules and more.
                </div>
                <div class="rightcol">
                    <a href='<%=System.Configuration.ConfigurationManager.AppSettings["ShoppingCartRootPath"] %>/RedirectStore.aspx?MID=<%=MemID %>&MPID=<%=MemPID %>&CID=<%=CID %>&VC=<%=DomainNameenc %>&PackID=<%=hdnPackageID.Value %>'>
                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" />
                    </a>
                    <asp:HiddenField ID="hdnPackageID" runat="server" />
                </div>
            </div> 
            <div class="clear5">
            </div>
            <%}
              if (IsShowWidget)
              {
            %>
            <div class="row-wrapperdown">
                <div class="leftcol">
                    <span>Content Widget</span><br />
                    Customize the appearance of the widget and generate the code that allows you to embed it on your website to automatically display specific content from your mobile app.
                </div>
                <div class="rightcol">
                    <a href='<%=Page.ResolveClientUrl("~/Business/MyAccount/WebWidget.aspx")%>'>
                        <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" />
                    </a>
                </div>
            </div>
            <%} %>
            <div class="clear5">
            </div>
        </div>
    </div>
</asp:Content>
