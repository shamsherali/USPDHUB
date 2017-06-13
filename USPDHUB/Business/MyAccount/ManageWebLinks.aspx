<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Dashboard.master"
    CodeBehind="ManageWebLinks.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageWebLinks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
    <link href="../../css/Jquery-order-ui.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        var order = '';
        function ShowOrderScript() {
            $('#sortable').sortable({
                placeholder: 'ui-state-highlight',
                update: OnSortableUpdate
            });
            $('#sortable').disableSelection();


            function OnSortableUpdate(event, ui) {
                order = $('#sortable').sortable('toArray').join(',').replace(/id_/gi, '');
            }
        }
        function UpdateOder() {
            var typeval = PageMethods.UpdateItemsOrder(order, OnSuccess, OnFailure);
            return false;
        }
        function OnSuccess(result) {
            if (result == "success") {
                document.getElementById("<%=lblSuccess.ClientID%>").innerHTML = "<font color=green face=arial size=2>The order has been updated successfully.<font>";
                $find('<%=ModalPopupWebLinkOrderNo.ClientID %>').hide();
                document.getElementById("<%=btnUpdateImgOrderNumber1.ClientID %>").click();
            }
            else
                OnFailure(result);
        }
        function OnFailure(result) {
            $find('<%=ModalPopupWebLinkOrderNo.ClientID %>').show();
            alert("Failure occurs while updating the links order.");
        }

        function checkweburl() {
            var url = document.getElementById('<%=txtlinkUrl.ClientID %>').value;

            if (url.length > 0) {

                if ((url.charAt(url.length - 1) == '/')) {
                    document.getElementById('<%=txtlinkUrl.ClientID %>').value = url.substring(0, url.length - 1);
                }

            }
        }
        function CountMaxLength(id, text) {
            var maxlength = 30;

            if (id.value.length > maxlength) {
                id.value = id.value.substring(0, maxlength);
                alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
            }
            document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;
        }
    </script>
    <style type="text/css">
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
        .ActionButtons
        {
            color: #000;
            font-size: 13px;
            background: #ebebeb;
            padding: 4px 8px 4px 8px;
            text-decoration: none;
            border: solid #e6e6e6 2px;
        }
        #manage h1
        {
            font-size: 18px;
            color: #EC2027;
            height: 35px;
            line-height: 35px;
            padding: 0px 0px 0px 20px;
        }
    </style>
    <div id="webmangement_wrapper">
        <div id="webmangement_rightcol">
            <div id="divManageWebLinksPage">
                <%--<div class="webmangement_rightcol_heading rightcol_Position" style="height: 75px;">
                    <span style="color: Black; font-size: 14px; margin: 0px; padding: 0px; position: absolute;
                        font-weight: normal; margin-left: 200px; margin-top: 0px;">
                        <br />
                    </span>
                </div>--%>
                <div class="clear5">
                </div>
                <div class="clear5">
                </div>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <!---->
                            <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                                <colgroup>
                                    <col width="75%" />
                                    <col width="*" />
                                </colgroup>
                                <tbody>
                                    <tr>
                                        <td>
                                            <h1>
                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                            </h1>
                                        </td>
                                        <td style="float: left;">
                                            <span style="color: Black; font-size: 14px; margin: 0px; padding: 0px; position: absolute;
                                                margin-top: 8px;">
                                                <asp:Label runat="server" ID="lblOn" Visible="false">Displayed on App: <font class="showonapp">On</font></asp:Label>
                                                <asp:Label runat="server" ID="lblOff">Displayed on App: <font class="showoffapp">Off</font></asp:Label>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right; padding-right: 25%; color: Red;">
                                            <asp:Label ID="lblSuccess" runat="server" Style="font-weight: bold; font-size: 16px;"></asp:Label>
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td style="display: none;">
                                            <span style="color: Black; font-size: 14px; margin: 0px; font-weight: bold;">App Display
                                                Order: </span>
                                            <asp:RadioButtonList ID="RBAppOrder" runat="server" RepeatDirection="Horizontal"
                                                Style="color: Black; font-size: 14px; padding-left: -8px; margin-left: -8px;
                                                font-weight: normal;" OnSelectedIndexChanged="RBAppOrder_OnSelectedIndexChanged"
                                                AutoPostBack="true">
                                                <asp:ListItem Text="By Date" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="By Custom Order" Value="2" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <!---->
                            <br />
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" style="padding-right: 30px;">
                                        <asp:Button ID="btnChangeOrder" runat="server" Text="Change Order" CausesValidation="false"
                                            CssClass="ActionButtons" OnClick="btnChangeOrder_click" />
                                        <asp:Button ID="Button1" runat="server" Text="Web Link Categories" CausesValidation="false"
                                            CssClass="ActionButtons" OnClick="btnWeblinkCategory_Click" />
                                        <asp:Button ID="btnAddNew" runat="server" Text="Add Web Link" CausesValidation="false"
                                            CssClass="ActionButtons" OnClick="btnAddNew_Click" />
                                        <asp:HiddenField runat="server" ID="hdnPermissionType" />
                                        <asp:HiddenField runat="server" ID="hdnWebLinksPermission" />
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="content">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="valign-top">
                                            <tr>
                                                <td valign="top" align="center" style="padding: 20px;">
                                                    <asp:GridView ID="WebLinkGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="LinkID"
                                                        CssClass="datagrid2" AllowPaging="True" OnPageIndexChanging="WebLinkGrid_PageIndexChanging"
                                                        OnRowCommand="WebLinkGrid_RowCommand" OnRowDeleting="WebLinkGrid_RowDeleting"
                                                        OnRowDataBound="WebLinkGrid_RowDataBound" PageSize="10" Width="98%" ForeColor="Black">
                                                        <Columns>
                                                            <asp:BoundField DataField="Link_Title" HeaderText="Link Title">
                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Link_Url" HeaderText="Web Link">
                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="User_ID" Visible="false">
                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Profile_ID" Visible="false">
                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Category_Name" HeaderText="Category Name">
                                                                <HeaderStyle Width="150px"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lnkEdit" ToolTip="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"LinkID") %>'
                                                                        OnClientClick="return confirm('Are you sure you want to edit this web link?');"
                                                                        OnClick="lnkEdit_Click" Style="cursor: pointer;">
                                                                            <img src="../../Images/Dashboard/icon_modify.gif" alt="" />
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="40px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lnkDelete" CommandName="Delete" ToolTip="Delete"
                                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"LinkID") %>' OnClientClick="return confirm('Are you sure you want to delete this web link?');"
                                                                        Style="cursor: pointer;">
                                                                            <img src="../../Images/Dashboard/icon_delete.gif" alt="" />    
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="40px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="title3" />
                                                        <EmptyDataTemplate>
                                                            <span style="color: #c00000;">No Data Found</span>
                                                        </EmptyDataTemplate>
                                                        <EmptyDataRowStyle ForeColor="#e8e8e8" />
                                                        <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA;
                                        padding: 7px 0px 7px 0px;">
                                        <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" OnClick="btnDashboard_Click" CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblWebLink" runat="server"></asp:Label>
                                            <asp:ModalPopupExtender ID="mpeWebLink" runat="server" BackgroundCssClass="modal"
                                                PopupControlID="pnlWebLink" TargetControlID="lblWebLink" CancelControlID="imgClose">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel Style="display: none" ID="pnlWebLink" runat="server" Width="100%">
                                                <table class="popuptable" cellspacing="0" cellpadding="0" width="600px" align="center"
                                                    border="0">
                                                    <tr>
                                                        <td align="left" class="header">
                                                            <% if (hdnSPID.Value == "0")
                                                               {%>
                                                            Add
                                                            <%}
                                                               else
                                                               {%>
                                                            Edit
                                                            <%}%>Web Link
                                                        </td>
                                                        <td align="right">
                                                            <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                CausesValidation="false"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="padding-bottom: 20px;">
                                                            <asp:UpdateProgress ID="UpdateProgress10" runat="server" DisplayAfter="3">
                                                                <ProgressTemplate>
                                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Label ID="lblerror" runat="server" Style="font-weight: bold; font-size: 16px;"></asp:Label>
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                                                            ValidationGroup="A" HeaderText="The following error(s) occurred:" Font-Size="Small" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table border="0" cellpadding="2" cellspacing="0" width="600px">
                                                                <tr>
                                                                    <td style="width: 80px; vertical-align: top; padding-top: 5px;">
                                                                        Title Name
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtTitleName" runat="server" TabIndex="1" MaxLength="30" onkeyup="CountMaxLength(this,'Message');"
                                                                            onChange="CountMaxLength(this,'Weblink');"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator runat="server" ID="RFTitleName" ControlToValidate="txtTitleName"
                                                                            ValidationGroup="A" ErrorMessage="Title name is mandatory.">*</asp:RequiredFieldValidator>
                                                                        <br />
                                                                        <span style="font-size: 13px;">You have
                                                                            <asp:Label ID="lblLength" runat="server"></asp:Label>
                                                                            characters left. </span>
                                                                        <br />
                                                                        <span style="font-size: 13px;">(Max Characters 30)</span>
                                                                    </td>
                                                                    <td style="width: 80px; vertical-align: top; padding-top: 5px;">
                                                                        Web Link
                                                                    </td>
                                                                    <td style="vertical-align: top;">
                                                                        <asp:TextBox ID="txtlinkUrl" runat="server" TabIndex="2" Width="200px"></asp:TextBox><asp:RequiredFieldValidator
                                                                            runat="server" ID="RFlinkUrl" ControlToValidate="txtlinkUrl" ValidationGroup="A"
                                                                            ErrorMessage="Web link is mandatory.">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                                ID="rex1" ControlToValidate="txtlinkUrl" ErrorMessage="Please enter valid web link."
                                                                                Display="Dynamic" ValidationGroup="A" runat="server" ValidationExpression="(([\w]+:)?//)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w ]|%[a-fA-f\d]{2,2})+)?@)?([\d\w ][-\d\w ]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(/([-+_~.,\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.,\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.,\d\w]|%[a-fA-f\d]{2,2})*)?">*</asp:RegularExpressionValidator>
                                                                        <%--^http[s]*\:\/\/[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+\.[a-zA-Z]{2,3}(.[a-zA-Z]{2})?(/?)([a-zA-Z0-9-]{1,100})?(/?)([a-zA-Z0-9-]{1,100})?(/?)([a-zA-Z0-9-]{1,100})?(.[a-zA-Z]{3,4})?(\?)?([a-zA-Z]{1,100})?(=?)([a-zA-Z0-9-]{1,100})?(&?)([a-zA-Z]{1,100})?(=?)([a-zA-Z0-9-]{1,100})?$|^http[s]*\:\/\/[^w]{3}[a-zA-Z0-9-]+\.[a-zA-Z]{2,3}(.[a-zA-Z]{2})?(/?)([a-zA-Z0-9]{1,100})?(/?)([a-zA-Z0-9]{1,100})?(/?)([a-zA-Z0-9]{1,100})?(.[a-zA-Z]{3,4})?(\?)?([a-zA-Z]{1,100})?(=?)([a-zA-Z0-9-]{1,100})?(&?)([a-zA-Z]{1,100})?(=?)([a-zA-Z0-9-]{1,100})?$|http[s]*\:\/\/[0-9-]{2,3}\.[0-9-]{2,3}\.[0-9-]{2,3}\.[0-9]{2,3}(.[a-zA-Z]{2})?(/?)([a-zA-Z0-9]{1,100})?(/?)([a-zA-Z0-9]{1,100})?(/?)([a-zA-Z0-9]{1,100})?(.[a-zA-Z]{3,4})?(\?)?([a-zA-Z]{1,100})?(=?)([a-zA-Z0-9-]{1,100})?(&?)([a-zA-Z]{1,100})?(=?)([a-zA-Z0-9-]{1,100})?$/"--%>
                                                                        <%-- ValidationExpression="^http[s]*\:\/\/[a-zA-Z0-9]+\.[a-zA-Z0-9]+\.[a-zA-Z]{2,3}\/?$|^http[s]*\:\/\/[^w]{3}[a-zA-Z0-9]+\.[a-zA-Z]{2,3}\/?$|http[s]*\:\/\/[0-9]{2,3}\.[0-9]{2,3}\.[0-9]{2,3}\.[0-9]{2,3}\/?$/">--%>
                                                                        <br />
                                                                        <span style="font-size: 13px;">(Ex: http://www.google.com)</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 80px; vertical-align: top; padding-top: 5px;">
                                                                        Category
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList runat="server" ID="ddlCategory" Width="200px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 80px; vertical-align: top; padding-top: 5px;">
                                                                    </td>
                                                                    <td style="vertical-align: top;">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="padding: 10px;" colspan="4">
                                                                        <asp:Button ID="btnSumbit" runat="server" Text="Add" ValidationGroup="A" TabIndex="3"
                                                                            OnClick="btnSumbit_Click" />
                                                                        <asp:HiddenField ID="hdnSPID" runat="server" Value="0" />
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl2" runat="server"></asp:Label>
                                            <asp:ModalPopupExtender ID="ModalPopupWebLinkOrderNo" runat="server" PopupControlID="pnlpopup2"
                                                TargetControlID="lbl2" BackgroundCssClass="modal" CancelControlID="ImageButton4">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="pnlpopup2" runat="server" Style="display: none;">
                                                <table class="popuptable" cellspacing="0" cellpadding="0" width="500px" border="0">
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="3">
                                                                <ProgressTemplate>
                                                                    <img src="../../images/popup_ajax-loader.gif" border="0"><span class="processing">Processing....</span>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="header">
                                                        </td>
                                                        <td align="right">
                                                            <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="false" ImageUrl="~/images/popup_close.gif" />
                                                            <br />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        <br />
                                                        <tr>
                                                            <td colspan="2">
                                                                <div id="Div1" style="height: 300px; overflow-y: auto; border: solid 1px #ccc; padding-top: 5px;">
                                                                    <ul id="sortable">
                                                                        <asp:ListView ID="OrderListView" OnItemDataBound="OrderListView_ItemDataBound" runat="server"
                                                                            DataKeyNames="LinkID" ItemPlaceholderID="myItemPlaceHolder">
                                                                            <LayoutTemplate>
                                                                            </LayoutTemplate>
                                                                            <LayoutTemplate>
                                                                                <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                                            </LayoutTemplate>
                                                                            <ItemTemplate>
                                                                                <li class="ui-state-default" id='id_<%# Eval("LinkID") %>' style="border: 1px solid #ccc;
                                                                                    background: #EEEEEE; font-weight: normal; color: #8C8C8C;">
                                                                                    <asp:Label ID="lblKey" runat="server" Text='<%#Eval("LinkID") %>' Visible="false" />
                                                                                    <asp:Label ID="lblOrderThumb" runat="server" />
                                                                                    &nbsp&nbsp;&nbsp;
                                                                                    <%# Eval("Link_Title")%></li>
                                                                            </ItemTemplate>
                                                                        </asp:ListView>
                                                                    </ul>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td style="padding-top: 10px; padding-left: 120px;">
                                                                <asp:Button ID="btnUpdateImgOrderNumber" runat="server" OnClick="btnUpdateImgOrderNumber_Click"
                                                                    Text="Update" ValidationGroup="g" OnClientClick="return UpdateOder();" />
                                                                <asp:Button runat="server" ID="btnUpdateImgOrderNumber1" OnClick="btnUpdateImgOrderNumber1_Click"
                                                                    Style="display: none;" />
                                                                <asp:Button ID="btnCancelImgOrderNumber" runat="server" CausesValidation="false"
                                                                    OnClick="btnCancelImgOrderNumber_Click" Text="Cancel" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 25px;">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </caption>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="clear10">
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        window.onload = function () {

        }
        function ShortCut() {
            var modalDialog = $find("createshortcut");
            var iframe = document.getElementById('frmShortcut');
            var innerDoc = iframe.contentDocument || iframe.contentWindow.document;
            innerDoc.getElementById('chkCreate').checked = false;
            modalDialog.show();
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblcreateshortcut" runat="server"></asp:Label>
            <asp:ModalPopupExtender ID="popcreateshortcut" runat="server" TargetControlID="lblcreateshortcut"
                PopupControlID="pnlcreateshortcut" BackgroundCssClass="modal" BehaviorID="createshortcut"
                CancelControlID="imgclse">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlcreateshortcut" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="80%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="left">
                                <div class="pageheading">
                                    &nbsp; Create Shortcut
                                </div>
                            </td>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="imgclse" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid" style="padding: 5px; text-align: center;">
                                <div style="text-align: center;">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Font-Names="arial" Font-Size="14px"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <iframe src="../../ProfileIframes/UrlShortCut.aspx" frameborder="0" scrolling="no"
                                    height="100%" width="100%" style="border: 0px;" id="frmShortcut"></iframe>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
