<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" ValidateRequest="false"
    MasterPageFile="~/Admin.master" Inherits="Business_MyAccount_ModifyLogo" CodeBehind="ModifyLogo.aspx.cs" %>

<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="cphUser" ID="BMediafiles" runat="server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="../../Scripts/jquery.Jcrop.js" type="text/javascript"></script>
    <link href="../../css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .longimg
        {
            width: 500px;
            content: "";
            background-color: #CCCCCC;
            height: 140px;
        }
        .shortimg
        {
            width: 110px;
            height: 110px;
            background-color: #CCCCCC;
        }
    </style>
    <script type="text/javascript">
        function openWin1(url) {
            window.open(url, "composerwindow", "toolbar=no,width=465,height=322,status=no,scrollbars=no,resize=no,menubar=no");
        }

        function LogoResizeWindow() {
            document.getElementById('DIDIFrm').innerHTML = "";
            ifrm = document.createElement("IFRAME");
            ifrm.setAttribute("src", "ResizeLogo.aspx");
            ifrm.style.height = "710px";
            ifrm.style.width = "100%";
            ifrm.style.border = "0px";
            ifrm.scrolling = "no";
            ifrm.frameBorder = "0";
            document.getElementById('DIDIFrm').appendChild(ifrm);
            var modalDialog = $find("popupimage");
            modalDialog.show();

        } 

    </script>
    <script type="text/javascript">
        $(function () {

            //            var jcrop_api;
            //            jcrop_api = $.Jcrop('#imgcrop');
            //            jcrop_api.setSelect([0, 0, 65, 65]);
            //            jcrop_api.enable();

            LoadImage();
        })

        var resizeSel;
        function LoadImage() {
            document.getElementById('<%=rbSystemResizeLogo.ClientID %>').checked = true;
            resizeSel = 0;
            var imgOriginalWidth = document.getElementById("<%=hdnOriginalWidth.ClientID %>").value;
            var imgOriginalHeight = document.getElementById("<%=hdnOriginalHeight.ClientID %>").value;
            if (document.getElementById("imgMain") != null) {
                document.getElementById("imgMain").src = document.getElementById("<%=hdnImgURL.ClientID %>").value;
                document.getElementById("imgMain").style.width = imgOriginalWidth;
                document.getElementById("imgMain").style.height = imgOriginalHeight;

                document.getElementById("imgMain").width = imgOriginalWidth;
                document.getElementById("imgMain").height = imgOriginalHeight;
            }

            var LogoWidth;
            var LogoHeight;
            if (document.getElementById("<%= rbShortLogo.ClientID %>").checked == true) {
                LogoWidth = '<%= ConfigurationManager.AppSettings.Get("ShortLogoWidth") %>';
                LogoHeight = '<%= ConfigurationManager.AppSettings.Get("ShortLogoHeight") %>';

                document.getElementById("<%=lblLogoType.ClientID %>").innerHTML = "Short Logo";
            }
            else {
                LogoWidth = '<%= ConfigurationManager.AppSettings.Get("LongLogoWidth") %>';
                LogoHeight = '<%= ConfigurationManager.AppSettings.Get("LongLogoHeight") %>';

                document.getElementById("<%=lblLogoType.ClientID %>").innerHTML = "Long Logo";
            }

            document.getElementById("<%=lblFixedWidth.ClientID %>").innerHTML = LogoWidth + "px";
            document.getElementById("<%=lblFixedHeight.ClientID %>").innerHTML = LogoHeight + "px";
            document.getElementById("<%=lblDefaultWidth.ClientID %>").innerHTML = LogoWidth + "px";
            document.getElementById("<%=lblDefaultHeight.ClientID %>").innerHTML = LogoHeight + "px";
            if (document.getElementById("<%=rbShortLogo.ClientID %>").checked == true) {
                //                $("#tblTempLogo").css("display", "block");
                //                $("#trShortLogooptional1").css("display", "block");
                //                $("#trShortLogooptional2").css("display", "block");
                //                $("#trShortLogooptional3").css("display", "block");
                SetDivWidthText(1);
                $("#imgBlank").removeClass('longimg').addClass("shortimg");
                document.getElementById("TempShortLogo").src = document.getElementById("<%=hdbTempShortLogoURL.ClientID %>").value;
            }
            else {
                //                $("#tblTempLogo").css("display", "none");
                //                $("#trShortLogooptional1").css("display", "none");
                //                $("#trShortLogooptional2").css("display", "none");
                //                $("#trShortLogooptional3").css("display", "none");
                SetDivWidthText(2);
                $("#imgBlank").removeClass('shortimg').addClass("longimg");
                document.getElementById("TempShortLogo").src = document.getElementById("<%=hdbTempShortLogoURL.ClientID %>").value;
            }


            if (parseInt(imgOriginalWidth) > parseInt(LogoWidth) || parseInt(imgOriginalHeight) > parseInt(LogoHeight)) {
                LoadImgSettings(LogoWidth, LogoHeight);
            }
            else {
                document.getElementById("<%=hdnx.ClientID %>").value = 0;
                document.getElementById("<%=hdny.ClientID %>").value = 0;
                document.getElementById("<%=hdnw.ClientID %>").value = imgOriginalWidth;
                document.getElementById("<%=hdnh.ClientID %>").value = imgOriginalHeight;
            }

        }


        function LoadImgSettings(LogoWidth, LogoHeight) {

            document.getElementById("imgMain").src = document.getElementById("<%=hdnImgURL.ClientID %>").value;
            document.getElementById("imgMain").style.width = LogoWidth;
            document.getElementById("imgMain").style.height = LogoHeight;

            $('#imgMain').Jcrop({
                onSelect: getcroparea,
                setSelect: [20, 20, LogoWidth, LogoHeight],
                minSize: [LogoWidth, LogoHeight],
                maxSize: [LogoWidth, LogoHeight],
                allowResize: false

            });
        }

        function SetImgURL() {
            LoadImage();
        }

        function getcroparea(c) {
            if (resizeSel == 1 && document.getElementById('<%=rbUserCropLogo.ClientID %>').checked == false) {
                document.getElementById('<%=rbUserCropLogo.ClientID %>').checked = true;
            }
            if (resizeSel == 0)
                resizeSel = 1;
            document.getElementById("<%=hdnx.ClientID %>").value = c.x;
            document.getElementById("<%=hdny.ClientID %>").value = c.y;
            document.getElementById("<%=hdnw.ClientID %>").value = c.w;
            document.getElementById("<%=hdnh.ClientID %>").value = c.h;


            //            $('#hdnx').val(c.x);
            //            $('#hdny').val(c.y);
            //            $('#hdnw').val(c.w);
            //            $('#hdnh').val(c.h);
        };

        function DisplayCropImg(IsDisplay) {
            if (IsDisplay == true) {
                $("#tblCropLogo").css("display", "block");
            }
            else {
                $("#tblCropLogo").css("display", "none");
            }
        }
        function ChangeBlank() {
            if (document.getElementById("<%=rbShortLogo.ClientID %>").checked == true) {
                SetDivWidthText(1);
                $("#imgBlank").removeClass('longimg').addClass("shortimg");
            }
            else {
                $("#imgBlank").removeClass('shortimg').addClass("longimg");
                SetDivWidthText(2);
            }
        }
        function SetDivWidthText(type) {
            if (document.getElementById('lblimgWidth') != null) {
                if (type == 1)
                    document.getElementById('lblimgWidth').innerHTML = '110px <b>X</b> 110px';
                else
                    document.getElementById('lblimgWidth').innerHTML = '640px <b>X</b> 165px';
            }
        }
    </script>
    <script type="text/javascript">
        function openWin2(url) {
            window.open(url, "composerwindow", "toolbar=no,width=700,height=400,status=no,scrollbars=no,resize=no,menubar=no");
        }


        function CheckResizeLogoSize() {

            //WIDTH *168 MAX LOGO WIDTH
            //HEIGHT * 275 MAX LOGO HEIGHT
            var height = document.getElementById("yui_img").offsetHeight;
            var width = document.getElementById("yui_img").offsetWidth;

            if (height > 170) {
                alert("The logo size should be less than or equal to the block height size.");
                return false;
            } else if (width > 275) {
                alert("The logo size should be less than or equal to the block width size.");
                return false
            }
            else
                return true;
        }

    </script>
    <style>
        #yui_img
        {
        }
        #example-canvas
        {
            height: 200px;
        }
        div.wrap
        {
        }
    </style>
    <style>
        .popup
        {
            width: 730px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #333333;
        }
        .mid
        {
            background: #fff;
            padding: 0px 5px 5px 15px;
        }
        .sizes
        {
            width: 670px;
            vertical-align: top;
            background: #fff;
            border: #6e6e6e solid 1px;
        }
        .orange
        {
            background: #d57300;
            color: #fff;
            font-size: 13px;
            line-height: 28px;
            padding-left: 5px;
        }
        .blue
        {
            background: #005879;
            color: #fff;
            font-size: 13px;
            line-height: 28px;
            padding-left: 5px;
        }
        .blocklistcolor
        {
            background: #eaeaea;
            line-height: 28px;
            font-size: 13px;
            color: #333333;
            padding-left: 5px;
        }
        .resizelistcolor
        {
            background: #f6f6f6;
            line-height: 28px;
            font-size: 13px;
            color: #333333;
            padding-left: 5px;
        }
        .resizelogo
        {
            width: 670px;
            border: #d57300 solid 1px;
            padding: 10px;
        }
        .resizelogo1
        {
            width: 780px;
            border: #d57300 solid 1px;
            padding: 10px;
        }
        .logo
        {
            width: 200px;
            border: #005879 solid 1px;
            vertical-align: top;
        }
        body
        {
            background-color: #666666;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="page-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="valign-top">
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td>
                                            <uc3:wowmap ID="sitemaplinks" runat="server"></uc3:wowmap>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="page-title" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td>
                                                    Manage Logo
                                                </td>
                                                <td align="left">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="3">
                                                        <ProgressTemplate>
                                                            <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                                <td class="right" align="right">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Label ID="lblLogoMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table class="inputtable" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="valign-top">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 24px">
                                                                            <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-left.gif")%>'
                                                                                width="9" />
                                                                        </td>
                                                                        <td class="new-header">
                                                                            Logo<asp:HiddenField ID="hdnIsLiteVersion" Value="false" runat="server" />
                                                                        </td>
                                                                        <td>
                                                                            <img height="28" src='<%=Page.ResolveClientUrl("~/Images/Dashboard/head-right.gif")%>'
                                                                                width="9" />
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table class="new-table" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="valign-top" align="center">
                                                                            <table cellspacing="0" cellpadding="0" align="center" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="center" colspan="2">
                                                                                            <asp:Image ID="logo" runat="server" Visible="false"></asp:Image>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align='left' valign='top'>
                                                                                            <%--  <%if (hdnSubAcc.Value == "1")
                                                                                              { %>
                                                                                            <span style="padding-left: 15px;"><b>*Note: </b>Affiliate apps display master app logo.</span>
                                                                                            <%} %>--%><asp:HiddenField ID="hdnSubAcc" runat="server" />
                                                                                            <asp:CheckBox runat="server" Text="Add to Image Gallery" ID="chkImageGallery" AutoPostBack="True"
                                                                                                OnCheckedChanged="chkImageGallery_CheckedChanged" Visible="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="align-center" colspan="2">
                                                                                            <br />
                                                                                            <asp:Button ID="btnLogoDelete" OnClick="btnLogoDelete_Click" OnClientClick="return confirm(' Are you sure you want to delete this logo?');"
                                                                                                runat="server" Text="Delete Logo"></asp:Button>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                            <asp:Panel ID="pnlLogoUpload" runat="server">
                                                                                <table class="profile-padding" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td class="profile-caption">
                                                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <%if (!IsLongLogo)
                                                                                                          { %>
                                                                                                            <td colspan="3" style="display: none;">
                                                                                                           <%}
                                                                                                          else
                                                                                                          { %>
                                                                                                            <td colspan="3">
                                                                                                           <%} %>
                                                                                                              <asp:RadioButton runat="server" GroupName="logo" ID="rbShortLogo" Text="Short Logo"
                                                                                                                  Checked="true" Font-Size="14px" Font-Bold="true" onchange="ChangeBlank()" />                                                                                                            
                                                                                                              <asp:RadioButton runat="server" GroupName="logo" ID="rbLongLogo" Text="Long Logo"
                                                                                                                  Font-Size="14px" Font-Bold="true" onchange="ChangeBlank()" />
                                                                                                          </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td style="padding-top: 10px;" valign="top">
                                                                                                            <asp:FileUpload ID="logoimage" runat="server"></asp:FileUpload><br />
                                                                                                            <span class="profile-caption red-color">NOTE: Please use gif, jpeg, png or bmp files
                                                                                                                only.</span>
                                                                                                            <% if (DomainName.ToLower().Contains("inschoolalert"))
                                                                                                               { %>
                                                                                                            <br />
                                                                                                            <label id="lblshortlogo">
                                                                                                                110px <b>X</b> 110px
                                                                                                            </label>
                                                                                                            <%} %>
                                                                                                        </td>
                                                                                                        <td style="padding-top: 10px;" valign="top">
                                                                                                            <asp:LinkButton ID="BtnUpdateLogo" OnClick="BtnUpdateLogo_Click" runat="server" Text="<img src='../../images/upload.gif' border='0'/>"></asp:LinkButton>
                                                                                                            <% if (!DomainName.ToLower().Contains("inschoolalert"))
                                                                                                               { %>
                                                                                                            <a href="javascript:ModalHelpPopup('Add Logo',83,'');">
                                                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" style='border: 0px;' /></a>
                                                                                                            <%}
                                                                                                               else
                                                                                                               { %>
                                                                                                            <a href="javascript:ModalHelpPopup('Add Logo',375,'');">
                                                                                                                <img src="<%=Page.ResolveClientUrl("~/images/Dashboard/new.png")%>" style='border: 0px;' /></a>
                                                                                                            <%} %>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <% if (!DomainName.ToLower().Contains("inschoolalert"))
                                                                                                               { %>
                                                                                                            <div id="dvimgWidth" style="font-size: 13px; display: block; margin: 0 auto; text-align: center;">
                                                                                                                <label id="lblimgWidth">
                                                                                                                </label>
                                                                                                                <div id="imgBlank" class="shortimg">
                                                                                                                </div>
                                                                                                            </div>
                                                                                                            <%} %>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </asp:Panel>
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Panel ID="pnlwizard" runat="server" Width="100%">
                                                                                            <table class="profile-btntbl" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td class="align-center">
                                                                                                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" />&nbsp;&nbsp;<asp:Button
                                                                                                                ID="btndashboard1" OnClick="btndashboard1_Click" runat="server" Text="Go to Dashboard"
                                                                                                                CausesValidation="false" />
                                                                                                            <asp:Button ID="btnwizard" runat="server" Text="Go to Setup Wizard" OnClick="btnwizard_Click"
                                                                                                                CausesValidation="false" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table border="0" width="50%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblpre" runat="server" visiable="false"></asp:Label>
                        <cc1:ModalPopupExtender ID="LogoModalPopup" runat="server" TargetControlID="lblpre"
                            PopupControlID="pnlpopup1" BackgroundCssClass="modal">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlpopup1" runat="server" Width="50%" Style="display: none;">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="popup">
                                <tr>
                                    <td>
                                        <img src="../../images/logos/top.png" width="860" height="17" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="mid">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top" align="right">
                                                    <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/images/popup_close.gif"
                                                        CausesValidation="false" OnClick="btnResizeCancel_Click"></asp:ImageButton>
                                                </td>
                                            </tr>
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
                                                <td align="center">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="sizes">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="1">
                                                                    <tr>
                                                                        <td colspan="2" class="orange">
                                                                            Block Scale: <span style="text-align: right; margin-left: 290px;">
                                                                                <asp:Label runat="server" ID="lblLogoType"></asp:Label>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="blocklistcolor">
                                                                            Width
                                                                        </td>
                                                                        <td class="blocklistcolor">
                                                                            <asp:Label ID="lblFixedWidth" runat="server" Text="275px"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="blocklistcolor">
                                                                            Height
                                                                        </td>
                                                                        <td class="blocklistcolor">
                                                                            <asp:Label ID="lblFixedHeight" runat="server" Text="170px"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="trShortLogooptional1">
                                                <td style="padding-left: 0px;">
                                                    <div style="float: left;">
                                                        <asp:RadioButton runat="server" ID="rbSystemResizeLogo" GroupName="rb1" Checked="true" />
                                                        <span style="font-weight: bold;">Please use the logo that was resized to the recommended
                                                            size of
                                                            <asp:Label ID="lblDefaultWidth" runat="server" Text="110px"></asp:Label>
                                                            X
                                                            <asp:Label ID="lblDefaultHeight" runat="server" Text="110px"></asp:Label>.</span>
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="resizelogo1">
                                                            <tr>
                                                                <td align="center">
                                                                    &nbsp;
                                                                    <img id="TempShortLogo" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="trShortLogooptional2">
                                                <td align="center" style="padding: 5px 20px;" colspan="2">
                                                    <span style="color: #d57300; font-size: 18px; padding: 10px; font-weight: bold;">(OR)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 0px;">
                                                    <div style="float: left;">
                                                        <span id="trShortLogooptional3">
                                                            <asp:RadioButton runat="server" ID="rbUserCropLogo" GroupName="rb1" />
                                                            <span style="font-weight: bold;">Do it yourself by selecting the part of the image that
                                                                you wish to keep as the logo.</span> </span>
                                                        <table border="0" cellpadding="0" cellspacing="0" class="resizelogo1" id='tblCropLogo'>
                                                            <tr>
                                                                <td style="padding-left: 10px;">
                                                                    <div style="width: 750px; height: 220px; overflow: auto;">
                                                                        <img id="imgMain" />
                                                                    </div>
                                                                    <input type="hidden" id="hdnx" runat="server" />
                                                                    <input type="hidden" id="hdny" runat="server" />
                                                                    <input type="hidden" id="hdnw" runat="server" />
                                                                    <input type="hidden" id="hdnh" runat="server" />
                                                                    <asp:HiddenField runat="server" ID="hdnImgURL" />
                                                                    <asp:HiddenField ID="hdnOriginalWidth" runat="server" />
                                                                    <asp:HiddenField ID="hdnOriginalHeight" runat="server" />
                                                                    <asp:HiddenField ID="hdbTempShortLogoURL" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-top: 10px;">
                                                    <asp:LinkButton ID="lnkImageSubmit" runat="server" Width="76" Height="34" OnClick="btnCropLogo_OnClick"><img src="../../images/logos/submit.png" alt="" />
                                                    </asp:LinkButton>
                                                    &nbsp;
                                                    <asp:LinkButton ID="lnkImageCancel" runat="server" Width="76" Height="34" OnClick="btnResizeCancel_Click"><img src="../../images/logos/cancel.png" alt="" />
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="../../images/logos/bottom.png" width="860" height="17" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblnewsimage" runat="server"></asp:Label>
            <cc1:ModalPopupExtender ID="popnewsletterimage" runat="server" TargetControlID="lblnewsimage"
                PopupControlID="pnlnewsletterimage" BackgroundCssClass="modal">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnlnewsletterimage" runat="server" Style="display: none" Width="730px">
                <table cellpadding="0" cellspacing="0" width="730px">
                    <tbody>
                        <tr>
                            <td>
                                <div id="framediv" runat="server">
                                    <%--   <iframe id="IFRAME" src="ResizeLogo.aspx" width="730px" height="590px" scrolling="no"
                                        frameborder="0"></iframe>--%>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnUpdateLogo" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnResizeImageValue" runat="server" />
    <asp:HiddenField ID="hdheight" runat="server" />
    <asp:HiddenField ID="hdwidth" runat="server" />
    <asp:HiddenField ID="hdnPermissionType" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>
            <div style="color: #005aa0; font-weight: bold;">
                Manage Logo
            </div>
            <div style="color: red;" align="center">
                <asp:Label ID="lblerrormessage" runat="server"></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
