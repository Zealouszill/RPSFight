using System;
using System.Collections.Generic;
using System.Text;

namespace RPSBackendLogic.Entities
{
    public class GameBoard
    {
        public Roshambo Player { get; set; }
        public Roshambo Enemy { get; set; }
    }
}
