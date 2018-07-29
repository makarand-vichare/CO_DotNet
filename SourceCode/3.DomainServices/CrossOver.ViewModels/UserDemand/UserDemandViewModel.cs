using CrossOver.ViewModels.Core;
using MongoDB.Bson;
using System;

namespace CrossOver.ViewModels
{
    public class UserDemandViewModel : BaseViewModel
    {
        public ObjectId UserId { get; set; }
        public ObjectId BookId { get; set; }
        public bool RequestStatus { get; set; }
        public string Remark { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}