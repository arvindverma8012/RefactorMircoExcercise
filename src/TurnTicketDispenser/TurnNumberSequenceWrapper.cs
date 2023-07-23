
using TDDMicroExercises.TurnTicketDispenser;
using TDDMicroExercises.TurnTicketDispenser.Interface;

namespace TDDMicroExercises.TurnTicketDispensers
{
    public class TurnNumberSequenceWrapper : ITurnNumberSequenceWrapper
    {
        public int GetNextTurnNumber()
        {
           return TurnNumberSequence.GetNextTurnNumber();
        }
    }
}
