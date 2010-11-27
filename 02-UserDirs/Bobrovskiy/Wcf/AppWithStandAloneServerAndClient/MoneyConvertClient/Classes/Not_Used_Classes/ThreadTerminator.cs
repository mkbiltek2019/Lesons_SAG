
using System;

namespace Classes.ThreadWrapper
{
    class ThreadTerminator
    {
        object _cancelLocker = new object();
        
        volatile bool _cancelRequest = false;

        public bool IsCancellationRequested
        {
            get
            {
                lock (_cancelLocker)
                {
                    return _cancelRequest;
                }
            }
        }

        public void Cancel()
        {
            lock (_cancelLocker)
            {
                _cancelRequest = true;
            }
        }

        public void ThrowIfCancellationRequested()
        {
            if (IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }
        }

    }
}
