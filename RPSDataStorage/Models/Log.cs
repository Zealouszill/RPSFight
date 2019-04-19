using System;

namespace RPSDataStorage.Models
{
    public class Log
    {
        public Log() { }
        public int Id { get; set; }
        public string Entry { get; set; }
        public DateTime DateTime { get; set; }
    }
}
