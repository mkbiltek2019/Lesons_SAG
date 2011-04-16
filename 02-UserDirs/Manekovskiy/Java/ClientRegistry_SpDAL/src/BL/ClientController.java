/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package BL;

import DAL.ClientDataProvider;
import Entities.Client;
import java.util.List;

/**
 *
 * @author manekovskiy
 */
public class ClientController {

    private ClientDataProvider dataProvider;

    public ClientController() {
        dataProvider = new ClientDataProvider();
    }

    public List<Client> GetAll() {
        return dataProvider.GetAll();
    }

    public void Delete(Client client) {
        dataProvider.Delete(client);
    }

    public Integer Save(Client client) {
        Integer result;
        if(client.getId() == null) {
            result = dataProvider.Insert(client);
        }
        else {
            result = dataProvider.Update(client);
        }

        return result;
    }

    public Client GetById(Integer id) {
        return dataProvider.GetById(id);
    }
}