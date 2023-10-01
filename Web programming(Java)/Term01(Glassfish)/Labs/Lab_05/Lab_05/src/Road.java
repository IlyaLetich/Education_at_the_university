import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.ReentrantLock;

class Road{
    private int countCar = 0;
    Condition condition;
    ReentrantLock lock;
    public Road(ReentrantLock lock){
        this.lock = lock;
        condition = lock.newCondition();
    }
    public void driveLeft() throws InterruptedException {
        lock.lock();
        while (countCar < 1) {
            condition.await();
        }
        countCar--;
        System.out.println("Left Car start drive");
        Thread.sleep(300);
        System.out.println("Left Car end drive");
        condition.signalAll();
    }
    public void driveRight() throws InterruptedException {
        lock.lock();
        while (countCar >= 3) {
            condition.await();
        }
        countCar++;
        System.out.println("Right Car start drive");
        Thread.sleep(300);
        System.out.println("Right Car end drive");
        condition.signalAll();
    }
}