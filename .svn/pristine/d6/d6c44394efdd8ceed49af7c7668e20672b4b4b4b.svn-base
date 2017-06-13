<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTools.aspx.cs" Inherits="USPDHUB.OP.uspdhubcom.AddTools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Mobile App for Law Enforcement, Community Outreach, Police App & Agency App from
        USPDhub.com</title>
    <link href="<%=Page.ResolveClientUrl("~/css/uspdhubglobal_new.css")%>" rel="stylesheet"
        type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="viewport" content="width=device-width, user-scalable=no" />
    <meta name="author" content="USPDhub.com Team" />
    <meta name="description" content="USPDhub is an easy and smart online business tool box which includes email marketing, contact management, a dynamic web presence, calendar, local directory listings and more." />
    <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.min.js")%>" type="text/javascript"></script>
    <script src="<%=Page.ResolveClientUrl("~/Scripts/fadeslideshow.js")%>" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            localStorage.clear();
        });

        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
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
    <script type="text/javascript">
       function SelectedTools() {
            var ProfileID=<%=ProfileID %>;
            var EncryptAffilateID='<%=EncryptAffilateID%>';
            var result;        
            if (document.getElementById('hdnPkgVal').value == "") {
                if(parseInt(ProfileID) == 0){
                    result = confirm('You have not selected any package; click ok to proceed with a 30 Day Free Trial.'); 
                    if(result==true)
                    {
                        var str="";
                        if(EncryptAffilateID!="")
                        {            
                         str=EncryptAffilateID.replace('PLUS','+');
                            str=str.replace('EQUAL','=');               
                            window.location.href="../Business/BusinessListing.aspx?PC=FreeTrial&AID="+str;
                        }
                        else
                            window.location.href="../Business/BusinessListing.aspx?PC=FreeTrial"
                        return false;
                    }
                    else
                        return false;
                }
                else
                {
                     result = confirm('You have not selected any package, click ok to go to Dashboard.'); 
                     if(result==true)
                     {
                        window.location.href="MyAccount/Default.aspx";
                        return false;
                     }
                    else
                        return false;
               }
            }
            else
            {
               if(<%=UserPackegeNum %>!=0)
               {
                    if(selPacakgevalue<=<%=UserPackegeNum %>)
                    {
                        alert("You have selected the lower package. Please select higher package.");
                        return false;
                    }
                    else
                        return true;
               }
               else
                   return true;
           }
        }
    </script>
    <script language="javascript" type="text/ecmascript">
        var selPacakgevalue = 0;
        function CheckSelectedPackage(priceamt, value) {
            var price = 0;
            price = parseInt(priceamt);
            if (document.getElementById('hdnRemainingdays').value != "") {
                var RemaingAmt = price * parseInt(document.getElementById('hdnRemainingdays').value) / 30;
                price = RemaingAmt;
            }
            if (price != 0)
                document.getElementById('hdnPkgVal').value = 1;
            selPacakgevalue = parseInt(value);
            document.getElementById('hdnSelcPkg').value=value;
            document.getElementById('hdnTotal').value = parseFloat(price).toFixed(2);
            if (document.getElementById('hdnoldAmount').value != "") {
                price = (price - parseFloat(document.getElementById('hdnoldAmount').value)).toFixed(2);
            }
            document.getElementById('hdnAmount').value = parseFloat(price).toFixed(2);
            return SelectedTools();
        }
        function GetTools() {
            var price = 0;
            price = <%=PreviousPkgAmount %>
            if (document.getElementById('hdnRemainingdays').value != "") {
                var RemaingAmt = price * parseInt(document.getElementById('hdnRemainingdays').value) / 30;
                price = RemaingAmt;
            }
            if (price != 0)
                document.getElementById('hdnPkgVal').value = 1;
            selPacakgevalue = parseInt(document.getElementById('hdnSelcPkg').value);
            document.getElementById('hdnTotal').value = parseFloat(price).toFixed(2);
            if (document.getElementById('hdnoldAmount').value != "") {
                price = (price - parseFloat(document.getElementById('hdnoldAmount').value)).toFixed(2);
            }
            document.getElementById('hdnAmount').value = parseFloat(price).toFixed(2);
        }
    </script>
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
    <div id="wrapper">
        <div id="innerwrapper">
            <div id="banner">
                <div id="brand">
                    <img src="../../images/UspdOuterImages/uspd-hub.png" alt="USPD hub branded app" width="251"
                        height="192" border="0"></div>
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
                            <li class="pricinglive"><a href="javascript:void(0);">USPDhub Features and Pricing</a></li>
                            <li class="about"><a href="aboutus.html">About USPDhub</a></li>
                            <li class="login"><a href="Login.aspx">Login</a></li>
                        </ul>
                        <!--nav-->
                    </div>
                    <!--navigation-->
                    <div id="logictree">
                        <a href="http://logictreeit.com" target="_blank">
                            <img src="../../images/UspdOuterImages/logictree-it.png" alt="Powered by LogicTree IT"
                                width="205" height="50" border="0"></a></div>
                </div>
                <!--bannerright-->
            </div>
            <!--banner-->
            <div id="container" class="pricingplan-page">
                <div class="col-md-12">
                    <h4 class="text-center">
                        A Mobile App to connect with your community</h4>
                </div>
                <div class="plans">
                    <p style="color: #56aaff; font-weight: bold; font-size: 13px; text-align: center;">
                        One month free with annual payment</p>
                    <div class="plan">
                        <div style="height: 10px;">
                        </div>
                        <h2 class="plan-title">
                            Basic</h2>
                        <p class="plan-price" style="margin-bottom: 3px !important;">
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
                        <div style="height: 20px;">
                        </div>
                        <p>
                            <img src="../../images/UspdOuterImages/basic.png" /></p>
                        <ul class="plan-features">
                            <li>Branding with Your Name and Logo Published in App Stores</li>
                            <li>Content Modules - 3 Incl.</li>
                            <li>SmartConnect Module</li>
                            <li>Social Media Share Manual / Social Button</li>
                            <li>Push / Text Notifications</li>
                            <li>Customizable App Display</li>
                            <li>Call Button</li>
                            <li>Desktop & Web Widgets / Resources</li>
                            <li>Free Live Chat and Phone Support</li>
                        </ul>
                        <div style="height: 20px;">
                        </div>
                        <asp:LinkButton ID="lnkBasic" runat="server" class="plan-button" Text="Subscribe"
                            OnClick="lnkSubscription_Click" CommandArgument="qF2lqN9Iouk=" Style="text-decoration: none !important;"></asp:LinkButton>
                    </div>
                    <div class="plan plan-tall">
                        <p class="thrown">
                            <img src="../../images/UspdOuterImages/thrown.png" />
                            Popular</p>
                        <h2 class="plan-title">
                            Premium</h2>
                        <p class="plan-price" style="margin-bottom: 3px;">
                            <span>$180.00/mo.</span>
                        </p>
                        <center>
                            <b>+</b></center>
                        <div class="publish">
                            <span>$500.00</span>
                        </div>
                        <div class="publishtext">
                            (One-time Publishing Fee)
                        </div>
                        <br />
                        <div style="height: 18px;">
                        </div>
                        <p>
                            <img src="../../images/UspdOuterImages/premium.png" /></p>
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
                        <div style="height: 63px;">
                        </div>
                        <asp:LinkButton ID="lnkPremium" runat="server" class="plan-button" Text="Subscribe"
                            OnClick="lnkSubscription_Click" CommandArgument="VssBxH5DOvs=" Style="text-decoration: none !important;"></asp:LinkButton>
                    </div>
                    <div class="plan">
                        <div style="height: 30px;">
                        </div>
                        <h2 class="plan-title">
                           Select your Features</h2>
                        <p class="plan-price" style="margin-bottom: 3px;">
                            <span>$55.00/mo.</span>
                        </p>
                        <div style="height: 15px;">
                        </div>
                        <div class="publishtext">
                            Select the features and functions that fit your agency's needs
                        </div>
                        <br />
                        <p>
                            <img src="../../images/UspdOuterImages/create.png" /></p>
                        <ul class="plan-features">
                            <li>Content Modules - 3 Incl.</li>
                            <li>SmartConnect Module</li>
                            <li>Social Media Share Manual / Social Button</li>
                            <li>Push / Text Notifications</li>
                            <li>Customizable App Display</li>
                            <li>Call Button</li>
                            <li>Desktop & Web Widgets / Resources</li>
                            <li>Free Live Chat and Phone Support</li>
                        </ul>
                        <div style="height: 57px;">
                        </div>
                        <asp:LinkButton ID="lnkCreateNew" runat="server" class="plan-button" Text="A La Carte"
                            OnClick="lnkSubscription_Click" CommandArgument="lJvAn/bzjhU=" Style="text-decoration: none !important;"></asp:LinkButton>
                    </div>
                </div>
                <center class="favcenter">
                    Your app will be published on</center>
                <center class="app_center">
                    <a href="https://itunes.apple.com/us/app/uspdhub/id640196983?mt=8" target="_blank">
                        <img src="../../images/Homepage/apple.png" />
                    </a><a href="https://play.google.com/store/apps/details?id=com.logictree.uspdhub&amp;hl=en"
                        target="_blank">
                        <img src="../../images/Homepage/android.png" /></a> <a href="http://www.windowsphone.com/en-in/store/app/uspdhub/e498cf4c-d075-4fa9-8cad-44c15418f509"
                            target="_blank">
                            <img src="../../images/Homepage/windows.png" /></a>
                </center>
            </div>
            <!--container-->
            <div id="footer">
                <p>
                    <a href="http://logictreeit.com" target="_blank">A Product of LogicTree IT</a> |
                    <a href="terms.html" target="_blank">Terms of Service</a></p>
                <asp:HiddenField ID="hdnprice" runat="server" />
                <asp:HiddenField ID="hdnTotal" runat="server" />
                <asp:HiddenField ID="hdndiscount" runat="server" />
                <asp:HiddenField ID="hdnAmount" runat="server" Value="0.00" />
                <asp:HiddenField ID="hdnRemainingdays" runat="server" />
                <asp:HiddenField ID="hdnDiscountPercent" runat="server" Value="" />
                <asp:HiddenField ID="hdnPkgVal" runat="server" Value="" />
                <asp:HiddenField ID="hdnoldAmount" runat="server" />
                <asp:HiddenField ID="hdnSelcPkg" runat="server" />
            </div>
            <!--footer-->
        </div>
        <!--innerwrapper-->
    </div>
    <!--wrapper-->
    </form>
</body>
</html>
