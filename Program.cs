using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
namespace plan_your_heist
{
    class Program
    {
        static void Main(string[] args)
        {
            // var rnd = new Random();
            // Crew crew = new Crew();
            // int bankDifficulty = 100 + rnd.Next(-10, 11);
            // {

            // }
            // Console.WriteLine("Planning Scene..");

            // while (true)
            // {
            //     Console.WriteLine();
            //     Console.WriteLine("Assemble your crew, a name is a good place to start:");
            //     string name = Console.ReadLine();
            //     if (name.ToLower() == "")
            //     {
            //         break;
            //     }
            //     Goon member = new Goon() { Name = name };
            //     Console.WriteLine("How skilled are they, from 1-30? Keep it real.");
            //     member.SkillLevel = int.Parse(Console.ReadLine());
            //     Console.WriteLine("What's their Courage Factor? Be specific, from 0.0 - 2.0.");
            //     member.CourageFactor = Double.Parse(Console.ReadLine());
            //     crew.CrewList.Add(member);
            //     Console.WriteLine($"Alright, {member.Name} is in. With a {member.SkillLevel} skill level and a {member.CourageFactor} courage factor, he should be an asset to the team. That brings our goon count up to {crew.CrewList.Count}.");
            //     // Console.WriteLine();
            //     // Console.WriteLine("Here's who we've got so far:");
            //     // foreach(Goon goon in crew.CrewList)
            //     // {
            //     //     Console.WriteLine(goon);
            //     // }
            // }
            // Console.WriteLine();
            // Console.WriteLine($"Alright, the gang's all here. With a combined skill level of {crew.CrewSkill()}, this job should be a breeze. Probably.");
            // Console.WriteLine($"Bank Level: {bankDifficulty}");
            // if (crew.CrewSkill() > bankDifficulty)
            // {
            //     Console.WriteLine("Success! The money's good, but for me, the action is the juice.");
            // }
            // else{
            //     Console.WriteLine("Well, shit. Should've asked Deniro for some pointers. Oh well, too late now.");
            // }

            var rnd = new Random();
            TextInfo myTI = new CultureInfo("en-US", true).TextInfo;

            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker()
                {
                    Name = "Luke",
                    SkillLevel = 47,
                    PercentageCut = 25
                },

                new Hacker()
                {
                    Name = "Tanner",
                    SkillLevel = 67,
                    PercentageCut = 35
                },

                new Muscle()
                {
                    Name = "Bane",
                    SkillLevel = 80,
                    PercentageCut = 15
                },

                new Muscle()
                {
                    Name = "Strong Guy",
                    SkillLevel = 37,
                    PercentageCut = 20
                },

                new LockSpecialist()
                {
                    Name = "York",
                    SkillLevel = 77,
                    PercentageCut = 45
                },

            };
            while (true)
            {
                System.Console.WriteLine(rolodex.Count + " current Goons.");
                System.Console.WriteLine("Enter name for new crew member:");
                System.Console.Write("> "); string name = Console.ReadLine();
                if(name == "")
                {
                    break;
                }
                System.Console.WriteLine("Pick a specialty:");
                System.Console.WriteLine("Hacker (Disables alarms)");
                System.Console.WriteLine("Muscle (Disarms guards)");
                System.Console.WriteLine("Lock Specialist (cracks vault)");
                System.Console.Write("> ");
                string specialty = Console.ReadLine().ToLower();
                while (specialty != "hacker" && specialty != "muscle" && specialty != "lock specialist")
                {
                    System.Console.WriteLine("Invalid option, select Hacker, Muscle or Lock Specialist");
                    specialty = Console.ReadLine().ToLower();
                }
                specialty = myTI.ToTitleCase(specialty).Replace(" ", "");
                System.Console.WriteLine("Enter skill level (1-100)");
                System.Console.Write("> ");
                int skillLevel = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter % cut for the job");
                int cut = int.Parse(Console.ReadLine());

                dynamic newMember = Activator.CreateInstance("plan-your-heist", "plan_your_heist." + specialty).Unwrap();
                newMember.Name = name;
                newMember.SkillLevel = skillLevel;
                newMember.PercentageCut = cut;
                rolodex.Add(newMember);

                foreach (var goon in rolodex)
                {
                    Type tp = goon.GetType();
                    System.Console.WriteLine($"{goon.Name} - {tp}");
                }
            }

            Bank bank = new Bank()
            {
                AlarmScore = rnd.Next(0, 101),
                VaultScore = rnd.Next(0, 101),
                SecurityGuardScore = rnd.Next(0, 101),
                CashOnHand = rnd.Next(50000, 1000001)
            };

            if(bank.AlarmScore > bank.VaultScore && bank.AlarmScore > bank.SecurityGuardScore)
            {
                System.Console.WriteLine("Most Secure: Alarm");
            }
            else if(bank.VaultScore > bank.AlarmScore && bank.VaultScore > bank.SecurityGuardScore)
            {
                System.Console.WriteLine("Most Secure: Vault");
            }
            else if(bank.SecurityGuardScore > bank.AlarmScore && bank.SecurityGuardScore > bank.VaultScore)
            {
                System.Console.WriteLine("Most Secure: Guards");
            }

            System.Console.WriteLine("Assemble your crew!");
            foreach(var goon in rolodex)
            {
                var specialty = goon.GetType().ToString().Split(".")[1];
                specialty = Regex.Replace(specialty, "([a-z])([A-Z])", "$1 $2");
                System.Console.WriteLine();
                System.Console.WriteLine($"{rolodex.IndexOf(goon)+1}. {goon.Name} - {goon.SkillLevel} {specialty} - Cut {goon.PercentageCut}");
            }
            System.Console.Write("> ");
            int selectedGoon = int.Parse(Console.ReadLine());
        }
    }
}
