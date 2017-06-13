<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminRenewalStore.aspx.cs"
    MasterPageFile="~/AdminHome.master" Inherits="USPDHUB.Admin.AdminRenewalStore" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
    <script src="../Scripts/Angular/angular.min.js" type="text/javascript"></script>
    <script src="../Scripts/Angular/Store.js" type="text/javascript"></script>
    <link href="../css/Store.css" rel="stylesheet" type="text/css" />
    <link href="../css/sweetalert.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="../../Scripts/flyers/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet"
        type="text/css" />
    <script src="../../Scripts/flyers/jquery-ui-1.8.21.custom.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.textarea-expander.js" type="text/javascript"></script>
    <script>
        function HideAlertWindow() {
            $(".sweet-overlay").css("display", "none");
            $("#divConfirmWindow").css("display", "none");
            return false;
        }

        function LoadDataPickers() {
            $("#txtExpiryDate").datepicker();
        }

        window.onload = function () {
            LoadDataPickers();
        };

    </script>
    <style type="text/css">
        .btn
        {
            background: #3498db;
            background-image: -webkit-linear-gradient(top, #3498db, #2980b9);
            background-image: -moz-linear-gradient(top, #3498db, #2980b9);
            background-image: -ms-linear-gradient(top, #3498db, #2980b9);
            background-image: -o-linear-gradient(top, #3498db, #2980b9);
            background-image: linear-gradient(to bottom, #3498db, #2980b9);
            -webkit-border-radius: 28;
            -moz-border-radius: 28;
            border-radius: 28px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            padding: 10px 20px 10px 20px;
            text-decoration: none;
        }
        
        .btn:hover
        {
            background: #3cb0fd;
            text-decoration: none;
        }
        .butn
        {
            background: #afb2b5;
            background-image: -webkit-linear-gradient(top, #afb2b5, #afb2b5);
            background-image: -moz-linear-gradient(top, #afb2b5, #afb2b5);
            background-image: -ms-linear-gradient(top, #afb2b5, #afb2b5);
            background-image: -o-linear-gradient(top, #afb2b5, #afb2b5);
            background-image: linear-gradient(to bottom, #afb2b5, #afb2b5);
            -webkit-border-radius: 28;
            -moz-border-radius: 28;
            border-radius: 28px;
            font-family: Arial;
            color: #ffffff;
            font-size: 16px;
            padding: 10px 20px 4.5px 20px;
            text-decoration: none;
        }
        
        .butn:hover
        {
            background: #afb2b5;
            text-decoration: none;
        }
        #innermidbg
        {
            float: left;
        }
        .ui-datepicker
        {
            font-size: 8pt !important;
        }
        hr
        {
            background: #0a487a none repeat scroll 0 0;
            border: medium none;
            height: 1px;
            margin: 0;
            width: 780px;
        }
    </style>
    <div class="main_container" ng-app="MyApp" ng-controller="StoreController">
        <div style="font-size: large; font-size: 14px bold; margin: 5px 10px; padding-left: 223px;
            color: green;">
            {{lblMessgae}}</div>
        <div class="sweet-overlay" tabindex="-1" style="opacity: 1.03; display: none;">
        </div>
        <div id="divConfirmWindow" class="sweet-alert showSweetAlert visible" data-custom-class=""
            data-has-cancel-button="true" data-has-confirm-button="true" data-allow-outside-click="false"
            data-has-done-function="true" data-animation="pop" data-timer="null" style="display: none;
            margin-top: -174px;">
            <div class="sa-icon sa-error" style="display: none;">
                <span class="sa-x-mark"><span class="sa-line sa-left"></span><span class="sa-line sa-right">
                </span></span>
            </div>
            <div class="sa-icon sa-warning pulseWarning" style="display: block;">
                <span class="sa-body pulseWarningIns"></span><span class="sa-dot pulseWarningIns">
                </span>
            </div>
            <div class="sa-icon sa-info" style="display: none;">
            </div>
            <div class="sa-icon sa-success" style="display: none;">
                <span class="sa-line sa-tip"></span><span class="sa-line sa-long"></span>
                <div class="sa-placeholder">
                </div>
                <div class="sa-fix">
                </div>
            </div>
            <div class="sa-icon sa-custom" style="display: none;">
            </div>
            <h2>
                Are you sure?</h2>
            <p style="display: block;">
                <img src='{{tempobjProduct.ImageUrl}}' style="display: inline-block; vertical-align: middle;" />
                &nbsp; {{tempobjProduct.ItemTitle}}</p>
            <fieldset>
                <input type="text" tabindex="3" placeholder="">
                <div class="sa-input-error">
                </div>
            </fieldset>
            <div class="sa-error-container">
                <div class="icon">
                    !</div>
                <p>
                    Not valid!</p>
            </div>
            <div class="sa-button-container">
                <button class="cancel" tabindex="2" onclick="return HideAlertWindow();" style="display: inline-block;">
                    Cancel</button>
                <div class="sa-confirm-button-container">
                    <input value="Yes, remove it!" type="button" id="btnConfirmDelete" ng-click="btnRemoveProductFromCartList(tempobjProduct);"
                        class="confirm" tabindex="1" style="display: inline-block; color: White; background-color: rgb(221, 107, 85);">
                    </input>
                    <div class="la-ball-fall">
                        <div>
                        </div>
                        <div>
                        </div>
                        <div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="cartleftcontainer">
            <div>
                <div style="float: left;">
                    <h4>
                        RENEWAL CART</h4>
                </div>
                <div style="float: right;">
                    <div>
                        <b>Member ID:
                            <asp:Label ID="lblMemberID" runat="server"></asp:Label></b></div>
                    <div>
                        <b>Profile Name:
                            <asp:Label ID="lblProfileName" runat="server"></asp:Label></b></div>
                </div>
            </div>
            <hr />
            <div class="m-b-10">
            </div>
            <div ng-show="CartList.length === 0" class="nocart emptyCart" style="">
                <p translate="">
                    <b class="ng-scope" style="">Your cart is empty.</b></p>
            </div>
            <div class="card_aded_list" ng-repeat="row in CartList | orderBy:ItemID:false">
                <div class="cart_item" style="background-color: rgb(234, 234, 234);" ng-hide="row.IsPackageItem">
                    <div class="item_img">
                        <img src="{{row.ImageUrl}}" alt="" />
                    </div>
                    <div class="item_title">
                        <p>
                            {{row.ItemTitle}}
                        </p>
                    </div>
                    <div class="item_title" style="padding-top:25px" >
                        <p>
                            {{row.Renewal_Date |date:'dd/MM/yyyy' }}</p>
                    </div>
                    <div class="item_price" style="display: none;">
                        <p ng-show="!row.IsPackageItem && row.Price &gt; 0">
                            {{row.Quantity*row.Price | currency}}</p>
                    </div>
                    <div class="item_confirm" style="padding-right: 21px">
                        <a href="javascript:void(0);">
                            <img ng-show="row.IsDefaultItem == false" ng-click="btnRemoveProduct(row)" src="../Images/cart_images/Item_Cancel.png"
                                style="padding-top: 5px;" />
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div ng-show="CartList.length != 0 ">
            <table width="30%" style="padding-top: 10px">
                <tr>
                    <td>
                        Expiration Date:
                        <input type="text" id="txtExpiryDate" style="font: 14px bold;" />
                    </td>
                </tr>
                <tr>
                    <td align="center" style="padding-top: 10px;">
                        <input type="button" value="Submit" class="btn" ng-click="btnUpgradeModules();" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="butn" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="m-b-50">
        </div>
        <asp:HiddenField ID="hdnExpiryDate" runat="server" />
        <asp:HiddenField ID="hdnProfileID" runat="server" Value="0" />
        
    </div>
</asp:Content>
