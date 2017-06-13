<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgencyListing.aspx.cs"
    Inherits="USPDHUB.OP.uspdhubcom.AgencyListing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <title>USPDHub</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body onload="preloadImages();">
    <link href="../../css/public.css" rel="stylesheet" type="text/css" />
    <link href="<%=Page.ResolveClientUrl("~/css/uspdhubglobal.css")%>" rel="stylesheet"
        type="text/css">
    <link href="<%=Page.ResolveClientUrl("~/css/AjaxControlsStyles.css")%>" rel="stylesheet"
        type="text/css">
    <link href="../../css/AppFeatures.css" rel="stylesheet" type="text/css" />
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
        function Validate() {
            var theurl = document.getElementById('<%=txtWebSiteURL.ClientID %>').value;
            if (theurl != "") {
                var tomatch = /((ftp|http|https):\/\/)?([A-Za-z0-9\.-]{3,}\.[A-Za-z]{2,})/
                if (!tomatch.test(theurl)) {
                    window.alert("URL invalid. Try again.");
                    return false;
                }
            }

            if ($("#txtStartDate").val() != "") {
                /*   if ($("#ddlHours").val() == "H" && $("#ddlMints").val() == "M") {
                alert('Please select hours and minutes.');
                return false;
                }
                else if ($("#ddlHours").val() == "H") {
                alert('Please select hours.');
                return false;
                }
                else if ($("#ddlMints").val() == "M") {
                alert('Please select minutes.');
                return false;
                }
                else {*/
                var currentdate = new Date();
                var fromDate = $("#txtStartDate").val();
                var selDate = new Date(fromDate);
                //selDate.setHours(parseInt($("#ddlHours").val()), parseInt($("#ddlMints").val()), 0);
                if (selDate.getDate() < currentdate.getDate()) {
                    alert('Best day and time to call must be later than current date.');
                    $get('txtStartDate').focus();
                    return false;
                }
                else
                    return true;
                //}
            }
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
        
    </script>
    <script type="text/javascript">
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
    </style>
    <csscriptdict import>
			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>
    </csscriptdict>
    <csactiondict>
	<script type="text/javascript"><!--
	    var preloadFlag = false;
	    function preloadImages() {
	        if (document.images) {
	            pre_social_facebook_over = newImage('../../images/UspdOuterImages/facebook-over.png');
	            pre_social_twitter_over = newImage('../../images/UspdOuterImages/twitter-over.png');
	            pre_button_signup_over = newImage('../../images/UspdOuterImages/signup-over.png');
	            preloadFlag = true;
	        }
	    }

// --></script>
 
    </csactiondict>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="wrapper">
                <div id="innerwrapper">
                    <div id="banner">
                        <div id="brand">
                            <a href="Default.aspx">
                                <img src="../../images/UspdOuterImages/uspd-hub.png" alt="USPD hub branded app" width="251"
                                    height="192" border="0"></a></div>
                        <!--brand-->
                        <div id="bannerright">
                            <div id="social">
                                <a onmouseover="changeImages('facebook','../../images/UspdOuterImages/facebook-over.png');return true"
                                    onmouseout="changeImages('facebook','../../images/UspdOuterImages/facebook.png');return true"
                                    href="https://www.facebook.com/Uspdhub" target="_blank">
                                    <img id="facebook" src="../../images/UspdOuterImages/facebook.png" alt="USPDhub Facebook"
                                        name="facebook" width="19" height="40" border="0"></a> <a onmouseover="changeImages('twitter','../../images/UspdOuterImages/twitter-over.png');return true"
                                            onmouseout="changeImages('twitter','../../images/UspdOuterImages/twitter.png');return true"
                                            href="https://twitter.com/USPDHub" target="_blank">
                                            <img id="twitter" src="../../images/UspdOuterImages/twitter.png" alt="USPDhub Twitter"
                                                name="twitter" height="40" width="28" border="0"></a>
                            </div>
                            <!--social-->
                            <div id="navigation">
                                <ul id="nav">
                                    <li class="home"><a href="Default.aspx">Home</a></li>
                                    <li class="contact"><a href="Contactus.aspx">Contact USPDhub</a></li>
                                    <li class="pricing"><a href="AddTools.aspx">USPDhub Features and Pricing</a></li>
                                    <li class="about"><a href="aboutus.html">About USPDhub</a></li>
                                    <li class="login"><a href="Login.aspx">Login</a></li>
                                </ul>
                                <!--nav-->
                            </div>
                            <!--navigation-->
                            <div id="signup">
                            </div>
                            <div id="logictree">
                                <a href="http://logictreeit.com" target="_blank">
                                    <img src="../../images/UspdOuterImages/logictree-it.png" alt="Powered by LogicTree IT"
                                        width="205" height="50" border="0"></a></div>
                        </div>
                        <!--bannerright-->
                    </div>
                    <!--banner-->
                    <div id="container">
                        <div id="col405fl">
                            <p>
                                In order to maintain the integrity of the USPDhub we will be calling to verify your
                                information.
                            </p>
                            <h2>
                                Contact Information</h2>
                            <p>
                                Toll Free: 800-281-0263</p>
                            <p>
                                Hours: Monday-Friday</p>
                            <p>
                                8:00 a.m. to 5:00 p.m. PST</p>
                            <div class="appfeatureswrap" style="margin-top: 60px; display: none;">
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
                                            Pricing <span style="font-size: 11px;">(Generic USPDhub App)</span><br />
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
                        <!--col329fl-->
                        <div id="col550fr">
                            <div align="center">
                                <div id="content">
                                    <div id="contact">
                                        <div style="text-align: center">
                                            <div style="width: 62%; margin: 0 auto; text-align: left; font-family: Arial, Helvetica, sans-serif;
                                                font-size: 14px; margin-left: 185px;">
                                                <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                                                    HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                                            </div>
                                        </div>
                                        <div class="formwrap" style="padding-left: 80px;">
                                            <div class="errormsg">
                                                * Marked fields are mandatory.</div>
                                            <asp:Panel ID="pnlParent" runat="server" Visible="false">
                                                <div class="labelal">
                                                    <span class="errormsg">&nbsp;</span> &nbsp;Parent Agency</div>
                                                <div class="txtfild1">
                                                    <asp:Label ID="lblParent" runat="server" Style="color: Green;"></asp:Label>
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
                                            <div id="divlite" class="column full  triangle-isosceles2">
                                                Basic - Includes one content module, send a tip, push/text notifications and call
                                                button along with the ability to manually post to social media, feed content to
                                                websites and customize the app.
                                            </div>
                                            <div id="divpremium" class="column full triangle-isosceles1" style="display: none;">
                                                Premium - Includes all Basic features plus administrative controls, auto post to
                                                social media, scheduling, as well as buttons for calendar, survey, web links and
                                                image gallery, 3 additional content modules, a contact us button and contacts -
                                                email.
                                            </div>--%>
                                            <div class="labelal">
                                                <span class="errormsg">*</span> Agency Name</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtAgencyname" TabIndex="1" class="txtfild1" runat="server" MaxLength="500">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAgencyname"
                                                    ErrorMessage="Agency Name is mandatory." SetFocusOnError="True" Font-Size="14px"
                                                    ValidationGroup="A" Display="Dynamic">*
                                                </asp:RequiredFieldValidator></div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                <span class="errormsg">* </span>First Name</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtFirstName" TabIndex="3" class="txtfild1" runat="server" MaxLength="500">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                                                    ErrorMessage="First Name is mandatory." SetFocusOnError="True" Font-Size="14px"
                                                    ValidationGroup="A" Display="Dynamic">*
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFirstName"
                                                    ErrorMessage="Enter Valid First Name." SetFocusOnError="True" Font-Size="14px"
                                                    ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$" ValidationGroup="A" Display="Dynamic">*
                                                </asp:RegularExpressionValidator></div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                &nbsp;&nbsp;&nbsp;Last Name</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtLastName" TabIndex="4" class="txtfild1" runat="server" MaxLength="500">
                                                </asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastName"
                                                    ErrorMessage="Enter Valid Last Name." SetFocusOnError="True" Font-Size="14px"
                                                    ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$" ValidationGroup="A" Display="Dynamic">*
                                                </asp:RegularExpressionValidator></div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                &nbsp;&nbsp;&nbsp;Title</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtTitle" TabIndex="5" class="txtfild1" runat="server" MaxLength="200">
                                                </asp:TextBox></div>
                                            <div class="clear15">
                                            </div>
                                            <%if (hdnIsPaid.Value == "" || Convert.ToBoolean(hdnIsPaid.Value) == false)
                                              { %>
                                            <div class="labelal">
                                                &nbsp;&nbsp;&nbsp;How did you hear about us?</div>
                                            <div class="txtfild1wrap" style="text-align: left;">
                                                <asp:DropDownList ID="ddlHow" runat="server" Width="258" TabIndex="6">
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
                                            <div class="labelal">
                                                &nbsp;&nbsp;&nbsp;Website URL</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtWebSiteURL" TabIndex="7" runat="server" class="txtfild1">
                                                </asp:TextBox>
                                            </div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                <span class="errormsg">* </span>Agency Phone Number</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtphonenumber"
                                                    WatermarkText="xxx-xxx-xxxx" runat="server" WatermarkCssClass="txtfild1">
                                                </asp:TextBoxWatermarkExtender>
                                                <asp:TextBox ID="txtphonenumber" TabIndex="7" runat="server" MaxLength="14" class="txtfild1">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtphonenumber"
                                                    ErrorMessage="Agency Phone Number is mandatory." Font-Size="14px" ValidationGroup="A"
                                                    SetFocusOnError="True" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtphonenumber"
                                                    ErrorMessage="Enter Valid Agency Phone Number." ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                                                    SetFocusOnError="True" Font-Size="14px" ValidationGroup="A" Display="Dynamic">*
                                                </asp:RegularExpressionValidator></div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                <span class="errormsg">* </span>Contact Email Address</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtEmail" TabIndex="8" runat="server" AutoCompleteType="Disabled"
                                                    class="txtfild1" onblur="return ServerSidefill(this.id);" tooltipText="Valid email address required. Your email address will be your login ID.">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmail"
                                                    ErrorMessage="Email Address of Contact Person is mandatory." Font-Size="14px"
                                                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="A">*
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                                    Font-Size="14px" ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="A" SetFocusOnError="True" Display="Dynamic">*
                                                </asp:RegularExpressionValidator><br />
                                                <div style="font-size: 12px; font-family: Arial; font-weight: bold; width: 250px;
                                                    margin: 0px; padding: 0px; margin-top: 3px; margin-right: 20px;">
                                                    This will be your primary Login ID; you may change it at any time.</div>
                                                <span style="font-size: 12px; font-family: Arial; margin-right: 20px;">(Details will
                                                    be sent to this email address.) </span>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div style="width: 500px;">
                                                <div style="text-align: center; height: 15px;">
                                                    <div style="display: none;" id="Progress" class="CheckUsername">
                                                        <img src='../../images/popup_ajax-loader.gif' /><b><font color="green">Processing....</font></b></div>
                                                    <asp:Label ID="lblUserNameCheck" runat="server" Font-Size="14px" Font-Names="arial"
                                                        ForeColor="green" Style="padding-right: 40px;"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                <span class="errormsg">* </span>Address</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtAddress" TabIndex="9" runat="server" class="txtfild1">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress"
                                                    ErrorMessage="Address is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                <span class="errormsg">* </span>City</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtCity" TabIndex="10" runat="server" class="txtfild1">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                                                    ErrorMessage="City is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                <span class="errormsg">* </span>State</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtState" TabIndex="11" runat="server" class="txtfild1">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtState"
                                                    ErrorMessage="State is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                <span class="errormsg">* </span>Zipcode</div>
                                            <div class="txtfild1wrap">
                                                <asp:TextBox ID="txtzipcode" MaxLength="8" runat="server" Rows="7" TabIndex="12"
                                                    onkeypress="return isNumber(event)" class="txtfild1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtzipcode"
                                                    runat="server" SetFocusOnError="True" ValidationGroup="A" ErrorMessage="Zip Code is mandatory.">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Invalid Zipcode."
                                                    SetFocusOnError="True" ValidationGroup="A" ControlToValidate="txtzipcode" ValidationExpression="^[0-9]{5,8}$">*</asp:RegularExpressionValidator>
                                            </div>
                                            <div class="clear15">
                                            </div>
                                            <div class="labelal">
                                                <span class="errormsg">* </span>Country</div>
                                            <div class="txtfild1wrap">
                                                <asp:DropDownList ID="ddlCountry" TabIndex="13" runat="server" Width="241" class="txtfild1">
                                                </asp:DropDownList>
                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator40" SetFocusOnError="True"
                                        Font-Size="14px" ControlToValidate="ddlCountry" runat="server" InitialValue="0"
                                        ValidationGroup="A" ErrorMessage="Country is mandatory.">*</asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="clear15">
                                            </div>
                                            <div style="display: none;">
                                                <%if (hdnIsPaid.Value == "" || Convert.ToBoolean(hdnIsPaid.Value) == false)
                                                  { %>
                                                <div class="labelal">
                                                    &nbsp;&nbsp;&nbsp;Best Day and Time to Call</div>
                                                <div class="txtfild1wrap">
                                                    <asp:TextBox ID="txtStartDate" runat="server" Width="80px" TabIndex="14" class="txtfild1"></asp:TextBox>
                                                    <asp:CalendarExtender ID="calex" runat="server" Format="MM/dd/yyyy" TargetControlID="txtStartDate"
                                                        CssClass="MyCalendar">
                                                    </asp:CalendarExtender>
                                                    <asp:DropDownList ID="ddlHours" runat="server" TabIndex="15" Height="28px" Style="float: left;
                                                        margin-left: 5px;">
                                                        <asp:ListItem Text="Hours" Value="H"></asp:ListItem>
                                                        <asp:ListItem Value="00"></asp:ListItem>
                                                        <asp:ListItem Value="01"></asp:ListItem>
                                                        <asp:ListItem Value="02"></asp:ListItem>
                                                        <asp:ListItem Value="03"></asp:ListItem>
                                                        <asp:ListItem Value="04"></asp:ListItem>
                                                        <asp:ListItem Value="05"></asp:ListItem>
                                                        <asp:ListItem Value="06"></asp:ListItem>
                                                        <asp:ListItem Value="07"></asp:ListItem>
                                                        <asp:ListItem Value="08"></asp:ListItem>
                                                        <asp:ListItem Value="09"></asp:ListItem>
                                                        <asp:ListItem Value="10"></asp:ListItem>
                                                        <asp:ListItem Value="11"></asp:ListItem>
                                                        <asp:ListItem Value="12"></asp:ListItem>
                                                        <asp:ListItem Value="13"></asp:ListItem>
                                                        <asp:ListItem Value="14"></asp:ListItem>
                                                        <asp:ListItem Value="15"></asp:ListItem>
                                                        <asp:ListItem Value="16"></asp:ListItem>
                                                        <asp:ListItem Value="17"></asp:ListItem>
                                                        <asp:ListItem Value="18"></asp:ListItem>
                                                        <asp:ListItem Value="19"></asp:ListItem>
                                                        <asp:ListItem Value="20"></asp:ListItem>
                                                        <asp:ListItem Value="21"></asp:ListItem>
                                                        <asp:ListItem Value="22"></asp:ListItem>
                                                        <asp:ListItem Value="23"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlMints" runat="server" TabIndex="16" Height="28px" Style="float: left;
                                                        margin-left: 5px;">
                                                        <asp:ListItem Text="Minutes" Value="M"></asp:ListItem>
                                                        <asp:ListItem Value="00"></asp:ListItem>
                                                        <asp:ListItem Value="01"></asp:ListItem>
                                                        <asp:ListItem Value="02"></asp:ListItem>
                                                        <asp:ListItem Value="03"></asp:ListItem>
                                                        <asp:ListItem Value="04"></asp:ListItem>
                                                        <asp:ListItem Value="05"></asp:ListItem>
                                                        <asp:ListItem Value="06"></asp:ListItem>
                                                        <asp:ListItem Value="07"></asp:ListItem>
                                                        <asp:ListItem Value="08"></asp:ListItem>
                                                        <asp:ListItem Value="09"></asp:ListItem>
                                                        <asp:ListItem Value="10"></asp:ListItem>
                                                        <asp:ListItem Value="11"></asp:ListItem>
                                                        <asp:ListItem Value="12"></asp:ListItem>
                                                        <asp:ListItem Value="13"></asp:ListItem>
                                                        <asp:ListItem Value="14"></asp:ListItem>
                                                        <asp:ListItem Value="15"></asp:ListItem>
                                                        <asp:ListItem Value="16"></asp:ListItem>
                                                        <asp:ListItem Value="17"></asp:ListItem>
                                                        <asp:ListItem Value="18"></asp:ListItem>
                                                        <asp:ListItem Value="19"></asp:ListItem>
                                                        <asp:ListItem Value="20"></asp:ListItem>
                                                        <asp:ListItem Value="21"></asp:ListItem>
                                                        <asp:ListItem Value="22"></asp:ListItem>
                                                        <asp:ListItem Value="23"></asp:ListItem>
                                                        <asp:ListItem Value="24"></asp:ListItem>
                                                        <asp:ListItem Value="25"></asp:ListItem>
                                                        <asp:ListItem Value="26"></asp:ListItem>
                                                        <asp:ListItem Value="27"></asp:ListItem>
                                                        <asp:ListItem Value="28"></asp:ListItem>
                                                        <asp:ListItem Value="29"></asp:ListItem>
                                                        <asp:ListItem Value="30"></asp:ListItem>
                                                        <asp:ListItem Value="31"></asp:ListItem>
                                                        <asp:ListItem Value="32"></asp:ListItem>
                                                        <asp:ListItem Value="33"></asp:ListItem>
                                                        <asp:ListItem Value="34"></asp:ListItem>
                                                        <asp:ListItem Value="35"></asp:ListItem>
                                                        <asp:ListItem Value="36"></asp:ListItem>
                                                        <asp:ListItem Value="37"></asp:ListItem>
                                                        <asp:ListItem Value="38"></asp:ListItem>
                                                        <asp:ListItem Value="39"></asp:ListItem>
                                                        <asp:ListItem Value="40"></asp:ListItem>
                                                        <asp:ListItem Value="41"></asp:ListItem>
                                                        <asp:ListItem Value="42"></asp:ListItem>
                                                        <asp:ListItem Value="43"></asp:ListItem>
                                                        <asp:ListItem Value="44"></asp:ListItem>
                                                        <asp:ListItem Value="45"></asp:ListItem>
                                                        <asp:ListItem Value="46"></asp:ListItem>
                                                        <asp:ListItem Value="47"></asp:ListItem>
                                                        <asp:ListItem Value="48"></asp:ListItem>
                                                        <asp:ListItem Value="49"></asp:ListItem>
                                                        <asp:ListItem Value="50"></asp:ListItem>
                                                        <asp:ListItem Value="51"></asp:ListItem>
                                                        <asp:ListItem Value="52"></asp:ListItem>
                                                        <asp:ListItem Value="53"></asp:ListItem>
                                                        <asp:ListItem Value="54"></asp:ListItem>
                                                        <asp:ListItem Value="55"></asp:ListItem>
                                                        <asp:ListItem Value="56"></asp:ListItem>
                                                        <asp:ListItem Value="57"></asp:ListItem>
                                                        <asp:ListItem Value="58"></asp:ListItem>
                                                        <asp:ListItem Value="59"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="clear15">
                                                </div>
                                                <%} %>
                                                <div class="labelal">
                                                    &nbsp;&nbsp;&nbsp;Remarks</div>
                                                <div class="txtfild1wrap">
                                                    <asp:TextBox ID="txtRemarks" TabIndex="17" class="txtarea" runat="server" TextMode="MultiLine">
                                                    </asp:TextBox></div>
                                            </div>
                                        <div class="clear15">
                                        </div>
                                        <div class="txtfild1wrap" style="margin-left: 140px;">
                                            <asp:Image Visible="false" runat="server" ID="img1" ImageUrl="~/GenerateCaptcha.aspx"
                                                AlternateText="Captcha" CssClass="captch" />
                                            <cc1:CaptchaControl ID="captcha" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5"
                                                CaptchaHeight="35" CaptchaWidth="150" CaptchaMinTimeout="5" CaptchaMaxTimeout="3600"
                                                BackColor="White" NoiseColor="White" Width="150px" BorderColor="White" BorderStyle="Double"
                                                CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789" />
                                        </div>
                                        <div class="clear15">
                                        </div>
                                        <div class="labelal">
                                            <span class="errormsg">*</span> Security Code</div>
                                        <div class="txtfild1wrap">
                                            <asp:TextBox ID="txtcaptcha" TabIndex="18" runat="server" class="txtfild1">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqCapha" runat="server" ControlToValidate="txtcaptcha"
                                                SetFocusOnError="True" ErrorMessage="Security Code is mandatory." Font-Size="14px"
                                                ValidationGroup="A" Display="Dynamic">*
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="clear15">
                                    </div>
                                    <div class="agree" style="padding-left: 80px;">
                                        By clicking 'Submit' you agree to the Terms of Service of this site.
                                    </div>
                                    <div class="clear15">
                                    </div>
                                    <div class="submit1" style="padding-left: 70px;">
                                        <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="return Validate();"
                                            CausesValidation="true" TabIndex="19" ValidationGroup="A"><img src="<%=Page.ResolveClientUrl("~/images/Homepage/submit.png")%>" alt="" /></asp:LinkButton>
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
                                <div class="clear40">
                                </div>
                            </div>
                            <div class="bottombrdr">
                            </div>
                            <div class="clear40">
                            </div>
                        </div>
                    </div>
                    <!--col550FR-->
                </div>
                <!--container-->
                <div id="footer">
                    <p style="padding-right: 65px;">
                        <a href="http://logictreeit.com" target="_blank">A Product of LogicTree IT</a> |
                        <a href="terms.html" target="_blank">Terms of Service</a></p>
                </div>
                <!--footer-->
            </div>
            <!--innerwrapper-->
            </div>
            <!--wrapper-->
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        window.onload = function () {
            if (document.getElementById('<%=hdnPackageType.ClientID %>').value != "") {
                active(document.getElementById('<%=hdnPackageType.ClientID %>').value);
                document.getElementById('<%=hdnPackageType.ClientID %>').value = '';
            }
        }
    </script>
</body>
</html>
