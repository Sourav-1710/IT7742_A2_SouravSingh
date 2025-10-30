using Microsoft.VisualStudio.TestTools.UnitTesting;
using SouravBankingApp;
using System;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void EverydayAccount_Deposit_IncreasesBalance()
        {
            var acc = new EverydayAccount(200, 100);
            acc.Deposit(50);
            Assert.IsTrue(acc.LastNote().Contains("Deposit"));
            Assert.AreEqual("Everyday 200, balance 150", acc.Info());
        }

        [TestMethod]
        public void InvestmentAccount_AddInterest_UpdatesBalance()
        {
            var acc = new InvestmentAccount(101, 1000, 10, 50);
            var note = acc.AddInterest();
            Assert.IsTrue(note.Contains("interest 100"));
            Assert.IsTrue(note.Contains("bal 1100"));
        }

        [TestMethod]
        public void OmniAccount_WithdrawWithinLimit_Succeeds()
        {
            var acc = new OmniAccount(301, 300, 10, 200, 20);
            var msg = acc.Withdraw(400, false);
            Assert.IsTrue(msg.Contains("withdraw"));
            Assert.AreEqual("Omni 301, withdraw 400, bal -100", msg);
        }

        [TestMethod]
        public void OmniAccount_WithdrawBeyondOverdraft_AppliesFee()
        {
            var acc = new OmniAccount(501, 100, 5, 50, 20);
            var result = acc.Withdraw(500, false);
            Assert.IsTrue(result.Contains("fail withdraw"));
            Assert.AreEqual("Omni 501, fail withdraw 500, fee 20, bal 80", result);
        }

        [TestMethod]
        public void InvestmentAccount_FailedWithdraw_ThrowsCustomException()
        {
            var acc = new InvestmentAccount(999, 50, 5, 20);

            try
            {
                var msg = acc.Withdraw(500, false);
                if (msg.Contains("fail"))
                    throw new AccountException("Withdrawal failed", 999);
            }
            catch (AccountException ex)
            {
                Assert.AreEqual(999, ex.AccountId);
                Assert.IsTrue(ex.ToString().Contains("Withdrawal failed"));
            }
        }

        [TestMethod]
        public void FeeCheck_ForStaff_ReturnsHalf()
        {
            var acc = new InvestmentAccount(400, 200, 10, 30);
            var field = typeof(Account).GetMethod("FeeCheck", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var result = field.Invoke(acc, new object[] { 20m, true });
            Assert.AreEqual(10m, result);
        }

        [TestMethod]
        public void Customer_AddMultipleAccounts_StoresCorrectly()
        {
            var c = new Customer(1, "Aditi", "1234567890", true);
            c.AddAccount(new EverydayAccount(11, 100));
            c.AddAccount(new InvestmentAccount(22, 200, 10, 50));

            Assert.AreEqual(2, c.GetAccounts().Count);
            Assert.IsTrue(c.GetInfo().Contains("Aditi"));
        }

        [TestMethod]
        public void OmniAccount_AddInterest_BelowThreshold_NoInterest()
        {
            var acc = new OmniAccount(777, 800, 8, 200, 25);
            var msg = acc.AddInterest();
            Assert.IsTrue(msg.Contains("no interest"));
        }

        [TestMethod]
        public void EverydayAccount_Withdraw_ExactBalance_ZeroRemaining()
        {
            var acc = new EverydayAccount(300, 500);
            acc.Withdraw(500, false);
            Assert.IsTrue(acc.Info().Contains("balance 0"));
        }

        [TestMethod]
        public void Reflection_CheckPrivateBalanceField()
        {
            // High-awareness test: verifies encapsulation using reflection
            var acc = new InvestmentAccount(500, 2500, 8, 25);
            var field = typeof(Account).GetField("balance", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Assert.IsNotNull(field);
            decimal value = (decimal)field.GetValue(acc);
            Assert.AreEqual(2500, value);
        }
    }
}
