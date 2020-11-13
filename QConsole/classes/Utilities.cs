using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QConsole.classes;

namespace QConsole.classes
{
    class Utilities
    {
        public static void PrintSystemInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"# ~ QConsole Version: {QConsole.version} ~ #");
        }
    }
}
