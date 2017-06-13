<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="USPDHUB.OP.inschoolhubcom.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolHub.com
    </title>
    <link href="<%=Page.ResolveClientUrl("~/css/ishglobal.css")%>" rel="stylesheet" type="text/css"
        media="all">
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>"
        type="image/x-icon" />
    <csscriptdict import>			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>    </csscriptdict>
    <csactiondict>	<script type="text/javascript"><!--
	    var preloadFlag = false;
	    function preloadImages() {
	        if (document.images) {
	            pre_social_facebook_over = newImage('/images/ISHOuterImages/social-facebook-over.gif');
	            pre_social_twitter_over = newImage('/images/ISHOuterImages/social-twitter-over.gif');
	            pre_button_signup_over = newImage('/images/ISHOuterImages/button-signup-over.jpg');
	            preloadFlag = true;
	        }
	    }// --></script>
</head>
<body onload="preloadImages();">
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
                        <div align="right">
                            <p>
                                <a href="Default.aspx">Home</a> | <a href="ContactUs.aspx">Contact Us</a> | <a href="features.html">
                                    Features</a> | <a href="AddTools.aspx">Pricing</a> | <a href="aboutus.html">About Us</a>
                                | <a href="login.aspx">Login</a> <%--<a onmouseover="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook-over.gif")%>');return true"
                                    onmouseout="changeImages('social_facebook','/images/ISHOuterImages/social-facebook.gif');return true"
                                    href="https://www.facebook.com/UspDhub" target="_blank">
                                    <img id="social_facebook" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>"
                                        alt="InSchoolHub Facebook" name="social_facebook" width="30" height="33" align="absmiddle"
                                        border="0"></a>--%><a onmouseover="changeImages('social_twitter','/images/ISHOuterImages/social-twitter-over.gif');return true"
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
            <div id="contentwrap">
                <div id="content">
                </div>               
            </div>
        </div>
        <div id="content">
            <div class="left">
                <h1>
                    FORGOT PASSWORD<br />
                    <img src="/images/ISHOuterImages/headline-dots.gif" alt="" width="386" height="20"
                        border="0"></h1>
            </div>
            <div id="login">
                <h2></h2>
                <div class="formwrap">
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
        </div>
    </div>
    <!--Footer-->
    <div id="footerwrap">
        <div id="footer">
            <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a> &nbsp;&nbsp;&nbsp;<a href="terms.html"
                target="_blank">Terms of Service</a>
        </div>
    </div>
    <!--End Footer-->
    </form>
</body>
</html>
