using System;

namespace RPSDataStorage.Models
{
    public class Log
    {
        public Log() { }
        public string Id { get; set; }
        public string Entry { get; set; }
        public DateTime DateTime { get; set; }
    }
}
