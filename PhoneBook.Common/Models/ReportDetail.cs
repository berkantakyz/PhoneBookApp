namespace PhoneBook.Common.Models
{
    public class ReportDetail
    {
        public Guid Id { get; protected set; } 
        public Guid ReportId { get; protected set; }
        public string Location { get; protected set; }
        public int TotalPersonByLocation { get; protected set; }
        public int TotalPersonByPhoneNumber { get; protected set; }
        public Report Report { get; set; }

        public ReportDetail SetBaseInformation(Guid reportId, string location, int totalPersonByLocation, int totalPersonByPhoneNumber)
        {
            ReportId = reportId;
            Location = location;
            TotalPersonByLocation = totalPersonByLocation;
            TotalPersonByPhoneNumber = totalPersonByPhoneNumber;

            return this;
        }

        public ReportDetail SetId(Guid id)
        {
            Id = id;

            return this;
        }

        public ReportDetail AddTotalPersonByPhoneNumber()
        {
            TotalPersonByPhoneNumber = TotalPersonByPhoneNumber + 1;

            return this;
        }

        public ReportDetail AddTotalPersonByLocation()
        {
            TotalPersonByLocation = TotalPersonByLocation + 1;

            return this;
        }
    }
}