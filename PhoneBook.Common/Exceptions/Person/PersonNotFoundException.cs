namespace PhoneBook.Common.Exceptions.Person
{
    public class PersonNotFoundException : Exception
    {
        public static string Message => "Sistemde kişi bulunamadı.";

        public PersonNotFoundException()
            : base(Message)
        {
        }

        public PersonNotFoundException(Guid id)
            : base($"{id.ToString()} ID'li kişi sistemde bulunamadı.")
        {
            
        }

        public override string ToString()
        {
            return Message;
        }
    }
}