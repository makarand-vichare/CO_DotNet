var UserDemandModule;
(function (UserDemandModule) {
    var UserDemandModuleRoutes = (function () {
        function UserDemandModuleRoutes() {
        }
        UserDemandModuleRoutes.configureRoutes = function ($routeProvider) {
            $routeProvider
                .when("/", {
                controller: "UserDemandModule.Controllers.UserDemandController",
                templateUrl: "/MiniSpas/UserDemandModule/Views/userDemand.html",
                controllerAs: "userDemandCtrl"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        };
        return UserDemandModuleRoutes;
    }());
    UserDemandModuleRoutes.$inject = ["$routeProvider"];
    UserDemandModule.UserDemandModuleRoutes = UserDemandModuleRoutes;
})(UserDemandModule || (UserDemandModule = {}));
//# sourceMappingURL=UserDemandModuleRoutes.js.map