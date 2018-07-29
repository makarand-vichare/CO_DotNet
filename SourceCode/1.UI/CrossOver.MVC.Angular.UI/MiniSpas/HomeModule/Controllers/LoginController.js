var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var HomeModule;
(function (HomeModule) {
    var Controllers;
    (function (Controllers) {
        var LoginController = (function (_super) {
            __extends(LoginController, _super);
            function LoginController(_injectorService, authService) {
                var _this = _super.call(this, _injectorService) || this;
                _this.authService = authService;
                _this.loginVM = {
                    UserName: "",
                    UseRefreshTokens: true,
                    Password: ""
                };
                _this.Initialize();
                return _this;
            }
            LoginController.prototype.Login = function (loginData) {
                var self = this;
                self.authService.Login(loginData).then(function (response) {
                    if (response.data != null) {
                        self.windowService.location.href = '/UserDemand';
                    }
                })
                    .catch(function (response) {
                    self.ProcessInfo.Message = response.data;
                })
                    .finally(function () {
                    self.ProcessInfo.Loading = false;
                });
            };
            LoginController.prototype.LogOut = function () {
                var self = this;
                self.authService.LogOut();
                self.locationService.path('/');
            };
            LoginController.prototype.Initialize = function () {
                var self = this;
                self.authenticationVM = self.authService.authVM;
            };
            return LoginController;
        }(Common.Controllers.BaseController));
        LoginController.$inject = ["$injector", "HomeModule.Services.AuthService"];
        Controllers.LoginController = LoginController;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").controller("HomeModule.Controllers.LoginController", LoginController);
    })(Controllers = HomeModule.Controllers || (HomeModule.Controllers = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=LoginController.js.map