using System;
using System.Timers;

namespace TabooGame.Managers
{
    public class MyTimer
    {
        private readonly Action _timeAction;
        private readonly Action _timeEndAction;
        private readonly Timer _timer;
        public int Counter { get; private set; }

        public MyTimer(double interval, int counter, Action timeAction = null, Action timeEndAction = null)
        {
            _timer = new Timer(interval);
            Counter = counter;
            _timeAction = timeAction;
            _timeEndAction = timeEndAction;
            _timer.Elapsed += (sender, e) => TimerElapsed(sender, e);
        }
        public void StartTimer()
        {
            _timer.Enabled = true;
            _timer.Start();
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (Counter <= 1)
            {
                _timer.Dispose();
                _timeEndAction?.Invoke();
            }

            Counter--;
            _timeAction?.Invoke();
        }
    }
}
