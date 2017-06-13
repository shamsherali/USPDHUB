<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="USPDHUB.OP.inschoolhubin.Login" %>

<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolHub.com
    </title>
    <link href="<%=Page.ResolveClientUrl("~/css/ishglobal.css")%>" rel="stylesheet" type="text/css"
        media="all">
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>"
        type="image/x-icon" />
    <meta name="author" content="InSchoolhub.com Team" />
    <meta name="description" content="InSchoolhub is a software platform that provides a proven System and the Tools to Simplify Communication and Online Marketing." />
    <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
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
    <csscriptdict import>			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>    </csscriptdict>
    <csactiondict>	<script type="text/javascript"><!--
	    var preloadFlag = false;
	    function preloadImages() {
	        if (document.images) {
	            pre_social_facebook_over = newImage('../../images/ISHOuterImages/social-facebook-over.gif');
	            pre_social_twitter_over = newImage('../../images/ISHOuterImages/social-twitter-over.gif');
	            pre_button_signup_over = newImage('../../images/ISHOuterImages/button-signup-over.jpg');
	            preloadFlag = true;
	        }
	    }// --></script>
</csactiondict>
</head>
<body onload="preloadImages();">
    <form id="form1" runat="server">
    <div id="mainwrapper">
        <div id="container">
            <div id="bannersecondary">
                <div id="bannerleft">
                    <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/ihs-logo.png")%>" alt="InSchoolHub"
                        width="227" height="123" border="0"></div>
                <!--bannerleft-->
                <div id="rightcol">
                    <div id="navigation">
                        <div align="right">
                            <p>
                                <a href="Default.aspx">Home</a> | <a href="ContactUs.aspx">Contact Us</a> | <a href="features.html">
                                    Features</a> | <a href="AddTools.aspx">Pricing</a> | <a href="aboutus.html">About Us</a>
                                | <a href="Javascript:void(0);" class="active">Login</a> <%--<a onmouseover="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook-over.gif")%>');return true"
                                    onmouseout="changeImages('social_facebook','/images/ISHOuterImages/social-facebook.gif');return true"
                                    href="https://www.facebook.com/UspDhub" target="_blank">
                                    <img id="social_facebook" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>"
                                        alt="InSchoolHub Facebook" name="social_facebook" width="30" height="33" align="absmiddle"
                                        border="0"></a><a onmouseover="changeImages('social_twitter','/images/ISHOuterImages/social-twitter-over.gif');return true"
                                            onmouseout="changeImages('social_twitter','/images/ISHOuterImages/social-twitter.gif');return true"
                                            href="https://twitter.com/USPDHub" target="_blank"><img id="social_twitter" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter.gif")%>"
                                                alt="InSchoolHub Twitter" name="social_twitter" width="28" height="33" align="absmiddle"
                                                border="0"></a>--%></p>
                        </div>
                    </div>
                    <!--navigation-->
                </div>
                <!--bannerright-->
            </div>
            <!--bannersecondary-->
        </div>
        <div id="content">
            <div class="left">
                <h1>
                    LOGIN<br />
                    <img src="/images/ISHOuterImages/headline-dots.gif" alt="" width="386" height="20"
                        border="0"></h1>
            </div>
            <div id="login">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <!--Start Loginpage logic-->
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="font-size: 14px; color: Red;">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 0px;" align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 294px;">
                                <tr>
                                    <td valign="top" align="center">
                                        <uc1:Login ID="loginbox" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!--End Loginpage logic--->
                </table>
            </div>
        </div>
    </div>
    <!--Footer-->
    <div id="footerwrap">
        <div id="footer">
            <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a> &nbsp;&nbsp;&nbsp;<a href="terms.html"
                target="_blank">Terms of Service</a>
        </div>
    </div>
    <!--End Footer-->
    </form>
</body>
</html>