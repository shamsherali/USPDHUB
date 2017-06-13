<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contactusold.aspx.cs" Inherits="USPDHUB.OP.uspdhubcom.Contactusold" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Mobile App for Law Enforcement, Community Outreach, Police App & Agency App from
        USPDhub.com</title>
    <meta name="author" content="USPDhub.com Team" />
    <meta name="description" content="Contact USPDhub.com and know about best Online Marketing Systems, Email Marketing Softwares and Online Marketing tools available in the market." />
    <meta name="keywords" content="online marketing system, online marketing, email marketing, internet marketing, local online marketing, online marketing companies, online marketing blog, online marketing tools" />
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <link href="<%=Page.ResolveClientUrl("~/css/global.css")%>" rel="stylesheet" type="text/css" />
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
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--Header starts-->
    <div id="header">
        <div class="menu_top">
            <div class="container">
                <div class="navwrap">
                    <div class="nav">
                        <ul>
                            <li><a href="Default.aspx">Home</a></li>
                            <li><a href="Javascript:void(0);" class="active">Contact Us</a></li>
                            <li><a href="AddTools.aspx">Pricing</a></li>
                            <li><a href="aboutus.html">About Us</a></li>
                            <li><a href="login.aspx">Login</a></li>
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
            <div class="pagehead">
                Contact Us</div>
            <div align="center">
                <img src="<%=Page.ResolveClientUrl("~/images/OuterImages/shadow.png")%>" width="100%" /></div>
            <div id="containercontact">
                <div id="containercontact-content">
                    <div id="contactinfo">
                        <img src="<%=Page.ResolveClientUrl("~/images/OuterImages/img-contactus.png")%>" align="left" width="336" height="218"
                            style="margin-bottom: 15px;" /><br />
                        <div class="h3bold">USPDhub Headquarters:</div>
                        <div class="h3">6060 Sunrise Vista Drive, Suite 3500</div>
                        <div class="h3">Citrus Heights, CA 95610</div>
                        <div class="h3bold">Toll Free: 1-800-281-0263</div>
                        <div class="h3bold">Monday - Friday 8 a.m. - 5 p.m. PST</div><br/>
                        <div class="h4">
                                Customer Care: <a href="mailTo:support@uspdhub.com">support@uspdhub.com</a></div>
                        <div class="h4">
                                Sales Inquiries: <a href="mailTo:sales@uspdhub.com">sales@uspdhub.com</a></div>
                                <br />
                        <div class="h3bold">
                                For Information:</div>
                        <div class="h4">
                            Contact us at <a href="mailTo:info@uspdhub.com">info@uspdhub.com</a></div>
                    </div>
                    <div id="contactform">
                        <div style="text-align: center">
                            <div style="width: 55%; margin: 0 auto; text-align: left">
                                <asp:ValidationSummary ID="VSContactUs" runat="server" HeaderText="The following error(s) occurred:"
                                    Font-Size="13px" Font-Names="arial" ValidationGroup="A" />
                            </div>
                        </div>
                        <div style="margin-bottom: 10px;"  class="h3">
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
                        <asp:TextBox runat="server" ID="txtPhone" CssClass="inputtextarea" Width="250px"></asp:TextBox>
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
                        <asp:TextBox ID="txtcaptcha" CssClass="inputtextarea" TabIndex="8" runat="server" Width="250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqCapha" runat="server" ControlToValidate="txtcaptcha"
                            ErrorMessage="Verification Code is mandatory." Font-Size="XX-Small" SetFocusOnError="True"
                            ValidationGroup="A">*</asp:RequiredFieldValidator><br />
                        <div>
                            <asp:Label ID="lblShowError" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="left" style="padding-left: 135px; padding-top: 10px;">
                            <asp:LinkButton ID="lnkSubmit" runat="server" ValidationGroup="A" OnClick="lnkSubmit_Click"><img src="<%=Page.ResolveClientUrl("~/images/OuterImages/submit.png")%>" /></asp:LinkButton>
                        </div>
                        <div class="clear60">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
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
                <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a></div>
            <div class="footerlinks">
                <%--<a href="javascript:void(0);">Privacy Policy</a> |--%> <a href="Terms.html" target="_blank">
                    Terms of Service</a></div>
            <div class="snwrap">
                <div class="followus">
                    Follow us on</div>
                <div class="sn1">
                    <ul>
                        <li><a href="https://twitter.com/USPDHub" target="_blank">
                            <img src="<%=Page.ResolveClientUrl("~/images/Homepage/twit.png")%>" alt="Twitter" title="Twitter" /></a></li>
                        <li><a href="https://www.facebook.com/UspDhub" target="_blank">
                            <img src="<%=Page.ResolveClientUrl("~/images/Homepage/fb.png")%>" alt="Facebook" title="Facebook" /></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

