using MongoDB.Bson;

namespace MongoExercises.Models
{
    internal class Title
    {
        public ObjectId ObjectId { get; set; }
        public string TConst { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public int StartYear { get; set; }
        public string EndYear { get; set; }
        public int RuntimeMinutes { get; set; }
        public string Genres { get; set; }
    }
}
