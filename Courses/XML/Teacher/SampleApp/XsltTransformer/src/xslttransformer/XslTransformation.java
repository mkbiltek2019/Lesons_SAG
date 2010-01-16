/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package xslttransformer;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.StringReader;
import java.io.StringWriter;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerConfigurationException;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.stream.StreamResult;
import javax.xml.transform.stream.StreamSource;
/**
 *
 * @author Vova
 */
public class XslTransformation {

    private String xmlDocument = null;
    private String xslDocument = null;
    private String transformedDocument = null;

    private String loadTextFile(String fileName) throws FileNotFoundException, IOException {
        BufferedReader reader = new BufferedReader(new FileReader(fileName));
        try {
            StringBuffer buffer = new StringBuffer();
            String line = null;
            while ((line = reader.readLine()) != null) {
                buffer.append(line + "\n");
            }
            return buffer.toString();
        } finally {
            reader.close();
        }
    }

    public void loadXmlDocumentFromFile(String fileName) throws FileNotFoundException, IOException {
        xmlDocument = loadTextFile(fileName);
    }

    public void loadXslDocumentFromFile(String fileName) throws FileNotFoundException, IOException {
        xslDocument = loadTextFile(fileName);
    }

    public void transform() throws TransformerConfigurationException, TransformerException {
        TransformerFactory transformerFactory = TransformerFactory.newInstance();
        Transformer transformer = transformerFactory.newTransformer(new StreamSource(new StringReader(xslDocument)));
        StringWriter resultWriter = new StringWriter();
        transformer.transform(new StreamSource(new StringReader(xmlDocument)), new StreamResult(resultWriter));
        transformedDocument = resultWriter.toString();
    }

    public String getXmlDocument() {
        return xmlDocument;
    }

    public String getXslDocument() {
        return xslDocument;
    }

    public void setXmlDocument(String document) {
        xmlDocument = document;
    }

    public void setXslDocument(String document) {
        xslDocument = document;
    }

    public String getTransformedDocument() {
        return transformedDocument;
    }

}
