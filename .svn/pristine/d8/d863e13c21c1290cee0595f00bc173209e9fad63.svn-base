<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" ValidateRequest="false"
    AutoEventWireup="true" CodeBehind="ManageSubAppsInvitations.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageSubAppsInvitations" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <style>
        .AcceptedStatusClass
        {
            font-weight: bold;
            color: Green;
        }
        
        .DeclinedStatusClass
        {
            font-weight: bold;
            color: Red;
        }
        
        .PendingStatusClass
        {
            font-weight: bold;
            color: Red;
        }
    </style>
    <style type="text/css">
        .lblfont
        {
            font-size: 11px;
        }
        .headerbgcolor
        {
            background-color: #000080;
        }
        .multiline-txtbox
        {
            display: block;
            width: 90%;
            height: 80px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857;
            color: #555;
            vertical-align: middle;
            background-color: #FFF;
            background-image: none;
            border: 1px solid #CCC;
            border-radius: 4px;
            box-shadow: 0px 1px 1px rgba(0, 0, 0, 0.075) inset;
            transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s;
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
            height: 1.5em;
            cursor: move;
        }
        html > body #sortable li
        {
            height: 1.5em;
            line-height: 1.2em;
        }
    </style>
    <style type="text/css">
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
            margin-top: 10px;
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
            width: 740px;
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
            width: 167px;
            padding-bottom: 1px;
        }
        #tabber .content .rightmenu .rightLinks a
        {
            display: block;
            font-size: 13px;
            color: #003c7f;
            width: 167px;
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
                                        <h1>
                                            <asp:Label ID="lblTitle" runat="server" Text="Manage Affiliate Invitations "></asp:Label>
                                        </h1>
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
                                    <td style="color: green" align="center">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Panel ID="pnlSearch" runat="server">
                                            <table width="350px">
                                                <tr>
                                                    <td align="right">
                                                     <b>Search:</b>   <asp:TextBox ID="txtSearch" runat="server" MaxLength="100" Height="18px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" CausesValidation="false" Text="Go" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnClear" runat="server" OnClick="btnbtnClear_Click" CausesValidation="false" Text="Clear" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
                            <colgroup>
                                <col width="310px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td colspan="2" class="content">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td valign="top">
                                                <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:GridView ID="grdSubApps" runat="server" ForeColor="Black"
                                                                    EmptyDataText="" DataKeyNames="Profile_ID" GridLines="None" AutoGenerateColumns="False"
                                                                    OnRowDataBound="grdSubApps_RowDataBound" CssClass="datagrid2" Width="100%" AllowSorting="True"
                                                                    PageSize="5" AllowPaging="True" OnPageIndexChanging="grdSubApps_PageIndexChanging"  OnSorting="grdSubApps_Sorting">
                                                                    <EmptyDataRowStyle ForeColor="Red"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Name" SortExpression="FullAddress">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblProfile_name" runat="server" Text='<%# Bind("FullAddress") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date" SortExpression="Created_Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Created_Date") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="100px"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Email ID" SortExpression="EmailID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNotes" runat="server" Text='<%# Bind("Email_Address") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No sub-app(s) found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                    <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <asp:HiddenField ID="hdnCommandArg" runat="server" />
                                                <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA;
                                    padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnCancel" runat="server" Text="Dashboard" PostBackUrl="~/Business/MyAccount/Default.aspx"
                                        CausesValidation="false" />
                                    <asp:Button ID="btnSend" runat="server" Text="Send Invitation" PostBackUrl="~/Business/MyAccount/SendSubAppInvitation.aspx"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnURLPath" runat="server" />
            </td> </tr> </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
