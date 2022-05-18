using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoExercises.Databases
{
    internal class BsonNullableIntegerSerializer : SerializerBase<int?>
    {
        public override int? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var type = context.Reader.GetCurrentBsonType();
            if (type == BsonType.String)
            {
                context.Reader.ReadString();
                return null;
            }

            return context.Reader.ReadInt32();
        }
    }
}
