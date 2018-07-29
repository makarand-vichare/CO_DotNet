var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var HomeModule;
(function (HomeModule) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function (_super) {
            __extends(HomeController, _super);
            function HomeController(userDemandService, _injectorService) {
                var _this = _super.call(this, _injectorService) || this;
                _this.userDemandService = userDemandService;
                _this.GetProfiles = function () {
                    var self = _this;
                    self.StartProcess();
                    self.userDemandService.GetTestValuesList()
                        .then(function (response) {
                        self.profiles = response.data.result;
                        self.ProcessInfo.Message = response.data.message;
                    })
                        .catch(function (response) {
                        self.ProcessInfo.Message = response.data;
                    })
                        .finally(function () {
                        self.ProcessInfo.Loading = false;
                    });
                };
                return _this;
            }
            return HomeController;
        }(Common.Controllers.BaseController));
        HomeController.$inject = ["UserDemandModule.Services.UserDemandService", "$injector"];
        Controllers.HomeController = HomeController;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").controller("HomeModule.Controllers.HomeController", HomeController);
    })(Controllers = HomeModule.Controllers || (HomeModule.Controllers = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=HomeController.js.map