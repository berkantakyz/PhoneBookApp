namespace PhoneBook.Common.Exceptions.Report
{
    public class ReportNotFoundException : Exception
    {
        public static string Message => "Rapor bulunamadı.";

        public ReportNotFoundException()
            : base(Message)
        {
        }

        public ReportNotFoundException(string message)
            : base(message)
        {
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
