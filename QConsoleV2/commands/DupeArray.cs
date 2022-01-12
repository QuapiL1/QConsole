using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.commands
{
    class DupeArray : classes.Command
    {
        public DupeArray()
        {
            SetName("dupearray");
        }

        public override void Run(string[] args)
        {
            int[] numberArray = new int[10];

            Random random = new Random();

            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = random.Next(1, 10);
            }

            Console.Write("Array: ");
            foreach (int i in numberArray)
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine("");


            int[] duplicatedNumbers = new int[numberArray.Length];

            for (int i = 0; i < numberArray.Length; i++)
            {
                for (int i2 = 0; i2 < numberArray.Length; i2++)
                {
                    if (numberArray[i] == numberArray[i2] && i != i2)
                    {
                        if (!duplicatedNumbers.Contains(numberArray[i]))
                        {
                            duplicatedNumbers[numberArray[i]] = numberArray[i];
                        }
                    }
                }
            }

            foreach (int i in duplicatedNumbers)
            {
                if (duplicatedNumbers.Contains(i))
                {
                    if (i != 0)
                    {
                        Console.WriteLine("Duplicate found! " + i);
                    }
                }
            }
        }
    }
}
