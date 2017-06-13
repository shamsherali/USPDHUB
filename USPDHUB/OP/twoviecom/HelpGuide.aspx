<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpGuide.aspx.cs" Inherits="USPDHUB.OP.twoviecom.HelpGuide" %>

<%@ Register Src="~/Controls/HelpControl.ascx" TagName="HelpControl" TagPrefix="hca" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=iso-8859-1" />
    <title>Help Guide</title>
    <link href="../../css/twovieglobal.css" rel="stylesheet" type="text/css" media="all" />
    <link rel="icon" href="../../images/tvfav.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="../../images/tvfav.ico" type="image/x-icon" />
    <csscriptdict import>
			<script type="text/javascript" src="../../scripts/CSScriptLib.js"></script>
		</csscriptdict>
    <csactiondict>
			<script type="text/javascript"><!--
			    var preloadFlag = false;
			    function preloadImages() {
			        if (document.images) {
			            pre_social_facebook_over = newImage('../../images/TVOuterImages/signup-over.png');
			            preloadFlag = true;
			        }
			    }// --></script>
		</csactiondict>
</head>
<body onload="preloadImages();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="outerwrapper">
        <div id="wrapper">
            <div id="banner">
                <div id="brand">
                    <img src="../../images/TVOuterImages/logo.png" alt="TwoVie Hub" width="349" height="190"
                        border="0">
                </div>
                <div id="bannerright">
                    <div id="social">
                        <a href="https://twitter.com/twoviehub" target="_blank">
                            <img src="../../images/TVOuterImages/social-twitter.gif" alt="Twitter" width="23"
                                height="42" border="0"></a></div>
                    <!--social-->
                    <div id="navspace">
                        <ul id="nav">
                            <li class="home"><a href="Default.aspx">Home</a></li>
                            <li class="contact"><a href="contactus.aspx">Contact Us</a></li>
                            <li class="pricing"><a href="AddTools.aspx">Pricing</a></li>
                            <li class="about"><a class="active" href="Javascript:void(0);">About Us</a></li>
                            <li class="login"><a href="Login.aspx">Login</a></li>
                        </ul>
                        <!--nav-->
                    </div>
                    <!--navspace-->
                </div>
                <!--bannerright-->
            </div>
            <!--banner-->
            <div id="container" style="width: 650px; margin:0px auto;">
                <div style="background-color: #F0F3F4;">
                    <div class="features">
                        <div class="titlesmall" style="margin-left: 10px;">
                            Help</div>
                    </div>
                    <hca:HelpControl runat="server" ID="UserHelpCtrl" />
                </div>
                <div id="footer">
                    <p>
                        <a href="http://www.logictreeit.com/" target="_blank">A Product of LogicTree IT</a>
                        &bull; <a href="terms.html" target="_blank">Terms of Service</a></p>
                </div>
                <!--footer-->
            </div>
            <!--container-->
        </div>
        <!--wrapper-->
    </div>
    </form>
</body>
</html>
