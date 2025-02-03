using PhoneBook.Common.Request;
using PhoneBook.Common.Response;

namespace PhoneBook.Services.IServices
{
    public interface IContactInfoService
    {
        Task<BaseResponse> CreateContactInfoAsync(CreateContactInfoRequest contactInfo);
        Task<BaseResponse> DeleteContactInfoAsync(Guid id);
        Task<BaseResponse> GetContactInfosByPersonIdAsync(Guid personId);
    }
}