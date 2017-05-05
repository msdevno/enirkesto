using Bifrost.Events;
using Events.Mailbox.Messages;

namespace TextAnalytics.Mailbox.Messages
{
    public class Messaging : IProcessEvents
    {
        public void Process(MessageReceived @event)
        {
            // Call the REST API for tagging it

            // Mix tags with tags already there
        }
    }
}