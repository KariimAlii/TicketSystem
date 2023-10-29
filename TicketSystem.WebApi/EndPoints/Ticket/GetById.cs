using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdRequest>.WithActionResult<GetByIdResponse>
    {
        [HttpGet(GetByIdRequest.Route)]
        [SwaggerOperation(Summary = "Get Ticket By Id", Description = "Get a Ticket by its Id", OperationId = "Tickets.GetById", Tags = new[] { "TicketsEndPoint" })]
        public override Task<ActionResult<GetByIdResponse>> HandleAsync([FromQuery] GetByIdRequest request, CancellationToken cancellationToken = default)
        {
            var data = new GetByIdResponse();
            return Task.FromResult<ActionResult<GetByIdResponse>>(Ok(data));
        }

    }


}
