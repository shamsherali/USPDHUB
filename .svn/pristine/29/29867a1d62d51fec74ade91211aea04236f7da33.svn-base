<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendPSCInvitation.aspx.cs"
    ValidateRequest="false" Inherits="USPDHUB.Business.MyAccount.SendPSCInvitation"
    MasterPageFile="~/Business/MyAccount/PrivateSmartConnect.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphUser1" runat="server">
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/Scripts/jquery.lightbox-0.5.js")%>"></script>
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveClientUrl("~/css/jquery.lightbox-0.5.css")%>"
        media="screen" />
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
        #boxes .window
        {
            border: solid 2px #FFCC00;
            position: absolute;
            left: 0;
            top: 0;
            width: 490px;
            height: 200px;
            display: none;
            z-index: 9999;
        }
        
        #boxes #dialog
        {
            width: 500px;
            height: 405px;
            padding: 10px;
            background-color: #FFFFFF;
            margin-top: 12%;
            margin-left: 36%;
        }
    </style>
    <style>
        .GridDock
        {
            overflow-x: auto;
            overflow-y: hidden;
            padding: 0 0 10px 0;
            min-width: 950px;
        }
    </style>
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
                                    <td>
                                        <asp:HiddenField ID="hdnAddOnName" runat="server" />
                                    </td>
                                    <td style="float: left;">
                                    </td>
                                </tr>
                                <tr>
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
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td align="left" style="color: #0c3879; padding-left: 4px;">
                                        <b><font size="2">Contacts Selected To Receive Invitation To Display Private QR Connect</font></b>
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
                                                    <asp:HiddenField ID="hdnsortdire" runat="server" />
                                                    <asp:HiddenField ID="hdnsortcount" runat="server" />
                                                    <div id="gallery" style="height: 500px; overflow-y: auto; border: solid 1px #4684C5;">
                                                        <table class="popuptablecheckbox" cellspacing="0" cellpadding="0" width="100%" style="display: none">
                                                            <tr>
                                                                <td style="padding-left: 4px;">
                                                                    *Note: Please select 1 or more contact(s) within your chosen groups.
                                                                </td>
                                                            </tr>
                                                            <tr style="display: none;">
                                                                <td style="padding-left: 4px;">
                                                                    <asp:CheckBox ID="chkall" runat="server" AutoPostBack="True" OnCheckedChanged="chkall_CheckedChanged"
                                                                        Text="All Groups"></asp:CheckBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBoxList ID="drpcheck" runat="server" AutoPostBack="True" RepeatColumns="5"
                                                                        RepeatDirection="Horizontal" OnSelectedIndexChanged="drpcheck_SelectedIndexChanged">
                                                                    </asp:CheckBoxList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table cellspacing="0" cellpadding="0" width="100%">
                                                            <tr>
                                                                <td style="padding-left: 4px;">
                                                                    *Note: Please select 1 or more contacts.
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:GridView ID="grdusercontacts" AllowSorting="true" runat="server" CssClass="datagrid2"
                                                            Width="100%" OnRowDataBound="grdusercontacts_RowDataBound" OnPageIndexChanging="grdusercontacts_PageIndexChanging"
                                                            AllowPaging="True" DataKeyNames="ContactID,checkvalue,RowRank" AutoGenerateColumns="False"
                                                            PageSize="10" OnSorting="grdusercontacts_Sorting">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/emailarrow.gif")%>" width="17px"
                                                                            height="8" border="0" /><asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="True"
                                                                                OnCheckedChanged="chkSelectAll_CheckedChanged"></asp:CheckBox>Select All
                                                                    </HeaderTemplate>
                                                                    <ItemStyle Width="85px" CssClass="align-center"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Convert.ToBoolean(Convert.ToInt32(Eval("checkvalue").ToString())) %>'
                                                                            AutoPostBack="True" OnCheckedChanged="chkContact_CheckedChanged" ToolTip='<%# Eval("ContactID") %>'>
                                                                        </asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="False">
                                                                    <ItemStyle Width="60px"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcontactid" runat="server" Text='<%# Bind("ContactID") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("RowRank") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFN" runat="server" Text='<%# Bind("FirstName") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblLN" runat="server" Text='<%# Bind("LastName") %>' Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Email" SortExpression="email">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblemail" runat="server" Text='<%# Bind("EmailID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mobile" SortExpression="Mobile">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("MobileNumber") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcheckvalue" runat="server" Text='<%# Convert.ToBoolean(Convert.ToInt32(Eval("checkvalue").ToString())) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                No contacts found
                                                            </EmptyDataTemplate>
                                                            <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                            <HeaderStyle CssClass="ContactTitle" />
                                                            <PagerStyle CssClass="pagination1" />
                                                        </asp:GridView>
                                                        <div style="margin: 20px auto; width: 200px;">
                                                            <asp:LinkButton runat="server" ID="btnSend" Text="Send Invitation" OnClick="btnSend_OnClick"
                                                                CssClass="btn" />
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" OnClick="btnBack_OnClick"
                                        Width="50px" Height="24px" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnManageInvitations" runat="server" Text="Manage Invitations" CausesValidation="false"
                                        OnClick="btnManageInvitations_OnClick" Width="150px" Height="24px" />&nbsp;&nbsp;
                                    <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" CausesValidation="false"
                                        OnClick="btnDashboard_OnClick" Width="87px" Height="24px" />
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnURLPath" runat="server" />
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
