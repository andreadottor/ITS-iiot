using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.EventGenerics
{
    class TimerInitializedEventArgs : EventArgs
    {

        public TimerInitializedEventArgs()
        {
        }

        public TimerInitializedEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
