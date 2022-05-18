using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoExercises.Databases
{
    internal class BsonListOfStringsSerializer : SerializerBase<List<string>>
    {
        public override List<string> Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var content = context.Reader.ReadString();
            if (content == "\\N")
            {
                return null;
            }

            return content.Replace("[\"", "").Replace("\"]", "").Split(',').ToList();
        }
    }
}
