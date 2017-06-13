<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="DownloadShortCut.aspx.cs" Inherits="USPDHUB.Business.MyAccount.DownloadShortCut" %>

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
                    <%if (IsAdmin)
                      {%>
                    <img src="../../images/dashboard/marketplace-m.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageMarketPlace.aspx")%>">
                        Market Place</a> </span>
                    <%}
                      else
                      { %>
                    <img src="../../images/dashboard//marketplace-m.png" /><span> <a href="#" onclick="ShowAssociateMSG();">
                        Market Place</a> </span>
                    <%} %>
                </div>
                <%} %>
                <div class="webmangement_rightcol_rowbg_heading14">
                    <img src="../../images/dashboard/resource.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManageContentWidget.aspx")%>">
                        Content Widget</a></span></div>
                <div class="webmangement_rightcol_rowbg_heading14">
                    <%if (IsDownloadAccess)
                      {%>
                    <img src="../../images/dashboard/tipmanage-m.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/DownloadManager.aspx")%>">
                        Notifications Manager</a></span>
                    <%}
                      else
                      { %>
                    <img src="../../images/dashboard/tipmanage-m.png" /><span> <a href="#" onclick="ShowAssociateMSG();">
                        Notifications Manager</a> </span>
                    <%} %>
                </div>
                <div class="webmangement_rightcol_rowbg_heading13">
                    <img src="../../images/dashboard/shortcut-h.png" /><span> <a href="javascript:void(0);">
                        Shortcut</a></span>
                </div>
            </div>
        </div>
        <div id="webmangement_leftcol1">
            <div id="divGeneralAppSettingsPage">
                <div class="clear10">
                </div>
                <div class="row-wrapper">
                    <div class="leftcol">
                        <span>Shortcut</span><br />
                        Install the desktop shortcut to conveniently access your account.
                    </div>
                    <div class="rightcol">
                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="btnshortcut_OnClick" ImageUrl="~/images/Dashboard/download.png" />
                    </div>
                </div>
                <div class="clear5">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
