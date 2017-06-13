<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="LeadsApplication.ContactInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Contact Information</title>
    <link href="Styles/twovieglobal.css" rel="stylesheet" type="text/css" />
    <link href="Styles/AjaxControlsStyles.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <link href="Scripts/jquery.timepicker.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="Scripts/jquery.timepicker.js" type="text/javascript"></script>
    <%-- <script src='https://www.google.com/recaptcha/api.js'></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Scr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="outerwrapper" style="background-image: none;">
                <div id="wrapper">
                    <div id="banner">
                        <div id="brand">
                            <img src="http://www.uspdhub.com/images/verticallogos/<%=LogoName %>" border="0">
                        </div>
                        <div id="bannerright">
                            <div id="social">
                            </div>
                            <div id="navspace">
                            </div>
                        </div>
                        <!--bannerright-->
                    </div>
                    <!--banner-->
                    <div id="container">
                        <div id="contentleft500" style="float: none; margin-left: 205px; width: 600px;">
                            <h1 style="float: left; width: 600px;">
                                Information Request Form</h1>
                            <div id="signupform">
                                <div style="font-weight: bold; line-height: 20px;">
                                    Disclaimer: We will not share, rent or sell the information you provide by completing
                                    this form.
                                </div>
                                <div style="text-align: center">
                                    <div style="width: 65%; margin: 0 auto; text-align: left; line-height: 20px;">
                                        <asp:ValidationSummary ID="ValidateUserDetails" runat="server" ValidationGroup="A"
                                            HeaderText="The following error(s) occurred:" CssClass="errormsg_text" />
                                    </div>
                                </div>
                                <div class="errormsg">
                                    <strong>&nbsp;Note: </strong>* Marked fields are mandatory.</div>
                                <div class="label">
                                    <span class="errormsg">*</span> Contact Name</div>
                                <div class="txtfildwrap">
                                    <asp:TextBox ID="txtAgencyname" TabIndex="1" runat="server" MaxLength="500" class="signuptextarea"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAgencyname"
                                        ErrorMessage="Contact Name is mandatory." Font-Size="14px" ValidationGroup="A"
                                        SetFocusOnError="True" CssClass="errormsg_text">*
                                    </asp:RequiredFieldValidator></div>
                                <div class="label">
                                    <span class="errormsg">*</span> Business Name</div>
                                <div class="txtfildwrap">
                                    <asp:TextBox ID="txtBusinessName" TabIndex="2" runat="server" MaxLength="500" class="signuptextarea"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBusinessName"
                                        ErrorMessage="Business Name is mandatory." Font-Size="14px" ValidationGroup="A"
                                        SetFocusOnError="True" CssClass="errormsg_text">*
                                    </asp:RequiredFieldValidator></div>
                                <div class="label">
                                    &nbsp; Phone Number</div>
                                <div class="txtfildwrap">
                                    <asp:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtphonenumber"
                                        WatermarkText="xxx-xxx-xxxx" runat="server" WatermarkCssClass="signuptextarea">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:TextBox ID="txtphonenumber" TabIndex="3" runat="server" MaxLength="14" class="signuptextarea">
                                    </asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtphonenumber"
                                        ErrorMessage="Enter Valid Phone Number." ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$"
                                        SetFocusOnError="True" Font-Size="14px" CssClass="errormsg_text" ValidationGroup="A">*
                                    </asp:RegularExpressionValidator></div>
                                <div class="label">
                                    <span class="errormsg">* </span>Email Address</div>
                                <div class="txtfildwrap">
                                    <asp:TextBox ID="txtEmail" TabIndex="4" runat="server" AutoCompleteType="Disabled"
                                        class="signuptextarea" tooltipText="Valid email address required. Your email address will be your login ID.">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Email Address of Contact Person is mandatory." Font-Size="14px"
                                        Display="Dynamic" SetFocusOnError="True" ValidationGroup="A" CssClass="errormsg_text">*
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                        Font-Size="14px" ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="A" SetFocusOnError="True" CssClass="errormsg_text">*
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="label">
                                    <span class="errormsg">* </span>City</div>
                                <div class="txtfildwrap">
                                    <asp:TextBox ID="txtCity" TabIndex="5" runat="server" class="signuptextarea">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                                        ErrorMessage="City is mandatory." Font-Size="14px" ValidationGroup="A" SetFocusOnError="True"
                                        CssClass="errormsg_text">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="label">
                                    <span class="errormsg">* </span>State</div>
                                <div class="txtfildwrap">
                                    <asp:DropDownList ID="drpState" TabIndex="6" runat="server" Width="241">
                                        <asp:ListItem Value="0">-- Select State --</asp:ListItem>
                                        <asp:ListItem Value="Alabama">Alabama</asp:ListItem>
                                        <asp:ListItem Value="Alaska">Alaska</asp:ListItem>
                                        <asp:ListItem Value="Arizona">Arizona</asp:ListItem>
                                        <asp:ListItem Value="Arkansas">Arkansas</asp:ListItem>
                                        <asp:ListItem Value="California">California</asp:ListItem>
                                        <asp:ListItem Value="Colorado">Colorado</asp:ListItem>
                                        <asp:ListItem Value="Connecticut">Connecticut</asp:ListItem>
                                        <asp:ListItem Value="District">District of Columbia</asp:ListItem>
                                        <asp:ListItem Value="Delaware">Delaware</asp:ListItem>
                                        <asp:ListItem Value="Florida">Florida</asp:ListItem>
                                        <asp:ListItem Value="Georgia">Georgia</asp:ListItem>
                                        <asp:ListItem Value="Hawaii">Hawaii</asp:ListItem>
                                        <asp:ListItem Value="Idaho">Idaho</asp:ListItem>
                                        <asp:ListItem Value="Illinois">Illinois</asp:ListItem>
                                        <asp:ListItem Value="Indiana">Indiana</asp:ListItem>
                                        <asp:ListItem Value="Iowa">Iowa</asp:ListItem>
                                        <asp:ListItem Value="Kansas">Kansas</asp:ListItem>
                                        <asp:ListItem Value="Kentucky">Kentucky</asp:ListItem>
                                        <asp:ListItem Value="Louisiana">Louisiana</asp:ListItem>
                                        <asp:ListItem Value="Maine">Maine</asp:ListItem>
                                        <asp:ListItem Value="Maryland">Maryland</asp:ListItem>
                                        <asp:ListItem Value="Massachusetts">Massachusetts</asp:ListItem>
                                        <asp:ListItem Value="Michigan">Michigan</asp:ListItem>
                                        <asp:ListItem Value="Minnesota">Minnesota</asp:ListItem>
                                        <asp:ListItem Value="Mississippi">Mississippi</asp:ListItem>
                                        <asp:ListItem Value="Missouri">Missouri</asp:ListItem>
                                        <asp:ListItem Value="Montana">Montana</asp:ListItem>
                                        <asp:ListItem Value="Nebraska">Nebraska</asp:ListItem>
                                        <asp:ListItem Value="Nevada">Nevada</asp:ListItem>
                                        <asp:ListItem Value="New Hampshire">New Hampshire</asp:ListItem>
                                        <asp:ListItem Value="New Jersey">New Jersey</asp:ListItem>
                                        <asp:ListItem Value="New Mexico">New Mexico</asp:ListItem>
                                        <asp:ListItem Value="New York">New York</asp:ListItem>
                                        <asp:ListItem Value="North Carolina">North Carolina</asp:ListItem>
                                        <asp:ListItem Value="North Dakota">North Dakota</asp:ListItem>
                                        <asp:ListItem Value="Ohio">Ohio</asp:ListItem>
                                        <asp:ListItem Value="Oklahoma">Oklahoma</asp:ListItem>
                                        <asp:ListItem Value="Oregon">Oregon</asp:ListItem>
                                        <asp:ListItem Value="Pennsylvania">Pennsylvania</asp:ListItem>
                                        <asp:ListItem Value="Rhode Island">Rhode Island</asp:ListItem>
                                        <asp:ListItem Value="South Carolina">South Carolina</asp:ListItem>
                                        <asp:ListItem Value="South Dakota">South Dakota</asp:ListItem>
                                        <asp:ListItem Value="Tennessee">Tennessee</asp:ListItem>
                                        <asp:ListItem Value="Texas">Texas</asp:ListItem>
                                        <asp:ListItem Value="Utah">Utah</asp:ListItem>
                                        <asp:ListItem Value="Vermont">Vermont</asp:ListItem>
                                        <asp:ListItem Value="Virginia">Virginia</asp:ListItem>
                                        <asp:ListItem Value="Washington">Washington</asp:ListItem>
                                        <asp:ListItem Value="West Virginia">West Virginia</asp:ListItem>
                                        <asp:ListItem Value="Wisconsin">Wisconsin</asp:ListItem>
                                        <asp:ListItem Value="Wyoming">Wyoming</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" SetFocusOnError="True"
                                        Font-Size="14px" ControlToValidate="drpState" runat="server" InitialValue="0"
                                        ValidationGroup="A" ErrorMessage="State is mandatory." CssClass="errormsg_text">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="label">
                                    &nbsp;&nbsp;&nbsp;Best Day to Call</div>
                                <div class="txtfildwrap">
                                    <asp:DropDownList ID="ddlDays" runat="server" TabIndex="8" Height="28px">
                                        <asp:ListItem Text="Select a Day" Value="D"></asp:ListItem>
                                        <asp:ListItem Value="Monday"></asp:ListItem>
                                        <asp:ListItem Value="Tuesday"></asp:ListItem>
                                        <asp:ListItem Value="Wednesday"></asp:ListItem>
                                        <asp:ListItem Value="Thursday"></asp:ListItem>
                                        <asp:ListItem Value="Friday"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<input id="timePick" type="text" style="width: 110px;" placeholder="Select Time"
                                        runat="server" class="signuptextarea" readonly />--%>
                                </div>
                                <div class="clear15">
                                </div>
                                <div class="txtfildwrap" style="margin-left: 120px;">
                                    <asp:Image Visible="false" runat="server" ID="img1" ImageUrl="~/GenerateCaptcha.aspx"
                                        AlternateText="Captcha" CssClass="captch" />
                                    <cc1:CaptchaControl ID="captcha" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5"
                                        CaptchaHeight="35" CaptchaWidth="150" CaptchaMinTimeout="5" CaptchaMaxTimeout="3600"
                                        BackColor="White" NoiseColor="White" Width="150px" BorderColor="White" BorderStyle="Double"
                                        CaptchaChars="ACDEFGHJKLNPQRTUVXYZ2346789" />
                                </div>
                                <div class="clear15">
                                </div>
                                <div class="txtfildwrap">
                                    <asp:TextBox ID="txtcaptcha" TabIndex="13" runat="server" class="signuptextarea">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqCapha" runat="server" ControlToValidate="txtcaptcha"
                                        SetFocusOnError="True" ErrorMessage="Security Code is mandatory." Font-Size="14px"
                                        ValidationGroup="A">*
                                    </asp:RequiredFieldValidator></div>
                                <div class="label">
                                    <span class="errormsg">*</span> Security Code</div>
                                <div class="clear15">
                                </div>
                                <%-- <div class="g-recaptcha" data-sitekey="<%= ConfigurationManager.AppSettings["SiteKey"] %>"
                                    style="margin-left: 120px;">
                                </div>--%>
                                <div class="clear15">
                                </div>
                                <div class="signupbtn">
                                    <asp:LinkButton ID="lnkSubmit" runat="server" OnClick="btnSubmit_Click" CausesValidation="true"
                                        TabIndex="14" ValidationGroup="A" OnClientClick="return Validate();"><img src="<%=Page.ResolveClientUrl("~/images/twoviesubmit.png")%>" border="0" /></asp:LinkButton>
                                    <br />
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                                <div>
                                    <asp:Label runat="server" ID="lblErrorMSG" ForeColor="Red"></asp:Label>
                                    <asp:HiddenField ID="hdnResellerName" Value="LogicTreeIT" runat="server" />
                                </div>
                            </div>
                            <br>
                        </div>
                        <!--contentleft377-->
                        <div id="footer" style="float: none; margin-left: 117px; width: 600px;">
                            <p>
                                <a href="http://www.logictreeit.com/" target="_blank">A Product of Logictree IT Solutions,
                                    Inc </a>
                        </div>
                        <!--footer-->
                    </div>
                    <!--container-->
                </div>
                <!--wrapper-->
            </div>
            <!--outerwrapper-->
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        $(function () {
            //LoadTimer();
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
        function Validate() {
            if ($("#txtStartDate").val() != "") {
                var currentdate = new Date();
                var fromDate = $("#txtStartDate").val();
                var selDate = new Date(fromDate);
                if (selDate < currentdate) {
                    alert('Best day and time to call must be later than current date.');
                    $get('txtStartDate').focus();
                    return false;
                }
                else
                    return true;
            }
            var captcha_response = grecaptcha.getResponse();
            if (captcha_response.length == 0) {
                // Captcha is not Passed
                return false;
            }
            else {
                // Captcha is Passed
                return true;
            }
        }
    </script>
</body>
</html>
