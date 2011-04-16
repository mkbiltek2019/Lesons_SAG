/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package DAL;

import java.sql.*;

/**
 *
 * @author manekovskiy
 */
public class DbConnectionProvider
{
    private static final String dbDriverClassName = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
    private static final String connectionString = "jdbc:sqlserver://localhost:1433;DatabaseName=ClientRegistry";

    private static final String login = "sa";
    private static final String password= "123456";

    public static Connection GetConnection() throws SQLException, ClassNotFoundException {
        Class.forName(dbDriverClassName);
        return DriverManager.getConnection(connectionString, login, password);
    }
}
