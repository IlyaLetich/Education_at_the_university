package by.Bank.BankAccount;

public class RubBankAccount extends BankAccount {
    {
        type = EType.rubl;
    }
    public RubBankAccount(double sum, String fio)
    {
        super(sum,fio);
    }

    @Override
    public void checkBalance() {

        System.out.println("Balance = " + balance + "Rub");
    }
}
