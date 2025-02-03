namespace PhoneBook.Common.Exceptions.ContactInfo
{
    public class ContactInfoNotFoundException : Exception
    {
        public static string Message => "İletişim bilgisi bulunamadı.";

        public ContactInfoNotFoundException()
            : base(Message)
        {
        }

        public ContactInfoNotFoundException(Guid id)
            : base($"{id} kişisine ait iletişim bilgisi bulunamadı.")
        {
        }

        public override string ToString()
        {
            return Message;
        }
    }
}