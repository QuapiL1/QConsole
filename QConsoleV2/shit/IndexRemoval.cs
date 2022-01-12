using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.shit
{
    class IndexRemoval : classes.Command
    {
        public IndexRemoval()
        {
            this.SetName("indexremoval");
        }


        private int[] numbers = new int[] { 5, 9, 4, 2, 7, 25, 6 };


        public override void Run(string[] args)
        {
            removeIndex(numbers);
        }

        private void removeIndex(int[] a)
        {
            bool running = true;
            while (running)
            {
                Console.Write("Please enter an index to remove: ");
                int i = int.Parse(Console.ReadLine());

                if (i > a.Length)
                {
                    Console.WriteLine("Index too large!");
                } else
                {
                    Console.Write("Removing " + a.ElementAt(i) + " which is index #" + i + " in the array... ");
                    a = remove(i, a);
                    Console.Write("Removed!");
                    Console.WriteLine("");
                    Console.WriteLine("<----------------->");
                    Console.Write("New array: ");


                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (int b in a)
                    {
                        stringBuilder.Append(b).Append(", ");
                    }
                    Console.Write(stringBuilder.ToString());
                    Console.WriteLine("");
                    Console.WriteLine("<----------------->");

                    if (a.Length <= 1)
                    {
                        Console.WriteLine("Array is too little to continue. shutting off..");
                        running = false;
                    }
                }
            }
        }

        private int[] remove(int index, int[] array)
        {
            int[] newarray = new int[array.Length - 1];
            for (int i = 0; i < array.Length-1; i++)
            {
                if (i != index) {
                    if (i >= index)
                    {
                        newarray[i-1] = array[i + 1];
                    } else {
                        newarray[i] = array[i];
                    }
                }
            }
            return newarray;
        }
    }
}
