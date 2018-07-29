module UserDemandModule
{
    export class UserDemandModuleRoutes
    {
        static $inject = ["$routeProvider"];
        static configureRoutes( $routeProvider: ng.route.IRouteProvider )
        {
            $routeProvider
                .when( "/",
                            {
                                controller: "UserDemandModule.Controllers.UserDemandController",
                                templateUrl: "/MiniSpas/UserDemandModule/Views/userDemand.html",
                                controllerAs: "userDemandCtrl"
                            }
                );
            $routeProvider.otherwise( { redirectTo: "/" });
        }
    }
}