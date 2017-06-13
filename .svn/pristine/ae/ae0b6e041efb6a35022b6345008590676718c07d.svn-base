<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="ManageAppButtons.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageAppButtons" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <link href="../../css/jquery.jscrollpane.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../css/pop-up.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <link href="../../css/Jquery-order-ui.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        var yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(EndRequestHandler);
        $(window).scroll(function () { yPos = $(window).scrollTop(); });
        function EndRequestHandler(sender, args) {
            yPos = 0;
            $(window).scrollTop(yPos);
        }
    </script>
    <script type="text/javascript">
        function BindLoadEvents() {
            $('#sortable').sortable({
                placeholder: 'ui-state-highlight',
                update: OnSortableUpdate
            });
            $('#sortable').disableSelection();
        }
    </script>
    <style type="text/css">
        #tbltt IMG
        {
            vertical-align: bottom;
        }
        
        #sortable
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: auto;
        }
        #sortable li
        {
            margin: 0 5px 5px 5px;
            padding: 5px;
            font-size: 1.2em;
            cursor: move;
        }
        html > body #sortable li
        {
            /*height: 1.5em;*/
            line-height: 1.2em;
        }
        
        
        #sortable1
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            width: auto;
        }
        #sortable1 li
        {
            margin: 0 5px 5px 5px;
            padding: 5px;
            font-size: 1.2em;
        }
        html > body #sortable1 li
        {
            /*height: 1.5em;*/
            line-height: 1.2em;
        }
        
        .ui-state-highlight
        {
            height: 35px;
        }
        .couponcode
        {
            width: 100px;
        }
        .couponcode:hover .coupontooltip
        {
            display: inline-block;
        }
        .coupontooltip
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            margin-left: 10px;
            margin-bottom: 100px;
            border: 1px dashed #297CCF;
            padding: 10px;
            position: absolute;
            z-index: 1000;
            width: 320px;
            height: 100px;
            color: Black;
        }
        .couponcode:hover .questiontooltip
        {
            display: inline-block;
        }
        .questiontooltip
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            margin-left: 10px;
            margin-bottom: 100px;
            border: 1px dashed #297CCF;
            padding: 10px;
            position: absolute;
            z-index: 1000;
            width: 320px;
            height: 30px;
            color: Black;
        }
        .couponcode1
        {
            position: relative;
            display: inline-block;
            width: 25px;
            float: right;
        }
        .couponcode1:hover .questiontooltip1
        {
            visibility: visible;
        }
        .couponcode1 .questiontooltip1
        {
            visibility: hidden;
            width: 320px;
            background-color: #D9E8FF;
            color: Black;
            padding: 10px;
            min-height: 30px;
            border: 1px dashed #297CCF;
            font-weight: normal;
            font-size: 14px;
            margin-left: 10px;
            margin-bottom: 100px; /* Position the tooltip */
            position: absolute;
            z-index: 1000;
            top: -5px;
            right: 105%;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(BindLoadEvents);
            </script>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                                        Style="border: 0; border-color: White!important;"></asp:TextBox>
                                    App Buttons &nbsp;&nbsp; <span class="couponcode">
                                        <img border="0" src="../../images/Dashboard/new.png" />
                                        <span class="coupontooltip">You may choose which buttons will display on your
                                            <br />
                                            App by checking the boxes here, change the order<br />
                                            buttons are displayed by dragging and dropping<br />
                                            them to your preferred position and change their<br />
                                            names and icons by clicking 'Modify'. </span></span>
                                    <asp:HiddenField runat="server" ID="hdnPermissionType" />
                                    <asp:HiddenField runat="server" ID="hdnUserModuleID" />
                                    <asp:HiddenField runat="server" ID="hdnTabName" />
                                    <asp:HiddenField runat="server" ID="hdnModuleTemplateID" />
                                    <asp:HiddenField runat="server" ID="hdnModuleAppButton" />
                                    <asp:HiddenField runat="server" ID="hdnCall" />
                                </td>
                                <td align="left">
                                    <table width="200px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="align-right" valign="top">
                                                <asp:Button ID="btncancelTop" CssClass="button" runat="server" Text="Back" OnClick="btncancelupdate_Click" />&nbsp;&nbsp;
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Button ID="btnUpdateTop" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click"
                                                    OnClientClick="return UpdateOder();" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" class="inputgrid">
                                    <asp:Label ID="lblstatusmessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="pnlAppButtons" runat="server">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="margin-top">
                                <tr>
                                    <td class="valign-top">
                                        <table id="tbltt" width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="border-bottom: 1px solid #ECECEC;">
                                                    <%-- <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>" width="9"
                                                        height="28">--%>
                                                    <asp:LinkButton ID="lnkDefault" runat="server" CausesValidation="false" Text="<img  src='../../Images/Dashboard/Default_h.png'   border='0'   />"
                                                        OnClick="lnkDefault_OnClick"></asp:LinkButton>
                                                    <%-- <td class="new-header">
                                                </td>--%>
                                                    <% if (Convert.ToBoolean(Session["IsLiteVersion"]) == false || DomainName.ToLower().Contains("inschoolhub"))
                                                       { %>
                                                    <asp:LinkButton ID="lnkPirvateCall" runat="server" CausesValidation="false" Text="<img  src='../../Images/Dashboard/PrivateCall.png'   border='0'  />"
                                                        OnClick="lnkPirvateCall_OnClick"></asp:LinkButton>
                                                       
                                                    <%-- <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>" width="9"
                                                        height="28">--%>
                                                    <%--
                                                        1 Means Default Tab
                                                        2 Means Private Call Tab--%>
                                                    <%} %>
                                                     &nbsp;&nbsp; <span class="couponcode">
                                                        <img border="0" src="../../images/Dashboard/new.png" style="vertical-align:top" />
                                                        <span class="coupontooltip" style=" height:140px;">If you have a private call module you may choose which directory
                                                            buttons will display on your App by selecting this tab and checking the boxes; you
                                                            may change their names and icons by clicking 'Modify'. The private call module will
                                                            only display on those smart devices that have accepted an invitation sent by you.
                                                            Private Call Modules are available for purchase in the market place.</span></span>
                                                    <asp:HiddenField runat="server" ID="hdnSelectedTab" Value="1" />
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel runat="server" ID="pnlDefaultButtons">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="profile-input">
                                                <tr>
                                                    <td align="left" style="padding-left: 5px; padding-top: 5px;">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="space">
                                                                    <ul id="sortable">
                                                                        <asp:ListView ID="lvCustomModule" OnItemDataBound="lvCustomModule_ItemDataBound"
                                                                            runat="server" DataKeyNames="UserModuleID" ItemPlaceholderID="myItemPlaceHolder">
                                                                            <LayoutTemplate>
                                                                            </LayoutTemplate>
                                                                            <LayoutTemplate>
                                                                                <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                                            </LayoutTemplate>
                                                                            <ItemTemplate>
                                                                                <li class="ui-state-default" id='id_<%# Eval("UserModuleID") %>' style="border: 2px solid #ccc;
                                                                                    background: #FFF; font-weight: normal; color: #8C8C8C; height: auto;">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td width="22%" style="vertical-align: top; padding-right: 10px;">
                                                                                                <asp:CheckBox ID="chkVisible" runat="server" Name="visible" Checked='<%#Eval("IsVisible") %>' />&nbsp;
                                                                                                <img src='../../Images/CustomModulesAppIcons/<%#Eval("AppIcon") %>.png' class="imgpad tpad" />&nbsp;
                                                                                                <asp:Label ID="lblTemplatename" runat="server" Text='<%#Eval("TabName") %>'></asp:Label>&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: auto;">
                                                                                                <asp:LinkButton ID="lnkChange" CommandArgument='<%#Eval("UserModuleID") %>' runat="server"
                                                                                                    CssClass="linkColor" OnClick="lnkChange_Click">Modify</asp:LinkButton>&nbsp;
                                                                                                <asp:PlaceHolder ID="CallPlaceHolder" runat="server" Visible='<%#(Convert.ToString(Eval("ButtonType"))=="Call")?true:false %>'>
                                                                                                    | &nbsp; <span style="color: #ff7a5a; font-weight: bold;">
                                                                                                        <%=hdnCall.Value%></span>&nbsp;&nbsp;<asp:LinkButton ID="lnkCall" runat="server"
                                                                                                            CssClass="linkColor" OnClick="lnkCall_Click">View / Change</asp:LinkButton>
                                                                                                </asp:PlaceHolder>
                                                                                                <asp:PlaceHolder ID="CategoryPlaceHolder" runat="server" Visible='<%# (DomainName.ToLower().Contains("uspd") || DomainName.ToLower().Contains("localhost")==true?(Convert.ToBoolean(Eval("IsHasChilds"))==true?true:false):false) %>'>
                                                                                                    | &nbsp;
                                                                                                    <asp:LinkButton ID="lnkDeactivate" Text='<%# Eval("Deactivate") + " (" +  Eval("ActiveForms") + ")" %>'
                                                                                                        CommandArgument='<%#Eval("UserModuleID") %>' runat="server" CssClass="linkColor"
                                                                                                        OnClick="lnkDeactivate_Click"></asp:LinkButton>&nbsp; | &nbsp;
                                                                                                    <asp:LinkButton ID="lnkAddMore" CommandArgument='<%#Eval("UserModuleID") %>' runat="server"
                                                                                                        CssClass="linkColor" OnClick="lnkAddMore_Click">Add More Templates</asp:LinkButton>
                                                                                                </asp:PlaceHolder>
                                                                                                <asp:PlaceHolder ID="PrivateConPlaceHolder" runat="server" Visible='<%#(Convert.ToString(Eval("ButtonType"))=="PrivateAddOn")?true:false %>'>
                                                                                                    | &nbsp;<asp:LinkButton ID="lnkInvitations" CommandArgument='<%#Eval("UserModuleID") %>'
                                                                                                        runat="server" CssClass="linkColor" OnClick="lnkInvitations_Click">Invitations</asp:LinkButton>
                                                                                                </asp:PlaceHolder>
                                                                                                <asp:PlaceHolder ID="CategoryPlaceHolder2" runat="server" Visible='<%# (DomainName.ToLower().Contains("uspd") || DomainName.ToLower().Contains("localhost")==true?(Convert.ToBoolean(Eval("IsHasChilds"))==true?true:false):false) %>'>
                                                                                                    <br />
                                                                                                    <asp:DataList ID="dlCMForms" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                                                                                                        Style="height: auto; margin-top: 5px;">
                                                                                                        <ItemTemplate>
                                                                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                                                                <tr>
                                                                                                                    <td style="padding-right: 25px;">
                                                                                                                        <img src='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("ImagePath") %>'
                                                                                                                            style="border-width: 0px;" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" colspan="2" style="color: Orange; font-weight: bold; padding-right: 20px;">
                                                                                                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("TemplateName") %>'></asp:Label>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:DataList>
                                                                                                </asp:PlaceHolder>
                                                                                            </td>
                                                                                            <td valign="top" style="margin-right: 20px; color: Red;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("ButtonType") %>'></asp:Label></b>
                                                                                            </td>
                                                                                            <td valign="top" style="margin-right: 20px;">
                                                                                                <span class="couponcode1">
                                                                                                    <img border="0" src="../../images/Dashboard/new.png" />
                                                                                                    <span id="spancoupon1" class="questiontooltip1">
                                                                                                        <asp:Label ID="lbltooltip" runat="server" Text='<%# Eval("ToolTip") %>'></asp:Label>
                                                                                                    </span></span>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </li>
                                                                            </ItemTemplate>
                                                                        </asp:ListView>
                                                                    </ul>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlPrivateCallButtons" Visible="false">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="profile-input">
                                                <tr>
                                                    <td align="left" style="padding-left: 5px; padding-top: 5px;">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="space">
                                                                    <ul id="sortable1">
                                                                        <asp:ListView ID="lstPrivateCallButtons" OnItemDataBound="lvCustomModule_ItemDataBound"
                                                                            runat="server" DataKeyNames="UserModuleID" ItemPlaceholderID="myItemPlaceHolder">
                                                                            <LayoutTemplate>
                                                                            </LayoutTemplate>
                                                                            <LayoutTemplate>
                                                                                <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                                            </LayoutTemplate>
                                                                            <ItemTemplate>
                                                                                <li class="ui-state-default" id='id_<%# Eval("UserModuleID") %>' style="border: 2px solid #ccc;
                                                                                    background: #FFF; font-weight: normal; color: #8C8C8C; height: auto;">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td width="22%" style="vertical-align: top; padding-right: 10px;">
                                                                                                <asp:CheckBox ID="chkVisible" runat="server" Name="visible" Checked='<%#Eval("IsVisible") %>' />&nbsp;
                                                                                                <img src='../../Images/CustomModulesAppIcons/<%#Eval("AppIcon") %>.png' class="imgpad tpad" />&nbsp;
                                                                                                <asp:Label ID="lblTemplatename" runat="server" Text='<%#Eval("TabName") %>'></asp:Label>&nbsp;
                                                                                            </td>
                                                                                            <td align="left" style="width: auto;">
                                                                                                <asp:LinkButton ID="lnkChange" CommandArgument='<%#Eval("UserModuleID") %>' runat="server"
                                                                                                    CssClass="linkColor" OnClick="lnkChange_Click">Modify</asp:LinkButton>&nbsp;
                                                                                                <asp:PlaceHolder ID="CallPlaceHolder" runat="server" Visible='<%#(Convert.ToString(Eval("ButtonType"))=="Call")?true:false %>'>
                                                                                                    | &nbsp; <span style="color: Orange; font-weight: bold;">
                                                                                                        <%=hdnCall.Value%></span>&nbsp;&nbsp;<asp:LinkButton ID="lnkCall" runat="server"
                                                                                                            CssClass="linkColor" OnClick="lnkCall_Click">View / Change</asp:LinkButton>
                                                                                                </asp:PlaceHolder>
                                                                                                <asp:PlaceHolder ID="CategoryPlaceHolder" runat="server" Visible='<%# (DomainName.ToLower().Contains("uspd") || DomainName.ToLower().Contains("localhost")==true?(Convert.ToBoolean(Eval("IsHasChilds"))==true?true:false):false) %>'>
                                                                                                    | &nbsp;
                                                                                                    <asp:LinkButton ID="lnkDeactivate" Text='<%# Eval("Deactivate") + " (" +  Eval("ActiveForms") + ")" %>'
                                                                                                        CommandArgument='<%#Eval("UserModuleID") %>' runat="server" CssClass="linkColor"
                                                                                                        OnClick="lnkDeactivate_Click"></asp:LinkButton>&nbsp; | &nbsp;
                                                                                                    <asp:LinkButton ID="lnkAddMore" CommandArgument='<%#Eval("UserModuleID") %>' runat="server"
                                                                                                        CssClass="linkColor" OnClick="lnkAddMore_Click">Add More Templates</asp:LinkButton>
                                                                                                </asp:PlaceHolder>
                                                                                                <asp:PlaceHolder ID="PrivateConPlaceHolder" runat="server" Visible='<%#(Convert.ToString(Eval("ButtonType"))=="PrivateAddOn")?true:false %>'>
                                                                                                    | &nbsp;<asp:LinkButton ID="lnkInvitations" CommandArgument='<%#Eval("UserModuleID") %>'
                                                                                                        runat="server" CssClass="linkColor" OnClick="lnkInvitations_Click">Invitations</asp:LinkButton>
                                                                                                </asp:PlaceHolder>
                                                                                            </td>
                                                                                            <td valign="top" style="margin-right: 20px; color: Red;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("ButtonType") %>' Style="display: none;"></asp:Label></b>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </li>
                                                                            </ItemTemplate>
                                                                        </asp:ListView>
                                                                    </ul>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="profile-btntbl">
                                <tr>
                                    <td class="align-right" valign="top">
                                        <asp:Button ID="btncancelupdate" CssClass="button" runat="server" Text="Back" OnClick="btncancelupdate_Click" />&nbsp;&nbsp;
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click"
                                            OnClientClick="return UpdateOder();" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table border="0" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblCustomModule" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalCustomModule" runat="server" TargetControlID="lblCustomModule"
                            PopupControlID="pnlCustomModulepop" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlCustomModulepop" runat="server" Width="50%" Style="display: none;">
                            <table>
                                <tr>
                                    <td>
                                        <div>
                                            <div id="popup-cont">
                                                <div class="top">
                                                    <a href="javascript:HideCustomModuleModalWindow();"></a>
                                                </div>
                                                <div class="middle">
                                                    <h2 class="lft">
                                                        1. Show In App</h2>
                                                    <asp:CheckBox ID="chkIndVisible" runat="server" />
                                                    <%--<h2>
                                                        2. App Button name</h2>
                                                    <asp:TextBox ID="txtAppButtonName" runat="server" MaxLength="13" class="txt-input"></asp:TextBox>
                                                    <h2>--%>
                                                    <br />
                                                    <br />
                                                    <p class="lft">
                                                        <h2>
                                                            2. App Button name
                                                            <asp:TextBox ID="txtAppButtonName" runat="server" onkeypress="return isNumberKey(event);"
                                                                onkeydown="return Maxlength(this);" MaxLength="13" class="txt-input"></asp:TextBox></h2>
                                                    </p>
                                                    <h2>
                                                        3. App Button Icon (Select any one from the below list)</h2>
                                                    <div class="scrollablebox">
                                                        <div class="auto">
                                                            <ul class="AppIcons">
                                                                <asp:Literal ID="ltrlCustomAppIcons" runat="server"></asp:Literal>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    <asp:LinkButton ID="lnkSubmit" runat="server" class="btn" Text="Submit" OnClick="lnkSubmit_Click"
                                                        OnClientClick="return ValidateAppButton();"></asp:LinkButton>
                                                </div>
                                                <div class="bottom">
                                                </div>
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
                                                                            <asp:CheckBox ID="chkDeactivate" runat="server" />
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function GetSelectAppButton(moduleAppButton) {
            var prvAppIcon = document.getElementById("<%=hdnModuleAppButton.ClientID %>").value;
            $("#img" + moduleAppButton).parent("li").addClass("iconselect").siblings().removeClass('iconselect');
            $("#img" + prvAppIcon).parent("li").addClass("icon")
            document.getElementById("<%=hdnModuleAppButton.ClientID %>").value = moduleAppButton;

        }
        function HideCustomModuleModalWindow() {
            $find("<%=ModalCustomModule.ClientID %>").hide();
            document.getElementById("<%=hdnModuleTemplateID.ClientID %>").value = "";
        }
        function HideDeactivateWindow() {
            $find("<%=ModalDeactivate.ClientID %>").hide();
        }
        function HideAddMoreWindow() {
            $find("<%=ModalRemaing.ClientID %>").hide();
        }
        function CheckDeactivate() {
            var selCount = 0;
            var foo = document.getElementById("<%=dlDeactivate.ClientID %>");
            var inps = foo.getElementsByTagName("input");

            for (var i = 0; i < inps.length; i++) {

                if (inps[i].type == "checkbox" && inps[i].checked) {
                    selCount = selCount + 1;
                }
            }
            if (selCount == 0) {
                alert('Please select at least one form to remove.');
                return false;
            }
            return true;
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
                alert('Please select at least one form to add.');
                return false;
            }
            return true;
        }
        var order = '';
        $(document).ready(function () {
            BindLoadEvents();
        });



        function OnSortableUpdate(event, ui) {
            order = $('#sortable').sortable('toArray').join(',').replace(/id_/gi, '');
        }

        function UpdateOder() {
            document.getElementById('<%=lblstatusmessage.ClientID %>').innerHTML = "";
            var typeval = PageMethods.UpdateItemsOrder(order, OnSuccess, OnFailure);
        }
        function OnSuccess(result) {
            if (result == "success") {
                return true;
            }
            else {
                OnFailure(result);
                return false;
            }
        }
        function OnFailure(result) {
            //alert(result);
            //alert("Failure occurs while updating. Please try again.");
            return false;
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode > 47 && charCode < 58) || (charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32)
                return true;
            else
                return false;
        }
        function ValidateAppButton() {
            var returnValue = false;
            var appButton = document.getElementById("<%=txtAppButtonName.ClientID %>").value;
            if (appButton == "")
                alert("Please enter app button name.");
            else {
                var re = /^[a-zA-Z0-9 ]*$/;
                if ((re.test(appButton)) == true) {
                    returnValue = true;
                }
                else {
                    alert("Special characters are not allowed in tab names.");
                    returnValue = false;
                }
            }
            return returnValue;
        }
        function Maxlength(text) {
            var textLength = text.value.length;
            if (parseInt(textLength) > 13) {
                alert("The maximum allowable length should be 13 characters only.");
                return false;
            }
            else
                return true;
        }
    </script>
</asp:Content>
