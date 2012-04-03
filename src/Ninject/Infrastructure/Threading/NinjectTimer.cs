#if !WINRT
namespace Ninject.Infrastructure.Threading
{
    using System;
    using System.Threading;

    public delegate void NinjectTimerCallback();

    public class NinjectTimer : IDisposable
    {
        private readonly NinjectTimerCallback callback;
        private readonly long interval;
        private readonly Timer timer;

        public NinjectTimer(NinjectTimerCallback callback, long interval)
        {
            this.callback = callback;
            this.interval = interval;
            this.timer = new Timer(this.OnTimer, null, interval, Timeout.Infinite);
        }

        ~NinjectTimer()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            using (var signal = new ManualResetEvent(false))
            {
#if !NETCF
                this.timer.Dispose(signal);
                signal.WaitOne();
#else
                this.timer.Dispose();
#endif
            }
        }

        private void OnTimer(object state)
        {
            try
            {
                this.callback();
            }
            finally
            {
                this.timer.Change(this.interval, Timeout.Infinite);
            }
        }
    }
}
#endif