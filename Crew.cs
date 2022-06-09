using System;
using System.Collections.Generic;
namespace plan_your_heist
{
    public class Crew
    {
        public List<Goon> CrewList = new List<Goon>();

        public int CrewCount { get; set; }

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