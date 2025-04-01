namespace LotteriesDigitalApi.Contracts.PurchaseTickets
{
    public record PurchaseTicketResponse(
        decimal TotalCost,
        bool TicketsPurchased
        );
}