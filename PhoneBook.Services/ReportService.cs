using Microsoft.EntityFrameworkCore;
using PhoneBook.Common.Enums;
using PhoneBook.Common.Exceptions.Report;
using PhoneBook.Common.Infrastructure;
using PhoneBook.Common.Models;
using PhoneBook.Common.Response;
using PhoneBook.Data;
using PhoneBook.Services.IServices;

namespace PhoneBook.Services
{
    public class ReportService : IReportService
    {
        private readonly PhoneBookContext _context;
        private readonly IKafkaService _kafkaService;

        public ReportService(PhoneBookContext context, IKafkaService kafkaService)
        {
            _context = context;
            _kafkaService = kafkaService;
        }

        public async Task CreateReport(string reportId)
        {
            var report = await _context.Report.FirstOrDefaultAsync(x => x.Id == Guid.Parse(reportId));

            if (report != null) {

                List<ReportDetail> reportDetailList = new List<ReportDetail>();

                var locationContactInfos = await _context.ContactInfo
                    .Where(c => c.InfoTypeId == (int)ContactInfoTypeEnum.Location)
                    .Select(c => new { c.PersonId, c.InfoContent })
                    .ToListAsync();

                var reportDetailDictionary = locationContactInfos
                    .Select(x => x.InfoContent)
                    .Distinct()
                    .ToDictionary(location => location, location => new ReportDetail()
                    .SetBaseInformation(Guid.Parse(reportId), location, 0, 0)
                    .SetId(Guid.NewGuid()));

                var phoneContactInfos = await _context.ContactInfo
                    .Where(x => x.InfoTypeId == (int)ContactInfoTypeEnum.PhoneNumber)
                    .GroupBy(x => x.PersonId)
                    .ToListAsync();

                foreach (var item in locationContactInfos)
                {
                    if (reportDetailDictionary.TryGetValue(item.InfoContent, out var reportDetail))
                    {
                        reportDetail.AddTotalPersonByLocation();
                    }
                }

                foreach (var group in phoneContactInfos)
                {
                    var personLocation = locationContactInfos.FirstOrDefault(x => x.PersonId == group.Key)?.InfoContent;
                    if (personLocation != null && reportDetailDictionary.TryGetValue(personLocation, out var reportDetail))
                    {
                        reportDetail.AddTotalPersonByPhoneNumber();
                    }
                }

                report.SetReportStatus(ReportStatusEnum.Completed);
                _context.ReportDetail.AddRange(reportDetailDictionary.Values);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<BaseResponse> CreateReportRequest()
        {
            var reportId = Guid.NewGuid();

            Report report = new Report()
                .SetBaseInformation(DateTime.UtcNow)
                .SetId(reportId)
                .SetReportStatus(ReportStatusEnum.Pending);

            _context.Report.Add(report);
            await _context.SaveChangesAsync();

            await _kafkaService.SendMessageAsync("ReportId",reportId.ToString());

            return new BaseResponse(reportId);
        }

        public async Task<BaseResponse> GetAllReports()
        {
            var reports = await _context.Report
                .Select(x => new { x.Id,x.ReportStatus.Name })
                .ToListAsync();

            Guard.IsNullOrEmpty(reports, new ReportHasNotBeenCreatedYetException());

            return new BaseResponse(reports);
        }

        public async Task<BaseResponse> GetReportById(Guid id)
        {
            var report = await _context.ReportDetail.Where(x => x.ReportId == id).ToListAsync();

            Guard.IsNullOrEmpty(report, new ReportNotFoundException());

            return new BaseResponse(report);
        }
    }
}