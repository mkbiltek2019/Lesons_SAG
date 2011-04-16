/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package clientregistry_spdal;

import BL.ClientController;
import Entities.Client;
import Entities.Gender;
import java.util.List;

/**
 *
 * @author manekovskiy
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // Setup
        ClientController controller = new ClientController();
        List<Client> allClientsToDelete = controller.GetAll();
        for(Client client: allClientsToDelete) {
            controller.Delete(client);
        }

        // save (insert)
        Client john = new Client();
        john.setFirstName("John");
        john.setSecondName("Foo");
        john.setGender(Gender.Male);
        john.setAge(135);
        
        Integer id = controller.Save(john);

        assert id != null;

        // getById
        Client fetchetJohn = controller.GetById(id);

        assert fetchetJohn != null;
        assert john.getFirstName() == fetchetJohn.getFirstName();
        assert john.getSecondName() == fetchetJohn.getSecondName();
        assert john.getGender() == fetchetJohn.getGender();
        assert john.getAge() == fetchetJohn.getAge();

        // save (update)
        fetchetJohn.setFirstName("Martha");
        fetchetJohn.setGender(Gender.Female);

        controller.Save(fetchetJohn);

        List<Client> allClients = controller.GetAll();
        assert allClients.size() == 2;
    }
}