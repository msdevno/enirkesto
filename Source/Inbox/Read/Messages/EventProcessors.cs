using Bifrost.Events;
using Events.Messages;

namespace Read.Messages
{
    public class EventProcessors : IProcessEvents
    {
        public void Process(MessageReceived @event)
        {
            var i=0;
            i++;
            
        }
    }
}