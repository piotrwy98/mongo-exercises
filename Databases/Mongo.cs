using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoExercises.Databases
{
    internal class Mongo
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public IMongoCollection<BsonDocument> Title { get; }
        public IMongoCollection<BsonDocument> Cast { get; }
        public IMongoCollection<BsonDocument> Crew { get; }
        public IMongoCollection<BsonDocument> Rating { get; }
        public IMongoCollection<BsonDocument> Name { get; }

        public Mongo()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("IMDB");

            Title = _database.GetCollection<BsonDocument>("Title");
            Cast = _database.GetCollection<BsonDocument>("Cast");
            Crew = _database.GetCollection<BsonDocument>("Crew");
            Rating = _database.GetCollection<BsonDocument>("Rating");
            Name = _database.GetCollection<BsonDocument>("Name");
        }
    }
}
