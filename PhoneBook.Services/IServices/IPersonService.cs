using PhoneBook.Common.Request;
using PhoneBook.Common.Response;

namespace PhoneBook.Services.IServices
{
    public interface IPersonService
    {
        Task<BaseResponse> CreatePerson(CreatePersonRequest request);
        Task<BaseResponse> DeletePerson(Guid id);
        Task<BaseResponse> GetPersons();
        Task<BaseResponse> GetPersonById(Guid id);
    }
}