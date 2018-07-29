
module UserDemandModule.Controllers
{
    export class UserDemandController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector", "UserDemandModule.Services.UserDemandService", "HomeModule.Services.AuthService"];

        constructor( _injectorService: ng.auto.IInjectorService, private userDemandService: UserDemandModule.Interfaces.IUserDemandService, private authService: HomeModule.Interfaces.IAuthService )
        {
            super( _injectorService );
            this.Initialize();
        }

        demandList: Array<UserDemandModule.ViewModels.IUserDemandVM>;
        bookImagePath: string;

        Initialize()
        {
            var self = this;
            self.bookImagePath = './Images';
            self.authService.GetAuthData();
            self.GetUserDemands();
        }

        SetBookPhoto()
        {
            var self = this;
            var photoIndex = 1;
            for ( var i = 0; i < self.demandList.length; i++ )
            {
                if ( photoIndex == 3 )
                {
                    photoIndex = 1;
                }
                else
                {
                    photoIndex++;
                }
                self.demandList[i].BookPhoto = 'Book' + photoIndex + '.jpg';
            }
        }

        GetUserDemands = () =>
        {
            var self = this;
            self.StartProcess();
            self.userDemandService.GetUserDemands( self.authService.authVM.UserName)
                .then( function ( response: any )
                {
                    self.demandList = response.data.viewModels;
                    if ( self.demandList.length > 0 )
                    {
                        self.SetBookPhoto();
                    }
                    self.ProcessInfo.Message = response.data.message;
                    self.ProcessInfo.IsSucceed = true;
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
    MiniSpas.ModuleInitiator.GetModule( "UserDemandModule" ).controller( "UserDemandModule.Controllers.UserDemandController", UserDemandController );
} 