<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpGuide.aspx.cs" Inherits="USPDHUB.OP.inschoolhubcom.HelpGuide" %>

<%@ Register Src="~/Controls/HelpControl.ascx" TagName="HelpControl" TagPrefix="hca" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Help Guide</title>
    <link href="<%=Page.ResolveClientUrl("~/css/ishglobal.css")%>" rel="stylesheet" type="text/css"
        media="all">
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>"
        type="image/x-icon" />
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
    <meta name="author" content="USPDhub.com Team" />
    <meta name="description" content="Contact USPDhub.com and know about best Online Marketing Systems, Email Marketing Softwares and Online Marketing tools available in the market." />
    <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-40935673-1', 'uspdhub.com');
        ga('send', 'pageview');

    </script>
</head>
<body onload="preloadImages();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
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
                                    Featues & Pricing</a> | <a href="aboutus.html">About Us</a> | <a href="login.aspx">Login</a><a
                                        onmouseover="changeImages('social_twitter','/images/ISHOuterImages/social-twitter-over.gif');return true"
                                        onmouseout="changeImages('social_twitter','/images/ISHOuterImages/social-twitter.gif');return true"
                                        href="https://twitter.com/inSchoolHub" target="_blank"><img id="social_twitter" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter.gif")%>"
                                            alt="InSchoolHub Twitter" name="social_twitter" width="28" height="33" align="absmiddle"
                                            border="0"></a></p>
                        </div>
                    </div>
                    <!--navigation-->
                </div>
                <!--bannerright-->
            </div>
            <!--bannersecondary-->
        </div>
        <div id="content" style="width: 650px; margin:0px auto;">
            <div style="background-color: #F0F3F4;">
                <div id="columnleft" style="margin-left: 10px; text-align:left;">
                    <h1>
                        Help</h1>
                </div>
                <hca:HelpControl runat="server" ID="UserHelpCtrl" />
            </div>
        </div>
    </div>
    <!--Footer-->
    <div id="footerwrap">
        <div id="footer">
            <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a>
            &nbsp;&nbsp;&nbsp;<a href="terms.html" target="_blank">Terms of Service</a>
        </div>
    </div>
    <!--End Footer-->
    </form>
</body>
</html>
