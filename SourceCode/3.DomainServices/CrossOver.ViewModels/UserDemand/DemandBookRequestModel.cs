using System;

namespace CrossOver.ViewModels
{
    [Serializable]
    public class DemandBookRequestModel 
    {
        public string UserName { get; set; }
        public string BookId { get; set; }
    }
}