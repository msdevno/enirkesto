using MongoDB.Bson.Serialization;

namespace Read.Mailbox.Messages
{
    public class MessageMap : BsonClassMap<Message>
    {
        public MessageMap()
        {
            AutoMap();
            MapIdMember(c=>c.MessageId);
        }
    }
}