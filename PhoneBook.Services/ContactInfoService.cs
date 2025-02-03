using Microsoft.EntityFrameworkCore;
using PhoneBook.Common.Exceptions.ContactInfo;
using PhoneBook.Common.Infrastructure;
using PhoneBook.Common.Models;
using PhoneBook.Common.Request;
using PhoneBook.Common.Response;
using PhoneBook.Data;
using PhoneBook.Services.IServices;

namespace PhoneBook.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly PhoneBookContext _context;

        public ContactInfoService(PhoneBookContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse> CreateContactInfoAsync(CreateContactInfoRequest request)
        {
            var contactInfo = new ContactInfo()
                .SetBaseInformation(request.InfoTypeId,request.InfoContent,request.PersonId)
                .SetId(new Guid());
            
            _context.ContactInfo.Add(contactInfo);
            await _context.SaveChangesAsync();

            return new BaseResponse(contactInfo);
        }

        public async Task<BaseResponse> DeleteContactInfoAsync(Guid id)
        {
            var contactInfo = await _context.ContactInfo.FindAsync(id);

            Guard.IsNull(contactInfo, new ContactInfoNotFoundException(id));

            _context.ContactInfo.Remove(contactInfo);
            await _context.SaveChangesAsync();

            return new BaseResponse(id);
        }

        public async Task<BaseResponse> GetContactInfosByPersonIdAsync(Guid personId)
        {
            var contactInfo = await _context.ContactInfo
                                 .Where(c => c.PersonId == personId)
                                 .ToListAsync();

            Guard.IsNullOrEmpty(contactInfo, new ContactInfoNotFoundException(personId));

            return new BaseResponse(contactInfo);
        }
    }
}