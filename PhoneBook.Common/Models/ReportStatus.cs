namespace PhoneBook.Common.Models
{
    public class ReportStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Report> Reports { get; set; }
    }
}