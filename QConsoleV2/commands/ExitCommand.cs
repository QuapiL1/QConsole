using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.commands
{
    class ExitCommand : classes.Command
    {
        public ExitCommand(string name)
        {
            this.SetName(name);
        }

        public override void Run(string[] args)
        {
            QConsole.SetRunning(false);
        }
    }
}
