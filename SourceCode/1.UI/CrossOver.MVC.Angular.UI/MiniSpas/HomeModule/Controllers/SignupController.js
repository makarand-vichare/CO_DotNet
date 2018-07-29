var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var HomeModule;
(function (HomeModule) {
    var Controllers;
    (function (Controllers) {
        var SignupController = (function (_super) {
            __extends(SignupController, _super);
            function SignupController(_injectorService, userDemandService, timeOutService) {
                var _this = _super.call(this, _injectorService) || this;
                _this.userDemandService = userDemandService;
                _this.timeOutService = timeOutService;
                _this.SignUp = function () {
                    var self = _this;
                    self.StartProcess();
                    self.userDemandService.SignUp(_this.signUpVM)
                        .then(function (response) {
                        self.ProcessInfo.Message = response.data.message;
                        self.ProcessInfo.IsSucceed = true;
                        self.StartTimer();
                    })
                        .catch(function (response) {
                        var errors;
                        for (var key in response.data.modelState) {
                            for (var i = 0; i < response.data.modelState[key].length; i++) {
                                errors.push(response.data.modelState[key][i]);
                            }
                        }
                        self.ProcessInfo.Message = "Failed to register user due to:" + errors.join(' ');
                    })
                        .finally(function () {
                        self.ProcessInfo.Loading = false;
                    });
                    ;
                };
                _this.StartTimer = function () {
                    var self = _this;
                    var timer = self.timeOutService(function () {
                        self.timeOutService.cancel(timer);
                        self.locationService.path('/login');
                    }, 2000);
                };
                _this.Initialize();
                return _this;
            }
            SignupController.prototype.Initialize = function () {
                var self = this;
                self.signUpVM = {
                    Password: "",
                    Id: null,
                    UserName: "",
                };
            };
            return SignupController;
        }(Common.Controllers.BaseController));
        SignupController.$inject = ["$injector", "UserDemandModule.Services.UserDemandService", "$timeout"];
        Controllers.SignupController = SignupController;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").controller("HomeModule.Controllers.SignupController", SignupController);
    })(Controllers = HomeModule.Controllers || (HomeModule.Controllers = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=SignupController.js.map