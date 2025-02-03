using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services.IServices;

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("CreateReport")]
        public async Task<IActionResult> SendReportRequest() => Ok(await _reportService.CreateReportRequest());

        [HttpGet("GetAllReports")]
        public async Task<IActionResult> GetAllReports() => Ok(await _reportService.GetAllReports());

        [HttpGet("GetReportById")]
        public async Task<IActionResult> GetReportById(Guid id) => Ok(await _reportService.GetReportById(id));
    }
}