using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using QConsole.classes;

namespace QConsole.shit
{
    class PcCrasher : Command
    {
        public PcCrasher(string name)
        {
            SetName(name);
        }

        public override void Run(string[] args)
        {
            Console.Write("Are you sure?(true/false) ");
            bool.TryParse(Console.ReadLine(), out bool sure);

            if (sure)
            {
                RecursiveNewThread();
            }
        }

        private void RecursiveNewThread()
        {
            Thread thr = new Thread(RecursiveNewThread);
            thr.Start();
            Utilities.GetThreads().Add(thr);
        }
    }
}
