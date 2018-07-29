module SearchBookModule.ViewModels
{
    export class IBookListVM extends Common.ViewModels.IBaseVM
    {
        Id: any;
        Title: string;
        BookPhoto: string;
        Publisher: string;
        Description: string;
        Author: string;
    }
}