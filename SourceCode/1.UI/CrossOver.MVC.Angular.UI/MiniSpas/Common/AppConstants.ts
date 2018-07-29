
module Common
{
    export class AppConstants
    {
        static get BaseWebApiUrl(): string { return "http://localhost:8888" };
    }


    MiniSpas.ModuleInitiator.GetModule( "Common" ).constant( "Common.AppConstants", AppConstants);
}