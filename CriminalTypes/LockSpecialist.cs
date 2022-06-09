using System;
namespace plan_your_heist
{
    public class LockSpecialist : IRobber
    {
        public string Name {get;set;}
        public int SkillLevel {get;set;}
        public int PercentageCut {get;set;}
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            System.Console.WriteLine($"{Name} is working the Vault. Decreased vault security by {SkillLevel}.");
            if (bank.VaultScore <= 0)
            {
                System.Console.WriteLine($"{Name} has cracked the Vault.");
            }
        }
    }
}