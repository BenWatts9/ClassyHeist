using System;

namespace ClassyHeist
{
    public class Bank
    {
        public int CashOnHand { get; set; }

        public int AlarmScore { get; set; }

        public int VaultScore { get; set; }

        public int SecurityGuardScore { get; set; }
        
        public bool IsSecure
        { 
            get
            {
                return AlarmScore + VaultScore + SecurityGuardScore <= 0 ? true : false;
            } 
        }
    }
}