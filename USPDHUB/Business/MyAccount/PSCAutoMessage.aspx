<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PSCAutoMessage.aspx.cs"
    ValidateRequest="false" Inherits="USPDHUB.Business.MyAccount.PSCAutoMessage"
    MasterPageFile="~/Admin.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <style>
        #tblQRcode img
        {
            width: 150px;
            height: 150px;
        }
        .vr
        {
            width: 1px;
            background-color: #000;
            position: absolute;
            top: 0;
            bottom: 0;
            left: 150px;
        }
        .btnorange1
        {
            color: #DC7224;
        }
        .callivisble
        {
            width: 75px;
            border: 1px solid #CCc;
            border-radius: 10px;
        }
        #ctl00_cphUser_rbAnonymously label
        {
            padding: 12px;
        }
        .selcontcts
        {
            color: #F2635F; /*text-decoration:none;*/
            font-weight: bold;
        }
        .Grid th
        {
            color: #fff;
            background-color: #3AC0F2;
        }
        /* CSS to change the GridLines color */
        .Grid, .Grid th, .Grid td
        {
            border: 1px solid #FFAE5D;
        }
        .couponcode
        {
            width: 100px;
        }
        .couponcode:hover .coupontooltip
        {
            display: inline-block;
        }
        .coupontooltip
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            margin-left: 10px;
            margin-bottom: 100px;
            border: 1px dashed #297CCF;
            padding: 10px;
            position: absolute;
            z-index: 1000;
            width: 320px;
            height: 60px;
            color: Black;
        }
        .couponcode:hover .questiontooltip
        {
            display: inline-block;
        }
        .questiontooltip
        {
            font-weight: normal;
            font-size: 14px;
            display: none;
            background: #D9E8FF;
            margin-left: 10px;
            margin-bottom: 100px;
            border: 1px dashed #297CCF;
            padding: 10px;
            position: absolute;
            z-index: 1000;
            width: 320px;
            height: 30px;
            color: Black;
        }
        .watermark
        {
            color: #d0d0d0;
            font-size: 26px;
            width: 100%;
            height: 100%;
            text-align: center;
            vertical-align: middle;
            margin-top: 40px;
        }
    </style>
    <script src="../../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <link href="../../css/chosen.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            LoadSearchableCategoryControl();
            ShowProximityRadius();
            ShowEnable();
            DisplayImage();
            //            $(".chosen-search input[type='text']").live("blur", function () {
            //                InsertSearchCategory();
            //            });

        });
        $(document).ready(function () {
            Show_Hide_DailPhonenumber();
            Show_Hide_EmailMessageDivs();
            ShowEnable();
            $("#callIdentityCount").html(30 - $("#<%=txtCallBtnIdentity.ClientID %>").val().length);

        });

        function ValidateGroupSelection(controlID) {
            var gName = "";

            if (controlID == "1")
                gName = document.getElementById("<%=ddlEGroup.ClientID %>").value;

            else if (controlID == "3")
                gName = document.getElementById("<%=ddlTextGroup.ClientID %>").value;

            if (gName == "Select Group" || gName == "") {
                alert("Please select group.");
                return false;
            }
            else {

                if (document.getElementById('divImage').innerHTML.indexOf('img') != -1 || document.getElementById('divImage').innerHTML.indexOf('IMG') != -1) {
                    document.getElementById("<%=hdnImage.ClientID %>").value = $('#divImage img').attr('src');
                }
                if (document.getElementById('divImage').innerHTML.indexOf('href=') != -1) {
                    document.getElementById("<%=hdnDPLink.ClientID %>").value = $('#divImage a').attr('href');
                }

                return true;
            }
        }

        function Show_Hide_EmailMessageDivs() {
            // var IsShowSetting = false;
            $("#divSettings1").css("display", "block");
            $("#divSettings2").css("display", "block");
            $("#divSettings3").css("display", "block");

            var IsShowSetting = document.getElementById("<%=rdbtnSendPreMsg.ClientID %>").checked;

            if (IsShowSetting) {
                //alert(selected.value);
                $("#divSettings1").css("display", "block");
                $("#divSettings2").css("display", "block");
                $("#divSettings3").css("display", "block");
                $("#divMessageMandtory").css("display", "none");
                document.getElementById("<%=chkIsMessageMandtory.ClientID %>").checked = false;
            }
            else {
                $("#divMessageMandtory").css("display", "block");

            }
        }
        function CountMaxLength(id, e, displayId) {
            var maxLength = $(id).attr('MaxLength');
            $("#" + displayId).html(maxLength - id.value.length);
        }

        window.onload = function () {
            LoadSearchableCategoryControl();
            ShowProximityRadius();

            //            $(".chosen-search input[type='text']").live("blur", function () {
            //                InsertSearchCategory();
            //            });

            $("#<%=txtRadius.ClientID %>").keydown(function (e) {
                // Allow: backspace, delete, tab, escape, enter and .
                if ($.inArray(e.keyCode, [8, 9, 13, 35, 36, 37, 39]) !== -1 ||
                // Allow: Ctrl+A, Command+A
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
                    // let it happen, don't do anything
                    return;
                }
                // Ensure that it is a number and stop the keypress
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {

                    e.preventDefault();
                }
            });
            $("#<%=txtQRZip.ClientID %>").keydown(function (e) {
                // Allow: backspace, delete, tab, escape, enter and .
                if ($.inArray(e.keyCode, [8, 9, 13, 35, 36, 37, 39]) !== -1 ||
                // Allow: Ctrl+A, Command+A
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
                    // let it happen, don't do anything
                    return;
                }
                // Ensure that it is a number and stop the keypress
                if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                    e.preventDefault();
                }
            });
            document.getElementById("<%=txtRadius.ClientID %>").onkeyup = function (event) {
                document.getElementById('rfvRadius').style.display = "none";
                document.getElementById('rfvRadiusRange').style.display = "none";
            }

            document.getElementById("<%=txtQRStreet.ClientID %>").onkeyup = function (event) {
                document.getElementById('rfvQRStreet').style.display = "none";
            }
            document.getElementById("<%=txtQRCity.ClientID %>").onkeyup = function (event) {
                document.getElementById('rfvQRCity').style.display = "none";
            }
            document.getElementById("<%=txtQRZip.ClientID %>").onkeyup = function (event) {
                document.getElementById('rfvQRZip').style.display = "none";
            }
            document.getElementById("<%=txtQRState.ClientID %>").onkeyup = function (event) {
                document.getElementById('rfvState').style.display = "none";
            }
            document.getElementById("<%=txtQRCountry.ClientID %>").onkeyup = function (event) {
                document.getElementById('rfvCountry').style.display = "none";
            }
            var t = false

            $("#<%=txtRadius.ClientID %>").focus(function () {
                var $this = $(this)

                t = setInterval(

    function () {
        if (($this.val() < 100) && $this.val().length != 0) {
            if ($this.val() < 100) {
                $this.val()
            }


            $(document.getElementById('radiusRange')).fadeIn(2000, function () {
                $(this).fadeOut(1500)
            })
        }
    }, 50)
            })

            $("#<%=txtRadius.ClientID %>").blur(function () {
                if (t != false) {
                    window.clearInterval(t)
                    t = false;
                }
            })
        }

        function LoadSearchableCategoryControl() {

            $("#<%=ddlCategory.ClientID %>").chosen({
                disable_search_threshold: 1,
                no_results_text: "No result found",
                width: "95%"
            });

        }

        function ShowProximityRadius() {
            document.getElementById('rfvRadius').style.display = "none";
            document.getElementById('rfvQRStreet').style.display = "none";
            document.getElementById('rfvQRCity').style.display = "none";
            document.getElementById('rfvQRZip').style.display = "none";
            document.getElementById('rfvState').style.display = "none";
            document.getElementById('rfvCountry').style.display = "none";
            document.getElementById('rfvRadiusRange').style.display = "none";
            if ($("#<%=chkIsLocationProximityOn.ClientID %>").is(':checked')) {
                $("#trProximity").css("display", "block");
                $("#trAddress").css("display", "block");
                if (document.getElementById("<%=txtRadius.ClientID %>").value == "")
                    document.getElementById("<%=txtRadius.ClientID %>").value = "100";
            }
            else {
                $("#trProximity").css("display", "none");
                $("#trAddress").css("display", "none");
                document.getElementById("<%=txtRadius.ClientID %>").value = "";
                document.getElementById("<%=ddlFeet.ClientID %>").selectedIndex = 0;
                document.getElementById("<%=txtQRStreet.ClientID %>").value = "";
                document.getElementById("<%=txtQRCity.ClientID %>").value = "";
                document.getElementById("<%=txtQRZip.ClientID %>").value = "";
                document.getElementById("<%=txtQRState.ClientID %>").value = "";
                document.getElementById("<%=txtQRCountry.ClientID %>").value = "";
            }
        }

        function ShowEnable() {
            if ($("#<%=chkVisible.ClientID %>").is(':checked')) {
                $("#divEnable").css("display", "block");
                var customid = '<%= Request.QueryString["CustomID"]%>';
                if (customid == '')
                    document.getElementById("<%=rdnFunction.ClientID %>").checked = true;
            }
            else {
                $("#divEnable").css("display", "none");

            }
        }
        
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btndownload" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <div class="headernav" style="color: #0033FF;">
                    Private QR Connect -
                    <asp:Label ID="lblCallModuleName" runat="server"></asp:Label>
                </div>
                <br />
                <hr style="width: auto; border: 1px dashed #dddddd;" />
                <br />
                <div style="text-align: center;">
                    <asp:Label ID="lblerror" runat="server" Font-Bold="true" Style="color: Red; font-size: small"></asp:Label>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                        <ProgressTemplate>
                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"
                                size="2">Processing....</font></b>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <div class="fields_wrap">
                    <label style="color: Red; font-size: 14px;">
                        * Marked fields are mandatory.</label>
                </div>
                <br />
                <table cellspacing="3" cellpadding="20">
                    <tr>
                        <td valign="top">
                            <div style="text-align: center; border: 1px solid #dddddd;">
                                <div id='divImage' style="width: 160px; min-height: 160px; display: block; border: 0px soild #dddddd;
                                    text-align: center;">
                                </div>
                                <asp:HiddenField ID="hdnImage" runat="server" />
                                <asp:HiddenField ID="hdnDPLink" runat="server" />
                            </div>
                            <br />
                            <label>
                                <img style="cursor: pointer;" onclick="EditImage('divImage');" src="../../Images/Dashboard/Browseimg.png" />
                            </label>
                        </td>
                        <td>
                            <table style="margin-bottom: 30px;">
                                <tr>
                                    <td>
                                        <font color="red">*</font>
                                        <asp:Label ID="lblCallBtnIdentity" runat="server" Text="Enter QR code and button identity"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtCallBtnIdentity" runat="server" onkeyup="CountMaxLength(this,event,'callIdentityCount')"
                                            MaxLength="30" Width="300px"></asp:TextBox>
                                        <span>(Max 30 characters)</span><span class="couponcode">
                                            <img border="0" src="../../images/Dashboard/new.png" />
                                            <span class="coupontooltip">QR code button identity - Name that will identify where
                                                the QR code is located.</span></span>
                                        <asp:RequiredFieldValidator ID="rfvCallBtnIdentity" runat="server" Display="Dynamic"
                                            ValidationGroup="SV" ControlToValidate="txtCallBtnIdentity" ErrorMessage="Enter QR code button identity"></asp:RequiredFieldValidator>
                                        <p>
                                            You have (<span id="callIdentityCount">30</span>) characters left</p>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td>
                                        <asp:CheckBox ID="ChkIsInitiatesPhoneCall" runat="server" Checked="false" Text="Initiate Phone Call"
                                            onchange="Show_Hide_DailPhonenumber();" /></div>
                                    </td>
                                </tr>
                                <tr id="tr1" style="display: none;">
                                    <td>
                                        <font id="font1" runat="server" color="red">*</font>
                                        <asp:Label ID="lblPhone" runat="server" Text="Enter phone number"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr2" style="display: none;">
                                    <td>
                                        <asp:TextBox ID="txtPhone" runat="server" Width="200px" MaxLength="15" onkeyup="transform(this);"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                                            ErrorMessage="Enter Phone Number" Display="Dynamic" ValidationGroup="GS"></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator runat="server" ID="rexNumber" ControlToValidate="txtPhone"
                                            ValidationExpression="^[0-9]{4}$" ErrorMessage="Please enter only numbers" ValidationGroup="SV" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkVisible" runat="server" Text="Display on App" onclick="ShowEnable();" />
                                        <div style="margin-left: 20px; margin-top: 5px; display: none;" id="divEnable">
                                            <asp:RadioButton runat="server" ID="rdnFunction" GroupName="BtnFunction" Text="Button Function On" /><br />
                                            <asp:RadioButton runat="server" ID="rdnDisplay" GroupName="BtnFunction" Text="Display Only" /><br />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font color="red">*</font>
                                        <asp:Label ID="lblDesc" runat="server" Text="Enter description"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDesc" runat="server" Width="300px" TextMode="MultiLine" Style="color: Black;"></asp:TextBox>&nbsp;
                                        <span class="couponcode">
                                            <img border="0" src="../../images/Dashboard/new.png" />
                                            <span class="coupontooltip">Description - Let's users know the purpose of the QR code.</span></span>
                                        <asp:RequiredFieldValidator ID="rfvDesc" runat="server" Display="Dynamic" ValidationGroup="SV"
                                            ControlToValidate="txtDesc" ErrorMessage="Enter description"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="padding-top: 10px;">
                                            <asp:Label ID="lblCategory" runat="server" Text="Reporting Category" Font-Size="16px"></asp:Label>
                                            &nbsp; <span class="couponcode">
                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                <span class="coupontooltip">Reporting Category - Identifies the category for the data
                                                    collection in the reports. </span></span>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="padding-top: 6px;">
                                    <td>
                                        <div style="border: 2px solid #dddddd; padding: 10px;">
                                            <asp:DropDownList data-placeholder="Choose a Cateogires..." class="chosen-select"
                                                ID="ddlCategory" runat="server" Style="float: none; display: none;" Width="200px"
                                                Height="30px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqCategory" runat="server" ControlToValidate="ddlCategory"
                                                Display="Dynamic" InitialValue="-1" SetFocusOnError="true" ValidationGroup="SV"
                                                ErrorMessage="Select the Category"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="padding-top: 10px;">
                                            <asp:Label ID="lblmessageoption" runat="server" Text="Message Option" Font-Size="16px"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="padding-top: 6px;">
                                    <td>
                                        <div style="border: 2px solid #dddddd;">
                                            <asp:RadioButton runat="server" ID="rdbtnDisplayCustom" Checked="true" GroupName="Predefined"
                                                Text="Display Custom Message Input Form On APP" onchange="Show_Hide_EmailMessageDivs();" /><br />
                                            <div style="margin-left: 20px; display: block;" id="divMessageMandtory">
                                                <asp:CheckBox ID="chkIsMessageMandtory" runat="server" Text=" Message Mandatory" />
                                            </div>
                                            <asp:RadioButton runat="server" ID="rdbtnSendPreMsg" GroupName="Predefined" Text="Send Pre-defined Message"
                                                onchange="Show_Hide_EmailMessageDivs();" /><br />
                                            <%--<asp:RadioButtonList runat="server" ID="rdPredefined">
                                                <asp:ListItem Text="" Value="true" Selected="True"
                                                    onchange="Show_Hide_EmailMessageDivs();"></asp:ListItem>
                                                <asp:ListItem Text="Send Pre-defined Message" Value="false" onchange="Show_Hide_EmailMessageDivs();"></asp:ListItem>
                                            </asp:RadioButtonList>--%>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="padding-top: 10px;">
                                            Default message appears only in message reports &nbsp; <span class="couponcode">
                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                <span class="coupontooltip">Default message only appears in message reports and is not
                                                    sent to button contacts. </span></span>
                                            <br />
                                            <asp:TextBox runat="server" ID="txtDefaultMessage" TextMode="MultiLine" Width="300px"
                                                Style="color: Black;"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" style="display: none;">
                            <div style="text-align: center; border: 1px solid #dddddd; height: 230px;">
                                <asp:Literal ID="literal1" runat="server"></asp:Literal>
                                <asp:Button ID="btndownload" runat="server" Text="Download" Visible="false" CausesValidation="false"
                                    Style="margin-bottom: 7px;" OnClick="btndownload_Click" />
                                <div style="padding-top: 88px; width: 150px;">
                                    <asp:Label ID="watermark" runat="server" Text="QR Code" Visible="false" CssClass="watermark"></asp:Label>
                                </div>
                            </div>
                            <br />
                        </td>
                    </tr>
                </table>
                <div>
                    <%-- <asp:LinkButton ID="lnkViewContacts" runat="server" CssClass="btnorange1" Style="margin-top: 10px;
                        padding-left: 780px;" Text="Select Contacts" OnClick="lnkViewContacts_Click"></asp:LinkButton>--%>
                </div>
                <div>
                    <font color="#FFAE5D"><strong>Communication To Contacts</strong></font>
                    <hr style="width: auto; border: 1px solid #dddddd;" />
                    <table>
                        <tr>
                            <td valign="top">
                                <div>
                                    <table cellpadding="5" cellspacing="5" class="group-selection">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkEmail" runat="server" Enabled="true" />
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblChkEmail" runat="server" Width="168px">Send auto email<span class="couponcode">
                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                <span class="coupontooltip">
Send auto email - An email will be automatically sent to selected contacts when the QR code has been scanned or the button activated.</span></span></asp:Label>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblEmail" runat="server" Text="Enter email subject "></asp:Label><span
                                                                class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip">Email Subject - Subject line will display when message is
                                                                    received.</span></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtEmailSub" runat="server" Width="200px"></asp:TextBox>
                                                            <span id="rfvEmailSub" class="errDiv" style="color: red; display: none;">* Subject is
                                                                required.</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table id="divSettings1" style="display: block;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblEDesc" runat="server" Text="Enter email message"></asp:Label>
                                                            <span class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip">Email Message : This is the message that will display when
                                                                    received.</span></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtEDesc" runat="server" TextMode="MultiLine" Style="color: Black;"
                                                                Width="200px"></asp:TextBox>
                                                            <span id="rfvEmailDesc" class="errDiv" style="color: red; display: none;">* Description
                                                                is required.</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table style="display: none">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblEGroup" runat="server" Text="Choose an email group"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlEGroup" runat="server" Width="200px">
                                                                <asp:ListItem Selected="True" Text="Select Group" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span id="rfvEmailGroup" class="errDiv" style="color: red; display: none;">* Please
                                                                select a group.</span>
                                                            <br />
                                                            <br />
                                                            <asp:LinkButton ID="lnkEmailViewContacts" runat="server" CssClass="btnorange1" OnClick="lnkEmailViewContacts_OnClick"
                                                                OnClientClick="return ValidateGroupSelection('1')" Style="margin-top: 20px;"
                                                                Text="View Contacts"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <hr style="width: auto; border: 1px solid #dddddd;" />
                                    <table cellpadding="5" cellspacing="5" class="group-selection">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkText" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblText" runat="server">Send auto text message<span class="couponcode">
                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                <span class="coupontooltip">Send auto text message - A text message will be automatically sent to selected contacts when the QR code has been scanned or the button activated.</span></span></asp:Label>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblTextSub" runat="server" Text="Enter text message subject "></asp:Label><span
                                                                class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip">Text Message Subject - Subject line will display when message
                                                                    is received.</span></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtTextSub" runat="server" Width="200px"></asp:TextBox>
                                                            <span id="rfvSMSSub" class="errDiv" style="color: red; display: none;">* Subject is
                                                                required.</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table id="divSettings2" style="display: block;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblTDesc" runat="server" Text="Enter text message"></asp:Label><span
                                                                class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip">Text Message : This is the message that will display when
                                                                    received.</span></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtTDesc" runat="server" TextMode="MultiLine" Style="color: Black;"
                                                                Width="200px"></asp:TextBox>
                                                            <span id="rfvSMSDesc" class="errDiv" style="color: red; display: none;">* Description
                                                                is required.</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table style="display: none;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblTextGroup" runat="server" Text="Choose an text message group"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlTextGroup" runat="server" Width="200px">
                                                                <asp:ListItem Selected="True" Text="Select Group" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span id="rfvSMSGroup" class="errDiv" style="color: red; display: none;">* Please select
                                                                a group.</span>
                                                            <br />
                                                            <br />
                                                            <asp:LinkButton ID="lnkMessageViewContacts" runat="server" CssClass="btnorange1"
                                                                OnClick="lnkMessageViewContacts_OnClick" OnClientClick="return ValidateGroupSelection('3')"
                                                                Style="margin-top: 20px;" Text="View Contacts"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <hr style="width: auto; border: 1px solid #dddddd;" />
                                    <table cellpadding="2" cellspacing="2" class="group-selection">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkPush" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPush" runat="server" Text="Send auto push notification"></asp:Label>
                                                <span class="couponcode">
                                                    <img border="0" src="../../images/Dashboard/new.png" />
                                                    <span class="coupontooltip">Send auto push notification - A push notification will be
                                                        automatically sent to only those contacts who have accepted the private button invitation
                                                        and registered their device.</span></span>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="width: 221px">
                                                            <asp:Label ID="lblPushSub" runat="server" Text="Enter push notification subject"></asp:Label>
                                                            <span class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip">Push Notification Subject - Subject line will display when
                                                                    message is received.</span></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtPushSub" runat="server" Width="200px"></asp:TextBox>
                                                            <span id="rfvPushSub" class="errDiv" style="color: red; display: none;">* Subject is
                                                                required.</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table id="divSettings3" style="display: block;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPDesc" runat="server" Text="Enter push message"></asp:Label>
                                                            <span class="couponcode">
                                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                                <span class="coupontooltip">Push Notification Message : This is the message that will
                                                                    display when received.</span></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtPDesc" runat="server" TextMode="MultiLine" Style="color: Black;"
                                                                Width="200px"></asp:TextBox>
                                                            <span id="rfvPushDesc" class="errDiv" style="color: red; display: none;">* Description
                                                                is required.</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table style="display: none;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPushGroup" runat="server" Text="Choose an push notification group"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPushGroup" runat="server" Width="200px">
                                                                <asp:ListItem Selected="True" Text="Select Group" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span id="rfvPushGroup" class="errDiv" style="color: red; display: none;">* Please select
                                                                a group.</span>
                                                            <br />
                                                            <br />
                                                            <asp:LinkButton ID="lnkPushViewContacts" runat="server" CssClass="btnorange1" OnClick="lnkPushViewContacts_OnClick"
                                                                OnClientClick="return ValidateGroupSelection('2')" Style="margin-top: 20px;"
                                                                Text="View Contacts"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <hr style="width: auto; border: 1px solid #dddddd;" />
                                <table cellpadding="5" cellspacing="10">
                                    <tr>
                                        <td colspan="4">
                                            Message Receipt Options:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkGPS" Checked="true" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGPS" runat="server">Include Device GPS Location
                                            <span class="couponcode">
                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                <span class="coupontooltip">Include Device GPS - Sends the user's device location when the QR code was scanned or the button activated.</span></span></asp:Label>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkUploadImage" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUploadImage" runat="server">Include User Image
                                               <span class="couponcode">
                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                <span class="coupontooltip">Include User's Image - Allows user to include an image when sending a message.</span></span>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <hr style="width: auto; border: 1px solid #dddddd;" />
                                <table cellpadding="2" cellspacing="2">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbladdress" runat="server" Text="QR Code Location"></asp:Label>
                                            <span class="couponcode">
                                                <img border="0" src="../../images/Dashboard/new.png" />
                                                <span class="coupontooltip">QR Code Location - Include the address of the QR code's
                                                    location when you want the system to compare the location of the code with the location
                                                    of the user's device when the code is scanned.</span></span>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <div style="border: 1px solid #FFAE5D">
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:CheckBox ID="chkIsLocationProximityOn" runat="server" Text="Set Location Proximity"
                                                                onclick="ShowProximityRadius();" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trProximity" style="display: none;">
                                                        <td>
                                                            <font color="red">*</font>Proximity Radius
                                                            <asp:TextBox runat="server" ID="txtRadius" MaxLength="5" Width="50px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="ddlFeet">
                                                                <asp:ListItem Text="Feet" Value="Feet"></asp:ListItem>
                                                                <asp:ListItem Text="Meters" Value="Meters" Selected="True"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <p id="radiusRange" style="display: none; color: Red">
                                                                Accepting Proximity Radius above 100</p>
                                                            <span id="rfvRadiusRange" class="errDiv" style="color: red; display: none;">Enter Proximity
                                                                Radius above 100</span> <span id="rfvRadius" class="errDiv" style="color: red; display: none;">
                                                                    Enter Proximity Radius </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="trAddress" style="display: none;">
                                            <td>
                                                <table cellpadding="2" cellspacing="2">
                                                    <tr>
                                                        <td colspan="2">
                                                            <font color="red">*</font>Street Address<br />
                                                            <asp:TextBox runat="server" ID="txtQRStreet" Width="240px"></asp:TextBox><br />
                                                            <span id="rfvQRStreet" class="errDiv" style="color: red; display: none;">Enter Street
                                                                Address </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <font color="red">*</font>City<br />
                                                            <asp:TextBox runat="server" ID="txtQRCity" Width="240px"></asp:TextBox>
                                                            <br />
                                                            <span id="rfvQRCity" class="errDiv" style="color: red; display: none;">Enter City</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <font color="red">*</font>Zip Code<br />
                                                            <asp:TextBox runat="server" ID="txtQRZip" Width="240px" MaxLength="8"></asp:TextBox>
                                                            <br />
                                                            <span id="rfvQRZip" class="errDiv" style="color: red; display: none;">Enter Zip Code</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="2" cellspacing="2" style="padding-top: 45px;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <font color="red">*</font>State<br />
                                                            <asp:TextBox runat="server" ID="txtQRState" Width="240px"></asp:TextBox>
                                                            <br />
                                                            <span id="rfvState" class="errDiv" style="color: red; display: none;">Enter State</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <font color="red">*</font>Country<br />
                                                            <asp:TextBox runat="server" ID="txtQRCountry" Width="240px"></asp:TextBox>
                                                            <br />
                                                            <span id="rfvCountry" class="errDiv" style="color: red; display: none;">Enter Country</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table cellpadding="5" cellspacing="10" style='display: none;'>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkAnonymous" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAnonymous" runat="server" Text="Receive Anonymously" Width="168px"></asp:Label>
                                        </td>
                                        <td style='display: none;'>
                                            <asp:CheckBox ID="chkPhone" runat="server" />
                                        </td>
                                        <td style='display: none;'>
                                            <asp:Label ID="lblPhoneInfo" runat="server" Text="Include All Phone Information"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <hr style="width: auto; border: 1px solid #dddddd; display: none;" />
                                <table cellpadding="5" cellspacing="10" style="width: auto; display: none;">
                                    <tr>
                                        <td>
                                            <div style="border: 2px solid #dddddd;">
                                                <asp:RadioButtonList runat="server" ID="rbAnonymously">
                                                    <asp:ListItem Text="App User identity mandatory" Value="111"></asp:ListItem>
                                                    <asp:ListItem Text="Let App user choose to identify or remain anonymous" Value="112"></asp:ListItem>
                                                    <asp:ListItem Text="Incoming messages will be anonymous" Value="113" Selected="True"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" style="padding-left: 10px; border-left: 1px solid #dddddd; border-left-style: groove;"
                                align="center">
                                <asp:LinkButton runat="server" ID="lnkContacts" OnClick="lnkContacts_Click" CssClass="selcontcts">Select Contacts</asp:LinkButton>
                                &nbsp;&nbsp;<asp:LinkButton runat="server" ID="lnkAddContact" OnClick="lnkAddContact_Click"
                                    CssClass="selcontcts">Add Contact</asp:LinkButton><br />
                                <br />
                                <div>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblContactList" runat="server"></asp:Label>
                                                    <cc1:ModalPopupExtender ID="modalContactsList" runat="server" TargetControlID="lblContactList"
                                                        PopupControlID="pnlContactList" BackgroundCssClass="modal" CancelControlID="imglogin2">
                                                    </cc1:ModalPopupExtender>
                                                    <asp:Panel Style="display: none;" ID="pnlContactList" runat="server" Width="100%">
                                                        <table class="popuptable" cellspacing="0" cellpadding="0" width="400" align="center"
                                                            border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="3">
                                                                            <ProgressTemplate>
                                                                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="font-weight: bold; color: #F2635F; font-size: 14px;">
                                                                                        Select Contacts
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                                            CausesValidation="false"></asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <br />
                                                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="HelpBox" Width="200px" Style="border: solid 1px black;"></asp:TextBox>
                                                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="HelpButton" border="0"
                                                                            OnClick="btnSearch_Click" />&nbsp;&nbsp;
                                                                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="HelpButton" border="0"
                                                                            OnClick="btnClear_Click" />
                                                                        <br />
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-right: 10px;">
                                                                        <div style="overflow-y: auto; max-height: 320px; border: 1px solid #F2635F;">
                                                                            <asp:GridView runat="server" ID="gvManageContacts" AutoGenerateColumns="False" Width="50%"
                                                                                Height="30%" ShowHeader="true" ForeColor="#333333" GridLines="None">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="checkAll(this,0);" AutoPostBack="false">
                                                                                            </asp:CheckBox>Select All
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="chkContacts" runat="server" AutoPostBack="false" onclick="checkItem_All(this,0)" />
                                                                                            <asp:Label ID="lblFCName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                                                            <asp:Label ID="lblLCName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label><br />
                                                                                            <asp:Label ID="lblCEmail" runat="server" Text='<%# Bind("EmailID") %>' Style="padding-left: 25px;"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblContactID" runat="server" Text='<%# Bind("ContactID") %>' Visible="false"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    No contacts found
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="center">
                                                                        <br />
                                                                        <asp:Button ID="btnContactSubmit" runat="server" Text="Submit" CssClass="HelpButton"
                                                                            border="0" OnClick="btnContactSubmit_Click" />
                                                                        <br />
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div style="max-height: 480px; overflow-y: auto;">
                                    <asp:GridView runat="server" ID="grdListContacts" AutoGenerateColumns="False" Width="100%"
                                        Visible="False" ShowHeader="False" CellPadding="4" CssClass="Grid" ForeColor="Black"
                                        GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
                                        BorderWidth="1px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No contacts found
                                        </EmptyDataTemplate>
                                        <RowStyle BackColor="#F8F8F2" />
                                    </asp:GridView>
                                </div>
                                <%-- Add Contacts--%>
                                <div>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCTarget" runat="server"></asp:Label>
                                                <cc1:ModalPopupExtender ID="MPEContacts" runat="server" BackgroundCssClass="modal"
                                                    PopupControlID="pnlContacts" TargetControlID="lblCTarget" CancelControlID="closeImage1">
                                                </cc1:ModalPopupExtender>
                                                <asp:Panel ID="pnlContacts" runat="server" Style="display: none" Width="600px">
                                                    <table cellspacing="0" cellpadding="0" width="400px" align="center" border="0" style="height: 500px;
                                                        background-color: White;">
                                                        <tr>
                                                            <td align="center">
                                                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="3">
                                                                    <ProgressTemplate>
                                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                            </td>
                                                            <td align="right" style="padding: 10px;">
                                                                <asp:ImageButton ID="closeImage1" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="padding: 10px;">
                                                                <div style="height: 430px; width: 600px; overflow-y: auto; border: solid 1px #4684C5;
                                                                    background-color: #CCFFFF;">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td align="center" colspan="2">
                                                                                <asp:Label runat="server" ID="lblmsg1" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-weight: bold; font-size: 14px; padding: 10px; padding-bottom: 0px;"
                                                                                align="left" class="groupsheadP">
                                                                                Contact Information
                                                                            </td>
                                                                            <td style="font-weight: bold; font-size: 14px; padding: 10px; padding-left: 0px;
                                                                                padding-bottom: 0px; display: none;" align="left" colspan="2" class="groupsheadP">
                                                                                Select Buttons to send message<%--Select Groups--%></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td valign="top" style="width: 350px;">
                                                                                <table class="mycontact-add">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" align="right">
                                                                                            First Name:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtFirstname" CssClass="infoinput" runat="server"></asp:TextBox><span
                                                                                                style="color: Red; font-size: medium;"> *</span><br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstname"
                                                                                                ErrorMessage="First name is mandatory." Display="Dynamic" ValidationGroup="Contacts"
                                                                                                Font-Size="Small"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            Last Name:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtLastname" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" align="right">
                                                                                            Email:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtEmail" CssClass="infoinput" runat="server"></asp:TextBox><span
                                                                                                style="color: Red; font-size: medium;"> *</span><br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                                                                                ErrorMessage="Email id is mandatory." Display="Dynamic" ValidationGroup="Contacts"
                                                                                                Font-Size="Small"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="revEmailID" runat="server" ControlToValidate="txtEmail"
                                                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid email."
                                                                                                Display="Dynamic" ValidationGroup="Contacts" Font-Size="Small"></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" align="right">
                                                                                            Mobile:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtMobile" CssClass="infoinput" MaxLength="12" runat="server" onkeyup="FormatPhoneNumber(this,event,3);"></asp:TextBox><span
                                                                                                style="color: Red; font-size: medium;"> *</span><br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobile"
                                                                                                ErrorMessage="Mobile number is mandatory." Display="Dynamic" ValidationGroup="Contacts"
                                                                                                Font-Size="Small"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobile"
                                                                                                ErrorMessage="Invalid mobile number." Display="Dynamic" ValidationExpression=".{12}.*"
                                                                                                ValidationGroup="Contacts"></asp:RegularExpressionValidator><br />
                                                                                            (xxx-xxx-xxxx)
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" align="right">
                                                                                            Title/Position:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtPosition" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" align="right">
                                                                                            Organization:
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtOrganization" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" style="padding-top: 3px; padding-bottom: 5px; padding-left: 10px;
                                                                                            font-size: 13px;" colspan="2">
                                                                                            <asp:CheckBox ID="chkSendInvitation" runat="server"></asp:CheckBox>
                                                                                            Allow sending invitation to display Private QR Connect.
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="display: none;">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td align="right">
                                                                                                        Company Name:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtcompanyname" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right">
                                                                                                        Address:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtAddress" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right">
                                                                                                        City:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtCity" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right">
                                                                                                        State:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtState" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right">
                                                                                                        Zip Code:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtZipcode" CssClass="infoinput" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td valign="top" align="right">
                                                                                                        Landline:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtContactPhone" CssClass="infoinput" MaxLength="12" runat="server"
                                                                                                            onkeyup="FormatPhoneNumber(this,event,1);"></asp:TextBox><br />
                                                                                                        (xxx-xxx-xxxx)
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td valign="top" align="right">
                                                                                                        Fax:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtFax" CssClass="infoinput" MaxLength="12" runat="server" onkeyup="FormatPhoneNumber(this,event,2);"></asp:TextBox><br />
                                                                                                        (xxx-xxx-xxxx)
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" style="padding-top: 3px; padding-bottom: 5px; padding-left: 10px;
                                                                                            font-size: 13px;" colspan="2">
                                                                                            <asp:CheckBox ID="chkMobile" runat="server"></asp:CheckBox>
                                                                                            This contact has agreed to receive emails and SMS(text messages).
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top" align="left" style="border: 1px solid #CCC; display: none;">
                                                                                <asp:HiddenField ID="hdnSelG" Value="0" runat="server" />
                                                                                <asp:CheckBoxList ID="chkGroupList" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                                                                                    CellPadding="5" CellSpacing="0" CssClass="myCheckbox">
                                                                                </asp:CheckBoxList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="padding-top: 10px;" align="center">
                                                                                <asp:Button ID="btnContactAdd" runat="server" Text="Add" CssClass="mailbtnP" OnClick="btnContactAdd_Click"
                                                                                    ValidationGroup="Contacts" OnClientClick="return AddValidateGroupSelection();" />&nbsp;
                                                                                <asp:Button ID="btnContactCancel" runat="server" Text="Cancel" CssClass="mailbtnP"
                                                                                    CausesValidation="false" />
                                                                                <asp:HiddenField ID="hdnContactID" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <hr style="width: auto; border: 1px solid #dddddd;" />
                <div class="fields_wrap ">
                    <div class="left_lable">
                    </div>
                    <div class="right_fields" style="margin: 10px 0px 0px 0px; width: 450px;">
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" border="0" CssClass="btn"
                            Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" border="0"
                            ValidationGroup="SV" OnClientClick="return BindImages(1);" OnClick="btnSubmit_Click" />
                        <asp:LinkButton ID="lnkPreview" runat="server" CausesValidation="false" OnClick="lnkPreview_Click"
                            OnClientClick="return BindImages(2);"><img src="../../images/BulletinThumbs/preview.png" width="100" height="37"></asp:LinkButton>
                        <input type="hidden" id="editDivCheck" value="" />
                        <input type="hidden" id="hdnalignindex" />
                    </div>
                </div>
                <br />
                <br />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblPreview" runat="server" visiable="false"></asp:Label>
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblPreview"
                            PopupControlID="pnlPreview" BackgroundCssClass="modal" CancelControlID="imgPreviewClose">
                        </cc1:ModalPopupExtender>
                        <asp:Panel Style="display: none" ID="pnlPreview" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%" class="popuptable" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" style="padding: 5px 10px 0px 10px;">
                                            <asp:ImageButton ID="imgPreviewClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                CausesValidation="false"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 14px; padding-bottom: 10px; padding-top: 10px"
                                            align="left">
                                            App Module Display Name:
                                            <asp:Label ID="lblName" runat="server" Style="color: green;"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            <div style="overflow-y: auto; height: 500px; position: relative; width: auto; padding-right: 30px;">
                                                <asp:Label ID="lblPreviewHTML" runat="server"></asp:Label></div>
                                        </td>
                                        <asp:HiddenField ID="hdnQRCode" runat="server" />
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <%--IMAGE GALLERY--%>
                        <asp:Label ID="lblimage" runat="server"></asp:Label>
                        <cc1:ModalPopupExtender ID="popbulletinimage" runat="server" TargetControlID="lblimage"
                            PopupControlID="pnlimage" BackgroundCssClass="modal" BehaviorID="popupimage"
                            CancelControlID="imcloseimagepopup">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlimage" runat="server" Style="display: none" Width="800px">
                            <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #EEECEC;
                                background-color: #F8F6F6;">
                                <tbody>
                                    <tr>
                                        <td align="right" style="padding: 5px 10px 0px 10px;">
                                            <asp:ImageButton ID="imcloseimagepopup" runat="server" ImageUrl="~/images/popup_close.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mid">
                                            <div id="DIDIFrm">
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblProgress" runat="server" visiable="false"></asp:Label>
                            <cc1:ModalPopupExtender ID="MPEProgress" runat="server" TargetControlID="lblProgress"
                                PopupControlID="pnlProgress" BackgroundCssClass="modal">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none;" ID="pnlProgress" runat="server" Width="500px">
                                <table class="modalpopup" cellspacing="0" cellpadding="0" width="100%" align="center"
                                    border="0">
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress8" runat="server" DisplayAfter="3">
                                                <ProgressTemplate>
                                                    <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green"> Your
                                                        request is in progress, please don't refresh or close window. </font></b>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblviewc" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="modalViewContacts" runat="server" TargetControlID="lblviewc"
                                PopupControlID="pnlViewCOntacts" BackgroundCssClass="modal" CancelControlID="imglogin2">
                            </cc1:ModalPopupExtender>
                            <asp:Panel Style="display: none" ID="pnlViewCOntacts" runat="server" Width="100%">
                                <table class="popuptable" cellspacing="0" cellpadding="0" width="800" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="3">
                                                    <ProgressTemplate>
                                                        <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b></ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="header">
                                                                Contacts for <span style="color: maroon; font-family: Arial; size: 2"><span style="color: maroon;
                                                                    font-family: Arial; size: 2">
                                                                    <asp:Label ID="lblViewGroupName" runat="server"></asp:Label>
                                                                </span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imglogin2" runat="server" ImageUrl="~/images/popup_close.gif"
                                                                    CausesValidation="false"></asp:ImageButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdViewContacts" runat="server" Width="100%" CssClass="datagrid2"
                                                                    AutoGenerateColumns="False" PageSize="15" AllowPaging="True" Visible="false">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                                                        <asp:BoundField DataField="EmailID" HeaderText="Email ID" />
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No contacts found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                                                                    PageSize="15" AllowPaging="True">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                                                        <asp:BoundField DataField="EmailID" HeaderText="Email ID" />
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No contacts found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                </asp:GridView>
                                                                <asp:GridView ID="GridView2" runat="server" Width="100%" CssClass="datagrid2" AutoGenerateColumns="False"
                                                                    PageSize="15" AllowPaging="True">
                                                                    <EmptyDataRowStyle ForeColor="#C00000"></EmptyDataRowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkRow" runat="server" HeaderText="Select" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                                                        <asp:BoundField DataField="EmailID" HeaderText="Email ID" />
                                                                        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        No contacts found
                                                                    </EmptyDataTemplate>
                                                                    <HeaderStyle CssClass="title1"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function checkAll(gvExample, colIndex) {
            var GridView = gvExample.parentNode.parentNode.parentNode;
            for (var i = 1; i < GridView.rows.length; i++) {
                var chb = GridView.rows[i].cells[colIndex].getElementsByTagName("input")[0];
                chb.checked = gvExample.checked;
            }
        }

        function checkItem_All(objRef, colIndex) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var selectAll = GridView.rows[0].cells[colIndex].getElementsByTagName("input")[0];
            if (!objRef.checked) {
                selectAll.checked = false;
            }
            else {
                var checked = true;
                for (var i = 1; i < GridView.rows.length; i++) {
                    var chb = GridView.rows[i].cells[colIndex].getElementsByTagName("input")[0];
                    if (!chb.checked) {
                        checked = false;
                        break;
                    }
                }
                selectAll.checked = checked;
            }
        }

        function FormatPhoneNumber(id, event, Vtype) {

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
            val = id.value.replace(/\D/g, '');
            var newVal = '';
            if (val.length > 10) {
                val = val.substring(0, 10)
            }
            while (val.length >= 3 && newVal.length <= 7) {
                newVal += val.substr(0, 3) + '-';
                val = val.substr(3);
            }
            newVal += val;
            id.value = newVal;
            if (newVal.length == 12) {
                if (newVal.length == 12) {
                    window.setTimeout(function () { id.focus(); }, 0);
                }
            }

        }
        function AddValidateGroupSelection() {
            if (Page_ClientValidate('Contacts')) {
                if (document.getElementById('<%=chkMobile.ClientID%>').checked == false) {
                    alert('Agreement to receive email and SMS must be checked.');
                    return false;
                }
                var chkListModules = document.getElementById('<%= chkGroupList.ClientID %>');
                var chkListinputs = chkListModules.getElementsByTagName("input");
                chkListinputs[0].checked = true;
                if (chkListinputs[0].checked) {
                    return true;
                }
                //                var chkListModules = document.getElementById('<%= chkGroupList.ClientID %>');
                //                if (chkListModules != null)
                //                    return true;
            }
            return false;
        }
        function Show_Hide_DailPhonenumber() {

            if (document.getElementById('<%=ChkIsInitiatesPhoneCall.ClientID %>').checked) {

                $("#tr1").css("display", "block");
                $("#tr2").css("display", "block");

            }
            else {
                $("#tr1").css("display", "none");
                $("#tr2").css("display", "none");
                document.getElementById('<%=txtPhone.ClientID %>').value = "";
            }
        }

        function numeric(e) {
            e.value = e.value.replace(/[^0-9]+/g, '');
        }

        function EditImage(imgdivID) {
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            imgSrc = document.getElementById(imgdivID).innerHTML.trim();

            // var divWidth = document.getElementById('imgid').offsetWidth;
            ifrm.setAttribute("src", "CallModuleImageGallery.aspx?fitblockwidth=" + (document.getElementById(imgdivID).offsetWidth - 10) + "&imgSrc=" + imgSrc + "&folder=Forms&ModuleName=PrivateSmartConnectAddOns&Directory=DefaultPSCCallModules");
            ifrm.style.height = "650px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";

            document.getElementById('DIDIFrm').appendChild(ifrm);
            document.getElementById('editDivCheck').value = imgdivID;

            var modalDialog = $find("popupimage");
            modalDialog.show();
        }
        function BindImages(typeValue) {
            
            var isValid = false;
            var list = document.getElementsByClassName("errDiv");
            for (var i = 0; i < list.length; i++) {
                if (list[i].style.display == "block")
                    list[i].style.display = 'none';
            }
            if (typeValue == "1") {
                if (document.getElementById('<%=chkEmail.ClientID %>').checked) {
                    if (document.getElementById('<%=txtEmailSub.ClientID %>').value.trim() == "")
                        document.getElementById('rfvEmailSub').style.display = "block";
                    if (document.getElementById('<%=txtEDesc.ClientID %>').value.trim() == "")
                        document.getElementById('rfvEmailDesc').style.display = "block";
                    //                    if ($('#ctl00_cphUser_ddlEGroup :selected').val() == "0" || $('#ctl00_cphUser_ddlEGroup :selected').val() == "Select Group")
                    //                        document.getElementById('rfvEmailGroup').style.display = "block";
                }

                if (document.getElementById('<%=chkText.ClientID %>').checked) {
                    if (document.getElementById('<%=txtTextSub.ClientID %>').value.trim() == "")
                        document.getElementById('rfvSMSSub').style.display = "block";
                    if (document.getElementById('<%=txtTDesc.ClientID %>').value.trim() == "")
                        document.getElementById('rfvSMSDesc').style.display = "block";
                    //                    if ($('#ctl00_cphUser_ddlTextGroup :selected').val() == "0" || $('#ctl00_cphUser_ddlTextGroup :selected').val() == "Select Group")
                    //                        document.getElementById('rfvSMSGroup').style.display = "block";
                }
                if (document.getElementById('<%=chkPush.ClientID %>').checked) {
                    if (document.getElementById('<%=txtPushSub.ClientID %>').value.trim() == "")
                        document.getElementById('rfvPushSub').style.display = "block";
                    if (document.getElementById('<%=txtPDesc.ClientID %>').value.trim() == "")
                        document.getElementById('rfvPushDesc').style.display = "block";

                }

            }

            if ($('.errDiv[style*="block"]').length == 0)
                isValid = true;
            if (document.getElementById('<%=chkIsLocationProximityOn.ClientID %>').checked && (document.getElementById('<%=txtRadius.ClientID %>').value == ""
                 || document.getElementById("<%=txtQRStreet.ClientID %>").value == "" || document.getElementById("<%=txtQRCity.ClientID %>").value == ""
                 || document.getElementById("<%=txtQRZip.ClientID %>").value == "" || document.getElementById("<%=txtQRState.ClientID %>").value == "" || document.getElementById("<%=txtQRCountry.ClientID %>").value == "")) {
                isValid = false;
                if (document.getElementById('<%=txtRadius.ClientID %>').value == "")
                    document.getElementById('rfvRadius').style.display = "block";
                if (document.getElementById("<%=txtQRStreet.ClientID %>").value == "")
                    document.getElementById('rfvQRStreet').style.display = "block";
                if (document.getElementById("<%=txtQRCity.ClientID %>").value == "")
                    document.getElementById('rfvQRCity').style.display = "block";
                if (document.getElementById("<%=txtQRZip.ClientID %>").value == "")
                    document.getElementById('rfvQRZip').style.display = "block";
                if (document.getElementById("<%=txtQRState.ClientID %>").value == "")
                    document.getElementById('rfvState').style.display = "block";
                if (document.getElementById("<%=txtQRCountry.ClientID %>").value == "")
                    document.getElementById('rfvCountry').style.display = "block";

            }
            if (document.getElementById('<%=chkIsLocationProximityOn.ClientID %>').checked && (document.getElementById('<%=txtRadius.ClientID %>').value < 100)) {
                isValid = false;
                document.getElementById('rfvRadiusRange').style.display = "block";
            }
            if (Page_ClientValidate('SV') && isValid && ValidateDailPhoneNumber()) {

                if (document.getElementById('divImage').innerHTML.indexOf('img') != -1 || document.getElementById('divImage').innerHTML.indexOf('IMG') != -1) {
                    document.getElementById("<%=hdnImage.ClientID %>").value = $('#divImage img').attr('src');
                }
                if (document.getElementById('divImage').innerHTML.indexOf('href=') != -1) {
                    document.getElementById("<%=hdnDPLink.ClientID %>").value = $('#divImage a').attr('href');
                }
                if (typeValue == "1") {
                    if (Page_ClientValidate('SV') == true && Page_IsValid == true)
                        $find("<%=MPEProgress.ClientID %>").show();
                }
                return true;
            }

            return false;
        }

        function ValidateDailPhoneNumber() {
            if (document.getElementById('<%=ChkIsInitiatesPhoneCall.ClientID %>').checked) {
                if (!Page_ClientValidate('GS')) {
                    document.getElementById('<%=txtPhone.ClientID %>').focus();
                    return false;
                }
            }
            return true;
        }

        function DisplayImage() {

            if (document.getElementById("<%=hdnImage.ClientID %>").value != "") {

                if (document.getElementById("<%=hdnDPLink.ClientID %>").value == "")
                    document.getElementById('divImage').innerHTML = "<img src='" + document.getElementById("<%=hdnImage.ClientID %>").value + "' />";
                else
                    document.getElementById('divImage').innerHTML = "<a href='" + document.getElementById("<%=hdnDPLink.ClientID %>").value + "' target='_blank'><img src='" + document.getElementById("<%=hdnImage.ClientID %>").value + "' /></a>";
            }
        }


        function transform(obj) {
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
            var val = obj.value.replace(/\D/g, '');
            var newVal = '';
            if (val.length > 14) {
                val = val.substring(0, 14)
            }
            while (val.length > 3 && newVal.length <= 7) {
                newVal += val.substr(0, 3) + '-';
                val = val.substr(3);
            }
            newVal += val;
            document.getElementById("<%=txtPhone.ClientID %>").value = newVal;

        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            Show_Hide_DailPhonenumber();
            Show_Hide_EmailMessageDivs();
            DisplayImage();
        });
       
      
    </script>
</asp:Content>
