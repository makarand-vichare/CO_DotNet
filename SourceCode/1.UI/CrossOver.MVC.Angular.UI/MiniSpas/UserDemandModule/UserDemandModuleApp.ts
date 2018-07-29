/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

( (): void =>
{
    var useDemandModule = MiniSpas.ModuleInitiator.GetModule( "UserDemandModule" );
    useDemandModule.config( UserDemandModule.UserDemandModuleRoutes.configureRoutes );

    useDemandModule.config( function ( $httpProvider: ng.IHttpProvider )
    {
         $httpProvider.defaults.withCredentials = true;
         $httpProvider.interceptors.push( Common.Interceptors.AuthenticationInterceptor.Factory );
    });

    useDemandModule.run( ['HomeModule.Services.AuthService', function ( authService: HomeModule.Services.AuthService )
    {
        authService.GetAuthData();
    }] );
})();