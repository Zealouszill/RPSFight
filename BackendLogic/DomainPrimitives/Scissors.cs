using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Scissors
    {
        public int Quantity { get; private set; }

        public Scissors(int scissorsQuantity)
        {
            Quantity = scissorsQuantity;
        }
    }
}
