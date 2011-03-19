/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Application;

import Business.BankAccount;
import Business.Customer;
import Business.Ticket;
import Business.TicketBookingSystem;
import java.text.MessageFormat;

/**
 *
 * @author user
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Boo booINstance = new Boo();
        String testString = "test " + booINstance;
        
        System.out.println(testString);
        System.out.println(booINstance);

        BankAccount johnBankAccount = new BankAccount();
        Customer john = new Customer(johnBankAccount);

        Ticket ticketToTheMoon = new Ticket(101);

        Customer.Add(ticketToTheMoon);
        Ticket.Add(john);

        TicketBookingSystem ticketBookingSystem = new TicketBookingSystem();
        ticketBookingSystem.BookTicket(john.getId(), ticketToTheMoon.getId());
        
        System.out.println(MessageFormat.format("Ticket {0} bought by {1}",
                john.getId(),
                ticketToTheMoon.getId()));
    }
}