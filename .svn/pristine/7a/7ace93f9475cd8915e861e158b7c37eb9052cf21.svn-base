<%@ Page Title="" Language="C#" MasterPageFile="~/AdminHome.master" AutoEventWireup="true"
    CodeBehind="UpgradeModuleExpiryDate.aspx.cs" Inherits="USPDHUB.Admin.UpgradeModuleExpiryDate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUser" runat="server">
    <link href="../css/Store.css" rel="stylesheet" type="text/css" />
    <link href="../css/sweetalert.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <link href="../../css/Bulletins.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="../Scripts/angular.min.js" type="text/javascript"></script>
    <script src="../Scripts/StoreCart.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            LoadDataPickers();

        });
        function LoadDataPickers() {
            $("#datepicker").datepicker();
        }
        function HideAlertWindow() {
            $(".sweet-overlay").css("display", "none");
            $("#divConfirmWindow").css("display", "none");
            return false;
        }

        function date() {
            var Date = document.getElementById("txtEndDate");
            '<%Session["ExpiryDate"] = "' + Date + '"; %>';
            alert('<%=Session["ExpiryDate"] %>');
        }
    </script>
    <style type="text/css">
        #innermidbg
        {
            float: left;
        }
        .ui-datepicker
        {
            font-size: 8pt !important;
        }
    </style>
    <asp:ScriptManager ID="smgr1" runat="server">
    </asp:ScriptManager>
    <table width="100%">
        <tr align="left">
            <td>
                <asp:Button ID="btnDashboar" runat="server" />
            </td>
        </tr>
    </table>
    <div class="main_container" ng-app="MyApp" ng-controller="StoreController">
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
            <h4 class="secondhead">
                Cart
            </h4>
            <hr />
            <div class="m-b-10">
            </div>
            <div ng-show="CartList.length === 0" class="nocart emptyCart" style="">
                <p translate="">
                    <b class="ng-scope" style="">Your cart is empty.</b><span class="ng-scope"> Select a
                        product from the list below.</span></p>
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
                    <div class="item_description" style="display: none;">
                        {{row.Quantity+' '+ row.ItemDescription}}
                    </div>
                    <div class="item_price" style="display: none;">
                        <p ng-show="!row.IsPackageItem && row.Price &gt; 0">
                            {{row.Quantity*row.Price | currency}}</p>
                    </div>
                    <div class="item_confirm">
                        <a href="javascript:void(0);">
                            <img ng-show="row.IsDefaultItem == false" ng-click="btnRemoveProduct(row)" src="../Images/cart_images/Item_Cancel.png"
                                style="padding-top: 5px;" />
                        </a>
                    </div>
                </div>
            </div>
            <div>
                <table width="60%" style="padding-top: 10px">
                    <tr>
                        <td>
                            Expiration Date:
                            <input type="text" id="datepicker" ng-model="Date" />
                        </td>
                        <td>
                            <button id="btnsubmit" value="click" style="padding-top: 5px; width: 30px; height: 30px;"
                                ng-click="btnUpgradeModules()">
                                click</button>
                            <%--  <img src="../Images/submit.png" style="padding-top: 5px; height: 30px; border-radius: 16.5px;"
                                    ng-click="btnUpgradeModules()" />--%>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="m-b-50">
            </div>
            <asp:HiddenField ID="hdnExpiryDate" runat="server" />
            <asp:HiddenField ID="hdnProfileID" runat="server" Value="0" />
        </div>
    </div>
</asp:Content>
