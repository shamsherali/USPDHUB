<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ManageAccessCodes.aspx.cs" Inherits="USPDHUB.Admin.ManageAccessCodes"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript">
        function confirmDelete(frm) {
            // loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our checkboxes only
                if (frm.elements[i].name.indexOf("CheckBox1") != -1) {
                    // If any are checked then confirm alert, otherwise nothing happens
                    if (frm.elements[i].checked) {
                        return confirm('Are you sure you want to delete your selection(s)?')
                    }
                }
            }
            alert('Please select at least one checkbox to delete');
            return false
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td style="padding-left: 6px;" valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <%-- <uc3:wowmap id="sitemaplinks" runat="server" />--%>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Manage Access Codes
                                </td>
                                <td>
                                    <asp:Label ID="lblerr" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div style="width: 880px;">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="admin-padding inputgrid">
                                <%-- **************** Added By Suneel for Print and Export to Excel *******************--%>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />
                                    </td>
                                </tr>
                                <%-- ************************************ End *****************************************--%>
                                <tr>
                                    <td valign="top">
                                        <asp:GridView ID="PincodeGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Profile_ID"
                                            CssClass="datagrid2" Width="100%" PageSize="10" OnRowEditing="PincodeGrid_RowEditing"
                                            OnRowDeleting="PincodeGrid_RowDeleting" OnRowCancelingEdit="PincodeGrid_RowCancelingEdit"
                                            AllowPaging="True" OnPageIndexChanging="PincodeGrid_PageIndexChanging">
                                            <%--OnSelectedIndexChanging="PincodeGrid_SelectedIndexChanging" OnRowDataBound="PincodeGrid_RowDataBound" --%>
                                            <Columns>
                                                <%-- <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Profile ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgridProfile" runat="server" Text='<%# Bind("Profile_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="User ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgridUser" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Profile Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgridProfileName" runat="server" Text='<%# Bind("ProfileName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="User Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgridUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Access Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgridAccessCode" runat="server" Text='<%# Bind("Access_code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vertical">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgridVertical" runat="server" Text='<%# Bind("Vertical") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="180px" />
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" Text="&lt;img src='../Images/icon_modify.gif' alt='Edit' title='Edit' border='0'/&gt;"
                                                            OnClientClick="return confirm('Are you sure you want to edit this pin code?');" OnClick="EditUsersRecord" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" CssClass="align-center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="deleteButton" runat="server" CommandName="Delete" Text="&lt;img src='../Images/icon_delete.gif' alt='Delete' title='Delete' border='0'/&gt;"
                                                            OnClientClick="return confirm('Are you sure you want to delete this pin code?');"
                                                            OnClick="deleteButton_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" CssClass="align-center" />
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <HeaderStyle CssClass="title" />
                                            <EmptyDataTemplate>
                                                No data Found
                                            </EmptyDataTemplate>
                                            <EmptyDataRowStyle ForeColor="#C00000" />
                                        </asp:GridView>
                                        <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="align-left">
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="DeleteUsersRecord"
                                                        OnClientClick="return confirmDelete (this.form)" />
                                                        &nbsp;
                                                    <asp:Button ID="btn_Dashboard" runat="server" OnClick="btn_goDashboard" Text="Go To Dashboard" />
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <table>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblpre"
                                PopupControlID="pnlpopup1" BackgroundCssClass="modal" CancelControlID="imglogin5">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlpopup1" runat="server" Width="100%" DefaultButton="btnUpdate">
                                <table class="popuptable" style="padding-left: 10px; background-color: white" cellspacing="0"
                                    cellpadding="0" width="450" align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:UpdateProgress ID="UpdateProgress7" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="header" align="left">
                                                <br />
                                                <span>Edit Pin Code</span><br />
                                            </td>
                                            <td style="padding-right: 20px; padding-top: 10px" align="right">
                                                <asp:ImageButton ID="imglogin5" OnClick="ImcloseClick" runat="server" CausesValidation="false"
                                                    ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 13px; padding-bottom: 10px; padding-top: 10px" align="right">
                                                Pin Code:
                                            </td>
                                            <td style="padding: 10px;" align="left">
                                                <asp:TextBox ID="txtEditPinCode" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="REGValidator" runat="server" ControlToValidate="txtEditPinCode"
                                                    Display="Dynamic" ErrorMessage="Please enter a valid pin code." ValidationExpression="^[0-9a-zA-Z]+$"
                                                    SetFocusOnError="True" ValidationGroup="g">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px; padding-bottom: 20px;" colspan="2" align="center">
                                                <asp:Button ID="btnUpdate" runat="server" ValidationGroup="g" Text="Update" OnClick="btnUpdate_popupClick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px; padding-bottom: 20px; padding-left: 135px;" colspan="2">
                                                <asp:ValidationSummary ID="ValidationSummary1" HeaderText="The following error(s) are occured:"
                                                    runat="server" ValidationGroup="g" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 10px; padding-bottom: 20px;" colspan="2" align="center">
                                                <asp:Label ID="lblSuccMsg" runat="server"></asp:Label>
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
</asp:Content>
