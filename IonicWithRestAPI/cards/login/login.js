"use strict";

angular.module("login", [])
    .controller("LoginCtrl", ["$scope", "$state", "$window", "$ionicLoading", "LoginService", function ($scope, $state, $window, $ionicLoading, LoginService) {

        $scope.DoLogin = function (user) {
            $ionicLoading.show({
                templateUrl: "partials/auth.html"
            });

            LoginService.authenticate(user.signonId, user.password)
                .$promise.then(
                    function (data) {
                        $window.sessionStorage.setItem("token", data.access_token);
                        $state.go("tabs.home");
                        $ionicLoading.hide();
                    },
                    function (error) {
                        console.log(error);
                        $ionicLoading.hide();
                    });
        };
    }]
);