using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Infrastructure.UnitTests.ThirdPartyTicketSeller.TestUtils
{
    public static class ThirdPartyTicketSellerTestUtils
    {
        public const int DrawID = 5;
        public const int ValidNumberofTickets = 5;
        public const int InvalidNumberofTickets = 6;
        public const decimal TicketPrice = 5.20m;
        public static readonly Guid Guid = new Guid();
        
    }
}
