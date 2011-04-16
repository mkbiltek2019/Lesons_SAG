/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Entities;

/**
 *
 * @author manekovskiy
 */
public class Client extends EntityBase {
    private String firstName;
    private String secondName;
    private int age;
    private Gender gender;

    public Client() {
        super(null);
    }

    /**
     * @return the firstName
     */
    public String getFirstName() {
        return firstName;
    }

    /**
     * @param firstName the firstName to set
     */
    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    /**
     * @return the secondName
     */
    public String getSecondName() {
        return secondName;
    }

    /**
     * @param secondName the secondName to set
     */
    public void setSecondName(String secondName) {
        this.secondName = secondName;
    }

    /**
     * @return the age
     */
    public int getAge() {
        return age;
    }

    /**
     * @param age the age to set
     */
    public void setAge(int age) {
        this.age = age;
    }

    /**
     * @return the gender
     */
    public Gender getGender() {
        return gender;
    }

    /**
     * @param gender the gender to set
     */
    public void setGenderBool(Boolean isMale) {
        this.gender = isMale ? Gender.Male : Gender.Female;
    }

    public void setGender(Gender gender) {
        this.gender = gender;
    }
}