
namespace TDDMicroExercises.TurnTicketDispenser.Interface
{
    public class SequenceWrapper : ISequenceWrapper
    {
        public int GetNextTurnNumber()
        {
           return TurnNumberSequence.GetNextTurnNumber();
        }
    }
}
