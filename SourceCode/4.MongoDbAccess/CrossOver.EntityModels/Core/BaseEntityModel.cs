using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using Newtonsoft.Json;
using CrossOver.Utility;

namespace CrossOver.EntityModels.Core
{
    [Serializable]
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract  class BaseEntityModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public  ObjectId Id { get; set; }
    }
}
