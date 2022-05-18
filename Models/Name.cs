using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoExercises.Databases;

namespace MongoExercises.Models
{
    internal class Name
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("tconst")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string TConst { get; set; }

        [BsonElement("primaryName")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string PrimaryName { get; set; }

        [BsonElement("birthYear")]
        [BsonSerializer(typeof(BsonNullableIntegerSerializer))]
        public int? BirthYear { get; set; }

        [BsonElement("deathYear")]
        [BsonSerializer(typeof(BsonNullableIntegerSerializer))]
        public int? DeathYear { get; set; }

        [BsonElement("primaryProfession")]
        [BsonSerializer(typeof(BsonListOfStringsSerializer))]
        public List<string> PrimaryProfession { get; set; }

        [BsonElement("knownForTitles")]
        [BsonSerializer(typeof(BsonListOfStringsSerializer))]
        public List<string> KnownForTitles { get; set; }
    }
}
