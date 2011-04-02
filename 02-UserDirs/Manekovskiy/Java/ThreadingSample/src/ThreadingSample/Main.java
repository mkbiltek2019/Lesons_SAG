/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ThreadingSample;

import java.io.IOException;

/**
 *
 * @author manekovskiy
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
        MyCounterThread counterThread1 = new MyCounterThread("CounterThread 1");
        MyCounterThread counterThread2 = new MyCounterThread("CounterThread 2");

        counterThread1.start();
        counterThread2.start();

        int i = System.in.read();
        counterThread1.interrupt();
        counterThread2.interrupt();
    }

}
