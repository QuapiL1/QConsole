namespace QConsole.classes
{
    public abstract class Command
    {
        protected string Name;

        public abstract void Run(string[] args);

        public void SetName(string name) { this.Name = name; }

        public string GetKey()
        {
            return "ERROR_UNSUPPORTED";
        }

        public string GetName() { return this.Name; }

        public override string ToString()
        {
            return Name;
        }
    }
}