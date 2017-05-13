using System;
using System.IO;
using Bifrost.Applications;
using Bifrost.Configuration;
using Bifrost.Events;
using Microsoft.Extensions.Configuration;

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

            var redisConnectionString = Environment.GetEnvironmentVariable("REDIS_CONNECTIONSTRING");
            var readModelsConnectionString = Environment.GetEnvironmentVariable("READMODELS_CONNECTIONSTRING");
            var eventStoreConnectionString = Environment.GetEnvironmentVariable("EVENTSTORE_CONNECTIONSTRING");

            if( string.IsNullOrEmpty(readModelsConnectionString)) readModelsConnectionString = "mongodb://localhost:27017";
            if( string.IsNullOrEmpty(eventStoreConnectionString)) eventStoreConnectionString = "mongodb://localhost:27018";

            configure
                .Application("Enirkesto", a => a.Structure(s => s
                        .Domain("Domain.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                        .Events("Events.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                        .Read("Read.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                        .Read("TextAnalytics.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                        .Frontend("Web.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                ))

                .Events(e =>
                {
                    if (string.IsNullOrEmpty(redisConnectionString))
                    {
                        e.EventSequenceNumbers.UsingFiles(eventSequenceNumbersPath);
                        e.EventProcessorStates.UsingFiles(eventProcessorsStatePath);
                        e.EventSourceVersions.UsingFiles(eventSourceVersionsPath);
                    }
                    else
                    {
                        e.EventSequenceNumbers.UsingRedis(redisConnectionString);
                        e.EventProcessorStates.UsingRedis(redisConnectionString);
                        e.EventSourceVersions.UsingRedis(redisConnectionString);
                    }

                    e.EventStore.UsingFiles(eventsPath);
                })

                .Serialization
                    .UsingJson()

                .DefaultStorage
                    .UsingMongoDB(e => e.WithUrl(readModelsConnectionString).WithDefaultDatabase("inboxes"))

                .Frontend
                    .Web(w =>
                    {
                        w.AsSinglePageApplication();
                        w.PathsToNamespaces.Clear();

                        var baseNamespace = "Web";

                        var @namespace = string.Format("{0}.**.", baseNamespace);

                        w.PathsToNamespaces.Add("**/", @namespace);
                        w.PathsToNamespaces.Add("/**/", @namespace);
                        w.PathsToNamespaces.Add("", baseNamespace);

                        w.NamespaceMapper.Add($"{baseNamespace}.**.","Concepts.**.");
                        w.NamespaceMapper.Add($"{baseNamespace}.**.","Read.**.");
                        w.NamespaceMapper.Add($"{baseNamespace}.**.","Events.**.");
                        w.NamespaceMapper.Add($"{baseNamespace}.**.",$"{baseNamespace}.**.");
                    });
        }


    }
}