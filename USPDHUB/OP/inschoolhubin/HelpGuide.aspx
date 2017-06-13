<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpGuide.aspx.cs" Inherits="USPDHUB.OP.inschoolhubin.HelpGuide" %>

<%@ Register Src="~/Controls/HelpControl.ascx" TagName="HelpControl" TagPrefix="hca" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Help Guide</title>
    <link href="../../css/ishglobal.css" rel="stylesheet" type="text/css" media="all" />
    <link rel="icon" href="/images/ishfav.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="/images/ishfav.ico" type="image/x-icon" />
    <csscriptdict import>
			<script type="text/javascript" src="../../scripts/CSScriptLib.js"></script>
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
			    }// --></script>
		</csactiondict>
</head>
<body onload="preloadImages();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="mainwrapper">
        <div id="container">
            <div id="bannersecondary">
                <div id="bannerleft">
                    <img src="../../images/ISHOuterImages/ihs-logo.png" alt="InSchoolHub" width="227"
                        height="123" border="0"></div>
                <!--bannerleft-->
                <div id="rightcol">
                    <div id="navigation">
                        <div align="right">
                            <p>
                                <a href="Default.aspx">Home</a> | <a href="contactus.aspx">Contact Us</a> | <a href="features.html">
                                    Features</a> | <a href="AddTools.aspx">Pricing</a> | <a href="aboutus.html">About Us</a>
                                | <a href="login.aspx">Login</a>
                            </p>
                        </div>
                    </div>
                    <!--navigation-->
                </div>
                <!--bannerright-->
            </div>
            <!--bannersecondary-->
            <div id="content" style="width: 650px; margin: 0px auto;">
                <div style="background-color: #F0F3F4;">
                    <div id="columnleft" style="margin-left: 10px; text-align: left;">
                        <h1>
                            Help</h1>
                    </div>
                    <hca:HelpControl runat="server" ID="UserHelpCtrl" />
                </div>
            </div>
            <!--container-->
        </div>
        <div id="footerwrap">
            <div id="footer">
                <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a>
                &nbsp;&nbsp;&nbsp;<a href="terms.html" target="_blank">Terms of Service</a>
            </div>
        </div>
        <!--footer-->
    </div>
    </form>
</body>
</html>
