using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using QConsole.classes;

namespace QConsole.classes
{
    class Utilities
    {
        private static List<Thread> threads = new List<Thread>();

        public static List<Thread> GetThreads() { return threads; }

        public static void PrintSystemInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"# ~ QConsole Version: {QConsole.version} ~ #");
        }

        public static string[] RemoveFirstArgument(string[] args)
        {
            string[] args2 = new string[args.Length-1];

            if (args.Length == 1)
            {
                return null;
            } else
            {
                for (int i = 1; i < args.Length; i++)
                {
                    args2[i - 1] = args[i];
                }
                return args2;
            }
        }
    }
}
