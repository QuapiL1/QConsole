using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.commands
{
    class MayaHomeWork : classes.Command
    {
        public MayaHomeWork()
        {
            SetName("maya");
        }

        public override void Run(string[] args)
        {
            Console.WriteLine("************************");
            Console.WriteLine("*                      *");
            Console.WriteLine("*       Maya gay       *");
            Console.WriteLine("*                      *");
            Console.WriteLine("************************");
        }
    }
}
