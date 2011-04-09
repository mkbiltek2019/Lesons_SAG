/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package jdbcclientregistry;

import java.sql.*;

/**
 *
 * @author manekovskiy
 */
public class Main {

    public Connection dbConnect(String db_connect_string,
            String db_userid,
            String db_password) {
        Connection result = null;


        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");

            result = DriverManager.getConnection(
                    db_connect_string,
                    db_userid,
                    db_password);
        } catch (Exception e) {
            e.printStackTrace();
        }

        return result;
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) throws SQLException {
        Main program = new Main();
        Connection connection = program.dbConnect(
                "jdbc:sqlserver://localhost:1433;DatabaseName=ClientRegistry",
                "sa",
                "123456");

        System.out.println("connected");

        Statement createStatement = connection.createStatement();
        String queryString = "select FirstName from Client";
        System.out.println(queryString);
        ResultSet rs = createStatement.executeQuery(queryString);
        while (rs.next()) {
            System.out.println(rs.getString(1));
        }

        try {
            // средство управления транзакциями
            connection.setAutoCommit(false);

            String insertIntoClient =
                    "INSERT INTO Client(FirstName, LastName, Gender, Age)" +
                    "VALUES(?, ?, ?, ?)";

            System.out.println(insertIntoClient);
            PreparedStatement insertstatement = connection.prepareStatement(insertIntoClient);
            insertstatement.setString(1, "WowWOWOWOW1");
            insertstatement.setString(2, "Wow1");
            insertstatement.setBoolean(3, true);
            insertstatement.setInt(4, 11);

            insertstatement.executeUpdate();
            Savepoint savePoint = connection.setSavepoint("After_insert_Before_insert2");

            PreparedStatement insertstatement2 = connection.prepareStatement(insertIntoClient);
            insertstatement2.setString(1, "WowWOWOWOW2");
            insertstatement2.setString(2, "Wow2");
            insertstatement2.setBoolean(3, false);
            insertstatement2.setInt(4, 11);

            insertstatement2.executeUpdate();

            connection.rollback(savePoint);

            connection.commit();
            connection.setAutoCommit(true);

            String spName = "EXECUTE [ClientRegistry].[dbo].[Client.GetById] ?";
            System.out.println(spName);
            CallableStatement getById = connection.prepareCall(spName);
            getById.setInt(1, 1);

            ResultSet selectResult = getById.executeQuery();
            while (selectResult.next()) {
                System.out.println(selectResult.getString(2));
            }
        }
        catch(SQLException e) {
            e.printStackTrace();
        }
        finally {
            connection.close();
        }
    }
}
