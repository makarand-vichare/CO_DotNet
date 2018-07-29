using CrossOver.ViewModels.Core;
using MongoDB.Bson;
using System;

namespace CrossOver.ViewModels
{
    [Serializable]
    public class UserDemandDetailViewModel :BaseViewModel
    {
        public ObjectId UserId { get; set; }
        public ObjectId BookId { get; set; }
        public string BookTitle { get; set; }
        public string RequestStatus { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Remark { get; set; }
    }
}