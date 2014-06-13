using Windows.System.Threading;

#if WINRT
public delegate void NinjectTimerCallback();

namespace Ninject.Infrastructure.Threading
{
    using System;

    public class NinjectTimer : IDisposable
    {
        private ThreadPoolTimer timer;

        public NinjectTimer(NinjectTimerCallback callback, long interval)
        {
            this.timer = ThreadPoolTimer.CreatePeriodicTimer(t => callback(), TimeSpan.FromMilliseconds(interval));            
        }

        public void Dispose()
        {
            this.timer.Cancel();
        }
    }
}
#endif