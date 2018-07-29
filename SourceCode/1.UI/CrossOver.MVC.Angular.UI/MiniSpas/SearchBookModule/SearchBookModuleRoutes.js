var SearchBookModule;
(function (SearchBookModule) {
    var SearchBookModuleRoutes = (function () {
        function SearchBookModuleRoutes() {
        }
        SearchBookModuleRoutes.configureRoutes = function ($routeProvider) {
            $routeProvider
                .when("/", {
                controller: "SearchBookModule.Controllers.SearchBookController",
                templateUrl: "/MiniSpas/SearchBookModule/Views/searchBook.html",
                controllerAs: "searchBookCtrl"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        };
        return SearchBookModuleRoutes;
    }());
    SearchBookModuleRoutes.$inject = ["$routeProvider"];
    SearchBookModule.SearchBookModuleRoutes = SearchBookModuleRoutes;
})(SearchBookModule || (SearchBookModule = {}));
//# sourceMappingURL=SearchBookModuleRoutes.js.map