using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TicketSystem.Application.Features.Tickets.Commands.CreateTicket;
using TicketSystem.Application.Features.Tickets.Queries.GetAllTickets;

namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class GetAll : EndpointBaseAsync.WithRequest<GetAllRequest>.WithActionResult<GetAllResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetAll(IMediator mediator , IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet(GetAllRequest.Route)]
        [SwaggerOperation(Summary = "Get List of All Tickets", Description = "List of All Tickets", OperationId = "Tickets.GetAll", Tags = new[] { "TicketsEndPoint" })]
        public override async Task<ActionResult<GetAllResponse>> HandleAsync([FromQuery] GetAllRequest request, CancellationToken cancellationToken = default)
        {
            GetAllTicketsQuery query = _mapper.Map<GetAllTicketsQuery>(request);

            var data = await _mediator.Send(query);

            var response = new GetAllResponse() { Result = data };

            return Ok(response);
        }

    }
}
