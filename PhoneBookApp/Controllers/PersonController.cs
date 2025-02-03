using Microsoft.AspNetCore.Mvc;
using PhoneBook.Common.Request;
using PhoneBook.Services.IServices;

namespace PhoneBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
     
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("CreatePerson")]
        public async Task<IActionResult> CreatePerson(CreatePersonRequest request) => Ok(await _personService.CreatePerson(request));

        [HttpDelete("DeletePerson")]
        public async Task<IActionResult> DeletePerson(Guid id) => Ok(await _personService.DeletePerson(id));
     

        [HttpGet("GetAllPersons")]
        public async Task<IActionResult> GetAllPersons() => Ok(await _personService.GetPersons());

        [HttpGet("GetPersonById")]
        public async Task<IActionResult> GetPersonById(Guid id) => Ok(await _personService.GetPersonById(id));
    }
}