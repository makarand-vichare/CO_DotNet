module UserDemandModule.ViewModels
{
    export class IUserDemandVM extends Common.ViewModels.IBaseVM
    {
        Id: any;
        UserId: any;
        BookTitle: string;
        DemandRequestDate: string;
        IssuedDate: string;
        ReturnedDate: string;
        DemandStatus: boolean;
        BookPhoto: string;
    }
}