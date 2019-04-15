using System;
using System.Collections.Generic;
using System.Text;

namespace RPSDataStorage.Models
{
    public class Roshamo
    {
        public Roshamo() { }
        public int Id { get; set; }
        public string Country { get; set; }
        public int RockQuantity { get; set; }
        public int PaperQuantity { get; set; }
        public int ScissorQuantity { get; set; }
    }
}
