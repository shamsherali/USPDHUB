<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    CodeBehind="DownloadManager.aspx.cs" Inherits="USPDHUB.Business.MyAccount.DownloadManager" %>

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
            <div class="webmangement_rightcol_rowbg_heading13">
                <img src="../../images/dashboard/tipmanage-h.png" /><span> <a href="javascript:void(0);">
                    Notifications Manager</a></span>
            </div>
            <div class="webmangement_rightcol_rowbg_heading14">
                <%if (IsDownloadAccess)
                  {%>
                <img src="../../images/dashboard/shortcut-m.png" /><span> <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/DownloadShortCut.aspx")%>">
                    Shortcut</a></span>
                <%}
                  else
                  { %>
                <img src="../../images/dashboard/shortcut-m.png" /><span> <a href="#" onclick="ShowAssociateMSG();">
                    Shortcut</a> </span>
                <%} %></div>
            </div>
        </div>
        <div id="webmangement_leftcol1">
            <div id="divGeneralAppSettingsPage">
                <div class="clear10">
                </div>
                <div class="row-wrapper">
                    <div class="leftcol">
                        <span>Notifications Manager</span><br />
                        Install the Notifications Manager to receive desktop alerts of incoming messages.
                    </div>
                    <div class="rightcol">
                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="btnTipsmanager_OnClick"
                            ImageUrl="~/images/Dashboard/download.png" />
                    </div>
                </div>
                <div class="clear5">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
