using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module3_MVC.Models
{
    [Serializable]
    public class Person
    {
        public string LastName;
        public string FirstName;
        public DateTime BirthDay;

        public Person(string inLastName, string inFirstName, DateTime inBirthDate)
        {
            LastName = inLastName;
            FirstName = inFirstName;
            BirthDay = inBirthDate;
        }
    }
}