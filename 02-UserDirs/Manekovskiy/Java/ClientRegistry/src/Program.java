
import clientsregistry.ClientsRegistry;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author manekovskiy
 */
public class Program {
    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                javax.swing.JFrame frame = new javax.swing.JFrame("Client Registry");
                frame.setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
                frame.getContentPane().add(new ClientsRegistry());
                frame.pack();
                frame.setVisible(true);
            }
        });
    }
}
