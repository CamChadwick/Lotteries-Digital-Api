using LotteriesDigitalApi.Application.Tickets.Commands.PurchaseTicket;
using LotteriesDigitalApi.Application.UnitTests.TestUtils.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Application.UnitTests.Tickets.Commands.TestUtils
{
    public static class PurchaseTicketsCommandUtils
    {

        public static PurchaseTicketCommand CreateValidCommand() =>
        
           new PurchaseTicketCommand (
                Constants.ValidTickets.CustomerID,
                Constants.ValidTickets.DrawID,
                Constants.ValidTickets.NumberofTickets,
                Constants.ValidTickets.TimeStamp
               
                );
        
    }
}
