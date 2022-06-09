using System;

namespace ClassyHeist
{
    public class LockSpecialist : IRobber
    {
        public string Name { get;set; }
        public int SkillLevel { get;set; }
        public int PercentageCut { get;set; }
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            Console.WriteLine($"{Name} is cracking the vault. Decreased security {SkillLevel} points");
            if(bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has cracked the vault!!");
            }
        }

        public LockSpecialist(string name, int skill, int cut)
        {
            Name = name;
            SkillLevel = skill;
            PercentageCut = cut;
        }
    }
}