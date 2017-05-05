using System;
using Bifrost.Events;

namespace Events.Mailbox.Tags
{
    public class TagAdded : Event
    {
        public TagAdded(EventSourceId eventSourceId) : base(eventSourceId) {}
        public string Name { get; set; }
    }
}