using Microsoft.EntityFrameworkCore;
using PhoneBook.Common.Models;
using PhoneBook.Common.Request;
using PhoneBook.Common.Response;
using PhoneBook.Data;
using PhoneBook.Services.IServices;

namespace PhoneBook.Services
{
    public class PersonService : IPersonService
    {
        private readonly PhoneBookContext _context;

        public PersonService(PhoneBookContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse> CreatePerson(CreatePersonRequest request)
        {
            var person = new Person()
            .SetId(Guid.NewGuid())
            .SetBaseInformation(request.FirstName, request.LastName, request.Company);

            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return new BaseResponse(person.Id);
        }

        public async Task<BaseResponse> DeletePerson(Guid id)
        {
            var person = await _context.Person.FindAsync(id);

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return new BaseResponse(id);
        }

        public async Task<BaseResponse> GetPersons()
        {
            var persons = await _context.Person.ToListAsync();

            return new BaseResponse(persons);
        }

        public async Task<BaseResponse> GetPersonById(Guid id)
        {
            var person = await _context.Person.FindAsync(id);

            return new BaseResponse(person);
        }
    }
}