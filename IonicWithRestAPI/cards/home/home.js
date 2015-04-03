"use strict";

angular.module("home", [])
    .controller("HomeCtrl", ["$scope", "$state", function ($scope, $state) {

        $scope.search = function () {
            $state.go("tabs.search");
        };
    }]
);