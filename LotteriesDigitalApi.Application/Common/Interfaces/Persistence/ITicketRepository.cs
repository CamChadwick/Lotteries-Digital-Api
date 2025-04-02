using LotteriesDigitalApi.Domain.Ticket;

namespace LotteriesDigitalApi.Application.Common.Interfaces.Persistence
{
    public interface ITicketRepository
    {
        public void SaveTicketRequest(TicketPurchase ticket);
        public bool IsDuplicateRequest(int drawID, int customerId, int numberofTickets, DateTime timeStamp);

    }
}
