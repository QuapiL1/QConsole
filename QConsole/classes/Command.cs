using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.classes
{
    abstract class Command
    {
        public string Name;

        public abstract void Run(string[] args);

        public void SetName(string name) { this.Name = name; }
        public string GetName() { return this.Name; }
    }
}
