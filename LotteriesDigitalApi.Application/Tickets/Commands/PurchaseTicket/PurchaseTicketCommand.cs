using ErrorOr;
using MediatR;
using LotteriesDigitalApi.Domain.Ticket;

namespace LotteriesDigitalApi.Application.Tickets.Commands.PurchaseTicket
{
    public record PurchaseTicketCommand(
         int CustomerId,
         int Drawid,
         int NumberofTickets,
         DateTime Timestamp
        ):IRequest<ErrorOr<TicketPurchase>>;   
}
