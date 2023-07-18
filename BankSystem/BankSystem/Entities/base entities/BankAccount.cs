namespace BankSystem.Entities
{
    internal class BankAccount
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string AccountOwner { get; set; }

        public BankAccount(int AccountId, decimal Balance, string AccountOwner)
        {
            if (AccountId < 0)
            {
                Console.WriteLine("The account ID must be positive");
                throw new Exception(); //bacam exception jer je tesko oporaviti se od pogresnog unosa
            }
            else
            {
                this.AccountId = AccountId;
                this.Balance = Balance;
                this.AccountOwner = AccountOwner;
            }
        }

        public BankAccount()
        {
        }

        public void Deposit(decimal iznos)
        {
            Balance += iznos;
        }

        public virtual void Withdrawal(decimal iznos)
        {
            if (iznos > Balance)
                Console.WriteLine("Not enough money on the account");
            else
                Balance -= iznos;
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine("Racun: " + AccountId + ", Vlasnik: " + AccountOwner + ", Balance:" + Balance);
        }

        public override bool Equals(object? obj)
        {
            return obj is BankAccount account &&
                   AccountId == account.AccountId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccountId);
        }
    }
}