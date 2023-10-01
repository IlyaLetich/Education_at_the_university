using Lab_17_18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_19_20
{
    internal class Client : IObserver
    {
        public string name;
        
        public Client(string name)
        {
            this.name = name;
        }

        public void depositMoneyInTheBankAccounts(BankAccount bankAccount, double money)
        {
            bankAccount.AddMoney(money);
        }

        public void makePayment(BankAccount bankAccount, double money)
        {
            bankAccount.RemoveMoney(money);
        }
        public void BlockedBankAccount(BankAccount bankAccount)
        {
            bankAccount.Blocked();
        }

        public void UnBlockedBankAccount(BankAccount bankAccount)
        {
            Console.WriteLine("The bank account has been successfully unblocked");
            bankAccount.status = "unblocked";
        }

        public void Update(string message)
        {
            Console.WriteLine(message);
        }
    }
}
