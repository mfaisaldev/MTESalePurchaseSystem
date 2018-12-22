/// <reference path="../angular.js" />

var app = angular.module("productApp",[]);

app.service("productService", function ($http) {
    this.getAllProducts = function () {
        return $http.get("/products/index");
    };
    this.getTopProducts= function(){
        return $http.get("");
    };
    this.getHotProducts = function () {
        return $http.get("");
    };
    this.getBestSeller = function () {
        return $http.get("");
    };
    this.getTrends = function () {
        return $http.get("");
    };
    this.getLatestProducts = function () {
        return $http.get("/Products/LatestProducts");
    };

});

app.controller("productController", function ($scope, productService) {
    $scope.ProductList = [];
    $scope.pLimit = 8;
    loadRecords();

    function loadRecords() {
        promiseGet = productService.getLatestProducts();
        promiseGet.then(function (products) {
            $scope.ProductList = products.data;
        });
    };
});