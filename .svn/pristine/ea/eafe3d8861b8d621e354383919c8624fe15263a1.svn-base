<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="InschoolAlert.ContactUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
     <title>inSchool ALERT</title>
    <link href="<%=Page.ResolveClientUrl("~/css/ishglobal.css")%>" rel="stylesheet" type="text/css"
        media="all">
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/ishfav.ico") %>"
        type="image/x-icon" />
    <link href="/css/bootstrap.css" rel="stylesheet">
    <link href="/css/custom.css" rel="stylesheet">
    <csscriptdict import>			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>    </csscriptdict>
    <csactiondict>	<script type="text/javascript"><!--
	    var preloadFlag = false;
	    function preloadImages() {
	        if (document.images) {
	            pre_social_facebook_over = newImage('../../images/social-facebook-over.gif');
	            pre_social_twitter_over = newImage('../../images/social-twitter-over.gif');
	            pre_button_signup_over = newImage('../../images/button-signup-over.jpg');
	            preloadFlag = true;
	        }
	    }// --></script>
</csactiondict>
    <meta name="author" content="USPDhub.com Team" />
    <meta name="description" content="Contact USPDhub.com and know about best Online Marketing Systems, Email Marketing Softwares and Online Marketing tools available in the market." />
    <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
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
    <script type="text/javascript">
        $(function () {
            $('#txtPhone').keyup(function (event) {
                // Allow: backspace, delete, tab, escape, and enter // Allow: home, end, left, right
                if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
                (event.keyCode >= 35 && event.keyCode <= 39)) {
                    return;
                }
                else {
                    // Ensure that it is a number and stop the keypress
                    if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                        event.preventDefault();
                    }
                }
                var val = this.value.replace(/\D/g, '');
                var newVal = '';
                if (val.length > 10) {
                    val = val.substring(0, 10)
                }
                while (val.length >= 3 && newVal.length <= 7) {
                    newVal += val.substr(0, 3) + '-';
                    val = val.substr(3);
                }
                newVal += val;
                this.value = newVal;
            });
        });
        
    </script>
</head>
<body onload="preloadImages();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="mainwrapper">
        <div id="container">
            <div id="bannersecondary">
                <div id="bannerleft">
                    <img src="images/inschoolalert.png" alt="InSchoolAlert"></div>
                <!--bannerleft-->
                <div id="rightcol">
                    <div id="navigation">
                        <div align="right">
                            <p>
                                <a href="Default.aspx">Home</a> | <a href="Javascript:void(0);" class="active">Contact
                                    Us</a> | <a href="features.htm">Featues & Pricing</a> | <a href="aboutus.htm">About
                                        Us</a> | <a href="login.aspx">Login</a>
                                <%--<a onmouseover="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook-over.gif")%>');return true"
                                        onmouseout="changeImages('social_facebook','/images/ISHOuterImages/social-facebook.gif');return true"
                                        href="https://www.facebook.com/UspDhub" target="_blank">
                                        <img id="social_facebook" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>"
                                            alt="InSchoolHub Facebook" name="social_facebook" width="30" height="33" align="absmiddle"
                                            border="0"></a>--%><a onmouseover="changeImages('social_twitter','/images/social-twitter-over.gif');return true"
                                                onmouseout="changeImages('social_twitter','/images/social-twitter.gif');return true"
                                                href="https://twitter.com/inSchoolAlert" target="_blank"><img id="social_twitter"
                                                    src="<%=Page.ResolveClientUrl("~/images/social-twitter.gif")%>" alt="InSchoolHub Twitter"
                                                    name="social_twitter" width="28" height="33" align="absmiddle" border="0"></a></p>
                        </div>
                    </div>
                    <!--navigation-->
                </div>
                <!--bannerright-->
            </div>
            <!--bannersecondary-->
        </div>
        <div id="content">
            <div id="containercontact">
                <div id="containercontact-content">
                    <div id="contactinfo">
                        <img src="/images/img-contactus.png" align="left" width="336" height="218" style="margin-bottom: 15px;"><br />
                        <div class="h3bold">
                            inSchoolAlert Headquarters:</div>
                        <div class="h3">
                            6060 Sunrise Vista Drive, Suite 3500</div>
                        <div class="h3">
                            Citrus Heights, CA 95610</div>
                        <div class="h3bold">
                            Toll Free: 1-800-281-0263</div>
                        <div class="h3bold">
                            Monday - Friday 8 a.m. - 5 p.m. PST</div>
                        <br />
                        <div class="h4">
                            Customer Care: <a href="mailto:support@inschoolalert.com">support@inschoolalert.com</a></div>
                        <div class="h4">
                            Sales Inquiries: <a href="mailto:sales@inschoolalert.com">sales@inschoolalert.com</a></div>
                        <br />
                        <div class="h3bold">
                            For Information:</div>
                        <div class="h4">
                            Contact us at <a href="mailto:info@inschoolalert.com">info@inschoolalert.com</a></div>
                    </div>
                    <div id="contactform">
                        <div style="text-align: center">
                            <div style="width: 55%; margin: 0 auto; text-align: left;" class="errormsg">
                                <asp:ValidationSummary ID="VSContactUs" runat="server" HeaderText="The following error(s) occurred:"
                                    Font-Size="13px" Font-Names="arial" ValidationGroup="A" />
                            </div>
                        </div>
                        <div style="margin-bottom: 10px;" class="h3">
                            <strong>Note: </strong><span style="color: red">*</span> Marked fields are mandatory.
                        </div>
                        <label for="user">
                            <span style="color: red">*</span> Name:</label>
                        <asp:TextBox runat="server" ID="txtName" CssClass="inputtextarea" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Name is mandatory." SetFocusOnError="True" Font-Size="XX-Small"
                            ValidationGroup="A">*</asp:RequiredFieldValidator><br />
                        <label for="emailaddress">
                            <span style="color: red">*</span> Email:</label>
                        <asp:TextBoxWatermarkExtender ID="txbwemail" TargetControlID="txtEmail" WatermarkText="example@example.com"
                            WatermarkCssClass="inputtextarea" runat="server">
                        </asp:TextBoxWatermarkExtender>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputtextarea" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Email is mandatory." SetFocusOnError="True" ValidationGroup="A"
                            Display="Dynamic" Font-Size="XX-Small">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Invalid Email format." Font-Size="XX-Small" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="A">*</asp:RegularExpressionValidator><br />
                        <label for="comments">
                            <span>&nbsp;</span> Telephone:</label>
                        <asp:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtPhone"
                            WatermarkText="xxx-xxx-xxxx" WatermarkCssClass="inputtextarea" runat="server">
                        </asp:TextBoxWatermarkExtender>
                        <asp:TextBox runat="server" ID="txtPhone" MaxLength="12" CssClass="inputtextarea"
                            Width="250px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPhone"
                            ErrorMessage="Invalid Telephone format." Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                            ValidationGroup="A">*</asp:RegularExpressionValidator><br />
                        <label for="comments">
                            <span>&nbsp;</span> Department:
                        </label>
                        <asp:DropDownList runat="server" ID="ddlType" Width="256px">
                            <asp:ListItem Text="Customer Support" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Sales" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Reseller" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="comments">
                            <span style="color: red">*</span> Subject:</label>
                        <asp:TextBox runat="server" ID="txtSubject" CssClass="inputtextarea" Width="250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSubject"
                            ErrorMessage="Subject is mandatory." SetFocusOnError="True" ValidationGroup="A"
                            Font-Size="XX-Small">*</asp:RequiredFieldValidator><br />
                        <label for="comments">
                            <span style="color: red">*</span> Comments:</label>
                        <asp:TextBox runat="server" ID="txtComments" Width="250px" TextMode="MultiLine" Height="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubject"
                            ErrorMessage="Comments are mandatory." SetFocusOnError="True" ValidationGroup="A"
                            Font-Size="XX-Small">*</asp:RequiredFieldValidator><br />
                        <div class="left" style="margin-left: 125px; margin-bottom: 3px;">
                            <asp:Image Visible="false" runat="server" ID="img1" ImageUrl="~/GenerateCaptcha.aspx"
                                AlternateText="Captcha" />
                            <cc1:CaptchaControl ID="captcha" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5"
                                CaptchaHeight="35" CaptchaWidth="150" CaptchaMinTimeout="5" CaptchaMaxTimeout="3600"
                                BackColor="White" NoiseColor="White" Width="200px" BorderColor="White" BorderStyle="Double"
                                CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789" />
                        </div>
                        <label for="comments">
                            <span style="color: red">*</span> Verification Code:</label>
                        <asp:TextBox ID="txtcaptcha" CssClass="inputtextarea" TabIndex="8" runat="server"
                            Width="250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqCapha" runat="server" ControlToValidate="txtcaptcha"
                            ErrorMessage="Verification Code is mandatory." Font-Size="XX-Small" SetFocusOnError="True"
                            ValidationGroup="A">*</asp:RequiredFieldValidator><br />
                        <div>
                            <asp:Label ID="lblShowError" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="left" style="padding-left: 135px; padding-top: 10px;">
                            <asp:LinkButton ID="lnkSubmit" runat="server" ValidationGroup="A" OnClick="lnkSubmit_Click"><img src="<%=Page.ResolveClientUrl("~/images/submit.png")%>" border="0" /></asp:LinkButton>
                        </div>
                        <div class="clear60">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--End Footer-->
    <footer>
  <div class="container">
    <div class="footer-text">LogicTree IT Solutions Inc.  |   6060 Sunrise Vista Drive, Suite 3500  |  Citrus Heights, CA 95610</div>
    <div class="footer-text margintop10"><a href="#">Info@LogicTreeIT.com</a> |  916.676.7335  |  800.281.0263</div>
  </div>
</footer>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    </form>
</body>
</html>
