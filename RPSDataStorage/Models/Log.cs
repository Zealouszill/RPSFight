using System;
using System.Collections.Generic;
using System.Text;

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
