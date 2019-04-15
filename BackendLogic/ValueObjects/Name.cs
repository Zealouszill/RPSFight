using RPSBackendLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.ValueObjects
{
    /// <summary>
    /// Value Object
    /// </summary>
    public class Name
    {
        private static readonly int MINIMUM_LENGTH = 4;
        private static readonly int MAXIMUM_LENGTH = 80;
        private static readonly string VALID_CHARACTERS = "^[^0-9][A-Za-z0-9_-]*$";
        //private static readonly string VALID_CHARACTERS = ".*";

        public Name(string v)
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

        public static implicit operator Name(string v)
        {
            return new Name(v);
        }

        public static implicit operator string(Name v)
        {
            return v.Value;
        }
    }
}
