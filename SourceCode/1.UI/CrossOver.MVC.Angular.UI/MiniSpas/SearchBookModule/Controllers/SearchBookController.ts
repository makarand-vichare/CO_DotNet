
module SearchBookModule.Controllers
{
    export class SearchBookController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector", "SearchBookModule.Services.SearchBookService", "HomeModule.Services.AuthService"];
        profiles: Array<SearchBookModule.ViewModels.IBookListVM>;
        constructor( _injectorService: ng.auto.IInjectorService, private searchBookService: SearchBookModule.Interfaces.ISearchBookService, private authService: HomeModule.Interfaces.IAuthService )
        {
            super( _injectorService );
            this.Initialize();
        }

        booksList: Array<SearchBookModule.ViewModels.IBookListVM>;
        searchBookParamVM: SearchBookModule.ViewModels.ISearchBookParamVM;
        bookImagePath: string;
        authenticationVM: HomeModule.ViewModels.IAuthenticationVM;

        Initialize()
        {
            var self = this;
            self.bookImagePath = './Images';
            self.GetTopBooks();
            self.authService.GetAuthData();
            self.authenticationVM = self.authService.authVM;
            self.searchBookParamVM = {
                Title: "",
                Author: "",
                UserName: self.authService.authVM.UserName
            } as SearchBookModule.ViewModels.ISearchBookParamVM;
        }

        GetTopBooks = () =>
        {
            var self = this;
            self.StartProcess();

            self.searchBookService.GetBooksTop10( self.authService.authVM.UserName)
                .then( function ( response: any )
                {
                    self.booksList = response.data.viewModels;
                    if ( self.booksList.length > 0 )
                    {
                        self.SetBookPhoto();
                    }
                    self.ProcessInfo.IsSucceed = true;
                    self.ProcessInfo.Message = response.data.message;
                })
                .catch( function ( response: any )
                {
                    self.ProcessInfo.Message = response.data.message;
                })
                .finally( function ()
                {
                    self.ProcessInfo.Loading = false;
                });
        }

        SetBookPhoto()
        {
            var self = this;
            var photoIndex = 1;
            for ( var i = 0; i < self.booksList.length; i++ )
            {
                if ( photoIndex == 3 )
                {
                    photoIndex = 1;
                }
                else
                {
                    photoIndex++;
                }
                self.booksList[i].BookPhoto = 'Book' + photoIndex +'.jpg';
            }
        }

        GetBooks = () =>
        {
            var self = this;
            self.StartProcess();

            self.searchBookService.GetBooks(self.searchBookParamVM)
                .then( function ( response: any )
                {
                    self.booksList = response.data.viewModels;
                    if ( self.booksList.length > 0 )
                    {
                        self.SetBookPhoto();
                    }
                    self.ProcessInfo.Message = response.data.message;
                    self.ProcessInfo.IsSucceed = true;
                })
                .catch( function ( response: any )
                {
                    self.ProcessInfo.Message = response.data.message;
                })
                .finally( function ()
                {
                    self.ProcessInfo.Loading = false;
                });
        }

        DemandBook = (bookId:string) =>
        {
            var self = this;
            self.StartProcess();

            self.searchBookService.DemandBook( bookId, self.authService.authVM.UserName)
                .then( function ( response: any )
                {
                    self.ProcessInfo.Message = response.data.message;
                    self.ProcessInfo.IsSucceed = true;
                })
                .catch( function ( response: any )
                {
                    self.ProcessInfo.Message = response.data.message;
                })
                .finally( function ()
                {
                    self.ProcessInfo.Loading = false;
                });
        }
    }
    MiniSpas.ModuleInitiator.GetModule( "SearchBookModule" ).controller( "SearchBookModule.Controllers.SearchBookController", SearchBookController );
} 