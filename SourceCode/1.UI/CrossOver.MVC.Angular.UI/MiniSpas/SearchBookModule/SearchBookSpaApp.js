/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
(function () {
    var searchBookModule = MiniSpas.ModuleInitiator.GetModule("SearchBookModule");
    searchBookModule.config(SearchBookModule.SearchProfileSpaRoutes.configureRoutes);
    searchBookModule.config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push(Common.Interceptors.AuthenticationInterceptor.Factory);
    });
    searchBookModule.run(['HomeSpa.Services.AuthService', function (authService) {
            authService.GetAuthData();
        }]);
})();
//# sourceMappingURL=SearchBookSpaApp.js.map