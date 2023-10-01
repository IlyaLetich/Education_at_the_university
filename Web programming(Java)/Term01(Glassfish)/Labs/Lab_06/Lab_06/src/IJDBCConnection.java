import java.sql.DriverManager;
import java.sql.SQLException;

public interface IJDBCConnection {
    void getConnection() throws SQLException;
}
