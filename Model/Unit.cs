using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Model
{
    public class Unit
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Employee head;
        public Employee Head
        {
            get { return head; }
            set { head = value; }
        }

        private DataBase<Employee> employeeList;
        private DataBase<Unit> unitList;
        private DataBase<Phone> phoneList;

        public List<Employee> getEmployeeList()
        {
            return employeeList.Items;
        }
        public List<Unit> getUnitList()
        {
            return unitList.Items;
        }
        public List<Phone> getPhoneList()
        {
            return phoneList.Items;
        }

        private int type;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public Unit()
        {
            unitList = new DataBase<Unit>();
            employeeList = new DataBase<Employee>();
            phoneList = new DataBase<Phone>();
        }

        public Unit(string nm, int t)
        {
            name = nm;
            type = t;
            unitList = new DataBase<Unit>();
            employeeList = new DataBase<Employee>();
            phoneList = new DataBase<Phone>();
        }

        public string TypeToString()
        {
            switch (type)
            {
                case 1: return "department";
                case 2: return "office";
                case 3: return "branch";
                default: return "company";
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            list.AddRange(employeeList.Items);
            foreach (Unit unit in unitList.Items)
            {
                list.AddRange(unit.getEmployeeList());
            }
            return list;
        }

        public List<Phone> GetAllPhones()
        {
            List<Phone> list = new List<Phone>();
            list.AddRange(phoneList.Items);
            foreach (Unit unit in unitList.Items)
            {
                list.AddRange(unit.getPhoneList());
            }
            return list;
        }

        public List<Unit> GetAllUnits()
        {
            List<Unit> list = new List<Unit>();
            list.AddRange(unitList.Items);
            foreach (Unit unit in unitList.Items)
            {
                list.AddRange(unit.getUnitList());
            }
            return list;
        }

        public void registerUnit(ref Unit unit)
        {
            unitList.Add(unit);
        }

        public void registerEmployee(ref Employee employee)
        {
            employeeList.Add(employee);
        }

        public void registerPhoneNumber(ref Phone phone)
        {
            phoneList.Add(phone);
        }

        public override string ToString()
        {
            return this.name;
        }
        
    }
}

