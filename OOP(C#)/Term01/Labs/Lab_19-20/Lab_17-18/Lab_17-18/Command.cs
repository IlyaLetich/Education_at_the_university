using Lab_19_20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_17_18
{
    public interface CommandBank
    {
        public void Blocked();
        public void UnBlocked();
    }

    public class BankAccountOnCommandBank : CommandBank
    {
        BankAccount bankAccount;

        public BankAccountOnCommandBank(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }

        public void Blocked()
        {
            bankAccount.Blocked();
        }
        public void UnBlocked()
        {
            bankAccount.UnBlocked();
        }
    }

    public class ComputerClient
    {
        CommandBank commandBank;

        public void SetCommand(CommandBank commandBank)
        {
            this.commandBank = commandBank;
        }

        public void PressBlock()
        {
            if (commandBank != null)
                commandBank.Blocked();
        }
        public void PressUnBlock()
        {
            if (commandBank != null)
                commandBank.UnBlocked();
        }
    }


}
