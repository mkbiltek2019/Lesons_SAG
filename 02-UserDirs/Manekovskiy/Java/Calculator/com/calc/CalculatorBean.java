package com.calc;

    import java.rmi.RemoteException;
    import javax.ejb.SessionBean;
    import javax.ejb.SessionContext;

    public class CalculatorBean implements SessionBean{
        public int summ(int a,int b){
            return a*b;
        }

        public void ejbCreate(){}

        public void ejbPostCreate(){}

        public void ejbRemove(){}

        public void ejbActivate(){}

        public void ejbPassivate(){}

        public void setSessionContext(SessionContext sc){}
}