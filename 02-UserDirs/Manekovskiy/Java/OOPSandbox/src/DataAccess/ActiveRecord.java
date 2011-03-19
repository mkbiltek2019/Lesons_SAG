/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/* This code is only for demostration purposes. Never use, never ever its bad, very bad! */

package DataAccess;

import Business.Abstraction.EntityBase;
import java.util.ArrayList;
import java.util.List;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

/**
 *
 * @author user
 */
public abstract class ActiveRecord extends EntityBase {
    static ArrayList<EntityBase> innerCollection;

    static {
        innerCollection = new ArrayList<EntityBase>();
    }

    protected ActiveRecord() {
        super(IdentityGenerator.GetId());
    }

    public static void Add(EntityBase entity) {
        innerCollection.add(entity);
    }

    public static EntityBase GetById(int Id) {
       EntityBase result = null;
       
       for(EntityBase entity: innerCollection)
       {
           if(entity.getId() == Id)
           {
               result = entity;
               break;
           }
       }
       
       return result;
    }
}