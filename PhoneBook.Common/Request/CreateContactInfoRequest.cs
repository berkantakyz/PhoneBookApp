namespace PhoneBook.Common.Request
{
    public class CreateContactInfoRequest
    {
        public int InfoTypeId { get; set; }
        public string InfoContent { get; set; }
        public Guid PersonId { get; set; }
    }
}