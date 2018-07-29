
module HomeModule.Services
{
    export class AuthService implements HomeModule.Interfaces.IAuthService
    {
        httpService: ng.IHttpService;
        localStorageService: ng.local.storage.ILocalStorageService;
        static $inject = ["$http", "localStorageService"];

        constructor( $http: ng.IHttpService, _localStorageService: ng.local.storage.ILocalStorageService )
        {
            this.httpService = $http;
            this.localStorageService = _localStorageService;
        }

        useRefreshToken: boolean = false;
        isAuth: boolean = false;

        authVM: HomeModule.ViewModels.IAuthenticationVM = {
            IsAuth: this.isAuth,
            UseRefreshTokens: this.useRefreshToken,
            UserName: "",
            Id :""
        };

        Login = (loginData: HomeModule.ViewModels.ILoginVM): ng.IPromise<any> =>
        {
            var self = this;

            var data = "grant_type=password&username=" + loginData.UserName + "&password=" + loginData.Password;

            return self.httpService.post( Common.AppConstants.BaseWebApiUrl + '/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then( function( response:any )
                {
                    if (loginData.UseRefreshTokens)
                    {
                        self.localStorageService.set( 'authorizationData',
                            {
                                Token: response.data.access_token,
                                UserName: loginData.UserName,
                                RefreshToken: response.data.refresh_token,
                                UseRefreshTokens: !self.useRefreshToken
                            } as HomeModule.ViewModels.IAuthorizationVM );
                    }
                    else
                    {
                        self.localStorageService.set( 'authorizationData',
                            {
                                Token: response.data.access_token,
                                UserName: loginData.UserName,
                                RefreshToken: "",
                                UseRefreshTokens: self.useRefreshToken
                            } as HomeModule.ViewModels.IAuthorizationVM );
                    }
                    self.authVM.IsAuth = !self.isAuth;
                    self.authVM.UserName = loginData.UserName;
                    self.authVM.UseRefreshTokens = loginData.UseRefreshTokens;
                    return response;

                }).catch( function ( response: any )
                {
                    self.LogOut();
                    return response;
                });
        }

        LogOut = () =>
        {
            var self = this;
            self.localStorageService.remove( 'authorizationData' );
            self.authVM.IsAuth = self.isAuth;
            self.authVM.UserName = "";
            self.authVM.UseRefreshTokens = !self.useRefreshToken;
        }

        GetAuthData = () =>
        {
            var self = this;

            var authData = self.localStorageService.get( 'authorizationData' ) as HomeModule.ViewModels.IAuthorizationVM;
            if ( authData != null )
            {
                self.authVM.IsAuth = !self.isAuth;
                self.authVM.UserName = authData.UserName;
                self.authVM.UseRefreshTokens = authData.UseRefreshTokens;
            }
        }

        GetFreshToken = (): ng.IPromise<any> =>
        {
            var self = this;

            var authData = self.localStorageService.get( 'authorizationData' ) as HomeModule.ViewModels.IAuthorizationVM;
            if ( authData )
            {
                if ( authData.UseRefreshTokens )
                {
                    var data = "grant_type=refresh_token&refresh_token=" + authData.RefreshToken;
                    self.localStorageService.remove( 'authorizationData' );

                    return self.httpService.post( Common.AppConstants.BaseWebApiUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                    .then( function ( response:any )
                    {
                        self.localStorageService.set( 'authorizationData',
                            {
                                Token: response.data.access_token,
                                UserName: response.data.userName,
                                RefreshToken: response.data.refresh_token,
                                UseRefreshTokens: self.useRefreshToken
                            } as HomeModule.ViewModels.IAuthorizationVM );
                        return response;
                    })
                    .catch( function ( response: any)
                    {
                        self.LogOut();
                        return response
                    });
                }
            }
       }

        GetAntiForgeryToken = (): ng.IPromise<any> =>
        {
            var self = this;

            return self.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/RefreshTokens/antiforgerytoken')
                .then( function ( response: any )
                {
                    return response;
                })
                .catch( function ( response: any )
                {
                    return response
                });
        }

        public static getInstance()
        {
            var instance = ( $http: ng.IHttpService, _localStorageService: ng.local.storage.ILocalStorageService ) => new AuthService( $http, _localStorageService);
            return instance;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).service( "HomeModule.Services.AuthService", AuthService );
} 