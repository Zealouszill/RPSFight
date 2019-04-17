using RPSBackendLogic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.DomainPrimitives
{
    public class Log
    {
        public Name Entry { get; private set; }
        public DateTime DateTime { get; private set; }
        public Log(Name log)
        {
            Entry = log;
            var time = DateTime.Now;
            DateTime = time.ToLocalTime();
            //DateTime.ToString("yyyy, MM, dd, hh, mm, ss");
        }
    }
}
