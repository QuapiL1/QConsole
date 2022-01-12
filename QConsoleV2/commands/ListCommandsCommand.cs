using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QConsole.classes;

namespace QConsole.commands
{
    class ListCommandsCommand : classes.Command
    {
        public ListCommandsCommand(string name)
        {
            this.Name = name;
        }

        public override void Run(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder("Commands: \n");
            Command command;
            foreach (string cmdString in QConsole.GetCommands().Keys)
            {
                command = QConsole.GetCommands()[cmdString];
                stringBuilder.AppendLine($" • {cmdString}: {command.GetKey()}");
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
