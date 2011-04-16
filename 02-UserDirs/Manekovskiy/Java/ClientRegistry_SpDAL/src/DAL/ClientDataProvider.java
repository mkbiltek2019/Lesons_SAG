/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package DAL;

import Entities.Client;
import Entities.Gender;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author manekovskiy
 */
public class ClientDataProvider {

    // Stored procedures names
    private final String sp_delete = "EXECUTE [Client.Delete] ?";
    private final String sp_insert = "EXECUTE [Client.Insert] ?, ?, ?, ?";
    private final String sp_update = "EXECUTE [Client.Update] ?, ?, ?, ?";
    private final String sp_getbyid = "EXECUTE [Client.GetById] ?";
    private final String sp_getall = "EXECUTE [Client.GetAll]";

    // Column names
    private final String fn_id = "id";
    private final String fn_firstName = "FirstName";
    private final String fn_secondName = "SecondName";
    private final String fn_gender = "Gender"; 
    private final String fn_age = "Age";

    public List<Client> GetAll() throws ClassNotFoundException, SQLException {
        List<Client> result = new ArrayList<Client>();
        Connection connection = null;
        try {
            connection = DbConnectionProvider.GetConnection();

            CallableStatement getAll = connection.prepareCall(sp_getall);
            ResultSet selectResult = getAll.executeQuery();

            while (selectResult.next()) {
                Client client = new Client();
                client.setId(selectResult.getInt(this.fn_id));
                client.setFirstName(selectResult.getString(this.fn_firstName));
                client.setSecondName(selectResult.getString(this.fn_secondName));
                client.setGenderBool(selectResult.getBoolean(this.fn_gender));
                client.setAge(selectResult.getInt(this.fn_age));

                result.add(client);
            }

            getAll.close();
        } catch(SQLException e) {
            // TODO: handle exceptions
        }
        finally {
            if(connection != null)
                connection.close();
        }

        return result;
    }

    public void Delete(Client client) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    public Integer Insert(Client client) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    public Integer Update(Client client) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    public Client GetById(Integer id) {
        throw new UnsupportedOperationException("Not yet implemented");
    }
}