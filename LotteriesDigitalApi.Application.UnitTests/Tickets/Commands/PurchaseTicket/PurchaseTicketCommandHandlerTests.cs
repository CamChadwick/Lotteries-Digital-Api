using FluentAssertions;
using LotteriesDigitalApi.Application.Common.Interfaces.Persistence;
using LotteriesDigitalApi.Application.Common.Interfaces.Services;
using LotteriesDigitalApi.Application.Tickets.Commands.PurchaseTicket;
using LotteriesDigitalApi.Application.UnitTests.TestUtils.Tickets.Extensions;
using LotteriesDigitalApi.Application.UnitTests.Tickets.Commands.TestUtils;
using Moq;


namespace LotteriesDigitalApi.Application.UnitTests.Tickets.Commands.PurchaseTicket
{
    public class PurchaseTicketCommandHandlerTests
    {
       
        private readonly PurchaseTicketCommandHandler _handler;
        private readonly Mock<ITicketRepository> _mockTicketRepository;
        private readonly Mock<ITicketProvider> _mockTicketProvider;

       

        public PurchaseTicketCommandHandlerTests()
        {
            _mockTicketRepository = new Mock<ITicketRepository>();
            _mockTicketProvider = new Mock<ITicketProvider>();
            _handler = new PurchaseTicketCommandHandler(_mockTicketRepository.Object, _mockTicketProvider.Object);
        }
        [Fact]
        public async Task PurchaseTicketRequestCommand_WhenTicketIsValid_ShouldCreateAndReturnPurchasedTicket()
        {
            //Arange
            var PurchaseTicketCommand = PurchaseTicketsCommandUtils.CreateValidCommand();
            //Act
            var result = await _handler.Handle(PurchaseTicketCommand,default);

            //Assert
            result.IsError.Should().BeFalse();

            result.Value.ValidateCreatedFrom(PurchaseTicketCommand);
            _mockTicketRepository.Verify(m => m.IsDuplicateRequest(PurchaseTicketCommand.Drawid,PurchaseTicketCommand.CustomerId, PurchaseTicketCommand.NumberofTickets, PurchaseTicketCommand.Timestamp), Times.Once);
            _mockTicketProvider.Verify(m=>m.PurchaseTicket(PurchaseTicketCommand.Drawid,PurchaseTicketCommand.NumberofTickets,result.Value.Id), Times.Once);
            _mockTicketRepository.Verify(m=>m.SaveTicketRequest(result.Value),Times.Once);
           
        }
    }
}
