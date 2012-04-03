#if SILVERLIGHT || NETCF
namespace Ninject.Infrastructure.Threading
{
    using System.Threading;

    public class ReaderWriterLockSlim
    {
        ReaderWriterLock readerWriterLock = new ReaderWriterLock();
        private object cookie;

        public void EnterReadLock()
        {
            this.readerWriterLock.AcquireReaderLock(Timeout.Infinite);
        }

        public void ExitReadLock()
        {
            this.readerWriterLock.ReleaseReaderLock();
        }

        public void EnterUpgradeableReadLock()
        {
            this.readerWriterLock.AcquireReaderLock(Timeout.Infinite);
        }

        public void ExitUpgradeableReadLock()
        {
            this.readerWriterLock.ReleaseReaderLock();
        }

        public void EnterWriteLock()
        {
            this.readerWriterLock.UpgradeToWriterLock(Timeout.Infinite);
        }

        public void ExitWriteLock()
        {
            int i = 0;
            this.readerWriterLock.DowngradeFromWriterLock(ref i);
        }
    }
}
#endif