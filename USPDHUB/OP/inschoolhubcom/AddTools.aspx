<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTools.aspx.cs" Inherits="USPDHUB.OP.inschoolhubcom.AddTools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="viewport" content="width=device-width, user-scalable=no" />
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolHub.com
    </title>
    <link href="<%=Page.ResolveClientUrl("~/css/ishglobal.css")%>" rel="stylesheet" type="text/css"
        media="all">
    <link href="<%=Page.ResolveClientUrl("~/css/futurepricinginschool.css")%>" rel="stylesheet"
        type="text/css" />
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>"
        type="image/x-icon" />
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
<body>
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
                                <a href="Default.aspx">Home</a> | <a href="ContactUs.aspx">Contact Us</a> | <a href="Javascript:void(0);"
                                    class="active">Features & Pricing</a> | <a href="aboutus.html">About Us</a>
                                | <a href="login.aspx">Login</a><a onmouseover="changeImages('social_twitter','/images/ISHOuterImages/social-twitter-over.gif');return true"
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
        <div id="content" class="pricingplan-page">
            <div class="col-md-12">
                <h4 class="text-center">
                    A Mobile App to connect with your community</h4>
            </div>
            <div class="plans">
                <p style="color: #56aaff; font-weight: bold; font-size: 13px;">
                    One month free with annual payment</p>
                <div class="plan">
                    <div style="height: 14px;">
                    </div>
                    <h2 class="plan-title">
                        Basic</h2>
                    <p class="plan-price" style="margin-bottom: 2px !important;">
                        <span>$70.00/mo.</span></p>
                    <center>
                        <b>+</b></center>
                    <div class="publish">
                        <span>$500.00</span>
                    </div>
                    <div class="publishtext">
                        (One-time Publishing Fee)
                    </div>
                    <br />
                    <div style="height: 25px;">
                    </div>
                    <p>
                        <img src="../../Images/UspdOuterImages/InSchoolBasic.png" />
                    </p>
                    <ul class="plan-features">
                        <li>Branding with Your Name and Logo Published in App Stores</li>
                        <li>
                            <img src="../../Images/UspdOuterImages/inschoolalertlogo.png" />
                            <span style="vertical-align: top;">Private Call/Msg Directory</span></li>
                        <li>Content Modules - 3 Incl.</li>
                        <li>SmartConnect Module</li>
                        <li>Social Media Share Manual / Social Button</li>
                        <li>Push / Text Notifications</li>
                        <li>Customizable App Display</li>
                        <li>Call Button</li>
                        <li>Desktop & Web Widgets / Resources</li>
                         <li>Free Live Chat and Phone Support</li>
                    </ul>
                     <div style="height:18px;">
                    </div>
                    <asp:LinkButton ID="lnkBasic" runat="server" class="plan-button" Text="Subscribe"
                        OnClick="lnkSubscription_Click" CommandArgument="/eAPjDwv/dw=" Style="text-decoration: none !important;"></asp:LinkButton>
                </div>
                <div class="plan plan-tall">
                    <p class="thrown">
                        <img src="../../images/UspdOuterImages/thrown.png" />
                        Popular</p>
                    <h2 class="plan-title">
                        Premium</h2>
                    <p class="plan-price" style="margin-bottom: 2px;">
                        <span>$180.00/mo.</span></p>
                    <center>
                        <b>+</b></center>
                    <div class="publish">
                        <span>$500.00</span>
                    </div>
                    <div class="publishtext">
                        (One-time Publishing Fee)
                    </div>
                    <br />
                    <div style="height: 24px;">
                    </div>
                    <p>
                        <img src="../../Images/UspdOuterImages/InSchoolPremium.png" />
                    </p>
                    <span class="basicalign">Basic +</span>
                    <ul class="plan-features">
                        <li>Multiple Logins w/ Admin Permissions</li>
                        <li>Surveys and Polls</li>
                        <li>Event Calendar</li>
                        <li>Web Links Module</li>
                        <li>Image Gallery</li>
                        <li>Scheduling for All Modules</li>
                        <li>Email Contacts and Campaign Reports</li>
                        <li>1 Additional Content Module</li>
                    </ul>
                    <div style="height: 99px;">
                    </div>
                    <asp:LinkButton ID="lnkPremium" runat="server" class="plan-button" Text="Subscribe"
                        OnClick="lnkSubscription_Click" CommandArgument="wjuMKXgX6lw=" Style="text-decoration: none !important;"></asp:LinkButton>
                </div>
                <div class="plan">
                    <div style="height: 20px;">
                    </div>
                    <h2 class="plan-title">
                   Select your Features</h2>
                    <p class="plan-price" style="margin-bottom: 3px;">
                        <span>$55.00/mo.</span>
                    </p>
                    <div style="height: 37px;">
                    </div>
                    <div class="publishtext">
                        Select the features and functions that fit your school's needs
                    </div>
                    <br />
                    <p>
                        <img src="../../Images/UspdOuterImages/InSchoolCreate.png" />
                    </p>
                    <div style="height: 15px;">
                    </div>
                    <ul class="plan-features">
                        <li>Content Modules - 3 Incl.</li>
                        <li>
                            <img src="../../Images/UspdOuterImages/inschoolalertlogo.png" />
                            <span style="vertical-align: top;">Private Call/Msg Directory</span></li>
                        <li>SmartConnect Module</li>
                        <li>Social Media Share Manual / Social Button</li>
                        <li>Push / Text Notifications</li>
                        <li>Customizable App Display</li>
                        <li>Call Button</li>
                        <li>Desktop & Web Widgets / Resources</li>
                        <li>Free Live Chat and Phone Support</li>
                    </ul>
                    <div style="height: 53px;">
                    </div>
                    <asp:LinkButton ID="lnkCreateNew" runat="server" class="plan-button" Text="A La Carte"
                        OnClick="lnkSubscription_Click" CommandArgument="u4To+mMyvXE=" Style="text-decoration: none !important;"></asp:LinkButton>
                </div>
            </div>
            <center class="favcenter">
                Your app will be published on</center>
            <center class="app_center">
                <a href="https://itunes.apple.com/us/app/inschoolhub/id698109267?mt=8" target="_blank">
                    <img src="../../images/Homepage/apple.png" /></a> <a href="https://play.google.com/store/apps/details?id=com.logictree.inschoolhub&amp;hl=en"
                        target="_blank">
                        <img src="../../images/Homepage/android.png" /></a> <a href="https://www.microsoft.com/en-us/store/p/inschoolhub/9nblgggzj9dk"
                            target="_blank">
                            <img src="../../images/Homepage/windows.png" /></a>
            </center>
        </div>
        <!--container-->
    </div>
    <!--mainwrapper-->
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
