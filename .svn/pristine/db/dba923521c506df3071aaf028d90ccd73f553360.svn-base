<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="ManageTipsAudio.aspx.cs" Inherits="USPDHUB.Business.MyAccount.ManageTipsAudio" %>

<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>"></script>
    <style type="text/css">
        .datalist
        {
        }
        .datalist td
        {
            vertical-align: top;
            padding-top: 5px;
        }
    </style>
     <script type="text/javascript">
         function SetFileName() {
             var arrFileName = document.getElementById('<%= AudioFileUpload.ClientID %>').value.split('\\');
             var imageName = arrFileName[arrFileName.length - 1].replace(".wav", "");
             document.getElementById('<%= txtAudioName.ClientID %>').value = imageName;
         }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td>
                        <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td>
                                                    Manage Tips Manager Audio
                                                </td>
                                                <td align="left">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div id="divUpload" style="display: none">
                                            <div style="text-align: center;">
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/ezSmartAjax.gif")%>" border="0" /><b><font
                                                    color="green">Processing....</font></b>
                                            </div>
                                        </div>
                                        <asp:Label ID="lblPhotoMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:Panel ID="pnlallimage" runat="server">
                            <div>
                                <table class="inputtable" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 24px">
                                                            <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>'
                                                                width="9" />
                                                        </td>
                                                        <td class="new-header">
                                                            Upload Audio File
                                                        </td>
                                                        <td>
                                                            <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>'
                                                                width="9" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <table class="new-table" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <table class="profile-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="profile-caption">
                                                                            <asp:Panel ID="pnlAudio" runat="server">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" style="background-color: #E8F3FF;
                                                                                    border: 2px solid #D1DDEA;">
                                                                                    <colgroup>
                                                                                        <col width="15%" />
                                                                                        <col width="*" />
                                                                                    </colgroup>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <b>Enter Audio Title:</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtAudioName" runat="server" Width="236px" MaxLength="13" CssClass="textfield"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>&nbsp;Upload File :</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:FileUpload ID="AudioFileUpload" runat="server" Width="236px" onchange="SetFileName();"></asp:FileUpload>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Set as Default Audio:</b>
                                                                                        </td>
                                                                                        <td>
                                                                                            <input type="checkbox" id="chkDefaultAudio" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="BtnUpdate" runat="server" Text="<img src='../../images/Dashboard/upload.gif' border='0'/>"
                                                                                                OnClick="BtnUpdate_OnClick">
                                                                                            </asp:LinkButton>
                                                                                        </td>
                                                                                        <td class="profile-caption red-color">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="profile-caption" colspan="2">
                                                                                            <span class="profile-caption red-color">NOTE: The file size for each audio file is 2MB.
                                                                                                When uploading files, please use wav format.</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div>
                                                                <asp:GridView ID="GrdAudio" runat="server" PageSize="5" AllowPaging="True" ForeColor="Black"
                                                                    EmptyDataText="" DataKeyNames="AudioID,DefaultID,AudioFile,AudioType" GridLines="None"
                                                                    AutoGenerateColumns="False" CssClass="datagrid2" Width="100%" OnRowDataBound="GrdAudio_OnRowDataBound">
                                                                    <EmptyDataRowStyle ForeColor="Red"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Title" SortExpression="Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblDefaultAudioID" Visible="false" Text='<%# Bind("DefaultID") %>'></asp:Label>
                                                                                <asp:Label runat="server" ID="lblIsDefault" Visible="false" Text='<%# Bind("IsDefault") %>'></asp:Label>
                                                                                <asp:Label runat="server" ID="lblAudioType" Visible="false" Text='<%# Bind("AudioType") %>'></asp:Label>
                                                                                <asp:Label ID="lblAudioName" runat="server" Text='<%# Bind("AudioName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Audio Player">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAudioPlayer" runat="server" Text='<%# Bind("AudioFile") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Action">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton runat="server" ID="btnEdit" Text="<img src='../../Images/icon_modify.gif' title='Edit' border='0' />"
                                                                                    CommandArgument='<%#Eval("AudioID") %>' OnClientClick="return confirm('Are you sure you want to change default audio?')"
                                                                                    OnClick="btnEdit_OnClick"></asp:LinkButton>
                                                                                <asp:LinkButton runat="server" ID="btnDelete" Text="<img src='../../Images/icon_delete.gif' title='Delete' border='0' />"
                                                                                    CommandArgument='<%#Eval("AudioID") %>' OnClientClick='<%#Eval("IsDefault","return DeleteAudio(\"{0}\");")%>' OnClick="btnDelete_OnClick"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No audio found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title3"></HeaderStyle>
                                                                    <AlternatingRowStyle BackColor="#EEECEC"></AlternatingRowStyle>
                                                                </asp:GridView>
                                                            </div>
                                                            <table class="profile-btntbl" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:HiddenField ID="hdnVerticalName" runat="server" />
                                                                        <asp:Button ID="btnBack" runat="server" CausesValidation="false" OnClick="btnBack_Click"
                                                                            Text="Back" />&nbsp;&nbsp;
                                                                        <asp:Button ID="btndashboard1" OnClick="btndashboard1_Click" runat="server" Text="Go to Dashboard"
                                                                            CausesValidation="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnPermissionType" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnUpdate" />
        </Triggers>

    </asp:UpdatePanel>
    <script type="text/javascript">
        function DeleteAudio(IsAudio) {           
            if (IsAudio=="True") {
                alert("The audio is set as default audio for tips manager, So please change the status and delete it.");
                return false;
            }
            else {
                return confirm("Are you sure you want to delete?");
            }
        }
    </script>
</asp:Content>
