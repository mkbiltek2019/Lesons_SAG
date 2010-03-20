using System;

namespace Lesson_04
{
public class Human
{
    protected String fName;
    public String FirstName
    {
        get { return fName; }
        set { fName = value; }
    }

    protected String mName;
    public String MiddleName
    {
        get { return mName; }
        set { mName = value; }
    }

    protected String lName;
    public String LastName
    {
        get { return lName; }
        set { lName = value; }
    }

    protected DateTime birthday;
    public DateTime Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }


    public Human() { }
    public Human(String FirstName, String MiddleName, String LastName)
    {
        this.fName = FirstName;
        this.mName = MiddleName;
        this.lName = LastName;
    }

    public Human(String FirstName, String MiddleName, String LastName, DateTime Birthday)
    {
        this.fName = FirstName;
        this.mName = MiddleName;
        this.lName = LastName;
        this.birthday = Birthday;
    }

    public virtual void Work()
    {
        // Do something        
    }
}
}
