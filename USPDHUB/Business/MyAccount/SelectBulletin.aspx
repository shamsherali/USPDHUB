<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="SelectBulletin.aspx.cs" Inherits="USPDHUB.Business.MyAccount.SelectBulletin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
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
        .ItemStyles1
        {
            border-left: 1px solid #2c58e8;
            border-right: 1px solid #2c58e8;
        }
        .ItemStyles2
        {
            border-right: 1px solid #2c58e8;
        }
        .btn-default
        {
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
            color: #ffffff;
            min-width: 85px;
            height: 32px;
            white-space: nowrap;
            cursor: pointer;
            outline: 0 none;
            padding: 4px 10px 2px;
            text-align: center;
            border-radius: 2px 2px 2px 2px;
            border: 1px solid #0061a7; /*#fcb040;*/
            background-color: #007dc1; /*#fcb040;*/
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#5384BE', endColorstr='#4386D7'); /* for IE */
            -ms-filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#5384BE', endColorstr='#4386D7'); /* for IE 8 and above */
            background: -webkit-gradient(linear, left top, left bottom, from(#5384BE), to(#4386D7)); /* for webkit browsers */
            background: -moz-linear-gradient(top, #5384BE, #4386D7); /* for firefox 3.6+ */
            background: -o-linear-gradient(top, #5384BE, #4386D7); /* for Opera */
        }
        .btn-default::before
        {
            cursor: pointer;
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=' #85B6F0', endColorstr='#579AEB'); /* for IE */
            -ms-filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=' #85B6F0',    endColorstr='#579AEB'); /* for IE 8 and above */
            background: -webkit-gradient(linear, left top, left bottom, from(#85B6F0),    to(#579AEB)); /* for webkit browsers */
            background: -moz-linear-gradient(top, #85B6F0, #579AEB); /* for firefox 3.6+ */
            background: -o-linear-gradient(top, #85B6F0, #579AEB); /* for Opera */
        }
        #ctl00_cphUser_lnkAdd, #ctl00_cphUser_lnkRemove
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
            margin-left:20%;
        }
        #ctl00_cphUser_lnkRemove
        {
            background: url(../../../images/icon-remove.png) no-repeat;
            background-position: 3px;
            margin-right: 17px;
            color: red;
            margin-left:0%;
        }
        .favorite
        {
            font-weight: 600;
            color: green;
            font-size: 16px;
        }
        .header
        {
            color: red !important;
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
                                                Create App Bulletin <a href="javascript:ModalHelpPopup('Create Content Using Templates & Forms',139,'');">
                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                            </div>
                                            <div style="display: table-cell; vertical-align: middle; text-align: center;">
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
                                        <td>
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
                                            <tr>
                                                <td style="padding-top: 10px;">
                                                    <asp:Panel ID="pnlFavCategories" runat="server">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="GrdCategory" runat="server" Width="235px" OnRowDataBound="GrdCategory_RowDataBound"
                                                                        AutoGenerateColumns="false" CssClass="datagrid3" ShowHeader="false">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-CssClass="ItemStyles1">
                                                                                <ItemTemplate>
                                                                                    <asp:RadioButton ID="rbBulletin" runat="server" AutoPostBack="true" onclick='<%# string.Format("javascript:AssignCategoryID(this, \"{0}\",\"{1}\")", Eval("Category_ID"), Eval("Category"))%>'
                                                                                        OnCheckedChanged="rbBulletin_CheckedChanged" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="20px"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-CssClass="ItemStyles2">
                                                                                <ItemTemplate>
                                                                                    <li id="active"><span>
                                                                                        <asp:LinkButton ID="lnktemplatename" runat="server" Text='<%#Eval("Category")%>'
                                                                                            CommandArgument='<%#Eval("Category_ID") %>' OnClick="lnktemplatename_Click" CausesValidation="false"
                                                                                            onmouseover="change(this,event);" onmouseout="change(this,event);"></asp:LinkButton>
                                                                                    </span></li>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle ForeColor="AliceBlue" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span><b>Note: Use the buttons below to add/remove forms to your favorites list. </b></span><br />
                                                                    <asp:LinkButton ID="lnkAdd" runat="server" Text="ADD" OnClick="lnkAddFavourite_Click"></asp:LinkButton>
                                                                    <%if (hdnIsRemove.Value == "true")
                                                                      { %>
                                                                    <asp:LinkButton ID="lnkRemove" runat="server" Text="REMOVE" OnClick="lnkRemoveFavourite_Click"></asp:LinkButton>
                                                                    <%} %>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="pnlCustomLeft" runat="server" Visible="false">
                                            <br />
                                            <div id="customwrap" style="margin: 2px;">
                                                <img src="../../Images/Dashboard/need.png" width="231" height="52" />
                                                <div id="customcontent">
                                                    We'll create one for you
                                                    <br />
                                                    call us at <span class="phn">1-800-281-0263</span><br />
                                                    Mon - Fri 8 a.m. - 5 p.m. PST<br />
                                                    or email us at
                                                    <br />
                                                    <a class="phn" href="mailTo:<%=hdnSupport.Value %>">
                                                        <%=hdnSupport.Value %></a>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                    <td valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="navy20" style="padding-left: 5px;">
                                                    Step 2: Choose a Template Design
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="height: 420px; overflow-y: auto; border: solid 1px #4684C5; margin: 5px;">
                                                        <%-- <asp:Panel ID="pnlAddFavourite" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="80%" align="center" style="padding-top: 150px;">
                                                                <tr>
                                                                    <td style="font-size: 16px; text-align: center; line-height: 22px">
                                                                        Currently you do not have any favorites.<br />
                                                                        <asp:LinkButton ID="lnkAddFavourite" runat="server" class="phn" OnClick="lnkAddFavourite_Click">Add Favorites</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>--%>
                                                        <asp:Panel ID="pnlCustom" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="80%" align="center" style="padding-top: 150px;">
                                                                <tr>
                                                                    <td style="font-size: 16px; text-align: center; line-height: 22px">
                                                                        Need a custom form? We'll create one for you. Call us at 1-800-281-0263
                                                                        <br />
                                                                        Monday - Friday 8 a.m. - 5 p.m. PST
                                                                        <br />
                                                                        or email us at <a href="mailTo:<%=hdnSupport.Value %>">
                                                                            <%=hdnSupport.Value %></a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:DataList ID="DLAllCategory" runat="server" RepeatDirection="Vertical" OnItemDataBound="DLAllCategory_ItemDataBound"
                                                            DataKeyNames="Category_ID" Style="width: 100%; display: none;">
                                                            <ItemTemplate>
                                                                <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                                    <tr>
                                                                        <td style="background-color: #5590cc; color: White; font-weight: bold;">
                                                                            <asp:Label ID="lblCatTemplatename" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DataList ID="rptTest" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                                                DataKeyField="Template_BID">
                                                                                <ItemTemplate>
                                                                                    <table cellpadding="5" cellspacing="0" border="0" width="95%">
                                                                                        <tr style="padding-left: 20px; padding-top: 20px; padding-bottom: 10px;">
                                                                                            <td colspan="2" valign="top" style="padding: 0px 60px 0px 5px;">
                                                                                                <div align="right" style="position: relative; left: 5px; top: 19px; z-index: 0;">
                                                                                                    <a href='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("Image_ThumbName") %>'
                                                                                                        style="width: 150px;" class="highslide" onclick="return hs.expand(this)">
                                                                                                        <asp:ImageButton ID="imgpreview" runat="server" ToolTip="Zoom" ImageUrl="~/Business/MyAccount/Images/zoom.png"
                                                                                                            CausesValidation="false" />
                                                                                                    </a>
                                                                                                </div>
                                                                                                <a href='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("Image_ThumbName") %>'
                                                                                                    class="highslide" onclick="return hs.expand(this)">
                                                                                                    <input type="image" src='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("Image_ThumbName") %>'
                                                                                                        style="border-width: 0px;" />
                                                                                                </a>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table cellpadding="5" cellspacing="0" border="0" width="95%">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="lblTemplatename" runat="server" Text='<%#Eval("Template_Name") %>'></asp:Label>
                                                                                            </td>
                                                                                            <td align="right" style="padding-right: 50px;">
                                                                                                <asp:LinkButton ID="btnSelect" CommandArgument='<%#Eval("Template_BID") %>' runat="server"
                                                                                                    OnClick="btnSelect_Click" OnClientClick="return CheckForTemplateName()"><img src="<%=Page.ResolveClientUrl("~/images/Dashboard/SelectBulletin.png")%>"/></asp:LinkButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:DataList ID="DLMyFavorites" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                            DataKeyField="Template_BID" Style="display: none;">
                                                            <ItemTemplate>
                                                                <table cellpadding="5" cellspacing="0" border="0" width="95%">
                                                                    <tr style="padding-left: 20px; padding-top: 20px; padding-bottom: 10px;">
                                                                        <td colspan="2" valign="top" style="padding: 0px 60px 0px 5px;">
                                                                            <div align="right" style="position: relative; left: 5px; top: 19px; z-index: 0;">
                                                                                <a href='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("Image_ThumbName") %>'
                                                                                    style="width: 150px;" class="highslide" onclick="return hs.expand(this)">
                                                                                    <asp:ImageButton ID="imgpreview" runat="server" ToolTip="Zoom" ImageUrl="~/Business/MyAccount/Images/zoom.png"
                                                                                        CausesValidation="false" />
                                                                                </a>
                                                                            </div>
                                                                            <a href='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("Image_ThumbName") %>'
                                                                                class="highslide" onclick="return hs.expand(this)">
                                                                                <input type="image" src='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("Image_ThumbName") %>'
                                                                                    style="border-width: 0px;" />
                                                                            </a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table cellpadding="5" cellspacing="0" border="0" width="95%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblTemplatename" runat="server" Text='<%#Eval("Template_Name") %>'></asp:Label>
                                                                        </td>
                                                                        <td align="right" style="padding-right: 50px;">
                                                                            <asp:LinkButton ID="btnSelect" CommandArgument='<%#Eval("Template_BID") %>' runat="server"
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
            </table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblAllTemplates" runat="server" visiable="false"></asp:Label>
                        <cc1:ModalPopupExtender ID="MPETemplates" runat="server" TargetControlID="lblAllTemplates"
                            PopupControlID="pnlAllTemplates" BackgroundCssClass="modal" CancelControlID="imgClose">
                        </cc1:ModalPopupExtender>
                        <asp:Panel Style="display: none" ID="pnlAllTemplates" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%" class="popuptable" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" style="padding: 5px;">
                                                <tbody>
                                                    <tr>
                                                        <td class="header">
                                                            <asp:Label ID="lblHeading" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                CausesValidation="false"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <div style="overflow-y: auto; height: 475px; position: relative; width: auto; border: 1px solid #888;
                                                min-width: 300px;">
                                                <asp:DataList ID="DLFavCategories" runat="server" RepeatDirection="Vertical" OnItemDataBound="DLFavCategories_ItemDataBound"
                                                    DataKeyNames="Category_ID" Style="width: 100%;">
                                                    <ItemTemplate>
                                                        <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td style="background-color: #5590cc; color: White; font-weight: bold;">
                                                                    <asp:Label ID="lblTemplatename" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DataList ID="DLFavourites" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                                        DataKeyField="Template_BID">
                                                                        <ItemTemplate>
                                                                            <table cellpadding="5" cellspacing="0" border="0" width="95%">
                                                                                <tr style="padding-left: 20px; padding-top: 20px; padding-bottom: 10px;">
                                                                                    <td valign="top">
                                                                                        <asp:CheckBox ID="chkFavourite" runat="server" onclick='<%# string.Format("javascript:return AddTemplateFavorite(this,\"{0}\")", Eval("Template_BID"))%>' />
                                                                                    </td>
                                                                                    <td valign="top" style="padding: 6px 60px 0px 5px;">
                                                                                        <a href='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("Image_ThumbName") %>'
                                                                                            class="highslide" onclick="return hs.expand(this)">
                                                                                            <input type="image" src='<%=Page.ResolveClientUrl("~/images/BulletinThumbs/")%><%#Eval("Image_ThumbName") %>'
                                                                                                style="border-width: 0px;" />
                                                                                        </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <table cellpadding="5" cellspacing="0" border="0" width="95%">
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td style="padding: 0px 60px 0px 25px;">
                                                                                        <asp:Label ID="lblTemplatename" runat="server" Text='<%#Eval("Template_Name") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 10px;">
                                            <asp:Button ID="btnAddFavorites" runat="server" Text="Add" CssClass="btn-default"
                                                OnClick="btnAddFavorites_Click" OnClientClick="return CheckFavorites();" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnimage" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hdnSupport" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hdnrow" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="hdnrowindex" runat="server" />
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
            <asp:HiddenField ID="hdnSelItems" runat="server" />
            <asp:HiddenField ID="hdnIsRemove" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
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
        function AssignCategoryID(rbID, CategoryID, CategoryText) {
            var gv = document.getElementById("<%=GrdCategory.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rbID) {
                        rbs[i].checked = false;
                        break;
                    }
                }
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
        function CheckForTemplateName() {
            if (document.getElementById('<%=Txttemplatename.ClientID %>').value == '') {
                alert('Please enter a title.');
                return false;
            }
            else {
                return true;
            }
        }
        function AddTemplateFavorite(chkid, templateid) {
            var selFavorites = document.getElementById('<%= hdnSelItems.ClientID%>').value;
            if (chkid.checked)
                selFavorites = selFavorites + templateid + ", ";
            else
                selFavorites = selFavorites.replace(templateid + ", ", "");
            document.getElementById('<%= hdnSelItems.ClientID%>').value = selFavorites;
        }
        function CheckFavorites() {
            if (document.getElementById('<%= hdnSelItems.ClientID%>').value.trim() == "") {
                alert('Please select atleast a form.');
                return false;
            }
            return true;
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
