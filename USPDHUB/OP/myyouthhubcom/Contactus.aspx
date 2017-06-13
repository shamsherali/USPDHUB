<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contactus.aspx.cs" Inherits="USPDHUB.OP.myyouthhubcom.Contactus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=iso-8859-1">
    <title>Contact My Youth Hub</title>
    <link href="<%=Page.ResolveClientUrl("~/css/myhglobal.css")%>" rel="stylesheet" type="text/css" />
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/myhfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/myhfav.ico") %>"
        type="image/x-icon" />
    <csscriptdict import>
            <script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>
            <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
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
                        <li class="contactlive"><a href="Contactus.aspx">Contact My Youth Hub</a></li>
                        <li class="features"><a href="AddTools.aspx">Features of My Youth Hub</a></li>
                        <li class="about"><a href="aboutus.html">About My Youth Hub</a></li>
                        <li class="login"><a href="Login.aspx">Login to My Youth Hub</a></li>
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
                <div id="container">
                    <div id="contentleft377">
                        <h1>
                            Contact Us</h1>
                        <div align="center">
                            <p>
                                <img src="<%=Page.ResolveClientUrl("~/images/MYHOuterImages/ContactUs.png")%>" alt=""
                                    width="250" height="207" border="0"></p>
                            <h2>
                                <strong>My Youth Hub Headquarters</strong></h2>
                            <p>
                                6060 Sunrise Vista Drive, Suite 3500<br>
                                Citrus Heights, CA 95610<br>
                                Toll Free: 1-800-281-0263<br>
                                Monday - Friday 8 a.m. - 5 p.m. PST</p>
                            <p>
                                <strong>Customer Care:</strong> <a href="mailto:support@myyouthhub.com">support@myyouthhub.com</a><br />
                                <strong>Sales Inquiries:</strong> <a href="mailto:sales@myyouthhub.com">sales@myyouthhub.com<br />
                                </a><strong>For Information:</strong> <a href="mailto:info@myyouthhub.com">info@myyouthhub.com</a></p>
                        </div>
                    </div>
                    <!--contentleft377-->
                    <div id="contentright473">
                        <div id="contactform">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <div style="text-align: center">
                                            <div style="width: 55%; margin: 0 auto; text-align: left; line-height: 20px;">
                                                <div id="VSContactUs" style="color: red; font-family: arial; font-size: 13px;">
                                                    <asp:ValidationSummary ID="vsContactsUs" runat="server" HeaderText="The following error(s) occurred:"
                                                        Font-Size="13px" Font-Names="arial" ValidationGroup="A" />
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div style="margin-bottom: 10px;" class="h3">
                                            <strong>Note: </strong><span style="color: red">*</span> Marked fields are mandatory.
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="user">
                                            <span style="color: red">*</span> Name:</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="inputtextarea" style="height:25px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                            ErrorMessage="Name is mandatory." SetFocusOnError="True" Font-Size="Medium"
                                            ValidationGroup="A">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="emailaddress">
                                            <span style="color: red">*</span> Email:</label>
                                    </td>
                                    <td>
                                        <cc1:TextBoxWatermarkExtender ID="txbwemail" TargetControlID="txtEmail" WatermarkText="example@example.com"
                                            WatermarkCssClass="inputtextarea" runat="server">
                                        </cc1:TextBoxWatermarkExtender>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputtextarea" style="height:25px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="Email is mandatory." SetFocusOnError="True" ValidationGroup="A"
                                            Display="Dynamic" Font-Size="Medium">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="Invalid Email format." Font-Size="Medium" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="A">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="comments">
                                            <span>&nbsp;</span> Telephone:
                                        </label>
                                    </td>
                                    <td>
                                        <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtPhone"
                                            WatermarkText="xxx-xxx-xxxx" WatermarkCssClass="inputtextarea" runat="server">
                                        </cc1:TextBoxWatermarkExtender>
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="inputtextarea" style="height:25px;"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPhone"
                                            ErrorMessage="Invalid Telephone format." Font-Size="Medium" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                                            ValidationGroup="A">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="comments">
                                            <span>&nbsp;</span> Department:
                                        </label>
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlType" name="ddlType" Width="252px">
                                            <asp:ListItem Text="Customer Support" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Sales" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Reseller" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Others" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="comments">
                                            <span style="color: red">*</span> Subject:</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSubject" runat="server" CssClass="inputtextarea" style="height:25px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSubject"
                                            ErrorMessage="Subject is mandatory." SetFocusOnError="True" ValidationGroup="A"
                                            Font-Size="Medium">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="comments">
                                            <span style="color: red">*</span> Comments:</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtComments" Rows="2" Columns="20" TextMode="MultiLine" runat="server"
                                            CssClass="inputtextarea" style="height:25px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubject"
                                            ErrorMessage="Comments are mandatory." SetFocusOnError="True" ValidationGroup="A"
                                            Font-Size="Medium">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td colspan="2">
                                        <div class="left" style="margin-left: 135px; margin-bottom: 3px;">
                                            <asp:Image Visible="false" runat="server" ID="img1" ImageUrl="~/GenerateCaptcha.aspx"
                                                AlternateText="Captcha" />
                                            <cc1:CaptchaControl ID="captcha" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5"
                                                CaptchaHeight="35" CaptchaWidth="150" CaptchaMinTimeout="5" CaptchaMaxTimeout="3600"
                                                BackColor="White" NoiseColor="White" Width="200px" BorderColor="White" BorderStyle="Double"
                                                CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789"></cc1:CaptchaControl>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="comments">
                                            <span style="color: red">*</span> Verification Code:</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcaptcha" runat="server" TabIndex="8" CssClass="inputtextarea" style="height:25px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqCapha" runat="server" ControlToValidate="txtcaptcha"
                                            ErrorMessage="Verification Code is mandatory." Font-Size="Medium" SetFocusOnError="True"
                                            ValidationGroup="A">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div>
                                            <asp:Label ID="lblShowError" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="left" style="padding-left: 135px; padding-top: 10px;">
                                            <asp:LinkButton ID="lnkSubmit" runat="server" ValidationGroup="A" OnClick="lnkSubmit_Click"><img src="<%=Page.ResolveClientUrl("~/images/OuterImages/submit.png")%>" border="0" /></asp:LinkButton></div>
                                        <div class="clear">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <!--contentright473-->
                    <!--footer-->
                    <div class="clear">
                    </div>
                </div>
            </div>
            <!--container-->
            <div id="footer">
                <div align="right">
                    <p>
                        <a href="http://www.logictreeit.com" target="_blank">A Product of LogicTree IT</a>
                        :: <a href="Terms.html" target="_blank">Terms of Service</a></p>
                </div>
            </div>
        </div>
        <!--innerwrapper-->
    </div>
    </form>
</body>
</html>
