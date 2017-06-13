<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" Inherits="Business_MyAccount_ManageReports" Codebehind="ManageReports.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <div id="webmangement_wrapper">
        <div id="webmangement_leftcol">
            <div class="webmangement_leftcol_heading">
                Reports</div>
            <div class="webmangement_rightcol_rowbg">                
                <div class="webmangement_rightcol_rowbg_heading1" id="divUpdates">
                    <span><a href="javascript:void(0);" onclick="ChangeWebPage('divUpdates');">Update Campaigns</a></span></div>
                <div class="webmangement_rightcol_rowbg_heading2" id="divEvents">
                    <span><a href="javascript:void(0);" onclick="ChangeWebPage('divEvents');">Event Campaigns</a></span></div>                
                <asp:HiddenField ID="hdnPreviousDivID" runat="server" />
            </div>
        </div>
        <div id="webmangement_rightcol">                
            <div id="divUpdatesPage" style="display: none;">
                <div class="webmangement_rightcol_heading">
                    Update Campaigns</div>
                <div class="clear5">
                </div>
                <%if (Update == false)
                  { %>
                 <div class="row-wrapper">
                    <div class="leftcol">
                        Upgrade the package to use advantages of Updates.</div>
                    <div class="rightcol">
                        <a href="<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/Business/UpgradeTools.aspx?PID=<%=encProfileID %>&U=T">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" /></a>
                    </div>
                </div>
                <div style="height: 325px;">
                </div>
                <%}
                  else
                  { %>
                 <div class="row-wrapper">
                    <div class="leftcol">
                        View the results of your update campaigns.</div>
                    <div class="rightcol">
                        <a href="<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/Business/MyAccount/UpdatesReports.aspx">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" /></a>
                    </div>
                </div>
                <div style="height: 325px;">
                </div>
                <%} %>
            </div>
            <div id="divEventsPage" style="display: none;">
                <div class="webmangement_rightcol_heading">
                    Event Campaigns</div>
                <div class="clear5">
                </div>
                <%if (Event == false)
                  { %>
                  <div class="row-wrapper">
                    <div class="leftcol">
                        Upgrade the package to use advantages of Events.</div>
                    <div class="rightcol">
                        <a href="<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/Business/UpgradeTools.aspx?PID=<%=encProfileID %>&U=T">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" /></a>
                    </div>
                </div>
                <div style="height: 325px;">
                </div>
                <%}
                  else
                  { %>
                 <div class="row-wrapper">
                    <div class="leftcol">
                        View the results of your event campaigns.</div>
                    <div class="rightcol">
                        <a href="<%=System.Configuration.ConfigurationManager.AppSettings.Get("SRootPath")%>/Business/MyAccount/EventsReports.aspx">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" /></a>
                    </div>
                </div>
                <div style="height: 325px;">
                </div>
                <%} %>
            </div>
        </div>
    </div>
    <div style="background-color: #D2E5FA; border: 1px solid #D1DDEA; height:35px;">
        <div style="margin: 0px auto 0px auto; padding-top: 5px; text-align: center;">           
            <asp:Button ID="btnCancel" runat="server" Text="Dashboard" OnClick="btnCancel_Click" />  
       </div>                                         
    </div>
    <script type="text/javascript">
        function ChangeWebPage(id) {
            var previousID = "";
            if (document.getElementById('<%=hdnPreviousDivID.ClientID %>').value == "")
                previousID = 'divUpdates';
            else
                previousID = document.getElementById('<%=hdnPreviousDivID.ClientID %>').value;
            if (id != previousID) {
                $('#' + id).removeClass('webmangement_rightcol_rowbg_heading2').addClass('webmangement_rightcol_rowbg_heading1');
                $('#' + id + 'Page').css('display', 'block');
                $('#' + previousID).removeClass('webmangement_rightcol_rowbg_heading1').addClass('webmangement_rightcol_rowbg_heading2');
                $('#' + previousID + 'Page').css('display', 'none');
                document.getElementById('<%=hdnPreviousDivID.ClientID %>').value = id;
            }
        }
        window.onload = function () {
            if (document.getElementById('<%=hdnPreviousDivID.ClientID %>').value == "") {
                $('#divUpdatesPage').css('display', 'block');
            }
        }
    </script>
</asp:Content>
