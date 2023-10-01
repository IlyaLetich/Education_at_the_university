import by.Bank.Bank;
import by.Person.Admin;
import by.Person.User;
import org.apache.log4j.LogManager;
import org.apache.log4j.xml.DOMConfigurator;
import org.apache.log4j.Logger;

public class Main{

    static{
        new DOMConfigurator().doConfigure("log/log4j.xml",
                LogManager.getLoggerRepository());
    }
    private static final Logger LOG = Logger.getLogger(Main.class);
    public static void main(String[] args)
    {
        try {
            LOG.info("Hello my frend");
            Bank bank = new Bank("AlphaBank");
            Admin admin = new Admin(bank);

            User user_01 = new User("Ivan", "Ivanov", "Ivanovich");

            user_01.createBankAccount(bank);
            user_01.depositBalance(0, 1000);
            user_01.depositBalance(0, 1000);
            user_01.checkBalance(0);
            user_01.createCard(0);
            user_01.makePay(0, 100);
            user_01.checkBalance(0);

            admin.Blocked(0);
            user_01.makePay(0, 100);
            admin.FindID(0);
        }
        catch (Exception ex){
            System.out.println(ex.getMessage());
        }
    }
}