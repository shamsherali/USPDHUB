<%@ Page Title="" Language="C#" MasterPageFile="~/Business/MyAccount/CallIndexMaster.Master"
    ValidateRequest="false" AutoEventWireup="true" CodeBehind="ManageCallIndexInvitations.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.ManageCallIndexInvitations" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser1" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <link href="../../css/Jquery-order-ui.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-bubble-popup-v3.min.js" type="text/javascript"></script>
    <link href="../../css/accordion/jquery.ui.base.css" rel="stylesheet" type="text/css" />
    <link href="../../css/accordion/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../../css/jquery-bubble-popup-v3.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.min.js"></script>
    <script language="javascript" type="text/javascript">
        function CallHelpMethod() {


            return true;
        }
        $(document).ready(function () {

            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: '<p style="line-height:18px; text-align:left; font-size:14px;">Disabling a device allows the app owner to restrict </br> that device from displaying the private button </br>temporarily. This is especially helpful if the app user</br> reports the device misplaced or lost. To reinstate it,</br> simply enable it.</p>',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });



        });
    </script>
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: '<p style="line-height:18px; text-align:left; font-size:14px;">Disabling a device allows the app owner to restrict </br> that device from displaying the private button </br>temporarily. This is especially helpful if the app user</br> reports the device misplaced or lost. To reinstate it,</br> simply enable it.</p>',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'

                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });


            $('.jquerybubblepopup').css('z-index', '9999');

        });

    </script>
    <style type="text/css">
        .btn
        {
            -webkit-border-radius: 3;
            -moz-border-radius: 3;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            background: #3498db;
            padding: 7px 15px 7px 15px;
            text-decoration: none;
        }
        
        .btn:hover
        {
            background: #3cb0fd;
            text-decoration: none;
        }
        .btnorange
        {
            -webkit-border-radius: 3;
            -moz-border-radius: 3;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 12px;
            background: #DC7224;
            padding: 4px 8px;
            color: #fff !important;
            text-decoration: none !important;
        }
        
        .btnorange:hover
        {
            background: #3cb0fd;
            text-decoration: none;
        }
        .radius
        {
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
        }
        #manage
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        #manage .clear
        {
            clear: both;
        }
        #manage a img
        {
            border: none;
        }
        #manage h1, #manage h2, #tabber ul
        {
            margin: 0;
            padding: 0;
        }
        #manage h1
        {
            font-size: 18px;
            color: #EC2027;
            height: 35px;
            line-height: 35px;
        }
        #manage h2
        {
            background: #f3f3f3;
            display: block;
            padding: 5px;
            font-size: 16px;
            color: #0a59a9;
            margin-top: 10px;
            border: solid 1px #dcdcdc;
        }
        #tabber
        {
            margin-top: 27px;
        }
        #tabber .content
        {
            background: #f3f3f3;
            border: solid 1px #d5d5d5;
            padding: 6px;
        }
        #tabber .content .leftmenu
        {
            vertical-align: top;
            padding-right: 5px;
        }
        #tabber .content .rightmenu
        {
            vertical-align: top;
            padding-left: 0px;
            width: 169px;
            float: left;
        }
        #tabber .content .rightmenu .rightLinks
        {
            padding-bottom: 1px;
        }
        #tabber .content .rightmenu .rightLinks a
        {
            display: block;
            font-size: 13px;
            color: #003c7f;
            background: url(../../images/Dashboard/side_link.gif) repeat-x;
            height: 35px;
            text-align: left;
            border: solid 1px #9abfe7;
            text-decoration: none;
            font-weight: bold;
            line-height: 35px;
        }
        #tabber .content .rightmenu .rightLinks a:hover
        {
            background: url(../../images/Dashboard/side_link_h.gif) repeat-x;
        }
        #tabber .content .rightmenu .rightLinks a span
        {
            display: block;
            float: left;
            height: 35px;
            width: 35px;
            margin-right: 13px;
        }
        #tabber .content .rightmenu .share
        {
            background: #f8fcff;
            text-align: center;
            border: solid 1px #d2e8ff;
        }
        #tabber .content .rightmenu .share img
        {
            margin: 10px;
        }
        #fullheight
        {
            height: 100%;
            text-align: center;
        }
        .cursor
        {
            cursor: hand;
        }
        .sendcontactsbutton
        {
            background: url(../../images/CreateModule.png) no-repeat;
            width: 134px;
            height: 35px;
            color: #fff;
            font-size: 16px;
            text-align: center;
            border: 0px;
            font-weight: bold;
            cursor: hand;
        }
        .navy20
        {
            width: 100px;
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
            padding: 10px 0px 5px 0px;
        }
    </style>
    <style>
        .GridDock
        {
            overflow-x: auto;
            overflow-y: hidden;
            padding: 0 0 10px 0;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <h1>
                                            Manage Invitations</h1>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: red;" align="center">
                                        <asp:Label ID="lblerrormessage" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <colgroup>
                                <col width="75%" />
                                <col width="*" />
                            </colgroup>
                            <tbody>
                                <tr>
                                    <asp:HiddenField ID="hdnAddOnName" runat="server" />
                                    <td style="text-align: right; padding-right: 25%;">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td style="color: green" align="center">
                                        <asp:Label ID="lblmess" runat="server"></asp:Label>
                                        <asp:Label ID="lbleditn" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
                            <tr>
                                <td>
                                    <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                    <div class="GridDock" id="dvGridWidth" style="border: 1px solid #428ad7;">
                                                        <asp:GridView ID="GrdInviters" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            CssClass="datagrid2" AllowPaging="True" Width="100%" GridLines="None" PageSize="5"
                                                            OnRowDataBound="GrdInviters_OnRowDataBound" DataKeyNames="MobileNumber" OnSorting="GrdInviters_Sorting"
                                                            OnPageIndexChanging="GrdInviters_PageIndexChanging">
                                                            <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Contact Details" SortExpression="FirstName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFirstName" Text='<%# Eval("FirstName") + " " + Eval("LastName")%>'
                                                                            runat="server"></asp:Label><br />
                                                                        <asp:Label ID="lblEmaildId" Text='<%# Eval("EmailID")%>' runat="server"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="lblMobile" Text='<%# Eval("MobileNumber")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Device Management">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="LinkButton1" OnClick="lnkDeviceCount_OnClick"
                                                                            OnClientClick="return CallHelpMethod();" CommandArgument='<%# Bind("InviterID") %>'>                                                                            
                                                                          <img src="../../images/dashboard/preview.png"  /></asp:LinkButton><br />
                                                                        <asp:LinkButton runat="server" ID="lnkDeviceCount" Text='<%# Bind("DeviceCount") %>'
                                                                            OnClick="lnkDeviceCount_OnClick" OnClientClick="return CallHelpMethod();" CommandArgument='<%# Bind("InviterID") %>'>                                                                            
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tab Name" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTabNameTitle" Text='<%# Bind("TabName") %>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIsActive" Text='<%# Bind("IsActive") %>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText='Actions'>
                                                                    <ItemTemplate>
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:LinkButton runat="server" ID="lnkDelete" Font-Bold="true" OnClick="lnkDelete_OnClick"
                                                                                        CommandArgument='<%# Bind("InviterID") %>' OnClientClick="return confirm('Are you sure you want to delete?');">
                                                                                        <img src="../../images/Dashboard/managedelete.png" /><br />Delete</asp:LinkButton>
                                                                                    <asp:LinkButton runat="server" ID="lnkDisable" Font-Bold="true" Text="Disable" OnClick="lnkDisable_OnClick"
                                                                                        CommandArgument='<%# Bind("InviterID") %>' OnClientClick="return Enable_Disable(this);"
                                                                                        Style="display: none;"></asp:LinkButton>
                                                                                </td><%--
                                                                                <td align="center">
                                                                                    <asp:LinkButton runat="server" ID="LinkButton3" Font-Bold="true" OnClick="lnkResend_OnClick"
                                                                                        CommandArgument='<%# Bind("InviterID") %>' OnClientClick="return confirm('Are you sure you want to send another invitation?');">
                                                                               <img src="../../images/Dashboard/manageadddevice.png"><br />Add Device</asp:LinkButton>
                                                                                </td>--%>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="175px" HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                No contents found
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="title3"></HeaderStyle>
                                                            <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnSepupInvitations" runat="server" Text="Back" CausesValidation="false"
                                        OnClick="btnSepupInvitations_OnClick" Width="50px" Height="24px" />
                                    <%-- &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" Text="Dashboard" CausesValidation="false"
                                        OnClick="btnDashboard_OnClick" />--%>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnURLPath" runat="server" />
                        <asp:HiddenField ID="hdnsortdire" runat="server" />
                        <asp:HiddenField ID="hdnsortcount" runat="server" />
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblp" runat="server" Visible="false"></asp:Label><asp:Label ID="lblc"
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <style>
                                            .modal1
                                            {
                                                background-color: Gray;
                                                filter: alpha(opacity=90);
                                                opacity: 0.7;
                                                z-index: 0 !important;
                                            }
                                            #ctl00_cphUser_pnlcoupsch
                                            {
                                                z-index: 1 !important;
                                                position: fixed !important;
                                            }
                                            #ctl00_ctl00_cphUser_cphUser1_pnlcoupsch
                                            {
                                                z-index: 1 !important;
                                            }
                                        </style>
                                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblc"
                                            PopupControlID="pnlcoupsch" BackgroundCssClass="modal1">
                                        </cc1:ModalPopupExtender>
                                        <asp:Panel Style="display: none; z-index: 1;" ID="pnlcoupsch" runat="server" Width="100%">
                                            <table class="popuptable" cellspacing="0" cellpadding="0" width="950" align="center"
                                                border="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                                                <ProgressTemplate>
                                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="header">
                                                                            Device Management for <span style="color: maroon; font-family: Arial; size: 2"><span
                                                                                style="color: maroon; font-family: Arial; size: 2">
                                                                                <asp:Label ID="lblx" runat="server"></asp:Label>
                                                                            </span></span>
                                                                        </td>
                                                                        <td align="right">
                                                                            <asp:ImageButton ID="imglogin1" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif"
                                                                                OnClick="btn_OnClick"></asp:ImageButton>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label runat="server" ID="lblMessage1"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="grdDeviceDetails" runat="server" PageSize="10" AllowPaging="True"
                                                                                AutoGenerateColumns="False" CssClass="datagrid2" Width="100%" OnRowDataBound="Grd_OnRowDataBound">
                                                                                <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Device ID">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("UniqueDeviceID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Wrap="true" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="DeviceType" HeaderText="Device Type" />
                                                                                    <asp:TemplateField HeaderText="Status">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblIsActive" Text='<%# Bind("IsActive") %>' runat="server" Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblIsEnable" Text='<%# Bind("IsEnable") %>' runat="server" Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblOTP" Text='<%# Bind("OTP") %>' runat="server" Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblStatus" Text='<%# Bind("Status") %>' runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Phone Number">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblMobileNumber" runat="server" Text='<%# Bind("MobileNumber") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Wrap="true" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="StatusDate" HeaderText="Date" />
                                                                                    <asp:TemplateField HeaderText='Actions <span style="margin-left:10px; padding-top:10px;"><a href="#"><img id="help1" src="../../images/Dashboard/new.png" /></a></span>'>
                                                                                        <ItemTemplate>
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                <tr>
                                                                                                    <td align="center">
                                                                                                        <asp:LinkButton runat="server" ID="lnkDelete1" Font-Bold="true" OnClick="lnkDelete1_OnClick"
                                                                                                            CommandArgument='<%# Bind("InvitationID") %>' OnClientClick="return confirm('Are you sure you want to delete?');"><img src="../../images/Dashboard/managedelete.png"/><br />Delete </asp:LinkButton>
                                                                                                    </td>
                                                                                                    <td align="center">
                                                                                                        <img src="../../images/Dashboard/disable-icon.gif" /><br />
                                                                                                        <asp:LinkButton runat="server" ID="lnkDisable1" Font-Bold="true" OnClick="lnkDisable1_OnClick"
                                                                                                            CommandArgument='<%# Bind("InvitationID") %>' OnClientClick="return Enable_Disable(this);">Disable </asp:LinkButton>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="175px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    No device found
                                                                                </EmptyDataTemplate>
                                                                                <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
            <script type="text/javascript">
                function Enable_Disable(control) {
                    return confirm("Are you sure you want to " + control.innerText.toLowerCase() + "?");
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
