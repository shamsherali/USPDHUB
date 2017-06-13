<%@ Page Language="C#" MasterPageFile="~/Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeBehind="ManageAssociates.aspx.cs" Inherits="Business_MyAccount_ManageAssociates" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <style type="text/css">
        .navy20
        {
            color: #2F348F;
            font-size: 15px;
            font-weight: bold;
            font-family: Arial;
            padding: 10px 0px 5px 0px;
            width: 100px;
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
            padding-left: 5px;
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
            margin-top: 15px;
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
            background: url(../../images/Dashboard/CreateModule.png) no-repeat;
            width: 134px;
            height: 35px;
            color: #fff;
            font-size: 16px;
            text-align: center;
            border: 0px;
            font-weight: bold;
            cursor: hand;
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
        .operatelogins
        {
            color: #FFF;
            font-size: 11px;
            text-align: center;
            margin: 5px 0px 0px;
            padding: 5px 14px;
            border: 1px solid #999;
            border-radius: 2px;
            background: #003752 none repeat scroll 0% 0%;
            border-color: #003752;
            float: none;
            display: inline-block;
            text-decoration: none;
            transition: all 0.2s ease 0s;
            font-size: 13px;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function ValidateFlyer(ControlId) {
            var id = ControlId.id;
            var TargetBaseControl = document.getElementById("<%=hdnCommandArg.ClientID%>").value;
            if (id == "ctl00_ctl00_cphUser_cphUser_lnkPermissions") {
                if (TargetBaseControl == '' || TargetBaseControl == null) {
                    alert('Please select an Associate.');
                    return false;
                }
                // *** Commentted for JIRA 321 *** // 
                //               else if (TargetBaseControl == document.getElementById("<%=hdnUserID.ClientID%>").value) {
                //                    alert('You have already full permissions.');
                //                    return false;
                //                }
            }
            else if (id == "ctl00_ctl00_cphUser_cphUser_lnkEdit") {
                if (TargetBaseControl == '' || TargetBaseControl == null) {
                    alert('Please select an Associate.');
                    return false;
                }
            }
            else {
                if (id == "ctl00_ctl00_cphUser_cphUser_lnkdelete") {
                    if (TargetBaseControl == '' || TargetBaseControl == null) {
                        alert('Please select an Associate to delete.');
                        return false;
                    }
                    else {
                        if (TargetBaseControl == document.getElementById("<%=hdnUserID.ClientID%>").value) {
                            alert('Your are unable to delete your data.');
                            return false;
                        }
                        else {
                            return confirm('Are you sure you want to delete the selected Associate?');
                        }
                    }
                }
            }
        }
        function RadioCheck(rb, UpdateName, UpdateID) {
            RadioCheched = "True";
            var gv = document.getElementById("<%=GrdbusinessUpdates.ClientID%>");
            var rbs = gv.getElementsByTagName("input");
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <tbody>
                                <tr>
                                    <td>
                                        <h1>
                                            <div style="float: left;">
                                                Manage Associates
                                            </div>
                                        </h1>
                                    </td>
                                    <td style="padding-right: 70px">
                                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                    <td align="center" class="navy20" valign="top">
                                        </a>
                                        <div id="boxes">
                                            <div id="dialog" class="window">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="right">
                                                            <span class="cursor"><a class="navigate">
                                                                <img src="../../images/popup_close.gif" border="0" />
                                                            </a></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="padding-top: 5px;" valign="top">
                                                            <div id="DIDIFrm">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
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
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tabber">
                            <colgroup>
                                <col width="310px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td colspan="2" class="content">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td class="leftmenu">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <table class="datagrid nomargin-bottom" cellspacing="0" cellpadding="0" width="100%"
                                                                border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="GrdbusinessUpdates" runat="server" PageSize="5" AllowPaging="True"
                                                                                OnPageIndexChanging="GrdbusinessUpdates_PageIndexChanging" ForeColor="Black"
                                                                                EmptyDataText="" OnRowDataBound="GrdbusinessUpdates_RowDataBound" DataKeyNames="User_ID"
                                                                                GridLines="None" AutoGenerateColumns="False" CssClass="datagrid2" Width="100%"
                                                                                OnSorting="GrdbusinessUpdates_Sorting" AllowSorting="True">
                                                                                <EmptyDataRowStyle ForeColor="Red"></EmptyDataRowStyle>
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Select">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblid" runat="server" Text='<%# Bind("User_ID") %>' Visible="False"></asp:Label>
                                                                                            <asp:RadioButton ID="rbUpdate" runat="server" AutoPostBack="true" OnCheckedChanged="rbUpdate_CheckedChanged"
                                                                                                onclick='<%# string.Format("javascript:RadioCheck(this, \"{0}\",\"{1}\")", Eval("Firstname"), Eval("User_ID")) %>' />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="20px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="First Name" SortExpression="Firstname">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblFirstname" runat="server" Text='<%# Bind("Firstname") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="200px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Last Name" SortExpression="Lastname">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblLastname" runat="server" Text='<%# Bind("Lastname") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="200px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="User Name" SortExpression="Username">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="200px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <%--<asp:TemplateField HeaderText="Groups">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGroup" runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="200px"></ItemStyle>
                                                                                    </asp:TemplateField>--%>
                                                                                    <asp:TemplateField HeaderText="Receive Feedback" SortExpression="IsTipsAdmin">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTipsAdmin" runat="server" Text='<%# Bind("IsTipsAdmin") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="200px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Receive Tips" SortExpression="IsReceiveTips">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblReceiveTipsAdmin" runat="server" Text='<%# Bind("IsReceiveTips") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="200px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <%--<asp:TemplateField HeaderText="Status" SortExpression="Active_flag">
                                                                                        <ItemTemplate>
                                                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td style="border: 0px;" valign="top" nowrap="nowrap">
                                                                                                        <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Active_flag") %>' Visible="False"></asp:Label>
                                                                                                        <asp:Label ID="Status" runat="server" Visible="False"></asp:Label>
                                                                                                        <asp:Label ID="lblPwd" runat="server" Text='<%# Bind("Password") %>' Visible="False"></asp:Label>
                                                                                                        <asp:Label ID="lblSuperAdmin" runat="server" Text='<%# Bind("SuperAdmin_ID") %>'
                                                                                                            Visible="False"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="50px"></ItemStyle>
                                                                                    </asp:TemplateField>--%>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    No Associates found
                                                                                </EmptyDataTemplate>
                                                                                <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                                <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <asp:HiddenField ID="hdnShowButtons" runat="server" />
                                                            <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnCommandArg" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnUserID" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="right" class="rightmenu">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCreate" runat="server" Visible="false" CausesValidation="false"
                                                                OnClick="lnkCreate_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -370px;">
                                                            </span>Create Associate</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%if (hdnShowButtons.Value == "1")
                                                  { %>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" OnClick="lnkEdit_Click"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -32px;">
                                                            </span>Edit</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkPermissions" runat="server" CausesValidation="false" OnClick="lnkPermissions_Click"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -32px;">
                                                            </span>Permissions</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkdelete" runat="server" CausesValidation="false" OnClick="lnkdelete_Click"
                                                                OnClientClick="return ValidateFlyer(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -108px;">
                                                            </span>Delete</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%} %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA;
                                                padding: 7px 0px 7px 0px;">
                                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" />&nbsp;&nbsp;<asp:Button
                                                    ID="btnCancel" runat="server" Text="Dashboard" OnClick="btnCancel_Click" CausesValidation="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <tr>
                                <td>
                                    <h1>
                                        Manage Associates</h1>
                                </td>
                            </tr>
                            <tr>
                                <td style="color: red;" align="center">
                                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnTemp" runat="server" Text="Dashboard" OnClick="btnCancel_Click"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
