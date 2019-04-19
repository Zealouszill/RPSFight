using RPSBackendLogic.Exceptions;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Id
    {

        public Id(int id)
        {
            if (id < 0)
            {
                throw new InvalidValueException("Not valid characters in the name.");
            }
            Value = id;
        }
        public int Value { get; private set; }

        public static implicit operator Id(int v)
        {
            return new Id(v);
        }

        public static implicit operator int(Id v)
        {
            return v.Value;
        }
    }
}
