using System;
using Bifrost.Applications;
using Bifrost.Configuration;
using Bifrost.Events;

namespace TextAnalytics.dotnet
{
    public class Configurator : ICanConfigure
    {
        public void Configure(IConfigure configure)
        {
            var rabbitMQ = "amqp://guest:guest@localhost:5672/";
            var redis = "127.0.0.1:6379";

            configure
                .Application("QuickStart", a => a.Structure(s => s
                        .Domain("TextAnalytics.dotnet.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                        .Events("TextAnalytics.dotnet.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                        .Read("TextAnalytics.dotnet.{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                ))
            
                .Events(_ =>
                {
                    _.CommittedEventStreamReceiver.UsingRabbitMQ(rabbitMQ);
                    _.CommittedEventStreamSender.UsingRabbitMQ(rabbitMQ);

                    _.EventProcessorStates.UsingRedis(redis);
                    _.EventSourceVersions.UsingRedis(redis);
                    _.EventSequenceNumbers.UsingRedis(redis);
                })
                .Serialization.UsingJson();
        }
    }
}