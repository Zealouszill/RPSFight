using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Rock
    {
        public Quantity Quantity { get; private set; }
        public readonly double ModPaper = .1;
        public readonly double ModScissor = .6;

        public Rock(Quantity rockQuantity)
        {
            Quantity = rockQuantity;
        }
    }
}
