
module SearchBookModule.Services
{
    export class SearchBookService implements SearchBookModule.Interfaces.ISearchBookService
    {
        static $inject = ["$http"];
        constructor( private httpService: ng.IHttpService)
        {
        }

        GetBooksTop10(userName:string): ng.IPromise<any> 
        {
            var config = {
                params: {  userName: userName },
                headers: { 'Accept': 'application/json' }
            } as ng.IRequestShortcutConfig;

            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/Books/GetTop10', config );
        }

        DemandBook( bookId: string, userName: string ): ng.IPromise<any> 
        {
            var self = this;
            var data = { bookId: bookId, userName: userName};

            return self.httpService.post( Common.AppConstants.BaseWebApiUrl + '/api/Books/DemandBook', data );
        }

        GetBooks ( searchParam: SearchBookModule.ViewModels.ISearchBookParamVM): ng.IPromise<any> 
        {
            var config = {
                params:  searchParam ,
                headers: { 'Accept': 'application/json' }
            } as ng.IRequestShortcutConfig;

            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/Books/GetBooks', config );
        }


        static GetInstance = () =>
        {
            var instance = ( $http: ng.IHttpService ) => new SearchBookService( $http );
            return instance;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "SearchBookModule" ).service( "SearchBookModule.Services.SearchBookService", SearchBookService );
} 