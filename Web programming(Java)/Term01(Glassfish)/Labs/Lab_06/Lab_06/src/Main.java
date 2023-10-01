import org.apache.log4j.Logger;

import java.sql.*;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws SQLException {
        ConnectorDB connectorDB = new ConnectorDB("jdbc:mysql://localhost:3307/Java","root", "root");
        connectorDB.getConnection();

        //connectorDB.getOrderSum(25000);
        //connectorDB.getInfoOrder(7);
        //connectorDB.getOrderOnArticle(1);
        //connectorDB.deleteOrderByCountProduct(100);
        connectorDB.repietOrder(10,"2023-12-03");
        //connectorDB.getOrderNotExistsProductAndExistsDate(3,"2023-12-03");
        connectorDB.removeConnection();

    }
}