using System;

namespace CrossOver.Utility.ParamViewModels
{
    [Serializable]
    public class SearchBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string UserName { get; set; }
    }
}
