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
public class Ticket extends ActiveRecord {
    private Customer boughtBy;
    private double rentalPrice;

    public Ticket(double rentalPrice) {
        this.rentalPrice = rentalPrice;
    }

    /**
     * @return the BoughtBy
     */
    public Customer getBoughtBy() {
        return boughtBy;
    }

    /**
     * @param BoughtBy the BoughtBy to set
     */
    public void setBoughtBy(Customer BoughtBy) {
        this.boughtBy = BoughtBy;
    }

    /**
     * @return the RentalPrice
     */
    public double getRentalPrice() {
        return rentalPrice;
    }

    /**
     * @param RentalPrice the RentalPrice to set
     */
    public void setRentalPrice(double RentalPrice) {
        this.rentalPrice = RentalPrice;
    }
}
