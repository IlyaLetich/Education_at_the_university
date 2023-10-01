package by.Bank.BankAccount;

import by.Bank.Bank;

public class DollarBankAccount extends BankAccount implements IBankAccout{
    {
        type = EType.dollar;
    }
    public DollarBankAccount(double sum, String fio)
    {
        super(sum,fio);
    }

    @Override
    public void checkBalance() {

        System.out.println("Balance = " + balance + "$");
    }

    public void printDollarInRubl()
    {
        Converter converter = new Converter();
        converter.perevodFromDollarInRubl();
    }

    public class Converter
    {
        void perevodFromDollarInRubl()
        {
            System.out.println("Dollar: " + balance + " = Rubl:" + balance/2);
        }
    }

    @Override
    public String toString()
    {
        return this.id + " # " + this.balance + " # " + this.type;
    }
}
