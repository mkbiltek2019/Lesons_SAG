/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Business;

/**
 *
 * @author user
 */
public class TicketBookingSystem {
    public void BookTicket(int customerId, int ticketId) {
        Customer customer = (Customer) Customer.GetById(customerId);
        Ticket ticket = (Ticket) Ticket.GetById(ticketId);

        ticket.setBoughtBy(customer);

        customer.getBankAccount()
                .setBallance(customer.getBankAccount().getBallance() - ticket.getRentalPrice());
    }
}
