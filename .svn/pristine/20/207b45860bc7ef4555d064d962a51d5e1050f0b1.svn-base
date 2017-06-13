<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareDownloads.aspx.cs"
    Inherits="USPDHUB.Business.MyAccount.ShareDownloads" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../css/wowzzy_general.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .ezbtn
        {
            background: url(../../images/Dashboard/ezbtnbg.gif) top left repeat-x;
            padding: 3px 10px 4px 10px;
            color: #FFFFFF;
            border-style: none;
            margin-top: 5px;
            font-weight: bold;
            border: 1px solid #0099ff;
            overflow: visible;
            border: 0px;
            width: 70px;
            font-size: 15px;
            cursor: hand;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="padding-right: 70px;" align="center">
                            <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                                Style="border: 0; border-color: White!important;"></asp:TextBox>
                            <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                <ProgressTemplate>
                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                                        ValidationGroup="g" HeaderText="The following error(s) occurred:" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="profile-input"
                                style="border: 1px solid #ECECEC;">
                                <tr>
                                    <td>
                                        <table width="90%" border="0" cellspacing="0" cellpadding="0" style="padding: 10px">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" nowrap>
                                                    <table border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                From:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtfrom" runat="server" Width="350px" TabIndex="1"></asp:TextBox>
                                                                <br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtfrom"
                                                                    Display="Dynamic" ErrorMessage="Invalid Email Format" SetFocusOnError="True"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="g"
                                                                    Font-Size="XX-Small">*</asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfrom"
                                                                    Display="Dynamic" ErrorMessage="From is mandatory." Font-Size="XX-Small" SetFocusOnError="True"
                                                                    ValidationGroup="g">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                To:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTO" runat="server" Width="500px" TabIndex="2" TextMode="MultiLine"
                                                                    Height="70px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTO"
                                                                    Display="Dynamic" ErrorMessage="Invalid Email Format" SetFocusOnError="True"
                                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*"
                                                                    ValidationGroup="g" Font-Size="XX-Small">*</asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="To is mandatory."
                                                                    ControlToValidate="txtTO" Display="Dynamic" SetFocusOnError="True" ValidationGroup="g"
                                                                    Font-Size="XX-Small">*</asp:RequiredFieldValidator><br />
                                                                <span style="color: Red;">Note: Please separate addresses with a comma.</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Subject:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSubject" runat="server" TabIndex="4" Width="500px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Subject is mandatory."
                                                                    ControlToValidate="txtSubject" Display="Dynamic" SetFocusOnError="True" ValidationGroup="g"
                                                                    Font-Size="XX-Small">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Message:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtmessage" runat="server" TabIndex="5" TextMode="MultiLine" Width="500px"
                                                                    Height="350px" Style="white-space: pre-wrap"></asp:TextBox>
                                                                <br />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Message is mandatory."
                                                                    ControlToValidate="txtmessage" Display="Dynamic" SetFocusOnError="True" ValidationGroup="g"
                                                                    Font-Size="XX-Small">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="content-lable">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnsubmit" runat="server" Text="Send" CssClass="ezbtn" ValidationGroup="g"
                                                                    TabIndex="6" OnClick="btnsubmit_Click" OnClientClick="test();" />
                                                                <asp:HiddenField ID="hdnProfineName" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" align="left">
                                                            </td>
                                                        </tr>
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
            </ContentTemplate>
        </asp:UpdatePanel>
        <script type="text/javascript">
            function test() {
                document.getElementById('<%=txt.ClientID %>').focus();
            }   

        </script>
    </div>
    </form>
</body>
</html>
