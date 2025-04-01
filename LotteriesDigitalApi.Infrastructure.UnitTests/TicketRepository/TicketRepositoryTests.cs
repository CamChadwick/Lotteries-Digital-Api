using LotteriesDigitalApi.Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
using LotteriesDigitalApi.Infrastructure.UnitTests.TicketRepository.TestUtils;
using FluentAssertions;
using LotteriesDigitalApi.Domain.Ticket;

namespace LotteriesDigitalApi.Infrastructure.UnitTests.TicketRepository
{
    public class TicketRepositoryTests
    {

        private readonly Presistance.Repositories.TicketRepository _repository;
        private readonly LotteriesDigitalAPIDbContext _context;

        public TicketRepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LotteriesDigitalAPIDbContext>()
                .UseInMemoryDatabase("LotteriesDb");
            _context = new LotteriesDigitalAPIDbContext(optionsBuilder.Options);
            _repository = new Presistance.Repositories.TicketRepository(_context);
        }

        [Fact]
        public void TicketRepository_WhenIsDuplicateCheckedWithoutDup_ShoulReturnFalse()
        {
            //Arrange
            _context.Database.EnsureDeleted();
            //act
            var result = _repository.IsDuplicateRequest(TicketRepositoryUtils.DrawID, TicketRepositoryUtils.CustomerID, TicketRepositoryUtils.NumberofTickets, TicketRepositoryUtils.TimeStamp);
            //assert
            result.Should().BeFalse();
        }

        [Fact]
        public void TicketRepository_WhenIsDuplicateCheckedWithDup_ShoulReturnTrue()
        {
            //Arrange
            var ticket = TicketPurchase.Create(TicketRepositoryUtils.CustomerID, TicketRepositoryUtils.DrawID, TicketRepositoryUtils.TimeStamp, TicketRepositoryUtils.NumberofTickets);
            _repository.SaveTicketRequest(ticket);
            //act
            var result = _repository.IsDuplicateRequest(TicketRepositoryUtils.DrawID, TicketRepositoryUtils.CustomerID, TicketRepositoryUtils.NumberofTickets, TicketRepositoryUtils.TimeStamp);
            //assert
            result.Should().BeTrue();
        }

       

    }



}
