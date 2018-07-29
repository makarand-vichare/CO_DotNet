/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

( (): void =>
{
    var searchBookModule = MiniSpas.ModuleInitiator.GetModule( "SearchBookModule" );
    searchBookModule.config( SearchBookModule.SearchBookModuleRoutes.configureRoutes );

    searchBookModule.config(( $httpProvider: ng.IHttpProvider ) =>
    {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push( Common.Interceptors.AuthenticationInterceptor.Factory );
    });

    searchBookModule.run( ['HomeModule.Services.AuthService', function ( authService: HomeModule.Services.AuthService )
    {
        authService.GetAuthData();
    }]);
})() 