
module HomeModule.Controllers
{
    export class HomeController extends Common.Controllers.BaseController
    {
        static $inject = ["UserDemandModule.Services.UserDemandService", "$injector"];
        profiles: Array<UserDemandModule.ViewModels.IUserProfileVM>;
        constructor( private userDemandService: UserDemandModule.Interfaces.IUserDemandService, _injectorService: ng.auto.IInjectorService )
        {
            super( _injectorService);
        }

        GetProfiles = () =>
        {
            var self = this;
            self.StartProcess();

            self.userDemandService.GetTestValuesList()
                .then(function ( response: any )
                {
                    self.profiles = response.data.result;
                    self.ProcessInfo.Message = response.data.message;
                })
                .catch( function ( response: any )
                {
                    self.ProcessInfo.Message = response.data;
                })
                .finally( function ()
                {
                    self.ProcessInfo.Loading = false;
                });
        }
    }
    MiniSpas.ModuleInitiator.GetModule("HomeModule").controller( "HomeModule.Controllers.HomeController", HomeController );
} 