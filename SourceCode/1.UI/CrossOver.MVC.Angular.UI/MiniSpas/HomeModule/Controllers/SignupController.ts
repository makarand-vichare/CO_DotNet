
module HomeModule.Controllers
{
    export class SignupController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector", "UserDemandModule.Services.UserDemandService", "$timeout"];
        signUpVM: HomeModule.ViewModels.ISignUpVM;

        constructor( _injectorService: ng.auto.IInjectorService,
                     private userDemandService: UserDemandModule.Interfaces.IUserDemandService,
                     private timeOutService: ng.ITimeoutService)
        { 
            super( _injectorService );
            this.Initialize();
        }

        SignUp = () =>
        {
            var self = this;
            self.StartProcess();

            self.userDemandService.SignUp( this.signUpVM )
                .then( function ( response: any ) {
                    self.ProcessInfo.Message = response.data.message;
                    self.ProcessInfo.IsSucceed = true;
                    self.StartTimer();
                })
                .catch( function ( response: any )
                {
                    var errors: Array<string>;
                    for ( var key in response.data.modelState )
                    {
                        for ( var i = 0; i < response.data.modelState[key].length; i++ )
                        {
                            errors.push( response.data.modelState[key][i] );
                        }
                    }
                    self.ProcessInfo.Message = "Failed to register user due to:" + errors.join( ' ' );
                })
                .finally( function ()
                {
                    self.ProcessInfo.Loading = false;
                });;
        }

        StartTimer = () =>
        {
            var self = this;
            var timer = self.timeOutService( function ()
                                            {
                self.timeOutService.cancel( timer );
                self.locationService.path( '/login' );
            }, 2000 ) as ng.IPromise<void>;
        }

        Initialize()
        {
            var self = this;
            self.signUpVM = {
                Password: "",
                Id: null,
                UserName: "",
            } as HomeModule.ViewModels.ISignUpVM;
        }
    }
    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).controller( "HomeModule.Controllers.SignupController", SignupController );
} 