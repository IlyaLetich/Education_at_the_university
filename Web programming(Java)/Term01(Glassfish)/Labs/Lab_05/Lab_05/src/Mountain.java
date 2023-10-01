import java.util.concurrent.Semaphore;

public class Mountain {
    Semaphore semaphore;

    public Mountain(Semaphore semaphore) {
        this.semaphore = semaphore;
    }

    public void drive(int id, String status) throws InterruptedException {
        semaphore.acquire();
        System.out.println("Skier " + id + " Started");
        Thread.sleep(700);
        System.out.println("Skier " + id + " Finich");
        semaphore.release();
    }
}
