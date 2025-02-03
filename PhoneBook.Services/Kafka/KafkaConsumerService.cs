using Confluent.Kafka;
using PhoneBook.Services.IServices;

namespace PhoneBook.Services.Kafka
{
    public class KafkaConsumerService : IKafkaConsumerService
    {
        bool isFirst = false;

        IReportService _reportService;

        private readonly string _brokerList = "localhost:9092";
        private readonly string _topicName = "report-requests";
        private readonly string _groupId = "report-consumers";

        public KafkaConsumerService(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task ConsumeMessages(CancellationToken cancellationToken)
        {
            if (isFirst)
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = _brokerList,
                    GroupId = _groupId,
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumer.Subscribe(_topicName);

                    try
                    {
                        var result = consumer.Consume();

                        if (result != null)
                        {
                            await _reportService.CreateReport(result.Message.Value);

                            Console.WriteLine($"Rapor oluşturuldu : {result.Message.Value}");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                    }
                }
            }

            isFirst = true;
        }
    }
}