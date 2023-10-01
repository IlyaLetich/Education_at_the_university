package by.Bank.Card;

import by.Bank.Bank;
import by.Bank.BankAccount.BankAccount;

public class DebitCard extends Card{
    public DebitCard(BankAccount bankAccountUser)
    {
        this.fioCard = bankAccountUser.getFio();
        bankAccount = bankAccountUser;
        this.numberCard = Bank.countCardID;
        Bank.countCardID++;
    }
    @Override
    public void pay(double sum) {
        System.out.println("Pay debit card");
        this.bankAccount.pay(sum);
    }
}
