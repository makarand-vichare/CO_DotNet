module UserDemandModule.Interfaces
{
    export interface IUserDemandService
    {
        GetTestValuesList(): ng.IPromise<any>;
        GetUserDemands( userId: any): ng.IPromise<any>;
        SignUp( registration: HomeModule.ViewModels.ISignUpVM ): ng.IPromise<any>;
    }
}