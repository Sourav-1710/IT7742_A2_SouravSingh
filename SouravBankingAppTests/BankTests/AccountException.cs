using System;

namespace SouravBankingApp
{
    // Custom exception for failed withdrawal attempts
    public class AccountException : Exception
    {
        public int AccountId { get; }

        public AccountException(string message, int accId) : base(message)
        {
            AccountId = accId;
        }

        public override string ToString()
        {
            return $"AccountException: {Message} (Account ID: {AccountId})";
        }
    }
}
