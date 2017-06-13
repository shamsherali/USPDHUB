<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contactus.aspx.cs" Inherits="USPDHUB.OP.twoviecom.Contactus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile App for instant two way communication for organizations and their customers</title>
    <link href="<%=Page.ResolveClientUrl("~/css/twovieglobal.css")%>" rel="stylesheet"
        type="text/css" />
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/tvfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/tvfav.ico") %>"
        type="image/x-icon" />
    <csscriptdict import>			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>            <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>    </csscriptdict>
    <csactiondict>	<script type="text/javascript"><!--
	    var preloadFlag = false;
	    function preloadImages() {
	        if (document.images) {
	            pre_social_facebook_over = newImage('../../images/TVOuterImages/signup-over.png');
	            preloadFlag = true;
	        }
	    }// --></script>
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
</csactiondict>
</head>
<body onload="preloadImages();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--Header starts-->
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
                            <li class="contact"><a class="active" href="Javascript:void(0);">Contact Us</a></li>
                            <li class="pricing"><a href="AddTools.aspx">Pricing</a></li>
                            <li class="about"><a href="aboutus.html">About Us</a></li>
                            <li class="login"><a href="Login.aspx">Login</a></li>
                        </ul>
                        <!--nav-->
                    </div>
                    <!--navspace-->
                </div>
                <!--bannerright-->
            </div>
            <!--banner-->
            <div id="container">
                <div id="contentleft377">
                    <h1>&nbsp;</h1>
                    <div align="center">
                        <p>
                            <img src="<%=Page.ResolveClientUrl("~/images/TVOuterImages/cityscape.png")%>" alt=""
                                width="250" height="207" border="0"></p>
                        <h2>
                            <strong>TwoVie Headquarters</strong></h2>
                        <p>
                            6060 Sunrise Vista Drive, Suite 3500<br/>
                            Citrus Heights, CA 95610<br/>
                            Toll Free: 1-800-281-0263<br/>
                            Monday - Friday 8 a.m. - 5 p.m. PST</p>
                        <p>
                            <strong>Customer Care:</strong> <a href="mailto:support@twovie.com">support@twovie.com</a><br>
                            <strong>Sales Inquiries:</strong> <a href="mailto:sales@twovie.com">sales@twovie.com<br>
                            </a><strong>For Information:</strong> <a href="mailto:info@twovie.com">info@twovie.com</a></p>
                    </div>
                </div>
                <!--contentleft377-->
                <div id="contentright473">
                    <div id="contactform">
                        <div style="text-align: center">
                            <div style="width: 55%; margin: 0 auto; text-align: left; line-height: 20px;">
                                <asp:ValidationSummary ID="VSContactUs" runat="server" HeaderText="The following error(s) occurred:"
                                    Font-Size="13px" Font-Names="arial" ValidationGroup="A" />
                            </div>
                        </div>
                        <div style="margin-bottom: 10px;" class="h3">
                            <strong>Note: </strong><span style="color: red">*</span> Marked fields are mandatory.
                        </div>
                        <label for="user">
                            <span style="color: red">*</span> Name:</label>
                        <asp:TextBox runat="server" ID="txtName" CssClass="inputtextarea"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Name is mandatory." SetFocusOnError="True" Font-Size="XX-Small"
                            ValidationGroup="A">*</asp:RequiredFieldValidator><br />
                        <label for="emailaddress">
                            <span style="color: red">*</span> Email:</label>
                        <asp:TextBoxWatermarkExtender ID="txbwemail" TargetControlID="txtEmail" WatermarkText="example@example.com"
                            WatermarkCssClass="inputtextarea" runat="server">
                        </asp:TextBoxWatermarkExtender>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputtextarea"></asp:TextBox>
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
                        <asp:TextBox runat="server" ID="txtPhone" CssClass="inputtextarea"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPhone"
                            ErrorMessage="Invalid Telephone format." Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                            ValidationGroup="A">*</asp:RegularExpressionValidator><br />
                        <label for="comments">
                            <span>&nbsp;</span> Department:
                        </label>
                        <asp:DropDownList runat="server" ID="ddlType" Width="236px">
                            <asp:ListItem Text="Customer Support" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Sales" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Reseller" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="comments">
                            <span style="color: red">*</span> Subject:</label>
                        <asp:TextBox runat="server" ID="txtSubject" CssClass="inputtextarea" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSubject"
                            ErrorMessage="Subject is mandatory." SetFocusOnError="True" ValidationGroup="A"
                            Font-Size="XX-Small">*</asp:RequiredFieldValidator><br />
                        <label for="comments">
                            <span style="color: red">*</span> Comments:</label>
                        <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubject"
                            ErrorMessage="Comments are mandatory." SetFocusOnError="True" ValidationGroup="A"
                            Font-Size="XX-Small">*</asp:RequiredFieldValidator><br />
                        <div class="left" style="margin-left: 135px; margin-bottom: 3px;">
                            <asp:Image Visible="false" runat="server" ID="img1" ImageUrl="~/GenerateCaptcha.aspx"
                                AlternateText="Captcha" />
                            <cc1:CaptchaControl ID="captcha" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5"
                                CaptchaHeight="35" CaptchaWidth="150" CaptchaMinTimeout="5" CaptchaMaxTimeout="3600"
                                BackColor="White" NoiseColor="White" Width="200px" BorderColor="White" BorderStyle="Double"
                                CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789" />
                        </div>
                        <label for="comments">
                            <span style="color: red">*</span> Verification Code:</label>
                        <asp:TextBox ID="txtcaptcha" CssClass="inputtextarea" TabIndex="8" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqCapha" runat="server" ControlToValidate="txtcaptcha"
                            ErrorMessage="Verification Code is mandatory." Font-Size="XX-Small" SetFocusOnError="True"
                            ValidationGroup="A">*</asp:RequiredFieldValidator><br />
                        <div>
                            <asp:Label ID="lblShowError" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="left" style="padding-left: 135px; padding-top: 10px;">
                            <asp:LinkButton ID="lnkSubmit" runat="server" ValidationGroup="A" OnClick="lnkSubmit_Click"><img src="<%=Page.ResolveClientUrl("~/images/OuterImages/submit.png")%>" border="0" /></asp:LinkButton>
                        </div>
                        <div class="clear60">
                        </div>
                    </div>
                </div>
                <!--contentright473-->
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
