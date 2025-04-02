
namespace LotteriesDigitalApi.Application.Common.Interfaces.Services
{
    public interface ITicketProvider
    {
        Task<decimal> PurchaseTicket(int Drawid,
                                        int NumberofTickets,
                                        Guid RequestID);
    }
}
