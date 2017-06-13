<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="SelectItem.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SelectItem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <link href="../../css/pop-up.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <link href="../../highslide/highslide.css" rel="stylesheet" type="text/css" />
    <script src="../../highslide/highslide-with-gallery.js" type="text/javascript"></script>
    <script type="text/javascript">

        hs.graphicsDir = '../../highslide/graphics/';
        hs.align = 'center';
        hs.transitions = ['expand', 'crossfade'];
        hs.outlineType = 'rounded-white';
        hs.fadeInOut = true;
        hs.numberPosition = 'caption';
        hs.dimmingOpacity = 0.75;

        //        // Add the controlbar
        if (hs.addSlideshow) hs.addSlideshow({
            //slideshowGroup: 'group1',
            interval: 0,
            repeat: false,
            useControls: false,
            fixedControls: 'fit',
            overlayOptions: {
                opacity: .75,
                position: 'bottom center',
                hideOnMouseOut: true
            }
        });


        hs.registerOverlay({
            html: '<div class="closebutton" onclick="return hs.close(this)" title="Close"></div>',
            position: 'top right',
            fade: 2 // fading the semi-transparent overlay looks bad in IE
        });

        hs.graphicsDir = '../../highslide/graphics/';
    </script>
    <style type="text/css">
        .navy20
        {
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
        }
        .Llink
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #2C58E8 !important;
        }
        .Llink a
        {
            color: #FF860F !important;
            text-decoration: none;
            font-weight: bold;
            font-size: 12px;
        }
        .Llink a:hover
        {
            color: #FF860F !important;
            text-decoration: none;
        }
        .#active
        {
            color: #FF860F !important;
            text-decoration: none;
        }
        /* Added for Custom from Content */
        #customwrap
        {
            width: 233px;
            background: #fdf9e4;
            border: #d6c864 solid 1px;
            text-align: center;
            margin-bottom: 5px;
        }
        #customcontent
        {
            width: 200px;
            margin: auto 0px;
            font-size: 14px;
            padding: 12px;
            line-height: 22px;
        }
        .phn
        {
            color: #f15a29;
            font-weight: bold;
        }
        #ctl00_cphUser_lnkAddMore, #ctl00_cphUser_lnkRemove
        {
            background: url(../../../images/icon-add.png) no-repeat;
            background-position: 3px;
            margin-right: 5px;
            color: green;
            text-decoration: none;
            border: 1px solid #454545;
            border-radius: 5px;
            padding: 1px 5px 1px 15px;
            font-weight: 600;
            font-size: 11px;
            --float: right;
            margin-left: 20%;
        }
        #ctl00_cphUser_lnkRemove
        {
            background: url(../../../images/icon-remove.png) no-repeat;
            background-position: 3px;
            margin-right: 17px;
            color: red;
            margin-left: 0%;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 32px; font-size: 18px; color: #EC2027; margin-bottom: 5px; margin-top: 5px;
                                            font-weight: bold;" valign="top">
                                            <div style="float: left;">
                                                Create
                                                <%=hdnTabName.Value %>
                                                <a href="javascript:ModalHelpPopup('Create Content Using Templates & Forms',139,'');">
                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                            </div>
                                        </td>
                                        <td style="padding-right: 70px;">
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table cellpadding="0px" cellspacing="0" border="0" style="font-family: Arial; font-size: 10px;
                                                font-weight: normal;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblmess" runat="server" ForeColor="Green" Font-Size="Medium"></asp:Label><br />
                                                        <asp:Label ID="lblmsg" runat="server" align="center"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                                        ValidationGroup="g" HeaderText="The following error(s) occurred:" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table class="inputtable" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <colgroup>
                                    <col width="28%" />
                                    <col width="*" />
                                </colgroup>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td class="navy20" style="padding-bottom: 5px;">
                                                    Step 1: Title
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: solid 1px #4684C5;" align="center">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td style="height: 30px; background-color: #D2E5FA; padding: 5px; border-bottom: solid 1px #4684C5;">
                                                                <asp:TextBox ID="Txttemplatename" runat="server" onkeypress="return DisableSplChars(event);"
                                                                    Width="200"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reav" runat="server" ControlToValidate="Txttemplatename"
                                                                    Display="Dynamic" ErrorMessage="Campaign name is mandatory." ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px 5px 7px 10px; font-size: 14px;">
                                                                The title appears on your App.
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <%if (DomainName.ToLower().Contains("uspd") || DomainName.ToLower().Contains("localhost"))
                                              { %>
                                            <tr>
                                                <td style="padding-top: 10px;">
                                                    <%if(lnkAddMore.Visible){ %>
                                                    <span><b>Note: Use the buttons below to add/remove forms. </b></span>
                                                    <br />
                                                    <%} %> 
                                                    <asp:LinkButton ID="lnkAddMore" runat="server" Text="ADD" OnClick="lnkAddMore_Click"></asp:LinkButton>
                                                    <%if (hdnIsRemove.Value == "true")
                                                      { %>
                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="REMOVE" OnClick="lnkDeactivate_Click"></asp:LinkButton>
                                                    <%} %>
                                                </td>
                                            </tr>
                                            <%} %>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="navy20" style="padding-left: 5px;">
                                                    Step 2: Choose a Template Design
                                                    <%--<%if (DomainName.ToLower().Contains("uspd") || DomainName.ToLower().Contains("localhost"))
                                                      { %>
                                                    <span style="float: right; padding-right: 5px;">
                                                        <asp:LinkButton ID="" runat="server" Style="color: #F5A352;" OnClick="">Add More Templates</asp:LinkButton></span><%} %>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="height: 420px; overflow-y: auto; border: solid 1px #4684C5; margin: 5px;">
                                                        <asp:DataList ID="rptTest" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                            DataKeyField="ModuleID">
                                                            <ItemTemplate>
                                                                <table cellpadding="5" cellspacing="0" border="0" width="95%">
                                                                    <tr style="padding-left: 20px; padding-top: 20px; padding-bottom: 10px;">
                                                                        <td colspan="2" valign="top" style="padding: 0px 60px 0px 5px;">
                                                                            <div align="right" style="position: relative; left: 5px; top: 19px; z-index: 0;">
                                                                                <a href='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("ImagePath") %>'
                                                                                    style="width: 150px;" class="highslide" onclick="return hs.expand(this)">
                                                                                    <asp:ImageButton ID="imgpreview" runat="server" ToolTip="Zoom" ImageUrl="~/Business/MyAccount/Images/zoom.png"
                                                                                        CausesValidation="false" />
                                                                                </a>
                                                                            </div>
                                                                            <a href='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("ImagePath") %>'
                                                                                class="highslide" onclick="return hs.expand(this)">
                                                                                <input type="image" src='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("ImagePath") %>'
                                                                                    style="border-width: 0px;" />
                                                                            </a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table cellpadding="5" cellspacing="0" border="0" width="95%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblTemplatename" runat="server" Text='<%#Eval("TemplateName") %>'></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-right: 50px;">
                                                                            <asp:LinkButton ID="btnSelect" CommandArgument='<%#Eval("ModuleID") %>' runat="server"
                                                                                OnClick="btnSelect_Click" OnClientClick="return CheckForTemplateName()"><img src="<%=Page.ResolveClientUrl("~/images/Dashboard/SelectBulletin.png")%>"/></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="padding-top: 10px; padding-left: 15px; background-color: #D2E5FA; padding-bottom: 10px;">
                                    <td style="border-top: 1px solid #3E8EE1; font-size: 13px; padding-left: 12px; padding-top: 13px;"
                                        valign="top">
                                    </td>
                                    <td align="center" style="border-top: 1px solid #3E8EE1; padding-top: 10px;" valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" width="50%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                                        OnClick="btnCancel_Click" />
                                                </td>
                                                <td align="left" style="padding-left: 5px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Label ID="lblRemaining" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="ModalRemaing" runat="server" TargetControlID="lblRemaining"
                PopupControlID="pnlRemaing" BackgroundCssClass="modal">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlRemaing" runat="server" Width="50%" Style="display: none;">
                <table>
                    <tr>
                        <td>
                            <div id="popup-cont">
                                <div class="top">
                                    <a href="javascript:HideAddMoreWindow();"></a>
                                </div>
                                <div class="middle">
                                    <h1>
                                        Add More Forms</h1>
                                    <div class="scrollablebox" style="height: 100%;">
                                        <div class="auto" style="height: 100%;">
                                            <asp:DataList ID="dlRemaingForms" runat="server" RepeatDirection="Horizontal" DataKeyField="ModuleID">
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td valign="top" style="padding-right: 10px;">
                                                                <asp:CheckBox ID="chkRemaining" runat="server" />
                                                            </td>
                                                            <td style="padding-right: 25px;">
                                                                <img src='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("ImagePath") %>'
                                                                    style="border-width: 0px;" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2" style="color: Orange; font-weight: bold;">
                                                                <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("TemplateName") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                    </div>
                                    <asp:LinkButton ID="lnkAddMoreForms" runat="server" class="btn" Text="Add" OnClick="lnkAddMoreForms_Click"
                                        OnClientClick="return CheckAddMore();"></asp:LinkButton>
                                </div>
                                <div class="bottom">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Label ID="lblDeactivate" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="ModalDeactivate" runat="server" TargetControlID="lblDeactivate"
                PopupControlID="pnlDeactivate" BackgroundCssClass="modal">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlDeactivate" runat="server" Width="50%" Style="display: none;">
                <table>
                    <tr>
                        <td>
                            <div id="popup-cont">
                                <div class="top">
                                    <a href="javascript:HideDeactivateWindow();"></a>
                                </div>
                                <div class="middle">
                                    <h1>
                                        Remove Forms</h1>
                                    <div class="scrollablebox" style="height: 100%;">
                                        <div class="auto" style="height: 100%;">
                                            <asp:DataList ID="dlDeactivate" runat="server" RepeatDirection="Horizontal" DataKeyField="ID">
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td valign="top" style="padding-right: 10px;">
                                                              <asp:CheckBox ID="chkDeactivate" runat="server" onclick='<%# string.Format("javascript:return AddTemplateFavorite(this,\"{0}\")", Eval("ModuleID"))%>' />
                                                            </td>
                                                            <td style="padding-right: 25px;">
                                                                <img src='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("ImagePath") %>'
                                                                    style="border-width: 0px;" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2" style="color: Orange; font-weight: bold;">
                                                                <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("TemplateName") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                    </div>
                                    <asp:LinkButton ID="lnkDeactivateForms" runat="server" class="btn" Text="Remove"
                                        OnClick="lnkDeactivateForms_Click" OnClientClick="return CheckDeactivate();"></asp:LinkButton>
                                </div>
                                <div class="bottom">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
            <asp:HiddenField ID="hdnTabName" runat="server" />
            <asp:HiddenField ID="hdnIsRemove" runat="server" />
            <asp:HiddenField ID="hdnSelItems" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function AddTemplateFavorite(chkid, templateid) {
            var selFavorites = document.getElementById('<%= hdnSelItems.ClientID%>').value;
            if (chkid.checked)
                selFavorites = selFavorites + templateid + ", ";
            else
                selFavorites = selFavorites.replace(templateid + ", ", "");
            document.getElementById('<%= hdnSelItems.ClientID%>').value = selFavorites;
        }
        function CheckDeactivate() {
            if (document.getElementById('<%= hdnSelItems.ClientID%>').value == "") {
                alert('Please select atleast one form to remove.');
                return false;
            }
            return true;
        }
        function DisableSplChars(e) {

            var keynum;
            // For Internet Explorer    
            if (window.event) {
                keynum = e.keyCode
            }
            // For Netscape/Firefox/Opera    
            else if (e.which) {
                keynum = e.which
            }
            //keychar = String.fromCharCode(keynum)    
            //List of special characters you want to restrict    
            if (keynum == '34' || keynum == '42' || keynum == '47' || keynum == '58' || keynum == '60' || keynum == '62' || keynum == '92' || keynum == '124') {
                return false;
            }
            else {
                return true;
            }
        }

        function change(lnk, evt) {
            if (evt.type == "mouseover") {
                lnk.style.fontSize = "12px";
                lnk.style.fontWeight = "bold";
            }
            else if (evt.type == "mouseout") {
                lnk.style.fontWeight = "normal";
                lnk.style.fontSize = "12px";
            }
        }
        function CheckAddMore() {
            var selCount = 0;
            var foo = document.getElementById("<%=dlRemaingForms.ClientID %>");
            var inps = foo.getElementsByTagName("input");

            for (var i = 0; i < inps.length; i++) {

                if (inps[i].type == "checkbox" && inps[i].checked) {
                    selCount = selCount + 1;
                }
            }

            if (selCount == 0) {
                alert('Please select atleast one form to add.');
                return false;
            }
            return true;
        }
        function HideAddMoreWindow() {
            $find("<%=ModalRemaing.ClientID %>").hide();
           
        }
        function HideDeactivateWindow() {
            $find("<%=ModalDeactivate.ClientID %>").hide();
        }

        function CheckForTemplateName() {
            if (document.getElementById('<%=Txttemplatename.ClientID %>').value == '') {
                alert('Please enter a title.');
                return false;
            }
            else {
                return true;
            }
        }
        window.onload = function () {
            document.getElementById("<%= Txttemplatename.ClientID%>").focus();
        };
    </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
