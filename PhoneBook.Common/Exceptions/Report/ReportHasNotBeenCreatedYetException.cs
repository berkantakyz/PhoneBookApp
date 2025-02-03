namespace PhoneBook.Common.Exceptions.Report
{
    public class ReportHasNotBeenCreatedYetException : Exception
    {
        public static string Message => "Rapor henüz oluşturlmamış.";

        public ReportHasNotBeenCreatedYetException()
            : base(Message)
        {
        }

        public ReportHasNotBeenCreatedYetException(string message)
            : base(message)
        {
        }

        public override string ToString()
        {
            return Message;
        }
    }
}