using Moq;
using TDDMicroExercises.TurnTicketDispenser;
using TDDMicroExercises.TurnTicketDispenser.Interface;

namespace TDDMicroExcerciseTest.TurnTicketDispenserTest
{
    public class TicketDispenserTests
    {
        public readonly Mock<ISequenceWrapper> _sequenceMock;
        public readonly Mock<ITicketDispenser> _ticketDispenserMock;

        public TicketDispenserTests()
        {
            _sequenceMock = new Mock<ISequenceWrapper>();
            _ticketDispenserMock = new Mock<ITicketDispenser>();
        }
        [Fact]
            public void GetTurnTicket_ReturnsIncrementedTurnNumber()
            {
            // Arrange
                int expected = 1;
                var ticketDispenser = TicketDispenserService();
                _sequenceMock.Setup(s=>s.GetNextTurnNumber()).Returns(expected);

                // Act
                TurnTicket turnTicket = ticketDispenser.GetTurnTicket();

                // Assert
                Assert.Equal(expected, turnTicket.TurnNumber);
            }

        private ITicketDispenser TicketDispenserService()
        {
            return new TicketDispenser();
        }

    }
}
