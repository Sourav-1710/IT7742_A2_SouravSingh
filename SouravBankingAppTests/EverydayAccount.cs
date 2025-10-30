using System;

namespace SouravBankingApp
{
    public class EverydayAccount : Account
    {
        public EverydayAccount(int id, decimal bal) : base(id, bal) { }

        public override string Withdraw(decimal amount, bool staff)
        {
            if (amount <= balance)
            {
                balance -= amount;
                lastNote = $"Everyday {accountID}, withdraw {amount}, bal {balance}";
            }
            else
            {
                lastNote = $"Everyday {accountID}, failed withdraw, not enough money";
            }
            return lastNote;
        }

        public override string AddInterest()
        {
            lastNote = $"Everyday {accountID}, no interest here";
            return lastNote;
        }

        public override string Info()
        {
            return $"Everyday {accountID}, balance {balance}";
        }
    }
}
