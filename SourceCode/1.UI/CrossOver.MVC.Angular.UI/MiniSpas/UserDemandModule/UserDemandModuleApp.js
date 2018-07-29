/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
(function () {
    var useDemandModule = MiniSpas.ModuleInitiator.GetModule("UserDemandModule");
    useDemandModule.config(UserDemandModule.UserDemandModuleRoutes.configureRoutes);
    useDemandModule.config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push(Common.Interceptors.AuthenticationInterceptor.Factory);
    });
    useDemandModule.run(['HomeModule.Services.AuthService', function (authService) {
            authService.GetAuthData();
        }]);
})();
//# sourceMappingURL=UserDemandModuleApp.js.map