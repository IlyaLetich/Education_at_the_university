package by.Person;

import by.Bank.BankAccount.*;
import by.Bank.Card.*;
import by.Bank.Bank;

import java.util.ArrayList;
import java.util.Scanner;

public class User {
    String name;
    String secondName;
    String fatherName;
    ArrayList<Card> cards = new ArrayList<Card>();
    ArrayList<BankAccount> banks = new ArrayList<BankAccount>();

    public User(String name, String secondName, String fatherName) {
        this.name = name;
        this.secondName = secondName;
        this.fatherName = fatherName;
    }

    public void makePay(int numberCard, double sum)
    {
        for(Card item : cards) {
            if(numberCard == item.numberCard) {
                item.pay(sum);
            }
        }
    }
    public void checkBalance(int idAccount)
    {
        for(BankAccount item: banks) {
            if(item.id == idAccount) item.checkBalance();
        }
    }

    public void checkBalanceDollarInRubl(int idAccount)
    {
        for(BankAccount item: banks) {
            if(item.id == idAccount)
                if(item instanceof DollarBankAccount)
                {
                   ((DollarBankAccount) item).printDollarInRubl();
                }
        }
    }

    public void depositBalance(int idAccount, double sum)
    {
        for(BankAccount item: banks) {
            if(item.id == idAccount) item.depositBalance(sum);
        }
    }
    public void blockedAccount(int idAccount)
    {
        for(BankAccount item: banks) {
           if(item.id == idAccount) item.status = "blocked";
        }
    }

    public void createBankAccount(Bank bank)
    {
        Scanner in = new Scanner(System.in);
        System.out.println("Enter type BankAccount: \n1) DollarBankAccount\n2) RubBankAccount");
        int userBank = Integer.parseInt(in.nextLine());
        switch (userBank) {
            case 1:
                DollarBankAccount dollarBankAccount = new DollarBankAccount(0,(this.name + " " + this.secondName + " " + this.fatherName));
                bank.bankAccounts.add(dollarBankAccount);
                banks.add(dollarBankAccount);
                break;
            case 2:
                RubBankAccount rubBankAccount = new RubBankAccount(0,(this.name + " " + this.secondName + " " + this.fatherName));
                banks.add(rubBankAccount);
                bank.bankAccounts.add(rubBankAccount);
                break;
            default:
                System.out.println("Error: incorrect write");
        }

    }

    public void createCard(int idBank)
    {
        for(var item : banks) {
            if(item.id == idBank) {
                Scanner in = new Scanner(System.in);
                System.out.println("Enter type Card: \n1) Credit card\n2) Debit card");
                int userCard = Integer.parseInt(in.nextLine());
                switch (userCard) {
                    case 1:
                        CreditCard creditCard = new CreditCard(item);
                        item.listCard.add(creditCard);
                        cards.add(creditCard);
                        break;
                    case 2:
                        DebitCard debitCard = new DebitCard(item);
                        item.listCard.add(debitCard);
                        cards.add(debitCard);
                        break;
                    default:
                        System.out.println("Error: incorrect write");
                }
            }
        }
    }
}
