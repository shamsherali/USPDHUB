<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgencyListing.aspx.cs"
    Inherits="USPDHUB.OP.inschoolhubin.AgencyListing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolHub.com
    </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="/css/ishglobal.css" rel="stylesheet" type="text/css" media="all">
    <link href="/css/AjaxControlsStyles.css" rel="stylesheet" type="text/css" media="all">
    <link rel="icon" href="/images/ishfav.ico" type="image/x-icon" />
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

// --></script>
</csactiondict>
</head>
<body onload="preloadImages()">
    <script src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>" type="text/javascript"></script>
    <script type="text/javascript">
        function Validate() {
            if ($("#txtStartDate").val() != "") {
                if ($("#ddlHours").val() == "H")
                    $("#ddlHours").val('00')
                if ($("#ddlMints").val() == "M")
                    $("#ddlMints").val('00')
                var currentdate = new Date();
                var fromDate = $("#txtStartDate").val();
                var selDate = new Date(fromDate);
                selDate.setHours(parseInt($("#ddlHours").val()), parseInt($("#ddlMints").val()), 0);
                if (selDate <= currentdate) {
                    alert('Best day and time to call must be later than current date and time.');
                    $get('txtStartDate').focus();
                    return false;
                }
                else
                    return true;
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
    </script>
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
                                        <a href="Default.aspx">Home</a> | <a href="contactus.aspx">Contact Us</a> | <a href="features.html">
                                            Features</a> | <a href="AddTools.aspx">Pricing</a> | <a href="aboutus.html">About Us</a>
                                        | <a href="login.aspx">Login</a>
                                        <%--<a onmouseover="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook-over.gif")%>');return true"
                                            onmouseout="changeImages('social_facebook','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>');return true"
                                            href="https://www.facebook.com/UspDhub" target="_blank">
                                            <img id="social_facebook" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-facebook.gif")%>"
                                                alt="InSchoolHub Facebook" name="social_facebook" width="30" height="33" align="absmiddle"
                                                border="0"></a><a onmouseover="changeImages('social_twitter','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter-over.gif")%>');return true"
                                                    onmouseout="changeImages('social_twitter','<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter.gif")%>');return true"
                                                    href="https://twitter.com/USPDHub" target="_blank"><img id="social_twitter" src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/social-twitter.gif")%>"
                                                        alt="InSchoolHub Twitter" name="social_twitter" width="28" height="33" align="absmiddle"
                                                        border="0"></a>--%></p>
                                </div>
                            </div>
                        </div>
                        <!--bannerright-->
                    </div>
                    <!--banner-->
                </div>
                <div id="content" style="margin-top: 50px;">
                    <div id="containercontact">
                        <div class="left">
                            <h1>
                                SIGN UP<br>
                                <img src="<%=Page.ResolveClientUrl("~/images/ISHOuterImages/headline-dots.gif")%>"
                                    alt="" width="386" height="20" border="0" /></h1>
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
                                    ErrorMessage="Name of Contact Person is mandatory." SetFocusOnError="True" Font-Size="14px"
                                    ValidationGroup="A">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFirstName"
                                    ErrorMessage="Enter Valid Name of Contact Person." SetFocusOnError="True" Font-Size="14px"
                                    ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$" ValidationGroup="A">*
                                </asp:RegularExpressionValidator></div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                &nbsp;&nbsp;&nbsp;Last Name</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtLastName" TabIndex="4" class="signuptextarea" runat="server"
                                    MaxLength="500">
                                </asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastName"
                                    ErrorMessage="Enter Valid Name of Contact Person." SetFocusOnError="True" Font-Size="14px"
                                    ValidationExpression="^(a-z|A-Z|0-9)*[^#$%^&*()']*$" ValidationGroup="A">*
                                </asp:RegularExpressionValidator></div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                &nbsp;&nbsp;&nbsp;Title</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtTitle" TabIndex="5" class="signuptextarea" runat="server" MaxLength="200">
                                </asp:TextBox></div>
                            <div class="clear15">
                            </div>
                            <%if (hdnIsPaid.Value == "" || Convert.ToBoolean(hdnIsPaid.Value) == false)
                              { %>
                            <div class="label1">
                                &nbsp;&nbsp;&nbsp;How did you hear about us?</div>
                            <div class="txtfildwrap">
                                <asp:DropDownList ID="ddlHow" runat="server" Width="250" TabIndex="6">
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
                                <asp:TextBox ID="txtphonenumber" TabIndex="7" runat="server" MaxLength="14" class="signuptextarea">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtphonenumber"
                                    ErrorMessage="Agency Phone Number is mandatory." Font-Size="14px" ValidationGroup="A"
                                    SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtphonenumber"
                                    ErrorMessage="Enter Valid Agency Phone Number." ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                                    SetFocusOnError="True" Font-Size="14px" ValidationGroup="A">*
                                </asp:RegularExpressionValidator></div>
                            <div class="clear15">
                            </div>
                            <div class="label1">
                                <span class="errormsg">* </span>Email Address</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtEmail" TabIndex="8" runat="server" AutoCompleteType="Disabled"
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
                            <%if (hdnIsPaid.Value == "" || Convert.ToBoolean(hdnIsPaid.Value) == false)
                              { %>
                            <div class="label1">
                                &nbsp;&nbsp;&nbsp;Best Day and Time to Call</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtStartDate" runat="server" Width="85px" TabIndex="9" class="signuptextarea"></asp:TextBox>
                                <asp:CalendarExtender ID="calex" runat="server" Format="MM/dd/yyyy" TargetControlID="txtStartDate"
                                    CssClass="MyCalendar">
                                </asp:CalendarExtender>
                                &nbsp;
                                <asp:DropDownList ID="ddlHours" runat="server" TabIndex="10" Width="70px" Style="margin-left: 5px;">
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
                                <asp:DropDownList ID="ddlMints" runat="server" TabIndex="11" Width="80px" Style="margin-left: 5px;">
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
                            <div class="label1">
                                &nbsp;&nbsp;&nbsp;Remarks</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtRemarks" TabIndex="12" Width="240px" Height="50px" runat="server"
                                    TextMode="MultiLine">
                                </asp:TextBox></div>
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
                            <div class="signupbtn">
                                <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="return Validate();"
                                    CausesValidation="true" TabIndex="15" ValidationGroup="A"><img src="<%=Page.ResolveClientUrl("~/images/Homepage/submit.png")%>" alt="" border="0" /></asp:LinkButton>
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
                            </div>
                        </div>
                        <!--contactform-->
                        <!--signupinfo-->
                        <div id="signupinfo">
                            <div>
                                In order to maintain the integrity of the<br>
                                inSchoolHub we will be calling to verify your information.
                                <br>
                                <br>
                                At that time we will be happy to answer any questions you may have.
                                <br>
                                <br>
                                <strong>Contact Information</strong>
                                <br>
                                <br>
                                <strong><span class="signup1">Phone: +91 40 - 6460 1150</span></strong><br>
                                <br>
                                <strong>Hours:</strong> Monday-Friday
                                <br>
                                9:00 a.m. to 6:00 p.m. IST
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
                <div id="footer">
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
