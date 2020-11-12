using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QConsole.classes;
using QConsole.commands;

namespace QConsole
{
    class QConsole
    {
        private static Dictionary<string, Command> commands = new Dictionary<string, Command>();
        private static bool running = true;

        public static string prefix = "$~ ";

        static void Main(string[] args)
        {
            LoadCommands();
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(prefix);
                Console.ForegroundColor = ConsoleColor.White;
                string cmd = Console.ReadLine();

                int i = 0;
                foreach (char c in cmd)
                    if (c == ' ')
                        i++;
                string[] CommandArgs = new string[i + 1];
                i = 0;
                string word = "";
                cmd += " ";
                foreach (char c in cmd)
                {
                    if (c != ' ')
                        word += c;
                    else
                    {
                        CommandArgs[i] = word;
                        word = "";
                        i++;
                    }
                }
                if (i == 0)
                    CommandArgs[0] = word;
                HandleCommand(CommandArgs);
            }
        }

        public static void HandleCommand(string[] args)
        {
            Command command;
            if (!commands.TryGetValue(args[0], out command)) {
                Console.WriteLine($"Command {args[0]} was not found.");
                return;
            } else {
                command.Run(args);
            }
        }

        public static void SetRunning(bool value) { running = value; }

        private static void LoadCommands()
        {
            TestCommand testCommand = new TestCommand("qconsole.command.test");
            commands.Add("test", testCommand);
            ExitCommand exitCommand = new ExitCommand("qconsole.command.exit");
            commands.Add("exit", exitCommand);
            ListCommandsCommand listCommandsCommand = new ListCommandsCommand("qconsole.command.commandlist");
            commands.Add("commandlist", listCommandsCommand);
        }

        public static Dictionary<string, Command> GetCommands()
        {
            return commands;
        }
    }
}
