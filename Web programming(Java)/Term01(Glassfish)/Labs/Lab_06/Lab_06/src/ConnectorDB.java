import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;
import org.apache.log4j.xml.DOMConfigurator;

import java.sql.*;
import java.util.ResourceBundle;

public class ConnectorDB implements IJDBCConnection, IJDBCDeleteConnection, ICloseStatement{
    static{
        new DOMConfigurator().doConfigure("log/log4j.xml",
                LogManager.getLoggerRepository());
    }
    private static final Logger LOG = Logger.getLogger(ConnectorDB.class);
    Connection connection;
    String url;
    String user;
    String pass;

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public String getUser() {
        return user;
    }

    public void setUser(String user) {
        this.user = user;
    }

    public String getPass() {
        return pass;
    }

    public void setPass(String pass) {
        this.pass = pass;
    }
    public ConnectorDB(String url, String user, String pass) {
        this.url = url;
        this.user = user;
        this.pass = pass;
    }
    public void getConnection() throws SQLException {
        connection = DriverManager.getConnection(url, user, pass);
        if (!connection.isClosed())
            System.out.println("Подключение прошло успешно");
        LOG.info("Подключение успешно");
    }

    public void removeConnection() throws SQLException {
        System.out.println("Подключение удалено");
        connection.close();
        LOG.info("Подключение удалено");
    }

    public void getInfoOrder(int number) throws SQLException {
        System.out.println("=======================================");
        String request = "select * from orderinfo inner join ordertable on orderinfo.idOrder = ordertable.idorder where orderinfo.idOrder = ?";
        PreparedStatement preparedStatement = connection.prepareStatement(request);
        preparedStatement.setString(1, String.valueOf(number));
        ResultSet resultSet = preparedStatement.executeQuery();
        System.out.println("Ифнормация о заказе - " + number);
        while(resultSet.next()){
            int article = resultSet.getInt(2);
            int count = resultSet.getInt(3);
            String date = resultSet.getString(5);
            System.out.println("Артикул товара - " + article + " # Количество - " + count + " # Дата заказа - " + date);
        }
        System.out.println("=======================================");
    }
    public void getOrderNotExistsProductAndExistsDate(int number,String dateOrd) throws SQLException {
        System.out.println("=======================================");
        String request = "select * from orderinfo inner join ordertable on orderinfo.idOrder = ordertable.idorder and product != ? and dateOrder = ?";
        PreparedStatement preparedStatement = connection.prepareStatement(request);
        preparedStatement.setInt(1, number);
        preparedStatement.setString(2,dateOrd);
        ResultSet resultSet = preparedStatement.executeQuery();
        System.out.println(number + " продукт не содержат и в введённой дате соответствуют следующие заказы : ");
        while(resultSet.next()){
            int article = resultSet.getInt(1);
            System.out.println("Заказ " + article);
        }
        System.out.println("=======================================");
    }
    public void getOrderOnArticle(int number) throws SQLException {
        System.out.println("=======================================");
        String request = "select * from orderinfo where Product = ?";
        PreparedStatement preparedStatement = connection.prepareStatement(request);
        preparedStatement.setString(1, String.valueOf(number));
        ResultSet resultSet = preparedStatement.executeQuery();
        System.out.println(number + " продукт содержат следующие заказы : ");
        while(resultSet.next()){
            int article = resultSet.getInt(1);
            System.out.println("Заказ " + article);
        }
        System.out.println("=======================================");
    }

    public void getOrderSum(int number) throws SQLException {
        String request = "SELECT idOrder FROM orderinfo join product on orderinfo.Product = product.Article Group By idOrder HAVING  sum(CountProduct * Price) > ?;";
        PreparedStatement preparedStatement = connection.prepareStatement(request);
        preparedStatement.setString(1, String.valueOf(number));
        ResultSet resultSet = preparedStatement.executeQuery();
        System.out.println("=======================================");
        System.out.println("Заказы сумма которых больше "  + number +  " : ");
        while(resultSet.next()){
            int article = resultSet.getInt(1);
            System.out.println("Заказ " + article);
        }
        System.out.println("=======================================");
    }

    public void deleteOrderByCountProduct(int number) throws SQLException {
        System.out.println("=======================================");
        Connection connectionTOrderInfo = DriverManager.getConnection(
                "jdbc:mysql://localhost:3307/java", "root", "root");
        connectionTOrderInfo.setAutoCommit(false);
        Connection connectionTOrderTable = DriverManager.getConnection(
                "jdbc:mysql://localhost:3307/java", "root", "root");
        connectionTOrderTable.setAutoCommit(false);
        try {
            if (!connectionTOrderInfo.isClosed() && !connectionTOrderTable.isClosed()) {
                String request = "select idOrder from orderinfo where CountProduct = ?;";
                PreparedStatement preparedStatement = connectionTOrderInfo.prepareStatement(request);
                preparedStatement.setString(1, String.valueOf(number));
                ResultSet resultSet = preparedStatement.executeQuery();
                PreparedStatement preparedStatement_01 = connectionTOrderInfo.prepareStatement("delete from orderinfo where idOrder = ?;");
                PreparedStatement preparedStatement_02 = connectionTOrderTable.prepareStatement("delete from ordertable where idorder = ?;");
                while (resultSet.next()) {
                    int idOrder = resultSet.getInt(1);
                    preparedStatement_01.setInt(1, idOrder);
                    preparedStatement_02.setInt(1, idOrder);
                    preparedStatement_01.execute();
                    preparedStatement_02.execute();
                }
                connectionTOrderInfo.commit();
                connectionTOrderTable.commit();
            }
        } catch (SQLException e) {
            connectionTOrderInfo.rollback();
            connectionTOrderTable.rollback();
        }
        System.out.println("=======================================");
    }

    public  void repietOrder(int numberOrder, String dateOrderP) throws SQLException {
        System.out.println("=======================================");
        String request = "SELECT product, countProduct FROM ordertable inner join orderinfo where dateOrder = ?";
        PreparedStatement preparedStatement = connection.prepareStatement(request);
        preparedStatement.setString(1, dateOrderP);
        ResultSet resultSet = preparedStatement.executeQuery();
        preparedStatement = connection.prepareStatement("INSERT INTO ordertable (idorder,dateOrder) VALUES (?,?)");
        preparedStatement.setInt(1,numberOrder);
        preparedStatement.setString(2,dateOrderP);
        preparedStatement.execute();
        while(resultSet.next()){
            int article = resultSet.getInt(1);
            int count = resultSet.getInt(2);
            preparedStatement =
                    connection.prepareStatement("INSERT INTO orderinfo (idOrder, Product, CountProduct) VALUES (?,?,?)");
            preparedStatement.setInt(1,numberOrder);
            preparedStatement.setInt(2,article);
            preparedStatement.setInt(3,count);
            preparedStatement.execute();
        }
        System.out.println("=======================================");
    }

    public void closeStatement(Statement statement) throws SQLException {
        statement.close();
    }
}
