using System;

namespace SouravBankingApp
{
    public class InvestmentAccount : Account
    {
        public InvestmentAccount(int id, decimal bal, decimal rate, decimal fee) : base(id, bal)
        {
            this.rate = rate;
            this.fee = fee;
        }

        public override string Withdraw(decimal amount, bool staff)
        {
            if (amount <= balance)
            {
                balance -= amount;
                lastNote = $"Invest {accountID}, withdraw {amount}, bal {balance}";
            }
            else
            {
                decimal f = FeeCheck(fee, staff);
                balance -= f;
                lastNote = $"Invest {accountID}, fail withdraw {amount}, fee {f}, bal {balance}";
            }
            return lastNote;
        }

        public override string AddInterest()
        {
            decimal i = balance * (rate / 100);
            balance += i;
            lastNote = $"Invest {accountID}, interest {i}, bal {balance}";
            return lastNote;
        }

        public override string Info()
        {
            return $"Invest {accountID}, rate {rate}, fee {fee}, bal {balance}";
        }
    }
}
