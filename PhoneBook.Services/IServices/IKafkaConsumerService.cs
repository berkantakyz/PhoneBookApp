namespace PhoneBook.Services.IServices
{
    public interface IKafkaConsumerService
    {
        public Task ConsumeMessages(CancellationToken cancellationToken);
    }
}