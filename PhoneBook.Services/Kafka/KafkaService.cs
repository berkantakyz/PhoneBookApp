using Confluent.Kafka;
using PhoneBook.Services.IServices;

namespace PhoneBook.Services.Kafka
{
    public class KafkaService : IKafkaService
    {
        private readonly string _brokerList = "localhost:9092";
        private readonly string _topicName = "report-requests";
        private readonly string _groupId = "report-consumers";

        public async Task SendMessageAsync(string key, string message)
        {
            var config = new ProducerConfig { BootstrapServers = _brokerList };

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                try
                {
                    var result = await producer.ProduceAsync(_topicName, new Message<string, string> { Key = key, Value = message });
                    Console.WriteLine($"'{result.Value}' - '{result.TopicPartitionOffset} iletildi'");
                }
                catch (ProduceException<string, string> e)
                {
                    Console.WriteLine($"Hata : {e.Error.Reason}");
                }
            }
        }
    }
}