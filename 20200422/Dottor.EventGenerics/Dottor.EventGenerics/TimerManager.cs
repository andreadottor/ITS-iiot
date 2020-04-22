using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Dottor.EventGenerics
{
    class TimerManager
    {

        public event EventHandler<TimerInitializedEventArgs> Initialized;

        private readonly string _name;

        public TimerManager(string name)
        {
            _name = name;
        }

        public void Initialize()
        {
            var random = new Random();
            var time = random.Next(1000, 5000);

            System.Diagnostics.Debug.WriteLine($"Timer impostato a {time}");

            var timer = new Timer(time);
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnInitialized(new TimerInitializedEventArgs(_name));
        }

        private void OnInitialized(TimerInitializedEventArgs e)
        {
            //if (Initialized != null)
            //    Initialized.Invoke(this, e);
            
            Initialized?.Invoke(this, e);
        }


    }
}
