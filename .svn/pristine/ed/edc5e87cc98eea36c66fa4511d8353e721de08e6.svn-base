<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.ascx.cs" Inherits="USPDHUB.Controls.AdminLogin" %>

<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="content-input">
                <tr>
                    <td class="content-lable-leftaln">Username:</td>
                    <td>
                        <asp:TextBox ID="email"  runat="server" class="textfield" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="email" runat="server" ErrorMessage="Username is mandatory field. " Display="Dynamic">*</asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Invalid Username format."  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"/>
                    </td>
                </tr>
                <tr>
                    <td class="content-lable-leftaln">Password:</td>
                    <td>
                        <asp:TextBox ID="password" TextMode="Password" class="textfield" runat="server" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="email" runat="server" ErrorMessage="Password is mandatory field. " Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="wowzzyID" runat="server" /> Remember me on this computer
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnlogin" runat="server" OnClick="Login_Click"  Text="Sign in"  />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2"></td>
                                <td>
                                    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Errors:" runat="server" />
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

        </td>
    </tr>
</table>
