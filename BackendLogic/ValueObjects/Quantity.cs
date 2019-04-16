using RPSBackendLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.ValueObjects
{
    public class Quantity
    {

        public Quantity(int v)
        {
            if(v > 0 && v < 20)
                Value = v;
            throw new InvalidValueException("Quantity is invalid.");
        }

        public int Value { get; private set; }

        public static implicit operator Quantity(int v)
        {
            return new Quantity(v);
        }

        public static implicit operator int(Quantity v)
        {
            return v.Value;
        }
    }
}
