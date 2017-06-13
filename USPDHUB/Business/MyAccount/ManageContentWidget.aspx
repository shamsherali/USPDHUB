<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="ManageContentWidget.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageContentWidget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <div id="webmangement_wrapper">
        <div id="webmangement_leftcol">
            <div class="clear10">
            </div>
            <div class="webmangement_rightcol_rowbg">
             <%if (Convert.ToBoolean(Session["IsLiteVersion"]) == false)
               { %>
                <div class="webmangement_rightcol_rowbg_heading14">
                    <img src="../../images/dashboard/marketplace-m.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageMarketPlace.aspx")%>">
                        Market Place</a> </span>
                </div>
                <%} %>
                <div class="webmangement_rightcol_rowbg_heading13">
                    <img src="../../images/dashboard/resource-W.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageContentWidget.aspx")%>">
                        Content Widget</a></span></div>
            </div>
        </div>
        <div id="webmangement_leftcol1">
            <div id="divGeneralAppSettingsPage">
                <div class="clear10">
                </div>
                <div class="row-wrapper">
                    <div class="leftcol">
                        <span>Content Widget</span><br />
                        Create a code to automatically post choosen app content to a website.
                    </div>
                    <div class="rightcol">
                        <a href='<%=Page.ResolveClientUrl("~/Business/MyAccount/WebWidget.aspx")%>'>
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" />
                        </a>
                    </div>
                </div>
                <div class="clear5">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
