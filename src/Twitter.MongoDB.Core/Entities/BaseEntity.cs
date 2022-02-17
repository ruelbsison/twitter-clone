using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Twitter.MongoDB.Core.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
