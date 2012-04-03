#if WINRT
namespace Ninject.Infrastructure.Threading
{
    using System;

    public class NinjectTimer2 : IDisposable
    {
        private ThreadPoolTimer timer;

        public NinjectTimer2(NinjectTimerCallback callback, long interval)
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