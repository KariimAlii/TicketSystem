namespace TicketSystem.WebApi.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }
        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
