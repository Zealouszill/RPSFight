using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Rock
    {
        public int Quantity { get; private set; }

        public Rock(int rockQuantity)
        {
            Quantity = rockQuantity;
        }
    }
}
