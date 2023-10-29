namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class GetAllRequest
    {
        public const string Route = "/api/Ticket/GetAll";
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
