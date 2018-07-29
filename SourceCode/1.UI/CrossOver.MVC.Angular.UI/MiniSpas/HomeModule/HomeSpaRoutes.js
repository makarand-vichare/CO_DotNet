var HomeSpa;
(function (HomeSpa) {
    var HomeSpaRoutes = (function () {
        function HomeSpaRoutes() {
        }
        HomeSpaRoutes.ConfigureRoutes = function ($routeProvider) {
            $routeProvider
                .when("/", {
                controller: "HomeSpa.Controllers.HomeController",
                templateUrl: "/MiniSpas/HomeSpa/Views/home.html",
                controllerAs: "homeCtrl"
            })
                .when("/home", {
                controller: "HomeSpa.Controllers.HomeController",
                templateUrl: "/MiniSpas/HomeSpa/Views/home.html",
                controllerAs: "homeCtrl"
            })
                .when("/login", {
                controller: "HomeSpa.Controllers.LoginController",
                templateUrl: "/MiniSpas/HomeSpa/Views/login.html",
                controllerAs: "loginCtrl"
            })
                .when("/signup", {
                controller: "HomeSpa.Controllers.SignupController",
                templateUrl: "/MiniSpas/HomeSpa/Views/signup.html",
                controllerAs: "signupCtrl"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        };
        return HomeSpaRoutes;
    }());
    HomeSpaRoutes.$inject = ["$routeProvider"];
    HomeSpa.HomeSpaRoutes = HomeSpaRoutes;
})(HomeSpa || (HomeSpa = {}));
//# sourceMappingURL=HomeSpaRoutes.js.map