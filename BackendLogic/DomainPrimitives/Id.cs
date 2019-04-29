using RPSBackendLogic.Exceptions;
using System;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Id
    {
        private static readonly int MINIMUM_LENGTH = 1;
        private static readonly int MAXIMUM_LENGTH = 255;
        //private static readonly string VALID_CHARACTERS = "^[^0-9][A-Za-z0-9_-]*$";
        private static readonly string VALID_CHARACTERS = ".*";

        public Id(string v)
        {
            if (v != null)
            {
                string trimmed = v.Trim();
                if (trimmed.Length < MINIMUM_LENGTH || trimmed.Length > MAXIMUM_LENGTH)
                {
                    throw new InvalidStringLengthException("Not valid length for a name.");
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(trimmed, VALID_CHARACTERS))
                {
                    throw new InvalidValueException("Not valid characters in the name.");
                }
                Value = trimmed;
            }
            else throw new NullReferenceException("The value is null.");
        }

        public string Value { get; private set; }

        public static implicit operator Id(string v)
        {
            return new Id(v);
        }

        public static implicit operator string(Id v)
        {
            return v.Value;
        }
        //public Id(int id)
        //{
        //    if (id < 0)
        //    {
        //        throw new InvalidValueException("Not valid characters in the name.");
        //    }
        //    Value = id;
        //}
        //public int Value { get; private set; }

        //public static implicit operator Id(int v)
        //{
        //    return new Id(v);
        //}

        //public static implicit operator int(Id v)
        //{
        //    return v.Value;
        //}
    }
}
