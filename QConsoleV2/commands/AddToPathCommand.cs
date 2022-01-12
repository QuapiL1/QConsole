using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.commands
{
    class AddToPathCommand : classes.Command
    {
        public AddToPathCommand()
        {
            SetName("addtopath");
        }

        public override void Run(string[] args)
        {
            var name = args[0];
            var scope = EnvironmentVariableTarget.Machine;
            var oldVal = Environment.GetEnvironmentVariable(name, scope);
            var newVal = oldVal + @"" + args[1];
            Environment.SetEnvironmentVariable(name, newVal);
        }
    }
}
