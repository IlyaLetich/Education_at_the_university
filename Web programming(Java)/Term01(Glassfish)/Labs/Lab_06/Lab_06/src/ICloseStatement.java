import java.sql.SQLException;
import java.sql.Statement;

public interface ICloseStatement {
    void closeStatement(Statement statement) throws SQLException;
}
