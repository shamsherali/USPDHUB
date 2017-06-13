<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="USPDHUB.OP.twoviecom.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                            <li class="login"><a href="login.aspx">Login</a></li>
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
                    <div class="formwrap">
                        <%if (Session["VerticalDomain"] != null)
                        {
                              if(Session["VerticalDomain"].ToString() == "twoviecom")
                              { %>                            
                                    <h1 style="text-align: center">Forgot Password</h1>
                              <%} else {%> <h2 style="text-align: center">Forgot Password</h2> <%}
                       } %>
                        <h2 style="text-align: center">
                            </h2>
                        <div class="label1">
                            <span class="errormsg">&nbsp;</span>&nbsp;First Name:</div>
                        <div class="txtfild1wrap">
                            <asp:TextBox ID="txtRFirstname" runat="server" CssClass="txtfild1" TabIndex="1"></asp:TextBox></div>
                        <div class="clear15">
                        </div>
                        <div class="label1">
                            <span class="errormsg">&nbsp;</span>&nbsp;Last Name:</div>
                        <div class="txtfild1wrap">
                            <asp:TextBox ID="txtRlastname" runat="server" CssClass="txtfild1" TabIndex="2"></asp:TextBox></div>
                        <div class="clear15">
                        </div>
                        <div class="label1">
                            <span class="errormsg">* </span>Username:</div>
                        <div class="txtfild1wrap" style="width: 280px;">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtfild1" TabIndex="3"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                Font-Size="X-Small" ErrorMessage="Username is mandatory." Display="Dynamic" ValidationGroup="F">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Font-Size="X-Small"
                                ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic" ValidationGroup="F">*</asp:RegularExpressionValidator><br />
                            <span class="label1" style="padding: 0px;">(myname@example.com)</span></div>
                        <div class="clear15">
                        </div>
                    </div>
                    <div class="submit1">
                        <asp:ImageButton ID="Button1" ImageUrl="~/images/OuterImages/request.gif" runat="server"
                            Text="Request Password" OnClick="Sent_Password" TabIndex="19" Height="30px" ValidationGroup="F" />&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="Button2" Height="30px" ImageUrl="~/images/OuterImages/cancel.gif"
                            runat="server" Text="Cancel" CausesValidation="false" TabIndex="20" OnClick="btnCancel_Click" /></div>
                    <div class="clear15">
                    </div>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="loginbg">
                        <tr>
                            <td class="loginbg-mid">
                                <table width="100%" border="0" cellspacing="3" cellpadding="3" style="font-size: 12px;">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="padding-left: 25px;">
                                            <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="F" HeaderText="Errors:"
                                                ShowSummary="true" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
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
