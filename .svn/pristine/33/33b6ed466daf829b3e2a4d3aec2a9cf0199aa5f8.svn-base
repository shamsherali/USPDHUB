<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="USPDHUB.OP.inschoolalertcom.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolAlert.com
    </title>
    <link href="<%=Page.ResolveClientUrl("~/css/isaglobal.css")%>" rel="stylesheet" type="text/css"
        media="all">
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>"
        type="image/x-icon" />
    <link href="<%=Page.ResolveClientUrl("~/css/bootstrap.css")%>" rel="stylesheet">
    <link href="<%=Page.ResolveClientUrl("~/css/custom.css")%>" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid no-padding">
        <header>
            <div class="container">
                <div class="logo"><img src="<%=Page.ResolveClientUrl("~/images/ISAOuterImages/isa-logo.png")%>" alt="InSchoolAlert"></div>
                <div class="top-btn-right" id="navigation">
                    <a href="Default.aspx">Home</a> | <a href="HowToWorks.aspx">
                                        How It Works</a> | <a href="features.html">Pricing</a> | <a href="AboutUs.html">About Us</a>
                                    | <a href="Login.aspx" class="btn btn-green">Sign In</a>
                </div>
            </div>
        </header>
    </div>
    <div id="content">
        <div class="left loginheader">
            <h1 style="text-align:center;">
                FORGOT PASSWORD<br />
                <img src="/images/ISHOuterImages/headline-dots.gif" alt="" width="386" height="20"
                    border="0"></h1>
        </div>
        <div id="login">
            <h2>
            </h2>
            <div class="formwrap">
                <div class="label1">
                    <span class="errormsg">&nbsp;</span>&nbsp;First Name:</div>
                <div class="txtfild1wrap">
                    <asp:TextBox ID="txtRFirstname" runat="server" CssClass="txtfild1" TabIndex="1"></asp:TextBox></div>
                <div class="clear15">
                </div>
                <div class="label1">
                    <span class="errormsg">&nbsp;</span>&nbsp;Last Name:</div>
                <div class="txtfild1wrap">
                    <asp:TextBox ID="txtRlastname" runat="server" CssClass="txtfild1" TabIndex="2"></asp:TextBox></div>
                <div class="clear15">
                </div>
                <div class="label1">
                    <span class="errormsg">* </span>Username:</div>
                <div class="txtfild1wrap" style="width: 280px;">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtfild1" TabIndex="3"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                        Font-Size="X-Small" ErrorMessage="Username is mandatory." Display="Dynamic" ValidationGroup="F">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Font-Size="X-Small"
                        ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        Display="Dynamic" ValidationGroup="F">*</asp:RegularExpressionValidator><br />
                    <span class="label1" style="padding: 0px;">(myname@example.com)</span></div>
                <div class="clear15">
                </div>
            </div>
            <div class="submit1">
                <asp:ImageButton ID="Button1" ImageUrl="~/images/OuterImages/request.gif" runat="server"
                    Text="Request Password" OnClick="Sent_Password" TabIndex="19" Height="30px" ValidationGroup="F" />&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="Button2" Height="30px" ImageUrl="~/images/OuterImages/cancel.gif"
                    runat="server" Text="Cancel" CausesValidation="false" TabIndex="20" OnClick="btnCancel_Click" />
            </div>
            <div class="clear15">
            </div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="loginbg">
                <tr>
                    <td class="loginbg-mid">
                        <table width="100%" border="0" cellspacing="3" cellpadding="3" style="font-size: 12px;">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left" style="padding-left: 25px;">
                                    <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="F" HeaderText="Errors:"
                                        ShowSummary="true" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <footer>
        <div class="container">
            <div class="footer-text">LogicTree IT Solutions Inc.  |   6060 Sunrise Vista Drive, Suite 3500  |  Citrus Heights, CA 95610</div>
            <div class="footer-text margintop10"><a href="mailto:info@logictreeit.com">Info@LogicTreeIT.com</a> | <a href="http://www.logictreeit.com" target="_blank">www.logictreeit.com</a>  |  800.281.0263</div>
        </div>
     </footer>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js" type="text/javascript"></script>
    </form>
</body>
</html>
