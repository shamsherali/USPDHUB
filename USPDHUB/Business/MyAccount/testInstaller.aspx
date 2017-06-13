<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testInstaller.aspx.cs"
    MasterPageFile="~/Dashboard.master" Inherits="USPDHUB.Business.MyAccount.testInstaller" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Installation() {
            if (confirm("Setup file sucessfully downloaded. Do you want to install setup file?")) {
                MyObject = new ActiveXObject("WScript.Shell")
                var setupFilePath = document.getElementById("<%=hdnCopyPath.ClientID %>").value + "setup.exe";
                MyObject.Run(setupFilePath);
            }
        }
        function DownloadInstaller(type) {
            document.getElementById("<%=hdnInstallerName.ClientID %>").value = type;
            var modalDialog = $find("downloadinstaller");
            modalDialog.show();
            return false;
        }
    </script>
    <style>
        .modal
        {
            background-color: Gray;
            filter: alpha(opacity=90);
            opacity: 0.7;
        }
    </style>
    <div id="webmangement_wrapper">
        <table style="font-family: Verdana; font-size: 14px;">
            <tr>
                <td>
                    <%--<a href="#" onclick="DownloadInstaller('1');">Option 1 </a>--%>
                    <asp:Button ID="Button2" runat="server" Text="Option 1 (Tips Manager)" OnClientClick="return DownloadInstaller('2');" />
                    
                </td>
            </tr>
            <tr>
                <td>
                    <%-- <a href="https://www.dropbox.com/s/zfh0xlzvuiy7cmu/USPDTipsManager.exe">Option 2
                    </a>--%>
                    <asp:Button ID="Button3" runat="server" Text="Option 2 (Tips Manager)" OnClick="Unnamed1_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnCopyPath" runat="server" />
            <asp:HiddenField ID="hdnInstallerName" runat="server" Value="1" />
            <asp:Label ID="lbldownload" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lbldownload"
                PopupControlID="Paneldownload" BackgroundCssClass="modal" BehaviorID="downloadinstaller"
                CancelControlID="ImageButton1">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="Paneldownload" runat="server" Style="display: none" Width="600px">
                <table cellpadding="0" cellspacing="0" width="80%" style="border: 1px solid #EEECEC;
                    background-color: #F8F6F6;">
                    <tbody>
                        <tr>
                            <td align="left">
                                <div class="pageheading">
                                    &nbsp; Download Installer
                                </div>
                            </td>
                            <td align="right" style="padding: 5px 10px 0px 10px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/popup_close.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td class="mid" style="padding: 5px; text-align: center;">
                                <div style="text-align: center;">
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="1">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b> <font color="green">Processing....</font>
                                            </b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:Label ID="Label2" runat="server" ForeColor="Green" Font-Names="arial" Font-Size="14px"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table style="font-family: Segoe UI; font-size: 14px;">
                                    <tr>
                                        <td valign="top">
                                            Installer Folder Path:
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtfolderpath" runat="server" ValidationGroup="ABC1" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtfolderpath"
                                                runat="server" ErrorMessage="Download file path is mandatory." Display="Dynamic"
                                                ValidationGroup="ABC1" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <br />
                                            <span style="text-align: left; margin: 0px;">Ex: <b>D:\\Softwares\\</b></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <br />
                                            <asp:Button ID="BtnDownload1" runat="server" Text="Save" ValidationGroup="ABC1" OnClick="BtnDownload_Click"
                                                border="0" CssClass="btn" />
                                            <asp:Button ID="Button1" runat="server" Text="Cancel" border="0" CssClass="btn" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
