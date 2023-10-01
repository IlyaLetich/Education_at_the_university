public class Skier implements Runnable{

    int id;
    Mountain mountain;
    String status;

    public Skier(int id, Mountain mountain, String status) {
        this.id = id;
        this.mountain = mountain;
        this.status = status;
    }

    @Override
    public void run() {
        try {
            Thread.sleep(700);
            if (status != "invalid") {
                System.out.println("Уступил " + id);
                Thread.yield();
            }
            mountain.drive(id,status);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }
}
