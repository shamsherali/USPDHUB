<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgencyListing.aspx.cs"
    Inherits="USPDHUB.OP.myyouthhubcom.AgencyListing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Youth Hub</title>
    <link href="../../css/public.css" rel="stylesheet" type="text/css" />
    <link rel="icon" href="<%=Page.ResolveClientUrl("~/images/myhfav.ico") %>" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=Page.ResolveClientUrl("~/images/myhfav.ico") %>"
        type="image/x-icon" />
    <link href="<%=Page.ResolveClientUrl("~/css/myhglobal.css")%>" rel="stylesheet" type="text/css" />
    <link href="<%=Page.ResolveClientUrl("~/css/AjaxControlsStyles.css")%>" rel="stylesheet"
        type="text/css" />
    <link href="../../css/AppFeatures.css" rel="stylesheet" type="text/css" />
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <csscriptdict import>
			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>
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
	    }

	    $(document).ready(function () {
	        var sptext = $('#spdomain').text().toString().replace('##domain##', 'MyYouth Hub');
	        $('#spdomain').text(sptext);
	    });
	    // --></script>
    </csactiondict>
    <script src="../../Scripts/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Scripts/fadeslideshow.js"></script>
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

    </script>
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
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
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
</head>
<body onload="preloadImages();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scr1" runat="server" EnablePageMethods="true">
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
                        <li class="contact"><a href="Contactus.aspx">Contact My Youth Hub</a></li>
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
                <div id="col430fl">
                    <h2>
                        Contact Information</h2>
                    <p>
                        Toll Free: 800-281-0263</p>
                    <p>
                        Hours: Monday-Friday</p>
                    <p>
                        8:00 a.m. to 5:00 p.m. PST</p>
                    <div style="margin-top: 70px; display: none;">
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
                </div>
                <div id="contentright500">
                    <h1>
                        Sign up for My Youth Hub</h1>
                    <div id="signupform">
                        <div>
                            <%--<div id="ValidateUserDetails" class="errormsg_text" style="color: Red; display: none;">
                            </div>--%>
                            <asp:ValidationSummary ID="ValidationSummary1" class="errormsg_text" runat="server"
                                ValidationGroup="A" HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                        </div>
                        <div class="errormsg">
                            * Marked fields are mandatory.</div>
                        <asp:Panel ID="pnlParent" runat="server" Visible="false">
                            <div class="label1">
                                <span class="errormsg">&nbsp;</span> &nbsp;Parent Agency</div>
                            <div class="txtfildwrap">
                                <asp:Label ID="lblParent" runat="server" Style="color: Green;"></asp:Label>
                            </div>
                            <br />
                        </asp:Panel>
                        <asp:HiddenField runat="server" ID="hdnIsLite" Value="False" />
                        <asp:HiddenField runat="server" ID="hdnPackageType" />
                        <%--  <div class="column full">
                            <ul class="segmentation">
                                <li class="personal active" id="liLite" onclick="active(102)">Basic</li>
                                <li class="business" id="liPremium" onclick="active(101)">Premium</li>
                            </ul>
                        </div>
                        <div id="divlite" class="column full  triangle-isosceles2" style="font-weight: normal;
                            font: 100%/1.5 'ProximaNova', Segoe UI, Helvetica Neue, Helvetica, Arial, sans-serif">
                            Basic - Includes one content module, send a tip, push/text notifications and call
                            button along with the ability to manually post to social media, feed content to
                            websites and customize the app.
                        </div>
                        <div id="divpremium" class="column full triangle-isosceles1" style="display: none;
                            font-weight: normal; font: 100%/1.5 'ProximaNova', Segoe UI, Helvetica Neue, Helvetica, Arial, sans-serif">
                            Premium - Includes all Basic features plus administrative controls, auto post to
                            social media, scheduling, as well as buttons for calendar, survey, web links and
                            image gallery, 3 additional content modules, a contact us button and contacts -
                            email.
                        </div>--%>
                        <div class="label1">
                            <span class="errormsg">*</span> Organization Name</div>
                        <div class="txtfildwrap">
                            <asp:TextBox ID="txtAgencyname" TabIndex="1" runat="server" MaxLength="500" class="inputtextarea">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAgencyname"
                                ErrorMessage="Name is mandatory." SetFocusOnError="True" Font-Size="14px" ValidationGroup="A">*</asp:RequiredFieldValidator>&nbsp;
                        </div>
                        <div class="clear8">
                        </div>
                        <div class="label1">
                            <span class="errormsg">* </span>First Name</div>
                        <div class="txtfildwrap">
                            <asp:TextBox ID="txtFirstName" TabIndex="2" class="inputtextarea" runat="server"
                                MaxLength="500">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                                ErrorMessage="Name of Contact Person is mandatory." SetFocusOnError="True" Font-Size="14px"
                                ValidationGroup="A">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFirstName"
                                ErrorMessage="Enter Valid Name of Contact Person." SetFocusOnError="True" Font-Size="14px"
                                ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$" ValidationGroup="A">*
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="clear8">
                        </div>
                        <div class="label1">
                            <span class="errormsg" style="margin-left: 10px;"></span>Last Name</div>
                        <div class="txtfildwrap">
                            <asp:TextBox ID="txtLastName" TabIndex="3" class="inputtextarea" runat="server" MaxLength="500">
                            </asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLastName"
                                ErrorMessage="Enter Valid Name of Contact Person." SetFocusOnError="True" Font-Size="14px"
                                ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$" ValidationGroup="A">*
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="clear8">
                        </div>
                        <%if (hdnIsPaid.Value == "" || Convert.ToBoolean(hdnIsPaid.Value) == false)
                          { %>
                        <div class="label1">
                            &nbsp;&nbsp;How did you hear about us?</div>
                        <div class="txtfildwrap">
                            <asp:DropDownList ID="ddlHow" runat="server" TabIndex="4">
                                <asp:ListItem Text="-- Select --" Value=""></asp:ListItem>
                                <asp:ListItem Text="Google Search" Value="Google Search"></asp:ListItem>
                                <asp:ListItem Text="Referral" Value="Referral"></asp:ListItem>
                                <asp:ListItem Text="Sales Person" Value="Sales Person"></asp:ListItem>
                                <asp:ListItem Text="Magazine Ad" Value="Magazine Ad"></asp:ListItem>
                                <asp:ListItem Text="Trade Show" Value="Trade show"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="clear8">
                        </div>
                        <%} %>
                        <div class="label1">
                            <span class="errormsg">* </span>Phone Number</div>
                        <div class="txtfildwrap">
                            <asp:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtphonenumber"
                                WatermarkText="xxx-xxx-xxxx" runat="server" WatermarkCssClass="inputtextarea">
                            </asp:TextBoxWatermarkExtender>
                            <asp:TextBox ID="txtphonenumber" TabIndex="5" runat="server" MaxLength="14" class="inputtextarea">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtphonenumber"
                                ErrorMessage="Phone Number is mandatory." Font-Size="14px" ValidationGroup="A"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtphonenumber"
                                ErrorMessage="Enter Valid Phone Number." ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                                SetFocusOnError="True" Font-Size="14px" ValidationGroup="A">*
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="clear8">
                        </div>
                        <div class="label1">
                            <span class="errormsg">* </span>Email Address</div>
                        <div class="txtfildwrap">
                            <asp:TextBox ID="txtEmail" TabIndex="6" runat="server" AutoCompleteType="Disabled"
                                class="inputtextarea" onblur="return ServerSidefill(this.id);" tooltipText="Valid email address required. Your email address will be your login ID.">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Email Address of Contact Person is mandatory." Font-Size="14px"
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="A">*
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtEmail"
                                Font-Size="14px" ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="A" SetFocusOnError="True">*
                            </asp:RegularExpressionValidator><br />
                            <div style="font-size: 12px; font-family: Arial; font-weight: bold; width: 250px;
                                margin: 0px; padding: 0px; text-align: left; line-height: 20px;">
                                This will be your primary Login ID; you may change it at any time.</div>
                            <span style="font-size: 12px; font-family: Arial; float: left; line-height: 20px;">(Details
                                will be sent to this email address.) </span>
                        </div>
                        <div class="clear">
                        </div>
                        <%--<div class="txtfildwrap">
                            <div style="float: right; display: none;" id="Progress">
                                <div class="CheckUsername">
                                    <img src="../../images/popup_ajax-loader.gif"><b><font color="green">Processing....</font></b></div>
                            </div>
                        </div>
                        <div style="margin: auto 0px; line-height: 12px; display: none;" id="EmailAvailability">
                            <asp:Label ID="lblUserNameCheck" runat="server" Font-Size="14px" Font-Names="arial"
                                ForeColor="green"></asp:Label>
                        </div>--%>
                        <div class="txtfildwrap">
                            <div style="float: right;">
                                <div style="display: none;" id="Progress" class="CheckUsername">
                                    <img src='../../images/popup_ajax-loader.gif' /><b><font color="green">Processing....</font></b></div>
                                <asp:Label ID="lblUserNameCheck" runat="server" Font-Size="14px" Font-Names="arial"
                                    Width="280px" ForeColor="green" Style="line-height: 20px;"></asp:Label>
                            </div>
                        </div>
                        <div class="clear8">
                        </div>
                        <div class="label1">
                            <span class="errormsg">* </span>Address</div>
                        <div class="txtfildwrap">
                            <asp:TextBox ID="txtAddress" TabIndex="7" runat="server" class="inputtextarea">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAddress"
                                ErrorMessage="Address is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="clear8">
                        </div>
                        <div class="label1">
                            <span class="errormsg">* </span>City</div>
                        <div class="txtfildwrap">
                            <asp:TextBox ID="txtCity" TabIndex="8" runat="server" class="inputtextarea">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCity"
                                ErrorMessage="City is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="clear8">
                        </div>
                        <div class="label1">
                            <span class="errormsg">* </span>State</div>
                        <div class="txtfildwrap">
                            <asp:TextBox ID="txtState" TabIndex="9" runat="server" class="inputtextarea">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtState"
                                ErrorMessage="State is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="clear8">
                        </div>
                        <div class="label1">
                            <span class="errormsg">* </span>Zipcode</div>
                        <div class="txtfildwrap">
                            <asp:TextBox ID="txtzipcode" MaxLength="8" runat="server" Rows="7" TabIndex="10"
                                onkeypress="return isNumber(event)" class="inputtextarea"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtzipcode"
                                runat="server" SetFocusOnError="True" ValidationGroup="A" ErrorMessage="Zip Code is mandatory.">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                                SetFocusOnError="True" ValidationGroup="A" ControlToValidate="txtzipcode" ValidationExpression="^[0-9]{5,8}$">*</asp:RegularExpressionValidator>
                        </div>
                        <div class="clear8">
                        </div>
                        <div class="label1">
                            <span class="errormsg">* </span>Country</div>
                        <div class="txtfildwrap">
                            <asp:DropDownList ID="ddlCountry" TabIndex="11" runat="server" Width="241" class="inputtextarea">
                            </asp:DropDownList>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator40" SetFocusOnError="True"
                                        Font-Size="14px" ControlToValidate="ddlCountry" runat="server" InitialValue="0"
                                        ValidationGroup="A" ErrorMessage="Country is mandatory.">*</asp:RequiredFieldValidator>--%>
                        </div>
                        <%if (hdnIsPaid.Value == "" || Convert.ToBoolean(hdnIsPaid.Value) == false)
                          { %>
                        <div class="label1" style="display: none;">
                            <span class="errormsg" style="margin-left: 10px;"></span>Promo Code</div>
                        <div class="txtfildwrap" style="display: none;">
                            <asp:TextBox runat="server" ID="txtPromoCode" class="inputtextarea" TabIndex="12"></asp:TextBox>
                        </div>
                        <%} %>
                        <div class="clear8">
                        </div>
                        <div class="txtfildwrap" style="margin-left: 120px;">
                            <div style="width: 150px;">
                                <asp:Image Visible="false" runat="server" ID="img1" ImageUrl="~/GenerateCaptcha.aspx"
                                    AlternateText="Captcha" CssClass="captch" />
                                <cc1:CaptchaControl ID="captcha" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5"
                                    CaptchaHeight="35" CaptchaWidth="150" CaptchaMinTimeout="5" CaptchaMaxTimeout="3600"
                                    BackColor="White" NoiseColor="White" Width="150px" BorderColor="White" BorderStyle="Double"
                                    CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789" />
                            </div>
                        </div>
                        <div class="clear8">
                        </div>
                        <div class="label1">
                            <span class="errormsg">* </span>Security Code</div>
                        <div class="txtfildwrap">
                            <asp:TextBox ID="txtcaptcha" TabIndex="13" runat="server" class="inputtextarea">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqCapha" runat="server" ControlToValidate="txtcaptcha"
                                SetFocusOnError="True" ErrorMessage="Security Code is mandatory." Font-Size="14px"
                                ValidationGroup="A">*
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="clear8">
                        </div>
                        <div style="width: 475px; margin: 0px auto;">
                            By clicking 'Submit' you agree to the Terms of Service of this site.
                        </div>
                        <div class="left" style="padding-left: 238px; padding-top: 10px;">
                            <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="btnSubmit_Click" CausesValidation="true"
                                TabIndex="14" ValidationGroup="A"><img src="<%=Page.ResolveClientUrl("~/images/MYHOuterImages/submit.png")%>" border="0" /></asp:LinkButton>
                            <br />
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
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
                    <br>
                    <!--contentleft377-->
                    <!--footer-->
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
    </div>
    </form>
</body>
</html>
