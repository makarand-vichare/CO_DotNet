using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CrossOver.ViewModels.Core
{
    [Serializable]
    public abstract class BaseViewModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

    }
}
