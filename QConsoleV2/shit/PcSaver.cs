using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using QConsole.classes;

namespace QConsole.shit
{
    class PcSaver : Command
    {
        public PcSaver(string name)
        {
            SetName(name);
        }

        public override void Run(string[] args)
        {
            for (int i = 0; i<100; i++)
            {
                List<Thread> threads = Utilities.GetThreads();
                foreach (Thread thr in threads)
                {
                    thr.Interrupt();
                    Console.WriteLine($"Thread with the id: {thr.ManagedThreadId} was interrupted.");
                }
            }
        }
    }
}
