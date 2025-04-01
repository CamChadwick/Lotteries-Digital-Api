using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Application.Common.Interfaces.Services
{
    public interface ITicketProvider
    {
        Task<decimal> PurchaseTicket(int Drawid,
                                        int NumberofTickets,
                                        Guid RequestID);
    }
}
