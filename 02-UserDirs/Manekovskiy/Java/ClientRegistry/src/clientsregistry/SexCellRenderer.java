/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package clientsregistry;

import java.awt.Component;
import javax.swing.JTable;
import javax.swing.table.DefaultTableCellRenderer;

/**
 *
 * @author manekovskiy
 */
public class SexCellRenderer extends DefaultTableCellRenderer {

    @Override
    public Component getTableCellRendererComponent(
                JTable table,
                Object value,
                boolean isSelected,
                boolean hasFocus,
                int row,
                int column)
    {
        value = value.equals(0) ? "female" : "male";
 
        // And pass it on to parent class
        return super.getTableCellRendererComponent(
                table,
                value,
                isSelected,
                hasFocus,
                row,
                column);
    }
}
