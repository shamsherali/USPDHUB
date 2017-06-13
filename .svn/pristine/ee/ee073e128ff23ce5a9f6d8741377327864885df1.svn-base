<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeBehind="MobileAppSettings.aspx.cs" Inherits="USPDHUB.Business.MyAccount.MobileAppSettings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="Server">
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <link href="../../css/jquery-bubble-popup-v3.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-bubble-popup-v3.min.js" type="text/javascript"></script>
    <style type="text/css">
        .label_header
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #005aa0;
        }
        
        .label_checkbox1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
            color: #005aa0;
        }
        .label_checkbox2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
            color: #f15a29;
        }
        .label_checkbox3
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #353535;
        }
        .space
        {
            padding-left: 25px;
        }
        .align-right
        {
            width: 50%;
        }
        .select
        {
            width: 120px;
            font-weight: normal;
            padding: 2px;
        }
        .Tabstext
        {
            font-size: 12px;
        }
        .couponcode
        {
            width: 100px;
        }
        .couponcode:hover .coupontooltip
        {
            display: block;
        }
        
        .coupontooltip
        {
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            margin-left: 110px;
            border: 1px dashed #297CCF;
            padding: 10px;
            position: absolute;
            z-index: 1000;
            width: 300px;
            height: auto;
        }
        .class1
        {
            display:none;
            }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',
                innerHtml: 'Default button names appear in<br /> parenthesis. To change a button name, <br/>enter the desired name in the text block <br/>and update.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
        }); 
    </script>
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $('#help1').CreateBubblePopup({

                position: 'top',
                align: 'center',

                innerHtml: 'Default button names appear in<br /> parenthesis. To change a button name, <br/>enter the desired name in the text block <br/>and update.',
                innerHtmlStyle: {
                    color: '#FFFFFF',
                    'text-align': 'center'
                },
                themeName: 'all-blue',
                themePath: '../../Scripts/jquerybubblepopup-themes'

            });
        });

    </script>
    <asp:UpdatePanel ID="uppnlpopup1" runat="server">
        <ContentTemplate>
            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="page-padding">
                <tr>
                    <td class="valign-top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="page-title">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt" runat="server" Width="0" BorderStyle="none" BorderColor="white"
                                        Style="border: 0; border-color: White!important;"></asp:TextBox>
                                    Edit Mobile App Settings
                                </td>
                                <td class="right">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                        <ProgressTemplate>
                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" class="inputgrid">
                                    <asp:Label ID="lblstatusmessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:ValidationSummary ID="ValidateUserDetails" runat="server" Style="text-align: left;"
                                                    ValidationGroup="APPS" HeaderText="The following error(s) occurred:" />
                                                <asp:Label ID="lblProfileTabs" runat="server" Style="display: none;" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="margin-top">
                            <tr>
                                <td class="valign-top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>" width="9"
                                                    height="28">
                                            </td>
                                            <td class="new-header">
                                                Mobile App Settings
                                            </td>
                                            <td>
                                                <img src="<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>" width="9"
                                                    height="28">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="profile-input">
                                        <tr>
                                            <td align="left" style="padding-left: 30px;">
                                                <table width="80%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="30" align="center">
                                                            <input type="checkbox" runat="server" id="Chkmain" onclick="return EnableMobileApp(this.checked)" />
                                                            <label for="checkbox" class="label_checkbox1">
                                                                Enable Mobile App Listing
                                                            </label>
                                                            &nbsp;&nbsp; <span class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip">If this box is checked, your App will be listed in the <u>
                                                                    Hub's Master App.</u> Note: This will not affect any branded app's listing in the
                                                                    App Stores.</span> </span>
                                                            <div>
                                                                (Does not affect Branded App listing in App Stores.)</div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30">
                                                            <label for="checkbox" class="label_header">
                                                                <b>Check the boxes below to display items.</b>
                                                                <label class="label_checkbox1" for="checkbox">
                                                                </label>
                                                            </label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30" class="space">
                                                            <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="30">
                                                                        <div style="float: left;">
                                                                            <input type="checkbox" runat="server" id="chkBusinessDetails" onclick="return chkBusinessDetails_onclick(this.checked)" />
                                                                            <label for="checkbox2" class="label_checkbox2">
                                                                                Display Details <a id="AddImageProfileDetails" href="javascript:ModalHelpPopup('Display/Hide Mobile App Details',156,'');">
                                                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a>
                                                                            </label>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <%if (Convert.ToBoolean(Session["IsLiteVersion"]) == false)
                                                                  { %>
                                                                <tr>
                                                                    <td>
                                                                        <span style="font-weight: bold;">*Note: If you have uploaded a long logo, the display
                                                                        details will not appear on the app header.</b>
                                                                    </td>
                                                                </tr>
                                                                <%} %>
                                                                <tr>
                                                                    <td align="left" valign='top' class="space">
                                                                        <table id='tblBD' width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td height="30">
                                                                                    <input type="checkbox" disabled="disabled" runat="server" name="BD" id="chkBusinessName"
                                                                                        onclick="return SelectBusinessDetailsCheckBox();" />
                                                                                    <%-- <asp:CheckBox runat="server" ID="chkBusinessName" />--%>
                                                                                    <label for="checkbox3" class="label_checkbox3">
                                                                                        Organization Name</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="30">
                                                                                    <input type="checkbox" disabled="disabled" runat="server" name="BD" id="chkLogo"
                                                                                        onclick="return SelectBusinessDetailsCheckBox();" />
                                                                                    <%-- <asp:CheckBox runat="server" ID="chkBusinessName" />--%>
                                                                                    <label for="checkbox3" class="label_checkbox3">
                                                                                        Logo</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="30">
                                                                                    <input type="checkbox" runat="server" name="BD" id="chkAddress" onclick="return SelectBusinessDetailsCheckBox();" />
                                                                                    <%--<asp:CheckBox ID="chkAddress" runat="server" />--%>
                                                                                    <label for="checkbox3" class="label_checkbox3">
                                                                                        Street Address</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="30">
                                                                                    <input type="checkbox" runat="server" name="BD" id="chkCity" onclick="return SelectBusinessDetailsCheckBox();" />
                                                                                    <%--<asp:CheckBox ID="chkCity" runat="server" />--%>
                                                                                    <label for="checkbox4" class="label_checkbox3">
                                                                                        City</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="30">
                                                                                    <input type="checkbox" runat="server" name="BD" id="chkState" onclick="return SelectBusinessDetailsCheckBox();" />
                                                                                    <%--<asp:CheckBox ID="chkState" runat="server" />--%>
                                                                                    <label for="checkbox4" class="label_checkbox3">
                                                                                        State</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="30">
                                                                                    <input type="checkbox" runat="server" name="BD" id="chkCountry" onclick="return SelectBusinessDetailsCheckBox();" />
                                                                                    <%--<asp:CheckBox ID="chkCountry" runat="server" />--%>
                                                                                    <label for="checkbox4" class="label_checkbox3">
                                                                                        Country</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="30">
                                                                                    <input type="checkbox" runat="server" name="BD" id="chkZipcode" onclick="return SelectBusinessDetailsCheckBox();" />
                                                                                    <%--<asp:CheckBox ID="chkZipcode" runat="server" />--%>
                                                                                    <label for="checkbox6" class="label_checkbox3">
                                                                                        Zip Code</label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="30">
                                                                                    <input type="checkbox" runat="server" name="BD" id="chkEmergencyNumber" onclick="return SelectBusinessDetailsCheckBox();" />
                                                                                    <label for="checkbox6" class="label_checkbox3">
                                                                                        Enter text to display on app header
                                                                                    </label>
                                                                                    <span style="padding-left: 5px;">
                                                                                        <asp:TextBox ID="txtEmrgncyNumber" Text="9-1-1" runat="server" Width="250px" MaxLength="30"
                                                                                            onkeyup="CountMaxLength(this);" onChange="CountMaxLength(this);"></asp:TextBox>
                                                                                    </span>
                                                                                    <br />
                                                                                    <span style="padding-left: 235px; font-weight: bold;">
                                                                                        <asp:Label ID="lblAppHeaderTextCount" runat="server"></asp:Label>
                                                                                        Characters remaining. <span style="padding-left: 15px;"></span>Max characters 30</span>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="pnlActions" runat="server">
                                                                <table width="100%">
                                                                    <tr id='trPushNotifications' runat="server" visible="false">
                                                                        <td class="space">
                                                                            <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td height="30">
                                                                                        <input type="checkbox" runat="server" id="chkPushNotifications" />
                                                                                        <%--<asp:CheckBox ID="chkEvents" runat="server" />--%>
                                                                                        <label for="checkbox13" class="label_checkbox2">
                                                                                            Push Notifications</label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="space">
                                                                            <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td height="30">
                                                                                        <div style="float: left;">
                                                                                            <input type="checkbox" runat="server" id="chkContactDetails" onclick="return chkContactDetails_onclick(this.checked)" />
                                                                                            <%--<asp:CheckBox ID="chkContactDetails" runat="server" AutoPostBack="true" OnCheckedChanged="chkContactDetails_CheckedChanged" />--%>
                                                                                            <label for="checkbox7" class="label_checkbox2">
                                                                                                Display Action Buttons <a href="javascript:ModalHelpPopup('Display/Hide Action Buttons',155,'');">
                                                                                                    <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" /></a></label>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                                <div id="div1">
                                                                                    <tr>
                                                                                        <td align="left" class="space">
                                                                                            <table id='tblCD' width="95%" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td height="30">
                                                                                                        <input type="checkbox" runat="server" id="chkPhotoCapture" onclick="return SelectContactDetailsCheckBox();" />
                                                                                                        <%--<asp:CheckBox ID="chkEmailID" runat="server" />--%>
                                                                                                        <label for="checkbox9" class="label_checkbox3">
                                                                                                            Photo Capture</label>
                                                                                                        <span class="couponcode">
                                                                                                            <img border="0" src="../../images/Dashboard/new.png" />
                                                                                                            <span class="coupontooltip">By checking this box you allow your users to include their
                                                                                                                Photos when they contact you. </span></span>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30">
                                                                                                        <input type="checkbox" runat="server" id="chkGeoLocation" onclick="return SelectContactDetailsCheckBox();" />
                                                                                                        <label for="checkbox9" class="label_checkbox3">
                                                                                                            Geo Location (GPS Control)</label>
                                                                                                        <span class="couponcode">
                                                                                                            <img border="0" src="../../images/Dashboard/new.png" />
                                                                                                            <span class="coupontooltip">By checking this box you allow your users to include their
                                                                                                                Geo Location when they contact you. </span></span>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30">
                                                                                                        <input type="checkbox" runat="server" id="chkSharing" onclick="return SelectContactDetailsCheckBox();" />
                                                                                                        <label for="checkbox9" class="label_checkbox3">
                                                                                                            Sharing</label><span class="couponcode">
                                                                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                                                                <span class="coupontooltip">By checking this box a Share button will be available for
                                                                                                                    you to include on the information you are publishing. The App user can click on
                                                                                                                    this button and share specific content to their personal social media accounts.
                                                                                                                </span></span>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30">
                                                                                                        <input type="checkbox" runat="server" id="chkContact_Tip_CustomMessage" onclick="return SelectContactDetailsCheckBox();" />
                                                                                                        <label for="checkbox9" class="label_checkbox3">
                                                                                                            Enter text to display for contact /
                                                                                                            <%=textDisplay %>
                                                                                                        </label>
                                                                                                        <span style="padding-left: 5px;">
                                                                                                            <asp:TextBox ID="txtContact_Tip_CustomMessage" runat="server" Width="250px" MaxLength="30"
                                                                                                                onkeyup="CountMaxLengthTips(this);" onChange="CountMaxLengthTips(this);"></asp:TextBox>
                                                                                                        </span>
                                                                                                        <br />
                                                                                                        <span style="padding-left: 240px; font-weight: bold;">
                                                                                                            <asp:Label ID="lblCharsTips" runat="server"></asp:Label>
                                                                                                            Characters remaining. <span style="padding-left: 15px;"></span>Max characters 30</span>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="30">
                                                                                                        <input type="checkbox" runat="server" id="chkAnonymous" onclick="return SelectContactDetailsCheckBox();" />
                                                                                                        <label for="checkbox9" class="label_checkbox3">
                                                                                                            Anonymous Control</label>
                                                                                                        <span class="couponcode">
                                                                                                            <img border="0" src="../../images/Dashboard/new.png" />
                                                                                                            <span class="coupontooltip">By checking this box users will have the option to send
                                                                                                                their messages anonymously. Leaving the box unchecked will force users to provide
                                                                                                                their first name and either their phone number or email address. </span>
                                                                                                        </span>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr  class="class1">
                                                                                                    <td height="30">
                                                                                                        <input type="checkbox" runat="server" id="chkGPS" onclick="return SelectContactDetailsCheckBox();" />
                                                                                                        <label for="checkbox9" class="label_checkbox3">
                                                                                                            GPS Control</label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="class1">
                                                                                                    <td height="30">
                                                                                                        <input type="checkbox" runat="server" style="display: none;" id="chkPhonenumber"
                                                                                                            onclick="return SelectContactDetailsCheckBox();" />
                                                                                                        <%--<asp:CheckBox ID="chkPhonenumber" runat="server" />--%>
                                                                                                        <label for="checkbox8" class="label_checkbox3">
                                                                                                            &nbsp; Phone (click to call)</label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="display: none;" id="trphonenumbers">
                                                                                                    <td style="height: 30px;">
                                                                                                        <div class="label_checkbox3" style="padding-left: 25px; display: none;">
                                                                                                            <asp:RadioButton ID="rbmainph" runat="server" GroupName="phone" Checked="true" onclick="enable_disableAlterPH();" />
                                                                                                            <asp:Label runat="server" Text="Phone Number" Width="110px"></asp:Label>
                                                                                                            <asp:Label runat="server" ID="lblPhoneNumber" Font-Bold="true"></asp:Label>
                                                                                                            <br />
                                                                                                            <asp:RadioButton ID="rbalterph" runat="server" GroupName="phone" onclick="enable_disableAlterPH();" />
                                                                                                            <asp:Label ID="Label1" runat="server" Text="Alternate Number" Width="110px"></asp:Label>
                                                                                                            <asp:TextBox ID="txtalternateph" runat="server" Width="100px" MaxLength="14" Font-Bold="true"></asp:TextBox>
                                                                                                            <cc1:TextBoxWatermarkExtender ID="MaskedEditExtender1" TargetControlID="txtalternateph"
                                                                                                                WatermarkText="xxx-xxx-xxxx" runat="server" WatermarkCssClass="txtfild">
                                                                                                            </cc1:TextBoxWatermarkExtender>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtalternateph"
                                                                                                                ErrorMessage="Phone Number is mandatory." Font-Size="14px" ValidationGroup="group"
                                                                                                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="group"
                                                                                                                runat="server" ControlToValidate="txtalternateph" ErrorMessage="Enter Valid Mobile Number"
                                                                                                                Font-Size="XX-Small" ValidationExpression="^[0-9]\d{2}-\d{3}-\d{4}$">*</asp:RegularExpressionValidator>
                                                                                                        </div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="class1">
                                                                                                    <td style="height: 30px;">
                                                                                                        <input type="checkbox" runat="server" id="chkContactUs" style="display: none;" onclick="return SelectContactDetailsCheckBox();" />
                                                                                                        <label for="checkbox9" class="label_checkbox3">
                                                                                                            &nbsp; Contact Us Form</label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="display: none;">
                                                                                                    <td style="padding-left: 40px;">
                                                                                                        Email for Communication:
                                                                                                        <asp:TextBox ID="txtCommEmail" runat="server" CssClass="textfield" Width="200px"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCommEmail"
                                                                                                            ErrorMessage="Email for Communication is mandatory." ValidationGroup="APPS">*</asp:RequiredFieldValidator>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCommEmail"
                                                                                                            ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                                            ValidationGroup="APPS" SetFocusOnError="True">*</asp:RegularExpressionValidator>
                                                                                                        <br />
                                                                                                        <b>*Note: </b>All messages and tips sent by the Mobile App user (the public) will
                                                                                                        be sent to this email.
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </div>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="profile-btntbl">
                                        <tr>
                                            <td class="align-right" valign="top">
                                                <asp:Button ID="btncancelupdate" CssClass="button" runat="server" Text="Back" OnClick="btncancelupdate_Click" />&nbsp;&nbsp;
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" ValidationGroup="TABS"
                                                    OnClientClick="return CheckingValidation()" OnClick="btnUpdate_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnPackageNumber" runat="server" />
                        <asp:HiddenField runat="server" ID="hdnPermissionType" />
                        <input type="hidden" runat="server" id="hdnEmergencyPhoneNumber" value="For Emergencies Dial 9-1-1" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_cphUser_txtalternateph').keyup(function (event) {
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
    <script language="javascript" type="text/javascript">
        function MakeDefaultSettings(value) {
            EnableMobileApp(value);
            SelectBusinessDetailsCheckBox();
            SelectContactDetailsCheckBox();
            enable_disableAlterPH();

            if (document.getElementById("<%=hdnPackageNumber.ClientID %>").value != "") {
                if (parseInt(document.getElementById("<%=hdnPackageNumber.ClientID %>").value) <= 4) {
                    document.getElementById("<%=chkPhotoCapture.ClientID %>").disabled = true;
                    document.getElementById("<%=chkGeoLocation.ClientID %>").disabled = true;
                }
            }
        }


        //Main Check for Mobile App Enable OR Not
        function EnableMobileApp(value) {
            var chk_arr = $('[type=checkbox]');
            var chklength = chk_arr.length;

            if (value == true) {
                for (k = 0; k < chklength; k++) {
                    if (k != 0) {
                        chk_arr[k].disabled = false;
                    }
                }
            } else {
                for (k = 0; k < chklength; k++) {
                    if (k != 0) {
                        chk_arr[k].disabled = true;
                    }
                }
            }

            document.getElementById("<%=chkBusinessName.ClientID %>").disabled = true;
            document.getElementById("<%=chkLogo.ClientID %>").disabled = true;
            //document.getElementById("<%=chkZipcode.ClientID %>").disabled = true;

        }


        //Business Details Check Box
        function chkBusinessDetails_onclick(value) {
            $('#tblBD input:checkbox').attr('checked', value);

            document.getElementById("<%=chkBusinessName.ClientID %>").checked = true;
            document.getElementById("<%=chkLogo.ClientID %>").checked = true;
            //document.getElementById("<%=chkZipcode.ClientID %>").checked = true;



        }

        //Contact Details Checkbox
        function chkContactDetails_onclick(value) {
            $('#tblCD input:checkbox').attr('checked', value);

            if (value == true) {
                document.getElementById("trphonenumbers").style.display = "";
            }
            else {
                document.getElementById("trphonenumbers").style.display = "none";
            }
        }

        //Child Business Checkboxes
        function SelectBusinessDetailsCheckBox() {
            var chk_arr = $('#tblBD input:checkbox');
            var chklength = chk_arr.length;

            var isAll = false;

            for (k = 0; k < chklength; k++) {
                if (chk_arr[k].checked == true) {
                    //document.getElementById("<%=chkBusinessDetails.ClientID %>").checked = true;
                    isAll = true;
                }
                else {
                    isAll = false;
                    break;
                    //document.getElementById("<%=chkBusinessDetails.ClientID %>").checked = false;
                }
            }

            document.getElementById("<%=chkBusinessDetails.ClientID %>").checked = isAll;

        }

        //Child Contact Checkboxes
        function SelectContactDetailsCheckBox() {
            var chk_arr = $('#tblCD input:checkbox');
          //checking for tr with display none
            var chkavail = $('tr .class1').each(function () {
                return ($(this).css('display') === 'none');
            }).length;

            //making loop run for the length of tr that are visible(display block).
            var chklength = (chk_arr.length) - (chkavail);
            var isAll = false;
            for (k = 0; k < chklength; k++) {
                if (chk_arr[k].checked == true) {
                     isAll = true;
                }
                else {
                     isAll = false;
                    break;
                    //document.getElementById("<%=chkContactDetails.ClientID %>").checked = false;
                }
            }
            document.getElementById("<%=chkContactDetails.ClientID %>").checked = isAll;

            if (document.getElementById("<%=chkPhonenumber.ClientID %>").checked == true) {
                document.getElementById("trphonenumbers").style.display = "";
            }
            else {
                document.getElementById("trphonenumbers").style.display = "none";
            }

            if (document.getElementById("<%=chkContactUs.ClientID %>").checked == false) {
                $("#ctl00_cphUser_txtCommEmail").attr("disabled", "disabled");
            }
            else {
                $("#ctl00_cphUser_txtCommEmail").removeAttr("disabled");
            }
        }
        function DisableCommunication() {
            if (document.getElementById("<%=chkContactUs.ClientID %>").checked == false) {
                $("#ctl00_cphUser_txtCommEmail").attr("disabled", "disabled");
            }
        }
        window.onload = function () {
            DisableCommunication();
            CountMaxLength(document.getElementById('<%=txtEmrgncyNumber.ClientID %>'));
            CountMaxLengthTips(document.getElementById('<%=txtContact_Tip_CustomMessage.ClientID %>'));
        }
        function enable_disableAlterPH() {
            if (document.getElementById("<%=rbmainph.ClientID %>").checked == true) {
                document.getElementById("<%=txtalternateph.ClientID %>").disabled = true;
            }
            else {
                document.getElementById("<%=txtalternateph.ClientID %>").disabled = false;
            }
        }
        function CheckingValidation() {
            var ret = BlockPaste();
            if (ret) {
                if (Page_ClientValidate("TABS")) {
                    if (document.getElementById("<%=chkContactUs.ClientID %>").checked) {
                        var b = Validations();
                        if (b == true && document.getElementById("<%=chkPhonenumber.ClientID %>").checked == true && document.getElementById("<%=rbalterph.ClientID %>").checked == true) {
                            if (Page_ClientValidate('group')) {
                                return true;
                            }
                            else {
                                return false
                            }
                        }
                        else {
                            return b;
                        }
                    }
                    else {
                        return true;
                    }
                }
                else {
                    document.getElementById("<%=lblProfileTabs.ClientID%>").style.display = 'block';
                    document.getElementById("<%=lblProfileTabs.ClientID%>").innerHTML = "Profile tab name(s) are mandatory.";
                    return false;
                }
            }
            else
                return false;
        }

        function Validations() {
            if (Page_ClientValidate('APPS')) {
                if ($.trim($("#ctl00_cphUser_txtCommEmail").val()) != '') {
                    if (document.getElementById("<%=Chkmain.ClientID %>").checked == true) {
                        if (document.getElementById("<%=chkBusinessName.ClientID %>").checked == false) {
                            alert('Business Name is mandatory.');
                            return false;
                        }
                        else if (document.getElementById("<%=chkLogo.ClientID %>").checked == false) {
                            alert('Logo is mandatory.');
                            return false;
                        }
                        /* else if (document.getElementById("<%=chkZipcode.ClientID %>").checked == false) {
                        alert('Zipcode is mandatory.');
                        return false;
                        }
                        else if (document.getElementById("<%=chkEmergencyNumber.ClientID %>").checked == true && document.getElementById("<%=txtEmrgncyNumber.ClientID %>").value == "") {
                        alert('For Emergencies Dial is mandatory.');
                        return false;
                        }
                        */
                        else {
                            return true;
                        }

                    }
                    else {
                        return true;
                    }
                }
                else {
                    alert('Please enter a email address for communication.');
                    return false;
                }
            }
            else
                return false;
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode > 47 && charCode < 58) || (charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32)
                return true;
            else
                return false;
        }
        function isNumberKeyHypen() {
            //************** Check if emergency check box is checked. *************************//
            var emergencyPhno = document.getElementById("<%=txtEmrgncyNumber.ClientID %>").value;
            if (document.getElementById("<%=chkEmergencyNumber.ClientID %>").checked == true) {
                if (emergencyPhno != "") {
                    if (/^[a-zA-Z0-9-: ]+$/i.test(emergencyPhno)) {
                        return true;
                    }
                    else {
                        alert("Special characters are not allowed in app header text except hyphen.");
                        document.getElementById("<%=txtEmrgncyNumber.ClientID %>").focus();
                        return false;
                    }
                }
                else {
                    alert("Please enter text to display on app header.");
                    document.getElementById("<%=txtEmrgncyNumber.ClientID %>").focus();
                    return false;
                }
            }
            else
                return true;
        }


        function BlockPaste() {
            var returnValue = false;
            if (isNumberKeyHypen()) {
                return true;
            } //end If
            return returnValue;
        }
        function CountMaxLength(id) {
            var maxlength = 30;
            if (id.value.length > maxlength) {
                id.value = id.value.substring(0, maxlength);
                alert('You have exceeded the maximum of ' + maxlength + ' characters.');
            }
            document.getElementById('<%=lblAppHeaderTextCount.ClientID %>').innerHTML = maxlength - id.value.length;
        }
        function CountMaxLengthTips(id) {
            var maxlength = 30;
            if (id.value.length > maxlength) {
                id.value = id.value.substring(0, maxlength);
                alert('You have exceeded the maximum of ' + maxlength + ' characters.');
            }
            document.getElementById('<%=lblCharsTips.ClientID %>').innerHTML = maxlength - id.value.length;
        }
    </script>
</asp:Content>
