using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Entities
{
    internal class LoanAccount : BankAccount
    {
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public LoanAccount(int AccountId, decimal Balance, string AccountOwner, decimal LoanAmount, decimal InterestRate) : base(AccountId, Balance, AccountOwner)
        {
            if (LoanAmount < 0)
            {
                Console.WriteLine("The loan amount must be a positive number");
                throw new Exception(); //bacam exception jer je tesko oporaviti se od situacije u kojoj korisnik krivo upise podatke
            }
            else
            {
                this.LoanAmount = LoanAmount;
                this.InterestRate = InterestRate;
            }
        }
        public decimal CalculateInterestAmount()
        {
            return (InterestRate + 1) * LoanAmount;
        }

    }
}
