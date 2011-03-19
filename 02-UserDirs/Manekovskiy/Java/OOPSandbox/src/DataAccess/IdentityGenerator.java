/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package DataAccess;

/**
 *
 * @author user
 */
public class IdentityGenerator {
    private static int counter = 0;

    public static int GetId()
    {
        return counter++;
    }
}
