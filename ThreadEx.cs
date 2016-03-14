using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPlayer
{
  abstract class ThreadEx
  {
    private Thread m_thread;
    protected bool m_bStopThread;

    public void ThreadStart()
    {
      m_bStopThread = false;
      m_thread = new Thread(ThreadProcess);
      m_thread.Start();
    }

    public void ThreadStop()
    {
      ThreadPrepStop();

      m_bStopThread = true;
      m_thread.Abort();
    }

    protected virtual void ThreadPrepStop(){ }

    protected abstract void ThreadProcess();
  }
}
