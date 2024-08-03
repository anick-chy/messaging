using Messaging.Framework.Common;
using Messaging.Framework.RabbitMQ.Consumer;
using Newtonsoft.Json;
using static System.Formats.Asn1.AsnWriter;

namespace Messaging.Web.Listeners
{
    public class MessageListener : ConsumerBase
    {
        public MessageListener()
            : base(
                  "SampleExchange"  // exchange name
                  , "SampleEvent"   // event name to subscribe
                  )
        {
            
        }
        public override async Task<MessageAcknowledgement> HandleMessage(GenericMessage genericMessage, IServiceProvider provider)
        {
            // we have service provider here to get any required services
            // using var scope = provider.CreateScope();

            // we can convert the object passed to the message broker to our desired type
            // var convertedObject = JsonConvert.DeserializeObject<SomeEventRaisedClassName>(genericMessage.payload)

            // get required service from DI provider
            //var eventHandler = scope.ServiceProvider.GetService<SomeEventHandlers>();

            // handler
            // await eventHandler.Handle(convertedObject);

            return MessageAcknowledgement.Processed;
        }
    }
}
