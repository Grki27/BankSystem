namespace BankSystem.Entities
{
    internal class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(int AccountId, decimal Balance, string AccountOwner, decimal InterestRate) : base(AccountId, Balance, AccountOwner)
        {
            if (InterestRate < 0)
            {
                Console.WriteLine("The interest rate must be a positive decimal number");
                throw new Exception(); //bacam exception jer je tesko oporaviti se od situacije u kojoj korisnik krivo upise podatke}
            }
            else
            { this.InterestRate = InterestRate; }
        }

        public decimal CalculateInterestAmount()
        {
            return Balance * (InterestRate + 1);
        }
    }
}