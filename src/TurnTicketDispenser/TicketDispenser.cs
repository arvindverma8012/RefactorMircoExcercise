using TDDMicroExercises.TurnTicketDispenser.Interface;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser : ITicketDispenser
    {
        private readonly ITurnNumberSequenceWrapper _turnNumberSequence;
        public TicketDispenser()
        {
            
        }
        public TicketDispenser(ITurnNumberSequenceWrapper turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }
        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = _turnNumberSequence.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
