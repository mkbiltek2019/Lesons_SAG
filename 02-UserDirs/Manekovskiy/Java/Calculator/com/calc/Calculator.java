package com.calc;

    import javax.ejb.EJBObject;
    import java.rmi.RemoteException;

    public interface Calculator extends EJBObject {
        public int summ(int a,int b) throws RemoteException;
    }
