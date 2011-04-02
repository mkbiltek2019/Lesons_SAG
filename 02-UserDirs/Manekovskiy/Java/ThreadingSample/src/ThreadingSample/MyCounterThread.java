/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package ThreadingSample;

import java.text.MessageFormat;

/**
 *
 * @author manekovskiy
 */
// also we can impement Runnable
public class MyCounterThread extends Thread {
    private byte counter = 0;
    
    public MyCounterThread(String name) {
        this.setName(name);
    }

    @Override
    public void run(){
        while(!interrupted())
            System.out.println(MessageFormat.format("Thread {0}: counter = {1}", this.getName(), counter++));
    }
}
