module SearchBookModule
{
    export class SearchBookModuleRoutes
    {
        static $inject = ["$routeProvider"];
        static configureRoutes( $routeProvider: ng.route.IRouteProvider )
        {
            $routeProvider
                    .when( "/",
                            {
                                controller: "SearchBookModule.Controllers.SearchBookController",
                                templateUrl: "/MiniSpas/SearchBookModule/Views/searchBook.html",
                                controllerAs: "searchBookCtrl"
                            }
                   );
            $routeProvider.otherwise( { redirectTo: "/" });
        }
    }
}