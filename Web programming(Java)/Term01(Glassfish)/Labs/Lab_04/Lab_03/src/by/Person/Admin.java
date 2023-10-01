package by.Person;

import by.Bank.Bank;

public class Admin {
    Bank bank;

    public Admin(Bank bank)
    {
        this.bank = bank;
    }

    public void Blocked(int id)
    {
        for(var item : bank.bankAccounts)
        {
            if(id == item.id)
                item.status = "blocked";
        }
    }

    public void FindID(int id)
    {
        for(var item : bank.bankAccounts)
        {
            if(id == item.id)
                item.toString();
        }
    }
}
