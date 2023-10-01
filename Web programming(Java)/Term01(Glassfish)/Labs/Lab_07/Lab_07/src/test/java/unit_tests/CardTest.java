package unit_tests;

import org.example.BankAccount;
import org.example.Card;
import org.testng.Assert;
import org.testng.annotations.*;

public class CardTest {

    Card card;
    @BeforeSuite
    public void startTest(){
        System.out.println("Test started");
    }
    @BeforeTest
    public void startClassTest(){
        System.out.println("Test class Card start");
    }
    @BeforeClass
    public void beforeTest() {
        card = new Card("Ilya",0,"null");
        System.out.println("Class created");
    }
    @Test(dataProvider = "testUpBalance")
    public void testUpBalance(float sum, float resultSum){
        this.card.balance = 0;
        this.card.upBalance(sum);
        Assert.assertEquals(this.card.balance,resultSum);
    }
    @Test(groups = "upBalanceAndUnblock")
    public void testBalance(){
        this.card.upBalance(1000);
        Assert.assertEquals(this.card.balance,2000);
    }
    @BeforeMethod
    public void mnogoDeneg(){
        this.card.balance = 1000;
    }
    @Test(groups = "upBalanceAndUnblock")
    public void testUnblpcked(){
        this.card.unblock();
    }

    @Test(dependsOnGroups = "upBalanceAndUnblock", dataProvider = "dollar", timeOut = 100)
    public void testPay(float sum, String status ,float paySum,float result){
        this.card.balance = 0;
        this.card.status = status;
        this.card.upBalance(paySum);
        this.card.pay(sum);
        Assert.assertEquals(this.card.balance,result);
    }

    @DataProvider(name = "testUpBalance")
    public Object[][] createData1() {
        return new Object[][] {
                {1000,1000},
                {2000,2000},
                {12,12},
        };
    }
    @DataProvider(name = "dollar")
    public Object[][] createData2() {
        return new Object[][] {
                {10000,"unblocked",1000,1000},
                {777,"blocked",1000,1000},
                {777,"unblocked",1000,223},
        };
    }

    @Test
    public void TestCardAndBank(){
        float result = card.balance;
        BankAccount bankAccount = new BankAccount("Ilya",1000);
        result += 1000;
        bankAccount.addCard(card);
        Assert.assertEquals(bankAccount.balance,result);
        Assert.assertEquals(bankAccount.cards.size(),1);
    }

    @Ignore
    @Test
    public void testIgnore(){
        System.out.println("Test ignored");
    }

    @Test
    public void blockedTest(){
        this.card.block();
        Assert.assertEquals(this.card.status,"blocked");
    }
    @Test(dependsOnMethods = "blockedTest")
    public void unblockedTest(){
        this.card.unblock();
        Assert.assertEquals(this.card.status,"unblocked");
    }


    @AfterClass
    public void endClass(){
        System.out.println("Class Card test successfully");
    }
    @AfterSuite
    public void endTestSuite(){
        System.out.println("Test suite successfully");
    }
    @AfterTest
    public void endTest(){
        System.out.println("Test successfully");
    }
}
