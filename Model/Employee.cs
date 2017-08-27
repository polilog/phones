using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private string position;
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private Phone phone;
        public Phone Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private bool? sex;
        public bool? Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private DateTime birthdate;
        public DateTime BirthDate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        private Unit unit;
        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public Employee() {}

        public Employee(string nm, string sn, string pos, bool? s, DateTime bd, Unit u)
        {
            name = nm;
            surname = sn;
            position = pos;
            sex = s;
            birthdate = bd;
            unit = u;
        }

        public override string ToString()
        {
            string str = this.name + " " + this.surname;
            return str;
        }
    }
}
