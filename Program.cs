using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassyHeist
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            
            Bank bank = new Bank()
            {
                AlarmScore = new Random().Next(1,101),
                VaultScore = new Random().Next(1,101),
                SecurityGuardScore = new Random().Next(1,101),
                CashOnHand = new Random().Next(50000,1000001),
            };

            List<int> recon = new List<int>();
            recon.Add(bank.AlarmScore);
            recon.Add(bank.VaultScore);
            recon.Add(bank.SecurityGuardScore);

            bool check = true;
            List<IRobber> rolodex = new List<IRobber>();

            while(check){
                Console.WriteLine($"There are {rolodex.Count} operatives in the rolodex.");

                Console.WriteLine();
                Console.WriteLine("Please enter a name of a new possible recruit.");
                string newRecruitName = Console.ReadLine();
                
                Console.WriteLine($"What type of specialist is {newRecruitName}?");

                Console.WriteLine("1) Hacker (Disables alarms)");
                Console.WriteLine("2) Muscle (Disarms guards)");
                Console.WriteLine("3) Lock Specialist (cracks vault)");
                int specialty = int.Parse(Console.ReadLine());

                Console.WriteLine($"What is {newRecruitName}'s Skill level? (1 - 100)");
                int skillLevel = int.Parse(Console.ReadLine());

                Console.WriteLine($"What percentage of the cut does {newRecruitName} demand?");
                int percentageCut = int.Parse(Console.ReadLine());


                switch(specialty)
                {
                    case 1:
                        rolodex.Add(new Hacker(newRecruitName, skillLevel, percentageCut));
                        break;
                    case 2:
                        rolodex.Add(new Muscle(newRecruitName, skillLevel, percentageCut));
                        break;
                    case 3:
                        rolodex.Add(new LockSpecialist(newRecruitName, skillLevel, percentageCut));
                        break;
                }
                
                Console.WriteLine("Would you like to add another operative? (Y/N)");
                string userCheck = Console.ReadLine().ToLower();
                if(userCheck == "y")
                {
                    check = true;
                }
                else
                {
                    check = false;
                }

            }


            if(recon.Max() == bank.AlarmScore)
            {
                Console.WriteLine("Most Secure: Alarm");
            }
            else if(recon.Max() == bank.VaultScore)
            {
                Console.WriteLine("Most Secure: Vault");
            }
            else
            {
                Console.WriteLine("Most Secure: Security Guards");
            }

            if(recon.Min() == bank.AlarmScore)
            {
                Console.WriteLine("Least Secure: Alarm");
            }
            else if(recon.Min() == bank.VaultScore)
            {
                Console.WriteLine("Least Secure: Vault");
            }
            else
            {
                Console.WriteLine("Least Secure: Security Guards");
            }

            for(int i = 0; i<rolodex.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Crew List");
                Console.WriteLine("------------");
                Console.Write($"{i+1}) ");
                Console.WriteLine($"Name: {rolodex[i].Name}");
                Console.WriteLine($"Skill Level: {rolodex[i].SkillLevel}");
                Console.WriteLine($"Cut: {rolodex[i].PercentageCut}");
                
            }

            List<IRobber> crew = new List<IRobber>();
            bool crewCheck = true;
            while(crewCheck)
            {
                Console.WriteLine("Please select an operative to add to the crew.");
                try
                {
                    string crewSelect = Console.ReadLine();
                    int crewNum = int.Parse(crewSelect);
                    
                    crew.Add(rolodex[crewNum - 1]);
                    
                }
                catch(System.FormatException)
                {
                    Console.WriteLine("Crew Assembled.");
                    crewCheck = false;
                }
            }

            foreach(IRobber robber in crew)
            {
                robber.PerformSkill(bank);
            }

            






            

        }
    }
}
