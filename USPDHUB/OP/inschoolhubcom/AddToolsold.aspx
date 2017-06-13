<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToolsold.aspx.cs" Inherits="USPDHUB.OP.inschoolhubcom.AddToolsold" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolHub.com
    </title>
    <link href="<%=Page.ResolveClientUrl("~/css/ishglobal.css")%>" rel="stylesheet" type="text/css"
        media="all">
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>"
        type="image/x-icon" />
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
    <csscriptdict import>
			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>
    </csscriptdict>
    <csactiondict>
	<script type="text/javascript"><!--
	    var preloadFlag = false;
	    function preloadImages() {
	        if (document.images) {
	            pre_social_facebook_over = newImage('../../images/ISHOuterImages/social-facebook-over.gif');
	            pre_social_twitter_over = newImage('../../images/ISHOuterImages/social-twitter-over.gif');
	            pre_button_signup_over = newImage('../../images/ISHOuterImages/button-signup-over.jpg');
	            preloadFlag = true;
	        }
	    }

// --></script>
</csactiondict>
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
    <form id="frm1" runat="server">
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
                                    Features</a> | <a href="Javascript:void(0);" class="active">Pricing</a> | <a href="aboutus.html">
                                        About Us</a> | <a href="login.aspx">Login</a>
                                <%--<a onmouseover="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook-over.gif")%>');return true"
                                            onmouseout="changeImages('social_facebook','/images/ISHOuterImages/social-facebook.gif');return true"
                                            href="https://www.facebook.com/UspDhub" target="_blank">
                                            <img id="social_facebook" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>"
                                                alt="InSchoolHub Facebook" name="social_facebook" width="30" height="33" align="absmiddle"
                                                border="0"></a>--%><a onmouseover="changeImages('social_twitter','/images/ISHOuterImages/social-twitter-over.gif');return true"
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
        <div id="content">
            <div class="left">
                <h1>
                    PRICING<br />
                    <img src="/images/ISHOuterImages/headline-dots.gif" alt="" width="386" height="20"
                        border="0"></h1>
            </div>
            <div class="contentblock">
                <div class="contentblock">
                    <div style="width: 420px; float: left;">
                        <h1>
                            Two Way communication</h1>
                        <h2>
                            for schools</h2>
                        <h3>
                            Available for</h3>
                    </div>
                    <div class="not1">
                        <img src="/images/ISHOuterImages/androidimg.png" width="120" height="120"><br>
                        <span>Android</span></div>
                    <div class="not1">
                        <img src="/images/ISHOuterImages/iphoneimg.png" width="120" height="120"><br>
                        <span>iPhone</span></div>
                    <div class="not1">
                        <img src="/images/ISHOuterImages/windowsimg.png" width="120" height="120"><br>
                        <span>Windows</span></div>
                    <div class="clear">
                    </div>
                    <br />
                    <br />
                    <div class="price">
                        $799<span>/year OR</span> $76.00<span>/month</span>
                        <p>
                            <a onmouseover="changeImages('button_signup','/images/ISHOuterImages/button-signup-over.jpg');return true"
                                onmouseout="changeImages('button_signup','/images/ISHOuterImages/button-signup.jpg');return true"
                                href="AgencyListing.aspx">
                                <img id="button_signup" src="/images/ISHOuterImages/button-signup.jpg" alt="" name="button_signup"
                                    border="0"></a>
                        </p>
                    </div>
                    <div class="brandapp" style="margin-left: 20px; margin-top: 5px; margin-bottom: 5px;
                        font-size: 16px; color: #020000; font-family: Arial, Helvetica, sans-serif;">
                        <b>Plus $750.00</b><br />
                        <span>One Time Set Up Fee</span>
                    </div>
                    <br />
                    <div class="signup1">
                        For information on becoming a <span>Sponsor</span> of the inSchoolHub
                        <br />
                        for schools in your community, <a href="/ISH/sponsor.html" target="_blank"><span>learn
                            more</span></a> or call us at 800-281-0263</div>
                    <br />
                </div>
            </div>
            <div id="pricingcol2">
                <img src="/images/ISHOuterImages/pricing-photo1.jpg" width="418" height="422">
            </div>
        </div>
        <!--container-->
    </div>
    <!--mainwrapper-->
    <!--Footer-->
    <div id="footerwrap">4
        <div id="footer">
            <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a>
            &nbsp;&nbsp;&nbsp;<a href="terms.html" target="_blank">Terms of Service</a>
        </div>
    </div>
    <!--End Footer-->
    </form>
</body>
</html>
