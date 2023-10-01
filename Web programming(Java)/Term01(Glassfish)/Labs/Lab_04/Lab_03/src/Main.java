import by.Bank.Bank;
import by.Bank.BankAccount.DollarBankAccount;
import by.Bank.Card.Card;
import by.Bank.Card.CreditCard;
import by.DemoBankAccountHandler;
import by.Person.Admin;
import by.Person.User;
import by.ValidatorSAX;
import com.google.gson.Gson;
import org.apache.log4j.LogManager;
import org.apache.log4j.xml.DOMConfigurator;
import org.apache.log4j.Logger;
import org.xml.sax.SAXException;
import org.xml.sax.XMLReader;
import org.xml.sax.helpers.XMLReaderFactory;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class Main{

    static{
        new DOMConfigurator().doConfigure("log/log4j.xml",
                LogManager.getLoggerRepository());
    }
    private static final Logger LOG = Logger.getLogger(Main.class);
    public static void main(String[] args) throws IOException
    {
        try {

            LOG.info("Hello my frend");
            Bank bank = new Bank("AlphaBank");
            Admin admin = new Admin(bank);

            User user_01 = new User("Ivan", "Ivanov", "Ivanovich");

            user_01.createBankAccount(bank);
            user_01.createBankAccount(bank);
            user_01.createBankAccount(bank);
            user_01.depositBalance(0, 1000);
            user_01.depositBalance(1, 700);
            user_01.depositBalance(2, 100);
            user_01.checkBalance(0);
            user_01.createCard(0);
            user_01.makePay(0, 100);
            user_01.checkBalance(0);

            admin.Blocked(0);
            user_01.makePay(0, 100);
            admin.FindID(0);


            ValidatorSAX validatorSAX = new ValidatorSAX();
            validatorSAX.valid();

            try {
                XMLReader reader = XMLReaderFactory.createXMLReader();
                DemoBankAccountHandler handler = new DemoBankAccountHandler();
                reader.setContentHandler(handler);
                reader.parse("xml/data.xml"); //запускаем
            }
            catch (SAXException e) {
                System.out.print("ошибка SAX парсера " + e);
            } catch (IOException e) {
                System.out.print("ошибка I/О потока " + e);
            }

            DollarBankAccount bankAccount = new DollarBankAccount(1000,"Ya chelovek");
            Gson gson = new Gson();
            String jsonString2 = gson.toJson(bankAccount);

            System.out.println(jsonString2);
            FileOutputStream fileOutputStream = new FileOutputStream(new File("xml/data.json"));
            fileOutputStream.write(jsonString2.getBytes());
            fileOutputStream.close();

            String deser= "";
            FileInputStream fileInputStream = new FileInputStream(new File("xml/data.json"));
            int i;
            while((i=fileInputStream.read())!= -1){
                deser += (char)i;
            }
            fileInputStream.close();
            DollarBankAccount bankAccountDes = gson.fromJson(deser, DollarBankAccount.class);
            System.out.println(bankAccountDes.toString());

            bank.bankAccounts.stream().filter(s -> s.balance > 700).forEach(System.out::println);

        }
        catch (Exception ex){
            System.out.println(ex.getMessage());
        }
    }
}