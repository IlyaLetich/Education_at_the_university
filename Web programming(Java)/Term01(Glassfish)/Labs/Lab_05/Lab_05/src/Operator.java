public class Operator {
    synchronized void startConversation(int i) throws InterruptedException {
        System.out.println("Client " + i + " started");
        Thread.sleep(500);
        System.out.println("Client " + i + " finished");
    }
}
