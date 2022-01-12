using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QConsole.classes.security;
using LiteDB;

namespace QConsole.commands
{
    class ResetAuthentication : classes.Command
    {
        int tries = 0;

        public ResetAuthentication()
        {
            SetName("resetauth");
        }

        public override void Run(string[] args)
        {
            Console.Write("Please authenticate using 6-digit authentication code: ");
            string code = Console.ReadLine();

            if (!QConsole.getInstance().getAuthenticator().ValidateTwoFactorPIN(QConsole.getInstance().getUniqueId(), code))
            {
                if (tries < 1) {
                    Console.WriteLine("Code not correct!");
                    tries = tries + 1;
                } else  if (tries > 1) {
                    Console.WriteLine("Breach detected!");
                    EmergencyLockout.Lock();
                }
            } else {
                Console.Write("Please enter a name for your account: ");
                string accountName = Console.ReadLine();

                string accountId = QConsole.getInstance().getAuthenticator().GenerateTwoFactorAuthentication(accountName);

                Console.ReadLine();
                Console.Write("Please enter a 6 digit authentication code: ");
                string enteredCode = Console.ReadLine();

                if (!QConsole.getInstance().getAuthenticator().ValidateTwoFactorPIN(QConsole.getInstance().getUniqueId(), enteredCode))
                {
                    Console.WriteLine("Code not correct!");
                    QConsole.SetRunning(false);
                }
                else
                {
                    using (var db = new LiteDatabase(QConsole.databasePath))
                    {
                        var col = db.GetCollection<QConsole.Data>("settings");

                        col.DeleteMany(x => x.id == 1);

                        QConsole.Data data = new QConsole.Data
                        {
                            authCode = accountId,
                            secure = true
                        };

                        col.Insert(data);

                        col.EnsureIndex(x => x.id, true);
                    }

                    Console.WriteLine("Authenticated!");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    classes.Utilities.PrintSystemInfo();
                }
            }
        }
    }
}
