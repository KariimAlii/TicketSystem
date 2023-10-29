using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TicketSystem.Application.Features.Tickets.Commands.CreateTicket;
using TicketSystem.Application.Features.Tickets.Queries.GetAllTickets;

namespace TicketSystem.WebApi.EndPoints.Ticket
{
    public class Create : EndpointBaseAsync.WithRequest<CreateRequest>.WithActionResult<CreateResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public Create(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost(CreateRequest.Route)]
        [SwaggerOperation(Summary = "Create a New Ticket", Description = "Create a New Ticket", OperationId = "Tickets.Create", Tags = new[] { "TicketsEndPoint" })]

        public override async Task<ActionResult<CreateResponse>> HandleAsync([FromBody] CreateRequest request, CancellationToken cancellationToken = default)
        {
            CreateTicketCommand command = _mapper.Map<CreateTicketCommand>(request);

            CreateTicketCommandModel data = await _mediator.Send(command);

            var response = new CreateResponse() { Result = data };

            return Ok(response);
        }
    }
}
