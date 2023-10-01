using Lab_17_18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lab_19_20
{
    public interface IAdmin
    {
        public void UnBlock(BankAccount bankAccount);
    }

    internal class Admin : IAdmin, IObserver
    {
        PostAdmin admin;

        public Admin()
        {
            admin = PostAdmin.GetInstance();
        }
        public void UnBlock(BankAccount bankAccount)
        {
            admin.UnBlockedBankAccount(bankAccount);
        }

        public void Update(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class ComputerChanel
    { 
        public void  UnblockBankAccount(IAdmin admin, BankAccount bankAccount)
        {
            admin.UnBlock(bankAccount);
        }
    }

    class ClientToAdminAdapter : IAdmin
    {
        Client client;
        public ClientToAdminAdapter(Client client)
        {
            this.client = client;
        }

        public void UnBlock(BankAccount bankAccount)
        {
            client.UnBlockedBankAccount(bankAccount);
        }
    }
}
