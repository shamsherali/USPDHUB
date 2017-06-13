<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToolsold.aspx.cs" Inherits="USPDHUB.OP.myyouthhubcom.AddToolsold" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=iso-8859-1">
    <title>My Youth Hub Features and Pricing</title>
    <link href="<%=Page.ResolveClientUrl("~/css/myhglobal.css")%>" rel="stylesheet" type="text/css" />
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/myhfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/myhfav.ico") %>"
        type="image/x-icon" />
    <link rel="Stylesheet" href="../../css/AppFeatures.css" type="text/css" />
    <csscriptdict import>
            <script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>
            <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
		</csscriptdict>
    <csactiondict>
			<script type="text/javascript"><!--
			    var preloadFlag = false;
			    function preloadImages() {
			        if (document.images) {
			            pre_facebook_over = newImage('../../images/MYHOuterImages/facebook_over.png');
			            pre_twitter_over = newImage('../../images/MYHOuterImages/twitter-over.png');
			            pre_sign_up_for_my_youth_hub_over = newImage('../../images/MYHOuterImages/sign-up-for-my-youth-hub_over.png');
			            preloadFlag = true;
			        }
			    }

			    $(document).ready(function () {
			        var sptext = $('#spdomain').text().toString().replace('##domain##', 'MyYouth Hub');
			        $('#spdomain').text(sptext);
			    });
            // --></script>
	</csactiondict>
</head>
<body onload="preloadImages();">
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="innerwrapper">
            <div id="banner">
                <div id="brand">
                    <img src="<%=Page.ResolveClientUrl("~/images/MYHOuterImages/my-youth-hub.png")%>"
                        alt="My Youth Hub" width="199" height="118" border="0" />
                </div>
                <div id="navspace">
                    <ul id="nav" class="list">
                        <li class="home"><a href="Default.aspx">Home</a></li>
                        <li class="contact"><a href="Contactus.aspx">Contact My Youth Hub</a></li>
                        <li class="featureslive"><a href="AddTools.aspx">Features of My Youth Hub</a></li>
                        <li class="about"><a href="aboutus.html">About My Youth Hub</a></li>
                        <li class="login"><a href="Login.aspx">Login to My Youth Hub</a></li>
                    </ul>
                    <!--nav-->
                </div>
            </div>
            <!--banner-->
            <div id="social">
                <%--<div align="right">
                    <a onmouseover="changeImages('facebook','<%=Page.ResolveClientUrl("~/images/MYHOuterImages/facebook_over.png")%>');return true"
                        onmouseout="changeImages('facebook','<%=Page.ResolveClientUrl("~/images/MYHOuterImages/facebook.png")%>');return true"
                        href="#">
                        <img id="facebook" src="<%=Page.ResolveClientUrl("~/images/MYHOuterImages/facebook.png")%>"
                            alt="" name="facebook" width="24" height="20" border="0"></a><a onmouseover="changeImages('twitter','<%=Page.ResolveClientUrl("~/images/MYHOuterImages/twitter-over.png")%>');return true"
                                onmouseout="changeImages('twitter','<%=Page.ResolveClientUrl("~/images/MYHOuterImages/twitter.png")%>');return true"
                                href="#"><img id="twitter" src="<%=Page.ResolveClientUrl("~/images/MYHOuterImages/twitter.png")%>"
                                    alt="" name="twitter" height="20" width="23" border="0"></a></div>--%>
            </div>
            <!--social-->
            <div id="container">
                <div id="content898">
                   
                </div>
                <!--content898-->
                <div id="col520fl">
                    <div>
                        <h1 align="center">
                             App Features</h1>
                        <div class="appfeatureswrap">
                            <div class="featuretablediv">
                                <div class="appfeaturerow appfeaturehead">
                                    <div>
                                    </div>
                                    <div class="fnt15">
                                        Basic
                                    </div>
                                    <div class="fnt15">
                                        Premium
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Pricing <span id="spdomain" style="font-size: 11px;">(Generic ##domain## App)</span><br />
                                          <span style="font-size: 11px;"> For App Store Publishing Fees See Below</span>
                                    </div>
                                    <div class="appfeaturehead">
                                        $55.00/mo.<br />
                                        $605.00/yr.
                                    </div>
                                    <div class="appfeaturehead">
                                        $165.00/mo.<br />
                                        $1,815.00/yr.
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Content Modules
                                    </div>
                                    <div>
                                        1 Incl.
                                    </div>
                                    <div>
                                        4 Incl.
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Push / Text Notifications</div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Receive Feedback (Tips) w/ Blocking
                                    </div>
                                    <div>
                                        1 Incl.
                                    </div>
                                    <div>
                                        2 Incl.
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Social Media Share / Social Button
                                    </div>
                                    <div>
                                        Manual
                                    </div>
                                    <div>
                                        Auto
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Customizable App Display</div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Call Button</div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Desktop & Web Widgets / Resources</div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Free Live Chat and Phone Support</div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Multiple Logins w/ Admin Permissions
                                    </div>
                                    <div>
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Surveys and Polls</div>
                                    <div>
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Event Calendar</div>
                                    <div>
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Web Links Module
                                    </div>
                                    <div>
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Image Gallery</div>
                                    <div>
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Scheduling for All Modules</div>
                                    <div>
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Contacts Module w/ Email (Reports)
                                    </div>
                                    <div>
                                    </div>
                                    <div>
                                        <img src="../../images/OuterImages/check.png" />
                                    </div>
                                </div>
                            </div>
                            <div class="featuretablediv appfeaturehead upgradeappprice">
                                <div class="featuretablediv">
                                    UPGRADE YOUR APP - Brand and Publish in 3 App Stores</div>
                            </div>
                            <div class="featuretablediv">
                                <div class="appfeaturerow">
                                    <div>
                                        One-time Publishing Fee
                                    </div>
                                    <div class="appfeaturehead">
                                        $500.00
                                    </div>
                                    <div class="appfeaturehead">
                                        $500.00
                                    </div>
                                </div>
                                <div class="appfeaturerow">
                                    <div>
                                        Branded App Maintenance Fee<br />
                                        <span style="font-size: 11px;">(Publishing Fee for Ongoing App Store Updates)</span>
                                    </div>
                                    <div class="appfeaturehead">
                                        $15.00/mo.
                                    </div>
                                    <div class="appfeaturehead">
                                        $15.00/mo.
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="text-align: center; margin-top: 5px; font-weight: bold;">
                        Your App is listed as a Favorite in the<br />
                        MyYouth Hub App
                    </div>
                </div>
                <div id="contentleft300" style="margin-top: 65px;">
                    <div align="center">
                        <h3>
                            A Mobile App to
                        </h3>
                        <div style="font-family: Arial, Helvetica, sans-serif; font-size: 20px; font-weight: bold;
                            line-height: normal; margin: 8px 0; text-align: center;">
                            connect with your audience</div>
                        <div align="center">
                            <div style="font-size: 20px; font-weight: bold; text-align: center; font-family: Arial, Helvetica, sans-serif;">
                                Published on:
                            </div>
                        </div>
                        <div>
                            <div style="width: 220px;">
                                <div class="not2">
                                    <img src="/images/TVOuterImages/android_icon.png" /><br />
                                    <span>Android</span>
                                </div>
                                <div class="not2">
                                    <img src="/images/TVOuterImages/apple_icon.png" /><br />
                                    <span>iPhone</span>
                                </div>
                                <div class="not2">
                                    <img src="/images/TVOuterImages/windows_icon.png" /><br />
                                    <span>Windows</span>
                                </div>
                            </div>
                        </div>
                        <div>
                            <a onmouseover="changeImages('button_signup','<%=Page.ResolveClientUrl("~/images/MYHOuterImages/sign-up-for-my-youth-hub_over.png")%>');return true"
                                onmouseout="changeImages('button_signup','<%=Page.ResolveClientUrl("~/images/MYHOuterImages/sign-up-for-my-youth-hub.png")%>');return true"
                                href="<%=Page.ResolveClientUrl("~/OP/myyouthhubcom/AgencyListing.aspx")%>">
                                <img id="button_signup" src="<%=Page.ResolveClientUrl("~/images/MYHOuterImages/sign-up-for-my-youth-hub.png")%>"
                                    alt="" name="sign_up_for_my_youth_hub" class="signup1" width="133" height="70"
                                    border="0"></a>
                        </div>
                        <div class="clear">
                        </div>
                        <div style="font-weight: bold; text-align: center; font-family: Arial, Helvetica, sans-serif;
                            font-size: 18px;">
                            Have Your App<br />
                            Published in the
                            <br />
                            App Stores Branded<br />
                            with Your Name and
                            <br />
                            Logo
                        </div>
                        <div style="padding: 10px; text-align: Center; font-family: Arial, Helvetica, sans-serif;
                            font-size: 15px;">
                            <b>One Time<br />
                                Publishing Fee $500.00<br />
                                Plus $15.00 per month</b><br />
                        </div>
                    </div>
                    <!--contentright300-->
                </div>
                <!--contentright300-->
            </div>
            <!--innerwrapper-->
        </div>
    </div>
    </form>
</body>
</html>
