var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var SearchBookModule;
(function (SearchBookModule) {
    var Controllers;
    (function (Controllers) {
        var SearchBookController = (function (_super) {
            __extends(SearchBookController, _super);
            function SearchBookController(_injectorService, searchBookService, authService) {
                var _this = _super.call(this, _injectorService) || this;
                _this.searchBookService = searchBookService;
                _this.authService = authService;
                _this.GetTopBooks = function () {
                    var self = _this;
                    self.StartProcess();
                    self.searchBookService.GetBooksTop10(self.authService.authVM.UserName)
                        .then(function (response) {
                        self.booksList = response.data.viewModels;
                        if (self.booksList.length > 0) {
                            self.SetBookPhoto();
                        }
                        self.ProcessInfo.IsSucceed = true;
                        self.ProcessInfo.Message = response.data.message;
                    })
                        .catch(function (response) {
                        self.ProcessInfo.Message = response.data.message;
                    })
                        .finally(function () {
                        self.ProcessInfo.Loading = false;
                    });
                };
                _this.GetBooks = function () {
                    var self = _this;
                    self.StartProcess();
                    self.searchBookService.GetBooks(self.searchBookParamVM)
                        .then(function (response) {
                        self.booksList = response.data.viewModels;
                        if (self.booksList.length > 0) {
                            self.SetBookPhoto();
                        }
                        self.ProcessInfo.Message = response.data.message;
                        self.ProcessInfo.IsSucceed = true;
                    })
                        .catch(function (response) {
                        self.ProcessInfo.Message = response.data.message;
                    })
                        .finally(function () {
                        self.ProcessInfo.Loading = false;
                    });
                };
                _this.DemandBook = function (bookId) {
                    var self = _this;
                    self.StartProcess();
                    self.searchBookService.DemandBook(bookId, self.authService.authVM.UserName)
                        .then(function (response) {
                        self.ProcessInfo.Message = response.data.message;
                        self.ProcessInfo.IsSucceed = true;
                    })
                        .catch(function (response) {
                        self.ProcessInfo.Message = response.data.message;
                    })
                        .finally(function () {
                        self.ProcessInfo.Loading = false;
                    });
                };
                _this.Initialize();
                return _this;
            }
            SearchBookController.prototype.Initialize = function () {
                var self = this;
                self.bookImagePath = './Images';
                self.GetTopBooks();
                self.authService.GetAuthData();
                self.authenticationVM = self.authService.authVM;
                self.searchBookParamVM = {
                    Title: "",
                    Author: "",
                    UserName: self.authService.authVM.UserName
                };
            };
            SearchBookController.prototype.SetBookPhoto = function () {
                var self = this;
                var photoIndex = 1;
                for (var i = 0; i < self.booksList.length; i++) {
                    if (photoIndex == 3) {
                        photoIndex = 1;
                    }
                    else {
                        photoIndex++;
                    }
                    self.booksList[i].BookPhoto = 'Book' + photoIndex + '.jpg';
                }
            };
            return SearchBookController;
        }(Common.Controllers.BaseController));
        SearchBookController.$inject = ["$injector", "SearchBookModule.Services.SearchBookService", "HomeModule.Services.AuthService"];
        Controllers.SearchBookController = SearchBookController;
        MiniSpas.ModuleInitiator.GetModule("SearchBookModule").controller("SearchBookModule.Controllers.SearchBookController", SearchBookController);
    })(Controllers = SearchBookModule.Controllers || (SearchBookModule.Controllers = {}));
})(SearchBookModule || (SearchBookModule = {}));
//# sourceMappingURL=SearchBookController.js.map