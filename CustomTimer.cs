using System;
using System.Windows;
using System.Windows.Threading;

namespace IERG3080_____Pokemon_Go
{
    public class CustomTimer
    {
        private DispatcherTimer timer;
        private Func<bool> procedure = null;
        private readonly Action End = null;

        public CustomTimer(int interval, Func<bool> procedure)
        {
            StartTimer_Click(interval);
            this.procedure = procedure;
        }

        public CustomTimer(int interval, Action End)
        {
            StartTimer_Click(interval);
            this.End = End;
        }

        public CustomTimer(int interval, Func<bool> procedure, Action End)
        {
            StartTimer_Click(interval);
            this.procedure = procedure;
            this.End = End;
        }

        public CustomTimer(int interval, Action Initialize, Func<bool> procedure, Action End)
        {
            StartTimer_Click(interval);
            Initialize();
            this.procedure = procedure;
            this.End = End;
        }

        private void StartTimer_Click(int interval)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(interval);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (procedure == null || procedure() == true)
            {
                Stop();
            }
        }
        
        public void Stop()
        {
            timer.Tick -= timer_Tick;
            timer.Stop();
            if (End != null)
            {
                End();
            }
        }
    }
}
