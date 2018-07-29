using CrossOver.EntityModels.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrossOver.EntityModels.SearchBook
{
    [Serializable]
    public class BookEntityModel : BaseEntityModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IList<string> Authors { get; set; }
    }
}
