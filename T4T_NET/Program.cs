using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace T4T_NET
{
    class Program
    {
        static List<Talk> talks = new List<Talk>();
        static Track trackOne = new Track();
        static Track trackTwo = new Track();

        static void Main(string[] args)
        {
            WhatToDo();
            //ReadTxt();
            //GenerateTalks();
            //PlanTalks();
            //LogTalks();
            
        }

        public static void WhatToDo()
        {
            Console.WriteLine("Press 1 to use the hardcoded objects");
            Console.WriteLine("Press 2 to read a textfile");
            Console.WriteLine("Press 3 to add a talk");
            Console.WriteLine("Press 4 to generate the tracks");
            string i = Console.ReadLine();
            switch (i)
            {
                case "1":
                    GenerateTalks();
                    WhatToDo();
                    break;
                case "2":
                    ReadTxt();
                    WhatToDo();
                    break;
                case "3":
                    AddTalkCmd();
                    WhatToDo();
                    break;
                case "4":
                    PlanTalks();
                    LogTalks();
                    break;
                default:
                    WhatToDo();
                    break;
            }
        }

        public static void ReadTxt()
        {
            Console.WriteLine("Give the path to the textfile");
            string location = Console.ReadLine();
            //var allLines = File.ReadAllLines(@"C:\Users\jorit\Documents\talks.txt");
            var allLines = File.ReadAllLines(location);
            foreach (var line in allLines)
            {
                //In mijn javascript applicatie werkte volgende reguliere expressie wel om lightning in de array te steken, hier niet.
                //Hierdoor zal de applicatie dus ook een error geven als de talk met lightning in de .txt zit
                String[] talkObjectArray = Regex.Split(line, @"(?=[0-9])(.+)|lightning");
                if (String.Equals(talkObjectArray[1], "lightning"))
                {
                    talks.Add(new Talk(talkObjectArray[0], 5));
                }
                else
                {
                    talks.Add(new Talk(talkObjectArray[0], Int32.Parse(Regex.Match(talkObjectArray[1], @"\d+").Value)));
                }
            }
        }

        public static void AddTalkCmd()
        {
            Console.WriteLine("Enter the title of the talk");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the length of the talk in minutes");
            int length = int.Parse(Console.ReadLine());
            talks.Add(new Talk(title, length));
        }

        public static void GenerateTalks()
        {
            talks.Add(new Talk("Writing Fast Tests Against Enterprise Rails", 60));
            talks.Add(new Talk("Overdoing it in Python", 45));
            talks.Add(new Talk("Lua for the Masses", 30));
            talks.Add(new Talk("Ruby Errors from Mismatched Gem Versions", 45));
            talks.Add(new Talk("Common Ruby Errors", 45));
            talks.Add(new Talk("Communicating Over Distance", 60));
            talks.Add(new Talk("Accounting-Driven Development", 45));
            talks.Add(new Talk("Woah", 30));
            talks.Add(new Talk("Sit Down and Write", 30));
            talks.Add(new Talk("Pair Programming vs Noise", 45));
            talks.Add(new Talk("Rails Magic", 60));
            talks.Add(new Talk("Ruby on Rails: Why We Should Move On", 60));
            talks.Add(new Talk("Clojure Ate Scala(on my project)", 45));
            talks.Add(new Talk("Programming in the Boondocks of Seattle", 30));
            talks.Add(new Talk("Ruby vs.Clojure for Back-End Development", 30));
            talks.Add(new Talk("Ruby on Rails Legacy App Maintenance", 60));
            talks.Add(new Talk("A World Without HackerNews", 30));
            talks.Add(new Talk("User Interface CSS in Rails Apps", 30));
            talks.Add(new Talk("Rails for Python Developers", 5));
        }

        public static void PlanTalks()
        {
            // TrackOne Morning
            DateTime date = new DateTime(2015, 10, 5, 09, 00, 00);
            foreach (var Talk in talks.ToList())
            {
                if (Talk.Length <= trackOne.Morning.MaxLength)
                {
                    Talk.Time = date;
                    trackOne.Morning.AddTalk(Talk);
                    trackOne.Morning.MaxLength -= Talk.Length;
                    date = date.AddMinutes(Talk.Length);
                    talks.Remove(Talk);
                }
            }
            // TrackTwo Morning
            date = new DateTime(2015, 10, 5, 09, 00, 00);
            foreach (var Talk in talks.ToList())
            {
                if (Talk.Length <= trackTwo.Morning.MaxLength)
                {
                    Talk.Time = date;
                    trackTwo.Morning.AddTalk(Talk);
                    trackTwo.Morning.MaxLength -= Talk.Length;
                    date = date.AddMinutes(Talk.Length);
                    talks.Remove(Talk);
                }
            }
            // TrackOne Afternoon
            date = new DateTime(2015, 10, 5, 13, 00, 00);
            foreach (var Talk in talks.ToList())
            {
                if (Talk.Length <= trackOne.Afternoon.MaxLength)
                {
                    Talk.Time = date;
                    trackOne.Afternoon.AddTalk(Talk);
                    trackOne.Afternoon.MaxLength -= Talk.Length;
                    date = date.AddMinutes(Talk.Length);
                    talks.Remove(Talk);
                }
            }
            // TrackTwo Afternoon
            date = new DateTime(2015, 10, 5, 13, 00, 00);
            foreach (var Talk in talks.ToList())
            {
                if (Talk.Length <= trackTwo.Afternoon.MaxLength)
                {
                    Talk.Time = date;
                    trackTwo.Afternoon.AddTalk(Talk);
                    trackTwo.Afternoon.MaxLength -= Talk.Length;
                    date = date.AddMinutes(Talk.Length);
                    talks.Remove(Talk);
                }
            }
        }

        public static void LogTalks()
        {
            Console.WriteLine("Track 1:");
            Console.WriteLine();
            foreach (var Talk in trackOne.Morning.Talks)
            {
                Console.WriteLine($"{Talk.Time.ToString("hh:mmtt", CultureInfo.InvariantCulture)} {Talk.Title} {Talk.Length}min");
            }
            Console.WriteLine("12:00PM Lunch");
            foreach (var Talk in trackOne.Afternoon.Talks)
            {
                Console.WriteLine($"{Talk.Time.ToString("hh:mmtt", CultureInfo.InvariantCulture)} {Talk.Title} {Talk.Length}min");
            }
            Console.WriteLine("05:00PM Networking Event");
            Console.WriteLine();
            Console.WriteLine("Track 2:");
            Console.WriteLine();
            foreach (var Talk in trackTwo.Morning.Talks)
            {
                Console.WriteLine($"{Talk.Time.ToString("hh:mmtt", CultureInfo.InvariantCulture)} {Talk.Title} {Talk.Length}min");
            }
            Console.WriteLine("12:00PM Lunch");
            foreach (var Talk in trackTwo.Afternoon.Talks)
            {
                Console.WriteLine($"{Talk.Time.ToString("hh:mmtt", CultureInfo.InvariantCulture)} {Talk.Title} {Talk.Length}min");
            }
            Console.WriteLine("05:00PM Networking Event");
            Console.ReadKey(true);
        }
    }
}
