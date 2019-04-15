using RPSBackendLogic.DomainPrimitives;
using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.Entities
{
    public class Roshamo
    {
        public Id Id { get; private set; }
        public Name Name { get; private set; }
        public Rock Rock { get; private set; }
        public Paper Paper { get; private set; }
        public Scissors Scissors { get; private set; }

        public Roshamo(Name nm, Rock rk, Paper pr, Scissors sc) : this(new Id(0), nm, rk, pr, sc) { }
        public Roshamo(Id id, Name name, Rock rock, Paper paper, Scissors scissors)
        {
            Id = id;
            Name = name;
            Rock = rock;
            Paper = paper;
            Scissors = scissors;
        }
    }
}
