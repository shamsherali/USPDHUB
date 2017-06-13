<%@ Page Language="C#" AutoEventWireup="true" Inherits="ForgotPassword" CodeBehind="ForgotPassword.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Mobile App for Law Enforcement, Community Outreach, Police App & Agency App from
        USPDhub.com</title>
    <link href="<%=Page.ResolveClientUrl("~/css/global.css")%> rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--Header starts-->
    <div id="header">
        <div class="menu_top">
            <div class="container">
                <div class="navwrap">
                    <div class="nav">
                        <ul>
                            <li><a href="default.aspx">Home</a></li>
                            <li><a href="Javascript:void(0);" class="active">Contact Us</a></li>
                            <li><a href="<%=RootPath %>/OP/uspdhubcom/AddTools.aspx">Pricing</a></li>
                            <li><a href="aboutus.html">About Us</a></li>
                            <li><a href="login.aspx">Login</a></li>
                        </ul>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div id="bannerwrap">
            <div class="bg_colorwrap">
                <div class="banner" align="center">
                    <img src="images/Homepage/banner_1000.jpg" />
                </div>
            </div>
        </div>
        <div class="shadow_banner">
        </div>
    </div>
    <div class="clear">
    </div>
    <!--Header ends-->
    <div id="contentwrap">
        <div id="content">
            <div class="failed">
            </div>
            <div class="error">
            </div>
            <div id="login">
                <div class="formwrap">
                    <h2 style="text-align: center">
                        Forgot Password</h2>
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
                            Font-Size="X-Small" ErrorMessage="Username is mandatory." Display="Dynamic"
                            ValidationGroup="F">*</asp:RequiredFieldValidator>
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
                        runat="server" Text="Cancel" CausesValidation="false" TabIndex="20" OnClick="btnCancel_Click" /></div>
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
            <br />
            <br />
            <div class="clear40">
            </div>
        </div>
        <div class="bottombrdr">
        </div>
        <div class="clear40">
        </div>
    </div>
    <div id="menu">
        <div id="footer">
            <div class="copyrights">
                A Product of LogicTree IT</div>
            <div class="footerlinks">
                <%--<a href="javascript:void(0);">Privacy Policy</a> | --%><a href="Terms.html" target="_blank">
                    Terms of Service</a></div>
            <div class="snwrap">
                <div class="followus">
                    Follow us on</div>
                <div class="sn1">
                    <ul>
                        <li><a href="https://twitter.com/USPDHub" target="_blank">
                            <img src="images/Homepage/twit.png" alt="Twitter" title="Twitter" /></a></li>
                        <li><a href="https://www.facebook.com/UspDhub" target="_blank">
                            <img src="images/Homepage/fb.png" alt="Facebook" title="Facebook" /></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
