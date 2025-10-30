using System;

namespace SouravBankingApp
{
    public class OmniAccount : Account
    {
        public OmniAccount(int id, decimal bal, decimal rate, decimal overdraft, decimal fee) : base(id, bal)
        {
            this.rate = rate;
            this.overdraft = overdraft;
            this.fee = fee;
        }

        public override string Withdraw(decimal amount, bool staff)
        {
            if (amount <= balance + overdraft)
            {
                balance -= amount;
                lastNote = $"Omni {accountID}, withdraw {amount}, bal {balance}";
            }
            else
            {
                decimal f = FeeCheck(fee, staff);
                balance -= f;
                lastNote = $"Omni {accountID}, fail withdraw {amount}, fee {f}, bal {balance}";
            }
            return lastNote;
        }

        public override string AddInterest()
        {
            if (balance > 1000)
            {
                decimal i = balance * (rate / 100);
                balance += i;
                lastNote = $"Omni {accountID}, interest {i}, bal {balance}";
            }
            else
            {
                lastNote = $"Omni {accountID}, no interest, bal small";
            }
            return lastNote;
        }

        public override string Info()
        {
            return $"Omni {accountID}, rate {rate}, overdraft {overdraft}, fee {fee}, bal {balance}";
        }
    }
}
