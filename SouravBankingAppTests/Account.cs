
using System;

namespace SouravBankingApp
{
    public abstract class Account
    {
        protected int accountID;
        protected decimal balance;
        protected decimal rate;
        protected decimal overdraft;
        protected decimal fee;
        protected string lastNote;

        public Account(int id, decimal bal)
        {
            this.accountID = id;
            this.balance = bal;
            lastNote = "Nothing yet";
        }

        public virtual void Deposit(decimal amount)
        {
            balance += amount;
            lastNote = $"Deposit {amount}, new balance {balance}";
        }

        public abstract string Withdraw(decimal amount, bool staff);
        public abstract string AddInterest();
        public abstract string Info();

        public string LastNote()
        {
            return lastNote;
        }

        protected decimal FeeCheck(decimal f, bool staff)
        {
            return staff ? f / 2 : f;
        }
    }
}
