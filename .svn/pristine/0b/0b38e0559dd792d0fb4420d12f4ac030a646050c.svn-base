
var Myapp = angular.module("MyApp", []);
Myapp.controller('StoreController', function ($scope, $http) {
    var profileid = angular.element(document.querySelector('#cphUser_hdnProfileID'));
    $scope.ProfileID = profileid.val();
    var expiryDate = angular.element(document.querySelector('#cphUser_hdnExpiryDate'));
    $scope.ExpiryDate = expiryDate.val();
    loadProducts();
    function loadProducts() {
        //getting products using ajax call
        var post = $http({
            method: "POST",
            url: "UpgradeModuleExpiryDate.aspx/getProductsList",
            dataType: 'json',
            data: { pIsSignup: false, pProfileID: $scope.ProfileID }, 
            headers: { "Content-Type": "application/json" }
        });

        post.success(function (data, status) {

            $scope.ProductsList = [];
            $scope.CartList = [];
            var products = angular.forEach(data.d, function (item) {

                if (item.ListName == "productlist") {     // not in package items
                    if (item.IsSelected == true) {
                        if (item.Request_Type != 10004) {
                            if (parseInt($scope.SubType) == 1)
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
                        if (parseInt($scope.SubType) == 1) {

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
                            if (parseInt($scope.SubType) == 1)
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
                            if (parseInt($scope.SubType) == 1)
                                $scope.TotalAmount = parseFloat($scope.TotalAmount) + parseFloat(item.Price * item.Quantity);
                            else
                                $scope.TotalAmount = parseFloat($scope.TotalAmount) + parseFloat(item.Annual_Price * item.Quantity);
                        }
                        $scope.CartList.push(item);

                    }
                }
            });

        });

        post.error(function (data, status) {
            $window.alert(data.Message);
        });
    }


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
    }


    $scope.btnUpgradeModules = function (CartList) {
        var expiryDate = angular.element(document.querySelector('#cphUser_hdnExpiryDate'));
        $scope.ExpiryDate = expiryDate.val();
        alert($scope.ExpiryDate);
        var post = $http({
            url: 'UpgradeModuleExpiryDate.aspx/saveCart_ProductList',
            method: 'POST',
            headers: { 'content-type': 'application/json' },
            data: '{pcartlist:' + JSON.stringify(CartList) + ',ExpiryDate:' + $scope.ExpiryDate + '}'
        });
        post.success(function (data, status) {
            alert(data.message);
        });
        post.error(function (data, status) {
            alert(data.Message);
        });
    }


});

