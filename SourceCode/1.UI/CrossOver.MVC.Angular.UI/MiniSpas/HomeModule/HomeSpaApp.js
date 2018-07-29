/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
(function () {
    var homeModule = MiniSpas.ModuleInitiator.GetModule("HomeSpa");
    homeModule.config(HomeSpa.HomeSpaRoutes.ConfigureRoutes);
    homeModule.config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push(Common.Interceptors.AuthenticationInterceptor.Factory);
    });
    homeModule.run(['HomeSpa.Services.AuthService', function (authService) {
            authService.GetAuthData();
        }]);
})();
//# sourceMappingURL=HomeSpaApp.js.map