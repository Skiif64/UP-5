using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_3
{
   public class Employee
    {
        public uint Id { get;}
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Passport { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public Employee(uint id,string lastName,string firstName, string secondName,string passport, string phone, string email)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            SecondName = secondName;
            Passport = passport;
            PhoneNumber = phone;
            Email = email;
        }
        public Employee(string str)
        {
            string[] args = str.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Id = uint.Parse(args[0]);
            LastName = args[1];
            FirstName = args[2];
            SecondName = args[3];
            Passport = args[4];
            PhoneNumber = args[5];
            Email = args[6];
        }
    }
}
