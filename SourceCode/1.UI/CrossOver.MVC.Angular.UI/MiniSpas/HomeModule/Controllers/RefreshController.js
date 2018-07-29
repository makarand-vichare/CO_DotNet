var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var HomeModule;
(function (HomeModule) {
    var Controllers;
    (function (Controllers) {
        var RefreshController = (function (_super) {
            __extends(RefreshController, _super);
            function RefreshController(_authService, _injectorService) {
                var _this = _super.call(this, _injectorService) || this;
                _this.authService = _authService;
                _this.Initialize();
                return _this;
            }
            RefreshController.prototype.RefreshToken = function () {
                var self = this;
                self.authService.GetFreshToken().then(function (response) {
                    self.refreshTokenVM.TokenRefreshed = true;
                    self.refreshTokenVM.TokenResponse = response.data;
                }).catch(function (response) {
                    self.locationService.path('/login');
                });
            };
            ;
            RefreshController.prototype.Initialize = function () {
                var self = this;
                self.refreshTokenVM = {
                    TokenRefreshed: false,
                    TokenResponse: undefined,
                    Authentication: self.authService.authVM
                };
            };
            return RefreshController;
        }(Common.Controllers.BaseController));
        RefreshController.$inject = ["HomeModule.Services.AuthService", "$injector"];
        Controllers.RefreshController = RefreshController;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").controller("HomeModule.Controllers.RefreshController", RefreshController);
    })(Controllers = HomeModule.Controllers || (HomeModule.Controllers = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=RefreshController.js.map