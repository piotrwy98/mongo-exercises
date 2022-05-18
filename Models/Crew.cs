using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoExercises.Databases;

namespace MongoExercises.Models
{
    internal class Crew
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("tconst")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string TConst { get; set; }

        [BsonElement("directors")]
        [BsonSerializer(typeof(BsonListOfStringsSerializer))]
        public List<string> Directors { get; set; }

        [BsonElement("writers")]
        [BsonSerializer(typeof(BsonListOfStringsSerializer))]
        public List<string> Writers { get; set; }
    }
}
