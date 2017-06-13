<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="BannerAdsPreview.aspx.cs" Inherits="USPDHUB.Business.MyAccount.BannerAdsPreview" %>

<%@ Register Src="~/Controls/Sitemaplinks.ascx" TagName="wowmap" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/Scripts/jquery.js")%>"></script>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/main.js")%>"
        type="text/javascript"></script>
    <script language="JavaScript1.2" src="<%=Page.ResolveClientUrl("~/Scripts/dashboardstyle.js")%>"
        type="text/javascript"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="../../Scripts/jquery.Jcrop.js" type="text/javascript"></script>
    <link href="../../css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .datalist
        {
        }
        .datalist td
        {
            vertical-align: top;
            padding-top: 5px;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 300px;
            border: 0px solid #0DA9D0;
            border-radius: 6px;
            padding: 0;
        }
        .modalPopup .header
        {
            color: #454545;
            line-height: normal;
            text-align: center;
            font-weight: bold;
            border-bottom: 1px solid #999;
            font-size: 20px;
            height: auto;
            padding: 0 0 5px;
        }
        .modalPopup .body
        {
            min-height: 200px;
            line-height: 30px;
            text-align: center;
        }
        .btn
        {
            -webkit-border-radius: 3;
            -moz-border-radius: 3;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            background: #3498db;
            padding: 6px 25px;
            text-decoration: none;
            font-weight: normal;
            display: inline-block;
        }
        
        .btn:hover
        {
            background: #3cb0fd;
            text-decoration: none;
        }
        .btnorange
        {
            -webkit-border-radius: 3;
            -moz-border-radius: 3;
            border-radius: 3px;
            font-family: Arial;
            color: #ffffff;
            font-size: 15px;
            background: #DC7224;
            padding: 10px 20px;
            color: #fff !important;
            text-decoration: none !important;
            font-weight: normal;
        }
        
        .btnorange:hover
        {
            background: #3cb0fd;
            text-decoration: none;
        }
        #drop_zone
        {
            padding: 10px;
            width: 100%;
            min-height: 100px;
            max-height: 200px;
            overflow: auto;
            text-align: left;
            text-transform: uppercase;
            font-weight: bold;
            border: 1px solid #ccc;
            outline: 0px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            box-sizing: border-box;
        }
        .upload-table
        {
            padding: 10px;
            box-sizing: border-box;
            width: 100%;
        }
        .bannerdivider
        {
            /*border-left: 1px solid #EF7126;*/
            width: 25px;
        }
        #drop_zone
        {
            background: #f5f5f5;
        }
        .phone-no
        {
            font-size: 22px;
            padding-bottom: 10px;
        }
        .btn-submit
        {
            margin: 20px 0px 0px;
        }
        .col-1
        {
            width: 520px;
            padding-right: 10px;
        }
        #gallery img
        {
            max-width: 100%;
        }
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
        body
        {
            background-color: #666666;
        }
        .slotheader
        {
            width: 520px;
            margin-top: 15px;
        }
        .slotname
        {
            color: #F68B1F;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .slotblock
        {
            border: 1px solid #62C2CC;
            width: 320px;
            height: 51px;
            margin: 0px auto;
            text-align: center;
            line-height: 51px;
            float: left;
        }
        .displayblock
        {
            width: 100px;
            float: left;
            margin-top: 21px;
            text-align: center;
            padding-left: 10px;
        }
        .deleteblock
        {
            float: left;
            vertical-align: top;
            margin: 0px;
            padding-left: 5px;
            padding-top: 13px;
        }
        .actionheaders
        {
            width: 600px;
        }
        .brder
        {
            border-bottom: 2px solid #000000;
            margin-bottom: 15px;
            padding: 10px 0 10px;
        }
        .head-h3
        {
            font-size: 12px;
            font-weight: bold;
            color: #000000;
            text-align: center;
            display: table-cell;
            padding-left: 13px;
        }
        #slideshow > div
        {
            position: absolute;
        }
        .openrate a
        {
            color: #FFF;
            font-size: 11px;
            text-align: center;
            margin: 5px 0px 0px;
            padding: 5px 14px;
            border: 1px solid #999;
            border-radius: 2px;
            background: #FFF none repeat scroll 0% 0%;
            float: none;
            display: inline-block;
            text-decoration: none;
            transition: all 0.2s ease 0s;
            font-size: 13px;
            font-weight: bold;
            background: #008080 none repeat scroll 0% 0%;
        }
        .openrate a:hover
        {
            background: #003752 none repeat scroll 0% 0%;
            border-color: #003752;
            color: #FFF;
        }
    </style>
    <script type="text/javascript">
        var myTimer;
        var row_str = '<div style="background-color:#f1f1f1;" class="divToggleTop">&nbsp;</div>';
        function toggle_visibility(id) {
            if (document.getElementById(id).style.display == "none") {
                document.getElementById(id).style.display = "block";
                document.getElementById('<%=hdnToggle.ClientID %>').value = "0";
            }
            else {
                if (document.getElementById('<%=hdnToggle.ClientID %>').value == "0") {
                    $("#tabNavigation").append(row_str);
                    $(".divToggleTop").height($("#divMobileFooter").height() + $("#divMobileHeader").height() - $("#divMobileNav").height() + 20);
                    document.getElementById('<%=hdnToggle.ClientID %>').value = "1";
                }
                else {
                    $('.divToggleTop').remove();
                    document.getElementById(id).style.display = "none";
                }
            }
        }

        function hidePreview() {
            $('#imgPreview').stop().fadeOut('fast');
        }
        function BindLoadEvents() {
            var bannerAds = document.getElementsByClassName("banneraddrotator");
            if (bannerAds.length > 1) {
                $("#slideshow > div:gt(0)").hide();
                myTimer = setInterval(PlayBanners, 3000);
            }
            else {
                $("#slideshow:first-child").attr("display", "block");
            }
        }
        function PlayBanners() {
            $('#slideshow > div:first').fadeOut(1000).next().fadeIn(1000).end().appendTo('#slideshow');
        }
        $(function () {
            BindLoadEvents();
        });
        function UploadNewBannerAd(ordernumber) {
            document.getElementById('<%=hdnOrderNo.ClientID %>').value = ordernumber;
            location.href = "../../Business/MyAccount/BannerAdsUpload.aspx?slot=" + ordernumber;
        }
        function DeleteBannerAd(bannerAdId) {
            if (confirm("Are you sure you want to delete the selected banner ad?")) {
                document.getElementById('<%=hdnOrderNo.ClientID %>').value = bannerAdId;
                clearInterval(myTimer);
                document.getElementById('ctl00_cphUser_btnDelete').click();
            }
        }
        function EditBannerAd(bannerId, ordernumber) {
            location.href = "../../Business/MyAccount/BannerAdsUpload.aspx?slot=" + ordernumber + "&banid=" + bannerId;
        }

        var checkedList = "";
        function UpdateAppDisplay() {
            clearInterval(myTimer);
            checkedList = "";
            $('input.appdisplaycheck[type=checkbox]').each(function () {
                //SubmitAppDisplay(this.id.replace("chk", ""), this.checked);
                checkedList = checkedList + "##" + this.id.replace("chk", "") + "," + this.checked;
            });
            document.getElementById("<%=hdnBannerAdsResult.ClientID %>").value = "";
            document.getElementById("<%=hdnBannerAdsResult.ClientID %>").value = checkedList;
            return true;
        }
        function SubmitAppDisplay(bannerAddId, flag) {
            var typeval = PageMethods.UpdateAppDiplayItems(bannerAddId, flag, OnUpdateSuccess, OnUpdateFailure);
        }

        function OnUpdateSuccess(result) {

            if (result == "success") {

            }
            else {
                OnUpdateFailure(result);
                return false;
            }

        }
        function OnUpdateFailure(result) {
            alert("Failure occurs while updating. Please try again.");
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="upload-table">
                <tr>
                    <td valign="top">
                        <div style="color: #218C8D; font-size: 11px;">
                            <h1>
                                Banner Ads
                            </h1>
                            <asp:HiddenField ID="hdnUploadTye" runat="server" />
                            <asp:HiddenField runat="server" ID="hdnOrderNo" />
                            <asp:HiddenField ID="hdnToggle" runat="server" Value="0" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:UpdateProgress ID="UpdateProgress6" runat="server" DisplayAfter="3">
                            <ProgressTemplate>
                                <img src="../../images/popup_ajax-loader.gif" border="0" /><b><font color="green">Processing....</font></b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Label ID="lblUpdateMsg" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="col-1" style="padding-top: 10px;">
                                                <span style="text-align: left; line-height: 20px;"><span style="color: Red; font-weight: bold;">
                                                    Note:</span> You can upload a maximum of
                                                    <asp:Label ID="lblMaxAds" Text="6" runat="server"></asp:Label>
                                                    banner ads.</span><br />
                                                <span style="color: #DC7224; font-weight: bold;">Banner Ad Size:</span>
                                                <b>700px X 140px</b>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td class="openrate" style="float: right; padding-right: 20px;">
                                                <a href="BannerAdClickCountReport.aspx">Open Rate Report</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="col-1" valign="top">
                                                <asp:Literal ID="ltrBannersAds" runat="server"></asp:Literal>
                                            </td>
                                            <td class="bannerdivider">
                                                &nbsp;
                                            </td>
                                            <td valign="top" style="padding-top: 15px;">
                                                <asp:Literal ID="ltrBGImagePreview" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="float: right; padding-right: 170px; padding-top: 25px;">
                                                <%--OnClick="btnUpdate_Click"--%>
                                                <asp:Button ID="btnDashoard" runat="server" Text="Dashboard" Width="90px" Height="25px"
                                                    OnClick="btndashboard_OnClick" />
                                                &nbsp;
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="70px" Height="25px"
                                                    OnClientClick="return UpdateAppDisplay()" OnClick="btnUpdate_Click" />
                                                <asp:HiddenField runat="server" ID="hdnBannerAdsResult" />
                                            </td>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div style="visibility: hidden">
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" CausesValidation="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
