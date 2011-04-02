/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Application;

import Business.BankAccount;
import Business.Customer;
import Business.Ticket;
import Business.TicketBookingSystem;
import Streams.WhitespaceFilterOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStream;
import java.io.Writer;
import java.text.MessageFormat;

/**
 *
 * @author user
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) 
            throws IOException, ClassNotFoundException {
//        Boo booINstance = new Boo();
//        ((IBar)booINstance).Do();
//
//        String testString = "test " + booINstance;
//
//        System.out.println(testString);
//        System.out.println(booINstance);
//
        BankAccount johnBankAccount = new BankAccount();
        Customer john = new Customer(johnBankAccount);
//
//        Ticket ticketToTheMoon = new Ticket(101);
//
//        Customer.Add(ticketToTheMoon);
//        Ticket.Add(john);
//
//        TicketBookingSystem ticketBookingSystem = new TicketBookingSystem();
//        ticketBookingSystem.BookTicket(john.getId(), ticketToTheMoon.getId());
//
//        System.out.println(MessageFormat.format("Ticket {0} bought by {1}",
//                john.getId(),
//                ticketToTheMoon.getId()));

        File file = new File("C:\\oopsanboxlog.txt");
        System.out.println("File path is absolute: " + file.isAbsolute());
        boolean createNewFile = file.createNewFile();
        //file.deleteOnExit();

//        WhitespaceFilterOutputStream wsFilterOutputStream =
//                new WhitespaceFilterOutputStream(writer);
//        wsFilterOutputStream.write(new byte[] {'a', 'b', ' ', 'c', 'd'});
//        wsFilterOutputStream.flush();
//        wsFilterOutputStream.close();
//        writer.close();

        OutputStream writer = new FileOutputStream(file);
        ObjectOutputStream serializerStream = new ObjectOutputStream(writer);
        serializerStream.writeObject(john);

        InputStream reader = new FileInputStream(file);
        ObjectInputStream serializerInputStream = new ObjectInputStream(reader);

        Customer deserializedJohn = (Customer) serializerInputStream.readObject();
        boolean bankAccountIsNull = deserializedJohn.getBankAccount() == null;
        boolean johnsAreNotEqual = john.equals(deserializedJohn);

        System.out.println("Bank account of deserialized John is null: " + bankAccountIsNull);
        System.out.println("John is not equal to deserializedJohn: " + johnsAreNotEqual);
    }
}