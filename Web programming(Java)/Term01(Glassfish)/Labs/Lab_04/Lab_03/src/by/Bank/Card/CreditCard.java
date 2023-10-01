package by.Bank.Card;

import by.Bank.Bank;
import by.Bank.BankAccount.BankAccount;

public class CreditCard extends Card{
    public CreditCard(BankAccount bankAccountUser)
    {
        this.fioCard = bankAccountUser.getFio();
        bankAccount = bankAccountUser;
        this.numberCard = Bank.countCardID;
        Bank.countCardID++;
    }
    public CreditCard()
    {
        this.numberCard = Bank.countCardID;
        Bank.countCardID++;
    }
    @Override
    public void pay(double sum) {
        System.out.println("Pay credit card");
        this.bankAccount.pay(sum);
    }
}
