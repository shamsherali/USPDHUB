<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AdditionalBrandedRequestsPopUp.aspx.cs"
    Inherits="USPDHUB.Admin.AdditionalBrandedRequestsPopUp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script type="text/javascript">
        function Redirect() {
            window.top.location = "AdditionalBrandedRequests.aspx";
        }

        function RedirectWithEdit(reqid) {
            window.top.location = "AdditionalBrandedRequests.aspx?BRID=" + reqid;
        }
    </script>
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
    <link href="../CSS/wowzzy_newcss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
    <asp:ScriptManager runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <table cellspacing="0" cellpadding="0" width="687" style="padding: 17px;" border="0">
        <tbody>
            <tr>
                <td align="center">
                    <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
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
                                    <asp:Label runat="server" ID="AppName" Font-Size="16px" Style="color: Green; font-weight: bold;"></asp:Label>
                                    <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
                                        font-family: Arial; size: 2">
                                        <asp:Label ID="lblviewsentnewlettername" runat="server"></asp:Label>
                                    </span>
                                </td>
                                <td align="right">
                                    <a id="NewRequest" onclick="Redirect()" href="#" style="font-size: 14px; color: #bc2e07;
                                        font-weight: bold;">Add New Request</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdDetails" runat="server" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                        PageSize="3" AllowPaging="True" OnPageIndexChanging="grdDetails_PageIndexChanging"
                        OnRowDataBound="grdDetails_OnRowDataBound">
                        <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Request Details">
                                <ItemTemplate>
                                    </br>
                                    <asp:Label ID="lblreqDetails" runat="server" Text='<%#Eval("RequestDetails")%>'></asp:Label>
                                    <asp:Label ID="lblAppIcon" runat="server" Text='<%#Eval("App_Icon")%>' Style="display: none;"></asp:Label>
                                    <asp:Label ID="lblBackgroundIcon" runat="server" Text='<%#Eval("Background_Icon")%>' Style="display: none;"></asp:Label>
                                    <asp:Label ID="lblPID" runat="server" Text='<%#Eval("ProfileID")%>' Style="display: none;"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Created_Date")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status_Name")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <a href='#' onclick="return RedirectWithEdit(<%#Eval("BrandedApp_RequestID") %>);">
                                        <img alt="Edit" src="../../Images/edit.png" /></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No contacts found
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="title1"></HeaderStyle>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
