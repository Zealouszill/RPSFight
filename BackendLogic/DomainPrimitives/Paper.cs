using RPSBackendLogic.ValueObjects;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Paper
    {
        public Quantity Quantity { get; private set; }
        public readonly double ModRock = .6;
        public readonly double ModScissor = .1;

        public Paper(Quantity paperQuantity)
        {
            Quantity = paperQuantity;
        }
    }
}
