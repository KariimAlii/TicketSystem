using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TicketSystem.Application.Features.Tickets.Commands.CreateTicket;
using TicketSystem.Application.Features.Tickets.Commands.HandleTicket;
using TicketSystem.Application.Features.Tickets.Queries.GetAllTickets;

namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class Handle : EndpointBaseAsync.WithRequest<HandleRequest>.WithActionResult<HandleResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public Handle(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPut(HandleRequest.Route)]
        [SwaggerOperation(Summary = "Handle a Ticket", Description = "Handle a Ticket", OperationId = "Tickets.Handle", Tags = new[] { "TicketsEndPoint" })]

        public override async Task<ActionResult<HandleResponse>> HandleAsync([FromBody] HandleRequest request, CancellationToken cancellationToken = default)
        {
            HandleTicketCommand command = _mapper.Map<HandleTicketCommand>(request);
            command.LastModifiedDate = DateTime.Now;
            Unit data = await _mediator.Send(command);

            var response = new HandleResponse() { Result = data };

            return Ok(response);
        }
    }
}
