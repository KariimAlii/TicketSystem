namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class GetByIdRequest
    {
        public const string Route = "/api/Ticket/GetById";
        public int Id { get; set; }
    }
}
