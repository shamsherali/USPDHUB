<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelpGuide.aspx.cs" Inherits="USPDHUB.OP.myyouthhubcom.HelpGuide" %>

<%@ Register Src="~/Controls/HelpControl.ascx" TagName="HelpControl" TagPrefix="hca" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Help Guide</title>
    <link href="../../css/myhglobal.css" rel="stylesheet" type="text/css" media="all" />
    <link rel="icon" href="../../images/myhfav.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="../../images/myhfav.ico" type="image/x-icon" />
    <csscriptdict import>
			<script type="text/javascript" src="../../scripts/CSScriptLib.js"></script>
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
			    }            // --></script>
	</csactiondict>
</head>
<body onload="preloadImages();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div id="wrapper">
        <div id="innerwrapper">
            <div id="banner">
                <div id="brand">
                    <img src="../../images/MYHOuterImages/my-youth-hub.png" alt="My Youth Hub" width="199"
                        height="118" border="0" />
                </div>
                <div id="navspace">
                    <ul id="nav" class="list">
                        <li class="home"><a href="Default.aspx">Home</a></li>
                        <li class="contact"><a href="Contactus.aspx">Contact My Youth Hub</a></li>
                        <li class="features"><a href="AddTools.aspx">Features of My Youth Hub</a></li>
                        <li class="about"><a href="aboutus.html">About My Youth Hub</a></li>
                        <li class="login"><a href="Login.aspx">Login to My Youth Hub</a></li>
                    </ul>
                    <!--nav-->
                </div>
            </div>
            <!--banner-->
            <div id="container" style="width: 650px; margin: 0px auto;">
                <div style="background-color: #F0F3F4;">
                    <div id="contentleft564 "style="margin-left: 10px;">
                        <h1>
                            Help</h1>
                    </div>
                    <hca:HelpControl runat="server" ID="UserHelpCtrl" />
                </div>
            </div>
            <!--container-->
            <div id="footer">
                <div align="right">
                    <p>
                        <a href="http://logictreeit.com" target="_blank">A Product of LogicTree IT</a> ::
                        <a href="Terms.html" target="_blank">Terms of Service</a></p>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
