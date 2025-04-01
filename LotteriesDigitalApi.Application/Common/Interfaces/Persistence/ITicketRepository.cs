using LotteriesDigitalApi.Domain.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Application.Common.Interfaces.Persistence
{
    public interface ITicketRepository
    {
        public void SaveTicketRequest(TicketPurchase ticket);
        public bool IsDuplicateRequest(int drawID, int customerId, int numberofTickets, DateTime timeStamp);

    }
}
