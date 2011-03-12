package HelloJavaWorld;

import java.io.IOException;
import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Vector;

/**
 *
 * @author user
 */
public class Program {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
        final int bufferSize;

        bufferSize = 6;

        System.out.println("Hello Java World");
        byte[] bytes = new byte[bufferSize];
        int bytesCount = System.in.read(bytes);

        String readString = new String(bytes);
        readString = readString.substring(0, bytesCount - 1);

        System.out.format("Read Bytes: %d\n",bytesCount);
        System.out.format("Read String: %s\n",readString);
        
        String formattedString = MessageFormat.format("MessageFormat.format() works like .NET string.Format()\nString is {0}", readString);
        System.out.println(formattedString);

        // String.class in java == typeof(string) in .NET
        // readString.getClass() in java == readString.GetType() in .NET

        StringBuilder stringBuilder = new StringBuilder();

        String left = "left string";
        String right = "right string";

        String concatenatedString = left + right;
        String concatenatedString2 = stringBuilder
                .append(left)
                .append(right)
                .toString();

        System.out.println(MessageFormat.format("concatenatedString2 = {0}", concatenatedString2));

        // List is used only for reference types!
        // List<T> is interface!
        List<String> stringList = new ArrayList<String>();
        stringList.add(left);
        stringList.add(right);
        stringList.add(concatenatedString);
        
        System.out.println("stringList:");
        for (Iterator<String> iterator = stringList.iterator(); iterator.hasNext();) {
            String current = iterator.next();
            System.out.println(current);
        }
    }
}
