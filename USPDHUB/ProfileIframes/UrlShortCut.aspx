<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrlShortCut.aspx.cs" Inherits="ProfileIframes_UrlShortCut" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function HideShortCut() {
            document.getElementById("<%= chkCreate.ClientID %>").checked = false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <div>
        <table cellpadding="0" cellspacing="0" width="100%" style="border: 0px solid #EEECEC;
            background-color: #F8F6F6;">
            <tbody>
                <tr>
                    <td class="mid" style="padding: 15px;">
                        Create a USPDhub shortcut button on your desktop.
                        <br />
                        <br />
                        <div style="float: left;">
                            <div style="float: left;">
                                <span class="checkbox">
                                    <asp:CheckBox ID="chkCreate" TabIndex="2" runat="server" Text="Include your password." /></span></div>
                        </div>
                        <div style="margin-top: 20px; float: right;">
                            <%--<asp:ImageButton ID="BtnClose" runat="server" ImageUrl="~/images/Dashboard/Cancel.jpg"
                                TabIndex="3" OnClientClick="return HideShortCut();" />&nbsp;--%><asp:ImageButton
                                    ID="BtnCreate" runat="server" TabIndex="4" ImageUrl="~/images/Dashboard/Create.jpg"
                                    OnClick="BtnCreate_Click" />
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
