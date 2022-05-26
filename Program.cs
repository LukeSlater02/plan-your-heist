using System;
using System.Collections.Generic;
namespace plan_your_heist
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            Crew crew = new Crew();
            int bankDifficulty = 100;
            {

            }
            Console.WriteLine("Planning Scene..");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Assemble your crew, a name is a good place to start:");
                string name = Console.ReadLine();
                if (name.ToLower() == "")
                {
                    break;
                }
                Goon member = new Goon() { Name = name };
                Console.WriteLine("How skilled are they, from 1-30? Keep it real.");
                member.SkillLevel = int.Parse(Console.ReadLine());
                Console.WriteLine("What's their Courage Factor? Be specific, from 0.0 - 2.0.");
                member.CourageFactor = Double.Parse(Console.ReadLine());
                crew.CrewList.Add(member);
                Console.WriteLine($"Alright, {member.Name} is in. With a {member.SkillLevel} skill level and a {member.CourageFactor} courage factor, he should be an asset to the team. That brings our goon count up to {crew.CrewList.Count}.");
                // Console.WriteLine();
                // Console.WriteLine("Here's who we've got so far:");
                // foreach(Goon goon in crew.CrewList)
                // {
                //     Console.WriteLine(goon);
                // }
            }
            Console.WriteLine();
            Console.WriteLine("Alright, now that we've got the crew assembled, we need to do some practice runs. Question is, how many?");
            int trialRuns = int.Parse(Console.ReadLine());
            for (int i = 0; i < trialRuns; i++)
            {
                Console.WriteLine($"Alright, the gang's all here. With a combined skill level of {crew.CrewSkill()}, this job should be a breeze. Probably.");
                bankDifficulty +=  rnd.Next(-10, 11);
                Console.WriteLine($"Bank Level: {bankDifficulty}");
                if (crew.CrewSkill() > bankDifficulty)
                {
                    Console.WriteLine("Success! The money's good, but for me, the action is the juice.");
                    crew.Successes++;
                }
                else
                {
                    Console.WriteLine("Well, shit. Should've asked Deniro for some pointers. Oh well, too late now.");
                    crew.Failures++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Alright, the boys are back. They're reporting {crew.Successes} successful runs and {crew.Failures} failed runs.");





        }

        public class Goon
        {
            public string Name { get; set; }
            public int SkillLevel { get; set; }
            public double CourageFactor { get; set; }

            // public Goon(string n, int sl, double cf)
            // {
            //     Name = n;
            //     SkillLevel = sl;
            //     CourageFactor = cf;
            // }

            public override string ToString()
            {
                return $@"{Name}
Skill Level: {SkillLevel}
Courage Factor: {CourageFactor}
                ";
            }
        }

        public class Crew
        {
            public List<Goon> CrewList = new List<Goon>();

            public int CrewCount { get; set; }

            public int Successes {get;set;}

            public int Failures {get;set;}

            public int CrewSkill()
            {
                int total = 0;
                foreach (Goon member in CrewList)
                {
                    total += member.SkillLevel;
                }
                return total;
            }
        }

    }
}
