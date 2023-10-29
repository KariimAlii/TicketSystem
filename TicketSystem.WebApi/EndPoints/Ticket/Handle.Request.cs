namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class HandleRequest
    {
        public const string Route = "/api/Ticket/Handle";
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
