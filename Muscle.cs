using System;

namespace ClassyHeist
{
    public class Muscle : IRobber
    {
        public string Name { get;set; }
        public int SkillLevel { get;set; }
        public int PercentageCut { get;set; }
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;
            Console.WriteLine($"{Name} is dealing with the guards. Decreased security {SkillLevel} points");
            if(bank.SecurityGuardScore <=0)
            {
                Console.WriteLine($"{Name} has disarmed the guards!");
            }
        }

        public Muscle(string name, int skill, int cut)
        {
            Name = name;
            SkillLevel = skill;
            PercentageCut = cut;
        }
    }
}