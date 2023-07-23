using Moq;
using TDDMicroExercises.TurnTicketDispenser;
using TDDMicroExercises.TurnTicketDispenser.Interface;

namespace TDDMicroExcerciseTest.TurnTicketDispenserTest
{
    public class TicketDispenserTests
    {
        public readonly Mock<ITurnNumberSequenceWrapper> _sequenceMock;

        public TicketDispenserTests()
        {
            _sequenceMock = new Mock<ITurnNumberSequenceWrapper>();
        }
        [Fact]
            public void GetTurnTicket_ReturnsIncrementedTurnNumber()
            {
            // Arrange
                int expected = 1;
                var ticketDispenser = TicketDispenserService();
                _sequenceMock.Setup(s=>s.GetNextTurnNumber()).Returns(expected);

                // Act
                var turnTicket = ticketDispenser.GetTurnTicket();

                // Assert
                Assert.Equal(expected, turnTicket.TurnNumber);
            }

        private ITicketDispenser TicketDispenserService()
        {
            return new TicketDispenser(_sequenceMock.Object);
        }

    }
}
