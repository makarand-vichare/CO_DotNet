using CrossOver.ViewModels.Core;
using System;

namespace CrossOver.ViewModels
{
    [Serializable]
    public class BookViewModel :BaseViewModel
    {
        public string Title { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public string Authors { get; set; }

        public bool IsRequested { get; set; }

    }
}
