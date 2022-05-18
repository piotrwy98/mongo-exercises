using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoExercises.Databases;

namespace MongoExercises.Models
{
    internal class Cast
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("tconst")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string TConst { get; set; }

        [BsonElement("ordering")]
        [BsonSerializer(typeof(BsonNullableIntegerSerializer))]
        public int? Ordering { get; set; }

        [BsonElement("nconst")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string NConst { get; set; }

        [BsonElement("category")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string Category { get; set; }

        [BsonElement("job")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string Job { get; set; }

        [BsonElement("characters")]
        [BsonSerializer(typeof(BsonListOfStringsSerializer))]
        public List<string> Characters { get; set; }
    }
}
