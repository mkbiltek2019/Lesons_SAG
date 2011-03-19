/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Business.Abstraction;

/**
 *
 * @author user
 */
public abstract class EntityBase implements IHaveIdentity {
    private int Id;

    public EntityBase(int Id) {
        this.Id = Id;
    }
    
    public int getId() {
        return Id;
    }
}
