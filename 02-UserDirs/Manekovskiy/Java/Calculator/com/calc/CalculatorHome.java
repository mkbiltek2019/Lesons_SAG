package com.calc;

    import java.io.Serializable;
    import java.rmi.RemoteException;
    import javax.ejb.CreateException;
    import javax.ejb.EJBHome;

    public interface CalculatorHome extends EJBHome {
	    Calculator create() throws RemoteException, CreateException;
    }
