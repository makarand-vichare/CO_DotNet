var UserDemandModule;
(function (UserDemandModule) {
    var Services;
    (function (Services) {
        var UserDemandService = (function () {
            function UserDemandService(httpService, locationService) {
                this.httpService = httpService;
                this.locationService = locationService;
            }
            UserDemandService.prototype.GetTestValuesList = function () {
                return this.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/values');
            };
            UserDemandService.prototype.GetUserDemands = function (userName) {
                var config = {
                    params: { userName: userName },
                    headers: { 'Accept': 'application/json' }
                };
                return this.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/UserDemand/GetUserDemands', config);
            };
            UserDemandService.prototype.SignUp = function (registration) {
                var self = this;
                return self.httpService.post(Common.AppConstants.BaseWebApiUrl + '/api/Account/Register', registration)
                    .then(function (response) {
                    return response;
                }).catch(function (response) {
                    return response;
                });
            };
            return UserDemandService;
        }());
        UserDemandService.$inject = ["$http", "$location"];
        UserDemandService.GetInstance = function () {
            var instance = function ($http, locationService) { return new UserDemandService($http, locationService); };
            return instance;
        };
        Services.UserDemandService = UserDemandService;
        MiniSpas.ModuleInitiator.GetModule("UserDemandModule").service("UserDemandModule.Services.UserDemandService", UserDemandService);
    })(Services = UserDemandModule.Services || (UserDemandModule.Services = {}));
})(UserDemandModule || (UserDemandModule = {}));
//# sourceMappingURL=UserDemandService.js.map