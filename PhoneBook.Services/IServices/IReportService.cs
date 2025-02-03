using PhoneBook.Common.Response;

namespace PhoneBook.Services.IServices
{
    public interface IReportService
    {
        Task<BaseResponse> CreateReportRequest();
        Task<BaseResponse> GetAllReports();
        Task<BaseResponse> GetReportById(Guid id);
        Task CreateReport(string reportId);
    }
}