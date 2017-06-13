<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="USPDHUB.OP.twoviecom.Login" %>

<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Mobile App for instant two way communication for organizations and their customers</title>
    <meta name="author" content="TwoVie.com Team" />
    <meta name="description" content="TwoVie is a software platform that provides a proven System and the Tools to Simplify Communication and Online Marketing." />
    <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
    <link href="<%=Page.ResolveClientUrl("~/css/twovieglobal.css")%>" rel="stylesheet"
        type="text/css" />
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/tvfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/tvfav.ico") %>"
        type="image/x-icon" />
    <csscriptdict import>			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>    </csscriptdict>
    <csactiondict>	<script type="text/javascript"><!--
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
    <div id="outerwrapper">
        <div id="wrapper">
            <div id="banner">
                <div id="brand">
                    <img src="<%=Page.ResolveClientUrl("~/images/TVOuterImages/logo.png")%>" alt="TwoVie Hub"
                        width="349" height="190" border="0">
                </div>
                <div id="bannerright">
                    <div id="social">
                        <%--<a href="(EmptyReference!)">
                            <img src="<%=Page.ResolveClientUrl("~/images/social-facebook.gif")%>" alt="Facebook"
                                width="30" height="42" border="0"></a>--%><a href="https://twitter.com/twoviehub" target="_blank"><img src="<%=Page.ResolveClientUrl("~/images/TVOuterImages/social-twitter.gif")%>"
                                    alt="Twitter" width="23" height="42" border="0"></a></div>
                    <!--social-->
                    <div id="navspace">
                        <ul id="nav">
                            <li class="home"><a href="default.aspx">Home</a></li>
                            <li class="contact"><a href="contactus.aspx">Contact Us</a></li>
                            <li class="pricing"><a href="AddTools.aspx">Pricing</a></li>
                            <li class="about"><a href="aboutus.html">About Us</a></li>
                            <li class="login"><a class="active" href="Javascript:void(0);">Login</a></li>
                        </ul>
                        <!--nav-->
                    </div>
                    <!--navspace-->
                </div>
                <!--bannerright-->
            </div>
            <!--banner-->
            <div id="container">
                <div id="login">
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
                </div>
                <br />
                <br />
                <div class="clear40">
                </div>
                <div class="bottombrdr">
                </div>
                <div class="clear40">
                </div>
                <!--contentright263-->
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
