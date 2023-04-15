using RabbitMQ.Client;

namespace DevFreela.Payments.API.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private const string QUEUE = "Payments";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public ProcessPaymentConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                        queue: QUEUE,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
