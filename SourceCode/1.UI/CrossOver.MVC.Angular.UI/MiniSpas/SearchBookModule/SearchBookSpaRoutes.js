var SearchBookModule;
(function (SearchBookModule) {
    var SearchBookSpaRoutes = (function () {
        function SearchBookSpaRoutes() {
        }
        SearchBookSpaRoutes.configureRoutes = function ($routeProvider) {
            $routeProvider
                .when("/", {
                controller: "SearchBookModule.Controllers.SearchBookController",
                templateUrl: "/MiniSpas/SearchBookModule/Views/search.html",
                controllerAs: "searchBookCtrl"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        };
        return SearchBookSpaRoutes;
    }());
    SearchBookSpaRoutes.$inject = ["$routeProvider"];
    SearchBookModule.SearchBookSpaRoutes = SearchBookSpaRoutes;
})(SearchBookModule || (SearchBookModule = {}));
//# sourceMappingURL=SearchBookSpaRoutes.js.map