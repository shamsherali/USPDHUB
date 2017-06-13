<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="temp_QRConnectScan.aspx.cs" Inherits="USPDHUB.Business.MyAccount.temp_QRConnectScan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
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
        .paginationClass span
        {
            font-weight: bold;
            font-size: 14px;
            color: White;
            border: 1px solid #f15a29;
            padding: 0px 5px;
            background-color: #FFCC00;
        }
    </style>
    <style>
        .paginationClass span
        {
            font-weight: bold;
            font-size: 14px;
            color: White;
            border: 1px solid #f15a29;
            padding: 0px 5px;
            background-color: #FFCC00;
        }
    </style>
    <asp:UpdatePanel runat="server" ID="Updatepanel1">
        <ContentTemplate>
            <div>
                <p style="font-size: 18px; font-weight: bold; color: #EC2027; line-height: 35px;">
                    QR Connect History
                </p>
                <asp:GridView ID="grdQRConnectMsg" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    CssClass="datagrid2" PageSize="10" Width="100%" OnPageIndexChanging="grdQRConnectMsg_OnPageIndexChanging">
                    <EmptyDataTemplate>
                        No records found
                    </EmptyDataTemplate>
                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                    <HeaderStyle CssClass="title3"></HeaderStyle>
                    <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                    <PagerStyle CssClass="paginationClass" />
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First"
                        LastPageText="Last" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="HistoryID">
                            <HeaderStyle Width="15px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Title" DataField="Title">
                            <HeaderStyle Width="100px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Latitude" DataField="Latitude">
                            <HeaderStyle Width="60px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Longitude" DataField="Longitude">
                            <HeaderStyle Width="60px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Notes" DataField="Notes" ItemStyle-Wrap="true">
                            <HeaderStyle Width="200px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Sent Time" DataField="SentDate">
                            <HeaderStyle Width="100px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Device Type" DataField="DeviceType">
                        <HeaderStyle Width="40px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
