using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bifrost.Commands;
using Bifrost.Events;
using Bifrost.Extensions;
using Bifrost.Serialization;
using Domain.Mailbox.Messages;
using Events.Mailbox.Messages;

namespace TextAnalytics.Mailbox.Messages
{
    public class MessagingEventProcessors : IProcessEvents
    {
        ICommandCoordinator _commandCoordinator;
        ISerializer _serializer;

        RESTOperations _restOperations;

        public MessagingEventProcessors(ICommandCoordinator commandCoordinator, ISerializer serializer, RESTOperations restOperations)
        {
            _commandCoordinator = commandCoordinator;
            _serializer = serializer;
            _restOperations = restOperations;
        }

        public void Process(MessageReceived @event)
        {
            Task.Run(async () =>
            {
                var payload = new
                {
                    key = @event.EventSourceId,
                    text = $"{@event.Subject} {@event.Body}"
                };
                var tagsWithScore = await _restOperations.POST<IEnumerable<TagWithScore>>("http://localhost:3000/tags", payload);
                var filtered = tagsWithScore.Where(t => t.Score >= 0.1);

                // Get tags from message
                // Mix tags with tags already there

                filtered.ForEach(tag =>
                {
                    var tagMessage = new TagMessage
                    {
                        MessageId = @event.MessageId,
                        Tag = tag.Tag
                    };

                    _commandCoordinator.Handle(tagMessage);
                });
            });

        }
    }
}