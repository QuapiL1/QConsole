using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QConsole.classes;

namespace QConsole.commands
{
    class ClearCommand : classes.Command
    {
        public ClearCommand(string name)
        {
            SetName(name);
        }

        public override void Run(string[] args)
        {
            Console.Clear();
            Utilities.PrintSystemInfo();
        }
    }
}
