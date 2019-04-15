using BackendLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSFight
{
    class VMLocator
    {
        public VMLocator()
        {
            Main = new MainViewModel();
        }

        public MainViewModel Main { get; }
    }
}
