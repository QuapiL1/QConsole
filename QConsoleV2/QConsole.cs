using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using Newtonsoft.Json;
using QConsole.classes;
using QConsole.classes.packets;
using QConsole.classes.security;
using QConsole.commands;
using QConsole.shit;

namespace QConsole
{
    class QConsole
    {
        private static QConsole instance;

        public static bool authenticated;

        public static QConsole getInstance()
        {
            return instance;
        }

        private static string uuid;

        public string getUniqueId()
        {
            return uuid;
        }

        private string setUUID(string suuid)
        {
            uuid = suuid;
            return uuid;
        }
        
        private static readonly Dictionary<string, Command> commands = new();
        private static bool running = true;

        private Authenticator authenticator;

        public Authenticator getAuthenticator() { return authenticator; }
        
        public static string version = "0.1.5";
        public static string prefix = "$~ ";
        public static string consoleTitle = $"QConsole Version - {version}";

        private readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string applicationFolder;
        public static string databasePath;

        public void Enable(string[] args)
        {
            instance = this;
            authenticator = new Authenticator();

            applicationFolder = Path.Combine(folder, "QConsole");

            Directory.CreateDirectory(applicationFolder);

            databasePath = Path.Combine(applicationFolder, "database.db");

            bool debug = true;

            if (!debug)
            {
                using var db = new LiteDatabase(databasePath);
                var col = db.GetCollection<Data>("settings");

                if (col.Count() < 1)
                {
                    Console.Write("Please enter the name for your account: ");
                    string accountName = Console.ReadLine();

                    uuid = this.setUUID(authenticator.GenerateTwoFactorAuthentication(accountName));

                    Console.ReadLine();

                    Console.Write("Enter 6-pin authentication code: ");
                    string code = Console.ReadLine();

                    while (!authenticator.ValidateTwoFactorPIN(uuid, code))
                    {
                        Console.WriteLine("The code was invalid.. Please try again.");
                        Console.WriteLine("If you made a mistake typing the authentication code of the application, please restart the console.");
                        Console.WriteLine("");

                        Console.Write("Enter 6-pin authentication code: ");
                        code = Console.ReadLine();
                    }

                    {
                        Data data = new()
                        {
                            secure = true,
                            authCode = uuid
                        };

                        col.EnsureIndex(x => x.id, true);

                        col.Insert(data);

                        Console.WriteLine("The code was authenticated and saved to database. Starting...");
                        Thread.Sleep(500);
                        Console.Clear();
                    }
                }
                else
                {
                    Data data;
                    if ((data = col.FindById(1)) != null)
                    {
                        Console.Write("Please enter authentication code: ");
                        string code = Console.ReadLine();

                        this.setUUID(data.authCode);

                        if (!authenticator.ValidateTwoFactorPIN(data.authCode, code))
                        {
                            running = false;
                        }
                        else
                        {
                            Console.WriteLine("You have been authorized! Starting...");
                            Thread.Sleep(500);
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong!");
                    }
                }

            }

            //new PacketListener().run();

            LoadCommands();
            Utilities.PrintSystemInfo();

            while (running)
            {
                Console.Title = consoleTitle;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(prefix);
                Console.ForegroundColor = ConsoleColor.White;
                string cmd = Console.ReadLine();

                int i = 0;
                foreach (char c in cmd)
                    if (c == ' ')
                        i++;
                string[] CommandArgs = new string[i + 1];
                i = 0;
                string word = "";
                cmd += " ";
                foreach (char c in cmd)
                {
                    if (c != ' ')
                        word += c;
                    else
                    {
                        CommandArgs[i] = word;
                        word = "";
                        i++;
                    }
                }
                if (i == 0)
                    CommandArgs[0] = word;
                HandleCommand(CommandArgs);
            }
        }

        private static void HandleCommand(string[] args)
        {
            Command command;
            if (!commands.TryGetValue(args[0], out command)) {
                Console.WriteLine($"Command {args[0]} was not found.");
                return;
            } else {
                command.Run(args);
            }
        }

        public static void SetRunning(bool value) { running = value; }

        private void LoadCommands()
        {
            this.registerCommand(new ExitCommand("exit"));
            this.registerCommand(new ListCommandsCommand("commandlist"));
            this.registerCommand(new ClearCommand("clear"));
            this.registerCommand(new IndexRemoval());
            this.registerCommand(new CMDEmulator("cmdemulator"));
            this.registerCommand(new TestAuth());
            this.registerCommand(new Screenshot());
            this.registerCommand(new MayaHomeWork());
            this.registerCommand(new ResetAuthentication());
            this.registerCommand(new DupeArray());
            this.registerCommand(new AscendingList());
            this.registerCommand(new HypixelSkyblockMinionCalculator());
            this.registerCommand(new Spinner());
            this.registerCommand(new DrivingLicenseManager());
        }

        private void registerCommand(Command command)
        {
            commands.Add(command.GetName(), command);
        }
        
        public static Dictionary<string, Command> GetCommands()
        {
            return commands;
        }

        public class Data
        {
            public int id { get; set; }
            public bool secure { get; set; }
            public string authCode { get; set; }
        }
    }
}
