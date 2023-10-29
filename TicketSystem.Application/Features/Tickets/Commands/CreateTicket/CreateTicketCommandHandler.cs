using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Application.Contracts.Infrastructure;
using TicketSystem.Application.Contracts.Persistance.Repositories;
using TicketSystem.Application.Models.Mail;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Features.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, CreateTicketCommandModel>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IEmailService _emailService;

        public CreateTicketCommandHandler(IMapper mapper , IGenericRepository<Ticket> ticketRepository , IEmailService emailService)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _emailService = emailService;
        }
        public async Task<CreateTicketCommandModel> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var @ticket = _mapper.Map<Ticket>(request);
            @ticket.CreatedDate = DateTime.Now;
            @ticket.LastModifiedDate = DateTime.Now;
            var newTicket = await _ticketRepository.AddAsync(@ticket);

            #region Sending Email , After Successfully Adding the Ticket to Database ✔
            var email = new Email()
            {
                To = "kariimalii97@gmail.com",
                Subject = "A New Ticket Was Created",
                Body = $"A New Ticket was created : {request}"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                // just need to be logged , but not stop the application
            }
            #endregion

            return _mapper.Map<CreateTicketCommandModel>(ticket);
        }
    }
}
