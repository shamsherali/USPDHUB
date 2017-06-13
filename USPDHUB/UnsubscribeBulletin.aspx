<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnsubscribeBulletin.aspx.cs"
    Inherits="USPDHUB.UnsubscribeBulletin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/wowzzy_general.css" rel="stylesheet" type="text/css" />    
    <script type="text/javascript">
        function onpageload() {

            window.moveTo(0, 0)
        }
    </script>
    <script language="javascript" type="text/javascript">
        function MM_openBrWindow(theURL, winName, features) { //v2.0
            window.open(theURL, winName, features);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" style="padding: 10px" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="valign-top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="vertical-align: top">
                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>"
                                    width="9" height="28" />
                            </td>
                            <td class="new-header">
                                <strong>Unsubscribe me</strong>
                            </td>
                            <td class="new-header align-right">
                                <a href="#">
                                    <img src="<%=Page.ResolveClientUrl("~/images/OuterImages/close-btn.gif")%>"
                                        width="18" height="18" border="0" onclick="Javascript:window.close();" alt="Close Window" /></a>
                            </td>
                            <td style="vertical-align: top">
                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/head-right.gif")%>"
                                    width="9" height="28" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="profile-input">
                        <tr>
                            <td align="left">
                                <asp:Panel ID="pnlUnsubscribe" runat="server" Width="100%">
                                    <table>
                                        <tr>
                                            <td nowrap>
                                                To complete your request please enter your email-id&nbsp;&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtusername" runat="server" ValidationGroup="S"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqdusername" runat="server" Display="Dynamic" ControlToValidate="txtusername"
                                                    Text="*" ValidationGroup="S" Font-Bold="True"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rugemail" runat="server" ValidationGroup="S"
                                                    ControlToValidate="txtusername" ErrorMessage="Enter valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="lnkUnsubscribe" runat="server" Text="Unsubscribe" ValidationGroup="S"
                                                    OnClick="lnkUnsubscribe_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center" style="color: Green;">
                                                <asp:Label ID="lblmess" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>