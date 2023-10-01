package org.example;

import java.util.ArrayList;
import java.util.List;

public class BankAccount {
    public ArrayList<Card> cards;
    public String FIO;
    public float balance;

    public BankAccount(String FIO, float balance) {
        this.FIO = FIO;
        this.balance = balance;
        this.cards = new ArrayList<>();
    }

    public void addCard(Card card){
        cards.add(card);
        this.balance += card.balance;
    }
}
