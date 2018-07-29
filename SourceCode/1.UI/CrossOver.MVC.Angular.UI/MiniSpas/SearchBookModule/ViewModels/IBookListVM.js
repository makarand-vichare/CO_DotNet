var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var SearchBookModule;
(function (SearchBookModule) {
    var ViewModels;
    (function (ViewModels) {
        var IBookListVM = (function (_super) {
            __extends(IBookListVM, _super);
            function IBookListVM() {
                return _super.apply(this, arguments) || this;
            }
            return IBookListVM;
        }(Common.ViewModels.IBaseVM));
        ViewModels.IBookListVM = IBookListVM;
    })(ViewModels = SearchBookModule.ViewModels || (SearchBookModule.ViewModels = {}));
})(SearchBookModule || (SearchBookModule = {}));
//# sourceMappingURL=IBookListVM.js.map