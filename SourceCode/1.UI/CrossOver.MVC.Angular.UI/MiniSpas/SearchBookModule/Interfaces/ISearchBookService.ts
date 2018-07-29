module SearchBookModule.Interfaces
{
    export interface ISearchBookService
    {
        GetBooksTop10( userName: string ): ng.IPromise<any>;
        GetBooks( searchParam: SearchBookModule.ViewModels.ISearchBookParamVM ): ng.IPromise<any>;
        DemandBook( bookId: string, userName: string ): ng.IPromise<any>;
    }
}