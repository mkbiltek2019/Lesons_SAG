
import clienteditor.ClientEditor;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author manekovskiy
 */
public class Program {

    public void dbConnect(
            String db_connect_string,
            String db_userid,
            String db_password)
   {
      try {
         Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
         Connection conn = DriverManager.getConnection(db_connect_string,
                  db_userid, db_password);
         System.out.println("connected");
         Statement createStatement = conn.createStatement();
         String queryString = "select * from sysobjects where type='u'";
         ResultSet rs = createStatement.executeQuery(queryString);
         while (rs.next()) {
            System.out.println(rs.getString(1));
         }
      } catch (Exception e) {
         e.printStackTrace();
      }
   }

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        Program program = new Program();
         String connectionUrl = "jdbc:sqlserver://localhost:1433/SQLEXPRESS;" +
            "databaseName=AdventureWorks;integratedSecurity=true;";

        program.dbConnect("jdbc:sqlserver://localhost:1433;", "sa", "123456");

        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                javax.swing.JFrame frame = new javax.swing.JFrame("Client Editor");
                frame.setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
                frame.getContentPane().add(new ClientEditor());
                frame.pack();
                frame.setVisible(true);
            }
        });
    }
}
