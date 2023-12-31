package by.Ilya.p2p.async;

import javax.jms.*;

import by.Ilya.p2p.Message;
import com.sun.messaging.ConnectionFactory;
import com.sun.messaging.ConnectionConfiguration;

import java.util.Date;

public class Sender {
    public static void main(String[] args){
        ConnectionFactory factory= new com.sun.messaging.ConnectionFactory();
        try(JMSContext context = factory.createContext("admin", "admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList,
                    "mq://127.0.0.1:7676,mq://127.0.0.1:7676");
            Destination messagesQueue = context.createQueue("BrokerDestination");
            by.Ilya.p2p.Message message = new Message("Привет я в прямом эфиреее", new Date());
            ObjectMessage objMsg = context.createObjectMessage(message);
            JMSProducer producer = context.createProducer();
            producer.send(messagesQueue, objMsg);
            System.out.println("message sent");
        } catch (JMSException e) {
            System.out.println("ConnectionConfigurationError: " + e.getMessage());
        }
    }
}