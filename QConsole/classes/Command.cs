using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QConsole.classes
{
    abstract class Command
    {
        protected string Name;

        public abstract void Run(string[] args);

        public void SetName(string name) { this.Name = name; }
        public string GetName() { return "qconsole.command." + this.Name.ToLower(); }

        public override string ToString()
        {
            return Name;
        }
    }
}