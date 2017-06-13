<%@ Page Title="" Language="C#" MasterPageFile="~/Business/MyAccount/PublicCallIndexMaster.master"
    AutoEventWireup="true" CodeBehind="ManagePublicCallIndexAddOns.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManagePublicCallIndexAddOns" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/UcPageSize.ascx" TagName="PageSize" TagPrefix="UcPageSize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser1" runat="server">
    <style type="text/css">
        .GridDock
        {
            overflow-x: auto;
            overflow-y: hidden;
            padding: 0 0 10px 0;
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
            width: 171px;
            float: left;
        }
        #tabber .content .rightmenu .rightLinks
        {
            width: 171px;
            padding-bottom: 1px;
        }
        #tabber .content .rightmenu .rightLinks a
        {
            display: block;
            font-size: 13px;
            color: #003c7f;
            width: 171px;
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
        
        .imgStyle img
        {
            border-radius: 30px;
            width: 60px;
        }
        .callivisble
        {
            border: 1px solid #CCc;
            border-radius: 10px;
            padding: 2px 0px;
            font-size: 13px;
            background-color: #E5E4D7;
        }
        .callivisbleon label
        {
            display: block;
            float: right;
            color: #046b18;
            cursor: pointer;
            padding: 0px 7px;
            font-weight: bold;
        }
        .callivisbleoff label
        {
            display: block;
            float: right;
            color: #FF0000;
            cursor: pointer;
            padding: 0px 6px;
            font-weight: bold;
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
    <script type="text/javascript">
        function SelectAll(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdCallIndex.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdCallIndex.ClientID %>');
            var TargetChildControl = "chkItem";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[iCount].checked = CheckBox.checked;
            }
        }

        function SelectDeSelectHeader(CheckBox) {
            TotalChkBx = parseInt('<%= this.GrdCallIndex.Rows.Count %>');
            var TargetBaseControl = document.getElementById('<%= this.GrdCallIndex.ClientID %>');
            var TargetChildControl = "chkItem";
            var TargetHeaderControl = "chkSelectAll";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            var flag = false;
            var HeaderCheckBox;
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetHeaderControl, 0) >= 0)
                    HeaderCheckBox = Inputs[iCount];
                if (Inputs[iCount] != CheckBox && Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[iCount].id.indexOf(TargetHeaderControl, 0) == -1) {
                    if (CheckBox.checked) {
                        if (!Inputs[iCount].checked) {
                            flag = false;
                            HeaderCheckBox.checked = false;
                            return;
                        }
                        else
                            flag = true;
                    }
                    else if (!CheckBox.checked)
                        HeaderCheckBox.checked = false;
                }
            }
            if (flag)
                HeaderCheckBox.checked = CheckBox.checked
        }
        function ValidateNotification(ControlId) {
            var resultItem = ValidateItem(ControlId);
            if (resultItem) {
                if (document.getElementById('<%= hdnIsPusblished.ClientID %>').value == "true")
                    return true;
                else
                    alert('You cannot push a private item.');
            }
            return false;
        }
        function ValidateItem(ControlId) {
            var id = ControlId;
            if (document.getElementById("<%=hdnarchive.ClientID%>").value != "Archive") {
                var selectedcount = 0;
                var rowIndex = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdCallIndex.ClientID %>');
                var TargetChildControl = "chkCurrentTabCustomID";
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                    if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                        if (Inputs[iCount].checked) {
                            rowIndex = iCount + 1;
                            selectedcount += 1;
                            if (selectedcount > 1)
                                break;
                        }
                    }
                }

                if (selectedcount == 0) {
                    alert('Please select a Title.');
                    return false;
                }
                else {
                    if (id.indexOf("lnkPreview") != -1 && selectedcount > 1) {
                        alert("Multiple selections not allowed.");
                        return false;
                    }
                    else if (id.indexOf("lnkEdit") != -1 && selectedcount > 1) {
                        alert("Multiple selections not allowed..");
                        return false;
                    } else if (id.indexOf("lnkNotification") != -1 && selectedcount > 1) {
                        alert("Multiple selections not allowed.");
                        return false;
                    } else if (id.indexOf("lnkCopy") != -1 && selectedcount > 1) {
                        alert("Multiple selections not allowed.");
                        return false;
                    } else if (id.indexOf("lnkRename") != -1 && selectedcount > 1) {
                        alert("Multiple selections not allowed.");
                        return false;
                    } else if (id.indexOf("lnkSend") != -1 && selectedcount > 1) {
                        alert("Multiple selections not allowed.");
                        return false;
                    } else if (id.indexOf("lnkPrint") != -1 && selectedcount > 1) {
                        alert("Multiple selections not allowed.");
                        return false;
                    } else if (id.indexOf("lnkPrint") != -1 && selectedcount > 1) {
                        alert("Multiple selections not allowed.");
                        return false;
                    } else if (id.indexOf("lnkCrisisExport") != -1 && selectedcount > 1) {
                        alert("Multiple selections not allowed.");
                        return false;
                    }
                    else if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete the selected content?');
                    else if (id.indexOf("lnkArchive") != -1)
                        return confirm('Are you sure you want to archive the selected content?');
                    return true;
                }
            }
            else {
                var selectedcount = 0;
                var TargetBaseControl = document.getElementById('<%= this.GrdCallIndex.ClientID %>');
                var TargetChildControl = "chkItem";
                var Inputs = TargetBaseControl.getElementsByTagName("input");
                for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                    if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                        if (Inputs[iCount].checked) {
                            selectedcount += 1;
                            if (selectedcount > 1)
                                break;
                        }
                    }
                }
                if (selectedcount == 0) {
                    alert('Please select a Title.');
                    return false;
                }
                else if (selectedcount > 1) {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete the selected content?');
                    else if (id.indexOf("lnkChangeCurrent") != -1)
                        return confirm('Are you sure you want to reinstate this title(s)?');
                    else {
                        alert('Please select only one Title.');
                        return false;
                    }
                }
                else {
                    if (id.indexOf("lnkdelete") != -1)
                        return confirm('Are you sure you want to delete this content?');
                    else {
                        if (document.getElementById("<%=hdnCommandArg.ClientID%>").value == '') {
                            alert('Please select only one content.');
                            return false;
                        }
                        else {
                            if (id.indexOf("lnkChangeCurrent") != -1)
                                return confirm('Are you sure you want to reinstate this content?');
                            else
                                return true;
                        }
                    }
                }
            }
        }

        function TwitterShare(url) {
            if (ValidateCustomModuleMutipleSelection('Twitter'))
                window.open(url, '_blank');
        }

        function openEmailwindow(url) {
            if (ValidateCustomModuleMutipleSelection('Email'))
                window.open(url, '', "width=700,height=650,scrollbars=no,toolbars=yes,status=yes,resizable=yes").focus();
        }
        function RadioCheck(rb, NewsName, NewsID) {
            var gv = document.getElementById("<%=GrdCallIndex.ClientID%>");
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
        function GetConfirm(text, controlID) {
            if (ValidateItem(controlID)) {
                if (text.toLowerCase() == 'publish')
                    return confirm('Are you sure you want to ' + text + ' the selected content?');
                else
                    return confirm('Are you sure you want to make the selected content ' + text + '?');
            }
            else {
                return false;
            }
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <tbody>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblSCVersionMSG" runat="server" CssClass="app-update" Font-Size="Medium"
                                            Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: green" align="center">
                                        <asp:Label ID="lblmess" runat="server"></asp:Label>
                                        <asp:Label ID="lbleditn" runat="server"></asp:Label>
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <p style="margin-right:10px;float:right;">Page Size  <UcPageSize:PageSize ID="PageSizes" runat="server" /></p>
                        <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
                            <tr>
                                <td class="content">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td valign="top">
                                                <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td valign="top">
                                                                <div class="GridDock" id="dvGridWidth" style="border: 1px solid #428ad7;">
                                                                    <asp:GridView ID="GrdCallIndex" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        CssClass="datagrid2" DataKeyNames="CustomID,ExpiryDate" OnRowDataBound="GrdCallIndex_RowDataBound"
                                                                        OnPageIndexChanging="GrdCallIndex_PageIndexChanging" PageSize="5"
                                                                        AllowPaging="true"
                                                                        GridLines="None" OnSorting="GrdCallIndex_Sorting">
                                                                        <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Image">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblthumb" runat="server" CssClass="imgStyle" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="align-center" Width="100px" />
                                                                                <FooterStyle CssClass="align-center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Name" SortExpression="Title">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkTitle" runat="server" CausesValidation="false" Text='<%# Bind("Title") %>'
                                                                                        CommandArgument='<%# Bind("CustomID") %>' OnClick="lnkTitle_Click"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="150px" VerticalAlign="Top"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="MobileNumber" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Phone Number"
                                                                                HtmlEncode="False" SortExpression="MobileNumber">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                <ItemStyle VerticalAlign="Top" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="CategoryName" HeaderText="Category">
                                                                                <ItemStyle VerticalAlign="Top" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Description" HeaderText="Description">
                                                                                <HeaderStyle Width="190px"></HeaderStyle>
                                                                                <ItemStyle VerticalAlign="Top" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Display<br />on App">
                                                                                <ItemTemplate>
                                                                                    <div class="callivisble">
                                                                                        <asp:CheckBox ID="chkVisible" runat="server" Checked='<%#Bind("IsVisible") %>' Text='<%#Bind("Display") %>'
                                                                                            AutoPostBack="true" CssClass='<%# Eval("IsVisible").ToString().ToLower()=="true"?"callivisbleon":"callivisbleoff" %>'
                                                                                            OnCheckedChanged="chkVisible_CheckedChanged" onchange='<%# string.Format("javascript:return CheckVisible(\"{0}\",\"{1}\")", Eval("ConfirmAlert"), Eval("CustomID"))%>' /></div>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="linkEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("CustomID") %>'
                                                                                        OnClick="linkEdit_Click">
                                                                                        <img src="../../images/Dashboard/icon_modify.gif" style="padding-left:3px;" /><br />Edit
                                                                                    </asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="34px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="linkDelete" runat="server" CausesValidation="false" OnClick="linkDelete_Click"
                                                                                        OnClientClick="return confirm('Are you sure you want to delete?')" CommandArgument='<%# Bind("CustomID") %>'>
                                                                                        <img src="../../images/icon_delete.gif" /> Delete
                                                                                    </asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            <%if (hdnarchive.Value == "Archive")
                                                                              { %>
                                                                            There is no archived content.
                                                                            <%}
                                                                              else
                                                                              {%>
                                                                            Start building
                                                                            <%=hdnAddOnName.Value %>
                                                                            <%} %>
                                                                        </EmptyDataTemplate>
                                                                        <HeaderStyle CssClass="title3"></HeaderStyle>
                                                                        <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                        <PagerStyle CssClass="paginationClass" />
                                                                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First"
                                                                                        LastPageText="Last" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="hdnCommandArg" runat="server" />
                                                <asp:HiddenField ID="hdnShowButtons" runat="server" />
                                                <asp:HiddenField ID="hdnflyerthumb" runat="server" />
                                                <asp:HiddenField ID="hdnarchive" runat="server" />
                                                <asp:HiddenField ID="hdnPrintNewsID" runat="server" />
                                                <asp:HiddenField ID="hdnRowIndex" runat="server" />
                                                <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                                <asp:HiddenField ID="hdnLinkShareFB" runat="server" />
                                                <asp:HiddenField ID="hdnMessageDes" runat="server" />
                                                <asp:HiddenField ID="hdnFacebookAppId" runat="server" />
                                                <asp:HiddenField ID="hdnBulletinTitle" runat="server" />
                                                <asp:HiddenField ID="hdnAddOnName" runat="server" />
                                                <asp:HiddenField ID="hdnFacebook" runat="server" />
                                                <asp:HiddenField ID="hdnTwitter" runat="server" />
                                                <asp:HiddenField ID="hdnIsPrivateModule" runat="server" />
                                                <asp:HiddenField ID="hdnIsPusblished" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA; padding: 7px 0px 7px 0px;">
                                    <asp:Button ID="btnCancel" runat="server" Text="Dashboard" OnClick="btnCancel_Click"
                                        CausesValidation="false" Style="padding: 5px;" />
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnURLPath" runat="server" />
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblPreview" runat="server" visiable="false"></asp:Label>
                        <cc1:ModalPopupExtender ID="MPEPreview" runat="server" TargetControlID="lblPreview"
                            PopupControlID="pnlPreview" BackgroundCssClass="modal" CancelControlID="imgPreviewClose">
                        </cc1:ModalPopupExtender>
                        <asp:Panel Style="display: none" ID="pnlPreview" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%" class="popuptable" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" style="padding: 5px 10px 0px 10px;">
                                            <asp:ImageButton ID="imgPreviewClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                CausesValidation="false"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; padding-top: 10px"
                                            align="left">
                                            App Module Display Name:
                                            <asp:Label ID="lblNamme" runat="server" Style="color: green;"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            <div style="overflow-y: auto; height: 500px; position: relative; width: auto; padding-right: 30px;">
                                                <asp:Label ID="lblPreviewHTML" runat="server"></asp:Label></div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function CheckVisible(message, argid) {
            document.getElementById('<%=hdnCommandArg.ClientID %>').value = '';
            document.getElementById('<%=hdnCommandArg.ClientID %>').value = argid;
            if (confirm("Are you sure you want to turn the button " + message.toLowerCase() + "?"))
                return true;
            else {
                document.getElementById('<%=hdnCommandArg.ClientID %>').value = '';
                return false;
            }

        }
    </script>
</asp:Content>
