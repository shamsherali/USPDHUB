<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="USPDHUB.OP.inschoolhubin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolHub.in
    </title>
    <link href="<%=Page.ResolveClientUrl("~/css/ishglobal.css")%>" rel="stylesheet" type="text/css"
        media="all">
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>"
        type="image/x-icon" />
    <script src="<%=Page.ResolveClientUrl("~/scripts/jquery.min.js")%>" type="text/javascript"></script>
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
    <!--mainwrapper-->
    <div id="mainwrapper">
        <div id="container">
            <div id="banner">
                <div id="bannerleft">
                    <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/ihs-logo.png")%>" alt="InSchoolHub"
                        width="227" height="123" border="0"></div>
                <!--bannerleft-->
                <div id="bannerright">
                    <div id="navigation">
                        <div align="right">
                            <p>
                                <a href="Javascript:void(0);" class="active">Home</a> | <a href="contactus.aspx">Contact
                                    Us</a> | <a href="features.html">Features</a> | <a href="AddTools.aspx">Pricing</a>
                                | <a href="aboutus.html">About Us</a> | <a href="login.aspx">Login</a>
                                <%--<a onmouseover="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook-over.gif")%>');return true"
                                    onmouseout="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>');return true"
                                    href="https://www.facebook.com/UspDhub" target="_blank">
                                    <img id="social_facebook" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>"
                                        alt="InSchoolHub Facebook" name="social_facebook" width="30" height="33" align="absmiddle"
                                        border="0"></a><a onmouseover="changeImages('social_twitter','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter-over.gif")%>');return true"
                                            onmouseout="changeImages('social_twitter','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter.gif")%>');return true"
                                            href="https://twitter.com/USPDHub" target="_blank"><img id="social_twitter" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter.gif")%>"
                                                alt="InSchoolHub Twitter" name="social_twitter" width="28" height="33" align="absmiddle"
                                                border="0"></a>--%></p>
                        </div>
                    </div>
                    <!--navigation-->
                    <%-- <div id="schoollist">
                    </div>--%>
                    <!--school list scroll area-->
                </div>
                <!--bannerright-->
            </div>
            <!--banner-->
            <div id="homeleft">
                <p>
                    <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/home-banner-left.jpg")%>"
                        alt="inSchoolHub user photo" width="504" height="259" border="0"></p>
                <h1>
                    Mobilizing Community Outreach<br />
                    for Greater School Safety</h1>
                <p>
                    Introducing a ground-breaking community outreach tool for today&rsquo;s schools.
                    inSchoolHub provides current and critical two-way communication between faculty
                    and the community that will help to improve safety and public relations.</p>
                <div class="not-heading">
                    Available for download on:
                    <br />
                    <br />
                    <div class="not1">
                        <a href="https://play.google.com/store/apps/details?id=com.logictree.inschoolhub&hl=en"
                            target="_blank">
                            <img src="<%=Page.ResolveClientUrl("~/images/Homepage/android.png")%>" width="51"
                                height="47" border="0" />
                            <br />
                            <span>Android</span></a></div>
                    <div class="not1">
                        <a href="https://itunes.apple.com/us/app/inschoolhub/id698109267?mt=8" target="_blank">
                            <img src="<%=Page.ResolveClientUrl("~/images/Homepage/apple.png")%>" width="51" height="47"
                                border="0" />
                            <br />
                            <span>Apple</span></a></div>
                    <div class="not1">
                        <a href="http://www.windowsphone.com/en-in/search?q=inschoolhub" target="_blank">
                            <img src="<%=Page.ResolveClientUrl("~/images/Homepage/windows.png")%>" width="51"
                                height="47" border="0" /><br />
                            <span>Windows</span></a></div>
                    <div class="clear10">
                    </div>
                </div>
            </div>
            <!--homeleft-->
            <div id="homecenter">
                <div id="phone">
                    <div id="wowslider-container1">
                        <div class="ws_images">
                            <ul>
                                <li>
                                    <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/splash.png")%>" alt="scroll1"
                                        id="Img1" /></li>
                                <li>
                                    <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/hub.png")%>" alt="scroll2"
                                        id="Img2" /></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div id="signupbutton">
                    <div align="center">
                        <a onmouseover="changeImages('button_signup','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/button-signup-over.jpg")%>');return
                true" onmouseout="changeImages('button_signup','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/button-signup.jpg")%>');return
                true" href="<%=Page.ResolveClientUrl("~/OP/inschoolhubin/AgencyListing.aspx")%>">
                            <img id="button_signup" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/button-signup.jpg")%>"
                                alt="" name="button_signup" width="116" height="30" border="0"></a></div>
                </div>
            </div>
            <!--homecenter-->
            <div id="homeright">
                <p>
                    <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/home-banner-right.jpg")%>"
                        alt="inSchoolHub user photo" width="170" height="255" border="0">
                </p>
                <div align="center" style="margin-top: 170px;">
                    <a class="myvideo" target="_blank" href="<%=Page.ResolveClientUrl("~/ISH/Default.html")%>"></a>
                </div>
            </div>
            <!--homeright-->
        </div>
        <!--container-->
        <div id="midwrapper">
            <div id="container">
                <div id="column435left">
                    <h2>
                        <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/checkbox.png")%>" alt=""
                            height="27" width="29" align="absmiddle" border="0">Push Notifications</h2>
                    <p>
                        Use Push Notifications to share important information immediately to the mobile
                        devices of parents and caregivers, keeping them apprised, in real time, of current
                        and developing situations.</p>
                    <h2>
                        <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/checkbox.png")%>" alt=""
                            height="27" width="29" align="absmiddle" border="0">
                        Update Community</h2>
                    <p>
                        Keep families informed of the various day-to-day activities on your campus through
                        the regular posting of Bulletins and Updates.</p>
                    <h2>
                        <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/checkbox.png")%>" alt=""
                            height="27" width="29" align="absmiddle" border="0">Event Calendar</h2>
                    <p>
                        Use the Event Calendar to keep families aware of scheduled activities on your campus,
                        as well as district-wide events of interest.</p>
                </div>
                <!--column435left-->
                <!--column435right-->
                <div id="column435right">
                    <h2>
                        <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/checkbox.png")%>" alt=""
                            height="27" width="29" align="absmiddle" border="0">
                        Receive Feedback</h2>
                    <p>
                        With the simple touch of a button the app will display a form that allows users
                        to share potentially vital information with school administrators, anonymously if
                        that is what the sender prefers.</p>
                    <h2>
                        <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/checkbox.png")%>" alt=""
                            height="27" width="29" align="absmiddle" border="0">
                        Contact Us</h2>
                    <p>
                        The Contact Us button gives the user a means to easily send questions and comments,
                        further expanding lines of communication and strengthening the relationship between
                        schools and the neighborhoods they serve.</p>
                    <h2>
                        <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/checkbox.png")%>" alt=""
                            height="27" width="29" align="absmiddle" border="0">One Touch Call Button</h2>
                    <p>
                        The App also features a Call button, making it easy to reach the front office with
                        a single touch.</p>
                </div>
            </div>
        </div>
        <div id="container">
        </div>
    </div>
    <!--End mainwrapper-->
    <!--Footer-->
    <div id="footerwrap">
        <div id="footer">
            <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a>
            &nbsp;&nbsp;&nbsp;<a href="terms.html" target="_blank">Terms of Service</a>
        </div>
    </div>
    <!--End Footer-->
    </form>
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/scripts/wowslider.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/scripts/script.js")%>"></script>
</body>
</html>
