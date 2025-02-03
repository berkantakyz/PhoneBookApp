using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Services.IServices;

namespace PhoneBook.Services.Kafka
{
    public class KafkaConsumerHostedService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public KafkaConsumerHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var kafkaConsumerService = scope.ServiceProvider.GetRequiredService<IKafkaConsumerService>();
              
                async Task RunTask()
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        await kafkaConsumerService.ConsumeMessages(stoppingToken);
                        await Task.Delay(500, stoppingToken);
                    }
                }

                var task = RunTask();

                await task;
            }
        }
    }
}