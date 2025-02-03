namespace PhoneBook.Common.Response
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object? Result { get; set; }

        public BaseResponse()
        {
            IsSuccess = true;
            Message = "İşlem başarıyla tamamlandı.";
        }

        public BaseResponse(object result)
        {
            IsSuccess = true;
            Message = "İşlem başarıyla tamamlandı.";
            Result = result;
        }

        public BaseResponse(string message)
        {
            IsSuccess = false;
            Message = message;
        }
    }
}