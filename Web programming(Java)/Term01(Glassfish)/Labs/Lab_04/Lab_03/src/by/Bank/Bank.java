package by.Bank;

import by.Bank.BankAccount.BankAccount;

import java.util.ArrayList;

public class Bank {
    String name;
    public Bank(String name)
    {
        this.name = name;
    }
    public ArrayList<BankAccount> bankAccounts = new ArrayList<BankAccount>();

    public static int countCardID = 0;
    public static int countBankAccountID = 0;
}
