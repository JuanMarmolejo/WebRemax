using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Person
/// </summary>
public abstract class Person
{
    private string vFirstName;
    private string vLastName;
    private DateTime vBirthDate;
    private String vPhoneNumber;
    private string vEmail;

    public Person()
    {
    }

    public Person(string vFirstName, string vLastName, DateTime vBirthDate, string vPhoneNumber, string vEmail)
    {
        this.FirstName = vFirstName;
        this.LastName = vLastName;
        this.BirthDate = vBirthDate;
        this.PhoneNumber = vPhoneNumber;
        this.Email = vEmail;
    }

    public string FirstName { get => vFirstName; set => vFirstName = value; }
    public string LastName { get => vLastName; set => vLastName = value; }
    public DateTime BirthDate { get => vBirthDate; set => vBirthDate = value; }
    public string PhoneNumber { get => vPhoneNumber; set => vPhoneNumber = value; }
    public string Email { get => vEmail; set => vEmail = value; }
    public string FullName { get => FirstName + " " + LastName; }
}