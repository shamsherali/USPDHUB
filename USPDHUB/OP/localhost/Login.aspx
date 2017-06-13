<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="USPDHUB.OP.localhost.Login" %>

<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
        <title>
            Mobile App for Law Enforcement, Community Outreach, Police App & Agency App from
            USPDhub.com
        </title>
        <meta name="author" content="USPDhub.com Team" />
        <meta name="description" content="USPDhub is a software platform that provides a proven System and the Tools to Simplify Communication and Online Marketing." />
        <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
        <link href="<%=Page.ResolveClientUrl("~/css/global.css")%>" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r;
                i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date();
                a = s.createElement(o),
                m = s.getElementsByTagName(o)[0];
                a.async = 1;
                a.src = g;
                m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-40935673-1', 'uspdhub.com');
            ga('send', 'pageview');
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <!--Header starts-->
            <div id="header">
                <div class="menu_top">
                    <div class="container">
                        <div class="navwrap">
                            <div class="nav">
                                <ul>
                                    <li>
                                        <a href="Default.aspx">Home</a>
                                    </li>
                                    <li>
                                        <a href="contactus.aspx">Contact Us</a>
                                    </li>
                                    <li>
                                        <a href='AddTools.aspx'>Pricing</a>
                                    </li>
                                    <li>
                                        <a href="aboutus.html">About Us</a>
                                    </li>
                                    <li>
                                        <a href="javascript:void(0);" class="active">Login</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div id="bannerwrap">
                    <div class="bg_colorwrap">
                        <div class="banner" align="center">
                            <img src="<%=Page.ResolveClientUrl("~/images/Homepage/banner_1000.jpg")%>" />
                        </div>
                    </div>
                </div>
                <div class="shadow_banner">
                </div>
            </div>
            <div class="clear">
            </div>
            <!--Header ends-->
            <div id="contentwrap">
                <div id="content">
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
                    <br/>
                    <br/>
                    <div class="clear40">
                    </div>
                </div>
                <div class="bottombrdr">
                </div>
                <div class="clear40">
                </div>
            </div>
            <div id="menu">
                <div id="footer">
                    <div class="copyrights">
                        <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a>
                    </div>
                    <div class="footerlinks">
                        <%--<a href="javascript:void(0);">Privacy Policy</a> |--%> <a href="Terms.html" target="_blank">
                            Terms of Service
                        </a>
                    </div>
                    <div class="snwrap">
                        <div class="followus">
                            Follow us on
                        </div>
                        <div class="sn1">
                            <ul>
                                <li>
                                    <a href="https://twitter.com/USPDHub" target="_blank"><img src="<%=Page.ResolveClientUrl("~/images/Homepage/twit.png")%>" alt="Twitter" title="Twitter" /></a>
                                </li>
                                <li>
                                    <a href="https://www.facebook.com/UspDhub" target="_blank">
                                        <img src="<%=Page.ResolveClientUrl("~/images/Homepage/fb.png")%>" alt="Facebook" title="Facebook" />
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>