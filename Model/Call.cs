using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Call
    {
         public static decimal TotalAmount = 0;
         public static int TotalNumber = 0;
         private static Random rand = new Random();

         private Phone callingParty;
         public Phone CallingParty
         {
             get { return callingParty; }
             set { callingParty = value; }
         }

         private Phone calledParty;
         public Phone CalledParty
         {
             get { return calledParty; }
             set { calledParty = value; }
         }

         private decimal cost;
         public decimal Cost
         {
             get { return cost; }
             set { cost = value; }
         }

         private int length;
         public int Length
         {
             get { return length; }
             set { length = value; }
         }

         private DateTime callStart;
         public DateTime CallStart
         {
             get { return callStart; }
             set { callStart = value; }
         }

         public  Call() 
         {
             TotalNumber++;
         }

         public Call(Phone called, Phone calling)
         {
             calledParty = called;
             callingParty = calling;

             length = rand.Next(600);
             callStart = DateTime.Today.AddSeconds(-rand.Next(2592000));

             cost = calculateCost();

             TotalNumber++;
             TotalAmount += cost;
         }

         private decimal calculateCost()
         {
             if (calledParty.Tariff == callingParty.Tariff)
                 return callingParty.Tariff.InternalCost * length;
             else
                 return callingParty.Tariff.ExternalCost * length;
         }
    }
}
