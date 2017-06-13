<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="ManageCannedMessage.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageCannedMessage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/Jquery-order-ui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 300px;
            border-radius: 12px;
            padding: 0;
            border: 0;
        }
        .modalPopup .header
        {
            height: 30px;
            color: White;
            line-height: 30px;
            border-top-left-radius: 6px;
            border-top-right-radius: 6px;
        }
        .btn-send
        {
            background: #3c83d7;
            border-radius: 5px;
            padding: 8px 15px;
            color: #fff;
            font-size: 14px;
            text-decoration: none;
        }
        .btn-cancel
        {
            background: #f15a29;
            border-radius: 5px;
            padding: 8px 15px;
            color: #fff;
            font-size: 14px;
            text-decoration: none;
        }
        #tblHeading
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        
        
        #tblHeading h1
        {
            font-size: 18px;
            color: #EC2027;
            height: 35px;
            line-height: 35px;
            margin: 0;
            padding: 0;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="valign-top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="tblHeading">
                            <tbody>
                                <tr>
                                    <td>
                                        <h1>
                                            Canned Messages
                                        </h1>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblSuccessMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                            <ProgressTemplate>
                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
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
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="lnkAdd" runat="server" CssClass="btn-cancel" CausesValidation="false"
                            Text="Add" OnClick="lnkAdd_OnClick">  </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px;">
                    </td>
                </tr>
                <tr>
                    <td class="content">
                        <div>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="valign-top">
                                <tr>
                                    <td valign="top" align="center">
                                        <asp:GridView ID="GVMessage" runat="server" AutoGenerateColumns="False" PageSize="25"
                                            AllowSorting="true" Width="100%" ForeColor="Black" CssClass="datagrid2" AllowPaging="True"
                                            OnPageIndexChanging="GVMessage_PageIndexChanging" OnSorting="GVMessage_Sorting"
                                            OnRowCommand="GVMessage_RowCommand">
                                            <HeaderStyle CssClass="title3" />
                                            <Columns>
                                                <asp:BoundField DataField="CannedMessageID" Visible="false">
                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Message">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMsgText" runat="server" Text='<%#Eval("MessageText")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="400px"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="CreatedDate"
                                                    DataFormatString="{0:MM/dd/yyyy hh:mm tt}">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="200px"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnEdit" CommandName="EditRow" Style="cursor: pointer;"
                                                            ToolTip="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CannedMessageID") %>'>
                                                   <img src="../../Images/Dashboard/icon_modify.gif" />                     
                                                                        
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnDelete" CommandName="DeleteRow" Style="cursor: pointer;"
                                                            ToolTip="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CannedMessageID") %>'
                                                            OnClientClick="return confirm('Are you sure you want to delete selected message?');">
                                                   <img src="../../Images/Dashboard/icon_delete.gif" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span style="color: #c00000;">No Data Found</span>
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle ForeColor="#e8e8e8" />
                                            <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                        </asp:GridView>
                                        <asp:HiddenField ID="hdnsortcount" runat="server"></asp:HiddenField>
                                        <asp:HiddenField ID="hdnsortdire" runat="server"></asp:HiddenField>
                                        <asp:HiddenField ID="hdnEditID" runat="server"></asp:HiddenField>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button runat="server" Text="Back" OnClick="btnBack_OnClick" Width="80px" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbldummmy" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="MPEMessage" runat="server" TargetControlID="lbldummmy"
                PopupControlID="pnlMessage" BackgroundCssClass="modal" CancelControlID="btnClose">
            </cc1:ModalPopupExtender>
            <asp:Panel Style="display: none;" ID="pnlMessage" runat="server" Width="500px">
                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" class="popuptable"
                    style="height: 150px;">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="right">
                                            <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/popup_close.gif">
                                            </asp:ImageButton>
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
                        <td style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <b>Message:</b>
                            <asp:TextBox ID="txtMessage" runat="server" MaxLength="125" Width="370" Height="50"
                                TextMode="MultiLine" onkeyup="CountMaxLength(this,'message',event);" onChange="CountMaxLength(this,'message',event);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage"
                                Display="Dynamic" ValidationGroup="Save" Text="*"></asp:RequiredFieldValidator><br />
                            <span style="padding-left:30px;">You have
                                <asp:Label ID="lblLength" runat="server"></asp:Label>
                                characters left.</span><span style="float:right; margin-right: 20px;">(Max Characters 125)</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:LinkButton ID="lnkSave" runat="server" CssClass="btn-send" OnClick="lnkSave_Click"
                                ValidationGroup="Save" Text="Save"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkCancel" runat="server" CssClass="btn-cancel" OnClick="lnkCancel_Click"
                                CausesValidation="false" Text="Cancel">  </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px;">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function CountMaxLength(id, text, e) {
            var maxlength = 125;
            var myRegExp = new RegExp(/^[^<&]+$/);   //(/^[a-zA-Z0-9\-\.\'\,]+$/);            
            if (myRegExp.test(id.value)) {
                if (id.value.length > maxlength) {
                    id.value = id.value.substring(0, maxlength);
                    alert('You have exceeded the maximum of ' + maxlength + ' characters for ' + text + '.');
                }
                document.getElementById('<%=lblLength.ClientID %>').innerHTML = maxlength - id.value.length;

                return true;
            }
            else {
                if (e != undefined && (e.keyCode == 8 || e.keyCode == 46)) {
                    //
                }
                else {
                    document.getElementById('<%=txtMessage.ClientID %>').value = id.value.replace(/[&<]/g, '')
                    alert("Please do not enter & and < characters.");
                    return false;
                }
            }
        }

        function clearText() {
            document.getElementById('<%=txtMessage.ClientID %>').value = '';
            document.getElementById('<%=lblLength.ClientID %>').innerText = 75;
            document.getElementById('<%=lnkSave.ClientID %>').value = 'Save';
            document.getElementById('<%=lblSuccessMsg.ClientID %>').innerHTML = '';
        }
    </script>
</asp:Content>
