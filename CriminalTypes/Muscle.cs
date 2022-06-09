using System;
namespace plan_your_heist
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;
            System.Console.WriteLine($"{Name} is handling the guards. Decreased security guards by {SkillLevel}.");
            if (bank.SecurityGuardScore <= 0)
            {
                System.Console.WriteLine($"{Name} has eliminated security.");
            }
        }
    }
}