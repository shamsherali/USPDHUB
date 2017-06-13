<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgencyListing.aspx.cs"
    Inherits="USPDHUB.OP.inschoolhubcom.AgencyListing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!doctype html>
<html>
<head runat="server">
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolHub.com
    </title>
    <link href="../../css/public.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="/css/ishglobal.css" rel="stylesheet" type="text/css" media="all">
    <link rel="icon" href="/images/ishfav.ico" type="image/x-icon" />
    <link rel="Stylesheet" href="../../css/AppFeatures.css" type="text/css" />
    <link rel="shortcut icon" href="/images/ishfav.ico" type="image/x-icon" />
    <script src="/scripts/jquery.min.js" type="text/javascript"></script>
    <csscriptdict import>
		<script type="text/javascript" src="../../scripts/CSScriptLib.js"></script>
    </csscriptdict>
    <csactiondict>
	<script type="text/javascript"><!--
	    var preloadFlag = false;
	    function preloadImages() {
	        if (document.images) {
	            pre_social_facebook_over = newImage('../../images/ISHOuterImages/social-facebook-over.gif');
	            pre_social_twitter_over = newImage('../../images/ISHOuterImages/social-twitter-over.gif');
	            pre_button_signup_over = newImage('../../images/ISHOuterImages/button-signup-over.jpg');
	            preloadFlag = true;
	        }
	    }

	    $(document).ready(function () {
	        var sptext = $('#spdomain').text().toString().replace('##domain##', 'inSchoolHub');
	        $('#spdomain').text(sptext);
	    });
// --></script>
</csactiondict>
</head>
<body onload="preloadImages()">
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#txtphonenumber').keyup(function (event) {
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
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        var divstyle = new String();
        function ServerSidefill(id) {
            if (document.getElementById('<%=txtEmail.ClientID%>').value.replace(/ /g, '') != '') {
                divstyle = document.getElementById("Progress").style.visibility;
                if (divstyle.toLowerCase() == "none" || divstyle == "") {
                    document.getElementById("Progress").style.display = "block";
                }
                else {
                    document.getElementById("Progress").style.display = "none";
                }
                var divstyle = document.getElementById("EmailAvailability").style.visibility;
                if (divstyle.toLowerCase() == "none" || divstyle == "") {
                    document.getElementById("EmailAvailability").style.display = "block";
                }

                var idvalue = '';
                idvalue = $get(id).value;
                if (idvalue != '') {
                    var typeval = PageMethods.ServerSidefill(idvalue, OnSuccess, OnFailure);
                }
            }
        }
        function OnSuccess(result) {

            if (result == '1') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=green>Email address is available.</font>';
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '2') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Email address is already in use; please use a different one.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '3') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Please enter a valid Email Address.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
            if (result == '4') {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Email address is already associated with another user.</font>';
                $get('<%=txtEmail.ClientID %>').focus();
                document.getElementById("Progress").style.display = "none";
            }
        }
        function OnFailure(result) {
            if (result.get_message() != "The server method 'ServerSidefill' failed.") {
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>An error occured.</font>';
            }
            document.getElementById("Progress").style.display = "none";
        }

        function Focus(objname, waterMarkText) {
            obj = document.getElementById(objname);
            if (obj.value == waterMarkText) {
                obj.value = "";
            }
        }

        function active(valueID) {
            if (valueID == "101") {
                $("#liPremium").addClass("active");
                $("#liLite").removeClass("active");
                $("#<%=hdnIsLite.ClientID %>").val("False");

                $("#divpremium").css("display", "block");
                $("#divlite").css("display", "none");


            }
            else {
                $("#liLite").addClass("active");
                $("#liPremium").removeClass("active");
                $("#<%=hdnIsLite.ClientID %>").val("True");

                $("#divlite").css("display", "block");
                $("#divpremium").css("display", "none");


            }
        }

    </script>
    <style>
        /* Bubble with an isoceles triangle
------------------------------------------ */
        
        .triangle-isosceles1
        {
            text-align: left;
            position: relative;
            padding: 15px;
            margin: 1em 0 3em;
            color: #000;
            background: #d1dade;
            border-radius: 10px;
            background: linear-gradient(top, #f9d835, #f3961c);
        }
        
        /* creates triangle */
        .triangle-isosceles1:after
        {
            content: "";
            display: block; /* reduce the damage in FF3.0 */
            position: absolute;
            top: -14px;
            left: 270px;
            width: 0;
            border-width: 0px 15px 15px 15px;
            border-style: solid;
            border-color: #d1dade transparent;
        }
        
        .triangle-isosceles2
        {
            text-align: left;
            position: relative;
            padding: 15px;
            margin: 1em 0 3em;
            color: #000;
            background: #d1dade;
            border-radius: 10px;
            background: linear-gradient(top, #f9d835, #f3961c);
        }
        
        /* creates triangle */
        .triangle-isosceles2:after
        {
            content: "";
            display: block; /* reduce the damage in FF3.0 */
            position: absolute;
            top: -14px;
            left: 100px;
            width: 0;
            border-width: 0px 15px 15px 15px;
            border-style: solid;
            border-color: #d1dade transparent;
        }
    </style>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="mainwrapper">
                <div id="container">
                    <div id="banner">
                        <div id="bannerleft">
                            <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/ihs-logo.png")%>" alt="InSchoolHub"
                                width="227" height="123" border="0"></div>
                        <!--bannerleft-->
                        <div id="bannerright">
                            <div id="navigation">
                                <div align="right">
                                    <p>
                                        <a href="Default.aspx">Home</a> | <a href="contactus.aspx">Contact Us</a> | <a href="AddTools.aspx">
                                            Featues & Pricing</a>
                                        <%--| <a href="AddTools.aspx">Pricing</a> --%>| <a href="aboutus.html">About Us</a>
                                        | <a href="login.aspx">Login</a>
                                        <%--<a onmouseover="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook-over.gif")%>');return true"
                                            onmouseout="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>');return true"
                                            href="https://www.facebook.com/UspDhub" target="_blank">
                                            <img id="social_facebook" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>"
                                                alt="InSchoolHub Facebook" name="social_facebook" width="30" height="33" align="absmiddle"
                                                border="0"></a>--%><a onmouseover="changeImages('social_twitter','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter-over.gif")%>');return true"
                                                    onmouseout="changeImages('social_twitter','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter.gif")%>');return true"
                                                    href="https://twitter.com/inSchoolHub" target="_blank"><img id="social_twitter" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter.gif")%>"
                                                        alt="InSchoolHub Twitter" name="social_twitter" width="28" height="33" align="absmiddle"
                                                        border="0"></a></p>
                                </div>
                            </div>
                        </div>
                        <!--bannerright-->
                    </div>
                    <!--banner-->
                </div>
                <div id="content" style="margin-top: 50px;">
                    <div id="containercontact">
                        <div id="contentleft" style="display: none;">
                            <div class="appfeatureswrap">
                                <div class="featuretablediv">
                                    <div class="appfeaturerow appfeaturehead">
                                        <div>
                                        </div>
                                        <div class="fnt15">
                                            Basic
                                        </div>
                                        <div class="fnt15">
                                            Premium
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Pricing <span id="spdomain" style="font-size: 11px;">(Generic ##domain## App)</span><br />
                                            <span style="font-size: 11px;">For App Store Publishing Fees See Below</span>
                                        </div>
                                        <div class="appfeaturehead">
                                            $55.00/mo.<br />
                                            $605.00/yr.
                                        </div>
                                        <div class="appfeaturehead">
                                            $165.00/mo.<br />
                                            $1,815.00/yr.
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Content Modules
                                        </div>
                                        <div>
                                            1 Incl.
                                        </div>
                                        <div>
                                            4 Incl.
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Push / Text Notifications</div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Receive Feedback (Tips) w/ Blocking
                                        </div>
                                        <div>
                                            1 Incl.
                                        </div>
                                        <div>
                                            2 Incl.
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Social Media Share / Social Button
                                        </div>
                                        <div>
                                            Manual
                                        </div>
                                        <div>
                                            Auto
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Customizable App Display</div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Call Button</div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Desktop & Web Widgets / Resources</div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Free Live Chat and Phone Support</div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Multiple Logins w/ Admin Permissions
                                        </div>
                                        <div>
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Surveys and Polls</div>
                                        <div>
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Event Calendar</div>
                                        <div>
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Web Links Module
                                        </div>
                                        <div>
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Image Gallery</div>
                                        <div>
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Scheduling for All Modules</div>
                                        <div>
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Contacts Module w/ Email (Reports)
                                        </div>
                                        <div>
                                        </div>
                                        <div>
                                            <img src="../../images/OuterImages/check.png" />
                                        </div>
                                    </div>
                                </div>
                                <div class="featuretablediv appfeaturehead upgradeappprice">
                                    <div class="featuretablediv">
                                        UPGRADE YOUR APP - Brand and Publish in 3 App Stores</div>
                                </div>
                                <div class="featuretablediv">
                                    <div class="appfeaturerow">
                                        <div>
                                            One-time Publishing Fee
                                        </div>
                                        <div class="appfeaturehead">
                                            $500.00
                                        </div>
                                        <div class="appfeaturehead">
                                            $500.00
                                        </div>
                                    </div>
                                    <div class="appfeaturerow">
                                        <div>
                                            Branded App Maintenance Fee<br />
                                            <span style="font-size: 11px;">(Publishing Fee for Ongoing App Store Updates)</span>
                                        </div>
                                        <div class="appfeaturehead">
                                            $15.00/mo.
                                        </div>
                                        <div class="appfeaturehead">
                                            $15.00/mo.
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--contactform-->
                        <div id="signupform">
                            <div>
                                <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                                    HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                            </div>
                            <div class="errormsg">
                                * Marked fields are mandatory.</div>
                            <asp:Panel ID="pnlParent" runat="server" Visible="false">
                                <div class="label1">
                                    <span class="errormsg">&nbsp;</span> &nbsp;Parent School</div>
                                <div class="txtfildwrap">
                                    <asp:Label ID="lblParent" runat="server" Style="color: Green; float: left;"></asp:Label>
                                </div>
                                <div class="clear15">
                                </div>
                            </asp:Panel>
                            <asp:HiddenField runat="server" ID="hdnIsLite" Value="False" />
                            <asp:HiddenField runat="server" ID="hdnPackageType" />
                            <%--<div class="column full">
                                <ul class="segmentation">
                                    <li class="personal active" id="liLite" onclick="active(102)">Basic</li>
                                    <li class="business" id="liPremium" onclick="active(101)">Premium</li>
                                </ul>
                            </div>
                            <div id="divlite" class="column full  triangle-isosceles2" style="font-weight: normal;
                                font: 100%/1.5 'ProximaNova', Segoe UI, Helvetica Neue, Helvetica, Arial, sans-serif">
                                Basic - Includes one content module, private call directory, send a tip, push/text
                                notifications and call button along with the ability to manually post to social
                                media, feed content to websites and customize the app.
                            </div>
                            <div id="divpremium" class="column full triangle-isosceles1" style="display: none;
                                font-weight: normal; font: 100%/1.5 'ProximaNova', Segoe UI, Helvetica Neue, Helvetica, Arial, sans-serif">
                                Premium - Includes all Basic features plus administrative controls, auto post to
                                social media, scheduling, as well as buttons for calendar, survey, web links and
                                image gallery, 3 additional content modules, a contact us button and contacts -
                                email.
                            </div>--%>
                            <div class="label1">
                                <span class="errormsg">*</span> School Name</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtAgencyname" TabIndex="1" runat="server" MaxLength="500" class="signuptextarea">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAgencyname"
                                    ErrorMessage="School Name is mandatory." SetFocusOnError="True" Font-Size="14px"
                                    ValidationGroup="A">*</asp:RequiredFieldValidator>&nbsp;
                            </div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                <span class="errormsg">* </span>First Name</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtFirstName" TabIndex="3" class="signuptextarea" runat="server"
                                    MaxLength="500">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                                    ErrorMessage="First Name is mandatory." SetFocusOnError="True" Font-Size="14px"
                                    ValidationGroup="A">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFirstName"
                                    ErrorMessage="Enter Valid First Name." SetFocusOnError="True" Font-Size="14px"
                                    ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$" ValidationGroup="A">*
                                </asp:RegularExpressionValidator></div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                <span class="errormsg" style="margin-left: 10px;"></span>Last Name</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtLastName" TabIndex="4" class="signuptextarea" runat="server"
                                    MaxLength="500">
                                </asp:TextBox>
                            </div>
                            <div class="clear15">
                            </div>
                            <%if (hdnIsPaid.Value == "" || Convert.ToBoolean(hdnIsPaid.Value) == false)
                              { %>
                            <div class="label1">
                                &nbsp;&nbsp;&nbsp;How did you hear about us?</div>
                            <div class="txtfildwrap">
                                <asp:DropDownList ID="ddlHow" runat="server" Width="250" TabIndex="5">
                                    <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Google Search" Value="Google Search"></asp:ListItem>
                                    <asp:ListItem Text="Referral" Value="Referral"></asp:ListItem>
                                    <asp:ListItem Text="Sales Person" Value="Sales Person"></asp:ListItem>
                                    <asp:ListItem Text="Magazine Ad" Value="Magazine Ad"></asp:ListItem>
                                    <asp:ListItem Text="Trade Show" Value="Trade show"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="clear15">
                            </div>
                            <%} %>
                            <div class="label1">
                                <span class="errormsg">* </span>School Phone Number</div>
                            <div class="txtfildwrap">
                                <asp:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtphonenumber"
                                    WatermarkText="xxx-xxx-xxxx" runat="server" WatermarkCssClass="signuptextarea">
                                </asp:TextBoxWatermarkExtender>
                                <asp:TextBox ID="txtphonenumber" TabIndex="6" runat="server" MaxLength="14" class="signuptextarea">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtphonenumber"
                                    ErrorMessage="School Phone Number is mandatory." Font-Size="14px" ValidationGroup="A"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtphonenumber"
                                    ErrorMessage="Enter Valid School Phone Number." ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                                    SetFocusOnError="True" Font-Size="14px" ValidationGroup="A">*
                                </asp:RegularExpressionValidator></div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                <span class="errormsg">* </span>Email Address</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtEmail" TabIndex="7" runat="server" AutoCompleteType="Disabled"
                                    class="signuptextarea" onblur="return ServerSidefill(this.id);" tooltipText="Valid email address required. Your email address will be your login ID.">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Email Address of Contact Person is mandatory." Font-Size="14px"
                                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="A">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                    Font-Size="14px" ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="A" SetFocusOnError="True">*
                                </asp:RegularExpressionValidator><br />
                                <%--   <span style="font-size: 12px; font-family: Arial; font-weight:bold; float: left;">This will be your primary login ID</span><br />--%>
                                <div style="font-size: 12px; font-family: Arial; font-weight: bold; width: 250px;
                                    margin: 0px; padding: 0px; text-align: left; line-height: 18px;">
                                    This will be your primary Login ID; you may change it at any time.</div>
                                <span style="font-size: 12px; font-family: Arial; float: left; line-height: 18px;
                                    margin-top: 5px;">(Details will be sent to this email address.) </span>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="txtfildwraps">
                                <div style="float: right; display: none;" id="Progress">
                                    <div class="CheckUsername">
                                        <img src='../../images/popup_ajax-loader.gif' /><b><font color="green">Processing....</font></b></div>
                                </div>
                            </div>
                            <div style="margin: auto 0px; line-height: 12px; display: none;" id="EmailAvailability">
                                <asp:Label ID="lblUserNameCheck" runat="server" Font-Size="14px" Font-Names="arial"
                                    ForeColor="green"></asp:Label>
                            </div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                <span class="errormsg">* </span>Address</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtAddress" TabIndex="8" runat="server" class="signuptextarea">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress"
                                    ErrorMessage="Address is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                <span class="errormsg">* </span>City</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtCity" TabIndex="9" runat="server" class="signuptextarea">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCity"
                                    ErrorMessage="City is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                <span class="errormsg">* </span>State</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtState" TabIndex="10" runat="server" class="signuptextarea">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtState"
                                    ErrorMessage="State is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                <span class="errormsg">* </span>Zipcode</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtzipcode" MaxLength="8" runat="server" Rows="7" TabIndex="11"
                                    onkeypress="return isNumber(event)" class="signuptextarea"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtzipcode"
                                    runat="server" SetFocusOnError="True" ValidationGroup="A" ErrorMessage="Zip Code is mandatory.">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                                    SetFocusOnError="True" ValidationGroup="A" ControlToValidate="txtzipcode" ValidationExpression="^[0-9]{5,8}$">*</asp:RegularExpressionValidator>
                            </div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                <span class="errormsg">* </span>Country</div>
                            <div class="txtfildwrap">
                                <asp:DropDownList ID="ddlCountry" TabIndex="12" runat="server" Width="241" class="signuptextarea">
                                </asp:DropDownList>
                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator40" SetFocusOnError="True"
                                        Font-Size="14px" ControlToValidate="ddlCountry" runat="server" InitialValue="0"
                                        ValidationGroup="A" ErrorMessage="Country is mandatory.">*</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="clear15">
                            </div>
                            <%if (hdnIsPaid.Value == "" || Convert.ToBoolean(hdnIsPaid.Value) == false)
                              { %>
                            <div class="label1" style="display: none;">
                                <span class="errormsg" style="margin-left: 10px;"></span>Promo Code</div>
                            <div class="txtfildwrap" style="display: none;">
                                <asp:TextBox runat="server" ID="txtPromoCode" class="signuptextarea" TabIndex="13"></asp:TextBox>
                            </div>
                            <div class="clear15">
                            </div>
                            <%} %>
                            <div class="txtfildwrap" style="margin-left: 120px;">
                                <asp:Image Visible="false" runat="server" ID="img1" ImageUrl="~/GenerateCaptcha.aspx"
                                    AlternateText="Captcha" CssClass="captch" />
                                <cc1:CaptchaControl ID="captcha" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5"
                                    CaptchaHeight="35" CaptchaWidth="150" CaptchaMinTimeout="5" CaptchaMaxTimeout="3600"
                                    BackColor="White" NoiseColor="White" Width="150px" BorderColor="White" BorderStyle="Double"
                                    CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789" />
                            </div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtcaptcha" TabIndex="14" runat="server" class="signuptextarea">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqCapha" runat="server" ControlToValidate="txtcaptcha"
                                    SetFocusOnError="True" ErrorMessage="Security Code is mandatory." Font-Size="14px"
                                    ValidationGroup="A">*
                                </asp:RequiredFieldValidator>&nbsp;</div>
                            <div class="label1">
                                <span class="errormsg">*</span> Security Code</div>
                            <div class="clear15">
                            </div>
                            <div style="width: 450px; margin: 0px auto;">
                                By clicking 'Submit' you agree to the Terms of Service of this site.
                            </div>
                            <div class="submitbtn">
                                <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="btnSubmit_Click" CausesValidation="true"
                                    TabIndex="14" ValidationGroup="A"><img src="<%=Page.ResolveClientUrl("~/images/Homepage/submit.png")%>" alt="" border="0" /></asp:LinkButton>
                                <br />
                                <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                                    <ProgressTemplate>
                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div class="clear15">
                            </div>
                            <div>
                                <asp:Label runat="server" ID="lblErrorMSG" ForeColor="Red"></asp:Label>
                                <asp:HiddenField ID="hdnProfileID" runat="server" />
                                <asp:HiddenField ID="hdnIsPaid" runat="server" />
                                <asp:HiddenField ID="hdnPackgeID" runat="server" Value="1" />
                            </div>
                        </div>
                        <!--contactform-->
                        <!--signupinfo-->
                        <div id="signupinfo">
                            <div>
                                <%--In order to maintain the integrity of the<br>
                                inSchoolHub we will be calling to verify your information.
                                <br>
                                <br>
                                At that time we will be happy to answer any questions you may have.
                                <br>
                                <br>
                                <strong>Contact Information</strong>
                                <br>
                                <br>
                                <strong><span class="signup1">Toll Free: 800-281-0263</span></strong><br>
                                <br>
                                <strong>Hours:</strong> Monday-Friday
                                <br>
                                8:00 a.m. to 5:00 p.m. PST--%>
                            </div>
                        </div>
                        <!--signupinfo-->
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
            <!--Footer-->
            <div id="footerwrap">
                <div id="footer" style="padding-right: 200px;">
                    <a target="_blank" href="http://www.logictreeit.com">A Product of LogicTree IT</a>
                    &nbsp;&nbsp;&nbsp;<a href="terms.html" target="_blank">Terms of Service</a>
                </div>
            </div>
            <!--End Footer-->
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
