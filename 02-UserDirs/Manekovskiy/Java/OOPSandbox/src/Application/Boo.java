/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Application;

/**
 *
 * @author user
 */
public class Boo {
    @Override
    public String toString()
    {
        return  "Boo class instance";
    }

    @Override
    protected void finalize() throws Throwable
    {
        try
        {
            super.finalize();
        }
        catch(Throwable e)
        { }
    }
}
