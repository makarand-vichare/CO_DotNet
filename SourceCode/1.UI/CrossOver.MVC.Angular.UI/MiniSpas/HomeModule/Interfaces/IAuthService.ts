module HomeModule.Interfaces
{
    export interface IAuthService
    {
        Login( loginData: HomeModule.ViewModels.ILoginVM ) : ng.IPromise<any>;
        LogOut(): void;
        GetAuthData(): void;
        GetFreshToken() : ng.IPromise<any>;
        GetAntiForgeryToken(): ng.IPromise<any>;
        authVM: HomeModule.ViewModels.IAuthenticationVM;
    }
}