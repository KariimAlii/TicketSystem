using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Application.Contracts.Infrastructure;
using TicketSystem.Application.Contracts.Persistance.Repositories;
using TicketSystem.Application.Features.Tickets.Commands.CreateTicket;
using TicketSystem.Application.Models.Mail;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Features.Tickets.Commands.HandleTicket
{
    public class HandleTicketCommandHandler : IRequestHandler<HandleTicketCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IEmailService _emailService;

        public HandleTicketCommandHandler(IMapper mapper , IGenericRepository<Ticket> ticketRepository , IEmailService emailService)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _emailService = emailService;
        }
        public async Task<Unit> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
        {
            var @ticketToUpdate = await _ticketRepository.FirstOrDefaultAsync(t => t.Id == request.Id);

            @ticketToUpdate.Status = request.Status;
            @ticketToUpdate.LastModifiedDate = request.LastModifiedDate;

            await _ticketRepository.UpdateAsync(@ticketToUpdate);

            #region Sending Email , After Successfully Handling the Ticket  ✔
            var email = new Email()
            {
                To = "kariimalii97@gmail.com",
                Subject = "A Ticket was Handled",
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


            return Unit.Value;
        }
    }
}
