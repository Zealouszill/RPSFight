using RPSBackendLogic.ValueObjects;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Scissors
    {
        public Quantity Quantity { get; private set; }
        public readonly double ModRock = .1;
        public readonly double ModPaper = .6;

        public Scissors(Quantity scissorsQuantity)
        {
            Quantity = scissorsQuantity;
        }
    }
}