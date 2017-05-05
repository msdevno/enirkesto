using Bifrost.Events;
using Events.Mailbox.Messages;

namespace TextAnalytics.Mailbox.Messages
{
    public class Tagging : IProcessEvents
    {
        public void Process(MessageTagged @event)
        {
            // Get message by its event source ID

            // Call the REST API - training
        }

        public void Process(MessageUntagged @event)
        {
            // Get message by its event source ID

            // Call the REST API - training
        }
    }
}