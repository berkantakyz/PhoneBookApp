using Microsoft.AspNetCore.Mvc;
using PhoneBook.Common.Request;
using PhoneBook.Services.IServices;

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpPost("CreateContactInfo")]
        public async Task<IActionResult> CreateContactInfo(CreateContactInfoRequest request) => Ok(await _contactInfoService.CreateContactInfoAsync(request));


        [HttpDelete("DeleteContactInfo")]
        public async Task<IActionResult> DeleteContactInfo(Guid id) => Ok(await _contactInfoService.DeleteContactInfoAsync(id));


        [HttpGet("GetContactInfo")]
        public async Task<IActionResult> GetContactInfo(Guid personId) => Ok(await _contactInfoService.GetContactInfosByPersonIdAsync(personId));
    }
}