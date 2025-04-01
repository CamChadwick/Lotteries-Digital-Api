using ErrorOr;
using LotteriesDigitalApi.Application.Common.Interfaces.Persistence;
using LotteriesDigitalApi.Application.Common.Interfaces.Services;
using LotteriesDigitalApi.Domain.Ticket;
using MediatR;
using LotteriesDigitalApi.Domain.Common;


namespace LotteriesDigitalApi.Application.Tickets.Commands.PurchaseTicket
{
    public class PurchaseTicketCommandHandler:IRequestHandler<PurchaseTicketCommand,ErrorOr<TicketPurchase>>
    {
        ITicketRepository _ticketRepository;
        ITicketProvider _ticketProvider;


        public PurchaseTicketCommandHandler(ITicketRepository ticketRepository,ITicketProvider ticketProvider)
        {
            _ticketProvider = ticketProvider;
            _ticketRepository = ticketRepository;
        }

        public async Task<ErrorOr<TicketPurchase>> Handle(PurchaseTicketCommand request, CancellationToken cancellationToken)
        {
            //Check for Dupes
            if (_ticketRepository.IsDuplicateRequest(request.Drawid, request.CustomerId, request.NumberofTickets, request.Timestamp))
            {
                return Errors.Ticket.DupplicateTicketRequest;
            }

            //CreateTicketRequest
            TicketPurchase ticket =  TicketPurchase.Create(request.CustomerId,request.Drawid,request.Timestamp,request.NumberofTickets);

            //PurchaseTickets
            var totalCost =  await _ticketProvider.PurchaseTicket(ticket.Drawid, ticket.NumberofTickets, ticket.Id);
            if(totalCost>0)
            {
              ticket.TicketsPurchased(totalCost);
            }

            //SaveResults
            _ticketRepository.SaveTicketRequest(ticket);

            return ticket;
        }

    }
}
