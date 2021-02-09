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
    }
}
