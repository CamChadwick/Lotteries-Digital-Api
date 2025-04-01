using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Domain.Ticket
{
    public class TicketPurchase
    {
        public Guid Id { get;} = new Guid();
        public int CustomerId { get; set; }
        public int Drawid { get; set; }
        public int NumberofTickets { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Purchased { get; set; }
        public decimal TotalPurcahsePrice { get; set; }

        private TicketPurchase(
            Guid id,
            int customerId,
            int drawId,
            DateTime timeStamp,
            int numberOftickets
            )
            {
            Id = id;
            CustomerId = customerId;
            Drawid = drawId;
            NumberofTickets = numberOftickets;
            Purchased =false;
            TotalPurcahsePrice = 0;
            Timestamp = timeStamp;
        }

        private TicketPurchase() { }    

        public static TicketPurchase Create(
            int customerId,
            int drawId,
            DateTime timeStamp,
            int numberOfTickets
            )
        {
            return new (
                Guid.NewGuid(),
                customerId,
                drawId,
                timeStamp,
                numberOfTickets
                );
        }

        public void TicketsPurchased(decimal totalPurchasePrice)
        {
            Purchased = true;
            TotalPurcahsePrice= totalPurchasePrice;
        }


    }
}
