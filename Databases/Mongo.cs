using MongoDB.Driver;
using MongoExercises.Models;

namespace MongoExercises.Databases
{
    internal class Mongo
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public IMongoCollection<Title> Title { get; }
        public IMongoCollection<Cast> Cast { get; }
        public IMongoCollection<Crew> Crew { get; }
        public IMongoCollection<Rating> Rating { get; }
        public IMongoCollection<Name> Name { get; }

        public Mongo()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("IMDB");

            Title = _database.GetCollection<Title>("Title");
            Cast = _database.GetCollection<Cast>("Cast");
            Crew = _database.GetCollection<Crew>("Crew");
            Rating = _database.GetCollection<Rating>("Rating");
            Name = _database.GetCollection<Name>("Name");
        }

        public async Task<int> GetDocumentsCount<T>(IMongoCollection<T> collection)
        {
            return (await (await collection.FindAsync(x => true)).ToListAsync()).Count;
        }
    }
}
