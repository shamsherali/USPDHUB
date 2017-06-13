<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePSCCategories.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.ManagePSCCategories" ValidateRequest="false"
    MasterPageFile="~/PaidTools.master"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-latest.pack.js"></script>
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
        .header
        {
            font-size: 18px;
            color: #EC2027;
        }
    </style>
    <script type="text/javascript">
        function ValidateCategory(ControlId) {
            var id = ControlId.id;
            if (document.getElementById("<%=hdnCommandArg.ClientID%>").value == '') {
                alert('Please select a Category.');
                return false;
            }
            else if (id.indexOf("lnkdelete") != -1) {
                return confirm('Are you sure you want to delete this category?');
            }
            else {
                return true;
            }
        }

        function RadioCheck(rb, catName, catID) {
            document.getElementById("<%=hdnCommandArg.ClientID%>").value = catID;
            var gv = document.getElementById("<%=GrdCategories.ClientID%>");
            if (catName.indexOf("Not Assigned") > -1) {
                $('#<%= lnkEdit.ClientID %>').css("display", "none");
                $('#<%= lnkdelete.ClientID %>').css("display", "none");
            } else {
                $('#<%= lnkEdit.ClientID %>').css("display", "block");
                $('#<%= lnkdelete.ClientID %>').css("display", "block");
            }
            var rbs = gv.getElementsByTagName("input");
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }

                }
            }

            document.getElementById("<%=lblmess.ClientID %>").innerHTML = "";
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            var gv = document.getElementById("<%=GrdCategories.ClientID%>");
            var rbs = gv.getElementsByTagName("input");
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    rbs[i].checked = false;
                }
            }
            var maxlength = 30;
            var catname = document.getElementById("<%=txtCategoryName.ClientID%>").value;
            if (catname != '')
                document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - catname.length;

        });
        function CountMaxLength(id, text, e) {
            var maxlength = 30;
            var myRegExp = new RegExp(/^[^<&]+$/);   //(/^[a-zA-Z0-9\-\.\'\,]+$/);            
            if (myRegExp.test(id.value)) {
                if (id.value.length > maxlength) {
                    id.value = id.value.substring(0, maxlength);
                    alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
                }
                document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;
                return true;
            }

        }

    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <tbody>
                                <tr>
                                    <td>
                                        <h1>
                                            Manage Private QR Connect Categories</h1>
                                    </td>
                                    <td style="padding-right: 70px">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                        </asp:UpdateProgress>
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
                                    <td style="color: red;" align="center">
                                        <asp:Label ID="lblerrormessage" runat="server"></asp:Label>
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
                                    <table cellpadding="0" cellspacing="0" border="0" width="909px">
                                        <tr>
                                            <td class="leftmenu">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <asp:GridView ID="GrdCategories" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                CssClass="datagrid2" AllowPaging="True" OnPageIndexChanging="GrdCategories_PageIndexChanging"
                                                                                Width="100%" GridLines="None" OnSorting="GrdCategories_Sorting" PageSize="5">
                                                                                <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Select">
                                                                                        <ItemTemplate>
                                                                                            <asp:RadioButton ID="rbCategory" runat="server" onclick='<%# string.Format("javascript:RadioCheck(this, \"{0}\",\"{1}\")", Eval("CategoryName"), Eval("CategoryID")) %>' />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="20px"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="CategoryName" HeaderText="Category Name" HtmlEncode="False"
                                                                                        SortExpression="CategoryName">
                                                                                        <HeaderStyle Width="150px"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                      <asp:BoundField DataField="TotalButtonsCount" HeaderText="Total Buttons/QR" HtmlEncode="False">
                                                                                        <HeaderStyle Width="70px"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="MessagesCount" HeaderText="Messages Count" HtmlEncode="False">
                                                                                        <HeaderStyle Width="70px"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Description" HeaderText="Description" HtmlEncode="False">
                                                                                        <HeaderStyle Width="150px"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="CreatedDate">
                                                                                        <HeaderStyle Width="85px"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    No category found
                                                                                </EmptyDataTemplate>
                                                                                <HeaderStyle CssClass="title3"></HeaderStyle>
                                                                                <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                                            <asp:HiddenField ID="hdnShowButtons" runat="server" />
                                                            <asp:HiddenField ID="hdnPermissionType" runat="server" />
                                                            <asp:HiddenField ID="hdnRowIndex" runat="server" />
                                                            <asp:HiddenField ID="hdnSName" runat="server" />
                                                            <asp:HiddenField ID="hdnCommandArg" runat="server" />
                                                            <asp:HiddenField runat="server" ID="hdnCategoryPermission" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="rightmenu">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkCreate" runat="server" CausesValidation="false" OnClick="lnkCreate_Click"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -370px;"></span>Create</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%if (hdnShowButtons.Value == "1")
                                                  { %>
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" OnClick="lnkEdit_Click"
                                                                OnClientClick="return ValidateCategory(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -32px;"></span>Edit</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="rightLinks">
                                                            <asp:LinkButton ID="lnkdelete" runat="server" CausesValidation="false" OnClick="lnkdelete_Click"
                                                                OnClientClick="return ValidateCategory(this);"><span style="background: url(../../images/Dashboard/side_icons.png) no-repeat 6px -108px;"></span>Delete</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%} %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center" style="background-color: #D2E5FA; border: 1px solid #D1DDEA;
                                                padding: 7px 0px 7px 0px;">
                                                <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" OnClick="btnBack_Click" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Dashboard" CausesValidation="false"
                                                    OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnURLPath" runat="server" />
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblc1" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="mpeWebLink" runat="server" BackgroundCssClass="modal"
                                PopupControlID="pnleditnews" TargetControlID="lblc1" CancelControlID="imglogin3">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnleditnews" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="600" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0"><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <colgroup>
                                                        <col width="40%" />
                                                        <col width="*" />
                                                    </colgroup>
                                                    <tbody>
                                                        <tr>
                                                            <td align="right">
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin3" runat="server" OnClick="ImcloseClick" CausesValidation="false"
                                                                    ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center" style="color: Red; font-size: 13px; padding-bottom: 5px;">
                                                                <asp:Label ID="lbleditext" runat="server" ForeColor="red"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="header" align="center" colspan="2">
                                                                <br />
                                                                <span>Private QR Connect Category</span><br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="header" valign="top" style="padding-left: 50px; padding-bottom: 10px;
                                                                padding-top: 20px;" align="right">
                                                                Enter a new category:
                                                            </td>
                                                            <td style="padding-bottom: 10px; padding-top: 20px; padding-left: 5px;">
                                                                <asp:TextBox ID="txtCategoryName" runat="server" Width="275" onkeyup="CountMaxLength(this,'Category',event);"></asp:TextBox><br />
                                                                <span style="font-size: small;">You have
                                                                    <asp:Label ID="lblLength" runat="server" Text="30"></asp:Label>
                                                                    characters left.</span><span style="margin-left: 8px; font-size: small;">(Max Characters
                                                                        30)</span>
                                                                <asp:RequiredFieldValidator ID="reqeditcheck" runat="server" ErrorMessage="Category is mandatory."
                                                                    Display="Dynamic" ControlToValidate="txtCategoryName"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="header" style="padding-left: 50px; padding-bottom: 10px; padding-top: 10px;"
                                                                align="right">
                                                                Description:
                                                            </td>
                                                            <td style="padding-bottom: 10px; padding-top: 10px; padding-left: 5px;">
                                                                <asp:TextBox ID="txtDescription" runat="server" Width="275" Height="70px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding-left: 5px; padding-bottom: 10px;">
                                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSumbit_Click">
                                                                </asp:Button>&nbsp;&nbsp;
                                                                <asp:Button ID="btneditcancel" runat="server" Text="Cancel" CausesValidation="false">
                                                                </asp:Button><br />
                                                                <br />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="manage">
                            <tbody>
                                <tr>
                                    <td>
                                        <h1>
                                            Manage Private QR Connect Categories</h1>
                                    </td>
                                    <td style="padding-right: 70px">
                                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td align="center">
                                    <h3>
                                        <asp:Label ID="lblerrormsg" ForeColor="Red" runat="server"></asp:Label>
                                    </h3>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
