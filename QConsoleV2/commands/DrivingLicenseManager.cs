using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace QConsole.commands
{
    public class DrivingLicenseManager : classes.Command
    {
        public DrivingLicenseManager()
        {
            SetName("driving");
        }

        private readonly string prefix = "Driver's License -> ";

        public override void Run(string[] args)
        {
            switch (args[1].ToLower())
            {
                case "lesson":
                    if (args.Length >= 2)
                    {
                        switch (args[2].ToLower())
                        {
                            case "add":

                                if (args.Length >= 4)
                                {
                                    try {
                                        AddLesson(DateTime.Parse(args[3]));
                                        Console.WriteLine(prefix + "Lesson added!");
                                    } catch (Exception e) {
                                        Console.WriteLine(e.StackTrace);
                                        Console.WriteLine(prefix + "Something went wrong while adding lesson.");
                                    }
                                 
                                } else
                                {
                                    AddLesson(DateTime.Now);
                                    Console.WriteLine(prefix + "Lesson added!");
                                }
                                break;
                            case "list":
                                ListLessons();
                                break;
                        }
                    }
                    break;
                case "pricing":
                    if (args.Length >= 2)
                    {
                        switch (args[2].ToLower())
                        {
                            case "update":
                                UpdatePricing();
                                Console.WriteLine(prefix + "Updated!");
                                break;
                            case "add":
                                if (args.Length >= 4)
                                {
                                    AddMoneyPaid(int.Parse(args[3]));
                                    Console.WriteLine(prefix + "Added money to total paid");
                                }

                                break;
                        }
                    }
                    break;
            }
        }

        private static void UpdatePricing()
        {
            using var db = new LiteDatabase(QConsole.databasePath);
            var col = db.GetCollection<Lesson>("drivingslicenselessons");

            double lessonsPaid = db.GetCollection<GeneralData>("drivingslicensegeneral").FindById(1).MoneyPaid / 105d;

            col.FindAll().ToList().ForEach(lesson =>
            {
                if (lesson.Id <= lessonsPaid)
                {
                    lesson.Paid = true;

                    col.Update(lesson);
                }
            });
        }

        private void ListLessons()
        {
            using var db = new LiteDatabase(QConsole.databasePath);
            var col = db.GetCollection<Lesson>("drivingslicenselessons");

            Console.WriteLine(prefix + "Lessons list:");

            col.FindAll().ToList().ForEach(lesson =>
            {
                Console.WriteLine(" -> Id: " + lesson.Id + " Date: " + lesson.Date.ToShortDateString() + " Is paid?: " + (lesson.Paid ? "Yes" : "No"));
            });
        }

        private static void AddLesson(DateTime date)
        {
            using var db = new LiteDatabase(QConsole.databasePath);
            var col = db.GetCollection<Lesson>("drivingslicenselessons");

            Lesson data = new();
            data.Date = date;
            data.Paid = false;

            col.Insert(data);

            col.EnsureIndex(x => x.Id, true);
        }

        private void AddMoneyPaid(int paid)
        {
            using var db = new LiteDatabase(QConsole.databasePath);
            var col = db.GetCollection<GeneralData>("drivingslicensegeneral");

            if (col.Count() > 0)
            {
                GeneralData data = col.FindOne(x => x.Id == 1);

                data.MoneyPaid += paid;
                data.MoneyLeftToPay = (db.GetCollection("drivingslicenselessons").Count() * 105) - data.MoneyPaid;

                col.Update(data);

                Console.WriteLine(prefix + "Left to pay: " + data.MoneyLeftToPay);
            }
            else
            {
                GeneralData data2 = new();
                data2.MoneyPaid = paid;
                data2.MoneyLeftToPay = (db.GetCollection("drivingslicenselessons").Count() * 105) - data2.MoneyPaid;

                col.Insert(data2);
                col.EnsureIndex(x => x.Id, true);

                Console.WriteLine(prefix + "Left to pay: " + data2.MoneyLeftToPay);
            }
        }


        protected class GeneralData
        {
            public int Id { get; set; }
            public int MoneyPaid { get; set; }
            public int MoneyLeftToPay { get; set; }
        }

        protected class Lesson
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public bool Paid { get; set; }
        }
    }
}
