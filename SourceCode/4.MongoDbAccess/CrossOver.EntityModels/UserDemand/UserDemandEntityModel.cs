using CrossOver.EntityModels.Core;
using CrossOver.Utility;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrossOver.EntityModels.UserDemand
{
    [Serializable]
    public class UserDemandEntityModel :BaseEntityModel
    {

        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId UserId { get; set; }

        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId BookId { get; set; }

        [Required]
        public bool RequestStatus { get; set; }

        public string Remark { get; set; }

        public DateTime? IssuedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public DateTime UpdatedOn { get; set; }

        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId UpdatedBy { get; set; }

    }
}
