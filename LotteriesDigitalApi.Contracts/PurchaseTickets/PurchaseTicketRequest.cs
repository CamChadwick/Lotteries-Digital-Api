
namespace LotteriesDigitalApi.Contracts.PurchaseTickets
{
    public record PurchaseTicketRequest(
         int CustomerId,
         int Drawid,
         int NumberofTickets,
         DateTime Timestamp
        );
}