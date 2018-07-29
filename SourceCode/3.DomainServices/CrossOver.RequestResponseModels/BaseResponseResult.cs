using System.Collections.Generic;

namespace CrossOver.ServiceResponse
{
    public class BaseResponseResult
    {
        public string Message { get; set; }
        public bool IsSucceed { get; set; }
        public Dictionary<string, string> OtherInfo { get; set; }

    }
}
