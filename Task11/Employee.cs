using System;
using System.Collections.Generic;
using System.Text;

namespace Task11 {
    class Employee {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathersname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Employee() { }
        public Employee(string LastName, string FirstName, string PatronymicName, string PhoneNumber, string Address) {
            this.Surname = LastName;
            this.Name = FirstName;
            this.Fathersname = PatronymicName;
            this.Phone = PhoneNumber;
            this.Address = Address;
        }

        public override string ToString() {
            return $"*{Name}*{Surname}*{Fathersname}*{Phone}*{Address}*";
        }
    }
}
