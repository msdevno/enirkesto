using System;
using Bifrost.Events;

namespace Events.Mailbox.Tags
{
    public class TagAdded : Event
    {
        public TagAdded(EventSourceId eventSourceId) : base(eventSourceId) {}

        public Guid User { get; set; }
        public string Tag { get; set; }
    }
}