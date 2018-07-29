/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
(function () {
    var searchBookModule = MiniSpas.ModuleInitiator.GetModule("SearchBookModule");
    searchBookModule.config(SearchBookModule.SearchBookModuleRoutes.configureRoutes);
    searchBookModule.config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push(Common.Interceptors.AuthenticationInterceptor.Factory);
    });
    searchBookModule.run(['HomeModule.Services.AuthService', function (authService) {
            authService.GetAuthData();
        }]);
})();
//# sourceMappingURL=SearchBookModuleApp.js.map