module HomeModule.ViewModels
{
    export class IAuthenticationVM extends Common.ViewModels.IBaseVM
    {
        Id: any;
        IsAuth: boolean;
        UserName: string;
        UseRefreshTokens: boolean;
    }
}