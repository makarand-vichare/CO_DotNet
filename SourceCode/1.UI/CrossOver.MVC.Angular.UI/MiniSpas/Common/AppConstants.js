var Common;
(function (Common) {
    var AppConstants = (function () {
        function AppConstants() {
        }
        Object.defineProperty(AppConstants, "BaseWebApiUrl", {
            get: function () { return "http://localhost:8888"; },
            enumerable: true,
            configurable: true
        });
        ;
        return AppConstants;
    }());
    Common.AppConstants = AppConstants;
    MiniSpas.ModuleInitiator.GetModule("Common").constant("Common.AppConstants", AppConstants);
})(Common || (Common = {}));
//# sourceMappingURL=AppConstants.js.map