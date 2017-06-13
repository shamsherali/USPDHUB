<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CopyPaste_POC.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Varela+Round">
    <!--[if lt IE 9]>
		<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
    <style type="text/css">
    @charset "utf-8";
/* CSS Document */

/* ---------- FONTAWESOME ---------- */
/* ---------- http://fortawesome.github.com/Font-Awesome/ ---------- */
/* ---------- http://weloveiconfonts.com/ ---------- */

@import url(http://weloveiconfonts.com/api/?family=fontawesome);

/* ---------- ERIC MEYER'S RESET CSS ---------- */
/* ---------- http://meyerweb.com/eric/tools/css/reset/ ---------- */

@import url(http://meyerweb.com/eric/tools/css/reset/reset.css);

/* ---------- FONTAWESOME ---------- */

[class*="fontawesome-"]:before {
  font-family: 'FontAwesome', sans-serif;
}

/* ---------- GENERAL ---------- */

body {
	background-color: #C0C0C0;
	color: #000;
	font-family: "Varela Round", Arial, Helvetica, sans-serif;
	font-size: 16px;
	line-height: 1.5em;
}

input {
	border: none;
	font-family: inherit;
	font-size: inherit;
	font-weight: inherit;
	line-height: inherit;
	-webkit-appearance: none;
}

/* ---------- LOGIN ---------- */

#login {
	margin: 50px auto;
	width: 400px;
}

#login h2 {
	background-color: #f95252;
	-webkit-border-radius: 20px 20px 0 0;
	-moz-border-radius: 20px 20px 0 0;
	border-radius: 20px 20px 0 0;
	color: #fff;
	font-size: 28px;
	padding: 20px 26px;
}

#login h2 span[class*="fontawesome-"] {
	margin-right: 14px;
}

#login fieldset {
	background-color: #fff;
	-webkit-border-radius: 0 0 20px 20px;
	-moz-border-radius: 0 0 20px 20px;
	border-radius: 0 0 20px 20px;
	padding: 20px 26px;
}

#login fieldset p {
	color: #777;
	margin-bottom: 5px;
}

#login fieldset p:last-child {
	margin-bottom: 0;
}

#login fieldset input {
	-webkit-border-radius: 3px;
	-moz-border-radius: 3px;
	border-radius: 3px;
}

#login fieldset .inputbox 
{
    /*[type="email"], #login fieldset input[type="password"]*/
	background-color: #eee;
	color: #777;
	padding: 4px 10px;
	width: 310px;
	height: 32px;
	border:1px solid #33cc77;
}

#login fieldset input[type="submit"] {
	background-color: #33cc77;
	color: #fff;
	display: block;
	margin: 0 auto;
	padding: 4px 0;
	width: 100px;
	height:40px;
	cursor:pointer;
}

#login fieldset input[type="submit"]:hover {
	background-color: #28ad63;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
        <h2>
            <span class="fontawesome-lock"></span>Sign In</h2>
        <fieldset>
            <p>
                <label for="email">
                    Username <span style="color: Red;">*</span></label></p>
            <p>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="inputbox"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                    ErrorMessage="Username is mandatory." SetFocusOnError="True" ValidationGroup="L"
                    Style="color: Red; font-size: 14px;">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    Display="Dynamic" ErrorMessage="Invalid Username format." SetFocusOnError="True"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="L"
                    Style="color: Red; font-size: 14px;">*</asp:RegularExpressionValidator>
                <!-- <input type="email" id="email" value="mail@address.com" onblur="if(this.value=='')this.value='mail@address.com'"
                    onfocus="if(this.value=='mail@address.com')this.value=''">-->
            </p>
            <!-- JS because of IE support; better: placeholder="mail@address.com" -->
            <p>
                <label for="password">
                    Password <span style="color: Red;">*</span>
                </label>
            </p>
            <p>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="inputbox" TextMode="Password" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password is mandatory." SetFocusOnError="True" ValidationGroup="L"
                    Style="color: Red; font-size: 14px;">*</asp:RequiredFieldValidator>
                <!--<input type="password" id="password" value="password" onblur="if(this.value=='')this.value='password'"
                    onfocus="if(this.value=='password')this.value=''">-->
            </p>
            <!-- JS because of IE support; better: placeholder="password" -->
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Sign In" OnClick="btnSubmit_Click"
                    ValidationGroup="L" />
                <!-- <input type="submit" value="Sign In">-->
            </p>
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
                                    <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="L" HeaderText="Errors:"
                                        ShowSummary="true" Style="color: Red; font-size: 14px;" />
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
        </fieldset>
    </div>
    <!-- end login -->
    </form>
</body>
</html>
