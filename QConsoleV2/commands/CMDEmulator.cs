using QConsole.classes;
using System;
using System.Diagnostics;
using System.Text;

namespace QConsole.commands
{
    class CMDEmulator : Command
    {
        public CMDEmulator(String name)
        {
            SetName(name);
        }

        public override void Run(string[] args)
        {
            string[] argsFixed = Utilities.RemoveFirstArgument(args);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (string arg in argsFixed)
            {
                stringBuilder.Append(arg).Append(" ");
            }


            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();

            cmd.StandardInput.WriteLine(stringBuilder.ToString());
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }
    }
}
