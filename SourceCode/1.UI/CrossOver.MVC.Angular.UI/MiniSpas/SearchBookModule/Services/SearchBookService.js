var SearchBookModule;
(function (SearchBookModule) {
    var Services;
    (function (Services) {
        var SearchBookService = (function () {
            function SearchBookService(httpService) {
                this.httpService = httpService;
            }
            SearchBookService.prototype.GetBooksTop10 = function (userName) {
                var config = {
                    params: { userName: userName },
                    headers: { 'Accept': 'application/json' }
                };
                return this.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/Books/GetTop10', config);
            };
            SearchBookService.prototype.DemandBook = function (bookId, userName) {
                var self = this;
                var data = { bookId: bookId, userName: userName };
                return self.httpService.post(Common.AppConstants.BaseWebApiUrl + '/api/Books/DemandBook', data);
            };
            SearchBookService.prototype.GetBooks = function (searchParam) {
                var config = {
                    params: searchParam,
                    headers: { 'Accept': 'application/json' }
                };
                return this.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/Books/GetBooks', config);
            };
            return SearchBookService;
        }());
        SearchBookService.$inject = ["$http"];
        SearchBookService.GetInstance = function () {
            var instance = function ($http) { return new SearchBookService($http); };
            return instance;
        };
        Services.SearchBookService = SearchBookService;
        MiniSpas.ModuleInitiator.GetModule("SearchBookModule").service("SearchBookModule.Services.SearchBookService", SearchBookService);
    })(Services = SearchBookModule.Services || (SearchBookModule.Services = {}));
})(SearchBookModule || (SearchBookModule = {}));
//# sourceMappingURL=SearchBookService.js.map