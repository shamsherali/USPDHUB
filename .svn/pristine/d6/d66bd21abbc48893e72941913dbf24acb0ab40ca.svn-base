<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="ManageRequestCustomForms.aspx.cs" Inherits="USPDHUB.Admin.ManageRequestCustomForms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <asp:ScriptManager ID="smgr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    Manage Request Custom Forms
                                </td>
                                <td style="padding-right: 70px;">
                                    <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" id="tabber" width="100%">
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
                                                            <table class="valign-top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <asp:GridView ID="grdRequests" runat="server" AllowSorting="true" AutoGenerateColumns="False"
                                                                                AllowPaging="true" Width="100%" CssClass="datagrid2" OnPageIndexChanging="grdRequests_PageIndexChanging">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Request Type">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblRequestType" runat="server" Text='<%#Eval("TypeTitle") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="100px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Title">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="150px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Description">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="170px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Comments">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblComments" runat="server" Text='<%#Eval("Comments") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="170px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Requested Date">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblRequestedDate" runat="server" Text='<%#Eval("Requested_Date") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="130px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="MemberID">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblMemberID" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="50px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Preview">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="btnPreview" Text="<img src='../../Images/Dashboard/preview.png' title='Preview' border='0'"
                                                                                                CommandArgument='<%#Eval("RFP_RequestID")%>' OnClick="btnPreview_Click"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="10px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Edit">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="btnEdit" Text="<img src='../../Images/Dashboard/icon_modify.gif' title='Edit' border='0'"
                                                                                                CommandArgument='<%#Eval("RFP_RequestID") + ","+Eval("SubcriptionID") %>' OnClick="btnEdit_Click"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="10px" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <asp:Label ID="lblBUempty" runat="server" Text="There are no custom forms at this time."
                                                                                        Font-Bold="true" Font-Size="15px" ForeColor="#E8C41D"></asp:Label>
                                                                                </EmptyDataTemplate>
                                                                                <HeaderStyle CssClass="title1" />
                                                                                <EmptyDataRowStyle ForeColor="#C00000" />
                                                                                <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="page-title">
                            <tr>
                                <td align="right">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblPreview" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popupPreview" runat="server" TargetControlID="lblPreview"
                PopupControlID="pnlpreview" BackgroundCssClass="modal" CancelControlID="imgclosepreviewpopup"
                BehaviorID="BulletinPreview">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlpreview" runat="server" Style="display: none" Width="500px">
                <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td style="padding-right: 120px;" align="right">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                            <td align="right" style="padding: 5px 10px 20px 10px;">
                                <asp:ImageButton ID="imgclosepreviewpopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; padding: 10px;" colspan="2">
                                <div style="overflow-y: auto; height: 350px; position: relative;">
                                    <asp:Label ID="lblspreview" runat="server"></asp:Label></div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
