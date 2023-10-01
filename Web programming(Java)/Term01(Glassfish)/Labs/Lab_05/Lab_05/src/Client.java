public class Client implements Runnable{
    public int id;
    public Operator operator;
    public Client(int id, Operator operator){
        this.id = id;
        this.operator = operator;
    }
    @Override
    public void run() {
        try {
            operator.startConversation(id);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }
}
