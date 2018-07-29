
module UserDemandModule.Services
{
    export class UserDemandService implements UserDemandModule.Interfaces.IUserDemandService
    {
        static $inject = ["$http","$location"];
        constructor( private httpService: ng.IHttpService, private locationService: ng.ILocationService)
        {
        }

        GetTestValuesList(): ng.IPromise<any> 
        {
            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/values' );
        }

        GetUserDemands( userName:string): ng.IPromise<any> 
        {
            var config = {
                params: { userName: userName },
                headers: { 'Accept': 'application/json' }
            } as ng.IRequestShortcutConfig;

            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/UserDemand/GetUserDemands', config);
        }

        SignUp( registration: HomeModule.ViewModels.ISignUpVM ): ng.IPromise<any> 
        {
            var self = this;
            return self.httpService.post( Common.AppConstants.BaseWebApiUrl + '/api/Account/Register', registration )
                .then( function ( response: any )
                {
                    return response;

                }).catch( function ( response: any )
                {
                    return response;
                });
        }

        static GetInstance = () =>
        {
            var instance = ( $http: ng.IHttpService, locationService: ng.ILocationService ) => new UserDemandService( $http, locationService );
            return instance;
        }
   }

    MiniSpas.ModuleInitiator.GetModule( "UserDemandModule" ).service( "UserDemandModule.Services.UserDemandService", UserDemandService);
} 