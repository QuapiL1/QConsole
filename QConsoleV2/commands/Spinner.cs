using System;
using System.Threading;

namespace QConsole.commands
{
    public class Spinner : classes.Command
    {
        public Spinner()
        {
            SetName("spinner");
        }

        public override void Run(string[] args)
        {
            var spin = new ConsoleSpinner();
            Console.Write("Working....");
            for (int i = 0; i < 100; i++)
            {
                spin.Turn();
            }
        }

        private class ConsoleSpinner
        {
            int counter;

            public void Turn()
            {
                counter++;
                switch (counter % 4)
                {
                    case 0: Console.Write("/"); counter = 0; break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Thread.Sleep(100);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
    }
}
