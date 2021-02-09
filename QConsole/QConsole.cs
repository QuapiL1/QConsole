using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QConsole.classes;
using QConsole.commands;
using QConsole.shit;

namespace QConsole
{
    class QConsole
    {
        private static Dictionary<string, Command> commands = new Dictionary<string, Command>();
        private static bool running = true;

        public static string version = "0.1.1";
        public static string prefix = "$~ ";
        public static string consoleTitle = $"QConsole Version - {version}";

        static void Main(string[] args)
        {
            LoadCommands();
            Utilities.PrintSystemInfo();

            while (running)
            {
                Console.Title = consoleTitle;
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

        private static void HandleCommand(string[] args)
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
            TestCommand testCommand = new TestCommand("test");
            commands.Add("test", testCommand);
            ExitCommand exitCommand = new ExitCommand("exit");
            commands.Add("exit", exitCommand);
            ListCommandsCommand listCommandsCommand = new ListCommandsCommand("commandlist");
            commands.Add("commandlist", listCommandsCommand);
            ClearCommand clearCommand = new ClearCommand("clear");
            commands.Add("clear", clearCommand);
            PcCrasher pcCrasher = new PcCrasher("pcrasher");
            commands.Add("pcrasher", pcCrasher);
            PcSaver pcSaver = new PcSaver("pcsaver");
            commands.Add(pcSaver.ToString(), pcSaver);
            IndexRemoval indexRemoval = new IndexRemoval();
            commands.Add("indexremoval", indexRemoval);
        }

        public static Dictionary<string, Command> GetCommands()
        {
            return commands;
        }
    }
}
