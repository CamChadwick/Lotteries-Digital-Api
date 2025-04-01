using LotteriesDigitalApi.Application.Common.Interfaces.Persistence;
using LotteriesDigitalApi.Domain.Ticket;
using LotteriesDigitalApi.Infrastructure.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Infrastructure.Presistance.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly LotteriesDigitalAPIDbContext _dbContext;

        public TicketRepository(LotteriesDigitalAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsDuplicateRequest(int drawID, int customerId, int numberofTickets, DateTime timeStamp)
        {

            var ticket = _dbContext.TicketPurchases.FirstOrDefault(src => src.Drawid == drawID && src.CustomerId == customerId && src.NumberofTickets == numberofTickets && src.Timestamp == timeStamp);

            if (ticket == null)
            {
                return false;
            }

            return true;
        }

         public void SaveTicketRequest(TicketPurchase ticket)
        {
            _dbContext.TicketPurchases.Add(ticket);
            _dbContext.SaveChanges();
        }
    }
}
