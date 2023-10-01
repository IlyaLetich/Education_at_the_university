using Lab_17_18;
using Lab_19_20;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        Client client = new Client("Ded Moroz");
        Admin admin = new Admin();
        BankAccount bankAccount_01 = bank.CreateBankAccount(client.name);
        //AbstractFabrik
        bankAccount_01.CreateCreditDollarCard(client.name);
        bankAccount_01.CreateCreditBitcoinCard(client.name);
        bankAccount_01.CreateDebitDollarCard(client.name);
        bankAccount_01.CreateDebitBitcoinCard(client.name);

        bankAccount_01.WriteInfoCard();

        client.depositMoneyInTheBankAccounts(bankAccount_01, 100);
        Console.WriteLine(bankAccount_01.ToString());

        //client.BlockedBankAccount(bankAccount_01);
        client.makePayment(bankAccount_01, 10);
        Console.WriteLine(bankAccount_01.ToString());

        Console.WriteLine("--------------------------------------");
        //Prototype
        ICard card_01 = new Card(new CreditDollarFactory(), "Card1");
        ICard card_02 = card_01.Clone();

        card_02.ShowCardInfo();

        //Builder

        Cardener carder = new Cardener();

        CardBuilder builder = new CreditDollarBuilder();

        Console.WriteLine("--------------------------------------");
        Card card_03 = carder.CreateCard(builder);
        card_03.ShowCardInfo();


        //Decorator
        Console.WriteLine("--------------------------------------");
        BankAccount information = new DollarBankAccount(bankAccount_01);
        information.WriteMoney();

        //Adapter
        client.BlockedBankAccount(bankAccount_01);

        ComputerChanel computerChanel = new ComputerChanel();

        ClientToAdminAdapter clientToAdminAdapter = new ClientToAdminAdapter(client);

        computerChanel.UnblockBankAccount(clientToAdminAdapter, bankAccount_01);

        //Command
        Console.WriteLine("--------------------------------------");

        ComputerClient computerClient = new ComputerClient();
        BankAccountOnCommandBank commandBank = new BankAccountOnCommandBank(bankAccount_01);
        computerClient.SetCommand(commandBank);
        computerClient.PressBlock();
        computerClient.PressUnBlock();

        //Observer
        Console.WriteLine("--------------------------------------");

        BankObservable bankObservable = new BankObservable();
        BankAccount bankAccount_02 = new BankAccount("777","Lexa",1000,bankObservable);
        bankObservable.AddObserver(client);
        bankObservable.AddObserver(admin);

        bankAccount_02.AddMoney(1000);

        //Memento
        Console.WriteLine("--------------------------------------");

        BankHistory bankHistory = new BankHistory();
        Console.WriteLine(bankAccount_02.ToString());

        Console.WriteLine();
        bankHistory.Save(bankAccount_02.SaveState());
        bankAccount_02.AddMoney(1000000);
        Console.WriteLine(bankAccount_02.ToString());
        Console.WriteLine();

        bankAccount_02.RestoreState(bankHistory.History.Pop());
        Console.WriteLine(bankAccount_02.ToString());
    }
}