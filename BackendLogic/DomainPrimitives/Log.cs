using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Log
    {
        public Id Id { get; private set; }
        public Sentence Entry { get; private set; }
        public DateTime DateTime { get; private set; }

        public Log(Sentence nm) : this(new Id(0), nm, DateTime.Now){}
        public Log(Id id, Sentence log, DateTime tm)
        {
            Id = id;
            Entry = log;
            DateTime = tm;
        }
    }
}
