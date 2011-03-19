/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Business;

import DataAccess.ActiveRecord;

/**
 *
 * @author user
 */
public class Customer extends ActiveRecord {
    private BankAccount bankAccount;

    public Customer(BankAccount bankAccount) {
        this.bankAccount = bankAccount;
    }

    /**
     * @return the BankAccount
     */
    public BankAccount getBankAccount() {
        return bankAccount;
    }

    /**
     * @param BankAccount the BankAccount to set
     */
    public void setBankAccount(BankAccount BankAccount) {
        this.bankAccount = BankAccount;
    }
}