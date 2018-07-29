/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
(function () {
    var homeModule = MiniSpas.ModuleInitiator.GetModule("HomeModule");
    homeModule.config(HomeModule.HomeModuleRoutes.ConfigureRoutes);
    homeModule.config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push(Common.Interceptors.AuthenticationInterceptor.Factory);
    });
    homeModule.run(['HomeModule.Services.AuthService', function (authService) {
            authService.GetAuthData();
        }]);
})();
//# sourceMappingURL=HomeModuleApp.js.map