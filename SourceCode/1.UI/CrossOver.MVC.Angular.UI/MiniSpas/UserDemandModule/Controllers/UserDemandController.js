var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var UserDemandModule;
(function (UserDemandModule) {
    var Controllers;
    (function (Controllers) {
        var UserDemandController = (function (_super) {
            __extends(UserDemandController, _super);
            function UserDemandController(_injectorService, userDemandService, authService) {
                var _this = _super.call(this, _injectorService) || this;
                _this.userDemandService = userDemandService;
                _this.authService = authService;
                _this.GetUserDemands = function () {
                    var self = _this;
                    self.StartProcess();
                    self.userDemandService.GetUserDemands(self.authService.authVM.UserName)
                        .then(function (response) {
                        self.demandList = response.data.viewModels;
                        if (self.demandList.length > 0) {
                            self.SetBookPhoto();
                        }
                        self.ProcessInfo.Message = response.data.message;
                        self.ProcessInfo.IsSucceed = true;
                    })
                        .catch(function (response) {
                        self.ProcessInfo.Message = response.data;
                    })
                        .finally(function () {
                        self.ProcessInfo.Loading = false;
                    });
                };
                _this.Initialize();
                return _this;
            }
            UserDemandController.prototype.Initialize = function () {
                var self = this;
                self.bookImagePath = './Images';
                self.authService.GetAuthData();
                self.GetUserDemands();
            };
            UserDemandController.prototype.SetBookPhoto = function () {
                var self = this;
                var photoIndex = 1;
                for (var i = 0; i < self.demandList.length; i++) {
                    if (photoIndex == 3) {
                        photoIndex = 1;
                    }
                    else {
                        photoIndex++;
                    }
                    self.demandList[i].BookPhoto = 'Book' + photoIndex + '.jpg';
                }
            };
            return UserDemandController;
        }(Common.Controllers.BaseController));
        UserDemandController.$inject = ["$injector", "UserDemandModule.Services.UserDemandService", "HomeModule.Services.AuthService"];
        Controllers.UserDemandController = UserDemandController;
        MiniSpas.ModuleInitiator.GetModule("UserDemandModule").controller("UserDemandModule.Controllers.UserDemandController", UserDemandController);
    })(Controllers = UserDemandModule.Controllers || (UserDemandModule.Controllers = {}));
})(UserDemandModule || (UserDemandModule = {}));
//# sourceMappingURL=UserDemandController.js.map