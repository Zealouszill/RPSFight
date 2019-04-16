using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Rock
    {
        public Quantity Quantity { get; private set; }

        public Rock(Quantity rockQuantity)
        {
            Quantity = rockQuantity;
        }
    }
}
