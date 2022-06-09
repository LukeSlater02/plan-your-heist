using System;
namespace plan_your_heist
{
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
}