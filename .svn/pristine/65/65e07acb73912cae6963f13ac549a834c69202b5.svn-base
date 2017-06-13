/// <reference path="angular.min.js" />

var Myapp = angular.module("MyApp", []);

Myapp.controller("StoreController", function ($scope, StoreService, $timeout, Scopes, $rootScope, $sce) {

    $scope.ExpiryDate = "";
    $scope.ProfileID = angular.element(document.querySelector('#ctl00_cphUser_hdnProfileID')).val();
    var subtype = angular.element(document.querySelector('#cphUser_hdnSubType'));   // for finding monthly/yearly
    $scope.SubType = subtype.val();
   var ExpDate = new Date();
    /*** Bind Products ***/
    LoadProducts();

    function LoadProducts() {
        //alert($scope.ProfileID);
        StoreService.GetProductsList($scope.ProfileID).then(function (result) {

            console.log(result.data.d);
            $scope.ProductsList = [];
            $scope.CartList = [];

            var products = angular.forEach(result.data.d, function (item) {
                SubType = item.Subscription_period;
                if (item.ListName == "productlist") {     // not in package items
                    if (item.IsSelected == true) {
                        if (item.Request_Type != 10004) {
                            if (parseInt(item.Subscription_Period) == 1)
                                $scope.OrderAmount = parseFloat($scope.OrderAmount) - parseFloat(item.Price * item.Quantity);
                            else
                                $scope.OrderAmount = parseFloat($scope.OrderAmount) - parseFloat(item.Annual_Price * item.Quantity);
                        }
                        else// *** Adding branded app maintenance fee *** //
                        {
                            $scope.IsBranded = true;
                            $scope.AppOneTimeFee = item.Price;
                            $scope.TotalAmount = parseFloat($scope.TotalAmount) + parseFloat($scope.AppOneTimeFee);
                        }
                        if (parseInt(item.Subscription_Period) == 1) {

                            $scope.TotalAmount = parseFloat($scope.TotalAmount) + parseFloat(item.Price * item.Quantity);
                        }
                        else
                            $scope.TotalAmount = parseFloat($scope.TotalAmount) + parseFloat(item.Annual_Price * item.Quantity);
                        $scope.CartList.push(item);
                    }
                    else {

                        $scope.ProductsList.push(item);
                    }
                }
                else {

                    // Adding default cartlist items (package items)
                    if (item.ListName == "cartlist") {
                        if (item.Request_Type != 10004 && item.IsPackageItem != true) {
                            if (parseInt(item.Subscription_Period) == 1)
                                $scope.OrderAmount = parseFloat($scope.OrderAmount) + parseFloat(item.Price * item.Quantity);
                            else
                                $scope.OrderAmount = parseFloat($scope.OrderAmount) + parseFloat(item.Annual_Price * item.Quantity);

                        }
                        else// *** Adding branded app maintenance fee *** //
                        {
                            if (item.Request_Type == 10004) {
                                $scope.IsBranded = true;
                                $scope.AppOneTimeFee = item.Price;
                                $scope.TotalAmount = parseFloat($scope.TotalAmount) + parseFloat($scope.AppOneTimeFee);
                            }
                        }
                        if (item.IsPackageItem != true) { //item.Request_Type != 10000
                            if (parseInt(item.Subscription_Period) == 1)
                                $scope.TotalAmount = parseFloat($scope.TotalAmount) + parseFloat(item.Price * item.Quantity);
                            else
                                $scope.TotalAmount = parseFloat($scope.TotalAmount) + parseFloat(item.Annual_Price * item.Quantity);
                        }
                        $scope.CartList.push(item);

                    }
                }
            });


        }); // END GetProductsList factory method

    } // END function



    $scope.btnRemoveProduct = function (objProduct) {
        angular.element(document.querySelector('#divConfirmWindow')).css("display", "block");
        angular.element(document.querySelector('.sweet-overlay')).css("display", "block");

        $scope.tempobjProduct = objProduct;

    }

    $scope.btnRemoveProductFromCartList = function (objProduct) {

        var result = $scope.CartList.filter(function (elem) {
            return elem != objProduct;
        });
        $scope.CartList = result;

        if (objProduct.Request_Type != 40012) {
            if (parseInt($scope.SubType) == 1)
                $scope.OrderAmount = parseFloat($scope.OrderAmount) - parseFloat(objProduct.Price * objProduct.Quantity);
            else
                $scope.OrderAmount = parseFloat($scope.OrderAmount) - parseFloat(objProduct.Annual_Price * objProduct.Quantity);
        }
        else// *** removing branded app maintenance fee *** //
        {
            /*** Start Only Remove Branded App then Maintence Fee:10004 also removing ***/

            if (objProduct.Request_Type == 40012) {
                var AppOneTimeFeeObj = {};
                $scope.CartList.filter(function (el) {

                    if (el.Request_Type == 10004) {
                        $scope.AppOneTimeFee = parseFloat($scope.AppOneTimeFee) - parseFloat(el.Price);
                        return AppOneTimeFeeObj = el;

                    }
                });

                result = $scope.CartList.filter(function (elem) {
                    return elem != AppOneTimeFeeObj;
                });
                $scope.CartList = result;
                if (parseInt($scope.SubType) == 1) {
                    $scope.OrderAmount = parseFloat($scope.OrderAmount) - parseFloat(objProduct.Price);
                }
                else {
                    $scope.OrderAmount = parseFloat($scope.OrderAmount) - parseFloat(objProduct.Annual_Price);
                }
                $scope.ProductsList.push(AppOneTimeFeeObj);
            }

            /*** END Only Remove Branded App then Maintence Fee also removing ***/

            $scope.IsBranded = false;
        }

        $scope.TotalAmount = parseFloat($scope.OrderAmount) + parseFloat($scope.AppOneTimeFee);
        objProduct.IsExpand = false;
        $scope.ProductsList.push(objProduct);

        angular.element(document.querySelector('#divConfirmWindow')).css("display", "none");
        angular.element(document.querySelector('.sweet-overlay')).css("display", "none");

        return;

        return false;
    } // end remove products


    $scope.btnUpgradeModules = function () {
        var Month = ((ExpDate.getMonth().length + 1) === 1) ? (ExpDate.getMonth() + 1) : '0' + (ExpDate.getMonth() + 1);
        var currentDate = Month + "/" + ExpDate.getDate() + "/" + ExpDate.getFullYear();
        $scope.ExpiryDate = angular.element(document.querySelector('#txtExpiryDate')).val();
        if ($scope.ExpiryDate == '') {
            alert("Please enter Expiry Date.");
        }
        else if ($scope.ExpiryDate < currentDate) {
            alert("Expiration date should be later than current date.");
        }
        else {
            StoreService.UpdateUserModuleExpiryDate($scope.CartList, $scope.ExpiryDate, $scope.ProfileID).then(function (result) {

                $scope.lblMessgae = "Cart items updated successfully.";
                setTimeout(function () { window.location.reload(true); }, 2000);

            });
        }
    } //



})// END Controller

// Service callings to StoreService.asmx page
Myapp.factory("StoreService", function ($http) {
    var fact = {};

    fact.GetProductsList = function (pProfileID) {
        return $http({
            url: '../Admin/AdminRenewalStore.aspx/GetProductsList',
            method: 'POST',
            headers: { 'content-type': 'application/json' },
            data: '{pProfileID:' + pProfileID + '}'
        });
    } //

    fact.UpdateUserModuleExpiryDate = function (pCartList, pExpiryDate, pProfileID) {
        return $http({
            url: '../Admin/AdminRenewalStore.aspx/SaveCart_ProductList',
            method: 'POST',
            headers: { 'content-type': 'application/json' },
            data: '{pExpiryDate:' + JSON.stringify(pExpiryDate) + ',pProfileID:' + pProfileID + ',pCartList:' + JSON.stringify(pCartList) + '}'
        });
    } //

    return fact;

}); // END Factory Service Methods

Myapp.factory('Scopes', function ($rootScope) {
    var mem = {};

    return {
        store: function (key, value) {
            $rootScope.$emit('scope.stored', key);
            mem[key] = value;
        },
        get: function (key) {
            return mem[key];
        }
    };
});