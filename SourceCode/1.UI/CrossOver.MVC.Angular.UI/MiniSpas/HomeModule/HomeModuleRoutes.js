var HomeModule;
(function (HomeModule) {
    var HomeModuleRoutes = (function () {
        function HomeModuleRoutes() {
        }
        HomeModuleRoutes.ConfigureRoutes = function ($routeProvider) {
            $routeProvider
                .when("/", {
                controller: "SearchBookModule.Controllers.SearchBookController",
                templateUrl: "/MiniSpas/SearchBookModule/Views/searchBook.html",
                controllerAs: "searchBookCtrl"
            })
                .when("/home", {
                controller: "HomeModule.Controllers.HomeController",
                templateUrl: "/MiniSpas/HomeModule/Views/home.html",
                controllerAs: "homeCtrl"
            })
                .when("/login", {
                controller: "HomeModule.Controllers.LoginController",
                templateUrl: "/MiniSpas/HomeModule/Views/login.html",
                controllerAs: "loginCtrl"
            })
                .when("/signup", {
                controller: "HomeModule.Controllers.SignupController",
                templateUrl: "/MiniSpas/HomeModule/Views/signup.html",
                controllerAs: "signupCtrl"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        };
        return HomeModuleRoutes;
    }());
    HomeModuleRoutes.$inject = ["$routeProvider"];
    HomeModule.HomeModuleRoutes = HomeModuleRoutes;
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=HomeModuleRoutes.js.map