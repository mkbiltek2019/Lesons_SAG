/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Entities;

/**
 *
 * @author manekovskiy
 */
public class EntityBase {
    private Integer id;

    public EntityBase(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }

    public setId(int id) {
        this.id = id;
    }
}
