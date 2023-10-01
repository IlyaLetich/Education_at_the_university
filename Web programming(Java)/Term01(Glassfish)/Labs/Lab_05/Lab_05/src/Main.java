import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Semaphore;
import java.util.concurrent.locks.ReentrantLock;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        // - - - - - - - Task_01 (1) - - - - - - -
        /*
        Operator operator = new Operator();
        for(int i = 0; i < 10; i++){
            new Thread(new Client(i,operator)).start();
        }
        */
        // - - - - - - - Task_01 (2) - - - - - - -
        /*
        Semaphore semaphore = new Semaphore(2);
        Mountain mountain = new Mountain(semaphore);
        for(int i = 0; i < 30; i++){
            if(i%5 == 0)
                new Thread(new Skier(i,mountain,"invalid")).start();
            else new Thread(new Skier(i,mountain,"not invalid")).start();
        }
         */
        // - - - - - - - Task_02 (1) - - - - - - -
        /*
        ReentrantLock locker = new ReentrantLock();
        Road road = new Road(locker);
        new Thread(new Car(road,"Right")).start();
        new Thread(new Car(road,"Left")).start();
        */
        // - - - - - - - Task_02 (2) - - - - - - -

        final int NUMBER_OF_CARS = 10;
        final int FIRST_PARKING =3 ;
        final int SECOND_PARKING = 4;
        Parking first_parking = new Parking(1, FIRST_PARKING);
        Parking second_parking = new Parking(2, SECOND_PARKING);
        Semaphore first = new Semaphore(first_parking.getSize(), true);
        Semaphore second = new Semaphore(second_parking.getSize(), true);
        ExecutorService service = Executors.newCachedThreadPool();
        for (int number = 1; number <= NUMBER_OF_CARS; ) {
            service.execute(new Car2(first_parking, first, number++));
            service.execute(new Car2(second_parking, second, number++));
        }
        service.shutdown();

    }
}