/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package gallery;

import java.beans.*;
import java.io.Serializable;

/**
 *
 * @author rasik
 */
public class GalleryController implements Serializable {

    private String[] images = new String[] { "AddressBook.png", "AddressBookBlue.png", "Airmail.png" };

    public GalleryController() {
    }

    /**
     * @return the images
     */
    public String[] getImages() {
        return images;
    }

    /**
     * @param images the images to set
     */
    public void setImages(String[] images) {
        this.images = images;
    }

    int currentImageIndex = 0;
    public String getNextImage() {
        if(currentImageIndex == images.length)
            currentImageIndex = 0;
        String result = images[currentImageIndex];
        currentImageIndex++;
        
        return result;
    }
}