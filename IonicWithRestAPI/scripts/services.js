"use strict";

window.HostUrl = "https://wills-lenovo";

angular.module("services", [])
    .factory("LoginService", function ($rootScope, $resource) {

        var service = {};

        service.authenticate = function (userId, password) {
            var credentials = {
                "user_id": userId,
                "password": password
            };

            var tokenRequest = $resource(window.HostUrl + "/IdentityProvider/api/token", {}, {
                "authenticate": {
                    method: "POST",
                    headers: { 'Content-Type': "application/json; charset=utf-8" }
                }
            });

            return tokenRequest.save(credentials);
        };

        return service;
});