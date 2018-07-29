using System.Web.Optimization;

namespace CrossOver.MVC.Angular.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            "~/Scripts/angular.js",
            "~/Scripts/angular-cookies.js",
            "~/Scripts/angular-route.js",
            "~/Scripts/angular-local-storage.js",
            "~/Scripts/loading-bar.js",
            "~/Scripts/angular-messages.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/site.css",
            "~/Content/loading-bar.css"
            ));
      
            #region "common module Section"

            bundles.Add(new ScriptBundle("~/bundles/common-modules").Include(
                "~/MiniSpas/ModuleInitiator.js",
                "~/MiniSpas/Common/AppConstants.js",
                "~/MiniSpas/Common/IBaseVM.js",
                "~/MiniSpas/Common/IDictionary.js",
                "~/MiniSpas/Common/IMessageVM.js",
                "~/MiniSpas/Common/BaseController.js",
                "~/MiniSpas/Common/AuthenticationInterceptor.js"
            ));
            #endregion

            #region "Home module Section"

            bundles.Add(new ScriptBundle("~/bundles/home-modules").Include(
                "~/MiniSpas/HomeModule/HomeModuleRoutes.js",
                "~/MiniSpas/HomeModule/HomeModuleApp.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/home-services").Include(
                "~/MiniSpas/HomeModule/Services/AuthService.js",
                "~/MiniSpas/HomeModule/Services/AuthInterceptorService.js",
                "~/MiniSpas/HomeModule/Services/TokensManagerService.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/home-directives").Include(
                "~/MiniSpas/Common/Directives/AntiForgeryTokenDirective.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/home-controllers").Include(
                "~/MiniSpas/HomeModule/Controllers/HomeController.js",
                "~/MiniSpas/HomeModule/Controllers/LoginController.js",
                "~/MiniSpas/HomeModule/Controllers/RefreshController.js",
                "~/MiniSpas/HomeModule/Controllers/SignupController.js",
                "~/MiniSpas/HomeModule/Controllers/TokensManagerController.js"
            ));

            #endregion

            #region "User demand module Section"

            bundles.Add(new ScriptBundle("~/bundles/userdemand-modules").Include(
            "~/MiniSpas/UserDemandModule/UserDemandModuleRoutes.js",
            "~/MiniSpas/UserDemandModule/UserDemandModuleApp.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/userdemand-services").Include(
            "~/MiniSpas/UserDemandModule/Services/UserDemandService.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/userdemand-viewmodels").Include(
            "~/MiniSpas/UserDemandModule/ViewModels/IUserProfileVM.js",
            "~/MiniSpas/UserDemandModule/ViewModels/IUserDemandVM.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/userdemand-controllers").Include(
                "~/MiniSpas/UserDemandModule/Controllers/UserDemandController.js"
            ));

            #endregion

            #region "Search book module Section"

            bundles.Add(new ScriptBundle("~/bundles/searchbook-modules").Include(
            "~/MiniSpas/SearchBookModule/SearchBookModuleRoutes.js",
            "~/MiniSpas/SearchBookModule/SearchBookModuleApp.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/searchbook-services").Include(
            "~/MiniSpas/SearchBookModule/Services/SearchBookService.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/searchbook-viewmodels").Include(
            "~/MiniSpas/SearchBookModule/ViewModels/IBookListVM.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/searchbook-controllers").Include(
                "~/MiniSpas/SearchBookModule/Controllers/SearchBookController.js"
            ));

            #endregion

        }
    }
}
