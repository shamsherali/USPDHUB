<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true"
    Inherits="Business_MyAccount_ManageMedia" CodeBehind="ManageMedia.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <div id="webmangement_wrapper">
        <div id="webmangement_rightcol">
            <div id="divwebmangementMediaPage">
                <div class="webmangement_rightcol_heading">
                    Edit Gallery</div>
                <div class="clear5">
                </div>
                <div class="row-wrapper" style="width:96%;">
                    <div class="leftcol">
                        <span>Images</span><br />
                        <!-- *** Fix for IRH-36 25-01-2013 *** -->
                        Upload and control images displayed on your App.</div>
                    <div class="rightcol">
                        <a href="<%=Page.ResolveClientUrl("~/Business/MyAccount/ManagePhotosAlbum.aspx?App=1")%>">
                            <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/continuew.png")%>" /></a>
                    </div>
                </div>
                <div class="clear5">
                </div>
                <div style="height: 5px;">
                </div>
            </div>
        </div>
    </div>
    <div style="background-color: #D2E5FA; border: 1px solid #D1DDEA; height: 35px;">
        <div style="margin: 0px auto 0px auto; padding-top: 5px; text-align: center;">
            <asp:Button ID="btnCancel" runat="server" Text="Dashboard" OnClick="btnCancel_Click" />
        </div>
    </div>
    <script type="text/javascript">
        window.onload = function () {
            
        }
    </script>
</asp:Content>
