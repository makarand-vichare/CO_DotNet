module HomeModule.ViewModels
{
    export class IAuthorizationVM extends Common.ViewModels.IBaseVM
    {
        Id: any;
        Token: string;
        UserName: string;
        RefreshToken: string;
        UseRefreshTokens: boolean;
    }
}