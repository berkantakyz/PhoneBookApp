namespace PhoneBook.Common.Exceptions.Shared
{
    public class InvalidDataException : Exception
    {
        public static string Message => "Girilen bilgler geçersiz.";

        public InvalidDataException()
            : base(Message)
        {
        }

        public InvalidDataException(string message)
            : base(message)
        {
        }

        public override string ToString()
        {
            return Message;
        }
    }
}