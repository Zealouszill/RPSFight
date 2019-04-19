using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.ValueObjects;

namespace RPSBackendLogic.Entities
{
    public class Roshambo
    {
        public Id Id { get; private set; }
        public Name Name { get; private set; }
        public Rock Rock { get; private set; }
        public Paper Paper { get; private set; }
        public Scissors Scissors { get; private set; }
        public bool Enemy { get; private set; }

        public Roshambo(Name nm, Rock rk, Paper pr, Scissors sc) : this(new Id(0), nm, rk, pr, sc, true) { }
        public Roshambo(Name nm, Rock rk, Paper pr, Scissors sc, bool en) : this(new Id(0), nm, rk, pr, sc, en) { }
        public Roshambo(Id id, Name name, Rock rock, Paper paper, Scissors scissors, bool enemy)
        {
            Id = id;
            Name = name;
            Rock = rock;
            Paper = paper;
            Scissors = scissors;
            Enemy = enemy;
        }
    }
}
