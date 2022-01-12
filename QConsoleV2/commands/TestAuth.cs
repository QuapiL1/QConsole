using System;

namespace QConsole.commands
{
    public class TestAuth : classes.Command
    {
        public TestAuth()
        {
            SetName("auth");
        }
        
        public override void Run(string[] args)
        {
            Console.Write("Enter code: ");
            string code = Console.ReadLine();

            if (QConsole.getInstance().getAuthenticator().ValidateTwoFactorPIN(QConsole.getInstance().getUniqueId(), code))
            {
                Console.WriteLine("Validated!");
            }
            else
            {
                classes.security.EmergencyLockout.Lock();
            }
        }
    }
}