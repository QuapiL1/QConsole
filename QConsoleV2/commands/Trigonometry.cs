using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.commands
{
    class Trigonometry : classes.Command
    {
        public Trigonometry()
        {
            SetName("trig");
        }

        public override void Run(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            } else
            {
                if (args.Length == 3)
                {
                    double firstRib = double.Parse(args[1]);
                    double secondRib = double.Parse(args[2]);

                    double thirdRib = Math.Sqrt(firstRib * firstRib + secondRib * secondRib);

                    double firstAngle = Math.Cosh(firstRib / secondRib);
                  
                }
            }
        }
    }
}
