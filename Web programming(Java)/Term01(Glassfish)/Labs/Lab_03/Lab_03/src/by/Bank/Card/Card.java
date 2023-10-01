package by.Bank.Card;

import by.Bank.BankAccount.BankAccount;

public abstract class Card {
    public int numberCard;
    String fioCard;
    BankAccount bankAccount;
    public abstract void pay(double sum);
}
