<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgencyListing.aspx.cs"
    Inherits="InschoolAlert.AgencyListing" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile App for Community Outreach, Greater School Safety from inSchoolAlert.com
    </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="<%=Page.ResolveClientUrl("~/css/bootstrap.css")%>" rel="stylesheet">
    <link href="css/ishglobal.css" rel="stylesheet" type="text/css" media="all">
    <link href="<%=Page.ResolveClientUrl("~/css/custom.css")%>" rel="stylesheet">
    <csscriptdict import>
			<script src="<%=Page.ResolveClientUrl("~/scripts/CSScriptLib.js")%>" type="text/javascript"></script>
    </csscriptdict>
    <csactiondict>
    <style>
        .top-btn-right
        {
            float: right;
            margin: 1.8em 0;
        }
        .no-padding
        {
            padding-right: 0px;
            padding-left: 0px;
        }
        .btn-green
        {
            color: #fff;
            background-color: #3cbc9f;
            border-color: #3cbc9f;
        }
        .btn-green:focus, .btn-green.focus
        {
            color: #fff;
            background-color: #3cbc9f;
            border-color: #3cbc9f;
        }
        .btn-green:hover
        {
            color: #fff;
            background-color: #34ad92;
            border-color: #34ad92;
        }
        .btn
        {
            display: inline-block;
            padding: 6px 12px;
            margin-bottom: 0;
            font-size: 14px;
            font-weight: normal;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -ms-touch-action: manipulation;
            touch-action: manipulation;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
        }
        .btn:focus, .btn:active:focus, .btn.active:focus, .btn.focus, .btn:active.focus, .btn.active.focus
        {
            outline: thin dotted;
            outline: 5px auto -webkit-focus-ring-color;
            outline-offset: -2px;
        }
        .btn:hover, .btn:focus, .btn.focus
        {
            color: #333;
            text-decoration: none;
        }
        .btn:active, .btn.active
        {
            background-image: none;
            outline: 0;
            -webkit-box-shadow: inset 0 3px 5px rgba(0, 0, 0, .125);
            box-shadow: inset 0 3px 5px rgba(0, 0, 0, .125);
        }
        .btn.disabled, .btn[disabled], fieldset[disabled] .btn
        {
            cursor: not-allowed;
            filter: alpha(opacity=65);
            -webkit-box-shadow: none;
            box-shadow: none;
            opacity: .65;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="mainwrapper">
                <div id="container">
                    <div id="banner">
                        <div id="bannerleft">
                            <img src="<%=Page.ResolveClientUrl("~/images/inschoolalert.png")%>" alt="InSchoolAlert"
                                border="0"></div>
                        <!--bannerleft-->
                        <div id="bannerright">
                            <div id="navigation" class="top-btn-right">
                                <div align="right">
                                    <p>
                                        <a href="Default.aspx">Home</a> | <a href="HowToWorks.aspx">How It Works</a> | <a
                                            href="aboutus.htm">About Us</a> |
                                        <button type="button" class="btn btn-green">
                                            Login</button></p>
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
                                <img src="<%=Page.ResolveClientUrl("~/images/headline-dots.gif")%>" alt="" width="386"
                                    height="20" border="0" /></h1>
                        </div>
                        <!--contactform-->
                        <div id="signupform">
                            <div>
                                <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                                    HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                            </div>
                            <div class="errormsg">
                                * Marked fields are mandatory.</div>
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
                                <span class="errormsg">* </span>Zipcode</div>
                            <div class="txtfildwrap">
                                <asp:TextBox ID="txtzipcode" MaxLength="10" runat="server" Rows="7" TabIndex="11"
                                    class="signuptextarea"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtzipcode"
                                    runat="server" SetFocusOnError="True" ValidationGroup="A" ErrorMessage="Zip Code is mandatory.">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="clear15">
                            </div>
                            <%if (hdnIsPaid.Value == "" || Convert.ToBoolean(hdnIsPaid.Value) == false)
                              { %>
                            <div class="label1" style="display: none;">
                                <span class="errormsg" style="margin-left: 10px;"></span>Promo Code</div>
                            <div class="txtfildwrap" style="display: none;">
                                <asp:TextBox runat="server" ID="txtPromoCode" class="signuptextarea" TabIndex="12"></asp:TextBox>
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
                                <asp:TextBox ID="txtcaptcha" TabIndex="13" runat="server" class="signuptextarea">
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
                                By clicking 'Submit' you agree to the Terms of Services of this site.
                            </div>
                            <div class="signupbtn">
                                <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="btnSubmit_Click" CausesValidation="true"
                                    TabIndex="14" ValidationGroup="A"><img src="<%=Page.ResolveClientUrl("~/images/submit.png")%>" alt="" border="0" /></asp:LinkButton>
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
                                &nbsp;
                            </div>
                        </div>
                        <!--signupinfo-->
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
            <!--Footer-->
            <footer>
  <div class="container">
    <div class="footer-text">LogicTree IT Solutions Inc.  |   6060 Sunrise Vista Drive, Suite 3500  |  Citrus Heights, CA 95610</div>
    <div class="footer-text margintop10"><a href="mailto:info@logictreeit.com">Info@LogicTreeIT.com</a> |  916.676.7335  |  800.281.0263</div>
  </div>
</footer>
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
            <script src="Scripts/bootstrap.min.js"></script>
            <!--End Footer-->
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
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
                $get('<%=lblUserNameCheck.ClientID %>').innerHTML = '<font color=red>Email address is already in use; please use a different one.</font>';
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
</body>
</html>
