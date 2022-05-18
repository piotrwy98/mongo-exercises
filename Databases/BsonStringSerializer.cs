using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoExercises.Databases
{
    internal class BsonStringSerializer : SerializerBase<string>
    {
        public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var type = context.Reader.GetCurrentBsonType();
            if (type == BsonType.Int32)
            {
                return context.Reader.ReadInt32().ToString();
            }
            else if (type == BsonType.Int64)
            {
                return context.Reader.ReadInt64().ToString();
            }
            else if (type == BsonType.Double)
            {
                return context.Reader.ReadDouble().ToString();
            }

            var content = context.Reader.ReadString();
            return content == "\\N" ? null : content;
        }
    }
}
