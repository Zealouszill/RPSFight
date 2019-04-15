using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Paper
    {
        public int Quantity { get; private set; }

        public Paper(int paperQuantity)
        {
            Quantity = paperQuantity;
        }
    }
}
