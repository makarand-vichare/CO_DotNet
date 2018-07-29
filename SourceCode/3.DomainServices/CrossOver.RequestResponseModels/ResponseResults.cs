using CrossOver.ViewModels.Core;
using System.Collections.Generic;

namespace CrossOver.ServiceResponse
{
    public class ResponseResults<VM> : BaseResponseResult  where VM: BaseViewModel
    {
        public List<VM> ViewModels { get; set; } 
    }
}
