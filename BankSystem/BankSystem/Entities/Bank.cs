namespace BankSystem.Entities
{
    internal class Bank
    {
        public List<BankAccount> lista = new List<BankAccount>();

        public void CreateAccount(BankAccount account)
        {
            if (lista.Find(x => x.Equals(account)) == null)
                lista.Add(account);
            else

            {
                Console.WriteLine("The account allready exists");
            }
        }

        //ako se u listi ne pronade account id, ba ce biti null
        public void DepositToAccount(int AccountId, decimal deposit)
        {
            var ba = lista.Find(ba => ba.AccountId.Equals(AccountId));
            if (ba != null)
            {
                ba.Deposit(deposit);
            }
            else
                Console.WriteLine("Account ID is incorrect");
        }

        //ako se u listi ne pronade aacount id ba ce biti null
        public void WithdrawFromAccount(int AccountId, decimal amount)
        {
            var ba = lista.Find(x => x.AccountId.Equals(AccountId));
            if (ba != null)
            {
                ba.Withdrawal(amount);
            }
            else
                Console.WriteLine("Account ID is incorrect");
        }

        public void DisplayAccountInfo(int AccountId)
        {
            var ba = lista.Find(x => x.AccountId.Equals(AccountId));
            if (ba != null)
            {
                ba.DisplayAccountInfo();
            }
            else
                Console.WriteLine("Account ID is incorrect");
        }

        public BankAccount GetAccountById(int AccountId)
        {
            var ba = lista.Find(x => x.AccountId == AccountId);
            if (ba == null)
            {
                Console.WriteLine("The account with that ID doesn't exist");
                throw new Exception();
            }
            return ba;
        }

        public void CloseAccount(int AccountId)
        {
            var ba = lista.Find(x => x.AccountId == AccountId);
            if (ba != null)
                lista.Remove(ba);
        }

        public List<BankAccount> GetAllAccounts()
        {
            return lista;
        }

        public decimal GetTotalBalance(string ownerName)
        {
            decimal totalBalance = 0;
            List<BankAccount> listaKorisnika = GetAccountsByOwner(ownerName);
            foreach (var account in listaKorisnika)
            {
                totalBalance += account.Balance;
            }
            return totalBalance;
        }

        public List<BankAccount> allAccountsHigherThan(decimal amount)
        {
            return lista.Where(ba => ba.Balance >= amount).ToList();
        }

        public List<BankAccount> allAccountsStartingWithM()
        {
            return lista.Where(ba => ba.AccountOwner.StartsWith("M")).ToList();
        }

        public List<BankAccount> MostWealthy()
        {
            List<BankAccount> listaNajbogatijih = new List<BankAccount>();
            decimal max = lista.Select(ba => ba.Balance).Max();
            foreach (var ba in lista)
            {
                if (ba.Balance == max)
                    listaNajbogatijih.Add(ba);
            }
            return listaNajbogatijih;
        }

        public List<BankAccount> LeastWealthy()
        {
            List<BankAccount> listaNajsiromasnijih = new List<BankAccount>();
            decimal min = lista.Select(ba => ba.Balance).Min();
            foreach (var ba in lista)
            {
                if (ba.Balance == min)
                    listaNajsiromasnijih.Add(ba);
            }
            return listaNajsiromasnijih;
        }

        public decimal AverageWealth()
        {
            return lista.Select(ba => ba.Balance).Average();
        }

        public List<BankAccount> fromLowerToHigher()
        {
            return lista.OrderBy(ba => ba.Balance).ToList();
        }

        public List<BankAccount> fromHigherToLower()
        {
            return lista.OrderBy(ba => ba.Balance).Reverse().ToList();
        }

        public List<BankAccount> GetFirstNAccounts(string name, int n)
        {
            return GetAccountsByOwner(name).Take(n).ToList();
        }

        public List<BankAccount> GetAccountsByOwner(string ownerName)
        {
            List<BankAccount> listaPoImenu = lista.Where(ba => ba.AccountOwner.Equals(ownerName)).ToList();
            if (listaPoImenu.Count == 0)
            {
                Console.WriteLine("Nema korisnika s tim imenom");
                throw new Exception();
            }
            else
                return listaPoImenu;

        }

    }
}