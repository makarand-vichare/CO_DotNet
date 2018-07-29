var HomeModule;
(function (HomeModule) {
    var Services;
    (function (Services) {
        var AuthService = (function () {
            function AuthService($http, _localStorageService) {
                var _this = this;
                this.useRefreshToken = false;
                this.isAuth = false;
                this.authVM = {
                    IsAuth: this.isAuth,
                    UseRefreshTokens: this.useRefreshToken,
                    UserName: "",
                    Id: ""
                };
                this.Login = function (loginData) {
                    var self = _this;
                    var data = "grant_type=password&username=" + loginData.UserName + "&password=" + loginData.Password;
                    return self.httpService.post(Common.AppConstants.BaseWebApiUrl + '/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                        .then(function (response) {
                        if (loginData.UseRefreshTokens) {
                            self.localStorageService.set('authorizationData', {
                                Token: response.data.access_token,
                                UserName: loginData.UserName,
                                RefreshToken: response.data.refresh_token,
                                UseRefreshTokens: !self.useRefreshToken
                            });
                        }
                        else {
                            self.localStorageService.set('authorizationData', {
                                Token: response.data.access_token,
                                UserName: loginData.UserName,
                                RefreshToken: "",
                                UseRefreshTokens: self.useRefreshToken
                            });
                        }
                        self.authVM.IsAuth = !self.isAuth;
                        self.authVM.UserName = loginData.UserName;
                        self.authVM.UseRefreshTokens = loginData.UseRefreshTokens;
                        return response;
                    }).catch(function (response) {
                        self.LogOut();
                        return response;
                    });
                };
                this.LogOut = function () {
                    var self = _this;
                    self.localStorageService.remove('authorizationData');
                    self.authVM.IsAuth = self.isAuth;
                    self.authVM.UserName = "";
                    self.authVM.UseRefreshTokens = !self.useRefreshToken;
                };
                this.GetAuthData = function () {
                    var self = _this;
                    var authData = self.localStorageService.get('authorizationData');
                    if (authData != null) {
                        self.authVM.IsAuth = !self.isAuth;
                        self.authVM.UserName = authData.UserName;
                        self.authVM.UseRefreshTokens = authData.UseRefreshTokens;
                    }
                };
                this.GetFreshToken = function () {
                    var self = _this;
                    var authData = self.localStorageService.get('authorizationData');
                    if (authData) {
                        if (authData.UseRefreshTokens) {
                            var data = "grant_type=refresh_token&refresh_token=" + authData.RefreshToken;
                            self.localStorageService.remove('authorizationData');
                            return self.httpService.post(Common.AppConstants.BaseWebApiUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                                .then(function (response) {
                                self.localStorageService.set('authorizationData', {
                                    Token: response.data.access_token,
                                    UserName: response.data.userName,
                                    RefreshToken: response.data.refresh_token,
                                    UseRefreshTokens: self.useRefreshToken
                                });
                                return response;
                            })
                                .catch(function (response) {
                                self.LogOut();
                                return response;
                            });
                        }
                    }
                };
                this.GetAntiForgeryToken = function () {
                    var self = _this;
                    return self.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/RefreshTokens/antiforgerytoken')
                        .then(function (response) {
                        return response;
                    })
                        .catch(function (response) {
                        return response;
                    });
                };
                this.httpService = $http;
                this.localStorageService = _localStorageService;
            }
            AuthService.getInstance = function () {
                var instance = function ($http, _localStorageService) { return new AuthService($http, _localStorageService); };
                return instance;
            };
            return AuthService;
        }());
        AuthService.$inject = ["$http", "localStorageService"];
        Services.AuthService = AuthService;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").service("HomeModule.Services.AuthService", AuthService);
    })(Services = HomeModule.Services || (HomeModule.Services = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=AuthService.js.map