using System;
namespace plan_your_heist
{
    public class Hacker : IRobber
    {
        public string Name {get;set;}
        public int SkillLevel {get;set;}
        public int PercentageCut {get;set;}
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            System.Console.WriteLine($"{Name} is hacking the Alarm System. Decreased security by {SkillLevel}.");
            if (bank.AlarmScore <= 0)
            {
                System.Console.WriteLine($"{Name} has disabled the Alarm System.");
            }
        }
    }
}