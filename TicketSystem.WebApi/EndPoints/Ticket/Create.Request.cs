namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class CreateRequest
    {
        public const string Route = "/api/Ticket/Create";
        public string Status { get; set; }
        public string PhoneNumber { get; set; }
        public int GovernorateId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
    }
}
