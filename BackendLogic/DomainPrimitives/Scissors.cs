using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Scissors
    {
        public Quantity Quantity { get; private set; }

        public Scissors(Quantity scissorsQuantity)
        {
            Quantity = scissorsQuantity;
        }
    }
}