using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoExercises.Databases;

namespace MongoExercises.Models
{
    internal class Rating
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("tconst")]
        [BsonSerializer(typeof(BsonStringSerializer))]
        public string TConst { get; set; }

        [BsonElement("averageRating")]
        public float AverageRating { get; set; }

        [BsonElement("numVotes")]
        public int NumberOfVotes { get; set; }
    }
}
