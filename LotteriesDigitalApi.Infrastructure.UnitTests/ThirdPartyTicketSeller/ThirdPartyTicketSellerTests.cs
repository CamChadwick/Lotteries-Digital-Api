using TicketSeller = LotteriesDigitalApi.Infrastructure.Services.ThirdPartytTicketSeller;
using Moq;
using FluentAssertions;
using LotteriesDigitalApi.Infrastructure.UnitTests.ThirdPartyTicketSeller.TestUtils;

namespace LotteriesDigitalApi.Infrastructure.UnitTests.ThirdPartyTicketSeller
{
    public class ThirdPartyTicketSellerTests
    {

        private readonly TicketSeller.ThirdPartyTicketSeller _ticketSeller;
        private readonly Mock<HttpClient> _mockHttpClient;

        public ThirdPartyTicketSellerTests ()
        {
            _mockHttpClient =  new Mock<HttpClient>();
            _ticketSeller = new TicketSeller.ThirdPartyTicketSeller(_mockHttpClient.Object);
        }

        [Fact]
        public async Task ThirdPartyTicketSeller_PurchaseTicketValidPurchase_ShoulReturnTicketPrice()
        {
            //Arrange
            var TotalPrice = ThirdPartyTicketSellerTestUtils.TicketPrice * (decimal)ThirdPartyTicketSellerTestUtils.ValidNumberofTickets;
            //Act
            var result = await _ticketSeller.PurchaseTicket(ThirdPartyTicketSellerTestUtils.DrawID, ThirdPartyTicketSellerTestUtils.ValidNumberofTickets, ThirdPartyTicketSellerTestUtils.Guid);
            //Assert
            result.Should().Be(TotalPrice);
        }

        [Fact]
        public async Task ThirdPartyTicketSeller_PurchaseTicketInValidPurchase_ShoulReturnNegativeOne()
        {
            //Arrange
            //Act
            var result = await _ticketSeller.PurchaseTicket(ThirdPartyTicketSellerTestUtils.DrawID, ThirdPartyTicketSellerTestUtils.InvalidNumberofTickets, ThirdPartyTicketSellerTestUtils.Guid);
            //Assert
            result.Should().Be(-1m);
        }
    }
}
