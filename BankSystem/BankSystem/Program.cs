using BankSystem;
using BankSystem.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        Bank banka = new Bank();
        banka.CreateAccount(new CheckingAccount(3, 12000, "Mateo Majic", 1000));
        banka.CreateAccount(new SavingsAccount(9, 50000, "Marin Grkovic", (decimal)0.1));
        banka.CreateAccount(new LoanAccount(10, 70000, "Marin Grkovic",1000, (decimal)0.1));
        banka.CreateAccount(new CheckingAccount(19, 19000, "Kristijan Nikolic", 500));
        banka.CreateAccount(new SavingsAccount(1, 10000, "Toni Radanovic", (decimal)0.17));
        banka.DisplayAccountInfo(19); //vraca Kiku
        //banka.DisplayAccountInfo(13); //error jer ID ne postoji
        //banka.WithdrawFromAccount(12, 10000);
        //banka.DisplayAccountInfo(12);
        //banka.WithdrawFromAccount(12, 10000); //error jer mateo nema vise para na racunu LOL
        banka.DepositToAccount(9, 10000);
        banka.DisplayAccountInfo(9);
        //banka.DepositToAccount(0, 10000); //error jer ID ne postoji
        Console.WriteLine("----------------------------------------------");
        banka.CloseAccount(19);
        //banka.GetAccountById(19);//baca error jer taj account vise ne postoji
        List<BankAccount> listaNajsiromasnijih = banka.LeastWealthy();
        foreach (BankAccount account in listaNajsiromasnijih)
            account.DisplayAccountInfo(); //izbacuje Ratka jer je najsiromasniji
        Console.WriteLine("----------------------------------------------");
        List<BankAccount> listaOnihSaM=banka.AllAccountsStartingWithM();
        foreach (BankAccount account in listaOnihSaM)
            account.DisplayAccountInfo(); //izbacuje Marina i Matea
        Console.WriteLine("----------------------------------------------");
        List<BankAccount> lista2 = banka.FromHigherToLower();
        foreach (BankAccount account in lista2)
            account.DisplayAccountInfo(); //izbacuje sve od najveceg bogatsva prema najmanjem
        Console.WriteLine("----------------------------------------------");
        List<BankAccount> listaMarina=banka.GetFirstNAccounts("Marin Grkovic", 2); //vraca prva dva marinova accounta, da je ime pogresno vracao bi se error
        foreach (BankAccount account in listaMarina)
            account.DisplayAccountInfo();
        Console.WriteLine("----------------------------------------------");


    }
}