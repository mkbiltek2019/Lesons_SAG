/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Business.Abstraction;

import java.io.Serializable;

/**
 *
 * @author user
 */
public abstract class EntityBase implements IHaveIdentity, Serializable {
    private int Id;

    public EntityBase()
    {
        
    }

    public EntityBase(int Id) {
        this.Id = Id;
    }
    
    public int getId() {
        return Id;
    }
}
