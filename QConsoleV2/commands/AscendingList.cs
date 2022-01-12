using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.commands
{
    class AscendingList : classes.Command
    {
        public AscendingList()
        {
            SetName("ascending");
        }

        public override void Run(string[] args)
        {
            int a, b, c;
            Console.WriteLine("הכנס מספר ראשון");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("הכנס מספר שני");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("הכנס מספר שלישי");
            c = int.Parse(Console.ReadLine());




            if (a > b && a > c)
            {
                Console.WriteLine(a);

                if (b > c)
                {
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                }
                else
                {
                    Console.WriteLine(c);
                    Console.WriteLine(b);
                }
            }
            if (b > a && b > c)
            {
                Console.WriteLine(b);

                if (a > c)
                {
                    Console.WriteLine(a);
                    Console.WriteLine(c);
                }
                else
                {
                    Console.WriteLine(c);
                    Console.WriteLine(a);
                }
            }
            if (c > a && c > b)
            {
                Console.WriteLine(c);

                if (a > b)
                {
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                }
                else
                {
                    Console.WriteLine(b);
                    Console.WriteLine(a);
                }
            }
        }
    }
}
