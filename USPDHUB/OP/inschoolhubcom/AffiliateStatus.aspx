<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AffiliateStatus.aspx.cs"
    Inherits="USPDHUB.OP.inschoolhubcom.AffiliateStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolHub.com
    </title>
    <link href="<%=Page.ResolveClientUrl("~/css/ishglobal.css")%>" rel="stylesheet" type="text/css"
        media="all">
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>"
        type="image/x-icon" />
    <meta name="author" content="InSchoolhub.com Team" />
    <meta name="description" content="InSchoolhub is a software platform that provides a proven System and the Tools to Simplify Communication and Online Marketing." />
    <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
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
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <form id="form1" runat="server">
    <div id="mainwrapper">
        <div id="container">
            <div id="bannersecondary">
                <div id="bannerleft">
                    <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/ihs-logo.png")%>" alt="InSchoolHub"
                        width="227" height="123" border="0"></div>
                <!--bannerleft-->
                <div id="rightcol">
                    <div id="navigation">
                    </div>
                    <!--navigation-->
                </div>
                <!--bannerright-->
            </div>
            <!--bannersecondary-->
        </div>
        <div id="content">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="body_bg" style="height: 380px;">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="page-width">
                            <tr>
                                <td class="valign-top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="maingeading" align="left">
                                                Invitation Status
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td style="font-family: Arial; font-size: 16px; font-weight: bold; color: Green;
                                                            padding-left: 20px;">
                                                            <span><asp:Label ID="lblStatus" runat="server"></asp:Label></span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <a href="<%=Page.ResolveClientUrl("Default.aspx")%>">
                                                    <img src="<%=Page.ResolveClientUrl("~/images/Secure/btn_continue.gif")%>" style="border: 0px;" /></a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
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
