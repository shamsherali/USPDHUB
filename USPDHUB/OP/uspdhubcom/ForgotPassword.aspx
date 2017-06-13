<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="USPDHUB.OP.uspdhubcom.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile App for Law Enforcement, Community Outreach, Police App & Agency App from
        USPDhub.com</title>
    <link href="<%=Page.ResolveClientUrl("~/css/uspdhubglobal.css")%>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r;
            i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date();
            a = s.createElement(o),
                m = s.getElementsByTagName(o)[0];
            a.async = 1;
            a.src = g;
            m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-40935673-1', 'uspdhub.com');
        ga('send', 'pageview');
    </script>
    <csscriptdict import>
			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>
    </csscriptdict>
    <csactiondict>
	<script type="text/javascript"><!--
	    var preloadFlag = false;
	    function preloadImages() {
	        if (document.images) {
	            pre_social_facebook_over = newImage('../../images/UspdOuterImages/facebook-over.png');
	            pre_social_twitter_over = newImage('../../images/UspdOuterImages/twitter-over.png');
	            pre_button_signup_over = newImage('../../images/UspdOuterImages/signup-over.png');
	            preloadFlag = true;
	        }
	    }

    // --></script>
    </csactiondict>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="innerwrapper">
            <div id="banner">
                <div id="brand">
                    <a href="Default.aspx">
                        <img src="../../images/UspdOuterImages/uspd-hub.png" alt="USPD hub branded app" width="251"
                            height="192" border="0"></a></div>
                <!--brand-->
                <div id="bannerright">
                    <div id="social">
                        <a onmouseover="changeImages('facebook','../../images/UspdOuterImages/facebook-over.png');return true"
                            onmouseout="changeImages('facebook','../../images/UspdOuterImages/facebook.png');return true"
                            href="https://www.facebook.com/Uspdhub" target="_blank">
                            <img id="facebook" src="../../images/UspdOuterImages/facebook.png" alt="USPDhub Facebook"
                                name="facebook" width="19" height="40" border="0"></a><a onmouseover="changeImages('twitter','../../images/UspdOuterImages/twitter-over.png');return true"
                                    onmouseout="changeImages('twitter','../../images/UspdOuterImages/twitter.png');return true"
                                    href="https://twitter.com/USPDHub" target="_blank"><img id="twitter" src="../../images/UspdOuterImages/twitter.png"
                                        alt="USPDhub Twitter" name="twitter" height="40" width="28" border="0"></a>
                    </div>
                    <!--social-->
                    <div id="navigation">
                        <ul id="nav">
                            <li class="home"><a href="Default.aspx">Home</a></li>
                            <li class="contact"><a href="Contactus.aspx">Contact USPDhub</a></li>
                            <li class="pricing"><a href="AddTools.aspx">USPDhub Features and Pricing</a></li>
                            <li class="about"><a href="aboutus.html">About USPDhub</a></li>
                            <li class="login"><a href="Login.aspx">Login</a></li>
                        </ul>
                        <!--nav-->
                    </div>
                    <!--navigation-->
                    <div id="signup">
                    </div>
                    <div id="logictree">
                        <a href="http://logictreeit.com" target="_blank">
                            <img src="../../images/UspdOuterImages/logictree-it.png" alt="Powered by LogicTree IT"
                                width="205" height="50" border="0"></a></div>
                </div>
                <!--bannerright-->
            </div>
            <!--banner-->
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
            <!--container-->
            <div id="footer" style="margin-top: 25px;">
                <p>
                    <a href="http://logictreeit.com" target="_blank">A Product of LogicTree IT</a> |
                    <a href="terms.html" target="_blank">Terms of Service</a></p>
            </div>
            <!--footer-->
        </div>
        <!--innerwrapper-->
    </div>
    <!--wrapper-->
    </form>
</body>
</html>
