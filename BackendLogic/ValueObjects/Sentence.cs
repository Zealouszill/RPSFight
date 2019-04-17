using RPSBackendLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.ValueObjects
{
    public class Sentence
    {
        private static readonly int MINIMUM_LENGTH = 4;
        private static readonly int MAXIMUM_LENGTH = 255;
        private static readonly string VALID_CHARACTERS = "^[^0-9][A-Za-z0-9 .:_-]*$";
        //private static readonly string VALID_CHARACTERS = ".*";

        public Sentence(string v)
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

        public static implicit operator Sentence(string v)
        {
            return new Sentence(v);
        }

        public static implicit operator string(Sentence v)
        {
            return v.Value;
        }
    }
}
