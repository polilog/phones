using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tariff
    {
        private int internalCost;
        public int InternalCost
        {
            get { return internalCost; }
            set { internalCost = value; }
        }

        private int externalCost;
        public int ExternalCost
        {
            get { return externalCost; }
            set { externalCost = value; }
        }

        public Tariff()
        {
            Random rand = new Random();
            internalCost = rand.Next(4);
            externalCost = rand.Next(15);
        }

        public Tariff(int inC, int exC)
        {
            internalCost = inC;
            externalCost = exC;
        }
    }
}
