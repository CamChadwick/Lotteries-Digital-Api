using FluentAssertions;
using LotteriesDigitalApi.Domain.Ticket;
using LotteriesDigitalApi.Domain.UnitTests.Ticket.TestUtils;


namespace LotteriesDigitalApi.Domain.UnitTests.Ticket
{
    public class TicketPurchaseTests
    {
        [Fact]
        public void TicketPurchaseEntity_TicketsPurchased_ShouldUpdateTotalPriceAndSetPurchasedTrue()
        {
            //Arrange
            TicketPurchase ticket = TicketPurchase.Create(TicketPurchaseTestUtils.CustomerID, TicketPurchaseTestUtils.DrawID, TicketPurchaseTestUtils.TimeStamp, TicketPurchaseTestUtils.NumberofTickets);
            //Act
            ticket.TicketsPurchased(15);
            //Assert
            ticket.Purchased.Should().BeTrue();
            ticket.TotalPurcahsePrice.Should().Be(15);

        }
    }
}
