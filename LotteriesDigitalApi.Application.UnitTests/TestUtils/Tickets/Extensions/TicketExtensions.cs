using FluentAssertions;
using LotteriesDigitalApi.Application.Tickets.Commands.PurchaseTicket;
using LotteriesDigitalApi.Domain.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Application.UnitTests.TestUtils.Tickets.Extensions
{
    public static partial class TicketExtensions
    {
        public static void ValidateCreatedFrom(this TicketPurchase purchase,PurchaseTicketCommand command)
        {
            purchase.Drawid = command.Drawid;
            purchase.CustomerId = command.CustomerId;
            purchase.NumberofTickets = command.NumberofTickets;
            purchase.Timestamp = command.Timestamp;
            purchase.Id.Should().NotBeEmpty();
        }
    }
}
