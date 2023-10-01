import java.util.concurrent.locks.ReentrantLock;

public class Car implements Runnable{
    public String direction;
    Road road;
    public Car(Road road, String direction){
        this.road=road;
        this.direction = direction;
    }
    public void run(){
        for (int i = 1; i < 6; i++) {
            if(direction == "Right") {
                try {
                    road.driveRight();
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
            else if(direction == "Left") {
                try {
                    road.driveLeft();
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
            }
        }
    }
}