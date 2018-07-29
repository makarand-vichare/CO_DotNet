
module HomeModule.Controllers
{
    export class LoginController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector", "HomeModule.Services.AuthService"];

        constructor( _injectorService: ng.auto.IInjectorService , private authService: HomeModule.Interfaces.IAuthService)
        {
            super( _injectorService);
            this.Initialize();
        }

        loginVM: HomeModule.ViewModels.ILoginVM = {
            UserName: "",
            UseRefreshTokens: true,
            Password: ""
        };

        authenticationVM: HomeModule.ViewModels.IAuthenticationVM ;

        Login(loginData:HomeModule.ViewModels.ILoginVM)
        {
            var self = this;
            self.authService.Login(loginData).then( function ( response: any )
            {
                if ( response.data != null )
                {
                    self.windowService.location.href = '/UserDemand';
                }

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

        LogOut()
        {
            var self = this;
            self.authService.LogOut();
            self.locationService.path( '/' );
        }

        Initialize()
        {
            var self = this;
            self.authenticationVM = self.authService.authVM;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).controller( "HomeModule.Controllers.LoginController", LoginController );
} 