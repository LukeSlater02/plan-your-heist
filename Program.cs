using System;
using System.Collections.Generic;
namespace plan_your_heist
{
    class Program
    {
        static void Main(string[] args)
        {
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

            if (crew.CrewSkill() > bankDifficulty)
            {
                Console.WriteLine("Success! The money's good, but for me, the action is the juice.");
            }
            else{
                Console.WriteLine("Should've asked Deniro for some pointers. Oh well, too late now.");
            }




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

            public int CrewSkill()
            {
                int total = 0;
                foreach(Goon member in CrewList)
                {
                    total += member.SkillLevel;
                }
                return total;
            }
        }

    }
}
