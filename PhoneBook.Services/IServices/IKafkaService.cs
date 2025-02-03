namespace PhoneBook.Services.IServices
{
    public interface IKafkaService
    {
        public Task SendMessageAsync(string key, string message);
    }
}