using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Paper
    {
        public Quantity Quantity { get; private set; }

        public Paper(Quantity paperQuantity)
        {
            Quantity = paperQuantity;
        }
    }
}
