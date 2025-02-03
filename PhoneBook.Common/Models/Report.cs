using PhoneBook.Common.Enums;

namespace PhoneBook.Common.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ReportStatusId { get; set; }

        public ReportStatus ReportStatus { get; protected set; }
        public List<ReportDetail> ReportDetails { get; set; }

        #region Actions
        public Report SetBaseInformation(DateTime createdOn)
        {
            CreatedOn = createdOn;
            return this;
        }

        public Report SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public Report SetReportDetail(ReportDetail rd)
        {
            if (ReportDetails == null)
                ReportDetails = new List<ReportDetail>();

            ReportDetails.Add(rd);

            return this;
        }

        public Report SetReportStatus(ReportStatusEnum status)
        {
            ReportStatusId = (int)status;

            return this;
        }

        #endregion
    }
}   