namespace BankSystem.Entities
{
    internal class CheckingAccount : BankAccount
    {
        public decimal AllowedMinus;

        public CheckingAccount(int AccountId, decimal Balance, string AccountOwner, decimal AllowedMinus) : base(AccountId, Balance, AccountOwner)
        {
            if (AllowedMinus < 0)
            {
                Console.WriteLine("The allowed minus must be a positive number");
                throw new Exception(); //bacam exception jer je tesko oporaviti se od situacije u kojoj korisnik krivo upise podatke
            }
            else
                this.AllowedMinus = AllowedMinus;
        }

        public override void Withdrawal(decimal iznos)
        {
            if (iznos >= Balance + AllowedMinus)
                Console.WriteLine("Not enough money on the account");
            else
                Balance -= iznos;
        }
    }
}