using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Model
{
    public class Phone
    {
        private string number;
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        private Employee owner;
        public Employee Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        private Unit unit;
        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private Tariff tariff;
        public Tariff Tariff
        {
            get { return tariff; }
            set { tariff = value; }
        }

        private DataBase<Call> callLog;

        public Phone() {}

        public Phone(string num, Unit u)
        {
            number = num;
            unit = u;
            callLog = new DataBase<Call>();
            tariff = new Tariff();
        }

        public List<Call> showCallLog()
        {
            return callLog.Items;
        }

        public void registerCall(ref Call call)
        {
            callLog.Add(call);
        }

        public override string ToString()
        {
            return number;
        }
    }
}
