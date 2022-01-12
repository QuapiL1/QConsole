using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.commands
{
    class TestCommand : classes.Command
    {   
        public TestCommand(string name)
        {
            SetName(name);
        }

        public override void Run(string[] args)
        {
            Console.WriteLine("Test command is working.");
        }
    }
}
