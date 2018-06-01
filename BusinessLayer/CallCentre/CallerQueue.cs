using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.CallCentre
{
    public class CallerQueue : ICallerQueue
    {
        static CallerQueue callQueue = new CallerQueue();
        private Queue<string> queuedCalls;
        private object sync;
        public event EventHandler NewCall;

        private void onNewCall()
        {
            if (NewCall != null)
            {
                NewCall(this, new EventArgs());
            }
        }

        public static CallerQueue GetInstance()
        {
            return callQueue;
        }

        private CallerQueue()
        {
            sync = new object();
            queuedCalls = new Queue<string>();
        }

        public void AddCall(string call)
        {
            lock (sync)
            {
                queuedCalls.Enqueue(call);
                onNewCall();
            }
        }

        public int Count()
        {
            lock (sync) return queuedCalls.Count;
        }

        public string GetNextCall()
        {
            lock (sync)
            {
                if (queuedCalls.Count > 0) return queuedCalls.Dequeue();
                else throw new ArgumentOutOfRangeException("No calls are currently queued");
            }
        }

        public string PeekNextCall()
        {
            lock (sync)
            {
                if (queuedCalls.Count > 0) return queuedCalls.Peek();
                else throw new ArgumentOutOfRangeException("No calls are currently queued");
            }
        }
    }
}
