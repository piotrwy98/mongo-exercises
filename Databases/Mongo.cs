using MongoDB.Bson;
using MongoDB.Driver;
using MongoExercises.Models;

namespace MongoExercises.Databases
{
    internal class Mongo
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public IMongoCollection<Title> Title { get; }

        public Mongo()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("IMDB");
            Title = _database.GetCollection<Title>("Title");
        }
    }
}
