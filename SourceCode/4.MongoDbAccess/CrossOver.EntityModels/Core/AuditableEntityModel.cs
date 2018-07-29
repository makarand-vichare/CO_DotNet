using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CrossOver.EntityModels.Core
{
    [Serializable]
    public abstract class AuditableEntityModel1 : BaseEntityModel
    {
        public DateTime UpdatedOn { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UpdatedBy { get; set; }
    }
}
