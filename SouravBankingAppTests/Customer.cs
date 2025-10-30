using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace SouravBankingApp
{
    public class Customer
    {
        private int customerNo;
        private string name;
        private string contact;
        private bool isStaff;
        private List<Account> accounts;

        public Customer(int no, string name, string contact, bool isStaff)
        {
            this.customerNo = no;
            this.name = name;
            this.contact = contact;
            this.isStaff = isStaff;
            accounts = new List<Account>();
        }

        public void AddAccount(Account acc)
        {
            accounts.Add(acc);
        }

        public string GetInfo()
        {
            return $"Customer {customerNo}, Name: {name}, Contact: {contact}, Staff: {isStaff}";
        }

        public bool IsStaff()
        {
            return isStaff;
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }
    }
}
