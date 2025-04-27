using MassTransit;
using SenderWallet.Application.Common.Interfaces;

namespace SenderWallet.Infrastrucrure.Messaging
{
    public class EventBusPublisher : IEventBusPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventBusPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task PublishAsync<T>(T _event) where T : class
        {
            return _publishEndpoint.Publish(_event);
        }
    }
}
