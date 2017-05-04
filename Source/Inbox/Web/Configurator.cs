using System.IO;
using Bifrost.Applications;
using Bifrost.Configuration;
using Bifrost.Events;

namespace Web
{
    public class Configurator : ICanConfigure
    {
        public void Configure(IConfigure configure)
        {
            var basePath = "./EventStore";
            var entitiesPath = Path.Combine(basePath, "Entities");
            var eventsPath = Path.Combine(basePath, "Events");
            var eventSequenceNumbersPath = Path.Combine(basePath, "EventSequenceNumbers");
            var eventProcessorsStatePath = Path.Combine(basePath, "EventProcessors");
            var eventSourceVersionsPath = Path.Combine(basePath, "EventSourceVersions");
            var rabbitMQ = "amqp://guest:guest@localhost:5672/";

            configure
                .Application("QuickStart", a => a.Structure(s => s
                        .Domain("Domain.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                        .Events("Events.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                        .Read("Read.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                        .Frontend("Web.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                ))

                .Events(e =>
                {
                    e.EventStore.UsingFiles(eventsPath);
                    e.EventSequenceNumbers.UsingFiles(eventSequenceNumbersPath);
                    e.EventProcessorStates.UsingFiles(eventProcessorsStatePath);
                    e.EventSourceVersions.UsingFiles(eventSourceVersionsPath);

                    //e.CommittedEventStreamReceiver.UsingRabbitMQ(rabbitMQ);
                    //e.CommittedEventStreamSender.UsingRabbitMQ(rabbitMQ);
                })

                .Serialization
                    .UsingJson()

                .DefaultStorage
                    .UsingMongoDB(e => e.WithUrl("mongodb://localhost:27017").WithDefaultDatabase("inboxes"))
                    //.UsingFiles(entitiesPath)

                .Frontend
                    .Web(w =>
                    {
                        w.AsSinglePageApplication();
                        w.PathsToNamespaces.Clear();

                        var baseNamespace = global::Bifrost.Configuration.Configure.Instance.EntryAssembly.GetName().Name;

                        // Normally you would use the base namespace from the assembly - but since the demo code is written for a specific namespace
                        // all the conventions in Bifrost won't work.
                        // Recommend reading up on the namespacing and conventions related to it:
                        // https://dolittle.github.io/bifrost/Frontend/JavaScript/namespacing.html
                        baseNamespace = "Web";

                        var @namespace = string.Format("{0}.**.", baseNamespace);

                        w.PathsToNamespaces.Add("**/", @namespace);
                        w.PathsToNamespaces.Add("/**/", @namespace);
                        w.PathsToNamespaces.Add("", baseNamespace);

                        w.NamespaceMapper.Add(string.Format("{0}.**.", baseNamespace), string.Format("Comcepts.**.", baseNamespace));
                        w.NamespaceMapper.Add(string.Format("{0}.**.", baseNamespace), string.Format("Domain.**.", baseNamespace));
                        w.NamespaceMapper.Add(string.Format("{0}.**.", baseNamespace), string.Format("Read.**.", baseNamespace));
                        w.NamespaceMapper.Add(string.Format("{0}.**.", baseNamespace), string.Format("Events.**.", baseNamespace));
                        w.NamespaceMapper.Add(string.Format("{0}.**.", baseNamespace), string.Format("{0}.**.", baseNamespace));
                    });
        }


    }
}