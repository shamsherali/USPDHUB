<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="USPDHUB.OP.uspdhubcom.Login" %>

<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Mobile App for Law Enforcement, Community Outreach, Police App & Agency App from
        USPDhub.com </title>
    <meta name="author" content="USPDhub.com Team" />
    <meta name="description" content="USPDhub is a software platform that provides a proven System and the Tools to Simplify Communication and Online Marketing." />
    <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
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
                            <li class="loginlive"><a href="javascript:void(0);">Login</a></li>
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
            <div id="container">
                <div align="center" id="login">
                    <h1>
                        Login to USPDhub</h1>
                    <p>
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
                    </p>
                </div>
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
