using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoExercises.Databases;

namespace MongoExercises.Models
{
    internal class Title
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("tconst")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string TConst { get; set; }

        [BsonElement("titleType")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string TitleType { get; set; }

        [BsonElement("primaryTitle")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string PrimaryTitle { get; set; }

        [BsonElement("originalTitle")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string OriginalTitle { get; set; }

        [BsonElement("isAdult")]
        public bool IsAdult { get; set; }

        [BsonElement("startYear")]
        [BsonSerializer(typeof(BsonNullableIntegerSerializer))]
        public int? StartYear { get; set; }

        [BsonElement("endYear")]
        [BsonSerializer(typeof(BsonNullableIntegerSerializer))]
        public int? EndYear { get; set; }

        [BsonElement("runtimeMinutes")]
        [BsonSerializer(typeof(BsonNullableIntegerSerializer))]
        public int? RuntimeMinutes { get; set; }

        [BsonElement("genres")]
        [BsonSerializer(typeof(BsonListOfStringsSerializer))]
        public List<string> Genres { get; set; }
    }
}
