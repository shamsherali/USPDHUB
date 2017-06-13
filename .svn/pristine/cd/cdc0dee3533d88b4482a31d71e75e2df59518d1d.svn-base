<%@ Control Language="C#" AutoEventWireup="true" Inherits="Controls_Login" CodeBehind="Login.ascx.cs" %>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<div class="formwrap">
    <%--if (Session["VerticalDomain"].ToString() == "uspdhubcom")
            {%>

         <h2 style="text-align: center">Login</h2><%}
            else --%>
    <%if (Session["VerticalDomain"] != null)
      {
          if (Session["VerticalDomain"].ToString() == "twoviecom" || Session["VerticalDomain"].ToString() == "myyouthhubcom")
          { %>
    <h1 style="text-align: center">
        Login</h1>
    <%}
            else
            {%><h2 style="text-align: center">
    </h2>
    <%}
        } %>
    <div class="label1">
        <span class="errormsg">* </span>Username:</div>
    <div class="txtfild1wrap">
        <asp:TextBox ID="email" runat="server" class="white-space-is-dead txtfild1" ValidationGroup="g"
            CausesValidation="True" onkeypress="return RestrictSpace()" autocomplete="off"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email"
            Display="Dynamic" ErrorMessage="Username is mandatory." SetFocusOnError="True"
            ValidationGroup="g">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email"
            Display="Dynamic" ErrorMessage="Invalid Email Format." SetFocusOnError="True"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="g">*</asp:RegularExpressionValidator>
    </div>
    <div class="clear15">
    </div>
    <div class="label1">
        <span class="errormsg">* </span>Password:</div>
    <div class="txtfild1wrap">
        <asp:TextBox ID="password" TextMode="Password" Text="enter password" class="txtfild1"
            runat="server" ValidationGroup="g" CausesValidation="True" autocomplete="off"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
            ErrorMessage="Password is mandatory." SetFocusOnError="True" ValidationGroup="g">*</asp:RequiredFieldValidator>
    </div>
    <div class="clear15">
    </div>
    <div class="label1">
    </div>
    <div class="label2" id="divremember">
        <asp:CheckBox ID="wowzzyID" runat="server" CssClass="checkbox" />
        Remember me on this computer</div>
    <div class="clear15">
    </div>
    <div class="label1">
    </div>
    <div class="label2" id="forgot">
        <a href="ForgotPassword.aspx" class="label2anchor">Forgot Password?</a> |
        <asp:LinkButton ID="lblDifferentUser" runat="server" OnClick="lnkDifferentUser_Click"
            CausesValidation="False" CssClass="label2anchor">Sign in as a Different User</asp:LinkButton></div>
    <div class="clear15">
    </div>
</div>
<div class="submit1">
    <asp:Button ID="btnlogin" runat="server" Text="Sign In" ValidationGroup="g" OnClick="btnlogin_Click" />
</div>
<div class="clear15">
</div>
<table width="100%" border="0" cellpadding="0" cellspacing="0" class="loginbg">
    <tr>
        <td class="loginbg-mid">
            <table width="100%" border="0" cellspacing="3" cellpadding="3" style="font-size: 12px;">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" style="padding-left: 25px;">
                        <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="g" HeaderText="Errors:"
                            ShowSummary="true" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<script type="text/javascript">
    function RestrictSpace() {
        if (event.keyCode == 32) {
            event.returnValue = false;
            return false;
        }
    }
    $('.white-space-is-dead').change(function () {
        $(this).val($(this).val().replace(/\s/g, ""));
    });
</script>
