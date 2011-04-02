/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Streams;

import java.io.FilterOutputStream;
import java.io.IOException;
import java.io.OutputStream;

/**
 *
 * @author manekovskiy
 */
public class WhitespaceFilterOutputStream extends FilterOutputStream {
    public WhitespaceFilterOutputStream(OutputStream outputStream) {
        super(outputStream);
    }
    
    @Override
    public void write(byte b[]) throws IOException {
        for(int i = 0; i < b.length; i++)
        {
            if(b[i] != 0x20)
            {
                write(b[i]);
            }
        }
    }
}
