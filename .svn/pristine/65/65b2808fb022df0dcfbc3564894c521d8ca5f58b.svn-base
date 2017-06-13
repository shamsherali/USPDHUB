<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="USPDHUB.OP.myyouthhubcom.Login" %>

<%@ Register Src="~/Controls/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Youth Hub</title>
    <link href="<%=Page.ResolveClientUrl("~/css/myhglobal.css")%>" rel="stylesheet" type="text/css" />
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/myhfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/myhfav.ico") %>"
        type="image/x-icon" />
    <csscriptdict import>			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>    </csscriptdict>
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
    <script src="../../Scripts/jquery.min.js" type="text/javascript"></script>
    <style type="text/css">
        #login
        {
            width: 500px;
            padding: 10px 10px;
            position: relative;
            z-index: 99999;
            top: 76px;
            margin: 0 auto;
            border: #d6dbcc solid 8px;
            color: #565656;
            font-size: 14px;
            font-family: Arial, Helvetica, Geneva, SunSans-Regular, sans-serif;
            line-height: 17px;
        }
        .clear15
        {
            clear: both;
            height: 15px;
        }
        .submit1
        {
            margin: 0 auto;
            text-align: center;
        }
        .formwrap
        {
            float: left;
            width: 500px;
        }
        .formwrap .label1
        {
            color: #000000;
            float: left;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            padding: 4px 0 0 30px;
            text-align: left;
            width: 130px;
        }
        .formwrap .label2
        {
            color: #565656;
            font-size: 12px;
            text-align: left;
            float: left;
            padding: 4px 0px 0px 0px;
            width: 261px;
            font-family: Arial, Helvetica, sans-serif;
        }
        .formwrap .label2 a
        {
            color: #565656;
            font-size: 12px;
            text-align: left;
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: none;
        }
        .formwrap .label2 a:hover
        {
            color: #565656;
            font-size: 12px;
            text-align: left;
            font-family: Arial, Helvetica, sans-serif;
            text-decoration: underline;
        }
        .txtfild1wrap
        {
            float: left;
            width: 275px;
        }
        .txtfild1
        {
            border: solid 1px #bcc8d3;
            float: left;
            height: 24px;
            outline: medium none;
            padding: 2px;
            width: 260px;
            color: #666;
            background-color: transparent;
        }
        .loginbg-mid
        {
            font-family: Arial,Helvetica,sans-serif;
            line-height: 20px;
        }
        .errormsg
        {
            color: #FF0000;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            font-weight: normal;
            line-height: normal;
            margin: 10px auto;
            padding: 0 0 10px;
            text-align: left;
        }
    </style>
</head>
<body onload="preloadImages();">
    <form runat="server">
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
                        <li class="features"><a href="AddTools.aspx">Features of My Youth Hub</a></li>
                        <li class="about"><a href="aboutus.html">About My Youth Hub</a></li>
                        <li class="loginlive"><a href="Login.aspx">Login to My Youth Hub</a></li>
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
                    <br />
                    <div id="footer">
                        <div align="right">
                            <p>
                                <a href="http://www.logictreeit.com" target="_blank">A Product of LogicTree IT</a>
                                :: <a href="Terms.html" target="_blank">Terms of Service</a></p>
                        </div>
                    </div>
                    <!--contentright263-->
                </div>
            </div>
            <!--innerwrapper-->
        </div>
    </form>
</body>
</html>
