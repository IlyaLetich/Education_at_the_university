package by.Bank.BankAccount;

import by.Bank.Bank;
import by.Bank.Card.Card;

import java.util.ArrayList;
import java.util.Objects;

public abstract class BankAccount {
    public ArrayList<Card> listCard = new ArrayList<Card>();
    EType type = null;
    public String status = "unblocked";
    public int id;
    private String fio;

    @Override
    public String toString()
    {
        System.out.println("Type = " + type + " # Status = " + status + " # FIO = " + fio);
        return "Type = " + type + " # Status = " + status + " # FIO = " + fio;
    }

    public String getFio() {
        return fio;
    }

    public void setFio(String fio) {
        this.fio = fio;
    }

    public double balance;

    public void blockCard() {
        if(Objects.equals(status, "blocked")) return;
        status = "blocked";
    }
    public abstract void checkBalance();
    public void pay(double sum) {
        if(this.status != "blocked") {
            if(sum <= balance) {
                this.balance -= sum;
                System.out.println("- " + sum);
            }
            else System.out.println("Error: Balance < sum");
        }
        else {
            System.out.println("Error: Status BankAccount = blocked");
        }
    }
    public void depositBalance(double sum) {
        balance += sum;
    }

    public BankAccount(double sum, String fio)
    {
        this.fio = fio;
        balance = sum;
        this.id = Bank.countBankAccountID;
        Bank.countBankAccountID++;
    }
}
