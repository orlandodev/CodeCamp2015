"use strict";

angular.module("ionicCards", ["ionic", "ngResource", "home", "login", "services"])
    .run(function($ionicPlatform) {
        $ionicPlatform.ready(function() {
            // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
            // for form inputs)
            if (window.cordova && window.cordova.plugins.Keyboard) {
                cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
            }
            if (window.StatusBar) {
                // org.apache.cordova.statusbar required
                StatusBar.styleDefault();
            }
        });
    })
    .config(["$stateProvider","$urlRouterProvider", function($stateProvider, $urlRouteProvider) {

        $stateProvider
            .state("tabs", {
                abstract: true,
                url: "/tabs",
                template: "<ion-nav-view/>"
            })
            .state("login", {
                cache: false,
                url: "/login",
                templateUrl: "cards/login/login.html",
                controller: "LoginCtrl"
            })
            .state("tabs.home", {
                url: "/home",
                templateUrl: "cards/home/home.html",
                controller: "HomeCtrl"
            });

        $urlRouteProvider.otherwise("/login");
    }]);